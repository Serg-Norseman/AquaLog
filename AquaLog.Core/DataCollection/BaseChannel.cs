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
    /// 
    /// </summary>
    public class BaseChannel : BaseObject, IChannel
    {
        public virtual bool IsOpen
        {
            get {
                return false;
            }
        }


        public virtual void Open(string parameters)
        {
        }

        public virtual void Close()
        {
        }

        public virtual string ReadLine()
        {
            return string.Empty;
        }

        public virtual void WriteLine(string text)
        {
            // dummy
        }
    }
}
