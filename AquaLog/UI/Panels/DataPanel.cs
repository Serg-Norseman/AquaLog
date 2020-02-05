﻿/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Logging;
using AquaLog.UI.Components;
using BSLib;

namespace AquaLog.UI.Panels
{
    /// <summary>
    /// 
    /// </summary>
    public class DataPanel : Panel, ILocalizable
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "DataPanel");

        private readonly List<UserAction> fActions;
        protected IBrowser fBrowser;
        protected ALModel fModel;


        public List<UserAction> Actions
        {
            get { return fActions; }
        }

        public IBrowser Browser
        {
            get { return fBrowser; }
            set { fBrowser = value; }
        }

        public ALModel Model
        {
            get { return fModel; }
            set {
                if (fModel != value) {
                    fModel = value;
                }
            }
        }


        public DataPanel()
        {
            BackColor = SystemColors.Control;
            BorderStyle = BorderStyle.FixedSingle;
            Dock = DockStyle.Fill;

            fActions = new List<UserAction>();
        }

        public virtual void SetLocale()
        {
        }

        protected void ClearActions()
        {
            fActions.Clear();
        }

        protected virtual void InitActions()
        {
        }

        protected virtual void UpdateContent()
        {
        }

        public virtual void SelectionChanged(IList<Entity> records)
        {
        }

        public void UpdateView()
        {
            try {
                SetLocale();

                ClearActions();
                InitActions();

                UpdateContent();
            } catch (Exception ex) {
                fLogger.WriteError("UpdateView()", ex);
            }
        }

        public virtual void SetExtData(object extData)
        {
        }

        public void AddAction(string actionName, LSID btnText, string imageName, EventHandler clickHandler)
        {
            fActions.Add(new UserAction(actionName, btnText, imageName, clickHandler));
        }

        public void AddMultiSelector(string actionName, string[] choices, EventHandler changeHandler)
        {
            fActions.Add(new UserAction(actionName, choices, true, changeHandler));
        }

        public void AddSingleSelector(string actionName, string[] choices, EventHandler changeHandler)
        {
            fActions.Add(new UserAction(actionName, choices, false, changeHandler));
        }

        public void SetActionEnabled(string actionName, bool enabled)
        {
            foreach (var act in fActions) {
                if (act.Name == actionName) {
                    try {
                        if (act.Control != null) {
                            act.Control.Enabled = enabled;
                        }
                    } catch {
                    }
                    return;
                }
            }
        }
    }
}
