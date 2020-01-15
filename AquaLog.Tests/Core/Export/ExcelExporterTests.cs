/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using NUnit.Framework;

namespace AquaLog.Core.Export
{
    [TestFixture]
    public class ExcelExporterTests
    {
        [Test]
        public void Test_Common()
        {
            ExcelExporter.Generate(null, null);
        }
    }
}
