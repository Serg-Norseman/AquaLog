/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Collections.Generic;
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

                var item = ListView.AddItemEx(rec,
                               aqmName,
                               ALCore.GetTimeStr(rec.Timestamp),
                               rec.Event,
                               rec.Reminder.ToString(),
                               strType,
                               strStatus,
                               rec.Note
                           );
            }
        }

        protected override void InitActions()
        {
            AddAction("Add", LSID.Add, "btn_rec_new.gif", AddHandler);
            AddAction("Edit", LSID.Edit, "btn_rec_edit.gif", EditHandler);
            AddAction("Delete", LSID.Delete, "btn_rec_delete.gif", DeleteHandler);
        }

        public override void SelectionChanged(IList<Entity> records)
        {
            bool enabled = (records.Count == 1);

            SetActionEnabled("Edit", enabled);
            SetActionEnabled("Delete", enabled);
        }
    }
}
