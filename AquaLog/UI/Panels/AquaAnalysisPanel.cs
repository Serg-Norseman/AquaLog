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

namespace AquaLog.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public class AquaAnalysisPanel : ListPanel
    {
        private Aquarium fAquarium;

        public AquaAnalysisPanel() : base()
        {
        }

        public override void SetExtData(object extData)
        {
            fAquarium = (Aquarium)extData;
            UpdateContent();
        }

        protected override void UpdateListView()
        {
            ListView.Clear();

            ListView.Columns.Add(Localizer.LS(LSID.Date), 120, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Type), 100, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Value), 100, HorizontalAlignment.Right);
            ListView.Columns.Add(Localizer.LS(LSID.Note), 250, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.WaterVolume), 100, HorizontalAlignment.Right);
            ListView.Columns.Add("% change", 100, HorizontalAlignment.Right);
            ListView.Columns.Add("period change", 100, HorizontalAlignment.Right);

            ListView.Columns.Add("Temp (°C)", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("NO3 (mg/l)", 60, HorizontalAlignment.Right);
            //ListView.Columns.Add("NO2 (mg/l)", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("GH (°d)", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("KH (°d)", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("pH", 60, HorizontalAlignment.Right);
            //ListView.Columns.Add("Cl2 (mg/l)", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("CO2", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("NHtot", 60, HorizontalAlignment.Right);
            //ListView.Columns.Add("NH3", 60, HorizontalAlignment.Right);
            //ListView.Columns.Add("NH4", 60, HorizontalAlignment.Right);
            ListView.Columns.Add("PO4", 60, HorizontalAlignment.Right);

            if (fAquarium != null) {
                var events = new List<IEventEntity>();
                events.AddRange(fModel.QueryNotes(fAquarium.Id));
                events.AddRange(fModel.QueryMaintenances(fAquarium.Id));
                events.AddRange(fModel.QueryMeasures(fAquarium.Id));
                events.Sort((x, y) => { return x.Timestamp.CompareTo(y.Timestamp); });

                DateTime dtPrev = ALCore.ZeroDate;
                double prevVolume = 0.0d, curVolume = 0.0d, chngPercent;
                string prevTime = string.Empty, curTime;
                foreach (IEventEntity evnt in events) {
                    curTime = ALCore.GetTimeStr(evnt.Timestamp);
                    if (!prevTime.Equals(curTime)) {
                        prevTime = curTime;
                    }

                    if (evnt is Maintenance) {
                        Maintenance mnt = (Maintenance)evnt;

                        double changeValue = mnt.Value;
                        if (mnt.Type == MaintenanceType.Restart) {
                            prevVolume = curVolume;
                            curVolume = changeValue;
                        } else {
                            int factor = ALData.WaterChangeFactors[(int)mnt.Type];
                            if (factor != 0) {
                                prevVolume = curVolume;
                            }
                            curVolume += (changeValue * factor);
                        }
                        chngPercent = (changeValue / curVolume) * 100.0d;

                        int days = -1;
                        if (mnt.Type >= MaintenanceType.Restart && mnt.Type <= MaintenanceType.WaterReplaced) {
                            if (!ALCore.IsZeroDate(dtPrev)) {
                                days = (mnt.Timestamp.Date - dtPrev).Days;
                                //result += days;
                                //count += 1;
                            }
                            dtPrev = mnt.Timestamp.Date;
                        }

                        string strType = Localizer.LS(ALData.MaintenanceTypes[(int)mnt.Type]);

                        var item = new ListViewItem(curTime);
                        item.Tag = mnt;
                        item.SubItems.Add(strType);
                        item.SubItems.Add(ALCore.GetDecimalStr(mnt.Value));
                        item.SubItems.Add(mnt.Note);
                        item.SubItems.Add(ALCore.GetDecimalStr(curVolume));
                        item.SubItems.Add(ALCore.GetDecimalStr(chngPercent));
                        item.SubItems.Add((days >= 0) ? days.ToString() : string.Empty);
                        ListView.Items.Add(item);
                    }

                    if (evnt is Measure) {
                        Measure msr = (Measure)evnt;

                        var item = new ListViewItem(curTime);
                        item.Tag = msr;
                        item.SubItems.Add(Localizer.LS(LSID.Measure));
                        item.SubItems.Add(string.Empty);
                        item.SubItems.Add(string.Empty);
                        item.SubItems.Add(string.Empty);
                        item.SubItems.Add(string.Empty);
                        item.SubItems.Add(string.Empty);

                        item.SubItems.Add(ALCore.GetDecimalStr(msr.Temperature, 2, true));
                        item.SubItems.Add(ALCore.GetDecimalStr(msr.NO3, 2, true));
                        //item.SubItems.Add(ALCore.GetDecimalStr(msr.NO2, 2, true));
                        item.SubItems.Add(ALCore.GetDecimalStr(msr.GH, 2, true));
                        item.SubItems.Add(ALCore.GetDecimalStr(msr.KH, 2, true));
                        item.SubItems.Add(ALCore.GetDecimalStr(msr.pH, 2, true));
                        //item.SubItems.Add(ALCore.GetDecimalStr(msr.Cl2, 2, true));
                        item.SubItems.Add(ALCore.GetDecimalStr(msr.CO2, 2, true));
                        item.SubItems.Add(ALCore.GetDecimalStr(msr.NH, 2, true));
                        //item.SubItems.Add(ALCore.GetDecimalStr(msr.NH3, 2, true));
                        //item.SubItems.Add(ALCore.GetDecimalStr(msr.NH4, 2, true));
                        item.SubItems.Add(ALCore.GetDecimalStr(msr.PO4, 2, true));
                        ListView.Items.Add(item);
                    }

                    if (evnt is Note) {
                        Note note = (Note)evnt;

                        var item = new ListViewItem(curTime);
                        item.Tag = note;
                        item.SubItems.Add(Localizer.LS(LSID.Event));
                        item.SubItems.Add(string.Empty);
                        item.SubItems.Add(note.Event);
                        item.SubItems.Add(string.Empty);
                        item.SubItems.Add(string.Empty);
                        item.SubItems.Add(string.Empty);
                        ListView.Items.Add(item);
                    }
                }
            }
        }
    }
}
