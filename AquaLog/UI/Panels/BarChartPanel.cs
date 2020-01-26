﻿/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using AquaLog.UI.Components;

namespace AquaLog.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public class BarChartPanel : ChartPanel
    {
        public BarChartPanel() : base()
        {
            fChartStyle = ChartStyle.Bar;
        }
    }
}