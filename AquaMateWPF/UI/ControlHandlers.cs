/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AquaMate.UI.Components;
using BSLib;
using BSLib.Design;
using BSLib.Design.Graphics;
using BSLib.Design.MVP;
using BSLib.Design.MVP.Controls;
using WPG;

namespace AquaMate.UI
{
    public sealed class ColorHandler : TypeHandler<Color>, IColor
    {
        public ColorHandler(Color handle) : base(handle)
        {
        }

        public IColor Darker(float fraction)
        {
            return null;
            //new ColorHandler(UIHelper.Darker(this.Handle, fraction));
        }

        public IColor Lighter(float fraction)
        {
            return null;
            //new ColorHandler(UIHelper.Lighter(this.Handle, fraction));
        }

        public string GetName()
        {
            //Color color = this.Handle;
            //return color.Name;
            return string.Empty;
        }

        public int ToArgb()
        {
            int result = 0; //this.Handle.ToArgb();
            return result;
        }

        public string GetCode()
        {
            int argb = ToArgb() & 0xFFFFFF;
            string result = argb.ToString("X6");
            return result;
        }

        public byte GetR()
        {
            return Handle.R;
        }

        public byte GetG()
        {
            return Handle.G;
        }

        public byte GetB()
        {
            return Handle.B;
        }

        public byte GetA()
        {
            return Handle.A;
        }

        public bool IsTransparent()
        {
            return false;
            //(Handle == Color.Transparent);
        }
    }


    public sealed class BrushHandler : TypeHandler<SolidColorBrush>, IBrush
    {
        public IColor Color
        {
            get {
                return null;//UIHelper.ConvertColor(((SolidColorBrush)Handle).Color);
            }
        }

