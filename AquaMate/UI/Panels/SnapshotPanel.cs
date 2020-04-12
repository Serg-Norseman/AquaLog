﻿/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Logging;
using AquaMate.UI.Dialogs;
using BSLib;

namespace AquaMate.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SnapshotPanel : ListPanel<Snapshot, SnapshotEditDlg>
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "SnapshotPanel");


        public SnapshotPanel()
        {
        }

        protected override void UpdateListView()
        {
            ListView.Clear();
            ListView.Columns.Add(Localizer.LS(LSID.Name), 120, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Date), 120, HorizontalAlignment.Left);

            var records = fModel.QuerySnapshots();
            foreach (Snapshot rec in records) {
                var item = ListView.AddItemEx(rec,
                               rec.Name,
                               ALCore.GetTimeStr(rec.Timestamp)
                           );
            }
        }

        protected override void InitActions()
        {
            AddAction("Add", LSID.Add, "btn_rec_new.gif", AddHandler);
            AddAction("Edit", LSID.Edit, "btn_rec_edit.gif", EditHandler);
            AddAction("Delete", LSID.Delete, "btn_rec_delete.gif", DeleteHandler);
            AddAction("Export", LSID.Export, "btn_excel.gif", ExportHandler);
        }

        public override void SelectionChanged(IList<Entity> records)
        {
            bool enabled = (records.Count == 1);

            SetActionEnabled("Edit", enabled);
            SetActionEnabled("Delete", enabled);
        }

        private void ExportHandler(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog()) {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                    string path = folderBrowserDialog.SelectedPath;

                    int num = ListView.Items.Count;
                    for (int i = 0; i < num; i++) {
                        ListViewItem item = ListView.Items[i];
                        try {
                            Snapshot rec = item.Tag as Snapshot;
                            var image = ALCore.ByteToImage(rec.Image);
                            string fileName = Path.Combine(path, rec.Name + ".jpg");
                            image.Save(fileName);
                        } catch (Exception ex) {
                            fLogger.WriteError("ExportHandler()", ex);
                        }
                    }
                }
            }
        }
    }
}
