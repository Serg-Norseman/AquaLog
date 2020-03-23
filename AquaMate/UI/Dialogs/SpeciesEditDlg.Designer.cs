namespace AquaMate.UI.Dialogs
{
    partial class SpeciesEditDlg
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label lblScientificName;
        private System.Windows.Forms.TextBox txtScientificName;
        private System.Windows.Forms.Label lblTempMin;
        private System.Windows.Forms.TextBox txtTempMin;
        private System.Windows.Forms.Label lblTempMax;
        private System.Windows.Forms.TextBox txtTempMax;
        private System.Windows.Forms.Label lblPHMin;
        private System.Windows.Forms.TextBox txtPHMin;
        private System.Windows.Forms.Label lblPHMax;
        private System.Windows.Forms.TextBox txtPHMax;
        private System.Windows.Forms.Label lblGHMin;
        private System.Windows.Forms.Label lblGHMax;
        private System.Windows.Forms.TextBox txtGHMin;
        private System.Windows.Forms.TextBox txtGHMax;
        private System.Windows.Forms.TextBox txtAdultSize;
        private System.Windows.Forms.Label lblAdultSize;
        private System.Windows.Forms.TextBox txtLifeSpan;
        private System.Windows.Forms.Label lblLifeSpan;
        private System.Windows.Forms.ComboBox cmbSwimLevel;
        private System.Windows.Forms.Label lblSwimLevel;
        private System.Windows.Forms.ComboBox cmbFamily;
        private System.Windows.Forms.Label lblFamily;
        
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
            this.lblType = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblScientificName = new System.Windows.Forms.Label();
            this.txtScientificName = new System.Windows.Forms.TextBox();
            this.lblTempMin = new System.Windows.Forms.Label();
            this.txtTempMin = new System.Windows.Forms.TextBox();
            this.lblTempMax = new System.Windows.Forms.Label();
            this.txtTempMax = new System.Windows.Forms.TextBox();
            this.lblPHMin = new System.Windows.Forms.Label();
            this.txtPHMin = new System.Windows.Forms.TextBox();
            this.lblPHMax = new System.Windows.Forms.Label();
            this.txtPHMax = new System.Windows.Forms.TextBox();
            this.lblGHMin = new System.Windows.Forms.Label();
            this.lblGHMax = new System.Windows.Forms.Label();
            this.txtGHMin = new System.Windows.Forms.TextBox();
            this.txtGHMax = new System.Windows.Forms.TextBox();
            this.cmbFamily = new System.Windows.Forms.ComboBox();
            this.lblFamily = new System.Windows.Forms.Label();
            this.cmbSwimLevel = new System.Windows.Forms.ComboBox();
            this.lblSwimLevel = new System.Windows.Forms.Label();
            this.txtLifeSpan = new System.Windows.Forms.TextBox();
            this.txtAdultSize = new System.Windows.Forms.TextBox();
            this.lblLifeSpan = new System.Windows.Forms.Label();
            this.lblAdultSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(317, 357);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(96, 24);
            this.btnAccept.TabIndex = 28;
            this.btnAccept.Text = "Accept";
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(417, 357);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 24);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(9, 14);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(80, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(336, 14);
            this.lblType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(52, 17);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Type";
            // 
            // lblDesc
            // 
            this.lblDesc.Location = new System.Drawing.Point(9, 45);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(80, 17);
            this.lblDesc.TabIndex = 4;
            this.lblDesc.Text = "Description";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(94, 11);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(238, 22);
            this.txtName.TabIndex = 1;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(392, 11);
            this.cmbType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(119, 21);
            this.cmbType.TabIndex = 3;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(94, 42);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(417, 48);
            this.txtDesc.TabIndex = 5;
            // 
            // lblScientificName
            // 
            this.lblScientificName.Location = new System.Drawing.Point(9, 102);
            this.lblScientificName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblScientificName.Name = "lblScientificName";
            this.lblScientificName.Size = new System.Drawing.Size(107, 17);
            this.lblScientificName.TabIndex = 6;
            this.lblScientificName.Text = "Scientific Name";
            // 
            // txtScientificName
            // 
            this.txtScientificName.Location = new System.Drawing.Point(120, 99);
            this.txtScientificName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtScientificName.Name = "txtScientificName";
            this.txtScientificName.Size = new System.Drawing.Size(391, 22);
            this.txtScientificName.TabIndex = 7;
            // 
            // lblTempMin
            // 
            this.lblTempMin.Location = new System.Drawing.Point(9, 163);
            this.lblTempMin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTempMin.Name = "lblTempMin";
            this.lblTempMin.Size = new System.Drawing.Size(88, 17);
            this.lblTempMin.TabIndex = 10;
            this.lblTempMin.Text = "TempMin";
            // 
            // txtTempMin
            // 
            this.txtTempMin.Location = new System.Drawing.Point(120, 160);
            this.txtTempMin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtTempMin.Name = "txtTempMin";
            this.txtTempMin.Size = new System.Drawing.Size(60, 22);
            this.txtTempMin.TabIndex = 11;
            // 
            // lblTempMax
            // 
            this.lblTempMax.Location = new System.Drawing.Point(188, 161);
            this.lblTempMax.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTempMax.Name = "lblTempMax";
            this.lblTempMax.Size = new System.Drawing.Size(88, 17);
            this.lblTempMax.TabIndex = 12;
            this.lblTempMax.Text = "TempMax";
            // 
            // txtTempMax
            // 
            this.txtTempMax.Location = new System.Drawing.Point(271, 160);
            this.txtTempMax.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtTempMax.Name = "txtTempMax";
            this.txtTempMax.Size = new System.Drawing.Size(60, 22);
            this.txtTempMax.TabIndex = 13;
            // 
            // lblPHMin
            // 
            this.lblPHMin.Location = new System.Drawing.Point(9, 194);
            this.lblPHMin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPHMin.Name = "lblPHMin";
            this.lblPHMin.Size = new System.Drawing.Size(88, 17);
            this.lblPHMin.TabIndex = 14;
            this.lblPHMin.Text = "PHMin";
            // 
            // txtPHMin
            // 
            this.txtPHMin.Location = new System.Drawing.Point(120, 191);
            this.txtPHMin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtPHMin.Name = "txtPHMin";
            this.txtPHMin.Size = new System.Drawing.Size(60, 22);
            this.txtPHMin.TabIndex = 15;
            // 
            // lblPHMax
            // 
            this.lblPHMax.Location = new System.Drawing.Point(188, 192);
            this.lblPHMax.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPHMax.Name = "lblPHMax";
            this.lblPHMax.Size = new System.Drawing.Size(88, 17);
            this.lblPHMax.TabIndex = 16;
            this.lblPHMax.Text = "PHMax";
            // 
            // txtPHMax
            // 
            this.txtPHMax.Location = new System.Drawing.Point(271, 191);
            this.txtPHMax.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtPHMax.Name = "txtPHMax";
            this.txtPHMax.Size = new System.Drawing.Size(60, 22);
            this.txtPHMax.TabIndex = 17;
            // 
            // lblGHMin
            // 
            this.lblGHMin.Location = new System.Drawing.Point(9, 225);
            this.lblGHMin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGHMin.Name = "lblGHMin";
            this.lblGHMin.Size = new System.Drawing.Size(88, 17);
            this.lblGHMin.TabIndex = 18;
            this.lblGHMin.Text = "GHMin";
            // 
            // lblGHMax
            // 
            this.lblGHMax.Location = new System.Drawing.Point(188, 223);
            this.lblGHMax.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGHMax.Name = "lblGHMax";
            this.lblGHMax.Size = new System.Drawing.Size(88, 17);
            this.lblGHMax.TabIndex = 20;
            this.lblGHMax.Text = "GHMax";
            // 
            // txtGHMin
            // 
            this.txtGHMin.Location = new System.Drawing.Point(120, 222);
            this.txtGHMin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtGHMin.Name = "txtGHMin";
            this.txtGHMin.Size = new System.Drawing.Size(60, 22);
            this.txtGHMin.TabIndex = 19;
            // 
            // txtGHMax
            // 
            this.txtGHMax.Location = new System.Drawing.Point(271, 222);
            this.txtGHMax.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtGHMax.Name = "txtGHMax";
            this.txtGHMax.Size = new System.Drawing.Size(60, 22);
            this.txtGHMax.TabIndex = 21;
            // 
            // cmbFamily
            // 
            this.cmbFamily.Location = new System.Drawing.Point(120, 130);
            this.cmbFamily.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbFamily.Name = "cmbFamily";
            this.cmbFamily.Size = new System.Drawing.Size(228, 21);
            this.cmbFamily.TabIndex = 9;
            // 
            // lblFamily
            // 
            this.lblFamily.Location = new System.Drawing.Point(9, 133);
            this.lblFamily.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFamily.Name = "lblFamily";
            this.lblFamily.Size = new System.Drawing.Size(107, 17);
            this.lblFamily.TabIndex = 8;
            this.lblFamily.Text = "Family";
            // 
            // cmbSwimLevel
            // 
            this.cmbSwimLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSwimLevel.FormattingEnabled = true;
            this.cmbSwimLevel.Location = new System.Drawing.Point(120, 315);
            this.cmbSwimLevel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbSwimLevel.Name = "cmbSwimLevel";
            this.cmbSwimLevel.Size = new System.Drawing.Size(131, 21);
            this.cmbSwimLevel.TabIndex = 27;
            // 
            // lblSwimLevel
            // 
            this.lblSwimLevel.Location = new System.Drawing.Point(9, 318);
            this.lblSwimLevel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSwimLevel.Name = "lblSwimLevel";
            this.lblSwimLevel.Size = new System.Drawing.Size(107, 17);
            this.lblSwimLevel.TabIndex = 26;
            this.lblSwimLevel.Text = "SwimLevel";
            // 
            // txtLifeSpan
            // 
            this.txtLifeSpan.Location = new System.Drawing.Point(120, 284);
            this.txtLifeSpan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtLifeSpan.Name = "txtLifeSpan";
            this.txtLifeSpan.Size = new System.Drawing.Size(60, 22);
            this.txtLifeSpan.TabIndex = 25;
            // 
            // txtAdultSize
            // 
            this.txtAdultSize.Location = new System.Drawing.Point(120, 253);
            this.txtAdultSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtAdultSize.Name = "txtAdultSize";
            this.txtAdultSize.Size = new System.Drawing.Size(60, 22);
            this.txtAdultSize.TabIndex = 23;
            // 
            // lblLifeSpan
            // 
            this.lblLifeSpan.Location = new System.Drawing.Point(9, 287);
            this.lblLifeSpan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLifeSpan.Name = "lblLifeSpan";
            this.lblLifeSpan.Size = new System.Drawing.Size(107, 17);
            this.lblLifeSpan.TabIndex = 24;
            this.lblLifeSpan.Text = "LifeSpan";
            // 
            // lblAdultSize
            // 
            this.lblAdultSize.Location = new System.Drawing.Point(9, 256);
            this.lblAdultSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAdultSize.Name = "lblAdultSize";
            this.lblAdultSize.Size = new System.Drawing.Size(107, 17);
            this.lblAdultSize.TabIndex = 22;
            this.lblAdultSize.Text = "AdultSize";
            // 
            // SpeciesEditDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(522, 390);
            this.Controls.Add(this.cmbSwimLevel);
            this.Controls.Add(this.lblSwimLevel);
            this.Controls.Add(this.txtLifeSpan);
            this.Controls.Add(this.txtAdultSize);
            this.Controls.Add(this.lblLifeSpan);
            this.Controls.Add(this.lblAdultSize);
            this.Controls.Add(this.cmbFamily);
            this.Controls.Add(this.lblFamily);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.txtGHMax);
            this.Controls.Add(this.txtPHMax);
            this.Controls.Add(this.txtGHMin);
            this.Controls.Add(this.txtPHMin);
            this.Controls.Add(this.lblGHMax);
            this.Controls.Add(this.txtTempMax);
            this.Controls.Add(this.lblPHMax);
            this.Controls.Add(this.lblGHMin);
            this.Controls.Add(this.txtTempMin);
            this.Controls.Add(this.lblPHMin);
            this.Controls.Add(this.txtScientificName);
            this.Controls.Add(this.lblTempMax);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblTempMin);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblScientificName);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpeciesEditDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Species";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
