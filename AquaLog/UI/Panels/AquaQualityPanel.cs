/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AquaLog.Core.Model;
using AquaLog.Core.Types;
using AquaLog.UI.Components;

namespace AquaLog.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public class AquaQualityPanel : DataPanel
    {
        private const int LayoutPadding = 10;

        private Aquarium fAquarium;
        private readonly FlowLayoutPanel fLayoutPanel;


        public AquaQualityPanel() : base()
        {
            fLayoutPanel = new FlowLayoutPanel();
            fLayoutPanel.Dock = DockStyle.Fill;
            fLayoutPanel.Padding = new Padding(LayoutPadding);
            fLayoutPanel.FlowDirection = FlowDirection.TopDown;
            fLayoutPanel.WrapContents = false;
            fLayoutPanel.AutoScroll = true;
            fLayoutPanel.SizeChanged += FlowLayoutPanel_SizeChanged;
            Controls.Add(fLayoutPanel);
        }

        public override void SetExtData(object extData)
        {
            fAquarium = (Aquarium)extData;
            UpdateContent();
        }

        private void FlowLayoutPanel_SizeChanged(object sender, EventArgs e)
        {
            int innerWidth = fLayoutPanel.ClientSize.Width - LayoutPadding * 2;
            foreach (Control ctrl in fLayoutPanel.Controls) {
                ctrl.Width = innerWidth;
            }
        }

        internal override void UpdateContent()
        {
            fLayoutPanel.Controls.Clear();
            if (fModel == null) return;

            if (fAquarium != null) {
                fLayoutPanel.SuspendLayout();

                var values = fModel.CollectData(fAquarium);
                foreach (var mVal in values) {
                    if (!double.IsNaN(mVal.Value) && mVal.Ranges != null) {
                        string title = mVal.Name;
                        if (!string.IsNullOrEmpty(mVal.Unit)) {
                            title += ", " + mVal.Unit;
                        }

                        var qCtl = new QualityControl();
                        qCtl.Margin = new Padding(0, 0, 0, 4);
                        qCtl.Dock = DockStyle.Top;
                        qCtl.Anchor = AnchorStyles.Left;
                        qCtl.Ranges = mVal.Ranges;
                        qCtl.Value = mVal.Value;
                        qCtl.Title = title;
                        qCtl.Width = fLayoutPanel.ClientSize.Width - LayoutPadding * 2;
                        fLayoutPanel.Controls.Add(qCtl);
                    }
                }

                fLayoutPanel.ResumeLayout();
            }
        }
    }
}
