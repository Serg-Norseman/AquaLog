/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.UI.Dialogs;

namespace AquaMate.UI.Panels
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
            AddAction("Export", LSID.Export, "btn_excel.gif", ExportHandler);
        }

        public override void SelectionChanged(IList<Entity> records)
        {
            bool enabled = (records.Count == 1);

            SetActionEnabled("Edit", enabled);
            SetActionEnabled("Delete", enabled);
        }

        protected override void UpdateListView()
        {
            ListView.Clear();
            ListView.Columns.Add(Localizer.LS(LSID.Name), 200, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.ScientificName), 200, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.BioFamily), 200, HorizontalAlignment.Left);
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

                var item = ListView.AddItemEx(rec,
                               rec.Name,
                               rec.ScientificName,
                               rec.BioFamily,
                               strType,
                               rec.GetTempRange(),
                               rec.GetPHRange(),
                               rec.GetGHRange(),
                               ALCore.GetDecimalStr(rec.AdultSize),
                               ALCore.GetDecimalStr(rec.LifeSpan),
                               strLevel
                           );
            }
        }

        private void ExportHandler(object sender, EventArgs e)
        {
            Export();
        }
    }
}
