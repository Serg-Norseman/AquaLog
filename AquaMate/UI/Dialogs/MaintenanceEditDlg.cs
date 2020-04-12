/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Core.Types;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MaintenanceEditDlg : EditDialog<Maintenance>, IMaintenanceEditorView
    {
        private readonly MaintenanceEditorPresenter fPresenter;

        public MaintenanceEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            fPresenter = new MaintenanceEditorPresenter(this);
        }

        public override void SetLocale()
        {
            Text = Localizer.LS(LSID.Maintenance);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            var maintenanceTypesList = ALData.GetNamesList<MaintenanceType>(ALData.MaintenanceTypes);
            cmbType.FillCombo<MaintenanceType>(maintenanceTypesList, true);

            lblAquarium.Text = Localizer.LS(LSID.Aquarium);
            lblDateTime.Text = Localizer.LS(LSID.Date);
            lblType.Text = Localizer.LS(LSID.Type);
            lblValue.Text = Localizer.LS(LSID.Value);
            lblNote.Text = Localizer.LS(LSID.Note);
        }

        public override void SetContext(IModel model, Maintenance record)
        {
            base.SetContext(model, record);
            fPresenter.SetContext(model, record);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = fPresenter.ApplyChanges() ? DialogResult.OK : DialogResult.None;
        }

        #region View interface implementation

        IComboBoxHandlerEx IMaintenanceEditorView.AquariumCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbAquarium); }
        }

        IDateTimeBoxHandler IMaintenanceEditorView.TimestampField
        {
            get { return GetControlHandler<IDateTimeBoxHandler>(dtpDateTime); }
        }

        IComboBoxHandlerEx IMaintenanceEditorView.TypeCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbType); }
        }

        ITextBoxHandler IMaintenanceEditorView.ValueField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtValue); }
        }

        ITextBoxHandler IMaintenanceEditorView.NoteField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtNote); }
        }

        #endregion
    }
}
