/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Collections.Generic;

namespace AquaLog.Core
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class NavigationStack<T> where T : class
    {
        private readonly Stack<T> fStackBackward;
        private readonly Stack<T> fStackForward;
        private T fCurrent;


        public T Current
        {
            get { return fCurrent; }
            set {
                if (fCurrent == value) return;

                if (fCurrent != null) {
                    fStackBackward.Push(fCurrent);
                }
                fCurrent = value;
                fStackForward.Clear();
            }
        }


        public NavigationStack()
        {
            fStackBackward = new Stack<T>();
            fStackForward = new Stack<T>();
            fCurrent = default(T);
        }

        public T Back()
        {
            if (fCurrent != null) {
                fStackForward.Push(fCurrent);
            }
            fCurrent = (fStackBackward.Count > 0) ? fStackBackward.Pop() : null;
            return fCurrent;
        }

        public T Next()
        {
            if (fCurrent != null) {
                fStackBackward.Push(fCurrent);
            }
            fCurrent = (fStackForward.Count > 0) ? fStackForward.Pop() : null;
            return fCurrent;
        }

        public void Clear()
        {
            fStackBackward.Clear();
            fStackForward.Clear();
            fCurrent = null;
        }

        public bool CanBackward()
        {
            return fStackBackward.Count > 0;
        }

        public bool CanForward()
        {
            return fStackForward.Count > 0;
        }
    }
}
