/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaLog.Components;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.UI;

namespace AquaLog.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public class TanksPanel : DataPanel
    {
        private ContextMenu fContextMenu;
        private FlowLayoutPanel fLayoutPanel;
        private TankSticker fSelectedTank;

        public TankSticker SelectedTank
        {
            get { return fSelectedTank; }
        }


        public TanksPanel() : base()
        {
            fLayoutPanel = new FlowLayoutPanel();
            fLayoutPanel.Dock = DockStyle.Fill;
            fLayoutPanel.Padding = new Padding(10);
            Controls.Add(fLayoutPanel);

            var miEdit = new MenuItem();
            miEdit.Text = "Edit";
            miEdit.Click += btnEditTank_Click;

            var miDelete = new MenuItem();
            miDelete.Text = "Delete";
            miDelete.Click += btnDeleteTank_Click;

            fContextMenu = new ContextMenu();
            fContextMenu.MenuItems.AddRange(new MenuItem[] { miEdit, miDelete});
        }

        protected override void InitActions()
        {
            fActions.Add(new UserAction("Add", "btn_rec_new.gif", btnAddTank_Click));
            fActions.Add(new UserAction("Edit", "btn_rec_edit.gif", btnEditTank_Click));
            fActions.Add(new UserAction("Delete", "btn_rec_delete.gif", btnDeleteTank_Click));
        }

        public override void UpdateContent()
        {
            fLayoutPanel.Controls.Clear();
            if (fModel == null) return;

            var aquariums = fModel.QueryAquariums();

            foreach (var aqm in aquariums) {
                if (aqm.IsInactive() && ALSettings.Instance.HideClosedTanks) {
                    continue;
                }

                var aqPanel = new TankSticker();
                aqPanel.Model = fModel;
                aqPanel.Aquarium = aqm;
                aqPanel.Click += OnTankClick;
                aqPanel.DoubleClick += OnTankDoubleClick;
                aqPanel.ContextMenu = fContextMenu;
                fLayoutPanel.Controls.Add(aqPanel);
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
                    fModel.AddRecord(aqm);
                    UpdateContent();
                }
            }
        }

        private void btnEditTank_Click(object sender, EventArgs e)
        {
            var selectedItem = SelectedTank;
            if (selectedItem == null) return;

            var aqm = selectedItem.Aquarium;
            if (aqm == null) return;

            using (var dlg = new AquariumEditDlg()) {
                dlg.Aquarium = aqm;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fModel.UpdateRecord(aqm);
                    UpdateContent();
                }
            }
        }

        private void btnDeleteTank_Click(object sender, EventArgs e)
        {
            var selectedItem = SelectedTank;
            if (selectedItem == null) return;

            fModel.DeleteRecord(selectedItem.Aquarium);
            UpdateContent();
        }
    }
}
