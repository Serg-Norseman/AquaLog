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
    public class PumpTests
    {
        [Test]
        public void Test_Common()
        {
            var pump = new Pump();
            Assert.IsNotNull(pump);

            pump.Name = "Air Pump";
            Assert.AreEqual("Air Pump", pump.Name);
        }
    }
}
