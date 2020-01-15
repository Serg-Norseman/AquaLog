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
        private float fTemperature;

        public float Temperature
        {
            get { return fTemperature; }
            set { fTemperature = value; }
        }


        public TemperatureService()
        {
        }

        protected override void OnTimedEvent()
        {
            if (Channel.IsOpen) {
                Channel.WriteLine("Q:gettemp;2;");

                string response = Channel.ReadLine().Trim();
                if (!string.IsNullOrEmpty(response)) {
                    // "R:temp;sid:" + rom + ";val:" + celsius + ";"
                    string[] parts = response.Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 3 && parts[0] == "R:temp") {
                        string[] valPair = parts[2].Split(new char[] {':'}, StringSplitOptions.RemoveEmptyEntries);
                        if (valPair.Length == 2 && valPair[0] == "val") {
                            fTemperature = (float)ALCore.GetDecimalVal(valPair[1]);
                            ReceiveData();
                        }
                    }
                }
            }
        }
    }
}
