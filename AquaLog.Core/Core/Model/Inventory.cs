/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using AquaLog.Core.Types;

namespace AquaLog.Core.Model
{
    /// <summary>
    /// Inventory: additive, chemistry, equipment, maintenance, furniture, decoration.
    /// </summary>
    public class Inventory : Entity, IStateItem, IBrandedItem
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Note { get; set; }

        public InventoryType Type { get; set; }

        public ItemState State { get; set; }


        #region Decoration properties

        public float Size { get; set; }
        public float Weight { get; set; }

        #endregion


        public Inventory()
        {
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
