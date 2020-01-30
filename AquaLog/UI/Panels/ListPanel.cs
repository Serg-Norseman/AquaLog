/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Export;
using AquaLog.Core.Model;
using AquaLog.UI.Components;
using BSLib;

namespace AquaLog.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public class ListPanel : DataPanel
    {
        private readonly ZListView fListView;

        public ZListView ListView
        {
            get { return fListView; }
        }


        public ListPanel()
        {
            Padding = new Padding(10);

            fListView = UIHelper.CreateListView("ListView");
            fListView.DoubleClick += EditHandler;
            fListView.SelectedIndexChanged += ListView_SelectedIndexChanged;
            Controls.Add(fListView);
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            IList<Entity> records = new List<Entity>();

            foreach (ListViewItem item in ListView.SelectedItems) {
                Entity rec = item.Tag as Entity;
                if (rec != null) {
                    records.Add(rec);
                }
            }

            SelectionChanged(records);
        }

        protected override void UpdateContent()
        {
            ListView.BeginUpdate();
            ListView.Items.Clear();

            if (fModel != null) {
                UpdateListView();
            }

            ListView.EndUpdate();
        }

        protected virtual void UpdateListView()
        {
        }

        protected virtual void AddHandler(object sender, EventArgs e)
        {
        }

        protected virtual void EditHandler(object sender, EventArgs e)
        {
        }

        protected virtual void DeleteHandler(object sender, EventArgs e)
        {
        }

        protected void Export()
        {
            string fileName = UIHelper.GetSaveFile("Excel files (*.xls)|*.xls|CSV files (*.csv)|*.csv");
            if (string.IsNullOrEmpty(fileName)) return;

            string ext = FileHelper.GetFileExtension(fileName);
            switch (ext) {
                case ".xls":
                    ExcelExporter.Generate(fListView, fileName);
                    break;

                case ".csv":
                    CSVExporter.Generate(fListView, fileName);
                    break;

                default:
                    return;
            }

            ALCore.LoadExtFile(fileName);
        }
    }


    public class ListPanel<R, D> : ListPanel where R : Entity, new() where D : IEditDialog<R>, new()
    {
        private void SelectRecord(R record)
        {
            if (record == null) return;

            var lvItems = ListView.Items;
            int num = lvItems.Count;
            for (int i = 0; i < num; i++) {
                ListViewItem item = lvItems[i];
                var rowData = item.Tag as R;
                if (rowData.Id == record.Id) {
                    ListView.SelectItem(item);
                    return;
                }
            }
        }

        protected override void AddHandler(object sender, EventArgs e)
        {
            R record = new R();

            using (var dlg = new D()) {
                dlg.Model = fModel;
                dlg.Record = record;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fModel.AddRecord(record);
                    UpdateContent();
                    SelectRecord(record);
                }
            }
        }

        protected override void EditHandler(object sender, EventArgs e)
        {
            var record = ListView.GetSelectedTag<R>();
            if (record == null) return;

            using (var dlg = new D()) {
                dlg.Model = fModel;
                dlg.Record = record;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fModel.UpdateRecord(record);
                    UpdateContent();
                    SelectRecord(record);
                }
            }
        }

        protected override void DeleteHandler(object sender, EventArgs e)
        {
            var record = ListView.GetSelectedTag<R>();
            if (record == null) return;

            if (!UIHelper.ShowQuestionYN(string.Format(Localizer.LS(LSID.RecordDeleteQuery), record.ToString()))) return;

            fModel.DeleteRecord(record);
            UpdateContent();
        }
    }
}
