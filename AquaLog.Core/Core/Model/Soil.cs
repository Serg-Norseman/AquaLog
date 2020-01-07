/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

namespace AquaLog.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Soil : Entity
    {
        public string Name { get; set; }

        public float Density { get; set; } // kg/l

        public string Note { get; set; }

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
