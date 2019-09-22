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

namespace AquaLog.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class HistoryEditDlg : Form, IEditDialog<History>
    {
        private ALModel fModel;
        private History fRecord;

        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public History Record
        {
            get { return fRecord; }
            set {
                if (fRecord != value) {
                    fRecord = value;
                    UpdateView();
                }
            }
        }


        public HistoryEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            SetLocale();
        }

        public void SetLocale()
        {
            Text = Localizer.LS(LSID.Event);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            lblAquarium.Text = Localizer.LS(LSID.Aquarium);
            lblDate.Text = Localizer.LS(LSID.Date);
            lblEvent.Text = Localizer.LS(LSID.Event);
            lblNote.Text = Localizer.LS(LSID.Note);
        }

        private void UpdateView()
        {
            if (fRecord != null) {
                cmbAquarium.Items.Clear();
                var aquariums = fModel.QueryAquariums();
                foreach (var aqm in aquariums) {
                    if (fRecord.AquariumId != 0 || !aqm.IsInactive()) {
                        cmbAquarium.Items.Add(aqm);
                    }
                }

                cmbAquarium.SelectedItem = aquariums.FirstOrDefault(aqm => aqm.Id == fRecord.AquariumId);
                cmbAquarium.Enabled = (fRecord.AquariumId == 0);

                if (!fRecord.Timestamp.Equals(ALCore.ZeroDate)) {
                    dtpDateTime.Value = fRecord.Timestamp;
                }

                txtEvent.Text = fRecord.Event;
                txtNote.Text = fRecord.Note;
            }
        }

        private void ApplyChanges()
        {
            var aqm = cmbAquarium.SelectedItem as Aquarium;
            fRecord.AquariumId = (aqm == null) ? 0 : aqm.Id;

            fRecord.Timestamp = dtpDateTime.Value;
            fRecord.Event = txtEvent.Text;
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
