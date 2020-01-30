/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;
using AquaLog.UI.Dialogs;

namespace AquaLog.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class MeasurePanel : ListPanel<Measure, MeasureEditDlg>
    {
        private string fSelectedAquarium;

        public MeasurePanel()
        {
            fSelectedAquarium = "*";
        }

        protected override void UpdateListView()
        {
            ListView.Clear();
            ListView.Columns.Add(Localizer.LS(LSID.Aquarium), 120, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Timestamp), 120, HorizontalAlignment.Left);
            ListView.Columns.Add("Temp (°C)", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("NO3 (mg/l)", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("NO2 (mg/l)", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("GH (°d)", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("KH (°d)", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("pH", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("Cl2 (mg/l)", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("CO2", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("NHtot", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("NH3", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("NH4", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("PO4", 60, HorizontalAlignment.Right);

            var records = fModel.QueryMeasures();
            foreach (Measure rec in records) {
                Aquarium aqm = fModel.Cache.Get<Aquarium>(ItemType.Aquarium, rec.AquariumId);
                string aqmName = (aqm == null) ? "" : aqm.Name;
                if (fSelectedAquarium != "*" && fSelectedAquarium != aqmName) continue;

                var item = ListView.AddItemEx(rec,
                               aqmName,
                               ALCore.GetTimeStr(rec.Timestamp),
                               ALCore.GetDecimalStr(rec.Temperature, 2, true),
                               ALCore.GetDecimalStr(rec.NO3, 2, true),
                               ALCore.GetDecimalStr(rec.NO2, 2, true),
                               ALCore.GetDecimalStr(rec.GH, 2, true),
                               ALCore.GetDecimalStr(rec.KH, 2, true),
                               ALCore.GetDecimalStr(rec.pH, 2, true),
                               ALCore.GetDecimalStr(rec.Cl2, 2, true),
                               ALCore.GetDecimalStr(rec.CO2, 2, true),
                               ALCore.GetDecimalStr(rec.NH, 2, true),
                               ALCore.GetDecimalStr(rec.NH3, 2, true),
                               ALCore.GetDecimalStr(rec.NH4, 2, true),
                               ALCore.GetDecimalStr(rec.PO4, 2, true)
                           );
            }
        }

        protected override void InitActions()
        {
            ClearActions();

            AddAction("Add", LSID.Add, "btn_rec_new.gif", AddHandler);
            AddAction("Edit", LSID.Edit, "btn_rec_edit.gif", EditHandler);
            AddAction("Delete", LSID.Delete, "btn_rec_delete.gif", DeleteHandler);
            AddAction("Chart", LSID.Chart, "btn_chart.gif", ViewChartHandler);
            AddAction("Export", LSID.Export, "btn_excel.gif", ExportHandler);

            var aquariums = fModel.QueryAquariums();
            string[] items = new string[aquariums.Count + 1];
            items[0] = "*";
            int i = 1;
            foreach (var aqm in aquariums) {
                items[i] = aqm.Name;
                i += 1;
            }
            AddSingleSelector("AqmSelector", items, AquariumChangeHandler);
        }

        public override void SelectionChanged(IList<Entity> records)
        {
            bool enabled = (records.Count == 1);

            SetActionEnabled("Edit", enabled);
            SetActionEnabled("Delete", enabled);
        }

        private void AquariumChangeHandler(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            fSelectedAquarium = (comboBox != null) ? comboBox.Text : "*";
            UpdateContent();
        }

        private void ViewChartHandler(object sender, EventArgs e)
        {
            Browser.SetView(MainView.MeasuresChart, null);
        }

        private void ExportHandler(object sender, EventArgs e)
        {
            Export();
        }
    }
}
