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
    public partial class CalculatorDlg : Form, ILocalizable
    {
        private BaseCalculation fCalculation;

        public CalculatorDlg()
        {
            InitializeComponent();

            for (CalculationType ct = CalculationType.First; ct <= CalculationType.Last; ct++) {
                var calcProps = BaseCalculation.CalculationData[(int)ct];
                cmbType.AddItem<CalculationType>(calcProps.Name, ct);
            }
            cmbType.SelectedIndex = 0;

            SetLocale();
        }

        public void SetLocale()
        {
            Text = Localizer.LS(LSID.Calculator);
            btnCalc.Text = Localizer.LS(LSID.Calculate);
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var calcType = cmbType.GetSelectedTag<CalculationType>();

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
