/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using NUnit.Framework;

namespace AquaLog.TSDB
{
    [TestFixture]
    public class TSValueTests
    {
        [Test]
        public void Test_ctor()
        {
            var instance = new TSValue();
            Assert.IsNotNull(instance);
        }

        [Test]
        public void Test_ctor2()
        {
            var instance = new TSValue(DateTime.Now, 12345f);
            Assert.IsNotNull(instance);
        }
    }
}
