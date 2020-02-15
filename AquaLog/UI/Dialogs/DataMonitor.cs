/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.DataCollection;
using AquaLog.Logging;
using BSLib;

namespace AquaLog.UI.Dialogs
{
    public partial class DataMonitor : Form
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "DataMonitor");

        private IBrowser fBrowser;

        public DataMonitor()
        {
            InitializeComponent();

            Text = Localizer.LS(LSID.DataMonitor);
            btnSettings.Text = Localizer.LS(LSID.Settings);
        }

        public DataMonitor(IBrowser browser) : this()
        {
            fBrowser = browser;
            fBrowser.Model.ReceivedData += OnReceivedData;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (fBrowser != null) {
                    fBrowser.Model.ReceivedData -= OnReceivedData;
                }

                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void OnReceivedData(object sender, DataReceivedEventArgs e)
        {
            try {
                var tempSvc = (TemperatureService)e.Service;
                if (tempSvc != null) {
                    string text = string.Format("{0} [{1}]: {2}", tempSvc.Name, tempSvc.SID, ALCore.GetDecimalStr(tempSvc.Temperature));
                    textBox1.BeginInvoke(new UpdateDelegate(updateTextBox), text);
                }
            } catch (Exception ex) {
                fLogger.WriteError("OnReceivedData()", ex);
            }
        }

        private void updateTextBox(string text)
        {
            textBox1.Text += text + "\r\n";
        }

        private void DataMonitor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            fBrowser.ShowSettings(2);
        }
    }
}
