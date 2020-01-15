/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
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
    public class Snapshot : Entity, IEventEntity
    {
        [Indexed]
        public int ItemId { get; set; }

        [Indexed]
        public ItemType ItemType { get; set; }

        public DateTime Timestamp { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }

        public Snapshot()
        {
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
