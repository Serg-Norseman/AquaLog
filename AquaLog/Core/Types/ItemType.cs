/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

namespace AquaLog.Core.Types
{
    public enum ItemType
    {
        None,

        Aquarium,

        // Inhabitants
        Fish,
        Invertebrate,
        Plant,
        Coral,

        // Lifesupport
        Nutrition,
        Device,

        // Inventory, Lifesupport
        Additive,
        Chemistry,

        // Inventory
        Equipment,
        Maintenance,
        Furniture,
        Decoration,
    }
}
