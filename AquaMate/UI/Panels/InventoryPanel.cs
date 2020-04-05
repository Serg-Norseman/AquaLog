/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Core.Types;
using AquaMate.UI.Dialogs;

namespace AquaMate.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class InventoryPanel : ListPanel<Inventory, InventoryEditDlg>
    {
        public InventoryPanel()
        {
        }

        protected override void UpdateListView()
        {
            ListView.Clear();
            ListView.Columns.Add(Localizer.LS(LSID.Name), 100, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Brand), 50, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Type), 75, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Note), 50, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.State), 80, HorizontalAlignment.Left);

            var records = fModel.QueryInventory();
            foreach (Inventory rec in records) {
                string strType = Localizer.LS(ALData.InventoryTypes[(int)rec.Type].Name);

                ItemType itemType = ALCore.GetItemType(rec.Type);
                ItemState itemState;
                string strState = fModel.GetItemStateStr(rec.Id, itemType, out itemState);

                var item = ListView.AddItemEx(rec,
                               rec.Name,
                               rec.Brand,
                               strType,
                               rec.Note,
                               strState
                           );

                if (itemState == ItemState.Finished || itemState == ItemState.Broken) {
                    item.ForeColor = Color.Gray;
                }
            }
        }

        protected override void InitActions()
        {
            AddAction("Add", LSID.Add, "btn_rec_new.gif", AddHandler);
            AddAction("Edit", LSID.Edit, "btn_rec_edit.gif", EditHandler);
            AddAction("Delete", LSID.Delete, "btn_rec_delete.gif", DeleteHandler);
            AddAction("Transfer", LSID.Transfer, null, TransferHandler);

            // FIXME: change text
            AddAction("Transfers", LSID.Transfers, null, ViewTransfersHandler);
        }

        public override void SelectionChanged(IList<Entity> records)
        {
            bool enabled = (records.Count == 1);

            SetActionEnabled("Edit", enabled);
            SetActionEnabled("Delete", enabled);
            SetActionEnabled("Transfer", enabled);
        }

        private void TransferHandler(object sender, EventArgs e)
        {
            var record = ListView.GetSelectedTag<Inventory>();
            if (record == null) return;

            ItemType itemType = ALCore.GetItemType(record.Type);
            Browser.TransferItem(itemType, record.Id, this);
        }

        private void ViewTransfersHandler(object sender, EventArgs e)
        {
            var record = ListView.GetSelectedTag<Inventory>();
            if (record == null) return;

            ItemType itemType = ALCore.GetItemType(record.Type);
            Browser.ShowItemTransfers(itemType, record.Id);
        }
    }
}
