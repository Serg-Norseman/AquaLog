/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Windows;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Core.Types;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AquariumEditDlg : EditDialog, IAquariumEditorView
    {
        private readonly AquariumEditorPresenter fPresenter;

        public AquariumEditDlg()
        {
            InitializeComponent();

            fPresenter = new AquariumEditorPresenter(this);
        }

        public override void SetLocale()
        {
            base.Title = Localizer.LS(LSID.Aquarium);
            btnAccept.Content = Localizer.LS(LSID.Accept);
            btnCancel.Content = Localizer.LS(LSID.Cancel);

            tabCommon.Header = Localizer.LS(LSID.Common);
            tabTank.Header = Localizer.LS(LSID.Tank);

            lblName.Content = Localizer.LS(LSID.Name);
            lblDesc.Content = Localizer.LS(LSID.Description);
            lblStartDate.Content = Localizer.LS(LSID.StartDate);
            lblStopDate.Content = Localizer.LS(LSID.StopDate);
            lblShape.Content = Localizer.LS(LSID.Shape);
            lblWaterType.Content = Localizer.LS(LSID.WaterType);

            lblVolume.Content = ALData.GetLSuom(LSID.TankVolume, MeasurementType.Volume);
            lblWaterVolume.Content = ALData.GetLSuom(LSID.WaterVolume, MeasurementType.Volume);

            btnTank.Content = Localizer.LS(LSID.Tank) + "...";

            lblUnderfillHeight.Content = ALData.GetLSuom(LSID.UnderfillHeight, MeasurementType.Length);
            lblSoilHeight.Content = ALData.GetLSuom(LSID.SoilHeight, MeasurementType.Length);
            lblSoilVolume.Content = ALData.GetLSuom(LSID.SoilVolume, MeasurementType.Volume);
            lblSoilMass.Content = ALData.GetLSuom(LSID.SoilMass, MeasurementType.Mass);
            lblBrand.Content = Localizer.LS(LSID.Brand);
        }

        public void SetContext(IModel model, Aquarium record)
        {
            fPresenter.SetContext(model, record);
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = fPresenter.ApplyChanges();
        }

        private void cmbShape_SelectedIndexChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            fPresenter.RefreshProps();
        }

        private void txtValue_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            fPresenter.RecalcValues();
        }

        private void btnTank_Click(object sender, RoutedEventArgs e)
        {
            fPresenter.EditTank();
        }

        #region View interface implementation

        ITextBox IAquariumEditorView.NameField
        {
            get { return GetControlHandler<ITextBox>(txtName); }
        }

        IComboBox IAquariumEditorView.BrandCombo
        {
            get { return GetControlHandler<IComboBox>(cmbBrand); }
        }

        ITextBox IAquariumEditorView.DescriptionField
        {
            get { return GetControlHandler<ITextBox>(txtDesc); }
        }

        IComboBox IAquariumEditorView.ShapeCombo
        {
            get { return GetControlHandler<IComboBox>(cmbShape); }
        }

        IComboBox IAquariumEditorView.WaterTypeCombo
        {
            get { return GetControlHandler<IComboBox>(cmbWaterType); }
        }

        IDateTimeBox IAquariumEditorView.StartDateField
        {
            get { return GetControlHandler<IDateTimeBox>(dtpStartDate); }
        }

        IDateTimeBox IAquariumEditorView.StopDateField
        {
            get { return GetControlHandler<IDateTimeBox>(dtpStopDate); }
        }

        ITextBox IAquariumEditorView.TankVolumeField
        {
            get { return GetControlHandler<ITextBox>(txtTankVolume); }
        }

        ITextBox IAquariumEditorView.UnderfillHeightField
        {
            get { return GetControlHandler<ITextBox>(txtUnderfillHeight); }
        }

        ITextBox IAquariumEditorView.SoilHeightField
        {
            get { return GetControlHandler<ITextBox>(txtSoilHeight); }
        }

        IPropertyGrid IAquariumEditorView.PropsGrid
        {
            get { return GetControlHandler<IPropertyGrid>(pgProps); }
        }

        ITextBox IAquariumEditorView.WaterVolumeField
        {
            get { return GetControlHandler<ITextBox>(txtWaterVolume); }
        }

        ITextBox IAquariumEditorView.SoilVolumeField
        {
            get { return GetControlHandler<ITextBox>(txtSoilVolume); }
        }

        ITextBox IAquariumEditorView.SoilMassField
        {
            get { return GetControlHandler<ITextBox>(txtSoilMass); }
        }

        #endregion
    }
}
