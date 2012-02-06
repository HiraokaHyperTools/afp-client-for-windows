using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AFPClient4Windows {
    public partial class QueryOverwriteForm : Form {
        public QueryOverwriteForm() {
            InitializeComponent();
        }

        private void QueryOverwriteForm_Load(object sender, EventArgs e) {

        }

        private void bYes_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void bNo_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}