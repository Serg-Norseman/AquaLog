/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using SQLite;

namespace AquaLog.Core
{
    public enum TankShape
    {
        Unknown,
        Bowl,
        Cube,
        Rectangular,
        BowFront,
        BevelledFront,
        PlateFrontCorner,
        BowFrontCorner,
    }

    public enum AquariumType
    {
        Coldwater,
        Marine,
        Tropical,
    }

    /// <summary>
    /// 
    /// </summary>
    public class Aquarium
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public TankShape TankShape { get; set; }

        [MaxLength(140)]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsSalt { get; set; }

        //public List<Note> Notes { get; set; }
        //public List<Fish> Fishes { get; set; }
        //public List<Plant> Plants { get; set; }

        public DateTime StartDate { get; set; }

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
        public double Volume { get; set; }

        /// <summary>
        /// The base area of an aquarium (cm2).
        /// </summary>
        [Ignore]
        public double BaseArea
        {
            get {
                return ALCore.CalcArea(Width, Depth);
            }
        }


        public Aquarium()
        {
        }

        public Aquarium(string name)
        {
            Name = name;
        }

        public Aquarium(TankShape tankShape, double volume, bool isSalt)
        {
            TankShape = tankShape;
            Volume = volume;
            IsSalt = isSalt;
        }

        public Aquarium(TankShape tankShape, double depth, double width, double height, bool isSalt)
        {
            TankShape = tankShape;
            Depth = depth;
            Width = width;
            Height = height;
            Volume = ALCore.CalcVolume(depth, width, height);
            IsSalt = isSalt;
        }
    }
}
