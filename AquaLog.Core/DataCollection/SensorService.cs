/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaLog.Core;

namespace AquaLog.DataCollection
{
    public class SensorService : BaseService
    {
        private string fSID;
        private float fValue;


        public string SID
        {
            get { return fSID; }
        }

        public float Value
        {
            get { return fValue; }
        }


        protected SensorService(IChannel channel, double interval) : base(channel, interval)
        {
        }

        protected void WriteQuery(string sensor)
        {
            Channel.WriteLine(string.Format("Q:{0};2;", sensor));
        }

        protected void ReadResponse(string sensor)
        {
            string response = Channel.ReadLine().Trim();
            if (!string.IsNullOrEmpty(response)) {
                // "R:temp;sid:" + rom + ";val:" + celsius + ";"
                string[] parts = response.Split(new char[] { ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 6 && parts[0] == "R" && parts[1] == sensor) {
                    if (parts[2] == "sid") {
                        fSID = parts[3];
                    }
                    if (parts[4] == "val") {
                        fValue = (float)ALCore.GetDecimalVal(parts[5]);
                    }
                    ReceiveData();
                }
            }
        }

        protected override void OnTimedEvent()
        {
            if (Channel.IsOpen) {
                WriteQuery(SensorName);
                ReadResponse(SensorName);
            }
        }
    }
}
