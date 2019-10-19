namespace AquaLog.UI.Dialogs
{
    partial class MeasureEditDlg
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dtpTimestamp;
        private System.Windows.Forms.Label lblTimestamp;
        private System.Windows.Forms.TextBox txtTemperature;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.ComboBox cmbAquarium;
        private System.Windows.Forms.Label lblAquarium;
        private System.Windows.Forms.Label lblNO3;
        private System.Windows.Forms.TextBox txtNO3;
        private System.Windows.Forms.Label lblNO2;
        private System.Windows.Forms.TextBox txtNO2;
        private System.Windows.Forms.Label lblGH;
        private System.Windows.Forms.TextBox txtGH;
        private System.Windows.Forms.Label lblKH;
        private System.Windows.Forms.TextBox txtKH;
        private System.Windows.Forms.Label lblPH;
        private System.Windows.Forms.TextBox txtPH;
        private System.Windows.Forms.Label lblCl2;
        private System.Windows.Forms.TextBox txtCl2;
        private System.Windows.Forms.Label lblCO2;
        private System.Windows.Forms.TextBox txtCO2;
        private System.Windows.Forms.Button btnCalcCO2;
        private System.Windows.Forms.Label lblNHtot;
        private System.Windows.Forms.TextBox txtNHtot;
        private System.Windows.Forms.Label lblNH3;
        private System.Windows.Forms.TextBox txtNH3;
        private System.Windows.Forms.Label lblNH4;
        private System.Windows.Forms.TextBox txtNH4;
        private System.Windows.Forms.Button btnCalcNH4;
        private System.Windows.Forms.Button btnCalcNH3;
        private System.Windows.Forms.Label lblPO4;
        private System.Windows.Forms.TextBox txtPO4;
        
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
            this.lblTimestamp = new System.Windows.Forms.Label();
            this.txtTemperature = new System.Windows.Forms.TextBox();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.dtpTimestamp = new System.Windows.Forms.DateTimePicker();
            this.cmbAquarium = new System.Windows.Forms.ComboBox();
            this.lblAquarium = new System.Windows.Forms.Label();
            this.lblNO3 = new System.Windows.Forms.Label();
            this.txtNO3 = new System.Windows.Forms.TextBox();
            this.lblNO2 = new System.Windows.Forms.Label();
            this.txtNO2 = new System.Windows.Forms.TextBox();
            this.lblGH = new System.Windows.Forms.Label();
            this.txtGH = new System.Windows.Forms.TextBox();
            this.lblKH = new System.Windows.Forms.Label();
            this.txtKH = new System.Windows.Forms.TextBox();
            this.lblPH = new System.Windows.Forms.Label();
            this.txtPH = new System.Windows.Forms.TextBox();
            this.lblCl2 = new System.Windows.Forms.Label();
            this.txtCl2 = new System.Windows.Forms.TextBox();
            this.lblCO2 = new System.Windows.Forms.Label();
            this.txtCO2 = new System.Windows.Forms.TextBox();
            this.btnCalcCO2 = new System.Windows.Forms.Button();
            this.lblNHtot = new System.Windows.Forms.Label();
            this.txtNHtot = new System.Windows.Forms.TextBox();
            this.lblNH3 = new System.Windows.Forms.Label();
            this.txtNH3 = new System.Windows.Forms.TextBox();
            this.lblNH4 = new System.Windows.Forms.Label();
            this.txtNH4 = new System.Windows.Forms.TextBox();
            this.btnCalcNH4 = new System.Windows.Forms.Button();
            this.btnCalcNH3 = new System.Windows.Forms.Button();
            this.lblPO4 = new System.Windows.Forms.Label();
            this.txtPO4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(104, 439);
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
            this.btnCancel.Location = new System.Drawing.Point(204, 439);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 24);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblTimestamp
            // 
            this.lblTimestamp.Location = new System.Drawing.Point(11, 46);
            this.lblTimestamp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimestamp.Name = "lblTimestamp";
            this.lblTimestamp.Size = new System.Drawing.Size(80, 17);
            this.lblTimestamp.TabIndex = 2;
            this.lblTimestamp.Text = "Timestamp";
            // 
            // txtTemperature
            // 
            this.txtTemperature.Location = new System.Drawing.Point(101, 71);
            this.txtTemperature.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtTemperature.Name = "txtTemperature";
            this.txtTemperature.Size = new System.Drawing.Size(74, 22);
            this.txtTemperature.TabIndex = 5;
            // 
            // lblTemperature
            // 
            this.lblTemperature.Location = new System.Drawing.Point(11, 74);
            this.lblTemperature.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(80, 17);
            this.lblTemperature.TabIndex = 4;
            this.lblTemperature.Text = "Temperature";
            // 
            // dtpTimestamp
            // 
            this.dtpTimestamp.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dtpTimestamp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimestamp.Location = new System.Drawing.Point(101, 41);
            this.dtpTimestamp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.dtpTimestamp.Name = "dtpTimestamp";
            this.dtpTimestamp.Size = new System.Drawing.Size(152, 22);
            this.dtpTimestamp.TabIndex = 3;
            // 
            // cmbAquarium
            // 
            this.cmbAquarium.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAquarium.Location = new System.Drawing.Point(101, 10);
            this.cmbAquarium.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbAquarium.Name = "cmbAquarium";
            this.cmbAquarium.Size = new System.Drawing.Size(199, 21);
            this.cmbAquarium.TabIndex = 1;
            // 
            // lblAquarium
            // 
            this.lblAquarium.Location = new System.Drawing.Point(11, 13);
            this.lblAquarium.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAquarium.Name = "lblAquarium";
            this.lblAquarium.Size = new System.Drawing.Size(88, 17);
            this.lblAquarium.TabIndex = 0;
            this.lblAquarium.Text = "Aquarium";
            // 
            // lblNO3
            // 
            this.lblNO3.Location = new System.Drawing.Point(11, 105);
            this.lblNO3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNO3.Name = "lblNO3";
            this.lblNO3.Size = new System.Drawing.Size(80, 17);
            this.lblNO3.TabIndex = 6;
            this.lblNO3.Text = "NO3";
            // 
            // txtNO3
            // 
            this.txtNO3.Location = new System.Drawing.Point(101, 102);
            this.txtNO3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtNO3.Name = "txtNO3";
            this.txtNO3.Size = new System.Drawing.Size(74, 22);
            this.txtNO3.TabIndex = 7;
            // 
            // lblNO2
            // 
            this.lblNO2.Location = new System.Drawing.Point(11, 135);
            this.lblNO2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNO2.Name = "lblNO2";
            this.lblNO2.Size = new System.Drawing.Size(80, 17);
            this.lblNO2.TabIndex = 8;
            this.lblNO2.Text = "NO2";
            // 
            // txtNO2
            // 
            this.txtNO2.Location = new System.Drawing.Point(101, 132);
            this.txtNO2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtNO2.Name = "txtNO2";
            this.txtNO2.Size = new System.Drawing.Size(74, 22);
            this.txtNO2.TabIndex = 9;
            // 
            // lblGH
            // 
            this.lblGH.Location = new System.Drawing.Point(11, 165);
            this.lblGH.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGH.Name = "lblGH";
            this.lblGH.Size = new System.Drawing.Size(80, 17);
            this.lblGH.TabIndex = 10;
            this.lblGH.Text = "GH";
            // 
            // txtGH
            // 
            this.txtGH.Location = new System.Drawing.Point(101, 162);
            this.txtGH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtGH.Name = "txtGH";
            this.txtGH.Size = new System.Drawing.Size(74, 22);
            this.txtGH.TabIndex = 11;
            // 
            // lblKH
            // 
            this.lblKH.Location = new System.Drawing.Point(11, 196);
            this.lblKH.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblKH.Name = "lblKH";
            this.lblKH.Size = new System.Drawing.Size(80, 17);
            this.lblKH.TabIndex = 12;
            this.lblKH.Text = "KH";
            // 
            // txtKH
            // 
            this.txtKH.Location = new System.Drawing.Point(101, 193);
            this.txtKH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtKH.Name = "txtKH";
            this.txtKH.Size = new System.Drawing.Size(74, 22);
            this.txtKH.TabIndex = 13;
            // 
            // lblPH
            // 
            this.lblPH.Location = new System.Drawing.Point(11, 226);
            this.lblPH.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPH.Name = "lblPH";
            this.lblPH.Size = new System.Drawing.Size(80, 17);
            this.lblPH.TabIndex = 14;
            this.lblPH.Text = "pH";
            // 
            // txtPH
            // 
            this.txtPH.Location = new System.Drawing.Point(101, 223);
            this.txtPH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtPH.Name = "txtPH";
            this.txtPH.Size = new System.Drawing.Size(74, 22);
            this.txtPH.TabIndex = 15;
            // 
            // lblCl2
            // 
            this.lblCl2.Location = new System.Drawing.Point(11, 257);
            this.lblCl2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCl2.Name = "lblCl2";
            this.lblCl2.Size = new System.Drawing.Size(80, 17);
            this.lblCl2.TabIndex = 16;
            this.lblCl2.Text = "Cl2";
            // 
            // txtCl2
            // 
            this.txtCl2.Location = new System.Drawing.Point(101, 254);
            this.txtCl2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtCl2.Name = "txtCl2";
            this.txtCl2.Size = new System.Drawing.Size(74, 22);
            this.txtCl2.TabIndex = 17;
            // 
            // lblCO2
            // 
            this.lblCO2.Location = new System.Drawing.Point(11, 287);
            this.lblCO2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCO2.Name = "lblCO2";
            this.lblCO2.Size = new System.Drawing.Size(80, 17);
            this.lblCO2.TabIndex = 18;
            this.lblCO2.Text = "CO2";
            // 
            // txtCO2
            // 
            this.txtCO2.Location = new System.Drawing.Point(101, 284);
            this.txtCO2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtCO2.Name = "txtCO2";
            this.txtCO2.Size = new System.Drawing.Size(74, 22);
            this.txtCO2.TabIndex = 19;
            // 
            // btnCalcCO2
            // 
            this.btnCalcCO2.Location = new System.Drawing.Point(179, 284);
            this.btnCalcCO2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.btnCalcCO2.Name = "btnCalcCO2";
            this.btnCalcCO2.Size = new System.Drawing.Size(121, 22);
            this.btnCalcCO2.TabIndex = 30;
            this.btnCalcCO2.Text = "<= Calc(KH, pH)";
            this.btnCalcCO2.UseVisualStyleBackColor = true;
            this.btnCalcCO2.Click += new System.EventHandler(this.btnCalcCO2_Click);
            // 
            // lblNHtot
            // 
            this.lblNHtot.Location = new System.Drawing.Point(11, 318);
            this.lblNHtot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNHtot.Name = "lblNHtot";
            this.lblNHtot.Size = new System.Drawing.Size(80, 17);
            this.lblNHtot.TabIndex = 20;
            this.lblNHtot.Text = "NH total";
            // 
            // txtNHtot
            // 
            this.txtNHtot.Location = new System.Drawing.Point(101, 315);
            this.txtNHtot.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtNHtot.Name = "txtNHtot";
            this.txtNHtot.Size = new System.Drawing.Size(74, 22);
            this.txtNHtot.TabIndex = 21;
            // 
            // lblNH3
            // 
            this.lblNH3.Location = new System.Drawing.Point(11, 349);
            this.lblNH3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNH3.Name = "lblNH3";
            this.lblNH3.Size = new System.Drawing.Size(80, 17);
            this.lblNH3.TabIndex = 22;
            this.lblNH3.Text = "NH3";
            // 
            // txtNH3
            // 
            this.txtNH3.Location = new System.Drawing.Point(101, 346);
            this.txtNH3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtNH3.Name = "txtNH3";
            this.txtNH3.Size = new System.Drawing.Size(74, 22);
            this.txtNH3.TabIndex = 23;
            // 
            // lblNH4
            // 
            this.lblNH4.Location = new System.Drawing.Point(11, 379);
            this.lblNH4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNH4.Name = "lblNH4";
            this.lblNH4.Size = new System.Drawing.Size(80, 17);
            this.lblNH4.TabIndex = 24;
            this.lblNH4.Text = "NH4";
            // 
            // txtNH4
            // 
            this.txtNH4.Location = new System.Drawing.Point(101, 377);
            this.txtNH4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtNH4.Name = "txtNH4";
            this.txtNH4.Size = new System.Drawing.Size(74, 22);
            this.txtNH4.TabIndex = 25;
            // 
            // btnCalcNH4
            // 
            this.btnCalcNH4.Location = new System.Drawing.Point(179, 377);
            this.btnCalcNH4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.btnCalcNH4.Name = "btnCalcNH4";
            this.btnCalcNH4.Size = new System.Drawing.Size(121, 22);
            this.btnCalcNH4.TabIndex = 32;
            this.btnCalcNH4.Text = "<= Calc(NHtot,NH3)";
            this.btnCalcNH4.UseVisualStyleBackColor = true;
            this.btnCalcNH4.Click += new System.EventHandler(this.btnCalcNH4_Click);
            // 
            // btnCalcNH3
            // 
            this.btnCalcNH3.Location = new System.Drawing.Point(179, 346);
            this.btnCalcNH3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.btnCalcNH3.Name = "btnCalcNH3";
            this.btnCalcNH3.Size = new System.Drawing.Size(121, 22);
            this.btnCalcNH3.TabIndex = 31;
            this.btnCalcNH3.Text = "<= Calc(NHtot,pH,T)";
            this.btnCalcNH3.UseVisualStyleBackColor = true;
            this.btnCalcNH3.Click += new System.EventHandler(this.btnCalcNH3_Click);
            // 
            // lblPO4
            // 
            this.lblPO4.Location = new System.Drawing.Point(11, 411);
            this.lblPO4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPO4.Name = "lblPO4";
            this.lblPO4.Size = new System.Drawing.Size(80, 17);
            this.lblPO4.TabIndex = 26;
            this.lblPO4.Text = "PO4";
            // 
            // txtPO4
            // 
            this.txtPO4.Location = new System.Drawing.Point(101, 408);
            this.txtPO4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtPO4.Name = "txtPO4";
            this.txtPO4.Size = new System.Drawing.Size(74, 22);
            this.txtPO4.TabIndex = 27;
            // 
            // MeasureEditDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(311, 474);
            this.Controls.Add(this.btnCalcNH3);
            this.Controls.Add(this.btnCalcNH4);
            this.Controls.Add(this.btnCalcCO2);
            this.Controls.Add(this.cmbAquarium);
            this.Controls.Add(this.lblAquarium);
            this.Controls.Add(this.txtPO4);
            this.Controls.Add(this.txtNH4);
            this.Controls.Add(this.lblPO4);
            this.Controls.Add(this.dtpTimestamp);
            this.Controls.Add(this.lblNH4);
            this.Controls.Add(this.txtCO2);
            this.Controls.Add(this.txtNH3);
            this.Controls.Add(this.lblCO2);
            this.Controls.Add(this.lblNH3);
            this.Controls.Add(this.txtCl2);
            this.Controls.Add(this.txtNHtot);
            this.Controls.Add(this.lblCl2);
            this.Controls.Add(this.lblNHtot);
            this.Controls.Add(this.txtPH);
            this.Controls.Add(this.lblPH);
            this.Controls.Add(this.txtKH);
            this.Controls.Add(this.lblKH);
            this.Controls.Add(this.txtGH);
            this.Controls.Add(this.lblGH);
            this.Controls.Add(this.txtNO2);
            this.Controls.Add(this.lblNO2);
            this.Controls.Add(this.txtNO3);
            this.Controls.Add(this.lblNO3);
            this.Controls.Add(this.txtTemperature);
            this.Controls.Add(this.lblTemperature);
            this.Controls.Add(this.lblTimestamp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MeasureEditDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Measure";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
