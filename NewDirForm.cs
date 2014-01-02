using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AFPClient4Windows {
    public partial class NewDirForm : Form {
        public NewDirForm() {
            InitializeComponent();
        }

        public String fp1;

        private void button1_Click(object sender, EventArgs e) {
            fp1 = tb1.Text;
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}