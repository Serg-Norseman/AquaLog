/*
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

namespace AquaLog.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WaterChangeEditDlg : Form, IEditDialog<WaterChange>
    {
        private ALModel fModel;
        private WaterChange fRecord;

        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public WaterChange Record
        {
            get { return fRecord; }
            set {
                if (fRecord != value) {
                    fRecord = value;
                    UpdateView();
                }
            }
        }


        public WaterChangeEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = ALCore.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = ALCore.LoadResourceImage("btn_cancel.gif");

            for (WaterChangeType type = WaterChangeType.Added; type <= WaterChangeType.Removed; type++) {
                cmbType.Items.Add(type.ToString());
            }
        }

        private void UpdateView()
        {
            if (fRecord != null) {
                UIHelper.FillAquariumsCombo(cmbAquarium, fModel, fRecord.AquariumId);
                cmbAquarium.Enabled = (fRecord.AquariumId == 0);

                if (!fRecord.ChangeDate.Equals(ALCore.ZeroDate)) {
                    dtpDate.Value = fRecord.ChangeDate;
                }

                cmbType.SelectedIndex = (int)fRecord.Type;
                txtVolume.Text = ALCore.GetDecimalStr(fRecord.Volume);
                txtNote.Text = fRecord.Note;
            }
        }

        private void ApplyChanges()
        {
            var aqm = cmbAquarium.SelectedItem as Aquarium;
            fRecord.AquariumId = (aqm == null) ? 0 : aqm.Id;

            fRecord.ChangeDate = dtpDate.Value;
            fRecord.Type = (WaterChangeType)cmbType.SelectedIndex;
            fRecord.Volume = ALCore.GetDecimalVal(txtVolume.Text);
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
