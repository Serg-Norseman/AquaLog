/*
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

namespace AquaLog.Components
{
    /// <summary>
    /// 
    /// </summary>
    public class ExpensePanel : ListBrowser
    {
        public ExpensePanel()
        {
            ListView.Columns.Add("Item", 140, HorizontalAlignment.Left);
            ListView.Columns.Add("Date", 80, HorizontalAlignment.Left);
            ListView.Columns.Add("Qty", 80, HorizontalAlignment.Right);
            ListView.Columns.Add("UnitPrice", 80, HorizontalAlignment.Right);
            ListView.Columns.Add("Sum", 80, HorizontalAlignment.Right);
            ListView.Columns.Add("Shop", 180, HorizontalAlignment.Left);
        }

        protected override void InitActions()
        {
        }

        public override void UpdateContent()
        {
            ListView.Items.Clear();
            if (fModel == null) return;

            var records = fModel.QueryExpenses();
            foreach (Transfer rec in records) {
                string itName = fModel.GetRecordName(rec.ItemType, rec.ItemId);

                int factor = 0;
                switch (rec.Type) {
                    case TransferType.Purchase:
                        factor = -1;
                        break;
                    case TransferType.Sale:
                        factor = +1;
                        break;
                }

                if (factor != 0) {
                    double sum = (rec.Quantity * rec.UnitPrice * factor);
                    var item = new ListViewItem(itName);
                    item.Tag = rec;
                    item.SubItems.Add(ALCore.GetDateStr(rec.Date));
                    item.SubItems.Add(rec.Quantity.ToString());
                    item.SubItems.Add(ALCore.GetDecimalStr(rec.UnitPrice));
                    item.SubItems.Add(ALCore.GetDecimalStr(sum));
                    item.SubItems.Add(rec.Shop);
                    ListView.Items.Add(item);
                }
            }
        }
    }
}
