/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AquaMate.UI.Components;
using BSLib;
using Microsoft.Win32;

namespace AquaMate.UI
{
    /// <summary>
    /// 
    /// </summary>
    public static class UIHelper
    {
        #region Extensions

        public static T GetSelectedTag<T>(this ZListView listView) where T : class
        {
            var selectedData = listView.GetSelectedData();
            //var selectedItem = (listView.SelectedItems.Count <= 0) ? null : listView.SelectedItems[0];
            return (selectedData == null) ? default(T) : selectedData as T;
        }

        public static void SetSelectedItem(this ZListView listView, int index)
        {
            /*if (index >= 0 && index < listView.Items.Count) {
                ListViewItem item = listView.Items[index];
                if (item != null) {
                    listView.SelectedIndices.Clear();
                    item.Selected = true;
                    item.EnsureVisible();
                }
            }*/
        }

        public static void AddRange(this ItemCollection collection, MenuItem[] range)
        {
            foreach (MenuItem item in range) {
                collection.Add(item);
            }
        }

        public static void SetGridCell(this UIElement element, int col, int row)
        {
            Grid.SetColumn(element, col);
            Grid.SetRow(element, row);
        }

        #endregion

        public static string[] Convert(string text)
        {
            var strList = new StringList(text);
            return strList.ToArray();
        }

        #region Helpers to create controls

        public static ZListView CreateListView(string name)
        {
            var listView = new ZListView();
            listView.Name = name;
            //listView.HideSelection = false;
            //listView.LabelEdit = false;
            //listView.FullRowSelect = true;
            //listView.View = View.Details;
            return listView;
        }

        public static Control AddPanelButton(Panel panel, string actionName, string actionText, Image image, RoutedEventHandler handler)
        {
            var btn = new Button();
            DockPanel.SetDock(btn, Dock.Top);
            btn.Name = "btn" + actionName;
            btn.Content = actionText;
            //btn.Image = image;
            //btn.ImageAlign = ContentAlignment.MiddleCenter;
            //btn.TextAlign = ContentAlignment.MiddleCenter;
            //btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.Margin = new Thickness(10, 0, 10, 10);
            btn.Height = 28; // 30
            btn.Click += handler;
            //btn.BackColor = SystemColors.Control;
            panel.Children.Add(btn);
            return btn;
        }

        public static Control AddPanelOptionsPicker(Panel panel, string actionName, string[] choices, RoutedEventHandler handler)
        {
            var picker = new OptionsPicker();
            DockPanel.SetDock(picker, Dock.Top);
            picker.Name = "opt" + actionName;
            picker.Margin = new Thickness(10, 0, 10, 10);
            picker.Height = 28; // 30
            //picker.BackColor = SystemColors.Control;
            //picker.Items = choices;
            //picker.Click += handler;
            panel.Children.Add(picker);
            return picker;
        }

        public static Control AddPanelComboBox(Panel panel, string actionName, string[] choices, RoutedEventHandler handler)
        {
            var comboBox = new ComboBox();
            DockPanel.SetDock(comboBox, Dock.Top);
            comboBox.Name = "cmb" + actionName;
            comboBox.Margin = new Thickness(10, 0, 10, 10);
            comboBox.Height = 28; // 30
            //comboBox.BackColor = SystemColors.Control;
            //comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (string ch in choices) {
                comboBox.Items.Add(ch);
            }
            comboBox.SelectedIndex = 0;
            comboBox.SelectionChanged += new SelectionChangedEventHandler(handler);
            panel.Children.Add(comboBox);
            return comboBox;
        }

        #endregion

        #region Messages

        public static bool ShowQuestionYN(string msg)
        {
            return false;
            //return MessageBox.Show(msg, ALCore.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static void ShowWarning(string msg)
        {
            //MessageBox.Show(msg, ALCore.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion

        #region Resources

        public static Stream LoadResourceStream(Type baseType, string resName)
        {
            Assembly assembly = baseType.Assembly;
            return assembly.GetManifestResourceStream(resName);
        }

        public static Stream LoadResourceStream(string resName)
        {
            #if !NETCOREAPP30
            resName = "AquaMate.Resources." + resName;
            #else
            resName = "Resources." + resName;
            #endif

            return LoadResourceStream(typeof(UIHelper), resName);
        }

        /*public static Bitmap LoadResourceImage(string resName)
        {
            return new Bitmap(LoadResourceStream(resName));
        }*/

        #endregion

        #region Open/Save dialogs

        public static string GetOpenFile(string title, string context, string filter,
            int filterIndex, string defaultExt, bool multiSelect = false)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (!string.IsNullOrEmpty(title))
                ofd.Title = title;

            if (!string.IsNullOrEmpty(context))
                ofd.InitialDirectory = context;

            if (!string.IsNullOrEmpty(filter)) {
                ofd.Filter = filter;

                if (filterIndex > 0)
                    ofd.FilterIndex = filterIndex;
            }

            if (!string.IsNullOrEmpty(defaultExt))
                ofd.DefaultExt = defaultExt;

            ofd.Multiselect = multiSelect;

            return (bool)ofd.ShowDialog() ? ofd.FileName : string.Empty;
        }

        public static string GetSaveFile(string filter)
        {
            return GetSaveFile("", "", filter, 1, "", "");
        }

        public static string GetSaveFile(string title, string context, string filter,
            int filterIndex, string defaultExt, string suggestedFileName, bool overwritePrompt = true)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            if (!string.IsNullOrEmpty(title))
                sfd.Title = title;

            if (!string.IsNullOrEmpty(context))
                sfd.InitialDirectory = context;

            if (!string.IsNullOrEmpty(filter)) {
                sfd.Filter = filter;

                if (filterIndex > 0)
                    sfd.FilterIndex = filterIndex;
            }

            if (!string.IsNullOrEmpty(defaultExt))
                sfd.DefaultExt = defaultExt;

            if (!string.IsNullOrEmpty(suggestedFileName))
                sfd.FileName = suggestedFileName;

            sfd.OverwritePrompt = overwritePrompt;

            return (bool)sfd.ShowDialog() ? sfd.FileName : string.Empty;
        }

        #endregion

        #region Graphics

        public static Color CreateColor(int rgb)
        {
            int red = (rgb >> 16) & 0xFF;
            int green = (rgb >> 8) & 0xFF;
            int blue = (rgb >> 0) & 0xFF;
            return Color.FromRgb((byte)red, (byte)green, (byte)blue);
        }

        #endregion
    }
}
