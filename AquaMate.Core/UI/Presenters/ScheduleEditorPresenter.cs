/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Core.Types;
using AquaMate.Logging;
using BSLib;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI
{
    public interface IScheduleEditorView : IView
    {
        IComboBoxHandlerEx AquariumCombo { get; }
        IDateTimeBoxHandler TimestampField { get; }
        ITextBoxHandler EventField { get; }
        ICheckBoxHandler ReminderCheck { get; }
        IComboBoxHandlerEx TypeCombo { get; }
        IComboBoxHandlerEx StatusCombo { get; }
        ITextBoxHandler NoteField { get; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class ScheduleEditorPresenter : EditorPresenter<IModel, Schedule, IScheduleEditorView>
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "ScheduleEditorPresenter");


        public ScheduleEditorPresenter(IScheduleEditorView view) : base(view)
        {
        }

        public override void UpdateView()
        {
            if (fRecord != null) {
                fView.AquariumCombo.AddRange(fModel.QueryAquariumsList());
                fView.AquariumCombo.SetSelectedTag(fRecord.AquariumId);

                if (!ALCore.IsZeroDate(fRecord.Timestamp)) {
                    fView.TimestampField.Value = fRecord.Timestamp;
                }

                fView.EventField.Text = fRecord.Event;
                fView.ReminderCheck.Checked = fRecord.Reminder;
                fView.TypeCombo.SetSelectedTag(fRecord.Type);
                fView.StatusCombo.SetSelectedTag(fRecord.Status);
                fView.NoteField.Text = fRecord.Note;
            }
        }

        public override bool ApplyChanges()
        {
            try {
                fRecord.AquariumId = fView.AquariumCombo.GetSelectedTag<int>();
                fRecord.Timestamp = fView.TimestampField.Value;
                fRecord.Event = fView.EventField.Text;
                fRecord.Reminder = fView.ReminderCheck.Checked;
                fRecord.Type = fView.TypeCombo.GetSelectedTag<ScheduleType>();
                fRecord.Status = fView.StatusCombo.GetSelectedTag<TaskStatus>();
                fRecord.Note = fView.NoteField.Text;

                return true;
            } catch (Exception ex) {
                fLogger.WriteError("ApplyChanges()", ex);
                return false;
            }
        }
    }
}
