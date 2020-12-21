/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Windows.Controls;
using AquaMate.Core;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AboutDlg : EditDialog
    {
        public AboutDlg()
        {
            InitializeComponent();

            Title = Localizer.LS(LSID.About);
            btnClose.Content = "Close";
            lblProduct.Content = ALCore.AppName;
            lblVersion.Content = @"Version " + AppHost.GetAppVersion();
            lblCopyright.Content = AppHost.GetAppCopyright();
        }

        private void LabelMail_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl != null) {
                AppHost.LoadExtFile(lbl.Content as string);
            }
        }
    }
}
