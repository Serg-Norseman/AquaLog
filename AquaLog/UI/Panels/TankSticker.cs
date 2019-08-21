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

namespace AquaLog.Panels
{
    public enum TankState
    {
        Normal,
        Warning,
        Alert,
        Inactive
    }

    public class TankValue
    {
        public double Value;
        public string Text;
        public Color Color;
    }

    /// <summary>
    /// 
    /// </summary>
    public class TankSticker : UserControl
    {
        private Aquarium fAquarium;
        private ALModel fModel;
        private bool fSelected;
        private StringFormat fStrFormat;
        private SolidBrush fTextBrush;
        private List<TankValue> fValues;

        public Aquarium Aquarium
        {
            get { return fAquarium; }
            set {
                if (fAquarium != value) {
                    fAquarium = value;
                    UpdateView();
                }
            }
        }

        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public bool Selected
        {
            get { return fSelected; }
            set {
                if (fSelected != value) {
                    fSelected = value;
                    UpdateView();
                }
            }
        }


        public TankSticker()
        {
            Margin = new Padding(10);

            int XS = 24;
            MinimumSize = new Size(XS * 16, XS * 9);
            MaximumSize = new Size(XS * 16, XS * 9);

            fStrFormat = new StringFormat();
            fTextBrush = null;
            fValues = new List<TankValue>();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                fStrFormat.Dispose();
                if (fTextBrush != null) fTextBrush.Dispose();
            }
            base.Dispose(disposing);
        }

