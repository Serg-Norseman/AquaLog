/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaLog.Core.Model.Tanks;

namespace AquaLog.GLViewer.Tanks
{
    /// <summary>
    /// 
    /// </summary>
    public class RectangularTankRenderer : TankRenderer<RectangularTank>
    {
        public RectangularTankRenderer(RectangularTank tank) : base(tank)
        {
        }

        public override void Render(bool showWater = true, bool aeration = false)
        {
            DrawRectangularTank(fTank.Length, fTank.Width, fTank.Height, fTank.GlassThickness, showWater, aeration);
        }
    }
}
