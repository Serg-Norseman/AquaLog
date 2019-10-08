﻿/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

//#define DEFAULT_HEADER

using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace AquaLog.Components
{
    /// <summary>
    /// 
    /// </summary>
    public class ZListView : ListView
    {
        private class LVColumnSorter : IComparer
        {
            private readonly ZListView fOwner;

            public LVColumnSorter(ZListView owner)
            {
                fOwner = owner;
            }

            public int Compare(object x, object y)
            {
                int result = 0;

                int sortColumn = fOwner.fSortColumn;
                SortOrder sortOrder = fOwner.fSortOrder;

                if (sortOrder != SortOrder.None && sortColumn >= 0) {
                    ListViewItem item1 = (ListViewItem)x;
                    ListViewItem item2 = (ListViewItem)y;

                    if (sortColumn == 0) {
                        if (item1 is IComparable && item2 is IComparable) {
                            IComparable eitem1 = (IComparable)x;
                            IComparable eitem2 = (IComparable)y;
                            result = eitem1.CompareTo(eitem2);
                        } else {
                            result = ZListView.StrCompareEx(item1.Text, item2.Text);
                        }
                    } else if (sortColumn < item1.SubItems.Count && sortColumn < item2.SubItems.Count) {
                        ListViewItem.ListViewSubItem subitem1 = item1.SubItems[sortColumn];
                        ListViewItem.ListViewSubItem subitem2 = item2.SubItems[sortColumn];

                        if (subitem1 is IComparable && subitem2 is IComparable) {
                            IComparable sub1 = (IComparable)subitem1;
                            IComparable sub2 = (IComparable)subitem2;
                            result = sub1.CompareTo(sub2);
                        } else {
                            result = ZListView.StrCompareEx(subitem1.Text, subitem2.Text);
                        }
                    }

                    if (sortOrder == SortOrder.Descending) {
                        result = -result;
                    }
                }

                return result;
            }
        }

        private readonly LVColumnSorter fColumnSorter;

        protected int fSortColumn;
        protected SortOrder fSortOrder;
        protected int fUpdateCount;


        public int SortColumn
        {
            get { return fSortColumn; }
            set { fSortColumn = value; }
        }

        public SortOrder Order
        {
            get { return fSortOrder; }
            set { fSortOrder = value; }
        }


        public ZListView()
        {
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            // Enable the OnNotifyMessage event so we get a chance to filter out
            // Windows messages before they get to the form's WndProc
            SetStyle(ControlStyles.EnableNotifyMessage, true);

            OwnerDraw = true;
            HideSelection = false;
            LabelEdit = false;
            FullRowSelect = true;
            View = View.Details;

            fSortColumn = 0;
            fSortOrder = SortOrder.None;
            fColumnSorter = new LVColumnSorter(this);

            ListViewItemSorter = fColumnSorter;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
            }
            base.Dispose(disposing);
        }

        public new void BeginUpdate()
        {
            if (fUpdateCount == 0) {
                #if !__MonoCS__
                ListViewItemSorter = null;
                #endif
                base.BeginUpdate();
            }

            fUpdateCount++;
        }

        public new void EndUpdate()
        {
            fUpdateCount--;

            if (fUpdateCount == 0) {
                base.EndUpdate();
                #if !__MonoCS__
                ListViewItemSorter = fColumnSorter;
                #endif
            }
        }

        protected SortOrder GetColumnSortOrder(int columnIndex)
        {
            return (fSortColumn == columnIndex) ? fSortOrder : SortOrder.None;
        }

        public void SetSortColumn(int sortColumn, bool checkOrder = true)
        {
            int prevColumn = fSortColumn;
            if (prevColumn == sortColumn && checkOrder) {
                SortOrder prevOrder = GetColumnSortOrder(sortColumn);
                fSortOrder = (prevOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            }

            fSortColumn = sortColumn;
            Sort();
        }

        protected override void OnColumnClick(ColumnClickEventArgs e)
        {
            SetSortColumn(e.Column);

            // we use Refresh() because only Invalidate() isn't update header's area
            Refresh();

            base.OnColumnClick(e);
        }

        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            #if DEFAULT_HEADER

            e.DrawDefault = true;

            #else

            using (var sf = new StringFormat())
            {
                Graphics gfx = e.Graphics;
                Rectangle rt = e.Bounds;

                #if !__MonoCS__
                if (VisualStyleRenderer.IsSupported) {
                    VisualStyleElement element = VisualStyleElement.Header.Item.Normal;
                    if ((e.State & ListViewItemStates.Hot) == ListViewItemStates.Hot)
                        element = VisualStyleElement.Header.Item.Hot;
                    if ((e.State & ListViewItemStates.Selected) == ListViewItemStates.Selected)
                        element = VisualStyleElement.Header.Item.Pressed;

                    var visualStyleRenderer = new VisualStyleRenderer(element);
                    visualStyleRenderer.DrawBackground(gfx, rt);
                } else {
                    e.DrawBackground();
                }
                #else
                e.DrawBackground();
                #endif

                switch (e.Header.TextAlign) {
                    case HorizontalAlignment.Left:
                        sf.Alignment = StringAlignment.Near;
                        break;

                    case HorizontalAlignment.Right:
                        sf.Alignment = StringAlignment.Far;
                        break;

                    case HorizontalAlignment.Center:
                        sf.Alignment = StringAlignment.Center;
                        break;
                }

                sf.LineAlignment = StringAlignment.Center;
                sf.Trimming = StringTrimming.EllipsisCharacter;
                sf.FormatFlags = StringFormatFlags.NoWrap;

                int w = TextRenderer.MeasureText(" ", Font).Width;
                rt.Inflate(-(w / 5), 0);

                gfx.DrawString(e.Header.Text, Font, Brushes.Black, rt, sf);

                string arrow = "";
                switch (GetColumnSortOrder(e.ColumnIndex)) {
                    case SortOrder.Ascending:
                        arrow = "▲";
                        break;
                    case SortOrder.Descending:
                        arrow = "▼";
                        break;
                }

                if (arrow != "") {
                    using (var fnt = new Font(Font.FontFamily, Font.SizeInPoints * 0.6f, FontStyle.Regular)) {
                        float aw = gfx.MeasureString(arrow, fnt).Width;
                        float x = rt.Left + (rt.Width - aw) / 2.0f;
                        gfx.TextRenderingHint = TextRenderingHint.AntiAlias;
                        gfx.DrawString(arrow, fnt, Brushes.Black, x, rt.Top);
                    }
                }
            }

            #endif

            base.OnDrawColumnHeader(e);
        }

        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
            base.OnDrawItem(e);
        }

        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
            base.OnDrawSubItem(e);
        }

        public object GetSelectedData()
        {
            try {
                object result = null;
                ListViewItem item = GetSelectedItem();
                if (item != null) result = item.Tag;

                return result;
            } catch (Exception ex) {
                //Logger.LogWrite("GKListView.GetSelectedData(): " + ex.Message);
                return null;
            }
        }

        public void ResizeColumn(int columnIndex)
        {
            try {
                if (columnIndex >= 0 && Items.Count > 0) {
                    AutoResizeColumn(columnIndex, ColumnHeaderAutoResizeStyle.ColumnContent);

                    if (Columns[columnIndex].Width < 20) {
                        AutoResizeColumn(columnIndex, ColumnHeaderAutoResizeStyle.HeaderSize);
                    }
                }
            } catch (Exception ex) {
                //Logger.LogWrite("GKListView.ResizeColumn(): " + ex.Message);
            }
        }

        public ListViewItem GetSelectedItem()
        {
            ListViewItem result = (SelectedItems.Count <= 0) ? null : (SelectedItems[0] as ListViewItem);
            return result;
        }

        private void SelectItem(ListViewItem item)
        {
            if (item == null) return;

            SelectedIndices.Clear();
            item.Selected = true;
            item.EnsureVisible();
        }

        public void SelectItem(int index)
        {
            if (index >= 0 && index < Items.Count) {
                ListViewItem item = Items[index];
                SelectItem(item);
            }
        }

        public void SelectItem(object rowData)
        {
            try {
                int num = Items.Count;
                for (int i = 0; i < num; i++) {
                    var item = Items[i];
                    if (item.Tag == rowData) {
                        SelectItem(item);
                        return;
                    }
                }
            } catch (Exception ex) {
                //Logger.LogWrite("GKListView.SelectItem(): " + ex.Message);
            }
        }

        internal static int StrCompareEx(string str1, string str2)
        {
            double val1, val2;
            bool v1 = double.TryParse(str1, out val1);
            bool v2 = double.TryParse(str2, out val2);

            int result;
            if (v1 && v2) {
                if (val1 < val2) {
                    result = -1;
                } else if (val1 > val2) {
                    result = +1;
                } else {
                    result = 0;
                }
            } else {
                result = string.Compare(str1, str2, false);
                if (str1 != "" && str2 == "") {
                    result = -1;
                } else if (str1 == "" && str2 != "") {
                    result = +1;
                }
            }
            return result;
        }
    }
}
