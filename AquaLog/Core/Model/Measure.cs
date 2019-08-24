/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;

namespace AquaLog.Core.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Measure : AquariumDetails
    {
        public DateTime Timestamp { get; set; }

        // physical
        public float Conductivity { get; set; }
        public float Density { get; set; }
        public float Temperature { get; set; } // dlg+

        // chemical elements
        public float Ca { get; set; }
        public float Cu { get; set; }
        public float Fe { get; set; }
        public float Mg { get; set; }

        // chemical compounds and ions
        public float Cl2 { get; set; } // dlg+
        public float CO2 { get; set; } // dlg+
        public float NH { get; set; } // dlg+
        public float NH3 { get; set; } // dlg+
        public float NH4 { get; set; } // dlg+
        public float NO2 { get; set; } // dlg+
        public float NO3 { get; set; } // dlg+
        public float O2 { get; set; }
        public float PO4 { get; set; }

        // chemical complex
        public float GH { get; set; } // dlg+
        public float KH { get; set; } // dlg+
        public float pH { get; set; } // dlg+


        public Measure()
        {
        }
    }
}
