/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using AquaLog.Core.Types;
using SQLite;

namespace AquaLog.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Inhabitant : AquariumDetails, IStateItem
    {
        [Indexed]
        public int SpeciesId { get; set; }

        public string Name { get; set; }
        public Sex Sex { get; set; }

        public string Note { get; set; }

        public ItemState State { get; set; }


        /// <summary>
        /// Runtime property for rendering.
        /// </summary>
        [Ignore]
        public int Quantity { get; set; }


        public Inhabitant()
        {
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
