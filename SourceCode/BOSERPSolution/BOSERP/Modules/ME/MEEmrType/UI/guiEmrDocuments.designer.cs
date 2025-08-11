using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSComponent;

namespace BOSERP.Modules.MEEmrType.UI
{
    partial class guiEmrDocuments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiEmrDocuments));
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnBoldRemove = new DevExpress.XtraEditors.CheckButton();
            this.btnUnderlineRemove = new DevExpress.XtraEditors.CheckButton();
            this.btnItalicRemove = new DevExpress.XtraEditors.CheckButton();
            this.grcEmrDocuments = new BOSERP.Modules.MEEmrType.MEEmrDocumentsGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grcEmrDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.Location = new System.Drawing.Point(572, 527);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(179, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Tiếp tục cập nhật gáy (Alt+O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(757, 526);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            // grcEmrDocuments
            // 
            this.grcEmrDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grcEmrDocuments.BOSComment = null;
            this.grcEmrDocuments.BOSDataMember = null;
            this.grcEmrDocuments.BOSDataSource = "MEEmrDocuments";
            this.grcEmrDocuments.BOSDescription = null;
            this.grcEmrDocuments.BOSError = null;
            this.grcEmrDocuments.BOSFieldGroup = null;
            this.grcEmrDocuments.BOSFieldRelation = null;
            this.grcEmrDocuments.BOSGridType = null;
            this.grcEmrDocuments.BOSPrivilege = null;
            this.grcEmrDocuments.BOSPropertyName = null;
            this.grcEmrDocuments.Location = new System.Drawing.Point(3, 4);
            this.grcEmrDocuments.MainView = this.gridView1;
            this.grcEmrDocuments.MenuManager = this.screenToolbar;
            this.grcEmrDocuments.Name = "grcEmrDocuments";
            this.grcEmrDocuments.PrintReport = false;
            this.grcEmrDocuments.Screen = null;
            this.grcEmrDocuments.Size = new System.Drawing.Size(840, 516);
            this.grcEmrDocuments.TabIndex = 24;
            this.grcEmrDocuments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grcEmrDocuments;
            this.gridView1.Name = "gridView1";
            // 
            // guiEmrDocuments
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(844, 561);
            this.ControlBox = true;
            this.Controls.Add(this.grcEmrDocuments);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiEmrDocuments";
            this.Text = "Danh sách bệnh án đang soạn trên máy khác";
            this.Load += new System.EventHandler(this.EmrDocuments_Load);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.grcEmrDocuments, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grcEmrDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private IContainer components;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.CheckButton btnBoldRemove;
        private DevExpress.XtraEditors.CheckButton btnUnderlineRemove;
        private DevExpress.XtraEditors.CheckButton btnItalicRemove;
        private MEEmrDocumentsGridControl grcEmrDocuments;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}
