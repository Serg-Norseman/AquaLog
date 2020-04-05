/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.Core.Model;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public class EditDialog<T> : Form, IEditDialog<T> where T : Entity
    {
        protected ALModel fModel;
        protected T fRecord;


        public ALModel Model
        {
            get { return fModel; }
            set { fModel = value; }
        }

        public T Record
        {
            get { return fRecord; }
            set {
                if (fRecord != value) {
                    fRecord = value;
                    UpdateView();
                }
            }
        }


        public EditDialog()
        {
        }

        public virtual void SetLocale()
        {
            // dummy
        }

        protected virtual void UpdateView()
        {
            // dummy
        }

        protected virtual void ApplyChanges()
        {
            // dummy
        }

        public bool ShowDialog()
        {
            return (base.ShowDialog() == DialogResult.OK);
        }
    }
}
