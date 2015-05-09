namespace PasswordManager
{
    partial class PasswordGeneratorForm
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
            this.passwordLengthLabel = new System.Windows.Forms.Label();
            this.includeUppercaseCheckBox = new System.Windows.Forms.CheckBox();
            this.includeNumberCheckBox = new System.Windows.Forms.CheckBox();
            this.includeSymbolCheckBox = new System.Windows.Forms.CheckBox();
            this.passwordLengthComboBox = new System.Windows.Forms.ComboBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.includeLowercaseCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // passwordLengthLabel
            // 
            this.passwordLengthLabel.AutoSize = true;
            this.passwordLengthLabel.Location = new System.Drawing.Point(21, 23);
            this.passwordLengthLabel.Name = "passwordLengthLabel";
            this.passwordLengthLabel.Size = new System.Drawing.Size(92, 13);
            this.passwordLengthLabel.TabIndex = 0;
            this.passwordLengthLabel.Text = "Password Length:";
            // 
            // includeUppercaseCheckBox
            // 
            this.includeUppercaseCheckBox.AutoSize = true;
            this.includeUppercaseCheckBox.Checked = true;
            this.includeUppercaseCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeUppercaseCheckBox.Location = new System.Drawing.Point(21, 72);
            this.includeUppercaseCheckBox.Name = "includeUppercaseCheckBox";
            this.includeUppercaseCheckBox.Size = new System.Drawing.Size(116, 17);
            this.includeUppercaseCheckBox.TabIndex = 5;
            this.includeUppercaseCheckBox.Text = "Include Uppercase";
            this.includeUppercaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // includeNumberCheckBox
            // 
            this.includeNumberCheckBox.AutoSize = true;
            this.includeNumberCheckBox.Checked = true;
            this.includeNumberCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeNumberCheckBox.Location = new System.Drawing.Point(143, 47);
            this.includeNumberCheckBox.Name = "includeNumberCheckBox";
            this.includeNumberCheckBox.Size = new System.Drawing.Size(101, 17);
            this.includeNumberCheckBox.TabIndex = 6;
            this.includeNumberCheckBox.Text = "Include Number";
            this.includeNumberCheckBox.UseVisualStyleBackColor = true;
            // 
            // includeSymbolCheckBox
            // 
            this.includeSymbolCheckBox.AutoSize = true;
            this.includeSymbolCheckBox.Checked = true;
            this.includeSymbolCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeSymbolCheckBox.Location = new System.Drawing.Point(143, 71);
            this.includeSymbolCheckBox.Name = "includeSymbolCheckBox";
            this.includeSymbolCheckBox.Size = new System.Drawing.Size(98, 17);
            this.includeSymbolCheckBox.TabIndex = 7;
            this.includeSymbolCheckBox.Text = "Include Symbol";
            this.includeSymbolCheckBox.UseVisualStyleBackColor = true;
            // 
            // passwordLengthComboBox
            // 
            this.passwordLengthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.passwordLengthComboBox.FormattingEnabled = true;
            this.passwordLengthComboBox.Items.AddRange(new object[] {
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32"});
            this.passwordLengthComboBox.Location = new System.Drawing.Point(137, 20);
            this.passwordLengthComboBox.Name = "passwordLengthComboBox";
            this.passwordLengthComboBox.Size = new System.Drawing.Size(47, 21);
            this.passwordLengthComboBox.TabIndex = 8;
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(94, 95);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 10;
            this.generateButton.Text = "&Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(183, 167);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Enabled = false;
            this.okButton.Location = new System.Drawing.Point(94, 167);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 12;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Enabled = false;
            this.passwordTextBox.Location = new System.Drawing.Point(94, 132);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(269, 20);
            this.passwordTextBox.TabIndex = 13;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(21, 135);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 14;
            this.passwordLabel.Text = "Password:";
            // 
            // includeLowercaseCheckBox
            // 
            this.includeLowercaseCheckBox.AutoSize = true;
            this.includeLowercaseCheckBox.Checked = true;
            this.includeLowercaseCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeLowercaseCheckBox.Location = new System.Drawing.Point(21, 49);
            this.includeLowercaseCheckBox.Name = "includeLowercaseCheckBox";
            this.includeLowercaseCheckBox.Size = new System.Drawing.Size(116, 17);
            this.includeLowercaseCheckBox.TabIndex = 15;
            this.includeLowercaseCheckBox.Text = "Include Lowercase";
            this.includeLowercaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // PasswordGeneratorForm
            // 
            this.AcceptButton = this.generateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(371, 197);
            this.Controls.Add(this.includeLowercaseCheckBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.passwordLengthComboBox);
            this.Controls.Add(this.includeSymbolCheckBox);
            this.Controls.Add(this.includeNumberCheckBox);
            this.Controls.Add(this.includeUppercaseCheckBox);
            this.Controls.Add(this.passwordLengthLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordGeneratorForm";
            this.Text = "Password Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PasswordGeneratorForm_FormClosing);
            this.Load += new System.EventHandler(this.PasswordGeneratorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label passwordLengthLabel;
        private System.Windows.Forms.CheckBox includeUppercaseCheckBox;
        private System.Windows.Forms.CheckBox includeNumberCheckBox;
        private System.Windows.Forms.CheckBox includeSymbolCheckBox;
        private System.Windows.Forms.ComboBox passwordLengthComboBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.CheckBox includeLowercaseCheckBox;
    }
}