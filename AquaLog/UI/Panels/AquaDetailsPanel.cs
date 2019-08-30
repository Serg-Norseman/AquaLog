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
using AquaLog.UI;

namespace AquaLog.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public class AquaDetailsPanel : DataPanel
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
            SetCellGroup("Inhabitants", fInhabitantsLV, 0, 0);

            fMeasuresLV = UIHelper.CreateListView("MeasuresLV");
            SetCellGroup("Measures", fMeasuresLV, 1, 0);

            fNutritionLV = UIHelper.CreateListView("NutritionLV");
            SetCellGroup("Nutrition", fNutritionLV, 0, 1);

            fDevicesLV = UIHelper.CreateListView("DevicesLV");
            SetCellGroup("Devices", fDevicesLV, 1, 1);

            fMaintenanceLV = UIHelper.CreateListView("MaintenanceLV");
            SetCellGroup("Maintenance", fMaintenanceLV, 0, 2);

            fCompatibilityLV = UIHelper.CreateListView("CompatibilityLV");
            SetCellGroup("Compatibility", fCompatibilityLV, 1, 2);
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
        }

        public override void UpdateContent()
        {
            fHeader.Text = fAquarium.Name;

            FillInhabitantsList();
            FillMeasuresList();
            FillNutritionList();
            FillDevicesList();
            FillMaintenanceList();
            FillCompatibilityList();
        }

        private void FillInhabitantsList()
        {
            fInhabitantsLV.BeginUpdate();
            fInhabitantsLV.Clear();
            fInhabitantsLV.Columns.Add("Name", 200, HorizontalAlignment.Left);
            fInhabitantsLV.Columns.Add("Sex", 50, HorizontalAlignment.Left);
            fInhabitantsLV.Columns.Add("Qty", 50, HorizontalAlignment.Right);
            fInhabitantsLV.Columns.Add("Introduction date", 150, HorizontalAlignment.Left);
            fInhabitantsLV.Columns.Add("Temp", 100, HorizontalAlignment.Left);
            fInhabitantsLV.Columns.Add("PH", 100, HorizontalAlignment.Left);
            fInhabitantsLV.Columns.Add("GH", 100, HorizontalAlignment.Left);

            IEnumerable<Inhabitant> records = fModel.QueryInhabitants(fAquarium);
            foreach (Inhabitant rec in records) {
                Species spc = fModel.GetRecord<Species>(rec.SpeciesId);
                string sex = ALCore.IsAnimal(spc.Type) ? rec.Sex.ToString() : string.Empty;
                ItemType itemType = ALCore.GetItemType(spc.Type);
                int qty = fModel.QueryInhabitantsCount(rec.Id, itemType);

                int currAqmId = 0;
                DateTime intrDate = ALCore.ZeroDate;
                IList<Transfer> lastTransfers = fModel.QueryLastTransfers(rec.Id, (int)itemType);
                if (lastTransfers.Count > 0) {
                    currAqmId = lastTransfers[0].TargetId;
                    intrDate = lastTransfers[0].Date;
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

            fInhabitantsLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            fInhabitantsLV.EndUpdate();
        }

        private void FillMeasuresList()
        {
            fMeasuresLV.BeginUpdate();
            fMeasuresLV.Clear();
            fMeasuresLV.Columns.Add("Name", 200, HorizontalAlignment.Left);
            fMeasuresLV.Columns.Add("Value", 50, HorizontalAlignment.Right);
            fMeasuresLV.Columns.Add("Unit", 200, HorizontalAlignment.Left);

            var values = fModel.CollectData(fAquarium);
            foreach (MeasureValue mVal in values) {
                var item = new ListViewItem(mVal.Name);
                item.Tag = mVal;
                item.SubItems.Add(mVal.ValText);
                item.SubItems.Add(mVal.Unit);
                fMeasuresLV.Items.Add(item);
            }

            fMeasuresLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            fMeasuresLV.EndUpdate();
        }

        private void FillNutritionList()
        {
            fNutritionLV.BeginUpdate();
            fNutritionLV.Clear();
            fNutritionLV.Columns.Add("Name", 100, HorizontalAlignment.Left);
            fNutritionLV.Columns.Add("Brand", 50, HorizontalAlignment.Left);
            fNutritionLV.Columns.Add("Amount", 100, HorizontalAlignment.Right);

            var records = fModel.QueryNutritions(fAquarium);
            foreach (Nutrition rec in records) {
                var item = new ListViewItem(rec.Name);
                item.Tag = rec;
                item.SubItems.Add(rec.Brand);
                item.SubItems.Add(ALCore.GetDecimalStr(rec.Amount));
                fNutritionLV.Items.Add(item);
            }

            fNutritionLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            fNutritionLV.EndUpdate();
        }

        private void FillDevicesList()
        {
            fDevicesLV.BeginUpdate();
            fDevicesLV.Clear();
            fDevicesLV.Columns.Add("Name", 100, HorizontalAlignment.Left);
            fDevicesLV.Columns.Add("Enabled", 60, HorizontalAlignment.Left);
            fDevicesLV.Columns.Add("Digital", 60, HorizontalAlignment.Left);
            fDevicesLV.Columns.Add("Brand", 50, HorizontalAlignment.Left);
            fDevicesLV.Columns.Add("Wattage", 100, HorizontalAlignment.Right);

            var records = fModel.QueryDevices(fAquarium);
            foreach (Device rec in records) {
                var item = new ListViewItem(rec.Name);
                item.Tag = rec;
                item.SubItems.Add(rec.Enabled.ToString());
                item.SubItems.Add(rec.Digital.ToString());
                item.SubItems.Add(rec.Brand);
                item.SubItems.Add(ALCore.GetDecimalStr(rec.Wattage));
                fDevicesLV.Items.Add(item);
            }

            fDevicesLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            fDevicesLV.EndUpdate();
        }

        private void FillMaintenanceList()
        {
            fMaintenanceLV.BeginUpdate();
            fMaintenanceLV.Clear();
            fMaintenanceLV.Columns.Add("DateTime", 120, HorizontalAlignment.Left);
            fMaintenanceLV.Columns.Add("Type", 100, HorizontalAlignment.Left);
            fMaintenanceLV.Columns.Add("Value", 100, HorizontalAlignment.Left);
            fMaintenanceLV.Columns.Add("Note", 250, HorizontalAlignment.Left);

            var records = fModel.QueryMaintenances(fAquarium.Id);
            foreach (Maintenance rec in records) {
                var item = new ListViewItem(rec.DateTime.ToString());
                item.Tag = rec;
                item.SubItems.Add(rec.Type.ToString());
                item.SubItems.Add(ALCore.GetDecimalStr(rec.Value));
                item.SubItems.Add(rec.Note);
                fMaintenanceLV.Items.Add(item);
            }

            fMaintenanceLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
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
            fCompatibilityLV.Columns.Add("SpeciesType", 200, HorizontalAlignment.Left);
            fCompatibilityLV.Columns.Add("Req Temp", 100, HorizontalAlignment.Left);
            fCompatibilityLV.Columns.Add("Cur Temp", 100, HorizontalAlignment.Right);
            fCompatibilityLV.Columns.Add("Req PH", 100, HorizontalAlignment.Left);
            fCompatibilityLV.Columns.Add("Cur PH", 100, HorizontalAlignment.Right);
            fCompatibilityLV.Columns.Add("Req GH", 100, HorizontalAlignment.Left);
            fCompatibilityLV.Columns.Add("Cur GH", 100, HorizontalAlignment.Right);

            SpeciesTypeData[] stData;
            stData = new SpeciesTypeData[4];
            stData[0] = new SpeciesTypeData(SpeciesType.Fish.ToString());
            stData[1] = new SpeciesTypeData(SpeciesType.Invertebrate.ToString());
            stData[2] = new SpeciesTypeData(SpeciesType.Plant.ToString());
            stData[3] = new SpeciesTypeData(SpeciesType.Coral.ToString());

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
                var item = new ListViewItem(data.Name);
                item.SubItems.Add(ALCore.GetRangeStr(data.TempMin.GetResult(), data.TempMax.GetResult()));
                item.SubItems.Add(ALCore.GetDecimalStr(curTemp));
                item.SubItems.Add(ALCore.GetRangeStr(data.PHMin.GetResult(), data.PHMax.GetResult()));
                item.SubItems.Add(ALCore.GetDecimalStr(curPH));
                item.SubItems.Add(ALCore.GetRangeStr(data.GHMin.GetResult(), data.GHMax.GetResult()));
                item.SubItems.Add(ALCore.GetDecimalStr(curGH));
                fCompatibilityLV.Items.Add(item);
            }

            fCompatibilityLV.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            fCompatibilityLV.EndUpdate();
        }
    }
}
