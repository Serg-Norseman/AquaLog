/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.TSDB;
using AquaMate.UI.Dialogs;

namespace AquaMate.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class TSDBPanel : ListPanel
    {
        public TSDBPanel()
        {
        }

        protected override void InitActions()
        {
            AddAction("Add", LSID.Add, "btn_rec_new.gif", AddHandler);
            AddAction("Edit", LSID.Edit, "btn_rec_edit.gif", EditHandler);
            AddAction("Delete", LSID.Delete, "btn_rec_delete.gif", DeleteHandler);
            AddAction("Data", LSID.Data, "", ViewDataHandler);
            AddAction("Trend", LSID.Trend, "", ViewTrendHandler);
            AddAction("DataMonitor", LSID.DataMonitor, "", ShowMonitor);
        }

        public override void SelectionChanged(IList<Entity> records)
        {
            bool enabled = (records.Count == 1);

            SetActionEnabled("Edit", enabled);
            SetActionEnabled("Delete", enabled);

            SetActionEnabled("Data", enabled);
            SetActionEnabled("Trend", enabled);
        }

        protected override void UpdateListView()
        {
            ListView.Clear();
            ListView.Columns.Add(Localizer.LS(LSID.Name), 140, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Unit), 80, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Min), 80, HorizontalAlignment.Right);
            ListView.Columns.Add(Localizer.LS(LSID.Max), 80, HorizontalAlignment.Right);
            ListView.Columns.Add(Localizer.LS(LSID.Deviation), 80, HorizontalAlignment.Right);
            ListView.Columns.Add("SID", 140, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Value), 80, HorizontalAlignment.Right);

            TSDatabase tsdb = fModel.TSDB;
            var records = tsdb.GetPoints();
            foreach (TSPoint rec in records) {
                var item = ListView.AddItemEx(rec,
                               rec.Name,
                               rec.MeasureUnit,
                               ALCore.GetDecimalStr(rec.Min),
                               ALCore.GetDecimalStr(rec.Max),
                               ALCore.GetDecimalStr(rec.Deviation),
                               rec.SID,
                               string.Empty
                           );
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
            var record = ListView.GetSelectedTag<TSPoint>();
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
            var record = ListView.GetSelectedTag<TSPoint>();
            if (record == null) return;

            string recordName = fModel.GetEntityName(record);
            if (!UIHelper.ShowQuestionYN(string.Format(Localizer.LS(LSID.RecordDeleteQuery), recordName))) return;

            fModel.TSDB.DeletePoint(record);
            UpdateContent();
        }

        private void ViewDataHandler(object sender, EventArgs e)
        {
            var record = ListView.GetSelectedTag<TSPoint>();
            if (record == null) return;

            Browser.SetView(MainView.TSValues, record.Id);
        }

        private void ViewTrendHandler(object sender, EventArgs e)
        {
            var record = ListView.GetSelectedTag<TSPoint>();
            if (record == null) return;

            Browser.SetView(MainView.TSTrend, record.Id);
        }

        private void ShowMonitor(object sender, EventArgs e)
        {
            using (var monitor = new DataMonitor(Browser)) {
                monitor.ShowDialog();
            }
        }

        public override void TickTimer()
        {
            int num = ListView.Items.Count;
            for (int i = 0; i < num; i++) {
                ListViewItem item = ListView.Items[i];
                TSPoint point = item.Tag as TSPoint;
                if (point != null) {
                    double curValue = fModel.GetCurrentValue(point.Id);
                    string strVal = ALCore.GetDecimalStr(curValue);
                    item.SubItems[6].Text = strVal;
                }
            }
        }
    }
}
