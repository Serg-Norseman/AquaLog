/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Drawing;
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
    public partial class InhabitantEditDlg : Form
    {
        private Inhabitant fInhabitant;
        private ALModel fModel;

        public Inhabitant Inhabitant
        {
            get { return fInhabitant; }
            set {
                if (fInhabitant != value) {
                    fInhabitant = value;
                    UpdateView();
                }
            }
        }

        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }


        public InhabitantEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = ALCore.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = ALCore.LoadResourceImage("btn_cancel.gif");

            for (Sex sex = Sex.None; sex <= Sex.Hermaphrodite; sex++) {
                cmbSex.Items.Add(sex.ToString());
            }
        }

        private void UpdateView()
        {
            var species = fModel.QuerySpecies((int)fInhabitant.GetSpeciesType());
            foreach (Species spc in species) {
                cmbSpecies.Items.Add(spc);
            }

            txtName.Text = fInhabitant.Name;
            txtNote.Text = fInhabitant.Note;
            cmbSpecies.SelectedItem = species.FirstOrDefault(sp => sp.Id == fInhabitant.SpeciesId);
            txtQty.Text = fInhabitant.Quantity.ToString();

            if (fInhabitant is Animal) {
                cmbSex.SelectedIndex = (int)((Animal)fInhabitant).Sex;
            } else {
                lblSex.Visible = false;
                cmbSex.Visible = false;
            }
        }

        private void ApplyChanges()
        {
            Species spc = cmbSpecies.SelectedItem as Species;

            fInhabitant.Name = txtName.Text;
            fInhabitant.Note = txtNote.Text;
            fInhabitant.SpeciesId = spc.Id;
            fInhabitant.Quantity = int.Parse(txtQty.Text);

            if (fInhabitant is Animal) {
                ((Animal)fInhabitant).Sex = (Sex)cmbSex.SelectedIndex;
            }
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
