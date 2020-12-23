/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Core.Types;
using AquaMate.UI.Components;
using BSLib.Design;

namespace AquaMate.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class AquaDetailsPanel : DataPanel
    {
        private Aquarium fAquarium;

        private readonly Label fHeader;
        private readonly Grid fLayoutPanel;
        private readonly ZListView fInhabitantsLV;
        private readonly ZListView fMeasuresLV;
        private readonly ZListView fNutritionLV;
        private readonly ZListView fDevicesLV;
        private readonly ZListView fMaintenanceLV;
        private readonly ZListView fCompatibilityLV;


        public AquaDetailsPanel() : base()
        {
            Padding = new Thickness(10);

            fHeader = new Label();
            //fHeader.BorderStyle = BorderStyle.Fixed3D;
            //fHeader.Dock = DockStyle.Top;
            //fHeader.Font = new Font(this.Font.FontFamily, 10, FontStyle.Bold, this.Font.Unit);
            //fHeader.TextAlign = ContentAlignment.MiddleCenter;

            fLayoutPanel = new Grid();
            //fLayoutPanel.Padding = new Padding(10);
            fLayoutPanel.ColumnDefinitions.Add(new ColumnDefinition());
            fLayoutPanel.ColumnDefinitions.Add(new ColumnDefinition());
            fLayoutPanel.RowDefinitions.Add(new RowDefinition());
            fLayoutPanel.RowDefinitions.Add(new RowDefinition());
            fLayoutPanel.RowDefinitions.Add(new RowDefinition());

            var stackPanel = new StackPanel() {
                Children = {
                    fHeader,
                    fLayoutPanel
                }
            };
            Content = stackPanel;

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
            groupBox.Header = name;
            groupBox.Content = listView;
            Grid.SetRow(groupBox, row);
            Grid.SetColumn(groupBox, col);
            fLayoutPanel.Children.Add(groupBox);
        }

        public override void SetExtData(object extData)
        {
            fAquarium = (Aquarium)extData;
            UpdateContent();
        }

        public override void UpdateContent()
        {
            if (fAquarium != null) {
                fHeader.Content = fAquarium.Name;

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
            fInhabitantsLV.AddColumn(Localizer.LS(LSID.Name), 200, true, BSDTypes.HorizontalAlignment.Left);
            fInhabitantsLV.AddColumn(Localizer.LS(LSID.Sex), 50, true, BSDTypes.HorizontalAlignment.Left);
            fInhabitantsLV.AddColumn(Localizer.LS(LSID.Quantity), 50, true, BSDTypes.HorizontalAlignment.Right);
            fInhabitantsLV.AddColumn(Localizer.LS(LSID.InclusionDate), 150, true, BSDTypes.HorizontalAlignment.Left);
            fInhabitantsLV.AddColumn("Temp", 100, true, BSDTypes.HorizontalAlignment.Left);
            fInhabitantsLV.AddColumn("PH", 100, true, BSDTypes.HorizontalAlignment.Left);
            fInhabitantsLV.AddColumn("GH", 100, true, BSDTypes.HorizontalAlignment.Left);

            IList<Inhabitant> records = fModel.QueryInhabitants(fAquarium);
            foreach (Inhabitant rec in records) {
                Species spc = fModel.GetRecord<Species>(rec.SpeciesId);

                string sex, spTemp, spGH, spPH;
                ItemType itemType;
                if (spc != null) {
                    sex = ALCore.IsAnimal(spc.Type) ? Localizer.LS(ALData.SexNames[(int)rec.Sex]) : string.Empty;
                    itemType = ALCore.GetItemType(spc.Type);
                    spTemp = spc.GetTempRange();
                    spGH = spc.GetGHRange();
                    spPH = spc.GetPHRange();
                } else {
                    sex = string.Empty;
                    itemType = ItemType.Fish;
                    spTemp = string.Empty;
                    spGH = string.Empty;
                    spPH = string.Empty;
                }

                int qty = fModel.QueryInhabitantsCount(rec.Id, itemType);
                if (qty == 0) continue; // death, sale or gift?

                DateTime intrDate = ALCore.ZeroDate;
                IList<Transfer> lastTransfers = fModel.QueryLastTransfers(rec.Id, (int)itemType);
                if (lastTransfers.Count > 0) {
                    intrDate = lastTransfers[0].Timestamp;
                }
                string strIntrDate = ALCore.IsZeroDate(intrDate) ? string.Empty : ALCore.GetDateStr(intrDate);

                var item = fInhabitantsLV.AddItem(rec,
                               rec.Name,
                               sex,
                               qty.ToString(),
                               strIntrDate,
                               spTemp,
                               spPH,
                               spGH
                           );
            }

            fInhabitantsLV.EndUpdate();
        }

        private void FillMeasuresList()
        {
            fMeasuresLV.BeginUpdate();
            fMeasuresLV.Clear();
            fMeasuresLV.AddColumn(Localizer.LS(LSID.Name), 200, true, BSDTypes.HorizontalAlignment.Left);
            fMeasuresLV.AddColumn(Localizer.LS(LSID.Value), 50, true, BSDTypes.HorizontalAlignment.Right);
            fMeasuresLV.AddColumn(Localizer.LS(LSID.Unit), 200, true, BSDTypes.HorizontalAlignment.Left);

            var values = fModel.CollectData(fAquarium);
            foreach (MeasureValue mVal in values) {
                var item = fMeasuresLV.AddItem(mVal,
                               mVal.Name,
                               mVal.ValText,
                               mVal.Unit
                           );
            }

            fMeasuresLV.EndUpdate();
        }

        private void FillNutritionList()
        {
            fNutritionLV.BeginUpdate();
            fNutritionLV.Clear();
            fNutritionLV.AddColumn(Localizer.LS(LSID.Name), 100, true, BSDTypes.HorizontalAlignment.Left);
            fNutritionLV.AddColumn(Localizer.LS(LSID.Brand), 50, true, BSDTypes.HorizontalAlignment.Left);
            fNutritionLV.AddColumn(Localizer.LS(LSID.Amount), 100, true, BSDTypes.HorizontalAlignment.Right);

            var records = fModel.QueryNutritions(fAquarium);
            foreach (Nutrition rec in records) {
                var item = fNutritionLV.AddItem(rec,
                               rec.Name,
                               rec.Brand,
                               ALCore.GetDecimalStr(rec.Amount)
                           );
            }

            fNutritionLV.EndUpdate();
        }

        private void FillDevicesList()
        {
            fDevicesLV.BeginUpdate();
            fDevicesLV.Clear();
            fDevicesLV.AddColumn(Localizer.LS(LSID.Name), 100, true, BSDTypes.HorizontalAlignment.Left);
            fDevicesLV.AddColumn(Localizer.LS(LSID.Brand), 50, true, BSDTypes.HorizontalAlignment.Left);
            fDevicesLV.AddColumn(Localizer.LS(LSID.Enabled), 60, true, BSDTypes.HorizontalAlignment.Left);
            fDevicesLV.AddColumn(Localizer.LS(LSID.Digital), 60, true, BSDTypes.HorizontalAlignment.Left);
            fDevicesLV.AddColumn(Localizer.LS(LSID.Power), 100, true, BSDTypes.HorizontalAlignment.Right);

            var records = fModel.QueryDevices(fAquarium);
            foreach (Device rec in records) {
                var item = fDevicesLV.AddItem(rec,
                               rec.Name,
                               rec.Brand,
                               rec.Enabled.ToString(),
                               rec.Digital.ToString(),
                               ALCore.GetDecimalStr(rec.Power)
                           );
            }

            fDevicesLV.EndUpdate();
        }

        private void FillMaintenanceList()
        {
            fMaintenanceLV.BeginUpdate();
            fMaintenanceLV.Clear();
            fMaintenanceLV.AddColumn(Localizer.LS(LSID.Date), 120, true, BSDTypes.HorizontalAlignment.Left);
            fMaintenanceLV.AddColumn(Localizer.LS(LSID.Type), 100, true, BSDTypes.HorizontalAlignment.Left);
            fMaintenanceLV.AddColumn(Localizer.LS(LSID.Value), 100, true, BSDTypes.HorizontalAlignment.Right);
            fMaintenanceLV.AddColumn(Localizer.LS(LSID.Note), 250, true, BSDTypes.HorizontalAlignment.Left);

            var records = fModel.QueryMaintenances(fAquarium.Id);
            foreach (Maintenance rec in records) {
                string strType = Localizer.LS(ALData.MaintenanceTypes[(int)rec.Type].Name);

                var item = fMaintenanceLV.AddItem(rec,
                               ALCore.GetTimeStr(rec.Timestamp),
                               strType,
                               ALCore.GetDecimalStr(rec.Value),
                               rec.Note
                           );
            }

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

                PHMin = Average.Create();
                PHMax = Average.Create();
                GHMin = Average.Create();
                GHMax = Average.Create();
                TempMin = Average.Create();
                TempMax = Average.Create();
            }
        }

        private void FillCompatibilityList()
        {
            fCompatibilityLV.BeginUpdate();
            fCompatibilityLV.Clear();
            fCompatibilityLV.AddColumn(Localizer.LS(LSID.SpeciesS), 200, true, BSDTypes.HorizontalAlignment.Left);
            fCompatibilityLV.AddColumn("Req Temp", 100, true, BSDTypes.HorizontalAlignment.Left);
            fCompatibilityLV.AddColumn("Cur Temp", 100, true, BSDTypes.HorizontalAlignment.Right);
            fCompatibilityLV.AddColumn("Req PH", 100, true, BSDTypes.HorizontalAlignment.Left);
            fCompatibilityLV.AddColumn("Cur PH", 100, true, BSDTypes.HorizontalAlignment.Right);
            fCompatibilityLV.AddColumn("Req GH", 100, true, BSDTypes.HorizontalAlignment.Left);
            fCompatibilityLV.AddColumn("Cur GH", 100, true, BSDTypes.HorizontalAlignment.Right);

            SpeciesTypeData[] stData;
            stData = new SpeciesTypeData[4];
            stData[0] = new SpeciesTypeData(Localizer.LS(LSID.Fish));
            stData[1] = new SpeciesTypeData(Localizer.LS(LSID.Invertebrate));
            stData[2] = new SpeciesTypeData(Localizer.LS(LSID.Plant));
            stData[3] = new SpeciesTypeData(Localizer.LS(LSID.Coral));

            IList<Inhabitant> records = fModel.QueryInhabitants();
            foreach (Inhabitant rec in records) {
                Species spc = fModel.GetRecord<Species>(rec.SpeciesId);
                if (spc == null) continue;

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

                var item = fCompatibilityLV.AddItem(data,
                               data.Name,
                               rangeTemp,
                               ALCore.GetDecimalStr(curTemp),
                               rangePH,
                               ALCore.GetDecimalStr(curPH),
                               rangeGH,
                               ALCore.GetDecimalStr(curGH)
                           );
            }

            fCompatibilityLV.EndUpdate();
        }
    }
}
