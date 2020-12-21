using System.Windows.Controls;
using System.Windows.Data;
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
            //base.Background = new SolidColorBrush();
        }

        public void SetForeColor(IColor color)
        {
            //base.Foreground
        }

        public void SetFont(IFont font)
        {

        }
    }


    public class ZListView : ListView, IListView
    {
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
                return null;
            }
        }


        public ZListView()
        {
            View = new GridView();
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
    }
}
