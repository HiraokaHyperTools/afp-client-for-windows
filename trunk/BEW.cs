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
            byte[] bin = new byte[]{
                (byte)(w >> 8),
                (byte)(w >> 0),
            };
            wr.Write(bin);
        }
        public void Write(int sdw) { Write((uint)sdw); }
        public void Write(uint dw) {
            byte[] bin = new byte[]{
                (byte)(dw >> 24),
                (byte)(dw >> 16),
                (byte)(dw >> 8),
                (byte)(dw >> 0),
            };
            wr.Write(bin);
        }
        public void Write(long sqw) { Write((ulong)sqw); }
        public void Write(ulong qw) {
            byte[] bin = new byte[]{
                (byte)(qw >> 56),
                (byte)(qw >> 48),
                (byte)(qw >> 40),
                (byte)(qw >> 32),
                (byte)(qw >> 24),
                (byte)(qw >> 16),
                (byte)(qw >> 8),
                (byte)(qw >> 0),
            };
            wr.Write(bin);
        }
        public void Write(byte[] buffer, int index, int count) {
            wr.Write(buffer, index, count);
        }
    }
}
