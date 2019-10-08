/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
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
            lblDepth.Text = Localizer.LS(LSID.Depth);
            lblWidth.Text = Localizer.LS(LSID.Width);
            lblHeigth.Text = Localizer.LS(LSID.Heigth);
            lblVolume.Text = Localizer.LS(LSID.TankVolume);
            lblWaterVolume.Text = Localizer.LS(LSID.WaterVolume);
            lblGlassThickness.Text = Localizer.LS(LSID.GlassThickness);
        }

        private void UpdateView()
        {
            txtName.Text = fRecord.Name;
            txtDesc.Text = fRecord.Description;
            cmbShape.SetSelectedTag(fRecord.TankShape);
            cmbWaterType.SetSelectedTag(fRecord.WaterType);

            txtDepth.Text = ALCore.GetDecimalStr(fRecord.Depth);
            txtWidth.Text = ALCore.GetDecimalStr(fRecord.Width);
            txtHeigth.Text = ALCore.GetDecimalStr(fRecord.Height);
            txtTankVolume.Text = ALCore.GetDecimalStr(fRecord.TankVolume);
            txtGlassThickness.Text = ALCore.GetDecimalStr(fRecord.GlassThickness);

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

            fRecord.Depth = ALCore.GetDecimalVal(txtDepth.Text);
            fRecord.Width = ALCore.GetDecimalVal(txtWidth.Text);
            fRecord.Height = ALCore.GetDecimalVal(txtHeigth.Text);
            fRecord.TankVolume = ALCore.GetDecimalVal(txtTankVolume.Text);
            fRecord.GlassThickness = ALCore.GetDecimalVal(txtGlassThickness.Text);

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
            txtDepth.Text = "";
            txtWidth.Text = "";
            txtHeigth.Text = "";
            txtTankVolume.Text = "";

            var tankShape = cmbShape.GetSelectedTag<TankShape>();
            switch (tankShape) {
                case TankShape.Unknown:
                case TankShape.Bowl:
                case TankShape.BowFront:
                case TankShape.PlateFrontCorner:
                case TankShape.BowFrontCorner:
                    txtDepth.Enabled = false;
                    txtWidth.Enabled = false;
                    txtHeigth.Enabled = false;
                    txtTankVolume.Enabled = true;
                    txtGlassThickness.Enabled = false;
                    break;

                case TankShape.Cube:
                    txtDepth.Enabled = false;
                    txtWidth.Enabled = true;
                    txtHeigth.Enabled = false;
                    txtTankVolume.Enabled = false;
                    txtGlassThickness.Enabled = true;
                    break;

                case TankShape.Rectangular:
                    txtDepth.Enabled = true;
                    txtWidth.Enabled = true;
                    txtHeigth.Enabled = true;
                    txtTankVolume.Enabled = false;
                    txtGlassThickness.Enabled = true;
                    break;
            }
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            RecalcValues();
        }

        private void RecalcValues()
        {
            double glassThickness = ALCore.GetDecimalVal(txtGlassThickness.Text, -1.0d);
            double tankVolume;

            var tankShape = cmbShape.GetSelectedTag<TankShape>();
            switch (tankShape) {
                case TankShape.Unknown:
                case TankShape.Bowl:
                case TankShape.BowFront:
                case TankShape.PlateFrontCorner:
                case TankShape.BowFrontCorner:
                    tankVolume = ALCore.GetDecimalVal(txtTankVolume.Text);
                    break;

                case TankShape.Cube:
                    var size = ALCore.GetDecimalVal(txtWidth.Text);
                    tankVolume = ALData.CalcCubeTankVolume(size, glassThickness);
                    txtTankVolume.Text = ALCore.GetDecimalStr(tankVolume);
                    break;

                case TankShape.Rectangular:
                    var depth = ALCore.GetDecimalVal(txtDepth.Text);
                    var width = ALCore.GetDecimalVal(txtWidth.Text);
                    var height = ALCore.GetDecimalVal(txtHeigth.Text);
                    tankVolume = ALData.CalcRectangularTankVolume(depth, width, height, glassThickness);
                    txtTankVolume.Text = ALCore.GetDecimalStr(tankVolume);
                    break;

                default:
                    tankVolume = ALCore.GetDecimalVal(txtTankVolume.Text);
                    break;
            }

            double waterVolume = ALData.CalcWaterVolume(tankVolume);
            txtWaterVolume.Text = ALCore.GetDecimalStr(waterVolume);

            double waterHeight = 0.0d;
            if (tankShape == TankShape.Rectangular) {
                double depth = ALCore.GetDecimalVal(txtDepth.Text);
                double width = ALCore.GetDecimalVal(txtWidth.Text);
                waterHeight = ALData.CalcWaterHeight(depth, width, waterVolume, glassThickness);
            }
            lblWaterHeight.Text = string.Format("wH = {0:0.00}", waterHeight);
        }
    }
}
