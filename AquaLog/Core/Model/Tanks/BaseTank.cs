/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
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
        public double GlassThickness { get; set; }

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
    }
}
