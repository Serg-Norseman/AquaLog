/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.IO;
using SQLite;

namespace AquaLog.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class ALModel
    {
        private readonly SQLiteConnection fDB;

        public ALModel()
        {
            var databasePath = Path.Combine(ALCore.GetAppDataPath(), "ALData.db");
            fDB = new SQLiteConnection(databasePath);

            fDB.CreateTable<Aquarium>();
            fDB.CreateTable<Fish>();
            fDB.CreateTable<Note>();
            fDB.CreateTable<Plant>();
        }

        public void AddAquarium(string name)
        {
            var aqm = new Aquarium(name);
            fDB.Insert(aqm);
        }

        public void DeleteAquarium(int id)
        {
            fDB.Delete<Aquarium>(id);
        }

        public IEnumerable<Aquarium> QueryAquariums()
        {
            return fDB.Query<Aquarium>("select * from Aquarium");
        }

        public Aquarium GetAquarium(int aqmId)
        {
            return fDB.Get<Aquarium>(aqmId);
        }

        public IEnumerable<Fish> QueryFishes(Aquarium aquarium)
        {
            return fDB.Query<Fish>("select * from Fish where AquariumId = ?", aquarium.Id);
        }
    }
}
