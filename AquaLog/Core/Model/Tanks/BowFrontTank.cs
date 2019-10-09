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
    public class BowFrontTank : RectangularTank
    {
        /// <summary>
        /// The centre depth of an aquarium is the distance from front to back in the center (cm).
        /// </summary>
        public double CentreDepth { get; set; }

        public BowFrontTank()
        {
        }
    }
}
