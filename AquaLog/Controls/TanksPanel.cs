/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.UI;

namespace AquaLog.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public class TanksPanel : Browser
    {
        private TankSticker fSelectedTank;

        public TankSticker SelectedTank
        {
            get { return fSelectedTank; }
        }


        public TanksPanel() : base()
        {
        }

        protected override void InitActions()
        {
            fActions.Add(new Action() {
                Name = "Add Tank",
                Click = btnAddTank_Click
            });
            fActions.Add(new Action() {
                Name = "Edit Tank",
                Click = btnEditTank_Click
            });
            fActions.Add(new Action() {
                Name = "Delete Tank",
                Click = btnDeleteTank_Click
            });
        }

        public override void UpdateLayout()
        {
            Controls.Clear();
            if (Model == null) return;

            var aquariums = Model.QueryAquariums();

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

        private void btnAddTank_Click(object sender, EventArgs e)
        {
            var aqm = new Aquarium(ALCore.UnknownName);

            using (var dlg = new AquariumEditDlg()) {
                dlg.Aquarium = aqm;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    Model.AddRecord(aqm);
                    UpdateLayout();
                }
            }
        }

        private void btnEditTank_Click(object sender, EventArgs e)
        {
            var selectedTank = SelectedTank;
            if (selectedTank == null) return;

            var aqm = selectedTank.Aquarium;
            if (aqm == null) return;

            using (var dlg = new AquariumEditDlg()) {
                dlg.Aquarium = aqm;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    Model.UpdateRecord(aqm);
                    UpdateLayout();
                }
            }
        }

        private void btnDeleteTank_Click(object sender, EventArgs e)
        {
            var selectedTank = SelectedTank;
            if (selectedTank == null) return;

            Model.DeleteRecord(selectedTank.Aquarium);
            UpdateLayout();
        }
    }
}
