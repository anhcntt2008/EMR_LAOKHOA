using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    partial class guiCheckup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiCheckup));
            this.btnPrintAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintSelect = new DevExpress.XtraEditors.SimpleButton();
            this.fld_dgcMEEmrDocuments1 = new BOSERP.Modules.MEEmr.MEEmrDocumentsForCheckupGridControl();
            this.fld_dgvMEEmrDocuments = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.pdfViewer1 = new DevExpress.XtraPdfViewer.PdfViewer();
            this.pdfBarController1 = new DevExpress.XtraPdfViewer.Bars.PdfBarController();
            this.pdfFileOpenBarItem1 = new DevExpress.XtraPdfViewer.Bars.PdfFileOpenBarItem();
            this.pdfFileSaveAsBarItem1 = new DevExpress.XtraPdfViewer.Bars.PdfFileSaveAsBarItem();
            this.pdfFilePrintBarItem1 = new DevExpress.XtraPdfViewer.Bars.PdfFilePrintBarItem();
            this.pdfFindTextBarItem1 = new DevExpress.XtraPdfViewer.Bars.PdfFindTextBarItem();
            this.pdfPreviousPageBarItem1 = new DevExpress.XtraPdfViewer.Bars.PdfPreviousPageBarItem();
            this.pdfNextPageBarItem1 = new DevExpress.XtraPdfViewer.Bars.PdfNextPageBarItem();
            this.pdfSetPageNumberBarItem1 = new DevExpress.XtraPdfViewer.Bars.PdfSetPageNumberBarItem();
            this.repositoryItemPageNumberEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPageNumberEdit();
            this.pdfZoomOutBarItem1 = new DevExpress.XtraPdfViewer.Bars.PdfZoomOutBarItem();
            this.pdfZoomInBarItem1 = new DevExpress.XtraPdfViewer.Bars.PdfZoomInBarItem();
            this.pdfExactZoomListBarSubItem1 = new DevExpress.XtraPdfViewer.Bars.PdfExactZoomListBarSubItem();
            this.pdfZoom10CheckItem1 = new DevExpress.XtraPdfViewer.Bars.PdfZoom10CheckItem();
            this.pdfZoom25CheckItem1 = new DevExpress.XtraPdfViewer.Bars.PdfZoom25CheckItem();
            this.pdfZoom50CheckItem1 = new DevExpress.XtraPdfViewer.Bars.PdfZoom50CheckItem();
            this.pdfZoom75CheckItem1 = new DevExpress.XtraPdfViewer.Bars.PdfZoom75CheckItem();
            this.pdfZoom100CheckItem1 = new DevExpress.XtraPdfViewer.Bars.PdfZoom100CheckItem();
            this.pdfZoom125CheckItem1 = new DevExpress.XtraPdfViewer.Bars.PdfZoom125CheckItem();
            this.pdfZoom150CheckItem1 = new DevExpress.XtraPdfViewer.Bars.PdfZoom150CheckItem();
            this.pdfZoom200CheckItem1 = new DevExpress.XtraPdfViewer.Bars.PdfZoom200CheckItem();
            this.pdfZoom400CheckItem1 = new DevExpress.XtraPdfViewer.Bars.PdfZoom400CheckItem();
            this.pdfZoom500CheckItem1 = new DevExpress.XtraPdfViewer.Bars.PdfZoom500CheckItem();
            this.pdfSetActualSizeZoomModeCheckItem1 = new DevExpress.XtraPdfViewer.Bars.PdfSetActualSizeZoomModeCheckItem();
            this.pdfSetPageLevelZoomModeCheckItem1 = new DevExpress.XtraPdfViewer.Bars.PdfSetPageLevelZoomModeCheckItem();
            this.pdfSetFitWidthZoomModeCheckItem1 = new DevExpress.XtraPdfViewer.Bars.PdfSetFitWidthZoomModeCheckItem();
            this.pdfSetFitVisibleZoomModeCheckItem1 = new DevExpress.XtraPdfViewer.Bars.PdfSetFitVisibleZoomModeCheckItem();
            this.pdfCommandBar1 = new DevExpress.XtraPdfViewer.Bars.PdfCommandBar();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrDocuments1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pdfBarController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPageNumberEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrintAll
            // 
            this.btnPrintAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintAll.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintAll.ImageOptions.Image")));
            this.btnPrintAll.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnPrintAll.Location = new System.Drawing.Point(142, 634);
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.Size = new System.Drawing.Size(106, 23);
            this.btnPrintAll.TabIndex = 21;
            this.btnPrintAll.Text = "In toàn bộ";
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(856, 634);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrintSelect
            // 
            this.btnPrintSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintSelect.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintSelect.ImageOptions.Image")));
            this.btnPrintSelect.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnPrintSelect.Location = new System.Drawing.Point(12, 634);
            this.btnPrintSelect.Name = "btnPrintSelect";
            this.btnPrintSelect.Size = new System.Drawing.Size(124, 23);
            this.btnPrintSelect.TabIndex = 20;
            this.btnPrintSelect.Text = "In các tờ đã chọn";
            this.btnPrintSelect.Click += new System.EventHandler(this.btnPrintSelect_Click);
            // 
            // fld_dgcMEEmrDocuments1
            // 
            this.fld_dgcMEEmrDocuments1.AllowDrop = true;
            this.fld_dgcMEEmrDocuments1.BOSComment = "";
            this.fld_dgcMEEmrDocuments1.BOSDataMember = "";
            this.fld_dgcMEEmrDocuments1.BOSDataSource = "MEEmrDocuments";
            this.fld_dgcMEEmrDocuments1.BOSDescription = null;
            this.fld_dgcMEEmrDocuments1.BOSError = null;
            this.fld_dgcMEEmrDocuments1.BOSFieldGroup = "";
            this.fld_dgcMEEmrDocuments1.BOSFieldRelation = "";
            this.fld_dgcMEEmrDocuments1.BOSGridType = null;
            this.fld_dgcMEEmrDocuments1.BOSPrivilege = "";
            this.fld_dgcMEEmrDocuments1.BOSPropertyName = "";
            this.fld_dgcMEEmrDocuments1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_dgcMEEmrDocuments1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMEEmrDocuments1.Location = new System.Drawing.Point(0, 0);
            this.fld_dgcMEEmrDocuments1.MainView = this.fld_dgvMEEmrDocuments;
            this.fld_dgcMEEmrDocuments1.Name = "fld_dgcMEEmrDocuments1";
            this.fld_dgcMEEmrDocuments1.PrintReport = false;
            this.fld_dgcMEEmrDocuments1.Screen = null;
            this.fld_dgcMEEmrDocuments1.Size = new System.Drawing.Size(305, 626);
            this.fld_dgcMEEmrDocuments1.TabIndex = 15;
            this.fld_dgcMEEmrDocuments1.Tag = "DC";
            this.fld_dgcMEEmrDocuments1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvMEEmrDocuments});
            // 
            // fld_dgvMEEmrDocuments
            // 
            this.fld_dgvMEEmrDocuments.GridControl = this.fld_dgcMEEmrDocuments1;
            this.fld_dgvMEEmrDocuments.Name = "fld_dgvMEEmrDocuments";
            this.fld_dgvMEEmrDocuments.PaintStyleName = "Office2003";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 2);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.fld_dgcMEEmrDocuments1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.pdfViewer1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(936, 626);
            this.splitContainerControl1.SplitterPosition = 305;
            this.splitContainerControl1.TabIndex = 16;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfViewer1.Location = new System.Drawing.Point(2, 32);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.Size = new System.Drawing.Size(617, 594);
            this.pdfViewer1.TabIndex = 0;
            // 
            // pdfBarController1
            // 
            this.pdfBarController1.BarItems.Add(this.pdfFileOpenBarItem1);
            this.pdfBarController1.BarItems.Add(this.pdfFileSaveAsBarItem1);
            this.pdfBarController1.BarItems.Add(this.pdfFilePrintBarItem1);
            this.pdfBarController1.BarItems.Add(this.pdfFindTextBarItem1);
            this.pdfBarController1.BarItems.Add(this.pdfPreviousPageBarItem1);
            this.pdfBarController1.BarItems.Add(this.pdfNextPageBarItem1);
            this.pdfBarController1.BarItems.Add(this.pdfSetPageNumberBarItem1);
            this.pdfBarController1.BarItems.Add(this.pdfZoomOutBarItem1);
            this.pdfBarController1.BarItems.Add(this.pdfZoomInBarItem1);
            this.pdfBarController1.BarItems.Add(this.pdfExactZoomListBarSubItem1);
            this.pdfBarController1.BarItems.Add(this.pdfZoom10CheckItem1);
            this.pdfBarController1.BarItems.Add(this.pdfZoom25CheckItem1);
            this.pdfBarController1.BarItems.Add(this.pdfZoom50CheckItem1);
            this.pdfBarController1.BarItems.Add(this.pdfZoom75CheckItem1);
            this.pdfBarController1.BarItems.Add(this.pdfZoom100CheckItem1);
            this.pdfBarController1.BarItems.Add(this.pdfZoom125CheckItem1);
            this.pdfBarController1.BarItems.Add(this.pdfZoom150CheckItem1);
            this.pdfBarController1.BarItems.Add(this.pdfZoom200CheckItem1);
            this.pdfBarController1.BarItems.Add(this.pdfZoom400CheckItem1);
            this.pdfBarController1.BarItems.Add(this.pdfZoom500CheckItem1);
            this.pdfBarController1.BarItems.Add(this.pdfSetActualSizeZoomModeCheckItem1);
            this.pdfBarController1.BarItems.Add(this.pdfSetPageLevelZoomModeCheckItem1);
            this.pdfBarController1.BarItems.Add(this.pdfSetFitWidthZoomModeCheckItem1);
            this.pdfBarController1.BarItems.Add(this.pdfSetFitVisibleZoomModeCheckItem1);
            this.pdfBarController1.Control = this.pdfViewer1;
            // 
            // pdfFileOpenBarItem1
            // 
            this.pdfFileOpenBarItem1.Id = 0;
            this.pdfFileOpenBarItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O));
            this.pdfFileOpenBarItem1.Name = "pdfFileOpenBarItem1";
            // 
            // pdfFileSaveAsBarItem1
            // 
            this.pdfFileSaveAsBarItem1.Id = 1;
            this.pdfFileSaveAsBarItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.pdfFileSaveAsBarItem1.Name = "pdfFileSaveAsBarItem1";
            // 
            // pdfFilePrintBarItem1
            // 
            this.pdfFilePrintBarItem1.Id = 2;
            this.pdfFilePrintBarItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.pdfFilePrintBarItem1.Name = "pdfFilePrintBarItem1";
            // 
            // pdfFindTextBarItem1
            // 
            this.pdfFindTextBarItem1.Id = 3;
            this.pdfFindTextBarItem1.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F));
            this.pdfFindTextBarItem1.Name = "pdfFindTextBarItem1";
            // 
            // pdfPreviousPageBarItem1
            // 
            this.pdfPreviousPageBarItem1.Id = 4;
            this.pdfPreviousPageBarItem1.Name = "pdfPreviousPageBarItem1";
            // 
            // pdfNextPageBarItem1
            // 
            this.pdfNextPageBarItem1.Id = 5;
            this.pdfNextPageBarItem1.Name = "pdfNextPageBarItem1";
            // 
            // pdfSetPageNumberBarItem1
            // 
            this.pdfSetPageNumberBarItem1.Edit = this.repositoryItemPageNumberEdit1;
            this.pdfSetPageNumberBarItem1.EditValue = 0;
            this.pdfSetPageNumberBarItem1.Enabled = false;
            this.pdfSetPageNumberBarItem1.Id = 6;
            this.pdfSetPageNumberBarItem1.Name = "pdfSetPageNumberBarItem1";
            // 
            // repositoryItemPageNumberEdit1
            // 
            this.repositoryItemPageNumberEdit1.AutoHeight = false;
            this.repositoryItemPageNumberEdit1.Mask.EditMask = "########;";
            this.repositoryItemPageNumberEdit1.Name = "repositoryItemPageNumberEdit1";
            this.repositoryItemPageNumberEdit1.Orientation = DevExpress.XtraEditors.PagerOrientation.Horizontal;
            // 
            // pdfZoomOutBarItem1
            // 
            this.pdfZoomOutBarItem1.Id = 7;
            this.pdfZoomOutBarItem1.Name = "pdfZoomOutBarItem1";
            // 
            // pdfZoomInBarItem1
            // 
            this.pdfZoomInBarItem1.Id = 8;
            this.pdfZoomInBarItem1.Name = "pdfZoomInBarItem1";
            // 
            // pdfExactZoomListBarSubItem1
            // 
            this.pdfExactZoomListBarSubItem1.Id = 9;
            this.pdfExactZoomListBarSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.pdfZoom10CheckItem1, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.pdfZoom25CheckItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.pdfZoom50CheckItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.pdfZoom75CheckItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.pdfZoom100CheckItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.pdfZoom125CheckItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.pdfZoom150CheckItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.pdfZoom200CheckItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.pdfZoom400CheckItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.pdfZoom500CheckItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.pdfSetActualSizeZoomModeCheckItem1, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.pdfSetPageLevelZoomModeCheckItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.pdfSetFitWidthZoomModeCheckItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.pdfSetFitVisibleZoomModeCheckItem1)});
            this.pdfExactZoomListBarSubItem1.Name = "pdfExactZoomListBarSubItem1";
            this.pdfExactZoomListBarSubItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            // 
            // pdfZoom10CheckItem1
            // 
            this.pdfZoom10CheckItem1.Id = 10;
            this.pdfZoom10CheckItem1.Name = "pdfZoom10CheckItem1";
            // 
            // pdfZoom25CheckItem1
            // 
            this.pdfZoom25CheckItem1.Id = 11;
            this.pdfZoom25CheckItem1.Name = "pdfZoom25CheckItem1";
            // 
            // pdfZoom50CheckItem1
            // 
            this.pdfZoom50CheckItem1.Id = 12;
            this.pdfZoom50CheckItem1.Name = "pdfZoom50CheckItem1";
            // 
            // pdfZoom75CheckItem1
            // 
            this.pdfZoom75CheckItem1.Id = 13;
            this.pdfZoom75CheckItem1.Name = "pdfZoom75CheckItem1";
            // 
            // pdfZoom100CheckItem1
            // 
            this.pdfZoom100CheckItem1.Id = 14;
            this.pdfZoom100CheckItem1.Name = "pdfZoom100CheckItem1";
            // 
            // pdfZoom125CheckItem1
            // 
            this.pdfZoom125CheckItem1.Id = 15;
            this.pdfZoom125CheckItem1.Name = "pdfZoom125CheckItem1";
            // 
            // pdfZoom150CheckItem1
            // 
            this.pdfZoom150CheckItem1.Id = 16;
            this.pdfZoom150CheckItem1.Name = "pdfZoom150CheckItem1";
            // 
            // pdfZoom200CheckItem1
            // 
            this.pdfZoom200CheckItem1.Id = 17;
            this.pdfZoom200CheckItem1.Name = "pdfZoom200CheckItem1";
            // 
            // pdfZoom400CheckItem1
            // 
            this.pdfZoom400CheckItem1.Id = 18;
            this.pdfZoom400CheckItem1.Name = "pdfZoom400CheckItem1";
            // 
            // pdfZoom500CheckItem1
            // 
            this.pdfZoom500CheckItem1.Id = 19;
            this.pdfZoom500CheckItem1.Name = "pdfZoom500CheckItem1";
            // 
            // pdfSetActualSizeZoomModeCheckItem1
            // 
            this.pdfSetActualSizeZoomModeCheckItem1.Id = 20;
            this.pdfSetActualSizeZoomModeCheckItem1.Name = "pdfSetActualSizeZoomModeCheckItem1";
            // 
            // pdfSetPageLevelZoomModeCheckItem1
            // 
            this.pdfSetPageLevelZoomModeCheckItem1.Id = 21;
            this.pdfSetPageLevelZoomModeCheckItem1.Name = "pdfSetPageLevelZoomModeCheckItem1";
            // 
            // pdfSetFitWidthZoomModeCheckItem1
            // 
            this.pdfSetFitWidthZoomModeCheckItem1.Id = 22;
            this.pdfSetFitWidthZoomModeCheckItem1.Name = "pdfSetFitWidthZoomModeCheckItem1";
            // 
            // pdfSetFitVisibleZoomModeCheckItem1
            // 
            this.pdfSetFitVisibleZoomModeCheckItem1.Id = 23;
            this.pdfSetFitVisibleZoomModeCheckItem1.Name = "pdfSetFitVisibleZoomModeCheckItem1";
            // 
            // pdfCommandBar1
            // 
            this.pdfCommandBar1.BarName = "";
            this.pdfCommandBar1.Control = this.pdfViewer1;
            this.pdfCommandBar1.DockCol = 0;
            this.pdfCommandBar1.DockRow = 0;
            this.pdfCommandBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.pdfCommandBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.pdfFileOpenBarItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.pdfFileSaveAsBarItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.pdfFilePrintBarItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.pdfFindTextBarItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.pdfPreviousPageBarItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.pdfNextPageBarItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.pdfSetPageNumberBarItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.pdfZoomOutBarItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.pdfZoomInBarItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.pdfExactZoomListBarSubItem1)});
            this.pdfCommandBar1.Text = "";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnOk.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnOk.Location = new System.Drawing.Point(744, 634);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(106, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Duyệt và Lưu";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // guiCheckup
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(937, 661);
            this.ControlBox = true;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.btnPrintSelect);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrintAll);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiCheckup";
            this.Text = "Kiểm duyệt bệnh án";
            this.Load += new System.EventHandler(this.DSMEEMR100_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.DSMEEMR106_PreviewKeyDown);
            this.Controls.SetChildIndex(this.btnPrintAll, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnPrintSelect, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrDocuments1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pdfBarController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPageNumberEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private IContainer components;
        private DevExpress.XtraEditors.SimpleButton btnPrintAll;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnPrintSelect;
        private MEEmrDocumentsForCheckupGridControl fld_dgcMEEmrDocuments1;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvMEEmrDocuments;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer1;
        private DevExpress.XtraPdfViewer.Bars.PdfBarController pdfBarController1;
        private DevExpress.XtraPdfViewer.Bars.PdfFileOpenBarItem pdfFileOpenBarItem1;
        private DevExpress.XtraPdfViewer.Bars.PdfFileSaveAsBarItem pdfFileSaveAsBarItem1;
        private DevExpress.XtraPdfViewer.Bars.PdfFilePrintBarItem pdfFilePrintBarItem1;
        private DevExpress.XtraPdfViewer.Bars.PdfFindTextBarItem pdfFindTextBarItem1;
        private DevExpress.XtraPdfViewer.Bars.PdfPreviousPageBarItem pdfPreviousPageBarItem1;
        private DevExpress.XtraPdfViewer.Bars.PdfNextPageBarItem pdfNextPageBarItem1;
        private DevExpress.XtraPdfViewer.Bars.PdfSetPageNumberBarItem pdfSetPageNumberBarItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPageNumberEdit repositoryItemPageNumberEdit1;
        private DevExpress.XtraPdfViewer.Bars.PdfZoomOutBarItem pdfZoomOutBarItem1;
        private DevExpress.XtraPdfViewer.Bars.PdfZoomInBarItem pdfZoomInBarItem1;
        private DevExpress.XtraPdfViewer.Bars.PdfExactZoomListBarSubItem pdfExactZoomListBarSubItem1;
        private DevExpress.XtraPdfViewer.Bars.PdfZoom10CheckItem pdfZoom10CheckItem1;
        private DevExpress.XtraPdfViewer.Bars.PdfZoom25CheckItem pdfZoom25CheckItem1;
        private DevExpress.XtraPdfViewer.Bars.PdfZoom50CheckItem pdfZoom50CheckItem1;
        private DevExpress.XtraPdfViewer.Bars.PdfZoom75CheckItem pdfZoom75CheckItem1;
        private DevExpress.XtraPdfViewer.Bars.PdfZoom100CheckItem pdfZoom100CheckItem1;
        private DevExpress.XtraPdfViewer.Bars.PdfZoom125CheckItem pdfZoom125CheckItem1;
        private DevExpress.XtraPdfViewer.Bars.PdfZoom150CheckItem pdfZoom150CheckItem1;
        private DevExpress.XtraPdfViewer.Bars.PdfZoom200CheckItem pdfZoom200CheckItem1;
        private DevExpress.XtraPdfViewer.Bars.PdfZoom400CheckItem pdfZoom400CheckItem1;
        private DevExpress.XtraPdfViewer.Bars.PdfZoom500CheckItem pdfZoom500CheckItem1;
        private DevExpress.XtraPdfViewer.Bars.PdfSetActualSizeZoomModeCheckItem pdfSetActualSizeZoomModeCheckItem1;
        private DevExpress.XtraPdfViewer.Bars.PdfSetPageLevelZoomModeCheckItem pdfSetPageLevelZoomModeCheckItem1;
        private DevExpress.XtraPdfViewer.Bars.PdfSetFitWidthZoomModeCheckItem pdfSetFitWidthZoomModeCheckItem1;
        private DevExpress.XtraPdfViewer.Bars.PdfSetFitVisibleZoomModeCheckItem pdfSetFitVisibleZoomModeCheckItem1;
        private DevExpress.XtraPdfViewer.Bars.PdfCommandBar pdfCommandBar1;
        private DevExpress.XtraEditors.SimpleButton btnOk;
    }
}
