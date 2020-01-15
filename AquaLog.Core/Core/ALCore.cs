﻿/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.ComponentModel;
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
            return value.ToString(fmt, SQLITE_NFI);
        }

        public static string GetDateStr(DateTime value)
        {
            return value.ToString("yyyy/MM/dd");
        }

        public static string GetTimeStr(DateTime value)
        {
            return value.ToString("yyyy/MM/dd HH:mm:ss");
        }

        public static string GetRangeStr(double min, double max)
        {
            if (double.IsNaN(min) && double.IsNaN(max)) {
                return string.Empty;
            }
            return ALCore.GetDecimalStr(min) + " - " + ALCore.GetDecimalStr(max);
        }

        public static string GetTimespanText(DateTime startDate, DateTime endDate)
        {
            const double ApproxDaysPerMonth = 30.4375;
            const double ApproxDaysPerYear = 365.25;

            /*
            The above are the average days per month/year over a normal 4 year period
            We use these approximations as they are more accurate for the next century or so
            After that you may want to switch over to these 400 year approximations

                ApproxDaysPerMonth = 30.436875
                ApproxDaysPerYear  = 365.2425 

            How to get theese numbers:
                The are 365 days in a year, unless it is a leepyear.
                Leepyear is every forth year if Year % 4 = 0
                unless year % 100 == 1
                unless if year % 400 == 0 then it is a leep year.

            This gives us 97 leep years in 400 years. 
            So 400 * 365 + 97 = 146097 days.
            146097 / 400      = 365.2425
            146097 / 400 / 12 = 30,436875

            Due to the nature of the leap year calculation, on this side of the year 2100
            you can assume every 4th year is a leap year and use the other approximations
            */

            // Calculate the span in days
            int iDays = (endDate - startDate).Days;

            // Calculate years as an integer division
            int iYear = (int)(iDays / ApproxDaysPerYear);

            // Decrease remaing days
            iDays -= (int)(iYear * ApproxDaysPerYear);

            // Calculate months as an integer division
            int iMonths = (int)(iDays / ApproxDaysPerMonth);

            // Decrease remaing days
            iDays -= (int)(iMonths * ApproxDaysPerMonth);

            // Return the result as an string
            string result = "";
            if (iDays > 0) result = string.Format(Localizer.LS(LSID.DaysStr), iDays);
            if (iMonths > 0) {
                if (result.Length > 0) result = ", " + result;
                result = string.Format(Localizer.LS(LSID.MonthsStr), iMonths) + result;
            }
            if (iYear > 0) {
                if (result.Length > 0) result = ", " + result;
                result = string.Format(Localizer.LS(LSID.YearsStr), iYear) + result;
            }
            return result;
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

        public static void SetDisplayNameValue(object obj, string propName, string value)
        {
            SetAttributeValue(obj, propName, typeof(DisplayNameAttribute), "_displayName", value);
        }

        public static void SetCategoryValue(object obj, string propName, string value)
        {
            SetAttributeValue(obj, propName, typeof(CategoryAttribute), "categoryValue", value);
        }

        public static void SetDescriptionValue(object obj, string propName, string value)
        {
            SetAttributeValue(obj, propName, typeof(DescriptionAttribute), "description", value);
        }

        private static void SetAttributeValue(object obj, string propName, Type attrType, string fieldName, string value)
        {
            if (obj == null || string.IsNullOrEmpty(propName) || string.IsNullOrEmpty(fieldName))
                return;

            PropertyDescriptor prop = TypeDescriptor.GetProperties(obj.GetType())[propName];
            if (prop == null) return;

            Attribute att = prop.Attributes[attrType];
            if (att == null) return;

            FieldInfo cat = att.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            if (cat == null) return;

            cat.SetValue(att, value);
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

        public static string GetAppCopyright()
        {
            var attr = ReflectionHelper.GetAssemblyAttribute<AssemblyCopyrightAttribute>(GetAssembly());
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
