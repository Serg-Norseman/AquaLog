/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Core.Types;
using AquaMate.Logging;
using AquaMate.TSDB;
using BSLib;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DeviceEditDlg : EditDialog<Device>
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "DeviceEditDlg");

        public DeviceEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            SetLocale();
        }

        public override void SetLocale()
        {
            Text = Localizer.LS(LSID.Device);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            cmbType.FillCombo<DeviceType>(ALData.DeviceProps, true);

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

        protected override void UpdateView()
        {
            if (fRecord != null) {
                UIHelper.FillAquariumsCombo(cmbAquarium, fModel, fRecord.AquariumId);

                UIHelper.FillEntitiesCombo(cmbTSDBPoint, fModel.TSDB.GetPoints(), fRecord.PointId, true);

                UIHelper.FillStringsCombo(cmbBrand, fModel.QueryDeviceBrands(), fRecord.Brand);

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

        protected override void ApplyChanges()
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
            } catch (Exception ex) {
                fLogger.WriteError("ApplyChanges()", ex);
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
