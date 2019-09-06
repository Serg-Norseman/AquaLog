/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;

namespace AquaLog.UI.Panels
{
    public enum BudgetChartType
    {
        AllCategories,
        EnlargedCategories,
    }

    /// <summary>
    /// 
    /// </summary>
    public class BudgetPanel : ListPanel
    {
        private Label fFooter;

        public BudgetPanel()
        {
            fFooter = new Label();
            fFooter.BorderStyle = BorderStyle.Fixed3D;
            fFooter.Dock = DockStyle.Bottom;
            fFooter.Font = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold, this.Font.Unit);
            fFooter.TextAlign = ContentAlignment.MiddleLeft;
            Controls.Add(fFooter);

            Controls.SetChildIndex(ListView, 0);
            Controls.SetChildIndex(fFooter, 1);
        }

        protected override void InitActions()
        {
            AddAction("Chart", LSID.Chart, "", ViewChartHandler);
        }

        protected override void UpdateListView()
        {
            ListView.Clear();
            ListView.Columns.Add(Localizer.LS(LSID.Date), 80, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Type), 80, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Item), 140, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Quantity), 80, HorizontalAlignment.Right);
            ListView.Columns.Add(Localizer.LS(LSID.UnitPrice), 80, HorizontalAlignment.Right);
            ListView.Columns.Add(Localizer.LS(LSID.Sum), 80, HorizontalAlignment.Right);
            ListView.Columns.Add(Localizer.LS(LSID.Shop), 180, HorizontalAlignment.Left);

            double totalSum = 0.0d, expenses = 0.0d, incomes = 0.0d;
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
                    double sum = rec.Quantity * rec.UnitPrice;
                    if (factor > 0) {
                        incomes += sum;
                    } else {
                        expenses += sum;
                    }
                    sum *= factor;

                    var item = new ListViewItem(ALCore.GetDateStr(rec.Date));
                    item.Tag = rec;
                    item.SubItems.Add(Localizer.LS(ALData.ItemTypes[(int)rec.ItemType].Name));
                    item.SubItems.Add(itName);
                    item.SubItems.Add(rec.Quantity.ToString());
                    item.SubItems.Add(ALCore.GetDecimalStr(rec.UnitPrice));
                    item.SubItems.Add(ALCore.GetDecimalStr(sum));
                    item.SubItems.Add(rec.Shop);
                    ListView.Items.Add(item);

                    totalSum += sum;
                }
            }

            fFooter.Text = string.Format(Localizer.LS(LSID.BalanceStr), expenses, incomes, totalSum);
        }

        private void ViewChartHandler(object sender, EventArgs e)
        {
            Browser.SetView(MainView.BudgetChartPanel, BudgetChartType.AllCategories);
        }
    }
}
