/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.ComponentModel;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Core.Types;
using AquaMate.Logging;
using AquaMate.UI;
using BSLib;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI
{
    public interface IAquariumEditorView : IView
    {
        ITextBoxHandler NameField { get; }
        IComboBoxHandlerEx BrandCombo { get; }
        ITextBoxHandler DescriptionField { get; }
        IComboBoxHandlerEx ShapeCombo { get; }
        IComboBoxHandlerEx WaterTypeCombo { get; }
        IDateTimeBoxHandler StartDateField { get; }
        IDateTimeBoxHandler StopDateField { get; }
        ITextBoxHandler TankVolumeField { get; }
        ITextBoxHandler UnderfillHeightField { get; }
        ITextBoxHandler SoilHeightField { get; }
        IPropertyGridHandler PropsGrid { get; }
        ITextBoxHandler WaterVolumeField { get; }
        ITextBoxHandler SoilVolumeField { get; }
        ITextBoxHandler SoilMassField { get; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class AquariumEditorPresenter : EditorPresenter<IModel, Aquarium, IAquariumEditorView>
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "AquariumEditorPresenter");


        public AquariumEditorPresenter(IAquariumEditorView view) : base(view)
        {
        }

        public override void UpdateView()
        {
            fView.NameField.Text = fRecord.Name;
            fView.BrandCombo.AddRange(fModel.QueryAquariumBrands());
            fView.BrandCombo.Text = fRecord.Brand;
            fView.DescriptionField.Text = fRecord.Description;
            fView.ShapeCombo.SetSelectedTag(fRecord.TankShape);

            fView.WaterTypeCombo.SetSelectedTag(fRecord.WaterType);
            fView.StartDateField.SetCheckedDate(fRecord.StartDate);
            fView.StopDateField.SetCheckedDate(fRecord.StopDate);

            fView.TankVolumeField.SetDecimalVal(fRecord.TankVolume);
            fView.UnderfillHeightField.SetDecimalVal(fRecord.UnderfillHeight);
            fView.SoilHeightField.SetDecimalVal(fRecord.SoilHeight);
        }

        public override bool ApplyChanges()
        {
            try {
                fRecord.Name = fView.NameField.Text;
                fRecord.Brand = fView.BrandCombo.Text;
                fRecord.Description = fView.DescriptionField.Text;
                fRecord.TankShape = fView.ShapeCombo.GetSelectedTag<TankShape>();

                fRecord.WaterType = fView.WaterTypeCombo.GetSelectedTag<AquariumWaterType>();
                fRecord.StartDate = fView.StartDateField.GetCheckedDate();
                fRecord.StopDate = fView.StopDateField.GetCheckedDate();

                fRecord.TankVolume = fView.TankVolumeField.GetDecimalVal();
                fRecord.UnderfillHeight = fView.UnderfillHeightField.GetDecimalVal();
                fRecord.SoilHeight = fView.SoilHeightField.GetDecimalVal();

                return true;
            } catch (Exception ex) {
                fLogger.WriteError("ApplyChanges()", ex);
                return false;
            }
        }

        public void RefreshProps(TankShape tankShape)
        {
            ITank tank = fRecord.GetTank(tankShape, fRecord.TankProperties);
            TypeDescriptor.AddAttributes(tank, new Attribute[] { new ReadOnlyAttribute(true) });
            tank.SetPropNames();
            fView.PropsGrid.SelectedObject = tank;

            RecalcValues();
        }

        public void RecalcValues()
        {
            var tankShape = fView.ShapeCombo.GetSelectedTag<TankShape>();

            fView.TankVolumeField.Enabled = (tankShape == TankShape.Unknown);

            if (tankShape != TankShape.Unknown) {
                double tankVolume = fRecord.CalcTankVolume(tankShape);
                fView.TankVolumeField.SetDecimalVal(tankVolume);
            }

            double underfillHeight = ALCore.GetDecimalVal(fView.UnderfillHeightField.Text);
            double soilHeight = ALCore.GetDecimalVal(fView.SoilHeightField.Text);

            double waterVolume = fRecord.CalcWaterVolume(tankShape, underfillHeight, soilHeight);
            fView.WaterVolumeField.Text = ALData.CastStr(waterVolume, MeasurementType.Volume);

            double soilVolume = fRecord.CalcSoilVolume(tankShape, soilHeight);
            fView.SoilVolumeField.Text = ALData.CastStr(soilVolume, MeasurementType.Volume);

            double soilMass = soilVolume * ALData.DefaultSoilDensity;
            fView.SoilMassField.Text = ALData.CastStr(soilMass, MeasurementType.Mass);

            double waterMass = waterVolume * ALData.WaterDensity;
            //txtWaterMass.Text = ALData.CastStr(waterMass, MeasurementType.Mass);

            double totalMass = waterMass + soilMass;
        }

        public void EditTank(TankShape tankShape)
        {
            var tank = fRecord.GetTank(tankShape, fRecord.TankProperties);

            IBrowser browser = fModel.Browser;
            if (browser.EditTank(tank)) {
                fRecord.Tank = tank;
                RefreshProps(tankShape);
            }
        }
    }
}
