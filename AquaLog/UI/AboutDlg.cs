/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaLog.Core;

namespace AquaLog.UI
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class AboutDlg : Form
    {
        public AboutDlg()
        {
            InitializeComponent();

            btnClose.Image = ALCore.LoadResourceImage("btn_accept.gif");

            Text = Localizer.LS(LSID.About);
            btnClose.Text = "Close";
            lblProduct.Text = ALCore.AppName;
            lblVersion.Text = @"Version " + ALCore.GetAppVersion();
            lblCopyright.Text = ALCore.GetAppCopyright();
        }

        private void LabelMail_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl != null) {
                ALCore.LoadExtFile(lbl.Text);
            }
        }
    }
}
