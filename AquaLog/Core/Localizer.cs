/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace AquaLog.Core
{
    /// <summary>
    /// Localizable string id
    /// </summary>
    public enum LSID
    {
        /* 000 */ None,
        /* 001 */ First,

        /* 001 */ MIFile = 1,
        /* 002 */ MIEdit = 2,
        /* 003 */ MIHelp,
        /* 004 */ MIExit,
        /* 005 */ MIAbout,
        /* 006 */ MISettings,
        /* 007 */ MICleanSpace,
        /* 008 */ RecordDeleteQuery,
        /* 009 */ Aquariums,
        /* 010 */ Inhabitants,
        /* 011 */ Species,
        /* 012 */ Devices,
        /* 013 */ Nutrition,
        /* 014 */ Maintenance,
        /* 015 */ Notes,
        /* 016 */ History,
        /* 017 */ Measures,
        /* 018 */ Schedule,
        /* 019 */ Transfers,
        /* 020 */ Budget,
        /* 021 */ Accept,
        /* 022 */ Cancel,

        /* 000 */ Last = Cancel
    }


    public static class Localizer
    {
        public const int LS_DEF_CODE = 1033;
        public const string LS_DEF_SIGN = "enu";
        public const string LS_DEF_NAME = "English";

        private static readonly string[] LSDefList = new string[] {
            /* 001 */ "File",
            /* 002 */ "Edit",
            /* 003 */ "Help",
            /* 004 */ "Exit",
            /* 005 */ "About",
            /* 006 */ "Settings",
            /* 007 */ "Clean Space",
            /* 008 */ "Are you sure you want to remove record \"{0}\"?",
            /* 009 */ "Aquariums",
            /* 010 */ "Inhabitants",
            /* 011 */ "Species",
            /* 012 */ "Devices",
            /* 013 */ "Nutrition",
            /* 014 */ "Maintenance",
            /* 015 */ "Notes",
            /* 016 */ "History",
            /* 017 */ "Measures",
            /* 018 */ "Schedule",
            /* 019 */ "Transfers",
            /* 020 */ "Budget",
            /* 021 */ "Accept",
            /* 022 */ "Cancel",
        };


        private static readonly List<LocaleFile> fLocales;
        private static readonly Dictionary<int, string> fList;

        public static IList<LocaleFile> Locales
        {
            get { return fLocales; }
        }


        static Localizer()
        {
            fLocales = new List<LocaleFile>();
            fList = new Dictionary<int, string>();
        }

        public static string LS(LSID lsid)
        {
            int idx = ((IConvertible)lsid).ToInt32(null);
            string res;
            return (fList.TryGetValue(idx, out res)) ? res : "?";
        }

        public static void DefInit()
        {
            DefInit(LSDefList);
        }

        private static void DefInit(string[] source)
        {
            fList.Clear();
            for (LSID id = LSID.First; id <= LSID.Last; id++) {
                int idx = (int)id;
                fList.Add(idx, source[idx - 1]);
            }
        }

        public static bool LoadFromFile(string fileName)
        {
            bool result = false;

            if (File.Exists(fileName)) {
                fList.Clear();

                using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8)) {
                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.DtdProcessing = DtdProcessing.Ignore;

                    int lsId = -1;
                    string lsText;
                    using (XmlReader xr = XmlReader.Create(reader, settings)) {
                        while (xr.Read()) {
                            if (xr.NodeType == XmlNodeType.Element && xr.Name == "string") {
                                if (!int.TryParse(xr.GetAttribute("id"), out lsId)) {
                                    lsId = -1;
                                }
                                lsText = string.Empty;
                            } else if (xr.NodeType == XmlNodeType.Text && lsId != -1) {
                                lsText = xr.Value;
                                fList.Add(lsId, lsText);
                            }
                        }
                    }
                    result = true;
                }
            }

            return result;
        }

        private static void PrepareLocaleFile(string fileName)
        {
            try {
                using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8)) {
                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.DtdProcessing = DtdProcessing.Ignore;

                    int code = -1;
                    string name;
                    using (XmlReader xr = XmlReader.Create(reader, settings)) {
                        while (xr.Read()) {
                            if (xr.NodeType == XmlNodeType.Element && xr.Name == "resources") {
                                if (!int.TryParse(xr.GetAttribute("code"), out code)) {
                                    code = -1;
                                }
                                name = xr.GetAttribute("name");

                                fLocales.Add(new LocaleFile(code, "", name, fileName));
                                break;
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                //Logger.LogWrite("LangMan.PrepareLocaleFile("+fileName+"): " + ex.Message);
            }
        }

        public static void FindLocales()
        {
            try {
                string path = ALCore.GetLocalesPath();
                string[] localeFiles = Directory.GetFiles(path, "*.xml", SearchOption.TopDirectoryOnly);
                for (int i = 0; i < localeFiles.Length; i++) PrepareLocaleFile(localeFiles[i]);
            } catch (Exception ex) {
                //Logger.LogWrite("LangMan.FindLocales(): " + ex.Message);
            }
        }

        public static void LoadLocale(int localeCode)
        {
            if (localeCode != Localizer.LS_DEF_CODE) {
                bool loaded = false;

                foreach (LocaleFile localeFile in fLocales) {
                    if (localeFile.Code == localeCode) {
                        loaded = Localizer.LoadFromFile(localeFile.FileName);
                        break;
                    }
                }

                if (!loaded) localeCode = Localizer.LS_DEF_CODE;
            }

            if (localeCode == Localizer.LS_DEF_CODE) {
                DefInit();
            }

            //fInterfaceLang = (ushort)langCode;
        }

        public static LocaleFile GetLocaleByCode(int code)
        {
            foreach (LocaleFile localeFile in fLocales) {
                if (localeFile.Code == code) {
                    return localeFile;
                }
            }
            return null;
        }
    }

    public sealed class LocaleFile
    {
        public readonly int Code;
        public readonly string Sign;
        public readonly string Name;
        public readonly string FileName;

        public LocaleFile(int code, string sign, string name, string fileName)
        {
            Code = code;
            Sign = sign;
            Name = name;
            FileName = fileName;
        }
    }
}
