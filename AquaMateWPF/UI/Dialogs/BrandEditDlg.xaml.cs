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
    public partial class BrandEditDlg : EditDialog, IBrandEditorView
    {
        private readonly BrandEditorPresenter fPresenter;

        public BrandEditDlg()
        {
            InitializeComponent();

            fPresenter = new BrandEditorPresenter(this);
        }

        public override void SetLocale()
        {
            base.Title = Localizer.LS(LSID.Brand);
            btnAccept.Content = Localizer.LS(LSID.Accept);
            btnCancel.Content = Localizer.LS(LSID.Cancel);

            lblName.Content = Localizer.LS(LSID.Name);
            lblCountry.Content = Localizer.LS(LSID.Country);
            lblWebSite.Content = Localizer.LS(LSID.WebSite);
            lblEmail.Content = Localizer.LS(LSID.Email);
            lblNote.Content = Localizer.LS(LSID.Note);
        }

        public void SetContext(IModel model, Brand record)
        {
            fPresenter.SetContext(model, record);
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = fPresenter.ApplyChanges();
        }

        #region View interface implementation

        ITextBox IBrandEditorView.NameField
        {
            get { return GetControlHandler<ITextBox>(txtName); }
        }

        IComboBox IBrandEditorView.CountryCombo
        {
            get { return GetControlHandler<IComboBox>(cmbCountry); }
        }

        ITextBox IBrandEditorView.WebSiteField
        {
            get { return GetControlHandler<ITextBox>(txtWebSite); }
        }

        ITextBox IBrandEditorView.EmailField
        {
            get { return GetControlHandler<ITextBox>(txtEmail); }
        }

        ITextBox IBrandEditorView.NoteField
        {
            get { return GetControlHandler<ITextBox>(txtNote); }
        }

        #endregion
    }
}
