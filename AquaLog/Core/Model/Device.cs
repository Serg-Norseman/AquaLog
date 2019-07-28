﻿/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using SQLite;

namespace AquaLog.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Device : AquariumDetails
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }

        public string Brand { get; set; }
        public double Wattage { get; set; }


        public Device()
        {
        }
    }
}
