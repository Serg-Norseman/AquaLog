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

            float[] itemTypeSums = new float[((int)ItemType.Decoration) + 1];
            var records = fModel.QueryExpenses();
            foreach (Transfer rec in records) {
                if (rec.Type != TransferType.Purchase) continue;

                int itType = (int)rec.ItemType;
                itemTypeSums[itType] += (rec.Quantity * rec.UnitPrice);
            }

            List<ChartPoint> vals = new List<ChartPoint>();
            for (int i = 0; i < itemTypeSums.Length; i++) {
                float val = itemTypeSums[i];
                if (val > 0) {
                    vals.Add(new ChartPoint(Localizer.LS(ALData.ItemTypes[i].Name), val));
                }
            }
            fGraph.PrepareArray("Expenses", "Category", "Expenses", ChartStyle.Pie, vals, Color.Transparent);
        }
    }
}
