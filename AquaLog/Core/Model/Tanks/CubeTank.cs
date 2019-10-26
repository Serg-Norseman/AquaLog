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
    public class CubeTank : BaseTank
    {
        [Browsable(true), DisplayName("EdgeSize")]
        public double EdgeSize { get; set; }

        public CubeTank()
        {
        }

        public override TankShape GetTankShape()
        {
            return TankShape.Cube;
        }
    }
}
