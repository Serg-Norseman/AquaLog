/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AquaLog.Components;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;

namespace AquaLog.UI
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

            btnAccept.Image = ALCore.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = ALCore.LoadResourceImage("btn_cancel.gif");

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
                cmbType.Items.Add(new ComboItem<InventoryType>(Localizer.LS(ALCore.InventoryTypes[(int)type]), type));
            }

            lblName.Text = Localizer.LS(LSID.Name);
            lblBrand.Text = Localizer.LS(LSID.Brand);
            lblType.Text = Localizer.LS(LSID.Type);
            lblNote.Text = Localizer.LS(LSID.Note);
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
                UIHelper.SetSelectedTag(cmbType, fRecord.Type);
                txtNote.Text = fRecord.Note;
            }
        }

        private void ApplyChanges()
        {
            fRecord.Name = txtName.Text;
            fRecord.Brand = cmbBrand.Text;
            fRecord.Type = UIHelper.GetSelectedTag<InventoryType>(cmbType);
            fRecord.Note = txtNote.Text;
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
            var invType = UIHelper.GetSelectedTag<InventoryType>(cmbType);
            if (invType >= 0) {
            }
        }
    }
}
