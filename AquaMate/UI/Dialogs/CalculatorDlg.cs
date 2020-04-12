/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.Core.Calculations;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CalculatorDlg : Form, ICalculatorView, ILocalizable
    {
        private BaseCalculation fCalculation;

        private readonly CalculatorPresenter fPresenter;

        public CalculatorDlg()
        {
            InitializeComponent();

            var namesList = BaseCalculation.GetNamesList<CalculationType>();
            cmbType.FillCombo<CalculationType>(namesList, false);
            cmbType.SelectedIndex = 0;

            fPresenter = new CalculatorPresenter(this);
        }

        public void SetLocale()
        {
            Text = Localizer.LS(LSID.Calculator);
            btnCalc.Text = Localizer.LS(LSID.Calculate);
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var calcType = cmbType.GetSelectedTag<CalculationType>();
            fPresenter.ChangeSelectedType(calcType);

            if (calcType >= CalculationType.Units_cm2inch && calcType <= CalculationType.Units_ConvGHppm2GHdeg) {
                fCalculation = new UnitsCalculation(calcType);
            } else {
                switch (calcType) {
                    case CalculationType.NitriteSaltCalculator:
                        fCalculation = new SaltCalculation(calcType);
                        break;
                }
            }

            pgArgs.SelectedObject = fCalculation;
            txtDescription.Text = fCalculation.Description;
            pgArgs.Refresh();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            fCalculation.Calculate();
            pgArgs.Refresh();
        }

        private void CalculatorDlg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
