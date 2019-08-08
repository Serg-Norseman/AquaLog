/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using System.Timers;
using AquaLog.Core;

namespace AquaLog.DataCollection
{
    public partial class DataMonitor : Form
    {
        private IChannel fChannel;
        private BaseService fCommunicationLED;
        private BaseService fTemperatureService;

        public DataMonitor()
        {
            InitializeComponent();

            fChannel = new SerialChannel();

            fCommunicationLED = new CommunicationLEDService();
            fCommunicationLED.SetChannel(fChannel);
            fCommunicationLED.SetInterval(1000);
            //fCommunicationLED.Elapsed += OnTimedEvent;
            fCommunicationLED.ReceivedData += OnReceivedData;

            fTemperatureService = new TemperatureService();
            fTemperatureService.SetChannel(fChannel);
            fTemperatureService.SetInterval(5000);
            //fTemperatureService.Elapsed += OnTimedEvent;
            fTemperatureService.ReceivedData += OnReceivedData;
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
                    textBox1.BeginInvoke(new UpdateDelegate(updateTextBox), strFromPort);
                }
            } catch {
            }
        }

        private void OnReceivedData(object sender, EventArgs e)
        {
            try {
                if (fChannel.IsOpen) {
                    textBox1.BeginInvoke(new UpdateDelegate(updateTextBox), ALCore.GetDecimalStr(((TemperatureService)fTemperatureService).Temperature));
                    //textBox1.BeginInvoke(new UpdateDelegate(updateTextBox), (((TemperatureService)fTemperatureService).Temperature));
                }
            } catch {
            }
        }

        private void updateTextBox(string text)
        {
            textBox1.Text += text + "\r\n";
        }

        private void chkEnableCommLED_CheckedChanged(object sender, EventArgs e)
        {
            fCommunicationLED.Enabled = chkEnableCommLED.Checked;
        }

        private void chkEnableGetTemp_CheckedChanged(object sender, EventArgs e)
        {
            fTemperatureService.Enabled = chkEnableGetTemp.Checked;
        }
    }
}
