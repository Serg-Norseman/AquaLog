/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Core.Types;

namespace AquaMate.UI
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBrowser
    {
        ALModel Model { get; }

        bool CheckDelete(Entity entity);
        void SetView(MainView mainView, object extData);
        void ShowItemTransfers(ItemType itemType, int itemId);
        void ShowSettings(int tabIndex = 0);
        void TransferItem(ItemType itemType, int itemId, IDataPanel view);
    }
}
