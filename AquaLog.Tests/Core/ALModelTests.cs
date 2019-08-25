/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaLog.Core.Model;
using NUnit.Framework;

namespace AquaLog.Core
{
    [TestFixture]
    public class ALModelTests
    {
        [Test]
        public void Test_ctor()
        {
            var instance = new ALModel();
            Assert.IsNotNull(instance);
        }

        [Test]
        public void Test_CleanSpace()
        {
            var instance = new ALModel();
            instance.CleanSpace();
        }

        [Test]
        public void Test_AddRecord()
        {
            var instance = new ALModel();

            var aqm = new Aquarium("test aquarium");

            instance.AddRecord(aqm);
            Assert.IsNotNull(instance.GetRecord<Aquarium>(aqm.Id));
        }

        [Test]
        public void Test_UpdateRecord()
        {
            var instance = new ALModel();

            var aqm = new Aquarium("test aquarium");
            instance.AddRecord(aqm);
            aqm = instance.GetRecord<Aquarium>(aqm.Id);
            Assert.AreEqual("test aquarium", aqm.Name);

            aqm.Name = "test2";
            instance.UpdateRecord(aqm);
            var aqm2 = instance.GetRecord<Aquarium>(aqm.Id);
            Assert.AreEqual("test2", aqm2.Name);
        }
    }
}
