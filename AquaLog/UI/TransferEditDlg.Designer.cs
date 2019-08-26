namespace AquaLog.UI
{
    partial class TransferEditDlg
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.ComboBox cmbTarget;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.ComboBox cmbSource;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCause;
        private System.Windows.Forms.TextBox txtCause;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.Label lblShop;
        private System.Windows.Forms.ComboBox cmbShop;
        
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
            this.lblType = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblTarget = new System.Windows.Forms.Label();
            this.cmbTarget = new System.Windows.Forms.ComboBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCause = new System.Windows.Forms.Label();
            this.txtCause = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.lblShop = new System.Windows.Forms.Label();
            this.cmbShop = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(176, 264);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(96, 24);
            this.btnAccept.TabIndex = 18;
            this.btnAccept.Text = "Accept";
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(276, 264);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 24);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(10, 14);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(80, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Inhabitant";
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(10, 135);
            this.lblType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(80, 17);
            this.lblType.TabIndex = 8;
            this.lblType.Text = "Type";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(118, 10);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(254, 22);
            this.txtName.TabIndex = 1;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(118, 133);
            this.cmbType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(149, 21);
            this.cmbType.TabIndex = 9;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // lblTarget
            // 
            this.lblTarget.Location = new System.Drawing.Point(10, 74);
            this.lblTarget.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(88, 17);
            this.lblTarget.TabIndex = 4;
            this.lblTarget.Text = "To (target aquarium)";
            // 
            // cmbTarget
            // 
            this.cmbTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTarget.Location = new System.Drawing.Point(152, 71);
            this.cmbTarget.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbTarget.Name = "cmbTarget";
            this.cmbTarget.Size = new System.Drawing.Size(220, 21);
            this.cmbTarget.TabIndex = 5;
            // 
            // lblSource
            // 
            this.lblSource.Location = new System.Drawing.Point(10, 42);
            this.lblSource.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(131, 17);
            this.lblSource.TabIndex = 2;
            this.lblSource.Text = "From (source aquarium)";
            // 
            // cmbSource
            // 
            this.cmbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSource.Enabled = false;
            this.cmbSource.Location = new System.Drawing.Point(152, 40);
            this.cmbSource.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.Size = new System.Drawing.Size(220, 21);
            this.cmbSource.TabIndex = 3;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(118, 102);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(149, 22);
            this.dtpDate.TabIndex = 7;
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(10, 107);
            this.lblDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(80, 17);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Date";
            // 
            // lblCause
            // 
            this.lblCause.Location = new System.Drawing.Point(10, 166);
            this.lblCause.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCause.Name = "lblCause";
            this.lblCause.Size = new System.Drawing.Size(103, 17);
            this.lblCause.TabIndex = 10;
            this.lblCause.Text = "Cause";
            // 
            // txtCause
            // 
            this.txtCause.Location = new System.Drawing.Point(118, 164);
            this.txtCause.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtCause.Name = "txtCause";
            this.txtCause.Size = new System.Drawing.Size(254, 22);
            this.txtCause.TabIndex = 11;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(118, 194);
            this.txtQty.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(74, 22);
            this.txtQty.TabIndex = 13;
            // 
            // lblQty
            // 
            this.lblQty.Location = new System.Drawing.Point(10, 197);
            this.lblQty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(80, 17);
            this.lblQty.TabIndex = 12;
            this.lblQty.Text = "Qty";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(301, 194);
            this.txtUnitPrice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(71, 22);
            this.txtUnitPrice.TabIndex = 15;
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.Location = new System.Drawing.Point(209, 197);
            this.lblUnitPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(80, 17);
            this.lblUnitPrice.TabIndex = 14;
            this.lblUnitPrice.Text = "Unit Price";
            // 
            // lblShop
            // 
            this.lblShop.Location = new System.Drawing.Point(10, 227);
            this.lblShop.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShop.Name = "lblShop";
            this.lblShop.Size = new System.Drawing.Size(88, 17);
            this.lblShop.TabIndex = 16;
            this.lblShop.Text = "Shop";
            // 
            // cmbShop
            // 
            this.cmbShop.Location = new System.Drawing.Point(118, 225);
            this.cmbShop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbShop.Name = "cmbShop";
            this.cmbShop.Size = new System.Drawing.Size(254, 21);
            this.cmbShop.TabIndex = 17;
            // 
            // TransferEditDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(383, 299);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.lblUnitPrice);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.cmbShop);
            this.Controls.Add(this.cmbTarget);
            this.Controls.Add(this.txtCause);
            this.Controls.Add(this.cmbSource);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblShop);
            this.Controls.Add(this.lblCause);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransferEditDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Transfer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
