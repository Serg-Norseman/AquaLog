namespace AquaMate.UI.Dialogs
{
    partial class InventoryEditDlg
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.PropertyGrid pgProps;
        private System.Windows.Forms.TabControl tabControl;
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCommon = new System.Windows.Forms.TabPage();
            this.pgProps = new System.Windows.Forms.PropertyGrid();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.lblState = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tabTransfers = new System.Windows.Forms.TabPage();
            this.lvTransfers = new AquaMate.UI.Components.ZListView();
            this.tabControl.SuspendLayout();
            this.tabCommon.SuspendLayout();
            this.tabTransfers.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(381, 482);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(120, 30);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "Accept";
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(506, 482);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabCommon);
            this.tabControl.Controls.Add(this.tabTransfers);
            this.tabControl.Location = new System.Drawing.Point(14, 14);
            this.tabControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(612, 458);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabCommon
            // 
            this.tabCommon.BackColor = System.Drawing.SystemColors.Control;
            this.tabCommon.Controls.Add(this.pgProps);
            this.tabCommon.Controls.Add(this.cmbState);
            this.tabCommon.Controls.Add(this.lblState);
            this.tabCommon.Controls.Add(this.cmbType);
            this.tabCommon.Controls.Add(this.lblType);
            this.tabCommon.Controls.Add(this.txtNote);
            this.tabCommon.Controls.Add(this.lblNote);
            this.tabCommon.Controls.Add(this.cmbBrand);
            this.tabCommon.Controls.Add(this.lblBrand);
            this.tabCommon.Controls.Add(this.txtName);
            this.tabCommon.Controls.Add(this.lblName);
            this.tabCommon.Location = new System.Drawing.Point(4, 28);
            this.tabCommon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabCommon.Name = "tabCommon";
            this.tabCommon.Padding = new System.Windows.Forms.Padding(11, 11, 11, 11);
            this.tabCommon.Size = new System.Drawing.Size(604, 426);
            this.tabCommon.TabIndex = 0;
            this.tabCommon.Text = "tabCommon";
            // 
            // pgProps
            // 
            this.pgProps.HelpVisible = false;
            this.pgProps.Location = new System.Drawing.Point(14, 236);
            this.pgProps.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.pgProps.Name = "pgProps";
            this.pgProps.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.pgProps.Size = new System.Drawing.Size(575, 169);
            this.pgProps.TabIndex = 10;
            this.pgProps.ToolbarVisible = false;
            // 
            // cmbState
            // 
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(148, 199);
            this.cmbState.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(169, 27);
            this.cmbState.TabIndex = 9;
            // 
            // lblState
            // 
            this.lblState.Location = new System.Drawing.Point(14, 202);
            this.lblState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(100, 21);
            this.lblState.TabIndex = 8;
            this.lblState.Text = "State";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(148, 90);
            this.cmbType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(169, 27);
            this.cmbType.TabIndex = 5;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(14, 94);
            this.lblType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(100, 21);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Type";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(148, 128);
            this.txtNote.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(265, 59);
            this.txtNote.TabIndex = 7;
            // 
            // lblNote
            // 
            this.lblNote.Location = new System.Drawing.Point(14, 131);
            this.lblNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(129, 21);
            this.lblNote.TabIndex = 6;
            this.lblNote.Text = "Note";
            // 
            // cmbBrand
            // 
            this.cmbBrand.Location = new System.Drawing.Point(148, 52);
            this.cmbBrand.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(265, 27);
            this.cmbBrand.TabIndex = 3;
            // 
            // lblBrand
            // 
            this.lblBrand.Location = new System.Drawing.Point(14, 56);
            this.lblBrand.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(129, 21);
            this.lblBrand.TabIndex = 2;
            this.lblBrand.Text = "Brand";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(148, 14);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(265, 26);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(14, 18);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(129, 21);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // tabTransfers
            // 
            this.tabTransfers.BackColor = System.Drawing.SystemColors.Control;
            this.tabTransfers.Controls.Add(this.lvTransfers);
            this.tabTransfers.Location = new System.Drawing.Point(4, 28);
            this.tabTransfers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabTransfers.Name = "tabTransfers";
            this.tabTransfers.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabTransfers.Size = new System.Drawing.Size(604, 426);
            this.tabTransfers.TabIndex = 1;
            this.tabTransfers.Text = "tabTransfers";
            // 
            // lvTransfers
            // 
            this.lvTransfers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTransfers.FullRowSelect = true;
            this.lvTransfers.HideSelection = false;
            this.lvTransfers.Location = new System.Drawing.Point(4, 4);
            this.lvTransfers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvTransfers.Name = "lvTransfers";
            this.lvTransfers.Order = System.Windows.Forms.SortOrder.None;
            this.lvTransfers.OwnerDraw = true;
            this.lvTransfers.Size = new System.Drawing.Size(596, 418);
            this.lvTransfers.SortColumn = 0;
            this.lvTransfers.TabIndex = 2;
            this.lvTransfers.UseCompatibleStateImageBehavior = false;
            this.lvTransfers.View = System.Windows.Forms.View.Details;
            // 
            // InventoryEditDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(640, 526);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InventoryEditDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inventory";
            this.tabControl.ResumeLayout(false);
            this.tabCommon.ResumeLayout(false);
            this.tabCommon.PerformLayout();
            this.tabTransfers.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
