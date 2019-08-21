namespace AquaLog.UI
{
    partial class WaterChangeEditDlg
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblAquarium;
        private System.Windows.Forms.ComboBox cmbAquarium;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.TextBox txtVolume;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblType;
        
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
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblVolume = new System.Windows.Forms.Label();
            this.txtVolume = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(218, 265);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(96, 30);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Accept";
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(320, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblAquarium
            // 
            this.lblAquarium.Location = new System.Drawing.Point(12, 15);
            this.lblAquarium.Name = "lblAquarium";
            this.lblAquarium.Size = new System.Drawing.Size(110, 21);
            this.lblAquarium.TabIndex = 2;
            this.lblAquarium.Text = "Aquarium";
            // 
            // cmbAquarium
            // 
            this.cmbAquarium.Location = new System.Drawing.Point(147, 12);
            this.cmbAquarium.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.cmbAquarium.Name = "cmbAquarium";
            this.cmbAquarium.Size = new System.Drawing.Size(269, 27);
            this.cmbAquarium.TabIndex = 5;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(147, 51);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(167, 26);
            this.dtpDate.TabIndex = 8;
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(12, 57);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(100, 21);
            this.lblDate.TabIndex = 7;
            this.lblDate.Text = "Date";
            // 
            // lblVolume
            // 
            this.lblVolume.Location = new System.Drawing.Point(12, 131);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(129, 21);
            this.lblVolume.TabIndex = 2;
            this.lblVolume.Text = "Volume";
            // 
            // txtVolume
            // 
            this.txtVolume.Location = new System.Drawing.Point(147, 128);
            this.txtVolume.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.Size = new System.Drawing.Size(269, 26);
            this.txtVolume.TabIndex = 5;
            // 
            // lblNote
            // 
            this.lblNote.Location = new System.Drawing.Point(12, 169);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(129, 21);
            this.lblNote.TabIndex = 2;
            this.lblNote.Text = "Note";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(147, 166);
            this.txtNote.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(269, 71);
            this.txtNote.TabIndex = 5;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(147, 89);
            this.cmbType.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(167, 27);
            this.cmbType.TabIndex = 10;
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(12, 92);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(100, 21);
            this.lblType.TabIndex = 9;
            this.lblType.Text = "Type";
            // 
            // WaterChangeEditDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(428, 307);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cmbAquarium);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.txtVolume);
            this.Controls.Add(this.lblVolume);
            this.Controls.Add(this.lblAquarium);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WaterChangeEditDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Water Change";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
