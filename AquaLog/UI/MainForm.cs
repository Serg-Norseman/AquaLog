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
using AquaLog.Logging;

namespace AquaLog.UI
{
    public partial class MainForm : Form
    {
        private readonly ILogger fLogger;
        private ALModel fModel;
        private FishPanel fFishPanel;
        private InvertebratePanel fInvertebratePanel;
        private PlantPanel fPlantPanel;
        private TanksPanel fTanksPanel;
        private SpeciesPanel fSpeciesPanel;
        private TransferPanel fTransferPanel;
        private WaterChangePanel fWaterChangePanel;


        public MainForm()
        {
            InitializeComponent();

            ClientSize = new Size(896, 504);

            fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "MainForm");
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
            btnTransfers.Tag = MainView.Transfers;

            SetView(ref fTanksPanel);
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
                    SetView<TanksPanel>(ref fTanksPanel);
                    break;
                case MainView.Fishes:
                    SetView<FishPanel>(ref fFishPanel);
                    break;
                case MainView.Invertebrates:
                    SetView<InvertebratePanel>(ref fInvertebratePanel);
                    break;
                case MainView.Plants:
                    SetView<PlantPanel>(ref fPlantPanel);
                    break;
                case MainView.Species:
                    SetView<SpeciesPanel>(ref fSpeciesPanel);
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
                    SetView<WaterChangePanel>(ref fWaterChangePanel);
                    break;
                case MainView.History:
                    break;
                case MainView.Maintenance:
                    break;
                case MainView.Transfers:
                    SetView<TransferPanel>(ref fTransferPanel);
                    break;
            }
        }

        private void miCleanSpace_Click(object sender, EventArgs e)
        {
            fModel.CleanSpace();
        }

        #endregion

        #region Views functions

        private void SetActions(Browser browser)
        {
            for (int i = pnlTools.Controls.Count - 1; i >= 0; i--) {
                if (pnlTools.Controls[i] is Button) {
                    pnlTools.Controls.RemoveAt(i);
                }
            }

            for (int i = 0; i < browser.Actions.Count; i++) {
                var action = browser.Actions[i];

                var btn = new Button();
                btn.Dock = DockStyle.Top;
                btn.Text = action.Name;
                btn.Image = action.Image;
                btn.ImageAlign = ContentAlignment.MiddleCenter;
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                btn.Margin = new Padding(0, 0, 0, 10);
                btn.Size = new Size(190, 30);
                btn.Click += action.Click;
                btn.BackColor = SystemColors.Control;
                pnlTools.Controls.Add(btn);
            }
        }

        private void SetView<T>(ref T view) where T : Browser, new()
        {
            pnlClient.Controls.Clear();
            if (view == null) {
                view = new T();
                view.Model = fModel;
            }
            pnlClient.Controls.Add(view);

            SetActions(view);

            view.UpdateContent();
        }

        #endregion
    }
}
