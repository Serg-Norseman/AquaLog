/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

#define MSCHART

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AquaMate.UI.Components
{
    #if !MSCHART
    using ZedGraph;
    #else
    using System.Windows.Forms.DataVisualization.Charting;
    #endif

    /// <summary>
    /// 
    /// </summary>
    public sealed class ZGraphControl : UserControl
    {
        #if !MSCHART
        private readonly ZedGraphControl fGraph;
        #else
        private readonly Chart fGraph;
        #endif

        public ZGraphControl()
        {
            #if !MSCHART
            fGraph = new ZedGraphControl();
            fGraph.IsShowPointValues = true;
            fGraph.PointValueEvent += Graph_PointValueEvent;
            #else
            fGraph = new Chart();
            //chart.GetToolTipText += new EventHandler<ToolTipEventArgs>(this.chart_ToolTip);
            Clear();
            #endif

            fGraph.Dock = DockStyle.Fill;
            Controls.Add(fGraph);
        }

        public void Clear()
        {
            #if !MSCHART
            GraphPane gPane = fGraph.GraphPane;
            gPane.Title.Text = "";
            gPane.XAxis.Title.Text = "";
            gPane.YAxis.Title.Text = "";
            gPane.CurveList.Clear();
            fGraph.AxisChange();
            gPane.GraphObjList.Clear();
            #else
            fGraph.ChartAreas.Clear();
            fGraph.Series.Clear();
            fGraph.Legends.Clear();

            fGraph.ChartAreas.Add(new ChartArea("ChartArea1"));
            fGraph.Legends.Add(new Legend("Legend1"));
            fGraph.Legends["Legend1"].IsTextAutoFit = true;
            #endif

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

        #if !MSCHART

        private void ShowSeries(string title, string xAxis, ChartSeries series)
        {
            IList<ChartPoint> vals = series.Data;

            GraphPane gPane = fGraph.GraphPane;
            try {
                //gPane.Title.Text = title;
                gPane.XAxis.Title.Text = xAxis;
                gPane.XAxis.Scale.FontSpec.Angle = 60;
                gPane.XAxis.Scale.FontSpec.Size = 12;
                //gPane.YAxis.Title.Text = yAxis;

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
                    gPane.XAxis.Scale.Format = "yy-MM-dd HH:mm:ss";
                    gPane.XAxis.Scale.MajorUnit = DateUnit.Year;
                    gPane.XAxis.Scale.MinorUnit = DateUnit.Second;
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

                    //double maxVal = double.MinValue;
                    RadarPointList ppList = new RadarPointList();
                    ppList.Clockwise = true;
                    int num = vals.Count;
                    for (int i = 0; i < num; i++) {
                        ChartPoint item = vals[i];
                        ppList.Add(new PointPair(PointPair.Missing, item.Value, item.Caption));
                        //maxVal = Math.Max(maxVal, item.Value);
                    }

                    gPane.AddCurve(series.AxisName, ppList, series.Color, SymbolType.None);

                    for (int i = 0; i < num; i++) {
                        LineObj line = new ArrowObj(0, 0, ppList[i].X, ppList[i].Y);
                        line.Line.Color = Color.LightGray;
                        line.ZOrder = ZOrder.E_BehindCurves;
                        gPane.GraphObjList.Add(line);
                    }

                    BoxObj box = new BoxObj(-0.005, 0.005, 0.01, 0.01, Color.Black, Color.Black);
                    gPane.GraphObjList.Add(box);

                    gPane.XAxis.MajorTic.IsAllTics = true;
                    gPane.XAxis.MinorTic.IsAllTics = true;
                    gPane.XAxis.Title.IsTitleAtCross = false;
                    gPane.XAxis.Cross = 0;
                    gPane.XAxis.Scale.IsSkipFirstLabel = true;
                    gPane.XAxis.Scale.IsSkipLastLabel = true;
                    gPane.XAxis.Scale.IsSkipCrossLabel = true;

                    gPane.YAxis.MajorTic.IsAllTics = false;
                    gPane.YAxis.MinorTic.IsAllTics = false;
                    gPane.YAxis.Title.IsTitleAtCross = false;
                    gPane.YAxis.Cross = 0;
                    gPane.YAxis.Scale.IsSkipFirstLabel = true;
                    gPane.YAxis.Scale.IsSkipLastLabel = true;
                    gPane.YAxis.Scale.IsSkipCrossLabel = true;
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

        #else

        private void ShowSeries(string title, string xAxis, ChartSeries series)
        {
            IList<ChartPoint> vals = series.Data;

            var chArea = fGraph.ChartAreas["ChartArea1"];
            Series mscSeries = new Series(series.AxisName);
            mscSeries.ChartArea = "ChartArea1";
            mscSeries.Legend = "Legend1";
            mscSeries.Color = series.Color;
            fGraph.Series.Add(mscSeries);
            DataPointCollection dataPoints = mscSeries.Points;
            var legend = fGraph.Legends["Legend1"];

            try {
                switch (series.Style) {
                    case ChartStyle.Pie:
                    case ChartStyle.Radar:
                        foreach (var item in vals) {
                            dataPoints.AddXY(item.Caption, item.Value);
                        }
                        break;

                    case ChartStyle.Bar:
                    case ChartStyle.Point:
                        foreach (var item in vals) {
                            dataPoints.AddXY(item.Timestamp, item.Value);
                        }
                        break;
                }

                if (series.Style == ChartStyle.Pie) {
                    mscSeries.ChartType = SeriesChartType.Pie;
                    mscSeries["PieLabelStyle"] = "Outside";
                    mscSeries.Label = "#VALX (#PERCENT{P2})";
                    // see the connecting lines
                    mscSeries.BorderWidth = 1;
                    mscSeries.BorderColor = Color.FromArgb(26, 59, 105);
                    legend.Enabled = false;
                } else if (series.Style == ChartStyle.Bar || series.Style == ChartStyle.Point) {
                    switch (series.Style) {
                        case ChartStyle.Bar:
                            mscSeries.ChartType = SeriesChartType.Column;
                            mscSeries.Label = "#VALX\n#VALY{F2}";
                            break;
                        case ChartStyle.Point:
                            mscSeries.ChartType = SeriesChartType.Line;
                            break;
                    }
                    legend.Enabled = true;
                    legend.Docking = Docking.Bottom;

                    chArea.CursorX.IsUserEnabled = true;
                    chArea.CursorX.IsUserSelectionEnabled = true;
                    chArea.CursorY.IsUserEnabled = true;
                    chArea.CursorY.IsUserSelectionEnabled = true;
                } else {
                    mscSeries.ChartType = SeriesChartType.Radar;
                    mscSeries["RadarDrawingStyle"] = "Area";
                    mscSeries["AreaDrawingStyle"] = "Polygon";
                    mscSeries["CircularLabelsStyle"] = "Horizontal";
                    legend.Enabled = true;
                }
            } finally {
                fGraph.Invalidate();
            }
        }

        private void chart_ToolTip(object sender, ToolTipEventArgs e)
        {
            HitTestResult h = e.HitTestResult;

            switch (h.ChartElementType) {
                case ChartElementType.Axis:
                case ChartElementType.AxisLabels:
                    e.Text = "Click-drag in graph area to zoom";
                    break;
                case ChartElementType.ScrollBarZoomReset:
                    e.Text = "Zoom undo";
                    break;
                case ChartElementType.DataPoint:
                    e.Text = h.Series.Name + '\n' + h.Series.Points[h.PointIndex];
                    break;
            }
        }

        #endif
    }
}
