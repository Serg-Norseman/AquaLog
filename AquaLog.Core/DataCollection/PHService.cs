/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;

namespace AquaLog.DataCollection
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class PHService : SensorService
    {
        public override string Name
        {
            get { return "pH"; }
        }

        public override string SensorName
        {
            get { return "ph"; }
        }


        public PHService(IChannel channel, double interval) : base(channel, interval)
        {
        }
    }
}
