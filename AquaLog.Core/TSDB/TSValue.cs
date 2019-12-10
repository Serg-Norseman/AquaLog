/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using SQLite;

namespace AquaLog.TSDB
{
    /// <summary>
    /// 
    /// </summary>
    public class TSValue
    {
        [Unique]
        public DateTime Timestamp { get; set; }

        public double Value { get; set; }


        public TSValue()
        {
        }

        public TSValue(DateTime timestamp, double value)
        {
            Timestamp = timestamp;
            Value = value;
        }
    }
}
