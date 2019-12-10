/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Drawing;
using AquaLog.Core;
using AquaLog.UI;

namespace AquaLog.UI.Components
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class UserAction
    {
        public readonly string BtnName;
        public readonly LSID BtnText;
        public readonly Image Image;
        public readonly EventHandler Click;
        public string[] Choices;

        public UserAction(string btnName, LSID btnText, string imageName, EventHandler clickHandler)
        {
            BtnName = btnName;
            BtnText = btnText;
            Image = string.IsNullOrEmpty(imageName) ? null : UIHelper.LoadResourceImage(imageName);
            Click = clickHandler;
        }

        public UserAction(string actionName, string[] choices, EventHandler changeHandler)
        {
            BtnName = actionName;
            Choices = choices;
            Click = changeHandler;
        }
    }
}
