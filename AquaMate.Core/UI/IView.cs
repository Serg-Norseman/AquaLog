/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaMate.Core;

namespace AquaMate.UI
{
    public interface IView : IDisposable, ILocalizable
    {
    }


    public interface IView<TModel> : IView
        //where TModel : IModel
    {
    }


    public interface IFormView<TModel> : IView<TModel/*, IFormView<TModel>*/>, ILocalizable
        //where TModel : IModel
    {
    }


    public interface IDialogView<TModel> : IFormView<TModel>
    {
        /// <summary>
        /// DialogResult ShowDialog() [WinForms], bool? ShowDialog() [WPF]
        /// </summary>
        /// <returns></returns>
        bool ShowModal();
    }
}
