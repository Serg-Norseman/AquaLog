﻿/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Core.Types;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class InhabitantEditDlg : EditDialog, IInhabitantEditorView
    {
        private readonly InhabitantEditorPresenter fPresenter;

        public InhabitantEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            fPresenter = new InhabitantEditorPresenter(this);
        }

        public override void SetLocale()
        {
            Text = Localizer.LS(LSID.Inhabitant);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            lblName.Text = Localizer.LS(LSID.Name);
            lblNote.Text = Localizer.LS(LSID.Note);
            lblSpecies.Text = Localizer.LS(LSID.SpeciesS);
            lblSex.Text = Localizer.LS(LSID.Sex);
            lblState.Text = Localizer.LS(LSID.State);
        }

        public void SetContext(IModel model, Inhabitant record)
        {
            fPresenter.SetContext(model, record);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = fPresenter.ApplyChanges() ? DialogResult.OK : DialogResult.None;
        }

        private void cmbSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            fPresenter.ChangeSelectedSpecies();
        }

        #region View interface implementation

        IComboBox IInhabitantEditorView.SpeciesCombo
        {
            get { return GetControlHandler<IComboBox>(cmbSpecies); }
        }

        ITextBox IInhabitantEditorView.NameField
        {
            get { return GetControlHandler<ITextBox>(txtName); }
        }

        ITextBox IInhabitantEditorView.NoteField
        {
            get { return GetControlHandler<ITextBox>(txtNote); }
        }

        ILabel IInhabitantEditorView.SexLabel
        {
            get { return GetControlHandler<ILabel>(lblSex); }
        }

        IComboBox IInhabitantEditorView.SexCombo
        {
            get { return GetControlHandler<IComboBox>(cmbSex); }
        }

        IComboBox IInhabitantEditorView.StateCombo
        {
            get { return GetControlHandler<IComboBox>(cmbState); }
        }

        void IInhabitantEditorView.SetImage(ItemType itemType, int itemId)
        {
            imgViewer.SetRecord(fPresenter.Model, fPresenter.Record.Id, itemType);
        }

        #endregion
    }
}
