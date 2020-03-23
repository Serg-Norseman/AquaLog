/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

namespace BSLib.Timeline
{
    /// <summary>
    ///   Common interface members for elements that can serve as timeline tracks.
    /// </summary>
    public interface ITimeObject
    {
        /// <summary>
        ///   The name of the time object (event frame or track).
        ///   This will be displayed alongside the track in the timeline.
        /// </summary>
        string Name { get; set; }
    }
}
