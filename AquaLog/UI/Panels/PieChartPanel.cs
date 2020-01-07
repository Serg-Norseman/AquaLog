/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using AquaLog.UI.Components;

namespace AquaLog.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public class PieChartPanel : ChartPanel
    {
        public PieChartPanel() : base()
        {
            fChartStyle = ChartStyle.Pie;
        }
    }
}
