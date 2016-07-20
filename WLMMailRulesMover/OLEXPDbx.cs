// WLMMailRulesMover:
//   Uses ESENT Managed Interop (http://managedesent.codeplex.com/)
//        Licensed under Microsoft Public License (MS-PL)
//   Developed by HIRAOKA HYPERS TOOLS, Inc.
//   Licensed under Microsoft Public License (MS-PL)

using System;
using System.Collections.Generic;
using System.Text;

namespace WLMMailRulesMover.OLEXPDbx {
    // http://oedbx.aroh.de/

    public class DbxFH {
        byte[] bin;
        int off;

        public DbxFH(byte[] bin, int off) {
            this.bin = bin;
            this.off = off;
        }

        public bool IsMessageDatabase { get { return BitConverter.ToUInt32(bin, off + 4) == 0x6F74FDC5U; } }
        public bool IsFolderDatabase { get { return BitConverter.ToUInt32(bin, off + 4) == 0x6F74FDC6U; } }

        public DbxTre E4 { get { return new DbxTre(bin, BitConverter.ToInt32(bin, off + 0xE4)); } }
    }

    public class DbxTre {
        byte[] bin;
        int off;

        public DbxTre(byte[] bin, int off) {
            this.bin = bin;
            this.off = off;
        }

        public int ObjectMarker { get { return BitConverter.ToInt32(bin, off + 0); } }

        public int PtrChildNode { get { return BitConverter.ToInt32(bin, off + 8); } }
        public int PtrParentNode { get { return BitConverter.ToInt32(bin, off + 12); } }
        public byte NodeId { get { return bin[off + 16]; } }
        public byte CountEntries { get { return bin[off + 17]; } }

        public int Stored { get { return BitConverter.ToInt32(bin, off + 20); } }

        public DbxTreent[] Entries {
            get {
                int cx = CountEntries;
                DbxTreent[] al = new DbxTreent[cx];
                for (int x = 0; x < cx; x++) {
                    al[x] = new DbxTreent(bin, off + 24 + 12 * x);
                }
                return al;
            }
        }

        public DbxTre ChildNode {
            get {
                int ptr = PtrChildNode;
                return (ptr != 0) ? new DbxTre(bin, ptr) : null;
            }
        }
        public DbxTre ParentNode {
            get {
                int ptr = PtrParentNode;
                return (ptr != 0) ? new DbxTre(bin, ptr) : null;
            }
        }
    }

    public class DbxTreent {
        byte[] bin;
        int off;

        public DbxTreent(byte[] bin, int off) {
            this.bin = bin;
            this.off = off;
        }

        public int Value { get { return BitConverter.ToInt32(bin, off + 0); } }
        public int PtrChildNode { get { return BitConverter.ToInt32(bin, off + 4); } }
        public int Stored { get { return BitConverter.ToInt32(bin, off + 8); } }

        public DbxII IndexedInfo { get { return new DbxII(bin, Value); } }

        public DbxTre ChildNode {
            get {
                int ptr = PtrChildNode;
                return (ptr != 0) ? new DbxTre(bin, ptr) : null;
            }
        }
    }

    public class DbxII { // indexed info
        byte[] bin;
        int off;

        public DbxII(byte[] bin, int off) {
            this.bin = bin;
            this.off = off;
        }

        public int ObjectMarker { get { return BitConverter.ToInt32(bin, off + 0); } }
        public int Len4 { get { return BitConverter.ToInt32(bin, off + 4); } }
        public ushort Len8 { get { return BitConverter.ToUInt16(bin, off + 8); } }
        public byte CountEntries { get { return bin[off + 10]; } }
        public byte CountChanges { get { return bin[off + 11]; } }

        public DbxIF[] Fields {
            get {
                int cx = CountEntries;
                int dataoff = off + 12 + 4 * cx;
                DbxIF[] al = new DbxIF[cx];
                for (int x = 0; x < cx; x++) {
                    al[x] = new DbxIF(bin, off + 12 + 4 * x, dataoff);
                }
                return al;
            }
        }
    }

    public class DbxIF {
        byte[] bin;
        int off, dataoff;

        public DbxIF(byte[] bin, int off, int dataoff) {
            this.bin = bin;
            this.off = off;
            this.dataoff = dataoff;
        }

        public byte Index { get { return (byte)(bin[off] & 0x7F); } }
        public bool Direct { get { return 0 != (bin[off] & 0x80); } }
        public int Value { get { return bin[off + 1] | (bin[off + 2] << 8) | (bin[off + 3] << 16); } }

        public String StringValue {
            get {
                if (Direct) return null;
                int x0 = dataoff + Value;
                int x1 = x0;
                for (; bin[x1] != 0; x1++) { }
                return Encoding.Default.GetString(bin, x0, x1 - x0);
            }
        }

        public Int32 Int32Value {
            get {
                if (Direct) return Value;
                return BitConverter.ToInt32(bin, dataoff + Value);
            }
        }
    }
}
