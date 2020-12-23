/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaMate.Core;
using AquaMate.Core.Model;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ShopEditDlg : EditDialog, IShopEditorView
    {
        private readonly ShopEditorPresenter fPresenter;

        public ShopEditDlg()
        {
            InitializeComponent();

            //btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            //btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            fPresenter = new ShopEditorPresenter(this);
        }

        public override void SetLocale()
        {
            this.Title = Localizer.LS(LSID.Shop);
            btnAccept.Content = Localizer.LS(LSID.Accept);
            btnCancel.Content = Localizer.LS(LSID.Cancel);

            lblName.Content = Localizer.LS(LSID.Name);
            lblAddress.Content = Localizer.LS(LSID.Address);
            lblTelephone.Content = Localizer.LS(LSID.Telephone);
            lblWebSite.Content = Localizer.LS(LSID.WebSite);
            lblEmail.Content = Localizer.LS(LSID.Email);
            lblNote.Content = Localizer.LS(LSID.Note);
        }

        public void SetContext(IModel model, Shop record)
        {
            fPresenter.SetContext(model, record);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = fPresenter.ApplyChanges();
        }

        #region View interface implementation

        ITextBox IShopEditorView.NameField
        {
            get { return GetControlHandler<ITextBox>(txtName); }
        }

        ITextBox IShopEditorView.AddressField
        {
            get { return GetControlHandler<ITextBox>(txtAddress); }
        }

        ITextBox IShopEditorView.TelephoneField
        {
            get { return GetControlHandler<ITextBox>(txtTelephone); }
        }

        ITextBox IShopEditorView.WebSiteField
        {
            get { return GetControlHandler<ITextBox>(txtWebSite); }
        }

        ITextBox IShopEditorView.EmailField
        {
            get { return GetControlHandler<ITextBox>(txtEmail); }
        }

        ITextBox IShopEditorView.NoteField
        {
            get { return GetControlHandler<ITextBox>(txtNote); }
        }

        #endregion
    }
}
