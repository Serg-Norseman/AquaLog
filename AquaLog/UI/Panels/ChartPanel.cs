/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AquaLog.UI.Components;

namespace AquaLog.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ChartPanel : DataPanel
    {
        private readonly ZGraphControl fGraph;
        private Dictionary<string, double> fChartData;

        public ChartPanel()
        {
            fGraph = new ZGraphControl();
            fGraph.Dock = DockStyle.Fill;
            Controls.Add(fGraph);
        }

        public override void SetExtData(object extData)
        {
            fChartData = (Dictionary<string, double>)extData;
        }

        protected override void UpdateContent()
        {
            fGraph.Clear();
            if (fChartData == null) return;

            List<ChartPoint> vals = new List<ChartPoint>();
            foreach (var valPair in fChartData) {
                vals.Add(new ChartPoint(valPair.Key, valPair.Value));
            }
            fGraph.PrepareArray("", "Category", "Value", ChartStyle.Pie, vals, Color.Transparent);
        }
    }
}
