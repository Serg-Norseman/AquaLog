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
    public class MaintenancePanel : ListPanel<Maintenance, MaintenanceEditDlg>
    {
        public MaintenancePanel()
        {
            ListView.Columns.Add("Aquarium", 120, HorizontalAlignment.Left);
            ListView.Columns.Add("DateTime", 120, HorizontalAlignment.Left);
            ListView.Columns.Add("Type", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("Value", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("Note", 250, HorizontalAlignment.Left);
        }

        public override void UpdateContent()
        {
            ListView.Items.Clear();
            if (fModel == null) return;

            var records = fModel.QueryMaintenances();

            foreach (Maintenance rec in records) {
                Aquarium aqm = fModel.GetRecord<Aquarium>(rec.AquariumId);
                string aqmName = (aqm == null) ? "" : aqm.Name;

                var item = new ListViewItem(aqmName);
                item.Tag = rec;
                item.SubItems.Add(rec.DateTime.ToString());
                item.SubItems.Add(rec.Type.ToString());
                item.SubItems.Add(ALCore.GetDecimalStr(rec.Value));
                item.SubItems.Add(rec.Note);
                ListView.Items.Add(item);
            }
        }

        protected override void InitActions()
        {
            fActions.Add(new UserAction("Add", "btn_rec_new.gif", AddHandler));
            fActions.Add(new UserAction("Edit", "btn_rec_edit.gif", EditHandler));
            fActions.Add(new UserAction("Delete", "btn_rec_delete.gif", DeleteHandler));
        }
    }
}
