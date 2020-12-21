/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Windows;
using AquaMate.Core;
using AquaMate.Core.Model;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DeviceEditDlg : EditDialog, IDeviceEditorView
    {
        private readonly DeviceEditorPresenter fPresenter;

        public DeviceEditDlg()
        {
            InitializeComponent();

            fPresenter = new DeviceEditorPresenter(this);
        }

        public override void SetLocale()
        {
            base.Title = Localizer.LS(LSID.Device);
            btnAccept.Content = Localizer.LS(LSID.Accept);
            btnCancel.Content = Localizer.LS(LSID.Cancel);

            lblAquarium.Content = Localizer.LS(LSID.Aquarium);
            lblName.Content = Localizer.LS(LSID.Name);
            lblBrand.Content = Localizer.LS(LSID.Brand);
            lblEnabled.Content = Localizer.LS(LSID.Enabled);
            lblDigital.Content = Localizer.LS(LSID.Digital);
            lblType.Content = Localizer.LS(LSID.Type);
            lblPower.Content = Localizer.LS(LSID.Power);
            lblWorkTime.Content = Localizer.LS(LSID.WorkTime);
            lblNote.Content = Localizer.LS(LSID.Note);
            lblTSDBPoint.Content = Localizer.LS(LSID.TSDBPoint);
            lblState.Content = Localizer.LS(LSID.State);
        }

        public void SetContext(IModel model, Device record)
        {
            fPresenter.SetContext(model, record);
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = fPresenter.ApplyChanges();
        }

        private void cmbType_SelectedIndexChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
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
