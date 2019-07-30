/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AquaLog.Core;

namespace AquaLog.Components
{
    /// <summary>
    /// 
    /// </summary>
    public class Browser : Panel
    {
        protected readonly List<Action> fActions;
        protected ALModel fModel;


        public List<Action> Actions
        {
            get { return fActions; }
        }

        public ALModel Model
        {
            get { return fModel; }
            set {
                if (fModel != value) {
                    fModel = value;
                    UpdateContent();
                }
            }
        }


        public Browser()
        {
            BackColor = SystemColors.Control;
            BorderStyle = BorderStyle.FixedSingle;
            Dock = DockStyle.Fill;

            fActions = new List<Action>();
            InitActions();
        }

        protected virtual void InitActions()
        {
        }

        public virtual void UpdateContent()
        {
        }
    }
}
