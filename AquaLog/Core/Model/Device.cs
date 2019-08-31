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
    /// Electrical and/or measurement equipments.
    /// </summary>
    public class Device : AquariumDetails
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Note { get; set; }

        public DeviceType Type { get; set; }

        public bool Enabled { get; set; }
        public bool Digital { get; set; }
        public double Wattage { get; set; }
        public double WorkTime { get; set; }

        public int PointId { get; set; }

        #region Pump/Filter properties

        public int MinFlow { get; set; }
        public int MaxFlow { get; set; }

        #endregion

        #region Light properties

        // Photosynthetically Active Radiation
        public float PAR { get; set; }

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
