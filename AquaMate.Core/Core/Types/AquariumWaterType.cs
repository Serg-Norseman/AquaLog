﻿/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

namespace AquaMate.Core.Types
{
    public enum AquariumWaterType
    {
        FreshWater,
        BrackishWater,
        SeaWater,
    }

    // FIXME
    public enum AquariumTemperatureType
    {
        Coldwater,
        Tropical,
        ReefMarine, // only SeaWater
    }
}
