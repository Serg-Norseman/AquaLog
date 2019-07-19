/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using SQLite;

namespace AquaLog.Core.Model
{
    public class Pump : Device
    {
        public int MinFlow { get; set; }
        public int MaxFlow { get; set; }


        public Pump()
        {
        }

        public Pump(int id, string name, int minFlow, int maxFlow)
        {
            Id = id;
            Name = name;
            MinFlow = minFlow;
            MaxFlow = maxFlow;
        }
    }
}
