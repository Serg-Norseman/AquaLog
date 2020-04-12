﻿/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using AquaMate.Core;
using BSLib;

namespace AquaMate.UI
{
    public sealed class ALTray : BaseObject
    {
        private class TipInfo
        {
            public DateTime LastTime;
        }

        private MenuItem fAutorunItem;
        private MenuItem fAboutItem;
        private MenuItem fExitItem;
        private readonly IBrowser fMainForm;
        private readonly NotifyIcon fNotifyIcon;
        private readonly StringList fTipsList;
        private readonly System.Threading.Timer fTipsTimer;


        public ALTray(IBrowser mainForm)
        {
            fMainForm = mainForm;

            fNotifyIcon = new NotifyIcon();
            fNotifyIcon.DoubleClick += Icon_DoubleClick;
            fNotifyIcon.Icon = new Icon(UIHelper.LoadResourceStream("icon_aquamate.ico"));
            fNotifyIcon.ContextMenu = InitializeMenu();
            fNotifyIcon.Visible = true;

            fAutorunItem.Checked = UIHelper.IsStartupItem();

            fTipsList = new StringList();

            LoadSettings();
            SetLocale();

            fTipsTimer = new System.Threading.Timer(this.TimerCallback, null, 1000, 1000*60);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                fNotifyIcon.Icon = null;
                fNotifyIcon.Dispose();
                fTipsTimer.Dispose();
                fTipsList.Dispose();
            }
            base.Dispose(disposing);
        }

        private ContextMenu InitializeMenu()
        {
            var appItem = new MenuItem(ALCore.AppName, Icon_DoubleClick);
            appItem.DefaultItem = true;

            fAutorunItem = new MenuItem("Autorun", miAutorun_Click);
            fAboutItem = new MenuItem("About", miAbout_Click);
            fExitItem = new MenuItem("Exit", miExit_Click);

            MenuItem[] menuItems = new MenuItem[] {
                appItem,
                new MenuItem("-"),
                fAutorunItem,
                new MenuItem("-"),
                fAboutItem,
                fExitItem
            };

            return new ContextMenu(menuItems);
        }

        public void SetLocale()
        {
            fExitItem.Text = Localizer.LS(LSID.Exit);
            fAboutItem.Text = Localizer.LS(LSID.About);
            fAutorunItem.Text = Localizer.LS(LSID.Autorun);
        }

        private void LoadSettings()
        {
        }

        private void TimerCallback(object state)
        {
            DateTime timeNow = DateTime.Now;

            for (int i = 0; i < fTipsList.Count; i++) {
                var tipInfo = fTipsList.GetObject(i) as TipInfo;
                TimeSpan elapsedSpan = timeNow.Subtract(tipInfo.LastTime);
                if (elapsedSpan.TotalDays >= 1) {
                    tipInfo.LastTime = timeNow;

                    fNotifyIcon.BalloonTipText = fTipsList[i];
                    fNotifyIcon.ShowBalloonTip(5000);

                    break;
                }
            }
        }

        private void miAutorun_Click(object sender, EventArgs e)
        {
            fAutorunItem.Checked = fMainForm.SwitchAutorun();
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            fMainForm.ShowAbout();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Icon_DoubleClick(object sender, EventArgs e)
        {
            fMainForm.SwitchVisible();
        }
    }
}
