/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.UI;

namespace AquaLog.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public class SpeciesPanel : ListPanel<Species, SpeciesEditDlg>
    {
        public SpeciesPanel() : base()
        {
        }

        protected override void InitActions()
        {
            AddAction("Add", LSID.Add, "btn_rec_new.gif", AddHandler);
            AddAction("Edit", LSID.Edit, "btn_rec_edit.gif", EditHandler);
            AddAction("Delete", LSID.Delete, "btn_rec_delete.gif", DeleteHandler);
        }

        protected override void UpdateListView()
        {
            ListView.Clear();
            ListView.Columns.Add(Localizer.LS(LSID.Name), 200, HorizontalAlignment.Left);
            ListView.Columns.Add("ScientificName", 200, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Type), 100, HorizontalAlignment.Left);
            ListView.Columns.Add("Temp", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("PH", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("GH", 100, HorizontalAlignment.Left);

            var records = fModel.QuerySpecies();
            foreach (Species rec in records) {
                string strType = Localizer.LS(ALCore.SpeciesTypes[(int)rec.Type]);

                var item = new ListViewItem(rec.Name);
                item.SubItems.Add(rec.ScientificName);
                item.SubItems.Add(strType);
                item.SubItems.Add(rec.GetTempRange());
                item.SubItems.Add(rec.GetPHRange());
                item.SubItems.Add(rec.GetGHRange());
                item.Tag = rec;
                ListView.Items.Add(item);
            }
        }
    }
}
