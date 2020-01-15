/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaLog.Core.Types;
using AquaLog.Logging;
using BSLib;

namespace AquaLog.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class ALSettings
    {
        private readonly ILogger fLogger;

        private bool fHideClosedTanks;
        private bool fExitOnClose;
        private int fInterfaceLang;
        private bool fHideAtStartup;
        private MeasurementUnit fLengthUoM;
        private MeasurementUnit fVolumeUoM;
        private MeasurementUnit fMassUoM;
        private MeasurementUnit fTemperatureUoM;


        public bool HideClosedTanks
        {
            get { return fHideClosedTanks; }
            set { fHideClosedTanks = value; }
        }

        public bool ExitOnClose
        {
            get { return fExitOnClose; }
            set { fExitOnClose = value; }
        }

        public int CurrentLocale
        {
            get { return fInterfaceLang; }
            set { fInterfaceLang = value; }
        }

        public bool HideAtStartup
        {
            get { return fHideAtStartup; }
            set { fHideAtStartup = value; }
        }

        public MeasurementUnit LengthUoM
        {
            get { return fLengthUoM; }
            set { fLengthUoM = value; }
        }

        public MeasurementUnit VolumeUoM
        {
            get { return fVolumeUoM; }
            set { fVolumeUoM = value; }
        }

        public MeasurementUnit MassUoM
        {
            get { return fMassUoM; }
            set { fMassUoM = value; }
        }

        public MeasurementUnit TemperatureUoM
        {
            get { return fTemperatureUoM; }
            set { fTemperatureUoM = value; }
        }


        #region Instance

        private static ALSettings fInstance;

        public static ALSettings Instance
        {
            get {
                if (fInstance == null) fInstance = new ALSettings();
                return fInstance;
            }
        }

        #endregion


        private ALSettings()
        {
            fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "ALSettings");

            fHideClosedTanks = true;
            fExitOnClose = true;
            fInterfaceLang = Localizer.LS_DEF_CODE;
            fHideAtStartup = false;
        }

        public void LoadFromFile(IniFile ini)
        {
            if (ini == null)
                throw new ArgumentNullException("ini");

            fHideClosedTanks = ini.ReadBool("Common", "HideClosedTanks", true);
            fExitOnClose = ini.ReadBool("Common", "ExitOnClose", true);
            fInterfaceLang = ini.ReadInteger("Common", "InterfaceLang", 0);
            fHideAtStartup = ini.ReadBool("Common", "HideAtStartup", false);

            fLengthUoM = EnumHelper.Parse<MeasurementUnit>(ini.ReadString("Data", "LengthUoM", "Centimeter"), true, MeasurementUnit.Centimeter);
            fVolumeUoM = EnumHelper.Parse<MeasurementUnit>(ini.ReadString("Data", "VolumeUoM", "Litre"), true, MeasurementUnit.Litre);
            fMassUoM = EnumHelper.Parse<MeasurementUnit>(ini.ReadString("Data", "MassUoM", "Kilogram"), true, MeasurementUnit.Kilogram);
            fTemperatureUoM = EnumHelper.Parse<MeasurementUnit>(ini.ReadString("Data", "TemperatureUoM", "DegreeCelsius"), true, MeasurementUnit.DegreeCelsius);
        }

        public void LoadFromFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");

            try {
                IniFile ini = new IniFile(fileName);
                try {
                    LoadFromFile(ini);
                } finally {
                    ini.Dispose();
                }
            } catch (Exception ex) {
                fLogger.WriteError("ALSettings.LoadFromFile(): " + ex.Message);
            }
        }


        public void SaveToFile(IniFile ini)
        {
            if (ini == null)
                throw new ArgumentNullException("ini");

            ini.WriteBool("Common", "HideClosedTanks", fHideClosedTanks);
            ini.WriteBool("Common", "ExitOnClose", fExitOnClose);
            ini.WriteInteger("Common", "InterfaceLang", fInterfaceLang);
            ini.WriteBool("Common", "HideAtStartup", fHideAtStartup);

            ini.WriteString("Data", "LengthUoM", fLengthUoM.ToString());
            ini.WriteString("Data", "VolumeUoM", fVolumeUoM.ToString());
            ini.WriteString("Data", "MassUoM", fMassUoM.ToString());
            ini.WriteString("Data", "TemperatureUoM", fTemperatureUoM.ToString());
        }

        public void SaveToFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");

            try {
                IniFile ini = new IniFile(fileName);
                try {
                    SaveToFile(ini);
                } finally {
                    ini.Dispose();
                }
            } catch (Exception ex) {
                fLogger.WriteError("ALSettings.SaveToFile(): " + ex.Message);
            }
        }
    }
}
