/*
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
