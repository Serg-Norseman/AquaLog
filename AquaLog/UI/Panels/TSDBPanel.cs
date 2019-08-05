﻿/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaLog.Components;
using AquaLog.Core;
using AquaLog.DataCollection;
using AquaLog.TSDB;
using AquaLog.UI;

namespace AquaLog.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public class TSDBPanel : ListPanel
    {
        public TSDBPanel()
        {
            ListView.Columns.Add("Name", 140, HorizontalAlignment.Left);
            ListView.Columns.Add("MeasureUnit", 80, HorizontalAlignment.Left);
            ListView.Columns.Add("Min", 80, HorizontalAlignment.Right);
            ListView.Columns.Add("Max", 80, HorizontalAlignment.Right);
            ListView.Columns.Add("Deviation", 80, HorizontalAlignment.Right);
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

            TSDatabase tsdb = fModel.TSDB;

            var records = tsdb.GetPoints();
            foreach (TSPoint rec in records) {
                var item = new ListViewItem(rec.Name);
                item.Tag = rec;
                item.SubItems.Add(rec.MeasureUnit);
                item.SubItems.Add(ALCore.GetDecimalStr(rec.Min));
                item.SubItems.Add(ALCore.GetDecimalStr(rec.Max));
                item.SubItems.Add(ALCore.GetDecimalStr(rec.Deviation));
                ListView.Items.Add(item);
            }
        }

        protected override void AddHandler(object sender, EventArgs e)
        {
            TSPoint record = new TSPoint();

            using (var dlg = new TSPointEditDlg()) {
                dlg.Model = fModel.TSDB;
                dlg.Point = record;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fModel.TSDB.AddPoint(record);
                    UpdateContent();
                }
            }
        }

        protected override void EditHandler(object sender, EventArgs e)
        {
            var selectedItem = ALCore.GetSelectedItem(ListView);
            if (selectedItem == null) return;

            var record = selectedItem.Tag as TSPoint;
            if (record == null) return;

            using (var dlg = new TSPointEditDlg()) {
                dlg.Model = fModel.TSDB;
                dlg.Point = record;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fModel.TSDB.UpdatePoint(record);
                    UpdateContent();
                }
            }
        }

        protected override void DeleteHandler(object sender, EventArgs e)
        {
            var selectedItem = ALCore.GetSelectedItem(ListView);
            if (selectedItem == null) return;

            fModel.TSDB.DeletePoint(selectedItem.Tag as TSPoint);
            UpdateContent();
        }

        private void ViewDataHandler(object sender, EventArgs e)
        {
            var selectedItem = ALCore.GetSelectedItem(ListView);
            if (selectedItem == null) return;

            var record = selectedItem.Tag as TSPoint;
            if (record == null) return;

            Browser.SetView(MainView.TSValues, record.Id);
        }

        private void ViewTrendHandler(object sender, EventArgs e)
        {
            var selectedItem = ALCore.GetSelectedItem(ListView);
            if (selectedItem == null) return;

            var record = selectedItem.Tag as TSPoint;
            if (record == null) return;

            Browser.SetView(MainView.TSTrend, record.Id);
        }

        private void ShowMonitor(object sender, EventArgs e)
        {
            using (var monitor = new DataMonitor()) {
                monitor.ShowDialog();
            }
        }
    }
}