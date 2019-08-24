/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using NUnit.Framework;

namespace AquaLog.TSDB
{
    [TestFixture]
    public class SDCompressionTests
    {
        [Test]
        public void Test_Common()
        {
            // DS18B20: -55°C до +125°C, ±0.5°C
            var instance = new SDCompression(0.5, 3600);
            Assert.IsNotNull(instance);

            DateTime timestamp;
            double value;

            timestamp = new DateTime(2019, 08, 02, 20, 00, 00);
            value = 22.0;
            Assert.AreEqual(true, instance.ReceivePoint(ref timestamp, ref value));

            var timestamp2 = new DateTime(2019, 08, 02, 20, 00, 01);
            var value2 = 22.1;
            Assert.AreEqual(false, instance.ReceivePoint(ref timestamp2, ref value2));

            timestamp = new DateTime(2019, 08, 02, 20, 00, 02);
            value = 23.8;
            Assert.AreEqual(true, instance.ReceivePoint(ref timestamp, ref value));
            Assert.AreEqual(timestamp2, timestamp);
            Assert.AreEqual(value2, value);
        }
    }
}
