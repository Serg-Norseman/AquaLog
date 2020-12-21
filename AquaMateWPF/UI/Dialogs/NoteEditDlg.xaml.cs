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
    public partial class NoteEditDlg : EditDialog, INoteEditorView
    {
        private readonly NoteEditorPresenter fPresenter;

        public NoteEditDlg()
        {
            InitializeComponent();

            fPresenter = new NoteEditorPresenter(this);
        }

        public override void SetLocale()
        {
            base.Title = Localizer.LS(LSID.Note);
            btnAccept.Content = Localizer.LS(LSID.Accept);
            btnCancel.Content = Localizer.LS(LSID.Cancel);

            lblAquarium.Content = Localizer.LS(LSID.Aquarium);
            lblDate.Content = Localizer.LS(LSID.Date);
            lblEvent.Content = Localizer.LS(LSID.Event);
            lblNote.Content = Localizer.LS(LSID.Note);
        }

        public void SetContext(IModel model, Note record)
        {
            fPresenter.SetContext(model, record);
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = fPresenter.ApplyChanges();
        }

        #region View interface implementation

        IComboBox INoteEditorView.AquariumCombo
        {
            get { return GetControlHandler<IComboBox>(cmbAquarium); }
        }

        IDateTimeBox INoteEditorView.TimestampField
        {
            get { return GetControlHandler<IDateTimeBox>(dtpDateTime); }
        }

        ITextBox INoteEditorView.EventField
        {
            get { return GetControlHandler<ITextBox>(txtEvent); }
        }

        ITextBox INoteEditorView.NoteField
        {
            get { return GetControlHandler<ITextBox>(txtNote); }
        }

        #endregion
    }
}
