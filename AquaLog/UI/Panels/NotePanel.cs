/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.UI.Dialogs;

namespace AquaLog.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public class NotePanel : ListPanel<Note, NoteEditDlg>
    {
        public NotePanel()
        {
        }

        protected override void UpdateListView()
        {
            ListView.Clear();
            ListView.Columns.Add(Localizer.LS(LSID.Aquarium), 120, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Date), 120, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Text), 250, HorizontalAlignment.Left);

            var records = fModel.QueryNotes();
            foreach (Note rec in records) {
                Aquarium aqm = fModel.GetRecord<Aquarium>(rec.AquariumId);
                string aqmName = (aqm == null) ? "" : aqm.Name;

                var item = new ListViewItem(aqmName);
                item.Tag = rec;
                item.SubItems.Add(rec.Timestamp.ToString());
                item.SubItems.Add(rec.Content);
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
