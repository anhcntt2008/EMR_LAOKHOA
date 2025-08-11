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
    partial class guiUpdateEmrNo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiUpdateEmrNo));
            this.guiUpdateEmrNo_btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnBoldRemove = new DevExpress.XtraEditors.CheckButton();
            this.btnUnderlineRemove = new DevExpress.XtraEditors.CheckButton();
            this.btnItalicRemove = new DevExpress.XtraEditors.CheckButton();
            this.bosLabel1 = new BOSComponent.BOSLabel(this.components);
            this.guiUpdateEmrNo_lblMEEmrNoCurrent = new BOSComponent.BOSLabel(this.components);
            this.bosLabel2 = new BOSComponent.BOSLabel(this.components);
            this.guiUpdateEmrNo_fld_txtMEEmrNo = new BOSComponent.BOSTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.guiUpdateEmrNo_fld_txtMEEmrNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // guiUpdateEmrNo_btnOk
            // 
            this.guiUpdateEmrNo_btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guiUpdateEmrNo_btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("guiUpdateEmrNo_btnOk.ImageOptions.Image")));
            this.guiUpdateEmrNo_btnOk.Location = new System.Drawing.Point(295, 74);
            this.guiUpdateEmrNo_btnOk.Name = "guiUpdateEmrNo_btnOk";
            this.guiUpdateEmrNo_btnOk.Size = new System.Drawing.Size(151, 29);
            this.guiUpdateEmrNo_btnOk.TabIndex = 7;
            this.guiUpdateEmrNo_btnOk.Text = "Cập nhật (Alt+O)";
            this.guiUpdateEmrNo_btnOk.Click += new System.EventHandler(this.guiUpdateEmrNo_btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(452, 74);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.guiUpdateEmrNo_btnCancel_Click);
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
            this.bosLabel1.Location = new System.Drawing.Point(12, 46);
            this.bosLabel1.Name = "bosLabel1";
            this.bosLabel1.Screen = null;
            this.bosLabel1.Size = new System.Drawing.Size(139, 19);
            this.bosLabel1.TabIndex = 24;
            this.bosLabel1.Tag = "";
            this.bosLabel1.Text = "Mã bệnh án hiện tại";
            // 
            // guiUpdateEmrNo_lblMEEmrNoCurrent
            // 
            this.guiUpdateEmrNo_lblMEEmrNoCurrent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guiUpdateEmrNo_lblMEEmrNoCurrent.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.guiUpdateEmrNo_lblMEEmrNoCurrent.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.guiUpdateEmrNo_lblMEEmrNoCurrent.Appearance.Options.UseBackColor = true;
            this.guiUpdateEmrNo_lblMEEmrNoCurrent.Appearance.Options.UseFont = true;
            this.guiUpdateEmrNo_lblMEEmrNoCurrent.Appearance.Options.UseForeColor = true;
            this.guiUpdateEmrNo_lblMEEmrNoCurrent.BOSComment = "";
            this.guiUpdateEmrNo_lblMEEmrNoCurrent.BOSDataMember = "";
            this.guiUpdateEmrNo_lblMEEmrNoCurrent.BOSDataSource = "";
            this.guiUpdateEmrNo_lblMEEmrNoCurrent.BOSDescription = null;
            this.guiUpdateEmrNo_lblMEEmrNoCurrent.BOSError = null;
            this.guiUpdateEmrNo_lblMEEmrNoCurrent.BOSFieldGroup = "";
            this.guiUpdateEmrNo_lblMEEmrNoCurrent.BOSFieldRelation = "";
            this.guiUpdateEmrNo_lblMEEmrNoCurrent.BOSPrivilege = "";
            this.guiUpdateEmrNo_lblMEEmrNoCurrent.BOSPropertyName = "";
            this.guiUpdateEmrNo_lblMEEmrNoCurrent.Location = new System.Drawing.Point(166, 46);
            this.guiUpdateEmrNo_lblMEEmrNoCurrent.Name = "guiUpdateEmrNo_lblMEEmrNoCurrent";
            this.guiUpdateEmrNo_lblMEEmrNoCurrent.Screen = null;
            this.guiUpdateEmrNo_lblMEEmrNoCurrent.Size = new System.Drawing.Size(33, 19);
            this.guiUpdateEmrNo_lblMEEmrNoCurrent.TabIndex = 43;
            this.guiUpdateEmrNo_lblMEEmrNoCurrent.Tag = "";
            this.guiUpdateEmrNo_lblMEEmrNoCurrent.Text = "N/A";
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
            this.bosLabel2.Size = new System.Drawing.Size(114, 19);
            this.bosLabel2.TabIndex = 44;
            this.bosLabel2.Tag = "";
            this.bosLabel2.Text = "Mã bệnh án mới";
            // 
            // guiUpdateEmrNo_fld_txtMEEmrNo
            // 
            this.guiUpdateEmrNo_fld_txtMEEmrNo.BOSComment = "";
            this.guiUpdateEmrNo_fld_txtMEEmrNo.BOSDataMember = "";
            this.guiUpdateEmrNo_fld_txtMEEmrNo.BOSDataSource = "";
            this.guiUpdateEmrNo_fld_txtMEEmrNo.BOSDescription = null;
            this.guiUpdateEmrNo_fld_txtMEEmrNo.BOSError = null;
            this.guiUpdateEmrNo_fld_txtMEEmrNo.BOSFieldGroup = "";
            this.guiUpdateEmrNo_fld_txtMEEmrNo.BOSFieldRelation = "";
            this.guiUpdateEmrNo_fld_txtMEEmrNo.BOSPrivilege = "";
            this.guiUpdateEmrNo_fld_txtMEEmrNo.BOSPropertyName = "Text";
            this.guiUpdateEmrNo_fld_txtMEEmrNo.EditValue = "";
            this.guiUpdateEmrNo_fld_txtMEEmrNo.Location = new System.Drawing.Point(166, 12);
            this.guiUpdateEmrNo_fld_txtMEEmrNo.Name = "guiUpdateEmrNo_fld_txtMEEmrNo";
            this.guiUpdateEmrNo_fld_txtMEEmrNo.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.guiUpdateEmrNo_fld_txtMEEmrNo.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.guiUpdateEmrNo_fld_txtMEEmrNo.Properties.Appearance.Options.UseBackColor = true;
            this.guiUpdateEmrNo_fld_txtMEEmrNo.Properties.Appearance.Options.UseForeColor = true;
            this.guiUpdateEmrNo_fld_txtMEEmrNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.guiUpdateEmrNo_fld_txtMEEmrNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.guiUpdateEmrNo_fld_txtMEEmrNo.Screen = null;
            this.guiUpdateEmrNo_fld_txtMEEmrNo.Size = new System.Drawing.Size(364, 26);
            this.guiUpdateEmrNo_fld_txtMEEmrNo.TabIndex = 42;
            this.guiUpdateEmrNo_fld_txtMEEmrNo.TabStop = false;
            this.guiUpdateEmrNo_fld_txtMEEmrNo.Tag = "DC";
            // 
            // guiUpdateEmrNo
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(539, 115);
            this.ControlBox = true;
            this.Controls.Add(this.bosLabel2);
            this.Controls.Add(this.guiUpdateEmrNo_lblMEEmrNoCurrent);
            this.Controls.Add(this.guiUpdateEmrNo_fld_txtMEEmrNo);
            this.Controls.Add(this.bosLabel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.guiUpdateEmrNo_btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiUpdateEmrNo";
            this.Text = "Đổi mã bệnh án";
            this.Load += new System.EventHandler(this.guiUpdateEmrNo_Load);
            this.Controls.SetChildIndex(this.guiUpdateEmrNo_btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.bosLabel1, 0);
            this.Controls.SetChildIndex(this.guiUpdateEmrNo_fld_txtMEEmrNo, 0);
            this.Controls.SetChildIndex(this.guiUpdateEmrNo_lblMEEmrNoCurrent, 0);
            this.Controls.SetChildIndex(this.bosLabel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.guiUpdateEmrNo_fld_txtMEEmrNo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private IContainer components;
        private DevExpress.XtraEditors.SimpleButton guiUpdateEmrNo_btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.CheckButton btnBoldRemove;
        private DevExpress.XtraEditors.CheckButton btnUnderlineRemove;
        private DevExpress.XtraEditors.CheckButton btnItalicRemove;
        private BOSLabel bosLabel1;
        private BOSLabel guiUpdateEmrNo_lblMEEmrNoCurrent;
        private BOSLabel bosLabel2;
        private BOSTextBox guiUpdateEmrNo_fld_txtMEEmrNo;
    }
}
