/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaLog.Core.Model;
using NUnit.Framework;

namespace AquaLog.Core.Model
{
    [TestFixture]
    public class WaterChangeTests
    {
        [Test]
        public void Test_Common()
        {
            var waterChange = new WaterChange();
            Assert.IsNotNull(waterChange);

            waterChange.Volume = 2.5;
            Assert.AreEqual(2.5, waterChange.Volume);
        }
    }
}
