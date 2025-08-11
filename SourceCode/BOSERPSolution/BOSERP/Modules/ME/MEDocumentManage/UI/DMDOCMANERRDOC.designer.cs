using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSComponent;

namespace BOSERP.Modules.MEDocumentManage.UI
{
    partial class DMDOCMANERRDOC

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMDOCMANERRDOC));
            this.fld_tbnSearchDocument = new DevExpress.XtraEditors.SimpleButton();
            this.fld_grdDocumentSearchResult = new BOSERP.Modules.MEDocumentManage.MEEmrDocumentsGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bosLabel1 = new BOSComponent.BOSLabel(this.components);
            this.fld_dteErrDocumentToDate = new BOSComponent.BOSDateEdit(this.components);
            this.fld_dteErrDocumentFromDate = new BOSComponent.BOSDateEdit(this.components);
            this.bosLabel2 = new BOSComponent.BOSLabel(this.components);
            this.txtStorageDir = new BOSComponent.BOSTextBox(this.components);
            this.bosLabel3 = new BOSComponent.BOSLabel(this.components);
            this.panelControl1 = new BOSComponent.BOSPanel(this.components);
            this.fld_btnSelectFile = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.fld_grdDocumentSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteErrDocumentToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteErrDocumentToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteErrDocumentFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteErrDocumentFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStorageDir.Properties)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fld_tbnSearchDocument
            // 
            this.fld_tbnSearchDocument.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("fld_tbnSearchDocument.ImageOptions.Image")));
            this.fld_tbnSearchDocument.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.fld_tbnSearchDocument.Location = new System.Drawing.Point(767, 36);
            this.fld_tbnSearchDocument.Name = "fld_tbnSearchDocument";
            this.fld_tbnSearchDocument.Size = new System.Drawing.Size(75, 23);
            this.fld_tbnSearchDocument.TabIndex = 1;
            this.fld_tbnSearchDocument.Text = "Quét";
            this.fld_tbnSearchDocument.Click += new System.EventHandler(this.fld_tbnSearchDocument_Click);
            // 
            // fld_grdDocumentSearchResult
            // 
            this.fld_grdDocumentSearchResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_grdDocumentSearchResult.BOSComment = null;
            this.fld_grdDocumentSearchResult.BOSDataMember = null;
            this.fld_grdDocumentSearchResult.BOSDataSource = "MEEmrDocuments";
            this.fld_grdDocumentSearchResult.BOSDescription = null;
            this.fld_grdDocumentSearchResult.BOSError = null;
            this.fld_grdDocumentSearchResult.BOSFieldGroup = null;
            this.fld_grdDocumentSearchResult.BOSFieldRelation = null;
            this.fld_grdDocumentSearchResult.BOSGridType = null;
            this.fld_grdDocumentSearchResult.BOSPrivilege = null;
            this.fld_grdDocumentSearchResult.BOSPropertyName = null;
            this.fld_grdDocumentSearchResult.Location = new System.Drawing.Point(3, 65);
            this.fld_grdDocumentSearchResult.MainView = this.gridView1;
            this.fld_grdDocumentSearchResult.MenuManager = this.screenToolbar;
            this.fld_grdDocumentSearchResult.Name = "fld_grdDocumentSearchResult";
            this.fld_grdDocumentSearchResult.PrintReport = false;
            this.fld_grdDocumentSearchResult.Screen = null;
            this.fld_grdDocumentSearchResult.Size = new System.Drawing.Size(952, 642);
            this.fld_grdDocumentSearchResult.TabIndex = 24;
            this.fld_grdDocumentSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_grdDocumentSearchResult;
            this.gridView1.Name = "gridView1";
            // 
            // bosLabel1
            // 
            this.bosLabel1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.bosLabel1.Location = new System.Drawing.Point(427, 15);
            this.bosLabel1.Name = "bosLabel1";
            this.bosLabel1.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel1, true);
            this.bosLabel1.Size = new System.Drawing.Size(4, 13);
            this.bosLabel1.TabIndex = 1000000022;
            this.bosLabel1.Tag = "SI";
            this.bosLabel1.Text = "-";
            // 
            // fld_dteErrDocumentToDate
            // 
            this.fld_dteErrDocumentToDate.BOSComment = "";
            this.fld_dteErrDocumentToDate.BOSDataMember = "";
            this.fld_dteErrDocumentToDate.BOSDataSource = "";
            this.fld_dteErrDocumentToDate.BOSDescription = null;
            this.fld_dteErrDocumentToDate.BOSError = null;
            this.fld_dteErrDocumentToDate.BOSFieldGroup = "";
            this.fld_dteErrDocumentToDate.BOSFieldRelation = "";
            this.fld_dteErrDocumentToDate.BOSPrivilege = "";
            this.fld_dteErrDocumentToDate.BOSPropertyName = "EditValue";
            this.fld_dteErrDocumentToDate.EditValue = null;
            this.fld_dteErrDocumentToDate.Location = new System.Drawing.Point(437, 12);
            this.fld_dteErrDocumentToDate.Name = "fld_dteErrDocumentToDate";
            this.fld_dteErrDocumentToDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteErrDocumentToDate.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteErrDocumentToDate.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteErrDocumentToDate.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteErrDocumentToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteErrDocumentToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteErrDocumentToDate.Screen = null;
            this.fld_dteErrDocumentToDate.Size = new System.Drawing.Size(244, 20);
            this.fld_dteErrDocumentToDate.TabIndex = 1000000023;
            this.fld_dteErrDocumentToDate.Tag = "SC";
            // 
            // fld_dteErrDocumentFromDate
            // 
            this.fld_dteErrDocumentFromDate.BOSComment = "";
            this.fld_dteErrDocumentFromDate.BOSDataMember = "";
            this.fld_dteErrDocumentFromDate.BOSDataSource = "";
            this.fld_dteErrDocumentFromDate.BOSDescription = null;
            this.fld_dteErrDocumentFromDate.BOSError = null;
            this.fld_dteErrDocumentFromDate.BOSFieldGroup = "";
            this.fld_dteErrDocumentFromDate.BOSFieldRelation = "";
            this.fld_dteErrDocumentFromDate.BOSPrivilege = "";
            this.fld_dteErrDocumentFromDate.BOSPropertyName = "EditValue";
            this.fld_dteErrDocumentFromDate.EditValue = null;
            this.fld_dteErrDocumentFromDate.Location = new System.Drawing.Point(156, 12);
            this.fld_dteErrDocumentFromDate.Name = "fld_dteErrDocumentFromDate";
            this.fld_dteErrDocumentFromDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteErrDocumentFromDate.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteErrDocumentFromDate.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteErrDocumentFromDate.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteErrDocumentFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteErrDocumentFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteErrDocumentFromDate.Screen = null;
            this.fld_dteErrDocumentFromDate.Size = new System.Drawing.Size(265, 20);
            this.fld_dteErrDocumentFromDate.TabIndex = 1000000021;
            this.fld_dteErrDocumentFromDate.Tag = "SC";
            // 
            // bosLabel2
            // 
            this.bosLabel2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.bosLabel2.Location = new System.Drawing.Point(21, 19);
            this.bosLabel2.Name = "bosLabel2";
            this.bosLabel2.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel2, true);
            this.bosLabel2.Size = new System.Drawing.Size(43, 13);
            this.bosLabel2.TabIndex = 1000000024;
            this.bosLabel2.Tag = "SI";
            this.bosLabel2.Text = "Thời gian";
            // 
            // txtStorageDir
            // 
            this.txtStorageDir.BOSComment = "";
            this.txtStorageDir.BOSDataMember = "";
            this.txtStorageDir.BOSDataSource = "";
            this.txtStorageDir.BOSDescription = null;
            this.txtStorageDir.BOSError = null;
            this.txtStorageDir.BOSFieldGroup = "";
            this.txtStorageDir.BOSFieldRelation = "";
            this.txtStorageDir.BOSPrivilege = "";
            this.txtStorageDir.BOSPropertyName = "Text";
            this.txtStorageDir.EditValue = "";
            this.txtStorageDir.Location = new System.Drawing.Point(156, 39);
            this.txtStorageDir.Name = "txtStorageDir";
            this.txtStorageDir.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtStorageDir.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStorageDir.Properties.Appearance.Options.UseBackColor = true;
            this.txtStorageDir.Properties.Appearance.Options.UseForeColor = true;
            this.txtStorageDir.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtStorageDir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtStorageDir.Screen = null;
            this.txtStorageDir.Size = new System.Drawing.Size(525, 20);
            this.txtStorageDir.TabIndex = 1000000025;
            this.txtStorageDir.Tag = "SC";
            // 
            // bosLabel3
            // 
            this.bosLabel3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.bosLabel3.Location = new System.Drawing.Point(21, 42);
            this.bosLabel3.Name = "bosLabel3";
            this.bosLabel3.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel3, true);
            this.bosLabel3.Size = new System.Drawing.Size(118, 13);
            this.bosLabel3.TabIndex = 1000000026;
            this.bosLabel3.Tag = "SI";
            this.bosLabel3.Text = "Thư mục lưu trữ (~/Emr)";
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
            this.panelControl1.Controls.Add(this.fld_btnSelectFile);
            this.panelControl1.Controls.Add(this.fld_dteErrDocumentToDate);
            this.panelControl1.Controls.Add(this.bosLabel3);
            this.panelControl1.Controls.Add(this.fld_tbnSearchDocument);
            this.panelControl1.Controls.Add(this.txtStorageDir);
            this.panelControl1.Controls.Add(this.fld_grdDocumentSearchResult);
            this.panelControl1.Controls.Add(this.bosLabel2);
            this.panelControl1.Controls.Add(this.fld_dteErrDocumentFromDate);
            this.panelControl1.Controls.Add(this.bosLabel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Screen = null;
            this.panelControl1.Size = new System.Drawing.Size(955, 707);
            this.panelControl1.TabIndex = 1000000027;
            // 
            // fld_btnSelectFile
            // 
            this.fld_btnSelectFile.Location = new System.Drawing.Point(687, 36);
            this.fld_btnSelectFile.Name = "fld_btnSelectFile";
            this.fld_btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.fld_btnSelectFile.TabIndex = 1000000027;
            this.fld_btnSelectFile.Text = "Chọn thư mục";
            this.fld_btnSelectFile.Click += new System.EventHandler(this.fld_btnSelectFile_Click);
            // 
            // DMDOCMANERRDOC
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(955, 707);
            this.ControlBox = true;
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DMDOCMANERRDOC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tờ bệnh án lỗi nội dung";
            this.Load += new System.EventHandler(this.guiSearchDocument_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_grdDocumentSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteErrDocumentToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteErrDocumentToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteErrDocumentFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteErrDocumentFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStorageDir.Properties)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private IContainer components;
        private DevExpress.XtraEditors.SimpleButton fld_tbnSearchDocument;
        private MEEmrDocumentsGridControl fld_grdDocumentSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private BOSComponent.BOSLabel bosLabel1;
        private BOSComponent.BOSDateEdit fld_dteErrDocumentToDate;
        private BOSComponent.BOSDateEdit fld_dteErrDocumentFromDate;
        private BOSComponent.BOSLabel bosLabel2;
        private BOSTextBox txtStorageDir;
        private BOSLabel bosLabel3;
        private BOSPanel panelControl1;
        private DevExpress.XtraEditors.SimpleButton fld_btnSelectFile;
    }
}
