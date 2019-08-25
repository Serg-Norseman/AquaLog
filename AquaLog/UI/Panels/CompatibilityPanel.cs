/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;

namespace AquaLog.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public class CompatibilityPanel : ListPanel
    {
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

        private readonly SpeciesTypeData[] fData;

        public CompatibilityPanel() : base()
        {
            ListView.Columns.Add("SpeciesType", 200, HorizontalAlignment.Left);
            ListView.Columns.Add("Req Temp", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("Cur Temp", 100, HorizontalAlignment.Right);
            ListView.Columns.Add("Req PH", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("Cur PH", 100, HorizontalAlignment.Right);
            ListView.Columns.Add("Req GH", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("Cur GH", 100, HorizontalAlignment.Right);

            fData = new SpeciesTypeData[3];
            fData[0] = new SpeciesTypeData(SpeciesType.Fish.ToString());
            fData[1] = new SpeciesTypeData(SpeciesType.Invertebrate.ToString());
            fData[2] = new SpeciesTypeData(SpeciesType.Plant.ToString());
        }

        protected override void UpdateListView()
        {
            IEnumerable<Inhabitant> records = fModel.QueryInhabitants();
            foreach (Inhabitant rec in records) {
                Species spc = fModel.GetRecord<Species>(rec.SpeciesId);
                int speciesType = (int)spc.Type;
                var data = fData[speciesType];

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
            curTemp = GetCurrentMeasureValue("Temperature");
            curPH = GetCurrentMeasureValue("PH");
            curGH = GetCurrentMeasureValue("GH");

            foreach (var data in fData) {
                var item = new ListViewItem(data.Name);
                item.SubItems.Add(GetRangeStr(data.TempMin.GetResult(), data.TempMax.GetResult()));
                item.SubItems.Add(ALCore.GetDecimalStr(curTemp));
                item.SubItems.Add(GetRangeStr(data.PHMin.GetResult(), data.PHMax.GetResult()));
                item.SubItems.Add(ALCore.GetDecimalStr(curPH));
                item.SubItems.Add(GetRangeStr(data.GHMin.GetResult(), data.GHMax.GetResult()));
                item.SubItems.Add(ALCore.GetDecimalStr(curGH));
                ListView.Items.Add(item);
            }
        }

        private double GetCurrentMeasureValue(string field)
        {
            // FIXME: debug id
            var aqm = fModel.GetRecord<Aquarium>(4);
            QDecimal measure = fModel.QueryLastMeasure(aqm, field);
            double mVal = (measure != null) ? measure.value : double.NaN;
            return mVal;
        }

        private string GetRangeStr(double min, double max)
        {
            if (double.IsNaN(min) && double.IsNaN(max)) {
                return string.Empty;
            }
            return ALCore.GetDecimalStr(min) + " - " + ALCore.GetDecimalStr(max);
        }
    }
}
