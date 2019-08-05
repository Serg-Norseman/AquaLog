namespace AquaLog.UI
{
    partial class TSValueEditDlg
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dtpTimestamp;
        private System.Windows.Forms.Label lblTimestamp;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label lblValue;
        
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
            this.lblTimestamp = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.dtpTimestamp = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(75, 83);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(96, 30);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Accept";
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(177, 83);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblTimestamp
            // 
            this.lblTimestamp.Location = new System.Drawing.Point(12, 19);
            this.lblTimestamp.Name = "lblTimestamp";
            this.lblTimestamp.Size = new System.Drawing.Size(100, 21);
            this.lblTimestamp.TabIndex = 7;
            this.lblTimestamp.Text = "Timestamp";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(104, 43);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(91, 22);
            this.txtValue.TabIndex = 2;
            // 
            // lblValue
            // 
            this.lblValue.Location = new System.Drawing.Point(12, 46);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(100, 21);
            this.lblValue.TabIndex = 9;
            this.lblValue.Text = "Value";
            // 
            // dtpTimestamp
            // 
            this.dtpTimestamp.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dtpTimestamp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimestamp.Location = new System.Drawing.Point(104, 12);
            this.dtpTimestamp.Name = "dtpTimestamp";
            this.dtpTimestamp.Size = new System.Drawing.Size(169, 22);
            this.dtpTimestamp.TabIndex = 1;
            // 
            // TSValueEditDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(286, 124);
            this.Controls.Add(this.dtpTimestamp);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblTimestamp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TSValueEditDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TSValue";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
