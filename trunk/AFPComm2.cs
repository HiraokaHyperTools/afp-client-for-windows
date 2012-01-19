using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using AFPt;

// AFPt2 0.1@11:04 2012/01/17
// AFPc4w 0.2@11:23 2012/01/17

namespace AFPt2 {
    public interface IFP {
        byte[] ToArray();
    }

    public enum AfpPathType {
        kFPShortName = 1,
        kFPLongName = 2,
        kFPUTF8Name = 3,
    }

    [Flags]
    public enum AfpAccessMode {
        Read = 1, Write = 2, DenyRead = 16, DenyWrite = 32,
    }

    [Flags]
    public enum AfpFileBitmap {
        None = 0,
        Attributes = 1,
        ParentDirectoryID = 2,
        CreationDate = 4,
        ModificationDate = 8,
        BackupDate = 16,
        FinderInfo = 32,
        LongName = 64,
        ShortName = 128,

        NodeID = 256,
        DataForkLength = 512,
        ResourceForkLength = 1024,
        ExtDataForkLength = 2048,
        LaunchLimit = 4096,
        UnicodeName = 8192,
        ExtResourceForkLength = 16384,
        UNIXPrivileges = 32768,
    }

    [Flags]
    public enum AfpDirectoryBitmap {
        None = 0,
        Attributes = 1,
        ParentDirectoryID = 2,
        CreationDate = 4,
        ModificationDate = 8,
        BackupDate = 16,
        FinderInfo = 32,
        LongName = 64,
        ShortName = 128,

        NodeID = 256,
        OffspringCount = 512,
        OwnerID = 1024,
        GroupID = 2048,
        AccessRights = 4096,
        UnicodeName = 8192,

        UNIXPrivileges = 32768,
    }

    [Flags]
    public enum AfpVolumeBitmap {
        None = 0,
        kFPVolAttributeBit = 0x1,
        kFPVolSignatureBit = 0x2,
        kFPVolCreateDateBit = 0x4,
        kFPVolModDateBit = 0x8,
        kFPVolBackupDateBit = 0x10,
        kFPVolIDBit = 0x20,
        kFPVolBytesFreeBit = 0x40,
        kFPVolBytesTotalBit = 0x80,
        kFPVolNameBit = 0x100,
        kFPVolExtBytesFreeBit = 0x200,
        kFPVolExtBytesTotalBit = 0x400,
        kFPVolBlockSizeBit = 0x800,
    }

    public class FPLogin : IFP {
        public String AFPVersion;

        public FPLogin WithAFPVersion(String AFPVersion) { this.AFPVersion = AFPVersion; return this; }

        public byte[] ToArray() {
            MemoryStream os = new MemoryStream();
            BEW wr = new BEW(os);
            wr.Write((byte)18); // kFPLogin
            UtAfp.Write1Str(os, AFPVersion);
            UtAfp.Write1Str(os, "No User Authent");
            return os.ToArray();
        }
    }

    public class FPLogin_Cleartext_Password : IFP {
        public String AFPVersion;
        public String UserName;
        public String Passwd;

        public FPLogin_Cleartext_Password WithAFPVersion(String AFPVersion) { this.AFPVersion = AFPVersion; return this; }
        public FPLogin_Cleartext_Password WithUserName(String UserName) { this.UserName = UserName; return this; }
        public FPLogin_Cleartext_Password WithPasswd(String Passwd) { this.Passwd = Passwd; return this; }

        public byte[] ToArray() {
            MemoryStream os = new MemoryStream();
            BEW wr = new BEW(os);
            wr.Write((byte)18); // kFPLogin
            UtAfp.Write1Str(os, AFPVersion);
            UtAfp.Write1Str(os, "Cleartxt Passwrd");
            UtAfp.Write1Str(os, UserName);
            if (0 != ((int)os.Position & 1)) wr.Write((byte)0);
            wr.Write(Encoding.ASCII.GetBytes(Passwd.PadRight(8, '\0').Substring(0, 8)));
            return os.ToArray();
        }
    }

    public class FPGetSrvrParms : IFP {
        public byte[] ToArray() {
            byte[] bin = new byte[] { 
                16, // kFPGetSrvrParms 
                0
            };
            return bin;
        }
    }

    public class FPGetSrvrInfo : IFP {
        public byte[] ToArray() {
            byte[] bin = new byte[] { 
                15, // kFPGetSrvrInfo  
                0
            };
            return bin;
        }
    }

    public class FPLogout : IFP {
        public byte[] ToArray() {
            byte[] bin = new byte[] { 
                20, // kFPLogout  
                0
            };
            return bin;
        }
    }

    public class FPOpenVol : IFP {
        public ushort Bitmap = (ushort)(AfpVolumeBitmap.kFPVolIDBit);
        public String VolumeName;

        public FPOpenVol WithBitmap(ushort Bitmap) { this.Bitmap = Bitmap; return this; }
        public FPOpenVol WithBitmap(AfpVolumeBitmap Bitmap) { this.Bitmap = (ushort)Bitmap; return this; }
        public FPOpenVol WithVolumeName(String VolumeName) { this.VolumeName = VolumeName; return this; }

