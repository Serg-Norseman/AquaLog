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
        private int fMode;

        public override bool IsOpen
        {
            get {
                return true;
            }
        }

        public TestTempChannel()
        {
            fMode = -1;
        }

        public override string ReadLine()
        {
            if (fMode == 1) {
                fMode = -1;
                return "R:temp;sid:0000000000000000;val:25.1111;"; // temperature response
            } else {
                return string.Empty;
            }
        }

        public override void WriteLine(string text)
        {
            if (text == "Q:temp;2;") {
                fMode = 1; // temperature query
            } else {
                fMode = -1;
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
            tempService.Channel = serialChannel;

            var ledService = new LEDService(serialChannel, 1000);
            Assert.IsNotNull(ledService);
            ledService.Channel = serialChannel;
        }

        [Test]
        public void Test_TemperatureService()
        {
            var tempChannel = new TestTempChannel();
            Assert.IsNotNull(tempChannel);
            tempChannel.Open(string.Empty);

            float temperature = 0.0f;
            var tempService = new TemperatureService(tempChannel, 1000);
            Assert.IsNotNull(tempService);
            tempService.ReceivedData += delegate(object sender, DataReceivedEventArgs e) {
                var tempSvc = (TemperatureService)e.Service;
                temperature = tempSvc.Value;
            };
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
