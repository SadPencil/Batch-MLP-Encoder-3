using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace SadPencil.BatchMLPEncoder3 {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Program.IsDotNet46OrLater()) {
                if ((new LanguageForm()).ShowDialog() == DialogResult.OK) {
                    Application.Run(new MainForm());
                }
            }
            else {
                string ErrorMsg = "You MUST install .NET Framework 4.6 or later.";// + Environment.NewLine + "最低需要 .NET Framework 4.6。";
                MessageBox.Show(ErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.ExitCode = 11;
            }

        }
        private static bool IsDotNet46OrLater() {
            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\")) {
                if (ndpKey != null && ndpKey.GetValue("Release") != null) {
                    int releaseKey = (int)ndpKey.GetValue("Release");
                    return (releaseKey >= 393295);
                }
                else {
                    return false;
                }
            }
        }

    }
}
