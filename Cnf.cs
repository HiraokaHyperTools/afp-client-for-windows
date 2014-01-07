using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace AFPClient4Windows {
    public class Cnf {
        public static string Basek { get { return @"Software\HIRAOKA HYPERS TOOLS, Inc.\AFPClient4Windows"; } }

        public static List<CHost> ReadHosts() {
            List<CHost> al = new List<CHost>();
            RegistryKey rk;
            for (int x = 0; null != (rk = Registry.CurrentUser.OpenSubKey(Basek + @"\Options\Host" + x, false)); x++) {
                al.Add(new CHost().WithRead(rk));
                rk.Close();
            }
            return al;
        }

        public static void SaveHosts(List<CHost> alc) {
            int x = 0;
            for (; x < alc.Count; x++) {
                using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(Basek + @"\Options\Host" + x)) {
                    alc[x].Saveto(rk);
                }
            }
            Registry.CurrentUser.DeleteSubKey(Basek + @"\Options\Host" + x, false);
        }

        public static void SaveRemoteDir(int saveIndex, String dir) {
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(Basek + @"\Options\Host" + saveIndex, true)) {
                if (rk != null) {
                    rk.SetValue("RemoteDir", dir);
                }
            }
        }

        public static void SaveVol(int saveIndex, String vol) {
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(Basek + @"\Options\Host" + saveIndex, true)) {
                if (rk != null) {
                    rk.SetValue("HostVol", vol);
                }
            }
        }
    }
    public class CHost {
        public String HostName = String.Empty;
        public String HostAdrs = String.Empty;
        public String HostVol = String.Empty;
        public String UserName = String.Empty;
        public String Password = String.Empty;
        public String LocalDir = String.Empty;
        public String RemoteDir = String.Empty;
        public bool Last = false;
        public uint Set = 0;

        public bool cbNoUserAuthent = false;
        public bool cbCleartxtPasswrd = false;
        public bool cb2WayRandnumExchange = false;
        public bool cbDHCAST128 = false;
        public bool cbDHX2 = false;

        public CHost() { }

        internal void Saveto(RegistryKey rk) {
            rk.SetValue("HostName", HostName);
            rk.SetValue("HostAdrs", HostAdrs);
            rk.SetValue("HostVol", HostVol);
            rk.SetValue("UserName", UserName);
            rk.SetValue("Password", Password);
            rk.SetValue("LocalDir", LocalDir);
            rk.SetValue("RemoteDir", RemoteDir);
            RUt.W(rk, "Last", Last);
            rk.SetValue("Set", Set, RegistryValueKind.DWord);

            RUt.W(rk, "cbNoUserAuthent", cbNoUserAuthent);
            RUt.W(rk, "cbCleartxtPasswrd", cbCleartxtPasswrd);
            RUt.W(rk, "cb2WayRandnumExchange", cb2WayRandnumExchange);
            RUt.W(rk, "cbDHCAST128", cbDHCAST128);
            RUt.W(rk, "cbDHX2", cbDHX2);
        }

        class RUt {
            internal static void W(RegistryKey rk, String name, bool v) {
                rk.SetValue(name, v ? 1U : 0U, RegistryValueKind.DWord);
            }

            internal static bool R(RegistryKey rk, String name, bool defv) {
                return Convert.ToUInt32(rk.GetValue(name, defv)) != 0;
            }
        }

        public CHost WithRead(RegistryKey rk) {
            HostName = (rk.GetValue("HostName") as String) ?? String.Empty;
            HostAdrs = (rk.GetValue("HostAdrs") as String) ?? String.Empty;
            HostVol = (rk.GetValue("HostVol") as String) ?? String.Empty;
            UserName = (rk.GetValue("UserName") as String) ?? String.Empty;
            Password = (rk.GetValue("Password") as String) ?? String.Empty;
            LocalDir = (rk.GetValue("LocalDir") as String) ?? String.Empty;
            RemoteDir = (rk.GetValue("RemoteDir") as String) ?? String.Empty;
            Last = RUt.R(rk, "Last", false);
            Set = Convert.ToUInt32(rk.GetValue("Set", (uint)0));

            cbNoUserAuthent = RUt.R(rk, "cbNoUserAuthent", false);
            cbCleartxtPasswrd = RUt.R(rk, "cbCleartxtPasswrd", false);
            cb2WayRandnumExchange = RUt.R(rk, "cb2WayRandnumExchange", false);
            cbDHCAST128 = RUt.R(rk, "cbDHCAST128", false);
            cbDHX2 = RUt.R(rk, "cbDHX2", false);

            return this;
        }

        internal CHost Clone() {
            CHost o = (CHost)MemberwiseClone();
            return o;
        }
    }
}
