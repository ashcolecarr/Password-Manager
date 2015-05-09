using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace PasswordManager
{
    public partial class MainForm : Form
    {
        private Credential internetCredential;
        private SQLiteDatabase database;
        private List<string> allNames;
        
        private const int MILLISECOND_CONVERTER = 1000;
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SharedObject.passwordGood = false;
            SharedObject.generatedPassword = "";
            SharedObject.newCredentialAdded = false;
            
            // Password file exists, so user is asked to enter password instead
            if (File.Exists(Properties.Settings.Default.DatabaseFilename))
            {
                CheckPasswordForm checkPasswordForm = new CheckPasswordForm();
                checkPasswordForm.ShowDialog();
                this.Hide();
            }
            // Show the password-entry form to the user if this is the user's first time
            else
            {
                NewPasswordForm newPasswordForm = new NewPasswordForm();
                newPasswordForm.ShowDialog();
                this.Hide();
            }

            // The password was good, so activate everything on the form
            if (SharedObject.passwordGood)
            {
                // Set idle watch
                Application.Idle += new EventHandler(Application_Idle);

                ActivateMainForm();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.Clear();
            }
            catch
            {
                // This catch is here to catch the ExternalException and prevent the program breaking if some other application happens to use the clipboard.
            }
            this.Close();
        }

        public void ActivateMainForm()
        {
            internetCredential = new Credential();
            if (database == null)
            {
                database = new SQLiteDatabase();
            }
            CredentialEncryption.DeriveKey();
            
            // Activate window controls                
            categoryTreeView.Visible = true;
            nameLabel.Visible = true;
            nameTextBox.Visible = true;
            usernameLabel.Visible = true;
            usernameTextBox.Visible = true;
            passwordLabel.Visible = true;
            passwordTextBox.Visible = true;
            urlLabel.Visible = true;
            urlTextBox.Visible = true;
            descriptionLabel.Visible = true;
            descriptionTextBox.Visible = true;
            searchTextBox.Visible = true;
            searchButton.Visible = true;
            
            // Activate menu controls
            openToolStripMenuItem.Enabled = false;
            closeToolStripMenuItem.Enabled = true;
            saveBackupAsToolStripMenuItem.Enabled = true;
            changeMasterPasswordToolStripMenuItem.Enabled = true;
            exportToolStripMenuItem.Enabled = true;
            lockToolStripMenuItem.Enabled = true;
            lockToolStripMenuItem.Text = "&Lock";
            addCredentialToolStripMenuItem.Enabled = true;
            editCredentialToolStripMenuItem.Enabled = true;
            deleteCredentialToolStripMenuItem.Enabled = true;
            copyUsernameToolStripMenuItem.Enabled = true;
            copyPasswordToolStripMenuItem.Enabled = true;
            hideUsernamePasswordToolStripMenuItem.Enabled = true;
            passwordGeneratorToolStripMenuItem.Enabled = true;
            goToWebsiteToolStripMenuItem.Enabled = true;
            optionsToolStripMenuItem.Enabled = true;
            
            // Populate treeview
            allNames = database.SelectCredentialNames();
            if (allNames != null)
            {
                foreach (string name in allNames)
                {
                    categoryTreeView.Nodes[0].Nodes.Add(name);
                }
                categoryTreeView.ExpandAll();
            }

            // Set all tooltips
            treeviewToolTip.SetToolTip(categoryTreeView, "Click on a credential record's name to go directly to that record.");
            searchToolTip.SetToolTip(searchButton, "Enter the name of a credential record to search for.");
            
            // Populate fields
            internetCredential = database.SelectFirstCredential();
            if (internetCredential != null)
            {
                if (internetCredential.name != null)
                {
                    idLabel.Text = internetCredential.id.ToString();
                    nameTextBox.Text = internetCredential.name;
                    usernameTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.username);
                    passwordTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.password);
                    urlTextBox.Text = internetCredential.url;
                    descriptionTextBox.Text = internetCredential.description;
                }
            }

        }

        public void DeactivateMainForm()
        {
            Application.Idle -= Application_Idle;
            
            // Deactivate window controls                
            categoryTreeView.Visible = false;
            nameLabel.Visible = false;
            nameTextBox.Visible = false;
            usernameLabel.Visible = false;
            usernameTextBox.Visible = false;
            passwordLabel.Visible = false;
            passwordTextBox.Visible = false;
            urlLabel.Visible = false;
            urlTextBox.Visible = false;
            descriptionLabel.Visible = false;
            descriptionTextBox.Visible = false;
            searchTextBox.Visible = false;
            searchButton.Visible = false;

            // Deactivate menu controls
            openToolStripMenuItem.Enabled = true;
            closeToolStripMenuItem.Enabled = false;
            addCredentialToolStripMenuItem.Enabled = false;
            saveBackupAsToolStripMenuItem.Enabled = false;
            changeMasterPasswordToolStripMenuItem.Enabled = false;
            exportToolStripMenuItem.Enabled = false;
            lockToolStripMenuItem.Text = "&Unlock";
            editCredentialToolStripMenuItem.Enabled = false;
            deleteCredentialToolStripMenuItem.Enabled = false;
            copyUsernameToolStripMenuItem.Enabled = false;
            copyPasswordToolStripMenuItem.Enabled = false;
            hideUsernamePasswordToolStripMenuItem.Enabled = false;
            passwordGeneratorToolStripMenuItem.Enabled = false;
            goToWebsiteToolStripMenuItem.Enabled = false;
            optionsToolStripMenuItem.Enabled = false;

            // Depopulate treeview
            categoryTreeView.Nodes[0].Nodes.Clear();
            
            // Depopulate fields
            idLabel.Text = "";
            nameTextBox.Text = "";
            usernameTextBox.Text = "";
            passwordTextBox.Text = "";
            urlTextBox.Text = "";
            descriptionTextBox.Text = "";
        }

        private void addCredentialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCredentialForm addCredentialForm = new AddCredentialForm();
            addCredentialForm.ShowDialog();
        }

        private void hideUsernamePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Turn off password hiding
            if (usernameTextBox.PasswordChar.Equals('*'))
            {
                // Use \0 as "empty" character to clear the password character
                usernameTextBox.PasswordChar = '\0';
                passwordTextBox.PasswordChar = '\0';
                hideUsernamePasswordToolStripMenuItem.Checked = false;
            }
            // Turn on password hiding
            else
            {
                usernameTextBox.PasswordChar = '*';
                passwordTextBox.PasswordChar = '*';
                hideUsernamePasswordToolStripMenuItem.Checked = true;
            }
        }

        private void editCredentialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Length > 0)
            {
                internetCredential.id = Convert.ToInt32(idLabel.Text);
                internetCredential.name = nameTextBox.Text;
                usernameTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.username);
                passwordTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.password);
                internetCredential.url = urlTextBox.Text;
                internetCredential.description = descriptionTextBox.Text;

                EditCredentialForm editCredentialForm = new EditCredentialForm(internetCredential);
                editCredentialForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No credential exists to be edited.", "No Credential");
            }
        }

        private void deleteCredentialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Length > 0)
            {
                if (MessageBox.Show("Do you wish to delete this credential?\nThis data cannot be recovered once it is deleted.", "Delete Credential", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    database.DeleteInternetCredential(Convert.ToInt32(idLabel.Text));

                    // Depopulate treeview and then repopuate it with the new record
                    categoryTreeView.Nodes[0].Nodes.Clear();
                    allNames = database.SelectCredentialNames();
                    if (allNames != null)
                    {
                        foreach (string name in allNames)
                        {
                            categoryTreeView.Nodes[0].Nodes.Add(name);
                        }
                        categoryTreeView.ExpandAll();
                    }
                    
                    // Populate fields
                    internetCredential = database.SelectFirstCredential();
                    if (internetCredential != null)
                    {
                        if (internetCredential.name != null)
                        {
                            idLabel.Text = internetCredential.id.ToString();
                            nameTextBox.Text = internetCredential.name;
                            usernameTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.username);
                            passwordTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.password);
                            urlTextBox.Text = internetCredential.url;
                            descriptionTextBox.Text = internetCredential.description;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No credential exists to be deleted.", "No Credential");
            }
        }

        private void copyUsernameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(usernameTextBox.Text);

            // Set timer after clipboard is filled
            clipboardClearTimer.Interval = Properties.Settings.Default.ClipboardClearTime;
            clipboardClearTimer.Enabled = true;

            clipboardClearTimer.Start();
        }

        private void copyPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(passwordTextBox.Text);

            // Set timer after clipboard is filled
            clipboardClearTimer.Interval = Properties.Settings.Default.ClipboardClearTime;
            clipboardClearTimer.Enabled = true;

            clipboardClearTimer.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Detach idle event to avoid memory leaks
            Application.Idle -= Application_Idle;
            
            try
            {
                Clipboard.Clear();
            }
            catch
            {
                // This catch is here to catch the ExternalException and prevent the program breaking if some other application happens to use the clipboard.
            }

            /*if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Are you sure you wish to close?  Credential data will not be saved.", "Form Closing", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    try
                    {
                        Clipboard.Clear();
                    }
                    catch (Exception ex)
                    {
                        // This catch is here to catch the ExternalException and prevent the program breaking if some other application happens to use the clipboard.
                    }
                    e.Cancel = true;
                }
            }*/
        }

        private void categoryTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Equals(categoryTreeView.Nodes[0]))
            {
                // Don't do anything if the root element was clicked
            }
            else
            {
                // Get the text of the child node that has been clicked
                internetCredential = database.SelectCredentialByName(e.Node.Text);
                
                if (internetCredential != null)
                {
                    if (internetCredential.name != null)
                    {
                        idLabel.Text = internetCredential.id.ToString();
                        nameTextBox.Text = internetCredential.name;
                        usernameTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.username);
                        passwordTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.password);
                        urlTextBox.Text = internetCredential.url;
                        descriptionTextBox.Text = internetCredential.description;
                    }
                }
            }
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            internetCredential = database.SelectInternetCredential(Convert.ToInt32(idLabel.Text) - 1);
            if (internetCredential != null)
            {
                if (internetCredential.name != null)
                {
                    idLabel.Text = internetCredential.id.ToString();
                    nameTextBox.Text = internetCredential.name;
                    usernameTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.username);
                    passwordTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.password);
                    urlTextBox.Text = internetCredential.url;
                    descriptionTextBox.Text = internetCredential.description;
                }
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            internetCredential = database.SelectInternetCredential(Convert.ToInt32(idLabel.Text) + 1);
            if (internetCredential != null)
            {
                if (internetCredential.name != null)
                {
                    idLabel.Text = internetCredential.id.ToString();
                    nameTextBox.Text = internetCredential.name;
                    usernameTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.username);
                    passwordTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.password);
                    urlTextBox.Text = internetCredential.url;
                    descriptionTextBox.Text = internetCredential.description;
                }
            }
        }

        private void idLabel_TextChanged(object sender, EventArgs e)
        {
            if (idLabel.Text.Length > 0)
            {
                /*if (Convert.ToInt32(idLabel.Text) == 1)
                {
                    // Reached the beginning of the records
                    previousButton.Enabled = false;
                    nextButton.Enabled = true;
                }
                else if (Convert.ToInt32(idLabel.Text) == database.CountCredentials())
                {
                    // Reached the end of the records
                    previousButton.Enabled = true;
                    nextButton.Enabled = false;
                }
                else
                {
                    previousButton.Enabled = true;
                    nextButton.Enabled = true;
                }*/
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (e.KeyCode == Keys.Left && !searchTextBox.Focused)
            {
                internetCredential = database.SelectInternetCredential(Convert.ToInt32(idLabel.Text) - 1);
                if (internetCredential != null)
                {
                    if (internetCredential.name != null)
                    {
                        idLabel.Text = internetCredential.id.ToString();
                        nameTextBox.Text = internetCredential.name;
                        usernameTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.username);
                        passwordTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.password);
                        urlTextBox.Text = internetCredential.url;
                        descriptionTextBox.Text = internetCredential.description;
                    }
                }
            }
            else if (e.KeyCode == Keys.Right && !searchTextBox.Focused)
            {
                internetCredential = database.SelectInternetCredential(Convert.ToInt32(idLabel.Text) + 1);
                if (internetCredential != null)
                {
                    if (internetCredential.name != null)
                    {
                        idLabel.Text = internetCredential.id.ToString();
                        nameTextBox.Text = internetCredential.name;
                        usernameTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.username);
                        passwordTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.password);
                        urlTextBox.Text = internetCredential.url;
                        descriptionTextBox.Text = internetCredential.description;
                    }
                }
            }*/
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to close?\nIf you want to access the database after closing, you will need to enter your master password again.", "Closing Database", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DeactivateMainForm();
                SharedObject.passwordGood = false;
                SharedObject.encryptedPassword.Clear();
            }
        }

        private void categoryTreeView_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (e.KeyCode == Keys.Left)
            {
                // Stop the control from registering the left key press
                e.Handled = true;    
            }
            else if (e.KeyCode == Keys.Right)
            {
                // Stop the control from registering the right key press
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (categoryTreeView.SelectedNode.Equals(categoryTreeView.Nodes[0]))
                {
                    // Don't do anything if the root element was selected
                }
                else
                {
                    // Get the text of the child node that has been selected
                    internetCredential = database.SelectCredentialByName(categoryTreeView.SelectedNode.Text);

                    if (internetCredential != null)
                    {
                        if (internetCredential.name != null)
                        {
                            idLabel.Text = internetCredential.id.ToString();
                            nameTextBox.Text = internetCredential.name;
                            usernameTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.username);
                            passwordTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.password); 
                            urlTextBox.Text = internetCredential.url;
                            descriptionTextBox.Text = internetCredential.description;
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (categoryTreeView.SelectedNode.Equals(categoryTreeView.Nodes[0]))
                {
                    // Don't do anything if the root element was selected
                }
                else
                {
                    // Get the text of the child node that has been selected
                    internetCredential = database.SelectCredentialByName(categoryTreeView.SelectedNode.Text);

                    if (internetCredential != null)
                    {
                        if (internetCredential.name != null)
                        {
                            idLabel.Text = internetCredential.id.ToString();
                            nameTextBox.Text = internetCredential.name;
                            usernameTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.username);
                            passwordTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.password);
                            urlTextBox.Text = internetCredential.url;
                            descriptionTextBox.Text = internetCredential.description;
                        }
                    }
                }
            }*/
        }

        private void categoryTreeView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                // Stop the control from registering the left key press
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                // Stop the control from registering the right key press
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (categoryTreeView.SelectedNode.Equals(categoryTreeView.Nodes[0]))
                {
                    // Don't do anything if the root element was selected
                }
                else
                {
                    // Get the text of the child node that has been selected
                    internetCredential = database.SelectCredentialByName(categoryTreeView.SelectedNode.Text);

                    if (internetCredential != null)
                    {
                        if (internetCredential.name != null)
                        {
                            idLabel.Text = internetCredential.id.ToString();
                            nameTextBox.Text = internetCredential.name;
                            usernameTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.username);
                            passwordTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.password);
                            urlTextBox.Text = internetCredential.url;
                            descriptionTextBox.Text = internetCredential.description;
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (categoryTreeView.SelectedNode.Equals(categoryTreeView.Nodes[0]))
                {
                    // Don't do anything if the root element was selected
                }
                else
                {
                    // Get the text of the child node that has been selected
                    internetCredential = database.SelectCredentialByName(categoryTreeView.SelectedNode.Text);

                    if (internetCredential != null)
                    {
                        if (internetCredential.name != null)
                        {
                            idLabel.Text = internetCredential.id.ToString();
                            nameTextBox.Text = internetCredential.name;
                            usernameTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.username);
                            passwordTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.password);
                            urlTextBox.Text = internetCredential.url;
                            descriptionTextBox.Text = internetCredential.description;
                        }
                    }
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                database = new SQLiteDatabase();
            }
            
            if (File.Exists(Properties.Settings.Default.DatabaseFilename))
            {
                if (MessageBox.Show("Are you sure you wish to create a new credential database?\nDoing so will delete the current database and ALL of its data!", "Make New Database", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    DeactivateMainForm();
                    database.DeleteDatabase();

                    NewPasswordForm newPasswordForm = new NewPasswordForm();
                    newPasswordForm.ShowDialog();

                    // Rederive key after getting new password from user
                    CredentialEncryption.DeriveKey();

                    ActivateMainForm();
                }
            }
            else
            {
                NewPasswordForm newPasswordForm = new NewPasswordForm();
                newPasswordForm.ShowDialog();

                ActivateMainForm();
            }
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            Application.Idle += new EventHandler(Application_Idle);
            
            // Place the generated password into the password field when the users confirms copying it in the password generator
            if (SharedObject.generatedPassword.Length > 0)
            {
                passwordTextBox.Text = SharedObject.generatedPassword;
                SharedObject.generatedPassword = "";

                internetCredential.id = Convert.ToInt32(idLabel.Text);
                internetCredential.name = nameTextBox.Text;
                internetCredential.username = CredentialEncryption.EncryptCredential(usernameTextBox.Text);
                internetCredential.password = CredentialEncryption.EncryptCredential(passwordTextBox.Text);
                internetCredential.url = urlTextBox.Text;
                internetCredential.description = descriptionTextBox.Text;

                database.UpdateInternetCredential(internetCredential, internetCredential.id);
            }
            else if (SharedObject.newCredentialAdded)
            {
                SharedObject.newCredentialAdded = false;

                // Depopulate treeview and then repopuate it with the new record
                categoryTreeView.Nodes[0].Nodes.Clear();
                allNames = database.SelectCredentialNames();
                if (allNames != null)
                {
                    foreach (string name in allNames)
                    {
                        categoryTreeView.Nodes[0].Nodes.Add(name);
                    }
                    categoryTreeView.ExpandAll();
                }
                
                // Show the recently added record to the user
                internetCredential = database.SelectInternetCredential(database.CountCredentials());
                if (internetCredential != null)
                {
                    if (internetCredential.name != null)
                    {
                        idLabel.Text = internetCredential.id.ToString();
                        nameTextBox.Text = internetCredential.name;
                        usernameTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.username);
                        passwordTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.password);
                        urlTextBox.Text = internetCredential.url;
                        descriptionTextBox.Text = internetCredential.description;
                    }
                }
            }
        }

        private void goToWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(urlTextBox.Text.Length > 0)
            {
                string url = urlTextBox.Text;

                try
                {
                    Process.Start(url);
                }
                catch (Win32Exception ex)
                {
                    if (ex.ErrorCode == -2147467259)
                    {
                        MessageBox.Show("URL does not appear to be valid.", "Invalid URL");
                    }
                }
                catch /*(FileNotFoundException ex)*/
                {
                    MessageBox.Show("URL does not appear to be valid.", "Invalid URL");
                }
            }
            else
            {
                MessageBox.Show("URL is blank.  Please enter a URL.", "Missing URL");
            }
        }

        private void passwordGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasswordGeneratorForm passwordGeneratorForm = new PasswordGeneratorForm();
            passwordGeneratorForm.ShowDialog();
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.LockOnIdle)
            {
                // Set (or reset) timer every time the program goes idle
                idleTimer.Interval = Properties.Settings.Default.LockOnIdleTime;
                idleTimer.Enabled = true;

                idleTimer.Start();
                // Detach idle event 
                //Application.Idle -= Application_Idle;
            }
        }

        private void idleTimer_Tick(object sender, EventArgs e)
        {
            // Lock out the main form after X minutes of user inactivity, but only if main form is active
            if (this == Form.ActiveForm)
            {
                idleTimer.Stop();
                idleTimer.Enabled = false;
                LockMainForm();
            }
            else
            {
                idleTimer.Stop();
                idleTimer.Start();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckPasswordForm checkPasswordForm = new CheckPasswordForm();
            checkPasswordForm.ShowDialog();

            if (SharedObject.passwordGood)
            {
                ActivateMainForm();
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm optionsForm = new OptionsForm();
            optionsForm.ShowDialog();
        }

        private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backupSaveFileDialog.ShowDialog();
        }

        private void clipboardClearTimer_Tick(object sender, EventArgs e)
        {
            clipboardClearTimer.Stop();
            clipboardClearTimer.Enabled = false;

            // Clear clipboard after the timer runs out
            try
            {
                Clipboard.Clear();
            }
            catch
            {
                // This catch is here to catch the ExternalException and prevent the program breaking if some other application happens to use the clipboard.
            }
        }

        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!alwaysOnTopToolStripMenuItem.Checked)
            {
                this.TopMost = true;
                   alwaysOnTopToolStripMenuItem.Checked = true;
            }
            else if (alwaysOnTopToolStripMenuItem.Checked)
            {
                this.TopMost = false;
                alwaysOnTopToolStripMenuItem.Checked = false;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainAboutBox mainAboutBox = new MainAboutBox();
            mainAboutBox.ShowDialog();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (searchTextBox.Text.Length > 0)
            {
                internetCredential = database.SearchCredentialByName(searchTextBox.Text);
                if (internetCredential != null)
                {
                    if (internetCredential.name != null)
                    {
                        idLabel.Text = internetCredential.id.ToString();
                        nameTextBox.Text = internetCredential.name;
                        usernameTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.username);
                        passwordTextBox.Text = CredentialEncryption.DecryptCredential(internetCredential.password);
                        urlTextBox.Text = internetCredential.url;
                        descriptionTextBox.Text = internetCredential.description;
                    }
                }
                else
                {
                    MessageBox.Show("No result found.", "No Results");
                }
            }
            else
            {
                MessageBox.Show("Search field cannot be empty.", "Missing Search Text");
            }
        }

        private void changeMasterPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm = new ChangePasswordForm();
            changePasswordForm.ShowDialog();
        }

        private void lockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lockToolStripMenuItem.Text.Equals("&Lock"))
            {
                LockMainForm();
            }
            else
            {
                UnlockMainForm();
            }
        }

        public void LockMainForm()
        {
            DeactivateMainForm();
            SharedObject.passwordGood = false;
            SharedObject.encryptedPassword.Clear();

            this.Text = "Password Manager (Locked)";
            lockToolStripMenuItem.Text = "&Unlock";

            CheckPasswordForm checkPasswordForm = new CheckPasswordForm();
            checkPasswordForm.ShowDialog();

            if (SharedObject.passwordGood)
            {
                this.Text = "Password Manager";
                lockToolStripMenuItem.Text = "&Lock";

                ActivateMainForm();
            }
        }

        public void UnlockMainForm()
        {
            CheckPasswordForm checkPasswordForm = new CheckPasswordForm();
            checkPasswordForm.ShowDialog();

            if (SharedObject.passwordGood)
            {
                this.Text = "Password Manager";
                lockToolStripMenuItem.Text = "&Lock";

                ActivateMainForm();
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Credential> allCredentials;
            Stream stream;
            StreamWriter streamWriter;
            
            if (exportSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                allCredentials = database.SelectAllCredentials();

                stream = (Stream)exportSaveFileDialog.OpenFile();
                streamWriter = new StreamWriter(stream);

                // Write the full credential record to the file
                foreach (Credential internetCredential in allCredentials)
                {
                    streamWriter.WriteLine("Name: " + internetCredential.name + "\r\nUsername: " + CredentialEncryption.DecryptCredential(internetCredential.username)
                        + "\r\nPassword: " + CredentialEncryption.DecryptCredential(internetCredential.password) + "\r\nURL: " + internetCredential.url
                        + "\r\nDescription: " + internetCredential.description + "\r\n");
                }

                streamWriter.Close();
                stream.Close();
            }
        }

        private void saveBackupAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backupSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.Copy(Properties.Settings.Default.DatabaseFilename, backupSaveFileDialog.FileName);
            }
        }
    }
}
