/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.ComponentModel;
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
    public partial class AquariumEditDlg : Form, IEditDialog<Aquarium>
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "AquariumEditDlg");

        private ALModel fModel;
        private Aquarium fRecord;

        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public Aquarium Record
        {
            get { return fRecord; }
            set {
                if (fRecord != value) {
                    fRecord = value;
                    UpdateView();
                }
            }
        }

        public AquariumEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            SetLocale();
        }

        public void SetLocale()
        {
            Text = Localizer.LS(LSID.Aquarium);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            cmbShape.FillCombo<TankShape>(ALData.TankShapes, false);
            cmbWaterType.FillCombo<AquariumWaterType>(ALData.WaterTypes, false);

            tabCommon.Text = Localizer.LS(LSID.Common);
            tabTank.Text = Localizer.LS(LSID.Tank);

            lblName.Text = Localizer.LS(LSID.Name);
            lblDesc.Text = Localizer.LS(LSID.Description);
            lblStartDate.Text = Localizer.LS(LSID.StartDate);
            lblStopDate.Text = Localizer.LS(LSID.StopDate);
            lblShape.Text = Localizer.LS(LSID.Shape);
            lblWaterType.Text = Localizer.LS(LSID.WaterType);

            lblVolume.Text = ALData.GetLSuom(LSID.TankVolume, MeasurementType.Volume);
            lblWaterVolume.Text = ALData.GetLSuom(LSID.WaterVolume, MeasurementType.Volume);

            btnTank.Text = Localizer.LS(LSID.Tank) + "...";

            lblUnderfillHeight.Text = ALData.GetLSuom(LSID.UnderfillHeight, MeasurementType.Length);
            lblSoilHeight.Text = ALData.GetLSuom(LSID.SoilHeight, MeasurementType.Length);
            lblSoilVolume.Text = ALData.GetLSuom(LSID.SoilVolume, MeasurementType.Volume);
            lblSoilMass.Text = ALData.GetLSuom(LSID.SoilMass, MeasurementType.Mass);
            lblBrand.Text = Localizer.LS(LSID.Brand);
        }

        private void UpdateView()
        {
            txtName.Text = fRecord.Name;
            txtDesc.Text = fRecord.Description;
            cmbShape.SetSelectedTag(fRecord.TankShape);
            cmbWaterType.SetSelectedTag(fRecord.WaterType);
            txtTankVolume.Text = ALCore.GetDecimalStr(fRecord.TankVolume);
            txtUnderfillHeight.Text = ALCore.GetDecimalStr(fRecord.UnderfillHeight);
            txtSoilHeight.Text = ALCore.GetDecimalStr(fRecord.SoilHeight);

            UIHelper.FillStringsCombo(cmbBrand, fModel.QueryAquariumBrands(), fRecord.Brand);

            dtpStartDate.Checked = !fRecord.StartDate.Equals(ALCore.ZeroDate);
            if (dtpStartDate.Checked) {
                dtpStartDate.Value = fRecord.StartDate;
            }

            dtpStopDate.Checked = !fRecord.StopDate.Equals(ALCore.ZeroDate);
            if (dtpStopDate.Checked) {
                dtpStopDate.Value = fRecord.StopDate;
            }
        }

        private void ApplyChanges()
        {
            fRecord.Name = txtName.Text;
            fRecord.Description = txtDesc.Text;
            fRecord.TankShape = cmbShape.GetSelectedTag<TankShape>();
            fRecord.WaterType = cmbWaterType.GetSelectedTag<AquariumWaterType>();
            fRecord.Brand = cmbBrand.Text;

            fRecord.TankVolume = ALCore.GetDecimalVal(txtTankVolume.Text);

            fRecord.UnderfillHeight = ALCore.GetDecimalVal(txtUnderfillHeight.Text);
            fRecord.SoilHeight = ALCore.GetDecimalVal(txtSoilHeight.Text);

            fRecord.StartDate = dtpStartDate.Checked ? dtpStartDate.Value : new DateTime(0);
            fRecord.StopDate = dtpStopDate.Checked ? dtpStopDate.Value : new DateTime(0);
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

        private void cmbShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tankShape = cmbShape.GetSelectedTag<TankShape>();
            RefreshProps(tankShape);
        }

        private void RefreshProps(TankShape tankShape)
        {
            ITank tank = fRecord.GetTank(tankShape, fRecord.TankProperties);
            TypeDescriptor.AddAttributes(tank, new Attribute[] { new ReadOnlyAttribute(true) });
            tank.SetPropNames();
            pgProps.SelectedObject = tank;

            RecalcValues();
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            RecalcValues();
        }

        private void RecalcValues()
        {
            var tankShape = cmbShape.GetSelectedTag<TankShape>();

            txtTankVolume.Enabled = (tankShape == TankShape.Unknown);

            if (tankShape != TankShape.Unknown) {
                double tankVolume = fRecord.CalcTankVolume(tankShape);
                txtTankVolume.Text = ALCore.GetDecimalStr(tankVolume);
            }

            double underfillHeight = ALCore.GetDecimalVal(txtUnderfillHeight.Text);
            double soilHeight = ALCore.GetDecimalVal(txtSoilHeight.Text);

            double waterVolume = fRecord.CalcWaterVolume(tankShape, underfillHeight, soilHeight);
            txtWaterVolume.Text = ALData.CastStr(waterVolume, MeasurementType.Volume);

            double soilVolume = fRecord.CalcSoilVolume(tankShape, soilHeight);
            txtSoilVolume.Text = ALData.CastStr(soilVolume, MeasurementType.Volume);

            double soilMass = soilVolume * ALData.Soils[0].Density;
            txtSoilMass.Text = ALData.CastStr(soilMass, MeasurementType.Mass);

            double waterVolumeM3 = waterVolume * 0.001d;
            double waterDensity = 998.0d; // kg/m3
            double waterMass = waterVolumeM3 * waterDensity;
            //txtWaterMass.Text = ALData.CastStr(waterMass, MeasurementType.Mass);

            double totalMass = waterMass + soilMass;
        }

        private void btnTank_Click(object sender, EventArgs e)
        {
            var tankShape = cmbShape.GetSelectedTag<TankShape>();

            using (var dlg = new TankEditDlg()) {
                dlg.Record = fRecord.GetTank(tankShape, fRecord.TankProperties);
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fRecord.Tank = dlg.Record;
                    RefreshProps(tankShape);
                }
            }
        }
    }
}
