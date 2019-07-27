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
    public partial class TransferDlg : Form
    {
        private Inhabitant fInhabitant;
        private ALModel fModel;
        private Transfer fTransfer;

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

        public Transfer Transfer
        {
            get { return fTransfer; }
            set {
                if (fTransfer != value) {
                    fTransfer = value;
                    UpdateView();
                }
            }
        }


        public TransferDlg()
        {
            InitializeComponent();

            btnAccept.Image = ALCore.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = ALCore.LoadResourceImage("btn_cancel.gif");

            for (TransferType type = TransferType.Relocation; type <= TransferType.Death; type++) {
                cmbType.Items.Add(type.ToString());
            }
        }

        private void UpdateView()
        {
            txtName.Text = fInhabitant.Name;

            if (fTransfer != null) {
                int sourId = 0;
                IList<Transfer> lastTransfers = fModel.QueryLastTransfers(fInhabitant.Id, (int)ALCore.GetItemType(fInhabitant.GetSpeciesType()));
                if (lastTransfers.Count > 0) {
                    sourId = lastTransfers[0].TargetId;
                }
                // if editing exists transfer <= fTransfer.SourceId
                // sourId = fTransfer.SourceId;

                cmbTarget.Items.Clear();
                var aquariums = fModel.QueryAquariums();
                foreach (var aqm in aquariums) {
                    cmbSource.Items.Add(aqm);

                    if (aqm.Id != sourId) {
                        cmbTarget.Items.Add(aqm);
                    }
                }

                cmbSource.SelectedItem = aquariums.FirstOrDefault(aqm => aqm.Id == sourId);
                cmbTarget.SelectedItem = aquariums.FirstOrDefault(aqm => aqm.Id == fTransfer.TargetId);

                if (!fTransfer.Date.Equals(ALCore.ZeroDate)) {
                    dtpDate.Value = fTransfer.Date;
                }

                cmbType.SelectedIndex = (int)fTransfer.Type;
                txtCause.Text = fTransfer.Cause;
            }
        }

        private void ApplyChanges()
        {
            Aquarium aqm = cmbSource.SelectedItem as Aquarium;
            fTransfer.SourceId = (aqm == null) ? 0 : aqm.Id;

            aqm = cmbTarget.SelectedItem as Aquarium;
            fTransfer.TargetId = (aqm == null) ? 0 : aqm.Id;

            fTransfer.ItemId = fInhabitant.Id;
            fTransfer.ItemType = ALCore.GetItemType(fInhabitant.GetSpeciesType());
            fTransfer.Date = dtpDate.Value;
            fTransfer.Type = (TransferType)cmbType.SelectedIndex;
            fTransfer.Cause = txtCause.Text;
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
