namespace PasswordManager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Credential");
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveBackupAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.changeMasterPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.lockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCredentialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCredentialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCredentialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.copyUsernameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.hideUsernamePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passwordGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.goToWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryTreeView = new System.Windows.Forms.TreeView();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.urlLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.idleTimer = new System.Windows.Forms.Timer(this.components);
            this.backupSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.clipboardClearTimer = new System.Windows.Forms.Timer(this.components);
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.exportSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.nextToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.previousToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.searchToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.treeviewToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(641, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveBackupAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.changeMasterPasswordToolStripMenuItem,
            this.toolStripSeparator3,
            this.exportToolStripMenuItem,
            this.toolStripSeparator8,
            this.lockToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Enabled = false;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // saveBackupAsToolStripMenuItem
            // 
            this.saveBackupAsToolStripMenuItem.Enabled = false;
            this.saveBackupAsToolStripMenuItem.Name = "saveBackupAsToolStripMenuItem";
            this.saveBackupAsToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.saveBackupAsToolStripMenuItem.Text = "Save Backup &As...";
            this.saveBackupAsToolStripMenuItem.Click += new System.EventHandler(this.saveBackupAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(213, 6);
            // 
            // changeMasterPasswordToolStripMenuItem
            // 
            this.changeMasterPasswordToolStripMenuItem.Enabled = false;
            this.changeMasterPasswordToolStripMenuItem.Name = "changeMasterPasswordToolStripMenuItem";
            this.changeMasterPasswordToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.changeMasterPasswordToolStripMenuItem.Text = "Change &Master Password...";
            this.changeMasterPasswordToolStripMenuItem.Click += new System.EventHandler(this.changeMasterPasswordToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(213, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Enabled = false;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.exportToolStripMenuItem.Text = "&Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(213, 6);
            // 
            // lockToolStripMenuItem
            // 
            this.lockToolStripMenuItem.Enabled = false;
            this.lockToolStripMenuItem.Name = "lockToolStripMenuItem";
            this.lockToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.lockToolStripMenuItem.Text = "&Lock";
            this.lockToolStripMenuItem.Click += new System.EventHandler(this.lockToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCredentialToolStripMenuItem,
            this.editCredentialToolStripMenuItem,
            this.deleteCredentialToolStripMenuItem,
            this.toolStripSeparator4,
            this.copyUsernameToolStripMenuItem,
            this.copyPasswordToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // addCredentialToolStripMenuItem
            // 
            this.addCredentialToolStripMenuItem.Enabled = false;
            this.addCredentialToolStripMenuItem.Name = "addCredentialToolStripMenuItem";
            this.addCredentialToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.addCredentialToolStripMenuItem.Text = "&Add Credential...";
            this.addCredentialToolStripMenuItem.Click += new System.EventHandler(this.addCredentialToolStripMenuItem_Click);
            // 
            // editCredentialToolStripMenuItem
            // 
            this.editCredentialToolStripMenuItem.Enabled = false;
            this.editCredentialToolStripMenuItem.Name = "editCredentialToolStripMenuItem";
            this.editCredentialToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.editCredentialToolStripMenuItem.Text = "&Edit Credential...";
            this.editCredentialToolStripMenuItem.Click += new System.EventHandler(this.editCredentialToolStripMenuItem_Click);
            // 
            // deleteCredentialToolStripMenuItem
            // 
            this.deleteCredentialToolStripMenuItem.Enabled = false;
            this.deleteCredentialToolStripMenuItem.Name = "deleteCredentialToolStripMenuItem";
            this.deleteCredentialToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.deleteCredentialToolStripMenuItem.Text = "&Delete Credential";
            this.deleteCredentialToolStripMenuItem.Click += new System.EventHandler(this.deleteCredentialToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(161, 6);
            // 
            // copyUsernameToolStripMenuItem
            // 
            this.copyUsernameToolStripMenuItem.Enabled = false;
            this.copyUsernameToolStripMenuItem.Name = "copyUsernameToolStripMenuItem";
            this.copyUsernameToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.copyUsernameToolStripMenuItem.Text = "Copy &Username";
            this.copyUsernameToolStripMenuItem.Click += new System.EventHandler(this.copyUsernameToolStripMenuItem_Click);
            // 
            // copyPasswordToolStripMenuItem
            // 
            this.copyPasswordToolStripMenuItem.Enabled = false;
            this.copyPasswordToolStripMenuItem.Name = "copyPasswordToolStripMenuItem";
            this.copyPasswordToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.copyPasswordToolStripMenuItem.Text = "Copy &Password";
            this.copyPasswordToolStripMenuItem.Click += new System.EventHandler(this.copyPasswordToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alwaysOnTopToolStripMenuItem,
            this.toolStripSeparator5,
            this.hideUsernamePasswordToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.alwaysOnTopToolStripMenuItem.Text = "&Always on Top";
            this.alwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.alwaysOnTopToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(207, 6);
            // 
            // hideUsernamePasswordToolStripMenuItem
            // 
            this.hideUsernamePasswordToolStripMenuItem.Checked = true;
            this.hideUsernamePasswordToolStripMenuItem.CheckOnClick = true;
            this.hideUsernamePasswordToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hideUsernamePasswordToolStripMenuItem.Name = "hideUsernamePasswordToolStripMenuItem";
            this.hideUsernamePasswordToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.hideUsernamePasswordToolStripMenuItem.Text = "&Hide Username/Password";
            this.hideUsernamePasswordToolStripMenuItem.Click += new System.EventHandler(this.hideUsernamePasswordToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.passwordGeneratorToolStripMenuItem,
            this.toolStripSeparator6,
            this.goToWebsiteToolStripMenuItem,
            this.toolStripSeparator7,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // passwordGeneratorToolStripMenuItem
            // 
            this.passwordGeneratorToolStripMenuItem.Enabled = false;
            this.passwordGeneratorToolStripMenuItem.Name = "passwordGeneratorToolStripMenuItem";
            this.passwordGeneratorToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.passwordGeneratorToolStripMenuItem.Text = "Password &Generator...";
            this.passwordGeneratorToolStripMenuItem.Click += new System.EventHandler(this.passwordGeneratorToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(185, 6);
            // 
            // goToWebsiteToolStripMenuItem
            // 
            this.goToWebsiteToolStripMenuItem.Enabled = false;
            this.goToWebsiteToolStripMenuItem.Name = "goToWebsiteToolStripMenuItem";
            this.goToWebsiteToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.goToWebsiteToolStripMenuItem.Text = "Go to &Website";
            this.goToWebsiteToolStripMenuItem.Click += new System.EventHandler(this.goToWebsiteToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(185, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Enabled = false;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.optionsToolStripMenuItem.Text = "&Options...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // categoryTreeView
            // 
            this.categoryTreeView.Location = new System.Drawing.Point(13, 67);
            this.categoryTreeView.Name = "categoryTreeView";
            treeNode1.Name = "CredentialNode";
            treeNode1.Text = "Credential";
            this.categoryTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.categoryTreeView.Size = new System.Drawing.Size(210, 306);
            this.categoryTreeView.TabIndex = 1;
            this.categoryTreeView.Visible = false;
            this.categoryTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.categoryTreeView_NodeMouseClick);
            this.categoryTreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.categoryTreeView_KeyDown);
            this.categoryTreeView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.categoryTreeView_KeyUp);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Enabled = false;
            this.nameTextBox.Location = new System.Drawing.Point(310, 67);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(307, 20);
            this.nameTextBox.TabIndex = 2;
            this.nameTextBox.Visible = false;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Enabled = false;
            this.usernameTextBox.Location = new System.Drawing.Point(310, 103);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.PasswordChar = '*';
            this.usernameTextBox.Size = new System.Drawing.Size(307, 20);
            this.usernameTextBox.TabIndex = 3;
            this.usernameTextBox.Visible = false;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Enabled = false;
            this.passwordTextBox.Location = new System.Drawing.Point(310, 139);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(307, 20);
            this.passwordTextBox.TabIndex = 4;
            this.passwordTextBox.Visible = false;
            // 
            // urlTextBox
            // 
            this.urlTextBox.Enabled = false;
            this.urlTextBox.Location = new System.Drawing.Point(310, 175);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(307, 20);
            this.urlTextBox.TabIndex = 5;
            this.urlTextBox.Visible = false;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Enabled = false;
            this.descriptionTextBox.Location = new System.Drawing.Point(310, 211);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(307, 162);
            this.descriptionTextBox.TabIndex = 6;
            this.descriptionTextBox.Visible = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(241, 70);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 7;
            this.nameLabel.Text = "Name:";
            this.nameLabel.Visible = false;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(241, 106);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(58, 13);
            this.usernameLabel.TabIndex = 8;
            this.usernameLabel.Text = "Username:";
            this.usernameLabel.Visible = false;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(241, 142);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 9;
            this.passwordLabel.Text = "Password:";
            this.passwordLabel.Visible = false;
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(241, 178);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(32, 13);
            this.urlLabel.TabIndex = 10;
            this.urlLabel.Text = "URL:";
            this.urlLabel.Visible = false;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(241, 214);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.descriptionLabel.TabIndex = 11;
            this.descriptionLabel.Text = "Description:";
            this.descriptionLabel.Visible = false;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Enabled = false;
            this.idLabel.Location = new System.Drawing.Point(576, 39);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(0, 13);
            this.idLabel.TabIndex = 12;
            this.idLabel.Visible = false;
            this.idLabel.TextChanged += new System.EventHandler(this.idLabel_TextChanged);
            // 
            // idleTimer
            // 
            this.idleTimer.Tick += new System.EventHandler(this.idleTimer_Tick);
            // 
            // backupSaveFileDialog
            // 
            this.backupSaveFileDialog.DefaultExt = "bak";
            this.backupSaveFileDialog.FileName = "credentials.bak";
            this.backupSaveFileDialog.Filter = "Database File|*bak|All files|*.*";
            // 
            // clipboardClearTimer
            // 
            this.clipboardClearTimer.Tick += new System.EventHandler(this.clipboardClearTimer_Tick);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(244, 37);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(232, 20);
            this.searchTextBox.TabIndex = 15;
            this.searchTextBox.Visible = false;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(482, 34);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 16;
            this.searchButton.Text = "&Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Visible = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // exportSaveFileDialog
            // 
            this.exportSaveFileDialog.DefaultExt = "txt";
            this.exportSaveFileDialog.FileName = "credentials.txt";
            this.exportSaveFileDialog.Filter = "Text file|*.txt|All files|*.*";
            this.exportSaveFileDialog.RestoreDirectory = true;
            this.exportSaveFileDialog.Title = "Export Credentials to File";
            // 
            // MainForm
            // 
            this.AcceptButton = this.searchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 389);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.categoryTreeView);
            this.Controls.Add(this.mainMenuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Password Manager";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TreeView categoryTreeView;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem changeMasterPasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem addCredentialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editCredentialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCredentialToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem copyUsernameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyPasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem hideUsernamePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem passwordGeneratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem goToWebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Timer idleTimer;
        private System.Windows.Forms.SaveFileDialog backupSaveFileDialog;
        private System.Windows.Forms.Timer clipboardClearTimer;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem lockToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog exportSaveFileDialog;
        private System.Windows.Forms.ToolTip nextToolTip;
        private System.Windows.Forms.ToolTip previousToolTip;
        private System.Windows.Forms.ToolTip searchToolTip;
        private System.Windows.Forms.ToolTip treeviewToolTip;
        private System.Windows.Forms.ToolStripMenuItem saveBackupAsToolStripMenuItem;
    }
}

