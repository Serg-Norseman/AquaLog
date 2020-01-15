﻿/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using NUnit.Framework;

namespace AquaLog.Core.Model
{
    [TestFixture]
    public class MaintenanceTests
    {
        [Test]
        public void Test_Common()
        {
            var maintenance = new Maintenance();
            Assert.IsNotNull(maintenance);

            maintenance.Value = 2.5;
            Assert.AreEqual(2.5, maintenance.Value);
        }
    }
}
