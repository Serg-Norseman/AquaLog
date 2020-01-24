﻿/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;
using AquaLog.UI.Dialogs;

namespace AquaLog.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class TransferPanel : ListPanel<Transfer, TransferEditDlg>
    {
        public TransferPanel()
        {
        }

        protected override void InitActions()
        {
            // "Add" - only from other panels
            AddAction("Edit", LSID.Edit, "btn_rec_edit.gif", EditHandler);
            AddAction("Delete", LSID.Delete, "btn_rec_delete.gif", DeleteHandler);
        }

        protected override void UpdateListView()
        {
            ListView.Clear();
            ListView.Columns.Add(Localizer.LS(LSID.Date), 80, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Brand), 50, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Item), 140, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Type), 80, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.SourceTank), 80, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.TargetTank), 80, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Quantity), 80, HorizontalAlignment.Right);
            ListView.Columns.Add(Localizer.LS(LSID.UnitPrice), 80, HorizontalAlignment.Right);
            ListView.Columns.Add(Localizer.LS(LSID.Shop), 180, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Cause), 80, HorizontalAlignment.Left);

            Font defFont = ListView.Font;
            Font boldFont = new Font(defFont, FontStyle.Bold);

            var records = fModel.QueryTransfers();
            foreach (Transfer rec in records) {
                ItemType itemType = rec.ItemType;

                Aquarium aqmSour = fModel.Cache.Get<Aquarium>(ItemType.Aquarium, rec.SourceId);
                Aquarium aqmTarg = fModel.Cache.Get<Aquarium>(ItemType.Aquarium, rec.TargetId);

                var itemRec = fModel.GetRecord(rec.ItemType, rec.ItemId);
                string itName = (itemRec == null) ? string.Empty : itemRec.ToString();
                string strType = Localizer.LS(ALData.TransferTypes[(int)rec.Type]);
                var brandedItem = itemRec as IBrandedItem;
                string brand = (brandedItem == null) ? "-" : brandedItem.Brand;
                //var stateItem = itemRec as IStateItem;
                //var state = (stateItem == null) ? ItemState.Unknown : stateItem.State;

                var item = new ListViewItem(ALCore.GetDateStr(rec.Timestamp));
                item.Tag = rec;
                item.SubItems.Add(brand);
                item.SubItems.Add(itName);
                item.SubItems.Add(strType);
                item.SubItems.Add((aqmSour == null) ? string.Empty : aqmSour.Name);
                item.SubItems.Add((aqmTarg == null) ? string.Empty : aqmTarg.Name);
                item.SubItems.Add(rec.Quantity.ToString());
                item.SubItems.Add(ALCore.GetDecimalStr(rec.UnitPrice));
                item.SubItems.Add(rec.Shop);
                item.SubItems.Add(rec.Cause);

                if (itemType == ItemType.Aquarium) {
                    item.Font = boldFont;
                }

                if (rec.Type == TransferType.Death /*|| state == ItemState.Dead || state == ItemState.Finished || state == ItemState.Broken*/) {
                    item.ForeColor = Color.Gray; // death, sale or gift?
                }

                ListView.Items.Add(item);
            }
        }
    }
}
