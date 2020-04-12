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
    public partial class InventoryEditDlg : EditDialog<Inventory>, IInventoryEditorView
    {
        private readonly InventoryEditorPresenter fPresenter;

        public InventoryEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            fPresenter = new InventoryEditorPresenter(this);
        }

        public override void SetLocale()
        {
            Text = Localizer.LS(LSID.Inventory);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            var inventoryTypesList = ALData.GetNamesList<InventoryType>(ALData.InventoryTypes);
            cmbType.FillCombo<InventoryType>(inventoryTypesList, true);

            lblName.Text = Localizer.LS(LSID.Name);
            lblBrand.Text = Localizer.LS(LSID.Brand);
            lblType.Text = Localizer.LS(LSID.Type);
            lblNote.Text = Localizer.LS(LSID.Note);
            lblState.Text = Localizer.LS(LSID.State);
        }

        public override void SetContext(IModel model, Inventory record)
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
            var invType = cmbType.GetSelectedTag<InventoryType>();
            fPresenter.ChangeSelectedType(invType);
        }

        #region View interface implementation

        ITextBoxHandler IInventoryEditorView.NameField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtName); }
        }

        IComboBoxHandlerEx IInventoryEditorView.BrandCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbBrand); }
        }

        IComboBoxHandlerEx IInventoryEditorView.TypeCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbType); }
        }

        ITextBoxHandler IInventoryEditorView.NoteField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtNote); }
        }

        IComboBoxHandlerEx IInventoryEditorView.StateCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbState); }
        }

        IPropertyGridHandler IInventoryEditorView.PropsGrid
        {
            get { return GetControlHandler<IPropertyGridHandler>(pgProps); }
        }

        #endregion
    }
}
