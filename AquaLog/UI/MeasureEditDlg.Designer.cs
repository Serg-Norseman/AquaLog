namespace AquaLog.UI
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
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(174, 304);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(96, 30);
            this.btnAccept.TabIndex = 20;
            this.btnAccept.Text = "Accept";
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(276, 304);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 30);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblTimestamp
            // 
            this.lblTimestamp.Location = new System.Drawing.Point(12, 46);
            this.lblTimestamp.Name = "lblTimestamp";
            this.lblTimestamp.Size = new System.Drawing.Size(100, 21);
            this.lblTimestamp.TabIndex = 2;
            this.lblTimestamp.Text = "Timestamp";
            // 
            // txtTemperature
            // 
            this.txtTemperature.Location = new System.Drawing.Point(126, 67);
            this.txtTemperature.Name = "txtTemperature";
            this.txtTemperature.Size = new System.Drawing.Size(91, 22);
            this.txtTemperature.TabIndex = 5;
            // 
            // lblTemperature
            // 
            this.lblTemperature.Location = new System.Drawing.Point(12, 70);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(100, 21);
            this.lblTemperature.TabIndex = 4;
            this.lblTemperature.Text = "Temperature";
            // 
            // dtpTimestamp
            // 
            this.dtpTimestamp.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dtpTimestamp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimestamp.Location = new System.Drawing.Point(126, 39);
            this.dtpTimestamp.Name = "dtpTimestamp";
            this.dtpTimestamp.Size = new System.Drawing.Size(169, 22);
            this.dtpTimestamp.TabIndex = 3;
            // 
            // cmbAquarium
            // 
            this.cmbAquarium.Location = new System.Drawing.Point(126, 12);
            this.cmbAquarium.Name = "cmbAquarium";
            this.cmbAquarium.Size = new System.Drawing.Size(246, 21);
            this.cmbAquarium.TabIndex = 1;
            // 
            // lblAquarium
            // 
            this.lblAquarium.Location = new System.Drawing.Point(12, 15);
            this.lblAquarium.Name = "lblAquarium";
            this.lblAquarium.Size = new System.Drawing.Size(110, 21);
            this.lblAquarium.TabIndex = 0;
            this.lblAquarium.Text = "Aquarium";
            // 
            // lblNO3
            // 
            this.lblNO3.Location = new System.Drawing.Point(12, 98);
            this.lblNO3.Name = "lblNO3";
            this.lblNO3.Size = new System.Drawing.Size(100, 21);
            this.lblNO3.TabIndex = 6;
            this.lblNO3.Text = "NO3";
            // 
            // txtNO3
            // 
            this.txtNO3.Location = new System.Drawing.Point(126, 95);
            this.txtNO3.Name = "txtNO3";
            this.txtNO3.Size = new System.Drawing.Size(91, 22);
            this.txtNO3.TabIndex = 7;
            // 
            // lblNO2
            // 
            this.lblNO2.Location = new System.Drawing.Point(12, 126);
            this.lblNO2.Name = "lblNO2";
            this.lblNO2.Size = new System.Drawing.Size(100, 21);
            this.lblNO2.TabIndex = 8;
            this.lblNO2.Text = "NO2";
            // 
            // txtNO2
            // 
            this.txtNO2.Location = new System.Drawing.Point(126, 123);
            this.txtNO2.Name = "txtNO2";
            this.txtNO2.Size = new System.Drawing.Size(91, 22);
            this.txtNO2.TabIndex = 9;
            // 
            // lblGH
            // 
            this.lblGH.Location = new System.Drawing.Point(12, 154);
            this.lblGH.Name = "lblGH";
            this.lblGH.Size = new System.Drawing.Size(100, 21);
            this.lblGH.TabIndex = 10;
            this.lblGH.Text = "GH";
            // 
            // txtGH
            // 
            this.txtGH.Location = new System.Drawing.Point(126, 151);
            this.txtGH.Name = "txtGH";
            this.txtGH.Size = new System.Drawing.Size(91, 22);
            this.txtGH.TabIndex = 11;
            // 
            // lblKH
            // 
            this.lblKH.Location = new System.Drawing.Point(12, 182);
            this.lblKH.Name = "lblKH";
            this.lblKH.Size = new System.Drawing.Size(100, 21);
            this.lblKH.TabIndex = 12;
            this.lblKH.Text = "KH";
            // 
            // txtKH
            // 
            this.txtKH.Location = new System.Drawing.Point(126, 179);
            this.txtKH.Name = "txtKH";
            this.txtKH.Size = new System.Drawing.Size(91, 22);
            this.txtKH.TabIndex = 13;
            // 
            // lblPH
            // 
            this.lblPH.Location = new System.Drawing.Point(12, 210);
            this.lblPH.Name = "lblPH";
            this.lblPH.Size = new System.Drawing.Size(100, 21);
            this.lblPH.TabIndex = 14;
            this.lblPH.Text = "pH";
            // 
            // txtPH
            // 
            this.txtPH.Location = new System.Drawing.Point(126, 207);
            this.txtPH.Name = "txtPH";
            this.txtPH.Size = new System.Drawing.Size(91, 22);
            this.txtPH.TabIndex = 15;
            // 
            // lblCl2
            // 
            this.lblCl2.Location = new System.Drawing.Point(12, 238);
            this.lblCl2.Name = "lblCl2";
            this.lblCl2.Size = new System.Drawing.Size(100, 21);
            this.lblCl2.TabIndex = 16;
            this.lblCl2.Text = "Cl2";
            // 
            // txtCl2
            // 
            this.txtCl2.Location = new System.Drawing.Point(126, 235);
            this.txtCl2.Name = "txtCl2";
            this.txtCl2.Size = new System.Drawing.Size(91, 22);
            this.txtCl2.TabIndex = 17;
            // 
            // lblCO2
            // 
            this.lblCO2.Location = new System.Drawing.Point(12, 266);
            this.lblCO2.Name = "lblCO2";
            this.lblCO2.Size = new System.Drawing.Size(100, 21);
            this.lblCO2.TabIndex = 18;
            this.lblCO2.Text = "CO2";
            // 
            // txtCO2
            // 
            this.txtCO2.Location = new System.Drawing.Point(126, 263);
            this.txtCO2.Name = "txtCO2";
            this.txtCO2.Size = new System.Drawing.Size(91, 22);
            this.txtCO2.TabIndex = 19;
            // 
            // btnCalcCO2
            // 
            this.btnCalcCO2.Location = new System.Drawing.Point(223, 263);
            this.btnCalcCO2.Name = "btnCalcCO2";
            this.btnCalcCO2.Size = new System.Drawing.Size(149, 22);
            this.btnCalcCO2.TabIndex = 22;
            this.btnCalcCO2.Text = "<= Calc(KH, pH)";
            this.btnCalcCO2.UseVisualStyleBackColor = true;
            this.btnCalcCO2.Click += new System.EventHandler(this.btnCalcCO2_Click);
            // 
            // MeasureEditDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(384, 346);
            this.Controls.Add(this.btnCalcCO2);
            this.Controls.Add(this.cmbAquarium);
            this.Controls.Add(this.lblAquarium);
            this.Controls.Add(this.dtpTimestamp);
            this.Controls.Add(this.txtCO2);
            this.Controls.Add(this.lblCO2);
            this.Controls.Add(this.txtCl2);
            this.Controls.Add(this.lblCl2);
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
