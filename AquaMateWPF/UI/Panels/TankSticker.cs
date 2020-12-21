/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Core.Types;
using BSLib.Design.Graphics;

namespace AquaMate.UI.Panels
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
    public sealed class TankSticker : ContentControl
    {
        private Aquarium fAquarium;
        private IModel fModel;
        private bool fSelected;
        //private readonly StringFormat fStrFormat;
        //private SolidBrush fTextBrush;
        private List<MeasureValue> fValues;

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

        public IModel Model
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
            Margin = new Thickness(10);

            int XS = 24;
            MinWidth = XS * 16;
            MaxWidth = MinWidth;
            MinHeight = XS * 9;
            MaxHeight = MinHeight;

            /*fStrFormat = new StringFormat();
            fTextBrush = null;*/
            fValues = new List<MeasureValue>();
        }

        /*protected override void Dispose(bool disposing)
        {
            if (disposing) {
                fStrFormat.Dispose();
                if (fTextBrush != null) fTextBrush.Dispose();
            }
            base.Dispose(disposing);
        }*/

        public SolidColorBrush GetTankState(TankState state)
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
                    color = ALCore.NormalState;
                    break;
            }

            var clr = UIHelper.CreateColor(color);
            return new SolidColorBrush(clr);
        }

        public void UpdateView()
        {
            fValues = fModel.CollectData(fAquarium);
            UpdateLayout();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            TankState state = (fAquarium.IsInactive()) ? TankState.Inactive : TankState.Normal;
            var brush = GetTankState(state);

            //ButtonBorderStyle style = (fSelected) ? ButtonBorderStyle.Inset : ButtonBorderStyle.Outset;
            //ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Silver, style);
            var borderPen = new Pen(Brushes.Black, 1.0);
            var clientRect = new Rect(0, 0, ActualWidth - 1, ActualHeight - 1);
            drawingContext.DrawRectangle(brush, borderPen, clientRect);

            if (fAquarium == null) return;

            var layoutRect = clientRect;
            layoutRect.Inflate(-4, -4);

            FormattedText formattedText = new FormattedText(
                fAquarium.Name, CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                new Typeface("Verdana"), FontSize, Brushes.Black);
            formattedText.SetFontWeight(FontWeights.Bold);
            drawingContext.DrawText(formattedText, layoutRect.TopLeft);

            /*double normalWaterVolume = fAquarium.CalcWaterVolume();
            double waterVolume = fModel.GetWaterVolume(fAquarium.Id);
            string volumes = ALCore.GetDecimalStr(waterVolume) + " / " + ALCore.GetDecimalStr(normalWaterVolume) + " / " + ALCore.GetDecimalStr(fAquarium.TankVolume);
            fStrFormat.Alignment = StringAlignment.Far;
            Color wvColor = (DoubleHelper.Equals(normalWaterVolume, waterVolume, 0.5)) ? Color.Green : Color.Orange;
            DrawText(gfx, volumes, font, wvColor, layoutRect);

            string works;
            if (fAquarium.IsInactive()) {
                TimeSpan span = fAquarium.StopDate - fAquarium.StartDate;
                int days = span.Days;
                works = string.Format(Localizer.LS(LSID.AquaWorked), fAquarium.StartDate.ToString("dd/MM/yyyy"), fAquarium.StopDate.ToString("dd/MM/yyyy"), days);
            } else {
                TimeSpan span = DateTime.Now - fAquarium.StartDate;
                int days = span.Days;
                works = string.Format(Localizer.LS(LSID.AquaWorks), fAquarium.StartDate.ToString("dd/MM/yyyy"), days);
            }

            int x = layoutRect.Left;
            int y = layoutRect.Top + (int)(Font.Height * 1.6f);
            DrawText(gfx, works, Font, ForeColor, x, y);

            double avgChangeDays = fModel.GetAverageWaterChangeInterval(fAquarium.Id);
            string avgChange = "avg=" + ALCore.GetDecimalStr(avgChangeDays, 1) + "d";

            Color wsColor = ForeColor;
            string lastChange = "";
            string waterStatus = "";
            if (!fAquarium.IsInactive()) {
                double lastChangeDays = fModel.GetLastWaterChangeInterval(fAquarium.Id);
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
            DrawText(gfx, Localizer.LS(LSID.WaterChanges) + ": " + waterChanges, Font, wsColor, x, y);

            int inhabCount = fModel.QueryInhabitantsCount(fAquarium.Id);
            y = y + (int)(Font.Height * 1.6f);
            DrawText(gfx, Localizer.LS(LSID.Inhabitants) + ": " + inhabCount.ToString(), Font, ForeColor, x, y);

            int xoffset = layoutRect.Width / 4;
            int col = 0;
            for (int i = 0; i < 13; i++) {
                if (i % 4 == 0) {
                    y = y + (int)(Font.Height * 1.6f);
                    col = 0;
                }

                DrawMeasure(gfx, i, font, x + (xoffset * col), y);
                col += 1;
            }*/
        }

        /*private void DrawMeasure(Graphics gfx, int index, Font font, int x, int y)
        {
            MeasureValue tVal = fValues[index];
            if (!string.IsNullOrEmpty(tVal.Text) && !double.IsNaN(tVal.Value)) {
                DrawText(gfx, tVal.Text, font, tVal.Color, x, y);
            }
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
        }*/
    }
}
