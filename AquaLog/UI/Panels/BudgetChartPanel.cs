/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AquaLog.Components;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;

namespace AquaLog.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public class BudgetChartPanel : DataPanel
    {
        private ZGraphControl fGraph;
        private BudgetChartType fChartType;

        public BudgetChartPanel()
        {
            fGraph = new ZGraphControl();
            fGraph.Dock = DockStyle.Fill;
            Controls.Add(fGraph);
        }

        public override void SetExtData(object extData)
        {
            fChartType = (BudgetChartType)extData;
        }

        protected override void InitActions()
        {
        }

        public override void UpdateContent()
        {
            fGraph.Clear();
            if (fModel == null) return;

            Dictionary<string, double> itemSums = new Dictionary<string, double>();

            var records = fModel.QueryExpenses();
            foreach (Transfer rec in records) {
                if (rec.Type != TransferType.Purchase) continue;
                double trnSum = (rec.Quantity * rec.UnitPrice);
                var itemRec = fModel.GetRecord(rec.ItemType, rec.ItemId);

                string key;
                switch (fChartType) {
                    case BudgetChartType.ItemTypes:
                        ItemType itType = (itemRec is Inventory) ? ALCore.GetItemType(((Inventory)itemRec).Type) : rec.ItemType; // FIXME
                        key = Localizer.LS(ALData.ItemTypes[(int)itType].Name);
                        break;
                    case BudgetChartType.Shops:
                        key = rec.Shop;
                        break;
                    case BudgetChartType.Brands:
                        var brandedItem = itemRec as IBrandedItem;
                        key = (brandedItem == null) ? "-" : brandedItem.Brand;
                        break;
                    default:
                        key = "";
                        break;
                }

                double iSum;
                if (itemSums.TryGetValue(key, out iSum)) {
                    iSum += trnSum;
                    itemSums[key] = iSum;
                } else {
                    itemSums.Add(key, trnSum);
                }
            }

            List<ChartPoint> vals = new List<ChartPoint>();
            foreach (var valPair in itemSums) {
                vals.Add(new ChartPoint(valPair.Key, valPair.Value));
            }
            fGraph.PrepareArray("Expenses", "Category", "Expenses", ChartStyle.Pie, vals, Color.Transparent);
        }
    }
}
