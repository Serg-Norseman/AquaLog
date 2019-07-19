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
        }

        #region Aquarium functions

        public void AddAquarium(Aquarium aquarium)
        {
            fDB.Insert(aquarium);
        }

        public void UpdateAquarium(Aquarium aquarium)
        {
            fDB.Update(aquarium);
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

        #endregion

        #region Fish functions

        public IEnumerable<Fish> QueryFishes(Aquarium aquarium)
        {
            return fDB.Query<Fish>("select * from Fish where AquariumId = ?", aquarium.Id);
        }

        #endregion

        #region Invertebrate functions

        public IEnumerable<Invertebrate> QueryInvertebrates(Aquarium aquarium)
        {
            return fDB.Query<Invertebrate>("select * from Invertebrate where AquariumId = ?", aquarium.Id);
        }

        #endregion

        #region Plant functions

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
