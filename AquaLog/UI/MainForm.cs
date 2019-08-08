/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using AquaLog.Components;
using AquaLog.Core;
using AquaLog.Logging;
using AquaLog.Panels;

// TODO: food, additives, equipment, furniture

namespace AquaLog.UI
{
    public partial class MainForm : Form, IBrowser, ILocalizable
    {
        private readonly ILogger fLogger;
        private ALModel fModel;
        private NavigationStack<DataPanel> fNavigationStack;

        private FishPanel fFishPanel;
        private InvertebratePanel fInvertebratePanel;
        private PlantPanel fPlantPanel;
        private TanksPanel fTanksPanel;
        private SpeciesPanel fSpeciesPanel;
        private TransferPanel fTransferPanel;
        private WaterChangePanel fWaterChangePanel;
        private DevicePanel fDevicePanel;
        private MaintenancePanel fMaintenancePanel;
        private HistoryPanel fHistoryPanel;
        private NotePanel fNotePanel;
        private BudgetPanel fExpensePanel;
        private TSDBPanel fTSDBPanel;
        private TSValuePanel fTSValuePanel;
        private TSTrendPanel fTSTrendPanel;


        public MainForm()
        {
            InitializeComponent();

            ClientSize = new Size(896, 504);

            fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "MainForm");
            fModel = new ALModel();
            fNavigationStack = new NavigationStack<DataPanel>();

            SetSettings();
            UpdateControls();

            Icon = new Icon(ALCore.LoadResourceStream("AquaLog.Resources.icon_aqualog.ico"));
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
            btnDevices.Tag = MainView.Devices;
            btnBudget.Tag = MainView.Budget;
            btnNotes.Tag = MainView.Notes;
            btnWaterChanges.Tag = MainView.WaterChanges;
            btnHistory.Tag = MainView.History;
            btnMaintenance.Tag = MainView.Maintenance;
            btnTransfers.Tag = MainView.Transfers;
            btnTSDB.Tag = MainView.TSDB;

            SetView(MainView.Tanks, null);

            Localizer.FindLocales();
            Localizer.LoadLocale(1049); // 1049 | Localizer.LS_DEF_CODE
            SetLocale();
        }

        public void SetLocale()
        {
            miFile.Text = Localizer.LS(LSID.LSID_MIFile);
            miHelp.Text = Localizer.LS(LSID.LSID_MIHelp);
            miExit.Text = Localizer.LS(LSID.LSID_MIExit);
            miAbout.Text = Localizer.LS(LSID.LSID_MIAbout);
            miSettings.Text = Localizer.LS(LSID.LSID_MISettings);
            miCleanSpace.Text = Localizer.LS(LSID.LSID_MICleanSpace);
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        private void btnMainView_Click(object sender, EventArgs e)
        {
            var btn = sender as ToolStripButton;
            var mainView = (MainView)btn.Tag;
            SetView(mainView, null);
        }

        private void miCleanSpace_Click(object sender, EventArgs e)
        {
            fModel.CleanSpace();
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            using (var dlg = new AboutDlg()) {
                dlg.ShowDialog();
            }
        }

        #endregion

        #region Views functions

        private void SetActions(DataPanel browser)
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

        public void SetView(MainView mainView, object extData)
        {
            switch (mainView) {
                case MainView.Prev:
                    SetView(fNavigationStack.Back());
                    break;
                case MainView.Next:
                    SetView(fNavigationStack.Next());
                    break;
                case MainView.Tanks:
                    SetView<TanksPanel>(ref fTanksPanel, extData);
                    break;
                case MainView.Fishes:
                    SetView<FishPanel>(ref fFishPanel, extData);
                    break;
                case MainView.Invertebrates:
                    SetView<InvertebratePanel>(ref fInvertebratePanel, extData);
                    break;
                case MainView.Plants:
                    SetView<PlantPanel>(ref fPlantPanel, extData);
                    break;
                case MainView.Species:
                    SetView<SpeciesPanel>(ref fSpeciesPanel, extData);
                    break;
                case MainView.Devices:
                    SetView<DevicePanel>(ref fDevicePanel, extData);
                    break;
                case MainView.Budget:
                    SetView<BudgetPanel>(ref fExpensePanel, extData);
                    break;
                case MainView.Notes:
                    SetView<NotePanel>(ref fNotePanel, extData);
                    break;
                case MainView.WaterChanges:
                    SetView<WaterChangePanel>(ref fWaterChangePanel, extData);
                    break;
                case MainView.History:
                    SetView<HistoryPanel>(ref fHistoryPanel, extData);
                    break;
                case MainView.Maintenance:
                    SetView<MaintenancePanel>(ref fMaintenancePanel, extData);
                    break;
                case MainView.Transfers:
                    SetView<TransferPanel>(ref fTransferPanel, extData);
                    break;
                case MainView.TSDB:
                    SetView<TSDBPanel>(ref fTSDBPanel, extData);
                    break;
                case MainView.TSValues:
                    SetView<TSValuePanel>(ref fTSValuePanel, extData);
                    break;
                case MainView.TSTrend:
                    SetView<TSTrendPanel>(ref fTSTrendPanel, extData);
                    break;
            }
        }

        private void SetView<T>(ref T view, object extData) where T : DataPanel, new()
        {
            if (view == null) {
                view = new T();
                view.Browser = this;
                view.SetExtData(extData);
                view.Model = fModel;
            }

            fNavigationStack.Current = view;
            SetView(view);
        }

        private void SetView(DataPanel view)
        {
            pnlClient.Controls.Clear();
            if (view == null) {
                return;
            }
            pnlClient.Controls.Add(view);

            SetActions(view);

            view.SetLocale();
            view.UpdateContent();

            UpdateNavControls();
        }

        private void UpdateNavControls()
        {
            btnPrev.Enabled = fNavigationStack.CanBackward();
            btnNext.Enabled = fNavigationStack.CanForward();
        }

        #endregion
    }
}
