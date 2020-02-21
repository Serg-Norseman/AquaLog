/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;

namespace AquaLog.DataCollection
{
    /// <summary>
    /// 
    /// </summary>
    public class RandomChannel : BaseChannel
    {
        private int fMode;
        private Random fRandom;

        public override bool IsOpen
        {
            get {
                return true;
            }
        }

        public RandomChannel()
        {
            fMode = -1;
            fRandom = new Random();
        }

        public override string ReadLine()
        {
            if (fMode == 1) {
                fMode = -1;
                float val = 20.0f + fRandom.Next(100) / 10.0f;
                return string.Format("R:temp;sid:0000000000000000;val:{0};", val); // temperature response
            } else {
                return string.Empty;
            }
        }

        public override void WriteLine(string text)
        {
            if (text == "Q:temp;2;") {
                fMode = 1; // temperature query
            } else {
                fMode = -1;
            }
        }
    }
}
