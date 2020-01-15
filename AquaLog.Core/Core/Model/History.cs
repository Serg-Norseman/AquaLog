/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;

namespace AquaLog.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class History : AquariumDetails, IEventEntity
    {
        public DateTime Timestamp { get; set; }
        public string Event { get; set; }
        public string Note { get; set; }


        public History()
        {
        }

        public override string ToString()
        {
            return Event;
        }
    }
}
