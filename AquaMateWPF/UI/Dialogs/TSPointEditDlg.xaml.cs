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
    public partial class TSPointEditDlg : EditDialog, ITSPointEditorView
    {
        private readonly TSPointEditorPresenter fPresenter;

        public TSPointEditDlg()
        {
            InitializeComponent();

            fPresenter = new TSPointEditorPresenter(this);
        }

        public override void SetLocale()
        {
            base.Title = Localizer.LS(LSID.TSDBPoint);
            btnAccept.Content = Localizer.LS(LSID.Accept);
            btnCancel.Content = Localizer.LS(LSID.Cancel);

            lblName.Content = Localizer.LS(LSID.Name);
            lblUoM.Content = Localizer.LS(LSID.Unit);
            lblMin.Content = Localizer.LS(LSID.Min);
            lblMax.Content = Localizer.LS(LSID.Max);
            lblDeviation.Content = Localizer.LS(LSID.Deviation);
        }

        public void SetContext(IModel model, TSPoint record)
        {
            fPresenter.SetContext(model, record);
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = fPresenter.ApplyChanges();
        }

        #region View interface implementation

        ITextBox ITSPointEditorView.NameField
        {
            get { return GetControlHandler<ITextBox>(txtName); }
        }

        ITextBox ITSPointEditorView.MeasureUnitField
        {
            get { return GetControlHandler<ITextBox>(txtUoM); }
        }

        ITextBox ITSPointEditorView.MinField
        {
            get { return GetControlHandler<ITextBox>(txtMin); }
        }

        ITextBox ITSPointEditorView.MaxField
        {
            get { return GetControlHandler<ITextBox>(txtMax); }
        }

        ITextBox ITSPointEditorView.DeviationField
        {
            get { return GetControlHandler<ITextBox>(txtDeviation); }
        }

        ITextBox ITSPointEditorView.SIDField
        {
            get { return GetControlHandler<ITextBox>(txtSID); }
        }

        #endregion
    }
}
