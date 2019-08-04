/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AquaLog.Core;
using AquaLog.Core.Model;
using AquaLog.Core.Types;
using AquaLog.TSDB;

namespace AquaLog.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TSValueEditDlg : Form
    {
        private TSValue fValue;

        public TSValue Value
        {
            get { return fValue; }
            set {
                if (fValue != value) {
                    fValue = value;
                    UpdateView();
                }
            }
        }


        public TSValueEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = ALCore.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = ALCore.LoadResourceImage("btn_cancel.gif");
        }

        private void UpdateView()
        {
            if (fValue != null) {
                if (!fValue.Timestamp.Equals(ALCore.ZeroDate)) {
                    dtpTimestamp.Value = fValue.Timestamp;
                }
                txtValue.Text = ALCore.GetDecimalStr(fValue.Value);
            }
        }

        private void ApplyChanges()
        {
            fValue.Timestamp = dtpTimestamp.Value;
            fValue.Value = (float)ALCore.GetDecimalVal(txtValue);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try {
                ApplyChanges();
                DialogResult = DialogResult.OK;
            } catch {
                DialogResult = DialogResult.None;
            }
        }
    }
}
