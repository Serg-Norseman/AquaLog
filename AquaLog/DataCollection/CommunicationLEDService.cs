/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;

namespace AquaLog.DataCollection
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class CommunicationLEDService : BaseService
    {
        private bool fLED;


        public CommunicationLEDService()
        {
        }

        protected override void OnTimedEvent()
        {
            if (Channel.IsOpen) {
                fLED = !fLED;

                if (fLED) {
                    Channel.WriteLine("1");
                } else {
                    Channel.WriteLine("0");
                }
            }
        }
    }
}
