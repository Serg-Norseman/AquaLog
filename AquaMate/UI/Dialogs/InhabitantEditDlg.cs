/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
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
    public partial class InhabitantEditDlg : EditDialog<Inhabitant>, IInhabitantEditorView
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

            var sexNamesList = ALData.GetNamesList<Sex>(ALData.SexNames);
            cmbSex.FillCombo<Sex>(sexNamesList, false);

            lblName.Text = Localizer.LS(LSID.Name);
            lblNote.Text = Localizer.LS(LSID.Note);
            lblSpecies.Text = Localizer.LS(LSID.SpeciesS);
            lblSex.Text = Localizer.LS(LSID.Sex);
            lblState.Text = Localizer.LS(LSID.State);
        }

        public override void SetContext(IModel model, Inhabitant record)
        {
            base.SetContext(model, record);
            fPresenter.SetContext(model, record);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = fPresenter.ApplyChanges() ? DialogResult.OK : DialogResult.None;
        }

        private void cmbSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            int speciesId = cmbSpecies.GetSelectedTag<int>();
            var species = fModel.GetRecord<Species>(speciesId);
            fPresenter.ChangeSelectedSpecies(species);
        }

        #region View interface implementation

        IComboBoxHandlerEx IInhabitantEditorView.SpeciesCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbSpecies); }
        }

        ITextBoxHandler IInhabitantEditorView.NameField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtName); }
        }

        ITextBoxHandler IInhabitantEditorView.NoteField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtNote); }
        }

        ILabelHandler IInhabitantEditorView.SexLabel
        {
            get { return GetControlHandler<ILabelHandler>(lblSex); }
        }

        IComboBoxHandlerEx IInhabitantEditorView.SexCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbSex); }
        }

        IComboBoxHandlerEx IInhabitantEditorView.StateCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbState); }
        }

        void IInhabitantEditorView.SetImage(ItemType itemType, int itemId)
        {
            imgViewer.SetRecord(fModel, fRecord.Id, itemType);
        }

        #endregion
    }
}
