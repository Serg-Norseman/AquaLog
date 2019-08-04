/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.IO;
using AquaLog.Core;
using SQLite;

namespace AquaLog.TSDB
{
    /// <summary>
    /// 
    /// </summary>
    public class TSDatabase
    {
        private readonly SQLiteConnection fDB;
        private Dictionary<int, SDCompression> fCompressionCache;

        public TSDatabase()
        {
            var databasePath = Path.Combine(ALCore.GetAppDataPath(), "ALTSDB.db");
            fDB = new SQLiteConnection(databasePath);

            fDB.CreateTable<TSPoint>();

            fCompressionCache = new Dictionary<int, SDCompression>();
        }

        public void AddPoint(TSPoint point)
        {
            fDB.Insert(point);

            string tableName = point.GetDataTableName();

            string tblExpr = string.Format("create table {0}(\"Timestamp\" datetime, \"Value\" float)", tableName);
            fDB.Execute(tblExpr);

            string idxExpr = string.Format("create unique index \"{0}_Timestamp\" on \"{1}\"(\"Timestamp\")", tableName, tableName);
            fDB.Execute(idxExpr);
        }

        public void UpdatePoint(TSPoint point)
        {
            fDB.Update(point);
        }

        public void DeletePoint(TSPoint point)
        {
            string tableName = point.GetDataTableName();

            string idxExpr = string.Format("drop index \"{0}_Timestamp\"", tableName);
            fDB.Execute(idxExpr);

            string tblExpr = string.Format("drop table {0}", tableName);
            fDB.Execute(tblExpr);

            fDB.Delete(point);
        }

        public IList<TSPoint> GetPoints(string ptFilter = "*")
        {
            return fDB.Query<TSPoint>("select * from TSPoint");
        }

        public void InsertValue(int pointId, DateTime timestamp, double value)
        {
            TSPoint point = fDB.Get<TSPoint>(pointId);
            string tableName = point.GetDataTableName();
            InsertValue(tableName, timestamp, value);
        }

        private void InsertValue(string tableName, DateTime timestamp, double value)
        {
            fDB.Execute(string.Format("insert into {0}(Timestamp, Value) values('{1}', {2})", tableName, timestamp, value));
        }

        public void UpdateValue(int pointId, DateTime timestamp, double value)
        {
            TSPoint point = fDB.Get<TSPoint>(pointId);
            string tableName = point.GetDataTableName();

            fDB.Execute(string.Format("update {0} set Value = {1} where Timestamp = '{2}'", tableName, value, timestamp));
        }

        public void DeleteValue(int pointId, DateTime timestamp)
        {
            TSPoint point = fDB.Get<TSPoint>(pointId);
            string tableName = point.GetDataTableName();

            fDB.Execute(string.Format("delete from {0} where Timestamp = '{1}'", tableName, timestamp));
        }

        public IEnumerable<TSValue> QueryValues(int pointId, DateTime begTime, DateTime endTime)
        {
            TSPoint point = fDB.Get<TSPoint>(pointId);
            string tableName = point.GetDataTableName();

            // where Timestamp between '{1}' and '{2}', begTime, endTime
            string query = string.Format("select * from {0}", tableName);
            return fDB.Query<TSValue>(query);
        }

        public void ReceivePointValue(int pointId, DateTime timestamp, double value)
        {
            TSPoint point = fDB.Get<TSPoint>(pointId);

            SDCompression compression;
            if (!fCompressionCache.TryGetValue(pointId, out compression)) {
                compression = new SDCompression(point.Deviation, 60 * 10); // default: 60sec * 10min
                fCompressionCache.Add(pointId, compression);
            }

            if (compression.ReceivePoint(ref timestamp, ref value)) {
                string tableName = point.GetDataTableName();
                InsertValue(tableName, timestamp, value);
            }
        }
    }
}
