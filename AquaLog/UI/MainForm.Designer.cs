namespace AquaLog.UI
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
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripButton btnPrev;
        private System.Windows.Forms.ToolStripButton btnNext;
        private System.Windows.Forms.ToolStripButton btnTanks;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFishes;
        private System.Windows.Forms.ToolStripButton btnInvertebrates;
        private System.Windows.Forms.ToolStripButton btnPlants;
        private System.Windows.Forms.ToolStripButton btnSpecies;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnLights;
        private System.Windows.Forms.ToolStripButton btnPumps;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnExpenses;
        private System.Windows.Forms.ToolStripButton btnNotes;
        private System.Windows.Forms.ToolStripButton btnWaterChanges;
        private System.Windows.Forms.ToolStripButton btnHistory;
        private System.Windows.Forms.ToolStripButton btnMaintenance;
        
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
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPrev = new System.Windows.Forms.ToolStripButton();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.btnTanks = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFishes = new System.Windows.Forms.ToolStripButton();
            this.btnPlants = new System.Windows.Forms.ToolStripButton();
            this.btnInvertebrates = new System.Windows.Forms.ToolStripButton();
            this.btnSpecies = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLights = new System.Windows.Forms.ToolStripButton();
            this.btnPumps = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExpenses = new System.Windows.Forms.ToolStripButton();
            this.btnNotes = new System.Windows.Forms.ToolStripButton();
            this.btnWaterChanges = new System.Windows.Forms.ToolStripButton();
            this.pnlTools = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnAddTank = new System.Windows.Forms.Button();
            this.btnEditTank = new System.Windows.Forms.Button();
            this.btnDeleteTank = new System.Windows.Forms.Button();
            this.pnlClient = new System.Windows.Forms.Panel();
            this.pnlObjects = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnHistory = new System.Windows.Forms.ToolStripButton();
            this.btnMaintenance = new System.Windows.Forms.ToolStripButton();
            this.menuMain.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.menuMain.Size = new System.Drawing.Size(882, 25);
            this.menuMain.TabIndex = 2;
            this.menuMain.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miExit});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(37, 19);
            this.miFile.Text = "File";
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(92, 22);
            this.miExit.Text = "Exit";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrev,
            this.btnNext,
            this.btnTanks,
            this.toolStripSeparator1,
            this.btnFishes,
            this.btnPlants,
            this.btnInvertebrates,
            this.btnSpecies,
            this.toolStripSeparator2,
            this.btnLights,
            this.btnPumps,
            this.toolStripSeparator3,
            this.btnExpenses,
            this.btnNotes,
            this.btnWaterChanges,
            this.btnHistory,
            this.btnMaintenance});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(882, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnPrev
            // 
            this.btnPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(34, 22);
            this.btnPrev.Text = "Prev";
            this.btnPrev.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrev.Click += new System.EventHandler(this.btnMainView_Click);
            // 
            // btnNext
            // 
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(35, 22);
            this.btnNext.Text = "Next";
            this.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNext.Click += new System.EventHandler(this.btnMainView_Click);
            // 
            // btnTanks
            // 
            this.btnTanks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTanks.Name = "btnTanks";
            this.btnTanks.Size = new System.Drawing.Size(44, 22);
            this.btnTanks.Text = "Home";
            this.btnTanks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTanks.Click += new System.EventHandler(this.btnMainView_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator1.Click += new System.EventHandler(this.btnMainView_Click);
            // 
            // btnFishes
            // 
            this.btnFishes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFishes.Name = "btnFishes";
            this.btnFishes.Size = new System.Drawing.Size(43, 22);
            this.btnFishes.Text = "Fishes";
            this.btnFishes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFishes.Click += new System.EventHandler(this.btnMainView_Click);
            // 
            // btnPlants
            // 
            this.btnPlants.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPlants.Name = "btnPlants";
            this.btnPlants.Size = new System.Drawing.Size(43, 22);
            this.btnPlants.Text = "Plants";
            this.btnPlants.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPlants.Click += new System.EventHandler(this.btnMainView_Click);
            // 
            // btnInvertebrates
            // 
            this.btnInvertebrates.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInvertebrates.Name = "btnInvertebrates";
            this.btnInvertebrates.Size = new System.Drawing.Size(79, 22);
            this.btnInvertebrates.Text = "Invertebrates";
            this.btnInvertebrates.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnInvertebrates.Click += new System.EventHandler(this.btnMainView_Click);
            // 
            // btnSpecies
            // 
            this.btnSpecies.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSpecies.Name = "btnSpecies";
            this.btnSpecies.Size = new System.Drawing.Size(50, 22);
            this.btnSpecies.Text = "Species";
            this.btnSpecies.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSpecies.Click += new System.EventHandler(this.btnMainView_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator2.Click += new System.EventHandler(this.btnMainView_Click);
            // 
            // btnLights
            // 
            this.btnLights.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLights.Name = "btnLights";
            this.btnLights.Size = new System.Drawing.Size(43, 22);
            this.btnLights.Text = "Lights";
            this.btnLights.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLights.Click += new System.EventHandler(this.btnMainView_Click);
            // 
            // btnPumps
            // 
            this.btnPumps.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPumps.Name = "btnPumps";
            this.btnPumps.Size = new System.Drawing.Size(48, 22);
            this.btnPumps.Text = "Pumps";
            this.btnPumps.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPumps.Click += new System.EventHandler(this.btnMainView_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator3.Click += new System.EventHandler(this.btnMainView_Click);
            // 
            // btnExpenses
            // 
            this.btnExpenses.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExpenses.Name = "btnExpenses";
            this.btnExpenses.Size = new System.Drawing.Size(58, 22);
            this.btnExpenses.Text = "Expenses";
            this.btnExpenses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExpenses.Click += new System.EventHandler(this.btnMainView_Click);
            // 
            // btnNotes
            // 
            this.btnNotes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNotes.Name = "btnNotes";
            this.btnNotes.Size = new System.Drawing.Size(42, 22);
            this.btnNotes.Text = "Notes";
            this.btnNotes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNotes.Click += new System.EventHandler(this.btnMainView_Click);
            // 
            // btnWaterChanges
            // 
            this.btnWaterChanges.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnWaterChanges.Name = "btnWaterChanges";
            this.btnWaterChanges.Size = new System.Drawing.Size(89, 22);
            this.btnWaterChanges.Text = "Water changes";
            this.btnWaterChanges.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnWaterChanges.Click += new System.EventHandler(this.btnMainView_Click);
            // 
            // pnlTools
            // 
            this.pnlTools.Controls.Add(this.pnlDate);
            this.pnlTools.Controls.Add(this.btnAddTank);
            this.pnlTools.Controls.Add(this.btnEditTank);
            this.pnlTools.Controls.Add(this.btnDeleteTank);
            this.pnlTools.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTools.Location = new System.Drawing.Point(0, 50);
            this.pnlTools.Name = "pnlTools";
            this.pnlTools.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTools.Size = new System.Drawing.Size(210, 503);
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
            this.pnlClient.Location = new System.Drawing.Point(210, 50);
            this.pnlClient.Name = "pnlClient";
            this.pnlClient.Padding = new System.Windows.Forms.Padding(10);
            this.pnlClient.Size = new System.Drawing.Size(672, 503);
            this.pnlClient.TabIndex = 5;
            // 
            // pnlObjects
            // 
            this.pnlObjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlObjects.Location = new System.Drawing.Point(10, 10);
            this.pnlObjects.Name = "pnlObjects";
            this.pnlObjects.Size = new System.Drawing.Size(652, 483);
            this.pnlObjects.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
            // 
            // btnHistory
            // 
            this.btnHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(49, 22);
            this.btnHistory.Text = "History";
            this.btnHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnHistory.Click += new System.EventHandler(this.btnMainView_Click);
            // 
            // btnMaintenance
            // 
            this.btnMaintenance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMaintenance.Name = "btnMaintenance";
            this.btnMaintenance.Size = new System.Drawing.Size(80, 22);
            this.btnMaintenance.Text = "Maintenance";
            this.btnMaintenance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMaintenance.Click += new System.EventHandler(this.btnMainView_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
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
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlTools.ResumeLayout(false);
            this.pnlDate.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