        public byte[] ToArray() {
            MemoryStream os = new MemoryStream();
            BEW wr = new BEW(os);
            wr.Write((byte)24); // kFPOpenVol 
            wr.Write((byte)0);
            wr.Write((ushort)Bitmap);
            UtAfp.Write1Str(os, VolumeName);
            return os.ToArray();
        }
    }

    public class FPEnumerate : IFP {
        public ushort VolumeID;
        public uint DirectoryID;
        public ushort FileBitmap = (ushort)(AfpFileBitmap.NodeID | AfpFileBitmap.LongName);
        public ushort DirectoryBitmap = (ushort)(AfpDirectoryBitmap.NodeID | AfpDirectoryBitmap.LongName);
        public ushort ReqCount = 100;
        public ushort StartIndex = 1;
        public ushort MaxReplySize = 5000;
        public byte PathType = (byte)AfpPathType.kFPLongName;
        public String Path = String.Empty;

        public FPEnumerate WithVolumeID(ushort VolumeID) { this.VolumeID = VolumeID; return this; }
        public FPEnumerate WithDirectoryID(uint DirectoryID) { this.DirectoryID = DirectoryID; return this; }
        public FPEnumerate WithFileBitmap(ushort FileBitmap) { this.FileBitmap = FileBitmap; return this; }
        public FPEnumerate WithFileBitmap(AfpFileBitmap FileBitmap) { this.FileBitmap = (ushort)FileBitmap; return this; }
        public FPEnumerate WithDirectoryBitmap(ushort DirectoryBitmap) { this.DirectoryBitmap = DirectoryBitmap; return this; }
        public FPEnumerate WithDirectoryBitmap(AfpDirectoryBitmap DirectoryBitmap) { this.DirectoryBitmap = (ushort)DirectoryBitmap; return this; }
        public FPEnumerate WithReqCount(ushort ReqCount) { this.ReqCount = ReqCount; return this; }
        public FPEnumerate WithStartIndex(ushort StartIndex) { this.StartIndex = StartIndex; return this; }
        public FPEnumerate WithMaxReplySize(ushort MaxReplySize) { this.MaxReplySize = MaxReplySize; return this; }
        public FPEnumerate WithPathType(byte PathType) { this.PathType = PathType; return this; }
        public FPEnumerate WithPathType(AfpPathType PathType) { this.PathType = (byte)PathType; return this; }
        public FPEnumerate WithPath(String Path) { this.Path = Path; return this; }

        public byte[] ToArray() {
            MemoryStream os = new MemoryStream();
            BEW wr = new BEW(os);
            wr.Write((byte)9); // kFPEnumerate  
            wr.Write((byte)0);
            wr.Write((ushort)VolumeID);
            wr.Write((uint)DirectoryID);
            wr.Write((ushort)FileBitmap);
            wr.Write((ushort)DirectoryBitmap);
            wr.Write((ushort)ReqCount);
            wr.Write((ushort)StartIndex);
            wr.Write((ushort)MaxReplySize);
            wr.Write((byte)PathType);
            UtAfp.Write1Str(os, Path);
            UtPadding.Write2(os);
            return os.ToArray();
        }
    }

    public class FPOpenFork : IFP {
        public byte Flag; // (ResFork ? 0x80 : 0)
        public ushort VolumeID;
        public uint DirectoryID;
        public ushort Bitmap = (ushort)(AfpFileBitmap.None);
        public ushort AccessMode = (ushort)(AfpAccessMode.Read | AfpAccessMode.DenyWrite);
        public byte PathType = (byte)AfpPathType.kFPLongName;
        public String Path;

        public FPOpenFork WithFlag(byte Flag) { this.Flag = Flag; return this; }
        public FPOpenFork WithVolumeID(ushort VolumeID) { this.VolumeID = VolumeID; return this; }
        public FPOpenFork WithDirectoryID(uint DirectoryID) { this.DirectoryID = DirectoryID; return this; }
        public FPOpenFork WithBitmap(ushort Bitmap) { this.Bitmap = Bitmap; return this; }
        public FPOpenFork WithAccessMode(ushort AccessMode) { this.AccessMode = AccessMode; return this; }
        public FPOpenFork WithAccessMode(AfpAccessMode AccessMode) { this.AccessMode = (ushort)AccessMode; return this; }
        public FPOpenFork WithPathType(byte PathType) { this.PathType = PathType; return this; }
        public FPOpenFork WithPath(String Path) { this.Path = Path; return this; }
        public FPOpenFork WithPathType(AfpPathType PathType) { this.PathType = (byte)PathType; return this; }

        public FPOpenFork WithOpenDataFork() { Flag &= 0x7F; return this; }
        public FPOpenFork WithOpenResourceFork() { Flag |= 0x80; return this; }

        public byte[] ToArray() {
            MemoryStream os = new MemoryStream();
            BEW wr = new BEW(os);
            wr.Write((byte)26); // kFPOpenFork 
            wr.Write((byte)Flag);
            wr.Write((ushort)VolumeID);
            wr.Write((uint)DirectoryID);
            wr.Write((ushort)Bitmap);
            wr.Write((ushort)AccessMode);
            wr.Write((byte)PathType);
            UtAfp.Write1Str(os, Path);
            return os.ToArray();
        }
    }

    public class FPCloseVol : IFP {
        public ushort VolumeID;

        public FPCloseVol WithVolumeID(ushort VolumeID) { this.VolumeID = VolumeID; return this; }

