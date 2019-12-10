/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
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
    public sealed class BudgetPanel : ListPanel
    {
        private readonly Label fFooter;

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

            Font defFont = ListView.Font;
            Font boldFont = new Font(defFont, FontStyle.Bold);

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
                    ItemType itemType = rec.ItemType;
                    var itemRec = fModel.GetRecord(itemType, rec.ItemId);
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

                    if (itemType == ItemType.Aquarium) {
                        item.Font = boldFont;
                    }

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
            var chartData = GetChartData(BudgetChartType.ItemTypes);
            Browser.SetView(MainView.PieChart, chartData);
        }

        private void ViewChartShopsHandler(object sender, EventArgs e)
        {
            var chartData = GetChartData(BudgetChartType.Shops);
            Browser.SetView(MainView.PieChart, chartData);
        }

        private void ViewChartBrandsHandler(object sender, EventArgs e)
        {
            var chartData = GetChartData(BudgetChartType.Brands);
            Browser.SetView(MainView.PieChart, chartData);
        }

        private Dictionary<string, double> GetChartData(BudgetChartType chartType)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();

            var records = fModel.QueryExpenses();
            foreach (Transfer rec in records) {
                if (rec.Type != TransferType.Purchase) continue;
                double trnSum = (rec.Quantity * rec.UnitPrice);
                var itemRec = fModel.GetRecord(rec.ItemType, rec.ItemId);

                string key;
                switch (chartType) {
                    case BudgetChartType.ItemTypes:
                        Inventory inventRec = itemRec as Inventory;
                        ItemType itType = (inventRec != null) ? ALCore.GetItemType(inventRec.Type) : rec.ItemType;
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

                if (string.IsNullOrEmpty(key)) {
                    key = string.Empty;
                }

                double iSum;
                if (result.TryGetValue(key, out iSum)) {
                    iSum += trnSum;
                    result[key] = iSum;
                } else {
                    result.Add(key, trnSum);
                }
            }

            return result;
        }
    }
}
