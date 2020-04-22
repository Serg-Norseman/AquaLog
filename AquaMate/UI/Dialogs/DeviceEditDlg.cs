﻿/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.Core.Model;
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
            fPresenter.ChangeSelectedType();
        }

        #region View interface implementation

        IComboBox IDeviceEditorView.AquariumCombo
        {
            get { return GetControlHandler<IComboBox>(cmbAquarium); }
        }

        IComboBox IDeviceEditorView.TSPointsCombo
        {
            get { return GetControlHandler<IComboBox>(cmbTSDBPoint); }
        }

        ITextBox IDeviceEditorView.NameField
        {
            get { return GetControlHandler<ITextBox>(txtName); }
        }

        IComboBox IDeviceEditorView.BrandCombo
        {
            get { return GetControlHandler<IComboBox>(cmbBrand); }
        }

        ICheckBox IDeviceEditorView.EnabledCheck
        {
            get { return GetControlHandler<ICheckBox>(chkEnabled); }
        }

        ICheckBox IDeviceEditorView.DigitalCheck
        {
            get { return GetControlHandler<ICheckBox>(chkDigital); }
        }

        IComboBox IDeviceEditorView.TypeCombo
        {
            get { return GetControlHandler<IComboBox>(cmbType); }
        }

        ITextBox IDeviceEditorView.PowerField
        {
            get { return GetControlHandler<ITextBox>(txtPower); }
        }

        ITextBox IDeviceEditorView.WorkTimeField
        {
            get { return GetControlHandler<ITextBox>(txtWorkTime); }
        }

        ITextBox IDeviceEditorView.NoteField
        {
            get { return GetControlHandler<ITextBox>(txtNote); }
        }

        IComboBox IDeviceEditorView.StateCombo
        {
            get { return GetControlHandler<IComboBox>(cmbState); }
        }

        #endregion
    }
}
