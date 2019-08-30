/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaLog.Components;
using AquaLog.Core.Model;
using AquaLog.UI;

namespace AquaLog.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public class InventoryPanel : ListPanel<Inventory, InventoryEditDlg>
    {
        public InventoryPanel()
        {
            ListView.Columns.Add("Name", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("Brand", 50, HorizontalAlignment.Left);
            ListView.Columns.Add("Type", 75, HorizontalAlignment.Left);
            ListView.Columns.Add("Note", 50, HorizontalAlignment.Left);
        }

        protected override void InitActions()
        {
            fActions.Add(new UserAction("Add", "btn_rec_new.gif", AddHandler));
            fActions.Add(new UserAction("Edit", "btn_rec_edit.gif", EditHandler));
            fActions.Add(new UserAction("Delete", "btn_rec_delete.gif", DeleteHandler));
        }

        protected override void UpdateListView()
        {
            var records = fModel.QueryInventory();
            foreach (Inventory rec in records) {
                var item = new ListViewItem(rec.Name);
                item.Tag = rec;
                item.SubItems.Add(rec.Brand);
                item.SubItems.Add(rec.Type.ToString());
                item.SubItems.Add(rec.Note);
                ListView.Items.Add(item);
            }
        }
    }
}
