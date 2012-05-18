using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace AFPClient4Windows {
    public partial class PasteForm : Form {
        public PasteForm() {
            InitializeComponent();
        }

        internal void Done() {
            Close();
        }

        internal ManualResetEvent evStop = new ManualResetEvent(false);

        internal void StartFile(String fp, int y1, int cy) {
            lfp.Text = fp;
            progressBar1.Maximum = cy;
            progressBar1.Value = y1 - 1;

            progressBar2.Maximum = 0;
        }



        private void bCancel_Click(object sender, EventArgs e) {
            evStop.Set();
            bCancel.Enabled = false;
        }

        internal void ReportSend(long x, long cx) {
            while (cx > 60000) {
                x >>= 1;
                cx >>= 1;
            }
            progressBar2.Maximum = (int)cx;
            progressBar2.Value = (int)x;
        }

        private void PasteForm_FormClosing(object sender, FormClosingEventArgs e) {
            evStop.Set();
        }

        internal bool answer = false, all = false;

        internal bool QueryOverwrite() {
            QueryOverwriteForm form = new QueryOverwriteForm();
            form.lfp.Text = lfp.Text;
            switch (form.ShowDialog()) {
                case DialogResult.Yes:
                    all = form.cbAll.Checked;
                    return answer = true;
                case DialogResult.No:
                    all = form.cbAll.Checked;
                    return answer = false;
                default:
                    evStop.Set();
                    return false;
            }
        }
    }
}