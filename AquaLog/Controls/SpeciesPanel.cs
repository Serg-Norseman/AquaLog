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

namespace AquaLog.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public class SpeciesPanel : ListBrowser
    {
        public SpeciesPanel() : base()
        {
            ListView.Columns.Add("Name", 200, HorizontalAlignment.Left);
            ListView.Columns.Add("ScientificName", 200, HorizontalAlignment.Left);
            ListView.Columns.Add("Type", 100, HorizontalAlignment.Left);
        }

        protected override void InitActions()
        {
            fActions.Add(new Action("Add Species", "btn_rec_new.gif", btnAddRecord_Click));
            fActions.Add(new Action("Edit Species", "btn_rec_edit.gif", btnEditRecord_Click));
            fActions.Add(new Action("Delete Species", "btn_rec_delete.gif", btnDeleteRecord_Click));
        }

        public override void UpdateContent()
        {
            ListView.Items.Clear();
            if (fModel == null) return;

            var records = fModel.QuerySpecies();
            foreach (Species rec in records) {
                var item = new ListViewItem(rec.Name);
                item.SubItems.Add(rec.ScientificName);
                item.SubItems.Add(rec.Type.ToString());
                item.Tag = rec;
                ListView.Items.Add(item);
            }
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
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

        private void btnEditRecord_Click(object sender, EventArgs e)
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

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            var selectedItem = ALCore.GetSelectedItem(ListView);
            if (selectedItem == null) return;

            fModel.DeleteRecord(selectedItem.Tag as Species);
            UpdateContent();
        }
    }
}
