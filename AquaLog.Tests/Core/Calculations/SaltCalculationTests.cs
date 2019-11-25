﻿/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using NUnit.Framework;

namespace AquaLog.Core.Calculations
{
    [TestFixture]
    public class SaltCalculationTests
    {
        [Test]
        public void Test_Common()
        {
            var instance = new SaltCalculation(CalculationType.NitriteSaltCalculator);
            Assert.IsNotNull(instance);

            instance.Volume = 10.0f;
            instance.Nitrite = 57.0f;
            instance.Calculate();
            Assert.AreEqual(4.275f, instance.ResultValue, 0.001);
        }
    }
}
