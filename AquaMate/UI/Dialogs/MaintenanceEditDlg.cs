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
using BSLib;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MaintenanceEditDlg : EditDialog<Maintenance>
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "MaintenanceEditDlg");

        public MaintenanceEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            SetLocale();
        }

        public override void SetLocale()
        {
            Text = Localizer.LS(LSID.Maintenance);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            cmbType.FillCombo<MaintenanceType>(ALData.MaintenanceTypes, true);

            lblAquarium.Text = Localizer.LS(LSID.Aquarium);
            lblDateTime.Text = Localizer.LS(LSID.Date);
            lblType.Text = Localizer.LS(LSID.Type);
            lblValue.Text = Localizer.LS(LSID.Value);
            lblNote.Text = Localizer.LS(LSID.Note);
        }

        protected override void UpdateView()
        {
            if (fRecord != null) {
                UIHelper.FillAquariumsCombo(cmbAquarium, fModel, fRecord.AquariumId, true);

                if (!ALCore.IsZeroDate(fRecord.Timestamp)) {
                    dtpDateTime.Value = fRecord.Timestamp;
                }

                cmbType.SetSelectedTag(fRecord.Type);
                txtValue.Text = ALCore.GetDecimalStr(fRecord.Value);
                txtNote.Text = fRecord.Note;
            }
        }

        protected override void ApplyChanges()
        {
            var aqm = cmbAquarium.SelectedItem as Aquarium;
            fRecord.AquariumId = (aqm == null) ? 0 : aqm.Id;

            fRecord.Timestamp = dtpDateTime.Value;
            fRecord.Type = cmbType.GetSelectedTag<MaintenanceType>();
            fRecord.Value = ALCore.GetDecimalVal(txtValue.Text);
            fRecord.Note = txtNote.Text;
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
