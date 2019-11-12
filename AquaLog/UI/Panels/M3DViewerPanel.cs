/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
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
        private BaseTank fTank;
        private bool fWaterVisible = true;

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
            fViewer.Draw += Viewer_Draw;
            fViewer.KeyDown += Viewer_KeyDown;

            Controls.AddRange(new Control[] { fViewer, statusBar });
        }

        public override void SetExtData(object extData)
        {
            fTank = (BaseTank)extData;
        }

        protected override void InitActions()
        {
        }

        public override void UpdateContent()
        {
            fViewer.Reset();
        }

        private void Viewer_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) {
                case Keys.W:
                    fWaterVisible = !fWaterVisible;
                    fViewer.Invalidate(false);
                    break;
            }
        }

        private void Panel_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible) {
                fViewer.StartTimer();
            } else {
                fViewer.StopTimer();
            }
        }

        private void Viewer_Draw(object sender, EventArgs e)
        {
            if (fTank is BowFrontTank) {
                var bowTank = (BowFrontTank)fTank;
                M3DTanks.DrawBowfrontTank((float)bowTank.Width, (float)bowTank.Depth, (float)bowTank.CentreDepth, (float)bowTank.Height, (float)bowTank.GlassThickness, fWaterVisible);
            } else if (fTank is RectangularTank) {
                var rectTank = (RectangularTank)fTank;
                M3DTanks.DrawRectangularTank((float)rectTank.Width, (float)rectTank.Depth, (float)rectTank.Height, (float)rectTank.GlassThickness, fWaterVisible);
            } else if (fTank is CubeTank) {
                var cubeTank = (CubeTank)fTank;
                M3DTanks.DrawRectangularTank((float)cubeTank.EdgeSize, (float)cubeTank.EdgeSize, (float)cubeTank.EdgeSize, (float)cubeTank.GlassThickness, fWaterVisible);
            }
        }
    }
}
