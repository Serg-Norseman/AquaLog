/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using BSLib;

namespace AquaLog.DataCollection
{
    /// <summary>
    /// Data Acquisition System.
    /// </summary>
    public sealed class DAS : BaseObject
    {
        public static readonly string[] ChannelNames = new string[] { "Serial", "Random" };

        private readonly IChannel fChannel;
        private readonly BaseService fCommunicationLED;
        private readonly BaseService fTemperatureService;


        public DAS(string channelName, string parameters, DataReceivedEventHandler dataReceivedEventHandler)
        {
            fChannel = CreateChannel(channelName);
            fChannel.Open(parameters);

            fCommunicationLED = new LEDService(fChannel, 1000);
            fCommunicationLED.ReceivedData += dataReceivedEventHandler;
            fCommunicationLED.Enabled = true;

            fTemperatureService = new TemperatureService(fChannel, 5000);
            fTemperatureService.ReceivedData += dataReceivedEventHandler;
            fTemperatureService.Enabled = true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (fCommunicationLED != null)
                    fCommunicationLED.Dispose();

                if (fTemperatureService != null)
                    fTemperatureService.Dispose();

                fChannel.Close();
                if (fChannel != null)
                    fChannel.Dispose();
            }
            base.Dispose(disposing);
        }

        private static BaseChannel CreateChannel(string channelName)
        {
            if (channelName == "Serial") {
                #if !NETCOREAPP30
                return new SerialChannel();
                #else
                return new RandomChannel();
                #endif
            } else {
                return new RandomChannel();
            }
        }
    }
}
