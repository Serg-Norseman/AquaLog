/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AquaLog.Components;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;

namespace AquaLog.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ScheduleEditDlg : Form, IEditDialog<Schedule>
    {
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

            btnAccept.Image = ALCore.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = ALCore.LoadResourceImage("btn_cancel.gif");

            SetLocale();
        }

        public void SetLocale()
        {
            Text = Localizer.LS(LSID.ScheduleS);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            cmbSchedule.Items.Clear();
            for (ScheduleType ts = ScheduleType.Single; ts <= ScheduleType.Yearly; ts++) {
                cmbSchedule.Items.Add(new ComboItem<ScheduleType>(Localizer.LS(ALCore.ScheduleTypes[(int)ts]), ts));
            }

            cmbStatus.Items.Clear();
            for (TaskStatus status = TaskStatus.ToDo; status <= TaskStatus.Closed; status++) {
                cmbStatus.Items.Add(new ComboItem<TaskStatus>(Localizer.LS(ALCore.TaskStatuses[(int)status]), status));
            }

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

                if (!fRecord.DateTime.Equals(ALCore.ZeroDate)) {
                    dtpDateTime.Value = fRecord.DateTime;
                }

                txtEvent.Text = fRecord.Event;
                chkReminder.Checked = fRecord.Reminder;
                UIHelper.SetSelectedTag(cmbSchedule, fRecord.Type);
                UIHelper.SetSelectedTag(cmbStatus, fRecord.Status);
                txtNote.Text = fRecord.Note;
            }
        }

        private void ApplyChanges()
        {
            var aqm = cmbAquarium.SelectedItem as Aquarium;
            fRecord.AquariumId = (aqm == null) ? 0 : aqm.Id;

            fRecord.DateTime = dtpDateTime.Value;
            fRecord.Event = txtEvent.Text;
            fRecord.Reminder = chkReminder.Checked;
            fRecord.Type = UIHelper.GetSelectedTag<ScheduleType>(cmbSchedule);
            fRecord.Status = UIHelper.GetSelectedTag<TaskStatus>(cmbStatus);
            fRecord.Note = txtNote.Text;
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
