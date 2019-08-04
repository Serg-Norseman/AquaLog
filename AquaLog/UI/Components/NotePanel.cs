/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.UI;

namespace AquaLog.Components
{
    /// <summary>
    /// 
    /// </summary>
    public class NotePanel : ListPanel
    {
        public NotePanel()
        {
            ListView.Columns.Add("Aquarium", 120, HorizontalAlignment.Left);
            ListView.Columns.Add("PublishDate", 120, HorizontalAlignment.Left);
            ListView.Columns.Add("Content", 250, HorizontalAlignment.Left);
        }

        public override void UpdateContent()
        {
            ListView.Items.Clear();
            if (fModel == null) return;

            var records = fModel.QueryNotes();

            foreach (Note rec in records) {
                Aquarium aqm = fModel.GetRecord<Aquarium>(rec.AquariumId);
                string aqmName = (aqm == null) ? "" : aqm.Name;

                var item = new ListViewItem(aqmName);
                item.Tag = rec;
                item.SubItems.Add(rec.PublishDate.ToString());
                item.SubItems.Add(rec.Content);
                ListView.Items.Add(item);
            }
        }

        protected override void InitActions()
        {
            fActions.Add(new Action("Add", "btn_rec_new.gif", AddHandler));
            fActions.Add(new Action("Edit", "btn_rec_edit.gif", EditHandler));
            fActions.Add(new Action("Delete", "btn_rec_delete.gif", DeleteHandler));
        }

        protected override void AddHandler(object sender, EventArgs e)
        {
            Note record = new Note();

            using (var dlg = new NoteEditDlg()) {
                dlg.Model = fModel;
                dlg.Note = record;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fModel.AddRecord(record);
                    UpdateContent();
                }
            }
        }

        protected override void EditHandler(object sender, EventArgs e)
        {
            var selectedItem = ALCore.GetSelectedItem(ListView);
            if (selectedItem == null) return;

            var record = selectedItem.Tag as Note;
            if (record == null) return;

            using (var dlg = new NoteEditDlg()) {
                dlg.Model = fModel;
                dlg.Note = record;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fModel.UpdateRecord(record);
                    UpdateContent();
                }
            }
        }

        protected override void DeleteHandler(object sender, EventArgs e)
        {
            var selectedItem = ALCore.GetSelectedItem(ListView);
            if (selectedItem == null) return;

            fModel.DeleteRecord(selectedItem.Tag as Note);
            UpdateContent();
        }
    }
}
