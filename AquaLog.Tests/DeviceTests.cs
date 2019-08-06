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
    public class DeviceTests
    {
        [Test]
        public void Test_Common()
        {
            var light = new Device();
            Assert.IsNotNull(light);

            light.Name = "Light";
            Assert.AreEqual("Light", light.Name);
        }
    }
}
