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
        ItemTypes,
        Shops,
        Brands,
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
            AddAction("ChartTypes", LSID.ChartItemTypes, "", ViewChartTypesHandler);
            AddAction("ChartShops", LSID.ChartShops, "", ViewChartShopsHandler);
            AddAction("ChartBrands", LSID.ChartBrands, "", ViewChartBrandsHandler);
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
            ListView.Columns.Add(Localizer.LS(LSID.State), 80, HorizontalAlignment.Left);

            DateTime firstDate = ALCore.ZeroDate, lastDate = DateTime.Now.Date;
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
                    var itemRec = fModel.GetRecord(rec.ItemType, rec.ItemId);
                    string itName = (itemRec == null) ? string.Empty : itemRec.ToString();
                    ItemState itState = (itemRec is IStateItem) ? ((IStateItem)itemRec).State : ItemState.Unknown;
                    string stateStr = Localizer.LS(ALData.ItemStates[(int)itState]);

                    double sum = rec.Quantity * rec.UnitPrice;
                    if (factor > 0) {
                        incomes += sum;
                    } else {
                        expenses += sum;
                    }
                    sum *= factor;

                    var item = new ListViewItem(ALCore.GetDateStr(rec.Timestamp));
                    item.Tag = rec;
                    item.SubItems.Add(Localizer.LS(ALData.ItemTypes[(int)rec.ItemType].Name));
                    item.SubItems.Add(itName);
                    item.SubItems.Add(rec.Quantity.ToString());
                    item.SubItems.Add(ALCore.GetDecimalStr(rec.UnitPrice));
                    item.SubItems.Add(ALCore.GetDecimalStr(sum));
                    item.SubItems.Add(rec.Shop);
                    item.SubItems.Add(stateStr);
                    ListView.Items.Add(item);

                    totalSum += sum;

                    if (firstDate.Equals(ALCore.ZeroDate)) {
                        firstDate = rec.Timestamp;
                    }
                }
            }

            double days = (lastDate - firstDate).TotalDays;
            double avgExpense = expenses / days;
            fFooter.Text = string.Format(Localizer.LS(LSID.BalanceFooter), expenses, avgExpense, incomes, totalSum);
        }

        private void ViewChartTypesHandler(object sender, EventArgs e)
        {
            Browser.SetView(MainView.BudgetChart, BudgetChartType.ItemTypes);
        }

        private void ViewChartShopsHandler(object sender, EventArgs e)
        {
            Browser.SetView(MainView.BudgetChart, BudgetChartType.Shops);
        }

        private void ViewChartBrandsHandler(object sender, EventArgs e)
        {
            Browser.SetView(MainView.BudgetChart, BudgetChartType.Brands);
        }
    }
}
