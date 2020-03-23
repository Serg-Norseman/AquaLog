/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.Core.Model;

namespace AquaMate.UI
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
