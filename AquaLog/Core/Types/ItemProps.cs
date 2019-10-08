/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using BSLib;

namespace AquaLog.Core.Types
{
    public sealed class ItemProps
    {
        public LSID Name;
        public EnumSet<ItemState> States;

        public ItemProps(LSID name, EnumSet<ItemState> states)
        {
            Name = name;
            States = states;
        }
    }
}
