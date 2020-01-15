/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

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
