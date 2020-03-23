/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Security.Permissions;
using System.Windows.Forms;

namespace AquaMate.UI.Components
{
    /// <summary>
    /// 
    /// </summary>
    public class WizardPages : TabControl
    {
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode), SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            // Hide tabs by trapping the TCM_ADJUSTRECT message
            if (m.Msg == 0x1328 && !DesignMode) {
                m.Result = (IntPtr)1;
            } else {
                base.WndProc(ref m);
            }
        }
    }
}
