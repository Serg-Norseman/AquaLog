/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;
using AquaLog.Logging;
using BSLib;

namespace AquaLog.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MeasureEditDlg : Form, IEditDialog<Measure>
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "MeasureEditDlg");

        private ALModel fModel;
        private Measure fRecord;

        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public Measure Record
        {
            get { return fRecord; }
            set {
                if (fRecord != value) {
                    fRecord = value;
                    UpdateView();
                }
            }
        }


        public MeasureEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            SetLocale();
        }

        public void SetLocale()
        {
            Text = Localizer.LS(LSID.Measure);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            lblAquarium.Text = Localizer.LS(LSID.Aquarium);
            lblTimestamp.Text = Localizer.LS(LSID.Timestamp);
            lblTemperature.Text = ALData.GetLSuom(LSID.Temperature, MeasurementType.Temperature);
        }

        private void UpdateView()
        {
            if (fRecord != null) {
                UIHelper.FillAquariumsCombo(cmbAquarium, fModel, fRecord.AquariumId);
                cmbAquarium.Enabled = (fRecord.AquariumId == 0);

                if (!fRecord.Timestamp.Equals(ALCore.ZeroDate)) {
                    dtpTimestamp.Value = fRecord.Timestamp;
                }

                txtTemperature.Text = ALCore.GetDecimalStr(fRecord.Temperature);
                txtNO3.Text = ALCore.GetDecimalStr(fRecord.NO3);
                txtNO2.Text = ALCore.GetDecimalStr(fRecord.NO2);
                txtGH.Text = ALCore.GetDecimalStr(fRecord.GH);
                txtKH.Text = ALCore.GetDecimalStr(fRecord.KH);
                txtPH.Text = ALCore.GetDecimalStr(fRecord.pH);
                txtCl2.Text = ALCore.GetDecimalStr(fRecord.Cl2);
                txtCO2.Text = ALCore.GetDecimalStr(fRecord.CO2);
                txtNHtot.Text = ALCore.GetDecimalStr(fRecord.NH);
                txtNH3.Text = ALCore.GetDecimalStr(fRecord.NH3);
                txtNH4.Text = ALCore.GetDecimalStr(fRecord.NH4);
                txtPO4.Text = ALCore.GetDecimalStr(fRecord.PO4);
            }
        }

        private void ApplyChanges()
        {
            var aqm = cmbAquarium.SelectedItem as Aquarium;
            fRecord.AquariumId = (aqm == null) ? 0 : aqm.Id;

            fRecord.Timestamp = dtpTimestamp.Value;

            fRecord.Temperature = (float)ALCore.GetDecimalVal(txtTemperature.Text);
            fRecord.NO3 = (float)ALCore.GetDecimalVal(txtNO3.Text);
            fRecord.NO2 = (float)ALCore.GetDecimalVal(txtNO2.Text);
            fRecord.GH = (float)ALCore.GetDecimalVal(txtGH.Text);
            fRecord.KH = (float)ALCore.GetDecimalVal(txtKH.Text);
            fRecord.pH = (float)ALCore.GetDecimalVal(txtPH.Text);
            fRecord.Cl2 = (float)ALCore.GetDecimalVal(txtCl2.Text);
            fRecord.CO2 = (float)ALCore.GetDecimalVal(txtCO2.Text);
            fRecord.NH = (float)ALCore.GetDecimalVal(txtNHtot.Text);
            fRecord.NH3 = (float)ALCore.GetDecimalVal(txtNH3.Text);
            fRecord.NH4 = (float)ALCore.GetDecimalVal(txtNH4.Text);
            fRecord.PO4 = (float)ALCore.GetDecimalVal(txtPO4.Text);
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

        private void btnCalcCO2_Click(object sender, EventArgs e)
        {
            double degKH = ALCore.GetDecimalVal(txtKH.Text);
            double PH = ALCore.GetDecimalVal(txtPH.Text);
            double CO2 = ALData.CalcCO2(degKH, PH);
            txtCO2.Text = ALCore.GetDecimalStr(CO2);
        }

        private void btnCalcNH3_Click(object sender, EventArgs e)
        {
            double temp = ALCore.GetDecimalVal(txtTemperature.Text);
            double totalNH = ALCore.GetDecimalVal(txtNHtot.Text);
            double pH = ALCore.GetDecimalVal(txtPH.Text);
            double NH3 = ALData.CalcNH3(pH, temp, totalNH);
            txtNH3.Text = ALCore.GetDecimalStr(NH3);
        }

        private void btnCalcNH4_Click(object sender, EventArgs e)
        {
            double totalNH = ALCore.GetDecimalVal(txtNHtot.Text);
            double NH3 = ALCore.GetDecimalVal(txtNH3.Text);
            double NH4 = totalNH - NH3;
            txtNH4.Text = ALCore.GetDecimalStr(NH4);
        }
    }
}
