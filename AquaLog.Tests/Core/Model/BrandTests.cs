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
    public class BrandTests
    {
        [Test]
        public void Test_Common()
        {
            var instance = new Brand();
            Assert.IsNotNull(instance);

            instance.Name = "Dennerle";
            Assert.AreEqual("Dennerle", instance.Name);

            instance.Country = "Germany";
            Assert.AreEqual("Germany", instance.Country);

            instance = new Brand("JBL");
            Assert.IsNotNull(instance);
            Assert.AreEqual("JBL", instance.ToString());
        }
    }
}
