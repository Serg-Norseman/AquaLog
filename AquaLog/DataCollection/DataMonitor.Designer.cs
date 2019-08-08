namespace AquaLog.DataCollection
{
    partial class DataMonitor
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.CheckBox chkEnableCommLED;
        private System.Windows.Forms.CheckBox chkEnableGetTemp;
        private System.Windows.Forms.TextBox textBox1;

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
            this.SuspendLayout();
            // 
            // chkEnableCommLED
            // 
            this.chkEnableCommLED.Location = new System.Drawing.Point(12, 12);
            this.chkEnableCommLED.Name = "chkEnableCommLED";
            this.chkEnableCommLED.Size = new System.Drawing.Size(153, 24);
            this.chkEnableCommLED.TabIndex = 3;
            this.chkEnableCommLED.Text = "EnableCommLED";
            this.chkEnableCommLED.UseVisualStyleBackColor = true;
            this.chkEnableCommLED.CheckedChanged += new System.EventHandler(this.chkEnableCommLED_CheckedChanged);
            // 
            // chkEnableGetTemp
            // 
            this.chkEnableGetTemp.Location = new System.Drawing.Point(12, 42);
            this.chkEnableGetTemp.Name = "chkEnableGetTemp";
            this.chkEnableGetTemp.Size = new System.Drawing.Size(153, 24);
            this.chkEnableGetTemp.TabIndex = 3;
            this.chkEnableGetTemp.Text = "EnableGetTemp";
            this.chkEnableGetTemp.UseVisualStyleBackColor = true;
            this.chkEnableGetTemp.CheckedChanged += new System.EventHandler(this.chkEnableGetTemp_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 72);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(442, 170);
            this.textBox1.TabIndex = 4;
            // 
            // DataMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 254);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chkEnableGetTemp);
            this.Controls.Add(this.chkEnableCommLED);
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
