/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Drawing;
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
            txtVolume.Text = ALCore.GetDecimalStr(fAquarium.TankVolume);

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

            fAquarium.Depth = ALCore.GetDecimalVal(txtDepth);
            fAquarium.Width = ALCore.GetDecimalVal(txtWidth);
            fAquarium.Height = ALCore.GetDecimalVal(txtHeigth);
            fAquarium.TankVolume = ALCore.GetDecimalVal(txtVolume);

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
            txtVolume.Text = "";

            var tankShape = (TankShape)cmbShape.SelectedIndex;
            switch (tankShape) {
                case TankShape.Unknown:
                case TankShape.Bowl:
                    txtDepth.Enabled = false;
                    txtWidth.Enabled = false;
                    txtHeigth.Enabled = false;
                    txtVolume.Enabled = true;
                    break;

                case TankShape.Cube:
                    txtDepth.Enabled = false;
                    txtWidth.Enabled = true;
                    txtHeigth.Enabled = false;
                    txtVolume.Enabled = false;
                    break;

                case TankShape.Rectangular:
                    txtDepth.Enabled = true;
                    txtWidth.Enabled = true;
                    txtHeigth.Enabled = true;
                    txtVolume.Enabled = false;
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
            var tankShape = (TankShape)cmbShape.SelectedIndex;
            switch (tankShape) {
                case TankShape.Unknown:
                case TankShape.Bowl:
                    break;

                case TankShape.Cube:
                    var size = ALCore.GetDecimalVal(txtWidth);
                    txtVolume.Text = ALCore.GetDecimalStr(size * size * size);
                    break;

                case TankShape.Rectangular:
                    var depth = ALCore.GetDecimalVal(txtDepth);
                    var width = ALCore.GetDecimalVal(txtWidth);
                    var height = ALCore.GetDecimalVal(txtHeigth);
                    txtVolume.Text = ALCore.GetDecimalStr(ALCore.CalcVolume(depth, width, height));
                    break;

                case TankShape.BowFront:
                case TankShape.BevelledFront:
                case TankShape.PlateFrontCorner:
                case TankShape.BowFrontCorner:
                    break;
            }
        }
    }
}
