/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;

namespace AquaLog.DataCollection
{
    public delegate void UpdateDelegate(string text);

    /// <summary>
    /// 
    /// </summary>
    public interface IChannel : IDisposable
    {
        bool IsOpen { get; }

        void Close();
        void Open(string parameters);
        string ReadLine();
        void WriteLine(string text);
    }
}
