﻿/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using AquaLog.Core.Model;
using AquaLog.Core.Types;
using AquaLog.TSDB;
using BSLib;
using SQLite;

namespace AquaLog.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class ALModel
    {
        private readonly SQLiteConnection fDB;
        private readonly EntitiesCache fCache;
        private readonly TSDatabase fTSDB;


        public EntitiesCache Cache
        {
            get { return fCache; }
        }

        public TSDatabase TSDB
        {
            get { return fTSDB; }
        }


        public ALModel()
        {
            fTSDB = new TSDatabase();

            var databasePath = Path.Combine(ALCore.GetAppDataPath(), "ALData.db");
            fDB = new SQLiteConnection(databasePath);

            fDB.CreateTable<Aquarium>();

            fDB.CreateTable<Inhabitant>();
            fDB.CreateTable<Species>();

            fDB.CreateTable<Device>();
            fDB.CreateTable<Note>();
            fDB.CreateTable<Maintenance>();
            fDB.CreateTable<Transfer>();
            fDB.CreateTable<Nutrition>();
            fDB.CreateTable<Measure>();
            fDB.CreateTable<Schedule>();
            fDB.CreateTable<Inventory>();

            fDB.CreateTable<Snapshot>();
            fDB.CreateTable<Brand>();

            fCache = new EntitiesCache(this);
        }

        /// <summary>
        /// Cleaning waste space
        /// </summary>
        public void CleanSpace()
        {
            fDB.Execute("drop table if exists Expense");
            fDB.Execute("VACUUM;");
        }

        public void Execute(string query, params object[] args)
        {
            fDB.Execute(query, args);
        }

        public int AddRecord(Entity obj)
        {
            return fDB.Insert(obj);
        }

        public void UpdateRecord(Entity obj)
        {
            fDB.Update(obj);
        }

        public void DeleteRecord(Entity obj)
        {
            fDB.Delete(obj);
        }

        public void DeleteRecord<T>(int objId)
        {
            fDB.Delete<T>(objId);
        }

        // TODO: need to add control of keys of deleted records
        public T GetRecord<T>(int objId) where T : new()
        {
            T result;
            if (objId <= 0) {
                result = default(T);
            } else {
                try {
                    result = fDB.Get<T>(objId);
                } catch (InvalidOperationException) {
                    // record not exists
                    result = default(T);
                }
            }
            return result;
        }

        public Entity GetRecord(ItemType itemType, int itemId)
        {
            Entity result = null;
            switch (itemType) {
                case ItemType.Aquarium:
                    result = GetRecord<Aquarium>(itemId);
                    break;

                case ItemType.Fish:
                case ItemType.Invertebrate:
                case ItemType.Plant:
                case ItemType.Coral:
                    result = GetRecord<Inhabitant>(itemId);
                    break;

                case ItemType.Nutrition:
                    result = GetRecord<Nutrition>(itemId);
                    break;

                case ItemType.Device:
                    result = GetRecord<Device>(itemId);
                    break;

                case ItemType.Additive:
                case ItemType.Chemistry:
                case ItemType.Equipment:
                case ItemType.Maintenance:
                case ItemType.Furniture:
                case ItemType.Decoration:
                    result = GetRecord<Inventory>(itemId);
                    break;
            }
            return result;
        }

        public string GetRecordName(ItemType itemType, int itemId)
        {
            Entity itemRec = GetRecord(itemType, itemId);
            return (itemRec == null) ? string.Empty : itemRec.ToString();
        }

        public IList<T> QueryRecords<T>(string query, params object[] args) where T : new()
        {
            return fDB.Query<T>(query, args);
        }

        #region Aquarium functions

        public IList<Aquarium> QueryAquariums()
        {
            return fDB.Query<Aquarium>("select * from Aquarium");
        }

        public IList<QString> QueryAquariumBrands()
        {
            return fDB.Query<QString>("select distinct Brand as element from Aquarium");
        }

        public int QueryInhabitantsCount(int aquariumId)
        {
            int result = 0;
            var qv = fDB.Query<Transfer>("select * from Transfer where SourceId = ? or TargetId = ?", aquariumId, aquariumId);
            foreach (var val in qv) {
                int factor = 0;
                switch (val.Type) {
                    case TransferType.Relocation:
                        if (val.SourceId == aquariumId) {
                            factor = -1;
                        } else if (val.TargetId == aquariumId) {
                            factor = +1;
                        }
                        break;

                    case TransferType.Purchase:
                    case TransferType.Birth:
                        factor = +1;
                        break;

                    case TransferType.Sale:
                    case TransferType.Death:
                        factor = -1;
                        break;
                }

                switch (val.ItemType) {
                    case ItemType.Fish:
                    case ItemType.Invertebrate:
                    case ItemType.Plant:
                        result += ((int)val.Quantity * factor);
                        break;
                }
            }
            return result;
        }

        public int QueryInhabitantsCount(int itemId, ItemType itemType)
        {
            int result = 0;
            var qv = fDB.Query<Transfer>("select Type, Quantity from Transfer where ItemType = ? and ItemId = ?", (int)itemType, itemId);
            foreach (var val in qv) {
                int factor = 0;
                switch (val.Type) {
                    case TransferType.Relocation:
                        break;
                    case TransferType.Purchase:
                    case TransferType.Birth:
                        factor = +1;
                        break;
                    case TransferType.Sale:
                    case TransferType.Death:
                        factor = -1;
                        break;
                }
                result += ((int)val.Quantity * factor);
            }
            return result;
        }

        public void GetInhabitantDates(int recId, ItemType itemType, out DateTime inclusionDate, out DateTime exclusionDate, out int currAqmId)
        {
            currAqmId = -1;
            inclusionDate = ALCore.ZeroDate;
            exclusionDate = ALCore.ZeroDate;

            IList<Transfer> transfers = QueryTransfers(recId, (int)itemType);
            foreach (var trf in transfers) {
                switch (trf.Type) {
                    case TransferType.Relocation:
                        break;

                    case TransferType.Purchase:
                    case TransferType.Birth:
                        if (ALCore.IsZeroDate(inclusionDate)) {
                            inclusionDate = trf.Timestamp;
                        }
                        break;

                    case TransferType.Sale:
                    case TransferType.Death:
                        if (ALCore.IsZeroDate(exclusionDate)) {
                            exclusionDate = trf.Timestamp;
                        }
                        break;
                }

                if (trf.TargetId > 0) {
                    currAqmId = trf.TargetId;
                }
            }
        }

        public void GetItemState(int recId, ItemType itemType, out ItemState itemState, out DateTime exclusionDate)
        {
            itemState = ItemState.Unknown;
            exclusionDate = ALCore.ZeroDate;

            IList<Transfer> transfers = QueryTransfers(recId, (int)itemType);
            foreach (var trf in transfers) {
                switch (trf.Type) {
                    case TransferType.Death:
                        if (ALCore.IsZeroDate(exclusionDate)) {
                            itemState = ItemState.Dead;
                            exclusionDate = trf.Timestamp;
                        }
                        break;

                    case TransferType.Sale:
                        if (ALCore.IsZeroDate(exclusionDate)) {
                            itemState = ItemState.Sold;
                            exclusionDate = trf.Timestamp;
                        }
                        break;

                    case TransferType.Exclusion:
                        if (ALCore.IsZeroDate(exclusionDate)) {
                            switch (itemType) {
                                case ItemType.None:
                                    break;

                                case ItemType.Fish:
                                case ItemType.Invertebrate:
                                case ItemType.Plant:
                                case ItemType.Coral:
                                    itemState = ItemState.Dead;
                                    break;

                                case ItemType.Nutrition:
                                case ItemType.Additive:
                                case ItemType.Chemistry:
                                    itemState = ItemState.Finished;
                                    break;

                                case ItemType.Aquarium:
                                case ItemType.Device:
                                case ItemType.Equipment:
                                case ItemType.Maintenance:
                                case ItemType.Furniture:
                                case ItemType.Decoration:
                                    itemState = ItemState.Broken;
                                    break;
                            }

                            exclusionDate = trf.Timestamp;
                        }
                        break;
                }
            }
        }

        public string GetItemStateStr(int recId, ItemType itemType, out ItemState itemState)
        {
            DateTime exclusionDate;
            GetItemState(recId, itemType, out itemState, out exclusionDate);
            string strState;
            if (itemState == ItemState.Unknown) {
                strState = string.Empty;
            } else {
                string strExclusDate = ALCore.IsZeroDate(exclusionDate) ? "-" : ALCore.GetDateStr(exclusionDate);
                strState = string.Format("{0} [{1}]", Localizer.LS(ALData.ItemStates[(int)itemState]), strExclusDate);
            }
            return strState;
        }

        #endregion

        #region Inhabitant functions

        public IList<Inhabitant> QueryInhabitants()
        {
            return fDB.Query<Inhabitant>("select * from Inhabitant");
        }

        public IList<Inhabitant> QueryInhabitants(Aquarium aquarium)
        {
            return fDB.Query<Inhabitant>("select inh.Id, inh.SpeciesId, inh.Sex, inh.Name from Inhabitant inh, Transfer tran where (inh.Id = tran.ItemId and tran.ItemType in (2, 3, 4, 5) and TargetId = ?)", aquarium.Id);
        }

        #endregion

        #region Species functions

        public IList<Species> QuerySpecies()
        {
            return fDB.Query<Species>("select * from Species");
        }

        public IList<Species> QuerySpecies(int type)
        {
            return fDB.Query<Species>("select * from Species where [Type] = ?", type);
        }

        public SpeciesType GetSpeciesType(int speciesId)
        {
            var species = fDB.Query<Species>("select * from Species where [Id] = ?", speciesId);
            return (species != null && species.Count > 0) ? species[0].Type : SpeciesType.Fish;
        }

        public IList<QString> QuerySpeciesFamilies()
        {
            return fDB.Query<QString>("select distinct BioFamily as element from Species");
        }

        #endregion

        #region Device functions

        public IList<Device> QueryDevices()
        {
            return fDB.Query<Device>("select * from Device");
        }

        public IList<Device> QueryDevices(Aquarium aquarium)
        {
            return fDB.Query<Device>("select * from Device where AquariumId = ?", aquarium.Id);
        }

        public IList<QString> QueryDeviceBrands()
        {
            return fDB.Query<QString>("select distinct Brand as element from Device");
        }

        #endregion

        #region Inventory functions

        public IList<Inventory> QueryInventory()
        {
            return fDB.Query<Inventory>("select * from Inventory");
        }

        public IList<QString> QueryInventoryBrands()
        {
            return fDB.Query<QString>("select distinct Brand as element from Inventory");
        }

        #endregion

        #region Maintenance functions

        public IList<Maintenance> QueryMaintenances()
        {
            return fDB.Query<Maintenance>("select * from Maintenance order by [Timestamp]");
        }

        public IList<Maintenance> QueryMaintenances(int aquariumId)
        {
            return fDB.Query<Maintenance>("select * from Maintenance where (AquariumId = ?) order by [Timestamp]", aquariumId);
        }

        public IList<Maintenance> QueryWaterChanges(int aquariumId)
        {
            return fDB.Query<Maintenance>("select * from Maintenance where (AquariumId = ? and Type between 0 and 3) order by [Timestamp]", aquariumId);
        }

        public double GetWaterVolume(int aquariumId)
        {
            double result = 0.0d;

            var records = QueryWaterChanges(aquariumId);
            foreach (Maintenance rec in records) {
                if (rec.Type == MaintenanceType.Restart) {
                    result = rec.Value;
                } else {
                    int idx = (int)rec.Type;
                    int factor = ALData.WaterChangeFactors[idx];
                    result += (rec.Value * factor);
                }
            }

            return result;
        }

        public double GetAverageWaterChangeInterval(int aquariumId)
        {
            double result = 0.0d;
            int count = 0;

            DateTime dtPrev = ALCore.ZeroDate;
            var records = QueryWaterChanges(aquariumId);
            foreach (Maintenance rec in records) {
                if (!ALCore.IsZeroDate(dtPrev)) {
                    int days = (rec.Timestamp.Date - dtPrev).Days;
                    result += days;
                    count += 1;
                }
                dtPrev = rec.Timestamp.Date;
            }

            return result / count;
        }

        public double GetLastWaterChangeInterval(int aquariumId)
        {
            DateTime dtPrev = ALCore.ZeroDate;
            var records = QueryWaterChanges(aquariumId);
            foreach (Maintenance rec in records) {
                dtPrev = rec.Timestamp.Date;
            }
            return (DateTime.Now.Date - dtPrev).Days;
        }

        #endregion

        #region Schedule functions

        public IList<Schedule> QuerySchedule()
        {
            return fDB.Query<Schedule>("select * from Schedule order by [Timestamp]");
        }

        #endregion

        #region Transfer functions

        public IList<Transfer> QueryTransfers()
        {
            return fDB.Query<Transfer>("select * from Transfer order by [Timestamp]");
        }

        public IList<Transfer> QueryTransfers(int aquariumId)
        {
            return fDB.Query<Transfer>("select * from Transfer where (SourceId = ? or TargetId = ?) order by [Timestamp]", aquariumId, aquariumId);
        }

        public IList<Transfer> QueryTransfers(int itemId, int itemType)
        {
            return fDB.Query<Transfer>("select * from Transfer where (ItemId = ? and ItemType = ?) order by [Timestamp]", itemId, itemType);
        }

        public IList<Transfer> QueryLastTransfers(int itemId, int itemType)
        {
            return fDB.Query<Transfer>("select * from Transfer where (ItemId = ? and ItemType = ?) order by [Timestamp] desc", itemId, itemType);
        }

        #endregion

        #region Note functions

        public IList<Note> QueryNotes()
        {
            return fDB.Query<Note>("select * from Note order by [Timestamp]");
        }

        public IList<Note> QueryNotes(int aquariumId)
        {
            return fDB.Query<Note>("select * from Note where (AquariumId = ?) order by [Timestamp]", aquariumId);
        }

        #endregion

        #region Measure functions

        public IList<Measure> QueryMeasures()
        {
            return fDB.Query<Measure>("select * from Measure order by [Timestamp]");
        }

        public IList<Measure> QueryMeasures(int aquariumId)
        {
            return fDB.Query<Measure>("select * from Measure where AquariumId = ? order by [Timestamp]", aquariumId);
        }

        public QDecimal QueryLastMeasure(Aquarium aquarium, string field)
        {
            string query = string.Format("select [{0}] as value from Measure where AquariumId = {1} and [{2}] <> 0.00000 order by [Timestamp] desc limit 1", field, aquarium.Id, field);
            List<QDecimal> list = fDB.Query<QDecimal>(query);
            return (list != null && list.Count > 0) ? list[0] : null;
        }

        public double GetCurrentMeasureValue(Aquarium aquarium, string field)
        {
            QDecimal measure = QueryLastMeasure(aquarium, field);
            double mVal = (measure != null) ? measure.value : double.NaN;
            return mVal;
        }

        public List<MeasureValue> CollectData(Aquarium aquarium)
        {
            List<MeasureValue> measures = new List<MeasureValue>();

            PrepareValue(aquarium, measures, "Temperature", "T", "°C", null);
            double NO3 = PrepareValue(aquarium, measures, "NO3", "NO3", "mg/l", ALData.NO3Ranges);
            PrepareValue(aquarium, measures, "NO2", "NO2", "mg/l", ALData.NO2Ranges);
            PrepareValue(aquarium, measures, "Cl2", "Cl2", "mg/l", ALData.Cl2Ranges);
            PrepareValue(aquarium, measures, "GH", "GH", "°d", ALData.GHRanges);
            PrepareValue(aquarium, measures, "KH", "KH", "°d", ALData.KHRanges);
            PrepareValue(aquarium, measures, "pH", "pH", "", ALData.pHRanges);
            PrepareValue(aquarium, measures, "CO2", "CO2", "", ALData.CO2Ranges);

            PrepareValue(aquarium, measures, "NH", "NHtot", "", null);
            PrepareValue(aquarium, measures, "NH3", "NH3", "", ALData.NH3Ranges);
            PrepareValue(aquarium, measures, "NH4", "NH4", "", null);

            double PO4 = PrepareValue(aquarium, measures, "PO4", "PO4", "", ALData.PO4Ranges);

            double redfield = (!double.IsNaN(PO4) && !DoubleHelper.Equals(PO4, 0.0001, 0.0001)) ? ALData.CalcRedfield(NO3, PO4) : double.NaN;
            PrepareValue(measures, redfield, "Redfield", "", ALData.RedfieldRanges);

            return measures;
        }

        private double PrepareValue(Aquarium aquarium, IList<MeasureValue> measures, string field, string sign, string uom, ValueRange[] ranges)
        {
            if (aquarium == null) return double.NaN;

            QDecimal measure = QueryLastMeasure(aquarium, field);
            double mVal = (measure != null) ? measure.value : double.NaN;

            PrepareValue(measures, mVal, sign, uom, ranges);

            return mVal;
        }

        private void PrepareValue(IList<MeasureValue> measures, double mVal, string sign, string uom, ValueRange[] ranges)
        {
            string strVal = !double.IsNaN(mVal) ? ALCore.GetDecimalStr(mVal) : string.Empty;
            string text = string.Format("{0}={1} {2}", sign, strVal, uom);

            Color color = Color.Black;
            ValueRange bounds = CheckValue(mVal, ranges);
            if (bounds != null) {
                color = bounds.Color;
            }

            var tval = new MeasureValue() {
                Name = sign,
                Value = mVal,
                Unit = uom,
                ValText = strVal,
                Text = text,
                Color = color,
                Ranges = ranges
            };
            measures.Add(tval);
        }

        private double FindMeasure(IList<MeasureValue> measures, string sign)
        {
            foreach (MeasureValue tVal in measures) {
                if (tVal.Name == sign) {
                    return tVal.Value;
                }
            }
            return 0.0001;
        }

        public static ValueRange CheckValue(double value, ValueRange[] ranges)
        {
            if (double.IsNaN(value) || DoubleHelper.Equals(value, 0.0d, 0.0000000001d) || ranges == null) {
                return null;
            }

            foreach (var bounds in ranges) {
                if (value >= bounds.Min && value <= bounds.Max) {
                    return bounds;
                }
            }

            return null;
        }

        #endregion

        #region Nutrition functions

        public IList<Nutrition> QueryNutritions()
        {
            return fDB.Query<Nutrition>("select * from Nutrition");
        }

        public IList<Nutrition> QueryNutritions(Aquarium aquarium)
        {
            return fDB.Query<Nutrition>("select * from Nutrition where AquariumId = ?", aquarium.Id);
        }

        public IList<QString> QueryNutritionBrands()
        {
            return fDB.Query<QString>("select distinct Brand as element from Nutrition");
        }

        #endregion

        #region Expense functions

        public IList<Transfer> QueryExpenses()
        {
            return fDB.Query<Transfer>("select Timestamp, ItemType, ItemId, Type, Quantity, UnitPrice, Shop from Transfer order by [Timestamp]");
        }

        public IList<QString> QueryShops()
        {
            return fDB.Query<QString>("select distinct Shop as element from Transfer");
        }

        #endregion

        #region Brand functions

        public IList<Brand> QueryBrands()
        {
            return fDB.Query<Brand>("select * from Brand");
        }

        public IList<QString> QueryBrandCountries()
        {
            return fDB.Query<QString>("select distinct Country as element from Brand");
        }

        #endregion

        #region Image helpers

        public static byte[] ImageToByte(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream()) {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }

        public static Image ByteToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(ms);
            return image;
        }

        #endregion

        #region Snapshot functions

        public IList<Snapshot> QuerySnapshots()
        {
            return fDB.Query<Snapshot>("select * from Snapshot");
        }

        public IList<Snapshot> QuerySnapshots(int itemId, int itemType)
        {
            return fDB.Query<Snapshot>("select * from Snapshot where (ItemId = ? and ItemType = ?) order by [Timestamp]", itemId, itemType);
        }

        #endregion
    }
}
