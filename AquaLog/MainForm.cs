/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using AquaLog.Controls;
using AquaLog.Core;

namespace AquaLog
{
    public partial class MainForm : Form
    {
        private ALModel fModel;
        private TanksPanel fTanksPanel;


        public MainForm()
        {
            InitializeComponent();

            ClientSize = new Size(896, 504);

            fModel = new ALModel();

            SetSettings();
            UpdateControls();

            SetTanksPanel();
        }

        private void SetTanksPanel()
        {
            if (fTanksPanel == null) {
                fTanksPanel = new TanksPanel();
                fTanksPanel.Model = fModel;
            }
            pnlObjects.Controls.Add(fTanksPanel);
        }

        private void UpdateControls()
        {
            DateTime cdt = DateTime.Now;
            lblDate.Text = cdt.ToString("yyyy.MM.dd\r\nHH:mm:ss", null);
        }

        private void SetSettings()
        {
            timer1.Interval = ALCore.UpdateInterval;
            timer1.Enabled = true;
        }

        #region Event handlers

        private void Timer1Tick(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddTank_Click(object sender, EventArgs e)
        {
            var aqm = new Aquarium(ALCore.UnknownName);

            using (var dlg = new AquariumEditDlg()) {
                dlg.Aquarium = aqm;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fModel.AddAquarium(aqm);
                    fTanksPanel.UpdateLayout();
                }
            }
        }

        private void btnEditTank_Click(object sender, EventArgs e)
        {
            var selectedTank = fTanksPanel.SelectedTank;
            if (selectedTank == null) return;

            var aqm = selectedTank.Aquarium;
            if (aqm == null) return;

            using (var dlg = new AquariumEditDlg()) {
                dlg.Aquarium = aqm;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fModel.UpdateAquarium(aqm);
                    fTanksPanel.UpdateLayout();
                }
            }
        }

        private void btnDeleteTank_Click(object sender, EventArgs e)
        {
            var selectedTank = fTanksPanel.SelectedTank;
            if (selectedTank == null) return;

            fModel.DeleteAquarium(selectedTank.Aquarium.Id);
            fTanksPanel.UpdateLayout();
        }

        #endregion
    }
}
