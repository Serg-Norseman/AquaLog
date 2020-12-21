/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Windows;
using AquaMate.Core;
using AquaMate.Core.Model;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class NutritionEditDlg : EditDialog, INutritionEditorView
    {
        private readonly NutritionEditorPresenter fPresenter;

        public NutritionEditDlg()
        {
            InitializeComponent();

            fPresenter = new NutritionEditorPresenter(this);
        }

        public override void SetLocale()
        {
            base.Title = Localizer.LS(LSID.Nutrition);
            btnAccept.Content = Localizer.LS(LSID.Accept);
            btnCancel.Content = Localizer.LS(LSID.Cancel);

            lblName.Content = Localizer.LS(LSID.Name);
            lblBrand.Content = Localizer.LS(LSID.Brand);
            lblAmount.Content = Localizer.LS(LSID.Amount);
            lblNote.Content = Localizer.LS(LSID.Note);
            lblState.Content = Localizer.LS(LSID.State);
        }

        public void SetContext(IModel model, Nutrition record)
        {
            fPresenter.SetContext(model, record);
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = fPresenter.ApplyChanges();
        }

        #region View interface implementation

        ITextBox INutritionEditorView.NameField
        {
            get { return GetControlHandler<ITextBox>(txtName); }
        }

        IComboBox INutritionEditorView.BrandCombo
        {
            get { return GetControlHandler<IComboBox>(cmbBrand); }
        }

        ITextBox INutritionEditorView.AmountField
        {
            get { return GetControlHandler<ITextBox>(txtAmount); }
        }

        ITextBox INutritionEditorView.NoteField
        {
            get { return GetControlHandler<ITextBox>(txtNote); }
        }

        IComboBox INutritionEditorView.StateCombo
        {
            get { return GetControlHandler<IComboBox>(cmbState); }
        }

        #endregion
    }
}
