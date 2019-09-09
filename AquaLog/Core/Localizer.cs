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

        /* 001 */ File = 1,
        /* 002 */ Edit = 2,
        /* 003 */ Help,
        /* 004 */ Exit,
        /* 005 */ About,
        /* 006 */ Settings,
        /* 007 */ CleanSpace,
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
        /* 023 */ Add,
        /* 024 */ Delete,
        /* 025 */ Language,
        /* 026 */ HideClosedTanks,
        /* 027 */ ExitOnClose,
        /* 028 */ Autorun,
        /* 029 */ Name,
        /* 030 */ Description,
        /* 031 */ Shape,
        /* 032 */ StartDate,
        /* 033 */ StopDate,
        /* 034 */ WaterType,
        /* 035 */ Width,
        /* 036 */ Depth,
        /* 037 */ Heigth,
        /* 038 */ TankVolume,
        /* 039 */ WaterVolume,
        /* 040 */ GlassThickness,
        /* 041 */ Note,
        /* 042 */ Sex,
        /* 043 */ Aquarium,
        /* 044 */ Inhabitant,
        /* 045 */ SpeciesS,
        /* 046 */ Device,
        /* 047 */ Event,
        /* 048 */ Measure,
        /* 049 */ ScheduleS,
        /* 050 */ Transfer,
        /* 051 */ Date,
        /* 052 */ Type,
        /* 053 */ Value,
        /* 054 */ Reminder,
        /* 055 */ Status,
        /* 056 */ SourceTank,
        /* 057 */ TargetTank,
        /* 058 */ Cause,
        /* 059 */ Quantity,
        /* 060 */ Shop,
        /* 061 */ UnitPrice,
        /* 062 */ Item,
        /* 063 */ Text,
        /* 064 */ Brand,
        /* 065 */ Amount,
        /* 066 */ Inventory,
        /* 067 */ Additive,
        /* 068 */ Chemistry,
        /* 069 */ Equipment,
        /* 070 */ Furniture,
        /* 071 */ Decoration,
        /* 072 */ Timestamp,
        /* 073 */ Enabled,
        /* 074 */ Digital,
        /* 075 */ Power,
        /* 076 */ WorkTime,
        /* 077 */ TSDBPoint,
        /* 078 */ Data,
        /* 079 */ Trend,
        /* 080 */ DataMonitor,
        /* 081 */ Chart,
        /* 082 */ Relocation,
        /* 083 */ Purchase,
        /* 084 */ Sale,
        /* 085 */ Birth,
        /* 086 */ Death,
        /* 087 */ Light,
        /* 088 */ Pump,
        /* 089 */ Thermometer,
        /* 090 */ Filter,
        /* 091 */ Heater,
        /* 092 */ Sum,
        /* 093 */ Restart,
        /* 094 */ WaterAdded,
        /* 095 */ WaterReplaced,
        /* 096 */ WaterRemoved,
        /* 097 */ Clean,
        /* 098 */ Other,
        /* 099 */ IntroductionDate,
        /* 100 */ Fish,
        /* 101 */ Invertebrate,
        /* 102 */ Plant,
        /* 103 */ Coral,
        /* 104 */ Compatibility,
        /* 105 */ Unit,
        /* 106 */ WaterChanges,
        /* 107 */ Common,
        /* 108 */ Tank,
        /* 109 */ NavPrev,
        /* 110 */ NavNext,
        /* 111 */ Min,
        /* 112 */ Max,
        /* 113 */ Deviation,
        /* 114 */ Female,
        /* 115 */ Male,
        /* 116 */ Hermaphrodite,
        /* 117 */ FreshWater,
        /* 118 */ BrackishWater,
        /* 119 */ SeaWater,
        /* 120 */ Bowl,
        /* 121 */ Cube,
        /* 122 */ Rectangular,
        /* 123 */ BowFront,
        /* 124 */ PlateFrontCorner,
        /* 125 */ BowFrontCorner,
        /* 126 */ Single,
        /* 127 */ Daily,
        /* 128 */ Weekly,
        /* 129 */ Monthly,
        /* 130 */ Yearly,
        /* 131 */ ToDo,
        /* 132 */ Canceled,
        /* 133 */ Snoozed,
        /* 134 */ Late,
        /* 135 */ Closed,
        /* 136 */ Calculator,
        /* 137 */ Calculate,
        /* 138 */ AdultSize,
        /* 139 */ LifeSpan,
        /* 140 */ BalanceStr,
        /* 141 */ Alive,
        /* 142 */ Dead,
        /* 143 */ Sick,
        /* 144 */ InUse,
        /* 145 */ Stopped,
        /* 146 */ Finished,
        /* 147 */ Broken,
        /* 148 */ State,
        /* 149 */ HideAtStartup,
        /* 150 */ SL_Any,
        /* 151 */ SL_Top,
        /* 152 */ SL_Top_and_Mid,
        /* 153 */ SL_Mid,
        /* 154 */ SL_Mid_and_Bottom,
        /* 155 */ SL_Bottom,
        /* 156 */ SwimLevel,

        /* 000 */ Last = SwimLevel
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
            /* 023 */ "Add",
            /* 024 */ "Delete",
            /* 025 */ "Language",
            /* 026 */ "Hide closed tanks",
            /* 027 */ "Exit on Close",
            /* 028 */ "Autorun",
            /* 029 */ "Name",
            /* 030 */ "Description",
            /* 031 */ "Shape",
            /* 032 */ "Start date",
            /* 033 */ "Stop date",
            /* 034 */ "Water type",
            /* 035 */ "Width",
            /* 036 */ "Depth",
            /* 037 */ "Heigth",
            /* 038 */ "Tank volume",
            /* 039 */ "Water volume",
            /* 040 */ "Glass thickness",
            /* 041 */ "Note",
            /* 042 */ "Sex",
            /* 043 */ "Aquarium",
            /* 044 */ "Inhabitant",
            /* 045 */ "Species",
            /* 046 */ "Device",
            /* 047 */ "Event",
            /* 048 */ "Measure",
            /* 049 */ "Schedule",
            /* 050 */ "Transfer",
            /* 051 */ "Date",
            /* 052 */ "Type",
            /* 053 */ "Value",
            /* 054 */ "Reminder",
            /* 055 */ "Status",
            /* 056 */ "From aquarium",
            /* 057 */ "To Aquarium",
            /* 058 */ "Cause",
            /* 059 */ "Quantity",
            /* 060 */ "Shop",
            /* 061 */ "Unit price",
            /* 062 */ "Item",
            /* 063 */ "Text",
            /* 064 */ "Brand",
            /* 065 */ "Amount",
            /* 066 */ "Inventory",
            /* 067 */ "Additive",
            /* 068 */ "Chemistry",
            /* 069 */ "Equipment",
            /* 070 */ "Furniture",
            /* 071 */ "Decoration",
            /* 072 */ "Timestamp",
            /* 073 */ "Enabled",
            /* 074 */ "Digital",
            /* 075 */ "Power",
            /* 076 */ "Work time",
            /* 077 */ "TSDB Point",
            /* 078 */ "Data",
            /* 079 */ "Trend",
            /* 080 */ "Data Monitor",
            /* 081 */ "Chart",
            /* 082 */ "Relocation",
            /* 083 */ "Purchase",
            /* 084 */ "Sale",
            /* 085 */ "Birth",
            /* 086 */ "Death",
            /* 087 */ "Light",
            /* 088 */ "Pump",
            /* 089 */ "Thermometer",
            /* 090 */ "Filter",
            /* 091 */ "Heater",
            /* 092 */ "Sum",
            /* 093 */ "Restart",
            /* 094 */ "WaterAdded",
            /* 095 */ "WaterReplaced",
            /* 096 */ "WaterRemoved",
            /* 097 */ "Clean",
            /* 098 */ "Other",
            /* 099 */ "Introduction date",
            /* 100 */ "Fish",
            /* 101 */ "Invertebrate",
            /* 102 */ "Plant",
            /* 103 */ "Coral",
            /* 104 */ "Compatibility",
            /* 105 */ "Unit",
            /* 106 */ "Water changes",
            /* 107 */ "Common",
            /* 108 */ "Tank",
            /* 109 */ "Prev",
            /* 110 */ "Next",
            /* 111 */ "Min",
            /* 112 */ "Max",
            /* 113 */ "Deviation",
            /* 114 */ "Female",
            /* 115 */ "Male",
            /* 116 */ "Hermaphrodite",
            /* 117 */ "Freshwater",
            /* 118 */ "Brackish water",
            /* 119 */ "Seawater",
            /* 120 */ "Bowl",
            /* 121 */ "Cube",
            /* 122 */ "Rectangular",
            /* 123 */ "Bowfront",
            /* 124 */ "Platefront corner",
            /* 125 */ "Bowfront corner",
            /* 126 */ "Single",
            /* 127 */ "Daily",
            /* 128 */ "Weekly",
            /* 129 */ "Monthly",
            /* 130 */ "Yearly",
            /* 131 */ "ToDo",
            /* 132 */ "Canceled",
            /* 133 */ "Snoozed",
            /* 134 */ "Late",
            /* 135 */ "Closed",
            /* 136 */ "Calculator",
            /* 137 */ "Calculate",
            /* 138 */ "Adult size",
            /* 139 */ "Life span",
            /* 140 */ "Expenses: {0:0.00}, Incomes: {1:0.00}, Balance: {2:0.00}",
            /* 141 */ "Alive",
            /* 142 */ "Dead",
            /* 143 */ "Sick",
            /* 144 */ "In Use",
            /* 145 */ "Stopped",
            /* 146 */ "Finished",
            /* 147 */ "Broken",
            /* 148 */ "State",
            /* 149 */ "Hide at startup",
            /* 150 */ "Any",
            /* 151 */ "Top",
            /* 152 */ "Top and Mid",
            /* 153 */ "Mid",
            /* 154 */ "Mid and Bottom",
            /* 155 */ "Bottom",
            /* 156 */ "Swim Level",
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

        public override string ToString()
        {
            return Name;
        }
    }
}
