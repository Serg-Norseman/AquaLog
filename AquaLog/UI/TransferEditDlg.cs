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

namespace AquaLog.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TransferEditDlg : Form
    {
        private ALModel fModel;
        private Transfer fTransfer;

        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public Transfer Transfer
        {
            get { return fTransfer; }
            set {
                if (fTransfer != value) {
                    fTransfer = value;
                    UpdateView();
                }
            }
        }


        public TransferEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = ALCore.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = ALCore.LoadResourceImage("btn_cancel.gif");

            for (TransferType type = TransferType.Relocation; type <= TransferType.Death; type++) {
                cmbType.Items.Add(type.ToString());
            }
        }

        private void UpdateView()
        {
            if (fTransfer != null) {
                string itName = fModel.GetRecordName(fTransfer.ItemType, fTransfer.ItemId);
                txtName.Text = itName;

                if (fTransfer.Id == 0) {
                    IList<Transfer> lastTransfers = fModel.QueryLastTransfers(fTransfer.ItemId, (int)fTransfer.ItemType);
                    if (lastTransfers.Count > 0) {
                        fTransfer.SourceId = lastTransfers[0].TargetId;
                    }
                }

                cmbTarget.Items.Clear();
                var aquariums = fModel.QueryAquariums();
                foreach (var aqm in aquariums) {
                    cmbSource.Items.Add(aqm);

                    if (aqm.Id != fTransfer.SourceId) {
                        cmbTarget.Items.Add(aqm);
                    }
                }

                cmbSource.SelectedItem = aquariums.FirstOrDefault(aqm => aqm.Id == fTransfer.SourceId);
                cmbTarget.SelectedItem = aquariums.FirstOrDefault(aqm => aqm.Id == fTransfer.TargetId);

                if (!fTransfer.Date.Equals(ALCore.ZeroDate)) {
                    dtpDate.Value = fTransfer.Date;
                }

                cmbType.SelectedIndex = (int)fTransfer.Type;
                txtCause.Text = fTransfer.Cause;

                txtQty.Text = fTransfer.Quantity.ToString();
                if (fTransfer.Type == TransferType.Purchase || fTransfer.Type == TransferType.Sale) {
                    txtUnitPrice.Text = ALCore.GetDecimalStr(fTransfer.UnitPrice);

                    cmbShop.Items.Clear();
                    var shops = fModel.QueryShops();
                    foreach (var shp in shops) {
                        if (!string.IsNullOrEmpty(shp.element)) {
                            cmbShop.Items.Add(shp.element);
                        }
                    }

                    cmbShop.Text = fTransfer.Shop;
                }
            }
        }

        private void ApplyChanges()
        {
            Aquarium aqm = cmbSource.SelectedItem as Aquarium;
            fTransfer.SourceId = (aqm == null) ? 0 : aqm.Id;

            aqm = cmbTarget.SelectedItem as Aquarium;
            fTransfer.TargetId = (aqm == null) ? 0 : aqm.Id;

            //fTransfer.ItemId = fInhabitant.Id;
            //fTransfer.ItemType = ALCore.GetItemType(fInhabitant.GetSpeciesType());
            fTransfer.Date = dtpDate.Value;
            fTransfer.Type = (TransferType)cmbType.SelectedIndex;
            fTransfer.Cause = txtCause.Text;

            fTransfer.Quantity = int.Parse(txtQty.Text);
            if (fTransfer.Type == TransferType.Purchase || fTransfer.Type == TransferType.Sale) {
                fTransfer.UnitPrice = (float)ALCore.GetDecimalVal(txtUnitPrice.Text);
                fTransfer.Shop = cmbShop.Text;
            }
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
            var transferType = (TransferType)cmbType.SelectedIndex;

            bool ps = transferType == TransferType.Purchase || transferType == TransferType.Sale;
            txtUnitPrice.Enabled = ps;
            cmbShop.Enabled = ps;
            if (ps) {
                txtUnitPrice.Text = ALCore.GetDecimalStr(fTransfer.UnitPrice);
                cmbShop.Text = fTransfer.Shop;
            } else {
                txtUnitPrice.Text = "";
                cmbShop.Text = "";
            }
        }
    }
}
