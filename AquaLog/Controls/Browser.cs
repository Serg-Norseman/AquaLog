/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AquaLog.Core;

namespace AquaLog.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public class Browser : FlowLayoutPanel
    {
        protected List<Action> fActions;
        private ALModel fModel;

        public ALModel Model
        {
            get { return fModel; }
            set {
                if (fModel != value) {
                    fModel = value;
                    UpdateLayout();
                }
            }
        }

        public List<Action> Actions
        {
            get { return fActions; }
        }

        public Browser()
        {
            Dock = DockStyle.Fill;
            Padding = new Padding(10);

            fActions = new List<Action>();
            InitActions();
        }

        protected virtual void InitActions()
        {
        }

        public virtual void UpdateLayout()
        {
        }
    }
}
