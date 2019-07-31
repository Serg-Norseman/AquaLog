/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;

namespace AquaLog.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MaintenanceEditDlg : Form
    {
        private ALModel fModel;
        private Maintenance fMaintenance;

        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public Maintenance Maintenance
        {
            get { return fMaintenance; }
            set {
                if (fMaintenance != value) {
                    fMaintenance = value;
                    UpdateView();
                }
            }
        }


        public MaintenanceEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = ALCore.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = ALCore.LoadResourceImage("btn_cancel.gif");

            for (TaskSchedule ts = TaskSchedule.Single; ts <= TaskSchedule.Yearly; ts++) {
                cmbSchedule.Items.Add(ts.ToString());
            }

            for (TaskStatus status = TaskStatus.ToDo; status <= TaskStatus.Closed; status++) {
                cmbStatus.Items.Add(status.ToString());
            }
        }

        private void UpdateView()
        {
            if (fMaintenance != null) {
                cmbAquarium.Items.Clear();
                var aquariums = fModel.QueryAquariums();
                foreach (var aqm in aquariums) {
                    if (fMaintenance.AquariumId != 0 || !aqm.IsInactive()) {
                        cmbAquarium.Items.Add(aqm);
                    }
                }

                cmbAquarium.SelectedItem = aquariums.FirstOrDefault(aqm => aqm.Id == fMaintenance.AquariumId);
                cmbAquarium.Enabled = (fMaintenance.AquariumId == 0);

                if (!fMaintenance.DateTime.Equals(ALCore.ZeroDate)) {
                    dtpDateTime.Value = fMaintenance.DateTime;
                }

                txtEvent.Text = fMaintenance.Event;
                txtUnits.Text = fMaintenance.Units;
                chkReminder.Checked = fMaintenance.Reminder;
                cmbSchedule.SelectedIndex = (int)fMaintenance.Schedule;
                cmbStatus.SelectedIndex = (int)fMaintenance.Status;
                txtNote.Text = fMaintenance.Note;
            }
        }

        private void ApplyChanges()
        {
            var aqm = cmbAquarium.SelectedItem as Aquarium;
            fMaintenance.AquariumId = (aqm == null) ? 0 : aqm.Id;

            fMaintenance.DateTime = dtpDateTime.Value;
            fMaintenance.Event = txtEvent.Text;
            fMaintenance.Units = txtUnits.Text;
            fMaintenance.Reminder = chkReminder.Checked;
            fMaintenance.Schedule = (TaskSchedule)cmbSchedule.SelectedIndex;
            fMaintenance.Status = (TaskStatus)cmbStatus.SelectedIndex;
            fMaintenance.Note = txtNote.Text;
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
