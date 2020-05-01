﻿/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaMate.Core.Model.Tanks;
using AquaMate.UI.Components;

namespace AquaMate.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class M3DViewerPanel : DataPanel
    {
        private readonly OGLViewer fViewer;

        public M3DViewerPanel()
        {
            var infoPanel = new StatusBarPanel();
            infoPanel.AutoSize = StatusBarPanelAutoSize.Contents;
            infoPanel.Text = "Free-rotate (R); Water visible (W); Aeration (A)";

            var statusBar = new StatusBar();
            statusBar.Panels.AddRange(new StatusBarPanel[] { infoPanel });
            statusBar.ShowPanels = true;

            fViewer = new OGLViewer();
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
