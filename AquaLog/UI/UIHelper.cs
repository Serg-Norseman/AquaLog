/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Linq;
using System.Windows.Forms;
using AquaLog.Components;
using AquaLog.Core;

namespace AquaLog.UI
{
    /// <summary>
    /// 
    /// </summary>
    public static class UIHelper
    {
        public static void FillAquariumsCombo(ComboBox comboBox, ALModel model, int selectedId)
        {
            comboBox.Items.Clear();
            var aquariums = model.QueryAquariums();
            foreach (var aqm in aquariums) {
                if (selectedId != 0 || !aqm.IsInactive()) {
                    comboBox.Items.Add(aqm);
                }
            }
            comboBox.SelectedItem = aquariums.FirstOrDefault(aqm => aqm.Id == selectedId);
        }

        public static bool ShowQuestionYN(string msg)
        {
            return MessageBox.Show(msg, ALCore.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static ListView CreateListView(string name)
        {
            var listView = new ListView();
            listView.Dock = DockStyle.Fill;
            listView.Name = name;
            listView.HideSelection = false;
            listView.LabelEdit = false;
            listView.FullRowSelect = true;
            listView.View = View.Details;
            return listView;
        }

        public static T GetSelectedTag<T>(ComboBox comboBox)
        {
            object selectedItem = comboBox.SelectedItem;
            ComboItem<T> comboItem = (ComboItem<T>)selectedItem;
            T itemTag = (comboItem == null) ? default(T) : (T)comboItem.Tag;
            return itemTag;
        }

        public static void SetSelectedTag<T>(ComboBox comboBox, T tagValue)
        {
            foreach (object item in comboBox.Items) {
                ComboItem<T> comboItem = (ComboItem<T>)item;
                T itemTag = (T)comboItem.Tag;

                if (tagValue.Equals(itemTag)) {
                    comboBox.SelectedItem = item;
                    return;
                }
            }
            comboBox.SelectedIndex = 0;
        }
    }
}
