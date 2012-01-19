using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AFPt {
    // @8:25 2010/10/13
    public class BER {
        BinaryReader br;

        public BER(Stream si) {
            br = new BinaryReader(si);
        }

        public Stream BaseStream { get { return br.BaseStream; } }

        public byte ReadByte() { return br.ReadByte(); }
        public sbyte ReadSByte() { return br.ReadSByte(); }
        public short ReadInt16() {
            int v = br.ReadByte() << 8;
            v |= br.ReadByte();
            return (short)v;
        }
        public ushort ReadUInt16() { return (ushort)ReadInt16(); }
        public int ReadInt32() {
            int v = br.ReadByte() << 24;
            v |= br.ReadByte() << 16;
            v |= br.ReadByte() << 8;
            v |= br.ReadByte();
            return v;
        }
        public uint ReadUInt32() { return (uint)ReadInt32(); }
        public byte[] ReadBytes(int cb) { return (cb == 0) ? new byte[0] : br.ReadBytes(cb); }

        public ulong ReadUInt64() { return (ulong)ReadInt64(); }
        public long ReadInt64() {
            int v = br.ReadByte() << 24;
            v |= br.ReadByte() << 16;
            v |= br.ReadByte() << 8;
            v |= br.ReadByte();
            int w = br.ReadByte() << 24;
            w |= br.ReadByte() << 16;
            w |= br.ReadByte() << 8;
            w |= br.ReadByte();
            return (long)(v << 32) | (long)w;
        }
    }
}
