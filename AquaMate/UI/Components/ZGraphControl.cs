/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;

namespace AquaMate.UI.Components
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ZGraphControl : UserControl
    {
        private readonly ZedGraphControl fGraph;

        public ZGraphControl()
        {
            fGraph = new ZedGraphControl();
            fGraph.IsShowPointValues = true;
            fGraph.PointValueEvent += Graph_PointValueEvent;
            fGraph.Dock = DockStyle.Fill;
            Controls.Add(fGraph);
        }

        public void Clear()
        {
            GraphPane gPane = fGraph.GraphPane;

            gPane.Title.Text = "";
            gPane.XAxis.Title.Text = "";
            gPane.YAxis.Title.Text = "";

            gPane.CurveList.Clear();
            gPane.GraphObjList.Clear();

            fGraph.AxisChange();
            fGraph.Invalidate();
        }

        public void ShowData(string title, string xAxis, string yAxis, object data)
        {
            Clear();
            if (data == null) return;

            fGraph.GraphPane.Title.Text = title;

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

            GraphPane gPane = fGraph.GraphPane;
            try {
                gPane.XAxis.Title.Text = xAxis;
                //gPane.XAxis.Scale.FontSpec.Angle = 60;
                gPane.XAxis.Scale.FontSpec.Size = 10;
                gPane.YAxis.Title.Text = yAxis;
                gPane.YAxis.Scale.FontSpec.Size = 10;

                if (series.Style == ChartStyle.Pie) {
                    gPane.Legend.IsVisible = false;

                    int num = vals.Count;
                    for (int i = 0; i < num; i++) {
                        ChartPoint item = vals[i];
                        PieItem ps = gPane.AddPieSlice(item.Value, item.Color, 0F, item.Caption);
                        ps.LabelType = PieLabelType.Name_Value_Percent;
                    }
                } else if (series.Style == ChartStyle.Bar || series.Style == ChartStyle.Point) {
                    gPane.XAxis.Type = AxisType.Date;
                    gPane.Legend.IsVisible = true;

                    PointPairList ppList = new PointPairList();
                    int num = vals.Count;
                    for (int i = 0; i < num; i++) {
                        ChartPoint item = vals[i];
                        ppList.Add(new XDate(item.Timestamp), item.Value);
                    }

                    ppList.Sort();

                    switch (series.Style) {
                        case ChartStyle.Bar:
                            gPane.XAxis.Scale.Format = "yy-MM-dd";
                            gPane.XAxis.Scale.MajorUnit = DateUnit.Year;
                            gPane.XAxis.Scale.MinorUnit = DateUnit.Month;
                            gPane.AddBar(series.AxisName, ppList, series.Color);
                            break;
                        case ChartStyle.Point:
                            gPane.XAxis.Scale.Format = "yy-MM-dd HH:mm:ss";
                            gPane.XAxis.Scale.MajorUnit = DateUnit.Day;
                            gPane.XAxis.Scale.MinorUnit = DateUnit.Second;
                            gPane.AddCurve(series.AxisName, ppList, series.Color, SymbolType.Diamond).Symbol.Size = 3;
                            break;
                    }
                }
            } finally {
                fGraph.AxisChange();
                fGraph.Invalidate();
            }
        }

        private string Graph_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            var pieItem = curve as PieItem;
            if (pieItem != null) {
                return string.Format("{0}: {1:0.00}", pieItem.Label.Text, pieItem.Value);
            }

            var barItem = curve as BarItem;
            if (barItem != null) {
                return string.Format("{0}: {1:0.00}", DateTime.FromOADate(barItem[iPt].X), barItem[iPt].Y);
            }

            var lineItem = curve as LineItem;
            if (lineItem != null) {
                return string.Format("{0} ({1}): {2:0.00}", lineItem.Label.Text, DateTime.FromOADate(lineItem[iPt].X), lineItem[iPt].Y);
            }

            return string.Empty;
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
