/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using NUnit.Framework;

namespace AquaLog.Core.Model
{
    [TestFixture]
    public class NutritionTests
    {
        [Test]
        public void Test_Common()
        {
            var nutrition = new Nutrition();
            Assert.IsNotNull(nutrition);

            nutrition.Amount = 2.5f;
            Assert.AreEqual(2.5f, nutrition.Amount);
        }
    }
}
