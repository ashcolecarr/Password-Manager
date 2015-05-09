﻿namespace PasswordManager
{
    partial class CheckPasswordForm
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
            this.showPasswordButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.masterEntryTextBox = new System.Windows.Forms.TextBox();
            this.masterEntryLabel = new System.Windows.Forms.Label();
            this.useSHA3CheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // showPasswordButton
            // 
            this.showPasswordButton.Location = new System.Drawing.Point(244, 48);
            this.showPasswordButton.Name = "showPasswordButton";
            this.showPasswordButton.Size = new System.Drawing.Size(99, 23);
            this.showPasswordButton.TabIndex = 1;
            this.showPasswordButton.Text = "&Show Password";
            this.showPasswordButton.UseVisualStyleBackColor = true;
            this.showPasswordButton.Click += new System.EventHandler(this.showPasswordButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(120, 86);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(38, 86);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // masterEntryTextBox
            // 
            this.masterEntryTextBox.Location = new System.Drawing.Point(15, 50);
            this.masterEntryTextBox.Name = "masterEntryTextBox";
            this.masterEntryTextBox.PasswordChar = '*';
            this.masterEntryTextBox.Size = new System.Drawing.Size(223, 20);
            this.masterEntryTextBox.TabIndex = 0;
            // 
            // masterEntryLabel
            // 
            this.masterEntryLabel.AutoSize = true;
            this.masterEntryLabel.Location = new System.Drawing.Point(15, 23);
            this.masterEntryLabel.Name = "masterEntryLabel";
            this.masterEntryLabel.Size = new System.Drawing.Size(119, 13);
            this.masterEntryLabel.TabIndex = 9;
            this.masterEntryLabel.Text = "Enter Master Password:";
            // 
            // useSHA3CheckBox
            // 
            this.useSHA3CheckBox.AutoSize = true;
            this.useSHA3CheckBox.Location = new System.Drawing.Point(216, 90);
            this.useSHA3CheckBox.Name = "useSHA3CheckBox";
            this.useSHA3CheckBox.Size = new System.Drawing.Size(118, 17);
            this.useSHA3CheckBox.TabIndex = 10;
            this.useSHA3CheckBox.Text = "Use SHA3 Hashing";
            this.useSHA3CheckBox.UseVisualStyleBackColor = true;
            this.useSHA3CheckBox.CheckedChanged += new System.EventHandler(this.useSHA3CheckBox_CheckedChanged);
            // 
            // CheckPasswordForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(357, 129);
            this.Controls.Add(this.useSHA3CheckBox);
            this.Controls.Add(this.masterEntryTextBox);
            this.Controls.Add(this.masterEntryLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.showPasswordButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckPasswordForm";
            this.Text = "Enter Master Password";
            this.Load += new System.EventHandler(this.CheckPasswordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button showPasswordButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox masterEntryTextBox;
        private System.Windows.Forms.Label masterEntryLabel;
        private System.Windows.Forms.CheckBox useSHA3CheckBox;
    }
}