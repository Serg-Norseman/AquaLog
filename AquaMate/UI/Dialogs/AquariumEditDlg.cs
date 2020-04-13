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
    public partial class AquariumEditDlg : EditDialog<Aquarium>, IAquariumEditorView
    {
        private readonly AquariumEditorPresenter fPresenter;

        public AquariumEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            fPresenter = new AquariumEditorPresenter(this);
        }

        public override void SetLocale()
        {
            Text = Localizer.LS(LSID.Aquarium);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            var tankShapesList = ALData.GetNamesList<TankShape>(ALData.TankShapes);
            cmbShape.FillCombo<TankShape>(tankShapesList, false);

            var waterTypesList = ALData.GetNamesList<AquariumWaterType>(ALData.WaterTypes);
            cmbWaterType.FillCombo<AquariumWaterType>(waterTypesList, false);

            tabCommon.Text = Localizer.LS(LSID.Common);
            tabTank.Text = Localizer.LS(LSID.Tank);

            lblName.Text = Localizer.LS(LSID.Name);
            lblDesc.Text = Localizer.LS(LSID.Description);
            lblStartDate.Text = Localizer.LS(LSID.StartDate);
            lblStopDate.Text = Localizer.LS(LSID.StopDate);
            lblShape.Text = Localizer.LS(LSID.Shape);
            lblWaterType.Text = Localizer.LS(LSID.WaterType);

            lblVolume.Text = ALData.GetLSuom(LSID.TankVolume, MeasurementType.Volume);
            lblWaterVolume.Text = ALData.GetLSuom(LSID.WaterVolume, MeasurementType.Volume);

            btnTank.Text = Localizer.LS(LSID.Tank) + "...";

            lblUnderfillHeight.Text = ALData.GetLSuom(LSID.UnderfillHeight, MeasurementType.Length);
            lblSoilHeight.Text = ALData.GetLSuom(LSID.SoilHeight, MeasurementType.Length);
            lblSoilVolume.Text = ALData.GetLSuom(LSID.SoilVolume, MeasurementType.Volume);
            lblSoilMass.Text = ALData.GetLSuom(LSID.SoilMass, MeasurementType.Mass);
            lblBrand.Text = Localizer.LS(LSID.Brand);
        }

        public override void SetContext(IModel model, Aquarium record)
        {
            base.SetContext(model, record);
            fPresenter.SetContext(model, record);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = fPresenter.ApplyChanges() ? DialogResult.OK : DialogResult.None;
        }

        private void cmbShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tankShape = cmbShape.GetSelectedTag<TankShape>();
            fPresenter.RefreshProps(tankShape);
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            fPresenter.RecalcValues();
        }

        private void btnTank_Click(object sender, EventArgs e)
        {
            var tankShape = cmbShape.GetSelectedTag<TankShape>();
            fPresenter.EditTank(tankShape);
        }

        #region View interface implementation

        ITextBoxHandler IAquariumEditorView.NameField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtName); }
        }

        IComboBoxHandlerEx IAquariumEditorView.BrandCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbBrand); }
        }

        ITextBoxHandler IAquariumEditorView.DescriptionField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtDesc); }
        }

        IComboBoxHandlerEx IAquariumEditorView.ShapeCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbShape); }
        }

        IComboBoxHandlerEx IAquariumEditorView.WaterTypeCombo
        {
            get { return GetControlHandler<IComboBoxHandlerEx>(cmbWaterType); }
        }

        IDateTimeBoxHandler IAquariumEditorView.StartDateField
        {
            get { return GetControlHandler<IDateTimeBoxHandler>(dtpStartDate); }
        }

        IDateTimeBoxHandler IAquariumEditorView.StopDateField
        {
            get { return GetControlHandler<IDateTimeBoxHandler>(dtpStopDate); }
        }

        ITextBoxHandler IAquariumEditorView.TankVolumeField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtTankVolume); }
        }

        ITextBoxHandler IAquariumEditorView.UnderfillHeightField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtUnderfillHeight); }
        }

        ITextBoxHandler IAquariumEditorView.SoilHeightField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtSoilHeight); }
        }

        IPropertyGridHandler IAquariumEditorView.PropsGrid
        {
            get { return GetControlHandler<IPropertyGridHandler>(pgProps); }
        }

        ITextBoxHandler IAquariumEditorView.WaterVolumeField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtWaterVolume); }
        }

        ITextBoxHandler IAquariumEditorView.SoilVolumeField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtSoilVolume); }
        }

        ITextBoxHandler IAquariumEditorView.SoilMassField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtSoilMass); }
        }

        #endregion
    }
}
