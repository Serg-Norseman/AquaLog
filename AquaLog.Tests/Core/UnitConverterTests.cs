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
    public class UnitConverterTests
    {
        [Test]
        public void Test_cm2inch()
        {
            Assert.AreEqual(0.393701, UnitConverter.cm2inch(1.0f));
        }

        [Test]
        public void Test_inch2cm()
        {
            Assert.AreEqual(2.54, UnitConverter.inch2cm(1.0f));
        }

        [Test]
        public void Test_feet2cm()
        {
            Assert.AreEqual(30.48, UnitConverter.feet2cm(1.0f));
        }

        [Test]
        public void Test_cm2feet()
        {
            Assert.AreEqual(0.0328, UnitConverter.cm2feet(1.0f));
        }
    }
}
