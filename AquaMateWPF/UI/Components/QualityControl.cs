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
using AquaMate.Core.Types;

namespace AquaMate.UI.Components
{
    /// <summary>
    /// 
    /// </summary>
    public class QualityControl : UserControl
    {
        private class VRItem
        {
            public ValueRange Range;
            public double Length;
            public Rect Rect;
            public Brush Brush;
        }

        private const int Gap = 0;
        private const int LayoutPadding = 10;
        private const string ValuesFormat = "{0:0.00}";

        private Brush fEmptyBrush;
        private readonly List<VRItem> fList;
        private ValueRange[] fRanges;
        private double fRangesLength;
        private double fScaleWidth;
        private string fTitle;
        private double fValue;
        private int fValuePos;


        public ValueRange[] Ranges
        {
            get { return fRanges; }
        }

        public double Value
        {
            get { return fValue; }
        }

        public string Title
        {
            get { return fTitle; }
        }


        public QualityControl()
        {
            fEmptyBrush = new SolidColorBrush(Colors.Gray);
            fList = new List<VRItem>();
        }

        public void SetData(string title, double value, ValueRange[] ranges)
        {
            fTitle = title;
            fValue = value;
            fRanges = ranges;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            drawingContext.DrawRectangle(Brushes.Silver, new Pen(Brushes.Black, 1.0d), new Rect(0, 0, ActualWidth, ActualHeight));

            if (Width <= 0 || Height <= 0) return;

            UpdateContent();

            FormattedText fmtText = new FormattedText(fTitle, CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                new Typeface(this.FontFamily.Source), FontSize, Brushes.Black);
            fmtText.SetFontWeight(FontWeights.Bold);
            drawingContext.DrawText(fmtText, new Point(0, 0));

            double lineHeight = fmtText.Height;
            double scaleSize = FontSize * 0.8f;

            int count = fList.Count;
            if (count > 0) {
                string line = string.Format(ValuesFormat, fValue);
                fmtText = GetFmtText(line, scaleSize, Brushes.Black);
                DrawText(drawingContext, fmtText, fValuePos, (lineHeight + Gap) * 1, -1);

                line = "▼";
                fmtText = GetFmtText(line, scaleSize, Brushes.Black);
                DrawText(drawingContext, fmtText, fValuePos, (lineHeight + Gap) * 2, -1);

                int markersY = (int)((lineHeight + Gap) * 3 + (lineHeight / 2 + Gap));
                for (int i = 0; i < count; i++) {
                    VRItem item = fList[i];
                    DrawRect(drawingContext, item.Rect, item.Brush);

                    if (i == 0) {
                        double val = item.Range.Min;
                        line = string.Format(ValuesFormat, val);
                        float x = LayoutPadding + (int)(fScaleWidth * (val / fRangesLength));
                        DrawText(drawingContext, GetFmtText(line, scaleSize, Brushes.Black), x, markersY, 2);
                    } else if (i == count - 1) {
                        double val = item.Range.Min;
                        line = string.Format(ValuesFormat, val);
                        float x = LayoutPadding + (int)(fScaleWidth * (val / fRangesLength));
                        DrawText(drawingContext, GetFmtText(line, scaleSize, Brushes.Black), x, markersY, -1);

                        val = item.Range.Max;
                        line = string.Format(ValuesFormat, val);
                        x = LayoutPadding + (int)(fScaleWidth * (val / fRangesLength));
                        DrawText(drawingContext, GetFmtText(line, scaleSize, Brushes.Black), x, markersY, 3);
                    } else {
                        double val = item.Range.Min;
                        line = string.Format(ValuesFormat, val);
                        float x = LayoutPadding + (int)(fScaleWidth * (val / fRangesLength));
                        DrawText(drawingContext, GetFmtText(line, scaleSize, Brushes.Black), x, markersY, -1);
                    }
                }
            } else {
                //DrawRect(drawingContext, 10, Width - 20, fEmptyBrush);
            }
        }

        private void DrawRect(DrawingContext context, Rect rt, Brush lb)
        {
            if (rt.Width > 0) {
                context.DrawRectangle(lb, null, rt);
            }
        }

        private FormattedText GetFmtText(string text, double size, Brush brush)
        {
            return new FormattedText(text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                new Typeface(this.FontFamily.Source), size, brush);
        }

        private void DrawText(DrawingContext context, FormattedText fmtText, double x, double y, int quad = 2)
        {
            // quadrant clockwise from 00 hours
            switch (quad) {
                case -1:
                    x -= (fmtText.Width / 2.0f);
                    break;
                case 1:
                    y -= fmtText.Height;
                    break;
                case 2:
                    break;
                case 3:
                    x -= fmtText.Width;
                    break;
                case 4:
                    x -= fmtText.Width;
                    y -= fmtText.Height;
                    break;
            }

            context.DrawText(fmtText, new Point(x, y));
        }

        private void UpdateContent()
        {
            fList.Clear();
            if (fRanges == null) return;

            FormattedText fmtText = new FormattedText(fTitle, CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                new Typeface(this.FontFamily.Source), FontSize, Foreground);

            int lineHeight = (int)fmtText.Height;
            int scaleHeight = lineHeight / 2;
            //ClientSize = new Size(ClientSize.Width, (lineHeight * 4) + scaleHeight + (Gap * 6));

            int count = fRanges.Length;
            fScaleWidth = ActualWidth - (LayoutPadding * 2) - (count - 1);

            fRangesLength = 0.0;
            foreach (var range in fRanges) {
                var wfColor = range.Color;
                var wpfColor = Color.FromArgb(wfColor.A, wfColor.R, wfColor.G, wfColor.B);

                VRItem item = new VRItem();
                item.Range = range;
                item.Length = (range.Max - range.Min);
                item.Brush = new SolidColorBrush(wpfColor);
                fList.Add(item);

                fRangesLength += item.Length;
            }

            int x = LayoutPadding;
            int y = (lineHeight + Gap) * 3;
            for (int i = 0; i < count; i++) {
                var item = fList[i];
                int itemWidth = (int)(fScaleWidth * (item.Length / fRangesLength));
                item.Rect = new Rect(x, y, itemWidth, scaleHeight);
                x += (itemWidth + 1);
            }

            fValuePos = LayoutPadding + (int)(fScaleWidth * (fValue / fRangesLength));
        }
    }
}
