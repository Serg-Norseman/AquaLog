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
            new ValueBounds(0.020, 0.050, Color.YellowGreen, "Alert"),
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
            new ValueBounds(0, 12, Color.DeepPink, "very_low_adjust"),
            new ValueBounds(12, 20, Color.YellowGreen, "low_adjust"),
            new ValueBounds(20, 30, Color.Green, ""),
            new ValueBounds(30, 40, Color.Orange, "alert_high"),
            new ValueBounds(40, 9999, Color.Red, "Toxic"),
        };


        public static readonly List<ValueBounds> NO3Ranges = new List<ValueBounds>() {
            new ValueBounds(0, 25, Color.Green, "Safe"),
            new ValueBounds(25, 100, Color.Orange, "Warn"),
            new ValueBounds(100, 250, Color.Red, "Alarm"),
        };


        public static readonly List<ValueBounds> NO2Ranges = new List<ValueBounds>() {
            new ValueBounds(0, 1, Color.Green, "Safe"),
            new ValueBounds(1, 5, Color.Orange, "Warn"),
            new ValueBounds(5, 10, Color.Red, "Alarm"),
        };


        public static readonly List<ValueBounds> GHRanges = new List<ValueBounds>() {
            new ValueBounds(0, 4, Color.Orange, "Warn"),
            new ValueBounds(4, 16, Color.Green, "Safe"),
        };


        public static readonly List<ValueBounds> KHRanges = new List<ValueBounds>() {
            new ValueBounds(0, 3, Color.Red, "Alarm"),
            new ValueBounds(3, 10, Color.Green, "Safe"),
            new ValueBounds(10, 20, Color.Orange, "Warn"),
        };


        public static readonly List<ValueBounds> pHRanges = new List<ValueBounds>() {
            new ValueBounds(0, 6.4, Color.Orange, "Warn"),
            new ValueBounds(6.4, 8.4, Color.Green, "Safe"),
            new ValueBounds(8.4, 10, Color.Red, "Alarm"),
        };


        public static readonly List<ValueBounds> Cl2Ranges = new List<ValueBounds>() {
            new ValueBounds(0, 0.8, Color.Green, "Safe"),
            new ValueBounds(0.8, 3.0, Color.Red, "Alarm"),
        };


        public static double CalcArea(double depth, double width)
        {
            return depth * width;
        }

        public static double CalcTankVolume(double depth, double width, double height)
        {
            double ccVolume = depth * width * height; // cubic cm (cc)
            return UnitConverter.cc2l(ccVolume);
        }

        public static double CalcWaterVolume(double tankVolume)
        {
            // estimated water volume is 85% of tank volume
            return 0.85 * tankVolume;
        }

        public static double CalcNH3(double pH, double temperature, double totalNH)
        {
            return totalNH / (1 + Math.Pow(10, (0.0902 - pH + (2730 / (273.2 + temperature)))));
        }

        /// <summary>
        /// Calculate CO2
        /// </summary>
        public static double CalcCO2(double degKH, double PH)
        {
            // common variant: CO2 = 3 * KH * 10(7-pH) (KH in degrees) [1 source]
            // return 3 * degKH * Math.Pow(10, 7 - PH);

            // CO2 = 12.839 * dKH * 10^(6.37 - pH) [2 source]

            // corrected variants
            // CO2 = 15.65 * dKH * 10^(6.35-pH)
            // CO2 = 15.65 * dKH * 10^(6.37-pH)
            return 15.65 * degKH * Math.Pow(10, 6.37 - PH); // 3 source
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
