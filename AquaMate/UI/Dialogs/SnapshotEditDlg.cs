/*
 *  This file is part of the "AquaMate".
 *  Copyright (C) 2019-2020 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Windows.Forms;
using AquaMate.Core;
using AquaMate.Core.Model;
using BSLib.Design.MVP.Controls;

namespace AquaMate.UI.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SnapshotEditDlg : EditDialog<Snapshot>, ISnapshotEditorView
    {
        private readonly SnapshotEditorPresenter fPresenter;

        public SnapshotEditDlg()
        {
            InitializeComponent();

            btnAccept.Image = UIHelper.LoadResourceImage("btn_accept.gif");
            btnCancel.Image = UIHelper.LoadResourceImage("btn_cancel.gif");

            fPresenter = new SnapshotEditorPresenter(this);
        }

        public override void SetLocale()
        {
            Text = Localizer.LS(LSID.Snapshot);
            btnAccept.Text = Localizer.LS(LSID.Accept);
            btnCancel.Text = Localizer.LS(LSID.Cancel);

            lblName.Text = Localizer.LS(LSID.Name);
            lblDate.Text = Localizer.LS(LSID.Date);

            btnLoad.Text = Localizer.LS(LSID.Load);
            btnSave.Text = Localizer.LS(LSID.Save);
        }

        public override void SetContext(IModel model, Snapshot record)
        {
            base.SetContext(model, record);
            fPresenter.SetContext(model, record);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = fPresenter.ApplyChanges() ? DialogResult.OK : DialogResult.None;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = UIHelper.LoadImage();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UIHelper.SaveImage(pictureBox1.Image);
        }

        #region View interface implementation

        ITextBoxHandler ISnapshotEditorView.NameField
        {
            get { return GetControlHandler<ITextBoxHandler>(txtName); }
        }

        IPictureBoxHandler ISnapshotEditorView.PicBox
        {
            get { return GetControlHandler<IPictureBoxHandler>(pictureBox1); }
        }

        IDateTimeBoxHandler ISnapshotEditorView.TimestampField
        {
            get { return GetControlHandler<IDateTimeBoxHandler>(dtpDateTime); }
        }

        #endregion
    }
}
