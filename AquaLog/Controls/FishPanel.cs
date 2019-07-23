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
    public class FishPanel : Browser
    {
        private readonly ListView fListView;


        public FishPanel() : base()
        {
            Padding = new Padding(10);

            fListView = new ListView();
            fListView.Dock = DockStyle.Fill;
            fListView.HideSelection = false;
            fListView.LabelEdit = false;
            fListView.FullRowSelect = true;
            fListView.View = View.Details;
            Controls.Add(fListView);

            fListView.Columns.Add("Name", 200, HorizontalAlignment.Left);
            //fListView.Columns.Add("ScientificName", 200, HorizontalAlignment.Left);
            fListView.Columns.Add("Sex", 50, HorizontalAlignment.Left);
            fListView.Columns.Add("Qty", 50, HorizontalAlignment.Right);
            fListView.Columns.Add("Species", 150, HorizontalAlignment.Left);
        }

        protected override void InitActions()
        {
            fActions.Add(new Action("Add Fish", "btn_rec_new.gif", btnAddRecord_Click));
            fActions.Add(new Action("Edit Fish", "btn_rec_edit.gif", btnEditRecord_Click));
            fActions.Add(new Action("Delete Fish", "btn_rec_delete.gif", btnDeleteRecord_Click));
        }

        public override void UpdateContent()
        {
            fListView.Items.Clear();
            if (fModel == null) return;

            var records = fModel.QueryFishes();
            foreach (Fish rec in records) {
                Species spc = fModel.GetRecord<Species>(rec.SpeciesId);

                var item = new ListViewItem(rec.Name);
                //item.SubItems.Add(rec.ScientificName);
                item.SubItems.Add(rec.Sex.ToString());
                item.SubItems.Add(rec.Quantity.ToString());
                item.SubItems.Add(spc.Name);
                item.Tag = rec;
                fListView.Items.Add(item);
            }
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            var fish = new Fish();

            using (var dlg = new FishEditDlg()) {
                dlg.Model = fModel;
                dlg.Fish = fish;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fModel.AddRecord(fish);
                    UpdateContent();
                }
            }
        }

        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            var selectedItem = ALCore.GetSelectedItem(fListView);
            if (selectedItem == null) return;

            var fish = selectedItem.Tag as Fish;
            if (fish == null) return;

            using (var dlg = new FishEditDlg()) {
                dlg.Model = fModel;
                dlg.Fish = fish;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fModel.UpdateRecord(fish);
                    UpdateContent();
                }
            }
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            var selectedItem = ALCore.GetSelectedItem(fListView);
            if (selectedItem == null) return;

            fModel.DeleteRecord(selectedItem.Tag as Fish);
            UpdateContent();
        }
    }
}
