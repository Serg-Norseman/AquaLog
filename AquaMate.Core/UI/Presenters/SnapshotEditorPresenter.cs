﻿/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using AquaMate.Core;
using AquaMate.Core.Model;
using AquaMate.Logging;
using BSLib;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI
{
    public interface ISnapshotEditorView : IEditorView<Snapshot>
    {
        ITextBox NameField { get; }
        IPictureBox PicBox { get; }
        IDateTimeBox TimestampField { get; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class SnapshotEditorPresenter : EditorPresenter<IModel, Snapshot, ISnapshotEditorView>
    {
        private readonly ILogger fLogger = LogManager.GetLogger(ALCore.LOG_FILE, ALCore.LOG_LEVEL, "SnapshotEditorPresenter");


        public SnapshotEditorPresenter(ISnapshotEditorView view) : base(view)
        {
        }

        public override void UpdateView()
        {
            if (fRecord != null) {
                fView.NameField.Text = fRecord.Name;
                if (fRecord.Image != null) {
                    fView.PicBox.Image = AppHost.Instance.ByteToImage(fRecord.Image);
                }

                if (!ALCore.IsZeroDate(fRecord.Timestamp)) {
                    fView.TimestampField.Value = fRecord.Timestamp;
                }
            }
        }

        public override bool ApplyChanges()
        {
            try {
                fRecord.Name = fView.NameField.Text;
                var image = fView.PicBox.Image;
                if (image != null) {
                    fRecord.Image = AppHost.Instance.ImageToByte(image);
                }
                fRecord.Timestamp = fView.TimestampField.Value;

                return true;
            } catch (Exception ex) {
                fLogger.WriteError("ApplyChanges()", ex);
                return false;
            }
        }

        public void LoadImage()
        {
            fView.PicBox.Image = AppHost.Instance.LoadImage();
        }

        public void SaveImage()
        {
            AppHost.Instance.SaveImage(fView.PicBox.Image);
        }
    }
}
