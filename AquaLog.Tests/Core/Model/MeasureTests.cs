﻿/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using NUnit.Framework;

namespace AquaLog.Core.Model
{
    [TestFixture]
    public class MeasureTests
    {
        [Test]
        public void Test_Common()
        {
            var measure = new Measure();
            Assert.IsNotNull(measure);

            measure.Temperature = 2.5f;
            Assert.AreEqual(2.5f, measure.Temperature);
        }
    }
}