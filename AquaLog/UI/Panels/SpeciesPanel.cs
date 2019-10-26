/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.UI.Dialogs;

namespace AquaLog.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class SpeciesPanel : ListPanel<Species, SpeciesEditDlg>
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
            ListView.Columns.Add(Localizer.LS(LSID.AdultSize), 100, HorizontalAlignment.Right);
            ListView.Columns.Add(Localizer.LS(LSID.LifeSpan), 100, HorizontalAlignment.Right);
            ListView.Columns.Add(Localizer.LS(LSID.SwimLevel), 100, HorizontalAlignment.Right);

            var records = fModel.QuerySpecies();
            foreach (Species rec in records) {
                string strType = Localizer.LS(ALData.SpeciesTypes[(int)rec.Type]);
                string strLevel = Localizer.LS(ALData.SwimLevels[(int)rec.SwimLevel]);

                var item = new ListViewItem(rec.Name);
                item.SubItems.Add(rec.ScientificName);
                item.SubItems.Add(strType);
                item.SubItems.Add(rec.GetTempRange());
                item.SubItems.Add(rec.GetPHRange());
                item.SubItems.Add(rec.GetGHRange());
                item.SubItems.Add(ALCore.GetDecimalStr(rec.AdultSize));
                item.SubItems.Add(ALCore.GetDecimalStr(rec.LifeSpan));
                item.SubItems.Add(strLevel);
                item.Tag = rec;
                ListView.Items.Add(item);
            }
        }
    }
}
