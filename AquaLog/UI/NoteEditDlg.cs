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
    public partial class NoteEditDlg : Form
    {
        private ALModel fModel;
        private Note fNote;

        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public Note Note
        {
            get { return fNote; }
            set {
                if (fNote != value) {
                    fNote = value;
                    UpdateView();
                }
            }
        }


        public NoteEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = ALCore.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = ALCore.LoadResourceImage("btn_cancel.gif");
        }

        private void UpdateView()
        {
            if (fNote != null) {
                cmbAquarium.Items.Clear();
                var aquariums = fModel.QueryAquariums();
                foreach (var aqm in aquariums) {
                    if (fNote.AquariumId != 0 || !aqm.IsInactive()) {
                        cmbAquarium.Items.Add(aqm);
                    }
                }

                cmbAquarium.SelectedItem = aquariums.FirstOrDefault(aqm => aqm.Id == fNote.AquariumId);
                cmbAquarium.Enabled = (fNote.AquariumId == 0);

                if (!fNote.PublishDate.Equals(ALCore.ZeroDate)) {
                    dtpDateTime.Value = fNote.PublishDate;
                }

                txtNote.Text = fNote.Content;
            }
        }

        private void ApplyChanges()
        {
            var aqm = cmbAquarium.SelectedItem as Aquarium;
            fNote.AquariumId = (aqm == null) ? 0 : aqm.Id;

            fNote.PublishDate = dtpDateTime.Value;
            fNote.Content = txtNote.Text;
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
