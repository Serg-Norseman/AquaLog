/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

#define SDC_TEST

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AquaLog.UI.Components;
using AquaLog.TSDB;

namespace AquaLog.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class TSTrendPanel : DataPanel
    {
        private readonly ZGraphControl fGraph;
        private int fPointId;

        public int PointId
        {
            get { return fPointId; }
            set { fPointId = value; }
        }


        public TSTrendPanel()
        {
            fGraph = new ZGraphControl();
            fGraph.Dock = DockStyle.Fill;
            Controls.Add(fGraph);
        }

        public override void SetExtData(object extData)
        {
            int pointId = (int)extData;
            fPointId = pointId;
        }

        public override void UpdateContent()
        {
            fGraph.Clear();
            if (fModel == null) return;

            TSDatabase tsdb = fModel.TSDB;
            var pt = tsdb.GetPoint(fPointId);

            List<ChartPoint> vals = new List<ChartPoint>();
            #if SDC_TEST
            List<ChartPoint> comp_vals = new List<ChartPoint>();
            SDCompression compress = new SDCompression(0.5, 60);
            #endif

            var records = tsdb.QueryValues(fPointId, DateTime.Now.AddDays(-60), DateTime.Now);
            foreach (TSValue rec in records) {
                vals.Add(new ChartPoint(rec.Timestamp, rec.Value));
                #if SDC_TEST
                DateTime sdts = rec.Timestamp;
                double sdval = rec.Value;
                if (compress.ReceivePoint(ref sdts, ref sdval)) {
                    comp_vals.Add(new ChartPoint(sdts, 20 + sdval));
                }
                #endif
            }

            fGraph.PrepareArray(pt.Name, "Time", "Value", ChartStyle.Point, vals, Color.Green);
            #if SDC_TEST
            fGraph.PrepareArray(pt.Name, "Time", "CompValue", ChartStyle.Point, comp_vals, Color.Red);
            #endif
        }
    }
}
