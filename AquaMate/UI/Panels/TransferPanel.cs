/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Core.Types;
using AquaMate.UI.Dialogs;

namespace AquaMate.UI.Panels
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

        public override void SelectionChanged(IList<Entity> records)
        {
            bool enabled = (records.Count == 1);

            SetActionEnabled("Edit", enabled);
            SetActionEnabled("Delete", enabled);
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

                var item = ListView.AddItemEx(rec,
                               ALCore.GetDateStr(rec.Timestamp),
                               brand,
                               itName,
                               strType,
                               (aqmSour == null) ? string.Empty : aqmSour.Name,
                               (aqmTarg == null) ? string.Empty : aqmTarg.Name,
                               rec.Quantity.ToString(),
                               ALCore.GetDecimalStr(rec.UnitPrice),
                               rec.Shop,
                               rec.Cause
                           );

                if (itemType == ItemType.Aquarium) {
                    item.Font = boldFont;
                }

                switch (rec.Type) {
                    case TransferType.Sale:
                        item.ForeColor = Color.DimGray;
                        break;

                    case TransferType.Death:
                    case TransferType.Exclusion:
                        item.ForeColor = Color.Gray;
                        break;
                }

                // validation after format changes
                /*if (itemRec is Inventory) {
                    var inv = itemRec as Inventory;
                    var invType = ALCore.GetItemType(inv.Type);
                    if (invType != itemType) {
                        item.ForeColor = Color.Red;
                    }
                }*/
            }
        }
    }
}
