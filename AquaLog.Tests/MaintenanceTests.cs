/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaLog.Core.Model;
using AquaLog.Core.Types;
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

            maintenance.Schedule = TaskSchedule.Weekly;
            Assert.AreEqual(TaskSchedule.Weekly, maintenance.Schedule);
        }
    }
}