        public byte[] ToArray() {
            MemoryStream os = new MemoryStream();
            BEW wr = new BEW(os);
            wr.Write((byte)2); // kFPCloseVol  
            wr.Write((byte)0);
            wr.Write((ushort)VolumeID);
            return os.ToArray();
        }
    }

    public class FPCloseFork : IFP {
        public ushort Fork;

        public FPCloseFork WithFork(ushort Fork) { this.Fork = Fork; return this; }

        public byte[] ToArray() {
            MemoryStream os = new MemoryStream();
            BEW wr = new BEW(os);
            wr.Write((byte)4); // kFPCloseFork   
            wr.Write((byte)0);
            wr.Write((ushort)Fork);
            return os.ToArray();
        }
    }

    public class FPGetFileDirParms : IFP {
        public ushort VolumeID;
        public uint DirectoryID;
        public ushort FileBitmap = (ushort)(AfpFileBitmap.NodeID | AfpFileBitmap.ParentDirectoryID);
        public ushort DirectoryBitmap = (ushort)(AfpDirectoryBitmap.NodeID | AfpDirectoryBitmap.ParentDirectoryID);
        public byte PathType;
        public String Path;

        public FPGetFileDirParms WithVolumeID(ushort VolumeID) { this.VolumeID = VolumeID; return this; }
        public FPGetFileDirParms WithDirectoryID(uint DirectoryID) { this.DirectoryID = DirectoryID; return this; }
        public FPGetFileDirParms WithFileBitmap(ushort FileBitmap) { this.FileBitmap = FileBitmap; return this; }
        public FPGetFileDirParms WithDirectoryBitmap(ushort DirectoryBitmap) { this.DirectoryBitmap = DirectoryBitmap; return this; }
        public FPGetFileDirParms WithPathType(byte PathType) { this.PathType = PathType; return this; }
        public FPGetFileDirParms WithPath(String Path) { this.Path = Path; return this; }

        public byte[] ToArray() {
            MemoryStream os = new MemoryStream();
            BEW wr = new BEW(os);
            wr.Write((byte)34); // kFPGetFileDirParms  
            wr.Write((byte)0);
            wr.Write((ushort)VolumeID);
            wr.Write((uint)DirectoryID);
            wr.Write((ushort)FileBitmap);
            wr.Write((ushort)DirectoryBitmap);
            wr.Write((byte)2); // Long names
            UtAfp.Write1Str(os, Path);
            return os.ToArray();
        }
    }

    public class FPRead : IFP {
        public ushort OForkRefNum;
        public uint Offset = 0;
        public uint ReqCount = 10000;
        public byte NewLineMask;
        public byte NewLineChar;

        public FPRead WithOForkRefNum(ushort OForkRefNum) { this.OForkRefNum = OForkRefNum; return this; }
        public FPRead WithOffset(uint Offset) { this.Offset = Offset; return this; }
        public FPRead WithReqCount(uint ReqCount) { this.ReqCount = ReqCount; return this; }
        public FPRead WithNewLineMask(byte NewLineMask) { this.NewLineMask = NewLineMask; return this; }
        public FPRead WithNewLineChar(byte NewLineChar) { this.NewLineChar = NewLineChar; return this; }

        public byte[] ToArray() {
            MemoryStream os = new MemoryStream();
            BEW wr = new BEW(os);
            wr.Write((byte)27); // kFPRead    
            wr.Write((byte)0);
            wr.Write((ushort)OForkRefNum);
            wr.Write((uint)Offset);
            wr.Write((uint)ReqCount);
            wr.Write((byte)NewLineMask);
            wr.Write((byte)NewLineChar);
            return os.ToArray();
        }
    }

    public class FPLogin_2w : IFP {
        public string AFPVersion;
        public string UserID;

        public FPLogin_2w WithAFPVersion(string AFPVersion) { this.AFPVersion = AFPVersion; return this; }
        public FPLogin_2w WithUserID(string UserID) { this.UserID = UserID; return this; }

        public byte[] ToArray() {
            MemoryStream os = new MemoryStream();
            BEW wr = new BEW(os);
            wr.Write((byte)18); // kFPLogin
            UtAfp.Write1Str(os, AFPVersion);
            UtAfp.Write1Str(os, "2-Way Randnum Exchange");
            UtAfp.Write1Str(os, UserID);
            return os.ToArray();
        }
    }

    public class FPLogin_2w_2 : IFP {
        public ushort ContID;
        public byte[] EncPasswd;
        public byte[] RandKey;

        public FPLogin_2w_2 WithContID(ushort UserID) { this.ContID = UserID; return this; }
        public FPLogin_2w_2 WithEncPasswd(byte[] EncPasswd) { this.EncPasswd = EncPasswd; return this; }
        public FPLogin_2w_2 WithRandKey(byte[] RandKey) { this.RandKey = RandKey; return this; }

        public byte[] ToArray() {
            if (EncPasswd == null) throw new NullReferenceException("EncPasswd");
            if (EncPasswd.Length != 8) throw new ArgumentException("EncPasswd.Length != 8");
            if (RandKey == null) throw new NullReferenceException("RandKey");
            if (RandKey.Length != 8) throw new ArgumentException("RandKey.Length != 8");

            MemoryStream os = new MemoryStream();
            BEW wr = new BEW(os);
            wr.Write((byte)19); // kFPLoginCont 
            wr.Write((byte)0);
            wr.Write((ushort)ContID);
            os.Write(EncPasswd, 0, 8);
            os.Write(RandKey, 0, 8);
            return os.ToArray();
        }
    }

