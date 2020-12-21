/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Windows;
using AquaMate.Core;
using AquaMate.Core.Model;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ScheduleEditDlg : EditDialog, IScheduleEditorView
    {
        private readonly ScheduleEditorPresenter fPresenter;

        public ScheduleEditDlg()
        {
            InitializeComponent();

            fPresenter = new ScheduleEditorPresenter(this);
        }

        public override void SetLocale()
        {
            base.Title = Localizer.LS(LSID.ScheduleS);
            btnAccept.Content = Localizer.LS(LSID.Accept);
            btnCancel.Content = Localizer.LS(LSID.Cancel);

            lblAquarium.Content = Localizer.LS(LSID.Aquarium);
            lblDate.Content = Localizer.LS(LSID.Date);
            lblEvent.Content = Localizer.LS(LSID.Event);
            lblReminder.Content = Localizer.LS(LSID.Reminder);
            lblType.Content = Localizer.LS(LSID.Type);
            lblStatus.Content = Localizer.LS(LSID.Status);
            lblNote.Content = Localizer.LS(LSID.Note);
        }

        public void SetContext(IModel model, Schedule record)
        {
            fPresenter.SetContext(model, record);
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = fPresenter.ApplyChanges();
        }

        #region View interface implementation

        IComboBox IScheduleEditorView.AquariumCombo
        {
            get { return GetControlHandler<IComboBox>(cmbAquarium); }
        }

        IDateTimeBox IScheduleEditorView.TimestampField
        {
            get { return GetControlHandler<IDateTimeBox>(dtpDateTime); }
        }

        ITextBox IScheduleEditorView.EventField
        {
            get { return GetControlHandler<ITextBox>(txtEvent); }
        }

        ICheckBox IScheduleEditorView.ReminderCheck
        {
            get { return GetControlHandler<ICheckBox>(chkReminder); }
        }

        IComboBox IScheduleEditorView.TypeCombo
        {
            get { return GetControlHandler<IComboBox>(cmbSchedule); }
        }

        IComboBox IScheduleEditorView.StatusCombo
        {
            get { return GetControlHandler<IComboBox>(cmbStatus); }
        }

        ITextBox IScheduleEditorView.NoteField
        {
            get { return GetControlHandler<ITextBox>(txtNote); }
        }

        #endregion
    }
}
