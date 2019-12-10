/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

namespace AquaLog.UI.Components
{
    /// <summary>
    /// 
    /// </summary>
    public class ComboItem<T>
    {
        public readonly string Text;
        public readonly T Tag;

        public ComboItem(string text, T tag)
        {
            Text = text;
            Tag = tag;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
