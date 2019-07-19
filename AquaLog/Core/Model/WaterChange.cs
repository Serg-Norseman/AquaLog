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
    public class WaterChange : AquariumDetails
    {
        public DateTime ChangeDate { get; set; }
        public double Volume { get; set; }
        public string Note { get; set; }


        public WaterChange()
        {
        }
    }
}
