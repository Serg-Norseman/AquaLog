/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AquaLog.Components;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;
using AquaLog.UI;

namespace AquaLog.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public class InhabitantPanel : ListPanel
    {
        private ColumnHeader fSexColumn;
        protected SpeciesType fType;


        public InhabitantPanel() : base()
        {
            ListView.Columns.Add("Name", 200, HorizontalAlignment.Left);
            fSexColumn = ListView.Columns.Add("Sex", 50, HorizontalAlignment.Left);
            ListView.Columns.Add("Qty", 50, HorizontalAlignment.Right);
            ListView.Columns.Add("Species", 150, HorizontalAlignment.Left);
            ListView.Columns.Add("Current Aquarium", 150, HorizontalAlignment.Left);
            ListView.Columns.Add("Introduction date", 150, HorizontalAlignment.Left);
            ListView.Columns.Add("Temp", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("PH", 100, HorizontalAlignment.Left);
            ListView.Columns.Add("GH", 100, HorizontalAlignment.Left);
        }

        protected override void InitActions()
        {
            fActions.Add(new UserAction("Add", "btn_rec_new.gif", AddHandler));
            fActions.Add(new UserAction("Edit", "btn_rec_edit.gif", EditHandler));
            fActions.Add(new UserAction("Delete", "btn_rec_delete.gif", DeleteHandler));
            fActions.Add(new UserAction("Transfer", null, TransferInhabitantHandler));
        }

        public override void UpdateContent()
        {
            ListView.Items.Clear();
            if (fModel == null) return;

            bool isAnimal = (fType != SpeciesType.Plant);
            fSexColumn.Width = (isAnimal) ? 50 : 0;

            IEnumerable<Inhabitant> records = null;
            switch (fType) {
                case SpeciesType.Fish:
                    records = fModel.QueryFishes();
                    break;
                case SpeciesType.Invertebrate:
                    records = fModel.QueryInvertebrates();
                    break;
                case SpeciesType.Plant:
                    records = fModel.QueryPlants();
                    break;
            }

            foreach (Inhabitant rec in records) {
                Species spc = fModel.GetRecord<Species>(rec.SpeciesId);

                var item = new ListViewItem(rec.Name);
                item.Tag = rec;

                string sx = (isAnimal) ? ((Animal)rec).Sex.ToString() : string.Empty;
                item.SubItems.Add(sx);

                item.SubItems.Add(fModel.QueryInhabitantsCount(rec.Id, ALCore.GetItemType(rec.GetSpeciesType())).ToString());
                item.SubItems.Add(spc.Name);

                int currAqmId = 0;
                DateTime intrDate = ALCore.ZeroDate;
                IList<Transfer> lastTransfers = fModel.QueryLastTransfers(rec.Id, (int)ALCore.GetItemType(rec.GetSpeciesType()));
                if (lastTransfers.Count > 0) {
                    currAqmId = lastTransfers[0].TargetId;
                    intrDate = lastTransfers[0].Date;
                }
                Aquarium aqm = fModel.GetRecord<Aquarium>(currAqmId);
                string aqmName = (aqm == null) ? string.Empty : aqm.Name;
                item.SubItems.Add(aqmName);
                string strIntrDate = (intrDate.Equals(ALCore.ZeroDate)) ? string.Empty : ALCore.GetDateStr(intrDate);
                item.SubItems.Add(strIntrDate);

                item.SubItems.Add(spc.GetTempRange());
                item.SubItems.Add(spc.GetPHRange());
                item.SubItems.Add(spc.GetGHRange());

                ListView.Items.Add(item);
            }

            ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        protected override void AddHandler(object sender, EventArgs e)
        {
            Inhabitant record = null;
            switch (fType) {
                case SpeciesType.Fish:
                    record = new Fish();
                    break;
                case SpeciesType.Invertebrate:
                    record = new Invertebrate();
                    break;
                case SpeciesType.Plant:
                    record = new Plant();
                    break;
            }

            using (var dlg = new InhabitantEditDlg()) {
                dlg.Model = fModel;
                dlg.Inhabitant = record;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fModel.AddRecord(record);
                    UpdateContent();
                }
            }
        }

        protected override void EditHandler(object sender, EventArgs e)
        {
            var selectedItem = ALCore.GetSelectedItem(ListView);
            if (selectedItem == null) return;

            var record = selectedItem.Tag as Inhabitant;
            if (record == null) return;

            using (var dlg = new InhabitantEditDlg()) {
                dlg.Model = fModel;
                dlg.Inhabitant = record;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fModel.UpdateRecord(record);
                    UpdateContent();
                }
            }
        }

        protected override void DeleteHandler(object sender, EventArgs e)
        {
            var selectedItem = ALCore.GetSelectedItem(ListView);
            if (selectedItem == null) return;

            fModel.DeleteRecord(selectedItem.Tag as Inhabitant);
            UpdateContent();
        }

        private void TransferInhabitantHandler(object sender, EventArgs e)
        {
            var selectedItem = ALCore.GetSelectedItem(ListView);
            if (selectedItem == null) return;

            var record = selectedItem.Tag as Inhabitant;
            if (record == null) return;

            var transfer = new Transfer();
            transfer.ItemType = ALCore.GetItemType(record.GetSpeciesType());
            transfer.ItemId = record.Id;

            using (var dlg = new TransferEditDlg()) {
                dlg.Model = fModel;
                dlg.Transfer = transfer;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fModel.AddRecord(dlg.Transfer);
                    UpdateContent();
                }
            }
        }
    }


    public class FishPanel : InhabitantPanel
    {
        public FishPanel()
        {
            fType = SpeciesType.Fish;
        }
    }


    public class InvertebratePanel : InhabitantPanel
    {
        public InvertebratePanel()
        {
            fType = SpeciesType.Invertebrate;
        }
    }


    public class PlantPanel : InhabitantPanel
    {
        public PlantPanel()
        {
            fType = SpeciesType.Plant;
        }
    }
}