    public class FPLogin_DHX : IFP {
        public string AFPVersion;
        public string UserID;
        public byte[] Ma;

        public FPLogin_DHX WithAFPVersion(string AFPVersion) { this.AFPVersion = AFPVersion; return this; }
        public FPLogin_DHX WithUserID(string UserID) { this.UserID = UserID; return this; }
        public FPLogin_DHX WithMa(byte[] Ma) { this.Ma = Ma; return this; }

        public byte[] ToArray() {
            MemoryStream os = new MemoryStream();
            BEW wr = new BEW(os);
            wr.Write((byte)18); // kFPLogin
            UtAfp.Write1Str(os, AFPVersion);
            UtAfp.Write1Str(os, "DHCAST128");
            UtAfp.Write1Str(os, UserID);
            UtAfp.Even(os);
            wr.Write(Ma);
            return os.ToArray();
        }
    }

    public class FPLogin_DHX_2 : IFP {
        public ushort ContID;
        public byte[] Nonce1Passwd;

        public FPLogin_DHX_2 WithContID(ushort ContID) { this.ContID = ContID; return this; }
        public FPLogin_DHX_2 WithNonce1Passwd(byte[] Nonce1Passwd) { this.Nonce1Passwd = Nonce1Passwd; return this; }

        public byte[] ToArray() {
            MemoryStream os = new MemoryStream();
            BEW wr = new BEW(os);
            wr.Write((byte)19); // kFPLoginCont 
            wr.Write((byte)0);
            wr.Write((ushort)ContID);
            os.Write(Nonce1Passwd, 0, 16 + 64);
            return os.ToArray();
        }
    }

    public class TwoWay2ndPack {
        public byte[] ClientKey;

        public TwoWay2ndPack(BER br) {
            ClientKey = br.ReadBytes(8);
        }
    }

    public class TwoWay1stPack {
        public ushort Id;
        public byte[] ServerKey;

        public TwoWay1stPack(BER br) {
            Id = br.ReadUInt16();
            ServerKey = br.ReadBytes(8);
        }
    }

    public class DHXReplyPack {
        public ushort Id;
        public byte[] Mb;
        public byte[] nonce_ss;

        public DHXReplyPack(BER br) {
            Id = br.ReadUInt16();
            Mb = br.ReadBytes(16);
            nonce_ss = br.ReadBytes(32);
        }
    }

    public class GetFileDirParmsPack {
        public ushort FileBitmap;
        public ushort DirectoryBitmap;
        public byte FileDir;
        public FileParameters Parms;

        public GetFileDirParmsPack(BER br) {
            FileBitmap = br.ReadUInt16();
            DirectoryBitmap = br.ReadUInt16();
            FileDir = br.ReadByte();
            br.ReadByte();
            Parms = new FileParameters(br, (0 == (0x80 & FileDir)), (0 != (0x80 & FileDir)) ? DirectoryBitmap : FileBitmap);
        }

        public bool IsDirectory { get { return 0 != (0x80 & FileDir); } }
    }

    public class VolumeParameters {
        public ushort? VolAttribute = null, VolID = null, VolSignature = null;
        public uint? CreateDate = null, ModDate = null, VolBackupDate = null, VolBytesFree = null, VolBytesTotal = null, VolBlockSize = null;
        public string VolName = null;
        public ulong? VolExtBytesFree = null, VolExtBytesTotal = null;

        public VolumeParameters(BER br, ushort Bitmap) {
            Stream si = br.BaseStream;
            Int64 off = si.Position;

            ushort? VolNameOff = null;

            if (0 != (Bitmap & 1U)) VolAttribute = br.ReadUInt16();
            if (0 != (Bitmap & 2U)) VolSignature = br.ReadUInt16();
            if (0 != (Bitmap & 4U)) CreateDate = br.ReadUInt32();
            if (0 != (Bitmap & 8U)) ModDate = br.ReadUInt32();
            if (0 != (Bitmap & 16U)) VolBackupDate = br.ReadUInt32();
            if (0 != (Bitmap & 32U)) VolID = br.ReadUInt16();
            if (0 != (Bitmap & 64U)) VolBytesFree = br.ReadUInt32();
            if (0 != (Bitmap & 128U)) VolBytesTotal = br.ReadUInt32();

            if (0 != (Bitmap & 256U)) VolNameOff = br.ReadUInt16();
            if (0 != (Bitmap & 512U)) VolExtBytesFree = br.ReadUInt64();
            if (0 != (Bitmap & 1024U)) VolExtBytesTotal = br.ReadUInt64();
            if (0 != (Bitmap & 2048U)) VolBlockSize = br.ReadUInt32();

            if (VolNameOff != null) {
                si.Position = off + VolNameOff.Value;
                VolName = UtAfp.Read1Str(si);
            }
        }
    }

