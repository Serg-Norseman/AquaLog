/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Windows;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Core.Types;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class InhabitantEditDlg : EditDialog, IInhabitantEditorView
    {
        private readonly InhabitantEditorPresenter fPresenter;

        public InhabitantEditDlg()
        {
            InitializeComponent();

            fPresenter = new InhabitantEditorPresenter(this);
        }

        public override void SetLocale()
        {
            base.Title = Localizer.LS(LSID.Inhabitant);
            btnAccept.Content = Localizer.LS(LSID.Accept);
            btnCancel.Content = Localizer.LS(LSID.Cancel);

            tabCommon.Header = Localizer.LS(LSID.Common);
            tabTransfers.Header = Localizer.LS(LSID.Transfers);

            lblName.Content = Localizer.LS(LSID.Name);
            lblNote.Content = Localizer.LS(LSID.Note);
            lblSpecies.Content = Localizer.LS(LSID.SpeciesS);
            lblSex.Content = Localizer.LS(LSID.Sex);
            lblState.Content = Localizer.LS(LSID.State);
        }

        public void SetContext(IModel model, Inhabitant record)
        {
            fPresenter.SetContext(model, record);
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = fPresenter.ApplyChanges();
        }

        private void cmbSpecies_SelectedIndexChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            fPresenter.ChangeSelectedSpecies();
        }

        private void tabControl_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (tabControl1.SelectedIndex == 1) {
                var lv = GetControlHandler<IListView>(lvTransfers);
                ModelPresenter.FillTransfersLVPreview(lv, fPresenter.Model, fPresenter.Record);
            }
        }

        #region View interface implementation

        IComboBox IInhabitantEditorView.SpeciesCombo
        {
            get { return GetControlHandler<IComboBox>(cmbSpecies); }
        }

        ITextBox IInhabitantEditorView.NameField
        {
            get { return GetControlHandler<ITextBox>(txtName); }
        }

        ITextBox IInhabitantEditorView.NoteField
        {
            get { return GetControlHandler<ITextBox>(txtNote); }
        }

        ILabel IInhabitantEditorView.SexLabel
        {
            get { return GetControlHandler<ILabel>(lblSex); }
        }

        IComboBox IInhabitantEditorView.SexCombo
        {
            get { return GetControlHandler<IComboBox>(cmbSex); }
        }

        IComboBox IInhabitantEditorView.StateCombo
        {
            get { return GetControlHandler<IComboBox>(cmbState); }
        }

        void IInhabitantEditorView.SetImage(ItemType itemType, int itemId)
        {
            //imgViewer.SetRecord(fPresenter.Model, fPresenter.Record.Id, itemType);
        }

        #endregion
    }
}
