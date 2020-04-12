/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Core.Types;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ScheduleEditDlg : EditDialog<Schedule>, IScheduleEditorView
    {
        private readonly ScheduleEditorPresenter fPresenter;

        public ScheduleEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            fPresenter = new ScheduleEditorPresenter(this);
        }

        public override void SetLocale()
        {
            Text = Localizer.LS(LSID.ScheduleS);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            var scheduleTypesList = ALData.GetNamesList<ScheduleType>(ALData.ScheduleTypes);
            cmbSchedule.FillCombo<ScheduleType>(scheduleTypesList, false);

            var taskStatusesList = ALData.GetNamesList<TaskStatus>(ALData.TaskStatuses);
            cmbStatus.FillCombo<TaskStatus>(taskStatusesList, false);

            lblAquarium.Text = Localizer.LS(LSID.Aquarium);
            lblDate.Text = Localizer.LS(LSID.Date);
            lblEvent.Text = Localizer.LS(LSID.Event);
            chkReminder.Text = Localizer.LS(LSID.Reminder);
            lblType.Text = Localizer.LS(LSID.Type);
            lblStatus.Text = Localizer.LS(LSID.Status);
            lblNote.Text = Localizer.LS(LSID.Note);
        }

        public override void SetContext(IModel model, Schedule record)
        {
            base.SetContext(model, record);
            fPresenter.SetContext(model, record);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = fPresenter.ApplyChanges() ? DialogResult.OK : DialogResult.None;
        }

        #region View interface implementation

        IComboBoxHandlerEx IScheduleEditorView.AquariumCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbAquarium); }
        }

        IDateTimeBoxHandler IScheduleEditorView.TimestampField
        {
            get { return GetControlHandler<IDateTimeBoxHandler>(dtpDateTime); }
        }

        ITextBoxHandler IScheduleEditorView.EventField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtEvent); }
        }

        ICheckBoxHandler IScheduleEditorView.ReminderCheck
        {
            get { return GetControlHandler<ICheckBoxHandler>(chkReminder); }
        }

        IComboBoxHandlerEx IScheduleEditorView.TypeCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbSchedule); }
        }

        IComboBoxHandlerEx IScheduleEditorView.StatusCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbStatus); }
        }

        ITextBoxHandler IScheduleEditorView.NoteField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtNote); }
        }

        #endregion
    }
}
