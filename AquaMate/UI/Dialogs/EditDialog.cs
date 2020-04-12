/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.Core.Model;
using BSLib.Design.MVP;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public class EditDialog<TEntity> : Form, ILocalizable, IEditDialog<TEntity>
        where TEntity : IEntity
    {
        // TODO: to refactor!
        protected IModel fModel;
        protected TEntity fRecord;

        private readonly ControlsManager fControlsManager;

        public EditDialog()
        {
            fControlsManager = new ControlsManager();
        }

        protected T GetControlHandler<T>(object control) where T : class, IControl
        {
            return fControlsManager.GetControlHandler<T>(control);
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
