/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using AquaLog.Core.Types;

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
        public const int InactiveState = 0xE0E0E0;

        public const string UnknownName = "Unknown";
        public static readonly DateTime ZeroDate = new DateTime(0);

        public const string LOG_FILE = "AquaLog.log";
        public const string LOG_LEVEL = "INFO"; // "DEBUG";

        private static readonly int LitersDivider = 1000;

        private static string fAppDataPath = null;
        private const string fAppSign = "AquaLog";

        public ALCore()
        {
        }


        public static ItemType GetItemType(SpeciesType speciesType)
        {
            switch (speciesType) {
                case SpeciesType.Fish:
                    return ItemType.Fish;
                case SpeciesType.Invertebrate:
                    return ItemType.Invertebrate;
                case SpeciesType.Plant:
                    return ItemType.Plant;
                default:
                    return ItemType.None;
            }
        }

        public static Stream LoadResourceStream(string resName)
        {
            return LoadResourceStream(typeof(ALCore), resName);
        }

        public static Stream LoadResourceStream(Type baseType, string resName)
        {
            Assembly assembly = baseType.Assembly;
            return assembly.GetManifestResourceStream(resName);
        }

        public static Bitmap LoadResourceImage(string resName)
        {
            return new Bitmap(LoadResourceStream("AquaLog.Resources." + resName));
        }

        public static ListViewItem GetSelectedItem(ListView listView)
        {
            ListViewItem result;

            if (listView.SelectedItems.Count <= 0) {
                result = null;
            } else {
                result = (listView.SelectedItems[0] as ListViewItem);
            }

            return result;
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

        public static double GetDecimalVal(TextBox textBox)
        {
            string strVal = textBox.Text;
            double value;
            return (double.TryParse(strVal, out value)) ? value : 0.0d;
        }

        public static string GetDecimalStr(double value)
        {
            return value.ToString("0.00");
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
