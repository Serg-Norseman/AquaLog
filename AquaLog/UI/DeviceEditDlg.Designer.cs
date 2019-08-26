namespace AquaLog.UI
{
    partial class DeviceEditDlg
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblAquarium;
        private System.Windows.Forms.ComboBox cmbAquarium;
        private System.Windows.Forms.Label lblWattage;
        private System.Windows.Forms.TextBox txtWattage;
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
            this.lblWattage = new System.Windows.Forms.Label();
            this.txtWattage = new System.Windows.Forms.TextBox();
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
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(135, 315);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(96, 24);
            this.btnAccept.TabIndex = 16;
            this.btnAccept.Text = "Accept";
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(235, 315);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 24);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblAquarium
            // 
            this.lblAquarium.Location = new System.Drawing.Point(10, 12);
            this.lblAquarium.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAquarium.Name = "lblAquarium";
            this.lblAquarium.Size = new System.Drawing.Size(88, 17);
            this.lblAquarium.TabIndex = 0;
            this.lblAquarium.Text = "Aquarium";
            // 
            // cmbAquarium
            // 
            this.cmbAquarium.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAquarium.Location = new System.Drawing.Point(118, 10);
            this.cmbAquarium.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbAquarium.Name = "cmbAquarium";
            this.cmbAquarium.Size = new System.Drawing.Size(213, 21);
            this.cmbAquarium.TabIndex = 1;
            // 
            // lblWattage
            // 
            this.lblWattage.Location = new System.Drawing.Point(10, 194);
            this.lblWattage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWattage.Name = "lblWattage";
            this.lblWattage.Size = new System.Drawing.Size(103, 17);
            this.lblWattage.TabIndex = 10;
            this.lblWattage.Text = "Wattage";
            // 
            // txtWattage
            // 
            this.txtWattage.Location = new System.Drawing.Point(118, 191);
            this.txtWattage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtWattage.Name = "txtWattage";
            this.txtWattage.Size = new System.Drawing.Size(213, 22);
            this.txtWattage.TabIndex = 11;
            // 
            // lblNote
            // 
            this.lblNote.Location = new System.Drawing.Point(10, 224);
            this.lblNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(103, 17);
            this.lblNote.TabIndex = 12;
            this.lblNote.Text = "Note";
            // 
            // txtNote
            // 
            this.txtNote.Enabled = false;
            this.txtNote.Location = new System.Drawing.Point(118, 222);
            this.txtNote.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(213, 48);
            this.txtNote.TabIndex = 13;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(118, 160);
            this.cmbType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(136, 21);
            this.cmbType.TabIndex = 9;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(10, 162);
            this.lblType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(80, 17);
            this.lblType.TabIndex = 8;
            this.lblType.Text = "Type";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(10, 43);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(103, 17);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(118, 41);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(213, 22);
            this.txtName.TabIndex = 3;
            // 
            // lblBrand
            // 
            this.lblBrand.Location = new System.Drawing.Point(10, 74);
            this.lblBrand.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(103, 17);
            this.lblBrand.TabIndex = 4;
            this.lblBrand.Text = "Brand";
            // 
            // cmbBrand
            // 
            this.cmbBrand.Location = new System.Drawing.Point(118, 71);
            this.cmbBrand.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(213, 21);
            this.cmbBrand.TabIndex = 5;
            // 
            // chkEnabled
            // 
            this.chkEnabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEnabled.Location = new System.Drawing.Point(10, 102);
            this.chkEnabled.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(122, 19);
            this.chkEnabled.TabIndex = 6;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // chkDigital
            // 
            this.chkDigital.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDigital.Location = new System.Drawing.Point(10, 131);
            this.chkDigital.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.chkDigital.Name = "chkDigital";
            this.chkDigital.Size = new System.Drawing.Size(122, 19);
            this.chkDigital.TabIndex = 7;
            this.chkDigital.Text = "Digital";
            this.chkDigital.UseVisualStyleBackColor = true;
            // 
            // lblTSDBPoint
            // 
            this.lblTSDBPoint.Location = new System.Drawing.Point(10, 281);
            this.lblTSDBPoint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTSDBPoint.Name = "lblTSDBPoint";
            this.lblTSDBPoint.Size = new System.Drawing.Size(80, 17);
            this.lblTSDBPoint.TabIndex = 14;
            this.lblTSDBPoint.Text = "TSDB Point";
            // 
            // cmbTSDBPoint
            // 
            this.cmbTSDBPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTSDBPoint.FormattingEnabled = true;
            this.cmbTSDBPoint.Location = new System.Drawing.Point(118, 278);
            this.cmbTSDBPoint.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbTSDBPoint.Name = "cmbTSDBPoint";
            this.cmbTSDBPoint.Size = new System.Drawing.Size(213, 21);
            this.cmbTSDBPoint.TabIndex = 15;
            this.cmbTSDBPoint.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // DeviceEditDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(342, 350);
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
            this.Controls.Add(this.txtWattage);
            this.Controls.Add(this.lblWattage);
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
