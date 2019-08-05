/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Drawing;
using AquaLog.Core;

namespace AquaLog.Components
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class UserAction
    {
        public readonly string Name;
        public readonly Image Image;
        public readonly EventHandler Click;

        public UserAction(string name, string imageName, EventHandler clickHandler)
        {
            Name = name;
            Image = string.IsNullOrEmpty(imageName) ? null : ALCore.LoadResourceImage(imageName);
            Click = clickHandler;
        }
    }
}
