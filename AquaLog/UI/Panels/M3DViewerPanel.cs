/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaLog.Core.Model.Tanks;
using AquaLog.GLViewer;

namespace AquaLog.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class M3DViewerPanel : DataPanel
    {
        private readonly M3DViewer fViewer;

        public M3DViewerPanel()
        {
            var infoPanel = new StatusBarPanel();
            infoPanel.AutoSize = StatusBarPanelAutoSize.Contents;
            infoPanel.Text = "Free-rotate (R); Water visible (W)";

            var statusBar = new StatusBar();
            statusBar.Panels.AddRange(new StatusBarPanel[] { infoPanel });
            statusBar.ShowPanels = true;

            fViewer = new M3DViewer();
            fViewer.Dock = DockStyle.Fill;
            fViewer.VisibleChanged += Panel_VisibleChanged;

            Controls.AddRange(new Control[] { fViewer, statusBar });
        }

        public override void SetExtData(object extData)
        {
            fViewer.Tank = (BaseTank)extData;
        }

        private void Panel_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible) {
                fViewer.StartTimer();
            } else {
                fViewer.StopTimer();
            }
        }
    }
}
