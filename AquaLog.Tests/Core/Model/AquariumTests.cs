/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaLog.Core.Types;
using NUnit.Framework;

namespace AquaLog.Core.Model
{
    [TestFixture]
    public class AquariumTests
    {
        [Test]
        public void Test_ctorName()
        {
            var tank = new Aquarium("Nano");
            Assert.IsNotNull(tank);

            Assert.AreEqual("Nano", tank.Name);
            Assert.AreEqual("Nano", tank.ToString());
        }

        [Test]
        public void Test_ctor2a()
        {
            var tank = new Aquarium(TankShape.Bowl, 2.5);
            Assert.IsNotNull(tank);

            Assert.AreEqual(TankShape.Bowl, tank.TankShape);
            Assert.AreEqual(2.5, tank.TankVolume);
        }

        [Test]
        public void Test_ctor4a()
        {
            var tank = new Aquarium(TankShape.Rectangular, 17.5, 20.5, 26.5);
            Assert.IsNotNull(tank);

            Assert.AreEqual(TankShape.Rectangular, tank.TankShape);
            Assert.AreEqual(9.506875, tank.TankVolume);
        }

        [Test]
        public void Test_IsSalt()
        {
            var tank = new Aquarium();
            Assert.IsNotNull(tank);

            tank.WaterType = AquariumWaterType.SeaWater;
            Assert.AreEqual(true, tank.IsSalt());
        }

        [Test]
        public void Test_IsInactive()
        {
            var tank = new Aquarium();
            Assert.IsNotNull(tank);

            DateTime now = DateTime.Now;
            tank.StartDate = now;
            tank.StopDate = now;
            Assert.AreEqual(true, tank.IsInactive());
        }

        [Test]
        public void Test_GetBaseArea()
        {
            var tank = new Aquarium(TankShape.Rectangular, 17.5, 20.5, 26.5);
            Assert.IsNotNull(tank);

            Assert.AreEqual(358.75, tank.GetBaseArea());
        }
    }
}
