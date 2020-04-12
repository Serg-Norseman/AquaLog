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
    public partial class TransferEditDlg : EditDialog<Transfer>, ITransferEditorView
    {
        private readonly TransferEditorPresenter fPresenter;

        public TransferEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            fPresenter = new TransferEditorPresenter(this);
        }

        public override void SetLocale()
        {
            Text = Localizer.LS(LSID.Transfer);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            var transferTypesList = ALData.GetNamesList<TransferType>(ALData.TransferTypes);
            cmbType.FillCombo<TransferType>(transferTypesList, true);

            lblName.Text = Localizer.LS(LSID.Item);
            lblSource.Text = Localizer.LS(LSID.SourceTank);
            lblTarget.Text = Localizer.LS(LSID.TargetTank);
            lblDate.Text = Localizer.LS(LSID.Date);
            lblType.Text = Localizer.LS(LSID.Type);
            lblCause.Text = Localizer.LS(LSID.Cause);
            lblQty.Text = Localizer.LS(LSID.Quantity);
            lblUnitPrice.Text = Localizer.LS(LSID.UnitPrice);
            lblShop.Text = Localizer.LS(LSID.Shop);
        }

        public override void SetContext(IModel model, Transfer record)
        {
            base.SetContext(model, record);
            fPresenter.SetContext(model, record);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = fPresenter.ApplyChanges() ? DialogResult.OK : DialogResult.None;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var transferType = cmbType.GetSelectedTag<TransferType>();
            fPresenter.ChangeSelectedType(transferType);
        }

        #region View interface implementation

        ITextBoxHandler ITransferEditorView.NameField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtName); }
        }

        IComboBoxHandlerEx ITransferEditorView.SourceCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbSource); }
        }

        IComboBoxHandlerEx ITransferEditorView.TargetCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbTarget); }
        }

        IDateTimeBoxHandler ITransferEditorView.DateField
        {
            get { return GetControlHandler<IDateTimeBoxHandler>(dtpDate); }
        }

        IComboBoxHandlerEx ITransferEditorView.TypeCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbType); }
        }

        ITextBoxHandler ITransferEditorView.CauseField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtCause); }
        }

        ITextBoxHandler ITransferEditorView.QuantityField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtQty); }
        }

        ITextBoxHandler ITransferEditorView.UnitPriceField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtUnitPrice); }
        }

        IComboBoxHandler ITransferEditorView.ShopCombo
        {
            get { return GetControlHandler<IComboBoxHandler>(cmbShop); }
        }

        #endregion
    }
}
