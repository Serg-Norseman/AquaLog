namespace AquaLog.UI.Dialogs
{
    partial class DataMonitor
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.CheckBox chkEnableCommLED;
        private System.Windows.Forms.CheckBox chkEnableGetTemp;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblChannel;
        private System.Windows.Forms.ComboBox cmbChannel;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;

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
            this.chkEnableCommLED = new System.Windows.Forms.CheckBox();
            this.chkEnableGetTemp = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblChannel = new System.Windows.Forms.Label();
            this.cmbChannel = new System.Windows.Forms.ComboBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkEnableCommLED
            // 
            this.chkEnableCommLED.Location = new System.Drawing.Point(12, 63);
            this.chkEnableCommLED.Name = "chkEnableCommLED";
            this.chkEnableCommLED.Size = new System.Drawing.Size(153, 24);
            this.chkEnableCommLED.TabIndex = 3;
            this.chkEnableCommLED.Text = "EnableCommLED";
            this.chkEnableCommLED.UseVisualStyleBackColor = true;
            this.chkEnableCommLED.CheckedChanged += new System.EventHandler(this.chkEnableCommLED_CheckedChanged);
            // 
            // chkEnableGetTemp
            // 
            this.chkEnableGetTemp.Location = new System.Drawing.Point(12, 93);
            this.chkEnableGetTemp.Name = "chkEnableGetTemp";
            this.chkEnableGetTemp.Size = new System.Drawing.Size(153, 24);
            this.chkEnableGetTemp.TabIndex = 3;
            this.chkEnableGetTemp.Text = "EnableGetTemp";
            this.chkEnableGetTemp.UseVisualStyleBackColor = true;
            this.chkEnableGetTemp.CheckedChanged += new System.EventHandler(this.chkEnableGetTemp_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 123);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(442, 176);
            this.textBox1.TabIndex = 4;
            // 
            // lblChannel
            // 
            this.lblChannel.Location = new System.Drawing.Point(12, 15);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(63, 23);
            this.lblChannel.TabIndex = 5;
            this.lblChannel.Text = "Channel";
            // 
            // cmbChannel
            // 
            this.cmbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChannel.FormattingEnabled = true;
            this.cmbChannel.Items.AddRange(new object[] {
            "Serial"});
            this.cmbChannel.Location = new System.Drawing.Point(81, 12);
            this.cmbChannel.Name = "cmbChannel";
            this.cmbChannel.Size = new System.Drawing.Size(121, 21);
            this.cmbChannel.TabIndex = 6;
            // 
            // lblPort
            // 
            this.lblPort.Location = new System.Drawing.Point(242, 15);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(41, 23);
            this.lblPort.TabIndex = 5;
            this.lblPort.Text = "Port";
            // 
            // cmbPort
            // 
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Items.AddRange(new object[] {
            "COM3"});
            this.cmbPort.Location = new System.Drawing.Point(289, 12);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(121, 21);
            this.cmbPort.TabIndex = 6;
            this.cmbPort.Text = "COM3";
            // 
            // btnClose
            // 
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(379, 93);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(298, 93);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 8;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // DataMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 311);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cmbPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.cmbChannel);
            this.Controls.Add(this.lblChannel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chkEnableGetTemp);
            this.Controls.Add(this.chkEnableCommLED);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DataMonitor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
