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
    public class MeasurePanel : ListPanel
    {
        public MeasurePanel()
        {
            ListView.Columns.Add("Aquarium", 120, HorizontalAlignment.Left);
            ListView.Columns.Add("Timestamp", 120, HorizontalAlignment.Left);
            ListView.Columns.Add("Temp (°C)", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("NO3 (mg/l)", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("NO2 (mg/l)", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("GH (°d)", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("KH (°d)", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("pH", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("Cl2 (mg/l)", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("CO2", 60, HorizontalAlignment.Right);
        }

        public override void UpdateContent()
        {
            ListView.Items.Clear();
            if (fModel == null) return;

            var records = fModel.QueryMeasures();

            foreach (Measure rec in records) {
                Aquarium aqm = fModel.GetRecord<Aquarium>(rec.AquariumId);
                string aqmName = (aqm == null) ? "" : aqm.Name;

                var item = new ListViewItem(aqmName);
                item.Tag = rec;
                item.SubItems.Add(rec.Timestamp.ToString());
                item.SubItems.Add(ALCore.GetDecimalStr(rec.Temperature, 2, true));
                item.SubItems.Add(ALCore.GetDecimalStr(rec.NO3, 2, true));
                item.SubItems.Add(ALCore.GetDecimalStr(rec.NO2, 2, true));
                item.SubItems.Add(ALCore.GetDecimalStr(rec.GH, 2, true));
                item.SubItems.Add(ALCore.GetDecimalStr(rec.KH, 2, true));
                item.SubItems.Add(ALCore.GetDecimalStr(rec.pH, 2, true));
                item.SubItems.Add(ALCore.GetDecimalStr(rec.Cl2, 2, true));
                item.SubItems.Add(ALCore.GetDecimalStr(rec.CO2, 2, true));
                ListView.Items.Add(item);
            }
        }

        protected override void InitActions()
        {
            fActions.Add(new UserAction("Add", "btn_rec_new.gif", AddHandler));
            fActions.Add(new UserAction("Edit", "btn_rec_edit.gif", EditHandler));
            fActions.Add(new UserAction("Delete", "btn_rec_delete.gif", DeleteHandler));
        }

        protected override void AddHandler(object sender, EventArgs e)
        {
            Measure record = new Measure();

            using (var dlg = new MeasureEditDlg()) {
                dlg.Model = fModel;
                dlg.Measure = record;
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

            var record = selectedItem.Tag as Measure;
            if (record == null) return;

            using (var dlg = new MeasureEditDlg()) {
                dlg.Model = fModel;
                dlg.Measure = record;
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

            fModel.DeleteRecord(selectedItem.Tag as Measure);
            UpdateContent();
        }
    }
}
