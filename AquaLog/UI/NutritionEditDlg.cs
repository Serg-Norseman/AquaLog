/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;

namespace AquaLog.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class NutritionEditDlg : Form
    {
        private ALModel fModel;
        private Nutrition fNutrition;

        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public Nutrition Nutrition
        {
            get { return fNutrition; }
            set {
                if (fNutrition != value) {
                    fNutrition = value;
                    UpdateView();
                }
            }
        }


        public NutritionEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = ALCore.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = ALCore.LoadResourceImage("btn_cancel.gif");
        }

        private void UpdateView()
        {
            if (fNutrition != null) {
                cmbAquarium.Items.Clear();
                var aquariums = fModel.QueryAquariums();
                foreach (var aqm in aquariums) {
                    cmbAquarium.Items.Add(aqm);
                }
                cmbAquarium.SelectedItem = aquariums.FirstOrDefault(aqm => aqm.Id == fNutrition.AquariumId);

                cmbInhabitant.Items.Clear();
                var inhabitants = fModel.QueryInhabitants();
                foreach (Inhabitant inh in inhabitants) {
                    cmbInhabitant.Items.Add(inh);
                }
                cmbInhabitant.SelectedItem = inhabitants.FirstOrDefault(inh => inh.Id == fNutrition.InhabitantId);

                cmbBrand.Items.Clear();
                var brands = fModel.QueryNutritionBrands();
                foreach (ALModel.QString bqs in brands) {
                    cmbBrand.Items.Add(bqs.element);
                }
                cmbBrand.Text = fNutrition.Brand;

                txtName.Text = fNutrition.Name;
                txtAmount.Text = ALCore.GetDecimalStr(fNutrition.Amount);
                txtNote.Text = fNutrition.Note;
            }
        }

        private void ApplyChanges()
        {
            var aqm = cmbAquarium.SelectedItem as Aquarium;
            fNutrition.AquariumId = (aqm == null) ? 0 : aqm.Id;

            var pt = cmbInhabitant.SelectedItem as Inhabitant;
            fNutrition.InhabitantId = (pt == null) ? 0 : pt.Id;

            fNutrition.Name = txtName.Text;
            fNutrition.Brand = cmbBrand.Text;
            fNutrition.Amount = (float)ALCore.GetDecimalVal(txtAmount.Text);
            fNutrition.Note = txtNote.Text;
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
    }
}
