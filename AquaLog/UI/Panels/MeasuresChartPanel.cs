/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AquaLog.Components;
using AquaLog.Core.Model;
using BSLib.Controls;

namespace AquaLog.UI.Panels
{
    public class Trend
    {
        public string Name { get; private set; }
        public Color Color { get; private set; }
        public List<ChartPoint> Points { get; private set; }

        public Trend(string name, Color color)
        {
            Name = name;
            Color = color;
            Points = new List<ChartPoint>();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class MeasuresChartPanel : DataPanel
    {
        private readonly ZGraphControl fGraph;
        private Dictionary<string, Trend> fTrends;


        public MeasuresChartPanel()
        {
            fGraph = new ZGraphControl();
            fGraph.Dock = DockStyle.Fill;
            Controls.Add(fGraph);
        }

        public override void UpdateContent()
        {
            fGraph.Clear();
            if (fModel == null) return;

            var measures = fModel.QueryMeasures();
            fTrends = new Dictionary<string, Trend>();
            fTrends.Add("Temp", new Trend("Temp (°C)", Color.Red));
            fTrends.Add("NO3", new Trend("NO3 (mg/l)", Color.BlueViolet));
            fTrends.Add("NO2", new Trend("NO2 (mg/l)", Color.CornflowerBlue));
            fTrends.Add("GH", new Trend("GH (°d)", Color.DarkGray));
            fTrends.Add("KH", new Trend("KH (°d)", Color.Gray));
            fTrends.Add("pH", new Trend("pH", Color.Fuchsia));
            fTrends.Add("Cl2", new Trend("Cl2 (mg/l)", Color.GreenYellow));
            fTrends.Add("CO2", new Trend("CO2", Color.Maroon));
            fTrends.Add("NH", new Trend("NHtot", Color.Violet));
            fTrends.Add("NH3", new Trend("NH3", Color.PaleVioletRed));
            fTrends.Add("NH4", new Trend("NH4", Color.MediumVioletRed));
            fTrends.Add("PO4", new Trend("PO4", Color.BlueViolet));

            foreach (Measure rec in measures) {
                AddTrendValue("Temp", rec.Timestamp, rec.Temperature);
                AddTrendValue("NO3", rec.Timestamp, rec.NO3);
                AddTrendValue("NO2", rec.Timestamp, rec.NO2);
                AddTrendValue("GH", rec.Timestamp, rec.GH);
                AddTrendValue("KH", rec.Timestamp, rec.KH);
                AddTrendValue("pH", rec.Timestamp, rec.pH);
                AddTrendValue("Cl2", rec.Timestamp, rec.Cl2);
                AddTrendValue("CO2", rec.Timestamp, rec.CO2);
                AddTrendValue("NH", rec.Timestamp, rec.NH);
                AddTrendValue("NH3", rec.Timestamp, rec.NH3);
                AddTrendValue("NH4", rec.Timestamp, rec.NH4);
                AddTrendValue("PO4", rec.Timestamp, rec.PO4);
            }

            foreach (var trendPair in fTrends) {
                var trend = trendPair.Value;
                fGraph.PrepareArray(trend.Name, "Time", "Value", ChartStyle.Point, trend.Points, trend.Color);
            }
        }

        private void AddTrendValue(string key, DateTime timestamp, double value)
        {
            if (value == 0.0d) return;

            Trend trend;
            if (fTrends.TryGetValue(key, out trend)) {
                trend.Points.Add(new ChartPoint(timestamp, value));
            }
        }

        protected override void InitActions()
        {
            ClearActions();

            if (fTrends != null) {
                string[] items = fTrends.Keys.ToArray();
                AddAction("TrendSelector", items, ItemChangeHandler);
            }
        }

        private void ItemChangeHandler(object sender, EventArgs e)
        {
            var picker = sender as OptionsPicker;
            string[] selected = picker.Text.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            fGraph.Clear();
            foreach (string key in selected) {
                Trend trend;
                if (fTrends.TryGetValue(key, out trend)) {
                    fGraph.PrepareArray(key, "Time", "Value", ChartStyle.Point, trend.Points, trend.Color);
                }
            }
        }
    }
}
