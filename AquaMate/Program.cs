/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Threading;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.UI;

namespace AquaMate
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            ALCore.CheckPortable(args);

            bool isFirstInstance;
            using (Mutex mtx = new Mutex(true, "AquaMate", out isFirstInstance)) {
                if (isFirstInstance) {
                    MainForm.AppInit();

                    var mainForm = new MainForm();
                    Application.Run(mainForm);
                }
            }
        }
    }
}
