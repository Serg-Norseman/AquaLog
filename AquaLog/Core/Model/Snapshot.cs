/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;

namespace AquaLog.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Snapshot : Entity, IEventEntity
    {
        public DateTime Timestamp { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }

        public Snapshot()
        {
        }
    }
}