        public void SetTankState(TankState state)
        {
            int color;
            switch (state) {
                case TankState.Normal:
                    color = ALCore.NormalState;
                    break;
                case TankState.Warning:
                    color = ALCore.WarningState;
                    break;
                case TankState.Alert:
                    color = ALCore.AlertState;
                    break;
                case TankState.Inactive:
                    color = ALCore.InactiveState;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            BackColor = ALCore.CreateColor(color);
        }

        public void UpdateView()
        {
            if (fAquarium.IsInactive()) {
                SetTankState(TankState.Inactive);
            } else {
                SetTankState(TankState.Normal);
            }

            CollectData();

            Refresh();
        }

        private void CollectData()
        {
            fValues.Clear();

            PrepareValue("Temperature", "T", "°C", null);
            PrepareValue("NO3", "NO3", "mg/l", ALData.NO3Ranges);
            PrepareValue("NO2", "NO2", "mg/l", ALData.NO2Ranges);
            PrepareValue("Cl2", "Cl2", "mg/l", ALData.Cl2Ranges);
            PrepareValue("GH", "GH", "°d", ALData.GHRanges);
            PrepareValue("KH", "KH", "°d", ALData.KHRanges);
            PrepareValue("pH", "pH", "", ALData.pHRanges);
            PrepareValue("CO2", "CO2", "", ALData.CO2Ranges);
        }

        private void PrepareValue(string field, string sign, string uom, List<ValueBounds> ranges)
        {
            QDecimal measure = fModel.QueryLastMeasure(fAquarium, field);
            double mVal = (measure != null) ? measure.value : double.NaN;

            string str = !double.IsNaN(mVal) ? ALCore.GetDecimalStr(mVal) : string.Empty;
            str = string.Format("{0}={1} {2}", sign, str, uom);

            Color color = ForeColor;
            if (!double.IsNaN(mVal) && mVal != 0.0d && ranges != null) {
                ValueBounds bounds = CheckValue(mVal, ranges);
                if (bounds != null) {
                    color = bounds.Color;
                }
            }

            var tval = new TankValue() {
                Value = mVal,
                Text = str,
                Color = color
            };
            fValues.Add(tval);
        }

        private ValueBounds CheckValue(double value, List<ValueBounds> ranges)
        {
            foreach (var bounds in ranges) {
                if (value >= bounds.Min && value <= bounds.Max) {
                    return bounds;
                }
            }
            return null;
        }

        private string GetMeasureVal(string field, string sign, string uom)
        {
            QDecimal val = fModel.QueryLastMeasure(fAquarium, field);
            string str = (val != null) ? ALCore.GetDecimalStr(val.value) : string.Empty;
            str = string.Format("{0}={1} {2}", sign, str, uom);
            return str;
        }

        private double GetWaterVolume()
        {
            double result = 0.0d;

            var records = fModel.QueryWaterChanges(fAquarium.Id);
            foreach (WaterChange rec in records) {
                int idx = (int)rec.Type;
                int factor = ALCore.WaterChangeFactors[idx];
                result += (rec.Volume * factor);
            }

            return result;
        }

        private double GetAverageWaterChangeInterval()
        {
            double result = 0.0d;
            int count = 0;

            DateTime dtPrev = ALCore.ZeroDate;
            var records = fModel.QueryWaterChanges(fAquarium.Id);
            foreach (WaterChange rec in records) {
                if (!dtPrev.Equals(ALCore.ZeroDate)) {
                    int days = (rec.ChangeDate.Date - dtPrev).Days;
                    result += days;
                    count += 1;
                }
                dtPrev = rec.ChangeDate.Date;
            }

            return result / count;
        }

        private double GetLastWaterChangeInterval()
        {
            DateTime dtPrev = ALCore.ZeroDate;
            var records = fModel.QueryWaterChanges(fAquarium.Id);
            foreach (WaterChange rec in records) {
                dtPrev = rec.ChangeDate.Date;
            }
            return (DateTime.Now.Date - dtPrev).Days;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics gfx = e.Graphics;

            ButtonBorderStyle style = (fSelected) ? ButtonBorderStyle.Inset : ButtonBorderStyle.Outset;
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Silver, style);

            if (fAquarium == null) return;

            var layoutRect = ClientRectangle;
            layoutRect.Inflate(-4, -4);

            Font font = new Font(Font, FontStyle.Bold);

            fStrFormat.Alignment = StringAlignment.Near;
            DrawText(gfx, fAquarium.Name, font, ForeColor, layoutRect);

            double waterVolume = GetWaterVolume();
            string volumes = ALCore.GetDecimalStr(waterVolume) + " / " + ALCore.GetDecimalStr(fAquarium.TankVolume);
            fStrFormat.Alignment = StringAlignment.Far;
            DrawText(gfx, volumes, font, ForeColor, layoutRect);

            string works;
            TimeSpan span;
            if (fAquarium.IsInactive()) {
                span = fAquarium.StopDate - fAquarium.StartDate;
                works = "Worked from " + fAquarium.StartDate.ToString("dd/MM/yyyy") + " to " + fAquarium.StopDate.ToString("dd/MM/yyyy");
            } else {
                span = DateTime.Now - fAquarium.StartDate;
                works = "Works from " + fAquarium.StartDate.ToString("dd/MM/yyyy");
            }
            int days = span.Days;
            works += " [" + days + " d]";

            int x = layoutRect.Left;
            int y = layoutRect.Top + (int)(Font.Height * 1.6f);
            DrawText(gfx, works, Font, ForeColor, x, y);

            double avgChangeDays = GetAverageWaterChangeInterval();
            string avgChange = "avg=" + ALCore.GetDecimalStr(avgChangeDays, 1) + "d";

            Color wsColor = ForeColor;
            string lastChange = "";
            string waterStatus = "";
            if (!fAquarium.IsInactive()) {
                double lastChangeDays = GetLastWaterChangeInterval();
                lastChange = ", last=" + ALCore.GetDecimalStr(lastChangeDays, 1) + "d";

                if (lastChangeDays <= avgChangeDays) {
                    waterStatus = " [normal]";
                    wsColor = Color.Green;
                } else if (lastChangeDays >= avgChangeDays * 2) {
                    waterStatus = " [alarm]";
                    wsColor = Color.Red;
                } else if (avgChangeDays + 1 < lastChangeDays) {
                    waterStatus = " [exceeded]";
                    wsColor = Color.Orange;
                }
            }

            string waterChanges = avgChange + lastChange + waterStatus;
            y = y + (int)(Font.Height * 1.6f);
            DrawText(gfx, "Water changes: " + waterChanges, Font, wsColor, x, y);

            int inhabCount = fModel.QueryInhabitantsCount(fAquarium.Id);
            y = y + (int)(Font.Height * 1.6f);
            DrawText(gfx, "Inhabitants: " + inhabCount.ToString(), Font, ForeColor, x, y);

            int xoffset = layoutRect.Width / 4;

            y = y + (int)(Font.Height * 1.6f);
            DrawMeasure(gfx, 0, font, x, y);
            DrawMeasure(gfx, 1, font, x + xoffset * 1, y);
            DrawMeasure(gfx, 2, font, x + xoffset * 2, y);
            DrawMeasure(gfx, 3, font, x + xoffset * 3, y);

            y = y + (int)(Font.Height * 1.6f);
            DrawMeasure(gfx, 4, font, x, y);
            DrawMeasure(gfx, 5, font, x + xoffset * 1, y);
            DrawMeasure(gfx, 6, font, x + xoffset * 2, y);
            DrawMeasure(gfx, 7, font, x + xoffset * 3, y);
        }

        private void DrawMeasure(Graphics gfx, int index, Font font, int x, int y)
        {
            TankValue tVal = fValues[index];
            DrawText(gfx, tVal.Text, font, tVal.Color, x, y);
        }

        private void DrawText(Graphics gfx, string text, Font font, Color color, int x, int y)
        {
            if (fTextBrush == null) {
                fTextBrush = new SolidBrush(color);
            }
            fTextBrush.Color = color;
            gfx.DrawString(text, font, fTextBrush, x, y);
        }

        private void DrawText(Graphics gfx, string text, Font font, Color color, Rectangle layoutRect)
        {
            if (fTextBrush == null) {
                fTextBrush = new SolidBrush(color);
            }
            fTextBrush.Color = color;
            gfx.DrawString(text, font, fTextBrush, layoutRect, fStrFormat);
        }
    }
}
