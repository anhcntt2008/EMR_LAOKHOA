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
    /// Summary description for DSMEEMR100
    /// </summary>
    partial class guiDocumentNoteList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiDocumentNoteList));
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnBoldRemove = new DevExpress.XtraEditors.CheckButton();
            this.btnUnderlineRemove = new DevExpress.XtraEditors.CheckButton();
            this.btnItalicRemove = new DevExpress.XtraEditors.CheckButton();
            this.fld_dgcMEEmrDocumentNotes = new BOSERP.Modules.MEEmr.MEEmrDocumentNotesGridControl();
            this.fld_dgvMEEmrTransferHistories = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrDocumentNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrTransferHistories)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.Location = new System.Drawing.Point(327, 484);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(149, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Đi đến nội dung (Ctrl+G)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(482, 483);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Đóng";
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
            // fld_dgcMEEmrDocumentNotes
            // 
            this.fld_dgcMEEmrDocumentNotes.AllowDrop = true;
            this.fld_dgcMEEmrDocumentNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcMEEmrDocumentNotes.BOSComment = "";
            this.fld_dgcMEEmrDocumentNotes.BOSDataMember = "";
            this.fld_dgcMEEmrDocumentNotes.BOSDataSource = "MEEmrDocumentNotes";
            this.fld_dgcMEEmrDocumentNotes.BOSDescription = null;
            this.fld_dgcMEEmrDocumentNotes.BOSError = null;
            this.fld_dgcMEEmrDocumentNotes.BOSFieldGroup = "";
            this.fld_dgcMEEmrDocumentNotes.BOSFieldRelation = "";
            this.fld_dgcMEEmrDocumentNotes.BOSGridType = null;
            this.fld_dgcMEEmrDocumentNotes.BOSPrivilege = "";
            this.fld_dgcMEEmrDocumentNotes.BOSPropertyName = "";
            this.fld_dgcMEEmrDocumentNotes.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMEEmrDocumentNotes.Location = new System.Drawing.Point(3, 3);
            this.fld_dgcMEEmrDocumentNotes.MainView = this.fld_dgvMEEmrTransferHistories;
            this.fld_dgcMEEmrDocumentNotes.Name = "fld_dgcMEEmrDocumentNotes";
            this.fld_dgcMEEmrDocumentNotes.PrintReport = false;
            this.fld_dgcMEEmrDocumentNotes.Screen = null;
            this.fld_dgcMEEmrDocumentNotes.Size = new System.Drawing.Size(560, 475);
            this.fld_dgcMEEmrDocumentNotes.TabIndex = 1000000004;
            this.fld_dgcMEEmrDocumentNotes.Tag = "DC";
            this.fld_dgcMEEmrDocumentNotes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvMEEmrTransferHistories});
            // 
            // fld_dgvMEEmrTransferHistories
            // 
            this.fld_dgvMEEmrTransferHistories.GridControl = this.fld_dgcMEEmrDocumentNotes;
            this.fld_dgvMEEmrTransferHistories.Name = "fld_dgvMEEmrTransferHistories";
            this.fld_dgvMEEmrTransferHistories.PaintStyleName = "Office2003";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(87, 489);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(234, 13);
            this.labelControl1.TabIndex = 1000000005;
            this.labelControl1.Text = "Double click các dòng ghi chú để đến vị trí trên tờ";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(3, 484);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(70, 23);
            this.btnRefresh.TabIndex = 1000000006;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // guiDocumentNoteList
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(567, 511);
            this.ControlBox = true;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.fld_dgcMEEmrDocumentNotes);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiDocumentNoteList";
            this.Text = "Ghi chú tờ bệnh án";
            this.Load += new System.EventHandler(this.DSMEEMR100_Load);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.fld_dgcMEEmrDocumentNotes, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.btnRefresh, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrDocumentNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrTransferHistories)).EndInit();
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
        private MEEmrDocumentNotesGridControl fld_dgcMEEmrDocumentNotes;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvMEEmrTransferHistories;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
    }
}
