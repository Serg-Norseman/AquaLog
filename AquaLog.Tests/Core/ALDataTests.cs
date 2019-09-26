/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using NUnit.Framework;

namespace AquaLog.Core
{
    [TestFixture]
    public class ALDataTests
    {
        [Test]
        public void Test_CalcArea()
        {
            Assert.AreEqual(358.75, ALData.CalcArea(17.5, 20.5));
        }

        [Test]
        public void CalcTankVolume()
        {
            Assert.AreEqual(9.506875, ALData.CalcRectangularTankVolume(17.5, 20.5, 26.5));
        }

        [Test]
        public void Test_CalcWaterVolume()
        {
            Assert.AreEqual(17.0f, ALData.CalcWaterVolume(20.0f));
        }
    }
}
