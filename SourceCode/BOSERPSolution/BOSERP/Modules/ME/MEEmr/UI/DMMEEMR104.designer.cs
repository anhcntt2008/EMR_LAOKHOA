using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSComponent;

namespace BOSERP.Modules.MEEmr.UI
{
	/// <summary>
	/// Summary description for DMMEEMR104
	/// </summary>
	partial class DMMEEMR104
	{
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMMEEMR104));
            this.panelControl1 = new BOSComponent.BOSPanel(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fld_btnRefreshHistory = new DevExpress.XtraEditors.SimpleButton();
            this.btnRunAgainMEEmrDocumentBackground = new DevExpress.XtraEditors.SimpleButton();
            this.fld_dgcMdAutoGenDocumentDto = new BOSERP.Modules.MEEmr.MdAutoGenDocumentDtoGridControl();
            this.fld_dgvMdAutoGenDocumentDto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMdAutoGenDocumentDto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMdAutoGenDocumentDto)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BOSComment = null;
            this.panelControl1.BOSDataMember = null;
            this.panelControl1.BOSDataSource = null;
            this.panelControl1.BOSDescription = null;
            this.panelControl1.BOSError = null;
            this.panelControl1.BOSFieldGroup = null;
            this.panelControl1.BOSFieldRelation = null;
            this.panelControl1.BOSPrivilege = null;
            this.panelControl1.BOSPropertyName = null;
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.fld_btnRefreshHistory);
            this.panelControl1.Controls.Add(this.btnRunAgainMEEmrDocumentBackground);
            this.panelControl1.Controls.Add(this.fld_dgcMdAutoGenDocumentDto);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Screen = null;
            this.panelControl1.Size = new System.Drawing.Size(947, 425);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DarkGray;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(241, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(377, 13);
            this.labelControl1.TabIndex = 21;
            this.labelControl1.Text = "Bấm thực hiện lại để khởi chạy lại tác vụ trong trường hợp tác vụ bị lỗi hay treo";
            // 
            // fld_btnRefreshHistory
            // 
            this.fld_btnRefreshHistory.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("fld_btnRefreshHistory.ImageOptions.Image")));
            this.fld_btnRefreshHistory.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.fld_btnRefreshHistory.Location = new System.Drawing.Point(12, 8);
            this.fld_btnRefreshHistory.Name = "fld_btnRefreshHistory";
            this.fld_btnRefreshHistory.Size = new System.Drawing.Size(86, 23);
            this.fld_btnRefreshHistory.TabIndex = 20;
            this.fld_btnRefreshHistory.Text = "Làm mới";
            this.fld_btnRefreshHistory.Click += new System.EventHandler(this.fld_btnRefreshHistory_Click);
            // 
            // btnRunAgainMEEmrDocumentBackground
            // 
            this.btnRunAgainMEEmrDocumentBackground.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRunAgainMEEmrDocumentBackground.ImageOptions.Image")));
            this.btnRunAgainMEEmrDocumentBackground.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnRunAgainMEEmrDocumentBackground.Location = new System.Drawing.Point(117, 8);
            this.btnRunAgainMEEmrDocumentBackground.Name = "btnRunAgainMEEmrDocumentBackground";
            this.btnRunAgainMEEmrDocumentBackground.Size = new System.Drawing.Size(118, 23);
            this.btnRunAgainMEEmrDocumentBackground.TabIndex = 19;
            this.btnRunAgainMEEmrDocumentBackground.Text = "Thực hiện lại";
            this.btnRunAgainMEEmrDocumentBackground.Click += new System.EventHandler(this.btnRunAgainMEEmrDocumentBackground_Click);
            // 
            // fld_dgcMdAutoGenDocumentDto
            // 
            this.fld_dgcMdAutoGenDocumentDto.AllowDrop = true;
            this.fld_dgcMdAutoGenDocumentDto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcMdAutoGenDocumentDto.BOSComment = "";
            this.fld_dgcMdAutoGenDocumentDto.BOSDataMember = "";
            this.fld_dgcMdAutoGenDocumentDto.BOSDataSource = "MdAutoGenDocumentDto";
            this.fld_dgcMdAutoGenDocumentDto.BOSDescription = null;
            this.fld_dgcMdAutoGenDocumentDto.BOSError = null;
            this.fld_dgcMdAutoGenDocumentDto.BOSFieldGroup = "";
            this.fld_dgcMdAutoGenDocumentDto.BOSFieldRelation = "";
            this.fld_dgcMdAutoGenDocumentDto.BOSGridType = null;
            this.fld_dgcMdAutoGenDocumentDto.BOSPrivilege = "";
            this.fld_dgcMdAutoGenDocumentDto.BOSPropertyName = "";
            this.fld_dgcMdAutoGenDocumentDto.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMdAutoGenDocumentDto.Location = new System.Drawing.Point(0, 37);
            this.fld_dgcMdAutoGenDocumentDto.MainView = this.fld_dgvMdAutoGenDocumentDto;
            this.fld_dgcMdAutoGenDocumentDto.Name = "fld_dgcMdAutoGenDocumentDto";
            this.fld_dgcMdAutoGenDocumentDto.PrintReport = false;
            this.fld_dgcMdAutoGenDocumentDto.Screen = null;
            this.fld_dgcMdAutoGenDocumentDto.Size = new System.Drawing.Size(944, 385);
            this.fld_dgcMdAutoGenDocumentDto.TabIndex = 16;
            this.fld_dgcMdAutoGenDocumentDto.Tag = "DC";
            this.fld_dgcMdAutoGenDocumentDto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvMdAutoGenDocumentDto});
            // 
            // fld_dgvMdAutoGenDocumentDto
            // 
            this.fld_dgvMdAutoGenDocumentDto.GridControl = this.fld_dgcMdAutoGenDocumentDto;
            this.fld_dgvMdAutoGenDocumentDto.Name = "fld_dgvMdAutoGenDocumentDto";
            this.fld_dgvMdAutoGenDocumentDto.PaintStyleName = "Office2003";
            // 
            // DMMEEMR104
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(947, 425);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DMMEEMR104";
            this.Text = "Tác vụ chạy ngầm";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMdAutoGenDocumentDto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMdAutoGenDocumentDto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion

        private IContainer components;
        private BOSPanel panelControl1;
        private MdAutoGenDocumentDtoGridControl fld_dgcMdAutoGenDocumentDto;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvMdAutoGenDocumentDto;
        private DevExpress.XtraEditors.SimpleButton btnRunAgainMEEmrDocumentBackground;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton fld_btnRefreshHistory;
    }
}
