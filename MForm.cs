using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AFPClient4Windows.Properties;
using System.Net.Sockets;
using System.Net;
using AFPt2;
using System.Threading;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Text.RegularExpressions;
using AFPt;
using System.Runtime.InteropServices;
using com = System.Runtime.InteropServices.ComTypes;
using Oyster.Math;
using Renci.SshNet.Security.Cryptography.Ciphers;
using Renci.SshNet.Security.Cryptography.Ciphers.Modes;
using System.Xml.Serialization;

namespace AFPClient4Windows {
    public partial class MForm : Form, IAddLOG, IUpdateList {
        public MForm(String fp) {
            this.fpOpen = fp;
            InitializeComponent();
        }

        String fpOpen;

        private void MForm_Load(object sender, EventArgs e) {
            Text = Text.Replace("(*)", Application.ProductVersion);
            UpdTyp();

            if (!String.IsNullOrEmpty(fpOpen) && File.Exists(fpOpen)) {
                XmlSerializer xmls = new XmlSerializer(typeof(Conn));
                Conn conn;
                using (FileStream fs = File.OpenRead(fpOpen)) {
                    conn = (Conn)xmls.Deserialize(fs);
                }
                Connect2(conn);
            }
        }

        private void UpdTyp() {
            bTypData.Checked = Settings.Default.ForkTyp == 0;
            bTypNews.Checked = Settings.Default.ForkTyp == 1;
            bTypMacOSX.Checked = Settings.Default.ForkTyp == 2;

            bNoTimeout.Checked = Settings.Default.NoTimeout;
        }

        class HUt {
            internal static IPEndPoint Parse(String any) {
                String[] cols = any.Split(':');
                String host;
                int port = 548;
                if (cols.Length == 2) {
                    port = int.Parse(cols[1]);
                }
                host = cols[0];
                IPAddress ip;
                if (!IPAddress.TryParse(host, out ip)) {
                    foreach (IPAddress ip1 in Dns.GetHostAddresses(host)) {
                        ip = ip1;
                        break;
                    }
                }
                return new IPEndPoint(ip, port);
            }
        }

        private void bConn_Click(object sender, EventArgs e) {
            using (ConnsForm form = new ConnsForm()) {
                if (form.ShowDialog() == DialogResult.OK) {
                    Conn conn = form.connSel;
                    Connect2(conn);
                }
            }
        }

        private void Connect2(Conn conn) {
            CloseAFP();
            LPC lpc = new LPC(conn, this);
            DelRefs.Add(lpc);

            TreeNode tnPC = AddPC(lpc);

            try {
                EnumPC(lpc, tnPC, 1);

                if (!String.IsNullOrEmpty(conn.HostDir)) {
                    TreeNode tnCur = tnPC;
                    tvF.SelectedNode = tnCur;
                    foreach (String part in conn.HostDir.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries)) {
                        UpdateSel(tnCur, false);
                        tnCur = tnCur.Nodes[part];
                        if (tnCur == null) break;
                        tvF.SelectedNode = tnCur;
                    }
                }
            }
            catch (Exception err) {
                MessageBox.Show(this, "接続に失敗しました:\n\n" + err.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Debug.WriteLine("!" + err);
                return;
            }
        }

        class RUt {
            internal static void Report(IAddLOG logging, GetSrvrInfoPack pack) {
                logging.AddLOG(String.Format(""
                    + "GetSrvrInfo 解析結果 \n"
                    + "  MachineType: {0} \n"
                    + "  AFP versions: {1} \n"
                    + "  UAMs: {2} \n"
                    + "  Server name: {3} \n"
                    , pack.MachineType //0
                    , String.Join(",", pack.AFPVersionsList.ToArray()) //1
                    , String.Join(",", pack.UAMsList.ToArray()) //2
                    , pack.ServerName //3
                    ));

            }

            internal static void Report(IAddLOG logging, TransmitRes res) {
                if (res.pack.ErrorCode == 0) {
                    logging.AddLOG("  結果: Ok\n");
                }
                else {
                    logging.AddLOG("  結果: " + res.pack.ErrorCode + ", " + (DSIException.ResultCode)(res.pack.ErrorCode) + ", " + new DSIException(res.pack.ErrorCode).Message + "\n");
                }
            }

            internal static void ReportErr(IAddLOG logging, TransmitRes res, String what) {
                logging.AddELog(what + "失敗: " + res.pack.ErrorCode + ", " + (DSIException.ResultCode)(res.pack.ErrorCode) + ", " + new DSIException(res.pack.ErrorCode).Message + "\n");
            }

            internal static void ReportEx(IAddLOG logging, Exception err, String what) {
                logging.AddELog(what + "失敗: " + err.Message + "\n");
            }
        }

        public interface IHier {
            /// <summary>
            /// 
            /// </summary>
            /// <returns>True means still alive, False means connected/reconnected. Throw exception for errors.</returns>
            bool ConnectUpper();
        }

        class UtForkNaming {
            int forkTyp;

            public UtForkNaming(int forkTyp) {
                this.forkTyp = forkTyp;
            }

            public ForkNam Parse(String mfp) {
                String[] cols = (mfp ?? "").Split('\0');
                int x = cols.Length - 1;
                String s = cols[x];
                FTy fty = FTy.Data;
                if (forkTyp == 1) {
                    if (s.EndsWith(".AFP_Resource")) {
                        s = s.Substring(0, s.Length - 13);
                        fty = FTy.ResNews;
                    }
                    else if (s.EndsWith(".AFP_FinderInfo")) {
                        s = s.Substring(0, s.Length - 15);
                        fty = FTy.FI;
                    }
                }
                else if (forkTyp == 2) {
                    if (s.StartsWith("._")) {
                        s = s.Substring(2);
                        fty = FTy.ResMac;
                    }
                }
                cols[x] = s;

                return new ForkNam(String.Join("\0", cols), fty);
            }
        }

        class ForkNam {
            public String mfp;
            public FTy fty;

            public String LocalPath {
                get {
                    if (mfp != null) return mfp.Replace('\0', '\\');
                    return mfp;
                }
            }

            public ForkNam(String mfp, FTy fty) {
                this.mfp = mfp;
                this.fty = fty;
            }
        }

        class LPC : IHier, IDisposable, IVerDesc {
            public IPEndPoint afp;

            readonly string kNoUserAuthStr = "No User Authent";
            readonly string kClearTextUAMStr = "Cleartxt Passwrd";
            readonly string kTwoWayRandNumUAMStr = "2-Way Randnum";
            readonly string kDHCAST128UAMStr = "DHCAST128";
            readonly string kDHX2UAMStr = "DHX2";

            public String afpVer = "AFP2.2";

            Conn conn;

            public string Name { get { return afp.ToString(); } }

            MyDSI3 comm = null;

            public MyDSI3 Comm { get { return comm; } }

            bool avail = false;

            IAddLOG logging;

            int afpVerno = 0;

            public bool IsVer(int verno) { return afpVerno >= verno; }

            public bool HasFPUTF8Name { get { return IsVer(300); } }
            public bool FPHasReadExt { get { return IsVer(300); } }
            public bool HasFPWriteExt { get { return IsVer(300); } }
            public bool HasFPEnumerateExt { get { return IsVer(300); } }
            public bool HasFPEnumerateExt2 { get { return IsVer(310); } }
            public bool UseUTC { get { return IsVer(300); } }

            public AfpPathType MaxPathType {
                get {
                    if (HasFPUTF8Name)
                        return AfpPathType.kFPUTF8Name;
                    return AfpPathType.kFPLongName;
                }
            }

            public LPC(Conn conn, IAddLOG logging) {
                this.conn = conn;
                this.logging = logging;

                this.afp = HUt.Parse(conn.Host);
            }

