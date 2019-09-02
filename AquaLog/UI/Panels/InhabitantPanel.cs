/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;
using AquaLog.UI;

namespace AquaLog.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public class InhabitantPanel : ListPanel<Inhabitant, InhabitantEditDlg>
    {
        public InhabitantPanel() : base()
        {
        }

        protected override void InitActions()
        {
            AddAction("Add", LSID.Add, "btn_rec_new.gif", AddHandler);
            AddAction("Edit", LSID.Edit, "btn_rec_edit.gif", EditHandler);
            AddAction("Delete", LSID.Delete, "btn_rec_delete.gif", DeleteHandler);
            AddAction("Transfer", LSID.Transfer, null, TransferInhabitantHandler);
        }

        protected override void UpdateListView()
        {
            ListView.Clear();
            ListView.Columns.Add(Localizer.LS(LSID.Name), 200, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Sex), 50, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Quantity), 50, HorizontalAlignment.Right);
            ListView.Columns.Add(Localizer.LS(LSID.SpeciesS), 150, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.Aquarium), 150, HorizontalAlignment.Left);
            ListView.Columns.Add(Localizer.LS(LSID.IntroductionDate), 150, HorizontalAlignment.Left);
            ListView.Columns.Add("Temp", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("PH", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("GH", 100, HorizontalAlignment.Left);

            IEnumerable<Inhabitant> records = fModel.QueryInhabitants();
            foreach (Inhabitant rec in records) {
                Species spc = fModel.GetRecord<Species>(rec.SpeciesId);
                string sx = ALCore.IsAnimal(spc.Type) ? Localizer.LS(ALCore.SexNames[(int)rec.Sex]) : string.Empty;
                SpeciesType speciesType = fModel.GetSpeciesType(rec.SpeciesId);
                ItemType itemType = ALCore.GetItemType(speciesType);
                int currAqmId = 0;
                DateTime intrDate = ALCore.ZeroDate;
                IList<Transfer> lastTransfers = fModel.QueryLastTransfers(rec.Id, (int)itemType);
                if (lastTransfers.Count > 0) {
                    currAqmId = lastTransfers[0].TargetId;
                    intrDate = lastTransfers[0].Date;
                }
                Aquarium aqm = fModel.GetRecord<Aquarium>(currAqmId);
                string aqmName = (aqm == null) ? string.Empty : aqm.Name;
                string strIntrDate = (intrDate.Equals(ALCore.ZeroDate)) ? string.Empty : ALCore.GetDateStr(intrDate);

                var item = new ListViewItem(rec.Name);
                item.Tag = rec;
                item.SubItems.Add(sx);
                item.SubItems.Add(fModel.QueryInhabitantsCount(rec.Id, itemType).ToString());
                item.SubItems.Add(spc.Name);
                item.SubItems.Add(aqmName);
                item.SubItems.Add(strIntrDate);
                item.SubItems.Add(spc.GetTempRange());
                item.SubItems.Add(spc.GetPHRange());
                item.SubItems.Add(spc.GetGHRange());
                ListView.Items.Add(item);
            }
        }

        private void TransferInhabitantHandler(object sender, EventArgs e)
        {
            var record = ALCore.GetSelectedTag<Inhabitant>(ListView);
            if (record == null) return;

            SpeciesType speciesType = fModel.GetSpeciesType(record.SpeciesId);
            ItemType itemType = ALCore.GetItemType(speciesType);

            var transfer = new Transfer();
            transfer.ItemType = itemType;
            transfer.ItemId = record.Id;

            using (var dlg = new TransferEditDlg()) {
                dlg.Model = fModel;
                dlg.Record = transfer;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fModel.AddRecord(dlg.Record);
                    UpdateContent();
                }
            }
        }
    }
}
