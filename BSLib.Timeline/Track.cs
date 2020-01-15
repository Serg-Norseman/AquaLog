/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Collections.Generic;

namespace BSLib.Timeline
{
    /// <summary>
    ///   Wraps a single <see cref="EventFrame" /> into an Track.
    /// </summary>
    public class Track : ITimeObject
    {
        /// <summary>
        ///   The wrapped timeline track.
        /// </summary>
        private readonly IList<EventFrame> fFrames;


        /// <summary>
        ///   The elements within this track.
        /// </summary>
        public IList<EventFrame> Frames
        {
            get { return fFrames; }
        }

        /// <summary>
        ///   The name of the track.
        ///   This will be displayed alongside the track in the timeline.
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        ///   Construct a new Track.
        /// </summary>
        public Track()
        {
            fFrames = new List<EventFrame>();
        }

        /// <summary>
        ///   Construct a new Track.
        /// </summary>
        /// <param name="track">The timeline track that should be wrapped.</param>
        public Track(EventFrame track) : this()
        {
            fFrames.Add(track);
            Name = track.Name;
        }
    }
}
