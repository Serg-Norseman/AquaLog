/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AquaMate.Prognostics;

namespace AquaMate.UI.Dialogs
{
    public partial class DiagnosticConsole : Form, IConsole
    {
        private LogicService service;
        private bool? stop;
        private ManualResetEvent semaMoreStop;
        private ManualResetEvent semaGetInput;
        private WinIO winIO;
        private Queue<int> charBuffer;
        private ConsoleAction readMode; // for distinguishing between various ways of reading input

        public DiagnosticConsole()
        {
            InitializeComponent();

            Text = "Prolog diagnostic console";

            stop = null;
            semaGetInput = new ManualResetEvent(false);
            charBuffer = new Queue<int>();
            winIO = new WinIO(this, charBuffer);
            bgwExecuteQuery.ReportProgress((int)ConsoleAction.BtnsOff);
            service = new LogicService(winIO);
            readMode = ConsoleAction.None;
        }

        private void btnXeqQuery_Click(object sender, EventArgs e)
        {
            if (bgwExecuteQuery.IsBusy && !bgwExecuteQuery.CancellationPending) return;

            btnCancelQuery.Enabled = true;
            btnMore.Enabled = btnStop.Enabled = false;
            lblMoreOrStop.Visible = false;
            bgwExecuteQuery.RunWorkerAsync(rtbQuery.Text);
        }

        private void bgwExecuteQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            try {
                string query = e.Argument as string;

                var results = service.GetQuerySolutions(query);

                semaMoreStop = new ManualResetEvent(false);

                foreach (var s in results) {
                    winIO.WriteLine("{0}{1}", s.Solution, (s.IsLast ? null : ";"));

                    if (s.IsLast) break;

                    bool stop;
                    WaitForMoreOrStopPressed(out stop);
                    semaMoreStop.Reset();

                    if (stop) break;
                }
            } finally {
            }
        }

        private void WaitForMoreOrStopPressed(out bool halt)
        {
            bgwExecuteQuery.ReportProgress((int)ConsoleAction.BtnsOn);

            try {
                semaMoreStop.WaitOne();
            } finally {
                halt = stop ?? false;
                stop = null;
                bgwExecuteQuery.ReportProgress((int)ConsoleAction.BtnsOff);
            }
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            stop = false;
            semaMoreStop.Set();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stop = true;
            semaMoreStop.Set();
        }

        // click event for (now invisible) Cancel-button, which does not work as expected.
        // (execution does not get interrupted, have to sort out why this does not work)
        private void btnCancelQuery_Click(object sender, EventArgs e)
        {
            bgwExecuteQuery.CancelAsync();
            btnXeqQuery.Enabled = true;

            while (bgwExecuteQuery.CancellationPending) {
                Application.DoEvents();
                Thread.Sleep(10);
            }
        }

        private void bgwExecuteQuery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnCancelQuery.Enabled = false;
            btnMore.Enabled = btnStop.Enabled = false;
            btnXeqQuery.Enabled = true;
        }

        private void bgwExecuteQuery_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch ((ConsoleAction)e.ProgressPercentage)
            {
                case ConsoleAction.ReadStart:
                    tbInput.Text = null;
                    tbInput.Enabled = true;
                    btnXeqQuery.Enabled = false;
                    grpInput.BackColor = Color.Red;
                    tbInput.Focus();
                    break;
                case ConsoleAction.ReadEnd:
                    tbInput.Enabled = false;
                    btnXeqQuery.Enabled = true;
                    grpInput.BackColor = tpInterpreter.BackColor;
                    break;
                case ConsoleAction.ReadLn:
                    readMode = ConsoleAction.ReadLn;
                    break;
                case ConsoleAction.ReadCh:
                    readMode = ConsoleAction.ReadCh;
                    break;
                case ConsoleAction.Write:
                    tbAnswer.AppendText(e.UserState as string);
                    break;
                case ConsoleAction.WriteLn:
                    tbAnswer.AppendText(e.UserState as string);
                    break;
                case ConsoleAction.NewLn:
                    tbAnswer.AppendText(Environment.NewLine);
                    break;
                case ConsoleAction.Clear:
                    tbAnswer.Clear();
                    break;
                case ConsoleAction.Reset:
                    tbInput.Clear();
                    break;
                case ConsoleAction.BtnsOn:
                    btnMore.Enabled = btnStop.Enabled = true;
                    btnXeqQuery.Enabled = false;
                    lblMoreOrStop.Visible = true;
                    break;
                case ConsoleAction.BtnsOff:
                    tbInput.Enabled = false;
                    btnMore.Enabled = btnStop.Enabled = false;
                    lblMoreOrStop.Visible = false;
                    break;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbQuery.Text = null;
        }

        private void tbInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                if (readMode == ConsoleAction.ReadCh) {
                    foreach (char c in tbInput.Text) charBuffer.Enqueue(c);
                    foreach (char c in Environment.NewLine) charBuffer.Enqueue(c);
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
                semaGetInput.Set();
            }
        }

        private void btnClearA_Click(object sender, EventArgs e)
        {
            tbAnswer.Clear();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        void IConsole.DoAction(ConsoleAction action, object userState = null)
        {
            bgwExecuteQuery.ReportProgress((int)action, userState);
        }

        string IConsole.GetInputText()
        {
            return tbInput.Text;
        }

        void IConsole.ResetInput()
        {
            semaGetInput.Reset();
        }

        void IConsole.WaitInput()
        {
            semaGetInput.WaitOne();
        }
    }
}
