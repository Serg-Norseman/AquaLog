/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

namespace AquaLog.Core.Types
{
    /// <summary>
    /// 
    /// </summary>
    public enum ItemState
    {
        Unknown, // all item types

        Alive, // Inhabitant
        Dead, // Inhabitant
        Sick, // Inhabitant

        InUse, // (or InWork) Device, Nutrition, Inventory
        Stopped, // Device

        Finished, // Nutrition, Additive, Chemistry
        Broken, // Device, Equipment, Maintenance, Furniture, Decoration,
    }
}
