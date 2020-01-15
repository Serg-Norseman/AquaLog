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
        private System.Windows.Forms.CheckBox chkHideAtStartup;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCommon;
        private System.Windows.Forms.TabPage tabData;
        private System.Windows.Forms.ComboBox cmbVolumeUoM;
        private System.Windows.Forms.Label lblVolumeUoM;
        private System.Windows.Forms.ComboBox cmbLengthUoM;
        private System.Windows.Forms.Label lblLengthUoM;
        private System.Windows.Forms.ComboBox cmbMassUoM;
        private System.Windows.Forms.Label lblMassUoM;
        private System.Windows.Forms.ComboBox cmbTemperatureUoM;
        private System.Windows.Forms.Label lblTemperatureUoM;
        
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCommon = new System.Windows.Forms.TabPage();
            this.cmbLocale = new System.Windows.Forms.ComboBox();
            this.lblLocale = new System.Windows.Forms.Label();
            this.chkExitOnClose = new System.Windows.Forms.CheckBox();
            this.chkHideAtStartup = new System.Windows.Forms.CheckBox();
            this.chkAutorun = new System.Windows.Forms.CheckBox();
            this.chkHideClosedTanks = new System.Windows.Forms.CheckBox();
            this.tabData = new System.Windows.Forms.TabPage();
            this.cmbMassUoM = new System.Windows.Forms.ComboBox();
            this.lblMassUoM = new System.Windows.Forms.Label();
            this.cmbVolumeUoM = new System.Windows.Forms.ComboBox();
            this.lblVolumeUoM = new System.Windows.Forms.Label();
            this.cmbLengthUoM = new System.Windows.Forms.ComboBox();
            this.lblLengthUoM = new System.Windows.Forms.Label();
            this.lblTemperatureUoM = new System.Windows.Forms.Label();
            this.cmbTemperatureUoM = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabCommon.SuspendLayout();
            this.tabData.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(208, 253);
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
            this.btnCancel.Location = new System.Drawing.Point(334, 253);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCommon);
            this.tabControl1.Controls.Add(this.tabData);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(446, 228);
            this.tabControl1.TabIndex = 6;
            // 
            // tabCommon
            // 
            this.tabCommon.BackColor = System.Drawing.SystemColors.Control;
            this.tabCommon.Controls.Add(this.cmbLocale);
            this.tabCommon.Controls.Add(this.lblLocale);
            this.tabCommon.Controls.Add(this.chkExitOnClose);
            this.tabCommon.Controls.Add(this.chkHideAtStartup);
            this.tabCommon.Controls.Add(this.chkAutorun);
            this.tabCommon.Controls.Add(this.chkHideClosedTanks);
            this.tabCommon.Location = new System.Drawing.Point(4, 28);
            this.tabCommon.Margin = new System.Windows.Forms.Padding(2);
            this.tabCommon.Name = "tabCommon";
            this.tabCommon.Padding = new System.Windows.Forms.Padding(9);
            this.tabCommon.Size = new System.Drawing.Size(438, 196);
            this.tabCommon.TabIndex = 0;
            this.tabCommon.Text = "Common";
            // 
            // cmbLocale
            // 
            this.cmbLocale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocale.FormattingEnabled = true;
            this.cmbLocale.Location = new System.Drawing.Point(115, 151);
            this.cmbLocale.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.cmbLocale.Name = "cmbLocale";
            this.cmbLocale.Size = new System.Drawing.Size(185, 27);
            this.cmbLocale.TabIndex = 15;
            // 
            // lblLocale
            // 
            this.lblLocale.Location = new System.Drawing.Point(11, 154);
            this.lblLocale.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLocale.Name = "lblLocale";
            this.lblLocale.Size = new System.Drawing.Size(100, 21);
            this.lblLocale.TabIndex = 14;
            this.lblLocale.Text = "Locale";
            // 
            // chkExitOnClose
            // 
            this.chkExitOnClose.Location = new System.Drawing.Point(11, 116);
            this.chkExitOnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.chkExitOnClose.Name = "chkExitOnClose";
            this.chkExitOnClose.Size = new System.Drawing.Size(406, 24);
            this.chkExitOnClose.TabIndex = 13;
            this.chkExitOnClose.Text = "Exit on Close";
            this.chkExitOnClose.UseVisualStyleBackColor = true;
            // 
            // chkHideAtStartup
            // 
            this.chkHideAtStartup.Location = new System.Drawing.Point(11, 46);
            this.chkHideAtStartup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.chkHideAtStartup.Name = "chkHideAtStartup";
            this.chkHideAtStartup.Size = new System.Drawing.Size(406, 24);
            this.chkHideAtStartup.TabIndex = 10;
            this.chkHideAtStartup.Text = "HideAtStartup";
            this.chkHideAtStartup.UseVisualStyleBackColor = true;
            // 
            // chkAutorun
            // 
            this.chkAutorun.Location = new System.Drawing.Point(11, 11);
            this.chkAutorun.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.chkAutorun.Name = "chkAutorun";
            this.chkAutorun.Size = new System.Drawing.Size(406, 24);
            this.chkAutorun.TabIndex = 11;
            this.chkAutorun.Text = "Autorun";
            this.chkAutorun.UseVisualStyleBackColor = true;
            // 
            // chkHideClosedTanks
            // 
            this.chkHideClosedTanks.Location = new System.Drawing.Point(11, 81);
            this.chkHideClosedTanks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.chkHideClosedTanks.Name = "chkHideClosedTanks";
            this.chkHideClosedTanks.Size = new System.Drawing.Size(406, 24);
            this.chkHideClosedTanks.TabIndex = 12;
            this.chkHideClosedTanks.Text = "Hide closed tanks";
            this.chkHideClosedTanks.UseVisualStyleBackColor = true;
            // 
            // tabData
            // 
            this.tabData.BackColor = System.Drawing.SystemColors.Control;
            this.tabData.Controls.Add(this.cmbTemperatureUoM);
            this.tabData.Controls.Add(this.lblTemperatureUoM);
            this.tabData.Controls.Add(this.cmbMassUoM);
            this.tabData.Controls.Add(this.lblMassUoM);
            this.tabData.Controls.Add(this.cmbVolumeUoM);
            this.tabData.Controls.Add(this.lblVolumeUoM);
            this.tabData.Controls.Add(this.cmbLengthUoM);
            this.tabData.Controls.Add(this.lblLengthUoM);
            this.tabData.Location = new System.Drawing.Point(4, 28);
            this.tabData.Margin = new System.Windows.Forms.Padding(2);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Windows.Forms.Padding(9);
            this.tabData.Size = new System.Drawing.Size(438, 196);
            this.tabData.TabIndex = 1;
            this.tabData.Text = "Data";
            // 
            // cmbMassUoM
            // 
            this.cmbMassUoM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMassUoM.FormattingEnabled = true;
            this.cmbMassUoM.Location = new System.Drawing.Point(179, 87);
            this.cmbMassUoM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.cmbMassUoM.Name = "cmbMassUoM";
            this.cmbMassUoM.Size = new System.Drawing.Size(185, 27);
            this.cmbMassUoM.TabIndex = 17;
            // 
            // lblMassUoM
            // 
            this.lblMassUoM.Location = new System.Drawing.Point(11, 90);
            this.lblMassUoM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMassUoM.Name = "lblMassUoM";
            this.lblMassUoM.Size = new System.Drawing.Size(164, 21);
            this.lblMassUoM.TabIndex = 16;
            this.lblMassUoM.Text = "MassUoM";
            // 
            // cmbVolumeUoM
            // 
            this.cmbVolumeUoM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVolumeUoM.FormattingEnabled = true;
            this.cmbVolumeUoM.Location = new System.Drawing.Point(179, 49);
            this.cmbVolumeUoM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.cmbVolumeUoM.Name = "cmbVolumeUoM";
            this.cmbVolumeUoM.Size = new System.Drawing.Size(185, 27);
            this.cmbVolumeUoM.TabIndex = 17;
            // 
            // lblVolumeUoM
            // 
            this.lblVolumeUoM.Location = new System.Drawing.Point(11, 52);
            this.lblVolumeUoM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVolumeUoM.Name = "lblVolumeUoM";
            this.lblVolumeUoM.Size = new System.Drawing.Size(164, 21);
            this.lblVolumeUoM.TabIndex = 16;
            this.lblVolumeUoM.Text = "VolumeUoM";
            // 
            // cmbLengthUoM
            // 
            this.cmbLengthUoM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLengthUoM.FormattingEnabled = true;
            this.cmbLengthUoM.Location = new System.Drawing.Point(179, 11);
            this.cmbLengthUoM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.cmbLengthUoM.Name = "cmbLengthUoM";
            this.cmbLengthUoM.Size = new System.Drawing.Size(185, 27);
            this.cmbLengthUoM.TabIndex = 17;
            // 
            // lblLengthUoM
            // 
            this.lblLengthUoM.Location = new System.Drawing.Point(11, 14);
            this.lblLengthUoM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLengthUoM.Name = "lblLengthUoM";
            this.lblLengthUoM.Size = new System.Drawing.Size(164, 21);
            this.lblLengthUoM.TabIndex = 16;
            this.lblLengthUoM.Text = "LengthUoM";
            // 
            // lblTemperatureUoM
            // 
            this.lblTemperatureUoM.Location = new System.Drawing.Point(11, 128);
            this.lblTemperatureUoM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTemperatureUoM.Name = "lblTemperatureUoM";
            this.lblTemperatureUoM.Size = new System.Drawing.Size(164, 21);
            this.lblTemperatureUoM.TabIndex = 16;
            this.lblTemperatureUoM.Text = "TemperatureUoM";
            // 
            // cmbTemperatureUoM
            // 
            this.cmbTemperatureUoM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTemperatureUoM.FormattingEnabled = true;
            this.cmbTemperatureUoM.Location = new System.Drawing.Point(179, 125);
            this.cmbTemperatureUoM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.cmbTemperatureUoM.Name = "cmbTemperatureUoM";
            this.cmbTemperatureUoM.Size = new System.Drawing.Size(185, 27);
            this.cmbTemperatureUoM.TabIndex = 17;
            // 
            // SettingsDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(470, 294);
            this.Controls.Add(this.tabControl1);
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
            this.tabControl1.ResumeLayout(false);
            this.tabCommon.ResumeLayout(false);
            this.tabData.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
