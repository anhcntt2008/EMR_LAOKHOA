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
	/// Summary description for DMMEEMR101
	/// </summary>
	partial class DMMEEMR101
	{
		private BOSComponent.BOSTextBox fld_txtMEEmrNo2;
		private BOSComponent.BOSMemoEdit fld_medMEEmrDesc1;
		private BOSComponent.BOSDateEdit fld_dteAACreatedDate;
		private BOSComponent.BOSDateEdit fld_dteAACreatedDate1;
		private BOSComponent.BOSLabel fld_lblLabel2;
		private BOSComponent.BOSLabel fld_lblLabel3;
		private BOSComponent.BOSLabel fld_lblLabel4;
		private BOSComponent.BOSLabel fld_lblLabel5;
		private BOSComponent.BOSLabel fld_lblLabel6;
		private BOSComponent.BOSLabel fld_lblLabel7;
		private BOSComponent.BOSLookupEdit fld_lkeLookupEdit;


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
            DevExpress.XtraTab.XtraTabControl tacTransferAndShare;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMMEEMR101));
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.fld_dgcMEEmrTransferHistories = new BOSERP.Modules.MEEmr.MEEmrTransfersGridControl();
            this.fld_dgvMEEmrTransferHistories = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_btnTransfer = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.fld_tbnSaveShareEmrClose = new DevExpress.XtraEditors.SimpleButton();
            this.fld_btnSelectEmployee = new DevExpress.XtraEditors.SimpleButton();
            this.fld_dgcMEEmrShareHistories = new BOSERP.Modules.MEEmr.MEEmrShareGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_btnSelectDepartment = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fld_btnRefreshMergeHistory = new DevExpress.XtraEditors.SimpleButton();
            this.fld_dgcMEEmrMergeHistories = new BOSERP.Modules.MEEmr.MEEmrMergeHistoriesGridControl();
            this.fld_dgvMEEmrMergeHistories = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_txtMEEmrNo2 = new BOSComponent.BOSTextBox();
            this.fld_medMEEmrDesc1 = new BOSComponent.BOSMemoEdit();
            this.fld_dteAACreatedDate = new BOSComponent.BOSDateEdit();
            this.fld_dteAACreatedDate1 = new BOSComponent.BOSDateEdit();
            this.fld_lblLabel2 = new BOSComponent.BOSLabel();
            this.fld_lblLabel3 = new BOSComponent.BOSLabel();
            this.fld_lblLabel4 = new BOSComponent.BOSLabel();
            this.fld_lblLabel5 = new BOSComponent.BOSLabel();
            this.fld_lblLabel6 = new BOSComponent.BOSLabel();
            this.fld_lblLabel7 = new BOSComponent.BOSLabel();
            this.fld_lkeLookupEdit = new BOSComponent.BOSLookupEdit();
            this.fld_tbnSearchPatientFromHis = new DevExpress.XtraEditors.SimpleButton();
            this.fld_lkeFK_MEEmrTypeID = new BOSComponent.BOSLookupEdit();
            this.bosLabel1 = new BOSComponent.BOSLabel();
            this.bosLabel2 = new BOSComponent.BOSLabel();
            this.bosLookupEdit1 = new BOSComponent.BOSLookupEdit();
            this.panelControl1 = new BOSComponent.BOSPanel();
            this.bosLabel11 = new BOSComponent.BOSLabel();
            this.fld_txtMEEmrPatientAddr = new BOSComponent.BOSTextBox();
            this.bosLabel10 = new BOSComponent.BOSLabel();
            this.fld_txtMEEmrArchiveNo = new BOSComponent.BOSTextBox();
            this.fld_lkeFK_HREmployeeClosedID = new BOSComponent.BOSLookupEdit();
            this.bosLabel9 = new BOSComponent.BOSLabel();
            this.bosLabel8 = new BOSComponent.BOSLabel();
            this.fld_txtMEEmrBedNo = new BOSComponent.BOSTextBox();
            this.bosLabel7 = new BOSComponent.BOSLabel();
            this.fld_txtMEEmrRoomNo = new BOSComponent.BOSTextBox();
            this.bosLabel6 = new BOSComponent.BOSLabel();
            this.fld_dpkMEEmrDateOut = new BOSComponent.BOSDateEdit();
            this.bosLabel5 = new BOSComponent.BOSLabel();
            this.fld_dpkMEEmrDateIn = new BOSComponent.BOSDateEdit();
            this.fld_lkeFK_HREmployeeCreatedID = new BOSComponent.BOSLookupEdit();
            this.bosLabel4 = new BOSComponent.BOSLabel();
            this.fld_lkeMEEmrTypeProfile = new BOSComponent.BOSLookupEdit();
            this.bosLabel3 = new BOSComponent.BOSLabel();
            this.bosTextBox2 = new BOSComponent.BOSTextBox();
            this.fld_txtMEPatientNo = new BOSComponent.BOSTextBox();
            this.fld_tbnSearchPatientLocal = new DevExpress.XtraEditors.SimpleButton();
            tacTransferAndShare = new DevExpress.XtraTab.XtraTabControl();
            ((System.ComponentModel.ISupportInitialize)(tacTransferAndShare)).BeginInit();
            tacTransferAndShare.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrTransferHistories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrTransferHistories)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrShareHistories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrMergeHistories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrMergeHistories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrNo2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_medMEEmrDesc1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteAACreatedDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteAACreatedDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteAACreatedDate1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteAACreatedDate1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeLookupEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_MEEmrTypeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosLookupEdit1.Properties)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrPatientAddr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrArchiveNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HREmployeeClosedID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrBedNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrRoomNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dpkMEEmrDateOut.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dpkMEEmrDateOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dpkMEEmrDateIn.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dpkMEEmrDateIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HREmployeeCreatedID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEEmrTypeProfile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosTextBox2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEPatientNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tacTransferAndShare
            // 
            tacTransferAndShare.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tacTransferAndShare.Location = new System.Drawing.Point(3, 279);
            tacTransferAndShare.Name = "tacTransferAndShare";
            tacTransferAndShare.SelectedTabPage = this.xtraTabPage1;
            tacTransferAndShare.Size = new System.Drawing.Size(671, 248);
            tacTransferAndShare.TabIndex = 25;
            tacTransferAndShare.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.fld_dgcMEEmrTransferHistories);
            this.xtraTabPage1.Controls.Add(this.fld_btnTransfer);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(665, 220);
            this.xtraTabPage1.Text = "Lịch sử chuyển khoa";
            // 
            // fld_dgcMEEmrTransferHistories
            // 
            this.fld_dgcMEEmrTransferHistories.AllowDrop = true;
            this.fld_dgcMEEmrTransferHistories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcMEEmrTransferHistories.BOSComment = "";
            this.fld_dgcMEEmrTransferHistories.BOSDataMember = "";
            this.fld_dgcMEEmrTransferHistories.BOSDataSource = "MEEmrTransferHistories";
            this.fld_dgcMEEmrTransferHistories.BOSDescription = null;
            this.fld_dgcMEEmrTransferHistories.BOSError = null;
            this.fld_dgcMEEmrTransferHistories.BOSFieldGroup = "";
            this.fld_dgcMEEmrTransferHistories.BOSFieldRelation = "";
            this.fld_dgcMEEmrTransferHistories.BOSGridType = null;
            this.fld_dgcMEEmrTransferHistories.BOSPrivilege = "";
            this.fld_dgcMEEmrTransferHistories.BOSPropertyName = "";
            this.fld_dgcMEEmrTransferHistories.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMEEmrTransferHistories.Location = new System.Drawing.Point(-1, 32);
            this.fld_dgcMEEmrTransferHistories.MainView = this.fld_dgvMEEmrTransferHistories;
            this.fld_dgcMEEmrTransferHistories.Name = "fld_dgcMEEmrTransferHistories";
            this.fld_dgcMEEmrTransferHistories.PrintReport = false;
            this.fld_dgcMEEmrTransferHistories.Screen = null;
            this.fld_dgcMEEmrTransferHistories.Size = new System.Drawing.Size(666, 188);
            this.fld_dgcMEEmrTransferHistories.TabIndex = 11;
            this.fld_dgcMEEmrTransferHistories.Tag = "DC";
            this.fld_dgcMEEmrTransferHistories.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvMEEmrTransferHistories});
            // 
            // fld_dgvMEEmrTransferHistories
            // 
            this.fld_dgvMEEmrTransferHistories.GridControl = this.fld_dgcMEEmrTransferHistories;
            this.fld_dgvMEEmrTransferHistories.Name = "fld_dgvMEEmrTransferHistories";
            this.fld_dgvMEEmrTransferHistories.PaintStyleName = "Office2003";
            // 
            // fld_btnTransfer
            // 
            this.fld_btnTransfer.Location = new System.Drawing.Point(3, 3);
            this.fld_btnTransfer.Name = "fld_btnTransfer";
            this.fld_btnTransfer.Size = new System.Drawing.Size(75, 23);
            this.fld_btnTransfer.TabIndex = 25;
            this.fld_btnTransfer.Text = "Chuyển khoa";
            this.fld_btnTransfer.Click += new System.EventHandler(this.fld_btnTransfer_Click);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.fld_tbnSaveShareEmrClose);
            this.xtraTabPage2.Controls.Add(this.fld_btnSelectEmployee);
            this.xtraTabPage2.Controls.Add(this.fld_dgcMEEmrShareHistories);
            this.xtraTabPage2.Controls.Add(this.fld_btnSelectDepartment);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(665, 220);
            this.xtraTabPage2.Text = "Danh sách chia sẻ";
            // 
            // fld_tbnSaveShareEmrClose
            // 
            this.fld_tbnSaveShareEmrClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("fld_tbnSaveShareEmrClose.ImageOptions.Image")));
            this.fld_tbnSaveShareEmrClose.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.fld_tbnSaveShareEmrClose.Location = new System.Drawing.Point(190, 3);
            this.fld_tbnSaveShareEmrClose.Name = "fld_tbnSaveShareEmrClose";
            this.fld_tbnSaveShareEmrClose.Size = new System.Drawing.Size(135, 23);
            this.fld_tbnSaveShareEmrClose.TabIndex = 104;
            this.fld_tbnSaveShareEmrClose.Text = "Lưu chia sẻ";
            this.fld_tbnSaveShareEmrClose.Visible = false;
            this.fld_tbnSaveShareEmrClose.Click += new System.EventHandler(this.fld_tbnSaveShareEmrClose_Click);
            // 
            // fld_btnSelectEmployee
            // 
            this.fld_btnSelectEmployee.Location = new System.Drawing.Point(3, 3);
            this.fld_btnSelectEmployee.Name = "fld_btnSelectEmployee";
            this.fld_btnSelectEmployee.Size = new System.Drawing.Size(100, 23);
            this.fld_btnSelectEmployee.TabIndex = 28;
            this.fld_btnSelectEmployee.Text = "Chọn nhân viên";
            this.fld_btnSelectEmployee.Click += new System.EventHandler(this.fld_btnSelectEmployee_Click);
            // 
            // fld_dgcMEEmrShareHistories
            // 
            this.fld_dgcMEEmrShareHistories.AllowDrop = true;
            this.fld_dgcMEEmrShareHistories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcMEEmrShareHistories.BOSComment = "";
            this.fld_dgcMEEmrShareHistories.BOSDataMember = "";
            this.fld_dgcMEEmrShareHistories.BOSDataSource = "MEEmrShareHistories";
            this.fld_dgcMEEmrShareHistories.BOSDescription = null;
            this.fld_dgcMEEmrShareHistories.BOSError = null;
            this.fld_dgcMEEmrShareHistories.BOSFieldGroup = "";
            this.fld_dgcMEEmrShareHistories.BOSFieldRelation = "";
            this.fld_dgcMEEmrShareHistories.BOSGridType = null;
            this.fld_dgcMEEmrShareHistories.BOSPrivilege = "";
            this.fld_dgcMEEmrShareHistories.BOSPropertyName = "";
            this.fld_dgcMEEmrShareHistories.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMEEmrShareHistories.Location = new System.Drawing.Point(0, 30);
            this.fld_dgcMEEmrShareHistories.MainView = this.gridView1;
            this.fld_dgcMEEmrShareHistories.Name = "fld_dgcMEEmrShareHistories";
            this.fld_dgcMEEmrShareHistories.PrintReport = false;
            this.fld_dgcMEEmrShareHistories.Screen = null;
            this.fld_dgcMEEmrShareHistories.Size = new System.Drawing.Size(666, 188);
            this.fld_dgcMEEmrShareHistories.TabIndex = 26;
            this.fld_dgcMEEmrShareHistories.Tag = "DC";
            this.fld_dgcMEEmrShareHistories.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcMEEmrShareHistories;
            this.gridView1.Name = "gridView1";
            this.gridView1.PaintStyleName = "Office2003";
            // 
            // fld_btnSelectDepartment
            // 
            this.fld_btnSelectDepartment.Location = new System.Drawing.Point(109, 3);
            this.fld_btnSelectDepartment.Name = "fld_btnSelectDepartment";
            this.fld_btnSelectDepartment.Size = new System.Drawing.Size(75, 23);
            this.fld_btnSelectDepartment.TabIndex = 27;
            this.fld_btnSelectDepartment.Text = "Chọn khoa";
            this.fld_btnSelectDepartment.Click += new System.EventHandler(this.fld_btnSelectDepartment_Click);
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.labelControl1);
            this.xtraTabPage3.Controls.Add(this.fld_btnRefreshMergeHistory);
            this.xtraTabPage3.Controls.Add(this.fld_dgcMEEmrMergeHistories);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(665, 220);
            this.xtraTabPage3.Text = "Lịch sử trộn";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DarkGray;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(95, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(186, 13);
            this.labelControl1.TabIndex = 31;
            this.labelControl1.Text = "Bấm làm mới để lấy danh sách mới nhất";
            // 
            // fld_btnRefreshMergeHistory
            // 
            this.fld_btnRefreshMergeHistory.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("fld_btnRefreshMergeHistory.ImageOptions.Image")));
            this.fld_btnRefreshMergeHistory.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.fld_btnRefreshMergeHistory.Location = new System.Drawing.Point(3, 3);
            this.fld_btnRefreshMergeHistory.Name = "fld_btnRefreshMergeHistory";
            this.fld_btnRefreshMergeHistory.Size = new System.Drawing.Size(86, 23);
            this.fld_btnRefreshMergeHistory.TabIndex = 29;
            this.fld_btnRefreshMergeHistory.Text = "Làm mới";
            this.fld_btnRefreshMergeHistory.Click += new System.EventHandler(this.fld_btnRefreshMergeHistory_Click);
            // 
            // fld_dgcMEEmrMergeHistories
            // 
            this.fld_dgcMEEmrMergeHistories.AllowDrop = true;
            this.fld_dgcMEEmrMergeHistories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcMEEmrMergeHistories.BOSComment = "";
            this.fld_dgcMEEmrMergeHistories.BOSDataMember = "";
            this.fld_dgcMEEmrMergeHistories.BOSDataSource = "MEEmrMergeHistories";
            this.fld_dgcMEEmrMergeHistories.BOSDescription = null;
            this.fld_dgcMEEmrMergeHistories.BOSError = null;
            this.fld_dgcMEEmrMergeHistories.BOSFieldGroup = "";
            this.fld_dgcMEEmrMergeHistories.BOSFieldRelation = "";
            this.fld_dgcMEEmrMergeHistories.BOSGridType = null;
            this.fld_dgcMEEmrMergeHistories.BOSPrivilege = "";
            this.fld_dgcMEEmrMergeHistories.BOSPropertyName = "";
            this.fld_dgcMEEmrMergeHistories.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMEEmrMergeHistories.Location = new System.Drawing.Point(-1, 31);
            this.fld_dgcMEEmrMergeHistories.MainView = this.fld_dgvMEEmrMergeHistories;
            this.fld_dgcMEEmrMergeHistories.Name = "fld_dgcMEEmrMergeHistories";
            this.fld_dgcMEEmrMergeHistories.PrintReport = false;
            this.fld_dgcMEEmrMergeHistories.Screen = null;
            this.fld_dgcMEEmrMergeHistories.Size = new System.Drawing.Size(666, 188);
            this.fld_dgcMEEmrMergeHistories.TabIndex = 26;
            this.fld_dgcMEEmrMergeHistories.Tag = "DC";
            this.fld_dgcMEEmrMergeHistories.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvMEEmrMergeHistories});
            // 
            // fld_dgvMEEmrMergeHistories
            // 
            this.fld_dgvMEEmrMergeHistories.GridControl = this.fld_dgcMEEmrMergeHistories;
            this.fld_dgvMEEmrMergeHistories.Name = "fld_dgvMEEmrMergeHistories";
            this.fld_dgvMEEmrMergeHistories.PaintStyleName = "Office2003";
            // 
            // fld_txtMEEmrNo2
            // 
            this.fld_txtMEEmrNo2.BOSComment = "";
            this.fld_txtMEEmrNo2.BOSDataMember = "MEEmrNo";
            this.fld_txtMEEmrNo2.BOSDataSource = "MEEmrs";
            this.fld_txtMEEmrNo2.BOSDescription = null;
            this.fld_txtMEEmrNo2.BOSError = null;
            this.fld_txtMEEmrNo2.BOSFieldGroup = "";
            this.fld_txtMEEmrNo2.BOSFieldRelation = "";
            this.fld_txtMEEmrNo2.BOSPrivilege = "";
            this.fld_txtMEEmrNo2.BOSPropertyName = "Text";
            this.fld_txtMEEmrNo2.EditValue = "";
            this.fld_txtMEEmrNo2.Location = new System.Drawing.Point(85, 12);
            this.fld_txtMEEmrNo2.Name = "fld_txtMEEmrNo2";
            this.fld_txtMEEmrNo2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEEmrNo2.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEEmrNo2.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEEmrNo2.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEEmrNo2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEEmrNo2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEEmrNo2.Screen = null;
            this.fld_txtMEEmrNo2.Size = new System.Drawing.Size(435, 20);
            this.fld_txtMEEmrNo2.TabIndex = 0;
            this.fld_txtMEEmrNo2.Tag = "DC";
            this.fld_txtMEEmrNo2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fld_txtMEEmrNo2_KeyUp);
            // 
            // fld_medMEEmrDesc1
            // 
            this.fld_medMEEmrDesc1.BOSComment = "";
            this.fld_medMEEmrDesc1.BOSDataMember = "MEEmrDesc";
            this.fld_medMEEmrDesc1.BOSDataSource = "MEEmrs";
            this.fld_medMEEmrDesc1.BOSDescription = null;
            this.fld_medMEEmrDesc1.BOSError = null;
            this.fld_medMEEmrDesc1.BOSFieldGroup = "";
            this.fld_medMEEmrDesc1.BOSFieldRelation = "";
            this.fld_medMEEmrDesc1.BOSPrivilege = "";
            this.fld_medMEEmrDesc1.BOSPropertyName = "Text";
            this.fld_medMEEmrDesc1.EditValue = "";
            this.fld_medMEEmrDesc1.Location = new System.Drawing.Point(85, 195);
            this.fld_medMEEmrDesc1.Name = "fld_medMEEmrDesc1";
            this.fld_medMEEmrDesc1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_medMEEmrDesc1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_medMEEmrDesc1.Properties.Appearance.Options.UseBackColor = true;
            this.fld_medMEEmrDesc1.Properties.Appearance.Options.UseForeColor = true;
            this.fld_medMEEmrDesc1.Screen = null;
            this.fld_medMEEmrDesc1.Size = new System.Drawing.Size(589, 51);
            this.fld_medMEEmrDesc1.TabIndex = 7;
            this.fld_medMEEmrDesc1.Tag = "DC";
            // 
            // fld_dteAACreatedDate
            // 
            this.fld_dteAACreatedDate.BOSComment = "";
            this.fld_dteAACreatedDate.BOSDataMember = "MEEmrCreatedDate";
            this.fld_dteAACreatedDate.BOSDataSource = "MEEmrs";
            this.fld_dteAACreatedDate.BOSDescription = null;
            this.fld_dteAACreatedDate.BOSError = null;
            this.fld_dteAACreatedDate.BOSFieldGroup = "";
            this.fld_dteAACreatedDate.BOSFieldRelation = "";
            this.fld_dteAACreatedDate.BOSPrivilege = "";
            this.fld_dteAACreatedDate.BOSPropertyName = "EditValue";
            this.fld_dteAACreatedDate.EditValue = null;
            this.fld_dteAACreatedDate.Location = new System.Drawing.Point(85, 117);
            this.fld_dteAACreatedDate.Name = "fld_dteAACreatedDate";
            this.fld_dteAACreatedDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteAACreatedDate.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteAACreatedDate.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteAACreatedDate.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteAACreatedDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteAACreatedDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteAACreatedDate.Screen = null;
            this.fld_dteAACreatedDate.Size = new System.Drawing.Size(158, 20);
            this.fld_dteAACreatedDate.TabIndex = 4;
            this.fld_dteAACreatedDate.Tag = "DC";
            // 
            // fld_dteAACreatedDate1
            // 
            this.fld_dteAACreatedDate1.BOSComment = "";
            this.fld_dteAACreatedDate1.BOSDataMember = "MEEmrEndDate";
            this.fld_dteAACreatedDate1.BOSDataSource = "MEEmrs";
            this.fld_dteAACreatedDate1.BOSDescription = null;
            this.fld_dteAACreatedDate1.BOSError = null;
            this.fld_dteAACreatedDate1.BOSFieldGroup = "";
            this.fld_dteAACreatedDate1.BOSFieldRelation = "";
            this.fld_dteAACreatedDate1.BOSPrivilege = "";
            this.fld_dteAACreatedDate1.BOSPropertyName = "EditValue";
            this.fld_dteAACreatedDate1.EditValue = null;
            this.fld_dteAACreatedDate1.Enabled = false;
            this.fld_dteAACreatedDate1.Location = new System.Drawing.Point(318, 117);
            this.fld_dteAACreatedDate1.Name = "fld_dteAACreatedDate1";
            this.fld_dteAACreatedDate1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteAACreatedDate1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteAACreatedDate1.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteAACreatedDate1.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteAACreatedDate1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteAACreatedDate1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteAACreatedDate1.Screen = null;
            this.fld_dteAACreatedDate1.Size = new System.Drawing.Size(138, 20);
            this.fld_dteAACreatedDate1.TabIndex = 5;
            this.fld_dteAACreatedDate1.Tag = "DC";
            // 
            // fld_lblLabel2
            // 
            this.fld_lblLabel2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel2.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel2.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel2.BOSComment = "";
            this.fld_lblLabel2.BOSDataMember = "";
            this.fld_lblLabel2.BOSDataSource = "";
            this.fld_lblLabel2.BOSDescription = null;
            this.fld_lblLabel2.BOSError = null;
            this.fld_lblLabel2.BOSFieldGroup = "";
            this.fld_lblLabel2.BOSFieldRelation = "";
            this.fld_lblLabel2.BOSPrivilege = "";
            this.fld_lblLabel2.BOSPropertyName = "";
            this.fld_lblLabel2.Location = new System.Drawing.Point(12, 16);
            this.fld_lblLabel2.Name = "fld_lblLabel2";
            this.fld_lblLabel2.Screen = null;
            this.fld_lblLabel2.Size = new System.Drawing.Size(56, 13);
            this.fld_lblLabel2.TabIndex = 9;
            this.fld_lblLabel2.Tag = "";
            this.fld_lblLabel2.Text = "Mã bệnh án";
            // 
            // fld_lblLabel3
            // 
            this.fld_lblLabel3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel3.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel3.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel3.BOSComment = "";
            this.fld_lblLabel3.BOSDataMember = "";
            this.fld_lblLabel3.BOSDataSource = "";
            this.fld_lblLabel3.BOSDescription = null;
            this.fld_lblLabel3.BOSError = null;
            this.fld_lblLabel3.BOSFieldGroup = "";
            this.fld_lblLabel3.BOSFieldRelation = "";
            this.fld_lblLabel3.BOSPrivilege = "";
            this.fld_lblLabel3.BOSPropertyName = "";
            this.fld_lblLabel3.Location = new System.Drawing.Point(11, 39);
            this.fld_lblLabel3.Name = "fld_lblLabel3";
            this.fld_lblLabel3.Screen = null;
            this.fld_lblLabel3.Size = new System.Drawing.Size(51, 13);
            this.fld_lblLabel3.TabIndex = 10;
            this.fld_lblLabel3.Tag = "";
            this.fld_lblLabel3.Text = "Bệnh nhân";
            // 
            // fld_lblLabel4
            // 
            this.fld_lblLabel4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel4.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel4.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel4.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel4.BOSComment = "";
            this.fld_lblLabel4.BOSDataMember = "";
            this.fld_lblLabel4.BOSDataSource = "";
            this.fld_lblLabel4.BOSDescription = null;
            this.fld_lblLabel4.BOSError = null;
            this.fld_lblLabel4.BOSFieldGroup = "";
            this.fld_lblLabel4.BOSFieldRelation = "";
            this.fld_lblLabel4.BOSPrivilege = "";
            this.fld_lblLabel4.BOSPropertyName = "";
            this.fld_lblLabel4.Location = new System.Drawing.Point(11, 120);
            this.fld_lblLabel4.Name = "fld_lblLabel4";
            this.fld_lblLabel4.Screen = null;
            this.fld_lblLabel4.Size = new System.Drawing.Size(44, 13);
            this.fld_lblLabel4.TabIndex = 11;
            this.fld_lblLabel4.Tag = "";
            this.fld_lblLabel4.Text = "Ngày tạo";
            // 
            // fld_lblLabel5
            // 
            this.fld_lblLabel5.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel5.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel5.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel5.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel5.BOSComment = "";
            this.fld_lblLabel5.BOSDataMember = "";
            this.fld_lblLabel5.BOSDataSource = "";
            this.fld_lblLabel5.BOSDescription = null;
            this.fld_lblLabel5.BOSError = null;
            this.fld_lblLabel5.BOSFieldGroup = "";
            this.fld_lblLabel5.BOSFieldRelation = "";
            this.fld_lblLabel5.BOSPrivilege = "";
            this.fld_lblLabel5.BOSPropertyName = "";
            this.fld_lblLabel5.Location = new System.Drawing.Point(251, 121);
            this.fld_lblLabel5.Name = "fld_lblLabel5";
            this.fld_lblLabel5.Screen = null;
            this.fld_lblLabel5.Size = new System.Drawing.Size(52, 13);
            this.fld_lblLabel5.TabIndex = 12;
            this.fld_lblLabel5.Tag = "";
            this.fld_lblLabel5.Text = "Ngày đóng";
            // 
            // fld_lblLabel6
            // 
            this.fld_lblLabel6.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel6.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel6.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel6.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel6.BOSComment = "";
            this.fld_lblLabel6.BOSDataMember = "";
            this.fld_lblLabel6.BOSDataSource = "";
            this.fld_lblLabel6.BOSDescription = null;
            this.fld_lblLabel6.BOSError = null;
            this.fld_lblLabel6.BOSFieldGroup = "";
            this.fld_lblLabel6.BOSFieldRelation = "";
            this.fld_lblLabel6.BOSPrivilege = "";
            this.fld_lblLabel6.BOSPropertyName = "";
            this.fld_lblLabel6.Location = new System.Drawing.Point(12, 197);
            this.fld_lblLabel6.Name = "fld_lblLabel6";
            this.fld_lblLabel6.Screen = null;
            this.fld_lblLabel6.Size = new System.Drawing.Size(35, 13);
            this.fld_lblLabel6.TabIndex = 13;
            this.fld_lblLabel6.Tag = "";
            this.fld_lblLabel6.Text = "Ghi chú";
            // 
            // fld_lblLabel7
            // 
            this.fld_lblLabel7.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel7.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel7.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel7.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel7.BOSComment = "";
            this.fld_lblLabel7.BOSDataMember = "";
            this.fld_lblLabel7.BOSDataSource = "";
            this.fld_lblLabel7.BOSDescription = null;
            this.fld_lblLabel7.BOSError = null;
            this.fld_lblLabel7.BOSFieldGroup = "";
            this.fld_lblLabel7.BOSFieldRelation = "";
            this.fld_lblLabel7.BOSPrivilege = "";
            this.fld_lblLabel7.BOSPropertyName = "";
            this.fld_lblLabel7.Location = new System.Drawing.Point(461, 95);
            this.fld_lblLabel7.Name = "fld_lblLabel7";
            this.fld_lblLabel7.Screen = null;
            this.fld_lblLabel7.Size = new System.Drawing.Size(49, 13);
            this.fld_lblLabel7.TabIndex = 14;
            this.fld_lblLabel7.Tag = "";
            this.fld_lblLabel7.Text = "Trạng thái";
            // 
            // fld_lkeLookupEdit
            // 
            this.fld_lkeLookupEdit.BOSAllowAddNew = false;
            this.fld_lkeLookupEdit.BOSAllowDummy = false;
            this.fld_lkeLookupEdit.BOSComment = "";
            this.fld_lkeLookupEdit.BOSDataMember = "MEEmrStatus";
            this.fld_lkeLookupEdit.BOSDataSource = "MEEmrs";
            this.fld_lkeLookupEdit.BOSDescription = null;
            this.fld_lkeLookupEdit.BOSDummyText = null;
            this.fld_lkeLookupEdit.BOSError = null;
            this.fld_lkeLookupEdit.BOSFieldGroup = "";
            this.fld_lkeLookupEdit.BOSFieldParent = "";
            this.fld_lkeLookupEdit.BOSFieldRelation = "";
            this.fld_lkeLookupEdit.BOSPrivilege = "";
            this.fld_lkeLookupEdit.BOSPropertyName = "EditValue";
            this.fld_lkeLookupEdit.BOSSelectType = "";
            this.fld_lkeLookupEdit.BOSSelectTypeValue = "";
            this.fld_lkeLookupEdit.CurrentDisplayText = null;
            this.fld_lkeLookupEdit.Enabled = false;
            this.fld_lkeLookupEdit.Location = new System.Drawing.Point(516, 91);
            this.fld_lkeLookupEdit.Name = "fld_lkeLookupEdit";
            this.fld_lkeLookupEdit.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeLookupEdit.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeLookupEdit.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeLookupEdit.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeLookupEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeLookupEdit.Properties.NullText = "";
            this.fld_lkeLookupEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeLookupEdit.Screen = null;
            this.fld_lkeLookupEdit.Size = new System.Drawing.Size(158, 20);
            this.fld_lkeLookupEdit.TabIndex = 3;
            this.fld_lkeLookupEdit.Tag = "DC";
            // 
            // fld_tbnSearchPatientFromHis
            // 
            this.fld_tbnSearchPatientFromHis.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("fld_tbnSearchPatientFromHis.ImageOptions.Image")));
            this.fld_tbnSearchPatientFromHis.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.fld_tbnSearchPatientFromHis.Location = new System.Drawing.Point(526, 10);
            this.fld_tbnSearchPatientFromHis.Name = "fld_tbnSearchPatientFromHis";
            this.fld_tbnSearchPatientFromHis.Size = new System.Drawing.Size(136, 23);
            this.fld_tbnSearchPatientFromHis.TabIndex = 1;
            this.fld_tbnSearchPatientFromHis.Text = "Tìm bệnh án từ HIS";
            this.fld_tbnSearchPatientFromHis.Click += new System.EventHandler(this.fld_tbnSearchPatientFromHis_Click);
            // 
            // fld_lkeFK_MEEmrTypeID
            // 
            this.fld_lkeFK_MEEmrTypeID.BOSAllowAddNew = false;
            this.fld_lkeFK_MEEmrTypeID.BOSAllowDummy = false;
            this.fld_lkeFK_MEEmrTypeID.BOSComment = "";
            this.fld_lkeFK_MEEmrTypeID.BOSDataMember = "FK_MEEmrTypeID";
            this.fld_lkeFK_MEEmrTypeID.BOSDataSource = "MEEmrs";
            this.fld_lkeFK_MEEmrTypeID.BOSDescription = null;
            this.fld_lkeFK_MEEmrTypeID.BOSDummyText = null;
            this.fld_lkeFK_MEEmrTypeID.BOSError = null;
            this.fld_lkeFK_MEEmrTypeID.BOSFieldGroup = "";
            this.fld_lkeFK_MEEmrTypeID.BOSFieldParent = "";
            this.fld_lkeFK_MEEmrTypeID.BOSFieldRelation = "";
            this.fld_lkeFK_MEEmrTypeID.BOSPrivilege = "";
            this.fld_lkeFK_MEEmrTypeID.BOSPropertyName = "EditValue";
            this.fld_lkeFK_MEEmrTypeID.BOSSelectType = "";
            this.fld_lkeFK_MEEmrTypeID.BOSSelectTypeValue = "";
            this.fld_lkeFK_MEEmrTypeID.CurrentDisplayText = null;
            this.fld_lkeFK_MEEmrTypeID.Location = new System.Drawing.Point(85, 91);
            this.fld_lkeFK_MEEmrTypeID.Name = "fld_lkeFK_MEEmrTypeID";
            this.fld_lkeFK_MEEmrTypeID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeFK_MEEmrTypeID.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeFK_MEEmrTypeID.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeFK_MEEmrTypeID.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeFK_MEEmrTypeID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_MEEmrTypeID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MEEmrTypeNo", "Mã loại"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MEEmrTypeName", "Tên loại")});
            this.fld_lkeFK_MEEmrTypeID.Properties.DisplayMember = "MEEmrTypeName";
            this.fld_lkeFK_MEEmrTypeID.Properties.NullText = "";
            this.fld_lkeFK_MEEmrTypeID.Properties.PopupWidth = 40;
            this.fld_lkeFK_MEEmrTypeID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeFK_MEEmrTypeID.Properties.ValueMember = "MEEmrTypeID";
            this.fld_lkeFK_MEEmrTypeID.Screen = null;
            this.fld_lkeFK_MEEmrTypeID.Size = new System.Drawing.Size(159, 20);
            this.fld_lkeFK_MEEmrTypeID.TabIndex = 5;
            this.fld_lkeFK_MEEmrTypeID.Tag = "DC";
            this.fld_lkeFK_MEEmrTypeID.QueryCloseUp += new System.ComponentModel.CancelEventHandler(this.fld_lkeFK_MEEmrTypeID_QueryCloseUp);
            this.fld_lkeFK_MEEmrTypeID.EditValueChanged += new System.EventHandler(this.fld_lkeFK_MEEmrTypeID_EditValueChanged);
            // 
            // bosLabel1
            // 
            this.bosLabel1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel1.Appearance.Options.UseBackColor = true;
            this.bosLabel1.Appearance.Options.UseForeColor = true;
            this.bosLabel1.BOSComment = "";
            this.bosLabel1.BOSDataMember = "";
            this.bosLabel1.BOSDataSource = "";
            this.bosLabel1.BOSDescription = null;
            this.bosLabel1.BOSError = null;
            this.bosLabel1.BOSFieldGroup = "";
            this.bosLabel1.BOSFieldRelation = "";
            this.bosLabel1.BOSPrivilege = "";
            this.bosLabel1.BOSPropertyName = "";
            this.bosLabel1.Location = new System.Drawing.Point(11, 94);
            this.bosLabel1.Name = "bosLabel1";
            this.bosLabel1.Screen = null;
            this.bosLabel1.Size = new System.Drawing.Size(61, 13);
            this.bosLabel1.TabIndex = 21;
            this.bosLabel1.Tag = "";
            this.bosLabel1.Text = "Loại bệnh án";
            // 
            // bosLabel2
            // 
            this.bosLabel2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel2.Appearance.Options.UseBackColor = true;
            this.bosLabel2.Appearance.Options.UseForeColor = true;
            this.bosLabel2.BOSComment = "";
            this.bosLabel2.BOSDataMember = "";
            this.bosLabel2.BOSDataSource = "";
            this.bosLabel2.BOSDescription = null;
            this.bosLabel2.BOSError = null;
            this.bosLabel2.BOSFieldGroup = "";
            this.bosLabel2.BOSFieldRelation = "";
            this.bosLabel2.BOSPrivilege = "";
            this.bosLabel2.BOSPropertyName = "";
            this.bosLabel2.Location = new System.Drawing.Point(12, 172);
            this.bosLabel2.Name = "bosLabel2";
            this.bosLabel2.Screen = null;
            this.bosLabel2.Size = new System.Drawing.Size(62, 13);
            this.bosLabel2.TabIndex = 22;
            this.bosLabel2.Tag = "";
            this.bosLabel2.Text = "Khoa quản lý";
            // 
            // bosLookupEdit1
            // 
            this.bosLookupEdit1.BOSAllowAddNew = false;
            this.bosLookupEdit1.BOSAllowDummy = true;
            this.bosLookupEdit1.BOSComment = "";
            this.bosLookupEdit1.BOSDataMember = "FK_HRDepartmentID";
            this.bosLookupEdit1.BOSDataSource = "MEEmrs";
            this.bosLookupEdit1.BOSDescription = null;
            this.bosLookupEdit1.BOSDummyText = null;
            this.bosLookupEdit1.BOSError = null;
            this.bosLookupEdit1.BOSFieldGroup = "";
            this.bosLookupEdit1.BOSFieldParent = "";
            this.bosLookupEdit1.BOSFieldRelation = "";
            this.bosLookupEdit1.BOSPrivilege = "";
            this.bosLookupEdit1.BOSPropertyName = "EditValue";
            this.bosLookupEdit1.BOSSelectType = "";
            this.bosLookupEdit1.BOSSelectTypeValue = "";
            this.bosLookupEdit1.CurrentDisplayText = null;
            this.bosLookupEdit1.Enabled = false;
            this.bosLookupEdit1.Location = new System.Drawing.Point(85, 169);
            this.bosLookupEdit1.Name = "bosLookupEdit1";
            this.bosLookupEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLookupEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLookupEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.bosLookupEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.bosLookupEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bosLookupEdit1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRDepartmentNo", "Mã khoa", 20, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRDepartmentName", "Tên khoa")});
            this.bosLookupEdit1.Properties.DisplayMember = "HRDepartmentName";
            this.bosLookupEdit1.Properties.NullText = "";
            this.bosLookupEdit1.Properties.PopupWidth = 40;
            this.bosLookupEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.bosLookupEdit1.Properties.ValueMember = "HRDepartmentID";
            this.bosLookupEdit1.Screen = null;
            this.bosLookupEdit1.Size = new System.Drawing.Size(157, 20);
            this.bosLookupEdit1.TabIndex = 6;
            this.bosLookupEdit1.Tag = "DC";
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
            this.panelControl1.Controls.Add(this.bosLabel11);
            this.panelControl1.Controls.Add(this.fld_txtMEEmrPatientAddr);
            this.panelControl1.Controls.Add(this.bosLabel10);
            this.panelControl1.Controls.Add(this.fld_txtMEEmrArchiveNo);
            this.panelControl1.Controls.Add(this.fld_lkeFK_HREmployeeClosedID);
            this.panelControl1.Controls.Add(this.bosLabel9);
            this.panelControl1.Controls.Add(this.bosLabel8);
            this.panelControl1.Controls.Add(this.fld_txtMEEmrBedNo);
            this.panelControl1.Controls.Add(this.bosLabel7);
            this.panelControl1.Controls.Add(this.fld_txtMEEmrRoomNo);
            this.panelControl1.Controls.Add(this.bosLabel6);
            this.panelControl1.Controls.Add(this.fld_dpkMEEmrDateOut);
            this.panelControl1.Controls.Add(this.bosLabel5);
            this.panelControl1.Controls.Add(this.fld_dpkMEEmrDateIn);
            this.panelControl1.Controls.Add(this.fld_lkeFK_HREmployeeCreatedID);
            this.panelControl1.Controls.Add(this.bosLabel4);
            this.panelControl1.Controls.Add(this.fld_lkeMEEmrTypeProfile);
            this.panelControl1.Controls.Add(this.bosLabel3);
            this.panelControl1.Controls.Add(this.bosTextBox2);
            this.panelControl1.Controls.Add(this.fld_txtMEPatientNo);
            this.panelControl1.Controls.Add(this.fld_tbnSearchPatientLocal);
            this.panelControl1.Controls.Add(tacTransferAndShare);
            this.panelControl1.Controls.Add(this.bosLookupEdit1);
            this.panelControl1.Controls.Add(this.fld_lkeLookupEdit);
            this.panelControl1.Controls.Add(this.bosLabel2);
            this.panelControl1.Controls.Add(this.fld_lblLabel7);
            this.panelControl1.Controls.Add(this.bosLabel1);
            this.panelControl1.Controls.Add(this.fld_lblLabel6);
            this.panelControl1.Controls.Add(this.fld_lkeFK_MEEmrTypeID);
            this.panelControl1.Controls.Add(this.fld_lblLabel5);
            this.panelControl1.Controls.Add(this.fld_tbnSearchPatientFromHis);
            this.panelControl1.Controls.Add(this.fld_lblLabel4);
            this.panelControl1.Controls.Add(this.fld_txtMEEmrNo2);
            this.panelControl1.Controls.Add(this.fld_lblLabel3);
            this.panelControl1.Controls.Add(this.fld_medMEEmrDesc1);
            this.panelControl1.Controls.Add(this.fld_lblLabel2);
            this.panelControl1.Controls.Add(this.fld_dteAACreatedDate1);
            this.panelControl1.Controls.Add(this.fld_dteAACreatedDate);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Screen = null;
            this.panelControl1.Size = new System.Drawing.Size(681, 530);
            this.panelControl1.TabIndex = 0;
            this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // bosLabel11
            // 
            this.bosLabel11.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel11.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel11.Appearance.Options.UseBackColor = true;
            this.bosLabel11.Appearance.Options.UseForeColor = true;
            this.bosLabel11.BOSComment = "";
            this.bosLabel11.BOSDataMember = "";
            this.bosLabel11.BOSDataSource = "";
            this.bosLabel11.BOSDescription = null;
            this.bosLabel11.BOSError = null;
            this.bosLabel11.BOSFieldGroup = "";
            this.bosLabel11.BOSFieldRelation = "";
            this.bosLabel11.BOSPrivilege = "";
            this.bosLabel11.BOSPropertyName = "";
            this.bosLabel11.Location = new System.Drawing.Point(12, 255);
            this.bosLabel11.Name = "bosLabel11";
            this.bosLabel11.Screen = null;
            this.bosLabel11.Size = new System.Drawing.Size(32, 13);
            this.bosLabel11.TabIndex = 103;
            this.bosLabel11.Tag = "";
            this.bosLabel11.Text = "Địa chỉ";
            // 
            // fld_txtMEEmrPatientAddr
            // 
            this.fld_txtMEEmrPatientAddr.BOSComment = "";
            this.fld_txtMEEmrPatientAddr.BOSDataMember = "MEEmrPatientAddr";
            this.fld_txtMEEmrPatientAddr.BOSDataSource = "MEEmrs";
            this.fld_txtMEEmrPatientAddr.BOSDescription = null;
            this.fld_txtMEEmrPatientAddr.BOSError = null;
            this.fld_txtMEEmrPatientAddr.BOSFieldGroup = "";
            this.fld_txtMEEmrPatientAddr.BOSFieldRelation = "";
            this.fld_txtMEEmrPatientAddr.BOSPrivilege = "";
            this.fld_txtMEEmrPatientAddr.BOSPropertyName = "Text";
            this.fld_txtMEEmrPatientAddr.EditValue = "";
            this.fld_txtMEEmrPatientAddr.Enabled = false;
            this.fld_txtMEEmrPatientAddr.Location = new System.Drawing.Point(85, 252);
            this.fld_txtMEEmrPatientAddr.Name = "fld_txtMEEmrPatientAddr";
            this.fld_txtMEEmrPatientAddr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEEmrPatientAddr.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEEmrPatientAddr.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEEmrPatientAddr.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEEmrPatientAddr.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEEmrPatientAddr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEEmrPatientAddr.Screen = null;
            this.fld_txtMEEmrPatientAddr.Size = new System.Drawing.Size(589, 20);
            this.fld_txtMEEmrPatientAddr.TabIndex = 102;
            this.fld_txtMEEmrPatientAddr.Tag = "DC";
            // 
            // bosLabel10
            // 
            this.bosLabel10.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel10.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel10.Appearance.Options.UseBackColor = true;
            this.bosLabel10.Appearance.Options.UseForeColor = true;
            this.bosLabel10.BOSComment = "";
            this.bosLabel10.BOSDataMember = "";
            this.bosLabel10.BOSDataSource = "";
            this.bosLabel10.BOSDescription = null;
            this.bosLabel10.BOSError = null;
            this.bosLabel10.BOSFieldGroup = "";
            this.bosLabel10.BOSFieldRelation = "";
            this.bosLabel10.BOSPrivilege = "";
            this.bosLabel10.BOSPropertyName = "";
            this.bosLabel10.Location = new System.Drawing.Point(12, 70);
            this.bosLabel10.Name = "bosLabel10";
            this.bosLabel10.Screen = null;
            this.bosLabel10.Size = new System.Drawing.Size(48, 13);
            this.bosLabel10.TabIndex = 101;
            this.bosLabel10.Tag = "";
            this.bosLabel10.Text = "Số lưu trữ";
            // 
            // fld_txtMEEmrArchiveNo
            // 
            this.fld_txtMEEmrArchiveNo.BOSComment = "";
            this.fld_txtMEEmrArchiveNo.BOSDataMember = "MEEmrArchiveNo";
            this.fld_txtMEEmrArchiveNo.BOSDataSource = "MEEmrs";
            this.fld_txtMEEmrArchiveNo.BOSDescription = null;
            this.fld_txtMEEmrArchiveNo.BOSError = null;
            this.fld_txtMEEmrArchiveNo.BOSFieldGroup = "";
            this.fld_txtMEEmrArchiveNo.BOSFieldRelation = "";
            this.fld_txtMEEmrArchiveNo.BOSPrivilege = "";
            this.fld_txtMEEmrArchiveNo.BOSPropertyName = "Text";
            this.fld_txtMEEmrArchiveNo.EditValue = "";
            this.fld_txtMEEmrArchiveNo.Enabled = false;
            this.fld_txtMEEmrArchiveNo.Location = new System.Drawing.Point(85, 67);
            this.fld_txtMEEmrArchiveNo.Name = "fld_txtMEEmrArchiveNo";
            this.fld_txtMEEmrArchiveNo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEEmrArchiveNo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEEmrArchiveNo.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEEmrArchiveNo.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEEmrArchiveNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEEmrArchiveNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEEmrArchiveNo.Screen = null;
            this.fld_txtMEEmrArchiveNo.Size = new System.Drawing.Size(158, 20);
            this.fld_txtMEEmrArchiveNo.TabIndex = 100;
            this.fld_txtMEEmrArchiveNo.Tag = "DC";
            // 
            // fld_lkeFK_HREmployeeClosedID
            // 
            this.fld_lkeFK_HREmployeeClosedID.BOSAllowAddNew = false;
            this.fld_lkeFK_HREmployeeClosedID.BOSAllowDummy = true;
            this.fld_lkeFK_HREmployeeClosedID.BOSComment = "";
            this.fld_lkeFK_HREmployeeClosedID.BOSDataMember = "FK_HREmployeeClosedID";
            this.fld_lkeFK_HREmployeeClosedID.BOSDataSource = "MEEmrs";
            this.fld_lkeFK_HREmployeeClosedID.BOSDescription = null;
            this.fld_lkeFK_HREmployeeClosedID.BOSDummyText = null;
            this.fld_lkeFK_HREmployeeClosedID.BOSError = null;
            this.fld_lkeFK_HREmployeeClosedID.BOSFieldGroup = "";
            this.fld_lkeFK_HREmployeeClosedID.BOSFieldParent = "";
            this.fld_lkeFK_HREmployeeClosedID.BOSFieldRelation = "";
            this.fld_lkeFK_HREmployeeClosedID.BOSPrivilege = "";
            this.fld_lkeFK_HREmployeeClosedID.BOSPropertyName = "EditValue";
            this.fld_lkeFK_HREmployeeClosedID.BOSSelectType = "";
            this.fld_lkeFK_HREmployeeClosedID.BOSSelectTypeValue = "";
            this.fld_lkeFK_HREmployeeClosedID.CurrentDisplayText = null;
            this.fld_lkeFK_HREmployeeClosedID.Enabled = false;
            this.fld_lkeFK_HREmployeeClosedID.Location = new System.Drawing.Point(318, 142);
            this.fld_lkeFK_HREmployeeClosedID.Name = "fld_lkeFK_HREmployeeClosedID";
            this.fld_lkeFK_HREmployeeClosedID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeFK_HREmployeeClosedID.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeFK_HREmployeeClosedID.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeFK_HREmployeeClosedID.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeFK_HREmployeeClosedID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_HREmployeeClosedID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRDepartmentNo", "Mã khoa", 20, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRDepartmentName", "Tên khoa")});
            this.fld_lkeFK_HREmployeeClosedID.Properties.DisplayMember = "HREmployeeName";
            this.fld_lkeFK_HREmployeeClosedID.Properties.NullText = "";
            this.fld_lkeFK_HREmployeeClosedID.Properties.PopupWidth = 40;
            this.fld_lkeFK_HREmployeeClosedID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeFK_HREmployeeClosedID.Properties.ValueMember = "HREmployeeID";
            this.fld_lkeFK_HREmployeeClosedID.Screen = null;
            this.fld_lkeFK_HREmployeeClosedID.Size = new System.Drawing.Size(138, 20);
            this.fld_lkeFK_HREmployeeClosedID.TabIndex = 98;
            this.fld_lkeFK_HREmployeeClosedID.Tag = "DC";
            // 
            // bosLabel9
            // 
            this.bosLabel9.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel9.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel9.Appearance.Options.UseBackColor = true;
            this.bosLabel9.Appearance.Options.UseForeColor = true;
            this.bosLabel9.BOSComment = "";
            this.bosLabel9.BOSDataMember = "";
            this.bosLabel9.BOSDataSource = "";
            this.bosLabel9.BOSDescription = null;
            this.bosLabel9.BOSError = null;
            this.bosLabel9.BOSFieldGroup = "";
            this.bosLabel9.BOSFieldRelation = "";
            this.bosLabel9.BOSPrivilege = "";
            this.bosLabel9.BOSPropertyName = "";
            this.bosLabel9.Location = new System.Drawing.Point(251, 145);
            this.bosLabel9.Name = "bosLabel9";
            this.bosLabel9.Screen = null;
            this.bosLabel9.Size = new System.Drawing.Size(55, 13);
            this.bosLabel9.TabIndex = 99;
            this.bosLabel9.Tag = "";
            this.bosLabel9.Text = "Người đóng";
            // 
            // bosLabel8
            // 
            this.bosLabel8.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel8.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel8.Appearance.Options.UseBackColor = true;
            this.bosLabel8.Appearance.Options.UseForeColor = true;
            this.bosLabel8.BOSComment = "";
            this.bosLabel8.BOSDataMember = "";
            this.bosLabel8.BOSDataSource = "";
            this.bosLabel8.BOSDescription = null;
            this.bosLabel8.BOSError = null;
            this.bosLabel8.BOSFieldGroup = "";
            this.bosLabel8.BOSFieldRelation = "";
            this.bosLabel8.BOSPrivilege = "";
            this.bosLabel8.BOSPropertyName = "";
            this.bosLabel8.Location = new System.Drawing.Point(462, 171);
            this.bosLabel8.Name = "bosLabel8";
            this.bosLabel8.Screen = null;
            this.bosLabel8.Size = new System.Drawing.Size(34, 13);
            this.bosLabel8.TabIndex = 97;
            this.bosLabel8.Tag = "";
            this.bosLabel8.Text = "Giường";
            // 
            // fld_txtMEEmrBedNo
            // 
            this.fld_txtMEEmrBedNo.BOSComment = "";
            this.fld_txtMEEmrBedNo.BOSDataMember = "MEEmrBedNo";
            this.fld_txtMEEmrBedNo.BOSDataSource = "MEEmrs";
            this.fld_txtMEEmrBedNo.BOSDescription = null;
            this.fld_txtMEEmrBedNo.BOSError = null;
            this.fld_txtMEEmrBedNo.BOSFieldGroup = "";
            this.fld_txtMEEmrBedNo.BOSFieldRelation = "";
            this.fld_txtMEEmrBedNo.BOSPrivilege = "";
            this.fld_txtMEEmrBedNo.BOSPropertyName = "Text";
            this.fld_txtMEEmrBedNo.EditValue = "";
            this.fld_txtMEEmrBedNo.Enabled = false;
            this.fld_txtMEEmrBedNo.Location = new System.Drawing.Point(515, 168);
            this.fld_txtMEEmrBedNo.Name = "fld_txtMEEmrBedNo";
            this.fld_txtMEEmrBedNo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEEmrBedNo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEEmrBedNo.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEEmrBedNo.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEEmrBedNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEEmrBedNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEEmrBedNo.Screen = null;
            this.fld_txtMEEmrBedNo.Size = new System.Drawing.Size(159, 20);
            this.fld_txtMEEmrBedNo.TabIndex = 96;
            this.fld_txtMEEmrBedNo.Tag = "DC";
            // 
            // bosLabel7
            // 
            this.bosLabel7.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel7.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel7.Appearance.Options.UseBackColor = true;
            this.bosLabel7.Appearance.Options.UseForeColor = true;
            this.bosLabel7.BOSComment = "";
            this.bosLabel7.BOSDataMember = "";
            this.bosLabel7.BOSDataSource = "";
            this.bosLabel7.BOSDescription = null;
            this.bosLabel7.BOSError = null;
            this.bosLabel7.BOSFieldGroup = "";
            this.bosLabel7.BOSFieldRelation = "";
            this.bosLabel7.BOSPrivilege = "";
            this.bosLabel7.BOSPropertyName = "";
            this.bosLabel7.Location = new System.Drawing.Point(251, 171);
            this.bosLabel7.Name = "bosLabel7";
            this.bosLabel7.Screen = null;
            this.bosLabel7.Size = new System.Drawing.Size(30, 13);
            this.bosLabel7.TabIndex = 95;
            this.bosLabel7.Tag = "";
            this.bosLabel7.Text = "Phòng";
            // 
            // fld_txtMEEmrRoomNo
            // 
            this.fld_txtMEEmrRoomNo.BOSComment = "";
            this.fld_txtMEEmrRoomNo.BOSDataMember = "MEEmrRoomNo";
            this.fld_txtMEEmrRoomNo.BOSDataSource = "MEEmrs";
            this.fld_txtMEEmrRoomNo.BOSDescription = null;
            this.fld_txtMEEmrRoomNo.BOSError = null;
            this.fld_txtMEEmrRoomNo.BOSFieldGroup = "";
            this.fld_txtMEEmrRoomNo.BOSFieldRelation = "";
            this.fld_txtMEEmrRoomNo.BOSPrivilege = "";
            this.fld_txtMEEmrRoomNo.BOSPropertyName = "Text";
            this.fld_txtMEEmrRoomNo.EditValue = "";
            this.fld_txtMEEmrRoomNo.Enabled = false;
            this.fld_txtMEEmrRoomNo.Location = new System.Drawing.Point(318, 168);
            this.fld_txtMEEmrRoomNo.Name = "fld_txtMEEmrRoomNo";
            this.fld_txtMEEmrRoomNo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEEmrRoomNo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEEmrRoomNo.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEEmrRoomNo.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEEmrRoomNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEEmrRoomNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEEmrRoomNo.Screen = null;
            this.fld_txtMEEmrRoomNo.Size = new System.Drawing.Size(138, 20);
            this.fld_txtMEEmrRoomNo.TabIndex = 94;
            this.fld_txtMEEmrRoomNo.Tag = "DC";
            // 
            // bosLabel6
            // 
            this.bosLabel6.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel6.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel6.Appearance.Options.UseBackColor = true;
            this.bosLabel6.Appearance.Options.UseForeColor = true;
            this.bosLabel6.BOSComment = "";
            this.bosLabel6.BOSDataMember = "";
            this.bosLabel6.BOSDataSource = "";
            this.bosLabel6.BOSDescription = null;
            this.bosLabel6.BOSError = null;
            this.bosLabel6.BOSFieldGroup = "";
            this.bosLabel6.BOSFieldRelation = "";
            this.bosLabel6.BOSPrivilege = "";
            this.bosLabel6.BOSPropertyName = "";
            this.bosLabel6.Location = new System.Drawing.Point(462, 145);
            this.bosLabel6.Name = "bosLabel6";
            this.bosLabel6.Screen = null;
            this.bosLabel6.Size = new System.Drawing.Size(36, 13);
            this.bosLabel6.TabIndex = 93;
            this.bosLabel6.Tag = "";
            this.bosLabel6.Text = "Ra viện";
            // 
            // fld_dpkMEEmrDateOut
            // 
            this.fld_dpkMEEmrDateOut.BOSComment = "";
            this.fld_dpkMEEmrDateOut.BOSDataMember = "MEEmrDateOut";
            this.fld_dpkMEEmrDateOut.BOSDataSource = "MEEmrs";
            this.fld_dpkMEEmrDateOut.BOSDescription = null;
            this.fld_dpkMEEmrDateOut.BOSError = null;
            this.fld_dpkMEEmrDateOut.BOSFieldGroup = "";
            this.fld_dpkMEEmrDateOut.BOSFieldRelation = "";
            this.fld_dpkMEEmrDateOut.BOSPrivilege = "";
            this.fld_dpkMEEmrDateOut.BOSPropertyName = "EditValue";
            this.fld_dpkMEEmrDateOut.EditValue = null;
            this.fld_dpkMEEmrDateOut.Enabled = false;
            this.fld_dpkMEEmrDateOut.Location = new System.Drawing.Point(516, 142);
            this.fld_dpkMEEmrDateOut.Name = "fld_dpkMEEmrDateOut";
            this.fld_dpkMEEmrDateOut.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dpkMEEmrDateOut.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dpkMEEmrDateOut.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dpkMEEmrDateOut.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dpkMEEmrDateOut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dpkMEEmrDateOut.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dpkMEEmrDateOut.Screen = null;
            this.fld_dpkMEEmrDateOut.Size = new System.Drawing.Size(158, 20);
            this.fld_dpkMEEmrDateOut.TabIndex = 92;
            this.fld_dpkMEEmrDateOut.Tag = "DC";
            // 
            // bosLabel5
            // 
            this.bosLabel5.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel5.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel5.Appearance.Options.UseBackColor = true;
            this.bosLabel5.Appearance.Options.UseForeColor = true;
            this.bosLabel5.BOSComment = "";
            this.bosLabel5.BOSDataMember = "";
            this.bosLabel5.BOSDataSource = "";
            this.bosLabel5.BOSDescription = null;
            this.bosLabel5.BOSError = null;
            this.bosLabel5.BOSFieldGroup = "";
            this.bosLabel5.BOSFieldRelation = "";
            this.bosLabel5.BOSPrivilege = "";
            this.bosLabel5.BOSPropertyName = "";
            this.bosLabel5.Location = new System.Drawing.Point(462, 121);
            this.bosLabel5.Name = "bosLabel5";
            this.bosLabel5.Screen = null;
            this.bosLabel5.Size = new System.Drawing.Size(41, 13);
            this.bosLabel5.TabIndex = 91;
            this.bosLabel5.Tag = "";
            this.bosLabel5.Text = "Vào viện";
            // 
            // fld_dpkMEEmrDateIn
            // 
            this.fld_dpkMEEmrDateIn.BOSComment = "";
            this.fld_dpkMEEmrDateIn.BOSDataMember = "MEEmrDateIn";
            this.fld_dpkMEEmrDateIn.BOSDataSource = "MEEmrs";
            this.fld_dpkMEEmrDateIn.BOSDescription = null;
            this.fld_dpkMEEmrDateIn.BOSError = null;
            this.fld_dpkMEEmrDateIn.BOSFieldGroup = "";
            this.fld_dpkMEEmrDateIn.BOSFieldRelation = "";
            this.fld_dpkMEEmrDateIn.BOSPrivilege = "";
            this.fld_dpkMEEmrDateIn.BOSPropertyName = "EditValue";
            this.fld_dpkMEEmrDateIn.EditValue = null;
            this.fld_dpkMEEmrDateIn.Enabled = false;
            this.fld_dpkMEEmrDateIn.Location = new System.Drawing.Point(516, 116);
            this.fld_dpkMEEmrDateIn.Name = "fld_dpkMEEmrDateIn";
            this.fld_dpkMEEmrDateIn.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dpkMEEmrDateIn.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dpkMEEmrDateIn.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dpkMEEmrDateIn.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dpkMEEmrDateIn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dpkMEEmrDateIn.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dpkMEEmrDateIn.Screen = null;
            this.fld_dpkMEEmrDateIn.Size = new System.Drawing.Size(158, 20);
            this.fld_dpkMEEmrDateIn.TabIndex = 90;
            this.fld_dpkMEEmrDateIn.Tag = "DC";
            // 
            // fld_lkeFK_HREmployeeCreatedID
            // 
            this.fld_lkeFK_HREmployeeCreatedID.BOSAllowAddNew = false;
            this.fld_lkeFK_HREmployeeCreatedID.BOSAllowDummy = true;
            this.fld_lkeFK_HREmployeeCreatedID.BOSComment = "";
            this.fld_lkeFK_HREmployeeCreatedID.BOSDataMember = "FK_HREmployeeCreatedID";
            this.fld_lkeFK_HREmployeeCreatedID.BOSDataSource = "MEEmrs";
            this.fld_lkeFK_HREmployeeCreatedID.BOSDescription = null;
            this.fld_lkeFK_HREmployeeCreatedID.BOSDummyText = null;
            this.fld_lkeFK_HREmployeeCreatedID.BOSError = null;
            this.fld_lkeFK_HREmployeeCreatedID.BOSFieldGroup = "";
            this.fld_lkeFK_HREmployeeCreatedID.BOSFieldParent = "";
            this.fld_lkeFK_HREmployeeCreatedID.BOSFieldRelation = "";
            this.fld_lkeFK_HREmployeeCreatedID.BOSPrivilege = "";
            this.fld_lkeFK_HREmployeeCreatedID.BOSPropertyName = "EditValue";
            this.fld_lkeFK_HREmployeeCreatedID.BOSSelectType = "";
            this.fld_lkeFK_HREmployeeCreatedID.BOSSelectTypeValue = "";
            this.fld_lkeFK_HREmployeeCreatedID.CurrentDisplayText = null;
            this.fld_lkeFK_HREmployeeCreatedID.Enabled = false;
            this.fld_lkeFK_HREmployeeCreatedID.Location = new System.Drawing.Point(85, 143);
            this.fld_lkeFK_HREmployeeCreatedID.Name = "fld_lkeFK_HREmployeeCreatedID";
            this.fld_lkeFK_HREmployeeCreatedID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeFK_HREmployeeCreatedID.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeFK_HREmployeeCreatedID.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeFK_HREmployeeCreatedID.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeFK_HREmployeeCreatedID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_HREmployeeCreatedID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRDepartmentNo", "Mã khoa", 20, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRDepartmentName", "Tên khoa")});
            this.fld_lkeFK_HREmployeeCreatedID.Properties.DisplayMember = "HREmployeeName";
            this.fld_lkeFK_HREmployeeCreatedID.Properties.NullText = "";
            this.fld_lkeFK_HREmployeeCreatedID.Properties.PopupWidth = 40;
            this.fld_lkeFK_HREmployeeCreatedID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeFK_HREmployeeCreatedID.Properties.ValueMember = "HREmployeeID";
            this.fld_lkeFK_HREmployeeCreatedID.Screen = null;
            this.fld_lkeFK_HREmployeeCreatedID.Size = new System.Drawing.Size(157, 20);
            this.fld_lkeFK_HREmployeeCreatedID.TabIndex = 88;
            this.fld_lkeFK_HREmployeeCreatedID.Tag = "DC";
            // 
            // bosLabel4
            // 
            this.bosLabel4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel4.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel4.Appearance.Options.UseBackColor = true;
            this.bosLabel4.Appearance.Options.UseForeColor = true;
            this.bosLabel4.BOSComment = "";
            this.bosLabel4.BOSDataMember = "";
            this.bosLabel4.BOSDataSource = "";
            this.bosLabel4.BOSDescription = null;
            this.bosLabel4.BOSError = null;
            this.bosLabel4.BOSFieldGroup = "";
            this.bosLabel4.BOSFieldRelation = "";
            this.bosLabel4.BOSPrivilege = "";
            this.bosLabel4.BOSPropertyName = "";
            this.bosLabel4.Location = new System.Drawing.Point(11, 146);
            this.bosLabel4.Name = "bosLabel4";
            this.bosLabel4.Screen = null;
            this.bosLabel4.Size = new System.Drawing.Size(47, 13);
            this.bosLabel4.TabIndex = 89;
            this.bosLabel4.Tag = "";
            this.bosLabel4.Text = "Người tạo";
            // 
            // fld_lkeMEEmrTypeProfile
            // 
            this.fld_lkeMEEmrTypeProfile.BOSAllowAddNew = false;
            this.fld_lkeMEEmrTypeProfile.BOSAllowDummy = false;
            this.fld_lkeMEEmrTypeProfile.BOSComment = "";
            this.fld_lkeMEEmrTypeProfile.BOSDataMember = "MEEmrTypeProfile";
            this.fld_lkeMEEmrTypeProfile.BOSDataSource = "MEEmrs";
            this.fld_lkeMEEmrTypeProfile.BOSDescription = null;
            this.fld_lkeMEEmrTypeProfile.BOSDummyText = null;
            this.fld_lkeMEEmrTypeProfile.BOSError = null;
            this.fld_lkeMEEmrTypeProfile.BOSFieldGroup = "";
            this.fld_lkeMEEmrTypeProfile.BOSFieldParent = "";
            this.fld_lkeMEEmrTypeProfile.BOSFieldRelation = "";
            this.fld_lkeMEEmrTypeProfile.BOSPrivilege = "";
            this.fld_lkeMEEmrTypeProfile.BOSPropertyName = "EditValue";
            this.fld_lkeMEEmrTypeProfile.BOSSelectType = "";
            this.fld_lkeMEEmrTypeProfile.BOSSelectTypeValue = "";
            this.fld_lkeMEEmrTypeProfile.CurrentDisplayText = null;
            this.fld_lkeMEEmrTypeProfile.Enabled = false;
            this.fld_lkeMEEmrTypeProfile.Location = new System.Drawing.Point(318, 91);
            this.fld_lkeMEEmrTypeProfile.Name = "fld_lkeMEEmrTypeProfile";
            this.fld_lkeMEEmrTypeProfile.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeMEEmrTypeProfile.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeMEEmrTypeProfile.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeMEEmrTypeProfile.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeMEEmrTypeProfile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeMEEmrTypeProfile.Properties.NullText = "";
            this.fld_lkeMEEmrTypeProfile.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeMEEmrTypeProfile.Screen = null;
            this.fld_lkeMEEmrTypeProfile.Size = new System.Drawing.Size(138, 20);
            this.fld_lkeMEEmrTypeProfile.TabIndex = 87;
            this.fld_lkeMEEmrTypeProfile.Tag = "DC";
            // 
            // bosLabel3
            // 
            this.bosLabel3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel3.Appearance.Options.UseBackColor = true;
            this.bosLabel3.Appearance.Options.UseForeColor = true;
            this.bosLabel3.BOSComment = "";
            this.bosLabel3.BOSDataMember = "";
            this.bosLabel3.BOSDataSource = "";
            this.bosLabel3.BOSDescription = null;
            this.bosLabel3.BOSError = null;
            this.bosLabel3.BOSFieldGroup = "";
            this.bosLabel3.BOSFieldRelation = "";
            this.bosLabel3.BOSPrivilege = "";
            this.bosLabel3.BOSPropertyName = "";
            this.bosLabel3.Location = new System.Drawing.Point(251, 95);
            this.bosLabel3.Name = "bosLabel3";
            this.bosLabel3.Screen = null;
            this.bosLabel3.Size = new System.Drawing.Size(48, 13);
            this.bosLabel3.TabIndex = 86;
            this.bosLabel3.Tag = "";
            this.bosLabel3.Text = "Loại hồ sơ";
            // 
            // bosTextBox2
            // 
            this.bosTextBox2.BOSComment = "";
            this.bosTextBox2.BOSDataMember = "MEPatientName";
            this.bosTextBox2.BOSDataSource = "MEPatients";
            this.bosTextBox2.BOSDescription = null;
            this.bosTextBox2.BOSError = null;
            this.bosTextBox2.BOSFieldGroup = "";
            this.bosTextBox2.BOSFieldRelation = "";
            this.bosTextBox2.BOSPrivilege = "";
            this.bosTextBox2.BOSPropertyName = "Text";
            this.bosTextBox2.EditValue = "";
            this.bosTextBox2.Enabled = false;
            this.bosTextBox2.Location = new System.Drawing.Point(286, 36);
            this.bosTextBox2.Name = "bosTextBox2";
            this.bosTextBox2.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.bosTextBox2.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosTextBox2.Properties.Appearance.Options.UseBackColor = true;
            this.bosTextBox2.Properties.Appearance.Options.UseForeColor = true;
            this.bosTextBox2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.bosTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bosTextBox2.Screen = null;
            this.bosTextBox2.Size = new System.Drawing.Size(234, 20);
            this.bosTextBox2.TabIndex = 28;
            this.bosTextBox2.Tag = "DC";
            // 
            // fld_txtMEPatientNo
            // 
            this.fld_txtMEPatientNo.BOSComment = "";
            this.fld_txtMEPatientNo.BOSDataMember = "MEPatientNo";
            this.fld_txtMEPatientNo.BOSDataSource = "MEPatients";
            this.fld_txtMEPatientNo.BOSDescription = null;
            this.fld_txtMEPatientNo.BOSError = null;
            this.fld_txtMEPatientNo.BOSFieldGroup = "";
            this.fld_txtMEPatientNo.BOSFieldRelation = "";
            this.fld_txtMEPatientNo.BOSPrivilege = "";
            this.fld_txtMEPatientNo.BOSPropertyName = "Text";
            this.fld_txtMEPatientNo.EditValue = "";
            this.fld_txtMEPatientNo.Location = new System.Drawing.Point(85, 36);
            this.fld_txtMEPatientNo.Name = "fld_txtMEPatientNo";
            this.fld_txtMEPatientNo.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.fld_txtMEPatientNo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEPatientNo.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEPatientNo.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEPatientNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEPatientNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEPatientNo.Screen = null;
            this.fld_txtMEPatientNo.Size = new System.Drawing.Size(195, 20);
            this.fld_txtMEPatientNo.TabIndex = 2;
            this.fld_txtMEPatientNo.Tag = "DC";
            this.fld_txtMEPatientNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fld_txtMEPatientNo_KeyUp);
            // 
            // fld_tbnSearchPatientLocal
            // 
            this.fld_tbnSearchPatientLocal.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("fld_tbnSearchPatientLocal.ImageOptions.Image")));
            this.fld_tbnSearchPatientLocal.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.fld_tbnSearchPatientLocal.Location = new System.Drawing.Point(527, 35);
            this.fld_tbnSearchPatientLocal.Name = "fld_tbnSearchPatientLocal";
            this.fld_tbnSearchPatientLocal.Size = new System.Drawing.Size(135, 23);
            this.fld_tbnSearchPatientLocal.TabIndex = 3;
            this.fld_tbnSearchPatientLocal.Text = "Tìm bệnh nhân";
            this.fld_tbnSearchPatientLocal.Click += new System.EventHandler(this.fld_tbnSearchPatientLocal_Click);
            // 
            // DMMEEMR101
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(681, 530);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DMMEEMR101";
            this.Text = "Thông tin";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(tacTransferAndShare)).EndInit();
            tacTransferAndShare.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrTransferHistories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrTransferHistories)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrShareHistories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrMergeHistories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrMergeHistories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrNo2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_medMEEmrDesc1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteAACreatedDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteAACreatedDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteAACreatedDate1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteAACreatedDate1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeLookupEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_MEEmrTypeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosLookupEdit1.Properties)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrPatientAddr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrArchiveNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HREmployeeClosedID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrBedNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrRoomNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dpkMEEmrDateOut.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dpkMEEmrDateOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dpkMEEmrDateIn.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dpkMEEmrDateIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HREmployeeCreatedID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEEmrTypeProfile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosTextBox2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEPatientNo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion

        private IContainer components;
        private DevExpress.XtraEditors.SimpleButton fld_tbnSearchPatientFromHis;
        private BOSComponent.BOSLookupEdit fld_lkeFK_MEEmrTypeID;
        private BOSComponent.BOSLabel bosLabel1;
        private BOSComponent.BOSLabel bosLabel2;
        private BOSComponent.BOSLookupEdit bosLookupEdit1;
        private BOSPanel panelControl1;
        private MEEmrTransfersGridControl fld_dgcMEEmrTransferHistories;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvMEEmrTransferHistories;
        private DevExpress.XtraEditors.SimpleButton fld_btnTransfer;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.SimpleButton fld_btnSelectEmployee;
        private MEEmrShareGridControl fld_dgcMEEmrShareHistories;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton fld_btnSelectDepartment;
        private DevExpress.XtraEditors.SimpleButton fld_tbnSearchPatientLocal;
        private BOSTextBox bosTextBox2;
        private BOSTextBox fld_txtMEPatientNo;
        private BOSLookupEdit fld_lkeMEEmrTypeProfile;
        private BOSLabel bosLabel3;
        private BOSLookupEdit fld_lkeFK_HREmployeeCreatedID;
        private BOSLabel bosLabel4;
        private BOSLookupEdit fld_lkeFK_HREmployeeClosedID;
        private BOSLabel bosLabel9;
        private BOSLabel bosLabel8;
        private BOSTextBox fld_txtMEEmrBedNo;
        private BOSLabel bosLabel7;
        private BOSTextBox fld_txtMEEmrRoomNo;
        private BOSLabel bosLabel6;
        private BOSDateEdit fld_dpkMEEmrDateOut;
        private BOSLabel bosLabel5;
        private BOSDateEdit fld_dpkMEEmrDateIn;
        private BOSLabel bosLabel11;
        private BOSTextBox fld_txtMEEmrPatientAddr;
        private BOSLabel bosLabel10;
        private BOSTextBox fld_txtMEEmrArchiveNo;
        private DevExpress.XtraEditors.SimpleButton fld_tbnSaveShareEmrClose;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private MEEmrMergeHistoriesGridControl fld_dgcMEEmrMergeHistories;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvMEEmrMergeHistories;
        private DevExpress.XtraEditors.SimpleButton fld_btnRefreshMergeHistory;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
