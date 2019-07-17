namespace AquaLog
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel pnlTools;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel pnlClient;
        private System.Windows.Forms.Panel pnlDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel pnlObjects;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnAddTank;
        private System.Windows.Forms.Button btnEditTank;
        private System.Windows.Forms.Button btnDeleteTank;
        
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
            this.components = new System.ComponentModel.Container();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.pnlTools = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnAddTank = new System.Windows.Forms.Button();
            this.btnEditTank = new System.Windows.Forms.Button();
            this.btnDeleteTank = new System.Windows.Forms.Button();
            this.pnlClient = new System.Windows.Forms.Panel();
            this.pnlObjects = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuMain.SuspendLayout();
            this.pnlTools.SuspendLayout();
            this.pnlDate.SuspendLayout();
            this.pnlClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuMain.Size = new System.Drawing.Size(882, 30);
            this.menuMain.TabIndex = 2;
            this.menuMain.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(44, 24);
            this.miFile.Text = "File";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Location = new System.Drawing.Point(0, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(882, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // pnlTools
            // 
            this.pnlTools.Controls.Add(this.pnlDate);
            this.pnlTools.Controls.Add(this.btnAddTank);
            this.pnlTools.Controls.Add(this.btnEditTank);
            this.pnlTools.Controls.Add(this.btnDeleteTank);
            this.pnlTools.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTools.Location = new System.Drawing.Point(0, 55);
            this.pnlTools.Name = "pnlTools";
            this.pnlTools.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTools.Size = new System.Drawing.Size(210, 498);
            this.pnlTools.TabIndex = 4;
            // 
            // pnlDate
            // 
            this.pnlDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDate.Controls.Add(this.lblDate);
            this.pnlDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDate.Location = new System.Drawing.Point(10, 10);
            this.pnlDate.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(190, 59);
            this.pnlDate.TabIndex = 0;
            // 
            // lblDate
            // 
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDate.Location = new System.Drawing.Point(0, 0);
            this.lblDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(188, 57);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "lblDate";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddTank
            // 
            this.btnAddTank.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddTank.Location = new System.Drawing.Point(10, 89);
            this.btnAddTank.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnAddTank.Name = "btnAddTank";
            this.btnAddTank.Size = new System.Drawing.Size(190, 30);
            this.btnAddTank.TabIndex = 2;
            this.btnAddTank.Text = "Add Tank";
            this.btnAddTank.UseVisualStyleBackColor = true;
            this.btnAddTank.Click += new System.EventHandler(this.btnAddTank_Click);
            // 
            // btnEditTank
            // 
            this.btnEditTank.Location = new System.Drawing.Point(10, 129);
            this.btnEditTank.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnEditTank.Name = "btnEditTank";
            this.btnEditTank.Size = new System.Drawing.Size(190, 30);
            this.btnEditTank.TabIndex = 3;
            this.btnEditTank.Text = "Edit Tank";
            this.btnEditTank.UseVisualStyleBackColor = true;
            this.btnEditTank.Click += new System.EventHandler(this.btnEditTank_Click);
            // 
            // btnDeleteTank
            // 
            this.btnDeleteTank.Location = new System.Drawing.Point(10, 169);
            this.btnDeleteTank.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteTank.Name = "btnDeleteTank";
            this.btnDeleteTank.Size = new System.Drawing.Size(190, 30);
            this.btnDeleteTank.TabIndex = 4;
            this.btnDeleteTank.Text = "Delete Tank";
            this.btnDeleteTank.UseVisualStyleBackColor = true;
            this.btnDeleteTank.Click += new System.EventHandler(this.btnDeleteTank_Click);
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.pnlObjects);
            this.pnlClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClient.Location = new System.Drawing.Point(210, 55);
            this.pnlClient.Name = "pnlClient";
            this.pnlClient.Padding = new System.Windows.Forms.Padding(10);
            this.pnlClient.Size = new System.Drawing.Size(672, 498);
            this.pnlClient.TabIndex = 5;
            // 
            // pnlObjects
            // 
            this.pnlObjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlObjects.Location = new System.Drawing.Point(10, 10);
            this.pnlObjects.Name = "pnlObjects";
            this.pnlObjects.Size = new System.Drawing.Size(652, 478);
            this.pnlObjects.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.pnlClient);
            this.Controls.Add(this.pnlTools);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuMain);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AquaLog";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.pnlTools.ResumeLayout(false);
            this.pnlDate.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
