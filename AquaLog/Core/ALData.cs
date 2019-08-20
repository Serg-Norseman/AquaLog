/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using AquaLog.Core.Types;

namespace AquaLog.Core
{
    /// <summary>
    /// 
    /// </summary>
    public static class ALData
    {
        /// <summary>
        /// NH3 levels (ppm)
        /// </summary>
        public static readonly List<ValueBounds> NH3Ranges = new List<ValueBounds>() {
            new ValueBounds(0.000, 0.020, Color.Green, ""),
            new ValueBounds(0.020, 0.050, Color.Yellow, "Alert"),
            new ValueBounds(0.050, 0.200, Color.Orange, "Alarm"),
            new ValueBounds(0.200, 0.500, Color.Red, "Toxic"),
            new ValueBounds(0.500, 99999, Color.Magenta, "Deadly"),
        };


        /// <summary>
        /// CO2 alert levels
        ///  0 -> 12 mg/l    red [very low for plants - adjust]
        /// 13 -> 20 mg/l    yellow [low for plants - adjust]
        /// 21 -> 30 mg/l    green [optimum for plants & fish]
        /// 31 -> 40 mg/l    yellow [high for fish - adjust]
        ///     > 40 mg/l    red [toxic for fish - adjust immediately] 
        /// </summary>
        public static readonly List<ValueBounds> CO2Ranges = new List<ValueBounds>() {
            new ValueBounds(0, 12, Color.Pink, "very_low_adjust"),
            new ValueBounds(12, 20, Color.Yellow, "low_adjust"),
            new ValueBounds(20, 30, Color.Green, ""),
            new ValueBounds(30, 40, Color.Orange, "alert_high"),
            new ValueBounds(40, 9999, Color.Red, "Toxic"),
        };


        public static double CalcNH3(double pH, double temperature, double totalNH)
        {
            return totalNH / (1 + Math.Pow(10, (0.0902 - pH + (2730 / (273.2 + temperature)))));
        }

        /// <summary>
        /// Calculate CO2 = 3 * KH * 10(7-pH) (KH in degrees)
        /// </summary>
        public static double CalcCO2(double degKH, double PH)
        {
            return 3 * degKH * Math.Pow(10, 7 - PH);
        }

        /// <summary>
        /// Calculate KH = CO2 / 3 / 10(7-PH)
        /// </summary>
        public static double CalcKH(double PH, double CO2)
        {
            return CO2 / 3 / Math.Pow(10, 7 - PH);
        }

        /// <summary>
        /// Calculate pH = 7,5 + Log(KH) - Log(ppmCO2)
        /// </summary>
        public static double CalcPH(double degKH, double CO)
        {
            return 7.5 + Math.Log10(degKH) - Math.Log10(CO);
        }
    }
}
