/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.UI.Components;
using BSLib.Controls;
using Microsoft.Win32;

namespace AquaMate.UI
{
    /// <summary>
    /// 
    /// </summary>
    public static class UIHelper
    {
        #region Helpers to create controls

        public static ZListView CreateListView(string name)
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

        public static Control AddPanelButton(Panel panel, string actionName, string actionText, Image image, EventHandler handler)
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
            return btn;
        }

        public static Control AddPanelOptionsPicker(Panel panel, string actionName, string[] choices, EventHandler handler)
        {
            var picker = new OptionsPicker();
            picker.Dock = DockStyle.Top;
            picker.Name = "opt" + actionName;
            picker.Margin = new Padding(0, 0, 0, 10);
            picker.Size = new Size(190, 30);
            picker.BackColor = SystemColors.Control;
            picker.Items = choices;
            picker.Click += handler;
            panel.Controls.Add(picker);
            return picker;
        }

        public static Control AddPanelComboBox(Panel panel, string actionName, string[] choices, EventHandler handler)
        {
            var comboBox = new ComboBox();
            comboBox.Dock = DockStyle.Top;
            comboBox.Name = "cmb" + actionName;
            comboBox.Margin = new Padding(0, 0, 0, 10);
            comboBox.Size = new Size(190, 30);
            comboBox.BackColor = SystemColors.Control;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.Items.AddRange(choices);
            comboBox.SelectedIndex = 0;
            comboBox.SelectedIndexChanged += handler;
            panel.Controls.Add(comboBox);
            return comboBox;
        }

        #endregion

        public static Color CreateColor(int rgb)
        {
            int red = (rgb >> 16) & 0xFF;
            int green = (rgb >> 8) & 0xFF;
            int blue = (rgb >> 0) & 0xFF;
            return Color.FromArgb(red, green, blue);
        }

        #region Messages

        public static bool ShowQuestionYN(string msg)
        {
            return MessageBox.Show(msg, ALCore.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static void ShowWarning(string msg)
        {
            MessageBox.Show(msg, ALCore.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion

        #region Resources

        public static Stream LoadResourceStream(string resName)
        {
            #if !NETCOREAPP30
            resName = "AquaMate.Resources." + resName;
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

        #endregion

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
                    image = ALCore.ByteToImage(data);
                }
            }

            return image;
        }

        public static void SaveImage(Image image)
        {
            string fileName = GetSaveFile("title", "context",
                          "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.tiff)|*.jpg;*.jpeg;*.png;*.gif;*.tiff",
                          1, "jpg", "", true);

            if (string.IsNullOrEmpty(fileName))
                return;

            image.Save(fileName);
        }

        #endregion

        #region Application's autorun

        public static void RegisterStartup()
        {
            if (!IsStartupItem()) {
                RegistryKey rkApp = GetRunKey();
                string trayPath = ALCore.GetAppPath() + "AquaMate.exe";
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
