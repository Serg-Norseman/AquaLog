/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using AquaMate.Core.Types;

namespace AquaMate.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Soil : Entity
    {
        public string Name { get; set; }

        public float Density { get; set; } // kg/l

        public string Note { get; set; }


        public override EntityType EntityType
        {
            get {
                return EntityType.Soil;
            }
        }


        public Soil()
        {
        }

        public Soil(string name)
        {
            Name = name;
        }

        public Soil(string name, float density)
        {
            Name = name;
            Density = density;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
