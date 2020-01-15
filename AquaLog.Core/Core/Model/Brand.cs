/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

namespace AquaLog.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Brand : Entity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Note { get; set; }

        public Brand()
        {
        }

        public Brand(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
