using System.ComponentModel;

namespace BOSERP
{
    partial class guiDocumentRelease
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                if (components != null)
                    components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiDocumentRelease));
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.grcEmrDocumentRelease = new DevExpress.XtraGrid.GridControl();
            this.gridViewEmrDocumentRelease = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grcEmrDocumentRelease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEmrDocumentRelease)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnOk.Location = new System.Drawing.Point(606, 294);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(183, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Giải phóng";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(792, 294);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grcEmrDocumentRelease
            // 
            this.grcEmrDocumentRelease.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grcEmrDocumentRelease.Location = new System.Drawing.Point(2, 2);
            this.grcEmrDocumentRelease.MainView = this.gridViewEmrDocumentRelease;
            this.grcEmrDocumentRelease.MenuManager = this.screenToolbar;
            this.grcEmrDocumentRelease.Name = "grcEmrDocumentRelease";
            this.grcEmrDocumentRelease.Size = new System.Drawing.Size(871, 286);
            this.grcEmrDocumentRelease.TabIndex = 9;
            this.grcEmrDocumentRelease.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEmrDocumentRelease});
            // 
            // gridViewEmrDocumentRelease
            // 
            this.gridViewEmrDocumentRelease.GridControl = this.grcEmrDocumentRelease;
            this.gridViewEmrDocumentRelease.Name = "gridViewEmrDocumentRelease";
            // 
            // guiDocumentRelease
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(876, 327);
            this.ControlBox = true;
            this.Controls.Add(this.grcEmrDocumentRelease);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiDocumentRelease";
            this.Text = "Danh sách tờ bệnh án đang được soạn trên máy khác";
            this.Load += new System.EventHandler(this.guiDocumentRelease_Load);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.grcEmrDocumentRelease, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grcEmrDocumentRelease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEmrDocumentRelease)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private IContainer components;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraGrid.GridControl grcEmrDocumentRelease;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEmrDocumentRelease;
    }
}
