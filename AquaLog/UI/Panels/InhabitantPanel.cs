/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;
using AquaLog.UI.Components;
using AquaLog.UI.Dialogs;

namespace AquaLog.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class InhabitantPanel : ListPanel<Inhabitant, InhabitantEditDlg>
    {
        public InhabitantPanel() : base()
        {
        }

        protected override void InitActions()
        {
            AddAction("Add", LSID.Add, "btn_rec_new.gif", AddHandler);
            AddAction("Edit", LSID.Edit, "btn_rec_edit.gif", EditHandler);
            AddAction("Delete", LSID.Delete, "btn_rec_delete.gif", DeleteHandler);
            AddAction("Transfer", LSID.Transfer, null, TransferHandler);
            AddAction("Chart", LSID.Chart, "", ViewLifeLinesHandler);
            AddAction("ChartFamilies", LSID.ChartFamilies, "", ViewChartFamiliesHandler);
        }

        protected override void UpdateListView()
        {
            ListView.Clear();
            ListView.Columns.Add(Localizer.LS(LSID.Name), 200, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Sex), 50, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Quantity), 50, HorizontalAlignment.Right);
            ListView.Columns.Add(Localizer.LS(LSID.SpeciesS), 150, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.State), 80, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Aquarium), 150, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.InclusionDate), 150, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.ExclusionDate), 150, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.LifeSpan), 150, HorizontalAlignment.Left);
            ListView.Columns.Add("Temp", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("PH", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("GH", 100, HorizontalAlignment.Left);

            // TODO: need to add protection of item adding and cells filling
            IEnumerable<Inhabitant> records = fModel.QueryInhabitants();
            foreach (Inhabitant rec in records) {
                Species spc = fModel.GetRecord<Species>(rec.SpeciesId);

                SpeciesType spType;
                string spName, spTemp, spGH, spPH;
                if (spc == null) {
                    spType = SpeciesType.Fish;
                    spName = string.Empty;
                    spTemp = string.Empty;
                    spGH = string.Empty;
                    spPH = string.Empty;
                } else {
                    spType = spc.Type;
                    spName = spc.Name;
                    spTemp = spc.GetTempRange();
                    spGH = spc.GetGHRange();
                    spPH = spc.GetPHRange();
                }

                string sx = ALCore.IsAnimal(spType) ? Localizer.LS(ALData.SexNames[(int)rec.Sex]) : string.Empty;
                SpeciesType speciesType = fModel.GetSpeciesType(rec.SpeciesId);
                ItemType itemType = ALCore.GetItemType(speciesType);

                int currAqmId = 0;
                DateTime inclusionDate, exclusionDate;
                fModel.GetInhabitantDates(rec.Id, (int)itemType, out inclusionDate, out exclusionDate, out currAqmId);

                string aqmName = fModel.GetRecordName(ItemType.Aquarium, currAqmId);
                string strInclusDate = (inclusionDate.Equals(ALCore.ZeroDate)) ? string.Empty : ALCore.GetDateStr(inclusionDate);
                string strExclusDate = (exclusionDate.Equals(ALCore.ZeroDate)) ? string.Empty : ALCore.GetDateStr(exclusionDate);

                DateTime endDate = (exclusionDate.Equals(ALCore.ZeroDate)) ? DateTime.Now.Date : exclusionDate;
                string strLifespan = (inclusionDate.Equals(ALCore.ZeroDate)) ? string.Empty : ALCore.GetTimespanText(inclusionDate, endDate);

                rec.Quantity = fModel.QueryInhabitantsCount(rec.Id, itemType);

                var item = new ListViewItem(rec.Name);
                item.Tag = rec;
                item.SubItems.Add(sx);
                item.SubItems.Add(rec.Quantity.ToString());
                item.SubItems.Add(spName);
                item.SubItems.Add(Localizer.LS(ALData.ItemStates[(int)rec.State]));
                item.SubItems.Add(aqmName);
                item.SubItems.Add(strInclusDate);
                item.SubItems.Add(strExclusDate);
                item.SubItems.Add(strLifespan);
                item.SubItems.Add(spTemp);
                item.SubItems.Add(spPH);
                item.SubItems.Add(spGH);

                if (rec.Quantity == 0) {
                    item.ForeColor = Color.Gray; // death, sale or gift?
                }

                ListView.Items.Add(item);
            }
        }

        private void TransferHandler(object sender, EventArgs e)
        {
            var record = ListView.GetSelectedTag<Inhabitant>();
            if (record == null) return;

            SpeciesType speciesType = fModel.GetSpeciesType(record.SpeciesId);
            ItemType itemType = ALCore.GetItemType(speciesType);

            var transfer = new Transfer();
            transfer.ItemType = itemType;
            transfer.ItemId = record.Id;

            using (var dlg = new TransferEditDlg()) {
                dlg.Model = fModel;
                dlg.Record = transfer;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fModel.AddRecord(dlg.Record);
                    UpdateContent();
                }
            }
        }

        private void ViewLifeLinesHandler(object sender, EventArgs e)
        {
            Browser.SetView(MainView.LifeLinesChart, null);
        }

        private void ViewChartFamiliesHandler(object sender, EventArgs e)
        {
            var chartData = GetChartData();
            Browser.SetView(MainView.PieChart, chartData);
        }

        private IList<ChartPoint> GetChartData()
        {
            Dictionary<string, ChartPoint> result = new Dictionary<string, ChartPoint>();

            IEnumerable<Inhabitant> records = fModel.QueryInhabitants();
            foreach (Inhabitant rec in records) {
                Species spc = fModel.GetRecord<Species>(rec.SpeciesId);
                SpeciesType speciesType = fModel.GetSpeciesType(rec.SpeciesId);
                ItemType itemType = ALCore.GetItemType(speciesType);
                var qty = fModel.QueryInhabitantsCount(rec.Id, itemType);

                string key = spc.BioFamily;
                if (!string.IsNullOrEmpty(key)) {
                    ChartPoint chartPoint;
                    if (result.TryGetValue(key, out chartPoint)) {
                        chartPoint.Value += qty;
                        result[key] = chartPoint;
                    } else {
                        chartPoint = new ChartPoint(key, qty);
                        result.Add(key, chartPoint);
                    }
                }
            }

            List<ChartPoint> vals = new List<ChartPoint>();
            foreach (var valPair in result) {
                vals.Add(valPair.Value);
            }

            return vals;
        }
    }
}
