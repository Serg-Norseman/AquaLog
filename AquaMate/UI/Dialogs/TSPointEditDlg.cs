/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.Logging;
using AquaMate.TSDB;
using BSLib;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TSPointEditDlg : Form
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "TSPointEditDlg");

        private TSDatabase fModel;
        private TSPoint fPoint;

        public TSDatabase Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public TSPoint Point
        {
            get { return fPoint; }
            set {
                if (fPoint != value) {
                    fPoint = value;
                    UpdateView();
                }
            }
        }


        public TSPointEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            SetLocale();
        }

        public void SetLocale()
        {
            Text = Localizer.LS(LSID.TSDBPoint);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            lblName.Text = Localizer.LS(LSID.Name);
            lblUoM.Text = Localizer.LS(LSID.Unit);
            lblMin.Text = Localizer.LS(LSID.Min);
            lblMax.Text = Localizer.LS(LSID.Max);
            lblDeviation.Text = Localizer.LS(LSID.Deviation);
        }

        private void UpdateView()
        {
            if (fPoint != null) {
                txtName.Text = fPoint.Name;
                txtUoM.Text = fPoint.MeasureUnit;
                txtMin.Text = ALCore.GetDecimalStr(fPoint.Min);
                txtMax.Text = ALCore.GetDecimalStr(fPoint.Max);
                txtDeviation.Text = ALCore.GetDecimalStr(fPoint.Deviation);
                txtSID.Text = fPoint.SID;
            }
        }

        private void ApplyChanges()
        {
            fPoint.Name = txtName.Text;
            fPoint.MeasureUnit = txtUoM.Text;
            fPoint.Min = (float)ALCore.GetDecimalVal(txtMin.Text);
            fPoint.Max = (float)ALCore.GetDecimalVal(txtMax.Text);
            fPoint.Deviation = (float)ALCore.GetDecimalVal(txtDeviation.Text);
            fPoint.SID = txtSID.Text;
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
