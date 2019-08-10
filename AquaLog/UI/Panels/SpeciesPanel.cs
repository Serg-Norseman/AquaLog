/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaLog.Components;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.UI;

namespace AquaLog.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public class SpeciesPanel : ListPanel
    {
        public SpeciesPanel() : base()
        {
            ListView.Columns.Add("Name", 200, HorizontalAlignment.Left);
            ListView.Columns.Add("ScientificName", 200, HorizontalAlignment.Left);
            ListView.Columns.Add("Type", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("Temp", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("PH", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("GH", 100, HorizontalAlignment.Left);
        }

        protected override void InitActions()
        {
            fActions.Add(new UserAction("Add Species", "btn_rec_new.gif", AddHandler));
            fActions.Add(new UserAction("Edit Species", "btn_rec_edit.gif", EditHandler));
            fActions.Add(new UserAction("Delete Species", "btn_rec_delete.gif", DeleteHandler));
        }

        protected override void UpdateListView()
        {
            var records = fModel.QuerySpecies();
            foreach (Species rec in records) {
                var item = new ListViewItem(rec.Name);
                item.SubItems.Add(rec.ScientificName);
                item.SubItems.Add(rec.Type.ToString());
                item.SubItems.Add(rec.GetTempRange());
                item.SubItems.Add(rec.GetPHRange());
                item.SubItems.Add(rec.GetGHRange());
                item.Tag = rec;
                ListView.Items.Add(item);
            }
        }

        protected override void AddHandler(object sender, EventArgs e)
        {
            var spc = new Species();

            using (var dlg = new SpeciesEditDlg()) {
                dlg.Species = spc;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fModel.AddRecord(spc);
                    UpdateContent();
                }
            }
        }

        protected override void EditHandler(object sender, EventArgs e)
        {
            var selectedItem = ALCore.GetSelectedItem(ListView);
            if (selectedItem == null) return;

            var spc = selectedItem.Tag as Species;
            if (spc == null) return;

            using (var dlg = new SpeciesEditDlg()) {
                dlg.Species = spc;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fModel.UpdateRecord(spc);
                    UpdateContent();
                }
            }
        }

        protected override void DeleteHandler(object sender, EventArgs e)
        {
            var selectedItem = ALCore.GetSelectedItem(ListView);
            if (selectedItem == null) return;

            fModel.DeleteRecord(selectedItem.Tag as Species);
            UpdateContent();
        }
    }
}
