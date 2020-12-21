﻿/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Windows;
using System.Windows.Controls;
using AquaMate.Core;
using AquaMate.UI.Components;
using AquaMate.UI.Dialogs;
using BSLib.Design.Graphics;
using BSLib.Design.IoC;
using BSLib.Design.MVP;
using WPG;

namespace AquaMate.UI
{
    /// <summary>
    /// 
    /// </summary>
    public class WPFAppHost : AppHost
    {
        public WPFAppHost() : base()
        {
        }

        protected override void AppInit()
        {
            #if NETCOREAPP30
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            #endif

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            RegisterControlHandlers();
            RegisterViews();
        }

        protected override void AppRun(AquaMate.UI.IView view)
        {
            var mainForm = view as Window;
            mainForm.Show();
        }

        public override byte[] ImageToByte(IImage image)
        {
            /*var wfImage = ((ImageHandler)image).Handle;
            return ALCore.ImageToByte(wfImage, ImageFormat.Jpeg);*/
            return null;
        }

        public override IImage ByteToImage(byte[] imageBytes)
        {
            /*var wfImage = ALCore.ByteToImage(imageBytes);
            return new ImageHandler(wfImage);*/
            return null;
        }

        public override IImage LoadImage()
        {
            /*Image image = null;

            string fileName = UIHelper.GetOpenFile("title", "context",
                          "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.tiff)|*.jpg;*.jpeg;*.png;*.gif;*.tiff",
                          1, "");

            if (string.IsNullOrEmpty(fileName))
                return null;

            if (File.Exists(fileName)) {
                using (FileStream stream = File.Open(fileName, FileMode.Open)) {
                    BinaryReader br = new BinaryReader(stream);
                    byte[] data = br.ReadBytes((int)stream.Length);
                    image = ALCore.ByteToImage(data);
                }
            }*/

            return null;//new ImageHandler(image);
        }

        public override void SaveImage(IImage image)
        {
            /*string fileName = UIHelper.GetSaveFile("title", "context",
                          "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.tiff)|*.jpg;*.jpeg;*.png;*.gif;*.tiff",
                          1, "jpg", "", true);

            if (string.IsNullOrEmpty(fileName))
                return;

            var wfImage = ((ImageHandler)image).Handle;
            wfImage.Save(fileName);*/
        }

        public static void RegisterControlHandlers()
        {
            ControlsManager.RegisterHandlerType(typeof(Button), typeof(ButtonHandler));
            ControlsManager.RegisterHandlerType(typeof(CheckBox), typeof(CheckBoxHandler));
            ControlsManager.RegisterHandlerType(typeof(ComboBox), typeof(ComboBoxHandler));
            ControlsManager.RegisterHandlerType(typeof(Label), typeof(LabelHandler));
            //ControlsManager.RegisterHandlerType(typeof(MaskedTextBox), typeof(MaskedTextBoxHandler));
            //ControlsManager.RegisterHandlerType(typeof(NumericUpDown), typeof(NumericBoxHandler));
            //ControlsManager.RegisterHandlerType(typeof(ProgressBar), typeof(ProgressBarHandler));
            //ControlsManager.RegisterHandlerType(typeof(RadioButton), typeof(RadioButtonHandler));
            //ControlsManager.RegisterHandlerType(typeof(TabControl), typeof(TabControlHandler));
            ControlsManager.RegisterHandlerType(typeof(TextBox), typeof(TextBoxHandler));
            //ControlsManager.RegisterHandlerType(typeof(TreeView), typeof(TreeViewHandler));
            //ControlsManager.RegisterHandlerType(typeof(ToolStripMenuItem), typeof(MenuItemHandler));
            //ControlsManager.RegisterHandlerType(typeof(ToolStripComboBox), typeof(ToolStripComboBoxHandler));
            ControlsManager.RegisterHandlerType(typeof(PropertyGrid), typeof(PropertyGridHandler));
            //ControlsManager.RegisterHandlerType(typeof(DateTimePicker), typeof(DateTimeBoxHandler));
            //ControlsManager.RegisterHandlerType(typeof(PictureBox), typeof(PictureBoxHandler));
            ControlsManager.RegisterHandlerType(typeof(ZListView), typeof(ZListViewHandler));
        }

        public static void RegisterViews()
        {
            IContainer container = Container;
            container.Reset();

            container.Register<IGraphicsProvider, WPFGfxProvider>(LifeCycle.Singleton);

            container.Register<IAquariumEditorView, AquariumEditDlg>(LifeCycle.Transient);
            container.Register<ICalculatorView, CalculatorDlg>(LifeCycle.Transient);
            container.Register<ISettingsDialogView, SettingsDlg>(LifeCycle.Transient);
            container.Register<ITankEditorView, TankEditDlg>(LifeCycle.Transient);
        }
    }
}
