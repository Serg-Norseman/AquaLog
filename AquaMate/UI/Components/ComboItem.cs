/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

namespace AquaMate.UI.Components
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
