/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using AquaLog.Components;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;
using Microsoft.Win32;

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
            ListViewItem result;

            if (listView.SelectedItems.Count <= 0) {
                result = null;
            } else {
                result = (listView.SelectedItems[0] as ListViewItem);
            }

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
            return LoadResourceStream(typeof(ALCore), resName);
        }

        public static Stream LoadResourceStream(Type baseType, string resName)
        {
            Assembly assembly = baseType.Assembly;
            return assembly.GetManifestResourceStream(resName);
        }

        public static Bitmap LoadResourceImage(string resName)
        {
            return new Bitmap(LoadResourceStream("AquaLog.Resources." + resName));
        }

        public static void SetTankPropNames(ITank tank)
        {
            TankShape tankShape = tank.GetTankShape();

            ALCore.SetDisplayNameValue(tank, "GlassThickness", Localizer.LS(LSID.GlassThickness));

            switch (tankShape) {
                case TankShape.Unknown:
                case TankShape.Bowl:
                    break;

                case TankShape.Cube:
                    ALCore.SetDisplayNameValue(tank, "EdgeSize", Localizer.LS(LSID.EdgeSize));
                    break;

                case TankShape.Rectangular:
                    ALCore.SetDisplayNameValue(tank, "Depth", Localizer.LS(LSID.Depth));
                    ALCore.SetDisplayNameValue(tank, "Width", Localizer.LS(LSID.Width));
                    ALCore.SetDisplayNameValue(tank, "Height", Localizer.LS(LSID.Height));
                    break;

                case TankShape.BowFront:
                    ALCore.SetDisplayNameValue(tank, "Depth", Localizer.LS(LSID.Depth));
                    ALCore.SetDisplayNameValue(tank, "Width", Localizer.LS(LSID.Width));
                    ALCore.SetDisplayNameValue(tank, "Height", Localizer.LS(LSID.Height));
                    ALCore.SetDisplayNameValue(tank, "CentreDepth", Localizer.LS(LSID.CentreDepth));
                    break;

                case TankShape.PlateFrontCorner:
                case TankShape.BowFrontCorner:
                default:
                    break;
            }
        }

        #region Open/Save dialogs

        public static string GetOpenFile(string title, string context, string filter, int filterIndex, string defaultExt)
        {
            using (OpenFileDialog ofd = CreateOpenFileDialog(title, context, filter, filterIndex, defaultExt, false)) {
                return (ofd.ShowDialog() == DialogResult.OK) ? ofd.FileName : string.Empty;
            }
        }

        private static OpenFileDialog CreateOpenFileDialog(string title, string context, string filter,
            int filterIndex, string defaultExt, bool multiSelect)
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

            return ofd;
        }

        public static string GetSaveFile(string filter)
        {
            return GetSaveFile("", "", filter, 1, "", "");
        }

        public static string GetSaveFile(string title, string context, string filter, int filterIndex, string defaultExt,
            string suggestedFileName, bool overwritePrompt = true)
        {
            using (SaveFileDialog sfd = CreateSaveFileDialog(title, context, filter, filterIndex, defaultExt, suggestedFileName)) {
                sfd.OverwritePrompt = overwritePrompt;
                return (sfd.ShowDialog() == DialogResult.OK) ? sfd.FileName : string.Empty;
            }
        }

        private static SaveFileDialog CreateSaveFileDialog(string title, string context, string filter,
            int filterIndex, string defaultExt, string suggestedFileName)
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

            return sfd;
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
