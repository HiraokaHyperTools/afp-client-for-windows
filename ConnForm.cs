using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AFPClient4Windows.Properties;

namespace AFPClient4Windows {
    public partial class ConnForm : Form {
        public ConnForm() {
            InitializeComponent();
        }

        private void bOk_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void bSave_Click(object sender, EventArgs e) {
            Settings.Default.Save();
            MessageBox.Show(this, "ï€ë∂ÇµÇ‹ÇµÇΩÅB", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
