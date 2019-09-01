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

namespace AquaLog.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public class BudgetPanel : ListPanel
    {
        public BudgetPanel()
        {
        }

        public override void UpdateContent()
        {
            ListView.Clear();
            ListView.Columns.Add(Localizer.LS(LSID.Item), 140, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Date), 80, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Quantity), 80, HorizontalAlignment.Right);
            ListView.Columns.Add(Localizer.LS(LSID.UnitPrice), 80, HorizontalAlignment.Right);
            ListView.Columns.Add(Localizer.LS(LSID.Sum), 80, HorizontalAlignment.Right);
            ListView.Columns.Add(Localizer.LS(LSID.Shop), 180, HorizontalAlignment.Left);

            var records = fModel.QueryExpenses();
            foreach (Transfer rec in records) {
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
                    string itName = fModel.GetRecordName(rec.ItemType, rec.ItemId);
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
