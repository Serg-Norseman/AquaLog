/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;
using AquaLog.UI.Components;
using BSLib;

namespace AquaLog.UI.Panels
{
    public enum BudgetChartType
    {
        ItemTypes,
        Shops,
        Brands,
        Countries,
        Monthes,
        Days,
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class BudgetPanel : ListPanel
    {
        private readonly Label fFooter;
        private string fTotalFooter;

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
            AddAction("ChartCountries", LSID.ChartCountries, "", ViewChartCountriesHandler);
            AddAction("ChartMonthes", LSID.ChartMonthes, "", ViewChartMonthesHandler);
            // AddAction("ChartDays", LSID.ChartMonthes, "", ViewChartDaysHandler);
            AddAction("Brands", LSID.Brands, "", ViewBrandsHandler);
        }

        protected override void UpdateListView()
        {
            ListView.Clear();
            ListView.Columns.Add(Localizer.LS(LSID.Date), 80, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Type), 80, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Brand), 50, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Item), 140, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Quantity), 80, HorizontalAlignment.Right);
            ListView.Columns.Add(Localizer.LS(LSID.UnitPrice), 80, HorizontalAlignment.Right);
            ListView.Columns.Add(Localizer.LS(LSID.Sum), 80, HorizontalAlignment.Right);
            ListView.Columns.Add(Localizer.LS(LSID.Shop), 180, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.State), 80, HorizontalAlignment.Left);

            var records = fModel.QueryExpenses();
            fTotalFooter = ProcessRecords(records, ListView);

            CollectBrands(records);
        }

        private string ProcessRecords(IList<Transfer> records, ZListView listView)
        {
            Font defFont = ListView.Font;
            Font boldFont = new Font(defFont, FontStyle.Bold);

            DateTime firstDate = ALCore.ZeroDate, lastDate = DateTime.Now.Date;
            double totalSum = 0.0d, expenses = 0.0d, incomes = 0.0d;
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
                    double sum = rec.Quantity * rec.UnitPrice;
                    if (factor > 0) {
                        incomes += sum;
                    } else {
                        expenses += sum;
                    }
                    sum *= factor;

                    if (listView != null) {
                        ItemType itemType = rec.ItemType;
                        var itemRec = fModel.GetRecord(itemType, rec.ItemId);
                        string itName = (itemRec == null) ? string.Empty : itemRec.ToString();
                        ItemState itState = (itemRec is IStateItem) ? ((IStateItem)itemRec).State : ItemState.Unknown;
                        string stateStr = Localizer.LS(ALData.ItemStates[(int)itState]);
                        var brandedItem = itemRec as IBrandedItem;
                        string brand = (brandedItem == null) ? "-" : brandedItem.Brand;

                        var item = listView.AddItemEx(rec,
                                       ALCore.GetDateStr(rec.Timestamp),
                                       Localizer.LS(ALData.ItemTypes[(int)rec.ItemType].Name),
                                       brand,
                                       itName,
                                       rec.Quantity.ToString(),
                                       ALCore.GetDecimalStr(rec.UnitPrice),
                                       ALCore.GetDecimalStr(sum),
                                       rec.Shop,
                                       stateStr
                                   );

                        if (itemType == ItemType.Aquarium) {
                            item.Font = boldFont;
                        }
                    }

                    totalSum += sum;

                    if (ALCore.IsZeroDate(firstDate)) {
                        firstDate = rec.Timestamp;
                    }
                }
            }

            double days = (lastDate - firstDate).TotalDays;
            double avgExpense = expenses / days;
            string result = string.Format(Localizer.LS(LSID.BalanceFooter), expenses, avgExpense, incomes, totalSum);
            fFooter.Text = result;
            return result;
        }

        public override void SelectionChanged(IList<Entity> records)
        {
            if (records.Count > 1) {
                IList<Transfer> transfers = records.Cast<Transfer>().ToList();
                ProcessRecords(transfers, null);
            } else {
                fFooter.Text = fTotalFooter;
            }
        }

        private void ViewBrandsHandler(object sender, EventArgs e)
        {
            Browser.SetView(MainView.Brands, null);
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

        private void ViewChartCountriesHandler(object sender, EventArgs e)
        {
            var chartData = GetChartData(BudgetChartType.Countries);
            Browser.SetView(MainView.PieChart, chartData);
        }

        private void ViewChartMonthesHandler(object sender, EventArgs e)
        {
            var chartData = GetChartData(BudgetChartType.Monthes);
            Browser.SetView(MainView.BarChart, chartData);
        }

        private void ViewChartDaysHandler(object sender, EventArgs e)
        {
            var chartData = GetChartData(BudgetChartType.Days);
            Browser.SetView(MainView.BarChart, chartData);
        }

        private void CollectBrands(IList<Transfer> transfers)
        {
            var brandRecords = fModel.QueryBrands();

            foreach (Transfer rec in transfers) {
                var itemRec = fModel.GetRecord(rec.ItemType, rec.ItemId);
                var brandedItem = itemRec as IBrandedItem;
                string brand = (brandedItem == null) ? null : brandedItem.Brand;

                if (!string.IsNullOrEmpty(brand) && !brandRecords.Any(p => p.Name == brand)) {
                    fModel.AddRecord(new Brand(brand));
                }
            }
        }

        private IList<ChartPoint> GetChartData(BudgetChartType chartType)
        {
            Dictionary<string, ChartPoint> result = new Dictionary<string, ChartPoint>();

            IList<Brand> brandRecords = null;
            if (chartType == BudgetChartType.Countries) {
                brandRecords = fModel.QueryBrands();
            }

            var records = fModel.QueryExpenses();
            foreach (Transfer rec in records) {
                if (rec.Type != TransferType.Purchase) continue;

                double trnSum = (rec.Quantity * rec.UnitPrice);
                if (trnSum == 0.0d) continue;

                var itemRec = fModel.GetRecord(rec.ItemType, rec.ItemId);
                var ts = rec.Timestamp;

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
                    case BudgetChartType.Countries:
                        var brandedItem2 = itemRec as IBrandedItem;
                        var brand = (brandedItem2 == null) ? "-" : brandedItem2.Brand;
                        var brandRec = brandRecords.FirstOrDefault(p => p.Name == brand);
                        key = (brandRec == null) ? "-" : brandRec.Country;
                        break;
                    case BudgetChartType.Monthes:
                        key = string.Format("{0}/{1}", ts.Month, ts.Year);
                        break;
                    case BudgetChartType.Days:
                        key = string.Format("{0}/{1}/{2}", ts.Day, ts.Month, ts.Year);
                        break;
                    default:
                        key = "";
                        break;
                }

                if (string.IsNullOrEmpty(key)) {
                    key = string.Empty;
                }

                ChartPoint chartPoint;
                if (result.TryGetValue(key, out chartPoint)) {
                    chartPoint.Value += trnSum;
                    result[key] = chartPoint;
                } else {
                    chartPoint = new ChartPoint(key, trnSum);
                    if (chartType == BudgetChartType.Monthes) {
                        int days = DateHelper.DaysInMonth((short)ts.Year, (byte)ts.Month);
                        chartPoint.Timestamp = new DateTime(ts.Year, ts.Month, days);
                    } else if (chartType == BudgetChartType.Days) {
                        chartPoint.Timestamp = ts.Date;
                    }
                    result.Add(key, chartPoint);
                }
            }

            List<ChartPoint> vals = new List<ChartPoint>();
            foreach (var valPair in result) {
                vals.Add(valPair.Value);
            }

            if (chartType != BudgetChartType.Monthes && chartType != BudgetChartType.Days) {
                vals = AlternateSort(vals);
            }

            return vals;
        }

        private static List<ChartPoint> AlternateSort(List<ChartPoint> orig)
        {
            orig.Sort((x, y) => {
                return x.Value.CompareTo(y.Value);
            });

            ChartPoint[] varr = new ChartPoint[orig.Count];

            int t, b, lp, rp;
            t = orig.Count - 1;
            b = 0;
            lp = t / 2 - 1;
            rp = t / 2 + 1;
            varr[t / 2] = orig[t];
            t--;
            while (b < t) {
                varr[lp] = orig[b];
                b++;
                varr[rp] = orig[b];
                b++;
                lp--;
                rp++;

                if (b >= t) break;

                varr[lp] = orig[t];
                t--;
                varr[rp] = orig[t];
                t--;
                lp--;
                rp++;
            }

            List<ChartPoint> result = new List<ChartPoint>();
            for (int i = 0; i < orig.Count; ++i)
                result.Add(varr[i]);

            return result;
        }
    }
}
