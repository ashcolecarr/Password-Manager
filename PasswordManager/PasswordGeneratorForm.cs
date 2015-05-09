using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace PasswordManager
{
    public partial class PasswordGeneratorForm : Form
    {
        bool userAlreadyClosing = false;
        
        public PasswordGeneratorForm()
        {
            InitializeComponent();
        }

        private void PasswordGeneratorForm_Load(object sender, EventArgs e)
        {
            // Set default value for the password length box
            passwordLengthComboBox.Text = "6";
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.Text.Length > 0)
            {
                if (MessageBox.Show("Generated password will overwrite the current credential's password.  Are you sure?", "Copying Password", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SharedObject.generatedPassword = passwordTextBox.Text;
                    // Bypass the form closing event since the user already pressed the cancel button
                    userAlreadyClosing = true;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Password field cannot be blank.", "Missing Password");
            }
        }
        
        private void cancelButton_Click(object sender, EventArgs e)
        {
            // Check if a password has been generated
            if (passwordTextBox.Text.Length > 0)
            {
                if (MessageBox.Show("Discard the generated password?  The password will not be saved.", "Cancel Password Copying", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Bypass the form closing event since the user already pressed the cancel button
                    userAlreadyClosing = true;
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void PasswordGeneratorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !userAlreadyClosing && passwordTextBox.Text.Length > 0)
            {
                if (MessageBox.Show("Are you sure you wish to close?  Generated password will not be saved.", "Form Closing", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (!includeLowercaseCheckBox.Checked && !includeUppercaseCheckBox.Checked && !includeNumberCheckBox.Checked && !includeSymbolCheckBox.Checked)
            {
                MessageBox.Show("Please choose at least one inclusion option.", "No Option Selected");
            }
            else
            {
                passwordTextBox.Text = GeneratePassword(Convert.ToInt32(passwordLengthComboBox.Text), includeLowercaseCheckBox.Checked, includeUppercaseCheckBox.Checked, includeNumberCheckBox.Checked, includeSymbolCheckBox.Checked);
                passwordTextBox.Enabled = true;
                okButton.Enabled = true;
            }
        }

        public string GeneratePassword(int length, bool lowercaseAllowed, bool uppercaseAllowed, bool numbersAllowed, bool symbolsAllowed)
        {
            // String constants for the character pool
            const string LOWERCASE = "abcdefghijklmnopqrstuvwxyz";
            const string UPPERCASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string NUMBERS = "0123456789";
            const string SYMBOLS = "(){}[]|`¬¦!?\"£$%^&*'<>:;#~_-+=,@\\/.";
            
            byte[] genValues = new byte[length];

            string characterPool;
            StringBuilder password = new StringBuilder();

            RNGCryptoServiceProvider randomGenerator = new RNGCryptoServiceProvider();

            if (lowercaseAllowed && uppercaseAllowed && numbersAllowed && symbolsAllowed)
            {
                characterPool = LOWERCASE + UPPERCASE + NUMBERS + SYMBOLS;
                randomGenerator.GetBytes(genValues);
                foreach (byte val in genValues)
                {
                    password.Append(characterPool[Convert.ToInt32(val) % characterPool.Length]);
                }
            }
            else if (lowercaseAllowed && uppercaseAllowed && numbersAllowed)
            {
                characterPool = LOWERCASE + UPPERCASE + NUMBERS;
                randomGenerator.GetBytes(genValues);
                foreach (byte val in genValues)
                {
                    password.Append(characterPool[Convert.ToInt32(val) % characterPool.Length]);
                }
            }
            else if (lowercaseAllowed && uppercaseAllowed && symbolsAllowed)
            {
                characterPool = LOWERCASE + UPPERCASE + SYMBOLS;
                randomGenerator.GetBytes(genValues);
                foreach (byte val in genValues)
                {
                    password.Append(characterPool[Convert.ToInt32(val) % characterPool.Length]);
                }
            }
            else if (lowercaseAllowed && numbersAllowed && symbolsAllowed)
            {
                characterPool = LOWERCASE + NUMBERS + SYMBOLS;
                randomGenerator.GetBytes(genValues);
                foreach (byte val in genValues)
                {
                    password.Append(characterPool[Convert.ToInt32(val) % characterPool.Length]);
                }
            }
            else if (uppercaseAllowed && numbersAllowed && symbolsAllowed)
            {
                characterPool = UPPERCASE + NUMBERS + SYMBOLS;
                randomGenerator.GetBytes(genValues);
                foreach (byte val in genValues)
                {
                    password.Append(characterPool[Convert.ToInt32(val) % characterPool.Length]);
                }
            }
            else if (lowercaseAllowed && uppercaseAllowed)
            {
                characterPool = LOWERCASE + UPPERCASE;
                randomGenerator.GetBytes(genValues);
                foreach (byte val in genValues)
                {
                    password.Append(characterPool[Convert.ToInt32(val) % characterPool.Length]);
                }
            }
            else if (lowercaseAllowed && numbersAllowed)
            {
                characterPool = LOWERCASE + NUMBERS;
                randomGenerator.GetBytes(genValues);
                foreach (byte val in genValues)
                {
                    password.Append(characterPool[Convert.ToInt32(val) % characterPool.Length]);
                }
            }
            else if (lowercaseAllowed && symbolsAllowed)
            {
                characterPool = LOWERCASE + SYMBOLS;
                randomGenerator.GetBytes(genValues);
                foreach (byte val in genValues)
                {
                    password.Append(characterPool[Convert.ToInt32(val) % characterPool.Length]);
                }
            }
            else if (uppercaseAllowed && numbersAllowed)
            {
                characterPool = UPPERCASE + NUMBERS;
                randomGenerator.GetBytes(genValues);
                foreach (byte val in genValues)
                {
                    password.Append(characterPool[Convert.ToInt32(val) % characterPool.Length]);
                }
            }
            else if (uppercaseAllowed && symbolsAllowed)
            {
                characterPool = UPPERCASE + SYMBOLS;
                randomGenerator.GetBytes(genValues);
                foreach (byte val in genValues)
                {
                    password.Append(characterPool[Convert.ToInt32(val) % characterPool.Length]);
                }
            }
            else if (numbersAllowed && symbolsAllowed)
            {
                characterPool = NUMBERS + SYMBOLS;
                randomGenerator.GetBytes(genValues);
                foreach (byte val in genValues)
                {
                    password.Append(characterPool[Convert.ToInt32(val) % characterPool.Length]);
                }
            }
            else if (lowercaseAllowed)
            {
                characterPool = LOWERCASE;
                randomGenerator.GetBytes(genValues);
                foreach (byte val in genValues)
                {
                    password.Append(characterPool[Convert.ToInt32(val) % characterPool.Length]);
                }
            }
            else if (uppercaseAllowed)
            {
                characterPool = UPPERCASE;
                randomGenerator.GetBytes(genValues);
                foreach (byte val in genValues)
                {
                    password.Append(characterPool[Convert.ToInt32(val) % characterPool.Length]);
                }
            }
            else if (numbersAllowed)
            {
                characterPool = NUMBERS;
                randomGenerator.GetBytes(genValues);
                foreach (byte val in genValues)
                {
                    password.Append(characterPool[Convert.ToInt32(val) % characterPool.Length]);
                }
            }
            else if (symbolsAllowed)
            {
                characterPool = SYMBOLS;
                randomGenerator.GetBytes(genValues);
                foreach (byte val in genValues)
                {
                    password.Append(characterPool[Convert.ToInt32(val) % characterPool.Length]);
                }
            }
            else
            {
                characterPool = LOWERCASE;
                randomGenerator.GetBytes(genValues);
                foreach (byte val in genValues)
                {
                    password.Append(characterPool[Convert.ToInt32(val) % characterPool.Length]);
                }
            }
            
            return password.ToString();
        }
    }
}
