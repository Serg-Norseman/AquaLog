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
using AquaLog.DataCollection;
using AquaLog.UI;

namespace AquaLog.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public class DevicePanel : ListPanel
    {
        public DevicePanel()
        {
            ListView.Columns.Add("Aquarium", 200, HorizontalAlignment.Left);
            ListView.Columns.Add("Name", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("Enabled", 60, HorizontalAlignment.Left);
            ListView.Columns.Add("Digital", 60, HorizontalAlignment.Left);
            ListView.Columns.Add("Brand", 50, HorizontalAlignment.Left);
            ListView.Columns.Add("Wattage", 100, HorizontalAlignment.Right);
        }

        protected override void InitActions()
        {
            fActions.Add(new UserAction("Add", "btn_rec_new.gif", AddHandler));
            fActions.Add(new UserAction("Edit", "btn_rec_edit.gif", EditHandler));
            fActions.Add(new UserAction("Delete", "btn_rec_delete.gif", DeleteHandler));

            fActions.Add(new UserAction("Data", "", ViewDataHandler));
            fActions.Add(new UserAction("Trend", "", ViewTrendHandler));
            fActions.Add(new UserAction("Data Monitor", "", ShowMonitor));
        }

        public override void UpdateContent()
        {
            ListView.Items.Clear();
            if (fModel == null) return;

            var records = fModel.QueryDevices();
            foreach (Device rec in records) {
                Aquarium aqm = fModel.GetRecord<Aquarium>(rec.AquariumId);
                string aqmName = (aqm == null) ? "" : aqm.Name;

                var item = new ListViewItem(aqmName);
                item.Tag = rec;
                item.SubItems.Add(rec.Name);
                item.SubItems.Add(rec.Enabled.ToString());
                item.SubItems.Add(rec.Digital.ToString());
                item.SubItems.Add(rec.Brand);
                item.SubItems.Add(ALCore.GetDecimalStr(rec.Wattage));
                ListView.Items.Add(item);
            }
        }

        protected override void AddHandler(object sender, EventArgs e)
        {
            Device record = new Device();

            using (var dlg = new DeviceEditDlg()) {
                dlg.Model = fModel;
                dlg.Device = record;
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

            var record = selectedItem.Tag as Device;
            if (record == null) return;

            using (var dlg = new DeviceEditDlg()) {
                dlg.Model = fModel;
                dlg.Device = record;
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

            fModel.DeleteRecord(selectedItem.Tag as Device);
            UpdateContent();
        }


        private void ViewDataHandler(object sender, EventArgs e)
        {
            var selectedItem = ALCore.GetSelectedItem(ListView);
            if (selectedItem == null) return;

            var device = selectedItem.Tag as Device;
            if (device == null || device.PointId == 0) return;

            Browser.SetView(MainView.TSValues, device.PointId);
        }

        private void ViewTrendHandler(object sender, EventArgs e)
        {
            var selectedItem = ALCore.GetSelectedItem(ListView);
            if (selectedItem == null) return;

            var device = selectedItem.Tag as Device;
            if (device == null || device.PointId == 0) return;

            Browser.SetView(MainView.TSTrend, device.PointId);
        }

        private void ShowMonitor(object sender, EventArgs e)
        {
            using (var monitor = new DataMonitor()) {
                monitor.ShowDialog();
            }
        }
    }
}
