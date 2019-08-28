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
    public class TransferPanel : ListPanel<Transfer, TransferEditDlg>
    {
        public TransferPanel()
        {
        }

        protected override void InitActions()
        {
            fActions.Add(new UserAction("Add", "btn_rec_new.gif", AddHandler));
            fActions.Add(new UserAction("Edit", "btn_rec_edit.gif", EditHandler));
            fActions.Add(new UserAction("Delete", "btn_rec_delete.gif", DeleteHandler));
        }

        public override void UpdateContent()
        {
            ListView.Clear();
            ListView.Columns.Add(Localizer.LS(LSID.Item), 140, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Date), 80, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Type), 80, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Cause), 80, HorizontalAlignment.Right);
            ListView.Columns.Add(Localizer.LS(LSID.SourceTank), 80, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.TargetTank), 80, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Quantity), 80, HorizontalAlignment.Right);
            ListView.Columns.Add(Localizer.LS(LSID.UnitPrice), 80, HorizontalAlignment.Right);
            ListView.Columns.Add(Localizer.LS(LSID.Shop), 180, HorizontalAlignment.Left);

            var records = fModel.QueryTransfers();
            foreach (Transfer rec in records) {
                Aquarium aqmSour = fModel.GetRecord<Aquarium>(rec.SourceId);
                Aquarium aqmTarg = fModel.GetRecord<Aquarium>(rec.TargetId);

                string itName = fModel.GetRecordName(rec.ItemType, rec.ItemId);

                var item = new ListViewItem(itName);
                item.Tag = rec;
                item.SubItems.Add(ALCore.GetDateStr(rec.Date));
                item.SubItems.Add(rec.Type.ToString());
                item.SubItems.Add(rec.Cause);
                item.SubItems.Add((aqmSour == null) ? string.Empty : aqmSour.Name);
                item.SubItems.Add((aqmTarg == null) ? string.Empty : aqmTarg.Name);
                item.SubItems.Add(rec.Quantity.ToString());
                item.SubItems.Add(ALCore.GetDecimalStr(rec.UnitPrice));
                item.SubItems.Add(rec.Shop);
                ListView.Items.Add(item);
            }
        }
    }
}
