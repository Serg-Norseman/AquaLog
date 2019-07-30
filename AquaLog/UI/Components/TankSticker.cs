/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;

namespace AquaLog.Components
{
    public enum TankState
    {
        Normal,
        Warning,
        Alert,
        Inactive
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
            MinimumSize = new Size(256, 144);
            MaximumSize = new Size(256, 144);

            fStrFormat = new StringFormat();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                fStrFormat.Dispose();
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

            Refresh();
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

            ButtonBorderStyle style = (fSelected) ? ButtonBorderStyle.Inset : ButtonBorderStyle.Outset;
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Silver, style);

            if (fAquarium == null) return;

            var layoutRect = ClientRectangle;
            layoutRect.Inflate(-4, -4);

            Font font = new Font(Font, FontStyle.Bold);
            fStrFormat.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(fAquarium.Name, font, new SolidBrush(ForeColor), layoutRect, fStrFormat);

            double waterVolume = GetWaterVolume();
            string volumes = ALCore.GetDecimalStr(waterVolume) + " / " + ALCore.GetDecimalStr(fAquarium.TankVolume);
            fStrFormat.Alignment = StringAlignment.Far;
            e.Graphics.DrawString(volumes, font, new SolidBrush(ForeColor), layoutRect, fStrFormat);

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
            e.Graphics.DrawString(works, Font, new SolidBrush(ForeColor), x, y);

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
            e.Graphics.DrawString("Water changes: " + waterChanges, Font, new SolidBrush(wsColor), x, y);

            int inhabCount = fModel.QueryInhabitantsCount(fAquarium.Id);
            y = y + (int)(Font.Height * 1.6f);
            e.Graphics.DrawString("Inhabitants: " + inhabCount.ToString(), Font, new SolidBrush(ForeColor), x, y);
        }
    }
}
