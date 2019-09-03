namespace AquaLog.UI.Dialogs
{
    partial class NutritionEditDlg
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblAquarium;
        private System.Windows.Forms.ComboBox cmbAquarium;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Label lblInhabitant;
        private System.Windows.Forms.ComboBox cmbInhabitant;
        
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
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.lblInhabitant = new System.Windows.Forms.Label();
            this.cmbInhabitant = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(135, 239);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(96, 24);
            this.btnAccept.TabIndex = 12;
            this.btnAccept.Text = "Accept";
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(235, 239);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 24);
            this.btnCancel.TabIndex = 13;
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
            // lblAmount
            // 
            this.lblAmount.Location = new System.Drawing.Point(10, 105);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(103, 17);
            this.lblAmount.TabIndex = 6;
            this.lblAmount.Text = "Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(118, 102);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(213, 22);
            this.txtAmount.TabIndex = 7;
            // 
            // lblNote
            // 
            this.lblNote.Location = new System.Drawing.Point(10, 135);
            this.lblNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(103, 17);
            this.lblNote.TabIndex = 8;
            this.lblNote.Text = "Note";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(118, 133);
            this.txtNote.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(213, 56);
            this.txtNote.TabIndex = 9;
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
            // lblInhabitant
            // 
            this.lblInhabitant.Location = new System.Drawing.Point(10, 202);
            this.lblInhabitant.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInhabitant.Name = "lblInhabitant";
            this.lblInhabitant.Size = new System.Drawing.Size(88, 17);
            this.lblInhabitant.TabIndex = 10;
            this.lblInhabitant.Text = "Inhabitant";
            // 
            // cmbInhabitant
            // 
            this.cmbInhabitant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInhabitant.Location = new System.Drawing.Point(118, 199);
            this.cmbInhabitant.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbInhabitant.Name = "cmbInhabitant";
            this.cmbInhabitant.Size = new System.Drawing.Size(213, 21);
            this.cmbInhabitant.TabIndex = 11;
            // 
            // NutritionEditDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(342, 274);
            this.Controls.Add(this.cmbInhabitant);
            this.Controls.Add(this.cmbAquarium);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.cmbBrand);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblInhabitant);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblAquarium);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NutritionEditDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nutrition";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
