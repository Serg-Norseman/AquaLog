/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows;
using BSLib.Design.MVP;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public class CommonForm : Window, IDisposable
    {
        private readonly ControlsManager fControlsManager;

        public CommonForm()
        {
            fControlsManager = new ControlsManager();
        }

        protected T GetControlHandler<T>(object control) where T : class, IControl
        {
            return fControlsManager.GetControlHandler<T>(control);
        }

        private bool fDisposed;

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            if (!fDisposed) {
                Dispose(true /*called by user directly*/);
                fDisposed = true;
            }

            GC.SuppressFinalize(this);
        }

        ~CommonForm()
        {
            Dispose(false /*not called by user directly*/);
        }
    }
}
