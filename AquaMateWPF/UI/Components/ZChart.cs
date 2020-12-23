/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace AquaMate.UI.Components
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ZChart : Control
    {

        public ZChart()
        {
            Clear();
        }

        public void Clear()
        {
        }

        public void ShowData(string title, string xAxis, string yAxis, object data)
        {
            Clear();
            if (data == null) return;
        }

        private void ShowSeries(string xAxis, string yAxis, ChartSeries series)
        {
        }

        #region Beautify

        public static List<ChartPoint> AlternateSort(List<ChartPoint> source)
        {
            int srcLen = source.Count;
            if (srcLen < 2) {
                return source;
            }

            source.Sort((x, y) => {
                return x.Value.CompareTo(y.Value);
            });

            ChartPoint[] target = new ChartPoint[srcLen];

            int t, b, lp, rp;
            t = srcLen - 1;
            b = 0;
            lp = t / 2 - 1;
            rp = t / 2 + 1;
            target[t / 2] = source[t];
            t--;
            while (b < t) {
                target[lp] = source[b];
                b++;
                target[rp] = source[b];
                b++;
                lp--;
                rp++;

                if (b >= t) break;

                target[lp] = source[t];
                t--;
                target[rp] = source[t];
                t--;
                lp--;
                rp++;
            }

            return target.ToList();
        }

        #endregion
    }
}
