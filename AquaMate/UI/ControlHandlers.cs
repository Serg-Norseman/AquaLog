/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BSLib;
using BSLib.Design.MVP;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI
{
    public abstract class BaseControlHandler<T, TThis> : ControlHandler<T, TThis>, IBaseControl
        where T : Control
        where TThis : ControlHandler<T, TThis>
    {
        protected BaseControlHandler(T control) : base(control)
        {
        }

        public bool Enabled
        {
            get { return Control.Enabled; }
            set { Control.Enabled = value; }
        }

        public void Activate()
        {
            Control.Select();
        }
    }


    public sealed class LabelHandler : BaseControlHandler<Label, LabelHandler>, ILabelHandler
    {
        public LabelHandler(Label control) : base(control)
        {
        }

        public string Text
        {
            get { return Control.Text; }
            set { Control.Text = value; }
        }
    }

    public sealed class ButtonHandler : BaseControlHandler<Button, ButtonHandler>, IButtonHandler
    {
        public ButtonHandler(Button control) : base(control)
        {
        }

        public string Text
        {
            get { return Control.Text; }
            set { Control.Text = value; }
        }
    }

    public sealed class CheckBoxHandler : BaseControlHandler<CheckBox, CheckBoxHandler>, ICheckBoxHandler
    {
        public CheckBoxHandler(CheckBox control) : base(control)
        {
        }

        public bool Checked
        {
            get { return Control.Checked; }
            set { Control.Checked = value; }
        }

        public string Text
        {
            get { return Control.Text; }
            set { Control.Text = value; }
        }
    }

    public sealed class RadioButtonHandler : BaseControlHandler<RadioButton, RadioButtonHandler>, IRadioButtonHandler
    {
        public RadioButtonHandler(RadioButton control) : base(control)
        {
        }

        public bool Checked
        {
            get { return Control.Checked; }
            set { Control.Checked = value; }
        }

        public string Text
        {
            get { return Control.Text; }
            set { Control.Text = value; }
        }
    }

    public sealed class ComboBoxHandler : BaseControlHandler<ComboBox, ComboBoxHandler>, IComboBoxHandlerEx
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

        /*public void AddItem(string caption, object tag, IImage image)
        {
            Control.Items.Add(new GKComboItem(caption, tag, image));
        }*/

        public void AddRange<T>(IEnumerable<ListItem<T>> items, bool sorted = false)
        {
            Control.Sorted = false;
            foreach (var item in items) {
                Control.Items.Add(item);
            }
            Control.Sorted = sorted;
        }

        public void AddRange(IList<string> items, bool sorted = false)
        {
            Control.Sorted = false;
            int num = items.Count;
            for (int i = 0; i < num; i++) {
                Control.Items.Add(items[i]);
            }
            Control.Sorted = sorted;
        }

        public void AddRange(object[] items, bool sorted = false)
        {
            Control.Sorted = false;
            Control.Items.AddRange(items);
            Control.Sorted = sorted;
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

        public void SortItems()
        {
        }

        public T GetSelectedTag<T>()
        {
            return Control.GetSelectedTag<T>();
        }

        public void SetSelectedTag<T>(T tagValue)
        {
            Control.SetSelectedTag<T>(tagValue);
        }
    }

    public sealed class ToolStripComboBoxHandler : ControlHandler<ToolStripComboBox, ToolStripComboBoxHandler>, IComboBoxHandlerEx
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

        /*public void AddItem(string caption, object tag, IImage image)
        {
            Control.Items.Add(new GKComboItem(caption, tag, image));
        }*/

        public void AddRange<T>(IEnumerable<ListItem<T>> items, bool sorted = false)
        {
            Control.Sorted = false;
            foreach (var item in items) {
                Control.Items.Add(item);
            }
            Control.Sorted = sorted;
        }

        public void AddRange(IList<string> items, bool sorted = false)
        {
            Control.Sorted = false;
            int num = items.Count;
            for (int i = 0; i < num; i++) {
                Control.Items.Add(items[i]);
            }
            Control.Sorted = sorted;
        }

        public void AddRange(object[] items, bool sorted = false)
        {
            Control.Sorted = false;
            Control.Items.AddRange(items);
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

        public void SortItems()
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
    }

    public sealed class PropertyGridHandler : BaseControlHandler<PropertyGrid, PropertyGridHandler>, IPropertyGridHandler
    {
        public PropertyGridHandler(PropertyGrid control) : base(control)
        {
        }

        public object SelectedObject
        {
            get { return Control.SelectedObject; }
            set { Control.SelectedObject = value; }
        }

        public void Refresh()
        {
            Control.Refresh();
        }
    }

    public sealed class PictureBoxHandler : BaseControlHandler<PictureBox, PictureBoxHandler>, IPictureBoxHandler
    {
        public PictureBoxHandler(PictureBox control) : base(control)
        {
        }

        public Image Image
        {
            get { return Control.Image; }
            set { Control.Image = value; }
        }
    }

    public sealed class TextBoxHandler : BaseControlHandler<TextBox, TextBoxHandler>, ITextBoxHandler
    {
        public TextBoxHandler(TextBox control) : base(control)
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
    }

    public sealed class MaskedTextBoxHandler : BaseControlHandler<MaskedTextBox, MaskedTextBoxHandler>, ITextBoxHandler
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
    }

    /*public sealed class DateBoxHandler : BaseControlHandler<GKDateBox, DateBoxHandler>, IDateBoxHandler
    {
        public DateBoxHandler(GKDateBox control) : base(control)
        {
        }

        public string NormalizeDate
        {
            get { return Control.NormalizeDate; }
            set { Control.NormalizeDate = value; }
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

    public sealed class NumericBoxHandler : BaseControlHandler<NumericUpDown, NumericBoxHandler>, INumericBoxHandler
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
    }

    public sealed class DateTimeBoxHandler : BaseControlHandler<DateTimePicker, DateTimeBoxHandler>, IDateTimeBoxHandler
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
    }

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

    public sealed class ProgressBarHandler : BaseControlHandler<ProgressBar, ProgressBarHandler>, IProgressBarHandler
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
    }

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
}
