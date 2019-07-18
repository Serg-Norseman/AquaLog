/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using SQLite;

namespace AquaLog.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class WaterChange : Entity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int AquariumId { get; set; }

        public DateTime ChangeDate { get; set; }
        public double Volume { get; set; }
        public string Note { get; set; }


        public WaterChange()
        {
        }
    }
}
