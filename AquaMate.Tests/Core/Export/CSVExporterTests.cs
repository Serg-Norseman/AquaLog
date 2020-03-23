﻿/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using NUnit.Framework;

namespace AquaMate.Core.Export
{
    [TestFixture]
    public class CSVExporterTests
    {
        [Test]
        public void Test_Common()
        {
            CSVExporter.Generate(null, null);
        }
    }
}
