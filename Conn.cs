using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace AFPClient4Windows {
    [XmlRoot("Conn", Namespace = "https://code.google.com/p/afp-client-for-windows/Conn", IsNullable = false)]
    public class Conn {
        String _Host;

        [XmlAttribute()]
        public String Host { get { return _Host; } set { _Host = value; } }

        String _U;

        [XmlAttribute()]
        public String U { get { return _U; } set { _U = value; } }

        String _P;

        [XmlAttribute()]
        public String P { get { return _P; } set { _P = value; } }

        String _HostDir;

        [XmlAttribute()]
        public String HostDir { get { return _HostDir; } set { _HostDir = value; } }

        uint _AuthMethod = 8U | 16U;

        [XmlAttribute()]
        public bool AllowNoUserAuth { get { return BitUt.Get(_AuthMethod, 0); } set { _AuthMethod = BitUt.Set(_AuthMethod, 0, value); } }

        [XmlAttribute()]
        public bool AllowClearText { get { return BitUt.Get(_AuthMethod, 1); } set { _AuthMethod = BitUt.Set(_AuthMethod, 1, value); } }
        
        [XmlAttribute()]
        public bool AllowTwoWayRandNum { get { return BitUt.Get(_AuthMethod, 2); } set { _AuthMethod = BitUt.Set(_AuthMethod, 2, value); } }
        
        [XmlAttribute()]
        public bool AllowDHCAST128 { get { return BitUt.Get(_AuthMethod, 3); } set { _AuthMethod = BitUt.Set(_AuthMethod, 3, value); } }
        
        [XmlAttribute()]
        public bool AllowDHX2 { get { return BitUt.Get(_AuthMethod, 4); } set { _AuthMethod = BitUt.Set(_AuthMethod, 4, value); } }

        class BitUt {
            internal static bool Get(uint v, int x) { return 0 != (v & (1U << x)); }
            internal static uint Set(uint v, int x, bool f) {
                return f ? v | (1U << x) : v & ~(1U << x);
            }
        }
    }
}
