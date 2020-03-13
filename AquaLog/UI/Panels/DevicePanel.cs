/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;
using AquaLog.UI.Dialogs;

namespace AquaLog.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class DevicePanel : ListPanel<Device, DeviceEditDlg>
    {
        private readonly Label fFooter;

        public DevicePanel()
        {
            fFooter = new Label();
            fFooter.BorderStyle = BorderStyle.Fixed3D;
            fFooter.Dock = DockStyle.Bottom;
            fFooter.Font = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold, this.Font.Unit);
            fFooter.TextAlign = ContentAlignment.MiddleLeft;
            Controls.Add(fFooter);

            Controls.SetChildIndex(ListView, 0);
            Controls.SetChildIndex(fFooter, 1);
        }

        protected override void InitActions()
        {
            AddAction("Add", LSID.Add, "btn_rec_new.gif", AddHandler);
            AddAction("Edit", LSID.Edit, "btn_rec_edit.gif", EditHandler);
            AddAction("Delete", LSID.Delete, "btn_rec_delete.gif", DeleteHandler);
            AddAction("Transfer", LSID.Transfer, null, TransferHandler);

            AddAction("Data", LSID.Data, "", ViewDataHandler);
            AddAction("Trend", LSID.Trend, "", ViewTrendHandler);
        }

        public override void SelectionChanged(IList<Entity> records)
        {
            bool enabled = (records.Count == 1);

            SetActionEnabled("Edit", enabled);
            SetActionEnabled("Delete", enabled);
            SetActionEnabled("Transfer", enabled);

            SetActionEnabled("Data", enabled);
            SetActionEnabled("Trend", enabled);

            if (enabled) {
                var device = records[0] as Device;
                if (device.PointId != 0) {
                    SetActionEnabled("Transfer", false);
                }
            }
        }

        protected override void UpdateListView()
        {
            ListView.Clear();
            ListView.Columns.Add(Localizer.LS(LSID.Aquarium), 200, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Name), 100, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Brand), 50, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Type), 100, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Enabled), 60, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Digital), 60, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Power), 100, HorizontalAlignment.Right);
            ListView.Columns.Add(Localizer.LS(LSID.WorkTime), 100, HorizontalAlignment.Right);
            ListView.Columns.Add(Localizer.LS(LSID.State), 80, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Value), 80, HorizontalAlignment.Right);

            double totalPow = 0.0d;
            var records = fModel.QueryDevices();
            foreach (Device rec in records) {
                Aquarium aqm = fModel.GetRecord<Aquarium>(rec.AquariumId);
                string aqmName = (aqm == null) ? "" : aqm.Name;
                string strType = Localizer.LS(ALData.DeviceProps[(int)rec.Type].Text);

                ItemState itemState;
                string strState = fModel.GetItemStateStr(rec.Id, ItemType.Device, out itemState);

                var item = ListView.AddItemEx(rec,
                               aqmName,
                               rec.Name,
                               rec.Brand,
                               strType,
                               rec.Enabled.ToString(),
                               rec.Digital.ToString(),
                               ALCore.GetDecimalStr(rec.Power),
                               ALCore.GetDecimalStr(rec.WorkTime),
                               strState,
                               string.Empty
                           );

                if (rec.Enabled) {
                    totalPow += (rec.Power /* W/h */ * rec.WorkTime /* h/day */);
                }

                if (itemState == ItemState.Broken) {
                    item.ForeColor = Color.Gray;
                }
            }

            totalPow /= 1000.0d;
            double electricCost = totalPow * ALData.kWhCost;
            fFooter.Text = string.Format(Localizer.LS(LSID.PowerFooter), totalPow, electricCost);
        }

        public override void TickTimer()
        {
            int num = ListView.Items.Count;
            for (int i = 0; i < num; i++) {
                ListViewItem item = ListView.Items[i];
                Device device = item.Tag as Device;
                if (device != null) {
                    double curValue = fModel.GetCurrentValue(device.PointId);
                    string strVal = ALCore.GetDecimalStr(curValue);
                    item.SubItems[9].Text = strVal;
                }
            }
        }

        private void ViewDataHandler(object sender, EventArgs e)
        {
            var device = ListView.GetSelectedTag<Device>();
            if (device == null || device.PointId == 0) return;

            Browser.SetView(MainView.TSValues, device.PointId);
        }

        private void ViewTrendHandler(object sender, EventArgs e)
        {
            var device = ListView.GetSelectedTag<Device>();
            if (device == null || device.PointId == 0) return;

            Browser.SetView(MainView.TSTrend, device.PointId);
        }

        private void TransferHandler(object sender, EventArgs e)
        {
            var record = ListView.GetSelectedTag<Device>();
            if (record == null) return;

            ItemType itemType = ItemType.Device;
            Browser.TransferItem(itemType, record.Id, this);
        }
    }
}
