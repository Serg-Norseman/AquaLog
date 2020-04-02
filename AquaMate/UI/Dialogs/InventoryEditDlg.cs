﻿/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Core.Types;
using AquaMate.Logging;
using BSLib;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class InventoryEditDlg : Form, IEditDialog<Inventory>
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "InventoryEditDlg");

        private ALModel fModel;
        private Inventory fRecord;

        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public Inventory Record
        {
            get { return fRecord; }
            set {
                if (fRecord != value) {
                    fRecord = value;
                    UpdateView();
                }
            }
        }


        public InventoryEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            SetLocale();
        }

        public void SetLocale()
        {
            Text = Localizer.LS(LSID.Inventory);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            cmbType.FillCombo<InventoryType>(ALData.InventoryTypes, true);

            lblName.Text = Localizer.LS(LSID.Name);
            lblBrand.Text = Localizer.LS(LSID.Brand);
            lblType.Text = Localizer.LS(LSID.Type);
            lblNote.Text = Localizer.LS(LSID.Note);
            lblState.Text = Localizer.LS(LSID.State);
        }

        private void UpdateView()
        {
            if (fRecord != null) {
                UIHelper.FillStringsCombo(cmbBrand, fModel.QueryInventoryBrands(), fRecord.Brand);

                txtName.Text = fRecord.Name;
                cmbType.SetSelectedTag(fRecord.Type);
                txtNote.Text = fRecord.Note;

                UIHelper.FillItemStatesCombo(cmbState, ALCore.GetItemType(fRecord.Type), fRecord.State);
            }
        }

        private void ApplyChanges()
        {
            fRecord.Name = txtName.Text;
            fRecord.Brand = cmbBrand.Text;
            fRecord.Type = cmbType.GetSelectedTag<InventoryType>();
            fRecord.Note = txtNote.Text;
            fRecord.State = cmbState.GetSelectedTag<ItemState>();

            fRecord.Properties = pgProps.SelectedObject as InventoryProperties;
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

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var invType = cmbType.GetSelectedTag<InventoryType>();
            UIHelper.FillItemStatesCombo(cmbState, ALCore.GetItemType(invType), fRecord.State);
            if (invType >= 0) {
            }

            InventoryProperties props = fRecord.GetProperties(invType, fRecord.RawProperties);
            if (props != null) {
                props.SetPropNames();
            }
            pgProps.SelectedObject = props;
        }
    }
}
