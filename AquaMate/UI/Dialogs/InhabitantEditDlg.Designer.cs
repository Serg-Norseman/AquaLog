namespace AquaMate.UI.Dialogs
{
    partial class InhabitantEditDlg
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbSex;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lblSpecies;
        private System.Windows.Forms.ComboBox cmbSpecies;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.Label lblState;
        private AquaMate.UI.Components.ImageViewer imgViewer;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCommon;
        private System.Windows.Forms.TabPage tabTransfers;
        private AquaMate.UI.Components.ZListView lvTransfers;
        
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
            this.lblSex = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblSpecies = new System.Windows.Forms.Label();
            this.cmbSpecies = new System.Windows.Forms.ComboBox();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.lblState = new System.Windows.Forms.Label();
            this.imgViewer = new AquaMate.UI.Components.ImageViewer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCommon = new System.Windows.Forms.TabPage();
            this.tabTransfers = new System.Windows.Forms.TabPage();
            this.lvTransfers = new AquaMate.UI.Components.ZListView();
            this.tabControl1.SuspendLayout();
            this.tabCommon.SuspendLayout();
            this.tabTransfers.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(599, 251);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(96, 24);
            this.btnAccept.TabIndex = 8;
            this.btnAccept.Text = "Accept";
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(699, 251);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 24);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(262, 14);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(80, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(588, 14);
            this.lblSex.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(80, 17);
            this.lblSex.TabIndex = 2;
            this.lblSex.Text = "Sex";
            // 
            // lblNote
            // 
            this.lblNote.Location = new System.Drawing.Point(262, 75);
            this.lblNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(80, 17);
            this.lblNote.TabIndex = 6;
            this.lblNote.Text = "Note";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(345, 11);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(239, 22);
            this.txtName.TabIndex = 1;
            // 
            // cmbSex
            // 
            this.cmbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Location = new System.Drawing.Point(638, 11);
            this.cmbSex.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(124, 21);
            this.cmbSex.TabIndex = 3;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(345, 72);
            this.txtNote.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(417, 48);
            this.txtNote.TabIndex = 7;
            // 
            // lblSpecies
            // 
            this.lblSpecies.Location = new System.Drawing.Point(262, 45);
            this.lblSpecies.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSpecies.Name = "lblSpecies";
            this.lblSpecies.Size = new System.Drawing.Size(88, 17);
            this.lblSpecies.TabIndex = 4;
            this.lblSpecies.Text = "Species";
            // 
            // cmbSpecies
            // 
            this.cmbSpecies.Location = new System.Drawing.Point(345, 42);
            this.cmbSpecies.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbSpecies.Name = "cmbSpecies";
            this.cmbSpecies.Size = new System.Drawing.Size(239, 21);
            this.cmbSpecies.TabIndex = 5;
            this.cmbSpecies.SelectedIndexChanged += new System.EventHandler(this.cmbSpecies_SelectedIndexChanged);
            // 
            // cmbState
            // 
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(345, 129);
            this.cmbState.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(136, 21);
            this.cmbState.TabIndex = 25;
            // 
            // lblState
            // 
            this.lblState.Location = new System.Drawing.Point(262, 132);
            this.lblState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(80, 17);
            this.lblState.TabIndex = 24;
            this.lblState.Text = "State";
            // 
            // imgViewer
            // 
            this.imgViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgViewer.Location = new System.Drawing.Point(12, 12);
            this.imgViewer.Name = "imgViewer";
            this.imgViewer.Size = new System.Drawing.Size(245, 172);
            this.imgViewer.TabIndex = 26;
            this.imgViewer.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCommon);
            this.tabControl1.Controls.Add(this.tabTransfers);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(783, 227);
            this.tabControl1.TabIndex = 27;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabCommon
            // 
            this.tabCommon.BackColor = System.Drawing.SystemColors.Control;
            this.tabCommon.Controls.Add(this.imgViewer);
            this.tabCommon.Controls.Add(this.cmbState);
            this.tabCommon.Controls.Add(this.lblState);
            this.tabCommon.Controls.Add(this.txtNote);
            this.tabCommon.Controls.Add(this.cmbSex);
            this.tabCommon.Controls.Add(this.cmbSpecies);
            this.tabCommon.Controls.Add(this.txtName);
            this.tabCommon.Controls.Add(this.lblNote);
            this.tabCommon.Controls.Add(this.lblSpecies);
            this.tabCommon.Controls.Add(this.lblSex);
            this.tabCommon.Controls.Add(this.lblName);
            this.tabCommon.Location = new System.Drawing.Point(4, 22);
            this.tabCommon.Name = "tabCommon";
            this.tabCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tabCommon.Size = new System.Drawing.Size(775, 201);
            this.tabCommon.TabIndex = 0;
            this.tabCommon.Text = "tabCommon";
            // 
            // tabTransfers
            // 
            this.tabTransfers.BackColor = System.Drawing.SystemColors.Control;
            this.tabTransfers.Controls.Add(this.lvTransfers);
            this.tabTransfers.Location = new System.Drawing.Point(4, 22);
            this.tabTransfers.Name = "tabTransfers";
            this.tabTransfers.Padding = new System.Windows.Forms.Padding(3);
            this.tabTransfers.Size = new System.Drawing.Size(775, 201);
            this.tabTransfers.TabIndex = 1;
            this.tabTransfers.Text = "tabTransfers";
            // 
            // lvTransfers
            // 
            this.lvTransfers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTransfers.FullRowSelect = true;
            this.lvTransfers.HideSelection = false;
            this.lvTransfers.Location = new System.Drawing.Point(3, 3);
            this.lvTransfers.Name = "lvTransfers";
            this.lvTransfers.Order = System.Windows.Forms.SortOrder.None;
            this.lvTransfers.OwnerDraw = true;
            this.lvTransfers.Size = new System.Drawing.Size(769, 195);
            this.lvTransfers.SortColumn = 0;
            this.lvTransfers.TabIndex = 3;
            this.lvTransfers.UseCompatibleStateImageBehavior = false;
            this.lvTransfers.View = System.Windows.Forms.View.Details;
            // 
            // InhabitantEditDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(806, 286);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InhabitantEditDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inhabitant";
            this.tabControl1.ResumeLayout(false);
            this.tabCommon.ResumeLayout(false);
            this.tabCommon.PerformLayout();
            this.tabTransfers.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
