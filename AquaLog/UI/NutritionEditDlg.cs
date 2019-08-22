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
using AquaLog.Core.Types;

namespace AquaLog.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class NutritionEditDlg : Form, IEditDialog<Nutrition>
    {
        private ALModel fModel;
        private Nutrition fRecord;


        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public Nutrition Record
        {
            get { return fRecord; }
            set {
                if (fRecord != value) {
                    fRecord = value;
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
            if (fRecord != null) {
                UIHelper.FillAquariumsCombo(cmbAquarium, fModel, fRecord.AquariumId);
                cmbAquarium.Enabled = (fRecord.AquariumId == 0);

                cmbInhabitant.Items.Clear();
                var inhabitants = fModel.QueryInhabitants();
                foreach (Inhabitant inh in inhabitants) {
                    cmbInhabitant.Items.Add(inh);
                }
                cmbInhabitant.SelectedItem = inhabitants.FirstOrDefault(inh => inh.Id == fRecord.InhabitantId);

                cmbBrand.Items.Clear();
                var brands = fModel.QueryNutritionBrands();
                foreach (QString bqs in brands) {
                    cmbBrand.Items.Add(bqs.element);
                }
                cmbBrand.Text = fRecord.Brand;

                txtName.Text = fRecord.Name;
                txtAmount.Text = ALCore.GetDecimalStr(fRecord.Amount);
                txtNote.Text = fRecord.Note;
            }
        }

        private void ApplyChanges()
        {
            var aqm = cmbAquarium.SelectedItem as Aquarium;
            fRecord.AquariumId = (aqm == null) ? 0 : aqm.Id;

            var pt = cmbInhabitant.SelectedItem as Inhabitant;
            fRecord.InhabitantId = (pt == null) ? 0 : pt.Id;

            fRecord.Name = txtName.Text;
            fRecord.Brand = cmbBrand.Text;
            fRecord.Amount = (float)ALCore.GetDecimalVal(txtAmount.Text);
            fRecord.Note = txtNote.Text;
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
