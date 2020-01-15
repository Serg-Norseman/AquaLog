/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
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
    public abstract class ChartPanel : DataPanel
    {
        private readonly ZGraphControl fGraph;
        private IList<ChartPoint> fChartData;
        protected ChartStyle fChartStyle;

        protected ChartPanel()
        {
            fGraph = new ZGraphControl();
            fGraph.Dock = DockStyle.Fill;
            Controls.Add(fGraph);
        }

        public override void SetExtData(object extData)
        {
            fChartData = (IList<ChartPoint>)extData;
        }

        protected override void UpdateContent()
        {
            fGraph.Clear();
            if (fChartData == null) return;

            Color chartColor = Color.Transparent;
            if (fChartStyle != ChartStyle.Pie) {
                chartColor = Color.Green;
            }

            fGraph.PrepareArray("", "Category", "Value", fChartStyle, fChartData, chartColor);
        }
    }
}
