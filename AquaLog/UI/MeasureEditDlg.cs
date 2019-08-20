/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;

namespace AquaLog.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MeasureEditDlg : Form
    {
        private ALModel fModel;
        private Measure fMeasure;

        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public Measure Measure
        {
            get { return fMeasure; }
            set {
                if (fMeasure != value) {
                    fMeasure = value;
                    UpdateView();
                }
            }
        }


        public MeasureEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = ALCore.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = ALCore.LoadResourceImage("btn_cancel.gif");
        }

        private void UpdateView()
        {
            if (fMeasure != null) {
                cmbAquarium.Items.Clear();
                var aquariums = fModel.QueryAquariums();
                foreach (var aqm in aquariums) {
                    cmbAquarium.Items.Add(aqm);
                }
                cmbAquarium.SelectedItem = aquariums.FirstOrDefault(aqm => aqm.Id == fMeasure.AquariumId);

                if (!fMeasure.Timestamp.Equals(ALCore.ZeroDate)) {
                    dtpTimestamp.Value = fMeasure.Timestamp;
                }

                txtTemperature.Text = ALCore.GetDecimalStr(fMeasure.Temperature);
                txtNO3.Text = ALCore.GetDecimalStr(fMeasure.NO3);
                txtNO2.Text = ALCore.GetDecimalStr(fMeasure.NO2);
                txtGH.Text = ALCore.GetDecimalStr(fMeasure.GH);
                txtKH.Text = ALCore.GetDecimalStr(fMeasure.KH);
                txtPH.Text = ALCore.GetDecimalStr(fMeasure.pH);
                txtCl2.Text = ALCore.GetDecimalStr(fMeasure.Cl2);
                txtCO2.Text = ALCore.GetDecimalStr(fMeasure.CO2);
            }
        }

        private void ApplyChanges()
        {
            var aqm = cmbAquarium.SelectedItem as Aquarium;
            fMeasure.AquariumId = (aqm == null) ? 0 : aqm.Id;

            fMeasure.Timestamp = dtpTimestamp.Value;

            fMeasure.Temperature = (float)ALCore.GetDecimalVal(txtTemperature.Text);
            fMeasure.NO3 = (float)ALCore.GetDecimalVal(txtNO3.Text);
            fMeasure.NO2 = (float)ALCore.GetDecimalVal(txtNO2.Text);
            fMeasure.GH = (float)ALCore.GetDecimalVal(txtGH.Text);
            fMeasure.KH = (float)ALCore.GetDecimalVal(txtKH.Text);
            fMeasure.pH = (float)ALCore.GetDecimalVal(txtPH.Text);
            fMeasure.Cl2 = (float)ALCore.GetDecimalVal(txtCl2.Text);
            fMeasure.CO2 = (float)ALCore.GetDecimalVal(txtCO2.Text);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try {
                ApplyChanges();
                DialogResult = DialogResult.OK;
            } catch {
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
    }
}
