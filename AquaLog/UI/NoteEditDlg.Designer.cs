namespace AquaLog.UI
{
    partial class NoteEditDlg
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblAquarium;
        private System.Windows.Forms.ComboBox cmbAquarium;
        private System.Windows.Forms.DateTimePicker dtpDateTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        
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
            this.dtpDateTime = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(218, 209);
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
            this.btnCancel.Location = new System.Drawing.Point(320, 209);
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
            this.cmbAquarium.Location = new System.Drawing.Point(148, 12);
            this.cmbAquarium.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.cmbAquarium.Name = "cmbAquarium";
            this.cmbAquarium.Size = new System.Drawing.Size(268, 27);
            this.cmbAquarium.TabIndex = 5;
            // 
            // dtpDateTime
            // 
            this.dtpDateTime.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTime.Location = new System.Drawing.Point(148, 51);
            this.dtpDateTime.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.dtpDateTime.Name = "dtpDateTime";
            this.dtpDateTime.Size = new System.Drawing.Size(169, 26);
            this.dtpDateTime.TabIndex = 8;
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(12, 57);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(100, 21);
            this.lblDate.TabIndex = 7;
            this.lblDate.Text = "Date";
            // 
            // lblNote
            // 
            this.lblNote.Location = new System.Drawing.Point(12, 92);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(129, 21);
            this.lblNote.TabIndex = 2;
            this.lblNote.Text = "Note";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(147, 89);
            this.txtNote.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(269, 102);
            this.txtNote.TabIndex = 5;
            // 
            // NoteEditDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(428, 251);
            this.Controls.Add(this.dtpDateTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cmbAquarium);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblAquarium);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NoteEditDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Note";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
