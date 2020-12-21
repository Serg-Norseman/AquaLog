/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Windows;
using AquaMate.Core;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CalculatorDlg : EditDialog, ICalculatorView
    {
        private readonly CalculatorPresenter fPresenter;

        public CalculatorDlg()
        {
            InitializeComponent();

            fPresenter = new CalculatorPresenter(this);
        }

        public override void SetLocale()
        {
            base.Title = Localizer.LS(LSID.Calculator);
            btnCalc.Content = Localizer.LS(LSID.Calculate);
        }

        private void cmbType_SelectedIndexChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (fPresenter != null) {
                fPresenter.ChangeSelectedType();
            }
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            fPresenter.Calculate();
        }

        #region View interface implementation

        IComboBox ICalculatorView.TypeCombo
        {
            get { return GetControlHandler<IComboBox>(cmbType); }
        }

        IPropertyGrid ICalculatorView.ArgsGrid
        {
            get { return GetControlHandler<IPropertyGrid>(pgArgs); }
        }

        ITextBox ICalculatorView.DescriptionField
        {
            get { return GetControlHandler<ITextBox>(txtDescription); }
        }

        #endregion
    }
}
