/*
 * Created by SharpDevelop.
 * User: Norseman
 * Date: 18.07.2019
 * Time: 10:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AquaLog
{
    partial class AquariumEditDlg
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
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
        private System.Windows.Forms.TextBox txtVolume;
        private System.Windows.Forms.Label lblVolume;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
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
            this.tabTank = new System.Windows.Forms.TabPage();
            this.txtVolume = new System.Windows.Forms.TextBox();
            this.txtHeigth = new System.Windows.Forms.TextBox();
            this.txtDepth = new System.Windows.Forms.TextBox();
            this.lblVolume = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.lblHeigth = new System.Windows.Forms.Label();
            this.lblDepth = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabTank.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(442, 326);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(96, 32);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(544, 326);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 32);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(15, 18);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            // 
            // lblShape
            // 
            this.lblShape.Location = new System.Drawing.Point(421, 18);
            this.lblShape.Name = "lblShape";
            this.lblShape.Size = new System.Drawing.Size(100, 23);
            this.lblShape.TabIndex = 3;
            this.lblShape.Text = "Shape";
            // 
            // lblDesc
            // 
            this.lblDesc.Location = new System.Drawing.Point(15, 57);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(100, 23);
            this.lblDesc.TabIndex = 4;
            this.lblDesc.Text = "Description";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(104, 15);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(311, 26);
            this.txtName.TabIndex = 5;
            // 
            // cmbShape
            // 
            this.cmbShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShape.FormattingEnabled = true;
            this.cmbShape.Location = new System.Drawing.Point(471, 15);
            this.cmbShape.Name = "cmbShape";
            this.cmbShape.Size = new System.Drawing.Size(169, 26);
            this.cmbShape.TabIndex = 6;
            this.cmbShape.SelectedIndexChanged += new System.EventHandler(this.cmbShape_SelectedIndexChanged);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(104, 54);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(536, 63);
            this.txtDesc.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCommon);
            this.tabControl1.Controls.Add(this.tabTank);
            this.tabControl1.Location = new System.Drawing.Point(15, 132);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(625, 179);
            this.tabControl1.TabIndex = 8;
            // 
            // tabCommon
            // 
            this.tabCommon.BackColor = System.Drawing.SystemColors.Control;
            this.tabCommon.Location = new System.Drawing.Point(4, 27);
            this.tabCommon.Name = "tabCommon";
            this.tabCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tabCommon.Size = new System.Drawing.Size(617, 148);
            this.tabCommon.TabIndex = 0;
            this.tabCommon.Text = "Common";
            // 
            // tabTank
            // 
            this.tabTank.BackColor = System.Drawing.SystemColors.Control;
            this.tabTank.Controls.Add(this.txtVolume);
            this.tabTank.Controls.Add(this.txtHeigth);
            this.tabTank.Controls.Add(this.txtDepth);
            this.tabTank.Controls.Add(this.lblVolume);
            this.tabTank.Controls.Add(this.txtWidth);
            this.tabTank.Controls.Add(this.lblHeigth);
            this.tabTank.Controls.Add(this.lblDepth);
            this.tabTank.Controls.Add(this.lblWidth);
            this.tabTank.Location = new System.Drawing.Point(4, 27);
            this.tabTank.Name = "tabTank";
            this.tabTank.Padding = new System.Windows.Forms.Padding(10);
            this.tabTank.Size = new System.Drawing.Size(617, 148);
            this.tabTank.TabIndex = 1;
            this.tabTank.Text = "Tank";
            // 
            // txtVolume
            // 
            this.txtVolume.Location = new System.Drawing.Point(85, 109);
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.Size = new System.Drawing.Size(100, 26);
            this.txtVolume.TabIndex = 5;
            // 
            // txtHeigth
            // 
            this.txtHeigth.Location = new System.Drawing.Point(85, 71);
            this.txtHeigth.Name = "txtHeigth";
            this.txtHeigth.Size = new System.Drawing.Size(100, 26);
            this.txtHeigth.TabIndex = 5;
            this.txtHeigth.TextChanged += new System.EventHandler(this.txtSizes_TextChanged);
            // 
            // txtDepth
            // 
            this.txtDepth.Location = new System.Drawing.Point(85, 39);
            this.txtDepth.Name = "txtDepth";
            this.txtDepth.Size = new System.Drawing.Size(100, 26);
            this.txtDepth.TabIndex = 4;
            this.txtDepth.TextChanged += new System.EventHandler(this.txtSizes_TextChanged);
            // 
            // lblVolume
            // 
            this.lblVolume.Location = new System.Drawing.Point(13, 112);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(100, 23);
            this.lblVolume.TabIndex = 2;
            this.lblVolume.Text = "Heigth";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(85, 7);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(100, 26);
            this.txtWidth.TabIndex = 3;
            this.txtWidth.TextChanged += new System.EventHandler(this.txtSizes_TextChanged);
            // 
            // lblHeigth
            // 
            this.lblHeigth.Location = new System.Drawing.Point(13, 74);
            this.lblHeigth.Name = "lblHeigth";
            this.lblHeigth.Size = new System.Drawing.Size(100, 23);
            this.lblHeigth.TabIndex = 2;
            this.lblHeigth.Text = "Heigth";
            // 
            // lblDepth
            // 
            this.lblDepth.Location = new System.Drawing.Point(13, 42);
            this.lblDepth.Name = "lblDepth";
            this.lblDepth.Size = new System.Drawing.Size(100, 23);
            this.lblDepth.TabIndex = 1;
            this.lblDepth.Text = "Depth";
            // 
            // lblWidth
            // 
            this.lblWidth.Location = new System.Drawing.Point(13, 10);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(100, 23);
            this.lblWidth.TabIndex = 0;
            this.lblWidth.Text = "Width";
            // 
            // AquariumEditDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(652, 370);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.cmbShape);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblShape);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AquariumEditDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AquariumEditDlg";
            this.tabControl1.ResumeLayout(false);
            this.tabTank.ResumeLayout(false);
            this.tabTank.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
