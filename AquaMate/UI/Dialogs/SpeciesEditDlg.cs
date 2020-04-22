/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.Core.Model;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SpeciesEditDlg : EditDialog<Species>, ISpeciesEditorView
    {
        private readonly SpeciesEditorPresenter fPresenter;

        public SpeciesEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            fPresenter = new SpeciesEditorPresenter(this);
        }

        public override void SetLocale()
        {
            Text = Localizer.LS(LSID.SpeciesS);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            lblName.Text = Localizer.LS(LSID.Name);
            lblDesc.Text = Localizer.LS(LSID.Description);
            lblType.Text = Localizer.LS(LSID.Type);
            lblScientificName.Text = Localizer.LS(LSID.ScientificName);
            lblFamily.Text = Localizer.LS(LSID.BioFamily);

            /*tabFish.Text = Localizer.LS(LSID.Fish);
            tabInvertebrate.Text = Localizer.LS(LSID.Invertebrate);
            tabPlant.Text = Localizer.LS(LSID.Plant);
            tabCoral.Text = Localizer.LS(LSID.Coral);*/

            lblAdultSize.Text = Localizer.LS(LSID.AdultSize);
            lblLifeSpan.Text = Localizer.LS(LSID.LifeSpan);
            lblSwimLevel.Text = Localizer.LS(LSID.SwimLevel);
        }

        public override void SetContext(IModel model, Species record)
        {
            base.SetContext(model, record);
            fPresenter.SetContext(model, record);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = fPresenter.ApplyChanges() ? DialogResult.OK : DialogResult.None;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            fPresenter.ChangeSelectedType();
        }

        #region View interface implementation

        ITextBox ISpeciesEditorView.NameField
        {
            get { return GetControlHandler<ITextBox>(txtName); }
        }

        ITextBox ISpeciesEditorView.DescriptionField
        {
            get { return GetControlHandler<ITextBox>(txtDesc); }
        }

        IComboBox ISpeciesEditorView.TypeCombo
        {
            get { return GetControlHandler<IComboBox>(cmbType); }
        }

        ITextBox ISpeciesEditorView.ScientificNameField
        {
            get { return GetControlHandler<ITextBox>(txtScientificName); }
        }

        IComboBox ISpeciesEditorView.BioFamilyCombo
        {
            get { return GetControlHandler<IComboBox>(cmbFamily); }
        }

        ITextBox ISpeciesEditorView.TempMinField
        {
            get { return GetControlHandler<ITextBox>(txtTempMin); }
        }

        ITextBox ISpeciesEditorView.TempMaxField
        {
            get { return GetControlHandler<ITextBox>(txtTempMax); }
        }

        ITextBox ISpeciesEditorView.PHMinField
        {
            get { return GetControlHandler<ITextBox>(txtPHMin); }
        }

        ITextBox ISpeciesEditorView.PHMaxField
        {
            get { return GetControlHandler<ITextBox>(txtPHMax); }
        }

        ITextBox ISpeciesEditorView.GHMinField
        {
            get { return GetControlHandler<ITextBox>(txtGHMin); }
        }

        ITextBox ISpeciesEditorView.GHMaxField
        {
            get { return GetControlHandler<ITextBox>(txtGHMax); }
        }

        ITextBox ISpeciesEditorView.AdultSizeField
        {
            get { return GetControlHandler<ITextBox>(txtAdultSize); }
        }

        ITextBox ISpeciesEditorView.LifeSpanField
        {
            get { return GetControlHandler<ITextBox>(txtLifeSpan); }
        }

        IComboBox ISpeciesEditorView.SwimLevelCombo
        {
            get { return GetControlHandler<IComboBox>(cmbSwimLevel); }
        }

        #endregion
    }
}
