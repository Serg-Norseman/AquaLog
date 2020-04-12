/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaMate.Core;

namespace AquaMate.UI
{
    public interface IView : ILocalizable
    {
    }


    public interface IView<TModel> : IView
        where TModel : IModel
    {
    }


    public interface IDialogView : IView
    {
        /// <summary>
        /// DialogResult ShowDialog() [WinForms], bool? ShowDialog() [WPF]
        /// </summary>
        /// <returns></returns>
        bool ShowModal();
    }
}
