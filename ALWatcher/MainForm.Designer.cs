namespace ALWatcher
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblPortData;
        private System.Windows.Forms.CheckBox chkEnableCommLED;

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
            this.lblPortData = new System.Windows.Forms.Label();
            this.chkEnableCommLED = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblPortData
            // 
            this.lblPortData.Location = new System.Drawing.Point(50, 28);
            this.lblPortData.Name = "lblPortData";
            this.lblPortData.Size = new System.Drawing.Size(211, 23);
            this.lblPortData.TabIndex = 0;
            this.lblPortData.Text = "label1";
            // 
            // chkEnableCommLED
            // 
            this.chkEnableCommLED.Location = new System.Drawing.Point(45, 128);
            this.chkEnableCommLED.Name = "chkEnableCommLED";
            this.chkEnableCommLED.Size = new System.Drawing.Size(153, 24);
            this.chkEnableCommLED.TabIndex = 3;
            this.chkEnableCommLED.Text = "EnableCommLED";
            this.chkEnableCommLED.UseVisualStyleBackColor = true;
            this.chkEnableCommLED.CheckedChanged += new System.EventHandler(this.chkEnableCommLED_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 261);
            this.Controls.Add(this.chkEnableCommLED);
            this.Controls.Add(this.lblPortData);
            this.Name = "MainForm";
            this.Text = "ALWatcher";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.ResumeLayout(false);

        }
    }
}
