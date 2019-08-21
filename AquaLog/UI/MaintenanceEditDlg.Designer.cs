namespace AquaLog.UI
{
    partial class MaintenanceEditDlg
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblAquarium;
        private System.Windows.Forms.ComboBox cmbAquarium;
        private System.Windows.Forms.DateTimePicker dtpDateTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.ComboBox cmbSchedule;
        private System.Windows.Forms.Label lblSchedule;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.TextBox txtEvent;
        private System.Windows.Forms.Label lblUnits;
        private System.Windows.Forms.TextBox txtUnits;
        private System.Windows.Forms.CheckBox chkReminder;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        
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
            this.lblAquarium = new System.Windows.Forms.Label();
            this.cmbAquarium = new System.Windows.Forms.ComboBox();
            this.dtpDateTime = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.cmbSchedule = new System.Windows.Forms.ComboBox();
            this.lblSchedule = new System.Windows.Forms.Label();
            this.lblEvent = new System.Windows.Forms.Label();
            this.txtEvent = new System.Windows.Forms.TextBox();
            this.lblUnits = new System.Windows.Forms.Label();
            this.txtUnits = new System.Windows.Forms.TextBox();
            this.chkReminder = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(218, 363);
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
            this.btnCancel.Location = new System.Drawing.Point(320, 363);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblAquarium
            // 
            this.lblAquarium.Location = new System.Drawing.Point(12, 15);
            this.lblAquarium.Name = "lblAquarium";
            this.lblAquarium.Size = new System.Drawing.Size(110, 21);
            this.lblAquarium.TabIndex = 2;
            this.lblAquarium.Text = "Aquarium";
            // 
            // cmbAquarium
            // 
            this.cmbAquarium.Location = new System.Drawing.Point(148, 12);
            this.cmbAquarium.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.cmbAquarium.Name = "cmbAquarium";
            this.cmbAquarium.Size = new System.Drawing.Size(268, 27);
            this.cmbAquarium.TabIndex = 5;
            // 
            // dtpDateTime
            // 
            this.dtpDateTime.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTime.Location = new System.Drawing.Point(148, 51);
            this.dtpDateTime.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.dtpDateTime.Name = "dtpDateTime";
            this.dtpDateTime.Size = new System.Drawing.Size(184, 26);
            this.dtpDateTime.TabIndex = 8;
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(12, 57);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(100, 21);
            this.lblDate.TabIndex = 7;
            this.lblDate.Text = "Date";
            // 
            // lblNote
            // 
            this.lblNote.Location = new System.Drawing.Point(12, 282);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(129, 21);
            this.lblNote.TabIndex = 2;
            this.lblNote.Text = "Note";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(147, 279);
            this.txtNote.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(269, 59);
            this.txtNote.TabIndex = 5;
            // 
            // cmbSchedule
            // 
            this.cmbSchedule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSchedule.FormattingEnabled = true;
            this.cmbSchedule.Location = new System.Drawing.Point(148, 201);
            this.cmbSchedule.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.cmbSchedule.Name = "cmbSchedule";
            this.cmbSchedule.Size = new System.Drawing.Size(169, 27);
            this.cmbSchedule.TabIndex = 10;
            // 
            // lblSchedule
            // 
            this.lblSchedule.Location = new System.Drawing.Point(12, 204);
            this.lblSchedule.Name = "lblSchedule";
            this.lblSchedule.Size = new System.Drawing.Size(100, 21);
            this.lblSchedule.TabIndex = 9;
            this.lblSchedule.Text = "Schedule";
            // 
            // lblEvent
            // 
            this.lblEvent.Location = new System.Drawing.Point(12, 92);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(129, 21);
            this.lblEvent.TabIndex = 2;
            this.lblEvent.Text = "Event";
            // 
            // txtEvent
            // 
            this.txtEvent.Location = new System.Drawing.Point(148, 89);
            this.txtEvent.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.txtEvent.Name = "txtEvent";
            this.txtEvent.Size = new System.Drawing.Size(268, 26);
            this.txtEvent.TabIndex = 5;
            // 
            // lblUnits
            // 
            this.lblUnits.Location = new System.Drawing.Point(12, 130);
            this.lblUnits.Name = "lblUnits";
            this.lblUnits.Size = new System.Drawing.Size(129, 21);
            this.lblUnits.TabIndex = 2;
            this.lblUnits.Text = "Units";
            // 
            // txtUnits
            // 
            this.txtUnits.Location = new System.Drawing.Point(148, 127);
            this.txtUnits.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.txtUnits.Name = "txtUnits";
            this.txtUnits.Size = new System.Drawing.Size(268, 26);
            this.txtUnits.TabIndex = 5;
            // 
            // chkReminder
            // 
            this.chkReminder.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkReminder.Location = new System.Drawing.Point(12, 165);
            this.chkReminder.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.chkReminder.Name = "chkReminder";
            this.chkReminder.Size = new System.Drawing.Size(153, 24);
            this.chkReminder.TabIndex = 11;
            this.chkReminder.Text = "Reminder";
            this.chkReminder.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(12, 243);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 21);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(148, 240);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(169, 27);
            this.cmbStatus.TabIndex = 10;
            // 
            // MaintenanceEditDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(428, 405);
            this.Controls.Add(this.chkReminder);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbSchedule);
            this.Controls.Add(this.lblSchedule);
            this.Controls.Add(this.dtpDateTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cmbAquarium);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.txtUnits);
            this.Controls.Add(this.lblUnits);
            this.Controls.Add(this.txtEvent);
            this.Controls.Add(this.lblEvent);
            this.Controls.Add(this.lblAquarium);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaintenanceEditDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Maintenance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
