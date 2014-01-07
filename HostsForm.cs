using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AFPClient4Windows {
    public partial class HostsForm : Form {
        public HostsForm(IHostParm hp) {
            this.hp = hp;
            InitializeComponent();
        }

        IHostParm hp;

        List<CHost> alc = new List<CHost>();

        private void HostsForm_Load(object sender, EventArgs e) {
            alc = Cnf.ReadHosts();

            OnHostsUpdate();
        }

        private void OnHostsUpdate() { OnHostsUpdate(Selty.Sel); }

        private void OnHostsUpdate(Selty selty) {
            while (lH.Items.Count > alc.Count) lH.Items.RemoveAt(lH.Items.Count - 1);
            while (lH.Items.Count < alc.Count) lH.Items.Add("");

            lH.Refresh();

            if (lH.Items.Count > 0) {
                if (selty == Selty.Last) {
                    lH.SelectedIndex = lH.Items.Count - 1;
                }
                else {
                    int y = 0, ny = -1;
                    foreach (CHost h in alc) {
                        if (h.HostName == lastHost) {
                            ny = y;
                            break;
                        }
                        y++;
                    }

                    lH.SelectedIndex = (ny < 0) ? 0 : ny;
                }
            }
        }

        private void bAdd_Click(object sender, EventArgs e) {
            using (ConnForm form = new ConnForm(hp)) {
                if (form.ShowDialog(this) == DialogResult.OK) {
                    CHost c = new CHost();
                    form.Saveto(c);
                    alc.Add(c);

                    Cnf.SaveHosts(alc);

                    OnHostsUpdate();
                }
            }
        }

        internal CHost SelHost = null;

        private void bConnect_Click(object sender, EventArgs e) {
            if (lH.SelectedIndex < 0) return;

            CHost c = (CHost)alc[lH.SelectedIndex];

            SelHost = c;

            if (hp != null) hp.SetSaveDir2Reg(c.Last ? lH.SelectedIndex : -1);

            DialogResult = DialogResult.OK;
            Close();
            return;
        }

        String lastHost = null;

        private void bEd_Click(object sender, EventArgs e) {
            if (lH.SelectedIndex < 0) return;

            CHost c = (CHost)alc[lH.SelectedIndex];

            lastHost = c.HostName;

            using (ConnForm form = new ConnForm(hp)) {
                form.Readfrm(c);
                if (form.ShowDialog(this) == DialogResult.OK) {
                    form.Saveto(c);

                    Cnf.SaveHosts(alc);

                    OnHostsUpdate();
                }
            }
        }

        private void bCopy_Click(object sender, EventArgs e) {
            if (lH.SelectedIndex < 0) return;

            CHost c = (CHost)alc[lH.SelectedIndex];

            alc.Add(c = c.Clone());

            Cnf.SaveHosts(alc);

            OnHostsUpdate(Selty.Last);
        }

        enum Selty {
            Sel, Last,
        }

        private void bClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void bRemove_Click(object sender, EventArgs e) {
            if (lH.SelectedIndex < 0) return;

            if (MessageBox.Show(this, "ホストの設定を削除しますか", "ホストの削除", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                return;

            alc.RemoveAt(lH.SelectedIndex);

            Cnf.SaveHosts(alc);

            OnHostsUpdate();
        }

        private void bUp_Click(object sender, EventArgs e) {
            int pos = lH.SelectedIndex;
            if (pos < 0) return;

            bool fUp = Object.ReferenceEquals(bUp, sender);

            CHost c = alc[pos];

            if (fUp) {
                if (pos == 0)
                    return;

                alc.Remove(c);
                alc.Insert(pos - 1, c);

                lH.SelectedIndex = pos - 1;
            }
            else {
                int cy = alc.Count;

                if (pos == cy - 1)
                    return;

                alc.Remove(c);
                alc.Insert(pos + 1, c);

                lH.SelectedIndex = pos + 1;

            }

            Cnf.SaveHosts(alc);

            OnHostsUpdate();
        }

        private void lH_DrawItem(object sender, DrawItemEventArgs e) {
            e.DrawBackground();
            Rectangle rc = e.Bounds;
            Graphics cv = e.Graphics;
            int pos = e.Index;
            if (pos >= 0) {
                int cey = (rc.Top + rc.Bottom) / 2;
                int x = rc.Left;
                il.Draw(cv, x + 2, cey - 16 / 2, 0);
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                cv.DrawString(alc[pos].HostName, lH.Font, new SolidBrush(e.ForeColor), x + 2 + 16 + 2, cey, sf);
            }
            e.DrawFocusRectangle();
        }

        private void lH_MouseDoubleClick(object sender, MouseEventArgs e) {
            bConnect_Click(sender, e);

        }
    }
}