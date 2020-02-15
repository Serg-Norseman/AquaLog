/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Linq;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Types;
using AquaLog.DataCollection;
using AquaLog.Logging;
using BSLib;

namespace AquaLog.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SettingsDlg : Form, ILocalizable
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "SettingsDlg");

        private ALModel fModel;
        private ALSettings fSettings;

        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public ALSettings Settings
        {
            get { return fSettings; }
            set {
                if (fSettings != value) {
                    fSettings = value;
                    UpdateView();
                }
            }
        }


        public SettingsDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            foreach (var locale in Localizer.Locales) {
                cmbLocale.Items.Add(locale);
            }

            for (MeasurementUnit unit = MeasurementUnit.First; unit <= MeasurementUnit.Last; unit++) {
                var uom = ALData.MeasurementUnits[(int)unit];

                if (uom.MeasurementType == MeasurementType.Length) {
                    cmbLengthUoM.AddItem<MeasurementUnit>(uom.StrName, unit);
                }
                if (uom.MeasurementType == MeasurementType.Volume) {
                    if (unit == MeasurementUnit.UKGallon) continue; // TODO: UKGallon not yet supported

                    cmbVolumeUoM.AddItem<MeasurementUnit>(uom.StrName, unit);
                }
                if (uom.MeasurementType == MeasurementType.Mass) {
                    cmbMassUoM.AddItem<MeasurementUnit>(uom.StrName, unit);
                }
                if (uom.MeasurementType == MeasurementType.Temperature) {
                    cmbTemperatureUoM.AddItem<MeasurementUnit>(uom.StrName, unit);
                }
            }

            // TODO: UOM changes not yet supported
            cmbLengthUoM.Enabled = false;
            cmbVolumeUoM.Enabled = false;
            cmbMassUoM.Enabled = false;
            cmbTemperatureUoM.Enabled = false;

            cmbChannel.Items.AddRange(DAS.ChannelNames);

            SetLocale();
        }

        public void SetLocale()
        {
            Text = Localizer.LS(LSID.Settings);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);
            chkHideClosedTanks.Text = Localizer.LS(LSID.HideClosedTanks);
            chkExitOnClose.Text = Localizer.LS(LSID.ExitOnClose);
            lblLocale.Text = Localizer.LS(LSID.Language);
            chkAutorun.Text = Localizer.LS(LSID.Autorun);
            chkHideAtStartup.Text = Localizer.LS(LSID.HideAtStartup);
            tabCommon.Text = Localizer.LS(LSID.Common);
            tabData.Text = Localizer.LS(LSID.Data);
            lblLengthUoM.Text = Localizer.LS(LSID.Length);
            lblVolumeUoM.Text = Localizer.LS(LSID.Volume);
            lblMassUoM.Text = Localizer.LS(LSID.Mass);
            lblTemperatureUoM.Text = Localizer.LS(LSID.Temperature);

            tabDAS.Text = Localizer.LS(LSID.DataAcquisition);
            lblChannel.Text = Localizer.LS(LSID.Channel);
            lblParameters.Text = Localizer.LS(LSID.Parameters);
            chkEnabled.Text = Localizer.LS(LSID.Enabled);
        }

        private void UpdateView()
        {
            if (fSettings != null) {
                chkHideClosedTanks.Checked = fSettings.HideClosedTanks;
                chkExitOnClose.Checked = fSettings.ExitOnClose;
                cmbLocale.SelectedItem = Localizer.Locales.FirstOrDefault(loc => loc.Code == fSettings.CurrentLocale);
                chkHideAtStartup.Checked = fSettings.HideAtStartup;

                cmbLengthUoM.SetSelectedTag<MeasurementUnit>(fSettings.LengthUoM);
                cmbVolumeUoM.SetSelectedTag<MeasurementUnit>(fSettings.VolumeUoM);
                cmbMassUoM.SetSelectedTag<MeasurementUnit>(fSettings.MassUoM);
                cmbTemperatureUoM.SetSelectedTag<MeasurementUnit>(fSettings.TemperatureUoM);

                chkEnabled.Checked = fSettings.ChannelEnabled;
                cmbChannel.Text = fSettings.ChannelName;
                cmbPort.Text = fSettings.ChannelParameters;
            }

            chkAutorun.Checked = UIHelper.IsStartupItem();
        }

        private void ApplyChanges()
        {
            LocaleFile currentLocale = (cmbLocale.SelectedItem as LocaleFile);

            fSettings.HideClosedTanks = chkHideClosedTanks.Checked;
            fSettings.ExitOnClose = chkExitOnClose.Checked;
            fSettings.CurrentLocale = (currentLocale != null) ? currentLocale.Code : Localizer.LS_DEF_CODE;
            fSettings.HideAtStartup = chkHideAtStartup.Checked;

            fSettings.LengthUoM = cmbLengthUoM.GetSelectedTag<MeasurementUnit>();
            fSettings.VolumeUoM = cmbVolumeUoM.GetSelectedTag<MeasurementUnit>();
            fSettings.MassUoM = cmbMassUoM.GetSelectedTag<MeasurementUnit>();
            fSettings.TemperatureUoM = cmbMassUoM.GetSelectedTag<MeasurementUnit>();

            fSettings.ChannelEnabled = chkEnabled.Checked;
            fSettings.ChannelName = cmbChannel.Text;
            fSettings.ChannelParameters = cmbPort.Text;

            if (chkAutorun.Checked) {
                UIHelper.RegisterStartup();
            } else {
                UIHelper.UnregisterStartup();
            }
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

        public void SelectTab(int tabIndex)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[tabIndex];
        }
    }
}
