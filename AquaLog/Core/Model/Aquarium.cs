/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaLog.Core.Model.Tanks;
using AquaLog.Core.Types;
using SQLite;

namespace AquaLog.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Aquarium : Entity
    {
        [MaxLength(140)]
        public string Name { get; set; }

        public string Description { get; set; }

        public AquariumWaterType WaterType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime StopDate { get; set; }

        public TankShape TankShape { get; set; }

        public string TankProperties { get; set; }

        private ITank fTank;

        [Ignore]
        public ITank Tank
        {
            get {
                if (fTank == null) {
                    fTank = GetTank(TankShape, TankProperties);
                }
                return fTank;
            }
            set {
                fTank = value;
                TankProperties = StringSerializer.Serialize(fTank);
            }
        }

        /// <summary>
        /// The volume of an aquarium (litres).
        /// </summary>
        public double TankVolume { get; set; }

        /// <summary>
        /// The volume of water (litres).
        /// </summary>
        public double WaterVolume { get; set; }


        public Aquarium()
        {
        }

        public bool IsSalt()
        {
            return (WaterType != AquariumWaterType.FreshWater);
        }

        public bool IsInactive()
        {
            return !StopDate.Equals(ALCore.ZeroDate);
        }

        /// <summary>
        /// The base area of an aquarium (cm2).
        /// </summary>
        public double GetBaseArea()
        {
            double result = 0.0d;

            switch (TankShape) {
                case TankShape.Unknown:
                case TankShape.Bowl:
                    break;

                case TankShape.Cube:
                    break;

                case TankShape.Rectangular:
                    var rectTank = (RectangularTank)Tank;
                    result = ALData.CalcArea(rectTank.Width, rectTank.Depth);
                    break;

                case TankShape.BowFront:
                    break;

                case TankShape.PlateFrontCorner:
                case TankShape.BowFrontCorner:
                default:
                    break;
            }

            return result;
        }

        public double CalcTankVolume()
        {
            return CalcTankVolume(TankShape);
        }

        public double CalcTankVolume(TankShape tankShape)
        {
            double result;

            switch (tankShape) {
                case TankShape.Unknown:
                case TankShape.Bowl:
                    result = 0.0f;
                    break;

                case TankShape.Cube:
                    result = ALData.CalcCubeTankVolume((CubeTank)Tank);
                    break;

                case TankShape.Rectangular:
                    result = ALData.CalcRectangularTankVolume((RectangularTank)Tank);
                    break;

                case TankShape.BowFront:
                    result = ALData.CalcBowFrontTankVolume((BowFrontTank)Tank);
                    break;

                case TankShape.PlateFrontCorner:
                case TankShape.BowFrontCorner:
                default:
                    result = 0.0f;
                    break;
            }

            return result;
        }

        public double CalcWaterHeight(double waterVolume)
        {
            return CalcWaterHeight(TankShape, waterVolume);
        }

        public double CalcWaterHeight(TankShape tankShape, double waterVolume)
        {
            double result;

            switch (tankShape) {
                case TankShape.Unknown:
                case TankShape.Bowl:
                case TankShape.Cube:
                    result = 0.0f;
                    break;

                case TankShape.Rectangular:
                    var rectTank = (RectangularTank)Tank;
                    result = ALData.CalcWaterHeight(rectTank.Depth, rectTank.Width, waterVolume, rectTank.GlassThickness);
                    break;

                case TankShape.BowFront:
                case TankShape.PlateFrontCorner:
                case TankShape.BowFrontCorner:
                default:
                    result = 0.0f;
                    break;
            }

            return result;
        }

        public override string ToString()
        {
            return Name;
        }

        public ITank GetTank(TankShape tankShape, string str)
        {
            ITank result;

            switch (tankShape) {
                case TankShape.Unknown:
                case TankShape.Bowl:
                    result = StringSerializer.Deserialize<BaseTank>(str);
                    break;

                case TankShape.Cube:
                    result = StringSerializer.Deserialize<CubeTank>(str);
                    break;

                case TankShape.Rectangular:
                    result = StringSerializer.Deserialize<RectangularTank>(str);
                    break;

                case TankShape.BowFront:
                    result = StringSerializer.Deserialize<BowFrontTank>(str);
                    break;

                case TankShape.PlateFrontCorner:
                case TankShape.BowFrontCorner:
                default:
                    result = StringSerializer.Deserialize<BaseTank>(str);
                    break;
            }

            return result;
        }
    }
}
