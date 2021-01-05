/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2021 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using AquaMate.UI.Charts;
using OxyPlot;
using OxyPlot.Wpf;

namespace AquaMate.UI.Components
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ZChart : UserControl
    {
        private PlotView fGraph;

        public ZChart()
        {
            Clear();
        }

        public void Clear()
        {
            Content = null;
            fGraph = new PlotView();
            Content = fGraph;
        }

        public void ShowData(string title, string xAxis, string yAxis, object data)
        {
            Clear();
            if (data == null) return;

            //fGraph.Title = title;

            var seriesList = data as Dictionary<string, ChartSeries>;
            if (seriesList != null) {
                foreach (var pair in seriesList) {
                    var series = pair.Value;
                    ShowSeries(xAxis, yAxis, series);
                }
            } else {
                var series = data as ChartSeries;
                if (series != null) {
                    ShowSeries(xAxis, yAxis, series);
                }
            }
        }

        private void ShowSeries(string xAxis, string yAxis, ChartSeries series)
        {
            IList<ChartPoint> vals = series.Data;

            var plotModel = new PlotModel { Title = series.AxisName };
            try {
                if (series.Style == ChartStyle.Pie) {
                    var pieSeries = new OxyPlot.Series.PieSeries() {
                        StrokeThickness = 1.0,
                        InsideLabelPosition = 0.9,
                        AngleSpan = 360,
                        StartAngle = 0,
                        Diameter = 0.9,
                        OutsideLabelFormat = "{1} ({2:0.00} %)",
                        InsideLabelFormat = ""
                    };

                    int num = vals.Count;
                    for (int i = 0; i < num; i++) {
                        ChartPoint item = vals[i];
                        if (item != null) {
                            pieSeries.Slices.Add(new OxyPlot.Series.PieSlice(item.Caption, item.Value));
                        }
                    }

                    plotModel.Series.Add(pieSeries);
                } else if (series.Style == ChartStyle.Bar || series.Style == ChartStyle.Point) {
                    /*fGraph.LegendPlacement = OxyPlot.LegendPlacement.Outside;
                    fGraph.LegendPosition = OxyPlot.LegendPosition.RightTop;
                    fGraph.LegendOrientation = OxyPlot.LegendOrientation.Vertical;*/
                    //gPane.XAxis.Type = AxisType.Date;
                    //gPane.Legend.IsVisible = true;

                    var catAxis = new OxyPlot.Axes.CategoryAxis();
                    catAxis.Title = xAxis;
                    catAxis.Position = OxyPlot.Axes.AxisPosition.Bottom;
                    plotModel.Axes.Add(catAxis);

                    var valAxis = new OxyPlot.Axes.LinearAxis();
                    valAxis.Title = yAxis;
                    valAxis.Position = OxyPlot.Axes.AxisPosition.Left;
                    plotModel.Axes.Add(valAxis);

                    switch (series.Style) {
                        case ChartStyle.Bar: {
                                /*gPane.XAxis.Scale.Format = "yy-MM-dd";
                                gPane.AddBar(series.AxisName, ppList, series.Color);*/

                                var columnSeries = new OxyPlot.Series.ColumnSeries() {
                                    LabelPlacement = OxyPlot.Series.LabelPlacement.Inside,
                                    LabelFormatString = "{0:.00}"
                                };

                                int num = vals.Count;
                                for (int i = 0; i < num; i++) {
                                    ChartPoint item = vals[i];

                                    catAxis.ActualLabels.Add(item.Caption);
                                    int categoryIndex = catAxis.ActualLabels.Count - 1;
                                    columnSeries.Items.Add(new OxyPlot.Series.ColumnItem(item.Value, categoryIndex));
                                }

                                plotModel.Series.Add(columnSeries);
                            }
                            break;

                        case ChartStyle.Point:
                            /*gPane.XAxis.Scale.Format = "yy-MM-dd HH:mm:ss";
                            gPane.XAxis.Scale.MajorUnit = DateUnit.Day;
                            gPane.XAxis.Scale.MinorUnit = DateUnit.Second;
                            gPane.AddCurve(series.AxisName, ppList, series.Color, SymbolType.Diamond).Symbol.Size = 3;*/
                            break;
                    }
                }
            } finally {
                fGraph.Model = plotModel;
            }
        }

        #region Beautify

        public static List<ChartPoint> AlternateSort(List<ChartPoint> source)
        {
            int srcLen = source.Count;
            if (srcLen < 2) {
                return source;
            }

            source.Sort((x, y) => {
                return x.Value.CompareTo(y.Value);
            });

            ChartPoint[] target = new ChartPoint[srcLen];

            int t, b, lp, rp;
            t = srcLen - 1;
            b = 0;
            lp = t / 2 - 1;
            rp = t / 2 + 1;
            target[t / 2] = source[t];
            t--;
            while (b < t) {
                target[lp] = source[b];
                b++;
                target[rp] = source[b];
                b++;
                lp--;
                rp++;

                if (b >= t) break;

                target[lp] = source[t];
                t--;
                target[rp] = source[t];
                t--;
                lp--;
                rp++;
            }

            return target.ToList();
        }

        #endregion
    }
}
