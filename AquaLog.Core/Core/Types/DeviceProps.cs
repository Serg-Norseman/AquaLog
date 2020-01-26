﻿/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

namespace AquaLog.Core.Types
{
    public class DeviceProps
    {
        public readonly LSID Text;
        public readonly bool HasMeasurements;

        public DeviceProps(LSID text, bool hasMeasurements)
        {
            Text = text;
            HasMeasurements = hasMeasurements;
        }
    }
}