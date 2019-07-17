/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using SQLite;

namespace AquaLog.Core
{
    public class Fish : Inhabitant
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int AquariumId { get; set; }

        public string Name { get; set; }

        //public int Quantity { get; set; }
        //public string Type { get; set; }

        //public Aquarium Aquarium { get; set; }

        public Fish()
        {
        }
    }
}
