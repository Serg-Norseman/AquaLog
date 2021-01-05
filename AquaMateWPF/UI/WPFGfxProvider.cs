/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2021 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BSLib;
using BSLib.Design.Graphics;

namespace AquaMate.UI
{
    /// <summary>
    /// 
    /// </summary>
    public class WPFGfxProvider : IGraphicsProvider
    {
        public WPFGfxProvider()
        {
        }

        public IImage LoadImage(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");

            if (File.Exists(fileName)) {
                using (FileStream stream = File.Open(fileName, FileMode.Open)) {
                    BinaryReader br = new BinaryReader(stream);
                    byte[] data = br.ReadBytes((int)stream.Length);
                    return UIHelper.ByteToImage(data);
                }
            }

            return null;
        }

        public void SaveImage(IImage image, string fileName)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");

            var wpfImage = ((ImageHandler)image).Handle;

            BitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(wpfImage));
            using (var stm = new FileStream(fileName, FileMode.CreateNew)) {
                encoder.Save(stm);
            }
        }

        public IImage CreateImage(Stream stream)
        {
            /*if (stream == null)
                throw new ArgumentNullException("stream");

            using (Bitmap bmp = new Bitmap(stream))
            {
                // cloning is necessary to release the resource
                // loaded from the image stream
                Bitmap resImage = (Bitmap)bmp.Clone();

                return new ImageHandler(resImage);
            }*/
            return null;
        }

        public IImage CreateImage(Stream stream, int thumbWidth, int thumbHeight, ExtRect cutoutArea)
        {
            /*if (stream == null)
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
            }*/
            return null;
        }

        public IImage LoadResourceImage(string resName, bool makeTransp)
        {
            /*Bitmap img = (Bitmap)UIHelper.LoadResourceImage("Resources." + resName);

            if (makeTransp) {
                img = (Bitmap)img.Clone();

                #if __MonoCS__
                img.MakeTransparent();
                #else
                img.MakeTransparent(img.GetPixel(0, 0));
                #endif
            }

            return new ImageHandler(img);*/
            return null;
        }

        public IGfxPath CreatePath()
        {
            /*return new GfxPathHandler(new GraphicsPath());*/
            return null;
        }

        public IFont CreateFont(string fontName, float size, bool bold)
        {
            var weight = (!bold) ? FontWeights.Normal : FontWeights.Bold;
            var imitFont = new WPFFont(fontName, size, weight);
            return new FontHandler(imitFont);
        }

        public IColor CreateColor(int argb)
        {
            // Dirty hack!
            //argb = (int)unchecked((long)argb & (long)((ulong)-1));
            //argb = (int)unchecked((ulong)argb & (uint)0xFF000000);
            int red = (argb >> 16) & 0xFF;
            int green = (argb >> 8) & 0xFF;
            int blue = (argb >> 0) & 0xFF;

            Color color = Color.FromRgb((byte)red, (byte)green, (byte)blue);
            return new ColorHandler(color);
        }

        public IColor CreateColor(int r, int g, int b)
        {
            Color color = Color.FromRgb((byte)r, (byte)g, (byte)b);
            return new ColorHandler(color);
        }

        public IColor CreateColor(int a, int r, int g, int b)
        {
            Color color = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            return new ColorHandler(color);
        }

        public IBrush CreateSolidBrush(IColor color)
        {
            Color sdColor = ((ColorHandler)color).Handle;
            return new BrushHandler(new SolidColorBrush(sdColor));
        }

        public IPen CreatePen(IColor color, float width)
        {
            Color sdColor = ((ColorHandler)color).Handle;
            return new PenHandler(new Pen(new SolidColorBrush(sdColor), width));
        }

        public ExtSizeF GetTextSize(string text, IFont font, object target)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException("text");

            if (font == null)
                throw new ArgumentNullException("font");

            /*Graphics gfx = target as Graphics;
            if (gfx != null && font != null) {
                Font sdFnt = ((FontHandler)font).Handle;
                var size = gfx.MeasureString(text, sdFnt);
                return new ExtSizeF(size.Width, size.Height);
            } else {
                return new ExtSizeF();
            }*/
            return ExtSizeF.Empty;
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
