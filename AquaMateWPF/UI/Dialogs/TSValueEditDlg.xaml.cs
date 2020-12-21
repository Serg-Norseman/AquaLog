/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System.Windows;
using AquaMate.Core;
using AquaMate.TSDB;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TSValueEditDlg : EditDialog, ITSValueEditorView
    {
        private readonly TSValueEditorPresenter fPresenter;

        public TSValueEditDlg()
        {
            InitializeComponent();

            fPresenter = new TSValueEditorPresenter(this);
        }

        public override void SetLocale()
        {
            base.Title = Localizer.LS(LSID.Value);
            btnAccept.Content = Localizer.LS(LSID.Accept);
            btnCancel.Content = Localizer.LS(LSID.Cancel);

            lblTimestamp.Content = Localizer.LS(LSID.Timestamp);
            lblValue.Content = Localizer.LS(LSID.Value);
        }

        public void SetContext(IModel model, TSValue record)
        {
            fPresenter.SetContext(model, record);
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = fPresenter.ApplyChanges();
        }

        #region View interface implementation

        IDateTimeBox ITSValueEditorView.TimestampField
        {
            get { return GetControlHandler<IDateTimeBox>(dtpTimestamp); }
        }

        ITextBox ITSValueEditorView.ValueField
        {
            get { return GetControlHandler<ITextBox>(txtValue); }
        }

        #endregion
    }
}
