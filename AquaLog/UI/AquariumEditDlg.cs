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

namespace AquaLog.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AquariumEditDlg : Form
    {
        private Aquarium fAquarium;

        public Aquarium Aquarium
        {
            get { return fAquarium; }
            set {
                if (fAquarium != value) {
                    fAquarium = value;
                    UpdateView();
                }
            }
        }

        public AquariumEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = ALCore.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = ALCore.LoadResourceImage("btn_cancel.gif");

            for (TankShape shape = TankShape.Unknown; shape <= TankShape.Rectangular; shape++) {
                cmbShape.Items.Add(shape.ToString());
            }

            for (AquariumWaterType awt = AquariumWaterType.Freshwater; awt <= AquariumWaterType.ReefMarine; awt++) {
                cmbWaterType.Items.Add(awt.ToString());
            }
        }

        private void UpdateView()
        {
            txtName.Text = fAquarium.Name;
            txtDesc.Text = fAquarium.Description;
            cmbShape.SelectedIndex = (int)fAquarium.TankShape;
            cmbWaterType.SelectedIndex = (int)fAquarium.WaterType;

            txtDepth.Text = ALCore.GetDecimalStr(fAquarium.Depth);
            txtWidth.Text = ALCore.GetDecimalStr(fAquarium.Width);
            txtHeigth.Text = ALCore.GetDecimalStr(fAquarium.Height);
            txtTankVolume.Text = ALCore.GetDecimalStr(fAquarium.TankVolume);
            txtGlassThickness.Text = ALCore.GetDecimalStr(fAquarium.GlassThickness);

            dtpStartDate.Checked = !fAquarium.StartDate.Equals(ALCore.ZeroDate);
            if (dtpStartDate.Checked) {
                dtpStartDate.Value = fAquarium.StartDate;
            }

            dtpStopDate.Checked = !fAquarium.StopDate.Equals(ALCore.ZeroDate);
            if (dtpStopDate.Checked) {
                dtpStopDate.Value = fAquarium.StopDate;
            }
        }

        private void ApplyChanges()
        {
            fAquarium.Name = txtName.Text;
            fAquarium.Description = txtDesc.Text;
            fAquarium.TankShape = (TankShape)cmbShape.SelectedIndex;
            fAquarium.WaterType = (AquariumWaterType)cmbWaterType.SelectedIndex;

            fAquarium.Depth = ALCore.GetDecimalVal(txtDepth.Text);
            fAquarium.Width = ALCore.GetDecimalVal(txtWidth.Text);
            fAquarium.Height = ALCore.GetDecimalVal(txtHeigth.Text);
            fAquarium.TankVolume = ALCore.GetDecimalVal(txtTankVolume.Text);
            fAquarium.GlassThickness = ALCore.GetDecimalVal(txtGlassThickness.Text);

            fAquarium.StartDate = dtpStartDate.Checked ? dtpStartDate.Value : new DateTime(0);
            fAquarium.StopDate = dtpStopDate.Checked ? dtpStopDate.Value : new DateTime(0);
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

        private void cmbShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDepth.Text = "";
            txtWidth.Text = "";
            txtHeigth.Text = "";
            txtTankVolume.Text = "";

            var tankShape = (TankShape)cmbShape.SelectedIndex;
            switch (tankShape) {
                case TankShape.Unknown:
                case TankShape.Bowl:
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

                case TankShape.BowFront:
                case TankShape.BevelledFront:
                case TankShape.PlateFrontCorner:
                case TankShape.BowFrontCorner:
                    break;
            }
        }

        private void txtSizes_TextChanged(object sender, EventArgs e)
        {
            double glassThickness = ALCore.GetDecimalVal(txtGlassThickness.Text, -1.0d);
            // two sides
            glassThickness *= 2.0;

            var tankShape = (TankShape)cmbShape.SelectedIndex;
            switch (tankShape) {
                case TankShape.Unknown:
                case TankShape.Bowl:
                    break;

                case TankShape.Cube:
                    var size = ALCore.GetDecimalVal(txtWidth.Text);
                    if (glassThickness > 0.0d) {
                        size -= glassThickness;
                    }
                    txtTankVolume.Text = ALCore.GetDecimalStr(size * size * size);
                    break;

                case TankShape.Rectangular:
                    var depth = ALCore.GetDecimalVal(txtDepth.Text);
                    var width = ALCore.GetDecimalVal(txtWidth.Text);
                    var height = ALCore.GetDecimalVal(txtHeigth.Text);
                    if (glassThickness > 0.0d) {
                        depth -= glassThickness;
                        width -= glassThickness;
                        height -= glassThickness;
                    }
                    txtTankVolume.Text = ALCore.GetDecimalStr(ALData.CalcTankVolume(depth, width, height));
                    break;

                case TankShape.BowFront:
                case TankShape.BevelledFront:
                case TankShape.PlateFrontCorner:
                case TankShape.BowFrontCorner:
                    break;
            }
        }

        private void txtTankVolume_TextChanged(object sender, EventArgs e)
        {
            var tankVolume = ALCore.GetDecimalVal(txtTankVolume.Text);
            txtWaterVolume.Text = ALCore.GetDecimalStr(ALData.CalcWaterVolume(tankVolume));
        }
    }
}
