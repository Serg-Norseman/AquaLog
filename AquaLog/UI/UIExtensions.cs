/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaLog.UI.Components;
using AquaLog.Core;

namespace AquaLog.UI
{
    /// <summary>
    /// 
    /// </summary>
    public static class UIExtensions
    {
        public static void AddItem<T>(this ComboBox comboBox, string text, T tag)
        {
            comboBox.Items.Add(new ComboItem<T>(text, tag));
        }

        public static T GetSelectedTag<T>(this ComboBox comboBox)
        {
            object selectedItem = comboBox.SelectedItem;
            ComboItem<T> comboItem = (ComboItem<T>)selectedItem;
            T itemTag = (comboItem == null) ? default(T) : comboItem.Tag;
            return itemTag;
        }

        public static void SetSelectedTag<T>(this ComboBox comboBox, T tagValue)
        {
            foreach (object item in comboBox.Items) {
                ComboItem<T> comboItem = (ComboItem<T>)item;
                T itemTag = comboItem.Tag;

                if (tagValue.Equals(itemTag)) {
                    comboBox.SelectedItem = item;
                    return;
                }
            }
            comboBox.SelectedIndex = 0;
        }

        public static void FillCombo<T>(this ComboBox comboBox, LSID[] names, bool sorted) where T : struct
        {
            T[] array = (T[])Enum.GetValues(typeof(T));

            comboBox.Items.Clear();
            comboBox.Sorted = sorted;
            foreach (var enm in array) {
                int eIdx = Convert.ToInt32(enm);
                comboBox.AddItem<T>(Localizer.LS(names[eIdx]), enm);
            }
        }

        public static T GetSelectedTag<T>(this ListView listView) where T : class
        {
            var selectedItem = UIHelper.GetSelectedItem(listView);
            return (selectedItem == null) ? default(T) : selectedItem.Tag as T;
        }

        public static void AutoResizeColumns(this ListView lv)
        {
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            foreach (ColumnHeader column in lv.Columns) {
                int colWidth = TextRenderer.MeasureText(column.Text, lv.Font).Width + 10;
                if (colWidth > column.Width) {
                    column.Width = colWidth;
                }
            }
        }
    }
}
