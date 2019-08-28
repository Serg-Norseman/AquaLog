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
    public class Device : AquariumDetails
    {
        public string Name { get; set; }
        public DeviceType Type { get; set; }

        public bool Enabled { get; set; }
        public bool Digital { get; set; }

        public string Brand { get; set; }
        public double Wattage { get; set; }

        public int PointId { get; set; }

        #region Pump properties

        public int MinFlow { get; set; }
        public int MaxFlow { get; set; }

        #endregion

        public Device()
        {
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
