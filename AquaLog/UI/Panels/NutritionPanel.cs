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
    public class NutritionPanel : ListPanel
    {
        public NutritionPanel()
        {
            ListView.Columns.Add("Aquarium", 200, HorizontalAlignment.Left);
            ListView.Columns.Add("Name", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("Brand", 50, HorizontalAlignment.Left);
            ListView.Columns.Add("Amount", 100, HorizontalAlignment.Right);
            ListView.Columns.Add("Note", 80, HorizontalAlignment.Left);
            ListView.Columns.Add("Inhabitant", 80, HorizontalAlignment.Left);
        }

        protected override void InitActions()
        {
            fActions.Add(new UserAction("Add", "btn_rec_new.gif", AddHandler));
            fActions.Add(new UserAction("Edit", "btn_rec_edit.gif", EditHandler));
            fActions.Add(new UserAction("Delete", "btn_rec_delete.gif", DeleteHandler));
        }

        protected override void UpdateListView()
        {
            var records = fModel.QueryNutritions();
            foreach (Nutrition rec in records) {
                Aquarium aqm = fModel.GetRecord<Aquarium>(rec.AquariumId);
                string aqmName = (aqm == null) ? "" : aqm.Name;

                Inhabitant inhab = fModel.GetRecord<Inhabitant>(rec.InhabitantId);
                string inhabName = (inhab == null) ? "" : inhab.Name;

                var item = new ListViewItem(aqmName);
                item.Tag = rec;
                item.SubItems.Add(rec.Name);
                item.SubItems.Add(rec.Brand);
                item.SubItems.Add(ALCore.GetDecimalStr(rec.Amount));
                item.SubItems.Add(rec.Note);
                item.SubItems.Add(inhabName);
                ListView.Items.Add(item);
            }
        }

        protected override void AddHandler(object sender, EventArgs e)
        {
            Nutrition record = new Nutrition();

            using (var dlg = new NutritionEditDlg()) {
                dlg.Model = fModel;
                dlg.Nutrition = record;
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

            var record = selectedItem.Tag as Nutrition;
            if (record == null) return;

            using (var dlg = new NutritionEditDlg()) {
                dlg.Model = fModel;
                dlg.Nutrition = record;
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

            fModel.DeleteRecord(selectedItem.Tag as Nutrition);
            UpdateContent();
        }
    }
}
