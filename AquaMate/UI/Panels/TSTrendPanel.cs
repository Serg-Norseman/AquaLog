﻿/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AquaMate.UI.Charts;
using AquaMate.UI.Components;
using AquaMate.TSDB;

namespace AquaMate.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class TSTrendPanel : DataPanel
    {
        private readonly ZChart fChart;
        private int fPointId;


        public TSTrendPanel()
        {
            fChart = new ZChart();
            fChart.Dock = DockStyle.Fill;
            Controls.Add(fChart);
        }

        public override void SetExtData(object extData)
        {
            int pointId = (int)extData;
            fPointId = pointId;
        }

        public override void UpdateContent()
        {
            fChart.Clear();
            if (fModel == null) return;

            TSDatabase tsdb = fModel.TSDB;
            var pt = tsdb.GetPoint(fPointId);

            List<ChartPoint> vals = new List<ChartPoint>();

            var endTime = DateTime.Now;
            var begTime = endTime.AddHours(-12);

            var records = tsdb.QueryValues(fPointId, begTime, endTime);
            foreach (TSValue rec in records) {
                vals.Add(new ChartPoint(rec.Timestamp, rec.Value));
            }

            fChart.ShowData(pt.Name, "Time", "Value", new ChartSeries("Value", ChartStyle.Point, vals, Color.Green));
        }
    }
}
