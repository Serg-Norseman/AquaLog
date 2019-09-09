﻿/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Linq;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;

namespace AquaLog.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class InhabitantEditDlg : Form, IEditDialog<Inhabitant>
    {
        private ALModel fModel;
        private Inhabitant fRecord;


        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public Inhabitant Record
        {
            get { return fRecord; }
            set {
                if (fRecord != value) {
                    fRecord = value;
                    UpdateView();
                }
            }
        }


        public InhabitantEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            SetLocale();
        }

        public void SetLocale()
        {
            Text = Localizer.LS(LSID.Inhabitant);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            cmbSex.FillCombo<Sex>(ALData.SexNames, false);

            lblName.Text = Localizer.LS(LSID.Name);
            lblNote.Text = Localizer.LS(LSID.Note);
            lblSpecies.Text = Localizer.LS(LSID.SpeciesS);
            lblSex.Text = Localizer.LS(LSID.Sex);
            lblState.Text = Localizer.LS(LSID.State);
        }

        private void UpdateView()
        {
            var speciesList = fModel.QuerySpecies();
            foreach (Species spc in speciesList) {
                cmbSpecies.Items.Add(spc);
            }
            var species = speciesList.FirstOrDefault(sp => sp.Id == fRecord.SpeciesId);

            txtName.Text = fRecord.Name;
            txtNote.Text = fRecord.Note;
            cmbSpecies.SelectedItem = species;
            cmbSex.SetSelectedTag(fRecord.Sex);

            if (species != null) {
                UIHelper.FillItemStatesCombo(cmbState, ALCore.GetItemType(species.Type), fRecord.State);
            } else {
                cmbState.Items.Clear();
            }
        }

        private void ApplyChanges()
        {
            Species spc = cmbSpecies.SelectedItem as Species;

            fRecord.Name = txtName.Text;
            fRecord.Note = txtNote.Text;
            fRecord.SpeciesId = spc.Id;
            fRecord.Sex = cmbSex.GetSelectedTag<Sex>();
            fRecord.State = cmbState.GetSelectedTag<ItemState>();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try {
                ApplyChanges();
                DialogResult = DialogResult.OK;
            } catch {
                DialogResult = DialogResult.None;
            }
        }

        private void cmbSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            var species = cmbSpecies.SelectedItem as Species;
            bool hasSex = (species != null && ALCore.IsAnimal(species.Type));

            UIHelper.FillItemStatesCombo(cmbState, ALCore.GetItemType(species.Type), fRecord.State);

            lblSex.Visible = hasSex;
            cmbSex.Visible = hasSex;
        }
    }
}