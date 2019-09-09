﻿namespace AquaLog.UI.Dialogs
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
        private System.Windows.Forms.TextBox txtAdultSize;
        private System.Windows.Forms.Label lblAdultSize;
        private System.Windows.Forms.TextBox txtLifeSpan;
        private System.Windows.Forms.Label lblLifeSpan;
        private System.Windows.Forms.ComboBox cmbSwimLevel;
        private System.Windows.Forms.Label lblSwimLevel;
        
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
            this.txtLifeSpan = new System.Windows.Forms.TextBox();
            this.txtAdultSize = new System.Windows.Forms.TextBox();
            this.lblLifeSpan = new System.Windows.Forms.Label();
            this.lblAdultSize = new System.Windows.Forms.Label();
            this.tabInvertebrate = new System.Windows.Forms.TabPage();
            this.tabPlant = new System.Windows.Forms.TabPage();
            this.tabCoral = new System.Windows.Forms.TabPage();
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
            this.cmbSwimLevel = new System.Windows.Forms.ComboBox();
            this.lblSwimLevel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabFish.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(394, 450);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(120, 30);
            this.btnAccept.TabIndex = 21;
            this.btnAccept.Text = "Accept";
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(519, 450);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 30);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(12, 18);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 21);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(421, 18);
            this.lblType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(100, 21);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Type";
            // 
            // lblDesc
            // 
            this.lblDesc.Location = new System.Drawing.Point(12, 54);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(100, 21);
            this.lblDesc.TabIndex = 4;
            this.lblDesc.Text = "Description";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(118, 11);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(296, 26);
            this.txtName.TabIndex = 1;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(475, 12);
            this.cmbType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(163, 27);
            this.cmbType.TabIndex = 3;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(118, 51);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(520, 59);
            this.txtDesc.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabFish);
            this.tabControl1.Controls.Add(this.tabInvertebrate);
            this.tabControl1.Controls.Add(this.tabPlant);
            this.tabControl1.Controls.Add(this.tabCoral);
            this.tabControl1.Location = new System.Drawing.Point(12, 274);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(626, 164);
            this.tabControl1.TabIndex = 20;
            // 
            // tabFish
            // 
            this.tabFish.BackColor = System.Drawing.SystemColors.Control;
            this.tabFish.Controls.Add(this.cmbSwimLevel);
            this.tabFish.Controls.Add(this.lblSwimLevel);
            this.tabFish.Controls.Add(this.txtLifeSpan);
            this.tabFish.Controls.Add(this.txtAdultSize);
            this.tabFish.Controls.Add(this.lblLifeSpan);
            this.tabFish.Controls.Add(this.lblAdultSize);
            this.tabFish.Location = new System.Drawing.Point(4, 28);
            this.tabFish.Margin = new System.Windows.Forms.Padding(2);
            this.tabFish.Name = "tabFish";
            this.tabFish.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.tabFish.Size = new System.Drawing.Size(618, 132);
            this.tabFish.TabIndex = 0;
            this.tabFish.Text = "Fish";
            // 
            // txtLifeSpan
            // 
            this.txtLifeSpan.Location = new System.Drawing.Point(169, 50);
            this.txtLifeSpan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.txtLifeSpan.Name = "txtLifeSpan";
            this.txtLifeSpan.Size = new System.Drawing.Size(74, 26);
            this.txtLifeSpan.TabIndex = 11;
            // 
            // txtAdultSize
            // 
            this.txtAdultSize.Location = new System.Drawing.Point(169, 11);
            this.txtAdultSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.txtAdultSize.Name = "txtAdultSize";
            this.txtAdultSize.Size = new System.Drawing.Size(74, 26);
            this.txtAdultSize.TabIndex = 11;
            // 
            // lblLifeSpan
            // 
            this.lblLifeSpan.Location = new System.Drawing.Point(11, 54);
            this.lblLifeSpan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLifeSpan.Name = "lblLifeSpan";
            this.lblLifeSpan.Size = new System.Drawing.Size(152, 21);
            this.lblLifeSpan.TabIndex = 10;
            this.lblLifeSpan.Text = "LifeSpan";
            // 
            // lblAdultSize
            // 
            this.lblAdultSize.Location = new System.Drawing.Point(11, 15);
            this.lblAdultSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAdultSize.Name = "lblAdultSize";
            this.lblAdultSize.Size = new System.Drawing.Size(152, 21);
            this.lblAdultSize.TabIndex = 10;
            this.lblAdultSize.Text = "AdultSize";
            // 
            // tabInvertebrate
            // 
            this.tabInvertebrate.BackColor = System.Drawing.SystemColors.Control;
            this.tabInvertebrate.Location = new System.Drawing.Point(4, 28);
            this.tabInvertebrate.Margin = new System.Windows.Forms.Padding(2);
            this.tabInvertebrate.Name = "tabInvertebrate";
            this.tabInvertebrate.Padding = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.tabInvertebrate.Size = new System.Drawing.Size(618, 132);
            this.tabInvertebrate.TabIndex = 1;
            this.tabInvertebrate.Text = "Invertebrate";
            // 
            // tabPlant
            // 
            this.tabPlant.BackColor = System.Drawing.SystemColors.Control;
            this.tabPlant.Location = new System.Drawing.Point(4, 28);
            this.tabPlant.Margin = new System.Windows.Forms.Padding(2);
            this.tabPlant.Name = "tabPlant";
            this.tabPlant.Padding = new System.Windows.Forms.Padding(2);
            this.tabPlant.Size = new System.Drawing.Size(618, 132);
            this.tabPlant.TabIndex = 2;
            this.tabPlant.Text = "Plant";
            // 
            // tabCoral
            // 
            this.tabCoral.BackColor = System.Drawing.SystemColors.Control;
            this.tabCoral.Location = new System.Drawing.Point(4, 28);
            this.tabCoral.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabCoral.Name = "tabCoral";
            this.tabCoral.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabCoral.Size = new System.Drawing.Size(618, 132);
            this.tabCoral.TabIndex = 3;
            this.tabCoral.Text = "Coral";
            // 
            // lblScientificName
            // 
            this.lblScientificName.Location = new System.Drawing.Point(12, 125);
            this.lblScientificName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblScientificName.Name = "lblScientificName";
            this.lblScientificName.Size = new System.Drawing.Size(110, 21);
            this.lblScientificName.TabIndex = 6;
            this.lblScientificName.Text = "Scientific Name";
            // 
            // txtScientificName
            // 
            this.txtScientificName.Location = new System.Drawing.Point(118, 122);
            this.txtScientificName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.txtScientificName.Name = "txtScientificName";
            this.txtScientificName.Size = new System.Drawing.Size(520, 26);
            this.txtScientificName.TabIndex = 7;
            // 
            // lblTempMin
            // 
            this.lblTempMin.Location = new System.Drawing.Point(12, 162);
            this.lblTempMin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTempMin.Name = "lblTempMin";
            this.lblTempMin.Size = new System.Drawing.Size(110, 21);
            this.lblTempMin.TabIndex = 8;
            this.lblTempMin.Text = "TempMin";
            // 
            // txtTempMin
            // 
            this.txtTempMin.Location = new System.Drawing.Point(118, 160);
            this.txtTempMin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.txtTempMin.Name = "txtTempMin";
            this.txtTempMin.Size = new System.Drawing.Size(74, 26);
            this.txtTempMin.TabIndex = 9;
            // 
            // lblTempMax
            // 
            this.lblTempMax.Location = new System.Drawing.Point(202, 162);
            this.lblTempMax.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTempMax.Name = "lblTempMax";
            this.lblTempMax.Size = new System.Drawing.Size(110, 21);
            this.lblTempMax.TabIndex = 10;
            this.lblTempMax.Text = "TempMax";
            // 
            // txtTempMax
            // 
            this.txtTempMax.Location = new System.Drawing.Point(306, 160);
            this.txtTempMax.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.txtTempMax.Name = "txtTempMax";
            this.txtTempMax.Size = new System.Drawing.Size(74, 26);
            this.txtTempMax.TabIndex = 11;
            // 
            // lblPHMin
            // 
            this.lblPHMin.Location = new System.Drawing.Point(12, 201);
            this.lblPHMin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPHMin.Name = "lblPHMin";
            this.lblPHMin.Size = new System.Drawing.Size(110, 21);
            this.lblPHMin.TabIndex = 12;
            this.lblPHMin.Text = "PHMin";
            // 
            // txtPHMin
            // 
            this.txtPHMin.Location = new System.Drawing.Point(118, 198);
            this.txtPHMin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.txtPHMin.Name = "txtPHMin";
            this.txtPHMin.Size = new System.Drawing.Size(74, 26);
            this.txtPHMin.TabIndex = 13;
            // 
            // lblPHMax
            // 
            this.lblPHMax.Location = new System.Drawing.Point(202, 201);
            this.lblPHMax.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPHMax.Name = "lblPHMax";
            this.lblPHMax.Size = new System.Drawing.Size(110, 21);
            this.lblPHMax.TabIndex = 14;
            this.lblPHMax.Text = "PHMax";
            // 
            // txtPHMax
            // 
            this.txtPHMax.Location = new System.Drawing.Point(306, 198);
            this.txtPHMax.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.txtPHMax.Name = "txtPHMax";
            this.txtPHMax.Size = new System.Drawing.Size(74, 26);
            this.txtPHMax.TabIndex = 15;
            // 
            // lblGHMin
            // 
            this.lblGHMin.Location = new System.Drawing.Point(12, 239);
            this.lblGHMin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGHMin.Name = "lblGHMin";
            this.lblGHMin.Size = new System.Drawing.Size(110, 21);
            this.lblGHMin.TabIndex = 16;
            this.lblGHMin.Text = "GHMin";
            // 
            // lblGHMax
            // 
            this.lblGHMax.Location = new System.Drawing.Point(202, 239);
            this.lblGHMax.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGHMax.Name = "lblGHMax";
            this.lblGHMax.Size = new System.Drawing.Size(110, 21);
            this.lblGHMax.TabIndex = 18;
            this.lblGHMax.Text = "GHMax";
            // 
            // txtGHMin
            // 
            this.txtGHMin.Location = new System.Drawing.Point(118, 236);
            this.txtGHMin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.txtGHMin.Name = "txtGHMin";
            this.txtGHMin.Size = new System.Drawing.Size(74, 26);
            this.txtGHMin.TabIndex = 17;
            // 
            // txtGHMax
            // 
            this.txtGHMax.Location = new System.Drawing.Point(306, 236);
            this.txtGHMax.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.txtGHMax.Name = "txtGHMax";
            this.txtGHMax.Size = new System.Drawing.Size(74, 26);
            this.txtGHMax.TabIndex = 19;
            // 
            // cmbSwimLevel
            // 
            this.cmbSwimLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSwimLevel.FormattingEnabled = true;
            this.cmbSwimLevel.Location = new System.Drawing.Point(421, 11);
            this.cmbSwimLevel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 9);
            this.cmbSwimLevel.Name = "cmbSwimLevel";
            this.cmbSwimLevel.Size = new System.Drawing.Size(163, 27);
            this.cmbSwimLevel.TabIndex = 13;
            // 
            // lblSwimLevel
            // 
            this.lblSwimLevel.Location = new System.Drawing.Point(264, 14);
            this.lblSwimLevel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSwimLevel.Name = "lblSwimLevel";
            this.lblSwimLevel.Size = new System.Drawing.Size(153, 21);
            this.lblSwimLevel.TabIndex = 12;
            this.lblSwimLevel.Text = "SwimLevel";
            // 
            // SpeciesEditDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(652, 494);
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
            this.tabFish.ResumeLayout(false);
            this.tabFish.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}