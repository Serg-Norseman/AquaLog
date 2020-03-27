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
    public sealed class Decoration : InventoryProperties
    {
        [Browsable(true), DisplayName("Size")]
        public float Size { get; set; }

        [Browsable(true), DisplayName("Weight")]
        public float Weight { get; set; }

        public Decoration()
        {
        }

        public override void SetPropNames()
        {
            ALCore.SetDisplayNameValue(this, "Size", ALData.GetLSuom(LSID.Size, MeasurementType.Length));
            ALCore.SetDisplayNameValue(this, "Weight", ALData.GetLSuom(LSID.Weight, MeasurementType.Mass));
        }
    }
}
