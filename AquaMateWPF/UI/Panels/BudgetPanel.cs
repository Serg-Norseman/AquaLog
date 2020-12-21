﻿/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Core.Types;
using AquaMate.UI.Components;
using BSLib.Design;

namespace AquaMate.UI.Panels
{
    public enum BudgetChartType
    {
        ItemTypes,
        Shops,
        Brands,
        Countries,
        Monthes,
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

            Content = null;
            var stackPanel = new StackPanel() {
                Children = {
                    ListView,
                    fFooter
                }
            };
            Content = stackPanel;
        }

        protected override void InitActions()
        {
            AddAction("ChartTypes", LSID.ChartItemTypes, "", ViewChartTypesHandler);
            AddAction("ChartShops", LSID.ChartShops, "", ViewChartShopsHandler);
            AddAction("ChartBrands", LSID.ChartBrands, "", ViewChartBrandsHandler);
            AddAction("ChartCountries", LSID.ChartCountries, "", ViewChartCountriesHandler);
            AddAction("ChartMonthes", LSID.ChartMonthes, "", ViewChartMonthesHandler);
            AddAction("Brands", LSID.Brands, "", ViewBrandsHandler);
        }

        protected override void UpdateListView()
        {
            ListView.Clear();
            ListView.AddColumn(Localizer.LS(LSID.Date), 80, true, BSDTypes.HorizontalAlignment.Left);
            ListView.AddColumn(Localizer.LS(LSID.Type), 80, true, BSDTypes.HorizontalAlignment.Left);
            ListView.AddColumn(Localizer.LS(LSID.Brand), 50, true, BSDTypes.HorizontalAlignment.Left);
            ListView.AddColumn(Localizer.LS(LSID.Item), 140, true, BSDTypes.HorizontalAlignment.Left);
            ListView.AddColumn(Localizer.LS(LSID.Quantity), 80, true, BSDTypes.HorizontalAlignment.Right);
            ListView.AddColumn(Localizer.LS(LSID.UnitPrice), 80, true, BSDTypes.HorizontalAlignment.Right);
            ListView.AddColumn(Localizer.LS(LSID.Sum), 80, true, BSDTypes.HorizontalAlignment.Right);
            ListView.AddColumn(Localizer.LS(LSID.Shop), 180, true, BSDTypes.HorizontalAlignment.Left);
            ListView.AddColumn(Localizer.LS(LSID.State), 80, true, BSDTypes.HorizontalAlignment.Left);

            var records = fModel.QueryTransferExpenses();
            fTotalFooter = ProcessRecords(records, ListView);

            CollectBrands(records);
        }

        private string ProcessRecords(IList<Transfer> records, ZListView listView)
        {
            //Font defFont = ListView.Font;
            //Font boldFont = new Font(defFont, FontStyle.Bold);

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

                        ItemState itemState;
                        string strState = fModel.GetItemStateStr(rec.ItemId, itemType, out itemState);

                        var brandedItem = itemRec as IBrandedItem;
                        string brand = (brandedItem == null) ? "-" : brandedItem.Brand;

                        var item = listView.AddItem(rec,
                                       ALCore.GetDateStr(rec.Timestamp),
                                       Localizer.LS(ALData.ItemTypes[(int)rec.ItemType].Name),
                                       brand,
                                       itName,
                                       rec.Quantity.ToString(),
                                       ALCore.GetDecimalStr(rec.UnitPrice),
                                       ALCore.GetDecimalStr(sum),
                                       rec.Shop,
                                       strState
                                   );

                        if (itemType == ItemType.Aquarium) {
                            //item.Font = boldFont;
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
            fFooter.Content = result;
            return result;
        }

        public override void SelectionChanged(IList<Entity> records)
        {
            /*if (records.Count > 1) {
                IList<Transfer> transfers = records.Cast<Transfer>().ToList();
                ProcessRecords(transfers, null);
            } else {
                fFooter.Text = fTotalFooter;
            }*/
        }

        private void ViewBrandsHandler(object sender, EventArgs e)
        {
            Browser.SetView(MainView.Brands, null);
        }

        private void ViewChartTypesHandler(object sender, EventArgs e)
        {
            //var chartData = GetChartData(BudgetChartType.ItemTypes);
            //Browser.SetView(MainView.ZChart, new ChartSeries("", ChartStyle.Pie, chartData, Color.Transparent));
        }

        private void ViewChartShopsHandler(object sender, EventArgs e)
        {
            //var chartData = GetChartData(BudgetChartType.Shops);
            //Browser.SetView(MainView.ZChart, new ChartSeries("", ChartStyle.Pie, chartData, Color.Transparent));
        }

        private void ViewChartBrandsHandler(object sender, EventArgs e)
        {
            //var chartData = GetChartData(BudgetChartType.Brands);
            //Browser.SetView(MainView.ZChart, new ChartSeries("", ChartStyle.Pie, chartData, Color.Transparent));
        }

        private void ViewChartCountriesHandler(object sender, EventArgs e)
        {
            //var chartData = GetChartData(BudgetChartType.Countries);
            //Browser.SetView(MainView.ZChart, new ChartSeries("", ChartStyle.Pie, chartData, Color.Transparent));
        }

        private void ViewChartMonthesHandler(object sender, EventArgs e)
        {
            /*var purcChartData = GetChartData(BudgetChartType.Monthes, TransferType.Purchase);
            var saleChartData = GetChartData(BudgetChartType.Monthes, TransferType.Sale);

            var series = new Dictionary<string, ChartSeries>();
            series.Add(Localizer.LS(LSID.Purchase), new ChartSeries(Localizer.LS(LSID.Purchase), ChartStyle.Bar, purcChartData, Color.Red));
            series.Add(Localizer.LS(LSID.Sale), new ChartSeries(Localizer.LS(LSID.Sale), ChartStyle.Bar, saleChartData, Color.Green));

            Browser.SetView(MainView.ZChart, series);*/
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

        /*private IList<ChartPoint> GetChartData(BudgetChartType chartType, TransferType transferType = TransferType.Purchase)
        {
            Dictionary<string, ChartPoint> result = new Dictionary<string, ChartPoint>();

            IList<Brand> brandRecords = null;
            if (chartType == BudgetChartType.Countries) {
                brandRecords = fModel.QueryBrands();
            }

            var records = fModel.QueryExpenses();
            foreach (Transfer rec in records) {
                if (rec.Type != transferType) continue;

                int factor = +1;
                if (chartType == BudgetChartType.Monthes) {
                    switch (rec.Type) {
                        case TransferType.Purchase:
                            factor = -1;
                            break;
                        case TransferType.Sale:
                            factor = +1;
                            break;
                    }
                }

                double trnSum = (rec.Quantity * rec.UnitPrice) * factor;
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
                    }
                    result.Add(key, chartPoint);
                }
            }

            List<ChartPoint> vals = result.Values.ToList();

            if (chartType != BudgetChartType.Monthes) {
                // prettification
                vals = ZChart.AlternateSort(vals);
            }

            return vals;
        }*/
    }
}