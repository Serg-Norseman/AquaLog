/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;

namespace AquaLog.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class InventoryEditDlg : Form, IEditDialog<Inventory>
    {
        private ALModel fModel;
        private Inventory fRecord;

        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public Inventory Record
        {
            get { return fRecord; }
            set {
                if (fRecord != value) {
                    fRecord = value;
                    UpdateView();
                }
            }
        }


        public InventoryEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            SetLocale();
        }

        public void SetLocale()
        {
            Text = Localizer.LS(LSID.Inventory);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            cmbType.Items.Clear();
            cmbType.Sorted = true;
            for (InventoryType type = InventoryType.Additive; type <= InventoryType.Decoration; type++) {
                cmbType.AddItem<InventoryType>(Localizer.LS(ALData.InventoryTypes[(int)type]), type);
            }

            lblName.Text = Localizer.LS(LSID.Name);
            lblBrand.Text = Localizer.LS(LSID.Brand);
            lblType.Text = Localizer.LS(LSID.Type);
            lblNote.Text = Localizer.LS(LSID.Note);
            lblState.Text = Localizer.LS(LSID.State);
        }

        private void UpdateView()
        {
            if (fRecord != null) {
                cmbBrand.Items.Clear();
                var brands = fModel.QueryInventoryBrands();
                foreach (QString bqs in brands) {
                    cmbBrand.Items.Add(bqs.element);
                }
                cmbBrand.Text = fRecord.Brand;

                txtName.Text = fRecord.Name;
                cmbType.SetSelectedTag(fRecord.Type);
                txtNote.Text = fRecord.Note;

                UIHelper.FillItemStatesCombo(cmbState, ALCore.GetItemType(fRecord.Type), fRecord.State);
            }
        }

        private void ApplyChanges()
        {
            fRecord.Name = txtName.Text;
            fRecord.Brand = cmbBrand.Text;
            fRecord.Type = cmbType.GetSelectedTag<InventoryType>();
            fRecord.Note = txtNote.Text;
            fRecord.State = cmbState.GetSelectedTag<ItemState>();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try {
                ApplyChanges();
                DialogResult = DialogResult.OK;
            } catch {
                DialogResult = DialogResult.None;
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var invType = cmbType.GetSelectedTag<InventoryType>();
            UIHelper.FillItemStatesCombo(cmbState, ALCore.GetItemType(invType), fRecord.State);
            if (invType >= 0) {
            }
        }
    }
}
