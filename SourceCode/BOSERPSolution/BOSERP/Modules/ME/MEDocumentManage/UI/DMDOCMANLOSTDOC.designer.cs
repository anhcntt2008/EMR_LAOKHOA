using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSComponent;

namespace BOSERP.Modules.MEDocumentManage.UI
{
    partial class DMDOCMANLOSTDOC

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMDOCMANLOSTDOC));
            this.fld_tbnSearchDocument = new DevExpress.XtraEditors.SimpleButton();
            this.fld_grdDocumentSearchResult = new BOSERP.Modules.MEDocumentManage.MEEmrDocumentsGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bosLabel1 = new BOSComponent.BOSLabel(this.components);
            this.fld_dteSearchToMEEmrDocumentCreatedDate = new BOSComponent.BOSDateEdit(this.components);
            this.fld_dteSearchFromMEEmrDocumentCreatedDate = new BOSComponent.BOSDateEdit(this.components);
            this.bosLabel2 = new BOSComponent.BOSLabel(this.components);
            this.panelControl1 = new BOSComponent.BOSPanel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fld_grdDocumentSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchToMEEmrDocumentCreatedDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchToMEEmrDocumentCreatedDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchFromMEEmrDocumentCreatedDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchFromMEEmrDocumentCreatedDate.Properties)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fld_tbnSearchDocument
            // 
            this.fld_tbnSearchDocument.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("fld_tbnSearchDocument.ImageOptions.Image")));
            this.fld_tbnSearchDocument.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.fld_tbnSearchDocument.Location = new System.Drawing.Point(471, 12);
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
            this.fld_grdDocumentSearchResult.Location = new System.Drawing.Point(3, 41);
            this.fld_grdDocumentSearchResult.MainView = this.gridView1;
            this.fld_grdDocumentSearchResult.MenuManager = this.screenToolbar;
            this.fld_grdDocumentSearchResult.Name = "fld_grdDocumentSearchResult";
            this.fld_grdDocumentSearchResult.PrintReport = false;
            this.fld_grdDocumentSearchResult.Screen = null;
            this.fld_grdDocumentSearchResult.Size = new System.Drawing.Size(951, 576);
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
            this.bosLabel1.Location = new System.Drawing.Point(277, 17);
            this.bosLabel1.Name = "bosLabel1";
            this.bosLabel1.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel1, true);
            this.bosLabel1.Size = new System.Drawing.Size(4, 13);
            this.bosLabel1.TabIndex = 1000000022;
            this.bosLabel1.Tag = "SI";
            this.bosLabel1.Text = "-";
            // 
            // fld_dteSearchToMEEmrDocumentCreatedDate
            // 
            this.fld_dteSearchToMEEmrDocumentCreatedDate.BOSComment = "";
            this.fld_dteSearchToMEEmrDocumentCreatedDate.BOSDataMember = "MEEmrDocumentCreatedDateTo";
            this.fld_dteSearchToMEEmrDocumentCreatedDate.BOSDataSource = "";
            this.fld_dteSearchToMEEmrDocumentCreatedDate.BOSDescription = null;
            this.fld_dteSearchToMEEmrDocumentCreatedDate.BOSError = null;
            this.fld_dteSearchToMEEmrDocumentCreatedDate.BOSFieldGroup = "";
            this.fld_dteSearchToMEEmrDocumentCreatedDate.BOSFieldRelation = "";
            this.fld_dteSearchToMEEmrDocumentCreatedDate.BOSPrivilege = "";
            this.fld_dteSearchToMEEmrDocumentCreatedDate.BOSPropertyName = "EditValue";
            this.fld_dteSearchToMEEmrDocumentCreatedDate.EditValue = null;
            this.fld_dteSearchToMEEmrDocumentCreatedDate.Location = new System.Drawing.Point(287, 14);
            this.fld_dteSearchToMEEmrDocumentCreatedDate.Name = "fld_dteSearchToMEEmrDocumentCreatedDate";
            this.fld_dteSearchToMEEmrDocumentCreatedDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteSearchToMEEmrDocumentCreatedDate.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteSearchToMEEmrDocumentCreatedDate.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteSearchToMEEmrDocumentCreatedDate.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteSearchToMEEmrDocumentCreatedDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteSearchToMEEmrDocumentCreatedDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteSearchToMEEmrDocumentCreatedDate.Screen = null;
            this.fld_dteSearchToMEEmrDocumentCreatedDate.Size = new System.Drawing.Size(178, 20);
            this.fld_dteSearchToMEEmrDocumentCreatedDate.TabIndex = 1000000023;
            this.fld_dteSearchToMEEmrDocumentCreatedDate.Tag = "SC";
            // 
            // fld_dteSearchFromMEEmrDocumentCreatedDate
            // 
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.BOSComment = "";
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.BOSDataMember = "MEEmrDocumentCreatedDateFrom";
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.BOSDataSource = "";
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.BOSDescription = null;
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.BOSError = null;
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.BOSFieldGroup = "";
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.BOSFieldRelation = "";
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.BOSPrivilege = "";
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.BOSPropertyName = "EditValue";
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.EditValue = null;
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.Location = new System.Drawing.Point(78, 14);
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.Name = "fld_dteSearchFromMEEmrDocumentCreatedDate";
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.Screen = null;
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.Size = new System.Drawing.Size(193, 20);
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.TabIndex = 1000000021;
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.Tag = "SC";
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
            this.bosLabel2.Location = new System.Drawing.Point(17, 17);
            this.bosLabel2.Name = "bosLabel2";
            this.bosLabel2.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel2, true);
            this.bosLabel2.Size = new System.Drawing.Size(43, 13);
            this.bosLabel2.TabIndex = 1000000024;
            this.bosLabel2.Tag = "SI";
            this.bosLabel2.Text = "Thời gian";
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
            this.panelControl1.Controls.Add(this.fld_dteSearchToMEEmrDocumentCreatedDate);
            this.panelControl1.Controls.Add(this.fld_tbnSearchDocument);
            this.panelControl1.Controls.Add(this.fld_grdDocumentSearchResult);
            this.panelControl1.Controls.Add(this.bosLabel2);
            this.panelControl1.Controls.Add(this.fld_dteSearchFromMEEmrDocumentCreatedDate);
            this.panelControl1.Controls.Add(this.bosLabel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Screen = null;
            this.panelControl1.Size = new System.Drawing.Size(957, 620);
            this.panelControl1.TabIndex = 1000000025;
            // 
            // DMDOCMANLOSTDOC
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(957, 620);
            this.ControlBox = true;
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DMDOCMANLOSTDOC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tờ bệnh án không tìm thấy trên FTP";
            this.Load += new System.EventHandler(this.guiSearchDocument_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_grdDocumentSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchToMEEmrDocumentCreatedDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchToMEEmrDocumentCreatedDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchFromMEEmrDocumentCreatedDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchFromMEEmrDocumentCreatedDate.Properties)).EndInit();
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
        private BOSComponent.BOSDateEdit fld_dteSearchToMEEmrDocumentCreatedDate;
        private BOSComponent.BOSDateEdit fld_dteSearchFromMEEmrDocumentCreatedDate;
        private BOSComponent.BOSLabel bosLabel2;
        private BOSPanel panelControl1;
    }
}
