/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;

namespace AquaLog.Core.Model.Tanks
{
    /// <summary>
    /// 
    /// </summary>
    public class RectangularTank : ITankProps
    {
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

        public RectangularTank()
        {
        }
    }
}
