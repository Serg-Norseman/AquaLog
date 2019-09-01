/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Linq;
using System.Windows.Forms;
using AquaLog.Components;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;

namespace AquaLog.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MaintenanceEditDlg : Form, IEditDialog<Maintenance>
    {
        private ALModel fModel;
        private Maintenance fRecord;

        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public Maintenance Record
        {
            get { return fRecord; }
            set {
                if (fRecord != value) {
                    fRecord = value;
                    UpdateView();
                }
            }
        }


        public MaintenanceEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = ALCore.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = ALCore.LoadResourceImage("btn_cancel.gif");

            SetLocale();
        }

        public void SetLocale()
        {
            Text = Localizer.LS(LSID.Maintenance);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            cmbType.Items.Clear();
            cmbType.Sorted = true;
            for (MaintenanceType type = MaintenanceType.Restart; type <= MaintenanceType.Other; type++) {
                cmbType.Items.Add(new ComboItem<MaintenanceType>(Localizer.LS(ALCore.MaintenanceTypes[(int)type]), type));
            }

            lblAquarium.Text = Localizer.LS(LSID.Aquarium);
            lblDateTime.Text = Localizer.LS(LSID.Date);
            lblType.Text = Localizer.LS(LSID.Type);
            lblValue.Text = Localizer.LS(LSID.Value);
            lblNote.Text = Localizer.LS(LSID.Note);
        }

        private void UpdateView()
        {
            if (fRecord != null) {
                UIHelper.FillAquariumsCombo(cmbAquarium, fModel, fRecord.AquariumId);
                cmbAquarium.Enabled = (fRecord.AquariumId == 0);

                if (!fRecord.DateTime.Equals(ALCore.ZeroDate)) {
                    dtpDateTime.Value = fRecord.DateTime;
                }

                UIHelper.SetSelectedTag(cmbType, fRecord.Type);
                txtValue.Text = ALCore.GetDecimalStr(fRecord.Value);
                txtNote.Text = fRecord.Note;
            }
        }

        private void ApplyChanges()
        {
            var aqm = cmbAquarium.SelectedItem as Aquarium;
            fRecord.AquariumId = (aqm == null) ? 0 : aqm.Id;

            fRecord.DateTime = dtpDateTime.Value;
            fRecord.Type = UIHelper.GetSelectedTag<MaintenanceType>(cmbType);
            fRecord.Value = ALCore.GetDecimalVal(txtValue.Text);
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
