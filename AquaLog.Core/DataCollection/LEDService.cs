﻿/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

namespace AquaLog.DataCollection
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class LEDService : BaseService
    {
        private bool fLED;


        public override string Name
        {
            get { return "LED"; }
        }


        public LEDService(IChannel channel, double interval) : base(channel, interval)
        {
        }

        protected override void OnTimedEvent()
        {
            if (Channel.IsConnected) {
                fLED = !fLED;

                if (fLED) {
                    Channel.Send("Q:setled;13;1");
                } else {
                    Channel.Send("Q:setled;13;0");
                }
            }
        }
    }
}
