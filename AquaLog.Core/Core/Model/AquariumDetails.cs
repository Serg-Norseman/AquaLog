/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using SQLite;

namespace AquaLog.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class AquariumDetails : Entity
    {
        [Indexed]
        public int AquariumId { get; set; }


        protected AquariumDetails()
        {
        }
    }
}
