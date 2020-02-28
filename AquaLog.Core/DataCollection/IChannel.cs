/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;

namespace AquaLog.DataCollection
{
    public delegate void DataReceivedEventHandler(object sender, DataReceivedEventArgs e);


    /// <summary>
    /// The interface of data channels.
    /// </summary>
    public interface IChannel : IDisposable
    {
        bool IsOpen { get; }
        List<BaseService> Services { get; }

        event DataReceivedEventHandler ReceivedData;

        void Close();
        bool Open(string parameters);
        void Send(string text);
    }
}
