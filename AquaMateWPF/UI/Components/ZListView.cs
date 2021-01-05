/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2021 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using BSLib.Design;
using BSLib.Design.Graphics;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI.Components
{
    public class ZListViewItem : ListViewItem, IListItem
    {
        public bool Checked
        {
            get {
                return false;
            }
            set {
            }
        }

        public object Data
        {
            get {
                return base.Tag;
            }
            set {
                base.Tag = value;
            }
        }

        public void AddSubItem(object itemValue)
        {
            
        }

        public int CompareTo(object obj)
        {
            return 0;
        }

        public void SetBackColor(IColor color)
        {
            if (color == null)
                return;

            Color sdColor = ((ColorHandler)color).Handle;
            base.Background = new SolidColorBrush(sdColor);
        }

        public void SetForeColor(IColor color)
        {
            if (color == null)
                return;

            Color sdColor = ((ColorHandler)color).Handle;
            base.Foreground = new SolidColorBrush(sdColor);
        }

        public void SetFont(IFont font)
        {
            if (font == null)
                return;

            WPFFont imitFont = ((FontHandler)font).Handle;
            base.FontFamily = new FontFamily(imitFont.FontFamily);
            base.FontSize = imitFont.Size;
            base.FontWeight = imitFont.FontWeight;
        }
    }


    public sealed class ZListViewItems : IListViewItems
    {
        private readonly ZListView fListView;

        public IListItem this[int index]
        {
            get { return (IListItem)fListView.Items[index]; }
        }

        public int Count
        {
            get { return fListView.Items.Count; }
        }

        public ZListViewItems(ZListView listView)
        {
            fListView = listView;
        }
    }


    public class ZListView : ListView, IListView
    {
        private GridViewColumnHeader lastHeaderClicked = null;
        private ListSortDirection lastDirection = ListSortDirection.Ascending;
        private ZListViewItems lvItems;

        public int SortColumn
        {
            get {
                return -1;
            }
            set {
            }
        }

        public bool Enabled
        {
            get {
                return base.IsEnabled;
            }
            set {
                base.IsEnabled = value;
            }
        }

        IListViewItems IListView.Items
        {
            get {
                return lvItems;
            }
        }


        public ZListView()
        {
            View = new GridView();
            lvItems = new ZListViewItems(this);
            this.AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(GridViewColumnHeaderClickedHandler));
        }

        public void Activate()
        {
            base.Focus();
        }

        public void AddColumn(string caption, int width, bool autoSize)
        {
            AddColumn(caption, width, autoSize, BSDTypes.HorizontalAlignment.Left);
        }

        public void AddColumn(string caption, int width, bool autoSize, BSDTypes.HorizontalAlignment textAlign)
        {
            double colWidth = (autoSize) ? double.NaN : width;

            var gridView = base.View as GridView;
            int lastIndex = gridView.Columns.Count;
            gridView.Columns.Add(
                new GridViewColumn() {
                    Header = caption,
                    Width = colWidth,
                    DisplayMemberBinding = new Binding("[" + lastIndex.ToString() + "]")
                });
        }

        public IListItem AddItem(object rowData, params object[] columnValues)
        {
            ZListViewItem item = new ZListViewItem();
            item.Data = rowData;
            item.Content = columnValues;
            base.Items.Add(item);
            return item;
        }

        public void BeginUpdate()
        {
        }

        public void EndUpdate()
        {
        }

        public void Clear()
        {
            base.Items.Clear();
            ClearColumns();
        }

        public void ClearColumns()
        {
            var gridView = base.View as GridView;
            gridView.Columns.Clear();
        }

        public void ClearItems()
        {
            base.Items.Clear();
        }

        public object GetSelectedData()
        {
            var item = base.SelectedItem as IListItem;
            return (item == null) ? null : item.Data;
        }

        public void SelectItem(object rowData)
        {
        }

        public void SetColumnCaption(int index, string caption)
        {
        }

        public void SetSortColumn(int sortColumn, bool checkOrder = true)
        {
        }

        public void Sort(int sortColumn, BSDTypes.SortOrder sortOrder)
        {
        }

        public void UpdateContents(bool columnsChanged = false)
        {
        }

        private void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader clickedHeader = e.OriginalSource as GridViewColumnHeader;
            if (clickedHeader != null) {
                if (clickedHeader.Role != GridViewColumnHeaderRole.Padding) {
                    ListSortDirection sortDirection;
                    if (clickedHeader != lastHeaderClicked) {
                        sortDirection = ListSortDirection.Ascending;
                    } else {
                        if (lastDirection == ListSortDirection.Ascending) {
                            sortDirection = ListSortDirection.Descending;
                        } else {
                            sortDirection = ListSortDirection.Ascending;
                        }
                    }

                    var binding = (Binding)clickedHeader.Column.DisplayMemberBinding;
                    string sortString = binding.Path.Path;
                    Sort(sortString, sortDirection);

                    lastHeaderClicked = clickedHeader;
                    lastDirection = sortDirection;
                }
            }
        }

        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(this.ItemsSource != null ? this.ItemsSource : this.Items);

            if (sortBy.StartsWith("[")) {
                IEnumerable lvItems = this.Items.SourceCollection;
                List<ZListViewItem> lviList = lvItems.Cast<ZListViewItem>().ToList();
                int colIndex = int.Parse(sortBy.Substring(1, sortBy.Length - 2));

                lviList.Sort(new ItComp(colIndex, direction));
                this.ItemsSource = null;
                this.Items.Clear();
                this.ItemsSource = lviList;
            } else {
                dataView.SortDescriptions.Clear();
                SortDescription sD = new SortDescription(sortBy, direction);
                dataView.SortDescriptions.Add(sD);
            }
            dataView.Refresh();
        }

        private class ItComp : IComparer<ZListViewItem>
        {
            private int fColIndex;
            private ListSortDirection fDirection;

            public ItComp(int colIndex, ListSortDirection direction)
            {
                fColIndex = colIndex;
                fDirection = direction;
            }

            public int Compare(ZListViewItem x, ZListViewItem y)
            {
                object[] xCont = (object[])x.Content;
                object[] yCont = (object[])y.Content;
                int result = ((IComparable)xCont[fColIndex]).CompareTo(yCont[fColIndex]);
                return (fDirection == ListSortDirection.Descending) ? -result : result;
            }
        }
    }
}
