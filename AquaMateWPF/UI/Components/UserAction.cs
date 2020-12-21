/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Windows;
using System.Windows.Controls;
using AquaMate.Core;

namespace AquaMate.UI.Components
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class UserAction
    {
        public readonly string Name;
        public readonly LSID BtnText;
        public readonly Image Image;
        public readonly RoutedEventHandler Click;

        public readonly string[] Choices;
        public readonly bool MultiChoice;

        public Control Control;

        public UserAction(string actionName, LSID btnText, string imageName, RoutedEventHandler clickHandler)
        {
            Name = actionName;
            BtnText = btnText;
            //Image = string.IsNullOrEmpty(imageName) ? null : UIHelper.LoadResourceImage(imageName);
            Click = clickHandler;
        }

        public UserAction(string actionName, string[] choices, bool multiChoice, RoutedEventHandler changeHandler)
        {
            Name = actionName;
            Choices = choices;
            MultiChoice = multiChoice;
            Click = changeHandler;
        }
    }
}
