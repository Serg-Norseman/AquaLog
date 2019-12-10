/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using AquaLog.UI.Components;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;
using BSLib.Controls;
using Microsoft.Win32;

namespace AquaLog.UI
{
    /// <summary>
    /// 
    /// </summary>
    public static class UIHelper
    {
        public static void AddPanelButton(Panel panel, string actionName, string actionText, Image image, EventHandler handler)
        {
            var btn = new Button();
            btn.Dock = DockStyle.Top;
            btn.Name = "btn" + actionName;
            btn.Text = actionText;
            btn.Image = image;
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.Margin = new Padding(0, 0, 0, 10);
            btn.Size = new Size(190, 30);
            btn.Click += handler;
            btn.BackColor = SystemColors.Control;
            panel.Controls.Add(btn);
        }

        public static void AddPanelCombo(Panel panel, string actionName, string[] choices, EventHandler handler)
        {
            var picker = new OptionsPicker();
            picker.Dock = DockStyle.Top;
            picker.Name = "opt" + actionName;
            picker.Margin = new Padding(0, 0, 0, 10);
            picker.Size = new Size(190, 30);
            picker.Click += handler;
            picker.BackColor = SystemColors.Control;
            picker.Items = choices;
            panel.Controls.Add(picker);
        }

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

        public static void FillItemStatesCombo(ComboBox comboBox, ItemType itemType, ItemState selectedState)
        {
            ItemProps props = ALData.ItemTypes[(int)itemType];
            comboBox.Items.Clear();
            for (ItemState state = ItemState.Unknown; state <= ItemState.Broken; state++) {
                if (state == ItemState.Unknown || props.States.Contains(state)) {
                    comboBox.AddItem<ItemState>(Localizer.LS(ALData.ItemStates[(int)state]), state);
                }
            }
            comboBox.SetSelectedTag<ItemState>(selectedState);
        }

        public static void FillStringsCombo(ComboBox comboBox, IList<QString> strings, string selectedText)
        {
            comboBox.Items.Clear();
            foreach (QString bqs in strings) {
                if (!string.IsNullOrEmpty(bqs.element))
                    comboBox.Items.Add(bqs.element);
            }
            comboBox.Text = selectedText;
        }

        public static bool ShowQuestionYN(string msg)
        {
            return MessageBox.Show(msg, ALCore.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static ListView CreateListView(string name)
        {
            var listView = new ZListView();
            listView.Dock = DockStyle.Fill;
            listView.Name = name;
            listView.HideSelection = false;
            listView.LabelEdit = false;
            listView.FullRowSelect = true;
            listView.View = View.Details;
            return listView;
        }

        public static ListViewItem GetSelectedItem(ListView listView)
        {
            ListViewItem result = (listView.SelectedItems.Count <= 0) ? null : listView.SelectedItems[0];
            return result;
        }

        public static Color CreateColor(int rgb)
        {
            int red = (rgb >> 16) & 0xFF;
            int green = (rgb >> 8) & 0xFF;
            int blue = (rgb >> 0) & 0xFF;
            return Color.FromArgb(red, green, blue);
        }

        public static Stream LoadResourceStream(string resName)
        {
            #if !NETCOREAPP30
            resName = "AquaLog.Resources." + resName;
            #else
            resName = "Resources." + resName;
            #endif

            return LoadResourceStream(typeof(UIHelper), resName);
        }

        public static Stream LoadResourceStream(Type baseType, string resName)
        {
            Assembly assembly = baseType.Assembly;
            return assembly.GetManifestResourceStream(resName);
        }

        public static Bitmap LoadResourceImage(string resName)
        {
            return new Bitmap(LoadResourceStream(resName));
        }

        #region Open/Save dialogs

        public static string GetOpenFile(string title, string context, string filter,
            int filterIndex, string defaultExt, bool multiSelect = false)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
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

                return (ofd.ShowDialog() == DialogResult.OK) ? ofd.FileName : string.Empty;
            }
        }

        public static string GetSaveFile(string filter)
        {
            return GetSaveFile("", "", filter, 1, "", "");
        }

        public static string GetSaveFile(string title, string context, string filter,
            int filterIndex, string defaultExt, string suggestedFileName, bool overwritePrompt = true)
        {
            using (SaveFileDialog sfd = new SaveFileDialog()) {
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

                return (sfd.ShowDialog() == DialogResult.OK) ? sfd.FileName : string.Empty;
            }
        }

        #endregion

        #region Images

        public static Image LoadImage()
        {
            Image image = null;

            string fileName = GetOpenFile("title", "context",
                          "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.tiff)|*.jpg;*.jpeg;*.png;*.gif;*.tiff",
                          1, "");

            if (string.IsNullOrEmpty(fileName))
                return image;

            if (File.Exists(fileName)) {
                using (FileStream stream = File.Open(fileName, FileMode.Open)) {
                    BinaryReader br = new BinaryReader(stream);
                    byte[] data = br.ReadBytes((int)stream.Length);
                    image = ALModel.ByteToImage(data);
                }
            }

            return image;
        }

        #endregion

        #region Application's autorun

        public static void RegisterStartup()
        {
            if (!IsStartupItem()) {
                RegistryKey rkApp = GetRunKey();
                string trayPath = ALCore.GetAppPath() + "AquaLog.exe";
                rkApp.SetValue(ALCore.AppName, trayPath);
            }
        }

        public static void UnregisterStartup()
        {
            if (IsStartupItem()) {
                RegistryKey rkApp = GetRunKey();
                rkApp.DeleteValue(ALCore.AppName, false);
            }
        }

        public static bool IsStartupItem()
        {
            RegistryKey rkApp = GetRunKey();
            return (rkApp.GetValue(ALCore.AppName) != null);
        }

        private static RegistryKey GetRunKey()
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            return rkApp;
        }

        #endregion
    }
}
