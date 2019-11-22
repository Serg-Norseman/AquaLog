/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaLog.Core.Types;

namespace AquaLog.Core.Types
{
    public sealed class MeasurementUnitProps
    {
        public LSID Name;
        public MeasurementType MeasurementType;

        public string StrName;
        public string StrAbbreviation;

        public MeasurementUnitProps(LSID name, MeasurementType measurementType)
        {
            Name = name;
            MeasurementType = measurementType;
        }
    }
}
