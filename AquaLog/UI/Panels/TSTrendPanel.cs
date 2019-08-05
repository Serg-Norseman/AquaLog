/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AquaLog.Components;
using AquaLog.TSDB;

namespace AquaLog.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public class TSTrendPanel : DataPanel
    {
        private int fPointId;
        private ZGraphControl fGraph;

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

        protected override void InitActions()
        {
        }

        public override void UpdateContent()
        {
            fGraph.Clear();
            if (fModel == null) return;

            TSDatabase tsdb = fModel.TSDB;
            var pt = tsdb.GetPoint(fPointId);

            List<ChartPoint> vals = new List<ChartPoint>();
            var records = tsdb.QueryValues(fPointId, DateTime.Now.AddDays(-60), DateTime.Now);
            foreach (TSValue rec in records) {
                vals.Add(new ChartPoint(rec.Timestamp, rec.Value));
            }
            fGraph.PrepareArray(pt.Name, "Time", "Value", ChartStyle.Point, vals);
        }
    }
}
