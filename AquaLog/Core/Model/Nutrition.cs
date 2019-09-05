/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;

namespace AquaLog.Core.Model
{
    public class Nutrition : AquariumDetails
    {
        public string Name { get; set; }
        public string Brand { get; set; }

        public float Amount { get; set; }
        public string Note { get; set; }

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
