/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;
using AquaLog.Logging;
using BSLib;

namespace AquaLog.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SpeciesEditDlg : Form, IEditDialog<Species>
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "SpeciesEditDlg");

        private ALModel fModel;
        private Species fRecord;


        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public Species Record
        {
            get { return fRecord; }
            set {
                if (fRecord != value) {
                    fRecord = value;
                    UpdateView();
                }
            }
        }

        public SpeciesEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            SetLocale();
        }

        public void SetLocale()
        {
            Text = Localizer.LS(LSID.SpeciesS);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            cmbType.FillCombo<SpeciesType>(ALData.SpeciesTypes, true);
            cmbSwimLevel.FillCombo<SwimLevel>(ALData.SwimLevels, false);

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

        private void UpdateView()
        {
            txtName.Text = fRecord.Name;
            txtDesc.Text = fRecord.Description;
            cmbType.SetSelectedTag(fRecord.Type);
            txtScientificName.Text = fRecord.ScientificName;

            txtTempMin.Text = ALCore.GetDecimalStr(fRecord.TempMin);
            txtTempMax.Text = ALCore.GetDecimalStr(fRecord.TempMax);
            txtPHMin.Text = ALCore.GetDecimalStr(fRecord.PHMin);
            txtPHMax.Text = ALCore.GetDecimalStr(fRecord.PHMax);
            txtGHMin.Text = ALCore.GetDecimalStr(fRecord.GHMin);
            txtGHMax.Text = ALCore.GetDecimalStr(fRecord.GHMax);

            if (fRecord.Type == SpeciesType.Fish) {
                txtAdultSize.Text = ALCore.GetDecimalStr(fRecord.AdultSize);
                txtLifeSpan.Text = ALCore.GetDecimalStr(fRecord.LifeSpan);
                cmbSwimLevel.SetSelectedTag(fRecord.SwimLevel);
            }

            UIHelper.FillStringsCombo(cmbFamily, fModel.QuerySpeciesFamilies(), fRecord.BioFamily);
        }

        private void ApplyChanges()
        {
            fRecord.Name = txtName.Text;
            fRecord.Description = txtDesc.Text;
            fRecord.Type = cmbType.GetSelectedTag<SpeciesType>();
            fRecord.ScientificName = txtScientificName.Text;

            fRecord.TempMin = (float)ALCore.GetDecimalVal(txtTempMin.Text);
            fRecord.TempMax = (float)ALCore.GetDecimalVal(txtTempMax.Text);
            fRecord.PHMin = (float)ALCore.GetDecimalVal(txtPHMin.Text);
            fRecord.PHMax = (float)ALCore.GetDecimalVal(txtPHMax.Text);
            fRecord.GHMin = (float)ALCore.GetDecimalVal(txtGHMin.Text);
            fRecord.GHMax = (float)ALCore.GetDecimalVal(txtGHMax.Text);

            if (ALCore.IsAnimal(fRecord.Type)) {
                fRecord.AdultSize = (float)ALCore.GetDecimalVal(txtAdultSize.Text);
                fRecord.LifeSpan = (float)ALCore.GetDecimalVal(txtLifeSpan.Text);
                fRecord.SwimLevel = cmbSwimLevel.GetSelectedTag<SwimLevel>();
            }

            fRecord.BioFamily = cmbFamily.Text;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try {
                ApplyChanges();
                DialogResult = DialogResult.OK;
            } catch (Exception ex) {
                fLogger.WriteError("ApplyChanges()", ex);
                DialogResult = DialogResult.None;
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var type = cmbType.GetSelectedTag<SpeciesType>();

            bool isFish = (type == SpeciesType.Fish);
            bool isInvertebrate = (type == SpeciesType.Invertebrate);

            txtAdultSize.Enabled = isFish || isInvertebrate;
            txtLifeSpan.Enabled = isFish || isInvertebrate;
            cmbSwimLevel.Enabled = isFish || isInvertebrate;

            switch (type) {
                case SpeciesType.Fish:
                    break;

                case SpeciesType.Invertebrate:
                    break;

                case SpeciesType.Plant:
                    break;

                case SpeciesType.Coral:
                    break;
            }
        }
    }
}