            public bool ConnectUpper() {
                if (avail && comm.Alive) return true;

                GetSrvrInfoPack pack;

                logging.AddLOG("接続中: " + afp + "\n");
                using (comm = new MyDSI3(afp)) {
                    logging.AddLOG("  Ok\n");
                    logging.AddLOG("DSIGetStatus 発行\n");
                    TransmitRes res = comm.Transmit(new DSIGetStatus());
                    RUt.Report(logging, res);
                    if (!(res.pack.IsResponse && res.pack.ErrorCode == 0)) throw new DSIException(res.pack.ErrorCode, res.pack);

                    pack = new GetSrvrInfoPack(res.br);

                    RUt.Report(logging, pack);
                }

                {
                    String s;
                    if (false) { }
                    else if (pack.AFPVersionsList.Contains(s = "AFP3.4")) { afpVer = s; afpVerno = 340; }
                    else if (pack.AFPVersionsList.Contains(s = "AFP3.3")) { afpVer = s; afpVerno = 330; }
                    else if (pack.AFPVersionsList.Contains(s = "AFP3.2")) { afpVer = s; afpVerno = 320; }
                    else if (pack.AFPVersionsList.Contains(s = "AFP3.1")) { afpVer = s; afpVerno = 310; }
                    else if (pack.AFPVersionsList.Contains(s = "AFPX03")) { afpVer = s; afpVerno = 300; }
                    else if (pack.AFPVersionsList.Contains(s = "AFP2.2")) { afpVer = s; afpVerno = 220; }

                    logging.AddLOG("使用するAFP: " + afpVer + "\n");
                }

                logging.AddLOG("接続中: " + afp + "\n");

                comm = new MyDSI3(afp);

                comm.NoTimeout = Settings.Default.NoTimeout;

                logging.AddLOG("  Ok\n");

                logging.AddLOG("DSIOpenSession 発行\n");

                {
                    TransmitRes res = comm.Transmit(new DSIOpenSession());
                    RUt.Report(logging, res);
                    if (!(res.pack.IsResponse && res.pack.ErrorCode == 0)) throw new DSIException(res.pack.ErrorCode, res.pack);
                }

                {
                    bool authDone = false;

                    if (!authDone && conn.AllowDHX2 && pack.UAMsList.Contains(kDHX2UAMStr)) {

                        logging.AddLOG(String.Format("認証手段: {0} \n", kDHX2UAMStr));

                        logging.AddLOG("FPLogin_DHXv2_1 発行\n");
                        TransmitRes res3 = comm.Transmit(new DSICommand().WithRequestPayload(new FPLogin_DHXv2_1()
                            .WithAFPVersion(afpVer)
                            .WithUserID(conn.U)
                            ));
                        RUt.Report(logging, res3);
                        if (res3.pack.IsResponse && res3.pack.ErrorCode == (int)DSIException.ResultCode.kFPAuthContinue) {
                            DHXv2ReplyPack blk1 = new DHXv2ReplyPack(res3.br);

                            UtDHXv2 dhx1 = new UtDHXv2(blk1.g, blk1.p, blk1.Mb);

                            logging.AddLOG("FPLogin_DHXv2_2 発行\n");
                            TransmitRes res4 = comm.Transmit(new DSICommand().WithRequestPayload(new FPLogin_DHXv2_2()
                                .WithContID(blk1.Id)
                                .WithMa(dhx1.GetMa())
                                .WithBody(dhx1.Compute())
                                ));
                            RUt.Report(logging, res4);
                            if (res4.pack.IsResponse && res4.pack.ErrorCode == (int)DSIException.ResultCode.kFPAuthContinue) {
                                DHXv2ContReplyPack blk2 = new DHXv2ContReplyPack(res4.br);

                                UtDHXv2Cont dhx2 = new UtDHXv2Cont(dhx1, blk2.Body);

                                logging.AddLOG("FPLogin_DHXv2_3 発行\n");
                                TransmitRes res5 = comm.Transmit(new DSICommand().WithRequestPayload(new FPLogin_DHXv2_3()
                                    .WithContID(blk2.Id)
                                    .WithBody(dhx2.Compute(conn.P))
                                    ));
                                RUt.Report(logging, res5);
                                if (res5.pack.IsResponse && res5.pack.ErrorCode == (int)DSIException.ResultCode.kFPNoMoreSessions)
                                    throw new IOException("セッション数の上限に達しました。\n・Macコンピュータ、又はファイル共有を再起動するか、\n・しばらく時間を置いて再接続してください。");
                                if (res5.pack.IsResponse && res5.pack.ErrorCode == 0) {
                                    authDone = true;

                                    logging.AddLOG("  認証Ok\n");
                                }
                            }
                        }

                    }

                    if (!authDone && conn.AllowDHCAST128 && pack.UAMsList.Contains(kDHCAST128UAMStr)) {

                        logging.AddLOG(String.Format("認証手段: {0} \n", kDHCAST128UAMStr));

                        UtDHCAST128 dhx1 = new UtDHCAST128();

                        logging.AddLOG("FPLogin_DHX 発行\n");
                        TransmitRes res3 = comm.Transmit(new DSICommand().WithRequestPayload(new FPLogin_DHX()
                            .WithAFPVersion(afpVer)
                            .WithUserID(conn.U)
                            .WithMa(dhx1.GetMa())
                            ));
                        RUt.Report(logging, res3);
                        if (res3.pack.IsResponse && res3.pack.ErrorCode == (int)DSIException.ResultCode.kFPAuthContinue) {
                            DHXReplyPack blk3 = new DHXReplyPack(res3.br);

                            UtDHCAST128Cont dhx2 = new UtDHCAST128Cont(dhx1, blk3.Mb, blk3.nonce_ss);

                            logging.AddLOG("FPLogin_DHX_2 発行\n");
                            TransmitRes res4 = comm.Transmit(new DSICommand().WithRequestPayload(new FPLogin_DHX_2()
                                .WithContID(blk3.Id)
                                .WithNonce1Passwd(dhx2.Compute(conn.P))
                                ));
                            RUt.Report(logging, res4);
                            if (res4.pack.IsResponse && res4.pack.ErrorCode == (int)DSIException.ResultCode.kFPNoMoreSessions)
                                throw new IOException("セッション数の上限に達しました。\n・Macコンピュータ、又はファイル共有を再起動するか、\n・しばらく時間を置いて再接続してください。");
                            if (res4.pack.IsResponse && res4.pack.ErrorCode == 0) {
                                authDone = true;

                                logging.AddLOG("  認証Ok\n");
                            }
                        }

                    }

                    if (!authDone && conn.AllowTwoWayRandNum && pack.UAMsList.Contains(kTwoWayRandNumUAMStr)) {

                        logging.AddLOG(String.Format("認証手段: {0} \n", kTwoWayRandNumUAMStr));

                        logging.AddLOG("FPLogin_2w 発行\n");
                        TransmitRes res3 = comm.Transmit(new DSICommand().WithRequestPayload(new FPLogin_2w()
                            .WithAFPVersion(afpVer)
                            .WithUserID(conn.U)
                            ));
                        RUt.Report(logging, res3);
                        if (res3.pack.IsResponse && res3.pack.ErrorCode == (int)DSIException.ResultCode.kFPAuthContinue) {
                            TwoWay1stPack blk3 = new TwoWay1stPack(res3.br);

                            byte[] key_buffer = Encoding.ASCII.GetBytes(conn.P.PadRight(8, '\0').Substring(0, 8));
                            byte carry = (byte)(key_buffer[0] >> 7);
                            int i;
                            for (i = 0; i < 7; i++) {
                                key_buffer[i] = (byte)((key_buffer[i] << 1) | (key_buffer[i + 1] >> 7));
                            }
                            key_buffer[i] = (byte)((key_buffer[i] << 1) | carry);

                            byte[] encPasswd = new byte[8];
                            DES cipher = DESCryptoServiceProvider.Create();
                            cipher.Mode = System.Security.Cryptography.CipherMode.ECB;
                            cipher.Padding = PaddingMode.None;
                            ICryptoTransform tf = cipher.CreateEncryptor(key_buffer, key_buffer);
                            tf.TransformBlock(blk3.ServerKey, 0, 8, encPasswd, 0);

                            byte[] randKey = new byte[8];
                            new Random().NextBytes(randKey);

                            logging.AddLOG("FPLogin_2w_2 発行\n");
                            TransmitRes res4 = comm.Transmit(new DSICommand().WithRequestPayload(new FPLogin_2w_2()
                                .WithContID(blk3.Id)
                                .WithRandKey(randKey)
                                .WithEncPasswd(encPasswd)
                                ));
                            RUt.Report(logging, res4);
                            if (res4.pack.IsResponse && res4.pack.ErrorCode == 0) {
                                TwoWay2ndPack blk4 = new TwoWay2ndPack(res4.br);
                                byte[] randKeyEnc = new byte[8];
                                tf.TransformBlock(randKey, 0, 8, randKeyEnc, 0);

                                bool agree = true;
                                for (int t = 0; t < 8; t++) agree &= (blk4.ClientKey[t] == randKeyEnc[t]);

                                if (agree) {
                                    authDone = true;

                                    logging.AddLOG("  認証Ok\n");
                                }
                            }
                        }

                    }

                    if (!authDone && conn.AllowClearText && pack.UAMsList.Contains(kClearTextUAMStr)) {

                        logging.AddLOG(String.Format("認証手段: {0} \n", kClearTextUAMStr));

                        logging.AddLOG("FPLogin_Cleartext_Password 発行\n");
                        TransmitRes res3 = comm.Transmit(new DSICommand().WithRequestPayload(new FPLogin_Cleartext_Password()
                            .WithAFPVersion(afpVer)
                            .WithUserName(conn.U)
                            .WithPasswd(conn.P)
                        ));
                        RUt.Report(logging, res3);
                        if (res3.pack.IsResponse && res3.pack.ErrorCode == 0) {
                            authDone = true;

                            logging.AddLOG("  認証Ok\n");
                        }

                    }

                    if (!authDone && conn.AllowNoUserAuth && pack.UAMsList.Contains(kNoUserAuthStr)) {

                        logging.AddLOG(String.Format("認証手段: {0} \n", kNoUserAuthStr));

                        logging.AddLOG("FPLogin 発行\n");
                        TransmitRes res3 = comm.Transmit(new DSICommand().WithRequestPayload(new FPLogin()
                            .WithAFPVersion(afpVer)
                        ));
                        RUt.Report(logging, res3);
                        if (res3.pack.IsResponse && res3.pack.ErrorCode == 0) {
                            authDone = true;

                            logging.AddLOG("  認証Ok\n");
                        }

                    }

                    if (!authDone) {
                        logging.AddLOG(String.Format("認証に失敗しました。\n"));
                        throw new UnauthorizedAccessException("認証に失敗しました。");
                    }
                    else {
                        avail = true;
                    }
                }

                return false;
            }

            private void Disconnect() {
                if (comm != null) {
                    try {
                        logging.AddLOG("FPLogout 発行\n");
                        TransmitRes res = comm.Transmit(new DSICommand().WithRequestPayload(new FPLogout()
                            ));
                        RUt.Report(logging, res);
                    }
                    catch (Exception err) { RUt.ReportEx(logging, err, "FPLogout"); }
                    try {
                        comm.SendNow(new DSICloseSession());
                    }
                    catch (Exception err) { RUt.ReportEx(logging, err, "DSICloseSession"); }
                    comm.Dispose();
                }

                avail = false;
            }

            #region IDisposable メンバ

            public void Dispose() {
                Disconnect();
            }

            #endregion
        }

        void EnumPC(LPC lpc, TreeNode tnPC, int depth) {
            tnPC.Nodes.Clear();

            if (depth < 1) return;

            lpc.ConnectUpper();

            logging.AddLOG("FPGetSrvrParms 発行\n");
            TransmitRes res = lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPGetSrvrParms()
                ));
            RUt.Report(logging, res);
            if (!res.pack.IsResponse || res.pack.ErrorCode != 0) throw new DSIException(res.pack.ErrorCode, res.pack);

            GetSrvrParmsPack pack = new GetSrvrParmsPack(res.br, lpc.IsVer(300));

            using (AH ah = new AH())
                foreach (VolStruc vs in pack.Volumes) {
                    LVol lvol = new LVol(lpc, vs.VolName);

                    TreeNode tnVol = AddVol(tnPC, lvol);
                    EnumVol(lvol, tnVol, depth - 1);
                }