    public class FileParameters {
        public byte? FileDir = null;
        public ushort? Attributes = null;
        public uint? ParentDirectoryID = null;
        public uint? CreationDate = null;
        public uint? ModificationDate = null;
        public uint? BackupDate = null;
        public byte[] FinderInfo = null;
        public String LongName = null, ShortName = null;
        public uint? NodeID = null, DataForkSize = null, ResourceForkSize = null;

        public ushort? OffspringCount;
        public uint? AccessRights;

        public bool IsDirectory;

        public FileParameters(BER br, bool IsFile, ushort Bitmap) {
            Stream si = br.BaseStream;
            Int64 off = si.Position;

            IsDirectory = !IsFile;

            ushort? LongNameOff = null;
            ushort? ShortNameOff = null;

            if (0 != (Bitmap & 1U)) Attributes = br.ReadUInt16();
            if (0 != (Bitmap & 2U)) ParentDirectoryID = br.ReadUInt32();
            if (0 != (Bitmap & 4U)) CreationDate = br.ReadUInt32();
            if (0 != (Bitmap & 8U)) ModificationDate = br.ReadUInt32();
            if (0 != (Bitmap & 16U)) BackupDate = br.ReadUInt32();
            if (0 != (Bitmap & 32U)) FinderInfo = br.ReadBytes(32);
            if (0 != (Bitmap & 64U)) LongNameOff = br.ReadUInt16();
            if (0 != (Bitmap & 128U)) ShortNameOff = br.ReadUInt16();
            if (0 != (Bitmap & 256U)) NodeID = br.ReadUInt32();
            if (IsFile) {
                if (0 != (Bitmap & 512U)) DataForkSize = br.ReadUInt32();
                if (0 != (Bitmap & 1024U)) ResourceForkSize = br.ReadUInt32();
                if (0 != (Bitmap & 2048U)) throw new NotSupportedException("Extended data fork size");
                if (0 != (Bitmap & 4096U)) throw new NotSupportedException("Launch limit");
                if (0 != (Bitmap & 8192U)) throw new NotSupportedException("UTF-8 name");
                if (0 != (Bitmap & 16384U)) throw new NotSupportedException("Extended resource fork size");
                if (0 != (Bitmap & 32768U)) throw new NotSupportedException("Unix privileges");
            }
            else {
                if (0 != (Bitmap & 512U)) OffspringCount = br.ReadUInt16();
                if (0 != (Bitmap & 1024U)) throw new NotSupportedException("Owner ID");
                if (0 != (Bitmap & 2048U)) throw new NotSupportedException("Group ID");
                if (0 != (Bitmap & 4096U)) AccessRights = br.ReadUInt32();
                if (0 != (Bitmap & 8192U)) throw new NotSupportedException("Unicode Name");
                if (0 != (Bitmap & 16384U)) throw new NotSupportedException("?");
                if (0 != (Bitmap & 32768U)) throw new NotSupportedException("Unix privileges");
            }

            if (LongNameOff.HasValue) {
                si.Position = off + LongNameOff.Value;
                LongName = UtAfp.Read1Str(si);
            }
            if (ShortNameOff.HasValue) {
                si.Position = off + ShortNameOff.Value;
                ShortName = UtAfp.Read1Str(si);
            }
        }

        public String Name {
            get {
                return LongName ?? ShortName;
            }
        }

        public DateTime? CT { get { return CreationDate.HasValue ? new DateTime(2000, 1, 1).AddSeconds(CreationDate.Value).ToLocalTime() : new DateTime?(); } }
        public DateTime? MT { get { return ModificationDate.HasValue ? new DateTime(2000, 1, 1).AddSeconds(ModificationDate.Value).ToLocalTime() : new DateTime?(); } }
        public DateTime? BT { get { return (!BackupDate.HasValue || BackupDate == 0x80000000U) ? new DateTime?() : new DateTime(2000, 1, 1).AddSeconds(BackupDate.Value).ToLocalTime(); } }
    }

    public class OpenForkPack {
        public ushort Bitmap, Fork;
        public FileParameters Parms;

        public OpenForkPack(BER br) {
            Bitmap = br.ReadUInt16();
            Fork = br.ReadUInt16();
            Parms = new FileParameters(br, true, Bitmap);
        }
    }

    public class EnumeratePack {
        public ushort FileBitmap, DirectoryBitmap, ActualCount;
        public List<FileParameters> Ents = new List<FileParameters>();

        public EnumeratePack(BER br) {
            FileBitmap = br.ReadUInt16();
            DirectoryBitmap = br.ReadUInt16();
            ActualCount = br.ReadUInt16();

            for (int x = 0; x < ActualCount; x++) {
                byte cb = br.ReadByte();
                byte fd = br.ReadByte();
                BER brInner = new BER(new MemoryStream(br.ReadBytes(cb - 2), false));

                bool isDir = ((fd & 0x80) != 0);

                Ents.Add(new FileParameters(brInner, !isDir, isDir ? DirectoryBitmap : FileBitmap));

                UtPadding.Read2(br.BaseStream);
            }
        }
    }

    class UtPadding {
        public static void Read2(Stream os) {
            if (0 != (1 & (int)os.Length)) os.Seek(1, SeekOrigin.Current);
        }

        public static void Write2(Stream os) {
            if (0 != (1 & (int)os.Length)) os.WriteByte(0);
        }
    }

    public class OpenVolPack {
        public ushort Bitmap;
        public VolumeParameters Ent;

