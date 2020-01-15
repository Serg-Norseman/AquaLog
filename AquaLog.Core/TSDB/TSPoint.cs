/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using AquaLog.Core.Types;
using BSLib;
using SQLite;

namespace AquaLog.TSDB
{
    /// <summary>
    /// 
    /// </summary>
    public class TSPoint
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique]
        public string Name { get; set; }

        public MeasurementType Type { get; set; }
        public string MeasureUnit { get; set; }

        #region Range

        public double Min { get; set; }
        public double Max { get; set; }
        public double Deviation { get; set; }

        #endregion

        internal string GetDataTableName()
        {
            string tableName = "PD" + ConvertHelper.AdjustNumber(Id, 6, '0');
            return tableName;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
