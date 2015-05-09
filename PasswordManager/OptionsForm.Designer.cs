namespace PasswordManager
{
    partial class OptionsForm
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
            this.idleTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.clipboardClearTimeLabel = new System.Windows.Forms.Label();
            this.idleTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.clipboardClearTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.idleTimeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clipboardClearTimeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // idleTimeCheckBox
            // 
            this.idleTimeCheckBox.AutoSize = true;
            this.idleTimeCheckBox.Location = new System.Drawing.Point(19, 26);
            this.idleTimeCheckBox.Name = "idleTimeCheckBox";
            this.idleTimeCheckBox.Size = new System.Drawing.Size(248, 17);
            this.idleTimeCheckBox.TabIndex = 2;
            this.idleTimeCheckBox.Text = "Enter number of seconds to idle before locking:";
            this.idleTimeCheckBox.UseVisualStyleBackColor = true;
            this.idleTimeCheckBox.CheckedChanged += new System.EventHandler(this.idleTimeCheckBox_CheckedChanged);
            // 
            // clipboardClearTimeLabel
            // 
            this.clipboardClearTimeLabel.AutoSize = true;
            this.clipboardClearTimeLabel.Location = new System.Drawing.Point(19, 67);
            this.clipboardClearTimeLabel.Name = "clipboardClearTimeLabel";
            this.clipboardClearTimeLabel.Size = new System.Drawing.Size(246, 13);
            this.clipboardClearTimeLabel.TabIndex = 4;
            this.clipboardClearTimeLabel.Text = "Time to wait before clearing clipboard (in seconds):";
            // 
            // idleTimeNumericUpDown
            // 
            this.idleTimeNumericUpDown.Location = new System.Drawing.Point(273, 26);
            this.idleTimeNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.idleTimeNumericUpDown.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.idleTimeNumericUpDown.Name = "idleTimeNumericUpDown";
            this.idleTimeNumericUpDown.Size = new System.Drawing.Size(81, 20);
            this.idleTimeNumericUpDown.TabIndex = 8;
            this.idleTimeNumericUpDown.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // clipboardClearTimeNumericUpDown
            // 
            this.clipboardClearTimeNumericUpDown.Location = new System.Drawing.Point(273, 65);
            this.clipboardClearTimeNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.clipboardClearTimeNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.clipboardClearTimeNumericUpDown.Name = "clipboardClearTimeNumericUpDown";
            this.clipboardClearTimeNumericUpDown.Size = new System.Drawing.Size(81, 20);
            this.clipboardClearTimeNumericUpDown.TabIndex = 9;
            this.clipboardClearTimeNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(113, 108);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(205, 108);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(380, 152);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.clipboardClearTimeNumericUpDown);
            this.Controls.Add(this.idleTimeNumericUpDown);
            this.Controls.Add(this.clipboardClearTimeLabel);
            this.Controls.Add(this.idleTimeCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.idleTimeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clipboardClearTimeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox idleTimeCheckBox;
        private System.Windows.Forms.Label clipboardClearTimeLabel;
        private System.Windows.Forms.NumericUpDown idleTimeNumericUpDown;
        private System.Windows.Forms.NumericUpDown clipboardClearTimeNumericUpDown;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}