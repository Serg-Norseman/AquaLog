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

        [Test]
        public void Test_CubeTankProperties()
        {
            var aquarium = new Aquarium() {
                TankShape = TankShape.Cube
            };
            Assert.IsNotNull(aquarium);

            Assert.IsNotNull(aquarium.Tank);
            Assert.IsInstanceOf(typeof(CubeTank), aquarium.Tank);

            CubeTank rectTank = new CubeTank() {
                EdgeSize = 21.5f
            };

            aquarium.Tank = rectTank;
            Assert.AreEqual("EdgeSize=21.5", aquarium.TankProperties);

            rectTank = (CubeTank)aquarium.Tank;
            Assert.AreEqual(21.5f, rectTank.EdgeSize);

            aquarium.GlassThickness = 0.5f;
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
            RectangularTank rectTank = new RectangularTank() {
                Width = 21.5f,
                Depth = 18.5f,
                Height = 27.0f
            };

            aquarium.Tank = rectTank;
            Assert.AreEqual("Depth=18.5;Width=21.5;Height=27", aquarium.TankProperties);

            rectTank = (RectangularTank)aquarium.Tank;
            Assert.AreEqual(21.5f, rectTank.Width);
            Assert.AreEqual(18.5f, rectTank.Depth);
            Assert.AreEqual(27.0f, rectTank.Height);

            aquarium.GlassThickness = 0.5f;
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
            BowFrontTank tank = new BowFrontTank() {
                CentreDepth = 41.0f,
                Width = 92.0f,
                Depth = 31.0f,
                Height = 55.0f
            };

            aquarium.Tank = tank;
            Assert.AreEqual("CentreDepth=41;Depth=31;Width=92;Height=55", aquarium.TankProperties);

            tank = (BowFrontTank)aquarium.Tank;
            Assert.AreEqual(41.0f, tank.CentreDepth);
            Assert.AreEqual(92.0f, tank.Width);
            Assert.AreEqual(31.0f, tank.Depth);
            Assert.AreEqual(55.0f, tank.Height);

            aquarium.GlassThickness = 0.6f;
            Assert.AreEqual(180.445f, aquarium.CalcTankVolume(), 0.001);
        }
    }
}
