/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using SQLite;

namespace AquaMate.TSDB
{
    /// <summary>
    /// The value of a point in a time series (tag).
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
