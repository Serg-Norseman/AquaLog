/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using NUnit.Framework;

namespace AquaLog.Core
{
    [TestFixture]
    public class ALSettingsTests
    {
        [Test]
        public void Test_Common()
        {
            var instance = ALSettings.Instance;
            Assert.IsNotNull(instance);

            instance.HideClosedTanks = true;
            Assert.AreEqual(true, instance.HideClosedTanks);

            instance.ExitOnClose = true;
            Assert.AreEqual(true, instance.ExitOnClose);

            instance.CurrentLocale = 1033;
            Assert.AreEqual(1033, instance.CurrentLocale);

            instance.HideAtStartup = true;
            Assert.AreEqual(true, instance.HideAtStartup);
        }
    }
}
