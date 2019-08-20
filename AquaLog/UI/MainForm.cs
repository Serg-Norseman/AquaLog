/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AquaLog.Components;
using AquaLog.Core;
using AquaLog.Logging;
using AquaLog.Panels;

namespace AquaLog.UI
{
    public partial class MainForm : Form, IBrowser, ILocalizable
    {
        private readonly ILogger fLogger;
        private ALModel fModel;
        private NavigationStack<DataPanel> fNavigationStack;
        private Dictionary<Type, DataPanel> fPanels;
        private DataPanel fCurrentPanel;


        public MainForm()
        {
            InitializeComponent();

            ClientSize = new Size(896, 504);

            fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "MainForm");
            fModel = new ALModel();
            fNavigationStack = new NavigationStack<DataPanel>();
            fPanels = new Dictionary<Type, DataPanel>();

            SetSettings();
            UpdateControls();

            Icon = new Icon(ALCore.LoadResourceStream("AquaLog.Resources.icon_aqualog.ico"));
            btnPrev.Image = ALCore.LoadResourceImage("btn_left.gif");
            btnNext.Image = ALCore.LoadResourceImage("btn_right.gif");
            miExit.Image = ALCore.LoadResourceImage("btn_exit.gif");

            btnPrev.Tag = MainView.Prev;
            btnNext.Tag = MainView.Next;
            btnTanks.Tag = MainView.Tanks;
            btnInhabitants.Tag = MainView.Inhabitants;
            btnSpecies.Tag = MainView.Species;
            btnDevices.Tag = MainView.Devices;
            btnBudget.Tag = MainView.Budget;
            btnNotes.Tag = MainView.Notes;
            btnWaterChanges.Tag = MainView.WaterChanges;
            btnHistory.Tag = MainView.History;
            btnMaintenance.Tag = MainView.Maintenance;
            btnTransfers.Tag = MainView.Transfers;
            btnTSDB.Tag = MainView.TSDB;
            btnNutrition.Tag = MainView.Nutrition;
            btnMeasures.Tag = MainView.Measures;

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

        private void miSettings_Click(object sender, EventArgs e)
        {
            using (var dlg = new SettingsDlg()) {
                dlg.Model = fModel;
                dlg.Settings = ALSettings.Instance;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fCurrentPanel.UpdateView();
                }
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
                    SetView<TanksPanel>(extData);
                    break;
                case MainView.Inhabitants:
                    SetView<InhabitantPanel>(extData);
                    break;
                case MainView.Species:
                    SetView<SpeciesPanel>(extData);
                    break;
                case MainView.Devices:
                    SetView<DevicePanel>(extData);
                    break;
                case MainView.Budget:
                    SetView<BudgetPanel>(extData);
                    break;
                case MainView.Notes:
                    SetView<NotePanel>(extData);
                    break;
                case MainView.WaterChanges:
                    SetView<WaterChangePanel>(extData);
                    break;
                case MainView.History:
                    SetView<HistoryPanel>(extData);
                    break;
                case MainView.Maintenance:
                    SetView<MaintenancePanel>(extData);
                    break;
                case MainView.Transfers:
                    SetView<TransferPanel>(extData);
                    break;
                case MainView.Nutrition:
                    SetView<NutritionPanel>(extData);
                    break;
                case MainView.TSDB:
                    SetView<TSDBPanel>(extData);
                    break;
                case MainView.TSValues:
                    SetView<TSValuePanel>(extData);
                    break;
                case MainView.TSTrend:
                    SetView<TSTrendPanel>(extData);
                    break;
                case MainView.Measures:
                    SetView<MeasurePanel>(extData);
                    break;
            }
        }

        private void SetView<T>(object extData) where T : DataPanel, new()
        {
            Type type = typeof(T);
            DataPanel panel;
            bool exists = fPanels.TryGetValue(type, out panel);

            if (!exists) {
                panel = new T();
                panel.Browser = this;
                panel.SetExtData(extData);
                panel.Model = fModel;
            }

            fNavigationStack.Current = panel;
            SetView(panel);

            if (!exists) {
                fPanels.Add(type, panel);
            }
        }

        private void SetView(DataPanel view)
        {
            pnlClient.Controls.Clear();
            if (view == null) {
                return;
            }
            pnlClient.Controls.Add(view);

            SetActions(view);

            fCurrentPanel = view;
            fCurrentPanel.UpdateView();

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
