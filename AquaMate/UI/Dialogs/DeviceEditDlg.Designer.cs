namespace AquaMate.UI.Dialogs
{
    partial class DeviceEditDlg
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblAquarium;
        private System.Windows.Forms.ComboBox cmbAquarium;
        private System.Windows.Forms.Label lblPower;
        private System.Windows.Forms.TextBox txtPower;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.CheckBox chkDigital;
        private System.Windows.Forms.Label lblTSDBPoint;
        private System.Windows.Forms.ComboBox cmbTSDBPoint;
        private System.Windows.Forms.TextBox txtWorkTime;
        private System.Windows.Forms.Label lblWorkTime;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.Label lblState;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        private void InitializeComponent()
        {
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblAquarium = new System.Windows.Forms.Label();
            this.cmbAquarium = new System.Windows.Forms.ComboBox();
            this.lblPower = new System.Windows.Forms.Label();
            this.txtPower = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.chkDigital = new System.Windows.Forms.CheckBox();
            this.lblTSDBPoint = new System.Windows.Forms.Label();
            this.cmbTSDBPoint = new System.Windows.Forms.ComboBox();
            this.txtWorkTime = new System.Windows.Forms.TextBox();
            this.lblWorkTime = new System.Windows.Forms.Label();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.lblState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(169, 462);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(120, 30);
            this.btnAccept.TabIndex = 18;
            this.btnAccept.Text = "Accept";
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(294, 462);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 30);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblAquarium
            // 
            this.lblAquarium.Location = new System.Drawing.Point(12, 15);
            this.lblAquarium.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAquarium.Name = "lblAquarium";
            this.lblAquarium.Size = new System.Drawing.Size(110, 21);
            this.lblAquarium.TabIndex = 0;
            this.lblAquarium.Text = "Aquarium";
            // 
            // cmbAquarium
            // 
            this.cmbAquarium.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAquarium.Location = new System.Drawing.Point(169, 12);
            this.cmbAquarium.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.cmbAquarium.Name = "cmbAquarium";
            this.cmbAquarium.Size = new System.Drawing.Size(244, 27);
            this.cmbAquarium.TabIndex = 1;
            // 
            // lblPower
            // 
            this.lblPower.Location = new System.Drawing.Point(12, 242);
            this.lblPower.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPower.Name = "lblPower";
            this.lblPower.Size = new System.Drawing.Size(153, 21);
            this.lblPower.TabIndex = 10;
            this.lblPower.Text = "Power";
            // 
            // txtPower
            // 
            this.txtPower.Location = new System.Drawing.Point(169, 239);
            this.txtPower.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.txtPower.Name = "txtPower";
            this.txtPower.Size = new System.Drawing.Size(244, 26);
            this.txtPower.TabIndex = 11;
            // 
            // lblNote
            // 
            this.lblNote.Location = new System.Drawing.Point(12, 315);
            this.lblNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(129, 21);
            this.lblNote.TabIndex = 14;
            this.lblNote.Text = "Note";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(169, 312);
            this.txtNote.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(244, 59);
            this.txtNote.TabIndex = 15;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(169, 200);
            this.cmbType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(175, 27);
            this.cmbType.TabIndex = 9;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(12, 202);
            this.lblType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(100, 21);
            this.lblType.TabIndex = 8;
            this.lblType.Text = "Type";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(12, 54);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(129, 21);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(169, 51);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(244, 26);
            this.txtName.TabIndex = 3;
            // 
            // lblBrand
            // 
            this.lblBrand.Location = new System.Drawing.Point(12, 92);
            this.lblBrand.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(129, 21);
            this.lblBrand.TabIndex = 4;
            this.lblBrand.Text = "Brand";
            // 
            // cmbBrand
            // 
            this.cmbBrand.Location = new System.Drawing.Point(169, 89);
            this.cmbBrand.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(244, 27);
            this.cmbBrand.TabIndex = 5;
            // 
            // chkEnabled
            // 
            this.chkEnabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEnabled.Location = new System.Drawing.Point(12, 128);
            this.chkEnabled.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(174, 24);
            this.chkEnabled.TabIndex = 6;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // chkDigital
            // 
            this.chkDigital.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDigital.Location = new System.Drawing.Point(12, 164);
            this.chkDigital.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.chkDigital.Name = "chkDigital";
            this.chkDigital.Size = new System.Drawing.Size(174, 24);
            this.chkDigital.TabIndex = 7;
            this.chkDigital.Text = "Digital";
            this.chkDigital.UseVisualStyleBackColor = true;
            // 
            // lblTSDBPoint
            // 
            this.lblTSDBPoint.Location = new System.Drawing.Point(12, 386);
            this.lblTSDBPoint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTSDBPoint.Name = "lblTSDBPoint";
            this.lblTSDBPoint.Size = new System.Drawing.Size(100, 21);
            this.lblTSDBPoint.TabIndex = 16;
            this.lblTSDBPoint.Text = "TSDB Point";
            // 
            // cmbTSDBPoint
            // 
            this.cmbTSDBPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTSDBPoint.FormattingEnabled = true;
            this.cmbTSDBPoint.Location = new System.Drawing.Point(169, 382);
            this.cmbTSDBPoint.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.cmbTSDBPoint.Name = "cmbTSDBPoint";
            this.cmbTSDBPoint.Size = new System.Drawing.Size(244, 27);
            this.cmbTSDBPoint.TabIndex = 17;
            this.cmbTSDBPoint.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // txtWorkTime
            // 
            this.txtWorkTime.Location = new System.Drawing.Point(169, 276);
            this.txtWorkTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.txtWorkTime.Name = "txtWorkTime";
            this.txtWorkTime.Size = new System.Drawing.Size(244, 26);
            this.txtWorkTime.TabIndex = 13;
            // 
            // lblWorkTime
            // 
            this.lblWorkTime.Location = new System.Drawing.Point(12, 279);
            this.lblWorkTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWorkTime.Name = "lblWorkTime";
            this.lblWorkTime.Size = new System.Drawing.Size(174, 21);
            this.lblWorkTime.TabIndex = 12;
            this.lblWorkTime.Text = "Work time (h / d)";
            // 
            // cmbState
            // 
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(169, 421);
            this.cmbState.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(169, 27);
            this.cmbState.TabIndex = 21;
            // 
            // lblState
            // 
            this.lblState.Location = new System.Drawing.Point(12, 424);
            this.lblState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(100, 21);
            this.lblState.TabIndex = 20;
            this.lblState.Text = "State";
            // 
            // DeviceEditDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(428, 506);
            this.Controls.Add(this.cmbState);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.txtWorkTime);
            this.Controls.Add(this.lblWorkTime);
            this.Controls.Add(this.chkDigital);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.cmbTSDBPoint);
            this.Controls.Add(this.lblTSDBPoint);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cmbAquarium);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.cmbBrand);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtPower);
            this.Controls.Add(this.lblPower);
            this.Controls.Add(this.lblAquarium);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceEditDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Device";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
