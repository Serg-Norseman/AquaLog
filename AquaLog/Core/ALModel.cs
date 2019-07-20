/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.IO;
using AquaLog.Core.Model;
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
            fDB.CreateTable<Invertebrate>();
            fDB.CreateTable<Plant>();
            fDB.CreateTable<Species>();

            fDB.CreateTable<Light>();
            fDB.CreateTable<Pump>();

            fDB.CreateTable<Expense>();
            fDB.CreateTable<Note>();
            fDB.CreateTable<WaterChange>();
            fDB.CreateTable<History>();
            fDB.CreateTable<Maintenance>();
        }

        #region Aquarium functions

        public void AddAquarium(Aquarium obj)
        {
            fDB.Insert(obj);
        }

        public void UpdateAquarium(Aquarium obj)
        {
            fDB.Update(obj);
        }

        public void DeleteAquarium(int objId)
        {
            fDB.Delete<Aquarium>(objId);
        }

        public Aquarium GetAquarium(int objId)
        {
            return fDB.Get<Aquarium>(objId);
        }

        public IEnumerable<Aquarium> QueryAquariums()
        {
            return fDB.Query<Aquarium>("select * from Aquarium");
        }

        #endregion

        #region Fish functions

        public void AddFish(Fish obj)
        {
            fDB.Insert(obj);
        }

        public void UpdateFish(Fish obj)
        {
            fDB.Update(obj);
        }

        public void DeleteFish(int objId)
        {
            fDB.Delete<Fish>(objId);
        }

        public Fish GetFish(int objId)
        {
            return fDB.Get<Fish>(objId);
        }

        public IEnumerable<Fish> QueryFishes()
        {
            return fDB.Query<Fish>("select * from Fish");
        }

        public IEnumerable<Fish> QueryFishes(Aquarium aquarium)
        {
            return fDB.Query<Fish>("select * from Fish where AquariumId = ?", aquarium.Id);
        }

        #endregion

        #region Invertebrate functions

        public void AddInvertebrate(Invertebrate obj)
        {
            fDB.Insert(obj);
        }

        public void UpdateInvertebrate(Invertebrate obj)
        {
            fDB.Update(obj);
        }

        public void DeleteInvertebrate(int objId)
        {
            fDB.Delete<Invertebrate>(objId);
        }

        public Invertebrate GetInvertebrate(int objId)
        {
            return fDB.Get<Invertebrate>(objId);
        }

        public IEnumerable<Invertebrate> QueryInvertebrates(Aquarium aquarium)
        {
            return fDB.Query<Invertebrate>("select * from Invertebrate where AquariumId = ?", aquarium.Id);
        }

        #endregion

        #region Plant functions

        public void AddPlant(Plant obj)
        {
            fDB.Insert(obj);
        }

        public void UpdatePlant(Plant obj)
        {
            fDB.Update(obj);
        }

        public void DeletePlant(int objId)
        {
            fDB.Delete<Plant>(objId);
        }

        public Plant GetPlant(int objId)
        {
            return fDB.Get<Plant>(objId);
        }

        public IEnumerable<Plant> QueryPlants(Aquarium aquarium)
        {
            return fDB.Query<Plant>("select * from Plant where AquariumId = ?", aquarium.Id);
        }

        #endregion

        #region Note functions

        public IEnumerable<Note> QueryNotes(Aquarium aquarium)
        {
            return fDB.Query<Note>("select * from Note where AquariumId = ?", aquarium.Id);
        }

        #endregion

        #region Expense functions

        public IEnumerable<Expense> QueryExpenses()
        {
            return fDB.Query<Expense>("select * from Expense");
        }

        public float GetTotalExpense()
        {
            // "select total(Price) as total_expense from Expenses"
            // "select distinct Type as element from Expenses"
            // "select distinct Shop as element from Expenses"
            return 0.0f;
        }

        #endregion
    }
}
