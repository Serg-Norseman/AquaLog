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
        private System.Windows.Forms.TabPage tabDAS;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.Label lblParameters;
        private System.Windows.Forms.ComboBox cmbChannel;
        private System.Windows.Forms.Label lblChannel;
        private System.Windows.Forms.CheckBox chkEnabled;
        
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
            this.cmbTemperatureUoM = new System.Windows.Forms.ComboBox();
            this.lblTemperatureUoM = new System.Windows.Forms.Label();
            this.cmbMassUoM = new System.Windows.Forms.ComboBox();
            this.lblMassUoM = new System.Windows.Forms.Label();
            this.cmbVolumeUoM = new System.Windows.Forms.ComboBox();
            this.lblVolumeUoM = new System.Windows.Forms.Label();
            this.cmbLengthUoM = new System.Windows.Forms.ComboBox();
            this.lblLengthUoM = new System.Windows.Forms.Label();
            this.tabDAS = new System.Windows.Forms.TabPage();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.lblParameters = new System.Windows.Forms.Label();
            this.cmbChannel = new System.Windows.Forms.ComboBox();
            this.lblChannel = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabCommon.SuspendLayout();
            this.tabData.SuspendLayout();
            this.tabDAS.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(166, 202);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(96, 24);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Accept";
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(267, 202);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCommon);
            this.tabControl1.Controls.Add(this.tabData);
            this.tabControl1.Controls.Add(this.tabDAS);
            this.tabControl1.Location = new System.Drawing.Point(10, 10);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(357, 182);
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
            this.tabCommon.Location = new System.Drawing.Point(4, 22);
            this.tabCommon.Margin = new System.Windows.Forms.Padding(2);
            this.tabCommon.Name = "tabCommon";
            this.tabCommon.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.tabCommon.Size = new System.Drawing.Size(349, 156);
            this.tabCommon.TabIndex = 0;
            this.tabCommon.Text = "Common";
            // 
            // cmbLocale
            // 
            this.cmbLocale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocale.FormattingEnabled = true;
            this.cmbLocale.Location = new System.Drawing.Point(92, 121);
            this.cmbLocale.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbLocale.Name = "cmbLocale";
            this.cmbLocale.Size = new System.Drawing.Size(149, 21);
            this.cmbLocale.TabIndex = 15;
            // 
            // lblLocale
            // 
            this.lblLocale.Location = new System.Drawing.Point(9, 123);
            this.lblLocale.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLocale.Name = "lblLocale";
            this.lblLocale.Size = new System.Drawing.Size(80, 17);
            this.lblLocale.TabIndex = 14;
            this.lblLocale.Text = "Locale";
            // 
            // chkExitOnClose
            // 
            this.chkExitOnClose.Location = new System.Drawing.Point(9, 93);
            this.chkExitOnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.chkExitOnClose.Name = "chkExitOnClose";
            this.chkExitOnClose.Size = new System.Drawing.Size(325, 19);
            this.chkExitOnClose.TabIndex = 13;
            this.chkExitOnClose.Text = "Exit on Close";
            this.chkExitOnClose.UseVisualStyleBackColor = true;
            // 
            // chkHideAtStartup
            // 
            this.chkHideAtStartup.Location = new System.Drawing.Point(9, 37);
            this.chkHideAtStartup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.chkHideAtStartup.Name = "chkHideAtStartup";
            this.chkHideAtStartup.Size = new System.Drawing.Size(325, 19);
            this.chkHideAtStartup.TabIndex = 10;
            this.chkHideAtStartup.Text = "HideAtStartup";
            this.chkHideAtStartup.UseVisualStyleBackColor = true;
            // 
            // chkAutorun
            // 
            this.chkAutorun.Location = new System.Drawing.Point(9, 9);
            this.chkAutorun.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.chkAutorun.Name = "chkAutorun";
            this.chkAutorun.Size = new System.Drawing.Size(325, 19);
            this.chkAutorun.TabIndex = 11;
            this.chkAutorun.Text = "Autorun";
            this.chkAutorun.UseVisualStyleBackColor = true;
            // 
            // chkHideClosedTanks
            // 
            this.chkHideClosedTanks.Location = new System.Drawing.Point(9, 65);
            this.chkHideClosedTanks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.chkHideClosedTanks.Name = "chkHideClosedTanks";
            this.chkHideClosedTanks.Size = new System.Drawing.Size(325, 19);
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
            this.tabData.Location = new System.Drawing.Point(4, 22);
            this.tabData.Margin = new System.Windows.Forms.Padding(2);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.tabData.Size = new System.Drawing.Size(349, 156);
            this.tabData.TabIndex = 1;
            this.tabData.Text = "Data";
            // 
            // cmbTemperatureUoM
            // 
            this.cmbTemperatureUoM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTemperatureUoM.FormattingEnabled = true;
            this.cmbTemperatureUoM.Location = new System.Drawing.Point(143, 100);
            this.cmbTemperatureUoM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbTemperatureUoM.Name = "cmbTemperatureUoM";
            this.cmbTemperatureUoM.Size = new System.Drawing.Size(149, 21);
            this.cmbTemperatureUoM.TabIndex = 17;
            // 
            // lblTemperatureUoM
            // 
            this.lblTemperatureUoM.Location = new System.Drawing.Point(9, 102);
            this.lblTemperatureUoM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTemperatureUoM.Name = "lblTemperatureUoM";
            this.lblTemperatureUoM.Size = new System.Drawing.Size(131, 17);
            this.lblTemperatureUoM.TabIndex = 16;
            this.lblTemperatureUoM.Text = "TemperatureUoM";
            // 
            // cmbMassUoM
            // 
            this.cmbMassUoM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMassUoM.FormattingEnabled = true;
            this.cmbMassUoM.Location = new System.Drawing.Point(143, 70);
            this.cmbMassUoM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbMassUoM.Name = "cmbMassUoM";
            this.cmbMassUoM.Size = new System.Drawing.Size(149, 21);
            this.cmbMassUoM.TabIndex = 17;
            // 
            // lblMassUoM
            // 
            this.lblMassUoM.Location = new System.Drawing.Point(9, 72);
            this.lblMassUoM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMassUoM.Name = "lblMassUoM";
            this.lblMassUoM.Size = new System.Drawing.Size(131, 17);
            this.lblMassUoM.TabIndex = 16;
            this.lblMassUoM.Text = "MassUoM";
            // 
            // cmbVolumeUoM
            // 
            this.cmbVolumeUoM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVolumeUoM.FormattingEnabled = true;
            this.cmbVolumeUoM.Location = new System.Drawing.Point(143, 39);
            this.cmbVolumeUoM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbVolumeUoM.Name = "cmbVolumeUoM";
            this.cmbVolumeUoM.Size = new System.Drawing.Size(149, 21);
            this.cmbVolumeUoM.TabIndex = 17;
            // 
            // lblVolumeUoM
            // 
            this.lblVolumeUoM.Location = new System.Drawing.Point(9, 42);
            this.lblVolumeUoM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVolumeUoM.Name = "lblVolumeUoM";
            this.lblVolumeUoM.Size = new System.Drawing.Size(131, 17);
            this.lblVolumeUoM.TabIndex = 16;
            this.lblVolumeUoM.Text = "VolumeUoM";
            // 
            // cmbLengthUoM
            // 
            this.cmbLengthUoM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLengthUoM.FormattingEnabled = true;
            this.cmbLengthUoM.Location = new System.Drawing.Point(143, 9);
            this.cmbLengthUoM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbLengthUoM.Name = "cmbLengthUoM";
            this.cmbLengthUoM.Size = new System.Drawing.Size(149, 21);
            this.cmbLengthUoM.TabIndex = 17;
            // 
            // lblLengthUoM
            // 
            this.lblLengthUoM.Location = new System.Drawing.Point(9, 11);
            this.lblLengthUoM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLengthUoM.Name = "lblLengthUoM";
            this.lblLengthUoM.Size = new System.Drawing.Size(131, 17);
            this.lblLengthUoM.TabIndex = 16;
            this.lblLengthUoM.Text = "LengthUoM";
            // 
            // tabDAS
            // 
            this.tabDAS.BackColor = System.Drawing.SystemColors.Control;
            this.tabDAS.Controls.Add(this.cmbPort);
            this.tabDAS.Controls.Add(this.lblParameters);
            this.tabDAS.Controls.Add(this.cmbChannel);
            this.tabDAS.Controls.Add(this.lblChannel);
            this.tabDAS.Controls.Add(this.chkEnabled);
            this.tabDAS.Location = new System.Drawing.Point(4, 22);
            this.tabDAS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabDAS.Name = "tabDAS";
            this.tabDAS.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabDAS.Size = new System.Drawing.Size(349, 156);
            this.tabDAS.TabIndex = 2;
            this.tabDAS.Text = "DAS";
            // 
            // cmbPort
            // 
            this.cmbPort.Items.AddRange(new object[] {
            "COM3"});
            this.cmbPort.Location = new System.Drawing.Point(92, 39);
            this.cmbPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(130, 21);
            this.cmbPort.TabIndex = 3;
            this.cmbPort.Text = "COM3";
            // 
            // lblParameters
            // 
            this.lblParameters.Location = new System.Drawing.Point(13, 42);
            this.lblParameters.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParameters.Name = "lblParameters";
            this.lblParameters.Size = new System.Drawing.Size(102, 18);
            this.lblParameters.TabIndex = 2;
            this.lblParameters.Text = "Parameters";
            // 
            // cmbChannel
            // 
            this.cmbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChannel.FormattingEnabled = true;
            this.cmbChannel.Location = new System.Drawing.Point(92, 13);
            this.cmbChannel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbChannel.Name = "cmbChannel";
            this.cmbChannel.Size = new System.Drawing.Size(130, 21);
            this.cmbChannel.TabIndex = 1;
            // 
            // lblChannel
            // 
            this.lblChannel.Location = new System.Drawing.Point(13, 15);
            this.lblChannel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(50, 18);
            this.lblChannel.TabIndex = 0;
            this.lblChannel.Text = "Channel";
            // 
            // chkEnabled
            // 
            this.chkEnabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEnabled.Location = new System.Drawing.Point(13, 66);
            this.chkEnabled.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(209, 19);
            this.chkEnabled.TabIndex = 4;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // SettingsDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(376, 235);
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
            this.tabDAS.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
