﻿using System;
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
    public partial class CheckPasswordForm : Form
    {
        public CheckPasswordForm()
        {
            InitializeComponent();
        }

        private void CheckPasswordForm_Load(object sender, EventArgs e)
        {
            useSHA3CheckBox.Checked = Properties.Settings.Default.UseSHA3Hashing;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (masterEntryTextBox.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please enter the password.", "Missing Password");
            }
            else
            {
                SQLiteDatabase database = new SQLiteDatabase();
                string storedHash = database.SelectHash();

                if (Properties.Settings.Default.UseSHA3Hashing)
                {
                    IHash hash = HashFactory.Crypto.SHA3.CreateKeccak512();
                    HashResult hashResult = hash.ComputeString(masterEntryTextBox.Text);

                    if (hashResult.ToString().Equals(storedHash))
                    {
                        // Put user's password in a secure string for later use
                        foreach (char c in masterEntryTextBox.Text)
                        {
                            SharedObject.encryptedPassword.AppendChar(c);
                        }

                        SharedObject.passwordGood = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Password is not valid.  Please try again.", "Invalid Password");
                    }
                }
                else
                {

                    if (PasswordHash.ValidatePassword(masterEntryTextBox.Text, storedHash))
                    {
                        // Put user's password in a secure string for later use
                        foreach (char c in masterEntryTextBox.Text)
                        {
                            SharedObject.encryptedPassword.AppendChar(c);
                        }

                        SharedObject.passwordGood = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Password is not valid.  Please try again.", "Invalid Password");
                    }
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
                showPasswordButton.Text = "&Hide Password";
            }
            // Turn on password hiding
            else
            {
                masterEntryTextBox.PasswordChar = '*';
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
