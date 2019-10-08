/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using AquaLog.Core.Types;
using BSLib;

namespace AquaLog.Core
{
    /// <summary>
    /// 
    /// </summary>
    public static class ALData
    {
        public static int[] WaterChangeFactors = new int[] {
             0, // Restart
            +1, // WaterAdded
             0, // WaterReplaced
            -1, // WaterRemoved
             0, // Clean
             0, // Other
        };

        public static readonly ItemProps[] ItemTypes = new ItemProps[] {
            new ItemProps(LSID.None,
                          EnumSet<ItemState>.Create()),

            new ItemProps(LSID.Aquarium,
                          EnumSet<ItemState>.Create()),

            new ItemProps(LSID.Fish,
                          EnumSet<ItemState>.Create(ItemState.Alive, ItemState.Dead, ItemState.Sick)),
            new ItemProps(LSID.Invertebrate,
                          EnumSet<ItemState>.Create(ItemState.Alive, ItemState.Dead, ItemState.Sick)),
            new ItemProps(LSID.Plant,
                          EnumSet<ItemState>.Create(ItemState.Alive, ItemState.Dead, ItemState.Sick)),
            new ItemProps(LSID.Coral,
                          EnumSet<ItemState>.Create(ItemState.Alive, ItemState.Dead, ItemState.Sick)),

            new ItemProps(LSID.Nutrition,
                          EnumSet<ItemState>.Create(ItemState.InUse, ItemState.Finished)),

            new ItemProps(LSID.Device,
                          EnumSet<ItemState>.Create(ItemState.InUse, ItemState.Stopped, ItemState.Broken)),

            new ItemProps(LSID.Additive,
                          EnumSet<ItemState>.Create(ItemState.InUse, ItemState.Finished)),
            new ItemProps(LSID.Chemistry,
                          EnumSet<ItemState>.Create(ItemState.InUse, ItemState.Finished)),

            new ItemProps(LSID.Equipment,
                          EnumSet<ItemState>.Create(ItemState.InUse, ItemState.Broken)),
            new ItemProps(LSID.Maintenance,
                          EnumSet<ItemState>.Create(ItemState.InUse, ItemState.Broken)),
            new ItemProps(LSID.Furniture,
                          EnumSet<ItemState>.Create(ItemState.InUse, ItemState.Broken)),
            new ItemProps(LSID.Decoration,
                          EnumSet<ItemState>.Create(ItemState.InUse, ItemState.Broken)),
        };

        public static readonly LSID[] ItemStates = new LSID[] {
            LSID.None,
            LSID.Alive,
            LSID.Dead,
            LSID.Sick,
            LSID.InUse,
            LSID.Stopped,
            LSID.Finished,
            LSID.Broken,
        };

        public static readonly DeviceProps[] DeviceProps = new DeviceProps[] {
            new DeviceProps(LSID.Light, false), // Light
            new DeviceProps(LSID.Pump, false), // Pump
            new DeviceProps(LSID.Thermometer, true), // Thermometer
            new DeviceProps(LSID.Filter, false), // Filter
            new DeviceProps(LSID.Heater, false), // Heater
        };

        public static readonly LSID[] InventoryTypes = new LSID[] {
            LSID.Additive,
            LSID.Chemistry,
            LSID.Equipment,
            LSID.Maintenance,
            LSID.Furniture,
            LSID.Decoration,
        };

        public static readonly LSID[] TransferTypes = new LSID[] {
            LSID.Relocation,
            LSID.Purchase,
            LSID.Sale,
            LSID.Birth,
            LSID.Death
        };

        public static readonly LSID[] MaintenanceTypes = new LSID[] {
            LSID.Restart,
            LSID.WaterAdded,
            LSID.WaterReplaced,
            LSID.WaterRemoved,
            LSID.Clean,
            LSID.Other,
        };

        public static readonly LSID[] SpeciesTypes = new LSID[] {
            LSID.Fish,
            LSID.Invertebrate,
            LSID.Plant,
            LSID.Coral,
        };

