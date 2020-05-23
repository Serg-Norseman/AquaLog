﻿/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using BSLib;
using BSLib.Design.Graphics;
using BSLib.Design.Handlers;

namespace AquaMate.UI
{
    /// <summary>
    /// 
    /// </summary>
    public class WFGfxProvider : IGraphicsProvider
    {
        public WFGfxProvider()
        {
        }

        public IImage LoadImage(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException("fileName");

            using (Bitmap bmp = new Bitmap(fileName))
            {
                // cloning is necessary to release the resource
                // loaded from the image stream
                Bitmap resImage = (Bitmap)bmp.Clone();

                return new ImageHandler(resImage);
            }
        }

        public void SaveImage(IImage image, string fileName)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            if (fileName == null)
                throw new ArgumentNullException("fileName");

            ((ImageHandler)image).Handle.Save(fileName, ImageFormat.Bmp);
        }

        public IImage CreateImage(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            using (Bitmap bmp = new Bitmap(stream))
            {
                // cloning is necessary to release the resource
                // loaded from the image stream
                Bitmap resImage = (Bitmap)bmp.Clone();

                return new ImageHandler(resImage);
            }
        }

        public IImage CreateImage(Stream stream, int thumbWidth, int thumbHeight, ExtRect cutoutArea)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            using (Bitmap bmp = new Bitmap(stream))
            {
                bool cutoutIsEmpty = cutoutArea.IsEmpty();
                int imgWidth = (cutoutIsEmpty) ? bmp.Width : cutoutArea.GetWidth();
                int imgHeight = (cutoutIsEmpty) ? bmp.Height : cutoutArea.GetHeight();

                if (thumbWidth > 0 && thumbHeight > 0) {
                    float ratio = GfxHelper.ZoomToFit(imgWidth, imgHeight, thumbWidth, thumbHeight);
                    imgWidth = (int)(imgWidth * ratio);
                    imgHeight = (int)(imgHeight * ratio);
                }

                Bitmap newImage = new Bitmap(imgWidth, imgHeight, PixelFormat.Format24bppRgb);
                using (Graphics graphic = Graphics.FromImage(newImage)) {
                    graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphic.SmoothingMode = SmoothingMode.HighQuality;
                    graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphic.CompositingQuality = CompositingQuality.HighQuality;

                    if (cutoutIsEmpty) {
                        graphic.DrawImage(bmp, 0, 0, imgWidth, imgHeight);
                    } else {
                        Rectangle destRect = new Rectangle(0, 0, imgWidth, imgHeight);
                        //Rectangle srcRect = cutoutArea.ToRectangle();
                        graphic.DrawImage(bmp, destRect,
                                          cutoutArea.Left, cutoutArea.Top,
                                          cutoutArea.GetWidth(), cutoutArea.GetHeight(),
                                          GraphicsUnit.Pixel);
                    }
                }

                return new ImageHandler(newImage);
            }
        }

        public IImage LoadResourceImage(string resName, bool makeTransp)
        {
            Bitmap img = (Bitmap)UIHelper.LoadResourceImage("Resources." + resName);

            if (makeTransp) {
                img = (Bitmap)img.Clone();

                #if __MonoCS__
                img.MakeTransparent();
                #else
                img.MakeTransparent(img.GetPixel(0, 0));
                #endif
            }

            return new ImageHandler(img);
        }

        public IGfxPath CreatePath()
        {
            return new GfxPathHandler(new GraphicsPath());
        }

        public IFont CreateFont(string fontName, float size, bool bold)
        {
            FontStyle style = (!bold) ? FontStyle.Regular : FontStyle.Bold;
            var sdFont = new Font(fontName, size, style, GraphicsUnit.Point);
            return new FontHandler(sdFont);
        }

        public IColor CreateColor(int argb)
        {
            // Dirty hack!
            //argb = (int)unchecked((long)argb & (long)((ulong)-1));
            //argb = (int)unchecked((ulong)argb & (uint)0xFF000000);
            int red = (argb >> 16) & 0xFF;
            int green = (argb >> 8) & 0xFF;
            int blue = (argb >> 0) & 0xFF;

            Color color = Color.FromArgb(red, green, blue);
            return new ColorHandler(color);
        }

        public IColor CreateColor(int r, int g, int b)
        {
            Color color = Color.FromArgb(r, g, b);
            return new ColorHandler(color);
        }

        public IColor CreateColor(int a, int r, int g, int b)
        {
            Color color = Color.FromArgb(a, r, g, b);
            return new ColorHandler(color);
        }

        public IBrush CreateSolidBrush(IColor color)
        {
            Color sdColor = ((ColorHandler)color).Handle;

            return new BrushHandler(new SolidBrush(sdColor));
        }

        public IPen CreatePen(IColor color, float width)
        {
            Color sdColor = ((ColorHandler)color).Handle;

            return new PenHandler(new Pen(sdColor, width));
        }

        public ExtSizeF GetTextSize(string text, IFont font, object target)
        {
            Graphics gfx = target as Graphics;
            if (gfx != null && font != null) {
                Font sdFnt = ((FontHandler)font).Handle;
                var size = gfx.MeasureString(text, sdFnt);
                return new ExtSizeF(size.Width, size.Height);
            } else {
                return new ExtSizeF();
            }
        }

        public string GetDefaultFontName()
        {
            string fontName;
            #if __MonoCS__
            fontName = "Noto Sans";
            #else
            fontName = "Verdana"; // "Tahoma";
            #endif
            return fontName;
        }
    }
}
