/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Drawing;
using AquaLog.Core.Model;
using Elistia.DotNetRtfWriter;

namespace AquaLog.Core.Export
{
    /// <summary>
    /// 
    /// </summary>
    public static class RTFLogBook
    {
        private class FontStruct
        {
            public FontDescriptor FD;
            public float Size;
            public Color OriginalColor;
            public ColorDescriptor Color;
            public bool Bold;
            public bool Underline;
        }

        private static RtfDocument fDocument;
        private static RtfParagraph fParagraph;


        public static void Generate(ALModel model, Aquarium aquarium, string fileName)
        {
            fDocument = new RtfDocument(PaperSize.A4, PaperOrientation.Portrait, Lcid.English);
            try {
                var titleFont = CreateFont("", 16.0f, true, false, Color.Black);
                var textFont = CreateFont("", 12.0f, false, false, Color.Black);
                var dateFont = CreateFont("", 12.0f, true, true, Color.Black);

                BeginParagraph(Align.Center, 0.0f, 16.0f);
                AddParagraphChunk(Localizer.LS(LSID.LogBook), titleFont);
                EndParagraph();

                string prevDate = string.Empty, curDate;
                var records = model.QueryTransfers();
                foreach (Transfer rec in records) {
                    curDate = ALCore.GetDateStr(rec.Date);
                    if (!prevDate.Equals(curDate)) {
                        BeginParagraph(Align.Left, 6.0f, 6.0f);
                        AddParagraphChunk(curDate, dateFont);
                        EndParagraph();

                        prevDate = curDate;
                    }

                    string strType = Localizer.LS(ALData.TransferTypes[(int)rec.Type]);
                    string itName = model.GetRecordName(rec.ItemType, rec.ItemId);
                    AddListItem(string.Format("{0}: {1} ({2} x {3:C2})", strType, itName, rec.Quantity, rec.UnitPrice), textFont);

                    /*Aquarium aqmSour = model.GetRecord<Aquarium>(rec.SourceId);
                    Aquarium aqmTarg = model.GetRecord<Aquarium>(rec.TargetId);
                    item.SubItems.Add((aqmSour == null) ? string.Empty : aqmSour.Name);
                    item.SubItems.Add((aqmTarg == null) ? string.Empty : aqmTarg.Name);*/
                }
            } finally {
                fDocument.save(fileName);
            }
        }

        private static void AddParagraph(string text, FontStruct font, Align alignment)
        {
            RtfParagraph par = fDocument.addParagraph();
            par.Alignment = alignment;
            AddParagraphChunk(par, text, font);
        }

        private static void AddParagraphAnchor(string text, FontStruct font, string anchor)
        {
            RtfParagraph par = fDocument.addParagraph();
            RtfCharFormat fmt = AddParagraphChunk(par, text, font);
            fmt.Bookmark = anchor;
        }

        private static void AddParagraphLink(string text, FontStruct font, string link)
        {
            RtfParagraph par = fDocument.addParagraph();
            RtfCharFormat fmt = AddParagraphChunk(par, text, font);
            fmt.LocalHyperlink = link;
        }

        private static void AddParagraphLink(string text, FontStruct font, string link, FontStruct linkFont)
        {
            RtfParagraph par = fDocument.addParagraph();
            RtfCharFormat fmt = AddParagraphChunk(par, text, font);
            fmt.LocalHyperlink = link;
        }

        private static RtfCharFormat AddParagraphChunk(RtfParagraph par, string text, FontStruct fntStr)
        {
            par.DefaultCharFormat.Font = fntStr.FD;

            int beg = par.Text.Length;
            par.Text.Append(text);
            int end = par.Text.Length - 1;

            RtfCharFormat fmt = par.addCharFormat(beg, end);
            fmt.Font = fntStr.FD;
            fmt.FgColor = fntStr.Color;
            fmt.FontSize = fntStr.Size;
            if (fntStr.Bold) fmt.FontStyle.addStyle(FontStyleFlag.Bold);
            if (fntStr.Underline) fmt.FontStyle.addStyle(FontStyleFlag.Underline);

            return fmt;
        }

        private static FontStruct CreateFont(string name, float size, bool bold, bool underline, Color color)
        {
            if (string.IsNullOrEmpty(name)) name = "Times New Roman";

            FontStruct fntStr = new FontStruct();
            fntStr.FD = fDocument.createFont(name);
            fntStr.OriginalColor = color;
            fntStr.Color = fDocument.createColor(new RtfColor(color));
            fntStr.Size = size;
            fntStr.Bold = bold;
            fntStr.Underline = underline;
            return fntStr;
        }

        private static void AddListItem(string text, FontStruct fntStr)
        {
            RtfParagraph par = fDocument.addParagraph();

            var symFont = CreateFont("Symbol", fntStr.Size, fntStr.Bold, fntStr.Underline, fntStr.OriginalColor);

            AddParagraphChunk(par, "\t· ", symFont);
            AddParagraphChunk(par, text, fntStr);
        }

        private static void AddListItemLink(string text, FontStruct font, string link, FontStruct linkFont)
        {
            RtfParagraph par = fDocument.addParagraph();

            var symFont = CreateFont("Symbol", font.Size, font.Bold, font.Underline, font.OriginalColor);

            AddParagraphChunk(par, "\t· ", symFont);
            AddParagraphChunk(par, text, font);

            if (!string.IsNullOrEmpty(link)) {
                RtfCharFormat fmt = AddParagraphChunk(par, link, linkFont);
                fmt.LocalHyperlink = link;
            }
        }

        private static void BeginParagraph(Align alignment,
            float spacingBefore, float spacingAfter,
            float indent = 0.0f, bool keepTogether = false)
        {
            fParagraph = fDocument.addParagraph();
            fParagraph.Alignment = alignment;

            var margins = fParagraph.Margins;
            margins[Direction.Top] = spacingBefore;
            margins[Direction.Bottom] = spacingAfter;
        }

        private static void EndParagraph()
        {
        }

        private static void AddParagraphChunk(string text, FontStruct font)
        {
            AddParagraphChunk(fParagraph, text, font);
        }

        private static void AddParagraphChunkAnchor(string text, FontStruct font, string anchor)
        {
            RtfCharFormat fmt = AddParagraphChunk(fParagraph, text, font);
            fmt.Bookmark = anchor;
        }

        private static void AddParagraphChunkLink(string text, FontStruct font, string link, bool sup = false)
        {
            RtfCharFormat fmt = AddParagraphChunk(fParagraph, text, font);
            if (sup) fmt.FontStyle.addStyle(FontStyleFlag.Super);
            fmt.LocalHyperlink = link;
        }
    }
}
