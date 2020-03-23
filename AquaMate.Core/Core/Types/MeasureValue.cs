/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Drawing;

namespace AquaMate.Core.Types
{
    public class MeasureValue
    {
        public string Name;
        public double Value;
        public string Unit;

        public string ValText;
        public string Text;

        public Color Color;

        public ValueRange[] Ranges;
    }
}
