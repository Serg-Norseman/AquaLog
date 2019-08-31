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

namespace AquaLog.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SpeciesEditDlg : Form, IEditDialog<Species>
    {
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

            btnAccept.Image = ALCore.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = ALCore.LoadResourceImage("btn_cancel.gif");

            for (SpeciesType type = SpeciesType.Fish; type <= SpeciesType.Coral; type++) {
                cmbType.Items.Add(type.ToString());
            }

            SetLocale();
        }

        public void SetLocale()
        {
            Text = Localizer.LS(LSID.SpeciesS);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            lblName.Text = Localizer.LS(LSID.Name);
            lblDesc.Text = Localizer.LS(LSID.Description);
            lblType.Text = Localizer.LS(LSID.Type);
        }

        private void UpdateView()
        {
            txtName.Text = fRecord.Name;
            txtDesc.Text = fRecord.Description;
            cmbType.SelectedIndex = (int)fRecord.Type;
            txtScientificName.Text = fRecord.ScientificName;

            txtTempMin.Text = ALCore.GetDecimalStr(fRecord.TempMin);
            txtTempMax.Text = ALCore.GetDecimalStr(fRecord.TempMax);
            txtPHMin.Text = ALCore.GetDecimalStr(fRecord.PHMin);
            txtPHMax.Text = ALCore.GetDecimalStr(fRecord.PHMax);
            txtGHMin.Text = ALCore.GetDecimalStr(fRecord.GHMin);
            txtGHMax.Text = ALCore.GetDecimalStr(fRecord.GHMax);
        }

        private void ApplyChanges()
        {
            fRecord.Name = txtName.Text;
            fRecord.Description = txtDesc.Text;
            fRecord.Type = (SpeciesType)cmbType.SelectedIndex;
            fRecord.ScientificName = txtScientificName.Text;

            fRecord.TempMin = (float)ALCore.GetDecimalVal(txtTempMin.Text);
            fRecord.TempMax = (float)ALCore.GetDecimalVal(txtTempMax.Text);
            fRecord.PHMin = (float)ALCore.GetDecimalVal(txtPHMin.Text);
            fRecord.PHMax = (float)ALCore.GetDecimalVal(txtPHMax.Text);
            fRecord.GHMin = (float)ALCore.GetDecimalVal(txtGHMin.Text);
            fRecord.GHMax = (float)ALCore.GetDecimalVal(txtGHMax.Text);
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

                case SpeciesType.Coral:
                    break;
            }
        }
    }
}
