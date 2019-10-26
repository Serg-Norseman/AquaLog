/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.UI.Dialogs;

namespace AquaLog.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SchedulePanel : ListPanel<Schedule, ScheduleEditDlg>
    {
        public SchedulePanel()
        {
        }

        protected override void UpdateListView()
        {
            ListView.Clear();
            ListView.Columns.Add(Localizer.LS(LSID.Aquarium), 120, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Date), 120, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Event), 100, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Reminder), 80, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Type), 80, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Status), 80, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Note), 250, HorizontalAlignment.Left);

            var records = fModel.QuerySchedule();
            foreach (Schedule rec in records) {
                Aquarium aqm = fModel.GetRecord<Aquarium>(rec.AquariumId);
                string aqmName = (aqm == null) ? "" : aqm.Name;
                string strType = Localizer.LS(ALData.ScheduleTypes[(int)rec.Type]);
                string strStatus = Localizer.LS(ALData.TaskStatuses[(int)rec.Status]);

                var item = new ListViewItem(aqmName);
                item.Tag = rec;
                item.SubItems.Add(ALCore.GetTimeStr(rec.Timestamp));
                item.SubItems.Add(rec.Event);
                item.SubItems.Add(rec.Reminder.ToString());
                item.SubItems.Add(strType);
                item.SubItems.Add(strStatus);
                item.SubItems.Add(rec.Note);
                ListView.Items.Add(item);
            }
        }

        protected override void InitActions()
        {
            AddAction("Add", LSID.Add, "btn_rec_new.gif", AddHandler);
            AddAction("Edit", LSID.Edit, "btn_rec_edit.gif", EditHandler);
            AddAction("Delete", LSID.Delete, "btn_rec_delete.gif", DeleteHandler);
        }
    }
}
