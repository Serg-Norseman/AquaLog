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
    public interface IMaintenanceEditorView : IView
    {
        IComboBoxHandlerEx AquariumCombo { get; }
        IDateTimeBoxHandler TimestampField { get; }
        IComboBoxHandlerEx TypeCombo { get; }
        ITextBoxHandler ValueField { get; }
        ITextBoxHandler NoteField { get; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class MaintenanceEditorPresenter : EditorPresenter<IModel, Maintenance, IMaintenanceEditorView>
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "MaintenanceEditorPresenter");


        public MaintenanceEditorPresenter(IMaintenanceEditorView view) : base(view)
        {
        }

        public override void UpdateView()
        {
            if (fRecord != null) {
                fView.AquariumCombo.AddRange(fModel.QueryAquariumsList());
                fView.AquariumCombo.SetSelectedTag(fRecord.AquariumId);

                if (!ALCore.IsZeroDate(fRecord.Timestamp)) {
                    fView.TimestampField.SetCheckedDate(fRecord.Timestamp);
                }

                fView.TypeCombo.SetSelectedTag(fRecord.Type);
                fView.ValueField.SetDecimalVal(fRecord.Value);
                fView.NoteField.Text = fRecord.Note;
            }
        }

        public override bool ApplyChanges()
        {
            try {
                fRecord.AquariumId = fView.AquariumCombo.GetSelectedTag<int>();
                fRecord.Timestamp = fView.TimestampField.Value;
                fRecord.Type = fView.TypeCombo.GetSelectedTag<MaintenanceType>();
                fRecord.Value = fView.ValueField.GetDecimalVal();
                fRecord.Note = fView.NoteField.Text;

                return true;
            } catch (Exception ex) {
                fLogger.WriteError("ApplyChanges()", ex);
                return false;
            }
        }
    }
}
