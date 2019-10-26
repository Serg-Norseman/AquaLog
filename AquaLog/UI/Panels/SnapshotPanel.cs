/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.UI.Dialogs;

namespace AquaLog.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SnapshotPanel : ListPanel<Snapshot, SnapshotEditDlg>
    {
        public SnapshotPanel()
        {
        }

        protected override void UpdateListView()
        {
            ListView.Clear();
            ListView.Columns.Add(Localizer.LS(LSID.Name), 120, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Date), 120, HorizontalAlignment.Left);

            var records = fModel.QuerySnapshots();
            foreach (Snapshot rec in records) {
                var item = new ListViewItem(rec.Name);
                item.SubItems.Add(ALCore.GetTimeStr(rec.Timestamp));
                item.Tag = rec;
                ListView.Items.Add(item);
            }
        }

        protected override void InitActions()
        {
            AddAction("Add", LSID.Add, "btn_rec_new.gif", AddHandler);
            AddAction("Edit", LSID.Edit, "btn_rec_edit.gif", EditHandler);
            AddAction("Delete", LSID.Delete, "btn_rec_delete.gif", DeleteHandler);
        }
    }
}