        public OpenVolPack(BER br) {
            Bitmap = br.ReadUInt16();
            Ent = new VolumeParameters(br, Bitmap);
        }
    }

    public class GetSrvrParmsPack {
        public uint ServerTime;
        public List<VolStruc> Volumes = new List<VolStruc>();

        public GetSrvrParmsPack(BER br) {
            ServerTime = br.ReadUInt32();
            {
                int cx = br.ReadByte();
                for (int x = 0; x < cx; x++) Volumes.Add(new VolStruc(br));
            }
        }
    }

    public class VolStruc {
        public byte Flags;
        public string VolName;

        public VolStruc(BER br) {
            Flags = br.ReadByte();
            VolName = UtAfp.Read1Str(br.BaseStream);
        }

        public bool HasConfigInfo { get { return 0 != (Flags & 1); } }
        public bool HasPassword { get { return 0 != (Flags & 128); } }
    }

    public class GetSrvrInfoPack {
        public ushort MachineTypeOff, AFPVersionCountOff, UAMCountOff, VolumeIconAndMaskOff;
        public ushort Flags;
        public string ServerName;
        public ushort ServerSignatureOff, NetworkAddressesCountOff, DirectoryNamesCountOff, UTF8ServerNameOff;
        public List<string> AFPVersionsList = new List<string>();
        public List<string> UAMsList = new List<string>();

        public bool SupportsCopyFile { get { return 0 != (Flags & 0x0001); } }
        public bool SupportsChaingingPassword { get { return 0 != (Flags & 0x0002); } }
        public bool DoesNotAllowPasswordSaving { get { return 0 != (Flags & 0x0004); } }
        public bool SupportsServerMessages { get { return 0 != (Flags & 0x0008); } }
        public bool SupportsServerSignature { get { return 0 != (Flags & 0x0010); } }
        public bool SupportsTCPIP { get { return 0 != (Flags & 0x0020); } }
        public bool SupportsServerNotifications { get { return 0 != (Flags & 0x0040); } }
        public bool SupportsReconnect { get { return 0 != (Flags & 0x0080); } }

        public bool SupportsOpenDirectory { get { return 0 != (Flags & 0x0100); } }
        public bool SupportsUTF8ServerName { get { return 0 != (Flags & 0x0200); } }
        public bool SupportsUUIDs { get { return 0 != (Flags & 0x0400); } }
        public bool SupportsSuperClient { get { return 0 != (Flags & 0x8000); } }

        public GetSrvrInfoPack(BER br) {
            Stream si = br.BaseStream;

            MachineTypeOff = br.ReadUInt16();
            AFPVersionCountOff = br.ReadUInt16();
            UAMCountOff = br.ReadUInt16();
            VolumeIconAndMaskOff = br.ReadUInt16();
            Flags = br.ReadUInt16();
            ServerName = UtAfp.Read1Str(si);
            ServerSignatureOff = br.ReadUInt16();
            NetworkAddressesCountOff = br.ReadUInt16();
            DirectoryNamesCountOff = br.ReadUInt16();
            UTF8ServerNameOff = br.ReadUInt16();

            {
                si.Position = AFPVersionCountOff;
                int cnt = br.ReadByte();
                for (int x = 0; x < cnt; x++) {
                    AFPVersionsList.Add(UtAfp.Read1Str(si));
                }
            }
            {
                si.Position = UAMCountOff;
                int cnt = br.ReadByte();
                for (int x = 0; x < cnt; x++) {
                    UAMsList.Add(UtAfp.Read1Str(si));
                }
            }
        }
    }

    class UtAfp {
        public static string Read1Str(Stream si) {
            BER br = new BER(si);
            byte cb = br.ReadByte();
            return Encoding.GetEncoding(10001).GetString(br.ReadBytes(cb));
        }
        public static void Write1Str(Stream os, String s) {
            byte[] bin = Encoding.GetEncoding(10001).GetBytes(s);
            os.WriteByte(Convert.ToByte(bin.Length));
            os.Write(bin, 0, bin.Length);
        }
        public static void Even(Stream os) {
            if (0 != (os.Length & 1)) os.WriteByte(0);
        }
    }

    public class DSIPack {
        public byte Flags, Command;
        public ushort RequestID;
        public int ErrorCode;
        public uint TotalDataLength, Reserved;
        public byte[] Payload;

        public bool IsRequest { get { return Flags == 0; } }
        public bool IsResponse { get { return Flags == 1; } }

        public DSIPack(Stream si) {
            BER br = new BER(si);
            Flags = br.ReadByte();
            Command = br.ReadByte();
            RequestID = br.ReadUInt16();
            ErrorCode = br.ReadInt32();
            TotalDataLength = br.ReadUInt32();
            Reserved = br.ReadUInt32();
            Payload = br.ReadBytes(Convert.ToInt32(TotalDataLength));
        }

        public uint WriteOffset { get { return (uint)ErrorCode; } set { ErrorCode = (int)value; } }
    }

    #region DSIException
    public class DSIException : ApplicationException {
        public DSIPack Res;
        public int ErrorCode;

        public enum ResultCode {
            kFPNoMoreSessions = -1068,
            kASPServerBusy = -1071,

