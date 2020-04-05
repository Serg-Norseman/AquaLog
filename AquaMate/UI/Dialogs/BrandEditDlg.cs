/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
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
    public partial class BrandEditDlg : EditDialog<Brand>
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "BrandEditDlg");

        public BrandEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            SetLocale();
        }

        public override void SetLocale()
        {
            Text = Localizer.LS(LSID.Brand);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            lblName.Text = Localizer.LS(LSID.Name);
            lblCountry.Text = Localizer.LS(LSID.Country);
            lblNote.Text = Localizer.LS(LSID.Note);
        }

        protected override void UpdateView()
        {
            if (fRecord != null) {
                txtName.Text = fRecord.Name;

                UIHelper.FillStringsCombo(cmbCountry, fModel.QueryBrandCountries(), fRecord.Country);

                txtNote.Text = fRecord.Note;
            }
        }

        protected override void ApplyChanges()
        {
            fRecord.Name = txtName.Text;
            fRecord.Country = cmbCountry.Text;
            fRecord.Note = txtNote.Text;
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
    }
}
