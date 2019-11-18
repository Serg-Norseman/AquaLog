/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.ComponentModel;
using AquaLog.Core.Types;

namespace AquaLog.Core.Model.Tanks
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseTank : ITank
    {
        [Browsable(true), DisplayName("GlassThickness")]
        public float GlassThickness { get; set; }

        public BaseTank()
        {
        }

        public ITank Clone()
        {
            return (ITank)this.MemberwiseClone();
        }

        public virtual TankShape GetTankShape()
        {
            return TankShape.Unknown;
        }

        /// <summary>
        /// The base area of an aquarium (cm2).
        /// </summary>
        public virtual double CalcBaseArea()
        {
            return 0.0d;
        }

        /// <summary>
        /// Calculate the volume of a tank (litres, all sizes in cm).
        /// </summary>
        public virtual double CalcTankVolume()
        {
            return 0.0d;
        }
    }
}
