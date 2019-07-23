/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;

namespace AquaLog.Logging
{
    // Levels in order of increasing priority: ALL, DEBUG, INFO, WARN, ERROR, FATAL, OFF
    public interface ILogger
    {
        void WriteDebug(string msg);
        void WriteDebug(string str, params object[] args);

        void WriteInfo(string msg);
        void WriteInfo(string str, params object[] args);

        void WriteError(string msg);
        void WriteError(string msg, Exception ex);

        // unused
        void WriteNumError(int num, Exception ex);
    }
}
