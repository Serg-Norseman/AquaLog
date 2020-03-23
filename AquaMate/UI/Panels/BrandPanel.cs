/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.UI.Dialogs;

namespace AquaMate.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class BrandPanel : ListPanel<Brand, BrandEditDlg>
    {
        public BrandPanel()
        {
        }

        protected override void UpdateListView()
        {
            ListView.Clear();
            ListView.Columns.Add(Localizer.LS(LSID.Name), 120, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Country), 120, HorizontalAlignment.Left);

            var records = fModel.QueryBrands();
            foreach (Brand rec in records) {
                var item = ListView.AddItemEx(rec,
                               rec.Name,
                               rec.Country
                           );
            }
        }

        protected override void InitActions()
        {
            AddAction("Add", LSID.Add, "btn_rec_new.gif", AddHandler);
            AddAction("Edit", LSID.Edit, "btn_rec_edit.gif", EditHandler);
            AddAction("Delete", LSID.Delete, "btn_rec_delete.gif", DeleteHandler);
        }
    }
}
