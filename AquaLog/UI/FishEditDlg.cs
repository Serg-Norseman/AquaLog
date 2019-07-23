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
    public partial class FishEditDlg : Form
    {
        private Fish fFish;
        private ALModel fModel;

        public Fish Fish
        {
            get { return fFish; }
            set {
                if (fFish != value) {
                    fFish = value;
                    UpdateView();
                }
            }
        }

        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }


        public FishEditDlg()
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
            var species = fModel.QuerySpecies();
            foreach (Species spc in species) {
                cmbSpecies.Items.Add(spc);
            }

            txtName.Text = fFish.Name;
            txtNote.Text = fFish.Note;
            cmbSex.SelectedIndex = (int)fFish.Sex;
            cmbSpecies.SelectedItem = species.FirstOrDefault(sp => sp.Id == fFish.SpeciesId);
            txtQty.Text = fFish.Quantity.ToString();
        }

        private void ApplyChanges()
        {
            Species spc = cmbSpecies.SelectedItem as Species;

            fFish.Name = txtName.Text;
            fFish.Note = txtNote.Text;
            fFish.Sex = (Sex)cmbSex.SelectedIndex;
            fFish.SpeciesId = spc.Id;
            fFish.Quantity = int.Parse(txtQty.Text);
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
