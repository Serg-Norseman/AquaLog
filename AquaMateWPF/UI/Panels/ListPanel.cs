/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Logging;
using AquaMate.UI.Components;
using BSLib;

namespace AquaMate.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public class ListPanel : DataPanel
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "ListPanel");

        private readonly ZListView fListView;

        public ZListView ListView
        {
            get { return fListView; }
        }


        public ListPanel()
        {
            Padding = new Thickness(10);

            fListView = UIHelper.CreateListView("ListView");
            fListView.MouseDoubleClick += EditHandler;
            fListView.SelectionChanged += ListView_SelectedIndexChanged;
            fListView.KeyDown += ListView_KeyDown;
            Content = fListView;
        }

        private void ListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) {
                EditHandler(sender, e);
            }
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

        public override void UpdateContent()
        {
            try {
                ListView.BeginUpdate();
                ListView.Items.Clear();

                if (fModel != null) {
                    UpdateListView();
                }

                ListView.EndUpdate();
            } catch (Exception ex) {
                fLogger.WriteError("UpdateContent()", ex);
            }
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
                    //ExcelExporter.Generate(fListView, fileName);
                    break;

                case ".csv":
                    //CSVExporter.Generate(fListView, fileName);
                    break;

                default:
                    return;
            }

            AppHost.LoadExtFile(fileName);
        }
    }


    public class ListPanel<R, D> : ListPanel
        where R : Entity, new()
        where D : IEditorView<R>, new()
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "ListPanel<>");

        private ContextMenu fMenu;

        public override void ProcessActions()
        {
            fMenu = new ContextMenu();
            foreach (var action in Actions) {
                if (action.Choices == null) {
                    var menuItem = new MenuItem() { Header = Localizer.LS(action.BtnText), Tag = action };
                    menuItem.Click += MenuItem_Click;
                    fMenu.Items.Add(menuItem);
                }
            }
            ListView.ContextMenu = fMenu;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            var action = (menuItem == null) ? null : menuItem.Tag as UserAction;
            if (action != null) {
                action.Click(sender, e);
            }
        }

        private void SelectRecord(R record)
        {
            if (record == null) return;

            var lvItems = ListView.Items;
            int num = lvItems.Count;
            for (int i = 0; i < num; i++) {
                ListViewItem item = lvItems[i] as ListViewItem;
                var rowData = item.Tag as R;
                if (rowData != null && rowData.Id == record.Id) {
                    ListView.SelectItem(item);
                    return;
                }
            }
        }

        protected override void AddHandler(object sender, EventArgs e)
        {
            try {
                R record = new R();

                using (var dlg = new D()) {
                    dlg.SetContext(fModel, record);

                    if (dlg.ShowModal()) {
                        fModel.AddRecord(record);
                        UpdateContent();
                        SelectRecord(record);
                    }
                }
            } catch (Exception ex) {
                fLogger.WriteError("AddHandler()", ex);
            }
        }

        protected override void EditHandler(object sender, EventArgs e)
        {
            try {
                var record = ListView.GetSelectedTag<R>();
                if (record == null) return;

                using (var dlg = new D()) {
                    dlg.SetContext(fModel, record);

                    if (dlg.ShowModal()) {
                        fModel.UpdateRecord(record);
                        UpdateContent();
                        SelectRecord(record);
                    }
                }
            } catch (Exception ex) {
                fLogger.WriteError("EditHandler()", ex);
            }
        }

        protected override void DeleteHandler(object sender, EventArgs e)
        {
            try {
                var record = ListView.GetSelectedTag<R>();
                if (record == null) return;

                if (!Browser.CheckDelete(record)) return;

                fModel.DeleteRecord(record);
                UpdateContent();
            } catch (Exception ex) {
                fLogger.WriteError("DeleteHandler()", ex);
            }
        }
    }
}
