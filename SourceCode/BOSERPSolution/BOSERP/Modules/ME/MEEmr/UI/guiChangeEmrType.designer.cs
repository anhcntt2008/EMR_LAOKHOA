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
    partial class guiChangeEmrType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiChangeEmrType));
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnBoldRemove = new DevExpress.XtraEditors.CheckButton();
            this.btnUnderlineRemove = new DevExpress.XtraEditors.CheckButton();
            this.btnItalicRemove = new DevExpress.XtraEditors.CheckButton();
            this.lblEmrType = new BOSComponent.BOSLabel(this.components);
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr = new BOSComponent.BOSLookupEdit(this.components);
            this.grcDocumentGroupMapping = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bosLabel2 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel3 = new BOSComponent.BOSLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_MEEmrTypeID_ChangeEmr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcDocumentGroupMapping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.Location = new System.Drawing.Point(602, 534);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(151, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Đổi loại bệnh án (Alt+O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(759, 533);
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
            // lblEmrType
            // 
            this.lblEmrType.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblEmrType.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEmrType.Appearance.Options.UseBackColor = true;
            this.lblEmrType.Appearance.Options.UseForeColor = true;
            this.lblEmrType.BOSComment = "";
            this.lblEmrType.BOSDataMember = "";
            this.lblEmrType.BOSDataSource = "";
            this.lblEmrType.BOSDescription = null;
            this.lblEmrType.BOSError = null;
            this.lblEmrType.BOSFieldGroup = "";
            this.lblEmrType.BOSFieldRelation = "";
            this.lblEmrType.BOSPrivilege = "";
            this.lblEmrType.BOSPropertyName = "";
            this.lblEmrType.Location = new System.Drawing.Point(24, 15);
            this.lblEmrType.Name = "lblEmrType";
            this.lblEmrType.Screen = null;
            this.lblEmrType.Size = new System.Drawing.Size(80, 13);
            this.lblEmrType.TabIndex = 23;
            this.lblEmrType.Tag = "";
            this.lblEmrType.Text = "Loại bệnh án mới";
            // 
            // fld_lkeFK_MEEmrTypeID_ChangeEmr
            // 
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.BOSAllowAddNew = false;
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.BOSAllowDummy = false;
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.BOSComment = "";
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.BOSDataMember = "FK_MEEmrTypeID";
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.BOSDataSource = "MEEmrTypeTemplates";
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.BOSDescription = null;
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.BOSDummyText = null;
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.BOSError = null;
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.BOSFieldGroup = "";
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.BOSFieldParent = "";
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.BOSFieldRelation = "";
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.BOSPrivilege = "";
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.BOSPropertyName = "EditValue";
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.BOSSelectType = "";
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.BOSSelectTypeValue = "";
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.CurrentDisplayText = null;
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.Location = new System.Drawing.Point(119, 12);
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.Name = "fld_lkeFK_MEEmrTypeID_ChangeEmr";
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MEEmrTypeNo", "Mã loại"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MEEmrTypeName", "Tên loại")});
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.Properties.DisplayMember = "MEEmrTypeName";
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.Properties.NullText = "";
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.Properties.PopupWidth = 40;
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.Properties.ValueMember = "MEEmrTypeID";
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.Screen = null;
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.Size = new System.Drawing.Size(441, 20);
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.TabIndex = 22;
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.Tag = "DC";
            this.fld_lkeFK_MEEmrTypeID_ChangeEmr.EditValueChanged += new System.EventHandler(this.fld_lkeFK_MEEmrTypeID_ChangeEmr_EditValueChanged);
            // 
            // grcDocumentGroupMapping
            // 
            this.grcDocumentGroupMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grcDocumentGroupMapping.Location = new System.Drawing.Point(3, 62);
            this.grcDocumentGroupMapping.MainView = this.gridView1;
            this.grcDocumentGroupMapping.MenuManager = this.screenToolbar;
            this.grcDocumentGroupMapping.Name = "grcDocumentGroupMapping";
            this.grcDocumentGroupMapping.Size = new System.Drawing.Size(840, 465);
            this.grcDocumentGroupMapping.TabIndex = 24;
            this.grcDocumentGroupMapping.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grcDocumentGroupMapping;
            this.gridView1.Name = "gridView1";
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
            this.bosLabel2.Location = new System.Drawing.Point(6, 43);
            this.bosLabel2.Name = "bosLabel2";
            this.bosLabel2.Screen = null;
            this.bosLabel2.Size = new System.Drawing.Size(236, 13);
            this.bosLabel2.TabIndex = 25;
            this.bosLabel2.Tag = "";
            this.bosLabel2.Text = "Thực hiện ánh xạ gáy bệnh án cũ -> bệnh án mới";
            // 
            // bosLabel3
            // 
            this.bosLabel3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel3.Appearance.ForeColor = System.Drawing.Color.Gray;
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
            this.bosLabel3.Location = new System.Drawing.Point(6, 539);
            this.bosLabel3.Name = "bosLabel3";
            this.bosLabel3.Screen = null;
            this.bosLabel3.Size = new System.Drawing.Size(360, 13);
            this.bosLabel3.TabIndex = 26;
            this.bosLabel3.Tag = "";
            this.bosLabel3.Text = "Chỉ thay đổi gáy các tờ bệnh án, KHÔNG thay đổi được thứ tự tờ trong gáy";
            // 
            // guiChangeEmrType
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(844, 561);
            this.ControlBox = true;
            this.Controls.Add(this.bosLabel3);
            this.Controls.Add(this.bosLabel2);
            this.Controls.Add(this.grcDocumentGroupMapping);
            this.Controls.Add(this.lblEmrType);
            this.Controls.Add(this.fld_lkeFK_MEEmrTypeID_ChangeEmr);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiChangeEmrType";
            this.Text = "Đổi loại bệnh án";
            this.Load += new System.EventHandler(this.DSMEEMR100_Load);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.fld_lkeFK_MEEmrTypeID_ChangeEmr, 0);
            this.Controls.SetChildIndex(this.lblEmrType, 0);
            this.Controls.SetChildIndex(this.grcDocumentGroupMapping, 0);
            this.Controls.SetChildIndex(this.bosLabel2, 0);
            this.Controls.SetChildIndex(this.bosLabel3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_MEEmrTypeID_ChangeEmr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcDocumentGroupMapping)).EndInit();
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
        private BOSLabel lblEmrType;
        private BOSLookupEdit fld_lkeFK_MEEmrTypeID_ChangeEmr;
        private DevExpress.XtraGrid.GridControl grcDocumentGroupMapping;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private BOSLabel bosLabel2;
        private BOSLabel bosLabel3;
    }
}
