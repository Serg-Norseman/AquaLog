/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

namespace AquaLog.Core.Types
{
    public sealed class MaintenanceProps : IProps
    {
        public LSID Name { get; private set; }
        public int WaterChangeFactor { get; private set; }

        public MaintenanceProps(LSID name, int waterChangeFactor)
        {
            Name = name;
            WaterChangeFactor = waterChangeFactor;
        }
    }
}
