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
    public partial class MaintenanceEditDlg : EditDialog, IMaintenanceEditorView
    {
        private readonly MaintenanceEditorPresenter fPresenter;

        public MaintenanceEditDlg()
        {
            InitializeComponent();

            fPresenter = new MaintenanceEditorPresenter(this);
        }

        public override void SetLocale()
        {
            base.Title = Localizer.LS(LSID.Maintenance);
            btnAccept.Content = Localizer.LS(LSID.Accept);
            btnCancel.Content = Localizer.LS(LSID.Cancel);

            lblAquarium.Content = Localizer.LS(LSID.Aquarium);
            lblDateTime.Content = Localizer.LS(LSID.Date);
            lblType.Content = Localizer.LS(LSID.Type);
            lblValue.Content = Localizer.LS(LSID.Value);
            lblNote.Content = Localizer.LS(LSID.Note);
        }

        public void SetContext(IModel model, Maintenance record)
        {
            fPresenter.SetContext(model, record);
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = fPresenter.ApplyChanges();
        }

        #region View interface implementation

        IComboBox IMaintenanceEditorView.AquariumCombo
        {
            get { return GetControlHandler<IComboBox>(cmbAquarium); }
        }

        IDateTimeBox IMaintenanceEditorView.TimestampField
        {
            get { return GetControlHandler<IDateTimeBox>(dtpDateTime); }
        }

        IComboBox IMaintenanceEditorView.TypeCombo
        {
            get { return GetControlHandler<IComboBox>(cmbType); }
        }

        ITextBox IMaintenanceEditorView.ValueField
        {
            get { return GetControlHandler<ITextBox>(txtValue); }
        }

        ITextBox IMaintenanceEditorView.NoteField
        {
            get { return GetControlHandler<ITextBox>(txtNote); }
        }

        #endregion
    }
}
