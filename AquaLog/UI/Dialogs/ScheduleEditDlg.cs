/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;
using AquaLog.Logging;
using BSLib;

namespace AquaLog.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ScheduleEditDlg : Form, IEditDialog<Schedule>
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "ScheduleEditDlg");

        private ALModel fModel;
        private Schedule fRecord;

        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public Schedule Record
        {
            get { return fRecord; }
            set {
                if (fRecord != value) {
                    fRecord = value;
                    UpdateView();
                }
            }
        }


        public ScheduleEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            SetLocale();
        }

        public void SetLocale()
        {
            Text = Localizer.LS(LSID.ScheduleS);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            cmbSchedule.FillCombo<ScheduleType>(ALData.ScheduleTypes, false);
            cmbStatus.FillCombo<TaskStatus>(ALData.TaskStatuses, false);

            lblAquarium.Text = Localizer.LS(LSID.Aquarium);
            lblDate.Text = Localizer.LS(LSID.Date);
            lblEvent.Text = Localizer.LS(LSID.Event);
            chkReminder.Text = Localizer.LS(LSID.Reminder);
            lblType.Text = Localizer.LS(LSID.Type);
            lblStatus.Text = Localizer.LS(LSID.Status);
            lblNote.Text = Localizer.LS(LSID.Note);
        }

        private void UpdateView()
        {
            if (fRecord != null) {
                cmbAquarium.Items.Clear();
                var aquariums = fModel.QueryAquariums();
                foreach (var aqm in aquariums) {
                    if (fRecord.AquariumId != 0 || !aqm.IsInactive()) {
                        cmbAquarium.Items.Add(aqm);
                    }
                }

                cmbAquarium.SelectedItem = aquariums.FirstOrDefault(aqm => aqm.Id == fRecord.AquariumId);
                cmbAquarium.Enabled = (fRecord.AquariumId == 0);

                if (!fRecord.Timestamp.Equals(ALCore.ZeroDate)) {
                    dtpDateTime.Value = fRecord.Timestamp;
                }

                txtEvent.Text = fRecord.Event;
                chkReminder.Checked = fRecord.Reminder;
                cmbSchedule.SetSelectedTag(fRecord.Type);
                cmbStatus.SetSelectedTag(fRecord.Status);
                txtNote.Text = fRecord.Note;
            }
        }

        private void ApplyChanges()
        {
            var aqm = cmbAquarium.SelectedItem as Aquarium;
            fRecord.AquariumId = (aqm == null) ? 0 : aqm.Id;

            fRecord.Timestamp = dtpDateTime.Value;
            fRecord.Event = txtEvent.Text;
            fRecord.Reminder = chkReminder.Checked;
            fRecord.Type = cmbSchedule.GetSelectedTag<ScheduleType>();
            fRecord.Status = cmbStatus.GetSelectedTag<TaskStatus>();
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
