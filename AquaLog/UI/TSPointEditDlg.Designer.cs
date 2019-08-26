namespace AquaLog.UI
{
    partial class TSPointEditDlg
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblUoM;
        private System.Windows.Forms.TextBox txtUoM;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.TextBox txtDeviation;
        private System.Windows.Forms.Label lblDeviation;
        
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblUoM = new System.Windows.Forms.Label();
            this.txtUoM = new System.Windows.Forms.TextBox();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.lblMin = new System.Windows.Forms.Label();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.lblMax = new System.Windows.Forms.Label();
            this.txtDeviation = new System.Windows.Forms.TextBox();
            this.lblDeviation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(174, 164);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(77, 24);
            this.btnAccept.TabIndex = 10;
            this.btnAccept.Text = "Accept";
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(256, 164);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 24);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(10, 12);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(80, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(84, 10);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 22);
            this.txtName.TabIndex = 1;
            // 
            // lblUoM
            // 
            this.lblUoM.Location = new System.Drawing.Point(10, 42);
            this.lblUoM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUoM.Name = "lblUoM";
            this.lblUoM.Size = new System.Drawing.Size(103, 17);
            this.lblUoM.TabIndex = 2;
            this.lblUoM.Text = "UoM";
            // 
            // txtUoM
            // 
            this.txtUoM.Location = new System.Drawing.Point(84, 40);
            this.txtUoM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtUoM.Name = "txtUoM";
            this.txtUoM.Size = new System.Drawing.Size(220, 22);
            this.txtUoM.TabIndex = 3;
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(84, 70);
            this.txtMin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(74, 22);
            this.txtMin.TabIndex = 5;
            // 
            // lblMin
            // 
            this.lblMin.Location = new System.Drawing.Point(10, 73);
            this.lblMin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(80, 17);
            this.lblMin.TabIndex = 4;
            this.lblMin.Text = "Min";
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(84, 101);
            this.txtMax.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(74, 22);
            this.txtMax.TabIndex = 7;
            // 
            // lblMax
            // 
            this.lblMax.Location = new System.Drawing.Point(10, 103);
            this.lblMax.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(80, 17);
            this.lblMax.TabIndex = 6;
            this.lblMax.Text = "Max";
            // 
            // txtDeviation
            // 
            this.txtDeviation.Location = new System.Drawing.Point(84, 131);
            this.txtDeviation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtDeviation.Name = "txtDeviation";
            this.txtDeviation.Size = new System.Drawing.Size(74, 22);
            this.txtDeviation.TabIndex = 9;
            // 
            // lblDeviation
            // 
            this.lblDeviation.Location = new System.Drawing.Point(10, 134);
            this.lblDeviation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeviation.Name = "lblDeviation";
            this.lblDeviation.Size = new System.Drawing.Size(80, 17);
            this.lblDeviation.TabIndex = 8;
            this.lblDeviation.Text = "Deviation";
            // 
            // TSPointEditDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(342, 198);
            this.Controls.Add(this.txtDeviation);
            this.Controls.Add(this.lblDeviation);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.txtUoM);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblUoM);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TSPointEditDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Point";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
