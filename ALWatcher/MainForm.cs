/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using System.Timers;

namespace ALWatcher
{
    public partial class MainForm : Form
    {
        private IChannel fChannel;
        private BaseService fCommunicationLED;

        public MainForm()
        {
            InitializeComponent();

            fChannel = new SerialChannel();

            fCommunicationLED = new CommunicationLEDService();
            fCommunicationLED.SetChannel(fChannel);
            fCommunicationLED.SetInterval(1000);
            fCommunicationLED.Elapsed += OnTimedEvent;
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            fChannel.Open("COM3");
        }

        private void MainFormFormClosed(object sender, FormClosedEventArgs e)
        {
            fCommunicationLED.Dispose();
            fChannel.Dispose();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            try {
                if (fChannel.IsOpen) {
                    string strFromPort = fChannel.ReadLine();
                    lblPortData.BeginInvoke(new UpdateDelegate(updateTextBox), strFromPort);
                }
            } catch {
            }
        }

        private void updateTextBox(string txt)
        {
            lblPortData.Text = txt;
        }

        private void chkEnableCommLED_CheckedChanged(object sender, EventArgs e)
        {
            fCommunicationLED.Enabled = chkEnableCommLED.Checked;
        }
    }
}
