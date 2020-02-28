/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using BSLib;

namespace AquaLog.DataCollection
{
    /// <summary>
    /// Channel of Data Acquisition System (DAS).
    /// </summary>
    public class BaseChannel : BaseObject, IChannel
    {
        public static readonly string[] ChannelNames = new string[] { "Serial", "Random", "TCP" };


        private readonly List<BaseService> fServices;


        public virtual bool IsOpen
        {
            get { return false; }
        }

        public List<BaseService> Services
        {
            get { return fServices; }
        }

        public event DataReceivedEventHandler ReceivedData;


        protected BaseChannel()
        {
            fServices = new List<BaseService>();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                Close();

                foreach (var service in fServices) {
                    service.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        public virtual bool Open(string parameters)
        {
            EnableServices(true);
            return true;
        }

        public virtual void Close()
        {
            EnableServices(false);
        }

        public virtual void Send(string text)
        {
            // dummy
        }

        protected void EnableServices(bool value)
        {
            foreach (var service in fServices) {
                service.Enabled = value;
            }
        }

        protected void ReceiveData(string response)
        {
            response = response.Trim();

            foreach (var service in fServices) {
                DataReceivedEventArgs data = service.TryReadResponse(response);
                if (data != null) {
                    DataReceivedEventHandler handler = ReceivedData;
                    if (handler != null) handler(this, data);
                    break;
                }
            }
        }

        public static BaseChannel CreateChannel(string channelName, string parameters, DataReceivedEventHandler dataReceivedEventHandler)
        {
            BaseChannel channel;

            if (channelName == "Serial") {
                #if !NETCOREAPP30
                channel = new SerialChannel();
                #else
                channel = new RandomChannel();
                #endif
            } else if (channelName == "TCP") {
                channel = new TCPChannel();
            } else {
                channel = new RandomChannel();
            }

            channel.ReceivedData += dataReceivedEventHandler;

            //channel.Services.Add(new LEDService(channel, 1000));
            channel.Services.Add(new TemperatureService(channel, 1000));

            bool result = channel.Open(parameters);
            if (!result) {
                channel.Dispose();
                channel = null;
            }

            return channel;
        }
    }
}
