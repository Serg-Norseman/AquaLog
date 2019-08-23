namespace AquaLog.UI
{
    partial class AquariumEditDlg
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblShape;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbShape;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCommon;
        private System.Windows.Forms.TabPage tabTank;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblHeigth;
        private System.Windows.Forms.Label lblDepth;
        private System.Windows.Forms.TextBox txtHeigth;
        private System.Windows.Forms.TextBox txtDepth;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtTankVolume;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.DateTimePicker dtpStopDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblStopDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.ComboBox cmbWaterType;
        private System.Windows.Forms.Label lblWaterType;
        private System.Windows.Forms.TextBox txtWaterVolume;
        private System.Windows.Forms.Label lblWaterVolume;
        private System.Windows.Forms.TextBox txtGlassThickness;
        private System.Windows.Forms.Label lblGlassThickness;
        
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
            this.lblShape = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbShape = new System.Windows.Forms.ComboBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCommon = new System.Windows.Forms.TabPage();
            this.cmbWaterType = new System.Windows.Forms.ComboBox();
            this.lblWaterType = new System.Windows.Forms.Label();
            this.dtpStopDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStopDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.tabTank = new System.Windows.Forms.TabPage();
            this.txtGlassThickness = new System.Windows.Forms.TextBox();
            this.txtWaterVolume = new System.Windows.Forms.TextBox();
            this.txtTankVolume = new System.Windows.Forms.TextBox();
            this.lblGlassThickness = new System.Windows.Forms.Label();
            this.txtHeigth = new System.Windows.Forms.TextBox();
            this.lblWaterVolume = new System.Windows.Forms.Label();
            this.txtDepth = new System.Windows.Forms.TextBox();
            this.lblVolume = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.lblHeigth = new System.Windows.Forms.Label();
            this.lblDepth = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabCommon.SuspendLayout();
            this.tabTank.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(317, 268);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(96, 24);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "Accept";
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(415, 268);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 24);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(10, 12);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(80, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // lblShape
            // 
            this.lblShape.Location = new System.Drawing.Point(317, 14);
            this.lblShape.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShape.Name = "lblShape";
            this.lblShape.Size = new System.Drawing.Size(80, 17);
            this.lblShape.TabIndex = 2;
            this.lblShape.Text = "Shape";
            // 
            // lblDesc
            // 
            this.lblDesc.Location = new System.Drawing.Point(10, 43);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(80, 17);
            this.lblDesc.TabIndex = 4;
            this.lblDesc.Text = "Description";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(83, 10);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(226, 22);
            this.txtName.TabIndex = 1;
            // 
            // cmbShape
            // 
            this.cmbShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShape.FormattingEnabled = true;
            this.cmbShape.Location = new System.Drawing.Point(375, 10);
            this.cmbShape.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbShape.Name = "cmbShape";
            this.cmbShape.Size = new System.Drawing.Size(136, 21);
            this.cmbShape.TabIndex = 3;
            this.cmbShape.SelectedIndexChanged += new System.EventHandler(this.cmbShape_SelectedIndexChanged);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(83, 41);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(428, 48);
            this.txtDesc.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCommon);
            this.tabControl1.Controls.Add(this.tabTank);
            this.tabControl1.Location = new System.Drawing.Point(10, 98);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(501, 160);
            this.tabControl1.TabIndex = 6;
            // 
            // tabCommon
            // 
            this.tabCommon.BackColor = System.Drawing.SystemColors.Control;
            this.tabCommon.Controls.Add(this.cmbWaterType);
            this.tabCommon.Controls.Add(this.lblWaterType);
            this.tabCommon.Controls.Add(this.dtpStopDate);
            this.tabCommon.Controls.Add(this.dtpStartDate);
            this.tabCommon.Controls.Add(this.lblStopDate);
            this.tabCommon.Controls.Add(this.lblStartDate);
            this.tabCommon.Location = new System.Drawing.Point(4, 22);
            this.tabCommon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabCommon.Name = "tabCommon";
            this.tabCommon.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.tabCommon.Size = new System.Drawing.Size(493, 134);
            this.tabCommon.TabIndex = 0;
            this.tabCommon.Text = "Common";
            // 
            // cmbWaterType
            // 
            this.cmbWaterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaterType.FormattingEnabled = true;
            this.cmbWaterType.Location = new System.Drawing.Point(93, 40);
            this.cmbWaterType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbWaterType.Name = "cmbWaterType";
            this.cmbWaterType.Size = new System.Drawing.Size(114, 21);
            this.cmbWaterType.TabIndex = 5;
            // 
            // lblWaterType
            // 
            this.lblWaterType.Location = new System.Drawing.Point(10, 42);
            this.lblWaterType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWaterType.Name = "lblWaterType";
            this.lblWaterType.Size = new System.Drawing.Size(80, 17);
            this.lblWaterType.TabIndex = 4;
            this.lblWaterType.Text = "Water type";
            // 
            // dtpStopDate
            // 
            this.dtpStopDate.Checked = false;
            this.dtpStopDate.Location = new System.Drawing.Point(341, 10);
            this.dtpStopDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.dtpStopDate.Name = "dtpStopDate";
            this.dtpStopDate.ShowCheckBox = true;
            this.dtpStopDate.Size = new System.Drawing.Size(143, 22);
            this.dtpStopDate.TabIndex = 3;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Checked = false;
            this.dtpStartDate.Location = new System.Drawing.Point(93, 10);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.ShowCheckBox = true;
            this.dtpStartDate.Size = new System.Drawing.Size(143, 22);
            this.dtpStartDate.TabIndex = 1;
            // 
            // lblStopDate
            // 
            this.lblStopDate.Location = new System.Drawing.Point(256, 14);
            this.lblStopDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStopDate.Name = "lblStopDate";
            this.lblStopDate.Size = new System.Drawing.Size(80, 17);
            this.lblStopDate.TabIndex = 2;
            this.lblStopDate.Text = "Stop date";
            // 
            // lblStartDate
            // 
            this.lblStartDate.Location = new System.Drawing.Point(10, 14);
            this.lblStartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(80, 17);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Start date";
            // 
            // tabTank
            // 
            this.tabTank.BackColor = System.Drawing.SystemColors.Control;
            this.tabTank.Controls.Add(this.txtGlassThickness);
            this.tabTank.Controls.Add(this.txtWaterVolume);
            this.tabTank.Controls.Add(this.txtTankVolume);
            this.tabTank.Controls.Add(this.lblGlassThickness);
            this.tabTank.Controls.Add(this.txtHeigth);
            this.tabTank.Controls.Add(this.lblWaterVolume);
            this.tabTank.Controls.Add(this.txtDepth);
            this.tabTank.Controls.Add(this.lblVolume);
            this.tabTank.Controls.Add(this.txtWidth);
            this.tabTank.Controls.Add(this.lblHeigth);
            this.tabTank.Controls.Add(this.lblDepth);
            this.tabTank.Controls.Add(this.lblWidth);
            this.tabTank.Location = new System.Drawing.Point(4, 22);
            this.tabTank.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabTank.Name = "tabTank";
            this.tabTank.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.tabTank.Size = new System.Drawing.Size(494, 134);
            this.tabTank.TabIndex = 1;
            this.tabTank.Text = "Tank";
            // 
            // txtGlassThickness
            // 
            this.txtGlassThickness.Location = new System.Drawing.Point(304, 40);
            this.txtGlassThickness.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtGlassThickness.Name = "txtGlassThickness";
            this.txtGlassThickness.Size = new System.Drawing.Size(82, 22);
            this.txtGlassThickness.TabIndex = 11;
            this.txtGlassThickness.TextChanged += new System.EventHandler(this.txtSizes_TextChanged);
            // 
            // txtWaterVolume
            // 
            this.txtWaterVolume.Location = new System.Drawing.Point(304, 10);
            this.txtWaterVolume.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtWaterVolume.Name = "txtWaterVolume";
            this.txtWaterVolume.Size = new System.Drawing.Size(82, 22);
            this.txtWaterVolume.TabIndex = 9;
            // 
            // txtTankVolume
            // 
            this.txtTankVolume.Location = new System.Drawing.Point(95, 101);
            this.txtTankVolume.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtTankVolume.Name = "txtTankVolume";
            this.txtTankVolume.Size = new System.Drawing.Size(82, 22);
            this.txtTankVolume.TabIndex = 7;
            this.txtTankVolume.TextChanged += new System.EventHandler(this.txtTankVolume_TextChanged);
            // 
            // lblGlassThickness
            // 
            this.lblGlassThickness.Location = new System.Drawing.Point(198, 42);
            this.lblGlassThickness.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGlassThickness.Name = "lblGlassThickness";
            this.lblGlassThickness.Size = new System.Drawing.Size(80, 17);
            this.lblGlassThickness.TabIndex = 10;
            this.lblGlassThickness.Text = "Glass thickness";
            // 
            // txtHeigth
            // 
            this.txtHeigth.Location = new System.Drawing.Point(95, 70);
            this.txtHeigth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtHeigth.Name = "txtHeigth";
            this.txtHeigth.Size = new System.Drawing.Size(82, 22);
            this.txtHeigth.TabIndex = 5;
            this.txtHeigth.TextChanged += new System.EventHandler(this.txtSizes_TextChanged);
            // 
            // lblWaterVolume
            // 
            this.lblWaterVolume.Location = new System.Drawing.Point(198, 12);
            this.lblWaterVolume.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWaterVolume.Name = "lblWaterVolume";
            this.lblWaterVolume.Size = new System.Drawing.Size(80, 17);
            this.lblWaterVolume.TabIndex = 8;
            this.lblWaterVolume.Text = "Water volume";
            // 
            // txtDepth
            // 
            this.txtDepth.Location = new System.Drawing.Point(95, 40);
            this.txtDepth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtDepth.Name = "txtDepth";
            this.txtDepth.Size = new System.Drawing.Size(82, 22);
            this.txtDepth.TabIndex = 3;
            this.txtDepth.TextChanged += new System.EventHandler(this.txtSizes_TextChanged);
            // 
            // lblVolume
            // 
            this.lblVolume.Location = new System.Drawing.Point(10, 103);
            this.lblVolume.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(80, 17);
            this.lblVolume.TabIndex = 6;
            this.lblVolume.Text = "Tank volume";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(95, 10);
            this.txtWidth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(82, 22);
            this.txtWidth.TabIndex = 1;
            this.txtWidth.TextChanged += new System.EventHandler(this.txtSizes_TextChanged);
            // 
            // lblHeigth
            // 
            this.lblHeigth.Location = new System.Drawing.Point(10, 73);
            this.lblHeigth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeigth.Name = "lblHeigth";
            this.lblHeigth.Size = new System.Drawing.Size(80, 17);
            this.lblHeigth.TabIndex = 4;
            this.lblHeigth.Text = "Heigth";
            // 
            // lblDepth
            // 
            this.lblDepth.Location = new System.Drawing.Point(10, 42);
            this.lblDepth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDepth.Name = "lblDepth";
            this.lblDepth.Size = new System.Drawing.Size(80, 17);
            this.lblDepth.TabIndex = 2;
            this.lblDepth.Text = "Depth";
            // 
            // lblWidth
            // 
            this.lblWidth.Location = new System.Drawing.Point(10, 12);
            this.lblWidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(80, 17);
            this.lblWidth.TabIndex = 0;
            this.lblWidth.Text = "Width";
            // 
            // AquariumEditDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(522, 303);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.cmbShape);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblShape);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AquariumEditDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Aquarium";
            this.tabControl1.ResumeLayout(false);
            this.tabCommon.ResumeLayout(false);
            this.tabTank.ResumeLayout(false);
            this.tabTank.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
