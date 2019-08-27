/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;

namespace AquaLog.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class ALSettings
    {
        private bool fHideClosedTanks;
        private bool fExitOnClose;
        private int fCurrentLocale;


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
            get { return fCurrentLocale; }
            set { fCurrentLocale = value; }
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
            fHideClosedTanks = true;
            fExitOnClose = true;
            fCurrentLocale = Localizer.LS_DEF_CODE;
        }
    }
}
