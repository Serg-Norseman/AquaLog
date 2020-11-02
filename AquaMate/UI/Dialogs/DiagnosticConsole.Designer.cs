namespace AquaMate.UI.Dialogs
{
    partial class DiagnosticConsole
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.ComponentModel.BackgroundWorker bgwExecuteQuery;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpInterpreter;
        private System.Windows.Forms.TextBox rtbQuery;
        private System.Windows.Forms.TextBox tbAnswer;
        private System.Windows.Forms.Button btnCancelQuery;
        private System.Windows.Forms.Label lblMoreOrStop;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.Button btnClearQ;
        private System.Windows.Forms.Button btnXeqQuery;
        private System.Windows.Forms.GroupBox grpAnswer;
        private System.Windows.Forms.GroupBox grpQuery;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miNew;
        private System.Windows.Forms.ToolStripMenuItem miOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem miEdit;
        private System.Windows.Forms.ToolStripMenuItem miUndo;
        private System.Windows.Forms.ToolStripMenuItem miRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem miCut;
        private System.Windows.Forms.ToolStripMenuItem miCopy;
        private System.Windows.Forms.ToolStripMenuItem miPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem miSelectAll;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Button btnClearA;
        private System.Windows.Forms.ToolStripMenuItem miSave;
        private System.Windows.Forms.ToolStripMenuItem miSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabPage tabKnowledges;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpInterpreter = new System.Windows.Forms.TabPage();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.grpAnswer = new System.Windows.Forms.GroupBox();
            this.btnClearA = new System.Windows.Forms.Button();
            this.tbAnswer = new System.Windows.Forms.TextBox();
            this.grpQuery = new System.Windows.Forms.GroupBox();
            this.rtbQuery = new System.Windows.Forms.TextBox();
            this.btnCancelQuery = new System.Windows.Forms.Button();
            this.lblMoreOrStop = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnMore = new System.Windows.Forms.Button();
            this.btnClearQ = new System.Windows.Forms.Button();
            this.btnXeqQuery = new System.Windows.Forms.Button();
            this.tabKnowledges = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miNew = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.miSave = new System.Windows.Forms.ToolStripMenuItem();
            this.miSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.miUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.miRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.miCut = new System.Windows.Forms.ToolStripMenuItem();
            this.miCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.miPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.miSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.bgwExecuteQuery = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpInterpreter.SuspendLayout();
            this.grpInput.SuspendLayout();
            this.grpAnswer.SuspendLayout();
            this.grpQuery.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(840, 600);
            this.panel1.TabIndex = 15;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpInterpreter);
            this.tabControl.Controls.Add(this.tabKnowledges);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(840, 600);
            this.tabControl.TabIndex = 14;
            // 
            // tpInterpreter
            // 
            this.tpInterpreter.BackColor = System.Drawing.Color.LightCyan;
            this.tpInterpreter.Controls.Add(this.grpInput);
            this.tpInterpreter.Controls.Add(this.grpAnswer);
            this.tpInterpreter.Controls.Add(this.grpQuery);
            this.tpInterpreter.Location = new System.Drawing.Point(4, 22);
            this.tpInterpreter.Name = "tpInterpreter";
            this.tpInterpreter.Padding = new System.Windows.Forms.Padding(3);
            this.tpInterpreter.Size = new System.Drawing.Size(832, 574);
            this.tpInterpreter.TabIndex = 4;
            this.tpInterpreter.Text = "Prolog console";
            // 
            // grpInput
            // 
            this.grpInput.BackColor = System.Drawing.Color.LightCyan;
            this.grpInput.Controls.Add(this.tbInput);
            this.grpInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInput.Location = new System.Drawing.Point(3, 452);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(826, 119);
            this.grpInput.TabIndex = 22;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Input";
            // 
            // tbInput
            // 
            this.tbInput.BackColor = System.Drawing.Color.White;
            this.tbInput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbInput.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInput.Location = new System.Drawing.Point(3, 16);
            this.tbInput.Multiline = true;
            this.tbInput.Name = "tbInput";
            this.tbInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInput.Size = new System.Drawing.Size(820, 100);
            this.tbInput.TabIndex = 22;
            this.tbInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInput_KeyDown);
            // 
            // grpAnswer
            // 
            this.grpAnswer.Controls.Add(this.btnClearA);
            this.grpAnswer.Controls.Add(this.tbAnswer);
            this.grpAnswer.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAnswer.Location = new System.Drawing.Point(3, 153);
            this.grpAnswer.Name = "grpAnswer";
            this.grpAnswer.Size = new System.Drawing.Size(826, 299);
            this.grpAnswer.TabIndex = 10;
            this.grpAnswer.TabStop = false;
            this.grpAnswer.Text = "Answer";
            // 
            // btnClearA
            // 
            this.btnClearA.BackColor = System.Drawing.SystemColors.Control;
            this.btnClearA.Location = new System.Drawing.Point(770, 19);
            this.btnClearA.Name = "btnClearA";
            this.btnClearA.Size = new System.Drawing.Size(50, 23);
            this.btnClearA.TabIndex = 25;
            this.btnClearA.Text = "Clear";
            this.btnClearA.UseVisualStyleBackColor = false;
            this.btnClearA.Click += new System.EventHandler(this.btnClearA_Click);
            // 
            // tbAnswer
            // 
            this.tbAnswer.BackColor = System.Drawing.SystemColors.Info;
            this.tbAnswer.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbAnswer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbAnswer.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAnswer.Location = new System.Drawing.Point(3, 48);
            this.tbAnswer.Multiline = true;
            this.tbAnswer.Name = "tbAnswer";
            this.tbAnswer.ReadOnly = true;
            this.tbAnswer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbAnswer.Size = new System.Drawing.Size(820, 248);
            this.tbAnswer.TabIndex = 14;
            // 
            // grpQuery
            // 
            this.grpQuery.Controls.Add(this.rtbQuery);
            this.grpQuery.Controls.Add(this.btnCancelQuery);
            this.grpQuery.Controls.Add(this.lblMoreOrStop);
            this.grpQuery.Controls.Add(this.btnStop);
            this.grpQuery.Controls.Add(this.btnMore);
            this.grpQuery.Controls.Add(this.btnClearQ);
            this.grpQuery.Controls.Add(this.btnXeqQuery);
            this.grpQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpQuery.Location = new System.Drawing.Point(3, 3);
            this.grpQuery.Name = "grpQuery";
            this.grpQuery.Size = new System.Drawing.Size(826, 150);
            this.grpQuery.TabIndex = 8;
            this.grpQuery.TabStop = false;
            this.grpQuery.Text = "Query";
            // 
            // rtbQuery
            // 
            this.rtbQuery.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbQuery.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbQuery.Location = new System.Drawing.Point(3, 48);
            this.rtbQuery.Multiline = true;
            this.rtbQuery.Name = "rtbQuery";
            this.rtbQuery.Size = new System.Drawing.Size(820, 99);
            this.rtbQuery.TabIndex = 19;
            this.rtbQuery.Text = "x = A; readln(L), writelnf( \"Line: {0}\", [L])";
            // 
            // btnCancelQuery
            // 
            this.btnCancelQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelQuery.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelQuery.Enabled = false;
            this.btnCancelQuery.Location = new System.Drawing.Point(660, 19);
            this.btnCancelQuery.Name = "btnCancelQuery";
            this.btnCancelQuery.Size = new System.Drawing.Size(104, 23);
            this.btnCancelQuery.TabIndex = 18;
            this.btnCancelQuery.Text = "Interrupt long run";
            this.btnCancelQuery.UseVisualStyleBackColor = false;
            this.btnCancelQuery.Visible = false;
            this.btnCancelQuery.Click += new System.EventHandler(this.btnCancelQuery_Click);
            // 
            // lblMoreOrStop
            // 
            this.lblMoreOrStop.AutoSize = true;
            this.lblMoreOrStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoreOrStop.ForeColor = System.Drawing.Color.Red;
            this.lblMoreOrStop.Location = new System.Drawing.Point(223, 24);
            this.lblMoreOrStop.Name = "lblMoreOrStop";
            this.lblMoreOrStop.Size = new System.Drawing.Size(115, 13);
            this.lblMoreOrStop.TabIndex = 17;
            this.lblMoreOrStop.Text = "Press More or Stop";
            this.lblMoreOrStop.Visible = false;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.SystemColors.Control;
            this.btnStop.Location = new System.Drawing.Point(170, 19);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(47, 23);
            this.btnStop.TabIndex = 16;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnMore
            // 
            this.btnMore.BackColor = System.Drawing.SystemColors.Control;
            this.btnMore.Location = new System.Drawing.Point(117, 19);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(47, 23);
            this.btnMore.TabIndex = 15;
            this.btnMore.Text = "More";
            this.btnMore.UseVisualStyleBackColor = false;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // btnClearQ
            // 
            this.btnClearQ.BackColor = System.Drawing.SystemColors.Control;
            this.btnClearQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearQ.Location = new System.Drawing.Point(770, 19);
            this.btnClearQ.Name = "btnClearQ";
            this.btnClearQ.Size = new System.Drawing.Size(50, 23);
            this.btnClearQ.TabIndex = 12;
            this.btnClearQ.Text = "Clear";
            this.btnClearQ.UseVisualStyleBackColor = false;
            this.btnClearQ.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnXeqQuery
            // 
            this.btnXeqQuery.BackColor = System.Drawing.SystemColors.Control;
            this.btnXeqQuery.Location = new System.Drawing.Point(11, 19);
            this.btnXeqQuery.Name = "btnXeqQuery";
            this.btnXeqQuery.Size = new System.Drawing.Size(100, 23);
            this.btnXeqQuery.TabIndex = 11;
            this.btnXeqQuery.Text = "Execute query";
            this.btnXeqQuery.UseVisualStyleBackColor = false;
            this.btnXeqQuery.Click += new System.EventHandler(this.btnXeqQuery_Click);
            // 
            // tabKnowledges
            // 
            this.tabKnowledges.Location = new System.Drawing.Point(4, 22);
            this.tabKnowledges.Name = "tabKnowledges";
            this.tabKnowledges.Padding = new System.Windows.Forms.Padding(3);
            this.tabKnowledges.Size = new System.Drawing.Size(832, 574);
            this.tabKnowledges.TabIndex = 5;
            this.tabKnowledges.Text = "Knowledges";
            this.tabKnowledges.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miEdit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(840, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNew,
            this.miOpen,
            this.toolStripSeparator,
            this.miSave,
            this.miSaveAs,
            this.toolStripSeparator1,
            this.miExit});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(37, 20);
            this.miFile.Text = "&File";
            // 
            // miNew
            // 
            this.miNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miNew.Name = "miNew";
            this.miNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.miNew.Size = new System.Drawing.Size(146, 22);
            this.miNew.Text = "&New";
            // 
            // miOpen
            // 
            this.miOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miOpen.Name = "miOpen";
            this.miOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.miOpen.Size = new System.Drawing.Size(146, 22);
            this.miOpen.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
            // 
            // miSave
            // 
            this.miSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miSave.Name = "miSave";
            this.miSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.miSave.Size = new System.Drawing.Size(146, 22);
            this.miSave.Text = "&Save";
            // 
            // miSaveAs
            // 
            this.miSaveAs.Name = "miSaveAs";
            this.miSaveAs.Size = new System.Drawing.Size(146, 22);
            this.miSaveAs.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(146, 22);
            this.miExit.Text = "E&xit";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // miEdit
            // 
            this.miEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miUndo,
            this.miRedo,
            this.toolStripSeparator3,
            this.miCut,
            this.miCopy,
            this.miPaste,
            this.toolStripSeparator4,
            this.miSelectAll});
            this.miEdit.Name = "miEdit";
            this.miEdit.Size = new System.Drawing.Size(39, 20);
            this.miEdit.Text = "&Edit";
            // 
            // miUndo
            // 
            this.miUndo.Name = "miUndo";
            this.miUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.miUndo.Size = new System.Drawing.Size(144, 22);
            this.miUndo.Text = "&Undo";
            // 
            // miRedo
            // 
            this.miRedo.Name = "miRedo";
            this.miRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.miRedo.Size = new System.Drawing.Size(144, 22);
            this.miRedo.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
            // 
            // miCut
            // 
            this.miCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miCut.Name = "miCut";
            this.miCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.miCut.Size = new System.Drawing.Size(144, 22);
            this.miCut.Text = "Cu&t";
            // 
            // miCopy
            // 
            this.miCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miCopy.Name = "miCopy";
            this.miCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.miCopy.Size = new System.Drawing.Size(144, 22);
            this.miCopy.Text = "&Copy";
            // 
            // miPaste
            // 
            this.miPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miPaste.Name = "miPaste";
            this.miPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.miPaste.Size = new System.Drawing.Size(144, 22);
            this.miPaste.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
            // 
            // miSelectAll
            // 
            this.miSelectAll.Name = "miSelectAll";
            this.miSelectAll.Size = new System.Drawing.Size(144, 22);
            this.miSelectAll.Text = "Select &All";
            // 
            // bgwExecuteQuery
            // 
            this.bgwExecuteQuery.WorkerReportsProgress = true;
            this.bgwExecuteQuery.WorkerSupportsCancellation = true;
            this.bgwExecuteQuery.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwExecuteQuery_DoWork);
            this.bgwExecuteQuery.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwExecuteQuery_ProgressChanged);
            this.bgwExecuteQuery.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwExecuteQuery_RunWorkerCompleted);
            // 
            // DiagnosticConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 624);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DiagnosticConsole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tpInterpreter.ResumeLayout(false);
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.grpAnswer.ResumeLayout(false);
            this.grpAnswer.PerformLayout();
            this.grpQuery.ResumeLayout(false);
            this.grpQuery.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
