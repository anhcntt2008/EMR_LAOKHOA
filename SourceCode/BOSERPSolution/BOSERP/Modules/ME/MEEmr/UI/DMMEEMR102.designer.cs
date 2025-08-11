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
    partial class DMMEEMR102
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMMEEMR102));
            this.fld_btnRefreshAchiveHistory = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new BOSComponent.BOSPanel(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.fld_dgcMEEmrArchives = new BOSERP.Modules.MEEmr.MEEmrArchiveGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pdfViewerEmrArchive = new DevExpress.XtraPdfViewer.PdfViewer();
            this.xtraUserControl1 = new DevExpress.XtraEditors.XtraUserControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrArchives)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_btnRefreshAchiveHistory
            // 
            this.fld_btnRefreshAchiveHistory.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("fld_btnRefreshAchiveHistory.ImageOptions.Image")));
            this.fld_btnRefreshAchiveHistory.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.fld_btnRefreshAchiveHistory.Location = new System.Drawing.Point(3, 3);
            this.fld_btnRefreshAchiveHistory.Name = "fld_btnRefreshAchiveHistory";
            this.fld_btnRefreshAchiveHistory.Size = new System.Drawing.Size(86, 23);
            this.fld_btnRefreshAchiveHistory.TabIndex = 1;
            this.fld_btnRefreshAchiveHistory.Text = "Làm mới";
            this.fld_btnRefreshAchiveHistory.Click += new System.EventHandler(this.fld_btnRefreshAchiveHistory_Click);
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
            this.panelControl1.Controls.Add(this.splitContainerControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Screen = null;
            this.panelControl1.Size = new System.Drawing.Size(975, 637);
            this.panelControl1.TabIndex = 0;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.fld_dgcMEEmrArchives);
            this.splitContainerControl1.Panel1.Controls.Add(this.fld_btnRefreshAchiveHistory);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.pdfViewerEmrArchive);
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraUserControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(975, 637);
            this.splitContainerControl1.SplitterPosition = 330;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // fld_dgcMEEmrArchives
            // 
            this.fld_dgcMEEmrArchives.AllowDrop = true;
            this.fld_dgcMEEmrArchives.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcMEEmrArchives.BOSComment = "";
            this.fld_dgcMEEmrArchives.BOSDataMember = "";
            this.fld_dgcMEEmrArchives.BOSDataSource = "MEEmrArchives";
            this.fld_dgcMEEmrArchives.BOSDescription = null;
            this.fld_dgcMEEmrArchives.BOSError = null;
            this.fld_dgcMEEmrArchives.BOSFieldGroup = "";
            this.fld_dgcMEEmrArchives.BOSFieldRelation = "";
            this.fld_dgcMEEmrArchives.BOSGridType = null;
            this.fld_dgcMEEmrArchives.BOSPrivilege = "";
            this.fld_dgcMEEmrArchives.BOSPropertyName = "";
            this.fld_dgcMEEmrArchives.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMEEmrArchives.Location = new System.Drawing.Point(3, 32);
            this.fld_dgcMEEmrArchives.MainView = this.gridView1;
            this.fld_dgcMEEmrArchives.Name = "fld_dgcMEEmrArchives";
            this.fld_dgcMEEmrArchives.PrintReport = false;
            this.fld_dgcMEEmrArchives.Screen = null;
            this.fld_dgcMEEmrArchives.Size = new System.Drawing.Size(326, 602);
            this.fld_dgcMEEmrArchives.TabIndex = 12;
            this.fld_dgcMEEmrArchives.Tag = "DC";
            this.fld_dgcMEEmrArchives.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcMEEmrArchives;
            this.gridView1.Name = "gridView1";
            this.gridView1.PaintStyleName = "Office2003";
            // 
            // pdfViewer1
            // 
            this.pdfViewerEmrArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfViewerEmrArchive.Location = new System.Drawing.Point(0, 32);
            this.pdfViewerEmrArchive.Name = "pdfViewer1";
            this.pdfViewerEmrArchive.Size = new System.Drawing.Size(637, 602);
            this.pdfViewerEmrArchive.TabIndex = 1;
            // 
            // xtraUserControl1
            // 
            this.xtraUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraUserControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraUserControl1.Name = "xtraUserControl1";
            this.xtraUserControl1.Size = new System.Drawing.Size(640, 637);
            this.xtraUserControl1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DarkGray;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(96, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(186, 13);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Bấm làm mới để lấy danh sách mới nhất";
            // 
            // DMMEEMR102
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(650, 637);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DMMEEMR102";
            this.Text = "Lưu trữ";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrArchives)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private IContainer components;
        private DevExpress.XtraEditors.SimpleButton fld_btnRefreshAchiveHistory;
        private BOSPanel panelControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private MEEmrArchiveGridControl fld_dgcMEEmrArchives;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.XtraUserControl xtraUserControl1;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewerEmrArchive;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
