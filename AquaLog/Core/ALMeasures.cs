/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.IO;
using SQLite;

namespace AquaLog.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class ALMeasures
    {
        private readonly SQLiteConnection fDB;

        public ALMeasures()
        {
            var databasePath = Path.Combine(ALCore.GetAppDataPath(), "ALMeasures.db");
            fDB = new SQLiteConnection(databasePath);

            //fDB.CreateTable<>();
        }
    }
}