            kASPSessClosed = -1072,
            kFPAccessDenied = -5000,
            kFPAuthContinue = -5001,
            kFPBadUAM = -5002,
            kFPBadVersNum = -5003,
            kFPBitmapErr = -5004,
            kFPCantMove = -5005,
            kFPDenyConflict = -5006,
            kFPDirNotEmpty = -5007,
            kFPDiskFull = -5008,
            kFPEOFErr = -5009,
            kFPFileBusy = -5010,
            kFPFlatVol = -5011,
            kFPItemNotFound = -5012,
            kFPLockErr = -5013,
            kFPMiscErr = -5014,
            kFPNoMoreLocks = -5015,
            kFPNoServer = -5016,
            kFPObjectExists = -5017,
            kFPObjectNotFound = -5018,
            kFPParamErr = -5019,
            kFPRangeNotLocked = -5020,
            kFPRangeOverlap = -5021,
            kFPSessClosed = -5022,
            kFPUserNotAuth = -5023,
            kFPCallNotSupported = -5024,
            kFPObjectTypeErr = -5025,
            kFPTooManyFilesOpen = -5026,
            kFPServerGoingDown = -5027,
            kFPCantRename = -5028,
            kFPDirNotFound = -5029,
            kFPIconTypeError = -5030,
            kFPVolLocked = -5031,
            kFPObjectLocked = -5032,
            kFPContainsSharedErr = -5033,
            kFPIDNotFound = -5034,
            kFPIDExists = -5035,
            kFPDiffVolErr = -5036,
            kFPCatalogChanged = -5037,
            kFPSameObjectErr = -5038,
            kFPBadIDErr = -5039,
            kFPPwdSameErr = -5040,
            kFPPwdTooShortErr = -5041,
            kFPPwdExpiredErr = -5042,
            kFPInsideSharedErr = -5043,
            kFPInsideTrashErr = -5044,
            kFPPwdNeedsChangeErr = -5045,
            kFPPwdPolicyErr = -5046,
            kFPDiskQuotaExceeded = -5047,
        }

        public DSIException(int ErrorCode)
            : base(GetErrorDescription((ResultCode)ErrorCode)) {
            this.ErrorCode = ErrorCode;
            this.Res = null;
        }

        public DSIException(int ErrorCode, DSIPack Res)
            : base(GetErrorDescription((ResultCode)ErrorCode)) {
            this.ErrorCode = ErrorCode;
            this.Res = Res;
        }

