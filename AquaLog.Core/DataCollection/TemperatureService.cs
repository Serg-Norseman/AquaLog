/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaLog.Core;

namespace AquaLog.DataCollection
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class TemperatureService : BaseService
    {
        private string fSID;
        private float fTemperature;


        public override string Name
        {
            get { return "Temperature"; }
        }

        public string SID
        {
            get { return fSID; }
        }

        public float Temperature
        {
            get { return fTemperature; }
        }


        public TemperatureService(IChannel channel, double interval) : base(channel, interval)
        {
        }

        protected override void OnTimedEvent()
        {
            if (Channel.IsOpen) {
                Channel.WriteLine("Q:gettemp;2;");

                string response = Channel.ReadLine().Trim();
                if (!string.IsNullOrEmpty(response)) {
                    // "R:temp;sid:" + rom + ";val:" + celsius + ";"
                    string[] parts = response.Split(new char[] { ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 6 && parts[0] == "R" && parts[1] == "temp") {
                        if (parts[2] == "sid") {
                            fSID = parts[3];
                        }
                        if (parts[4] == "val") {
                            fTemperature = (float)ALCore.GetDecimalVal(parts[5]);
                        }

                        ReceiveData();
                    }
                }
            }
        }
    }
}
