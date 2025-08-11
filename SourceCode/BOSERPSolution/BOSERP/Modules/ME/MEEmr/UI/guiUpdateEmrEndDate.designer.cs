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
    partial class guiUpdateEmrEndDate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiUpdateEmrEndDate));
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnBoldRemove = new DevExpress.XtraEditors.CheckButton();
            this.btnUnderlineRemove = new DevExpress.XtraEditors.CheckButton();
            this.btnItalicRemove = new DevExpress.XtraEditors.CheckButton();
            this.bosLabel2 = new BOSComponent.BOSLabel(this.components);
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1 = new BOSComponent.BOSDateEdit(this.components);
            this.guiUpdateEmrEndDate_btnOk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(387, 46);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 29);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Không cập nhật";
            this.btnCancel.Click += new System.EventHandler(this.guiUpdateEmrEndDate_btnCancel_Click);
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
            this.bosLabel2.Location = new System.Drawing.Point(12, 15);
            this.bosLabel2.Name = "bosLabel2";
            this.bosLabel2.Screen = null;
            this.bosLabel2.Size = new System.Drawing.Size(77, 19);
            this.bosLabel2.TabIndex = 44;
            this.bosLabel2.Tag = "";
            this.bosLabel2.Text = "Ngày đóng";
            // 
            // guiUpdateEmrEndDate_fld_dteAACreatedDate1
            // 
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.BOSComment = "";
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.BOSDataMember = "MEEmrEndDate";
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.BOSDataSource = "MEEmrs";
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.BOSDescription = null;
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.BOSError = null;
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.BOSFieldGroup = "";
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.BOSFieldRelation = "";
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.BOSPrivilege = "";
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.BOSPropertyName = "EditValue";
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.EditValue = null;
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.Enabled = false;
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.Location = new System.Drawing.Point(113, 12);
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.Name = "guiUpdateEmrEndDate_fld_dteAACreatedDate1";
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.Properties.Appearance.Options.UseBackColor = true;
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.Properties.Appearance.Options.UseForeColor = true;
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.Screen = null;
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.Size = new System.Drawing.Size(414, 26);
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.TabIndex = 45;
            this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.Tag = "DC";
            // 
            // guiUpdateEmrEndDate_btnOk
            // 
            this.guiUpdateEmrEndDate_btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guiUpdateEmrEndDate_btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("guiUpdateEmrEndDate_btnOk.ImageOptions.Image")));
            this.guiUpdateEmrEndDate_btnOk.Location = new System.Drawing.Point(266, 46);
            this.guiUpdateEmrEndDate_btnOk.Name = "guiUpdateEmrEndDate_btnOk";
            this.guiUpdateEmrEndDate_btnOk.Size = new System.Drawing.Size(115, 29);
            this.guiUpdateEmrEndDate_btnOk.TabIndex = 46;
            this.guiUpdateEmrEndDate_btnOk.Text = "Cập nhật";
            this.guiUpdateEmrEndDate_btnOk.Click += new System.EventHandler(this.guiUpdateEmrEndDate_btnOk_Click);
            // 
            // guiUpdateEmrEndDate
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(539, 87);
            this.ControlBox = true;
            this.Controls.Add(this.guiUpdateEmrEndDate_btnOk);
            this.Controls.Add(this.guiUpdateEmrEndDate_fld_dteAACreatedDate1);
            this.Controls.Add(this.bosLabel2);
            this.Controls.Add(this.btnCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiUpdateEmrEndDate";
            this.Text = "Cập nhật ngày đóng bệnh án";
            this.Load += new System.EventHandler(this.guiUpdateEmrEndDate_Load);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.bosLabel2, 0);
            this.Controls.SetChildIndex(this.guiUpdateEmrEndDate_fld_dteAACreatedDate1, 0);
            this.Controls.SetChildIndex(this.guiUpdateEmrEndDate_btnOk, 0);
            ((System.ComponentModel.ISupportInitialize)(this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guiUpdateEmrEndDate_fld_dteAACreatedDate1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private IContainer components;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.CheckButton btnBoldRemove;
        private DevExpress.XtraEditors.CheckButton btnUnderlineRemove;
        private DevExpress.XtraEditors.CheckButton btnItalicRemove;
        private BOSLabel bosLabel2;
        private BOSDateEdit guiUpdateEmrEndDate_fld_dteAACreatedDate1;
        private DevExpress.XtraEditors.SimpleButton guiUpdateEmrEndDate_btnOk;
    }
}
