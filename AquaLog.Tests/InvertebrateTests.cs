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
    public class InvertebrateTests
    {
        [Test]
        public void Test_Common()
        {
            var invertebrate = new Invertebrate();
            Assert.IsNotNull(invertebrate);

            invertebrate.Name = "Spike-topped apple snail";
            Assert.AreEqual("Spike-topped apple snail", invertebrate.Name);
        }
    }
}
