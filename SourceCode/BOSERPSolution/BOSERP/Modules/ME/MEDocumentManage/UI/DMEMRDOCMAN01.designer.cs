using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSComponent;

namespace BOSERP.Modules.MEDocumentManage.UI
{
    partial class DMEMRDOCMAN01
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMEMRDOCMAN01));
            this.panelControl1 = new BOSComponent.BOSPanel(this.components);
            this.btnReleaseDocument = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fld_btnRefreshDocument = new DevExpress.XtraEditors.SimpleButton();
            this.fld_dgcMEEmrDocumentsMan01 = new BOSERP.Modules.MEDocumentManage.MEEmrDocumentSelectionGridControl();
            this.fld_dgvMEEmrDocumentsMan01 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bosLabel1 = new BOSComponent.BOSLabel(this.components);
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrDocumentsMan01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrDocumentsMan01)).BeginInit();
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
            this.panelControl1.Controls.Add(this.btnReleaseDocument);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.fld_btnRefreshDocument);
            this.panelControl1.Controls.Add(this.fld_dgcMEEmrDocumentsMan01);
            this.panelControl1.Controls.Add(this.bosLabel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Screen = null;
            this.panelControl1.Size = new System.Drawing.Size(826, 530);
            this.panelControl1.TabIndex = 0;
            // 
            // btnReleaseDocument
            // 
            this.btnReleaseDocument.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnReleaseDocument.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnReleaseDocument.Location = new System.Drawing.Point(6, 5);
            this.btnReleaseDocument.Name = "btnReleaseDocument";
            this.btnReleaseDocument.Size = new System.Drawing.Size(96, 23);
            this.btnReleaseDocument.TabIndex = 1000000027;
            this.btnReleaseDocument.Text = "Giải phóng tờ";
            this.btnReleaseDocument.Click += new System.EventHandler(this.btnReleaseDocument_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DarkGray;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(200, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(186, 13);
            this.labelControl1.TabIndex = 1000000026;
            this.labelControl1.Text = "Bấm làm mới để lấy danh sách mới nhất";
            // 
            // fld_btnRefreshDocument
            // 
            this.fld_btnRefreshDocument.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("fld_btnRefreshDocument.ImageOptions.Image")));
            this.fld_btnRefreshDocument.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.fld_btnRefreshDocument.Location = new System.Drawing.Point(108, 5);
            this.fld_btnRefreshDocument.Name = "fld_btnRefreshDocument";
            this.fld_btnRefreshDocument.Size = new System.Drawing.Size(86, 23);
            this.fld_btnRefreshDocument.TabIndex = 1000000025;
            this.fld_btnRefreshDocument.Text = "Làm mới";
            this.fld_btnRefreshDocument.Click += new System.EventHandler(this.fld_btnRefreshDocument_Click);
            // 
            // fld_dgcMEEmrDocumentsMan01
            // 
            this.fld_dgcMEEmrDocumentsMan01.AllowDrop = true;
            this.fld_dgcMEEmrDocumentsMan01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcMEEmrDocumentsMan01.BOSComment = "";
            this.fld_dgcMEEmrDocumentsMan01.BOSDataMember = "";
            this.fld_dgcMEEmrDocumentsMan01.BOSDataSource = "MEEmrDocuments";
            this.fld_dgcMEEmrDocumentsMan01.BOSDescription = null;
            this.fld_dgcMEEmrDocumentsMan01.BOSError = null;
            this.fld_dgcMEEmrDocumentsMan01.BOSFieldGroup = "";
            this.fld_dgcMEEmrDocumentsMan01.BOSFieldRelation = "";
            this.fld_dgcMEEmrDocumentsMan01.BOSGridType = null;
            this.fld_dgcMEEmrDocumentsMan01.BOSPrivilege = "";
            this.fld_dgcMEEmrDocumentsMan01.BOSPropertyName = "";
            this.fld_dgcMEEmrDocumentsMan01.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMEEmrDocumentsMan01.Location = new System.Drawing.Point(3, 32);
            this.fld_dgcMEEmrDocumentsMan01.MainView = this.fld_dgvMEEmrDocumentsMan01;
            this.fld_dgcMEEmrDocumentsMan01.Name = "fld_dgcMEEmrDocumentsMan01";
            this.fld_dgcMEEmrDocumentsMan01.PrintReport = false;
            this.fld_dgcMEEmrDocumentsMan01.Screen = null;
            this.fld_dgcMEEmrDocumentsMan01.Size = new System.Drawing.Size(820, 495);
            this.fld_dgcMEEmrDocumentsMan01.TabIndex = 1000000024;
            this.fld_dgcMEEmrDocumentsMan01.Tag = "DC";
            this.fld_dgcMEEmrDocumentsMan01.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvMEEmrDocumentsMan01});
            // 
            // fld_dgvMEEmrDocumentsMan01
            // 
            this.fld_dgvMEEmrDocumentsMan01.GridControl = this.fld_dgcMEEmrDocumentsMan01;
            this.fld_dgvMEEmrDocumentsMan01.Name = "fld_dgvMEEmrDocumentsMan01";
            this.fld_dgvMEEmrDocumentsMan01.PaintStyleName = "Office2003";
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
            this.bosLabel1.Location = new System.Drawing.Point(495, 97);
            this.bosLabel1.Name = "bosLabel1";
            this.bosLabel1.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel1, true);
            this.bosLabel1.Size = new System.Drawing.Size(4, 13);
            this.bosLabel1.TabIndex = 1000000016;
            this.bosLabel1.Tag = "SI";
            this.bosLabel1.Text = "-";
            // 
            // DMEMRDOCMAN01
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(826, 530);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DMEMRDOCMAN01";
            this.Text = "Danh sách tờ bệnh án";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrDocumentsMan01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrDocumentsMan01)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private IContainer components;
        private BOSPanel panelControl1;
        private MEEmrDocumentSelectionGridControl fld_dgcMEEmrDocumentsMan01;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvMEEmrDocumentsMan01;
        private BOSLabel bosLabel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton fld_btnRefreshDocument;
        private DevExpress.XtraEditors.SimpleButton btnReleaseDocument;
    }
}
