/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaLog.Core.Model.Tanks;
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
            var tank = new Aquarium();
            tank.Name = "Nano";
            Assert.IsNotNull(tank);

            Assert.AreEqual("Nano", tank.Name);
            Assert.AreEqual("Nano", tank.ToString());
        }

        [Test]
        public void Test_ctor2a()
        {
            var aquarium = new Aquarium();
            aquarium.TankShape = TankShape.Bowl;
            aquarium.TankVolume = 2.5;
            Assert.IsNotNull(aquarium);

            Assert.AreEqual(TankShape.Bowl, aquarium.TankShape);
            Assert.AreEqual(2.5, aquarium.TankVolume);
        }

        [Test]
        public void Test_ctor4a()
        {
            var aquarium = new Aquarium();
            aquarium.TankShape = TankShape.Rectangular;
            Assert.IsNotNull(aquarium);

            var rectTank = new RectangularTank(20.5f, 17.5f, 26.5f, 0.0f);
            aquarium.Tank = rectTank;

            Assert.AreEqual(TankShape.Rectangular, aquarium.TankShape);
            Assert.AreEqual(9.506875, aquarium.CalcTankVolume());
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
            var aquarium = new Aquarium();
            aquarium.TankShape = TankShape.Rectangular;
            Assert.IsNotNull(aquarium);

            var tank = new RectangularTank(20.5f, 17.5f, 26.5f, 0.0f);
            aquarium.Tank = tank;

            Assert.AreEqual(358.75, aquarium.CalcBaseArea());
        }

        [Test]
        public void Test_BowlTankProperties()
        {
            var aquarium = new Aquarium() {
                TankShape = TankShape.Bowl
            };
            Assert.IsNotNull(aquarium);

            Assert.IsNotNull(aquarium.Tank);
            Assert.IsInstanceOf(typeof(BowlTank), aquarium.Tank);

            BowlTank tank = new BowlTank(14.5f, 9.0f, 12.4f, 0.5f);

            aquarium.Tank = tank;
            Assert.AreEqual("Height=14.5;BottomDiameter=9;TopDiameter=12.4;GlassThickness=0.5", aquarium.TankProperties);

            tank = (BowlTank)aquarium.Tank;
            Assert.AreEqual(14.5f, tank.Height);
            Assert.AreEqual(9.0f, tank.BottomDiameter);
            Assert.AreEqual(12.4f, tank.TopDiameter);

            Assert.AreEqual(2.5f, aquarium.CalcTankVolume(), 0.01);
        }

        [Test]
        public void Test_CubeTankProperties()
        {
            var aquarium = new Aquarium() {
                TankShape = TankShape.Cube
            };
            Assert.IsNotNull(aquarium);

            Assert.IsNotNull(aquarium.Tank);
            Assert.IsInstanceOf(typeof(CubeTank), aquarium.Tank);

            CubeTank tank = new CubeTank(21.5f, 0.5f);

            aquarium.Tank = tank;
            Assert.AreEqual("EdgeSize=21.5;GlassThickness=0.5", aquarium.TankProperties);

            tank = (CubeTank)aquarium.Tank;
            Assert.AreEqual(21.5f, tank.EdgeSize);

            Assert.AreEqual(8.82f, aquarium.CalcTankVolume(), 0.01);
        }

        [Test]
        public void Test_RectangularTankProperties()
        {
            var aquarium = new Aquarium() {
                TankShape = TankShape.Rectangular
            };
            Assert.IsNotNull(aquarium);

            Assert.IsNotNull(aquarium.Tank);
            Assert.IsInstanceOf(typeof(RectangularTank), aquarium.Tank);

            // 0.5f, 9.51 l
            RectangularTank tank = new RectangularTank(21.5f, 18.5f, 27.0f, 0.5f);

            aquarium.Tank = tank;
            Assert.AreEqual("Width=18.5;Length=21.5;Height=27;GlassThickness=0.5", aquarium.TankProperties);

            tank = (RectangularTank)aquarium.Tank;
            Assert.AreEqual(21.5f, tank.Length);
            Assert.AreEqual(18.5f, tank.Width);
            Assert.AreEqual(27.0f, tank.Height);

            Assert.AreEqual(9.51f, aquarium.CalcTankVolume(), 0.01);
        }

        [Test]
        public void Test_BowFrontTankProperties()
        {
            var aquarium = new Aquarium() {
                TankShape = TankShape.BowFront
            };
            Assert.IsNotNull(aquarium);

            Assert.IsNotNull(aquarium.Tank);
            Assert.IsInstanceOf(typeof(BowFrontTank), aquarium.Tank);

            // Juwel Vision 180: 92×41×55 (sideDepth=31, centreDepth=41), 180 l, Glass Thickness: 6 mm
            BowFrontTank tank = new BowFrontTank(92.0f, 31.0f, 41.0f, 55.0f, 0.6f);

            aquarium.Tank = tank;
            Assert.AreEqual("CentreWidth=41;Width=31;Length=92;Height=55;GlassThickness=0.6", aquarium.TankProperties);

            tank = (BowFrontTank)aquarium.Tank;
            Assert.AreEqual(41.0f, tank.CentreWidth);
            Assert.AreEqual(92.0f, tank.Length);
            Assert.AreEqual(31.0f, tank.Width);
            Assert.AreEqual(55.0f, tank.Height);

            Assert.AreEqual(180.445f, aquarium.CalcTankVolume(), 0.001);
        }
    }
}
