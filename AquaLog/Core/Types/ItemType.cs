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

        Fish,
        Invertebrate,
        Plant,
        Coral,

        // TODO: may be common table Inventory? (seems like a good idea)
        Nutrition,
        Chemistry,
        Additive,

        Device,
        Equipment,

        Maintenance,
        Furniture,
        Decoration
    }
}
