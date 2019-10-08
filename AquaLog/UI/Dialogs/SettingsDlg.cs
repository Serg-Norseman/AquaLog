/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Linq;
using System.Windows.Forms;
using AquaLog.Core;
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
        }

        private void UpdateView()
        {
            if (fSettings != null) {
                chkHideClosedTanks.Checked = fSettings.HideClosedTanks;
                chkExitOnClose.Checked = fSettings.ExitOnClose;
                cmbLocale.SelectedItem = Localizer.Locales.FirstOrDefault(loc => loc.Code == fSettings.CurrentLocale);
                chkHideAtStartup.Checked = fSettings.HideAtStartup;
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
    }
}
