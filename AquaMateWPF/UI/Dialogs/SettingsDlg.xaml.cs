/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Windows;
using AquaMate.Core;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SettingsDlg : EditDialog, ISettingsDialogView
    {
        private readonly SettingsDialogPresenter fPresenter;


        public ALSettings Settings
        {
            get { return fPresenter.Settings; }
            set { fPresenter.Settings = value; }
        }


        public SettingsDlg()
        {
            InitializeComponent();

            fPresenter = new SettingsDialogPresenter(this);

            SetLocale();
        }

        public override void SetLocale()
        {
            base.Title = Localizer.LS(LSID.Settings);
            btnAccept.Content = Localizer.LS(LSID.Accept);
            btnCancel.Content = Localizer.LS(LSID.Cancel);

            tabCommon.Header = Localizer.LS(LSID.Common);
            chkHideClosedTanks.Content = Localizer.LS(LSID.HideClosedTanks);
            chkExitOnClose.Content = Localizer.LS(LSID.ExitOnClose);
            lblLocale.Content = Localizer.LS(LSID.Language);
            chkAutorun.Content = Localizer.LS(LSID.Autorun);
            chkHideAtStartup.Content = Localizer.LS(LSID.HideAtStartup);

            tabData.Header = Localizer.LS(LSID.Data);
            lblLengthUoM.Content = Localizer.LS(LSID.Length);
            lblVolumeUoM.Content = Localizer.LS(LSID.Volume);
            lblMassUoM.Content = Localizer.LS(LSID.Mass);
            lblTemperatureUoM.Content = Localizer.LS(LSID.Temperature);
            chkHideLosses.Content = Localizer.LS(LSID.HideLosses);

            tabDAS.Header = Localizer.LS(LSID.DataAcquisition);
            lblChannel.Content = Localizer.LS(LSID.Channel);
            lblParameters.Content = Localizer.LS(LSID.Parameters);
            lblEnabled.Content = Localizer.LS(LSID.Enabled);
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = fPresenter.ApplyChanges();
        }

        public void SelectTab(int tabIndex)
        {
            tabControl1.SelectedIndex = tabIndex;
        }

        #region View interface implementation

        ICheckBox ISettingsDialogView.AutorunCheck
        {
            get { return GetControlHandler<ICheckBox>(chkAutorun); }
        }

        ICheckBox ISettingsDialogView.HideClosedTanksCheck
        {
            get { return GetControlHandler<ICheckBox>(chkHideClosedTanks); }
        }

        ICheckBox ISettingsDialogView.ExitOnCloseCheck
        {
            get { return GetControlHandler<ICheckBox>(chkExitOnClose); }
        }

        ICheckBox ISettingsDialogView.HideAtStartupCheck
        {
            get { return GetControlHandler<ICheckBox>(chkHideAtStartup); }
        }

        IComboBox ISettingsDialogView.LocaleCombo
        {
            get { return GetControlHandler<IComboBox>(cmbLocale); }
        }

        ICheckBox ISettingsDialogView.HideLossesCheck
        {
            get { return GetControlHandler<ICheckBox>(chkHideLosses); }
        }


        IComboBox ISettingsDialogView.LengthUoMCombo
        {
            get { return GetControlHandler<IComboBox>(cmbLengthUoM); }
        }

        IComboBox ISettingsDialogView.VolumeUoMCombo
        {
            get { return GetControlHandler<IComboBox>(cmbVolumeUoM); }
        }

        IComboBox ISettingsDialogView.MassUoMCombo
        {
            get { return GetControlHandler<IComboBox>(cmbMassUoM); }
        }

        IComboBox ISettingsDialogView.TemperatureUoMCombo
        {
            get { return GetControlHandler<IComboBox>(cmbTemperatureUoM); }
        }

        ICheckBox ISettingsDialogView.ChannelEnabledCheck
        {
            get { return GetControlHandler<ICheckBox>(chkEnabled); }
        }

        IComboBox ISettingsDialogView.ChannelNameCombo
        {
            get { return GetControlHandler<IComboBox>(cmbChannel); }
        }

        IComboBox ISettingsDialogView.ChannelParametersCombo
        {
            get { return GetControlHandler<IComboBox>(cmbParameters); }
        }

        #endregion
    }
}
