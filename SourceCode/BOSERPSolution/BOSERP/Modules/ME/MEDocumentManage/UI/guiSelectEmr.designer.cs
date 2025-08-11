using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSComponent;

namespace BOSERP.Modules.MEDocumentManage.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    partial class guiSelectEmr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiSelectEmr));
            this.btnBoldRemove = new DevExpress.XtraEditors.CheckButton();
            this.btnUnderlineRemove = new DevExpress.XtraEditors.CheckButton();
            this.btnItalicRemove = new DevExpress.XtraEditors.CheckButton();
            this.fld_dgcEmrs = new BOSERP.Modules.MEDocumentManage.MEEmrsGridControl();
            this.fld_dgvMEEmrs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_lblLabel9 = new BOSComponent.BOSLabel(this.components);
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcEmrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBoldRemove
            // 
            this.btnBoldRemove.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnBoldRemove.Appearance.Options.UseFont = true;
            this.btnBoldRemove.Location = new System.Drawing.Point(2, 170);
            this.btnBoldRemove.Name = "btnBoldRemove";
            this.btnBoldRemove.Size = new System.Drawing.Size(97, 22);
            this.btnBoldRemove.TabIndex = 16;
            this.btnBoldRemove.Text = "Bold";
            // 
            // btnUnderlineRemove
            // 
            this.btnUnderlineRemove.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.btnUnderlineRemove.Appearance.Options.UseFont = true;
            this.btnUnderlineRemove.Location = new System.Drawing.Point(214, 156);
            this.btnUnderlineRemove.Name = "btnUnderlineRemove";
            this.btnUnderlineRemove.Size = new System.Drawing.Size(98, 22);
            this.btnUnderlineRemove.TabIndex = 18;
            this.btnUnderlineRemove.Text = "Underline";
            // 
            // btnItalicRemove
            // 
            this.btnItalicRemove.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.btnItalicRemove.Appearance.Options.UseFont = true;
            this.btnItalicRemove.Location = new System.Drawing.Point(113, 156);
            this.btnItalicRemove.Name = "btnItalicRemove";
            this.btnItalicRemove.Size = new System.Drawing.Size(97, 22);
            this.btnItalicRemove.TabIndex = 17;
            this.btnItalicRemove.Text = "Italic";
            // 
            // fld_dgcEmrs
            // 
            this.fld_dgcEmrs.AllowDrop = true;
            this.fld_dgcEmrs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcEmrs.BOSComment = "";
            this.fld_dgcEmrs.BOSDataMember = "";
            this.fld_dgcEmrs.BOSDataSource = "MEEmrs";
            this.fld_dgcEmrs.BOSDescription = null;
            this.fld_dgcEmrs.BOSError = null;
            this.fld_dgcEmrs.BOSFieldGroup = "";
            this.fld_dgcEmrs.BOSFieldRelation = "";
            this.fld_dgcEmrs.BOSGridType = null;
            this.fld_dgcEmrs.BOSPrivilege = "";
            this.fld_dgcEmrs.BOSPropertyName = "";
            this.fld_dgcEmrs.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcEmrs.Location = new System.Drawing.Point(1, 75);
            this.fld_dgcEmrs.MainView = this.fld_dgvMEEmrs;
            this.fld_dgcEmrs.Name = "fld_dgcEmrs";
            this.fld_dgcEmrs.PrintReport = false;
            this.fld_dgcEmrs.Screen = null;
            this.fld_dgcEmrs.Size = new System.Drawing.Size(849, 522);
            this.fld_dgcEmrs.TabIndex = 1000000003;
            this.fld_dgcEmrs.Tag = "DC";
            this.fld_dgcEmrs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvMEEmrs});
            // 
            // fld_dgvMEEmrs
            // 
            this.fld_dgvMEEmrs.GridControl = this.fld_dgcEmrs;
            this.fld_dgvMEEmrs.Name = "fld_dgvMEEmrs";
            this.fld_dgvMEEmrs.PaintStyleName = "Office2003";
            // 
            // fld_lblLabel9
            // 
            this.fld_lblLabel9.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel9.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel9.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel9.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel9.BOSComment = "";
            this.fld_lblLabel9.BOSDataMember = "";
            this.fld_lblLabel9.BOSDataSource = "";
            this.fld_lblLabel9.BOSDescription = null;
            this.fld_lblLabel9.BOSError = null;
            this.fld_lblLabel9.BOSFieldGroup = "";
            this.fld_lblLabel9.BOSFieldRelation = "";
            this.fld_lblLabel9.BOSPrivilege = "";
            this.fld_lblLabel9.BOSPropertyName = "";
            this.fld_lblLabel9.Location = new System.Drawing.Point(12, 12);
            this.fld_lblLabel9.Name = "fld_lblLabel9";
            this.fld_lblLabel9.Screen = null;
            this.fld_lblLabel9.Size = new System.Drawing.Size(305, 57);
            this.fld_lblLabel9.TabIndex = 1000000004;
            this.fld_lblLabel9.Tag = "";
            this.fld_lblLabel9.Text = "Danh sách bệnh án có ký số. \r\nVui lòng thực hiện lại ký số.\r\nLưu lại thông tin = " +
            "thao tác Export dữ liệu.";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnOk.Location = new System.Drawing.Point(741, 603);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(98, 29);
            this.btnOk.TabIndex = 1000000005;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // guiSelectEmr
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(851, 635);
            this.ControlBox = true;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.fld_lblLabel9);
            this.Controls.Add(this.fld_dgcEmrs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiSelectEmr";
            this.Text = "Thông báo";
            this.Load += new System.EventHandler(this.guiSelectEmr_Load);
            this.Controls.SetChildIndex(this.fld_dgcEmrs, 0);
            this.Controls.SetChildIndex(this.fld_lblLabel9, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcEmrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private IContainer components;
        private DevExpress.XtraEditors.CheckButton btnBoldRemove;
        private DevExpress.XtraEditors.CheckButton btnUnderlineRemove;
        private DevExpress.XtraEditors.CheckButton btnItalicRemove;
        private MEEmrsGridControl fld_dgcEmrs;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvMEEmrs;
        private BOSLabel fld_lblLabel9;
        private DevExpress.XtraEditors.SimpleButton btnOk;
    }
}
