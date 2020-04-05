/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Windows.Forms;
using AquaMate.UI.Components;

namespace AquaMate.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ChartPanel : DataPanel
    {
        private readonly ZGraphControl fGraph;
        private object fData;

        public ChartPanel()
        {
            fGraph = new ZGraphControl();
            fGraph.Dock = DockStyle.Fill;
            Controls.Add(fGraph);
        }

        public override void SetExtData(object extData)
        {
            fData = extData;
        }

        public override void UpdateContent()
        {
            fGraph.ShowData("", "Labels", fData);
        }
    }
}
