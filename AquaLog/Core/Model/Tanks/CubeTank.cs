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
        public float EdgeSize { get; set; }


        public CubeTank()
        {
        }

        public CubeTank(float edgeSize, float glassThickness = 0.0f)
        {
            EdgeSize = edgeSize;
            GlassThickness = glassThickness;
        }

        public override TankShape GetTankShape()
        {
            return TankShape.Cube;
        }

        /// <summary>
        /// The base area of an aquarium (cm2).
        /// </summary>
        public override double CalcBaseArea()
        {
            double glassThickness = GlassThickness;
            double edgeSize = EdgeSize;

            if (glassThickness > 0.0d) {
                double thicknessX2 = glassThickness * 2.0d;

                edgeSize -= thicknessX2; // two sides
            }

            return edgeSize * edgeSize;
        }

        /// <summary>
        /// Calculate the volume of a tank (litres, all sizes in cm).
        /// </summary>
        public override double CalcTankVolume()
        {
            double glassThickness = GlassThickness;
            double height = EdgeSize;

            if (glassThickness > 0.0d) {
                height -= glassThickness; // only bottom
            }

            double baseArea = CalcBaseArea();
            double ccVolume = baseArea * height; // cubic cm (cc)
            return UnitConverter.cc2l(ccVolume);
        }
    }
}
