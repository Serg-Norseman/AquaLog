/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Timers;
using BSLib;

namespace AquaLog.DataCollection
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseService : BaseObject
    {
        private IChannel fChannel;
        private readonly Timer fTimer;


        public event ElapsedEventHandler Elapsed;

        public event EventHandler ReceivedData;


        public bool Enabled
        {
            get { return fTimer.Enabled; }
            set { fTimer.Enabled = value; }
        }

        public IChannel Channel
        {
            get { return fChannel; }
            set { fChannel = value; }
        }


        protected BaseService()
        {
            fTimer = new Timer(1000);
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
            EventHandler handler = ReceivedData;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
