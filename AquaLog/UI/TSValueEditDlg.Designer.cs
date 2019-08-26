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
            this.btnAccept.Location = new System.Drawing.Point(75, 78);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(77, 24);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Accept";
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(157, 78);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblTimestamp
            // 
            this.lblTimestamp.Location = new System.Drawing.Point(10, 14);
            this.lblTimestamp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimestamp.Name = "lblTimestamp";
            this.lblTimestamp.Size = new System.Drawing.Size(80, 17);
            this.lblTimestamp.TabIndex = 0;
            this.lblTimestamp.Text = "Timestamp";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(88, 40);
            this.txtValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(74, 22);
            this.txtValue.TabIndex = 3;
            // 
            // lblValue
            // 
            this.lblValue.Location = new System.Drawing.Point(10, 42);
            this.lblValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(80, 17);
            this.lblValue.TabIndex = 2;
            this.lblValue.Text = "Value";
            // 
            // dtpTimestamp
            // 
            this.dtpTimestamp.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dtpTimestamp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimestamp.Location = new System.Drawing.Point(88, 10);
            this.dtpTimestamp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.dtpTimestamp.Name = "dtpTimestamp";
            this.dtpTimestamp.Size = new System.Drawing.Size(146, 22);
            this.dtpTimestamp.TabIndex = 1;
            // 
            // TSValueEditDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(243, 111);
            this.Controls.Add(this.dtpTimestamp);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblTimestamp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
