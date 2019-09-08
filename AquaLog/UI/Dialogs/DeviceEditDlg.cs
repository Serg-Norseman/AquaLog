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

namespace AquaLog.UI.Dialogs
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

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            SetLocale();
        }

        public void SetLocale()
        {
            Text = Localizer.LS(LSID.Device);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            cmbType.Items.Clear();
            cmbType.Sorted = true;
            for (DeviceType type = DeviceType.Light; type <= DeviceType.Heater; type++) {
                cmbType.AddItem<DeviceType>(Localizer.LS(ALData.DeviceProps[(int)type].Text), type);
            }

            lblAquarium.Text = Localizer.LS(LSID.Aquarium);
            lblName.Text = Localizer.LS(LSID.Name);
            lblBrand.Text = Localizer.LS(LSID.Brand);
            chkEnabled.Text = Localizer.LS(LSID.Enabled);
            chkDigital.Text = Localizer.LS(LSID.Digital);
            lblType.Text = Localizer.LS(LSID.Type);
            lblPower.Text = Localizer.LS(LSID.Power);
            lblWorkTime.Text = Localizer.LS(LSID.WorkTime);
            lblNote.Text = Localizer.LS(LSID.Note);
            lblTSDBPoint.Text = Localizer.LS(LSID.TSDBPoint);
            lblState.Text = Localizer.LS(LSID.State);
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

                cmbType.SetSelectedTag(fRecord.Type);
                txtName.Text = fRecord.Name;
                chkEnabled.Checked = fRecord.Enabled;
                chkDigital.Checked = fRecord.Digital;
                txtPower.Text = ALCore.GetDecimalStr(fRecord.Power);
                txtWorkTime.Text = ALCore.GetDecimalStr(fRecord.WorkTime);
                txtNote.Text = fRecord.Note;

                UIHelper.FillItemStatesCombo(cmbState, ItemType.Device, fRecord.State);
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
            fRecord.Type = cmbType.GetSelectedTag<DeviceType>();
            fRecord.Power = ALCore.GetDecimalVal(txtPower.Text);
            fRecord.WorkTime = ALCore.GetDecimalVal(txtWorkTime.Text);
            fRecord.Note = txtNote.Text;
            fRecord.State = cmbState.GetSelectedTag<ItemState>();
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
            var deviceType = cmbType.GetSelectedTag<DeviceType>();
            if (deviceType >= 0) {
                var props = ALData.DeviceProps[(int)deviceType];
                cmbTSDBPoint.Enabled = props.HasMeasurements;
            }
        }
    }
}
