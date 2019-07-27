﻿/*
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

namespace AquaLog.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public class InhabitantPanel : ListBrowser
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
        }

        protected override void InitActions()
        {
            fActions.Add(new Action("Add", "btn_rec_new.gif", btnAddRecord_Click));
            fActions.Add(new Action("Edit", "btn_rec_edit.gif", btnEditRecord_Click));
            fActions.Add(new Action("Delete", "btn_rec_delete.gif", btnDeleteRecord_Click));
            fActions.Add(new Action("Transfer", null, btnTransferInhabitant_Click));
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
                //item.SubItems.Add(rec.ScientificName);

                string sx = (isAnimal) ? ((Animal)rec).Sex.ToString() : string.Empty;
                item.SubItems.Add(sx);

                item.SubItems.Add(rec.Quantity.ToString());
                item.SubItems.Add(spc.Name);

                int currAqmId = 0;
                IList<Transfer> lastTransfers = fModel.QueryLastTransfers(rec.Id, (int)ALCore.GetItemType(rec.GetSpeciesType()));
                if (lastTransfers.Count > 0) {
                    currAqmId = lastTransfers[0].TargetId;
                }
                Aquarium aqm = fModel.GetRecord<Aquarium>(currAqmId);
                string aqmName = (aqm == null) ? string.Empty : aqm.Name;
                item.SubItems.Add(aqmName);

                ListView.Items.Add(item);
            }
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
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

        private void btnEditRecord_Click(object sender, EventArgs e)
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

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            var selectedItem = ALCore.GetSelectedItem(ListView);
            if (selectedItem == null) return;

            fModel.DeleteRecord(selectedItem.Tag as Inhabitant);
            UpdateContent();
        }

        private void btnTransferInhabitant_Click(object sender, EventArgs e)
        {
            var selectedItem = ALCore.GetSelectedItem(ListView);
            if (selectedItem == null) return;

            var record = selectedItem.Tag as Inhabitant;
            if (record == null) return;

            using (var dlg = new TransferDlg()) {
                dlg.Model = fModel;
                dlg.Inhabitant = record;
                dlg.Transfer = new Transfer();
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