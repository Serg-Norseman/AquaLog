/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;

namespace AquaLog.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SpeciesEditDlg : Form
    {
        private Species fSpecies;

        public Species Species
        {
            get { return fSpecies; }
            set {
                if (fSpecies != value) {
                    fSpecies = value;
                    UpdateView();
                }
            }
        }

        public SpeciesEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = ALCore.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = ALCore.LoadResourceImage("btn_cancel.gif");

            for (SpeciesType type = SpeciesType.Fish; type <= SpeciesType.Plant; type++) {
                cmbType.Items.Add(type.ToString());
            }
        }

        private void UpdateView()
        {
            txtName.Text = fSpecies.Name;
            txtDesc.Text = fSpecies.Description;
            cmbType.SelectedIndex = (int)fSpecies.Type;
            txtScientificName.Text = fSpecies.ScientificName;

            txtTempMin.Text = ALCore.GetDecimalStr(fSpecies.TempMin);
            txtTempMax.Text = ALCore.GetDecimalStr(fSpecies.TempMax);
            txtPHMin.Text = ALCore.GetDecimalStr(fSpecies.PHMin);
            txtPHMax.Text = ALCore.GetDecimalStr(fSpecies.PHMax);
            txtGHMin.Text = ALCore.GetDecimalStr(fSpecies.GHMin);
            txtGHMax.Text = ALCore.GetDecimalStr(fSpecies.GHMax);
        }

        private void ApplyChanges()
        {
            fSpecies.Name = txtName.Text;
            fSpecies.Description = txtDesc.Text;
            fSpecies.Type = (SpeciesType)cmbType.SelectedIndex;
            fSpecies.ScientificName = txtScientificName.Text;

            fSpecies.TempMin = (float)ALCore.GetDecimalVal(txtTempMin);
            fSpecies.TempMax = (float)ALCore.GetDecimalVal(txtTempMax);
            fSpecies.PHMin = (float)ALCore.GetDecimalVal(txtPHMin);
            fSpecies.PHMax = (float)ALCore.GetDecimalVal(txtPHMax);
            fSpecies.GHMin = (float)ALCore.GetDecimalVal(txtGHMin);
            fSpecies.GHMax = (float)ALCore.GetDecimalVal(txtGHMax);
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

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var type = (SpeciesType)cmbType.SelectedIndex;
            switch (type) {
                case SpeciesType.Fish:
                    break;

                case SpeciesType.Invertebrate:
                    break;

                case SpeciesType.Plant:
                    break;
            }
        }
    }
}
