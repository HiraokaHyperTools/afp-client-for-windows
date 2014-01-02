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

        internal ExistSel es = ExistSel.Abort;
        internal bool all = false;
        internal String fpaAlt = String.Empty;

        internal ExistSel QueryOverwrite() {
            QueryOverwriteForm form = new QueryOverwriteForm();
            form.lfp.Text = lfp.Text;
            form.Location = PointToScreen(Point.Empty);
            DialogResult r = form.ShowDialog();
            if (false) { }
            else if (form.radioButton1.Checked) es = ExistSel.Overwrite;
            else if (form.radioButton2.Checked) es = ExistSel.IfNewer;
            else if (form.radioButton3.Checked) es = ExistSel.Resume;
            else if (form.radioButton4.Checked) es = ExistSel.Numbers;
            else if (form.radioButton5.Checked) es = ExistSel.SKip;
            else es = ExistSel.Abort;
            switch (r) {
                case DialogResult.Yes:
                    all = false;
                    break;
                case DialogResult.Retry:
                    all = true;
                    break;
                default:
                    evStop.Set();
                    break;
            }
            fpaAlt = form.lfp.Text;
            return es;
        }

        private void PasteForm_Load(object sender, EventArgs e) {

        }

        DateTime dt0 = DateTime.Now;

        Int64 total = 0;

        internal void AddSize(uint cbRead) {
            total += cbRead;

            lStat.Text = "開始: " + dt0.ToString("yyyy/MM/dd HH:mm:ss")
                + " 経過: " + GoodUt.Format(DateTime.Now.Subtract(dt0))
                + " 送信量: " + GoodUt.FormatSize(total)
                ;
        }

        class GoodUt {
            internal static string Format(TimeSpan timeSpan) {
                Double s = timeSpan.TotalSeconds;
                if (s < 0)
                    return "-" + Format(timeSpan);
                if (s < 60)
                    return ((int)s) + "秒";
                s /= 60;
                if (s < 60)
                    return ((int)s) + "分";
                s /= 60;
                if (s < 24)
                    return ((int)s) + "時間";
                s /= 24;
                return ((int)s) + "日間";
            }

            internal static string FormatSize(long total) {
                if (total < 0)
                    return "-" + FormatSize(-total);
                if (total < 1)
                    return "0";
                if (total < 1024)
                    return total + "B";
                total /= 1024;
                if (total < 1024)
                    return total + "KB";
                double val = total;
                val /= 1024;
                if (val < 1024)
                    return val.ToString("0.0") + "MB";
                val /= 1024;
                return val.ToString("0.0") + "GB";
            }
        }
    }

    public enum ExistSel {
        None = 0,

        Overwrite,
        IfNewer,
        Resume,
        Numbers,
        SKip,
        Abort,
    }
}