/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaLog.Core.Types;

namespace AquaLog.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Schedule : AquariumDetails
    {
        public DateTime Timestamp { get; set; }
        public string Event { get; set; }
        public string Note { get; set; }
        public bool Reminder { get; set; }
        public ScheduleType Type { get; set; }
        public TaskStatus Status { get; set; }


        public Schedule()
        {
        }
    }
}
