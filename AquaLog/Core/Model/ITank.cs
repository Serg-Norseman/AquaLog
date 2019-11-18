/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using AquaLog.Core.Types;

namespace AquaLog.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITank
    {
        ITank Clone();
        TankShape GetTankShape();


        /// <summary>
        /// The base area of an aquarium (cm2).
        /// </summary>
        double CalcBaseArea();

        /// <summary>
        /// Calculate the volume of a tank (litres, all sizes in cm).
        /// </summary>
        double CalcTankVolume();
    }
}
