/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaMate.Core.Types;
using SQLite;

namespace AquaMate.Core.Model
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

        // not used
        public ItemState State { get; set; }

        private InventoryProperties fProperties;

        [Ignore]
        public InventoryProperties Properties
        {
            get {
                if (fProperties == null) {
                    fProperties = GetProperties(Type, RawProperties);
                }
                return fProperties;
            }
            set {
                fProperties = value;
                RawProperties = StringSerializer.Serialize(fProperties);
            }
        }

        public string RawProperties { get; set; }


        public override EntityType EntityType
        {
            get {
                return EntityType.Inventory;
            }
        }


        public Inventory()
        {
        }

        public override string ToString()
        {
            return Name;
        }

        public InventoryProperties GetProperties(InventoryType type, string str)
        {
            Type propsType = ALData.InventoryTypes[(int)type].PropsType;
            return (propsType == null) ? null : (InventoryProperties)StringSerializer.Deserialize(propsType, str);
        }
    }
}
