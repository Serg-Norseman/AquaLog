/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Core.Types;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DeviceEditDlg : EditDialog<Device>, IDeviceEditorView
    {
        private readonly DeviceEditorPresenter fPresenter;

        public DeviceEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            fPresenter = new DeviceEditorPresenter(this);
        }

        public override void SetLocale()
        {
            Text = Localizer.LS(LSID.Device);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            var deviceTypesList = ALData.GetNamesList<DeviceType>(ALData.DeviceProps);
            cmbType.FillCombo<DeviceType>(deviceTypesList, true);

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

        public override void SetContext(IModel model, Device record)
        {
            base.SetContext(model, record);
            fPresenter.SetContext(model, record);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = fPresenter.ApplyChanges() ? DialogResult.OK : DialogResult.None;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var deviceType = cmbType.GetSelectedTag<DeviceType>();
            fPresenter.ChangeSelectedType(deviceType);
        }

        #region View interface implementation

        IComboBoxHandlerEx IDeviceEditorView.AquariumCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbAquarium); }
        }

        IComboBoxHandlerEx IDeviceEditorView.TSPointsCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbTSDBPoint); }
        }

        ITextBoxHandler IDeviceEditorView.NameField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtName); }
        }

        IComboBoxHandlerEx IDeviceEditorView.BrandCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbBrand); }
        }

        ICheckBoxHandler IDeviceEditorView.EnabledCheck
        {
            get { return GetControlHandler<ICheckBoxHandler>(chkEnabled); }
        }

        ICheckBoxHandler IDeviceEditorView.DigitalCheck
        {
            get { return GetControlHandler<ICheckBoxHandler>(chkDigital); }
        }

        IComboBoxHandlerEx IDeviceEditorView.TypeCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbType); }
        }

        ITextBoxHandler IDeviceEditorView.PowerField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtPower); }
        }

        ITextBoxHandler IDeviceEditorView.WorkTimeField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtWorkTime); }
        }

        ITextBoxHandler IDeviceEditorView.NoteField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtNote); }
        }

        IComboBoxHandlerEx IDeviceEditorView.StateCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbState); }
        }

        #endregion
    }
}
