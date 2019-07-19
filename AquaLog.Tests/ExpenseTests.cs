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
    public class ExpenseTests
    {
        [Test]
        public void Test_Common()
        {
            var expense = new Expense();
            Assert.IsNotNull(expense);

            expense.Shop = "AquaShop";
            Assert.AreEqual("AquaShop", expense.Shop);
        }
    }
}
