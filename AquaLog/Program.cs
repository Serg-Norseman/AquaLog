/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Threading;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.UI;

namespace AquaLog
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            ALCore.CheckPortable(args);

            #if NETCOREAPP30
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            #endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool isFirstInstance;
            using (Mutex mtx = new Mutex(true, "AquaLog", out isFirstInstance)) {
                if (isFirstInstance) {
                    var mainForm = new MainForm();
                    using (ALTray tray = new ALTray(mainForm)) {
                        mainForm.Tray = tray;
                        Application.Run(mainForm);
                    }
                }
            }
        }
    }
}
