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
    public class Expense : Entity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int ItemId { get; set; }

        [Indexed]
        public int ItemType { get; set; }

        [Indexed]
        public DateTime Date { get; set; }

        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Shop { get; set; }
        public string Note { get; set; }


        public Expense()
        {
        }
    }
}
