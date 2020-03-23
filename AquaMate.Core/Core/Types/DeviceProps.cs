/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

namespace AquaMate.Core.Types
{
    public class DeviceProps : IProps
    {
        public LSID Name { get; private set; }
        public bool HasMeasurements { get; private set; }

        public DeviceProps(LSID name, bool hasMeasurements)
        {
            Name = name;
            HasMeasurements = hasMeasurements;
        }
    }
}
