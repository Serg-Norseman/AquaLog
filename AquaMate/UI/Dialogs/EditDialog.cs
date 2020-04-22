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
    public class EditDialog<TEntity> : CommonForm, IEditDialog<TEntity>
        where TEntity : IEntity
    {
        // TODO: to refactor!
        protected IModel fModel;
        protected TEntity fRecord;

        public EditDialog() : base()
        {
        }

        public virtual void SetContext(IModel model, TEntity record)
        {
            // TODO: to refactor!
            fModel = model;
            fRecord = record;
        }

        public virtual void SetLocale()
        {
            // dummy
        }

        public bool ShowModal()
        {
            return (base.ShowDialog() == DialogResult.OK);
        }
    }
}
