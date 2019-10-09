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
    public class CubeTank : ITankProps
    {
        public double EdgeSize { get; set; }

        public CubeTank()
        {
        }
    }
}
