﻿/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaLog.Core.Types;
using SQLite;

namespace AquaLog.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Species : Entity
    {
        [Indexed]
        public SpeciesType Type { get; set; }

        /// <summary>
        /// Common name of species.
        /// </summary>
        public string Name { get; set; }

        public string Description { get; set; }

        #region Common properties

        public CareLevel CareLevel { get; set; }
        public string BioClass { get; set; } // BioClassification: ClassName
        public string BioFamily { get; set; } // BioClassification: FamilyName (dlg+)
        public string Distribution { get; set; }
        public int MinTankSize { get; set; }
        public float PHMin { get; set; } // (dlg+)
        public float PHMax { get; set; } // (dlg+)
        public float GHMin { get; set; } // (dlg+)
        public float GHMax { get; set; } // (dlg+)
        public bool ReefCompatible { get; set; }
        public string ScientificName { get; set; } // BioClassification: SpeciesName (dlg+)
        public float TempMin { get; set; } // (dlg+)
        public float TempMax { get; set; } // (dlg+)

        #endregion

        #region Fish/Invertebrate properties

        public float AdultSize { get; set; } // (dlg+)
        public string Biology { get; set; }
        public string Climate { get; set; }
        public string Dangerous { get; set; }
        public string Diagnosis { get; set; }
        public string Diet { get; set; }
        public string Environment { get; set; }
        public float LifeSpan { get; set; } // (dlg+)

        #endregion

        #region Fish properties

        public SwimLevel SwimLevel { get; set; } // (dlg+)
        public Temperament Temperament { get; set; }

        #endregion

        #region Invertebrate properties

        public float TDSMin { get; set; }
        public float TDSMax { get; set; }

        #endregion

        #region Plant properties

        public bool Aquatic { get; set; }
        public bool CO2Required { get; set; }
        public string Demands { get; set; }
        public string Growth { get; set; }
        public string Height { get; set; }
        public string Light { get; set; }
        public string Width { get; set; }

        #endregion

        public Species() : base()
        {
        }

        public override string ToString()
        {
            return Name;
        }

        public string GetTempRange()
        {
            if (TempMin == 0.0f && TempMax == 0.0f) {
                return string.Empty;
            }
            return ALCore.GetDecimalStr(TempMin) + " - " + ALCore.GetDecimalStr(TempMax);
        }

        public string GetPHRange()
        {
            if (PHMin == 0.0f && PHMax == 0.0f) {
                return string.Empty;
            }
            return ALCore.GetDecimalStr(PHMin) + " - " + ALCore.GetDecimalStr(PHMax);
        }

        public string GetGHRange()
        {
            if (GHMin == 0.0f && GHMax == 0.0f) {
                return string.Empty;
            }
            return ALCore.GetDecimalStr(GHMin) + " - " + ALCore.GetDecimalStr(GHMax);
        }
    }
}
