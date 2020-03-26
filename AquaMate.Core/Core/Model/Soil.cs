/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.ComponentModel;
using AquaMate.Core.Types;

namespace AquaMate.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Soil : IInventoryProps
    {
        [Browsable(true), DisplayName("Density")]
        public float Density { get; set; } // kg/l


        public Soil()
        {
        }

        public IInventoryProps Clone()
        {
            return (IInventoryProps)this.MemberwiseClone();
        }

        public virtual void SetPropNames()
        {
            ALCore.SetDisplayNameValue(this, "Density", ALData.GetLSuom(LSID.Density, MeasurementType.Density));
        }
    }
}
