/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Threading;
using NUnit.Framework;

namespace AquaLog.DataCollection
{
    internal sealed class TestTempChannel : BaseChannel
    {
        public override bool IsConnected
        {
            get { return true; }
        }

        public TestTempChannel() : base()
        {
        }

        public override void Send(string text)
        {
            if (text == "Q:temp;2") {
                // temperature query
                string response = "R:temp;sid:0000000000000000;val:25.1111;"; // temperature response
                ReceiveData(response);
            } else {
            }
        }
    }

    [TestFixture]
    public class DataCollectionTests
    {
        [Test]
        public void Test_Common()
        {
            var serialChannel = new SerialChannel();
            Assert.IsNotNull(serialChannel);

            var tempService = new TemperatureService(serialChannel, 5000);
            Assert.IsNotNull(tempService);
            Assert.AreEqual(tempService.Channel, serialChannel);

            var ledService = new LEDService(serialChannel, 1000);
            Assert.IsNotNull(ledService);
            Assert.AreEqual(ledService.Channel, serialChannel);
        }

        [Test]
        public void Test_TemperatureService()
        {
            float temperature = 0.0f;

            var tempChannel = new TestTempChannel();
            tempChannel.ReceivedData += delegate(object sender, DataReceivedEventArgs e) {
                temperature = e.Value;
            };
            Assert.IsNotNull(tempChannel);
            tempChannel.Open(string.Empty);

            var tempService = new TemperatureService(tempChannel, 1000);
            tempChannel.Services.Add(tempService);
            Assert.IsNotNull(tempService);
            tempService.Enabled = true;
            Thread.Sleep(2000);
            Assert.AreEqual(25.1111f, temperature);

            tempChannel.Close();
        }

        [Test]
        public void Test_LEDService()
        {
            var tempChannel = new TestTempChannel();
            Assert.IsNotNull(tempChannel);
            tempChannel.Open(string.Empty);

            var ledService = new LEDService(tempChannel, 100);
            Assert.IsNotNull(ledService);
            ledService.Enabled = true;
            Thread.Sleep(2000);

            tempChannel.Close();
        }
    }
}
