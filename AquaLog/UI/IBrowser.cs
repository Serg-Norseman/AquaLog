/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using AquaLog.Core;
using AquaLog.Core.Types;
using AquaLog.UI.Panels;

namespace AquaLog.UI
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBrowser
    {
        ALModel Model { get; }

        void ShowSettings(int tabIndex = 0);
        void SetView(MainView mainView, object extData);
        void TransferItem(ItemType itemType, int itemId, DataPanel view);
    }
}
