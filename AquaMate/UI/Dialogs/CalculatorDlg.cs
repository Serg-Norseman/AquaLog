/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.Core.Calculations;
using AquaMate.Core.Model;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CalculatorDlg : EditDialog<Entity>, ICalculatorView
    {
        private readonly CalculatorPresenter fPresenter;

        public CalculatorDlg()
        {
            InitializeComponent();

            fPresenter = new CalculatorPresenter(this);

            var namesList = BaseCalculation.GetNamesList<CalculationType>();
            cmbType.FillCombo<CalculationType>(namesList, false);
            cmbType.SelectedIndex = 0;
        }

        public override void SetLocale()
        {
            Text = Localizer.LS(LSID.Calculator);
            btnCalc.Text = Localizer.LS(LSID.Calculate);
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var calcType = cmbType.GetSelectedTag<CalculationType>();
            fPresenter.ChangeSelectedType(calcType);
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            fPresenter.Calculate();
        }

        private void CalculatorDlg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        #region View interface implementation

        IPropertyGridHandler ICalculatorView.ArgsGrid
        {
            get { return GetControlHandler<IPropertyGridHandler>(pgArgs); }
        }

        ITextBoxHandler ICalculatorView.DescriptionField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtDescription); }
        }

        #endregion
    }
}
