/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Collections.Generic;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Core.Types;
using AquaMate.Logging;
using BSLib;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI
{
    public interface IInventoryEditorView : IView
    {
        ITextBoxHandler NameField { get; }
        IComboBoxHandlerEx BrandCombo { get; }
        IComboBoxHandlerEx TypeCombo { get; }
        ITextBoxHandler NoteField { get; }
        IComboBoxHandlerEx StateCombo { get; }
        IPropertyGridHandler PropsGrid { get; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class InventoryEditorPresenter : EditorPresenter<IModel, Inventory, IInventoryEditorView>
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "InventoryEditorPresenter");


        public InventoryEditorPresenter(IInventoryEditorView view) : base(view)
        {
        }

        public override void UpdateView()
        {
            if (fRecord != null) {
                fView.NameField.Text = fRecord.Name;

                fView.BrandCombo.AddRange(fModel.QueryInventoryBrands());
                fView.BrandCombo.Text = fRecord.Brand;

                fView.TypeCombo.SetSelectedTag(fRecord.Type);
                fView.NoteField.Text = fRecord.Note;

                SetState(ALCore.GetItemType(fRecord.Type), fRecord.State);
            }
        }

        public override bool ApplyChanges()
        {
            try {
                fRecord.Name = fView.NameField.Text;
                fRecord.Brand = fView.BrandCombo.Text;
                fRecord.Type = fView.TypeCombo.GetSelectedTag<InventoryType>();
                fRecord.Note = fView.NoteField.Text;
                fRecord.State = fView.StateCombo.GetSelectedTag<ItemState>();

                //fRecord.Properties = pgProps.SelectedObject as InventoryProperties;

                return true;
            } catch (Exception ex) {
                fLogger.WriteError("ApplyChanges()", ex);
                return false;
            }
        }

        private void SetState(ItemType itemType, ItemState itemState)
        {
            var namesList = ALData.GetItemStateNamesList(itemType);
            fView.StateCombo.AddRange(namesList, false);
            fView.StateCombo.SetSelectedTag<ItemState>(itemState);
        }

        public void ChangeSelectedType(InventoryType invType)
        {
            SetState(ALCore.GetItemType(invType), fRecord.State);

            if (invType >= 0) {
            }

            InventoryProperties props = fRecord.GetProperties(invType, fRecord.RawProperties);
            if (props != null) {
                props.SetPropNames();
            }
            fView.PropsGrid.SelectedObject = props;
        }
    }
}
