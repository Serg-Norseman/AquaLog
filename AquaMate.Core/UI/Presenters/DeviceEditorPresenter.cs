/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Core.Types;
using AquaMate.Logging;
using BSLib;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI
{
    public interface IDeviceEditorView : IView
    {
        IComboBox AquariumCombo { get; }
        IComboBox TSPointsCombo { get; }
        ITextBox NameField { get; }
        IComboBox BrandCombo { get; }
        ICheckBox EnabledCheck { get; }
        ICheckBox DigitalCheck { get; }
        IComboBox TypeCombo { get; }
        ITextBox PowerField { get; }
        ITextBox WorkTimeField { get; }
        ITextBox NoteField { get; }
        IComboBox StateCombo { get; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class DeviceEditorPresenter : EditorPresenter<IModel, Device, IDeviceEditorView>
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "DeviceEditorPresenter");


        public DeviceEditorPresenter(IDeviceEditorView view) : base(view)
        {
            var deviceTypesList = ALData.GetNamesList<DeviceType>(ALData.DeviceProps);
            fView.TypeCombo.AddRange<DeviceType>(deviceTypesList, true);
        }

        public override void UpdateView()
        {
            if (fRecord != null) {
                fView.AquariumCombo.AddRange(fModel.QueryAquariumsList());
                fView.AquariumCombo.SetSelectedTag(fRecord.AquariumId);

                fView.TSPointsCombo.AddRange(ALData.GetEntityNamesList(fModel.TSDB.GetPoints()));
                fView.TSPointsCombo.SetSelectedTag(fRecord.PointId);

                fView.BrandCombo.AddRange(fModel.QueryDeviceBrands(), true);
                fView.BrandCombo.Text = fRecord.Brand;

                fView.TypeCombo.SetSelectedTag(fRecord.Type);
                fView.NameField.Text = fRecord.Name;
                fView.EnabledCheck.Checked = fRecord.Enabled;
                fView.DigitalCheck.Checked = fRecord.Digital;
                fView.PowerField.SetDecimalVal(fRecord.Power);
                fView.WorkTimeField.SetDecimalVal(fRecord.WorkTime);
                fView.NoteField.Text = fRecord.Note;

                var namesList = ALData.GetItemStateNamesList(ItemType.Device);
                fView.StateCombo.AddRange(namesList, false);
                fView.StateCombo.SetSelectedTag(fRecord.State);
            }
        }

        public override bool ApplyChanges()
        {
            try {
                fRecord.AquariumId = fView.AquariumCombo.GetSelectedTag<int>();
                fRecord.PointId = fView.TSPointsCombo.GetSelectedTag<int>();
                fRecord.Name = fView.NameField.Text;
                fRecord.Brand = fView.BrandCombo.Text;
                fRecord.Enabled = fView.EnabledCheck.Checked;
                fRecord.Digital = fView.DigitalCheck.Checked;
                fRecord.Type = fView.TypeCombo.GetSelectedTag<DeviceType>();
                fRecord.Power = fView.PowerField.GetDecimalVal();
                fRecord.WorkTime = fView.WorkTimeField.GetDecimalVal();
                fRecord.Note = fView.NoteField.Text;
                fRecord.State = fView.StateCombo.GetSelectedTag<ItemState>();

                return true;
            } catch (Exception ex) {
                fLogger.WriteError("ApplyChanges()", ex);
                return false;
            }
        }

        public void ChangeSelectedType()
        {
            DeviceType deviceType = fView.TypeCombo.GetSelectedTag<DeviceType>();

            if (deviceType >= 0) {
                var props = ALData.DeviceProps[(int)deviceType];
                fView.TSPointsCombo.Enabled = props.HasMeasurements;
            }
        }
    }
}
