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
using Microsoft.Win32;

namespace AFPClient4Windows {
    public partial class MForm : Form, IHostParm {
        public MForm() {
            InitializeComponent();
        }

        private void MForm_Load(object sender, EventArgs e) {
            DelRefs.Add(lpc);

            Naviloc(Environment.CurrentDirectory);
        }

        private void Naviloc(String dir) {
            cbDirLoc.Items.Add(dir);
            cbDirLoc.Text = dir;

            lvLoc.Items.Clear();

            foreach (String fp in Directory.GetDirectories(dir)) {
                ListViewItem lvi = new ListViewItem(Path.GetFileName(fp));
                lvi.SubItems.Add("");
                lvi.SubItems.Add("");
                lvi.SubItems.Add(new FileInfo(fp).LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss"));
                lvi.ImageKey = "Dir";
                lvi.Tag = fp;
                lvLoc.Items.Add(lvi);
            }
            foreach (LFEnt lf in LFLUt.GetFiles(dir)) {
                String fp = lf.fp;
                FileInfo fi = new FileInfo(fp);
                FileInfo fir = (lf.fpr != null) ? new FileInfo(lf.fpr) : null;
                ListViewItem lvi = new ListViewItem(Path.GetFileName(lf.fn));
                lvi.SubItems.Add(String.Format("{0:##,#0}", fi.Length));
                lvi.SubItems.Add(String.Format("{0:##,#0}", (fir != null) ? fir.Length : 0));
                lvi.SubItems.Add(fi.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss"));
                lvi.ImageKey = "File";
                lvi.Tag = fp;
                lvLoc.Items.Add(lvi);
            }
        }

        class LFEnt {
            public String fp, fpr, fn;
        }
        class LFLUt {
            public static IEnumerable<LFEnt> GetFiles(String dir) {
                foreach (String fp in Directory.GetFiles(dir)) {
                    LFEnt lf = new LFEnt();
                    lf.fn = Path.GetFileName(fp);
                    if (lf.fn.StartsWith("._")) continue;
                    lf.fp = fp;
                    String fpr = Path.Combine(dir, "._" + lf.fn);
                    if (File.Exists(fpr)) lf.fpr = fpr;
                    yield return lf;
                }
            }
        }

        private void mConn_Click(object sender, EventArgs e) {
            using (HostsForm form = new HostsForm(this)) {
                if (form.ShowDialog() == DialogResult.OK) {
                    CloseAFP();
                    DelRefs.Add(lpc);
                    try {
                        lpc.Connect(form.SelHost);
                    }
                    catch (Exception err) {
                        MessageBox.Show(this, "接続に失敗しました：" + err.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    TransmitRes res = lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPGetSrvrParms()
                        ));
                    if (!res.pack.IsResponse || res.pack.ErrorCode != 0) throw new DSIException(res.pack.ErrorCode, res.pack);

                    GetSrvrParmsPack pack = new GetSrvrParmsPack(res.br);

                    cmsVols.Items.Clear();

                    foreach (VolStruc vs in pack.Volumes) {
                        LVol lvol1 = new LVol(lpc, vs.VolName);

                        ToolStripItem tsiVol = cmsVols.Items.Add(lvol1.VolName);
                        tsiVol.Click += new EventHandler(tsiVol_Click);
                        tsiVol.Tag = lvol1;
                    }

                    bPCRem.Text = lpc.RemoteHost;
                    yh = form.SelHost;

                    if (yh.HostVol.Length == 0) {
                        bVolRem_Click(sender, e);
                        return;
                    }

                    lvol = new LVol(lpc, yh.HostVol);
                    try {
                        lvol.ConnectUpper();
                    }
                    catch (Exception err) {
                        MessageBox.Show(this, "接続に失敗しました：" + err.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    bVolRem.Text = lvol.VolName;
                    Navi(yh.RemoteDir);
                }
            }

        }

        void tsiVol_Click(object sender, EventArgs e) {
            lvol = new LVol(lpc, ((LVol)((ToolStripItem)sender).Tag).VolName);
            try {
                lvol.ConnectUpper();
            }
            catch (Exception err) {
                MessageBox.Show(this, "接続に失敗しました：" + err.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            bVolRem.Text = lvol.VolName;
            Navi("");
            if (saveIndex >= 0) {
                Cnf.SaveVol(saveIndex, bVolRem.Text);
            }
        }

        CHost yh = null;
        LPC lpc = new LPC();
        LVol lvol = null;

        class LPC : IDisposable {
            IPEndPoint afp;

            public bool Connected { get { return avail; } }

            const string kNoUserAuthStr = "No User Authent";
            const string kClearTextUAMStr = "Cleartxt Passwrd";
            const string kTwoWayRandNumUAMStr = "2-Way Randnum";

            public string afpVer = "AFP2.2";

            public string Name { get { return afp.ToString(); } }

            internal CHost cHost = null;

            MyDSI3 comm = null;

            public MyDSI3 Comm { get { return comm; } }

            public String RemoteHost { get { return afp.Address.ToString(); } }

            void ConnectUpper() {
                GetSrvrInfoPack pack;

                using (comm = new MyDSI3(afp)) {
                    TransmitRes res = comm.Transmit(new DSIGetStatus());
                    Debug.Assert(res.pack.IsResponse && res.pack.ErrorCode == 0);

                    pack = new GetSrvrInfoPack(res.br);

                    Debug.Assert(pack.AFPVersionsList.Contains("AFP2.2"));
                }

                comm = new MyDSI3(afp);

                {
                    TransmitRes res = comm.Transmit(new DSIOpenSession());
                    Debug.Assert(res.pack.IsResponse && res.pack.ErrorCode == 0);
                }

                {
                    bool authDone = false;
                    if (!authDone && cHost.cb2WayRandnumExchange && pack.UAMsList.Contains(kTwoWayRandNumUAMStr)) {

                        TransmitRes res3 = comm.Transmit(new DSICommand().WithRequestPayload(new FPLogin_2w()
                            .WithAFPVersion(afpVer)
                            .WithUserID(cHost.UserName)
                            ));
                        if (res3.pack.IsResponse && res3.pack.ErrorCode == (int)DSIException.ResultCode.kFPAuthContinue) {
                            TwoWay1stPack blk3 = new TwoWay1stPack(res3.br);

                            byte[] key_buffer = Encoding.ASCII.GetBytes(cHost.Password.PadRight(8, '\0').Substring(0, 8));
                            byte carry = (byte)(key_buffer[0] >> 7);
                            int i;
                            for (i = 0; i < 7; i++) {
                                key_buffer[i] = (byte)((key_buffer[i] << 1) | (key_buffer[i + 1] >> 7));
                            }
                            key_buffer[i] = (byte)((key_buffer[i] << 1) | carry);

                            byte[] encPasswd = new byte[8];
                            DES cipher = DESCryptoServiceProvider.Create();
                            cipher.Mode = CipherMode.ECB;
                            cipher.Padding = PaddingMode.None;
                            ICryptoTransform tf = cipher.CreateEncryptor(key_buffer, key_buffer);
                            tf.TransformBlock(blk3.ServerKey, 0, 8, encPasswd, 0);

                            byte[] randKey = new byte[8];
                            new Random().NextBytes(randKey);

                            TransmitRes res4 = comm.Transmit(new DSICommand().WithRequestPayload(new FPLogin_2w_2()
                                .WithContID(blk3.Id)
                                .WithRandKey(randKey)
                                .WithEncPasswd(encPasswd)
                                ));
                            if (res4.pack.IsResponse && res4.pack.ErrorCode == 0) {
                                TwoWay2ndPack blk4 = new TwoWay2ndPack(res4.br);
                                byte[] randKeyEnc = new byte[8];
                                tf.TransformBlock(randKey, 0, 8, randKeyEnc, 0);

                                bool agree = true;
                                for (int t = 0; t < 8; t++) agree &= (blk4.ClientKey[t] == randKeyEnc[t]);

                                if (agree) {
                                    authDone = true;
                                }
                            }
                        }

                    }

                    if (!authDone && cHost.cbCleartxtPasswrd && pack.UAMsList.Contains(kClearTextUAMStr)) {

                        TransmitRes res3 = comm.Transmit(new DSICommand().WithRequestPayload(new FPLogin_Cleartext_Password()
                            .WithAFPVersion(afpVer)
                            .WithUserName(cHost.UserName)
                            .WithPasswd(cHost.Password)
                        ));
                        if (res3.pack.IsResponse && res3.pack.ErrorCode == 0) {
                            authDone = true;
                        }

                    }

                    if (!authDone && cHost.cbNoUserAuthent && pack.UAMsList.Contains(kNoUserAuthStr)) {

                        TransmitRes res3 = comm.Transmit(new DSICommand().WithRequestPayload(new FPLogin()
                            .WithAFPVersion(afpVer)
                        ));
                        if (res3.pack.IsResponse && res3.pack.ErrorCode == 0) {
                            authDone = true;
                        }

                    }

                    if (!authDone) {
                        throw new UnauthorizedAccessException("認証に失敗しました。");
                    }
                    else {
                        avail = true;
                    }
                }
            }

            bool avail = false;

            private void Disconnect() {
                avail = false;

                if (comm != null) {
                    comm.Dispose();
                    comm = null;
                }
            }

            #region IDisposable メンバ

            public void Dispose() {
                Disconnect();
            }

            #endregion

            internal void Connect(CHost cHost) {
                Disconnect();
                this.cHost = cHost;

                IPAddress adr = null;
                IPHostEntry h;
                if (IPAddress.TryParse(cHost.HostAdrs, out adr)) {

                }
                else if ((h = Dns.GetHostEntry(cHost.HostAdrs)) != null && h.AddressList.Length != 0) {
                    adr = h.AddressList[0];
                }

                afp = new IPEndPoint((adr), 548);

                ConnectUpper();
            }
        }

        class LBaseDir : IDisposable {
            public List<FileParameters> ents = new List<FileParameters>();
            public LVol lvol;
            public string path;

            public bool isListed = false;
            public Exception listErr = null;

            #region IDisposable メンバ

            public void Dispose() {
                ents.Clear();
            }

            #endregion
        }

        class LVol : LBaseDir, IDisposable {
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

            public void ConnectUpper() {
                if (avail) return;

                TransmitRes res = lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPOpenVol()
                    .WithBitmap(AfpVolumeBitmap.kFPVolIDBit)
                    .WithVolumeName(volName)
                ));
                if (!res.pack.IsResponse || res.pack.ErrorCode != 0) throw new DSIException(res.pack.ErrorCode, res.pack);

                OpenVolPack pack = new OpenVolPack(res.br);

                volId = pack.Ent.VolID.Value;

                avail = true;
                lvol = this;
            }

        }

        private void Listup(LBaseDir lbd) {
            lvRem.Items.Clear();
            if (lbd == null) return;
            foreach (FileParameters ent in lbd.ents) {
                FEnt fe = new FEnt(ent, lbd);
                ListViewItem lvi = new ListViewItem(fe.Name);
                lvi.SubItems.Add(fe.IsDir ? "" : String.Format("{0:##,#0}", fe.DataSize));
                lvi.SubItems.Add(fe.IsDir ? "" : String.Format("{0:##,#0}", fe.ResSize));
                lvi.SubItems.Add(fe.FormatMT());
                lvi.ImageKey = fe.IsDir ? "Dir" : "File";
                lvi.Tag = fe;
                lvRem.Items.Add(lvi);
            }
        }

        private bool EnumDir(LBaseDir lbd) {
            lbd.ents.Clear();

            lbd.isListed = false;
            lbd.listErr = null;

            try {
                for (uint pos = 1; ; ) {
                    TransmitRes res = lbd.lvol.lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPEnumerate()
                        .WithDirectoryID(lbd.lvol.DirID)
                        .WithPath(APUt.EncodeApplePath(lbd.path))
                        .WithVolumeID(lbd.lvol.VolID)
                        .WithStartIndex(Convert.ToUInt16(pos))
                        .WithFileBitmap(AfpFileBitmap.DataForkLength | AfpFileBitmap.ResourceForkLength | AfpFileBitmap.ModificationDate | AfpFileBitmap.LongName)
                        ));
                    if (!res.pack.IsResponse) throw new ApplicationException();
                    if (res.pack.ErrorCode == (int)DSIException.ResultCode.kFPObjectNotFound) break;
                    if (res.pack.ErrorCode != 0) throw new DSIException(res.pack.ErrorCode, res.pack);

                    EnumeratePack pack = new EnumeratePack(res.br);

                    lbd.ents.AddRange(pack.Ents);

                    foreach (FileParameters ent in pack.Ents) {
                        LDir ldir = new LDir();
                        ldir.lvol = lbd.lvol;
                        ldir.ent = ent;
                        ldir.path = lbd.path + DirSep + ent.LongName;
                    }

                    pos += pack.ActualCount;
                }
                lbd.isListed = true;
                return true;
            }
            catch (Exception err) {
                MessageBox.Show(this, err.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private TreeNode AddDir(TreeNode tnVol, LDir ldir) {
            TreeNode tn = tnVol.Nodes.Add(ldir.Name);
            tn.Name = ldir.Name;
            tn.ImageKey = tn.SelectedImageKey = "Dir";
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

        List<IDisposable> DelRefs = new List<IDisposable>();

        private void CloseAFP() {
            foreach (IDisposable one in DelRefs) one.Dispose();
            DelRefs.Clear();

            lvRem.Items.Clear();
            cmsVols.Items.Clear();

            bPCRem.Text = "---";
            bVolRem.Text = "---";
            cbDirRem.Text = "";
        }

        private void MForm_FormClosing(object sender, FormClosingEventArgs e) {

        }

        private void MForm_FormClosed(object sender, FormClosedEventArgs e) {
            CloseAFP();
        }

        const char DirSep = ':';

        class FEnt {
            public FileParameters fe;
            public LBaseDir lbd;

            public FEnt(FileParameters fe, LBaseDir lbd) {
                this.fe = fe;
                this.lbd = lbd;
            }

            public string Name { get { return fe.LongName; } }

            public bool IsDir { get { return fe.IsDirectory; } }

            public Int64 DataSize { get { return fe.DataForkSize ?? 0; } }
            public Int64 ResSize { get { return fe.ResourceForkSize ?? 0; } }

            public String FormatMT() { return fe.MT.HasValue ? fe.MT.Value.ToString("yyyy/MM/dd HH:mm:ss") : ""; }

            public DateTime GetMT() { return fe.MT ?? DateTime.Now; }

            public string RefPath {
                get {
                    return (lbd.path + DirSep + Name).TrimStart(DirSep);
                }
            }

            public string MacPath {
                get {
                    return RefPath.TrimStart(DirSep).Replace(DirSep, '\0');
                }
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
                    fx = x.fe.MT.HasValue;
                    fy = y.fe.MT.HasValue;
                    if (!fx || !fy) return fx.CompareTo(fy) * ord;
                    return x.fe.MT.Value.CompareTo(y.fe.MT.Value) * ord;
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
                    fx = x.fe.DataForkSize.HasValue;
                    fy = y.fe.DataForkSize.HasValue;
                    if (!fx || !fy) return fx.CompareTo(fy) * ord;
                    return x.fe.DataForkSize.Value.CompareTo(y.fe.DataForkSize.Value) * ord;
                }

                #endregion
            }
        }

        private void lvRem_ColumnClick(object sender, ColumnClickEventArgs e) {
            bool asc = 0 == (ModifierKeys & Keys.Shift);
            if (e.Column == chfn.Index) lvRem.ListViewItemSorter = new Sort.Str(e.Column, asc);
            if (e.Column == chmt.Index) lvRem.ListViewItemSorter = new Sort.Mt(!asc);
            if (e.Column == chcbData.Index) lvRem.ListViewItemSorter = new Sort.Cb(asc);
        }

        class NUt {
            public static String Clean(String s) {
                if (s.Length == 2 && s[1] == ':' && char.IsLetter(s[0]))
                    return s.Substring(0, 1);

                return Regex.Replace(s, "[\\\\/\\*\\?\\|\\<\\>\"\\:]", "_");
            }
        }

        const string ExtResFork = ".AFP_Resource";
        const string ExtFinderInfo = ".AFP_AfpInfo";

        class AFPath {
            public String fp;
            public String forkType;

            public bool IsDataFork { get { return forkType != ExtResFork && forkType != ExtFinderInfo; } }
            public bool IsResourceFork { get { return forkType == ExtResFork; } }

            public AFPath(String fp) {
                if (false) { }
                else if (String.Compare(Path.GetExtension(fp), ExtResFork, StringComparison.InvariantCultureIgnoreCase) == 0) {
                    this.fp = Path.Combine(Path.GetDirectoryName(fp), Path.GetFileNameWithoutExtension(fp));
                    this.forkType = ExtResFork;
                }
                else if (String.Compare(Path.GetExtension(fp), ExtFinderInfo, StringComparison.InvariantCultureIgnoreCase) == 0) {
                    this.fp = Path.Combine(Path.GetDirectoryName(fp), Path.GetFileNameWithoutExtension(fp));
                    this.forkType = ExtFinderInfo;
                }
                else {
                    this.fp = fp;
                    this.forkType = String.Empty;
                }
            }
        }

        class APUt {
            public static string EncodeApplePath(String fp) {
                return EncodeApplePath(fp, '\\');
            }
            public static string EncodeApplePath(String fp, char sep) {
                return fp.TrimStart(sep).Replace(sep, '\0');
            }
        }

        public class UserCancelException : Exception {
            public UserCancelException()
                : base("ご要望により、中止しました。") {

            }
        }

        private void lvF_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete && !e.Alt && !e.Shift && !e.Control && !e.Handled) {
                e.Handled = true;
            }
        }

        private void bPCRem_Click(object sender, EventArgs e) {
            mConn_Click(sender, e);
        }

        private void bVolRem_Click(object sender, EventArgs e) {
            cmsVols.Show(bVolRem, 0, bVolRem.Height);
        }

        private void lvRem_ItemActivate(object sender, EventArgs e) {
            foreach (ListViewItem lvi in lvRem.SelectedItems) {
                FEnt fe = (FEnt)lvi.Tag;
                if (fe == null) break;

                if (fe.IsDir) {
                    String at = cbDirRem.Text;
                    Navi(((at.Length != 0) ? (at + DirSep) : "") + fe.Name);
                }
                else {
                }

                break;
            }
        }

        private void Navi(String dir) {
            if (!lpc.Connected) {
                mConn_Click(this, new EventArgs());
                return;
            }
            LBaseDir lb = new LBaseDir();
            lb.lvol = lvol;
            lb.path = dir.TrimStart(DirSep).Replace(DirSep, '\0');
            if (EnumDir(lb)) {
                Listup(lb);
                cbDirRem.Text = dir;

                if (saveIndex >= 0) {
                    Cnf.SaveRemoteDir(saveIndex, dir);
                }
            }
        }

        private void bGoRem_Click(object sender, EventArgs e) {
            Navi(cbDirRem.Text);
        }

        private void bUpRem_Click(object sender, EventArgs e) {
            String s = cbDirRem.Text;
            int i = s.LastIndexOf(':');
            String t = (i < 0) ? "" : s.Substring(0, i);
            if (s != t) Navi(t);
        }

        private void mDiscon_Click(object sender, EventArgs e) {
            CloseAFP();
        }

        private void bConn_Click(object sender, EventArgs e) {
            mConn_Click(sender, e);
        }

        private void bDisconn_Click(object sender, EventArgs e) {
            mDiscon_Click(sender, e);
        }

        private void mDown_Click(object sender, EventArgs e) {
            using (WForm form = new WForm()) {
                form.Show(this);
                foreach (ListViewItem lvi in lvRem.SelectedItems) {
                    FEnt fe = (FEnt)lvi.Tag;
                    form.lfp.Text = fe.Name;
                    if (fe.IsDir) {

                    }
                    else {
                        String fn = NUt.Clean(fe.Name);
                        for (int t = 0; t < 2; t++) {
                            bool isResFork = (t == 1);
                            String fpto = Path.Combine(cbDirLoc.Text, isResFork
                                ? "._" + fn
                                : fn);
                            using (FileStream fs = File.Create(fpto)) {
                                OpenForkPack pack;
                                Int64 cbIn = 0;
                                {
                                    TransmitRes res = lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPOpenFork()
                                        .WithVolumeID(lvol.VolID)
                                        .WithDirectoryID(lvol.DirID)
                                        .WithPath(fe.MacPath)
                                        .WithFlag((byte)(isResFork ? 0x80 : 0x00))
                                        .WithAccessMode(AfpAccessMode.Read | AfpAccessMode.DenyWrite)
                                        .WithBitmap(AfpFileBitmap.ModificationDate | (isResFork ? AfpFileBitmap.ResourceForkLength : AfpFileBitmap.DataForkLength))
                                    ));

                                    if (!res.pack.IsResponse) throw new InvalidDataException();
                                    if (res.pack.ErrorCode != 0) throw new DSIException(res.pack.ErrorCode, res.pack);

                                    pack = new OpenForkPack(res.br);

                                }

                                cbIn = isResFork ? pack.Parms.ResourceForkSize.Value : pack.Parms.DataForkSize.Value;

                                int pos = 0;
                                int cb = 4096;
                                byte[] bin;
                                int cbRead;
                                while (true) {
                                    form.SetPos(pos, cbIn);

                                    int cbRest = (int)Math.Min(cbIn - pos, cb);

                                    TransmitRes res = lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPRead()
                                        .WithOffset(Convert.ToInt32(pos))
                                        .WithOForkRefNum(pack.Fork)
                                        .WithReqCount(Convert.ToInt32(cb))
                                    ));

                                    if (!res.pack.IsResponse) throw new InvalidDataException();
                                    if (res.pack.ErrorCode == (int)DSIException.ResultCode.kFPEOFErr) {

                                    }
                                    else if (res.pack.ErrorCode != 0) {
                                        throw new DSIException(res.pack.ErrorCode, res.pack);
                                    }

                                    bin = res.pack.Payload;
                                    cbRead = res.pack.Payload.Length;

                                    fs.Write(bin, 0, cbRead);

                                    pos += cbRead;

                                    if (res.pack.ErrorCode == (int)DSIException.ResultCode.kFPEOFErr) {
                                        break;
                                    }
                                }

                                fs.Close();

                                {
                                    TransmitRes res2 = lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPCloseFork()
                                        .WithFork(pack.Fork)
                                    ));
                                }

                                if (pack.Parms.MT.HasValue) File.SetLastWriteTime(fpto, pack.Parms.MT.Value);
                            }

                            if (isResFork) File.SetAttributes(fpto, File.GetAttributes(fpto) | FileAttributes.Hidden);
                        }
                    }
                }
            }
            bGoLoc_Click(sender, e);
        }

        private void bGoLoc_Click(object sender, EventArgs e) {
            Naviloc(cbDirLoc.Text);
        }

        private void bUpLoc_Click(object sender, EventArgs e) {
            String s = cbDirLoc.Text;
            int i = s.LastIndexOf('\\');
            String t = (i < 0) ? "" : s.Substring(0, i);
            if (s != t) Naviloc(t);
        }

        #region IHostParm メンバ

        int saveIndex = -1;

        public void SetSaveDir2Reg(int saveIndex) {
            this.saveIndex = saveIndex;
        }

        public string GetDirRem() {
            return cbDirRem.Text;
        }

        #endregion

        private void mUp_Click(object sender, EventArgs e) {
            using (WForm form = new WForm()) {
                form.Show(this);
                foreach (ListViewItem lvi in lvLoc.SelectedItems) {
                    String fpfrm = lvi.Tag as String;
                    if (String.IsNullOrEmpty(fpfrm)) continue;
                    String fpfork = Path.Combine(Path.GetDirectoryName(fpfrm), "._" + Path.GetFileName(fpfrm));
                    FileInfo fifrm = new FileInfo(fpfrm);

                    if (0 != (fifrm.Attributes & FileAttributes.Directory)) {

                    }
                    else {
                        for (int t = 0; t < 2; t++) {
                            bool isResFork = (t == 1);
                            String fpMac2 = cbDirRem.Text + ":" + Path.GetFileName(fpfrm);
                            if (t == 0) {
                                TransmitRes res = lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPCreateFile()
                                    .WithVolumeID(lvol.VolID)
                                    .WithDirectoryID(lvol.DirID)
                                    .WithPath(APUt.EncodeApplePath(fpMac2, ':'))
                                    .WithHardCreate()
                                ));

                                if (!res.pack.IsResponse) throw new InvalidDataException();
                                if (res.pack.ErrorCode != 0) throw new DSIException(res.pack.ErrorCode, res.pack);
                            }
                            if (t == 1 && (fpfork == null || !File.Exists(fpfork))) continue;
                            using (FileStream fs = File.OpenRead(isResFork ? fpfork : fpfrm)) {
                                OpenForkPack pack;
                                {
                                    TransmitRes res = lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPOpenFork()
                                        .WithVolumeID(lvol.VolID)
                                        .WithDirectoryID(lvol.DirID)
                                        .WithPath(APUt.EncodeApplePath(fpMac2, ':'))
                                        .WithOpenForkOfData(!isResFork)
                                        .WithAccessMode(AfpAccessMode.Write | AfpAccessMode.DenyWrite)
                                    ));

                                    if (!res.pack.IsResponse) throw new InvalidDataException();
                                    if (res.pack.ErrorCode != 0) throw new DSIException(res.pack.ErrorCode, res.pack);

                                    pack = new OpenForkPack(res.br);
                                }

                                int pos = 0;
                                Int64 cbIn = fs.Length;
                                BinaryReader br = new BinaryReader(fs);
                                while (fs.Position < fs.Length) {
                                    form.SetPos(pos, cbIn);

                                    byte[] bin = br.ReadBytes(4096);

                                    TransmitRes res = lpc.Comm.Transmit(new DSIWrite().WithRequestPayload(new FPWrite()
                                        .WithOffset(Convert.ToInt32(pos))
                                        .WithOForkRefNum(pack.Fork)
                                        .WithReqCount(Convert.ToInt32(bin.Length))
                                        .WithForkData(bin)
                                    ));

                                    if (!res.pack.IsResponse) throw new InvalidDataException();
                                    if (res.pack.ErrorCode != 0) {
                                        throw new DSIException(res.pack.ErrorCode, res.pack);
                                    }

                                    pos += bin.Length;
                                }

                                {
                                    TransmitRes res2 = lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPCloseFork()
                                        .WithFork(pack.Fork)
                                    ));
                                }

                                fs.Close();

                                {
                                    FileParameters2 Parms2 = new FileParameters2(false)
                                        .WithModificationDate(fifrm.LastWriteTimeUtc);
                                    TransmitRes res = lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPSetFileDirParms()
                                        .WithVolumeID(lvol.VolID)
                                        .WithDirectoryID(lvol.DirID)
                                        .WithPath(APUt.EncodeApplePath(fpMac2, ':'))
                                        .WithParms2(Parms2)
                                    ));
                                }
                            }
                        }
                    }
                }
            }
            bGoRem_Click(sender, e);
        }

        private void timerTickle_Tick(object sender, EventArgs e) {
            if (IsDisposed) return;

            if (lpc == null || !lpc.Connected) return;

            lpc.Comm.Tickle();
        }

        private void lvLoc_ItemActivate(object sender, EventArgs e) {

        }
    }

    public interface IHostParm {
        void SetSaveDir2Reg(int saveIndex);
        String GetDirRem();
    }
}