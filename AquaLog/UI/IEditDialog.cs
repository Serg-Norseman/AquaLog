/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;

namespace AquaLog.UI
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEditDialog<T> : IDisposable, ILocalizable where T : Entity
    {
        ALModel Model { get; set; }

        T Record { get; set; }

        DialogResult ShowDialog();
    }
}
