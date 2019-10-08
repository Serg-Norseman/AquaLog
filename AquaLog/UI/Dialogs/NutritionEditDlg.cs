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
using AquaLog.Logging;
using BSLib;

namespace AquaLog.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class NutritionEditDlg : Form, IEditDialog<Nutrition>
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "NutritionEditDlg");

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

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            SetLocale();
        }

        public void SetLocale()
        {
            Text = Localizer.LS(LSID.Nutrition);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            lblAquarium.Text = Localizer.LS(LSID.Aquarium);
            lblName.Text = Localizer.LS(LSID.Name);
            lblBrand.Text = Localizer.LS(LSID.Brand);
            lblAmount.Text = Localizer.LS(LSID.Amount);
            lblNote.Text = Localizer.LS(LSID.Note);
            lblInhabitant.Text = Localizer.LS(LSID.Inhabitant);
            lblState.Text = Localizer.LS(LSID.State);
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

                UIHelper.FillItemStatesCombo(cmbState, ItemType.Nutrition, fRecord.State);
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
            fRecord.State = cmbState.GetSelectedTag<ItemState>();
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
    }
}
