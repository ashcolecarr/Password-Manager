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
    public partial class OptionsForm : Form
    {
        private const int MILLISECOND_CONVERTER = 1000;
        
        public OptionsForm()
        {
            InitializeComponent();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            idleTimeCheckBox.Checked = Properties.Settings.Default.LockOnIdle;

            // Enable and populate field if the program is set to lock on idle
            if (idleTimeCheckBox.Checked)
            {
                idleTimeNumericUpDown.Enabled = true;
                idleTimeNumericUpDown.Value = Properties.Settings.Default.LockOnIdleTime / MILLISECOND_CONVERTER;
            }
            else
            {
                idleTimeNumericUpDown.Enabled = false;
                idleTimeNumericUpDown.Value = idleTimeNumericUpDown.Minimum;
            }

            clipboardClearTimeNumericUpDown.Value = Properties.Settings.Default.ClipboardClearTime / MILLISECOND_CONVERTER;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (idleTimeCheckBox.Checked)
            {
                Properties.Settings.Default.LockOnIdle = true;
                Properties.Settings.Default.LockOnIdleTime = Convert.ToInt32(idleTimeNumericUpDown.Value * MILLISECOND_CONVERTER);
            }
            else
            {
                Properties.Settings.Default.LockOnIdle = false;
            }

            Properties.Settings.Default.ClipboardClearTime = Convert.ToInt32(clipboardClearTimeNumericUpDown.Value * MILLISECOND_CONVERTER);

            Properties.Settings.Default.Save();

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void idleTimeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (idleTimeCheckBox.Checked)
            {
                idleTimeNumericUpDown.Enabled = true;
            }
            else
            {
                idleTimeNumericUpDown.Enabled = false;
            }
        }
    }
}
