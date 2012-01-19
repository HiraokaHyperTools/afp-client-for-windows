using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AFPt {
    // @8:25 2010/10/13
    public class BEW {
        BinaryWriter wr;

        public BEW(Stream fs) {
            wr = new BinaryWriter(fs);
        }

        public void Write(byte[] bin) { wr.Write(bin); }
        public void Write(sbyte sb) { Write((byte)sb); }
        public void Write(byte b) {
            wr.Write(b);
        }
        public void Write(short sw) { Write((ushort)sw); }
        public void Write(ushort w) {
            wr.Write((byte)(w >> 8));
            wr.Write((byte)(w >> 0));
        }
        public void Write(int sdw) { Write((uint)sdw); }
        public void Write(uint dw) {
            wr.Write((byte)(dw >> 24));
            wr.Write((byte)(dw >> 16));
            wr.Write((byte)(dw >> 8));
            wr.Write((byte)(dw >> 0));
        }
        public void Write(long sqw) { Write((ulong)sqw); }
        public void Write(ulong qw) {
            wr.Write((byte)(qw >> 56));
            wr.Write((byte)(qw >> 48));
            wr.Write((byte)(qw >> 40));
            wr.Write((byte)(qw >> 32));
            wr.Write((byte)(qw >> 24));
            wr.Write((byte)(qw >> 16));
            wr.Write((byte)(qw >> 8));
            wr.Write((byte)(qw >> 0));
        }
    }
}
