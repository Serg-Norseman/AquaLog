/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;

namespace AquaLog.Core.Model
{
    public class Note : AquariumDetails, IEventEntity
    {
        public DateTime Timestamp { get; set; }
        public string Content { get; set; }


        public Note()
        {
        }

        public override string ToString()
        {
            return Content;
        }
    }
}
