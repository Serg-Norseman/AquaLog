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

        [Ignore]
        public string TankProperties { get; set; }

        private ITankProps fTank;

        [Ignore]
        public ITankProps Tank
        {
            get {
                if (fTank == null) {
                    fTank = Deserialize(TankProperties);
                }
                return fTank;
            }
            set {
                fTank = value;
                TankProperties = StringSerializer.Serialize(fTank);
            }
        }

        /// <summary>
        /// The depth of an aquarium is the distance from front to back (cm).
        /// </summary>
        public double Depth { get; set; }

        /// <summary>
        /// The width of an aquarium is the distance across the front (cm).
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// The height of an aquarium is the distance from top to bottom (cm).
        /// </summary>
        public double Height { get; set; }

        public double GlassThickness { get; set; }

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

        public Aquarium(string name)
        {
            Name = name;
        }

        public Aquarium(TankShape tankShape, double volume)
        {
            TankShape = tankShape;
            TankVolume = volume;
        }

        public Aquarium(TankShape tankShape, double depth, double width, double height)
        {
            TankShape = tankShape;
            Depth = depth;
            Width = width;
            Height = height;
            TankVolume = ALData.CalcRectangularTankVolume(depth, width, height);
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
            return ALData.CalcArea(Width, Depth);
        }

        public double CalcTankVolume()
        {
            double result;

            switch (TankShape) {
                case TankShape.Unknown:
                case TankShape.Bowl:
                    result = 0.0f;
                    break;

                case TankShape.Cube:
                    result = ALData.CalcCubeTankVolume((CubeTank)Tank, GlassThickness);
                    break;

                case TankShape.Rectangular:
                    result = ALData.CalcRectangularTankVolume((RectangularTank)Tank, GlassThickness);
                    break;

                case TankShape.BowFront:
                    result = ALData.CalcBowFrontTankVolume((BowFrontTank)Tank, GlassThickness);
                    break;

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

        private ITankProps Deserialize(string str)
        {
            ITankProps result;

            switch (TankShape) {
                case TankShape.Unknown:
                case TankShape.Bowl:
                    result = StringSerializer.Deserialize<UnknownTank>(str);
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
                    result = StringSerializer.Deserialize<UnknownTank>(str);
                    break;
            }

            return result;
        }
    }
}
