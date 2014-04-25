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
            System.Collections.ArrayList al = new System.Collections.ArrayList(lvC.Items);

            foreach (String fp in Directory.GetFiles(BaseDir, "*" + Resources.FExt, SearchOption.AllDirectories)) {
                String relfp = fp.Substring(BaseDir.Length).TrimStart('\\');
                int p = lvC.Items.IndexOfKey(relfp);
                ListViewItem lvi = (p < 0) ? new ListViewItem() : lvC.Items[p];
                lvi.Name = relfp;
                lvi.Tag = fp;
                lvi.ImageKey = "E";
                lvi.Text = Path.GetFileNameWithoutExtension(relfp);

                try {
                    XmlSerializer xmls = new XmlSerializer(typeof(Conn));
                    Conn conn;
                    using (FileStream fs = File.OpenRead(fp)) {
                        conn = (Conn)xmls.Deserialize(fs);
                    }
                    while (lvi.SubItems.Count < 3) lvi.SubItems.Add("");
                    lvi.SubItems[1].Text = (conn.Host);
                    lvi.SubItems[2].Text = (conn.U);
                }
                catch (Exception err) {
                    lvi.ImageKey = "X";
                    lvi.SubItems.Add(err.Message);
                }

                al.Remove(lvi);

                if (p < 0) lvC.Items.Add(lvi);
            }

            foreach (ListViewItem lvi in al) lvi.Remove();

            if (lvC.SelectedItems.Count == 0)
                foreach (ListViewItem lvi in lvC.Items) {
                    lvi.Focused = lvi.Selected = true;
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
            foreach (ListViewItem lvi in lvC.SelectedItems) {
                String fp = (String)lvi.Tag;
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
                break;
            }
            Upt();
        }

        private void bConn_Click(object sender, EventArgs e) {
            foreach (ListViewItem lvi in lvC.SelectedItems) {
                String fp = (String)lvi.Tag;
                if (fp == null) return;

                XmlSerializer xmls = new XmlSerializer(typeof(Conn));
                using (FileStream fs = File.OpenRead(fp)) {
                    this.connSel = (Conn)xmls.Deserialize(fs);
                }

                DialogResult = DialogResult.OK;
                Close();
                break;
            }
        }

        private void tvC_KeyDown(object sender, KeyEventArgs e) {
            if (!e.Alt && !e.Control && !e.Shift && !e.Handled && e.KeyCode == Keys.Return) {
                e.Handled = true;
                bConn.PerformClick();
            }
        }

        private void lvC_ItemActivate(object sender, EventArgs e) {
            bConn.PerformClick();
        }

        class Sort : System.Collections.IComparer {
            int i, ord;
            public Sort(int i, int ord) {
                this.i = i;
                this.ord = ord;
            }

            #region IComparer ƒƒ“ƒo

            public int Compare(object ax, object ay) {
                ListViewItem x = (ListViewItem)ax;
                ListViewItem y = (ListViewItem)ay;
                bool fx = i < x.SubItems.Count;
                bool fy = i < y.SubItems.Count;
                if (!fx || fx != fy) return fx.CompareTo(fy) * ord;
                return x.SubItems[i].Text.CompareTo(y.SubItems[i].Text) * ord;
            }

            #endregion
        }

        private void lvC_ColumnClick(object sender, ColumnClickEventArgs e) {
            lvC.ListViewItemSorter = new Sort(e.Column, ((ModifierKeys & Keys.Shift) == 0) ? 1 : -1);
        }
    }
}