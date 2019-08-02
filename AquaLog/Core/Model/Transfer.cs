/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaLog.Core.Types;
using SQLite;

namespace AquaLog.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Transfer : Entity
    {
        [Indexed]
        public int ItemId { get; set; }

        [Indexed]
        public ItemType ItemType { get; set; }

        [Indexed]
        public DateTime Date { get; set; }

        public TransferType Type { get; set; }
        public string Cause { get; set; }

        // Aquariums
        public int SourceId { get; set; }
        public int TargetId { get; set; }

        public int Quantity { get; set; }

        #region Expenses and Revenues

        public float UnitPrice { get; set; }
        public string Shop { get; set; }

        #endregion


        public Transfer()
        {
        }
    }
}
