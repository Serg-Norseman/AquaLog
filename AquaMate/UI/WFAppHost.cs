/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.UI.Dialogs;
using BSLib.Design.IoC;
using BSLib.Design.MVP;

namespace AquaMate.UI
{
    /// <summary>
    /// 
    /// </summary>
    public class WFAppHost : AppHost
    {
        public WFAppHost() : base()
        {
        }

        protected override void AppInit()
        {
            #if NETCOREAPP30
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            #endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            RegisterControlHandlers();
            RegisterViews();
        }

        protected override void AppRun(AquaMate.UI.IView view)
        {
            var mainForm = view as Form;
            Application.Run(mainForm);
        }

        public static void RegisterControlHandlers()
        {
            ControlsManager.RegisterHandlerType(typeof(Button), typeof(ButtonHandler));
            ControlsManager.RegisterHandlerType(typeof(CheckBox), typeof(CheckBoxHandler));
            ControlsManager.RegisterHandlerType(typeof(ComboBox), typeof(ComboBoxHandler));
            ControlsManager.RegisterHandlerType(typeof(Label), typeof(LabelHandler));
            ControlsManager.RegisterHandlerType(typeof(MaskedTextBox), typeof(MaskedTextBoxHandler));
            ControlsManager.RegisterHandlerType(typeof(NumericUpDown), typeof(NumericBoxHandler));
            ControlsManager.RegisterHandlerType(typeof(ProgressBar), typeof(ProgressBarHandler));
            ControlsManager.RegisterHandlerType(typeof(RadioButton), typeof(RadioButtonHandler));
            ControlsManager.RegisterHandlerType(typeof(TabControl), typeof(TabControlHandler));
            ControlsManager.RegisterHandlerType(typeof(TextBox), typeof(TextBoxHandler));
            //ControlsManager.RegisterHandlerType(typeof(TreeView), typeof(TreeViewHandler));
            //ControlsManager.RegisterHandlerType(typeof(ToolStripMenuItem), typeof(MenuItemHandler));
            ControlsManager.RegisterHandlerType(typeof(ToolStripComboBox), typeof(ToolStripComboBoxHandler));
            ControlsManager.RegisterHandlerType(typeof(PropertyGrid), typeof(PropertyGridHandler));
            ControlsManager.RegisterHandlerType(typeof(DateTimePicker), typeof(DateTimeBoxHandler));
            ControlsManager.RegisterHandlerType(typeof(PictureBox), typeof(PictureBoxHandler));
        }

        public static void RegisterViews()
        {
            IContainer container = Container;
            container.Reset();

            container.Register<IAquariumEditorView, AquariumEditDlg>(LifeCycle.Transient);
            container.Register<ICalculatorView, CalculatorDlg>(LifeCycle.Transient);
            container.Register<ISettingsDialogView, SettingsDlg>(LifeCycle.Transient);
            container.Register<ITankEditorView, TankEditDlg>(LifeCycle.Transient);
        }
    }
}
