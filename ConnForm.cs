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
        public ConnForm(Conn conn) {
            this.conn = conn;

            InitializeComponent();
        }

        Conn conn;

        private void ConnForm_Load(object sender, EventArgs e) {
            if (conn == null) return;

            tbHost.DataBindings.Add("Text", conn, "Host");
            tbU.DataBindings.Add("Text", conn, "U");
            tbP.DataBindings.Add("Text", conn, "P");
            tbHostDir.DataBindings.Add("Text", conn, "HostDir");

            checkBox1.DataBindings.Add("Checked", conn, "AllowDHX2");
            checkBox2.DataBindings.Add("Checked", conn, "AllowDHCAST128");
            checkBox3.DataBindings.Add("Checked", conn, "AllowTwoWayRandNum");
            checkBox4.DataBindings.Add("Checked", conn, "AllowClearText");
            checkBox5.DataBindings.Add("Checked", conn, "AllowNoUserAuth");
        }

        private void bOk_Click(object sender, EventArgs e) {
            if (!ValidateChildren()) return;
        }
    }
}