        public static readonly LSID[] SwimLevels = new LSID[] {
            LSID.SL_Any,
            LSID.SL_Top,
            LSID.SL_Top_and_Mid,
            LSID.SL_Mid,
            LSID.SL_Mid_and_Bottom,
            LSID.SL_Bottom,
        };

        public static readonly LSID[] SexNames = new LSID[] {
            LSID.None,
            LSID.Female,
            LSID.Male,
            LSID.Hermaphrodite,
        };

        public static readonly LSID[] WaterTypes = new LSID[] {
            LSID.FreshWater,
            LSID.BrackishWater,
            LSID.SeaWater,
        };

        public static readonly LSID[] TankShapes = new LSID[] {
            LSID.None,
            LSID.Bowl,
            LSID.Cube,
            LSID.Rectangular,
            LSID.BowFront,
            LSID.PlateFrontCorner,
            LSID.BowFrontCorner,
        };

        public static readonly LSID[] ScheduleTypes = new LSID[] {
            LSID.Single,
            LSID.Daily,
            LSID.Weekly,
            LSID.Monthly,
            LSID.Yearly,
        };

        public static readonly LSID[] TaskStatuses = new LSID[] {
            LSID.ToDo,
            LSID.Canceled,
            LSID.Snoozed,
            LSID.Late,
            LSID.Closed,
        };

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

        /// <summary>
        /// Calculate the volume of a cube tank (all sizes in cm).
        /// </summary>
        public static double CalcCubeTankVolume(double size, double glassThickness = 0.0d)
        {
            var depth = size;
            var width = size;
            var height = size;

            return CalcRectangularTankVolume(depth, width, height, glassThickness);
        }

        /// <summary>
        /// Calculate the volume of a rectangular tank (all sizes in cm).
        /// </summary>
        public static double CalcRectangularTankVolume(double depth, double width, double height, double glassThickness = 0.0d)
        {
            if (glassThickness > 0.0d) {
                double glassThicknessS2 = glassThickness * 2.0d;

                depth -= glassThicknessS2; // two sides
                width -= glassThicknessS2; // two sides
                height -= glassThickness; // only bottom
            }

            double ccVolume = depth * width * height; // cubic cm (cc)
            return UnitConverter.cc2l(ccVolume);
        }

        /// <summary>
        /// Estimated standard water volume (85% of tank volume).
        /// </summary>
        public static double CalcWaterVolume(double tankVolume)
        {
            // estimated water volume is 85% of tank volume
            return tankVolume * 0.85d;
        }

        public static double CalcWaterHeight(double depth, double width, double waterVolume, double glassThickness = 0.0d)
        {
            if (glassThickness > 0.0d) {
                double glassThicknessS2 = glassThickness * 2.0d;

                depth -= glassThicknessS2; // two sides
                width -= glassThicknessS2; // two sides
            }

            return UnitConverter.l2cc(waterVolume) / (depth * width);
        }

        public static double CalcNH3(double pH, double temperature, double totalNH)
        {
            // https://rdrr.io/cran/AmmoniaConcentration/man/ammonia.html
            // f = 1 / (1 + 10^(0.09018 - pH + (2727.92 / T)))

            return totalNH / (1 + Math.Pow(10, (0.0901821 - pH + (2729.92 / (273.15 + temperature)))));
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

        /// <summary>
        /// (all ppm)
        /// </summary>
        public static double CalcTDS(double GH, double KH, double nitrate, double nitrite, double chlorine, double other)
        {
            return (GH + KH + nitrate + nitrite + chlorine + other);
        }

        /// <summary>
        /// Treating nitrite calculator
        /// </summary>
        /// <param name="volume">Tank volume in litres</param>
        /// <param name="nitrite">Nitrite level (NO2, mg/l)</param>
        /// <returns>grams of salt to aquarium</returns>
        public static double CalcSalt(double volume, double nitrite)
        {
            return (volume * nitrite * 0.0075);
        }
    }
}
