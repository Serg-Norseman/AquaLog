/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaMate.Core;
using AquaMate.Core.Calculations;
using AquaMate.Logging;
using BSLib;

namespace AquaMate.UI
{
    public interface ICalculatorView : IView
    {
    }


    /// <summary>
    /// 
    /// </summary>
    public class CalculatorPresenter : ViewerPresenter<IModel, ICalculatorView>
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "CalculatorPresenter");


        public CalculatorPresenter(ICalculatorView view) : base(view)
        {
        }

        public override void UpdateView()
        {
        }

        public void ChangeSelectedType(CalculationType type)
        {
            
        }
    }
}
