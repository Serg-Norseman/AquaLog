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
using AquaLog.Core.Types;
using AquaLog.TSDB;

namespace AquaLog.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DeviceEditDlg : Form
    {
        private ALModel fModel;
        private Device fDevice;

        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public Device Device
        {
            get { return fDevice; }
            set {
                if (fDevice != value) {
                    fDevice = value;
                    UpdateView();
                }
            }
        }


        public DeviceEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = ALCore.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = ALCore.LoadResourceImage("btn_cancel.gif");

            for (DeviceType type = DeviceType.Light; type <= DeviceType.Thermometer; type++) {
                cmbType.Items.Add(type.ToString());
            }
        }

        private void UpdateView()
        {
            if (fDevice != null) {
                cmbAquarium.Items.Clear();
                var aquariums = fModel.QueryAquariums();
                foreach (var aqm in aquariums) {
                    cmbAquarium.Items.Add(aqm);
                }
                cmbAquarium.SelectedItem = aquariums.FirstOrDefault(aqm => aqm.Id == fDevice.AquariumId);

                cmbTSDBPoint.Items.Clear();
                TSDatabase tsdb = fModel.TSDB;
                var points = tsdb.GetPoints();
                foreach (TSPoint pt in points) {
                    cmbTSDBPoint.Items.Add(pt);
                }
                cmbTSDBPoint.SelectedItem = points.FirstOrDefault(pt => pt.Id == fDevice.PointId);

                cmbBrand.Items.Clear();
                var brands = fModel.QueryDeviceBrands();
                foreach (QString bqs in brands) {
                    cmbBrand.Items.Add(bqs.element);
                }
                cmbBrand.Text = fDevice.Brand;

                cmbType.SelectedIndex = (int)fDevice.Type;
                txtName.Text = fDevice.Name;
                chkEnabled.Checked = fDevice.Enabled;
                chkDigital.Checked = fDevice.Digital;
                txtWattage.Text = ALCore.GetDecimalStr(fDevice.Wattage);
            }
        }

        private void ApplyChanges()
        {
            var aqm = cmbAquarium.SelectedItem as Aquarium;
            fDevice.AquariumId = (aqm == null) ? 0 : aqm.Id;

            var pt = cmbTSDBPoint.SelectedItem as TSPoint;
            fDevice.PointId = (pt == null) ? 0 : pt.Id;

            fDevice.Name = txtName.Text;
            fDevice.Brand = cmbBrand.Text;
            fDevice.Enabled = chkEnabled.Checked;
            fDevice.Digital = chkDigital.Checked;
            fDevice.Type = (DeviceType)cmbType.SelectedIndex;
            fDevice.Wattage = ALCore.GetDecimalVal(txtWattage.Text);
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

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var deviceType = (DeviceType)cmbType.SelectedIndex;
            if (deviceType >= 0) {
                var props = ALCore.DeviceProps[(int)deviceType];
                cmbTSDBPoint.Enabled = props.HasMeasurements;
            }
        }
    }
}
