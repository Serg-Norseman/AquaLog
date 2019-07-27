/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

namespace AquaLog.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public class ComboItem
    {
        public readonly string Text;
        public readonly object Tag;

        public ComboItem(string text)
        {
            Text = text;
        }

        public ComboItem(string text, object tag)
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