            tnPC.ExpandAll();
        }

        IAddLOG logging { get { return this; } }

        class LBaseDir : IDisposable {
            public List<FileParameters> ents = new List<FileParameters>();
            public LVol lvol;
            public string path;

            public bool isListed = false;

            #region IDisposable メンバ

            public void Dispose() {
                ents.Clear();
            }

            #endregion
        }

        class LVol : LBaseDir, IHier, IDisposable {
            public LPC lpc;

            string volName = "";
            ushort volId = 0;

            public LVol(LPC lpc, string volName) {
                this.lpc = lpc;
                this.volName = volName;
                this.path = "";
            }

            public string VolName { get { return volName; } }
            public ushort VolID { get { return volId; } }

            public bool Avail { get { return avail; } }

            public ushort DirID { get { return 2; } }

            bool avail = false;

            public new void Dispose() {
                if (avail) {
                    TransmitRes res = lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPCloseVol()
                        .WithVolumeID(volId)
                    ));
                    volId = 0;
                }

                avail = false;

                base.Dispose();
            }

            public bool ConnectUpper() {
                if (lpc.ConnectUpper() && avail) return true;
                avail = false;

                TransmitRes res = lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPOpenVol()
                    .WithBitmap(AfpVolumeBitmap.kFPVolIDBit)
                    .WithVolumeName(volName)
                    .WithIsAFPv3(lpc.IsVer(300))
                ));
                if (!res.pack.IsResponse || res.pack.ErrorCode != 0) throw new DSIException(res.pack.ErrorCode, res.pack);

                OpenVolPack pack = new OpenVolPack(res.br);

                volId = pack.Ent.VolID.Value;

                avail = true;
                lvol = this;
                return false;
            }

        }

        void EnumVol(LVol lvol, TreeNode tnVol, int depth) {
            if (depth < 1) return;

            EnumDir(lvol, tnVol);
        }

        private bool EnumDir(LBaseDir lbd, TreeNode tnVol) {
            if (tnVol != null) tnVol.Nodes.Clear();
            lbd.ents.Clear();

            lbd.isListed = false;

            ((lbd is LVol) ? (LVol)lbd : lbd.lvol).ConnectUpper();

            IVerDesc vd = lbd.lvol.lpc;
            bool hasUTF8 = vd.HasFPUTF8Name;

            try {
                for (uint pos = 1; ; ) {
                    IFP ifp;
                    if (vd.HasFPEnumerateExt2) {
                        logging.AddLOG("FPEnumerateExt2 発行 " + lbd.path + "\n");
                        ifp = new FPEnumerateExt2()
                            .WithDirectoryID(lbd.lvol.DirID)
                            .WithPath(APUt.EncodeApplePath(lbd.path))
                            .WithVolumeID(lbd.lvol.VolID)
                            .WithStartIndex(Convert.ToInt32(pos))
                            .WithFileBitmap(
                                AfpFileBitmap.ExtDataForkLength
                                | AfpFileBitmap.ExtResourceForkLength
                                | AfpFileBitmap.FinderInfo
                                | AfpFileBitmap.ModificationDate
                                | (hasUTF8 ? AfpFileBitmap.UnicodeName : AfpFileBitmap.LongName)
                                )
                            .WithDirectoryBitmap(
                                AfpDirectoryBitmap.ModificationDate
                                | (hasUTF8 ? AfpDirectoryBitmap.UnicodeName : AfpDirectoryBitmap.LongName)
                                )
                            ;
                    }
                    else if (vd.HasFPEnumerateExt) {
                        logging.AddLOG("FPEnumerateExt 発行 " + lbd.path + "\n");
                        ifp = new FPEnumerateExt()
                            .WithDirectoryID(lbd.lvol.DirID)
                            .WithPath(APUt.EncodeApplePath(lbd.path))
                            .WithVolumeID(lbd.lvol.VolID)
                            .WithStartIndex(Convert.ToUInt16(pos))
                            .WithFileBitmap(
                                AfpFileBitmap.ExtDataForkLength
                                | AfpFileBitmap.ExtResourceForkLength
                                | AfpFileBitmap.FinderInfo
                                | AfpFileBitmap.ModificationDate
                                | (hasUTF8 ? AfpFileBitmap.UnicodeName : AfpFileBitmap.LongName)
                                )
                            .WithDirectoryBitmap(
                                AfpDirectoryBitmap.ModificationDate
                                | (hasUTF8 ? AfpDirectoryBitmap.UnicodeName : AfpDirectoryBitmap.LongName)
                                )
                            ;
                    }
                    else {
                        logging.AddLOG("FPEnumerate 発行 " + lbd.path + "\n");
                        ifp = new FPEnumerate()
                            .WithDirectoryID(lbd.lvol.DirID)
                            .WithPath(APUt.EncodeApplePath(lbd.path))
                            .WithVolumeID(lbd.lvol.VolID)
                            .WithStartIndex(Convert.ToUInt16(pos))
                            .WithFileBitmap(
                                AfpFileBitmap.DataForkLength
                                | AfpFileBitmap.ResourceForkLength
                                | AfpFileBitmap.FinderInfo
                                | AfpFileBitmap.ModificationDate
                                | (hasUTF8 ? AfpFileBitmap.UnicodeName : AfpFileBitmap.LongName)
                                )
                            .WithDirectoryBitmap(
                                AfpDirectoryBitmap.ModificationDate
                                | (hasUTF8 ? AfpDirectoryBitmap.UnicodeName : AfpDirectoryBitmap.LongName)
                                )
                            ;
                    }
                    TransmitRes res = lbd.lvol.lpc.Comm.Transmit(new DSICommand().WithRequestPayload(ifp));
                    RUt.Report(logging, res);
                    if (!res.pack.IsResponse) throw new ApplicationException();
                    if (res.pack.ErrorCode == (int)DSIException.ResultCode.kFPObjectNotFound) break;
                    if (res.pack.ErrorCode != 0) throw new DSIException(res.pack.ErrorCode, res.pack);

                    EnumeratePack pack = new EnumeratePack(res.br, vd.HasFPEnumerateExt || vd.HasFPEnumerateExt2);

                    lbd.ents.AddRange(pack.Ents);

                    foreach (FileParameters ent in pack.Ents) {
                        LDir ldir = new LDir();
                        ldir.lvol = lbd.lvol;
                        ldir.ent = ent;
                        ldir.path = lbd.path + DirSep + ent.Name;

                        if (ldir.ent.IsDirectory) {
                            if (tnVol != null) AddDir(tnVol, ldir);
                        }
                    }

                    pos += pack.ActualCount;
                }
                lbd.isListed = true;
                return true;
            }
            catch (Exception err) {
                AddErr(err);
                return false;
            }
        }

        LPC GetLPC(TreeNode tn) {
            while (tn != null) {
                LPC lpc = tn.Tag as LPC;
                if (lpc != null) return lpc;
                tn = tn.Parent;
            }
            return null;
        }

        private void AddErr(Exception err) {
            AddLOG(err.ToString() + "\n");
        }

        private TreeNode AddDir(TreeNode tnVol, LDir ldir) {
            TreeNode tn = tnVol.Nodes.Add(ldir.Name);
            tn.Name = ldir.Name;
            tn.ImageKey = "Dir";
            tn.SelectedImageKey = "DirOpen";
            tn.Tag = ldir;
            return tn;
        }

        class LDir : LBaseDir {
            public FileParameters ent;

            public string Name {
                get {
                    return ent.Name;
                }
            }
        }

        private TreeNode AddVol(TreeNode tnPC, LVol lvol) {
            TreeNode tn = tnPC.Nodes.Add(lvol.VolName);
            tn.ImageKey = "Vol";
            tn.SelectedImageKey = "VolOpen";
            tn.Tag = lvol;
            tn.Name = tn.Text;
            return tn;
        }

        private TreeNode AddPC(LPC lpc) {
            TreeNode tn = tvF.Nodes.Add(lpc.Name);
            tn.ImageKey = tn.SelectedImageKey = "PC";
            tn.Tag = lpc;
            tn.Name = tn.Text;
            return tn;
        }

        List<IDisposable> DelRefs = new List<IDisposable>();

        private void CloseAFP() {
            foreach (IDisposable one in DelRefs) one.Dispose();
            DelRefs.Clear();

            tvF.Nodes.Clear();
            lvF.Items.Clear();
        }

        private void MForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.Cancel) return;
            if (cntAsyncOp != 0) {
                if (MessageBox.Show(this, "終了しようとしています。終了するとファイル転送が停止します。終了しますか?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes) {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void MForm_FormClosed(object sender, FormClosedEventArgs e) {
            CloseAFP();
        }

        const char DirSep = '\\';

        private void tvF_AfterSelect(object sender, TreeViewEventArgs e) {
            TreeNode tn = e.Node ?? tvF.SelectedNode;
            if (tn == null) return;
            UpdateSel(tn, false);
        }

        private void UpdateSel(TreeNode tn, bool force) {
            if (tn == null)
                return;
            LPC lpc = tn.Tag as LPC;
            if (lpc != null) {
                if (force)
                    EnumPC(lpc, tn, 1);
                Listup(null);
                return;
            }
            LVol lvol = tn.Tag as LVol;
            if (lvol != null) {
                if (force || !lvol.isListed)
                    EnumVol(lvol, tn, 1);
                Listup(lvol);
                return;
            }
            LBaseDir lbd = tn.Tag as LBaseDir;
            if (lbd != null) {
                lvF.Items.Clear();
                if (force || !lbd.isListed) {
                    if (!EnumDir(lbd, tn))
                        return;
                }
                Listup(lbd);
                return;
            }
        }

        private void Listup(LBaseDir lbd) {
            lvF.Items.Clear();
            if (lbd == null) return;
            int y = 1;
            foreach (FileParameters ent in lbd.ents) {
                foreach (FEnt fe in Gen(ent, lbd)) {
                    ListViewItem lvi = new ListViewItem(fe.LocalName);
                    lvi.SubItems.Add(fe.IsDir ? "" : String.Format("{0:##,#0}", fe.LocalSize));
                    lvi.SubItems.Add(fe.FormatMT());
                    lvi.SubItems.Add("" + y);
                    lvi.ImageKey = fe.IsDir ? "Dir" : "File";
                    lvi.Tag = fe;
                    lvF.Items.Add(lvi);
                    y++;
                }
            }
        }

        List<FEnt> Gen(FileParameters ent, LBaseDir lbd) {
            List<FEnt> al = new List<FEnt>();
            LPC lpc = lbd.lvol.lpc;
            if (!ent.IsDirectory && Settings.Default.ForkTyp == 1) { // News
                al.Add(new FEnt(ent, lbd, FTy.Data));
                al.Add(new FEnt(ent, lbd, FTy.ResNews));
                al.Add(new FEnt(ent, lbd, FTy.FI));
            }
            else if (!ent.IsDirectory && Settings.Default.ForkTyp == 2) { // Mac
                al.Add(new FEnt(ent, lbd, FTy.Data));
                al.Add(new FEnt(ent, lbd, FTy.ResMac));
            }
            else {
                al.Add(new FEnt(ent, lbd, FTy.Data));
            }

            return al;
        }

        enum FTy {
            Data, ResMac, ResNews, FI,
        }

        class FEnt : VFCopy.IOpenSt2 {
            public FileParameters fe;
            public LBaseDir lbd;
            FTy fty;

            public FEnt(FileParameters fe, LBaseDir lbd, FTy fty) {
                this.fe = fe;
                this.lbd = lbd;
                this.fty = fty;
            }

            public bool IsData { get { return fty == FTy.Data; } }

            public string RealName { get { return fe.Name; } }

            public string LocalName {
                get {
                    if (fty == FTy.ResMac)
                        return "._" + fe.Name;
                    if (fty == FTy.ResNews)
                        return fe.Name + ".AFP_Resource";
                    if (fty == FTy.FI)
                        return fe.Name + ".AFP_FinderInfo";
                    return fe.Name;
                }
            }

            public bool IsDir { get { return fe.IsDirectory; } }

            public Int64 LocalSize {
                get {
                    if (fty == FTy.ResMac || fty == FTy.ResNews)
                        return Convert.ToInt64(fe.AnyResourceForkSize);
                    if (fty == FTy.FI)
                        return 32;
                    return Convert.ToInt64(fe.AnyDataForkSize);
                }
            }

            public Int64 DataSize { get { return Convert.ToInt64(fe.ExtDataForkSize ?? fe.DataForkSize ?? 0); } }
            public Int64 ResSize { get { return Convert.ToInt64(fe.ExtResourceForkSize ?? fe.ResourceForkSize ?? 0); } }

            public String FormatMT() { return fe.GetMT(v3).HasValue ? fe.GetMT(v3).Value.ToString("yyyy/MM/dd HH:mm:ss") : ""; }

            public DateTime GetMT() { return fe.GetMT(v3) ?? DateTime.Now; }

            bool v3 { get { return lbd != null && lbd.lvol.lpc.UseUTC; } }

            public string RefPath {
                get {
                    return (lbd.path + "\\" + RealName).TrimStart('\\');
                }
            }

            public string MacPath {
                get {
                    return RefPath.TrimStart(DirSep).Replace(DirSep, '\0');
                }
            }

            public VFCopy.ISt2 OpenSt2() {
                lbd.lvol.ConnectUpper();

                MyDSI3 comm = lbd.lvol.lpc.Comm;

                if (fty == FTy.Data || fty == FTy.ResMac || fty == FTy.ResNews) {
                    TransmitRes res = comm.Transmit(new DSICommand().WithRequestPayload(new FPOpenFork()
                        .WithVolumeID(lbd.lvol.VolID)
                        .WithDirectoryID(lbd.lvol.DirID)
                        .WithPath(MacPath)
                        .WithPathType(lbd.lvol.lpc.MaxPathType)
                        .WithFlag((byte)((fty != FTy.Data) ? 0x80 : 0x00))
                        .WithAccessMode(AfpAccessMode.Read | AfpAccessMode.DenyWrite)
                    ));

                    if (!res.pack.IsResponse) throw new InvalidDataException();
                    if (res.pack.ErrorCode != 0) throw new DSIException(res.pack.ErrorCode, res.pack);

                    OpenForkPack pack = new OpenForkPack(res.br);

                    return new ForkSt(pack, comm, lbd.lvol.lpc);
                }
                else { // FI
                    return new FISt(fe.FinderInfo);
                }
            }

            class FISt : VFCopy.ISt2 {
                byte[] bin;

                public FISt(byte[] bin) {
                    this.bin = bin;
                }

                #region ISt2 メンバ

                public void CloseSt2() {
                }

                public void ReadAt(long pos, out Array pparray, uint cb, out uint pcbRead) {
                    if (pos < 0 || 32 < pos) {
                        pcbRead = 0;
                        pparray = new byte[0];
                    }
                    else {
                        uint cx = Math.Min((uint)(32 - pos), cb);
                        pcbRead = cx;
                        byte[] buff = new byte[cx];
                        pparray = buff;
                        Buffer.BlockCopy(bin, (int)pos, buff, 0, (int)cx);
                    }
                }

                #endregion
            }

            class ForkSt : VFCopy.ISt2 {
                OpenForkPack forkPack;
                MyDSI3 comm;
                bool isOpened = true;
                IVerDesc vd;

                public ForkSt(OpenForkPack forkPack, MyDSI3 comm, IVerDesc vd) {
                    this.forkPack = forkPack;
                    this.comm = comm;
                    this.vd = vd;
                }

                #region ISt2 メンバ

                public void CloseSt2() {
                    if (!isOpened) return;

                    TransmitRes res2 = comm.Transmit(new DSICommand().WithRequestPayload(new FPCloseFork()
                        .WithFork(forkPack.Fork)
                    ));

                    isOpened = false;
                }

                public void ReadAt(Int64 pos, out byte[] bin, UInt32 cb, out UInt32 pcbRead) {
                    TransmitRes res;
                    if (vd.FPHasReadExt) {
                        res = comm.Transmit(new DSICommand().WithRequestPayload(new FPReadExt()
                            .WithOffset(Convert.ToInt32(pos))
                            .WithOForkRefNum(forkPack.Fork)
                            .WithReqCount(Convert.ToInt32(cb))
                        ));
                    }
                    else {
                        res = comm.Transmit(new DSICommand().WithRequestPayload(new FPRead()
                            .WithOffset(Convert.ToInt32(pos))
                            .WithOForkRefNum(forkPack.Fork)
                            .WithReqCount(Convert.ToInt32(cb))
                        ));
                    }

                    if (!res.pack.IsResponse) throw new InvalidDataException();
                    if (res.pack.ErrorCode == (int)DSIException.ResultCode.kFPEOFErr) {
                        Debug.WriteLine("!ReadAt: " + res.pack.ErrorCode + " " + pos);
                    }
                    else if (res.pack.ErrorCode != 0) {
                        throw new DSIException(res.pack.ErrorCode, res.pack);
                    }

                    bin = res.pack.Payload;
                    pcbRead = Convert.ToUInt32(res.pack.Payload.Length);
                }

                #endregion

                #region ISt2 メンバ

                public void ReadAt(long pos, out Array pparray, uint cb, out uint pcbRead) {
                    byte[] bin;
                    ReadAt(pos, out bin, cb, out pcbRead);
                    pparray = bin;
                }

                #endregion
            }
        }

        private void bRefreshSel_Click(object sender, EventArgs e) {
            TreeNode tn = tvF.SelectedNode;
            if (tn == null) return;
            try {
                UpdateSel(tn, true);
            }
            catch (Exception err) {
                MessageBox.Show(this, "更新に失敗しました。\n\n" + err.Message);
            }
        }


        class Sort {
            internal class Str : System.Collections.IComparer {
                int i;
                int ord;

                public Str(int i, bool asc) { this.i = i; ord = asc ? 1 : -1; }

                #region IComparer メンバ

                public int Compare(object xx, object yy) {
                    ListViewItem x = (ListViewItem)xx;
                    ListViewItem y = (ListViewItem)yy;
                    return x.SubItems[i].Text.CompareTo(y.SubItems[i].Text) * ord;
                }

                #endregion
            }

            internal class Mt : System.Collections.IComparer {
                int ord;

                public Mt(bool asc) { ord = asc ? 1 : -1; }

                #region IComparer メンバ

                public int Compare(object xx, object yy) {
                    ListViewItem vx = (ListViewItem)xx;
                    ListViewItem vy = (ListViewItem)yy;
                    bool fx = vx.Tag is FEnt;
                    bool fy = vy.Tag is FEnt;
                    if (!fx || !fy) return fx.CompareTo(fy) * ord;
                    FEnt x = (FEnt)vx.Tag;
                    FEnt y = (FEnt)vy.Tag;
                    fx = x.fe.GetMT(false).HasValue;
                    fy = y.fe.GetMT(false).HasValue;
                    if (!fx || !fy) return fx.CompareTo(fy) * ord;
                    return x.fe.GetMT(false).Value.CompareTo(y.fe.GetMT(false).Value) * ord;
                }

                #endregion
            }

            internal class Cb : System.Collections.IComparer {
                int ord;

                public Cb(bool asc) { ord = asc ? 1 : -1; }

                #region IComparer メンバ

                public int Compare(object xx, object yy) {
                    ListViewItem vx = (ListViewItem)xx;
                    ListViewItem vy = (ListViewItem)yy;
                    bool fx = vx.Tag is FEnt;
                    bool fy = vy.Tag is FEnt;
                    if (!fx || !fy) return fx.CompareTo(fy) * ord;
                    FEnt x = (FEnt)vx.Tag;
                    FEnt y = (FEnt)vy.Tag;
                    return x.LocalSize.CompareTo(y.LocalSize) * ord;
                }

                #endregion
            }

            internal class I : System.Collections.IComparer {
                int ord;
                int i;

                public I(bool asc, int i) { ord = asc ? 1 : -1; this.i = i; }

                #region IComparer メンバ

                public int Compare(object xx, object yy) {
                    ListViewItem vx = (ListViewItem)xx;
                    ListViewItem vy = (ListViewItem)yy;
                    bool fx = vx.SubItems.Count > i;
                    bool fy = vy.SubItems.Count > i;
                    if (!fx || !fy) return fx.CompareTo(fy) * ord;
                    int x;
                    int y;
                    fx = int.TryParse(vx.SubItems[i].Text, out x);
                    fy = int.TryParse(vy.SubItems[i].Text, out y);
                    if (!fx || !fy) return fx.CompareTo(fy) * ord;
                    return x.CompareTo(y) * ord;
                }

                #endregion
            }
        }

        private void lvF_ColumnClick(object sender, ColumnClickEventArgs e) {
            bool asc = 0 == (ModifierKeys & Keys.Shift);
            if (e.Column == chfn.Index) lvF.ListViewItemSorter = new Sort.Str(e.Column, asc);
            if (e.Column == chmt.Index) lvF.ListViewItemSorter = new Sort.Mt(!asc);
            if (e.Column == chcb.Index) lvF.ListViewItemSorter = new Sort.Cb(asc);
            if (e.Column == chi.Index) lvF.ListViewItemSorter = new Sort.I(asc, chi.Index);
        }

        private void lvF_ItemActivate(object sender, EventArgs e) {
            ListViewItem lvi = lvF.FocusedItem;
            if (lvi == null) return;
            FEnt curl = lvi.Tag as FEnt;
            if (curl != null) {
                TreeNode tn = tvF.SelectedNode;
                if (tn == null)
                    return;
                TreeNode tnFound = tn.Nodes[curl.RealName];
                if (tnFound == null)
                    return;

                tvF.SelectedNode = tnFound;
                return;
            }
        }

        class NUt {
            public static String Clean(String s) {
                if (s.Length == 2 && s[1] == ':' && char.IsLetter(s[0]))
                    return s.Substring(0, 1);

                return Regex.Replace(s, "[\\\\/\\*\\?\\|\\<\\>\"\\:]", "_");
            }
        }

        private void AddWalk(VFCopy.SrcClass dataSrc, TreeNode tnCur, String prefix) {
            GetSel(tnCur, false);

            LBaseDir lbd = tnCur.Tag as LBaseDir;
            if (lbd == null) return;

            bool v3 = lbd.lvol.lpc.UseUTC;

            foreach (FileParameters fparm in lbd.ents) {
                foreach (FEnt fe in Gen(fparm, lbd)) {
                    if (fe.IsDir) {
                        EnumDir(lbd, tnCur);
                        continue;
                    }
                    dataSrc.AddFile2(Path.Combine(prefix, NUt.Clean(fe.LocalName)), v3 ? fe.GetMT().ToUniversalTime() : fe.GetMT(), fe.LocalSize, fe);
                }
            }
            foreach (TreeNode tnSub in tnCur.Nodes) {
                AddWalk(dataSrc, tnSub, Path.Combine(prefix, NUt.Clean(Path.GetFileName(tnSub.Name))));
            }
        }

        private void GetSel(TreeNode tn, bool force) {
            if (tn == null)
                return;
            LBaseDir lbd = tn.Tag as LBaseDir;
            if (lbd != null) {
                if (force || !lbd.isListed) {
                    if (!EnumDir(lbd, tn))
                        return;
                }
                return;
            }
        }

        const string ExtResFork = ".AFP_Resource";
        const string ExtFinderInfo = ".AFP_AfpInfo";

        VFCopy.SrcClass GetTvSrc(TreeNode tn) {
            VFCopy.SrcClass dataSrc = new VFCopy.SrcClass();

            using (AH ah = new AH()) {
                TreeNode tnSub = tn;
                if (tnSub != null)
                    AddWalk(dataSrc, tnSub, NUt.Clean(tnSub.Name));
            }
            dataSrc.Make();
            dataSrc.SetAsyncMode(1);

            dataSrc.OnStartOperation += delegate { ++cntAsyncOp; };
            dataSrc.OnEndOperation += delegate { --cntAsyncOp; };
            return dataSrc;
        }

        VFCopy.SrcClass GetLvSrc(ListView sender) {
            VFCopy.SrcClass dataSrc = new VFCopy.SrcClass();

            TreeNode tn = tvF.SelectedNode;

            LBaseDir lbd = (tn != null) ? tn.Tag as LBaseDir : null;

            bool v3 = (lbd != null) && lbd.lvol.lpc.UseUTC;

            using (AH ah = new AH())
                foreach (ListViewItem lvi in sender.SelectedItems) {
                    FEnt fe = lvi.Tag as FEnt;
                    if (fe == null) continue;
                    if (!fe.IsDir) {
                        dataSrc.AddFile2(NUt.Clean(fe.LocalName), v3 ? fe.GetMT().ToUniversalTime() : fe.GetMT(), fe.LocalSize, fe);
                    }
                    else {
                        TreeNode tnSub = tn.Nodes[fe.RealName];
                        if (tnSub != null)
                            AddWalk(dataSrc, tnSub, NUt.Clean(tnSub.Name));
                    }
                }
            dataSrc.Make();
            dataSrc.SetAsyncMode(1);

            dataSrc.OnStartOperation += delegate { ++cntAsyncOp; };
            dataSrc.OnEndOperation += delegate { --cntAsyncOp; };
            return dataSrc;
        }

        int cntAsyncOp = 0;

        private void lvF_ItemDrag(object sender, ItemDragEventArgs e) {
            if (0 != (e.Button & MouseButtons.Left)) DoDragDrop(GetLvSrc(lvF), DragDropEffects.Copy);
        }

        private void tvF_ItemDrag(object sender, ItemDragEventArgs e) {
            if (0 != (e.Button & MouseButtons.Left)) DoDragDrop(GetTvSrc(e.Item as TreeNode ?? tvF.SelectedNode), DragDropEffects.Copy);
        }

        private void lvF_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.None;

            TreeNode tn = tvF.SelectedNode;
            LBaseDir lbd;
            if (tn == null || null == (lbd = tn.Tag as LBaseDir)) return;

            VFCopy.ReadSrcClass readSrc = new VFCopy.ReadSrcClass();
            try {
                readSrc.ParseDataObject(e.Data, VFCopy.PDOFlags.AllowParseHDROP | VFCopy.PDOFlags.DisallowEnumObjects);
                e.Effect = e.AllowedEffect & DragDropEffects.Copy;
            }
            catch (Exception) {
            }
        }

        private void lvF_DragOver(object sender, DragEventArgs e) {
            lvF_DragEnter(sender, e);
        }

        private void tvF_DragOver(object sender, DragEventArgs e) {
            tvF_DragEnter(sender, e);
        }

        private void tvF_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.None;

            TreeNode tn = tvF.SelectedNode;
            LBaseDir lbd;
            if (tn == null || null == (lbd = tn.Tag as LBaseDir)) return;

            VFCopy.ReadSrcClass readSrc = new VFCopy.ReadSrcClass();
            try {
                readSrc.ParseDataObject(e.Data, VFCopy.PDOFlags.AllowParseHDROP | VFCopy.PDOFlags.DisallowEnumObjects);
                e.Effect = e.AllowedEffect & DragDropEffects.Copy;
            }
            catch (Exception) {
            }
        }

        private void lvF_DragDrop(object sender, DragEventArgs e) {
            DropIt(tvF.SelectedNode, e.Data);

            e.Effect = DragDropEffects.Copy & e.AllowedEffect;
        }

        private void tvF_DragDrop(object sender, DragEventArgs e) {
            DropIt(tvF.SelectedNode, e.Data);

            e.Effect = DragDropEffects.Copy & e.AllowedEffect;
        }

        class APUt {
            public static string EncodeApplePath(String fp) {
                return EncodeApplePath(fp, '\\');
            }
            public static string EncodeApplePath(String fp, char sep) {
                return fp.TrimStart(sep).Replace(sep, '\0');
            }

            public static string EncodeApplePath2(String fp2, char sep) {
                String[] cols = Regex.Replace(fp2, Regex.Escape("" + sep) + "+", "" + sep).TrimStart(sep).Split(sep);
                String s = "";
                for (int x = 0; x < cols.Length; x++) {
                    if (x != 0) s += "\0";
                    String a = cols[x];
                    if (a == "..") {

                    }
                    else {
                        s += a;
                    }
                }
                return s;
            }
        }

        class NNUt {
            int no = 1;
            String mfp;

            public NNUt(String mfp) {
                this.mfp = mfp;
            }

            public String Next() {
                String[] cols = mfp.Split('\0');
                int x = cols.Length - 1;
                String a = cols[x];
                a = Path.GetFileNameWithoutExtension(a) + " (" + no + ")" + Path.GetExtension(a);
                no++;
                cols[x] = a;
                return String.Join("\0", cols);
            }
        }

        [DllImport("ole32.dll")]
        static extern int CoGetInterfaceAndReleaseStream(
            [In] com.IStream pStm,
            [In] ref Guid riid,
            [MarshalAs(UnmanagedType.IUnknown)] out object ppv
            );

        [DllImport("ole32.dll")]
        static extern int CoMarshalInterThreadInterfaceInStream(
            [In] ref Guid riid,
            [MarshalAs(UnmanagedType.IUnknown)] object pUnk,
            out com.IStream ppStm
            );

        static Guid IID_IDataObject = new Guid("0000010e-0000-0000-C000-000000000046");

        private void DropIt(TreeNode treeNode, IDataObject data) {
            LBaseDir lbd = treeNode.Tag as LBaseDir;
            if (lbd == null) throw new ArgumentException("treeNode.Tag");

            lbd.lvol.ConnectUpper();

            UtDropIt it = new UtDropIt(data, this, lbd, logging, this);
        }

        class UtDropIt {
            com.IStream dataStm;
            UtForkNaming ufn = new UtForkNaming(Settings.Default.ForkTyp);
            PasteForm form = new PasteForm();
            Thread t;
            SynchronizationContext Sync = SynchronizationContext.Current;
            LBaseDir lbd;
            IAddLOG logging;
            IUpdateList ul;
            Form parent;

            public UtDropIt(IDataObject data, Form parent, LBaseDir lbd, IAddLOG logging, IUpdateList ul) {
                this.lbd = lbd;
                this.logging = logging;
                this.ul = ul;

                CoMarshalInterThreadInterfaceInStream(ref IID_IDataObject, data, out dataStm);

                t = new Thread(ThreadProc);
                t.SetApartmentState(ApartmentState.STA);

                form.Location = parent.PointToScreen(new Point(0, 0));
                form.Load += new EventHandler(form_Load);

                form.Show(this.parent = parent);
            }

            void form_Load(object sender, EventArgs e) {
                t.Start();
            }

            public void ThreadProc() {
                try {
                    Application.OleRequired();

                    Object dataRaw;
                    CoGetInterfaceAndReleaseStream(dataStm, ref IID_IDataObject, out dataRaw);
                    com.IDataObject dataObj = (com.IDataObject)dataRaw;

                    VFCopy.ReadSrcClass readSrc = new VFCopy.ReadSrcClass();
                    Object aryRaw = readSrc.ParseDataObject(dataObj, VFCopy.PDOFlags.AllowParseHDROP);
                    Object[] ary = (Object[])aryRaw as Object[];
                    if (ary != null) {
                        int ypos = 0;
                        bool answerAll = false;
                        ExistSel es = ExistSel.None;
                        using (DCUt dcut = new DCUt(lbd.lvol.lpc.Comm, lbd.lvol.lpc.MaxPathType)) {
                            foreach (VFCopy.IFDEnt ent in ary) {
                                ++ypos;
                                if (form.evStop.WaitOne(0))
                                    throw new UserCancelException();
                                if (ent == null)
                                    continue;

                                ForkNam pathSrc = ufn.Parse(ent.FileName);
                                String fpDst = Path.Combine(lbd.path, Path.Combine(Path.GetDirectoryName(pathSrc.LocalPath), NUt.Clean(Path.GetFileName(pathSrc.LocalPath)))).TrimStart('\\');
                                Sync.Send(delegate { form.StartFile(fpDst, ypos, ary.Length); }, null);
                                String fpaDst = APUt.EncodeApplePath(fpDst);

                                if (0 != ((FileAttributes)ent.FileAttributes & FileAttributes.Directory)) {
                                    dcut.ResolveDir2(lbd.lvol, fpaDst);
                                    continue;
                                }

                                DCR dcr = dcut.ResolveFile(lbd.lvol, fpaDst);

                                logging.AddLOG("FPOpenFork 発行\n");
                                TransmitRes res6 = lbd.lvol.lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPOpenFork()
                                    .WithVolumeID(dcr.VolumeID)
                                    .WithDirectoryID(dcr.DirectoryID)
                                    .WithPath(dcr.LastName)
                                    .WithPathType(lbd.lvol.lpc.MaxPathType)
                                    .WithOpenDataFork()
                                    .WithAccessMode(AfpAccessMode.Read | AfpAccessMode.Write | AfpAccessMode.DenyWrite)
                                    .WithBitmap(AfpFileBitmap.ModificationDate)
                                    ));
                                RUt.Report(logging, res6);
                                if (res6.pack.ErrorCode != 0) {
                                    if (res6.pack.ErrorCode != (int)DSIException.ResultCode.kFPItemNotFound && res6.pack.ErrorCode != (int)DSIException.ResultCode.kFPObjectNotFound)
                                        throw new DSIException(res6.pack.ErrorCode, res6.pack);
                                }
                                else {
                                    OpenForkPack pack6 = new OpenForkPack(res6.br);
                                    lbd.lvol.lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPCloseFork()
                                        .WithFork(pack6.Fork)
                                        ));
                                    if (!answerAll)
                                        Sync.Send(delegate { es = form.QueryOverwrite(); answerAll = form.all; }, null);
                                    if (es == ExistSel.SKip)
                                        continue;
                                    if (es == ExistSel.Abort)
                                        continue;
                                    if (es == ExistSel.Overwrite) {
                                        dcr = dcut.ResolveFile(lbd.lvol, fpaDst = form.fpaAlt.Replace('\\', '\0'));
                                    }
                                    if (es == ExistSel.Resume) {
                                    }
                                    if (es == ExistSel.Numbers) {
                                        NNUt nnut = new NNUt(fpaDst);
                                        for (int w = 0; w < 100; w++) {
                                            dcr = dcut.ResolveFile(lbd.lvol, fpaDst = nnut.Next());
                                            TransmitRes res7 = lbd.lvol.lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPGetFileDirParms()
                                                .WithVolumeID(dcr.VolumeID)
                                                .WithDirectoryID(dcr.DirectoryID)
                                                .WithFileBitmap(AfpFileBitmap.NodeID)
                                                .WithDirectoryBitmap(AfpDirectoryBitmap.NodeID)
                                                .WithPathType(dcr.PathType)
                                                .WithPath(dcr.LastName)
                                                ));
                                            if (!res7.pack.IsResponse) throw new ApplicationException("!IsResponse");
                                            if (res7.pack.ErrorCode == 0)
                                                continue;
                                            if (res7.pack.ErrorCode == (int)DSIException.ResultCode.kFPItemNotFound)
                                                break;
                                            if (res7.pack.ErrorCode == (int)DSIException.ResultCode.kFPObjectNotFound)
                                                break;
                                            RUt.ReportErr(logging, res7, "ファイル名の作成");
                                            throw new DSIException(res7.pack.ErrorCode, res7.pack);
                                        }
                                    }
                                    if (es == ExistSel.IfNewer) {
                                        DateTime? mt = pack6.Parms.GetMT(lbd.lvol.lpc.UseUTC);
                                        if (mt.HasValue) {
                                            DateTime dtTar = lbd.lvol.lpc.UseUTC ? ent.LastWriteTime.ToLocalTime() : ent.LastWriteTime;
                                            if (dtTar > mt.Value)
                                                continue;
                                        }
                                    }
                                }

                                // 名前を変えて上書きされた場合にFPCreateFileが必要
                                logging.AddLOG("FPCreateFile 発行\n");
                                TransmitRes res1 = lbd.lvol.lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPCreateFile()
                                    .WithVolumeID(dcr.VolumeID)
                                    .WithDirectoryID(dcr.DirectoryID)
                                    .WithPath(dcr.LastName)
                                    .WithPathType(lbd.lvol.lpc.MaxPathType)
                                    .WithSoftCreate()
                                    ));
                                RUt.Report(logging, res1);
                                if (res6.pack.ErrorCode != 0) {
                                    // 存在しない
                                    if (res1.pack.ErrorCode != 0)
                                        throw new DSIException(res1.pack.ErrorCode, res1.pack);
                                }
                                if (pathSrc.fty == FTy.FI) {
                                    Int64 cbFile = ent.FileSize;
                                    VFCopy.ISt2 sIn = (VFCopy.ISt2)ent.OpenSt2();
                                    try {
                                        Array parray;
                                        uint cbRead;
                                        sIn.ReadAt(0, out parray, 32, out cbRead);
                                        byte[] bin = new byte[32];
                                        Buffer.BlockCopy(parray, 0, bin, 0, Math.Min(32, parray.Length));

                                        TransmitRes res7 = lbd.lvol.lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPSetFileParms()
                                            .WithVolumeID(dcr.VolumeID)
                                            .WithDirectoryID(dcr.DirectoryID)
                                            .WithPath(dcr.LastName)
                                            .WithPathType(lbd.lvol.lpc.MaxPathType)
                                            .WithFinderInfo((byte[])bin)
                                            ));
                                    }
                                    finally {
                                        sIn.CloseSt2();
                                    }
                                }
                                else {
                                    bool isData = pathSrc.fty == FTy.Data;
                                    logging.AddLOG("FPOpenFork 発行\n");
                                    TransmitRes res2 = lbd.lvol.lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPOpenFork()
                                        .WithVolumeID(dcr.VolumeID)
                                        .WithDirectoryID(dcr.DirectoryID)
                                        .WithPath(dcr.LastName)
                                        .WithPathType(lbd.lvol.lpc.MaxPathType)
                                        .WithOpenForkOfData(isData)
                                        .WithAccessMode(AfpAccessMode.Read | AfpAccessMode.Write | AfpAccessMode.DenyWrite)
                                        .WithBitmap(lbd.lvol.lpc.HasFPEnumerateExt
                                            ? (isData ? AfpFileBitmap.ExtDataForkLength : AfpFileBitmap.ExtResourceForkLength)
                                            : (isData ? AfpFileBitmap.DataForkLength : AfpFileBitmap.ResourceForkLength)
                                            )
                                        ));
                                    RUt.Report(logging, res2);
                                    if (res2.pack.ErrorCode != 0)
                                        throw new DSIException(res2.pack.ErrorCode, res2.pack);
                                    OpenForkPack pack2 = new OpenForkPack(res2.br);

                                    bool incomplete = true, anywayWritten = false;

                                    Int64 cbFile = ent.FileSize;
                                    try {
                                        VFCopy.ISt2 sIn = (VFCopy.ISt2)ent.OpenSt2();
                                        try {
                                            Int64 pos = 0;
                                            if (es == ExistSel.Resume)
                                                pos = Convert.ToInt64(isData
                                                 ? pack2.Parms.AnyDataForkSize
                                                 : pack2.Parms.AnyResourceForkSize
                                                 );
                                            while (true) {
                                                Array parray;
                                                uint cbRead;
                                                sIn.ReadAt(pos, out parray, 20000, out cbRead);
                                                if (cbRead == 0) {
                                                    incomplete = false;
                                                    break;
                                                }

                                                if (form.evStop.WaitOne(0))
                                                    throw new UserCancelException();

                                                if (lbd.lvol.lpc.HasFPWriteExt) {
                                                    TransmitRes res3 = lbd.lvol.lpc.Comm.Transmit(new DSIWrite().WithRequestPayload(new FPWriteExt()
                                                        .WithOffset(pos)
                                                        .WithOForkRefNum(pack2.Fork)
                                                        .WithForkData((byte[])parray)
                                                        .WithReqCount(cbRead)
                                                        ));
                                                    if (res3.pack.ErrorCode != 0) {
                                                        RUt.ReportErr(logging, res3, "FPWriteExt");
                                                        throw new DSIException(res3.pack.ErrorCode, res3.pack);
                                                    }
                                                }
                                                else {
                                                    TransmitRes res3 = lbd.lvol.lpc.Comm.Transmit(new DSIWrite().WithRequestPayload(new FPWrite()
                                                        .WithOffset(Convert.ToInt32(pos))
                                                        .WithOForkRefNum(pack2.Fork)
                                                        .WithForkData((byte[])parray)
                                                        .WithReqCount(Convert.ToInt32(cbRead))
                                                        ));
                                                    if (res3.pack.ErrorCode != 0) {
                                                        RUt.ReportErr(logging, res3, "FPWrite");
                                                        throw new DSIException(res3.pack.ErrorCode, res3.pack);
                                                    }
                                                }

                                                pos += cbRead;

                                                anywayWritten = true;

                                                Sync.Send(delegate { form.ReportSend(pos, cbFile); form.AddSize(cbRead); }, null);
                                            }
                                        }
                                        finally {
                                            sIn.CloseSt2();
                                        }

                                    }
                                    finally {
                                        try {
                                            logging.AddLOG("FPCloseFork 発行\n");
                                            TransmitRes resCF = lbd.lvol.lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPCloseFork()
                                                .WithFork(pack2.Fork)
                                                ));
                                            RUt.Report(logging, resCF);
                                        }
                                        finally {
                                            if (incomplete && anywayWritten && es != ExistSel.Resume) {
                                                bool erase = false;
                                                Sync.Send(delegate {
                                                    erase = MessageBox.Show(form, "不完全なファイル\n\n" + fpaDst.Replace('\0', '\\') + "\n\nを消しますか?", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes;
                                                }, null);
                                                if (erase) {
                                                    logging.AddLOG("FPDelete 発行\n");
                                                    TransmitRes resD = lbd.lvol.lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPDelete()
                                                        .WithVolumeID(lbd.lvol.VolID)
                                                        .WithDirectoryID(lbd.lvol.DirID)
                                                        .WithPath(fpaDst)
                                                        ));
                                                    RUt.Report(logging, resD);
                                                }
                                            }
                                        }
                                    }
                                }

                                TransmitRes res5 = lbd.lvol.lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPSetFileParms()
                                    .WithVolumeID(dcr.VolumeID)
                                    .WithDirectoryID(dcr.DirectoryID)
                                    .WithPath(dcr.LastName)
                                    .WithPathType(lbd.lvol.lpc.MaxPathType)
                                    .WithModDate(lbd.lvol.lpc.UseUTC ? ent.LastWriteTime.ToLocalTime() : ent.LastWriteTime)
                                    ));
                            }
                        }
                    }

                    Sync.Send(delegate {
                        form.Done();
                        ul.UpdateList();
                    }, null);
                }
                catch (Exception err) {
                    Sync.Send(delegate {
                        MessageBox.Show(parent, "失敗しました：\n\n" + err.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        form.Done();
                        ul.UpdateList();
                    }, null);
                }
            }
        }

        public class UserCancelException : Exception {
            public UserCancelException()
                : base("ご要望により、中止しました。") {

            }
        }

        private void lvF_KeyDown(object sender, KeyEventArgs e) {
            if (!e.Alt && !e.Shift && !e.Control && !e.Handled) {
                switch (e.KeyCode) {
                    case Keys.Delete:
                        e.Handled = true;
                        mDelf.PerformClick();
                        break;
                    case Keys.Back: {
                            e.Handled = true;
                            TreeNode tn = tvF.SelectedNode;
                            if (tn != null) {
                                tn = tn.Parent;
                                if (tn != null) {
                                    tvF.SelectedNode = tn;
                                }
                            }
                            break;
                        }
                    case Keys.F2: {
                            e.Handled = true;
                            mRenf.PerformClick();
                            break;
                        }
                }
            }
            if (!e.Alt && !e.Shift && e.Control && !e.Handled) {
                switch (e.KeyCode) {
                    case Keys.K: {
                            e.Handled = true;
                            mNewDir.PerformClick();
                            break;
                        }
                }
            }
        }

        class DCUt : IDisposable {
            MyDSI3 comm;
            SortedDictionary<String, Dir> dirs = new SortedDictionary<String, Dir>();
            AfpPathType pathType;

            struct Dir {
                public ushort volId;
                public uint dirId;

                public Dir(ushort volId, uint dirId) {
                    this.volId = volId;
                    this.dirId = dirId;
                }
            }

            public DCUt(MyDSI3 comm, AfpPathType pathType) {
                this.comm = comm;
                this.pathType = pathType;
            }

            public DCR ResolveFile(LVol lvol, String mfp) {
                return ResolveFile2(lvol, mfp, false);
            }

            public DCR ResolveFile2(LVol lvol, String mfp, bool parseParent) {
                String[] partsSrc = mfp.Split('\0');
                DCR res = new DCR();
                res.VolumeID = lvol.VolID;
                res.DirectoryID = lvol.DirID;
                res.LastName = mfp;
                res.PathType = pathType;
                if (partsSrc.Length > 0) {
                    String fpaDir = partsSrc[0];
                    res.LastName = partsSrc[partsSrc.Length - 1];
                    for (int p = 0; p < partsSrc.Length - 1; p++) {
                        String relDir = partsSrc[p];
                        Dir dir;
                        if (relDir == "") {
                            int t = fpaDir.LastIndexOf('\0');
                            fpaDir = (t < 0) ? String.Empty : fpaDir.Substring(0, t);
                        }
                        if (fpaDir == "") {
                            res.DirectoryID = 2;
                        }
                        else if (dirs.TryGetValue(fpaDir, out dir)) {
                            res.DirectoryID = dir.dirId;
                        }
                        else if (relDir != "") {
                            TransmitRes res4 = comm.Transmit(new DSICommand().WithRequestPayload(new FPCreateDir()
                                .WithVolumeID(res.VolumeID)
                                .WithDirectoryID(res.DirectoryID)
                                .WithPathType(pathType)
                                .WithPath(relDir)
                                ));
                            if (res4.pack.ErrorCode != 0) {
                                if (res4.pack.ErrorCode != (int)DSIException.ResultCode.kFPObjectExists)
                                    throw new DSIException(res4.pack.ErrorCode, res4.pack);
                                TransmitRes res5 = comm.Transmit(new DSICommand().WithRequestPayload(new FPOpenDir()
                                    .WithVolumeID(res.VolumeID)
                                    .WithDirectoryID(res.DirectoryID)
                                    .WithPathType(pathType)
                                    .WithPath(relDir)
                                    ));
                                if (res5.pack.ErrorCode != 0)
                                    throw new DSIException(res5.pack.ErrorCode, res5.pack);

                                OpenDirPack pack = new OpenDirPack(res5.br);
                                dirs[fpaDir] = new Dir(lvol.VolID, res.DirectoryID = pack.DirectoryID);
                            }
                            else {
                                CreateDirPack pack = new CreateDirPack(res4.br);
                                dirs[fpaDir] = new Dir(lvol.VolID, res.DirectoryID = pack.DirectoryID);
                            }
                        }
                        if (partsSrc[p + 1] != "") {
                            if (fpaDir != "")
                                fpaDir += "\0";
                            fpaDir += partsSrc[p + 1];
                        }
                    }
                }
                return res;
            }

            public DCR ResolveDir2(LVol lvol, String mfp) {
                String[] partsSrc = mfp.Split('\0');
                DCR res = new DCR();
                res.VolumeID = lvol.VolID;
                res.DirectoryID = lvol.DirID;
                res.LastName = "";
                res.PathType = pathType;
                if (partsSrc.Length > 0) {
                    String fpaDir = partsSrc[0];
                    for (int p = 0; p < partsSrc.Length; p++) {
                        String relDir = partsSrc[p];
                        Dir dir;
                        if (relDir == "") {
                            int t = fpaDir.LastIndexOf('\0');
                            fpaDir = (t < 0) ? String.Empty : fpaDir.Substring(0, t);
                        }
                        if (fpaDir == "") {
                            res.DirectoryID = 2;
                        }
                        else if (dirs.TryGetValue(fpaDir, out dir)) {
                            res.DirectoryID = dir.dirId;
                        }
                        else if (relDir != "") {
                            TransmitRes res4 = comm.Transmit(new DSICommand().WithRequestPayload(new FPCreateDir()
                                .WithVolumeID(res.VolumeID)
                                .WithDirectoryID(res.DirectoryID)
                                .WithPathType(pathType)
                                .WithPath(relDir)
                                ));
                            if (res4.pack.ErrorCode != 0) {
                                if (res4.pack.ErrorCode != (int)DSIException.ResultCode.kFPObjectExists)
                                    throw new DSIException(res4.pack.ErrorCode, res4.pack);
                                TransmitRes res5 = comm.Transmit(new DSICommand().WithRequestPayload(new FPOpenDir()
                                    .WithVolumeID(res.VolumeID)
                                    .WithDirectoryID(res.DirectoryID)
                                    .WithPathType(pathType)
                                    .WithPath(relDir)
                                    ));
                                if (res5.pack.ErrorCode != 0)
                                    throw new DSIException(res5.pack.ErrorCode, res5.pack);

                                OpenDirPack pack = new OpenDirPack(res5.br);
                                dirs[fpaDir] = new Dir(lvol.VolID, res.DirectoryID = pack.DirectoryID);
                            }
                            else {
                                CreateDirPack pack = new CreateDirPack(res4.br);
                                dirs[fpaDir] = new Dir(lvol.VolID, res.DirectoryID = pack.DirectoryID);
                            }
                        }
                        if (p + 1 == partsSrc.Length)
                            continue;
                        if (partsSrc[p + 1] != "") {
                            if (fpaDir != "")
                                fpaDir += "\0";
                            fpaDir += partsSrc[p + 1];
                        }
                    }
                }
                return res;
            }

            #region IDisposable メンバ

            public void Dispose() {
                foreach (Dir dir in dirs.Values) {
                    try {
                        TransmitRes res5 = comm.Transmit(new DSICommand().WithRequestPayload(new FPCloseDir()
                            .WithVolumeID(dir.volId)
                            .WithDirectoryID(dir.dirId)
                            ));

                    }
                    catch (DSIException) {

                    }
                }
            }

            #endregion
        }

        class DCR {
            public ushort VolumeID;
            public uint DirectoryID;
            public String LastName;
            public AfpPathType PathType;
        }

        class DHXUt {
            public static IntX g { get { return 0x07; } }
            public static IntX p {
                get {
                    return new IntX(DigitConverter.FromBytes(B2L(new byte[] { 0xBA, 0x28, 0x73, 0xDF, 0xB0, 0x60, 0x57, 0xD4, 0x3F, 0x20, 0x24, 0x74, 0x4C, 0xEE, 0xE7, 0x5B })), false);
                }
            }

            public static byte[] B2L(byte[] bin) {
                byte[] bin2 = (byte[])bin.Clone();
                Array.Reverse(bin2);
                return bin2;
            }

            public static byte[] L2B(byte[] bin) {
                byte[] bin2 = (byte[])bin.Clone();
                Array.Reverse(bin2);
                return bin2;
            }

            public static byte[] GetBytesLE(IntX val) {
                uint[] digits;
                bool negative;
                val.GetInternalState(out digits, out negative);
                Trace.Assert(!negative);
                return DigitConverter.ToBytes(digits);
            }

            public static byte[] GetBytesBE(IntX val) {
                return L2B(GetBytesLE(val));
            }

            public static IntX GetIntXfrmLE(byte[] bin) {
                return new IntX(DigitConverter.FromBytes(bin), false);
            }

            public static IntX GetIntXfrmBE(byte[] bin) {
                return GetIntXfrmLE(B2L(bin));
            }

            public static IntX PowerMod(IntX b, IntX e, IntX m) {
                IntX result = 1;

                while (e > 0) {
                    if ((e % 2) == 1) result = (result * b) % m;
                    e >>= 1;
                    b = (b * b) % m;
                }

                return result;
            }

            public static IntX RandX(int cb) {
                byte[] bin = new byte[cb];
                new Random().NextBytes(bin);
                return new IntX(DigitConverter.FromBytes(bin), false);
            }

            public static byte[] Cut(byte[] bin, int x, int cx) {
                byte[] buff = new byte[cx];
                for (int i = 0; i < cx; i++) buff[i] = bin[x + i];
                return buff;
            }

            public static byte[] S2CIV { get { return new byte[] { 0x43, 0x4a, 0x61, 0x6c, 0x62, 0x65, 0x72, 0x74 }; } }
            public static byte[] C2SIV { get { return new byte[] { 0x4c, 0x57, 0x61, 0x6c, 0x6c, 0x61, 0x63, 0x65 }; } }
        }

        class UtDHXv2Cont {
            public UtDHXv2 dhx1;
            public IntX Nonce1, ServerNonce;

            public UtDHXv2Cont(UtDHXv2 dhx1, byte[] body) {
                this.dhx1 = dhx1;

                CastCipher cc = new CastCipher(dhx1.GetK(), new CbcCipherMode(DHXUt.S2CIV), null);
                body = cc.Decrypt(body);

                Nonce1 = DHXUt.GetIntXfrmBE(DHXUt.Cut(body, 0, 16));
                ServerNonce = DHXUt.GetIntXfrmBE(DHXUt.Cut(body, 16, 16));
            }

            public byte[] Compute(String passwd) {
                return Compute(Encoding.UTF8.GetBytes(passwd));
            }

            public byte[] Compute(byte[] passwd) {
                CastCipher cc = new CastCipher(dhx1.GetK(), new CbcCipherMode(DHXUt.C2SIV), null);
                byte[] bin = new byte[16 + 256];
                Buffer.BlockCopy(DHXUt.GetBytesBE(ServerNonce + 1), 0, bin, 0, 16);
                Buffer.BlockCopy(passwd, 0, bin, 16, Math.Min(256, passwd.Length));
                return cc.Encrypt(bin);
            }
        }

        class UtDHXv2 {
            public uint g;
            public IntX p, Mb, Ma;
            public IntX Nonce = DHXUt.RandX(16);
            public IntX Ra = DHXUt.RandX(8);

            public UtDHXv2(uint g, byte[] pBytes, byte[] MbBytes) {
                if (pBytes.Length != MbBytes.Length) throw new ArgumentException();

                this.g = g;
                this.p = DHXUt.GetIntXfrmBE(pBytes);
                this.Mb = DHXUt.GetIntXfrmBE(MbBytes);

                this.Ma = DHXUt.PowerMod(g, Ra, p);
            }

            public byte[] GetMa() {
                return DHXUt.GetBytesBE(Ma);
            }

            IntX K {
                get {
                    return DHXUt.PowerMod(Mb, Ra, p);
                }
            }

            public byte[] GetK() {
                byte[] bin = DHXUt.GetBytesBE(K);
                Debug.Assert(bin.Length == 64);
                return (MD5.Create().ComputeHash(bin));
            }

            public byte[] Compute() {
                CastCipher cc = new CastCipher(GetK(), new CbcCipherMode(DHXUt.C2SIV), null);
                byte[] bin = cc.Encrypt(DHXUt.GetBytesBE(Nonce));
                if (bin.Length != 16) throw new Exception("Client nonce length " + bin.Length + " != 16");
                return bin;
            }
        }

        class UtDHCAST128 {
            public IntX Ra = DHXUt.RandX(12);

            public IntX Ma {
                get {
                    Debug.Assert(Ra <= DHXUt.p - 2);
                    return DHXUt.PowerMod(DHXUt.g, Ra, DHXUt.p);
                }
            }

            public byte[] GetMa() {
                return DHXUt.GetBytesBE(Ma);
            }
        }

        class UtDHCAST128Cont {
            UtDHCAST128 dhx1;
            IntX Mb;

            public IntX Nonce;
            public IntX ServerSig;

            IntX K {
                get {
                    return DHXUt.PowerMod(Mb, dhx1.Ra, DHXUt.p);
                }
            }

            byte[] GetK() {
                return DHXUt.GetBytesBE(K);
            }

            public UtDHCAST128Cont(UtDHCAST128 dhx1, byte[] MbBytes, byte[] NonceServerSig) {
                if (MbBytes.Length != 16) throw new ArgumentException();
                if (NonceServerSig.Length != 32) throw new ArgumentException();

                this.dhx1 = dhx1;

                this.Mb = DHXUt.GetIntXfrmBE(MbBytes);

                CastCipher cc = new CastCipher(GetK(), new CbcCipherMode(DHXUt.S2CIV), null);
                byte[] bin = cc.Decrypt(NonceServerSig);

                this.Nonce = DHXUt.GetIntXfrmBE(DHXUt.Cut(bin, 0, 16));
                this.ServerSig = DHXUt.GetIntXfrmBE(DHXUt.Cut(bin, 16, 16));
            }

            public byte[] Compute(String passwd) {
                return Compute(Encoding.UTF8.GetBytes(passwd));
            }

            public byte[] Compute(byte[] passwd) {
                byte[] bin = new byte[80];
                Buffer.BlockCopy(DHXUt.GetBytesBE(Nonce + 1), 0, bin, 0, 16);
                Buffer.BlockCopy(passwd, 0, bin, 16, Math.Min(passwd.Length, 64));

                CastCipher cc = new CastCipher(GetK(), new CbcCipherMode(DHXUt.C2SIV), null);
                return cc.Encrypt(bin);
            }
        }

        private void bTypData_Click(object sender, EventArgs e) {
            if (object.ReferenceEquals(sender, bTypData)) Settings.Default.ForkTyp = 0;
            if (object.ReferenceEquals(sender, bTypNews)) Settings.Default.ForkTyp = 1;
            if (object.ReferenceEquals(sender, bTypMacOSX)) Settings.Default.ForkTyp = 2;

            Settings.Default.Save();

            UpdTyp();

            TreeNode tn = tvF.SelectedNode;
            if (tn == null) return;

            LBaseDir lbd = tn.Tag as LBaseDir;
            if (lbd == null) return;

            Listup(lbd);
        }

        private void bAbout_Click(object sender, EventArgs e) {
            using (AboutForm form = new AboutForm()) {
                form.ShowDialog(this);
            }
        }

        private void mDelf_Click(object sender, EventArgs e) {
            TreeNode tn = tvF.SelectedNode;
            if (tn == null) return;
            LBaseDir lbd = tn.Tag as LBaseDir;
            if (lbd == null) return;
            LPC lpc = lbd.lvol.lpc;

            lbd.lvol.ConnectUpper();

            DialogResult input = DialogResult.None;
            IVerDesc vd = lpc;
            Queue<KeyValuePair<LBaseDir, FEnt>> list = new Queue<KeyValuePair<LBaseDir, FEnt>>();
            Stack<KeyValuePair<LBaseDir, FEnt>> dirs = new Stack<KeyValuePair<LBaseDir, FEnt>>();
            foreach (ListViewItem lvi in lvF.SelectedItems) {
                FEnt fe = lvi.Tag as FEnt;
                if (fe == null) continue;
                list.Enqueue(new KeyValuePair<LBaseDir, FEnt>(lbd, fe));
            }
            bool any = false;
            using (DCUt dcut = new DCUt(lpc.Comm, lpc.MaxPathType)) {
                while (list.Count != 0) {
                    KeyValuePair<LBaseDir, FEnt> kv = list.Dequeue();
                    FEnt fe = kv.Value;
                    if (fe == null) continue;
                    if (!fe.IsData) continue;

                    if (input != DialogResult.Retry) {
                        using (IfDelForm form = new IfDelForm()) {
                            form.tbF.Text = fe.RefPath;
                            input = form.ShowDialog(this);
                        }
                        if (input == DialogResult.Cancel) return;
                        if (input == DialogResult.No) continue;
                    }

                    //Debug.WriteLine(fe.RefPath);
                    if (fe.IsDir) {
                        dirs.Push(new KeyValuePair<LBaseDir, FEnt>(kv.Key, fe));

                        LDir ldir = COUt.Combine(kv.Key, fe);
                        EnumDir(ldir, null);

                        foreach (FileParameters ent in ldir.ents) {
                            foreach (FEnt lfe in Gen(ent, ldir)) {
                                list.Enqueue(new KeyValuePair<LBaseDir, FEnt>(ldir, lfe));
                            }
                        }
                    }
                    else {
                        DCR dcr = dcut.ResolveFile(kv.Key.lvol, fe.MacPath);
                        TransmitRes res = lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPDelete()
                            .WithVolumeID(dcr.VolumeID)
                            .WithDirectoryID(dcr.DirectoryID)
                            .WithPath(dcr.LastName)
                            .WithPathType(dcr.PathType)
                        ));
                        any = true;

                        if (!res.pack.IsResponse) throw new InvalidDataException();
                        if (res.pack.ErrorCode != 0) RUt.ReportErr(logging, res, "ファイル削除"); //throw new DSIException(res.pack.ErrorCode, res.pack);
                    }
                }
                while (dirs.Count != 0) {
                    KeyValuePair<LBaseDir, FEnt> kv = dirs.Pop();
                    FEnt fe = kv.Value;

                    DCR dcr = dcut.ResolveFile(kv.Key.lvol, fe.MacPath);

                    TransmitRes res = lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPDelete()
                        .WithVolumeID(dcr.VolumeID)
                        .WithDirectoryID(dcr.DirectoryID)
                        .WithPath(dcr.LastName)
                        .WithPathType(dcr.PathType)
                    ));
                    any = true;

                    if (!res.pack.IsResponse) throw new InvalidDataException();
                    if (res.pack.ErrorCode != 0) RUt.ReportErr(logging, res, "フォルダ削除"); //throw new DSIException(res.pack.ErrorCode, res.pack);
                }
            }
            if (any) UpdateSel(tvF.SelectedNode, true);
        }

        class COUt {
            internal static LDir Combine(LBaseDir lbd, FEnt ent) {
                LDir ldir = new LDir();
                ldir.lvol = lbd.lvol;
                ldir.ent = ent.fe;
                ldir.path = lbd.path + DirSep + ent.fe.Name;
                return ldir;
            }
        }

        delegate void _AddLOG(String p);

        public void AddLOG(String p) {
            if (IsDisposed) return;
            if (InvokeRequired) { Invoke((_AddLOG)AddLOG, p); return; }
            int cx = tbLOG.TextLength;
            tbLOG.Select(cx, 0);
            tbLOG.SelectedText = p.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n");
            tbLOG.Select(cx, p.Length);
        }

        public void AddELog(String p) {
            if (IsDisposed) return;
            if (InvokeRequired) { Invoke((_AddLOG)AddELog, p); return; }
            int cx = tbELog.TextLength;
            tbELog.Select(cx, 0);
            tbELog.SelectedText = p.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n");
            tbELog.Select(cx, p.Length);

            if (tabControl1.SelectedTab != tabPage1) {
                tabControl1.SelectedTab = tabPage1;
            }
        }

        private void mRenf_Click(object sender, EventArgs e) {
            TreeNode tn = tvF.SelectedNode;
            if (tn == null) return;
            LBaseDir lbd = tn.Tag as LBaseDir;
            if (lbd == null) return;
            bool any = false;
            foreach (ListViewItem lvi in new System.Collections.ArrayList(lvF.SelectedItems)) {
                using (RenForm form = new RenForm()) {
                    FEnt fe = lvi.Tag as FEnt;
                    if (fe == null) continue;
                    if (!fe.IsData) continue;
                    form.tb1.Text = form.tb2.Text = fe.RealName;
                    form.Location = PointToScreen(Point.Empty);
                    DialogResult r;
                    if ((r = form.ShowDialog(this)) == DialogResult.Yes) {
                        if (form.fp1 != form.fp2) {
                            String fp1 = Path.Combine(lbd.path, form.fp1);
                            String fp2 = Path.Combine(lbd.path, form.fp2);
                            using (DCUt dcut = new DCUt(lbd.lvol.lpc.Comm, lbd.lvol.lpc.MaxPathType)) {
                                DCR dcr1 = dcut.ResolveFile(lbd.lvol, APUt.EncodeApplePath(fp1));
                                DCR dcr2 = dcut.ResolveFile2(lbd.lvol, APUt.EncodeApplePath2(fp2, '\\'), true);
                                if (dcr1.VolumeID == dcr2.VolumeID) {
                                    if (dcr1.DirectoryID == dcr2.DirectoryID) {
                                        logging.AddLOG("FPRename 発行\n");
                                        TransmitRes res = lbd.lvol.lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPRename()
                                            .WithVolumeID(dcr1.VolumeID)
                                            .WithDirectoryID(dcr1.DirectoryID)
                                            .WithPathType(dcr1.PathType)
                                            .WithPath(dcr1.LastName)
                                            .WithNewType(dcr2.PathType)
                                            .WithNewPath(dcr2.LastName)
                                            ));
                                        any = true;
                                        RUt.Report(logging, res);
                                        if (res.pack.IsResponse && res.pack.ErrorCode != 0) RUt.ReportErr(logging, res, "名前変更");
                                    }
                                    else {
                                        logging.AddLOG("FPMoveAndRename 発行\n");
                                        TransmitRes res = lbd.lvol.lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPMoveAndRename()
                                            .WithVolumeID(dcr1.VolumeID)
                                            .WithSourceDirectoryID(dcr1.DirectoryID)
                                            .WithDestDirectoryID(dcr2.DirectoryID)
                                            .WithSourcePathType(dcr1.PathType)
                                            .WithSourcePath(dcr1.LastName)
                                            .WithDestPathType(dcr2.PathType)
                                            .WithDestPath("")
                                            .WithNewType(dcr2.PathType)
                                            .WithNewName(dcr2.LastName)
                                            ));
                                        any = true;
                                        RUt.Report(logging, res);
                                        if (res.pack.IsResponse && res.pack.ErrorCode != 0) RUt.ReportErr(logging, res, "移動と名前変更");
                                    }
                                }
                            }
                        }
                    }
                    else if (r == DialogResult.No) {
                        // Skip it
                    }
                    else break;
                }
            }
            if (any) UpdateSel(tvF.SelectedNode, true);
        }

        private void mNewDir_Click(object sender, EventArgs e) {
            TreeNode tn = tvF.SelectedNode;
            if (tn == null) return;
            LBaseDir lbd = tn.Tag as LBaseDir;
            if (lbd == null) return;
            using (NewDirForm form = new NewDirForm()) {
                form.Location = PointToScreen(Point.Empty);
                if (form.ShowDialog(this) == DialogResult.Yes) {
                    if (!String.IsNullOrEmpty(form.fp1)) {
                        String fp1 = Path.Combine(lbd.path, form.fp1);
                        using (DCUt dcut = new DCUt(lbd.lvol.lpc.Comm, lbd.lvol.lpc.MaxPathType)) {
                            DCR dcr = dcut.ResolveFile(lbd.lvol, APUt.EncodeApplePath(fp1));
                            logging.AddLOG("FPCreateDir 発行\n");
                            TransmitRes res = lbd.lvol.lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPCreateDir()
                                .WithVolumeID(dcr.VolumeID)
                                .WithDirectoryID(dcr.DirectoryID)
                                .WithPathType(dcr.PathType)
                                .WithPath(dcr.LastName)
                                ));
                            RUt.Report(logging, res);
                            if (res.pack.IsResponse && res.pack.ErrorCode != 0) RUt.ReportErr(logging, res, "フォルダ作成");
                            UpdateSel(tvF.SelectedNode, true);
                        }
                    }
                }
            }
        }

        private void bNoTimeout_Click(object sender, EventArgs e) {
            Settings.Default.NoTimeout = !Settings.Default.NoTimeout;
            UpdTyp();
        }


        #region IUpdateList メンバ

        public void UpdateList() {
            UpdateSel(tvF.SelectedNode, true);
        }

        #endregion
    }

    public interface IAddLOG {
        void AddLOG(String rows);
        void AddELog(String rows);
    }

    public interface IUpdateList {
        void UpdateList();
    }

    public interface IVerDesc {
        bool HasFPUTF8Name { get; }
        bool FPHasReadExt { get; }
        bool HasFPWriteExt { get; }
        bool HasFPEnumerateExt { get; }
        bool HasFPEnumerateExt2 { get; }
        bool UseUTC { get; }
    }
}