/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaLog.Core.Types;
using SQLite;

namespace AquaLog.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Invertebrate : Inhabitant
    {
        public Sex Sex { get; set; }


        public Invertebrate()
        {
        }
    }
}
