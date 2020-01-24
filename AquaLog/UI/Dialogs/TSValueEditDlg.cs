/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Logging;
using AquaLog.TSDB;
using BSLib;

namespace AquaLog.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TSValueEditDlg : Form
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "TSValueEditDlg");

        private TSValue fValue;

        public TSValue Value
        {
            get { return fValue; }
            set {
                if (fValue != value) {
                    fValue = value;
                    UpdateView();
                }
            }
        }


        public TSValueEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            SetLocale();
        }

        public void SetLocale()
        {
            Text = Localizer.LS(LSID.Value);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            lblTimestamp.Text = Localizer.LS(LSID.Timestamp);
            lblValue.Text = Localizer.LS(LSID.Value);
        }

        private void UpdateView()
        {
            if (fValue != null) {
                if (!ALCore.IsZeroDate(fValue.Timestamp)) {
                    dtpTimestamp.Value = fValue.Timestamp;
                }
                txtValue.Text = ALCore.GetDecimalStr(fValue.Value);
            }
        }

        private void ApplyChanges()
        {
            fValue.Timestamp = dtpTimestamp.Value;
            fValue.Value = (float)ALCore.GetDecimalVal(txtValue.Text);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try {
                ApplyChanges();
                DialogResult = DialogResult.OK;
            } catch (Exception ex) {
                fLogger.WriteError("ApplyChanges()", ex);
                DialogResult = DialogResult.None;
            }
        }
    }
}
