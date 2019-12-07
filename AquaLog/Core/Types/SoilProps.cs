/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

namespace AquaLog.Core.Types
{
    public sealed class SoilProps
    {
        public LSID Name;
        public float Density; // kg/l

        public SoilProps(LSID name, float density)
        {
            Name = name;
            Density = density;
        }
    }
}
