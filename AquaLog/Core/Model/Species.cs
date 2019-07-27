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
        public string BioFamily { get; set; } // BioClassification: FamilyName
        public string Distribution { get; set; }
        public int MinTankSize { get; set; }
        public string PHMin { get; set; }
        public string PHMax { get; set; }
        public string DHMin { get; set; }
        public string DHMax { get; set; }
        public bool ReefCompatible { get; set; }
        public string ScientificName { get; set; } // BioClassification: SpeciesName
        public string TempMin { get; set; }
        public string TempMax { get; set; }

        #endregion

        #region Fish/Invertebrate properties

        public string Biology { get; set; }
        public string Climate { get; set; }
        public string Dangerous { get; set; }
        public string Diagnosis { get; set; }
        public string Diet { get; set; }
        public string Environment { get; set; }
        public string LifeSpan { get; set; }
        public int MaxSize { get; set; }
        public string SwimLevel { get; set; }

        #endregion

        #region Fish properties

        public Temperament Temperament { get; set; }

        #endregion

        #region Invertebrate properties

        public string TDSMin { get; set; }
        public string TDSMax { get; set; }

        #endregion

        #region Plant properties

        public bool Aquatic { get; set; }
        public bool CO2Required { get; set; }
        public string Demands { get; set; }
        public string Growth { get; set; }
        public string Height { get; set; }
        public string Light { get; set; }
        public string Placement { get; set; }
        public string Width { get; set; }

        #endregion

        public Species()
        {
        }

        public override string ToString()
        {
            return Name;
        }
    }
}