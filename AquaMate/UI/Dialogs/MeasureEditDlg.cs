/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
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
    public partial class MeasureEditDlg : EditDialog<Measure>, IMeasureEditorView
    {
        private readonly MeasureEditorPresenter fPresenter;

        public MeasureEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            fPresenter = new MeasureEditorPresenter(this);
        }

        public override void SetLocale()
        {
            Text = Localizer.LS(LSID.Measure);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            lblAquarium.Text = Localizer.LS(LSID.Aquarium);
            lblTimestamp.Text = Localizer.LS(LSID.Timestamp);
            lblTemperature.Text = ALData.GetLSuom(LSID.Temperature, MeasurementType.Temperature);
        }

        public override void SetContext(IModel model, Measure record)
        {
            base.SetContext(model, record);
            fPresenter.SetContext(model, record);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = fPresenter.ApplyChanges() ? DialogResult.OK : DialogResult.None;
        }

        private void btnCalcCO2_Click(object sender, EventArgs e)
        {
            fPresenter.CalcCO2();
        }

        private void btnCalcNH3_Click(object sender, EventArgs e)
        {
            fPresenter.CalcNH3();
        }

        private void btnCalcNH4_Click(object sender, EventArgs e)
        {
            fPresenter.CalcNH4();
        }

        #region View interface implementation

        IComboBoxHandlerEx IMeasureEditorView.AquariumCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbAquarium); }
        }

        IDateTimeBoxHandler IMeasureEditorView.TimestampField
        {
            get { return GetControlHandler<IDateTimeBoxHandler>(dtpTimestamp); }
        }

        ITextBoxHandler IMeasureEditorView.TemperatureField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtTemperature); }
        }

        ITextBoxHandler IMeasureEditorView.NO3Field
        {
            get { return GetControlHandler<ITextBoxHandler>(txtNO3); }
        }

        ITextBoxHandler IMeasureEditorView.NO2Field
        {
            get { return GetControlHandler<ITextBoxHandler>(txtNO2); }
        }

        ITextBoxHandler IMeasureEditorView.GHField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtGH); }
        }

        ITextBoxHandler IMeasureEditorView.KHField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtKH); }
        }

        ITextBoxHandler IMeasureEditorView.PHField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtPH); }
        }

        ITextBoxHandler IMeasureEditorView.Cl2Field
        {
            get { return GetControlHandler<ITextBoxHandler>(txtCl2); }
        }

        ITextBoxHandler IMeasureEditorView.CO2Field
        {
            get { return GetControlHandler<ITextBoxHandler>(txtCO2); }
        }

        ITextBoxHandler IMeasureEditorView.NHField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtNHtot); }
        }

        ITextBoxHandler IMeasureEditorView.NH3Field
        {
            get { return GetControlHandler<ITextBoxHandler>(txtNH3); }
        }

        ITextBoxHandler IMeasureEditorView.NH4Field
        {
            get { return GetControlHandler<ITextBoxHandler>(txtNH4); }
        }

        ITextBoxHandler IMeasureEditorView.PO4Field
        {
            get { return GetControlHandler<ITextBoxHandler>(txtPO4); }
        }

        #endregion
    }
}
