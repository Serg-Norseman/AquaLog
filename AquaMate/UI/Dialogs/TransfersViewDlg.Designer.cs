namespace AquaMate.UI.Dialogs
{
	partial class TransfersViewDlg
	{
		private System.Windows.Forms.Button btnClose;
		private AquaMate.UI.Components.ZListView listView;

		private void InitializeComponent()
		{
		    this.btnClose = new System.Windows.Forms.Button();
		    this.listView = new AquaMate.UI.Components.ZListView();
		    this.SuspendLayout();
		    // 
		    // btnClose
		    // 
		    this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		    this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		    this.btnClose.Location = new System.Drawing.Point(521, 241);
		    this.btnClose.Margin = new System.Windows.Forms.Padding(2);
		    this.btnClose.Name = "btnClose";
		    this.btnClose.Size = new System.Drawing.Size(91, 24);
		    this.btnClose.TabIndex = 0;
		    this.btnClose.Text = "btnClose";
		    this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		    // 
		    // listView
		    // 
		    this.listView.FullRowSelect = true;
		    this.listView.HideSelection = false;
		    this.listView.Location = new System.Drawing.Point(12, 12);
		    this.listView.Name = "listView";
		    this.listView.Order = System.Windows.Forms.SortOrder.None;
		    this.listView.OwnerDraw = true;
		    this.listView.Size = new System.Drawing.Size(599, 224);
		    this.listView.SortColumn = 0;
		    this.listView.TabIndex = 1;
		    this.listView.UseCompatibleStateImageBehavior = false;
		    this.listView.View = System.Windows.Forms.View.Details;
		    // 
		    // TransfersViewDlg
		    // 
		    this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
		    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		    this.CancelButton = this.btnClose;
		    this.ClientSize = new System.Drawing.Size(623, 276);
		    this.Controls.Add(this.listView);
		    this.Controls.Add(this.btnClose);
		    this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
		    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		    this.Margin = new System.Windows.Forms.Padding(2);
		    this.MaximizeBox = false;
		    this.MinimizeBox = false;
		    this.Name = "TransfersViewDlg";
		    this.ShowInTaskbar = false;
		    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		    this.Text = "TransfersViewDlg";
		    this.ResumeLayout(false);

		}
	}
}
