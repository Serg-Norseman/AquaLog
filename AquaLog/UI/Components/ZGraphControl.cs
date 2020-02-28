/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace AquaLog.UI.Components
{
    public enum ChartStyle
    {
        Bar,
        Point,
        Pie,
    }

    public sealed class ChartPoint
    {
        public string Caption { get; private set; }
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }
        public Color Color { get; private set; }

        public ChartPoint(string caption, double value)
        {
            Caption = caption;
            Value = value;
        }

        public ChartPoint(string caption, double value, Color color)
        {
            Caption = caption;
            Value = value;
            Color = color;
        }

        public ChartPoint(DateTime timestamp, double value)
        {
            Timestamp = timestamp;
            Value = value;
        }

        public override string ToString()
        {
            return Caption;
        }
    }

    public class ChartSeries
    {
        public readonly string AxisName;
        public readonly ChartStyle Style;
        public readonly IList<ChartPoint> Data;
        public readonly Color Color;

        public ChartSeries(string axisName, ChartStyle style, IList<ChartPoint> data, Color color)
        {
            AxisName = axisName;
            Style = style;
            Data = data;
            Color = color;
        }
    }

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
            fGraph.Dock = DockStyle.Fill;
            fGraph.PointValueEvent += Graph_PointValueEvent;
            Controls.Add(fGraph);
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

        public void Clear()
        {
            GraphPane gPane = fGraph.GraphPane;
            gPane.Title.Text = "";
            gPane.XAxis.Title.Text = "";
            gPane.YAxis.Title.Text = "";
            gPane.CurveList.Clear();

            fGraph.AxisChange();
            fGraph.Invalidate();
        }

        public void ShowData(string title, string xAxis, object data)
        {
            Clear();
            if (data == null) return;

            var seriesList = data as Dictionary<string, ChartSeries>;
            if (seriesList != null) {
                foreach (var pair in seriesList) {
                    var series = pair.Value;
                    ShowSeries(title, xAxis, series);
                }
            } else {
                var series = data as ChartSeries;
                if (series != null) {
                    ShowSeries(title, xAxis, series);
                }
            }
        }

        private void ShowSeries(string title, string xAxis, ChartSeries series)
        {
            IList<ChartPoint> vals = series.Data;

            GraphPane gPane = fGraph.GraphPane;
            try {
                //gPane.Title.Text = title;

                gPane.XAxis.Title.Text = xAxis;
                gPane.XAxis.Type = AxisType.Date;
                gPane.XAxis.Scale.Format = "yy-MM-dd HH:mm:ss";
                gPane.XAxis.Scale.FontSpec.Angle = 60;
                gPane.XAxis.Scale.FontSpec.Size = 12;
                gPane.XAxis.Scale.MajorUnit = DateUnit.Year;
                gPane.XAxis.Scale.MinorUnit = DateUnit.Second;

                //gPane.YAxis.Title.Text = yAxis;

                if (series.Style != ChartStyle.Pie) {
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
                            gPane.AddBar(series.AxisName, ppList, series.Color);
                            break;

                        case ChartStyle.Point:
                            gPane.AddCurve(series.AxisName, ppList, series.Color, SymbolType.Diamond).Symbol.Size = 3;
                            break;
                    }
                } else {
                    gPane.Legend.IsVisible = false;

                    int num = vals.Count;
                    for (int i = 0; i < num; i++) {
                        ChartPoint item = vals[i];

                        PieItem ps = gPane.AddPieSlice(item.Value, item.Color, 0F, item.Caption);
                        ps.LabelType = PieLabelType.Name_Value_Percent;
                    }
                }
            } finally {
                fGraph.AxisChange();
                fGraph.Invalidate();
            }
        }
    }
}
