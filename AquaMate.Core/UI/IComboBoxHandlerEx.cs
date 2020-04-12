/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Collections.Generic;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI
{
    /// <summary>
    /// 
    /// </summary>
    public interface IComboBoxHandlerEx : IComboBoxHandler
    {
        void AddRange<T>(IEnumerable<ListItem<T>> items, bool sorted = false);
    }
}
