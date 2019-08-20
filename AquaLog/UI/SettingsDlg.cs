/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Linq;
using System.Windows.Forms;
using AquaLog.Core;

namespace AquaLog.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SettingsDlg : Form
    {
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

            btnAccept.Image = ALCore.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = ALCore.LoadResourceImage("btn_cancel.gif");
        }

        private void UpdateView()
        {
            if (fSettings != null) {
                chkHideClosedTanks.Checked = fSettings.HideClosedTanks;
            }
        }

        private void ApplyChanges()
        {
            fSettings.HideClosedTanks = chkHideClosedTanks.Checked;
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
    }
}
