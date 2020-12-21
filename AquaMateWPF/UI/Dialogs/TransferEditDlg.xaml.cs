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
    public partial class TransferEditDlg : EditDialog, ITransferEditorView
    {
        private readonly TransferEditorPresenter fPresenter;

        public TransferEditDlg()
        {
            InitializeComponent();

            fPresenter = new TransferEditorPresenter(this);
        }

        public override void SetLocale()
        {
            base.Title = Localizer.LS(LSID.Transfer);
            btnAccept.Content = Localizer.LS(LSID.Accept);
            btnCancel.Content = Localizer.LS(LSID.Cancel);

            lblName.Content = Localizer.LS(LSID.Item);
            lblSource.Content = Localizer.LS(LSID.SourceTank);
            lblTarget.Content = Localizer.LS(LSID.TargetTank);
            lblDate.Content = Localizer.LS(LSID.Date);
            lblType.Content = Localizer.LS(LSID.Type);
            lblCause.Content = Localizer.LS(LSID.Cause);
            lblQty.Content = Localizer.LS(LSID.Quantity);
            lblUnitPrice.Content = Localizer.LS(LSID.UnitPrice);
            lblShop.Content = Localizer.LS(LSID.Shop);
        }

        public void SetContext(IModel model, Transfer record)
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

        /*private void cmbAquarium_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back) {
                var comboBox = sender as ComboBox;
                if (comboBox != null) {
                    comboBox.SelectedItem = null;
                }
            }
        }*/

        #region View interface implementation

        ITextBox ITransferEditorView.NameField
        {
            get { return GetControlHandler<ITextBox>(txtName); }
        }

        IComboBox ITransferEditorView.SourceCombo
        {
            get { return GetControlHandler<IComboBox>(cmbSource); }
        }

        IComboBox ITransferEditorView.TargetCombo
        {
            get { return GetControlHandler<IComboBox>(cmbTarget); }
        }

        IDateTimeBox ITransferEditorView.DateField
        {
            get { return GetControlHandler<IDateTimeBox>(dtpDate); }
        }

        IComboBox ITransferEditorView.TypeCombo
        {
            get { return GetControlHandler<IComboBox>(cmbType); }
        }

        ITextBox ITransferEditorView.CauseField
        {
            get { return GetControlHandler<ITextBox>(txtCause); }
        }

        ITextBox ITransferEditorView.QuantityField
        {
            get { return GetControlHandler<ITextBox>(txtQty); }
        }

        ITextBox ITransferEditorView.UnitPriceField
        {
            get { return GetControlHandler<ITextBox>(txtUnitPrice); }
        }

        IComboBox ITransferEditorView.ShopCombo
        {
            get { return GetControlHandler<IComboBox>(cmbShop); }
        }

        #endregion
    }
}
