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
            this.btnAccept.Location = new System.Drawing.Point(305, 386);
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
            this.btnCancel.Location = new System.Drawing.Point(405, 386);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 24);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabCommon);
            this.tabControl.Controls.Add(this.tabTransfers);
            this.tabControl.Location = new System.Drawing.Point(11, 11);
            this.tabControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(490, 366);
            this.tabControl.TabIndex = 15;
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
            this.tabCommon.Location = new System.Drawing.Point(4, 22);
            this.tabCommon.Name = "tabCommon";
            this.tabCommon.Padding = new System.Windows.Forms.Padding(9);
            this.tabCommon.Size = new System.Drawing.Size(482, 340);
            this.tabCommon.TabIndex = 0;
            this.tabCommon.Text = "tabCommon";
            // 
            // pgProps
            // 
            this.pgProps.HelpVisible = false;
            this.pgProps.Location = new System.Drawing.Point(11, 189);
            this.pgProps.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.pgProps.Name = "pgProps";
            this.pgProps.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.pgProps.Size = new System.Drawing.Size(460, 135);
            this.pgProps.TabIndex = 25;
            this.pgProps.ToolbarVisible = false;
            // 
            // cmbState
            // 
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(118, 159);
            this.cmbState.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(136, 21);
            this.cmbState.TabIndex = 21;
            // 
            // lblState
            // 
            this.lblState.Location = new System.Drawing.Point(11, 162);
            this.lblState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(80, 17);
            this.lblState.TabIndex = 19;
            this.lblState.Text = "State";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(118, 72);
            this.cmbType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(136, 21);
            this.cmbType.TabIndex = 22;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(11, 75);
            this.lblType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(80, 17);
            this.lblType.TabIndex = 20;
            this.lblType.Text = "Type";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(118, 102);
            this.txtNote.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(213, 48);
            this.txtNote.TabIndex = 24;
            // 
            // lblNote
            // 
            this.lblNote.Location = new System.Drawing.Point(11, 105);
            this.lblNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(103, 17);
            this.lblNote.TabIndex = 23;
            this.lblNote.Text = "Note";
            // 
            // cmbBrand
            // 
            this.cmbBrand.Location = new System.Drawing.Point(118, 42);
            this.cmbBrand.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(213, 21);
            this.cmbBrand.TabIndex = 18;
            // 
            // lblBrand
            // 
            this.lblBrand.Location = new System.Drawing.Point(11, 45);
            this.lblBrand.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(103, 17);
            this.lblBrand.TabIndex = 17;
            this.lblBrand.Text = "Brand";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(118, 11);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(213, 22);
            this.txtName.TabIndex = 16;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(11, 14);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(103, 17);
            this.lblName.TabIndex = 15;
            this.lblName.Text = "Name";
            // 
            // tabTransfers
            // 
            this.tabTransfers.BackColor = System.Drawing.SystemColors.Control;
            this.tabTransfers.Controls.Add(this.lvTransfers);
            this.tabTransfers.Location = new System.Drawing.Point(4, 22);
            this.tabTransfers.Name = "tabTransfers";
            this.tabTransfers.Padding = new System.Windows.Forms.Padding(3);
            this.tabTransfers.Size = new System.Drawing.Size(482, 340);
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
            this.lvTransfers.Size = new System.Drawing.Size(476, 334);
            this.lvTransfers.SortColumn = 0;
            this.lvTransfers.TabIndex = 2;
            this.lvTransfers.UseCompatibleStateImageBehavior = false;
            this.lvTransfers.View = System.Windows.Forms.View.Details;
            // 
            // InventoryEditDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(512, 421);
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
