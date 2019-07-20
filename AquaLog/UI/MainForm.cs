/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using AquaLog.Controls;
using AquaLog.Core;
using AquaLog.Core.Model;

namespace AquaLog.UI
{
    public enum MainView
    {
        Prev,
        Next,
        Tanks,
        Fishes,
        Invertebrates,
        Plants,
        Species,
        Lights,
        Pumps,
        Expenses,
        Notes,
        WaterChanges,
        History,
        Maintenance
    }

    public partial class MainForm : Form
    {
        private ALModel fModel;
        private TanksPanel fTanksPanel;


        public MainForm()
        {
            InitializeComponent();

            ClientSize = new Size(896, 504);

            fModel = new ALModel();

            SetSettings();
            UpdateControls();

            btnPrev.Image = ALCore.LoadResourceImage("btn_left.gif");
            btnNext.Image = ALCore.LoadResourceImage("btn_right.gif");
            miExit.Image = ALCore.LoadResourceImage("btn_exit.gif");

            btnPrev.Tag = MainView.Prev;
            btnNext.Tag = MainView.Next;
            btnTanks.Tag = MainView.Tanks;
            btnFishes.Tag = MainView.Fishes;
            btnInvertebrates.Tag = MainView.Invertebrates;
            btnPlants.Tag = MainView.Plants;
            btnSpecies.Tag = MainView.Species;
            btnLights.Tag = MainView.Lights;
            btnPumps.Tag = MainView.Pumps;
            btnExpenses.Tag = MainView.Expenses;
            btnNotes.Tag = MainView.Notes;
            btnWaterChanges.Tag = MainView.WaterChanges;
            btnHistory.Tag = MainView.History;
            btnMaintenance.Tag = MainView.Maintenance;

            SetTanksView();
        }

        private void UpdateControls()
        {
            DateTime cdt = DateTime.Now;
            lblDate.Text = cdt.ToString("yyyy.MM.dd\r\nHH:mm:ss", null);
        }

        private void SetSettings()
        {
            timer1.Interval = ALCore.UpdateInterval;
            timer1.Enabled = true;
        }

        #region Event handlers

        private void Timer1Tick(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddTank_Click(object sender, EventArgs e)
        {
            var aqm = new Aquarium(ALCore.UnknownName);

            using (var dlg = new AquariumEditDlg()) {
                dlg.Aquarium = aqm;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fModel.AddAquarium(aqm);
                    fTanksPanel.UpdateLayout();
                }
            }
        }

        private void btnEditTank_Click(object sender, EventArgs e)
        {
            var selectedTank = fTanksPanel.SelectedTank;
            if (selectedTank == null) return;

            var aqm = selectedTank.Aquarium;
            if (aqm == null) return;

            using (var dlg = new AquariumEditDlg()) {
                dlg.Aquarium = aqm;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fModel.UpdateAquarium(aqm);
                    fTanksPanel.UpdateLayout();
                }
            }
        }

        private void btnDeleteTank_Click(object sender, EventArgs e)
        {
            var selectedTank = fTanksPanel.SelectedTank;
            if (selectedTank == null) return;

            fModel.DeleteAquarium(selectedTank.Aquarium.Id);
            fTanksPanel.UpdateLayout();
        }

        private void btnMainView_Click(object sender, EventArgs e)
        {
            var btn = sender as ToolStripButton;
            var mainView = (MainView)btn.Tag;

            switch (mainView) {
                case MainView.Prev:
                    break;
                case MainView.Next:
                    break;
                case MainView.Tanks:
                    SetTanksView();
                    break;
                case MainView.Fishes:
                    break;
                case MainView.Invertebrates:
                    break;
                case MainView.Plants:
                    break;
                case MainView.Species:
                    break;
                case MainView.Lights:
                    break;
                case MainView.Pumps:
                    break;
                case MainView.Expenses:
                    break;
                case MainView.Notes:
                    break;
                case MainView.WaterChanges:
                    break;
                case MainView.History:
                    break;
                case MainView.Maintenance:
                    break;
            }
        }

        #endregion

        #region Views functions

        private void SetTanksView()
        {
            if (fTanksPanel == null) {
                fTanksPanel = new TanksPanel();
                fTanksPanel.Model = fModel;
            }
            pnlObjects.Controls.Add(fTanksPanel);
        }

        #endregion
    }
}
