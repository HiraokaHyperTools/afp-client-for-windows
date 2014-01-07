using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using AFPt2;
using System.Diagnostics;

namespace AFPClient4Windows {
    public partial class GetSrvrInfoForm : Form {
        String host;

        public GetSrvrInfoForm(String host) {
            this.host = host;
            InitializeComponent();
        }

        private void GetSrvrInfoForm_Load(object sender, EventArgs e) {
            bwConfirm.RunWorkerAsync();
        }

        private void bwConfirm_DoWork(object sender, DoWorkEventArgs e) {
            IPAddress adr = null;
            IPHostEntry h;
            if (IPAddress.TryParse(host, out adr)) {

            }
            else if ((h = Dns.GetHostEntry(host)) != null && h.AddressList.Length != 0) {
                adr = h.AddressList[0];
            }

            IPEndPoint afp = new IPEndPoint((adr), 548);

            using (MyDSI3 comm = new MyDSI3(afp)) {
                {
                    TransmitRes res = comm.Transmit(new DSIGetStatus());
                    Debug.Assert(res.pack.IsResponse && res.pack.ErrorCode == 0);

                    e.Result = new GetSrvrInfoPack(res.br);
                }
            }
        }

        private void bwConfirm_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Error != null) {
                MessageBox.Show(this, "é∏îsÇµÇ‹ÇµÇΩÅB\n\n" + e.Error.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                GetSrvrInfoPack pack = (GetSrvrInfoPack)e.Result;
                tbServerName.Text = pack.ServerName;
                tbAFPVersionsList.Text = String.Join("\r\n", pack.AFPVersionsList.ToArray());
                tbUAMsList.Text = String.Join("\r\n", pack.UAMsList.ToArray());
            }
        }
    }
}