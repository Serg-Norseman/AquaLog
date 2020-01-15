/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;

namespace BSLib.Timeline
{
    /// <summary>
    ///   Describes an item that can be placed on a track in the timeline.
    /// </summary>
    public class EventFrame : ITimeObject
    {
        /// <summary>
        ///   The name of the time object (event frame or track).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///   The beginning of the item.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        ///   The end of the item.
        /// </summary>
        public DateTime End { get; set; }


        public EventFrame(string name, DateTime start, DateTime end)
        {
            Name = name;
            Start = start;
            End = end;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, End: {1}, Start: {2}", Name, End, Start);
        }
    }
}
