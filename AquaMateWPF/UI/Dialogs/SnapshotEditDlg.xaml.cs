/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Windows;
using AquaMate.Core;
using AquaMate.Core.Model;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SnapshotEditDlg : EditDialog, ISnapshotEditorView
    {
        private readonly SnapshotEditorPresenter fPresenter;

        public SnapshotEditDlg()
        {
            InitializeComponent();

            fPresenter = new SnapshotEditorPresenter(this);
        }

        public override void SetLocale()
        {
            base.Title = Localizer.LS(LSID.Snapshot);
            btnAccept.Content = Localizer.LS(LSID.Accept);
            btnCancel.Content = Localizer.LS(LSID.Cancel);

            lblName.Content = Localizer.LS(LSID.Name);
            lblDate.Content = Localizer.LS(LSID.Date);

            btnLoad.Content = Localizer.LS(LSID.Load);
            btnSave.Content = Localizer.LS(LSID.Save);
        }

        public void SetContext(IModel model, Snapshot record)
        {
            fPresenter.SetContext(model, record);
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = fPresenter.ApplyChanges();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            fPresenter.LoadImage();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            fPresenter.SaveImage();
        }

        #region View interface implementation

        ITextBox ISnapshotEditorView.NameField
        {
            get { return GetControlHandler<ITextBox>(txtName); }
        }

        IPictureBox ISnapshotEditorView.PicBox
        {
            get { return /*GetControlHandler<IPictureBox>(pictureBox1)*/null; }
        }

        IDateTimeBox ISnapshotEditorView.TimestampField
        {
            get { return GetControlHandler<IDateTimeBox>(dtpDateTime); }
        }

        #endregion
    }
}
