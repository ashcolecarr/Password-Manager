using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HashLib;

namespace PasswordManager
{
    public partial class ChangePasswordForm : Form
    {
        private List<Credential> credentials;
        private SQLiteDatabase database;
        
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            useSHA3CheckBox.Checked = Properties.Settings.Default.UseSHA3Hashing;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (masterEntryTextBox.Text.Trim().Equals("") || masterConfirmTextBox.Text.Trim().Equals(""))
            {
                MessageBox.Show("Password fields cannot be blank.", "Missing Password");
            }
            else
            {
                if (masterEntryTextBox.Text.Equals(masterConfirmTextBox.Text))
                {
                    database = new SQLiteDatabase();
                    
                    credentials = database.SelectAllSecureCredentials();

                    // Decrypt all the usernames and passwords using the old key
                    for (int i = 0; i < credentials.Count; i++)
                    {
                        credentials[i].username = CredentialEncryption.DecryptCredential(credentials[i].username);
                        credentials[i].password = CredentialEncryption.DecryptCredential(credentials[i].password);
                    }

                    string hashString;
                    if (Properties.Settings.Default.UseSHA3Hashing)
                    {
                        IHash hash = HashFactory.Crypto.SHA3.CreateKeccak512();
                        HashResult hashResult = hash.ComputeString(masterEntryTextBox.Text);

                        hashString = hashResult.ToString();
                    }
                    else
                    {
                        hashString = PasswordHash.CreateHash(masterEntryTextBox.Text);
                    }

                    database.UpdateHash(hashString);

                    // Update salt?

                    // Put user's password in a secure string for later use
                    SharedObject.encryptedPassword.Clear();
                    foreach (char c in masterEntryTextBox.Text)
                    {
                        SharedObject.encryptedPassword.AppendChar(c);
                    }

                    // Re-encrypt all the usernames and password using the new key
                    CredentialEncryption.DeriveKey();
                    for (int i = 0; i < credentials.Count; i++)
                    {
                        credentials[i].username = CredentialEncryption.EncryptCredential(credentials[i].username);
                        credentials[i].password = CredentialEncryption.EncryptCredential(credentials[i].password);

                        database.UpdateSecureCredential(credentials[i], credentials[i].id);
                    }

                    // SharedObject.passwordGood = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Passwords do not match.", "Mismatched Passwords");
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showPasswordButton_Click(object sender, EventArgs e)
        {
            // Turn off password hiding
            if (masterEntryTextBox.PasswordChar.Equals('*'))
            {
                // Use \0 as "empty" character to clear the password character
                masterEntryTextBox.PasswordChar = '\0';
                masterConfirmTextBox.PasswordChar = '\0';
                showPasswordButton.Text = "&Hide Password";
            }
            // Turn on password hiding
            else
            {
                masterEntryTextBox.PasswordChar = '*';
                masterConfirmTextBox.PasswordChar = '*';
                showPasswordButton.Text = "&Show Password";
            }
        }

        private void useSHA3CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (useSHA3CheckBox.Checked)
            {
                Properties.Settings.Default.UseSHA3Hashing = useSHA3CheckBox.Checked;
            }
            else
            {
                Properties.Settings.Default.UseSHA3Hashing = useSHA3CheckBox.Checked;
            }

            Properties.Settings.Default.Save();
        }
    }
}
