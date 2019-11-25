/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaLog.Core.Model.Tanks;
using NUnit.Framework;

namespace AquaLog.Core
{
    [TestFixture]
    public class LocalizerTests
    {
        [Test]
        public void Test_Common()
        {
            Localizer.DefInit();

            Assert.AreEqual("File", Localizer.LS(LSID.File));

            Localizer.FindLocales();
            Assert.AreEqual(null, Localizer.GetLocaleByCode(1033));
        }
    }
}
