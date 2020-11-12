﻿/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using AquaMate.Core;
using AquaMate.Core.Calculations;
using AquaMate.Logging;
using BSLib;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI
{
    public interface ICalculatorView : IDialogView<IModel>
    {
        IComboBox TypeCombo { get; }
        IPropertyGrid ArgsGrid { get; }
        ITextBox DescriptionField { get; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class CalculatorPresenter : ViewerPresenter<IModel, ICalculatorView>
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "CalculatorPresenter");

        private BaseCalculation fCalculation;

        public CalculatorPresenter(ICalculatorView view) : base(view)
        {
            var namesList = BaseCalculation.GetNamesList<CalculationType>();
            fView.TypeCombo.AddRange(namesList, false);
            fView.TypeCombo.SetSelectedTag<CalculationType>(CalculationType.Units_cm2inch);
        }

        public override void UpdateView()
        {
        }

        public void ChangeSelectedType()
        {
            CalculationType calcType = fView.TypeCombo.GetSelectedTag<CalculationType>();

            if (calcType >= CalculationType.Units_cm2inch && calcType <= CalculationType.Units_ConvGHppm2GHdeg) {
                fCalculation = new UnitsCalculation(calcType);
            } else {
                switch (calcType) {
                    case CalculationType.NitriteSaltCalculator:
                        fCalculation = new SaltCalculation(calcType);
                        break;
                }
            }

            fView.ArgsGrid.SelectedObject = fCalculation;
            fView.DescriptionField.Text = fCalculation.Description;
            fView.ArgsGrid.Refresh();
        }

        public void Calculate()
        {
            fCalculation.Calculate();
            fView.ArgsGrid.Refresh();
        }
    }
}
