/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using AquaMate.Core;
using AquaMate.Core.Model;
using NSubstitute;
using NUnit.Framework;

namespace AquaMate.UI
{
    [TestFixture]
    public class UINewTests
    {
        [Test]
        public void Test_BrandEditorPresenter_Common()
        {
            var view = Substitute.For<IBrandEditorView>();
            var model = new ALModel();
            var record = new Brand();

            var presenter = new BrandEditorPresenter(view);
            presenter.SetContext(model, record);
            Assert.IsTrue(presenter.ApplyChanges());
        }
    }
}
