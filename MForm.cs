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

namespace AFPClient4Windows {
    public partial class MForm : Form {
        public MForm() {
            InitializeComponent();
        }

        private void MForm_Load(object sender, EventArgs e) {

        }

        private void mConn_Click(object sender, EventArgs e) {
            using (ConnForm form = new ConnForm()) {
                if (form.ShowDialog() == DialogResult.OK) {
                    CloseAFP();
                    LPC lpc = new LPC();
                    lpc.afp = new IPEndPoint(IPAddress.Parse(form.tbHost.Text), 548);
                    lpc.fNoUserAuthStr = form.cb0.Checked;
                    lpc.fClearTextUAMStr = form.cb1.Checked;
                    lpc.fTwoWayRandNumUAMStr = form.cb2w.Checked;
                    lpc.userId = form.tbU.Text;
                    lpc.passwd = form.tbP.Text;
                    lpc.hostDir = form.tbHostDir.Text;
                    DelRefs.Add(lpc);

                    TreeNode tnPC = AddPC(lpc);

                    try {
                        EnumPC(lpc, tnPC, 1);

                        if (!String.IsNullOrEmpty(lpc.hostDir)) {
                            TreeNode tnCur = tnPC;
                            tvF.SelectedNode = tnCur;
                            foreach (String part in lpc.hostDir.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries)) {
                                UpdateSel(tnCur, false);
                                tnCur = tnCur.Nodes[part];
                                if (tnCur == null) break;
                                tvF.SelectedNode = tnCur;
                            }
                        }
                    }
                    catch (Exception err) {
                        MessageBox.Show(this, "失敗しました:\n\n" + err.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
        }

        public interface IHier {
            void ConnectUpper();
        }

        class LPC : IHier, IDisposable {
            public IPEndPoint afp;

            const string kNoUserAuthStr = "No User Authent";
            const string kClearTextUAMStr = "Cleartxt Passwrd";
            const string kTwoWayRandNumUAMStr = "2-Way Randnum";

            public bool fNoUserAuthStr = false;
            public bool fClearTextUAMStr = false;
            public bool fTwoWayRandNumUAMStr = false;
            public String userId, passwd, afpVer = "AFP2.2", hostDir;

            public string Name { get { return afp.ToString(); } }

            MyDSI3 comm = null;

            public MyDSI3 Comm { get { return comm; } }

            bool avail = false;

            public void ConnectUpper() {
                if (avail) return;

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
                    if (!authDone && fTwoWayRandNumUAMStr && pack.UAMsList.Contains(kTwoWayRandNumUAMStr)) {

                        TransmitRes res3 = comm.Transmit(new DSICommand().WithRequestPayload(new FPLogin_2w()
                            .WithAFPVersion(afpVer)
                            .WithUserID(userId)
                            ));
                        if (res3.pack.IsResponse && res3.pack.ErrorCode == (int)DSIException.ResultCode.kFPAuthContinue) {
                            TwoWay1stPack blk3 = new TwoWay1stPack(res3.br);

                            byte[] key_buffer = Encoding.ASCII.GetBytes(passwd.PadRight(8, '\0').Substring(0, 8));
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

                    if (!authDone && fClearTextUAMStr && pack.UAMsList.Contains(kClearTextUAMStr)) {

                        TransmitRes res3 = comm.Transmit(new DSICommand().WithRequestPayload(new FPLogin_Cleartext_Password()
                            .WithAFPVersion(afpVer)
                            .WithUserName(userId)
                            .WithPasswd(passwd)
                        ));
                        if (res3.pack.IsResponse && res3.pack.ErrorCode == 0) {
                            authDone = true;
                        }

                    }

                    if (!authDone && fNoUserAuthStr && pack.UAMsList.Contains(kNoUserAuthStr)) {

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

            private void Disconnect() {
                if (comm != null)
                    comm.Dispose();

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

            TransmitRes res = lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPGetSrvrParms()
                ));
            if (!res.pack.IsResponse || res.pack.ErrorCode != 0) throw new DSIException(res.pack.ErrorCode, res.pack);

            GetSrvrParmsPack pack = new GetSrvrParmsPack(res.br);

            using (AH ah = new AH())
                foreach (VolStruc vs in pack.Volumes) {
                    LVol lvol = new LVol(lpc, vs.VolName);

                    TreeNode tnVol = AddVol(tnPC, lvol);
                    EnumVol(lvol, tnVol, depth - 1);
                }

            tnPC.ExpandAll();
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

            public void ConnectUpper() {
                lpc.ConnectUpper();
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

        void EnumVol(LVol lvol, TreeNode tnVol, int depth) {
            if (depth < 1) return;

            lvol.ConnectUpper();

            EnumDir(lvol, tnVol);
        }

        private bool EnumDir(LBaseDir lbd, TreeNode tnVol) {
            tnVol.Nodes.Clear();
            tnVol.StateImageKey = null;
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

                        if (ldir.ent.IsDirectory) {
                            AddDir(tnVol, ldir);
                        }
                    }

                    pos += pack.ActualCount;
                }
                lbd.isListed = true;
                tnVol.StateImageKey = "OK";
                return true;
            }
            catch (Exception err) {
                lbd.listErr = err;
                tnVol.StateImageKey = "E";
                tlpErr.Show();
                lErr1.Text = err.Message;
                lErrDetail.Tag = err.ToString();
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

        private TreeNode AddVol(TreeNode tnPC, LVol lvol) {
            TreeNode tn = tnPC.Nodes.Add(lvol.VolName);
            tn.ImageKey = tn.SelectedImageKey = "Vol";
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
                tlpErr.Hide();
                Listup(lbd);
                return;
            }
        }

        private void Listup(LBaseDir lbd) {
            lvF.Items.Clear();
            if (lbd == null) return;
            foreach (FileParameters ent in lbd.ents) {
                FEnt fe = new FEnt(ent, lbd);
                ListViewItem lvi = new ListViewItem(fe.Name);
                lvi.SubItems.Add(fe.IsDir ? "" : String.Format("{0:##,#0}", fe.DataSize));
                lvi.SubItems.Add(fe.IsDir ? "" : String.Format("{0:##,#0}", fe.ResSize));
                lvi.SubItems.Add(fe.FormatMT());
                lvi.ImageKey = fe.IsDir ? "Dir" : "File";
                lvi.Tag = fe;
                lvF.Items.Add(lvi);
            }
        }

        class AsResFork : VFCopy.IOpenSt2 {
            FEnt fe;

            public AsResFork(FEnt fe) {
                this.fe = fe;
            }

            #region IOpenSt メンバ

            public VFCopy.ISt2 OpenSt2() {
                return fe.OpenSt2(true);
            }

            #endregion
        }

        class FEnt : VFCopy.IOpenSt2 {
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
                    return (lbd.path + "\\" + Name).TrimStart('\\');
                }
            }

            public string MacPath {
                get {
                    return RefPath.TrimStart(DirSep).Replace(DirSep, '\0');
                }
            }

            public VFCopy.ISt2 OpenSt2(bool resfork) {
                lbd.lvol.ConnectUpper();

                MyDSI3 comm = lbd.lvol.lpc.Comm;

                TransmitRes res = comm.Transmit(new DSICommand().WithRequestPayload(new FPOpenFork()
                    .WithVolumeID(lbd.lvol.VolID)
                    .WithDirectoryID(lbd.lvol.DirID)
                    .WithPath(MacPath)
                    .WithFlag((byte)(resfork ? 0x80 : 0x00))
                    .WithAccessMode(AfpAccessMode.Read | AfpAccessMode.DenyWrite)
                ));

                if (!res.pack.IsResponse) throw new InvalidDataException();
                if (res.pack.ErrorCode != 0) throw new DSIException(res.pack.ErrorCode, res.pack);

                OpenForkPack pack = new OpenForkPack(res.br);

                return new ForkSt(pack, comm);
            }

            #region IOpenSt メンバ

            public VFCopy.ISt2 OpenSt2() {
                return OpenSt2(false);
            }

            #endregion

            class ForkSt : VFCopy.ISt2 {
                OpenForkPack forkPack;
                MyDSI3 comm;
                bool isOpened = true;

                public ForkSt(OpenForkPack forkPack, MyDSI3 comm) {
                    this.forkPack = forkPack;
                    this.comm = comm;
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
                    TransmitRes res = comm.Transmit(new DSICommand().WithRequestPayload(new FPRead()
                        .WithOffset(Convert.ToInt32(pos))
                        .WithOForkRefNum(forkPack.Fork)
                        .WithReqCount(Convert.ToInt32(cb))
                    ));

                    if (!res.pack.IsResponse) throw new InvalidDataException();
                    if (res.pack.ErrorCode == (int)DSIException.ResultCode.kFPEOFErr) {

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

        private void lErrDetail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            MessageBox.Show(this, "" + lErrDetail.Tag, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void mRefreshSel_Click(object sender, EventArgs e) {
            TreeNode tn = tvF.SelectedNode;
            if (tn == null) return;
            UpdateSel(tn, true);
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

        private void lvF_ColumnClick(object sender, ColumnClickEventArgs e) {
            bool asc = 0 == (ModifierKeys & Keys.Shift);
            if (e.Column == chfn.Index) lvF.ListViewItemSorter = new Sort.Str(e.Column, asc);
            if (e.Column == chmt.Index) lvF.ListViewItemSorter = new Sort.Mt(!asc);
            if (e.Column == chcbData.Index) lvF.ListViewItemSorter = new Sort.Cb(asc);
        }

        private void lvF_ItemActivate(object sender, EventArgs e) {
            ListViewItem lvi = lvF.FocusedItem;
            if (lvi == null) return;
            FEnt curl = lvi.Tag as FEnt;
            if (curl != null) {
                TreeNode tn = tvF.SelectedNode;
                if (tn == null)
                    return;
                TreeNode tnFound = tn.Nodes[curl.Name];
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

            foreach (FileParameters fparm in lbd.ents) {
                FEnt fe = new FEnt(fparm, lbd);
                if (fe.IsDir)
                    continue;
                if (true)
                    dataSrc.AddFile2(Path.Combine(prefix, NUt.Clean(fe.Name)), fe.GetMT(), fe.DataSize, fe);
                if (mGetResFork.Checked)
                    dataSrc.AddFile2(Path.Combine(prefix, NUt.Clean(fe.Name) + ExtResFork), fe.GetMT(), fe.ResSize, new AsResFork(fe));
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

            using (AH ah = new AH())
                foreach (ListViewItem lvi in sender.SelectedItems) {
                    FEnt fe = lvi.Tag as FEnt;
                    if (fe == null) continue;
                    if (!fe.IsDir) {
                        if (true)
                            dataSrc.AddFile2(NUt.Clean(fe.Name), fe.GetMT(), fe.DataSize, fe);
                        if (mGetResFork.Checked)
                            dataSrc.AddFile2(NUt.Clean(fe.Name) + ExtResFork, fe.GetMT(), fe.ResSize, new AsResFork(fe));
                    }
                    else {
                        TreeNode tnSub = tn.Nodes[fe.Name];
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
            return;

            e.Effect = DragDropEffects.None;

            TreeNode tn = tvF.SelectedNode;
            LBaseDir lbd;
            if (tn == null || null == (lbd = tn.Tag as LBaseDir)) return;

            VFCopy.ReadSrcClass readSrc = new VFCopy.ReadSrcClass();
            try {
                readSrc.ParseDataObject(e.Data, VFCopy.PDOFlags.AllowParseMany | VFCopy.PDOFlags.DisallowEnumObjects);
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
            return;

            e.Effect = DragDropEffects.None;

            TreeNode tn = tvF.SelectedNode;
            LBaseDir lbd;
            if (tn == null || null == (lbd = tn.Tag as LBaseDir)) return;

            VFCopy.ReadSrcClass readSrc = new VFCopy.ReadSrcClass();
            try {
                readSrc.ParseDataObject(e.Data, VFCopy.PDOFlags.AllowParseMany | VFCopy.PDOFlags.DisallowEnumObjects);
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

            com.IStream dataStm;
            CoMarshalInterThreadInterfaceInStream(ref IID_IDataObject, data, out dataStm);

            PasteForm form = new PasteForm();

            SynchronizationContext Sync = SynchronizationContext.Current;

            Thread t = new Thread((ThreadStart)delegate {
                try {
                    Application.OleRequired();

                    Object dataRaw;
                    CoGetInterfaceAndReleaseStream(dataStm, ref IID_IDataObject, out dataRaw);
                    com.IDataObject dataObj = (com.IDataObject)dataRaw;

                    VFCopy.ReadSrcClass readSrc = new VFCopy.ReadSrcClass();
                    Object aryRaw = readSrc.ParseDataObject(dataObj, VFCopy.PDOFlags.AllowParseMany);
                    Object[] ary = (Object[])aryRaw as Object[];
                    if (ary != null) {
                        int ypos = 0;
                        bool lastAnswer = false, answerAll = false;
                        foreach (VFCopy.IFDEnt ent in ary) {
                            ++ypos;
                            if (form.evStop.WaitOne(0))
                                throw new UserCancelException();
                            if (ent == null)
                                continue;
                            if (0 != ((FileAttributes)ent.FileAttributes & FileAttributes.Directory))
                                continue;
                            AFPath pathSrc = new AFPath(ent.FileName);
                            Sync.Send(delegate { form.StartFile(ent.FileName, ypos, ary.Length); }, null);
                            String[] partsSrc = pathSrc.fp.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                            for (int x1 = 1; x1 < partsSrc.Length; x1++) {
                                String fpaDir = APUt.EncodeApplePath(Path.Combine(lbd.path, String.Join("\\", partsSrc, 0, x1)));
                                TransmitRes res4 = lbd.lvol.lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPCreateDir()
                                    .WithVolumeID(lbd.lvol.VolID)
                                    .WithDirectoryID(lbd.lvol.DirID)
                                    .WithPath(fpaDir)
                                    ));
                                if ((res4.pack.ErrorCode != 0 && res4.pack.ErrorCode != (int)DSIException.ResultCode.kFPObjectExists)) throw new DSIException(res4.pack.ErrorCode, res4.pack);
                            }

                            String fpaDst = APUt.EncodeApplePath(Path.Combine(lbd.path, Path.Combine(Path.GetDirectoryName(pathSrc.fp), NUt.Clean(Path.GetFileName(pathSrc.fp)))));

                            bool dstExists = false;

                            TransmitRes res2 = lbd.lvol.lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPOpenFork()
                                .WithVolumeID(lbd.lvol.VolID)
                                .WithDirectoryID(lbd.lvol.DirID)
                                .WithPath(fpaDst)
                                .WithOpenDataFork()
                                .WithAccessMode(AfpAccessMode.Read | AfpAccessMode.Write | AfpAccessMode.DenyWrite)
                                ));
                            if (res2.pack.ErrorCode != 0) {
                                if (res2.pack.ErrorCode != (int)DSIException.ResultCode.kFPItemNotFound && res2.pack.ErrorCode != (int)DSIException.ResultCode.kFPObjectNotFound)
                                    throw new DSIException(res2.pack.ErrorCode, res2.pack);

                                TransmitRes res1 = lbd.lvol.lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPCreateFile()
                                    .WithVolumeID(lbd.lvol.VolID)
                                    .WithDirectoryID(lbd.lvol.DirID)
                                    .WithPath(fpaDst)
                                    .WithSoftCreate()
                                    ));
                                if (res1.pack.ErrorCode != 0) throw new DSIException(res1.pack.ErrorCode, res1.pack);

                                res2 = lbd.lvol.lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPOpenFork()
                                    .WithVolumeID(lbd.lvol.VolID)
                                    .WithDirectoryID(lbd.lvol.DirID)
                                    .WithPath(fpaDst)
                                    .WithOpenForkOfData(pathSrc.IsDataFork)
                                    .WithAccessMode(AfpAccessMode.Read | AfpAccessMode.Write | AfpAccessMode.DenyWrite)
                                    ));
                                if (res2.pack.ErrorCode != 0) throw new DSIException(res2.pack.ErrorCode, res2.pack);
                            }
                            else dstExists = true;
                            OpenForkPack pack2 = new OpenForkPack(res2.br);

                            bool incomplete = true;

                            Int64 cbFile = ent.FileSize;
                            try {
                                if (dstExists) {
                                    if (!answerAll)
                                        Sync.Send(delegate { lastAnswer = form.QueryOverwrite(); answerAll = form.all; }, null);
                                    if (!lastAnswer) continue;
                                }

                                VFCopy.ISt2 sIn = (VFCopy.ISt2)ent.OpenSt2();
                                try {
                                    Int64 pos = 0;
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

                                        TransmitRes res3 = lbd.lvol.lpc.Comm.Transmit(new DSIWrite().WithRequestPayload(new FPWrite()
                                            .WithOffset(Convert.ToInt32(pos))
                                            .WithOForkRefNum(pack2.Fork)
                                            .WithForkData((byte[])parray)
                                            .WithReqCount(Convert.ToInt32(cbRead))
                                            ));
                                        if (res3.pack.ErrorCode != 0) throw new DSIException(res3.pack.ErrorCode, res3.pack);

                                        pos += cbRead;

                                        Sync.Send(delegate { form.ReportSend(pos, cbFile); }, null);
                                    }
                                }
                                finally {
                                    sIn.CloseSt2();
                                }

                            }
                            finally {
                                try {
                                    lbd.lvol.lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPCloseFork()
                                        .WithFork(pack2.Fork)
                                        ));
                                }
                                finally {
                                    if (incomplete) {
                                        lbd.lvol.lpc.Comm.Transmit(new DSICommand().WithRequestPayload(new FPDelete()
                                            .WithVolumeID(lbd.lvol.VolID)
                                            .WithDirectoryID(lbd.lvol.DirID)
                                            .WithPath(fpaDst)
                                            ));
                                    }
                                }
                            }
                        }
                    }

                    Sync.Send(delegate {
                        form.Done();
                    }, null);
                }
                catch (Exception err) {
                    Sync.Send(delegate {
                        MessageBox.Show(this, "失敗しました：\n\n" + err.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        form.Done();
                    }, null);
                }
            });
            t.SetApartmentState(ApartmentState.STA);
            form.Load += delegate {
                t.Start();
            };

            using (form) {
                form.ShowDialog();

                UpdateSel(treeNode, true);
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
    }
}