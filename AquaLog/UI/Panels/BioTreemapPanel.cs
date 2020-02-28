/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;
using BSLib;
using BSLib.DataViz.TreeMap;

namespace AquaLog.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class BioTreemapPanel : DataPanel
    {
        private static DataTable fCSVData;

        private readonly TreeMapViewer fDataMap;


        static BioTreemapPanel()
        {
            string taxFile = ALCore.GetAppPath() + @"common\taxonomy.csv";
            fCSVData = CSVReader.ReadCSVFile(taxFile, Encoding.GetEncoding(1251), true);
        }

        public BioTreemapPanel()
        {
            fDataMap = new TreeMapViewer();
            fDataMap.Dock = DockStyle.Fill;
            fDataMap.MouseoverHighlight = true;
            fDataMap.OnHintRequest += OnHintRequest;
            fDataMap.MouseMove += OnMouseMove;
            Controls.Add(fDataMap);
        }

        private static DataRow SearchFamily(string family)
        {
            if (fCSVData != null) {
                foreach (DataRow row in fCSVData.Rows) {
                    if (string.Equals(row[4].ToString(), family, StringComparison.OrdinalIgnoreCase)) {
                        return row;
                    }
                }
            }
            return null;
        }

        private MapItem GetTaxItem(DataRow taxRow)
        {
            MapItem mapItem = null;
            MapItem parent = null;
            var subItems = fDataMap.Model.Items;
            var items = taxRow.ItemArray;
            for (int i = 0; i < items.Length; i++) {
                string itName = items[i].ToString();
                mapItem = subItems.FirstOrDefault(mit => mit.Name == itName);
                if (mapItem == null) {
                    mapItem = fDataMap.Model.CreateItem(parent, itName, 0.0d);
                }
                subItems = mapItem.Items;
                parent = mapItem;
            }
            return mapItem;
        }

        internal override void UpdateContent()
        {
            fDataMap.Model.Items.Clear();

            var unkTax = CreateItem(null, "Unknown Taxonomy", 0.0d);

            Dictionary<string, SpeciesItem> species = new Dictionary<string, SpeciesItem>();

            IList<Inhabitant> records = fModel.QueryInhabitants();
            foreach (Inhabitant rec in records) {
                Species spc = fModel.GetRecord<Species>(rec.SpeciesId);
                if (spc == null) continue;

                SpeciesType speciesType = fModel.GetSpeciesType(rec.SpeciesId);
                ItemType itemType = ALCore.GetItemType(speciesType);
                int quantity = fModel.QueryInhabitantsCount(rec.Id, itemType);

                if (quantity != 0) {
                    string name = string.Format("{0} ({1})", spc.Name, spc.ScientificName);

                    SpeciesItem item;
                    if (!species.TryGetValue(name, out item)) {
                        item = new SpeciesItem(name, spc.BioFamily, quantity);
                        species.Add(name, item);
                    } else {
                        item.Quantity += quantity;
                    }
                }
            }

            foreach (var pair in species) {
                var item = pair.Value;
                var row = SearchFamily(item.Family);
                if (row == null) {
                    CreateItem(unkTax, item.Name, item.Quantity);
                } else {
                    var taxItem = GetTaxItem(row);
                    CreateItem(taxItem, item.Name, item.Quantity);
                }
            }

            fDataMap.UpdateView();
        }

        private MapItem CreateItem(MapItem parent, string name, double size)
        {
            var item = fDataMap.Model.CreateItem(parent, name, size) as SimpleItem;
            item.Color = Color.Silver;
            return item;
        }

        private void OnHintRequest(object sender, HintRequestEventArgs args)
        {
            args.Hint = GetFullName(args.MapItem);
        }

        private string GetFullName(MapItem item)
        {
            string result = string.Empty;

            while (item != null) {
                if (string.IsNullOrEmpty(result)) {
                    result = item.Name;
                } else {
                    result = item.Name + "\\" + result;
                }
                item = item.Parent;
            }

            return result;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            var curItem = fDataMap.CurrentItem;
        }
    }

    internal sealed class SpeciesItem
    {
        public string Name;
        public string Family;
        public int Quantity;

        public SpeciesItem(string name, string family, int quantity)
        {
            Name = name;
            Family = family;
            Quantity = quantity;
        }
    }
}
