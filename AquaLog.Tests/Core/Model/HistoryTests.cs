/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using NUnit.Framework;

namespace AquaLog.Core.Model
{
    [TestFixture]
    public class HistoryTests
    {
        [Test]
        public void Test_Common()
        {
            var instance = new History();
            Assert.IsNotNull(instance);

            instance.Event = "event";
            Assert.AreEqual("event", instance.Event);
        }
    }
}
