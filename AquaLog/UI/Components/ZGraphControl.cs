/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BSLib;
using ZedGraph;

namespace AquaLog.Components
{
    public enum ChartStyle
    {
        Bar,
        Point,
    }

    public sealed class ChartPoint
    {
        public string Caption;
        public double Value;

        public ChartPoint(string caption, double value)
        {
            Caption = caption;
            Value = value;
        }

        public override string ToString()
        {
            return Caption;
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
            Controls.Add(fGraph);
        }

        public void Activate()
        {
            Select();
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

        public void PrepareArray(string title, string xAxis, string yAxis, ChartStyle style, bool excludeUnknowns, List<ChartPoint> vals)
        {
            GraphPane gPane = fGraph.GraphPane;
            try {
                gPane.CurveList.Clear();

                gPane.Title.Text = title;
                gPane.XAxis.Title.Text = xAxis;
                gPane.YAxis.Title.Text = yAxis;

                //if (style != ChartStyle.ClusterBar)
                {
                    PointPairList ppList = new PointPairList();

                    int num = vals.Count;
                    for (int i = 0; i < num; i++) {
                        ChartPoint item = vals[i];

                        string s = item.Caption;
                        double lab = (s == "?") ? 0.0f : ConvertHelper.ParseFloat(s, 0.0f, true);

                        if (lab != 0.0d || !excludeUnknowns) {
                            ppList.Add(lab, item.Value);
                        }
                    }
                    ppList.Sort();

                    switch (style) {
                        case ChartStyle.Bar:
                            gPane.AddBar("-", ppList, Color.Green);
                            break;

                        case ChartStyle.Point:
                            gPane.AddCurve("-", ppList, Color.Green, SymbolType.Diamond).Symbol.Size = 3;
                            break;
                    }
                }
            } finally {
                fGraph.AxisChange();
                fGraph.Invalidate();
            }
        }
    }
}
