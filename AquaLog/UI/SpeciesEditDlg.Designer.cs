namespace AquaLog.UI
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
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(442, 344);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(96, 30);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Accept";
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(544, 344);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(12, 17);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 21);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(421, 17);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(100, 21);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "Type";
            // 
            // lblDesc
            // 
            this.lblDesc.Location = new System.Drawing.Point(12, 53);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(100, 21);
            this.lblDesc.TabIndex = 4;
            this.lblDesc.Text = "Description";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(104, 14);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(311, 22);
            this.txtName.TabIndex = 5;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(471, 14);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(165, 21);
            this.cmbType.TabIndex = 6;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(104, 50);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(532, 59);
            this.txtDesc.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabFish);
            this.tabControl1.Controls.Add(this.tabInvertebrate);
            this.tabControl1.Controls.Add(this.tabPlant);
            this.tabControl1.Location = new System.Drawing.Point(15, 167);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(625, 164);
            this.tabControl1.TabIndex = 8;
            // 
            // tabFish
            // 
            this.tabFish.BackColor = System.Drawing.SystemColors.Control;
            this.tabFish.Location = new System.Drawing.Point(4, 22);
            this.tabFish.Name = "tabFish";
            this.tabFish.Padding = new System.Windows.Forms.Padding(3);
            this.tabFish.Size = new System.Drawing.Size(617, 138);
            this.tabFish.TabIndex = 0;
            this.tabFish.Text = "Fish";
            // 
            // tabInvertebrate
            // 
            this.tabInvertebrate.BackColor = System.Drawing.SystemColors.Control;
            this.tabInvertebrate.Location = new System.Drawing.Point(4, 23);
            this.tabInvertebrate.Name = "tabInvertebrate";
            this.tabInvertebrate.Padding = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.tabInvertebrate.Size = new System.Drawing.Size(617, 137);
            this.tabInvertebrate.TabIndex = 1;
            this.tabInvertebrate.Text = "Invertebrate";
            // 
            // tabPlant
            // 
            this.tabPlant.BackColor = System.Drawing.SystemColors.Control;
            this.tabPlant.Location = new System.Drawing.Point(4, 23);
            this.tabPlant.Name = "tabPlant";
            this.tabPlant.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlant.Size = new System.Drawing.Size(617, 137);
            this.tabPlant.TabIndex = 2;
            this.tabPlant.Text = "Plant";
            // 
            // lblScientificName
            // 
            this.lblScientificName.Location = new System.Drawing.Point(15, 126);
            this.lblScientificName.Name = "lblScientificName";
            this.lblScientificName.Size = new System.Drawing.Size(110, 21);
            this.lblScientificName.TabIndex = 2;
            this.lblScientificName.Text = "Scientific Name";
            // 
            // txtScientificName
            // 
            this.txtScientificName.Location = new System.Drawing.Point(104, 123);
            this.txtScientificName.Name = "txtScientificName";
            this.txtScientificName.Size = new System.Drawing.Size(311, 22);
            this.txtScientificName.TabIndex = 5;
            // 
            // SpeciesEditDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(652, 386);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.txtScientificName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblScientificName);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpeciesEditDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AquariumEditDlg";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
