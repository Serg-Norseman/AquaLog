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
        public double CalcBaseArea()
        {
            double result = Tank.CalcBaseArea();
            return result;
        }

        public double CalcTankVolume()
        {
            return CalcTankVolume(TankShape);
        }

        public double CalcTankVolume(TankShape tankShape)
        {
            ITank tank = GetTank(tankShape, TankProperties);
            double result = tank.CalcTankVolume();
            return result;
        }

        public double CalcWaterHeight(double waterVolume)
        {
            return CalcWaterHeight(TankShape, waterVolume);
        }

        public double CalcWaterHeight(TankShape tankShape, double waterVolume)
        {
            double result;

            ITank tank = GetTank(tankShape, TankProperties);
            double baseArea = tank.CalcBaseArea();

            switch (tankShape) {
                case TankShape.Unknown:
                case TankShape.Bowl:
                    result = 0.0f;
                    break;

                default:
                    result = UnitConverter.l2cc(waterVolume) / baseArea;
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
