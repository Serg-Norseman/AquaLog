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
    public class ListPanel : DataPanel
    {
        private readonly ListView fListView;

        public ListView ListView
        {
            get { return fListView; }
        }


        public ListPanel()
        {
            Padding = new Padding(10);

            fListView = UIHelper.CreateListView("ListView");
            fListView.DoubleClick += EditHandler;
            Controls.Add(fListView);
        }

        public override void UpdateContent()
        {
            ListView.BeginUpdate();
            ListView.Items.Clear();

            if (fModel != null) {
                UpdateListView();
                ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }

            ListView.EndUpdate();
        }

        protected virtual void UpdateListView()
        {
        }

        protected virtual void AddHandler(object sender, EventArgs e)
        {
        }

        protected virtual void EditHandler(object sender, EventArgs e)
        {
        }

        protected virtual void DeleteHandler(object sender, EventArgs e)
        {
        }
    }


    public class ListPanel<R, D> : ListPanel where R : Entity, new() where D : IEditDialog<R>, new()
    {

        protected override void AddHandler(object sender, EventArgs e)
        {
            R record = new R();

            using (var dlg = new D()) {
                dlg.Model = fModel;
                dlg.Record = record;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fModel.AddRecord(record);
                    UpdateContent();
                }
            }
        }

        protected override void EditHandler(object sender, EventArgs e)
        {
            var record = ALCore.GetSelectedTag<R>(ListView);
            if (record == null) return;

            using (var dlg = new D()) {
                dlg.Model = fModel;
                dlg.Record = record;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    fModel.UpdateRecord(record);
                    UpdateContent();
                }
            }
        }

        protected override void DeleteHandler(object sender, EventArgs e)
        {
            var record = ALCore.GetSelectedTag<R>(ListView);
            if (record == null) return;

            if (!UIHelper.ShowQuestionYN(string.Format(Localizer.LS(LSID.RecordDeleteQuery), record.ToString()))) return;

            fModel.DeleteRecord(record);
            UpdateContent();
        }
    }
}
