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

        public bool HideClosedTanks
        {
            get { return fHideClosedTanks; }
            set { fHideClosedTanks = value; }
        }


        private static ALSettings fInstance;

        public static ALSettings Instance
        {
            get {
                if (fInstance == null) fInstance = new ALSettings();
                return fInstance;
            }
        }


        private ALSettings()
        {
            fHideClosedTanks = true;
        }
    }
}
