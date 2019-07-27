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
    public partial class WaterChangeEditDlg : Form
    {
        private ALModel fModel;
        private WaterChange fWaterChange;

        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public WaterChange WaterChange
        {
            get { return fWaterChange; }
            set {
                if (fWaterChange != value) {
                    fWaterChange = value;
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
            if (fWaterChange != null) {
                cmbAquarium.Items.Clear();
                var aquariums = fModel.QueryAquariums();
                foreach (var aqm in aquariums) {
                    cmbAquarium.Items.Add(aqm);
                }

                cmbAquarium.SelectedItem = aquariums.FirstOrDefault(aqm => aqm.Id == fWaterChange.AquariumId);

                if (!fWaterChange.ChangeDate.Equals(ALCore.ZeroDate)) {
                    dtpDate.Value = fWaterChange.ChangeDate;
                }

                cmbType.SelectedIndex = (int)fWaterChange.Type;
                txtVolume.Text = ALCore.GetDecimalStr(fWaterChange.Volume);
                txtNote.Text = fWaterChange.Note;
            }
        }

        private void ApplyChanges()
        {
            var aqm = cmbAquarium.SelectedItem as Aquarium;
            fWaterChange.AquariumId = (aqm == null) ? 0 : aqm.Id;

            fWaterChange.ChangeDate = dtpDate.Value;
            fWaterChange.Type = (WaterChangeType)cmbType.SelectedIndex;
            fWaterChange.Volume = ALCore.GetDecimalVal(txtVolume);
            fWaterChange.Note = txtNote.Text;
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
