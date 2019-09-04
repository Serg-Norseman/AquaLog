namespace AquaLog.UI.Dialogs
{
    partial class CalculatorDlg
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PropertyGrid pgArgs;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.TextBox txtDescription;

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
            this.pgArgs = new System.Windows.Forms.PropertyGrid();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnCalc = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pgArgs
            // 
            this.pgArgs.HelpVisible = false;
            this.pgArgs.Location = new System.Drawing.Point(9, 39);
            this.pgArgs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.pgArgs.Name = "pgArgs";
            this.pgArgs.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pgArgs.Size = new System.Drawing.Size(295, 218);
            this.pgArgs.TabIndex = 0;
            this.pgArgs.ToolbarVisible = false;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(9, 9);
            this.cmbType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(296, 21);
            this.cmbType.TabIndex = 1;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(208, 333);
            this.btnCalc.Margin = new System.Windows.Forms.Padding(2);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(96, 24);
            this.btnCalc.TabIndex = 8;
            this.btnCalc.Text = "Calculate";
            this.btnCalc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(9, 266);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2, 2, 2, 7);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(296, 58);
            this.txtDescription.TabIndex = 9;
            // 
            // CalculatorDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(313, 366);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.pgArgs);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalculatorDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
