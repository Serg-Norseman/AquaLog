/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaLog.Core;

namespace AquaLog.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public class TanksPanel : FlowLayoutPanel
    {
        private ALModel fModel;
        private TankSticker fSelectedTank;

        public ALModel Model
        {
            get { return fModel; }
            set {
                if (fModel != value) {
                    fModel = value;
                    UpdateLayout();
                }
            }
        }

        public TankSticker SelectedTank
        {
            get { return fSelectedTank; }
        }


        public TanksPanel()
        {
            Dock = DockStyle.Fill;
            Padding = new Padding(10);
        }

        public void UpdateLayout()
        {
            Controls.Clear();
            if (fModel == null) return;

            var aquariums = fModel.QueryAquariums();

            foreach (var aqm in aquariums) {
                var aqPanel = new TankSticker();
                aqPanel.Aquarium = aqm;
                aqPanel.Click += OnTankClick;
                aqPanel.DoubleClick += OnTankDoubleClick;
                Controls.Add(aqPanel);
            }
        }

        private void OnTankClick(object sender, EventArgs e)
        {
            if (fSelectedTank != null) {
                fSelectedTank.Selected = false;
            }
            fSelectedTank = sender as TankSticker;
            if (fSelectedTank != null) {
                fSelectedTank.Selected = true;
            }
        }

        private void OnTankDoubleClick(object sender, EventArgs e)
        {
        }
    }
}
