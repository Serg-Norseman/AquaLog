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
    public class Measure
    {
        [Indexed("IDX_Point", 1)]
        public int AquariumId { get; set; }

        [Indexed("IDX_Point", 2)]
        public DateTime Timestamp { get; set; }

        [Indexed("IDX_Point", 3)]
        public MeasurementType Type { get; set; }

        public double Value { get; set; }


        public Measure()
        {
        }
    }
}
