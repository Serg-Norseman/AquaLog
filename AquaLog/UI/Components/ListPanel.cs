/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;

namespace AquaLog.Components
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

            fListView = new ListView();
            fListView.Dock = DockStyle.Fill;
            fListView.HideSelection = false;
            fListView.LabelEdit = false;
            fListView.FullRowSelect = true;
            fListView.View = View.Details;
            fListView.DoubleClick += EditHandler;
            Controls.Add(fListView);
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
}
