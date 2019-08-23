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
    public partial class DeviceEditDlg : Form, IEditDialog<Device>
    {
        private ALModel fModel;
        private Device fRecord;

        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public Device Record
        {
            get { return fRecord; }
            set {
                if (fRecord != value) {
                    fRecord = value;
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

            SetLocale();
        }

        public void SetLocale()
        {
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);
        }

        private void UpdateView()
        {
            if (fRecord != null) {
                UIHelper.FillAquariumsCombo(cmbAquarium, fModel, fRecord.AquariumId);
                cmbAquarium.Enabled = (fRecord.AquariumId == 0);

                cmbTSDBPoint.Items.Clear();
                TSDatabase tsdb = fModel.TSDB;
                var points = tsdb.GetPoints();
                foreach (TSPoint pt in points) {
                    cmbTSDBPoint.Items.Add(pt);
                }
                cmbTSDBPoint.SelectedItem = points.FirstOrDefault(pt => pt.Id == fRecord.PointId);

                cmbBrand.Items.Clear();
                var brands = fModel.QueryDeviceBrands();
                foreach (QString bqs in brands) {
                    cmbBrand.Items.Add(bqs.element);
                }
                cmbBrand.Text = fRecord.Brand;

                cmbType.SelectedIndex = (int)fRecord.Type;
                txtName.Text = fRecord.Name;
                chkEnabled.Checked = fRecord.Enabled;
                chkDigital.Checked = fRecord.Digital;
                txtWattage.Text = ALCore.GetDecimalStr(fRecord.Wattage);
            }
        }

        private void ApplyChanges()
        {
            var aqm = cmbAquarium.SelectedItem as Aquarium;
            fRecord.AquariumId = (aqm == null) ? 0 : aqm.Id;

            var pt = cmbTSDBPoint.SelectedItem as TSPoint;
            fRecord.PointId = (pt == null) ? 0 : pt.Id;

            fRecord.Name = txtName.Text;
            fRecord.Brand = cmbBrand.Text;
            fRecord.Enabled = chkEnabled.Checked;
            fRecord.Digital = chkDigital.Checked;
            fRecord.Type = (DeviceType)cmbType.SelectedIndex;
            fRecord.Wattage = ALCore.GetDecimalVal(txtWattage.Text);
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
