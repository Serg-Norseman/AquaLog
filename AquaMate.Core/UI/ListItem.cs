/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using BSLib.Design.Graphics;

namespace AquaMate.UI
{
    /// <summary>
    /// 
    /// </summary>
    public class ListItem<T>
    {
        public readonly string Text;
        public readonly T Tag;
        public readonly IImage Image;

        public ListItem(string text, T tag)
        {
            Text = text;
            Tag = tag;
        }

        public ListItem(string text, T tag, IImage image)
        {
            Text = text;
            Tag = tag;
            Image = image;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
