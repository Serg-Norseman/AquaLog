﻿/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

namespace AquaMate.Prognostics
{
    public interface IConsole
    {
        void DoAction(ConsoleAction action, object userState = null);

        string GetInputText();

        void ResetInput();
        void WaitInput();
    }
}
