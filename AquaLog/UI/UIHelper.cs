/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Linq;
using System.Windows.Forms;
using AquaLog.Core;

namespace AquaLog.UI
{
    /// <summary>
    /// 
    /// </summary>
    public static class UIHelper
    {
        public static void FillAquariumsCombo(ComboBox comboBox, ALModel model, int selectedId)
        {
            comboBox.Items.Clear();
            var aquariums = model.QueryAquariums();
            foreach (var aqm in aquariums) {
                if (selectedId != 0 || !aqm.IsInactive()) {
                    comboBox.Items.Add(aqm);
                }
            }
            comboBox.SelectedItem = aquariums.FirstOrDefault(aqm => aqm.Id == selectedId);
        }

        public static bool ShowQuestionYN(string msg)
        {
            return MessageBox.Show(msg, ALCore.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
