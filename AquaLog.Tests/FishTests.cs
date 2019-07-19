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
    public class FishTests
    {
        [Test]
        public void Test_Common()
        {
            var fish = new Fish();
            Assert.IsNotNull(fish);

            fish.Name = "Siamese fighting fish";
            Assert.AreEqual("Siamese fighting fish", fish.Name);
        }
    }
}
