﻿/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;
using AquaLog.UI;

namespace AquaLog.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public class TransferPanel : ListBrowser
    {
        public TransferPanel()
        {
            ListView.Columns.Add("Item", 140, HorizontalAlignment.Left);
            ListView.Columns.Add("Date", 80, HorizontalAlignment.Left);
            ListView.Columns.Add("Type", 80, HorizontalAlignment.Left);
            ListView.Columns.Add("Cause", 80, HorizontalAlignment.Right);
            ListView.Columns.Add("Source", 80, HorizontalAlignment.Left);
            ListView.Columns.Add("Target", 80, HorizontalAlignment.Left);
        }

        protected override void InitActions()
        {
            fActions.Add(new Action("Add", "btn_rec_new.gif", AddHandler));
            fActions.Add(new Action("Edit", "btn_rec_edit.gif", EditHandler));
            fActions.Add(new Action("Delete", "btn_rec_delete.gif", DeleteHandler));
        }

        public override void UpdateContent()
        {
            ListView.Items.Clear();
            if (fModel == null) return;

            var records = fModel.QueryTransfers();
            foreach (Transfer rec in records) {
                Aquarium aqmSour = fModel.GetRecord<Aquarium>(rec.SourceId);
                Aquarium aqmTarg = fModel.GetRecord<Aquarium>(rec.TargetId);

                string itName = string.Empty;
                switch (rec.ItemType) {
                    case ItemType.Aquarium:
                        break;
                    case ItemType.Fish:
                        itName = fModel.GetRecord<Fish>(rec.ItemId).Name;
                        break;
                    case ItemType.Invertebrate:
                        itName = fModel.GetRecord<Invertebrate>(rec.ItemId).Name;
                        break;
                    case ItemType.Light:
                        break;
                    case ItemType.Plant:
                        itName = fModel.GetRecord<Plant>(rec.ItemId).Name;
                        break;
                    case ItemType.Pump:
                        break;
                }

                var item = new ListViewItem(itName);
                item.Tag = rec;
                item.SubItems.Add(ALCore.GetDateStr(rec.Date));
                item.SubItems.Add(rec.Type.ToString());
                item.SubItems.Add(rec.Cause);
                item.SubItems.Add((aqmSour == null) ? string.Empty : aqmSour.Name);
                item.SubItems.Add((aqmTarg == null) ? string.Empty : aqmTarg.Name);
                ListView.Items.Add(item);
            }
        }

        protected override void AddHandler(object sender, EventArgs e)
        {
            Transfer record = new Transfer();

            using (var dlg = new TransferDlg()) {
                dlg.Model = fModel;
                dlg.Transfer = record;
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

            var record = selectedItem.Tag as Transfer;
            if (record == null) return;

            using (var dlg = new TransferDlg()) {
                dlg.Model = fModel;
                dlg.Transfer = record;
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

            fModel.DeleteRecord(selectedItem.Tag as Transfer);
            UpdateContent();
        }
    }
}