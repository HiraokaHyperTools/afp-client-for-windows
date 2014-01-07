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
        public ConnForm(IHostParm hp) {
            this.hp = hp;
            InitializeComponent();
        }

        IHostParm hp;

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

        private void ConnForm_Load(object sender, EventArgs e) {

        }

        internal void Saveto(CHost c) {
            c.HostName = tbHostName.Text;
            c.HostAdrs = tbHostAdrs.Text;
            c.HostVol = tbHostVol.Text;
            c.UserName = tbUserName.Text;
            c.Password = tbPassword.Text;
            c.LocalDir = tbLocalDir.Text;
            c.RemoteDir = tbRemoteDir.Text;
            c.Last = cbLast.Checked;
            c.cbNoUserAuthent = cbNoUserAuthent.Checked;
            c.cbCleartxtPasswrd = cbCleartxtPasswrd.Checked;
            c.cb2WayRandnumExchange = cb2WayRandnumExchange.Checked;
            c.cbDHCAST128 = cbDHCAST128.Checked;
            c.cbDHX2 = cbDHX2.Checked;
        }

        internal void Readfrm(CHost c) {
            tbHostName.Text = c.HostName;
            tbHostAdrs.Text = c.HostAdrs;
            tbHostVol.Text = c.HostVol;
            tbUserName.Text = c.UserName;
            tbPassword.Text = c.Password;
            tbLocalDir.Text = c.LocalDir;
            tbRemoteDir.Text = c.RemoteDir;
            cbLast.Checked = c.Last;
            cbNoUserAuthent.Checked = c.cbNoUserAuthent;
            cbCleartxtPasswrd.Checked = c.cbCleartxtPasswrd;
            cb2WayRandnumExchange.Checked = c.cb2WayRandnumExchange;
            cbDHCAST128.Checked = c.cbDHCAST128;
            cbDHX2.Checked = c.cbDHX2;
        }

        private void bConfirm_Click(object sender, EventArgs e) {
            using (GetSrvrInfoForm form = new GetSrvrInfoForm(tbHostAdrs.Text)) {
                if (form.ShowDialog(this) == DialogResult.OK) {
                    if (form.cbServerName.Checked) {
                        tbHostName.Text = form.tbServerName.Text;
                    }
                    if (form.cbUAMsList.Checked) {
                        String s = form.tbUAMsList.Text;
                        cbNoUserAuthent.Checked = s.Contains("No User Authent");
                        cbCleartxtPasswrd.Checked = s.Contains("ClearTxt Passwrd") || s.Contains("Cleartxt Passwrd");
                        cb2WayRandnumExchange.Checked = s.Contains("2-Way Randnum Exchange");
                        cbDHCAST128.Checked = s.Contains("DHCAST128");
                        cbDHX2.Checked = s.Contains("DHX2");
                    }
                }
            }
        }

        private void bPutRem_Click(object sender, EventArgs e) {
            if (hp != null) tbRemoteDir.Text = hp.GetDirRem();
        }

        private void bRefHostVol_Click(object sender, EventArgs e) {
            ContextMenuStrip cmsVols = new ContextMenuStrip();

            cmsVols.Show(bVolRem, 0, bVolRem.Height);

        }
    }
}
