/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.UI.Dialogs;

namespace AquaLog.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public class MaintenancePanel : ListPanel<Maintenance, MaintenanceEditDlg>
    {
        public MaintenancePanel()
        {
        }

        protected override void UpdateListView()
        {
            ListView.Clear();
            ListView.Columns.Add(Localizer.LS(LSID.Aquarium), 120, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Date), 120, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Type), 100, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Value), 100, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Note), 250, HorizontalAlignment.Left);

            var records = fModel.QueryMaintenances();
            foreach (Maintenance rec in records) {
                Aquarium aqm = fModel.GetRecord<Aquarium>(rec.AquariumId);
                string aqmName = (aqm == null) ? "" : aqm.Name;
                string strType = Localizer.LS(ALData.MaintenanceTypes[(int)rec.Type]);

                var item = new ListViewItem(aqmName);
                item.Tag = rec;
                item.SubItems.Add(rec.Timestamp.ToString());
                item.SubItems.Add(strType);
                item.SubItems.Add(ALCore.GetDecimalStr(rec.Value));
                item.SubItems.Add(rec.Note);
                ListView.Items.Add(item);
            }
        }

        protected override void InitActions()
        {
            AddAction("Add", LSID.Add, "btn_rec_new.gif", AddHandler);
            AddAction("Edit", LSID.Edit, "btn_rec_edit.gif", EditHandler);
            AddAction("Delete", LSID.Delete, "btn_rec_delete.gif", DeleteHandler);
            AddAction("Export", LSID.Export, "btn_excel.gif", ExportHandler);
        }

        private void ExportHandler(object sender, EventArgs e)
        {
            Export();
        }
    }
}
