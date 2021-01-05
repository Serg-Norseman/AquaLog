/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2021 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Core.Types;
using BSLib;

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

            fValues = new List<MeasureValue>();
        }

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

            var clr = AppHost.GfxProvider.CreateColor(color);
            Color wpfColor = ((ColorHandler)clr).Handle;
            return new SolidColorBrush(wpfColor);
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

            FormattedText fmtText = UIHelper.GetFmtText("AW", FontSize, Colors.Black, FontWeights.Bold);

            DrawText(drawingContext, fAquarium.Name, FontSize, Colors.Black, FontWeights.Bold, layoutRect.TopLeft);

            double normalWaterVolume = fAquarium.CalcWaterVolume();
            double waterVolume = fModel.GetWaterVolume(fAquarium.Id);
            string volumes = ALCore.GetDecimalStr(waterVolume) + " / " + ALCore.GetDecimalStr(normalWaterVolume) + " / " + ALCore.GetDecimalStr(fAquarium.TankVolume);
            Color wvColor = (DoubleHelper.Equals(normalWaterVolume, waterVolume, 0.5)) ? Colors.Green : Colors.Orange;
            DrawText(drawingContext, volumes, FontSize, wvColor, FontWeights.Normal, layoutRect.TopRight, TextAlignment.Right);

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

            var lineOffset = fmtText.Height * 1.6f;
            var x = layoutRect.Left;
            var y = layoutRect.Top;

            var pt = new Point(x, y += lineOffset);
            DrawText(drawingContext, works, FontSize, Colors.Black, FontWeights.Normal, pt);

            double avgChangeDays = fModel.GetAverageWaterChangeInterval(fAquarium.Id);
            string avgChange = "avg=" + ALCore.GetDecimalStr(avgChangeDays, 1) + "d";

            Color wsColor = Colors.Black;
            string lastChange = "";
            string waterStatus = "";
            if (!fAquarium.IsInactive()) {
                double lastChangeDays = fModel.GetLastWaterChangeInterval(fAquarium.Id);
                lastChange = ", last=" + ALCore.GetDecimalStr(lastChangeDays, 1) + "d";

                if (lastChangeDays <= avgChangeDays) {
                    waterStatus = " [normal]";
                    wsColor = Colors.Green;
                } else if (lastChangeDays >= avgChangeDays * 2) {
                    waterStatus = " [alarm]";
                    wsColor = Colors.Red;
                } else if (avgChangeDays + 1 < lastChangeDays) {
                    waterStatus = " [exceeded]";
                    wsColor = Colors.Orange;
                }
            }

            string waterChanges = avgChange + lastChange + waterStatus;
            pt = new Point(x, y += lineOffset);
            DrawText(drawingContext, Localizer.LS(LSID.WaterChanges) + ": " + waterChanges, FontSize, wsColor, FontWeights.Normal, pt);

            int inhabCount = fModel.QueryInhabitantsCount(fAquarium.Id);
            pt = new Point(x, y += lineOffset);
            DrawText(drawingContext, Localizer.LS(LSID.Inhabitants) + ": " + inhabCount.ToString(), FontSize, Colors.Black, FontWeights.Normal, pt);

            int xoffset = (int)(layoutRect.Width / 4);
            int col = 0;
            for (int i = 0; i < 13; i++) {
                if (i % 4 == 0) {
                    y += lineOffset;
                    col = 0;
                }

                DrawMeasure(drawingContext, i, FontSize, x + (xoffset * col), y);
                col += 1;
            }
        }

        private void DrawMeasure(DrawingContext context, int index, double fontSize, double x, double y)
        {
            MeasureValue tVal = fValues[index];
            if (!string.IsNullOrEmpty(tVal.Text) && !double.IsNaN(tVal.Value)) {
                var wfColor = tVal.Color;
                var wpfColor = Color.FromArgb(wfColor.A, wfColor.R, wfColor.G, wfColor.B);

                DrawText(context, tVal.Text, fontSize, wpfColor, FontWeights.Normal, new Point(x, y));
            }
        }

        private static void DrawText(DrawingContext context, string text, double fontSize, Color color, FontWeight fontWeight,
            Point origin, TextAlignment textAlignment = TextAlignment.Left)
        {
            FormattedText fmtText = UIHelper.GetFmtText(text, fontSize, color, fontWeight, textAlignment);
            context.DrawText(fmtText, origin);
        }
    }
}
