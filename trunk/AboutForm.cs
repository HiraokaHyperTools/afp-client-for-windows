using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AFPClient4Windows.Properties;

namespace AFPClient4Windows {
    public partial class AboutForm : Form {
        public AboutForm() {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e) {
            rtb.LoadFile(new MemoryStream(Resources.About, false), RichTextBoxStreamType.RichText);

            int p = rtb.Find("(*)");
            if (p >= 0) {
                rtb.Select(p, 3);
                rtb.SelectedText = Application.ProductVersion;
                rtb.Select(0, 0);
            }
        }
    }
}