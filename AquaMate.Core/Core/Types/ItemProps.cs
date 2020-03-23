﻿/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using BSLib;

namespace AquaMate.Core.Types
{
    public sealed class ItemProps
    {
        public LSID Name { get; private set; }
        public EnumSet<ItemState> States { get; private set; }

        public ItemProps(LSID name, EnumSet<ItemState> states)
        {
            Name = name;
            States = states;
        }
    }
}
