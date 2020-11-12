/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Collections.Generic;
using Prolog;

namespace AquaMate.Prognostics
{
    public enum ConsoleAction
    {
        None,
        ReadStart,
        ReadEnd,
        ReadLn,
        ReadCh,
        Write,
        WriteLn,
        NewLn,
        Clear,
        Reset,
        BtnsOn,
        BtnsOff
    }

    public class WinIO : BasicIo
    {
        private readonly IConsole fConsole;
        private readonly Queue<int> fCharBuffer;

        public WinIO(IConsole console, Queue<int> charBuffer)
        {
            fConsole = console;
            fCharBuffer = charBuffer;
        }

        public override string ReadLine()
        {
            try {
                fConsole.DoAction(ConsoleAction.ReadStart);
                fConsole.DoAction(ConsoleAction.ReadLn);
                fConsole.WaitInput(); // wait until text has been entered in tbInput

                return fConsole.GetInputText();
            } finally {
                fConsole.ResetInput();
                fConsole.DoAction(ConsoleAction.ReadEnd);
            }
        }

        public override int ReadChar()
        {
            if (fCharBuffer.Count == 0) {
                try {
                    fConsole.DoAction(ConsoleAction.ReadStart);
                    fConsole.DoAction(ConsoleAction.ReadCh);
                    fConsole.WaitInput(); // wait until charBuffer is not empty
                } finally {
                    fConsole.ResetInput();
                    fConsole.DoAction(ConsoleAction.ReadEnd);
                }
            }

            return fCharBuffer.Dequeue();
        }

        public override void Write(string s)
        {
            fConsole.DoAction(ConsoleAction.Write, s);
        }

        public override void WriteLine(string s)
        {
            fConsole.DoAction(ConsoleAction.WriteLn, s);
        }

        public override void WriteLine()
        {
            fConsole.DoAction(ConsoleAction.NewLn);
        }

        public override void Clear()
        {
            fConsole.DoAction(ConsoleAction.Clear);
        }

        public override void Reset()
        {
            fConsole.DoAction(ConsoleAction.Reset);
        }
    }
}
