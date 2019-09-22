/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaLog.Core.Types;

namespace AquaLog.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Maintenance : AquariumDetails, IEventEntity
    {
        public DateTime Timestamp { get; set; }
        public MaintenanceType Type { get; set; }
        public double Value { get; set; }
        public string Note { get; set; }

        public Maintenance()
        {
        }
    }
}
