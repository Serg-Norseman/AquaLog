namespace AquaMate.UI.Dialogs
{
    partial class ShopEditDlg
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.Label lblWebSite;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.TextBox txtWebSite;
        private System.Windows.Forms.TextBox txtEmail;
        
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
            this.lblNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.lblWebSite = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.txtWebSite = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(168, 299);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(120, 30);
            this.btnAccept.TabIndex = 12;
            this.btnAccept.Text = "Accept";
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(293, 299);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 30);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(12, 15);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(132, 21);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(148, 12);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(265, 26);
            this.txtName.TabIndex = 1;
            // 
            // lblNote
            // 
            this.lblNote.Location = new System.Drawing.Point(12, 200);
            this.lblNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(132, 21);
            this.lblNote.TabIndex = 10;
            this.lblNote.Text = "Note";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(148, 197);
            this.txtNote.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(265, 80);
            this.txtNote.TabIndex = 11;
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(12, 52);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(132, 21);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "Address";
            // 
            // lblTelephone
            // 
            this.lblTelephone.Location = new System.Drawing.Point(12, 89);
            this.lblTelephone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(132, 21);
            this.lblTelephone.TabIndex = 4;
            this.lblTelephone.Text = "Telephone";
            // 
            // lblWebSite
            // 
            this.lblWebSite.Location = new System.Drawing.Point(12, 126);
            this.lblWebSite.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWebSite.Name = "lblWebSite";
            this.lblWebSite.Size = new System.Drawing.Size(132, 21);
            this.lblWebSite.TabIndex = 6;
            this.lblWebSite.Text = "WebSite";
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(12, 163);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(132, 21);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "Email";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(148, 49);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(265, 26);
            this.txtAddress.TabIndex = 3;
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(148, 86);
            this.txtTelephone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(265, 26);
            this.txtTelephone.TabIndex = 5;
            // 
            // txtWebSite
            // 
            this.txtWebSite.Location = new System.Drawing.Point(148, 123);
            this.txtWebSite.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.txtWebSite.Name = "txtWebSite";
            this.txtWebSite.Size = new System.Drawing.Size(265, 26);
            this.txtWebSite.TabIndex = 7;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(148, 160);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(265, 26);
            this.txtEmail.TabIndex = 9;
            // 
            // ShopEditDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(428, 340);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtWebSite);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblWebSite);
            this.Controls.Add(this.lblTelephone);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShopEditDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
