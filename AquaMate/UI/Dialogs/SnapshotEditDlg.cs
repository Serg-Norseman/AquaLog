﻿/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Drawing.Imaging;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Logging;
using BSLib;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SnapshotEditDlg : Form, IEditDialog<Snapshot>
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "SnapshotEditDlg");

        private ALModel fModel;
        private Snapshot fRecord;


        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public Snapshot Record
        {
            get { return fRecord; }
            set {
                if (fRecord != value) {
                    fRecord = value;
                    UpdateView();
                }
            }
        }


        public SnapshotEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            SetLocale();
        }

        public void SetLocale()
        {
            Text = Localizer.LS(LSID.Snapshot);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            lblName.Text = Localizer.LS(LSID.Name);
            lblDate.Text = Localizer.LS(LSID.Date);
        }

        private void UpdateView()
        {
            if (fRecord != null) {
                txtName.Text = fRecord.Name;
                if (fRecord.Image != null) {
                    pictureBox1.Image = ALModel.ByteToImage(fRecord.Image);
                }

                if (!ALCore.IsZeroDate(fRecord.Timestamp)) {
                    dtpDateTime.Value = fRecord.Timestamp;
                }
            }
        }

        private void ApplyChanges()
        {
            fRecord.Name = txtName.Text;
            if (pictureBox1.Image != null) {
                fRecord.Image = ALModel.ImageToByte(pictureBox1.Image, ImageFormat.Jpeg);
            }
            fRecord.Timestamp = dtpDateTime.Value;
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = UIHelper.LoadImage();
        }
    }
}