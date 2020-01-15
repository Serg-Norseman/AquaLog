﻿/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaLog.Core.Types;
using NUnit.Framework;

namespace AquaLog.Core.Model
{
    [TestFixture]
    public class SnapshotTests
    {
        [Test]
        public void Test_Common()
        {
            var snapshot = new Snapshot();
            Assert.IsNotNull(snapshot);

            snapshot.Name = "snapshot";
            Assert.AreEqual("snapshot", snapshot.Name);
            Assert.AreEqual("snapshot", snapshot.ToString());

            snapshot.Image = null;
            Assert.AreEqual(null, snapshot.Image);

            snapshot.Timestamp = ALCore.ZeroDate;
            Assert.AreEqual(ALCore.ZeroDate, snapshot.Timestamp);

            snapshot.ItemType = ItemType.Maintenance;
            Assert.AreEqual(ItemType.Maintenance, snapshot.ItemType);
        }
    }
}
