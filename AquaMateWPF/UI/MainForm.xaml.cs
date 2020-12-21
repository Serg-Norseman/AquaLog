/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Core.Types;
using AquaMate.Logging;
using AquaMate.UI.Components;
using AquaMate.UI.Dialogs;
using AquaMate.UI.Panels;
using BSLib;

namespace AquaMate.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainForm : CommonForm, IBrowser
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "MainForm");

        private DataPanel fCurrentPanel;
        private IModel fModel;
        private NavigationStack<DataPanel> fNavigationStack;
        //private NotificationDlg fNotificationDlg;
        private Dictionary<Type, DataPanel> fPanels;
        private DispatcherTimer fTimer;


        public IModel Model
        {
            get { return fModel; }
        }


        public MainForm()
        {
            InitializeComponent();

            fTimer = new DispatcherTimer();
            fTimer.Interval = new TimeSpan(0, 0, 1);
            fTimer.Tick += this.Timer1Tick;

            fModel = new ALModel(this);
            fNavigationStack = new NavigationStack<DataPanel>();
            fPanels = new Dictionary<Type, DataPanel>();

            ALSettings.Instance.LoadFromFile(Path.Combine(AppHost.GetAppDataPath(), "AquaMate.ini"));
            SetSettings();
            UpdateControls();

            btnPrev.Tag = MainView.Prev;
            btnNext.Tag = MainView.Next;
            btnTanks.Tag = MainView.Tanks;
            btnInhabitants.Tag = MainView.Inhabitants;
            btnSpecies.Tag = MainView.Species;
            btnDevices.Tag = MainView.Devices;
            btnBudget.Tag = MainView.Budget;
            btnNotes.Tag = MainView.Notes;
            btnMaintenance.Tag = MainView.Maintenance;
            btnTransfers.Tag = MainView.Transfers;
            btnTSDB.Tag = MainView.TSDB;
            btnNutrition.Tag = MainView.Nutrition;
            btnMeasures.Tag = MainView.Measures;
            btnSchedule.Tag = MainView.Schedule;
            btnInventory.Tag = MainView.Inventory;
            btnSnapshots.Tag = MainView.Snapshots;

            SetView(MainView.Tanks, null);

            Localizer.FindLocales();
            ApplySettings();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                ALSettings.Instance.SaveToFile(Path.Combine(AppHost.GetAppDataPath(), "AquaMate.ini"));
                //fTray.Dispose();
            }
            base.Dispose(disposing);
        }

        private void ChangeLocale()
        {
            Localizer.LoadLocale(ALSettings.Instance.CurrentLocale);
            SetLocale();

            if (fCurrentPanel != null) {
                fCurrentPanel.SetLocale();
                SetActions(fCurrentPanel);
            }

            //if (fTray != null)
            //    fTray.SetLocale();

            // other
            foreach (var props in ALData.MeasurementUnits) {
                string[] mes = Localizer.LS(props.Name).Split(new char[] { ',' });
                props.StrName = (mes.Length > 0) ? mes[0] : string.Empty;
                props.StrAbbreviation = (mes.Length > 1) ? mes[1] : string.Empty;
            }
        }

        public void SetLocale()
        {
            miFile.Header = Localizer.LS(LSID.File);
            miHelp.Header = Localizer.LS(LSID.Help);
            miExit.Header = Localizer.LS(LSID.Exit);
            miAbout.Header = Localizer.LS(LSID.About);
            miSettings.Header = Localizer.LS(LSID.Settings);
            miCleanSpace.Header = Localizer.LS(LSID.CleanSpace);
            miCalculator.Header = Localizer.LS(LSID.Calculator);

            btnTanks.Content = Localizer.LS(LSID.Aquariums);
            btnInhabitants.Content = Localizer.LS(LSID.Inhabitants);
            btnSpecies.Content = Localizer.LS(LSID.Species);
            btnDevices.Content = Localizer.LS(LSID.Devices);
            btnNutrition.Content = Localizer.LS(LSID.Nutrition);
            btnMaintenance.Content = Localizer.LS(LSID.Maintenance);
            btnNotes.Content = Localizer.LS(LSID.Notes);
            btnMeasures.Content = Localizer.LS(LSID.Measures);
            btnSchedule.Content = Localizer.LS(LSID.Schedule);
            btnTransfers.Content = Localizer.LS(LSID.Transfers);
            btnBudget.Content = Localizer.LS(LSID.Budget);
            btnInventory.Content = Localizer.LS(LSID.Inventory);
            btnSnapshots.Content = Localizer.LS(LSID.Snapshots);

            btnPrev.ToolTip = Localizer.LS(LSID.NavPrev);
            btnNext.ToolTip = Localizer.LS(LSID.NavNext);
        }

        private void UpdateControls()
        {
            DateTime cdt = DateTime.Now;
            lblDate.Text = cdt.ToString("yyyy.MM.dd\r\nHH:mm:ss", null);
        }

        private void SetSettings()
        {
            fTimer.Interval = new TimeSpan(0, 0, ALCore.UpdateInterval / 1000);
            fTimer.Start();
        }

        private void CheckTasks()
        {
            DateTime dtx = DateTime.Now;

            // one check per minute
            if (dtx.Second != 0) return;

            int notInterval = ALSettings.Instance.NotificationInterval;

            var records = fModel.QuerySchedule();
            foreach (Schedule rec in records) {
                if (rec.Status != TaskStatus.ToDo || !rec.Reminder) continue;

                if (rec.Timestamp.AddMinutes(-notInterval) <= dtx && dtx <= rec.Timestamp.AddMinutes(+notInterval)) {
                    Aquarium aqm = fModel.GetRecord<Aquarium>(rec.AquariumId);
                    string aqmName = (aqm == null) ? "" : aqm.Name;
                    string text = string.Format("{0} [{1}]", rec.Event, aqmName);
                    Notify(text, rec);
                }
            }
        }

        public void Notify(string text, Schedule record)
        {
            /*if (fNotificationDlg == null) {
                fNotificationDlg = new NotificationDlg(this);
            }
            fNotificationDlg.Notify(text, record);*/
        }

        public void AddMaintenance(Schedule scheduleRecord)
        {
            Activate();

            var record = new Maintenance();

            using (var dlg = new MaintenanceEditDlg()) {
                dlg.SetContext(fModel, record);

                if (dlg.ShowModal()) {
                    fModel.AddRecord(record);
                }
            }
        }

        public bool EditTank(ITank tank)
        {
            try {
                using (var dlg = new TankEditDlg()) {
                    dlg.SetContext(fModel, tank);

                    if (dlg.ShowModal()) {
                        return true;
                    }
                }
                return false;
            } catch (Exception ex) {
                fLogger.WriteError("EditTank()", ex);
                return false;
            }
        }

        public void TransferItem(ItemType itemType, int itemId, IDataPanel view)
        {
            var transfer = new Transfer();
            transfer.ItemType = itemType;
            transfer.ItemId = itemId;

            using (var dlg = new TransferEditDlg()) {
                dlg.SetContext(fModel, transfer);

                if (dlg.ShowModal()) {
                    fModel.AddRecord(transfer);

                    view.UpdateContent();
                }
            }
        }

        public void ShowSettings(int tabIndex = 0)
        {
            AppHost.Instance.ShowSettings(fModel, tabIndex);
        }

        public void ApplySettings()
        {
            fModel.ApplySettings(ALSettings.Instance);
            ChangeLocale();
        }

        public void UpdateView()
        {
            fCurrentPanel.UpdateView();
        }

        public bool CheckDelete(Entity entity)
        {
            // FIXME
            bool hasLinks = fModel.CheckConstraints(entity);
            if (hasLinks) {
                UIHelper.ShowWarning(Localizer.LS(LSID.RecordHasExternalLinks));
                return false;
            }

            string recordName = fModel.GetEntityName(entity);
            if (!UIHelper.ShowQuestionYN(string.Format(Localizer.LS(LSID.RecordDeleteQuery), recordName))) return false;

            return true;
        }

        public void ShowAbout()
        {
            using (var dlg = new AboutDlg()) {
                dlg.ShowDialog();
            }
        }

        public void SwitchVisible()
        {
            if (IsVisible) {
                Hide();
            } else {
                WindowState = WindowState.Normal;
                Show();
            }
        }

        #region Event handlers

        private void Timer1Tick(object sender, EventArgs e)
        {
            UpdateControls();

            if (fCurrentPanel != null) {
                fCurrentPanel.TickTimer();
            }

            CheckTasks();
        }

        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMainView_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var mainView = (MainView)btn.Tag;
            SetView(mainView, null);
        }

        private void miCleanSpace_Click(object sender, RoutedEventArgs e)
        {
            fModel.CleanSpace();
        }

        private void miAbout_Click(object sender, RoutedEventArgs e)
        {
            ShowAbout();
        }

        private void miSettings_Click(object sender, RoutedEventArgs e)
        {
            ShowSettings();
        }

        private void miCalculator_Click(object sender, RoutedEventArgs e)
        {
            AppHost.Instance.ShowCalculator();
        }

        private void miDiagnosticConsole_Click(object sender, RoutedEventArgs e)
        {
            /*using (var dlg = new DiagnosticConsole()) {
                dlg.ShowDialog();
            }*/
        }

        private void miTheme_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mItem = sender as MenuItem;
            ChangeTheme(mItem.Header as string);
        }

        private void ChangeTheme(string style)
        {
            // определяем путь к файлу ресурсов
            var uri = new Uri(style + ".xaml", UriKind.Relative);
            // загружаем словарь ресурсов
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            // очищаем коллекцию ресурсов приложения
            Application.Current.Resources.Clear();
            // добавляем загруженный словарь ресурсов
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        #endregion

        #region Views functions

        private void SetActions(DataPanel browser)
        {
            for (int i = pnlTools.Children.Count - 1; i >= 0; i--) {
                var ctl = pnlTools.Children[i];

                if (ctl is Button || ctl is OptionsPicker || ctl is ComboBox) {
                    pnlTools.Children.RemoveAt(i);
                }
            }

            foreach (var action in browser.Actions) {
                if (action.Choices == null) {
                    action.Control = UIHelper.AddPanelButton(pnlTools, action.Name, Localizer.LS(action.BtnText), action.Image, action.Click);
                } else {
                    if (action.MultiChoice) {
                        action.Control = UIHelper.AddPanelOptionsPicker(pnlTools, action.Name, action.Choices, action.Click);
                    } else {
                        action.Control = UIHelper.AddPanelComboBox(pnlTools, action.Name, action.Choices, action.Click);
                    }
                }
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
                case MainView.MeasuresChart:
                    SetView<MeasuresChartPanel>(extData);
                    break;
                case MainView.Schedule:
                    SetView<SchedulePanel>(extData);
                    break;
                case MainView.AquariumDetails:
                    SetView<AquaDetailsPanel>(extData);
                    break;
                case MainView.Inventory:
                    SetView<InventoryPanel>(extData);
                    break;
                case MainView.ZChart:
                    SetView<ChartPanel>(extData);
                    break;
                case MainView.LifeLinesChart:
                    SetView<LifeLinesPanel>(extData);
                    break;
                case MainView.Snapshots:
                    SetView<SnapshotPanel>(extData);
                    break;
                case MainView.M3DViewer:
                    SetView<M3DViewerPanel>(extData);
                    break;
                case MainView.Brands:
                    SetView<BrandPanel>(extData);
                    break;
                case MainView.Shops:
                    //SetView<ShopPanel>(extData);
                    break;
                case MainView.Analysis:
                    SetView<AquaAnalysisPanel>(extData);
                    break;
                case MainView.Quality:
                    SetView<AquaQualityPanel>(extData);
                    break;
                case MainView.BioTreemap:
                    SetView<BioTreemapPanel>(extData);
                    break;
                case MainView.Pricelist:
                    //SetView<PricelistPanel>(extData);
                    break;
            }
        }

        private void SetView<T>(object extData) where T : DataPanel, new()
        {
            try {
                Type type = typeof(T);
                DataPanel panel;
                bool exists = fPanels.TryGetValue(type, out panel);

                if (!exists) {
                    panel = new T();
                    panel.Browser = this;
                    panel.Model = fModel;
                    fPanels.Add(type, panel);
                }
                panel.SetExtData(extData);

                fNavigationStack.Current = panel;
                SetView(panel);
            } catch (Exception ex) {
                fLogger.WriteError("SetView.1()", ex);
            }
        }

        private void SetView(DataPanel view)
        {
            try {
                pnlClient.Content = null;
                if (view == null) {
                    return;
                }
                pnlClient.Content = view;

                fCurrentPanel = view;
                fCurrentPanel.UpdateView();

                SetActions(view);

                fCurrentPanel.SelectionChanged(new List<Entity>() { });

                btnPrev.IsEnabled = fNavigationStack.CanBackward();
                btnNext.IsEnabled = fNavigationStack.CanForward();
            } catch (Exception ex) {
                fLogger.WriteError("SetView.2()", ex);
            }
        }

        #endregion
    }
}
