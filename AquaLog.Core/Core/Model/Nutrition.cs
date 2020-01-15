/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using AquaLog.Core.Types;

namespace AquaLog.Core.Model
{
    public class Nutrition : AquariumDetails, IStateItem, IBrandedItem
    {
        public string Name { get; set; }
        public string Brand { get; set; }

        public float Amount { get; set; }
        public string Note { get; set; }

        public ItemState State { get; set; }

        public int InhabitantId { get; set; }


        public Nutrition()
        {
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
