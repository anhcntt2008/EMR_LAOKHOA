using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.EmrAbbrev.UI
{
	/// <summary>
	/// Summary description for DMEAB100
	/// </summary>
	partial class guiAbbrevSelection
    {
		/// <summary>
		/// Required designer variable
		/// </summary>
		private System.ComponentModel.Container components = null;


		/// <summary>
		/// Clean up any resources being used
		/// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiAbbrevSelection));
            this.fld_dgcMEEmrAbbrevs = new BOSERP.Modules.EmrAbbrev.MEEmrAbbrevSharedsGridControl();
            this.fld_dgvMEEmrImages = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrAbbrevs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrImages)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_dgcMEEmrAbbrevs
            // 
            this.fld_dgcMEEmrAbbrevs.AllowDrop = true;
            this.fld_dgcMEEmrAbbrevs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcMEEmrAbbrevs.BOSComment = "";
            this.fld_dgcMEEmrAbbrevs.BOSDataMember = "";
            this.fld_dgcMEEmrAbbrevs.BOSDataSource = "MEEmrAbbrevs";
            this.fld_dgcMEEmrAbbrevs.BOSDescription = null;
            this.fld_dgcMEEmrAbbrevs.BOSError = null;
            this.fld_dgcMEEmrAbbrevs.BOSFieldGroup = "";
            this.fld_dgcMEEmrAbbrevs.BOSFieldRelation = "";
            this.fld_dgcMEEmrAbbrevs.BOSGridType = null;
            this.fld_dgcMEEmrAbbrevs.BOSPrivilege = "";
            this.fld_dgcMEEmrAbbrevs.BOSPropertyName = "";
            this.fld_dgcMEEmrAbbrevs.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMEEmrAbbrevs.Location = new System.Drawing.Point(0, 0);
            this.fld_dgcMEEmrAbbrevs.MainView = this.fld_dgvMEEmrImages;
            this.fld_dgcMEEmrAbbrevs.Name = "fld_dgcMEEmrAbbrevs";
            this.fld_dgcMEEmrAbbrevs.PrintReport = false;
            this.fld_dgcMEEmrAbbrevs.Screen = null;
            this.fld_dgcMEEmrAbbrevs.Size = new System.Drawing.Size(862, 527);
            this.fld_dgcMEEmrAbbrevs.TabIndex = 11;
            this.fld_dgcMEEmrAbbrevs.Tag = "DC";
            this.fld_dgcMEEmrAbbrevs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvMEEmrImages});
            // 
            // fld_dgvMEEmrImages
            // 
            this.fld_dgvMEEmrImages.GridControl = this.fld_dgcMEEmrAbbrevs;
            this.fld_dgvMEEmrImages.Name = "fld_dgvMEEmrImages";
            this.fld_dgvMEEmrImages.PaintStyleName = "Office2003";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(783, 535);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(702, 535);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // guiAbbrevSelection
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(862, 567);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.fld_dgcMEEmrAbbrevs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiAbbrevSelection";
            this.Text = "Danh sách từ viết tắt";
            this.Load += new System.EventHandler(this.guiAbbrevSelection_Load);
            this.Controls.SetChildIndex(this.fld_dgcMEEmrAbbrevs, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrAbbrevs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrImages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion

        private MEEmrAbbrevSharedsGridControl fld_dgcMEEmrAbbrevs;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvMEEmrImages;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
    }
}
