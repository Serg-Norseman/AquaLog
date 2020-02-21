/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Timers;
using BSLib;

namespace AquaLog.DataCollection
{
    public class DataReceivedEventArgs : EventArgs
    {
        private readonly BaseService fService;

        public BaseService Service
        {
            get { return fService; }
        }


        internal DataReceivedEventArgs(BaseService service)
        {
            fService = service;
        }
    }


    public delegate void DataReceivedEventHandler(object sender, DataReceivedEventArgs e);


    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseService : BaseObject
    {
        private IChannel fChannel;
        private readonly Timer fTimer;


        public event ElapsedEventHandler Elapsed;

        public event DataReceivedEventHandler ReceivedData;


        public IChannel Channel
        {
            get { return fChannel; }
            set { fChannel = value; }
        }

        public bool Enabled
        {
            get { return fTimer.Enabled; }
            set { fTimer.Enabled = value; }
        }

        public virtual string Name
        {
            get { return string.Empty; }
        }

        public virtual string SensorName
        {
            get { return string.Empty; }
        }


        protected BaseService(IChannel channel, double interval)
        {
            fChannel = channel;

            fTimer = new Timer(interval);
            fTimer.Elapsed += OnTimerElapsed;
            fTimer.AutoReset = true;
            fTimer.Enabled = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (fTimer != null) {
                    fTimer.Enabled = false;
                    fTimer.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        public void SetChannel(IChannel channel)
        {
            fChannel = channel;
        }

        // milliseconds
        public void SetInterval(double interval)
        {
            fTimer.Interval = interval;
        }

        protected virtual void OnTimedEvent()
        {
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            OnTimedEvent();

            ElapsedEventHandler handler = Elapsed;
            if (handler != null) handler(sender, e);
        }

        protected void ReceiveData()
        {
            DataReceivedEventHandler handler = ReceivedData;
            if (handler != null) handler(this, new DataReceivedEventArgs(this));
        }
    }
}
