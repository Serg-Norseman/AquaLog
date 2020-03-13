/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
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
        private readonly Label fFooter;

        public InhabitantPanel() : base()
        {
            fFooter = new Label();
            fFooter.BorderStyle = BorderStyle.Fixed3D;
            fFooter.Dock = DockStyle.Bottom;
            fFooter.Font = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold, this.Font.Unit);
            fFooter.TextAlign = ContentAlignment.MiddleLeft;
            Controls.Add(fFooter);

            Controls.SetChildIndex(ListView, 0);
            Controls.SetChildIndex(fFooter, 1);
        }

        protected override void InitActions()
        {
            AddAction("Add", LSID.Add, "btn_rec_new.gif", AddHandler);
            AddAction("Edit", LSID.Edit, "btn_rec_edit.gif", EditHandler);
            AddAction("Delete", LSID.Delete, "btn_rec_delete.gif", DeleteHandler);
            AddAction("Transfer", LSID.Transfer, null, TransferHandler);
            AddAction("Chart", LSID.Chart, "", ViewLifeLinesHandler);
            AddAction("ChartFamilies", LSID.ChartFamilies, "", ViewChartFamiliesHandler);
            AddAction("Export", LSID.Export, "btn_excel.gif", ExportHandler);

            AddAction("BioTreemap", LSID.BioTreemap, "", ViewBioTreemapHandler);
        }

        public override void SelectionChanged(IList<Entity> records)
        {
            bool enabled = (records.Count == 1);

            SetActionEnabled("Edit", enabled);
            SetActionEnabled("Delete", enabled);
            SetActionEnabled("Transfer", enabled);
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

            Average avgLifespan = new Average();
            IList<Inhabitant> records = fModel.QueryInhabitants();
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

                rec.Quantity = fModel.QueryInhabitantsCount(rec.Id, itemType);
                bool fin = (rec.Quantity == 0);

                int currAqmId = 0;
                DateTime inclusionDate, exclusionDate;
                fModel.GetInhabitantDates(rec.Id, itemType, out inclusionDate, out exclusionDate, out currAqmId);

                string aqmName = fModel.GetRecordName(ItemType.Aquarium, currAqmId);
                string strInclusDate = ALCore.IsZeroDate(inclusionDate) ? string.Empty : ALCore.GetDateStr(inclusionDate);
                string strExclusDate = ALCore.IsZeroDate(exclusionDate) || !fin ? string.Empty : ALCore.GetDateStr(exclusionDate);

                DateTime endDate = ALCore.IsZeroDate(exclusionDate) || !fin ? DateTime.Now.Date : exclusionDate;
                string strLifespan = ALCore.IsZeroDate(inclusionDate) ? string.Empty : ALCore.GetTimespanText(inclusionDate, endDate);

                if (!ALCore.IsZeroDate(exclusionDate)) {
                    int iDays = (exclusionDate - inclusionDate).Days;
                    avgLifespan.AddValue(iDays);
                }

                ItemState itemState;
                string strState = fModel.GetItemStateStr(rec.Id, itemType, out itemState);
                if (itemState == ItemState.Unknown || !fin) {
                    strState = Localizer.LS(ALData.ItemStates[(int)rec.State]);
                }

                var item = ListView.AddItemEx(rec,
                               rec.Name,
                               sx,
                               rec.Quantity.ToString(),
                               spName,
                               strState,
                               aqmName,
                               strInclusDate,
                               strExclusDate,
                               strLifespan,
                               spTemp,
                               spPH,
                               spGH
                           );

                if (rec.Quantity == 0) {
                    item.ForeColor = Color.Gray; // death, sale or gift?
                }
            }

            ListView.Sort(6, SortOrder.Ascending);

            fFooter.Text = string.Format(Localizer.LS(LSID.LifeExpectancy) + ": {0}", ALCore.GetTimespanText((int)avgLifespan.GetResult()));
        }

        private void TransferHandler(object sender, EventArgs e)
        {
            var record = ListView.GetSelectedTag<Inhabitant>();
            if (record == null) return;

            SpeciesType speciesType = fModel.GetSpeciesType(record.SpeciesId);
            ItemType itemType = ALCore.GetItemType(speciesType);
            Browser.TransferItem(itemType, record.Id, this);
        }

        private void ViewLifeLinesHandler(object sender, EventArgs e)
        {
            Browser.SetView(MainView.LifeLinesChart, null);
        }

        private void ViewChartFamiliesHandler(object sender, EventArgs e)
        {
            var chartData = GetChartData();
            Browser.SetView(MainView.PieChart, new ChartSeries("", ChartStyle.Pie, chartData, Color.Transparent));
        }

        private void ViewBioTreemapHandler(object sender, EventArgs e)
        {
            Browser.SetView(MainView.BioTreemap, null);
        }

        private IList<ChartPoint> GetChartData()
        {
            Dictionary<string, ChartPoint> result = new Dictionary<string, ChartPoint>();

            IList<Inhabitant> records = fModel.QueryInhabitants();
            foreach (Inhabitant rec in records) {
                Species spc = fModel.GetRecord<Species>(rec.SpeciesId);
                if (spc == null) continue;

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

        private void ExportHandler(object sender, EventArgs e)
        {
            Export();
        }
    }
}
