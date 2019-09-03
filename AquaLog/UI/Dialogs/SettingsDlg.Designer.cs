namespace AquaLog.UI.Dialogs
{
    partial class SettingsDlg
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkHideClosedTanks;
        private System.Windows.Forms.CheckBox chkExitOnClose;
        private System.Windows.Forms.ComboBox cmbLocale;
        private System.Windows.Forms.Label lblLocale;
        private System.Windows.Forms.CheckBox chkAutorun;
        
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
            this.chkHideClosedTanks = new System.Windows.Forms.CheckBox();
            this.chkExitOnClose = new System.Windows.Forms.CheckBox();
            this.cmbLocale = new System.Windows.Forms.ComboBox();
            this.lblLocale = new System.Windows.Forms.Label();
            this.chkAutorun = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(171, 167);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(120, 30);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Accept";
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(297, 167);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chkHideClosedTanks
            // 
            this.chkHideClosedTanks.Location = new System.Drawing.Point(11, 46);
            this.chkHideClosedTanks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.chkHideClosedTanks.Name = "chkHideClosedTanks";
            this.chkHideClosedTanks.Size = new System.Drawing.Size(406, 24);
            this.chkHideClosedTanks.TabIndex = 0;
            this.chkHideClosedTanks.Text = "Hide closed tanks";
            this.chkHideClosedTanks.UseVisualStyleBackColor = true;
            // 
            // chkExitOnClose
            // 
            this.chkExitOnClose.Location = new System.Drawing.Point(11, 81);
            this.chkExitOnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.chkExitOnClose.Name = "chkExitOnClose";
            this.chkExitOnClose.Size = new System.Drawing.Size(406, 24);
            this.chkExitOnClose.TabIndex = 1;
            this.chkExitOnClose.Text = "Exit on Close";
            this.chkExitOnClose.UseVisualStyleBackColor = true;
            // 
            // cmbLocale
            // 
            this.cmbLocale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocale.FormattingEnabled = true;
            this.cmbLocale.Location = new System.Drawing.Point(115, 116);
            this.cmbLocale.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.cmbLocale.Name = "cmbLocale";
            this.cmbLocale.Size = new System.Drawing.Size(185, 27);
            this.cmbLocale.TabIndex = 3;
            // 
            // lblLocale
            // 
            this.lblLocale.Location = new System.Drawing.Point(11, 119);
            this.lblLocale.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLocale.Name = "lblLocale";
            this.lblLocale.Size = new System.Drawing.Size(100, 21);
            this.lblLocale.TabIndex = 2;
            this.lblLocale.Text = "Locale";
            // 
            // chkAutorun
            // 
            this.chkAutorun.Location = new System.Drawing.Point(11, 11);
            this.chkAutorun.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.chkAutorun.Name = "chkAutorun";
            this.chkAutorun.Size = new System.Drawing.Size(406, 24);
            this.chkAutorun.TabIndex = 0;
            this.chkAutorun.Text = "Autorun";
            this.chkAutorun.UseVisualStyleBackColor = true;
            // 
            // SettingsDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(428, 208);
            this.Controls.Add(this.cmbLocale);
            this.Controls.Add(this.lblLocale);
            this.Controls.Add(this.chkExitOnClose);
            this.Controls.Add(this.chkAutorun);
            this.Controls.Add(this.chkHideClosedTanks);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.ResumeLayout(false);

        }
    }
}
