/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Core.Types;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class TransfersViewDlg : Form
    {
        public TransfersViewDlg()
        {
            InitializeComponent();

            btnClose.Image = UIHelper.LoadResourceImage("btn_accept.gif");

            SetLocale();
        }

        public TransfersViewDlg(IModel model, ItemType itemType, int itemId) : this()
        {
            UpdateLV(model, itemType, itemId);
        }

        public void SetLocale()
        {
            Text = Localizer.LS(LSID.Transfers);
            btnClose.Text = "Close";
        }

        private void UpdateLV(IModel model, ItemType itemType, int itemId)
        {
            listView.BeginUpdate();

            listView.Clear();
            listView.Columns.Add(Localizer.LS(LSID.Date), 80, HorizontalAlignment.Left);
            listView.Columns.Add(Localizer.LS(LSID.Type), 80, HorizontalAlignment.Left);
            listView.Columns.Add(Localizer.LS(LSID.SourceTank), 80, HorizontalAlignment.Left);
            listView.Columns.Add(Localizer.LS(LSID.TargetTank), 80, HorizontalAlignment.Left);
            listView.Columns.Add(Localizer.LS(LSID.Quantity), 80, HorizontalAlignment.Right);
            listView.Columns.Add(Localizer.LS(LSID.UnitPrice), 80, HorizontalAlignment.Right);
            listView.Columns.Add(Localizer.LS(LSID.Shop), 180, HorizontalAlignment.Left);
            listView.Columns.Add(Localizer.LS(LSID.Cause), 80, HorizontalAlignment.Left);

            Font defFont = listView.Font;
            Font boldFont = new Font(defFont, FontStyle.Bold);

            var records = model.QueryTransfers(itemId, (int)itemType);
            foreach (Transfer rec in records) {
                Aquarium aqmSour = model.Cache.Get<Aquarium>(ItemType.Aquarium, rec.SourceId);
                Aquarium aqmTarg = model.Cache.Get<Aquarium>(ItemType.Aquarium, rec.TargetId);

                var itemRec = model.GetRecord(rec.ItemType, rec.ItemId);
                string itName = (itemRec == null) ? string.Empty : itemRec.ToString();
                string strType = Localizer.LS(ALData.TransferTypes[(int)rec.Type]);

                var item = listView.AddItemEx(rec,
                               ALCore.GetDateStr(rec.Timestamp),
                               strType,
                               (aqmSour == null) ? string.Empty : aqmSour.Name,
                               (aqmTarg == null) ? string.Empty : aqmTarg.Name,
                               rec.Quantity.ToString(),
                               ALCore.GetDecimalStr(rec.UnitPrice),
                               rec.Shop,
                               rec.Cause
                           );

                if (itemType == ItemType.Aquarium) {
                    item.Font = boldFont;
                }

                switch (rec.Type) {
                    case TransferType.Sale:
                        item.ForeColor = Color.DimGray;
                        break;

                    case TransferType.Death:
                    case TransferType.Exclusion:
                        item.ForeColor = Color.Gray;
                        break;
                }
            }

            listView.EndUpdate();
        }
    }
}
