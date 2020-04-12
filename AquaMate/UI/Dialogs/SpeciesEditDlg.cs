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

            var speciesTypesList = ALData.GetNamesList<SpeciesType>(ALData.SpeciesTypes);
            cmbType.FillCombo<SpeciesType>(speciesTypesList, true);

            var swimLevelsList = ALData.GetNamesList<SwimLevel>(ALData.SwimLevels);
            cmbSwimLevel.FillCombo<SwimLevel>(swimLevelsList, false);

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
            var type = cmbType.GetSelectedTag<SpeciesType>();
            fPresenter.ChangeSelectedType(type);
        }

        #region View interface implementation

        ITextBoxHandler ISpeciesEditorView.NameField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtName); }
        }

        ITextBoxHandler ISpeciesEditorView.DescriptionField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtDesc); }
        }

        IComboBoxHandlerEx ISpeciesEditorView.TypeCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbType); }
        }

        ITextBoxHandler ISpeciesEditorView.ScientificNameField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtScientificName); }
        }

        IComboBoxHandlerEx ISpeciesEditorView.BioFamilyCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbFamily); }
        }

        ITextBoxHandler ISpeciesEditorView.TempMinField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtTempMin); }
        }

        ITextBoxHandler ISpeciesEditorView.TempMaxField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtTempMax); }
        }

        ITextBoxHandler ISpeciesEditorView.PHMinField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtPHMin); }
        }

        ITextBoxHandler ISpeciesEditorView.PHMaxField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtPHMax); }
        }

        ITextBoxHandler ISpeciesEditorView.GHMinField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtGHMin); }
        }

        ITextBoxHandler ISpeciesEditorView.GHMaxField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtGHMax); }
        }

        ITextBoxHandler ISpeciesEditorView.AdultSizeField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtAdultSize); }
        }

        ITextBoxHandler ISpeciesEditorView.LifeSpanField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtLifeSpan); }
        }

        IComboBoxHandler ISpeciesEditorView.SwimLevelCombo
        {
            get { return GetControlHandler<IComboBoxHandler>(cmbSwimLevel); }
        }

        #endregion
    }
}
