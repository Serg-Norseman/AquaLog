/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AquaMate.Core;
using BSLib;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI
{
    /// <summary>
    /// 
    /// </summary>
    public static class UIExtensions
    {
        public static void AddItem<T>(this ComboBox comboBox, string text, T tag)
        {
            comboBox.Items.Add(new ListItem<T>(text, tag));
        }

        public static void FillCombo<T>(this ComboBox comboBox, IEnumerable<ListItem<T>> items, bool sorted)
        {
            comboBox.Items.Clear();
            foreach (var item in items) {
                comboBox.Items.Add(item);
            }
            comboBox.Sorted = sorted;
        }

        public static void FillCombo(this ComboBox comboBox, IEnumerable<string> items, bool sorted)
        {
            comboBox.Items.Clear();
            foreach (var item in items) {
                comboBox.Items.Add(item);
            }
            comboBox.Sorted = sorted;
        }

        public static T GetSelectedTag<T>(this ComboBox comboBox)
        {
            object selectedItem = comboBox.SelectedItem;
            ListItem<T> comboItem = (ListItem<T>)selectedItem;
            T itemTag = (comboItem == null) ? default(T) : comboItem.Tag;
            return itemTag;
        }

        public static void SetSelectedTag<T>(this ComboBox comboBox, T tagValue)
        {
            foreach (object item in comboBox.Items) {
                ListItem<T> comboItem = (ListItem<T>)item;
                T itemTag = comboItem.Tag;

                if (tagValue.Equals(itemTag)) {
                    comboBox.SelectedItem = item;
                    return;
                }
            }
            //comboBox.SelectedIndex = 0;
        }

        public static T GetSelectedTag<T>(this ListView listView) where T : class
        {
            var selectedItem = (listView.SelectedItems.Count <= 0) ? null : listView.SelectedItems[0];
            return (selectedItem == null) ? default(T) : selectedItem.Tag as T;
        }

        public static void SetSelectedItem(this ListView listView, int index)
        {
            if (index >= 0 && index < listView.Items.Count) {
                ListViewItem item = listView.Items[index];
                if (item != null) {
                    listView.SelectedIndices.Clear();
                    item.Selected = true;
                    item.EnsureVisible();
                }
            }
        }
    }
}
