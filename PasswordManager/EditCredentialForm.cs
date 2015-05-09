using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class EditCredentialForm : Form
    {
        private Credential internetCredential;
        private SQLiteDatabase database;
        private bool userAlreadyClosing = false;
        private CredentialEncryption encryptCredential;
        
        public EditCredentialForm()
        {
            InitializeComponent();
        }

        public EditCredentialForm(Credential credentialData)
        {
            internetCredential = credentialData;
            InitializeComponent();
        }

        private void EditCredentialForm_Load(object sender, EventArgs e)
        {
            encryptCredential = new CredentialEncryption();

            idLabel.Text = internetCredential.id.ToString();
            nameTextBox.Text = internetCredential.name;
            usernameTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.username);
            passwordTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.password);
            urlTextBox.Text = internetCredential.url;
            descriptionTextBox.Text = internetCredential.description;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Length < 1)
            {
                MessageBox.Show("Name cannot be blank.", "Missing Credential Name");
            }
            else if (usernameTextBox.Text.Length < 1)
            {
                MessageBox.Show("Username cannot be blank.", "Missing Credential Username");
            }
            else if (passwordTextBox.Text.Length < 1)
            {
                MessageBox.Show("Password cannot be blank.", "Missing Credential Password");
            }
            else
            {
                if (MessageBox.Show("Save changes to this credential?", "Save Credential Changes", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    database = new SQLiteDatabase();

                    internetCredential.name = nameTextBox.Text;
                    internetCredential.username = CredentialEncryption.EncryptCredential(usernameTextBox.Text);
                    internetCredential.password = CredentialEncryption.EncryptCredential(passwordTextBox.Text);
                    internetCredential.url = urlTextBox.Text;
                    internetCredential.description = descriptionTextBox.Text;

                    database.UpdateInternetCredential(internetCredential, internetCredential.id);

                    MessageBox.Show("New credential information saved.", "Changes Saved");
                    // Bypass the form closing event since the user already pressed the ok button
                    userAlreadyClosing = true;
                    this.Close();
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel editing credential?", "Cancel Editing Credential", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Bypass the form closing event since the user already pressed the cancel button
                userAlreadyClosing = true; 
                this.Close();
            }
        }

        private void showCredentialButton_Click(object sender, EventArgs e)
        {
            // Turn off password hiding
            if (usernameTextBox.PasswordChar.Equals('*'))
            {
                // Use \0 as "empty" character to clear the password character
                usernameTextBox.PasswordChar = '\0';
                passwordTextBox.PasswordChar = '\0';
                showCredentialButton.Text = "&Hide Password";
            }
            // Turn on password hiding
            else
            {
                usernameTextBox.PasswordChar = '*';
                passwordTextBox.PasswordChar = '*';
                showCredentialButton.Text = "&Show Password";
            }
        }

        private void EditCredentialForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !userAlreadyClosing)
            {
                if (MessageBox.Show("Are you sure you wish to close?  Credential data will not be saved.", "Form Closing", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
