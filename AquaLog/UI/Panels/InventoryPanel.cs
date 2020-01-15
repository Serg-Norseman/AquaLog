/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;
using AquaLog.UI.Dialogs;

namespace AquaLog.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class InventoryPanel : ListPanel<Inventory, InventoryEditDlg>
    {
        public InventoryPanel()
        {
        }

        protected override void InitActions()
        {
            AddAction("Add", LSID.Add, "btn_rec_new.gif", AddHandler);
            AddAction("Edit", LSID.Edit, "btn_rec_edit.gif", EditHandler);
            AddAction("Delete", LSID.Delete, "btn_rec_delete.gif", DeleteHandler);
            AddAction("Transfer", LSID.Transfer, null, TransferHandler);
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
                string strType = Localizer.LS(ALData.InventoryTypes[(int)rec.Type]);

                var item = new ListViewItem(rec.Name);
                item.Tag = rec;
                item.SubItems.Add(rec.Brand);
                item.SubItems.Add(strType);
                item.SubItems.Add(rec.Note);
                item.SubItems.Add(Localizer.LS(ALData.ItemStates[(int)rec.State]));
                ListView.Items.Add(item);
            }
        }

        private void TransferHandler(object sender, EventArgs e)
        {
            var record = ListView.GetSelectedTag<Inventory>();
            if (record == null) return;

            ItemType itemType = ALCore.GetItemType(record.Type);

            var transfer = new Transfer();
            transfer.ItemType = itemType;
            transfer.ItemId = record.Id;

            using (var dlg = new TransferEditDlg()) {
                dlg.Model = fModel;
                dlg.Record = transfer;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fModel.AddRecord(dlg.Record);
                    UpdateContent();
                }
            }
        }
    }
}