        public static string GetErrorDescription(ResultCode rc) {
            switch (rc) {
                case ResultCode.kASPServerBusy: return "Server busy"; // http://svn.now.ai/diff.php?repname=afp-perl&path=/trunk/Net/AFP/Result.pm&rev=271&sc=1&all=1

                case ResultCode.kFPNoMoreSessions: return "Server cannot handle additional sessions.";
                case ResultCode.kASPSessClosed: return "ASP session closed.";
                case ResultCode.kFPAccessDenied: return "User does not have the access privileges required to use the command.";
                case ResultCode.kFPAuthContinue: return "Authentication is not yet complete.";
                case ResultCode.kFPBadUAM: return "Specified UAM is unknown";
                case ResultCode.kFPBadVersNum: return "Server does not support the specified AFP version.";
                case ResultCode.kFPBitmapErr: return "Attempt was made to get or set a parameter that cannot be obtained or set with this command, or a required bitmap is null";
                case ResultCode.kFPCantMove: return "Attempt was made to move a directory into one of its descendent directories.";
                case ResultCode.kFPDenyConflict: return "Specified fork cannot be opened because of a deny modes conflict.";
                case ResultCode.kFPDirNotEmpty: return "Directory is not empty.";
                case ResultCode.kFPDiskFull: return "No more space exists on the volume";
                case ResultCode.kFPEOFErr: return "No more matches or end of fork reached.";
                case ResultCode.kFPFileBusy: return "When attempting a hard create, the file already exists and is open.";
                case ResultCode.kFPFlatVol: return "Volume is flat and does not support directories.";
                case ResultCode.kFPItemNotFound: return "Specified APPL mapping, comment, or icon was not found in the Desktop database; specified ID is unknown.";
                case ResultCode.kFPLockErr: return "Some or all of the requested range is locked by another user; a lock range conflict exists.";
                case ResultCode.kFPMiscErr: return "Non-AFP error occurred.";
                case ResultCode.kFPNoMoreLocks: return "Server’s maximum lock count has been reached.";
                case ResultCode.kFPNoServer: return "Server is not responding.";
                case ResultCode.kFPObjectExists: return "File or directory already exists.";
                case ResultCode.kFPObjectNotFound: return "Input parameters do not point to an existing directory, file, or volume.";
                case ResultCode.kFPParamErr: return "Session reference number, Desktop database reference number, open fork reference number, Volume ID, Directory ID, File ID, Group ID, or subfunction is unknown; byte range starts before byte zero; pathname is invalid; pathname type is unknown; user name is null, exceeds the UAM’s user name length limit, or does not exist, MaxReplySize is too small to hold a single offspring structure, ThisUser bit is not set, authentication failed for an undisclosed reason, specified user is unknown or the account has been disabled due to too many login attempts; ReqCount or Offset is negative; NewLineMask is invalid.";
                case ResultCode.kFPRangeNotLocked: return "Attempt to unlock a range that is locked by another user or that is not locked at all.";
                case ResultCode.kFPRangeOverlap: return "User tried to lock some or all of a range that the user has already locked.";
                case ResultCode.kFPSessClosed: return "Session is closed.";
                case ResultCode.kFPUserNotAuth: return "UAM failed (the specified old password doesn’t match); no user is logged in yet for the specified session; authentication failed; password is incorrect.";
                case ResultCode.kFPCallNotSupported: return "Server does not support this command.";
                case ResultCode.kFPObjectTypeErr: return "Input parameters point to the wrong type of object.";
                case ResultCode.kFPTooManyFilesOpen: return "Server cannot open another fork.";
                case ResultCode.kFPServerGoingDown: return "Server is shutting down.";
                case ResultCode.kFPCantRename: return "Attempt was made to rename a volume or root directory.";
                case ResultCode.kFPDirNotFound: return "Input parameters do not point to an existing directory.";
                case ResultCode.kFPIconTypeError: return "New icon’s size is different from the size of the existing icon.";
                case ResultCode.kFPVolLocked: return "Volume is Read Only.";
                case ResultCode.kFPObjectLocked: return "File or directory is marked DeleteInhibit; directory being moved, renamed, or moved and renamed is marked RenameInhibit; file being moved and renamed is marked RenameInhibit; attempt was made to open a file for writing that is marked WriteInhibit; attempt was made to rename a file or directory that is marked RenameInhibit.";
                case ResultCode.kFPContainsSharedErr: return "Directory contains a share point.";
                case ResultCode.kFPIDNotFound: return "File ID was not found. (No file thread exists.)";
                case ResultCode.kFPIDExists: return "File already has a File ID.";
                case ResultCode.kFPDiffVolErr: return "Wrong volume.";
                case ResultCode.kFPCatalogChanged: return "Catalog has changed.";
                case ResultCode.kFPSameObjectErr: return "Two objects that should be different are the same object.";
                case ResultCode.kFPBadIDErr: return "File ID is not valid.";
                case ResultCode.kFPPwdSameErr: return "User attempted to change his or her password to the same password that is currently set.";
                case ResultCode.kFPPwdTooShortErr: return "User password is shorter than the server’s minimum password length, or user attempted to change password to a password that is shorter than the server’s minimum password length.";
                case ResultCode.kFPPwdExpiredErr: return "User’s password has expired.";
                case ResultCode.kFPInsideSharedErr: return "Directory being moved contains a share point and is being moved into a directory that is shared or is the descendent of a directory that is shared.";
                case ResultCode.kFPInsideTrashErr: return "Shared directory is being moved into the Trash; a directory is being moved to the trash and it contains a shared folder.";
                case ResultCode.kFPPwdNeedsChangeErr: return "User’s password needs to be changed.";
                case ResultCode.kFPPwdPolicyErr: return "New password does not conform to the server’s password policy.";
                case ResultCode.kFPDiskQuotaExceeded: return "Disk quota exceeded";
            }
            return "?";
        }
    }
    #endregion

    public interface IDSI {
        byte[] ToArray(ushort RequestID);
    }

    public class DSIGetStatus : IDSI {
        public byte[] ToArray(ushort RequestID) {
            MemoryStream os = new MemoryStream();
            BEW wr = new BEW(os);
            wr.Write((byte)0);// REQ
            wr.Write((byte)3); // Command.GetStatus
            wr.Write((ushort)RequestID);
            wr.Write((uint)0); // off
            wr.Write((uint)0); // len
            wr.Write((uint)0); // reserved
            return os.ToArray();
        }
    }

    public class DSIOpenSession : IDSI {
        public byte[] ToArray(ushort RequestID) {
            MemoryStream os = new MemoryStream();
            BEW wr = new BEW(os);
            wr.Write((byte)0);// REQ
            wr.Write((byte)4); // Command.OpenSession
            wr.Write((ushort)RequestID);
            wr.Write((uint)0); // off
            wr.Write((uint)0); // len
            wr.Write((uint)0); // reserved
            return os.ToArray();
        }
    }

    public class DSICommand : IDSI {
        public IFP RequestPayload;

        public DSICommand WithRequestPayload(IFP RequestPayload) { this.RequestPayload = RequestPayload; return this; }

        public byte[] ToArray(ushort RequestID) {
            byte[] bin = RequestPayload.ToArray();

            MemoryStream os = new MemoryStream();
            BEW wr = new BEW(os);
            wr.Write((byte)0);// REQ
            wr.Write((byte)2); // Command
            wr.Write((ushort)RequestID);
            wr.Write((uint)0); // off
            wr.Write(Convert.ToUInt32(bin.Length)); // len
            wr.Write((uint)0); // reserved
            wr.Write(bin);
            return os.ToArray();
        }
    }

    public class DSICloseSession : IDSI {
        public byte[] ToArray(ushort RequestID) {
            MemoryStream os = new MemoryStream();
            BEW wr = new BEW(os);
            wr.Write((byte)0);// REQ
            wr.Write((byte)1); // Command.CloseSession
            wr.Write((ushort)RequestID);
            wr.Write((uint)0); // off
            wr.Write((uint)0); // len
            wr.Write((uint)0); // reserved
            return os.ToArray();
        }
    }
}
