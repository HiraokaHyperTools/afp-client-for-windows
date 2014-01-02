using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AFPClient4Windows {
    static class Program {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(String[] args) {
            String fp = null;
            for (int x = 0; x < args.Length; x++) {
                if (args[x] == "/open") {
                    x++;
                    if (x < args.Length) {
                        fp = args[x];
                    }
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MForm(fp));
            //Application.Run(new DropForm());
        }
    }
}