/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaLog.Core;
using NUnit.Framework;

namespace AquaLog.Tests
{
    [TestFixture]
    public class AquariumTests
    {
        [Test]
        public void Test_Common()
        {
            var tank = new Aquarium(TankShape.Rectangular, 17.5, 20.5, 26.5, false);
            Assert.IsNotNull(tank);

            Assert.AreEqual(TankShape.Rectangular, tank.TankShape);
            Assert.AreEqual(9.506875, tank.Volume);
        }
    }
}
