/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using AquaLog.Core.Types;
using BSLib;

namespace AquaLog.Core
{
    /// <summary>
    /// 
    /// </summary>
    public static class ALCore
    {
        public static bool TEST_MODE = false;

        public const int UpdateInterval = 1000;

        public const int NormalState = 0xC0FFFF;
        public const int WarningState = 0xFFFFC0;
        public const int AlertState = 0xFFC0C0;
        public const int InactiveState = 0xE0E0E0;

        public const string UnknownName = "Unknown";
        public static readonly DateTime ZeroDate = new DateTime(0);

        public const string LOG_FILE = "AquaLog.log";
        public const string LOG_LEVEL = "INFO"; // "DEBUG";

        private static string fAppDataPath = null;

        public const string AppName = "AquaLog";

        private static readonly NumberFormatInfo SQLITE_NFI = new NumberFormatInfo {
            NumberDecimalSeparator = ".",
            NumberGroupSeparator = ""
        };


        public static string FmtSQLiteDate(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string FmtSQLiteFloat(double value)
        {
            return value.ToString(SQLITE_NFI);
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
                case SpeciesType.Coral:
                    return ItemType.Coral;
                default:
                    return ItemType.None;
            }
        }

        public static ItemType GetItemType(InventoryType inventoryType)
        {
            switch (inventoryType) {
                case InventoryType.Additive:
                    return ItemType.Additive;

                case InventoryType.Chemistry:
                    return ItemType.Chemistry;

                case InventoryType.Equipment:
                    return ItemType.Equipment;

                case InventoryType.Maintenance:
                    return ItemType.Maintenance;

                case InventoryType.Furniture:
                    return ItemType.Furniture;

                case InventoryType.Decoration:
                    return ItemType.Decoration;

                default:
                    return ItemType.None;
            }
        }

        public static bool IsAnimal(SpeciesType speciesType)
        {
            return speciesType == SpeciesType.Fish || speciesType == SpeciesType.Invertebrate;
        }

        public static bool IsInhabitant(ItemType itemType)
        {
            return (itemType >= ItemType.Fish && itemType <= ItemType.Coral);
        }

        public static bool IsLifesupport(ItemType itemType)
        {
            return (itemType >= ItemType.Nutrition && itemType <= ItemType.Chemistry);
        }

        public static double GetDecimalVal(string strVal, double defaultValue = 0.0d)
        {
            return ConvertHelper.ParseFloat(strVal, defaultValue, true);
        }

        public static string GetDecimalStr(double value, int decimalDigits = 2, bool hideZero = false)
        {
            if (value == 0.0d && hideZero) {
                return string.Empty;
            }

            string fmt = "0.".PadRight(2 + decimalDigits, '0');
            return value.ToString(fmt);
        }

        public static string GetDateStr(DateTime value)
        {
            return value.ToString("dd/MM/yyyy");
        }

        public static string GetRangeStr(double min, double max)
        {
            if (double.IsNaN(min) && double.IsNaN(max)) {
                return string.Empty;
            }
            return ALCore.GetDecimalStr(min) + " - " + ALCore.GetDecimalStr(max);
        }

        public static void LoadExtFile(string fileName, string args = "")
        {
            #if !CI_MODE
            if (File.Exists(fileName)) {
                Process.Start(new ProcessStartInfo("file://"+fileName) { UseShellExecute = true, Arguments = args });
            } else {
                Process.Start(fileName);
            }
            #endif
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

        public static Version GetAppVersion()
        {
            return GetAssembly().GetName().Version;
        }

        public static string GetAppDataPath()
        {
            string path;

            if (TEST_MODE) {
                path = Environment.GetEnvironmentVariable("TEMP") + Path.DirectorySeparatorChar;
            } else {
                if (string.IsNullOrEmpty(fAppDataPath)) {
                    path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                        Path.DirectorySeparatorChar + AppName + Path.DirectorySeparatorChar;
                } else {
                    path = fAppDataPath;
                }
            }

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            return path;
        }

        public static string GetLocalesPath()
        {
            string appPath = GetAppPath();
            return appPath + "locales" + Path.DirectorySeparatorChar;
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
