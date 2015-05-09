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
    public partial class AddCredentialForm : Form
    {
        private Credential internetCredential;
        private SQLiteDatabase database;
        private bool userAlreadyClosing = false;
        private CredentialEncryption encryptCredential;
        
        public AddCredentialForm()
        {
            InitializeComponent();
        }

        private void AddCredentialForm_Load(object sender, EventArgs e)
        {
            SharedObject.newCredentialAdded = false;
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
                if (MessageBox.Show("Add this credential to the database?", "Add New Credential", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    internetCredential = new Credential();
                    database = new SQLiteDatabase();
                    encryptCredential = new CredentialEncryption();

                    internetCredential.name = nameTextBox.Text;
                    internetCredential.username = CredentialEncryption.EncryptCredential(usernameTextBox.Text);
                    internetCredential.password = CredentialEncryption.EncryptCredential(passwordTextBox.Text);
                    internetCredential.url = urlTextBox.Text;
                    internetCredential.description = descriptionTextBox.Text;

                    database.InsertInternetCredential(internetCredential);

                    MessageBox.Show("Credential added to the database.", "Credential Added");
                    SharedObject.newCredentialAdded = true;
                    // Bypass the form closing event since the user already pressed the ok button
                    userAlreadyClosing = true;
                    this.Close();
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel adding new credential?", "Cancel Creating Credential", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                showCredentialButton.Text = "&Hide Credential";
            }
            // Turn on password hiding
            else
            {
                usernameTextBox.PasswordChar = '*';
                passwordTextBox.PasswordChar = '*';
                showCredentialButton.Text = "&Show Credential";
            }
        }

        private void AddCredentialForm_FormClosing(object sender, FormClosingEventArgs e)
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
