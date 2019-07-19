/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using SQLite;

namespace AquaLog.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Expense : Entity
    {
        [Indexed]
        public int ItemId { get; set; }

        [Indexed]
        public int ItemType { get; set; }

        [Indexed]
        public DateTime Date { get; set; }

        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public string Shop { get; set; }
        public string Note { get; set; }


        public Expense()
        {
        }
    }
}
