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

namespace AquaLog.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class AquaDetailsPanel : DataPanel
    {
        private Aquarium fAquarium;
        private Label fHeader;
        private TableLayoutPanel fLayoutPanel;
        private ListView fInhabitantsLV;
        private ListView fMeasuresLV;
        private ListView fNutritionLV;
        private ListView fDevicesLV;
        private ListView fMaintenanceLV;
        private ListView fCompatibilityLV;


        public AquaDetailsPanel() : base()
        {
            Padding = new Padding(10);

            fHeader = new Label();
            fHeader.BorderStyle = BorderStyle.Fixed3D;
            fHeader.Dock = DockStyle.Top;
            fHeader.Font = new Font(this.Font.FontFamily, 10, FontStyle.Bold, this.Font.Unit);
            fHeader.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(fHeader);

            fLayoutPanel = new TableLayoutPanel();
            fLayoutPanel.Dock = DockStyle.Fill;
            fLayoutPanel.AutoSize = true;
            fLayoutPanel.Padding = new Padding(10);
            fLayoutPanel.ColumnCount = 2;
            fLayoutPanel.RowCount = 3;
            Controls.Add(fLayoutPanel);

            fLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            fLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            fLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40f));
            fLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            fLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40f));
            fLayoutPanel.Padding = new Padding(0);

            Controls.SetChildIndex(fLayoutPanel, 0);
            Controls.SetChildIndex(fHeader, 1);

            fInhabitantsLV = UIHelper.CreateListView("InhabitantsLV");
            SetCellGroup(Localizer.LS(LSID.Inhabitants), fInhabitantsLV, 0, 0);

            fMeasuresLV = UIHelper.CreateListView("MeasuresLV");
            SetCellGroup(Localizer.LS(LSID.Measures), fMeasuresLV, 1, 0);

            fNutritionLV = UIHelper.CreateListView("NutritionLV");
            SetCellGroup(Localizer.LS(LSID.Nutrition), fNutritionLV, 0, 1);

            fDevicesLV = UIHelper.CreateListView("DevicesLV");
            SetCellGroup(Localizer.LS(LSID.Devices), fDevicesLV, 1, 1);

            fMaintenanceLV = UIHelper.CreateListView("MaintenanceLV");
            SetCellGroup(Localizer.LS(LSID.Maintenance), fMaintenanceLV, 0, 2);

            fCompatibilityLV = UIHelper.CreateListView("CompatibilityLV");
            SetCellGroup(Localizer.LS(LSID.Compatibility), fCompatibilityLV, 1, 2);
        }

        private void SetCellGroup(string name, ListView listView, int col, int row)
        {
            var groupBox = new GroupBox();
            groupBox.Dock = DockStyle.Fill;
            groupBox.Text = name;
            groupBox.Controls.Add(listView);
            fLayoutPanel.Controls.Add(groupBox, col, row);
        }

        public override void SetExtData(object extData)
        {
            fAquarium = (Aquarium)extData;
            UpdateContent();
        }

        public override void UpdateContent()
        {
            if (fAquarium != null) {
                fHeader.Text = fAquarium.Name;

                FillInhabitantsList();
                FillMeasuresList();
                FillNutritionList();
                FillDevicesList();
                FillMaintenanceList();
                FillCompatibilityList();
            }
        }

        private void FillInhabitantsList()
        {
            fInhabitantsLV.BeginUpdate();
            fInhabitantsLV.Clear();
            fInhabitantsLV.Columns.Add(Localizer.LS(LSID.Name), 200, HorizontalAlignment.Left);
            fInhabitantsLV.Columns.Add(Localizer.LS(LSID.Sex), 50, HorizontalAlignment.Left);
            fInhabitantsLV.Columns.Add(Localizer.LS(LSID.Quantity), 50, HorizontalAlignment.Right);
            fInhabitantsLV.Columns.Add(Localizer.LS(LSID.InclusionDate), 150, HorizontalAlignment.Left);
            fInhabitantsLV.Columns.Add("Temp", 100, HorizontalAlignment.Left);
            fInhabitantsLV.Columns.Add("PH", 100, HorizontalAlignment.Left);
            fInhabitantsLV.Columns.Add("GH", 100, HorizontalAlignment.Left);

            IEnumerable<Inhabitant> records = fModel.QueryInhabitants(fAquarium);
            foreach (Inhabitant rec in records) {
                Species spc = fModel.GetRecord<Species>(rec.SpeciesId);
                string sex = ALCore.IsAnimal(spc.Type) ? Localizer.LS(ALData.SexNames[(int)rec.Sex]) : string.Empty;

                ItemType itemType = ALCore.GetItemType(spc.Type);
                int qty = fModel.QueryInhabitantsCount(rec.Id, itemType);
                if (qty == 0) continue; // death, sale or gift?

                int currAqmId = 0;
                DateTime intrDate = ALCore.ZeroDate;
                IList<Transfer> lastTransfers = fModel.QueryLastTransfers(rec.Id, (int)itemType);
                if (lastTransfers.Count > 0) {
                    currAqmId = lastTransfers[0].TargetId;
                    intrDate = lastTransfers[0].Timestamp;
                }
                string strIntrDate = (intrDate.Equals(ALCore.ZeroDate)) ? string.Empty : ALCore.GetDateStr(intrDate);

                var item = new ListViewItem(rec.Name);
                item.Tag = rec;
                item.SubItems.Add(sex);
                item.SubItems.Add(qty.ToString());
                item.SubItems.Add(strIntrDate);
                item.SubItems.Add(spc.GetTempRange());
                item.SubItems.Add(spc.GetPHRange());
                item.SubItems.Add(spc.GetGHRange());
                fInhabitantsLV.Items.Add(item);
            }

            fInhabitantsLV.AutoResizeColumns();
            fInhabitantsLV.EndUpdate();
        }

        private void FillMeasuresList()
        {
            fMeasuresLV.BeginUpdate();
            fMeasuresLV.Clear();
            fMeasuresLV.Columns.Add(Localizer.LS(LSID.Name), 200, HorizontalAlignment.Left);
            fMeasuresLV.Columns.Add(Localizer.LS(LSID.Value), 50, HorizontalAlignment.Right);
            fMeasuresLV.Columns.Add(Localizer.LS(LSID.Unit), 200, HorizontalAlignment.Left);

            var values = fModel.CollectData(fAquarium);
            foreach (MeasureValue mVal in values) {
                var item = new ListViewItem(mVal.Name);
                item.Tag = mVal;
                item.SubItems.Add(mVal.ValText);
                item.SubItems.Add(mVal.Unit);
                fMeasuresLV.Items.Add(item);
            }

            fMeasuresLV.AutoResizeColumns();
            fMeasuresLV.EndUpdate();
        }

        private void FillNutritionList()
        {
            fNutritionLV.BeginUpdate();
            fNutritionLV.Clear();
            fNutritionLV.Columns.Add(Localizer.LS(LSID.Name), 100, HorizontalAlignment.Left);
            fNutritionLV.Columns.Add(Localizer.LS(LSID.Brand), 50, HorizontalAlignment.Left);
            fNutritionLV.Columns.Add(Localizer.LS(LSID.Amount), 100, HorizontalAlignment.Right);

            var records = fModel.QueryNutritions(fAquarium);
            foreach (Nutrition rec in records) {
                var item = new ListViewItem(rec.Name);
                item.Tag = rec;
                item.SubItems.Add(rec.Brand);
                item.SubItems.Add(ALCore.GetDecimalStr(rec.Amount));
                fNutritionLV.Items.Add(item);
            }

            fNutritionLV.AutoResizeColumns();
            fNutritionLV.EndUpdate();
        }

        private void FillDevicesList()
        {
            fDevicesLV.BeginUpdate();
            fDevicesLV.Clear();
            fDevicesLV.Columns.Add(Localizer.LS(LSID.Name), 100, HorizontalAlignment.Left);
            fDevicesLV.Columns.Add(Localizer.LS(LSID.Brand), 50, HorizontalAlignment.Left);
            fDevicesLV.Columns.Add(Localizer.LS(LSID.Enabled), 60, HorizontalAlignment.Left);
            fDevicesLV.Columns.Add(Localizer.LS(LSID.Digital), 60, HorizontalAlignment.Left);
            fDevicesLV.Columns.Add(Localizer.LS(LSID.Power), 100, HorizontalAlignment.Right);

            var records = fModel.QueryDevices(fAquarium);
            foreach (Device rec in records) {
                var item = new ListViewItem(rec.Name);
                item.Tag = rec;
                item.SubItems.Add(rec.Brand);
                item.SubItems.Add(rec.Enabled.ToString());
                item.SubItems.Add(rec.Digital.ToString());
                item.SubItems.Add(ALCore.GetDecimalStr(rec.Power));
                fDevicesLV.Items.Add(item);
            }

            fDevicesLV.AutoResizeColumns();
            fDevicesLV.EndUpdate();
        }

        private void FillMaintenanceList()
        {
            fMaintenanceLV.BeginUpdate();
            fMaintenanceLV.Clear();
            fMaintenanceLV.Columns.Add(Localizer.LS(LSID.Date), 120, HorizontalAlignment.Left);
            fMaintenanceLV.Columns.Add(Localizer.LS(LSID.Type), 100, HorizontalAlignment.Left);
            fMaintenanceLV.Columns.Add(Localizer.LS(LSID.Value), 100, HorizontalAlignment.Left);
            fMaintenanceLV.Columns.Add(Localizer.LS(LSID.Note), 250, HorizontalAlignment.Left);

            var records = fModel.QueryMaintenances(fAquarium.Id);
            foreach (Maintenance rec in records) {
                string strType = Localizer.LS(ALData.MaintenanceTypes[(int)rec.Type]);

                var item = new ListViewItem(ALCore.GetTimeStr(rec.Timestamp));
                item.Tag = rec;
                item.SubItems.Add(strType);
                item.SubItems.Add(ALCore.GetDecimalStr(rec.Value));
                item.SubItems.Add(rec.Note);
                fMaintenanceLV.Items.Add(item);
            }

            fMaintenanceLV.AutoResizeColumns();
            fMaintenanceLV.EndUpdate();
        }

        private class SpeciesTypeData
        {
            public string Name;

            public Average PHMin;
            public Average PHMax;
            public Average GHMin;
            public Average GHMax;
            public Average TempMin;
            public Average TempMax;

            public SpeciesTypeData(string name)
            {
                Name = name;
            }
        }

        private void FillCompatibilityList()
        {
            fCompatibilityLV.BeginUpdate();
            fCompatibilityLV.Clear();
            fCompatibilityLV.Columns.Add(Localizer.LS(LSID.SpeciesS), 200, HorizontalAlignment.Left);
            fCompatibilityLV.Columns.Add("Req Temp", 100, HorizontalAlignment.Left);
            fCompatibilityLV.Columns.Add("Cur Temp", 100, HorizontalAlignment.Right);
            fCompatibilityLV.Columns.Add("Req PH", 100, HorizontalAlignment.Left);
            fCompatibilityLV.Columns.Add("Cur PH", 100, HorizontalAlignment.Right);
            fCompatibilityLV.Columns.Add("Req GH", 100, HorizontalAlignment.Left);
            fCompatibilityLV.Columns.Add("Cur GH", 100, HorizontalAlignment.Right);

            SpeciesTypeData[] stData;
            stData = new SpeciesTypeData[4];
            stData[0] = new SpeciesTypeData(Localizer.LS(LSID.Fish));
            stData[1] = new SpeciesTypeData(Localizer.LS(LSID.Invertebrate));
            stData[2] = new SpeciesTypeData(Localizer.LS(LSID.Plant));
            stData[3] = new SpeciesTypeData(Localizer.LS(LSID.Coral));

            IEnumerable<Inhabitant> records = fModel.QueryInhabitants();
            foreach (Inhabitant rec in records) {
                Species spc = fModel.GetRecord<Species>(rec.SpeciesId);
                int speciesType = (int)spc.Type;
                var data = stData[speciesType];

                if (spc.GHMin != 0.0f || spc.GHMax != 0.0f) {
                    data.GHMin.AddValue(spc.GHMin);
                    data.GHMax.AddValue(spc.GHMax);
                }

                if (spc.PHMin != 0.0f || spc.PHMax != 0.0f) {
                    data.PHMin.AddValue(spc.PHMin);
                    data.PHMax.AddValue(spc.PHMax);
                }

                if (spc.TempMin != 0.0f || spc.TempMax != 0.0f) {
                    data.TempMin.AddValue(spc.TempMin);
                    data.TempMax.AddValue(spc.TempMax);
                }
            }

            double curTemp, curPH, curGH;
            curTemp = fModel.GetCurrentMeasureValue(fAquarium, "Temperature");
            curPH = fModel.GetCurrentMeasureValue(fAquarium, "PH");
            curGH = fModel.GetCurrentMeasureValue(fAquarium, "GH");

            foreach (var data in stData) {
                string rangeTemp = ALCore.GetRangeStr(data.TempMin.GetResult(), data.TempMax.GetResult());
                string rangePH = ALCore.GetRangeStr(data.PHMin.GetResult(), data.PHMax.GetResult());
                string rangeGH = ALCore.GetRangeStr(data.GHMin.GetResult(), data.GHMax.GetResult());
                if (string.IsNullOrEmpty(rangeTemp) && string.IsNullOrEmpty(rangePH) && string.IsNullOrEmpty(rangeGH)) continue;

                var item = new ListViewItem(data.Name);
                item.SubItems.Add(rangeTemp);
                item.SubItems.Add(ALCore.GetDecimalStr(curTemp));
                item.SubItems.Add(rangePH);
                item.SubItems.Add(ALCore.GetDecimalStr(curPH));
                item.SubItems.Add(rangeGH);
                item.SubItems.Add(ALCore.GetDecimalStr(curGH));
                fCompatibilityLV.Items.Add(item);
            }

            fCompatibilityLV.AutoResizeColumns();
            fCompatibilityLV.EndUpdate();
        }
    }
}
