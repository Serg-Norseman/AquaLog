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

namespace AquaLog.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public class SpeciesPanel : Browser
    {
        public SpeciesPanel()
        {
        }

        protected override void InitActions()
        {
            fActions.Add(new Action() {
                Name = "Add Species",
                //Click = btnAddTank_Click
            });
            fActions.Add(new Action() {
                Name = "Edit Species",
                //Click = btnEditTank_Click
            });
            fActions.Add(new Action() {
                Name = "Delete Species",
                //Click = btnDeleteTank_Click
            });
        }

        public override void UpdateLayout()
        {
            
        }
    }
}