        public BrushHandler(SolidColorBrush handle) : base(handle)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                //Handle.Dispose();
            }
            base.Dispose(disposing);
        }
    }


    public abstract class BaseControlHandler<T, TThis> : ControlHandler<T, TThis>, IBaseControl
        where T : UIElement
        where TThis : ControlHandler<T, TThis>
    {
        protected BaseControlHandler(T control) : base(control)
        {
        }

        public bool Enabled
        {
            get { return Control.IsEnabled; }
            set { Control.IsEnabled = value; }
        }

        public void Activate()
        {
            Control.Focus();
        }
    }


    public sealed class LabelHandler : BaseControlHandler<Label, LabelHandler>, ILabel
    {
        public LabelHandler(Label control) : base(control)
        {
        }

        public string Text
        {
            get { return (string)Control.Content; }
            set { Control.Content = value; }
        }
    }

    public sealed class ButtonHandler : BaseControlHandler<Button, ButtonHandler>, IButton
    {
        public ButtonHandler(Button control) : base(control)
        {
        }

        public string Text
        {
            get { return (string)Control.Content; }
            set { Control.Content = value; }
        }
    }

    public sealed class CheckBoxHandler : BaseControlHandler<CheckBox, CheckBoxHandler>, ICheckBox
    {
        public CheckBoxHandler(CheckBox control) : base(control)
        {
        }

        public bool Checked
        {
            get { return (bool)Control.IsChecked; }
            set { Control.IsChecked = value; }
        }

        public string Text
        {
            get { return (string)Control.Content; }
            set { Control.Content = value; }
        }
    }

    public sealed class RadioButtonHandler : BaseControlHandler<RadioButton, RadioButtonHandler>, IRadioButton
    {
        public RadioButtonHandler(RadioButton control) : base(control)
        {
        }

        public bool Checked
        {
            get { return (bool)Control.IsChecked; }
            set { Control.IsChecked = value; }
        }

        public string Text
        {
            get { return (string)Control.Content; }
            set { Control.Content = value; }
        }
    }

    public sealed class ComboBoxHandler : BaseControlHandler<ComboBox, ComboBoxHandler>, IComboBox
    {
        public ComboBoxHandler(ComboBox control) : base(control)
        {
        }

        public IList Items
        {
            get { return Control.Items; }
        }

        public bool ReadOnly
        {
            get { return Control.IsReadOnly; }
            set { Control.IsReadOnly = value; }
        }

        public int SelectedIndex
        {
            get { return Control.SelectedIndex; }
            set { Control.SelectedIndex = value; }
        }

        public object SelectedItem
        {
            get { return Control.SelectedItem; }
            set { Control.SelectedItem = value; }
        }

        public string Text
        {
            get { return Control.Text; }
            set { Control.Text = value; }
        }

        public void Add(object item)
        {
            Control.Items.Add(item);
        }

        public void AddItem<T>(string caption, T tag)
        {
            Control.Items.Add(new ComboItem<T>(caption, tag));
        }

        public void AddItem<T>(string caption, T tag, IImage image)
        {
            Control.Items.Add(new ComboItem<T>(caption, tag, image));
        }

        public void AddRange(IEnumerable<object> items, bool sorted = false)
        {
            Control.Items.Clear();
            //Control.Sorted = false;
            foreach (object item in items) {
                Control.Items.Add(item);
            }
            //Control.Sorted = sorted;
        }

        public void AddStrings(StringList strings)
        {
            int num = strings.Count;
            for (int i = 0; i < num; i++) {
                AddItem(strings[i], strings.GetObject(i));
            }
        }

        public void BeginUpdate()
        {
            //Control.BeginUpdate();
        }

        public void Clear()
        {
            Control.Items.Clear();
        }

        public void EndUpdate()
        {
            //Control.EndUpdate();
        }

        public void Sort()
        {
        }

        public T GetSelectedTag<T>()
        {
            object selectedItem = Control.SelectedItem;
            ComboItem<T> comboItem = (ComboItem<T>)selectedItem;
            T itemTag = (comboItem == null) ? default(T) : comboItem.Tag;
            return itemTag;
        }

        public void SetSelectedTag<T>(T tagValue, bool allowDefault = true)
        {
            var items = Control.Items;
            for (int i = 0; i < items.Count; i++) {
                var item = items[i];
                ComboItem<T> comboItem = (ComboItem<T>)item;
                T itemTag = comboItem.Tag;

                if (tagValue.Equals(itemTag)) {
                    Control.SelectedItem = comboItem;
                    return;
                }
            }

            if (allowDefault) {
                Control.SelectedIndex = 0;
            }
        }
    }

    /*public sealed class ToolStripComboBoxHandler : ControlHandler<ToolStripComboBox, ToolStripComboBoxHandler>, IComboBox
    {
        public ToolStripComboBoxHandler(ToolStripComboBox control) : base(control)
        {
        }

        public bool Enabled
        {
            get { return Control.Enabled; }
            set { Control.Enabled = value; }
        }

        public IList Items
        {
            get { return Control.Items; }
        }

        public bool ReadOnly
        {
            get { return (Control.DropDownStyle == ComboBoxStyle.DropDownList); }
            set { Control.DropDownStyle = (value) ? ComboBoxStyle.DropDownList : ComboBoxStyle.DropDown; }
        }

        public int SelectedIndex
        {
            get { return Control.SelectedIndex; }
            set { Control.SelectedIndex = value; }
        }

        public object SelectedItem
        {
            get { return Control.SelectedItem; }
            set { Control.SelectedItem = value; }
        }

        public string Text
        {
            get { return Control.Text; }
            set { Control.Text = value; }
        }

        public void Add(object item)
        {
            Control.Items.Add(item);
        }

        public void AddItem<T>(string caption, T tag)
        {
            Control.Items.Add(new ListItem<T>(caption, tag));
        }

        public void AddItem<T>(string caption, T tag, IImage image)
        {
            Control.Items.Add(new ListItem<T>(caption, tag, image));
        }

        public void AddRange(IEnumerable<object> items, bool sorted = false)
        {
            Control.Items.Clear();
            Control.Sorted = false;
            foreach (object item in items) {
                Control.Items.Add(item);
            }
            Control.Sorted = sorted;
        }

        public void AddStrings(StringList strings)
        {
            int num = strings.Count;
            for (int i = 0; i < num; i++) {
                Control.Items.Add(strings[i]);
            }
        }

        public void BeginUpdate()
        {
            Control.BeginUpdate();
        }

        public void Clear()
        {
            Control.Items.Clear();
        }

        public void EndUpdate()
        {
            Control.EndUpdate();
        }

        public void Activate()
        {
            Control.Select();
        }

        public void Sort()
        {
        }

        public T GetSelectedTag<T>()
        {
            object selectedItem = Control.SelectedItem;
            ListItem<T> comboItem = (ListItem<T>)selectedItem;
            T itemTag = (T)comboItem.Tag;
            return itemTag;
        }

        public void SetSelectedTag<T>(T tagValue)
        {
            var ctl = Control;
            foreach (object item in ctl.Items) {
                ListItem<T> comboItem = (ListItem<T>)item;
                T itemTag = (T)comboItem.Tag;

                if (tagValue.Equals(itemTag)) {
                    ctl.SelectedItem = item;
                    return;
                }
            }
            ctl.SelectedIndex = 0;
        }
    }*/

    public sealed class PropertyGridHandler : BaseControlHandler<PropertyGrid, PropertyGridHandler>, IPropertyGrid
    {
        public PropertyGridHandler(PropertyGrid control) : base(control)
        {
        }

        public object SelectedObject
        {
            get { return Control.Instance; }
            set { Control.Instance = value; }
        }

        public void Refresh()
        {
            Control.Refresh();
        }
    }

    /*public sealed class PictureBoxHandler : BaseControlHandler<PictureBox, PictureBoxHandler>, IPictureBox
    {
        public PictureBoxHandler(PictureBox control) : base(control)
        {
        }

        public IImage Image
        {
            get {
                return new ImageHandler(Control.Image);
            }
            set {
                if (value == null) {
                    Control.Image = null;
                } else {
                    var image = ((ImageHandler)value).Handle;
                    Control.Image = image;
                }
            }
        }
    }*/

    public sealed class TextBoxHandler : BaseControlHandler<TextBox, TextBoxHandler>, ITextBox
    {
        public TextBoxHandler(TextBox control) : base(control)
        {
        }

        public string[] Lines
        {
            get { return UIHelper.Convert(Control.Text); }
            set { /*Control.Lines = value;*/ }
        }

        public bool ReadOnly
        {
            get { return Control.IsReadOnly; }
            set { Control.IsReadOnly = value; }
        }

        public string SelectedText
        {
            get { return Control.SelectedText; }
            set { Control.SelectedText = value; }
        }

        public string Text
        {
            get { return Control.Text; }
            set { Control.Text = value; }
        }

        public void AppendText(string text)
        {
            Control.AppendText(text);
        }

        public void Clear()
        {
            Control.Clear();
        }

        public void Copy()
        {
            Control.Copy();
        }

        public void SelectAll()
        {
            Control.SelectAll();
        }
    }

    /*public sealed class MaskedTextBoxHandler : BaseControlHandler<MaskedTextBox, MaskedTextBoxHandler>, ITextBox
    {
        public MaskedTextBoxHandler(MaskedTextBox control) : base(control)
        {
        }

        public string[] Lines
        {
            get { return Control.Lines; }
            set { Control.Lines = value; }
        }

        public bool ReadOnly
        {
            get { return Control.ReadOnly; }
            set { Control.ReadOnly = value; }
        }

        public string SelectedText
        {
            get { return Control.SelectedText; }
            set { Control.SelectedText = value; }
        }

        public string Text
        {
            get { return Control.Text; }
            set { Control.Text = value; }
        }

        public void AppendText(string text)
        {
            Control.AppendText(text);
        }

        public void Clear()
        {
            Control.Clear();
        }

        public void Copy()
        {
            Control.Copy();
        }

        public void SelectAll()
        {
            Control.SelectAll();
        }
    }*/

    /*public sealed class NumericBoxHandler : BaseControlHandler<NumericUpDown, NumericBoxHandler>, INumericBox
    {
        public NumericBoxHandler(NumericUpDown control) : base(control)
        {
        }

        public bool ReadOnly
        {
            get { return Control.ReadOnly; }
            set { Control.ReadOnly = value; }
        }

        public string Text
        {
            get { return Control.Text; }
            set { Control.Text = value; }
        }

        public double Value
        {
            get { return decimal.ToDouble(Control.Value); }
            set { Control.Value = (decimal)value; }
        }
    }*/

    /*public sealed class DateTimeBoxHandler : BaseControlHandler<DateTimePicker, DateTimeBoxHandler>, IDateTimeBox
    {
        public DateTimeBoxHandler(DateTimePicker control) : base(control)
        {
        }

        public bool Checked
        {
            get { return Control.Checked; }
            set { Control.Checked = value; }
        }

        public DateTime Value
        {
            get { return Control.Value; }
            set { Control.Value = value; }
        }
    }*/

    /*public sealed class TreeViewHandler : BaseControlHandler<TreeView, TreeViewHandler>, ITreeViewHandler
    {
        public TreeViewHandler(TreeView control) : base(control)
        {
        }

        public ITVNode AddNode(ITVNode parent, string name, object tag)
        {
            var node = new GKTreeNode(name, tag);
            if (parent == null) {
                Control.Nodes.Add(node);
            } else {
                ((GKTreeNode)parent).Nodes.Add(node);
            }
            return node;
        }

        public void BeginUpdate()
        {
            Control.BeginUpdate();
        }

        public void Clear()
        {
            Control.Nodes.Clear();
        }

        public void EndUpdate()
        {
            Control.EndUpdate();
        }

        public void Expand(ITVNode node)
        {
            TreeNode treeNode = node as TreeNode;
            if (treeNode != null) {
                treeNode.ExpandAll();
            }
        }

        public object GetSelectedData()
        {
            GKTreeNode node = Control.SelectedNode as GKTreeNode;
            return (node == null) ? null : node.Tag;
        }
    }*/

    /*public sealed class ProgressBarHandler : BaseControlHandler<ProgressBar, ProgressBarHandler>, IProgressBar
    {
        public ProgressBarHandler(ProgressBar control) : base(control)
        {
        }

        public int Minimum
        {
            get { return Control.Minimum; }
            set { Control.Minimum = value; }
        }

        public int Maximum
        {
            get { return Control.Maximum; }
            set { Control.Maximum = value; }
        }

        public int Value
        {
            get { return Control.Value; }
            set { Control.Value = value; }
        }

        public void Increment(int value)
        {
            Control.Increment(value);
        }
    }*/

    public sealed class TabControlHandler : BaseControlHandler<TabControl, TabControlHandler>, ITabControl
    {
        public TabControlHandler(TabControl control) : base(control)
        {
        }

        public int SelectedIndex
        {
            get { return Control.SelectedIndex; }
            set { Control.SelectedIndex = value; }
        }
    }

    /*public sealed class MenuItemHandler : ControlHandler<ToolStripMenuItem, MenuItemHandler>, IMenuItem
    {
        public MenuItemHandler(ToolStripMenuItem control) : base(control)
        {
        }

        public bool Checked
        {
            get { return Control.Checked; }
            set { Control.Checked = value; }
        }

        public bool Enabled
        {
            get { return Control.Enabled; }
            set { Control.Enabled = value; }
        }

        public object Tag
        {
            get { return Control.Tag; }
            set { Control.Tag = value; }
        }

        public int ItemsCount
        {
            get { return Control.DropDownItems.Count; }
        }

        public IMenuItem AddItem(string text, object tag, IImage image, ItemAction action)
        {
            var item = new MenuItemEx(text, tag, image, action);
            Control.DropDownItems.Add(item);
            return item;
        }

        public void ClearItems()
        {
            Control.DropDownItems.Clear();
        }
    }*/


    /// <summary>
    /// 
    /// </summary>
    /*public sealed class ColorHandler: TypeHandler<Color>, IColor
    {
        public ColorHandler(Color handle) : base(handle)
        {
        }

        public IColor Darker(float fraction)
        {
            int rgb = this.Handle.ToArgb();
            Color newColor = Color.FromArgb(GfxHelper.Darker(rgb, fraction));
            return new ColorHandler(newColor);
        }

        public IColor Lighter(float fraction)
        {
            int rgb = this.Handle.ToArgb();
            Color newColor = Color.FromArgb(GfxHelper.Lighter(rgb, fraction));
            return new ColorHandler(newColor);
        }

        public string GetName()
        {
            Color color = this.Handle;
            return color.Name;
        }

        public int ToArgb()
        {
            int result = this.Handle.ToArgb();
            return result;
        }

        public string GetCode()
        {
            int argb = ToArgb() & 0xFFFFFF;
            string result = argb.ToString("X6");
            return result;
        }

        public byte GetR()
        {
            return Handle.R;
        }

        public byte GetG()
        {
            return Handle.G;
        }

        public byte GetB()
        {
            return Handle.B;
        }

        public byte GetA()
        {
            return Handle.A;
        }

        public bool IsTransparent()
        {
            return (Handle == Color.Transparent);
        }
    }*/


    /// <summary>
    /// 
    /// </summary>
    /*public sealed class PenHandler: TypeHandler<Pen>, IPen
    {
        public IColor Color
        {
            get { return new ColorHandler(Handle.Color); }
        }

        public float Width
        {
            get { return Handle.Width; }
        }

        public PenHandler(Pen handle) : base(handle)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                Handle.Dispose();
            }
            base.Dispose(disposing);
        }
    }*/


    /// <summary>
    /// 
    /// </summary>
    /*public sealed class BrushHandler: TypeHandler<Brush>, IBrush
    {
        public IColor Color
        {
            get { return new ColorHandler(((SolidBrush)Handle).Color); }
        }

        public BrushHandler(Brush handle) : base(handle)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                Handle.Dispose();
            }
            base.Dispose(disposing);
        }
    }*/


    /// <summary>
    /// 
    /// </summary>
    /*public sealed class FontHandler: TypeHandler<Font>, IFont
    {
        public string FontFamilyName
        {
            get { return Handle.FontFamily.Name; }
        }

        public string Name
        {
            get { return Handle.Name; }
        }

        public float Size
        {
            get { return Handle.Size; }
        }

        public FontHandler(Font handle) : base(handle)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                Handle.Dispose();
            }
            base.Dispose(disposing);
        }
    }*/


    /// <summary>
    /// 
    /// </summary>
    /*public sealed class ImageHandler: TypeHandler<Image>, IImage
    {
        public int Height
        {
            get { return Handle.Height; }
        }

        public int Width
        {
            get { return Handle.Width; }
        }

        public ImageHandler(Image handle) : base(handle)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                Handle.Dispose();
            }
            base.Dispose(disposing);
        }

        public byte[] GetBytes()
        {
            //Handle.get
            using (var stream = new MemoryStream())
            {
                Handle.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                return stream.ToArray();
            }
        }
    }*/


    /// <summary>
    /// 
    /// </summary>
    /*public class GfxPathHandler: TypeHandler<GraphicsPath>, IGfxPath
    {
        public GfxPathHandler(GraphicsPath handle) : base(handle)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                Handle.Dispose();
            }
            base.Dispose(disposing);
        }

        public void AddEllipse(float x, float y, float width, float height)
        {
            Handle.AddEllipse(x, y, width, height);
        }

        public void CloseFigure()
        {
            Handle.CloseFigure();
        }

        public void StartFigure()
        {
            Handle.StartFigure();
        }

        public ExtRectF GetBounds()
        {
            RectangleF rect = Handle.GetBounds();
            return ExtRectF.CreateBounds(rect.Left, rect.Top, rect.Width, rect.Height);
        }
    }*/


    /*public class ZListItem : ListViewItem, IListItem
    {
        protected object fValue;

        public object Data { get; set; }

        public ZListItem()
        {
            fValue = null;
        }

        public ZListItem(object itemValue, object data)
        {
            fValue = itemValue;
            Text = ToString();
            Data = data;
        }

        public override string ToString()
        {
            return (fValue == null) ? string.Empty : fValue.ToString();
        }

        public int CompareTo(object obj)
        {
            ZListItem otherItem = obj as ZListItem;
            if (otherItem == null) {
                return -1;
            }

            //IComparable cv1 = fValue as IComparable;
            //IComparable cv2 = otherItem.fValue as IComparable;

            IComparable cv1 = this.Text as IComparable;
            IComparable cv2 = otherItem.Text as IComparable;

            int compRes;
            if (cv1 != null && cv2 != null)
            {
                compRes = cv1.CompareTo(cv2);
            }
            else if (cv1 != null)
            {
                compRes = -1;
            }
            else if (cv2 != null)
            {
                compRes = 1;
            }
            else {
                compRes = 0;
            }
            return compRes;
        }

        public void AddSubItem(object itemValue)
        {
            ZListSubItem subItem = new ZListSubItem(itemValue);
            SubItems.Add(subItem);
        }

        public void SetBackColor(IColor color)
        {
            var colorHandler = color as ColorHandler;
            if (colorHandler != null) {
                BackColor = colorHandler.Handle;
            }
        }

        public void SetForeColor(IColor color)
        {
            var colorHandler = color as ColorHandler;
            if (colorHandler != null) {
                ForeColor = colorHandler.Handle;
            }
        }
    }*/


    /*public class ZListSubItem : ListViewItem.ListViewSubItem, IComparable
    {
        protected object fValue;

        public ZListSubItem(object itemValue)
        {
            fValue = itemValue;
            Text = ToString();
        }

        public override string ToString()
        {
            return (fValue == null) ? string.Empty : fValue.ToString();
        }

        public int CompareTo(object obj)
        {
            ZListSubItem otherItem = obj as ZListSubItem;
            if (otherItem == null) {
                return -1;
            }

            if (fValue is string && otherItem.fValue is string) {
                return ZListView.StrCompareEx((string)fValue, (string)otherItem.fValue);
            }

            IComparable cv1 = fValue as IComparable;
            IComparable cv2 = otherItem.fValue as IComparable;

            int compRes;
            if (cv1 != null && cv2 != null)
            {
                compRes = cv1.CompareTo(cv2);
            }
            else if (cv1 != null)
            {
                compRes = -1;
            }
            else if (cv2 != null)
            {
                compRes = 1;
            }
            else {
                compRes = 0;
            }
            return compRes;
        }
    }*/

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

    public sealed class ZListViewHandler : BaseControlHandler<ZListView, ZListViewHandler>, IListView
    {
        private ZListViewItems fItems;

        public ZListViewHandler(ZListView control) : base(control)
        {
            fItems = new ZListViewItems(control);
        }

        public IListViewItems Items
        {
            get { return fItems; }
        }

        public int SortColumn
        {
            get { return Control.SortColumn; }
            set { Control.SortColumn = value; }
        }

        public void AddColumn(string caption, int width, bool autoSize)
        {
        }

        public void AddColumn(string caption, int width, bool autoSize, BSDTypes.HorizontalAlignment textAlign)
        {
            Control.AddColumn(caption, width, autoSize, textAlign);
        }

        public IListItem AddItem(object rowData, params object[] columnValues)
        {
            //string[] strValues = Array.ConvertAll<object, string>(columnValues, Convert.ToString);
            //return Control.AddItemEx<ZListItem>(rowData, strValues) as IListItem;
            return Control.AddItem(rowData, columnValues);
        }

        public void BeginUpdate()
        {
            Control.BeginUpdate();
        }

        public void EndUpdate()
        {
            Control.EndUpdate();
        }

        public void Clear()
        {
            Control.Clear();
        }

        public void ClearColumns()
        {
            Control.ClearColumns();
        }

        public void ClearItems()
        {
            Control.Items.Clear();
        }

        public void DeleteRecord(object data)
        {
        }

        public object GetSelectedData()
        {
            return null;
        }

        public void SelectItem(object rowData)
        {
        }

        public void SetColumnCaption(int index, string caption)
        {
        }

        public void SetSortColumn(int sortColumn, bool checkOrder = true)
        {
            Control.SortColumn = sortColumn;
        }

        public void Sort(int sortColumn, BSLib.Design.BSDTypes.SortOrder sortOrder)
        {
            //Control.Sort(sortColumn, (System.Windows.Forms.SortOrder)sortOrder);
        }

        public void UpdateContents(bool columnsChanged = false)
        {
        }
    }
}
