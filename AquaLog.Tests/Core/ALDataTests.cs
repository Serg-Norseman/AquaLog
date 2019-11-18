/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaLog.Core.Model.Tanks;
using NUnit.Framework;

namespace AquaLog.Core
{
    [TestFixture]
    public class ALDataTests
    {
        [Test]
        public void Test_CalcArea()
        {
            var tank = new RectangularTank(17.5f, 20.5f, 26.5f);
            Assert.AreEqual(358.75d, tank.CalcBaseArea());
        }

        [Test]
        public void CalcTankVolume()
        {
            var tank = new RectangularTank(17.5f, 20.5f, 26.5f);
            Assert.AreEqual(9.506875d, tank.CalcTankVolume());
        }

        [Test]
        public void Test_CalcWaterVolume()
        {
            Assert.AreEqual(17.0f, ALData.CalcWaterVolume(20.0f));
        }
    }
}
