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
    public partial class InventoryEditDlg : EditDialog, IInventoryEditorView
    {
        private readonly InventoryEditorPresenter fPresenter;

        public InventoryEditDlg()
        {
            InitializeComponent();

            fPresenter = new InventoryEditorPresenter(this);
        }

        public override void SetLocale()
        {
            base.Title = Localizer.LS(LSID.Inventory);
            btnAccept.Content = Localizer.LS(LSID.Accept);
            btnCancel.Content = Localizer.LS(LSID.Cancel);

            tabCommon.Header = Localizer.LS(LSID.Common);
            tabTransfers.Header = Localizer.LS(LSID.Transfers);

            lblName.Content = Localizer.LS(LSID.Name);
            lblBrand.Content = Localizer.LS(LSID.Brand);
            lblType.Content = Localizer.LS(LSID.Type);
            lblNote.Content = Localizer.LS(LSID.Note);
            lblState.Content = Localizer.LS(LSID.State);
        }

        public void SetContext(IModel model, Inventory record)
        {
            fPresenter.SetContext(model, record);
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = fPresenter.ApplyChanges();
        }

        private void cmbType_SelectedIndexChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            fPresenter.ChangeSelectedType();
        }

        private void tabControl_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (tabControl.SelectedIndex == 1) {
                var lv = GetControlHandler<IListView>(lvTransfers);
                ModelPresenter.FillTransfersLVPreview(lv, fPresenter.Model, fPresenter.Record, false);
            }
        }

        #region View interface implementation

        ITextBox IInventoryEditorView.NameField
        {
            get { return GetControlHandler<ITextBox>(txtName); }
        }

        IComboBox IInventoryEditorView.BrandCombo
        {
            get { return GetControlHandler<IComboBox>(cmbBrand); }
        }

        IComboBox IInventoryEditorView.TypeCombo
        {
            get { return GetControlHandler<IComboBox>(cmbType); }
        }

        ITextBox IInventoryEditorView.NoteField
        {
            get { return GetControlHandler<ITextBox>(txtNote); }
        }

        IComboBox IInventoryEditorView.StateCombo
        {
            get { return GetControlHandler<IComboBox>(cmbState); }
        }

        IPropertyGrid IInventoryEditorView.PropsGrid
        {
            get { return GetControlHandler<IPropertyGrid>(pgProps); }
        }

        #endregion
    }
}
