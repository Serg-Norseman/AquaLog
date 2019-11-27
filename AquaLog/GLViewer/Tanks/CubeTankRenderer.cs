/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaLog.Core.Model.Tanks;

namespace AquaLog.GLViewer.Tanks
{
    /// <summary>
    /// 
    /// </summary>
    public class CubeTankRenderer : TankRenderer<CubeTank>
    {
        public CubeTankRenderer(CubeTank tank) : base(tank)
        {
        }

        public override void Render(bool showWater = true, bool aeration = false)
        {
            DrawRectangularTank(fTank.EdgeSize, fTank.EdgeSize, fTank.EdgeSize, fTank.GlassThickness, showWater, aeration);
        }
    }
}
