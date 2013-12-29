using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;
using AFPClient4Windows.Properties;

namespace AFPClient4Windows {
    public partial class ConnsForm : Form {
        public ConnsForm() {
            InitializeComponent();
        }

        public Conn connSel = null;

        String BaseDir {
            get {
                String dir = Path.Combine(Application.LocalUserAppDataPath, "Conn");
                Directory.CreateDirectory(dir);
                return dir;
            }
        }

        private void bNew_Click(object sender, EventArgs e) {
            Conn conn = new Conn();
            using (ConnForm form = new ConnForm(conn)) {
                if (form.ShowDialog() == DialogResult.OK) {
                    XmlSerializer xmls = new XmlSerializer(typeof(Conn));
                    using (FileStream fs = File.Create(Path.Combine(BaseDir, form.tbFName.Text + Resources.FExt))) {
                        xmls.Serialize(fs, conn);
                    }
                }
            }
            Upt();
        }

        private void ConnsForm_Load(object sender, EventArgs e) {
            Upt();
        }

        private void Upt() {
            tvC.Nodes.Clear();

            foreach (String fp in Directory.GetFiles(BaseDir, "*" + Resources.FExt, SearchOption.AllDirectories)) {
                String relfp = fp.Substring(BaseDir.Length).TrimStart('\\');
                String[] cols = relfp.Split('\\');
                TreeNodeCollection tnc = tvC.Nodes;
                for (int x = 0; x < cols.Length; x++) {
                    String n = cols[x];
                    TreeNode tn = tnc[n];
                    if (tn == null) {
                        tn = tnc.Add(n, n);
                    }
                    tn.ImageKey = "D";
                    if (x + 1 == cols.Length) {
                        tn.Text = tn.Name = Path.GetFileNameWithoutExtension(tn.Name);
                        tn.Tag = fp;
                    }
                }
            }

            if (tvC.SelectedNode == null)
                foreach (TreeNode tn in tvC.Nodes) {
                    tvC.SelectedNode = tn;
                    break;
                }
        }

        private void bRefreshTree_Click(object sender, EventArgs e) {
            Upt();
        }

        private void bExplorer_Click(object sender, EventArgs e) {
            Process.Start(BaseDir);
        }

        private void bEdit_Click(object sender, EventArgs e) {
            TreeNode tn = tvC.SelectedNode;
            if (tn == null) return;
            String fp = (String)tn.Tag;
            if (fp == null) return;

            XmlSerializer xmls = new XmlSerializer(typeof(Conn));
            Conn conn;
            using (FileStream fs = File.OpenRead(fp)) {
                conn = (Conn)xmls.Deserialize(fs);
            }
            using (ConnForm form = new ConnForm(conn)) {
                form.tbFName.Text = Path.GetFileNameWithoutExtension(fp);
                if (form.ShowDialog() == DialogResult.OK) {
                    File.Delete(fp);
                    fp = Path.Combine(Path.GetDirectoryName(fp), form.tbFName.Text + Resources.FExt);
                    using (FileStream fs = File.Create(fp)) {
                        xmls.Serialize(fs, conn);
                    }
                }
            }
            Upt();
        }

        private void bConn_Click(object sender, EventArgs e) {
            TreeNode tn = tvC.SelectedNode;
            if (tn == null) return;
            String fp = (String)tn.Tag;
            if (fp == null) return;

            XmlSerializer xmls = new XmlSerializer(typeof(Conn));
            using (FileStream fs = File.OpenRead(fp)) {
                this.connSel = (Conn)xmls.Deserialize(fs);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void tvC_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
            bConn.PerformClick();
        }

        private void tvC_KeyDown(object sender, KeyEventArgs e) {
            if (!e.Alt && !e.Control && !e.Shift && !e.Handled && e.KeyCode == Keys.Return) {
                e.Handled = true;
                bConn.PerformClick();
            }
        }
    }
}