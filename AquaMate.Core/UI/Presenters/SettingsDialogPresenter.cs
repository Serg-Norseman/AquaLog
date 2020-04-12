/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaMate.Core;
using AquaMate.Logging;
using BSLib;

namespace AquaMate.UI
{
    public interface ISettingsDialogView : IView
    {
    }


    /// <summary>
    /// 
    /// </summary>
    public class SettingsDialogPresenter : Presenter<ISettingsDialogView>
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "SettingsDialogPresenter");


        public SettingsDialogPresenter(ISettingsDialogView view) : base(view)
        {
        }

        public override void UpdateView()
        {
        }
    }
}
