/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using NUnit.Framework;

namespace AquaLog.DataCollection
{
    [TestFixture]
    public class DataCollectionTests
    {
        [Test]
        public void Test_Common()
        {
            var serialChannel = new SerialChannel();
            Assert.IsNotNull(serialChannel);

            var tempService = new TemperatureService();
            Assert.IsNotNull(tempService);
            tempService.Channel = serialChannel;

            var ledService = new CommunicationLEDService();
            Assert.IsNotNull(ledService);
            ledService.Channel = serialChannel;
        }
    }
}
