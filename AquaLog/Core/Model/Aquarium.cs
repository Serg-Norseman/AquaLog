/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
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
            TankVolume = ALCore.CalcVolume(depth, width, height);
        }

        public bool IsSalt()
        {
            return (WaterType != AquariumWaterType.Freshwater);
        }

        /// <summary>
        /// The base area of an aquarium (cm2).
        /// </summary>
        public double GetBaseArea()
        {
            return ALCore.CalcArea(Width, Depth);
        }
    }
}
