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
    public partial class HistoryEditDlg : Form
    {
        private ALModel fModel;
        private History fHistory;

        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public History History
        {
            get { return fHistory; }
            set {
                if (fHistory != value) {
                    fHistory = value;
                    UpdateView();
                }
            }
        }


        public HistoryEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = ALCore.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = ALCore.LoadResourceImage("btn_cancel.gif");
        }

        private void UpdateView()
        {
            if (fHistory != null) {
                cmbAquarium.Items.Clear();
                var aquariums = fModel.QueryAquariums();
                foreach (var aqm in aquariums) {
                    if (fHistory.AquariumId != 0 || !aqm.IsInactive()) {
                        cmbAquarium.Items.Add(aqm);
                    }
                }

                cmbAquarium.SelectedItem = aquariums.FirstOrDefault(aqm => aqm.Id == fHistory.AquariumId);
                cmbAquarium.Enabled = (fHistory.AquariumId == 0);

                if (!fHistory.DateTime.Equals(ALCore.ZeroDate)) {
                    dtpDateTime.Value = fHistory.DateTime;
                }

                txtEvent.Text = fHistory.Event;
                txtNote.Text = fHistory.Note;
            }
        }

        private void ApplyChanges()
        {
            var aqm = cmbAquarium.SelectedItem as Aquarium;
            fHistory.AquariumId = (aqm == null) ? 0 : aqm.Id;

            fHistory.DateTime = dtpDateTime.Value;
            fHistory.Event = txtEvent.Text;
            fHistory.Note = txtNote.Text;
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
