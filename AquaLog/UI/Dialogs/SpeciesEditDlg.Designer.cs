namespace AquaLog.UI.Dialogs
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabFish;
        private System.Windows.Forms.TabPage tabInvertebrate;
        private System.Windows.Forms.TabPage tabPlant;
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
        private System.Windows.Forms.TabPage tabCoral;
        
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabFish = new System.Windows.Forms.TabPage();
            this.tabInvertebrate = new System.Windows.Forms.TabPage();
            this.tabPlant = new System.Windows.Forms.TabPage();
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
            this.tabCoral = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(315, 360);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(96, 24);
            this.btnAccept.TabIndex = 21;
            this.btnAccept.Text = "Accept";
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(415, 360);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 24);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(10, 14);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(80, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(337, 14);
            this.lblType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(80, 17);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Type";
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
            this.txtName.Location = new System.Drawing.Point(94, 10);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(238, 22);
            this.txtName.TabIndex = 1;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(380, 10);
            this.cmbType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(131, 21);
            this.cmbType.TabIndex = 3;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(94, 41);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(417, 48);
            this.txtDesc.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabFish);
            this.tabControl1.Controls.Add(this.tabInvertebrate);
            this.tabControl1.Controls.Add(this.tabPlant);
            this.tabControl1.Controls.Add(this.tabCoral);
            this.tabControl1.Location = new System.Drawing.Point(10, 219);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(501, 131);
            this.tabControl1.TabIndex = 20;
            // 
            // tabFish
            // 
            this.tabFish.BackColor = System.Drawing.SystemColors.Control;
            this.tabFish.Location = new System.Drawing.Point(4, 22);
            this.tabFish.Margin = new System.Windows.Forms.Padding(2);
            this.tabFish.Name = "tabFish";
            this.tabFish.Padding = new System.Windows.Forms.Padding(2);
            this.tabFish.Size = new System.Drawing.Size(493, 105);
            this.tabFish.TabIndex = 0;
            this.tabFish.Text = "Fish";
            // 
            // tabInvertebrate
            // 
            this.tabInvertebrate.BackColor = System.Drawing.SystemColors.Control;
            this.tabInvertebrate.Location = new System.Drawing.Point(4, 22);
            this.tabInvertebrate.Margin = new System.Windows.Forms.Padding(2);
            this.tabInvertebrate.Name = "tabInvertebrate";
            this.tabInvertebrate.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tabInvertebrate.Size = new System.Drawing.Size(493, 105);
            this.tabInvertebrate.TabIndex = 1;
            this.tabInvertebrate.Text = "Invertebrate";
            // 
            // tabPlant
            // 
            this.tabPlant.BackColor = System.Drawing.SystemColors.Control;
            this.tabPlant.Location = new System.Drawing.Point(4, 22);
            this.tabPlant.Margin = new System.Windows.Forms.Padding(2);
            this.tabPlant.Name = "tabPlant";
            this.tabPlant.Padding = new System.Windows.Forms.Padding(2);
            this.tabPlant.Size = new System.Drawing.Size(493, 105);
            this.tabPlant.TabIndex = 2;
            this.tabPlant.Text = "Plant";
            // 
            // lblScientificName
            // 
            this.lblScientificName.Location = new System.Drawing.Point(10, 100);
            this.lblScientificName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblScientificName.Name = "lblScientificName";
            this.lblScientificName.Size = new System.Drawing.Size(88, 17);
            this.lblScientificName.TabIndex = 6;
            this.lblScientificName.Text = "Scientific Name";
            // 
            // txtScientificName
            // 
            this.txtScientificName.Location = new System.Drawing.Point(94, 98);
            this.txtScientificName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtScientificName.Name = "txtScientificName";
            this.txtScientificName.Size = new System.Drawing.Size(417, 22);
            this.txtScientificName.TabIndex = 7;
            // 
            // lblTempMin
            // 
            this.lblTempMin.Location = new System.Drawing.Point(10, 130);
            this.lblTempMin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTempMin.Name = "lblTempMin";
            this.lblTempMin.Size = new System.Drawing.Size(88, 17);
            this.lblTempMin.TabIndex = 8;
            this.lblTempMin.Text = "TempMin";
            // 
            // txtTempMin
            // 
            this.txtTempMin.Location = new System.Drawing.Point(94, 128);
            this.txtTempMin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtTempMin.Name = "txtTempMin";
            this.txtTempMin.Size = new System.Drawing.Size(60, 22);
            this.txtTempMin.TabIndex = 9;
            // 
            // lblTempMax
            // 
            this.lblTempMax.Location = new System.Drawing.Point(162, 130);
            this.lblTempMax.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTempMax.Name = "lblTempMax";
            this.lblTempMax.Size = new System.Drawing.Size(88, 17);
            this.lblTempMax.TabIndex = 10;
            this.lblTempMax.Text = "TempMax";
            // 
            // txtTempMax
            // 
            this.txtTempMax.Location = new System.Drawing.Point(245, 128);
            this.txtTempMax.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtTempMax.Name = "txtTempMax";
            this.txtTempMax.Size = new System.Drawing.Size(60, 22);
            this.txtTempMax.TabIndex = 11;
            // 
            // lblPHMin
            // 
            this.lblPHMin.Location = new System.Drawing.Point(10, 161);
            this.lblPHMin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPHMin.Name = "lblPHMin";
            this.lblPHMin.Size = new System.Drawing.Size(88, 17);
            this.lblPHMin.TabIndex = 12;
            this.lblPHMin.Text = "PHMin";
            // 
            // txtPHMin
            // 
            this.txtPHMin.Location = new System.Drawing.Point(94, 158);
            this.txtPHMin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtPHMin.Name = "txtPHMin";
            this.txtPHMin.Size = new System.Drawing.Size(60, 22);
            this.txtPHMin.TabIndex = 13;
            // 
            // lblPHMax
            // 
            this.lblPHMax.Location = new System.Drawing.Point(162, 161);
            this.lblPHMax.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPHMax.Name = "lblPHMax";
            this.lblPHMax.Size = new System.Drawing.Size(88, 17);
            this.lblPHMax.TabIndex = 14;
            this.lblPHMax.Text = "PHMax";
            // 
            // txtPHMax
            // 
            this.txtPHMax.Location = new System.Drawing.Point(245, 158);
            this.txtPHMax.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtPHMax.Name = "txtPHMax";
            this.txtPHMax.Size = new System.Drawing.Size(60, 22);
            this.txtPHMax.TabIndex = 15;
            // 
            // lblGHMin
            // 
            this.lblGHMin.Location = new System.Drawing.Point(10, 191);
            this.lblGHMin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGHMin.Name = "lblGHMin";
            this.lblGHMin.Size = new System.Drawing.Size(88, 17);
            this.lblGHMin.TabIndex = 16;
            this.lblGHMin.Text = "GHMin";
            // 
            // lblGHMax
            // 
            this.lblGHMax.Location = new System.Drawing.Point(162, 191);
            this.lblGHMax.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGHMax.Name = "lblGHMax";
            this.lblGHMax.Size = new System.Drawing.Size(88, 17);
            this.lblGHMax.TabIndex = 18;
            this.lblGHMax.Text = "GHMax";
            // 
            // txtGHMin
            // 
            this.txtGHMin.Location = new System.Drawing.Point(94, 189);
            this.txtGHMin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtGHMin.Name = "txtGHMin";
            this.txtGHMin.Size = new System.Drawing.Size(60, 22);
            this.txtGHMin.TabIndex = 17;
            // 
            // txtGHMax
            // 
            this.txtGHMax.Location = new System.Drawing.Point(245, 189);
            this.txtGHMax.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtGHMax.Name = "txtGHMax";
            this.txtGHMax.Size = new System.Drawing.Size(60, 22);
            this.txtGHMax.TabIndex = 19;
            // 
            // tabCoral
            // 
            this.tabCoral.BackColor = System.Drawing.SystemColors.Control;
            this.tabCoral.Location = new System.Drawing.Point(4, 22);
            this.tabCoral.Name = "tabCoral";
            this.tabCoral.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoral.Size = new System.Drawing.Size(493, 105);
            this.tabCoral.TabIndex = 3;
            this.tabCoral.Text = "Coral";
            // 
            // SpeciesEditDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(522, 395);
            this.Controls.Add(this.tabControl1);
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
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
