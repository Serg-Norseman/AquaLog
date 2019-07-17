/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace AquaLog.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class ALCore
    {
        public const int UpdateInterval = 1000;

        public const int NormalState = 0xC0FFFF;
        public const int WarningState = 0xFFFFC0;
        public const int AlertState = 0xFFC0C0;

        private static readonly int LitersDivider = 1000;

        private static string fAppDataPath = null;
        private const string fAppSign = "AquaLog";

        public ALCore()
        {
        }

        #region Calculations

        public static double CalcArea(double depth, double width)
        {
            return depth * width;
        }

        public static double CalcVolume(double depth, double width, double height)
        {
            return depth * width * height / LitersDivider;
        }

        #endregion

        public static Color CreateColor(int rgb)
        {
            int red = (rgb >> 16) & 0xFF;
            int green = (rgb >> 8) & 0xFF;
            int blue = (rgb >> 0) & 0xFF;
            return Color.FromArgb(red, green, blue);
        }

        #region Application Runtime

        private static Assembly GetAssembly()
        {
            Assembly asm = Assembly.GetEntryAssembly();
            if (asm == null) {
                asm = Assembly.GetExecutingAssembly();
            }
            return asm;
        }

        public static Version GetAppVersion()
        {
            return GetAssembly().GetName().Version;
        }

        public static T GetAssemblyAttribute<T>(Assembly assembly) where T : Attribute
        {
            if (assembly == null)
                throw new ArgumentNullException("assembly");

            object[] attributes = assembly.GetCustomAttributes(typeof(T), false);
            T result;
            if (attributes == null || attributes.Length == 0) {
                result = null;
            } else {
                result = attributes[0] as T;
            }
            return result;
        }

        public static string GetAppCopyright()
        {
            var attr = GetAssemblyAttribute<AssemblyCopyrightAttribute>(GetAssembly());
            return (attr == null) ? string.Empty : attr.Copyright;
        }

        protected static string GetAppSign()
        {
            return fAppSign;
        }

        public static string GetAppDataPath()
        {
            string path;

            if (string.IsNullOrEmpty(fAppDataPath)) {
                path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                    Path.DirectorySeparatorChar + GetAppSign() + Path.DirectorySeparatorChar;
            } else {
                path = fAppDataPath;
            }

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            return path;
        }

        public static string GetAppPath()
        {
            Assembly asm = Assembly.GetEntryAssembly();
            if (asm == null) {
                asm = Assembly.GetExecutingAssembly();
            }

            Module[] mods = asm.GetModules();
            string fn = mods[0].FullyQualifiedName;
            return Path.GetDirectoryName(fn) + Path.DirectorySeparatorChar;
        }

        public static void CheckPortable(string[] args)
        {
            const string HomeDirArg = "-homedir:";
            const string LocalAppDataFolder = "appdata\\";

            string appPath = GetAppPath();

            string homedir = "";
            if (args != null && args.Length > 0) {
                foreach (var arg in args) {
                    if (arg.StartsWith(HomeDirArg)) {
                        homedir = arg.Remove(0, HomeDirArg.Length);
                    }
                }
            }

            if (!string.IsNullOrEmpty(homedir)) {
                string path = Path.Combine(appPath, homedir);
                if (Directory.Exists(path)) {
                    fAppDataPath = Path.Combine(path, LocalAppDataFolder);
                }
            }

            if (string.IsNullOrEmpty(fAppDataPath)) {
                string path = Path.Combine(appPath, LocalAppDataFolder);
                if (Directory.Exists(path)) {
                    fAppDataPath = path;
                }
            }
        }

        #endregion
    }
}
