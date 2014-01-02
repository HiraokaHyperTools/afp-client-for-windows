using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AFPClient4Windows {
    public partial class RenForm : Form {
        public RenForm() {
            InitializeComponent();
        }

        public String fp1,fp2;

        private void bY_Click(object sender, EventArgs e) {
            fp1 = tb1.Text;
            fp2 = tb2.Text;
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void bN_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.No;
            Close();
        }

        private void bStop_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void RenForm_Load(object sender, EventArgs e) {

        }
    }
}