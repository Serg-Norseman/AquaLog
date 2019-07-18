/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using SQLite;

namespace AquaLog.Core
{
    public enum InhabitantType
    {
        Fish,
        Invertebrate,
        Plant
    }


    /// <summary>
    /// 
    /// </summary>
    public class Inhabitant : Entity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int AquariumId { get; set; }

        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }


        public Inhabitant()
        {
        }
    }
}
