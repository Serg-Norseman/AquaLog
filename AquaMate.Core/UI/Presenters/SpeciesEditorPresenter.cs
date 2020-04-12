﻿/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Core.Types;
using AquaMate.Logging;
using BSLib;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI
{
    public interface ISpeciesEditorView : IView
    {
        ITextBoxHandler NameField { get; }
        ITextBoxHandler DescriptionField { get; }
        IComboBoxHandlerEx TypeCombo { get; }
        ITextBoxHandler ScientificNameField { get; }
        IComboBoxHandlerEx BioFamilyCombo { get; }
        ITextBoxHandler TempMinField { get; }
        ITextBoxHandler TempMaxField { get; }
        ITextBoxHandler PHMinField { get; }
        ITextBoxHandler PHMaxField { get; }
        ITextBoxHandler GHMinField { get; }
        ITextBoxHandler GHMaxField { get; }
        ITextBoxHandler AdultSizeField { get; }
        ITextBoxHandler LifeSpanField { get; }
        IComboBoxHandler SwimLevelCombo { get; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class SpeciesEditorPresenter : EditorPresenter<IModel, Species, ISpeciesEditorView>
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "SpeciesEditorPresenter");


        public SpeciesEditorPresenter(ISpeciesEditorView view) : base(view)
        {
        }

        public override void UpdateView()
        {
            fView.NameField.Text = fRecord.Name;
            fView.DescriptionField.Text = fRecord.Description;
            fView.TypeCombo.SetSelectedTag(fRecord.Type);
            fView.ScientificNameField.Text = fRecord.ScientificName;

            fView.BioFamilyCombo.AddRange(fModel.QuerySpeciesFamilies());
            fView.BioFamilyCombo.Text = fRecord.BioFamily;

            fView.TempMinField.SetDecimalVal(fRecord.TempMin);
            fView.TempMaxField.SetDecimalVal(fRecord.TempMax);
            fView.PHMinField.SetDecimalVal(fRecord.PHMin);
            fView.PHMaxField.SetDecimalVal(fRecord.PHMax);
            fView.GHMinField.SetDecimalVal(fRecord.GHMin);
            fView.GHMaxField.SetDecimalVal(fRecord.GHMax);

            if (fRecord.Type == SpeciesType.Fish) {
                fView.AdultSizeField.SetDecimalVal(fRecord.AdultSize);
                fView.LifeSpanField.SetDecimalVal(fRecord.LifeSpan);
                fView.SwimLevelCombo.SetSelectedTag(fRecord.SwimLevel);
            }
        }

        public override bool ApplyChanges()
        {
            try {
                fRecord.Name = fView.NameField.Text;
                fRecord.Description = fView.DescriptionField.Text;
                fRecord.Type = fView.TypeCombo.GetSelectedTag<SpeciesType>();
                fRecord.ScientificName = fView.ScientificNameField.Text;
                fRecord.BioFamily = fView.BioFamilyCombo.Text;

                fRecord.TempMin = (float)fView.TempMinField.GetDecimalVal();
                fRecord.TempMax = (float)fView.TempMaxField.GetDecimalVal();
                fRecord.PHMin = (float)fView.PHMinField.GetDecimalVal();
                fRecord.PHMax = (float)fView.PHMaxField.GetDecimalVal();
                fRecord.GHMin = (float)fView.GHMinField.GetDecimalVal();
                fRecord.GHMax = (float)fView.GHMaxField.GetDecimalVal();

                if (ALCore.IsAnimal(fRecord.Type)) {
                    fRecord.AdultSize = (float)fView.AdultSizeField.GetDecimalVal();
                    fRecord.LifeSpan = (float)fView.LifeSpanField.GetDecimalVal();
                    fRecord.SwimLevel = fView.SwimLevelCombo.GetSelectedTag<SwimLevel>();
                }

                return true;
            } catch (Exception ex) {
                fLogger.WriteError("ApplyChanges()", ex);
                return false;
            }
        }

        public void ChangeSelectedType(SpeciesType type)
        {
            bool isFish = (type == SpeciesType.Fish);
            bool isInvertebrate = (type == SpeciesType.Invertebrate);

            fView.AdultSizeField.Enabled = isFish || isInvertebrate;
            fView.LifeSpanField.Enabled = isFish || isInvertebrate;
            fView.SwimLevelCombo.Enabled = isFish || isInvertebrate;

            switch (type) {
                case SpeciesType.Fish:
                    break;

                case SpeciesType.Invertebrate:
                    break;

                case SpeciesType.Plant:
                    break;

                case SpeciesType.Coral:
                    break;
            }
        }
    }
}