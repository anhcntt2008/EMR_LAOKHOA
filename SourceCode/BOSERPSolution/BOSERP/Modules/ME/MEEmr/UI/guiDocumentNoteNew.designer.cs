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
    partial class guiDocumentNoteNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiDocumentNoteNew));
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnBoldRemove = new DevExpress.XtraEditors.CheckButton();
            this.btnUnderlineRemove = new DevExpress.XtraEditors.CheckButton();
            this.btnItalicRemove = new DevExpress.XtraEditors.CheckButton();
            this.fld_lblLabel6 = new BOSComponent.BOSLabel(this.components);
            this.fld_med_DocumentNote_MEEmrDocumentNoteText = new BOSComponent.BOSMemoEdit(this.components);
            this.fld_lke_DocumentNote_FK_HRDepartmentID = new BOSComponent.BOSLookupEdit(this.components);
            this.lblDocumentNote_FK_HRDepartmentID = new BOSComponent.BOSLabel(this.components);
            this.lblDocumentNote_FK_HREmployeeID = new BOSComponent.BOSLabel(this.components);
            this.fld_lke_DocumentNote_FK_HREmployeeID = new BOSComponent.BOSLookupEdit(this.components);
            this.lblDocumentNoteRemark = new BOSComponent.BOSLabel(this.components);
            this.txtDocumentNoteSelectedContent = new BOSComponent.BOSMemoEdit(this.components);
            this.bosLabel1 = new BOSComponent.BOSLabel(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.fld_med_DocumentNote_MEEmrDocumentNoteText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lke_DocumentNote_FK_HRDepartmentID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lke_DocumentNote_FK_HREmployeeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentNoteSelectedContent.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.Location = new System.Drawing.Point(448, 269);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(86, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "OK (Alt+O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(540, 268);
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
            // fld_lblLabel6
            // 
            this.fld_lblLabel6.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel6.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel6.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel6.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel6.BOSComment = "";
            this.fld_lblLabel6.BOSDataMember = "";
            this.fld_lblLabel6.BOSDataSource = "";
            this.fld_lblLabel6.BOSDescription = null;
            this.fld_lblLabel6.BOSError = null;
            this.fld_lblLabel6.BOSFieldGroup = "";
            this.fld_lblLabel6.BOSFieldRelation = "";
            this.fld_lblLabel6.BOSPrivilege = "";
            this.fld_lblLabel6.BOSPropertyName = "";
            this.fld_lblLabel6.Location = new System.Drawing.Point(20, 127);
            this.fld_lblLabel6.Name = "fld_lblLabel6";
            this.fld_lblLabel6.Screen = null;
            this.fld_lblLabel6.Size = new System.Drawing.Size(35, 13);
            this.fld_lblLabel6.TabIndex = 33;
            this.fld_lblLabel6.Tag = "";
            this.fld_lblLabel6.Text = "Ghi chú";
            // 
            // fld_med_DocumentNote_MEEmrDocumentNoteText
            // 
            this.fld_med_DocumentNote_MEEmrDocumentNoteText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_med_DocumentNote_MEEmrDocumentNoteText.BOSComment = "";
            this.fld_med_DocumentNote_MEEmrDocumentNoteText.BOSDataMember = "MEEmrDocumentNoteText";
            this.fld_med_DocumentNote_MEEmrDocumentNoteText.BOSDataSource = "MEEmrDocumentNotes";
            this.fld_med_DocumentNote_MEEmrDocumentNoteText.BOSDescription = null;
            this.fld_med_DocumentNote_MEEmrDocumentNoteText.BOSError = null;
            this.fld_med_DocumentNote_MEEmrDocumentNoteText.BOSFieldGroup = "";
            this.fld_med_DocumentNote_MEEmrDocumentNoteText.BOSFieldRelation = "";
            this.fld_med_DocumentNote_MEEmrDocumentNoteText.BOSPrivilege = "";
            this.fld_med_DocumentNote_MEEmrDocumentNoteText.BOSPropertyName = "Text";
            this.fld_med_DocumentNote_MEEmrDocumentNoteText.EditValue = "";
            this.fld_med_DocumentNote_MEEmrDocumentNoteText.Location = new System.Drawing.Point(95, 126);
            this.fld_med_DocumentNote_MEEmrDocumentNoteText.Name = "fld_med_DocumentNote_MEEmrDocumentNoteText";
            this.fld_med_DocumentNote_MEEmrDocumentNoteText.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_med_DocumentNote_MEEmrDocumentNoteText.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_med_DocumentNote_MEEmrDocumentNoteText.Properties.Appearance.Options.UseBackColor = true;
            this.fld_med_DocumentNote_MEEmrDocumentNoteText.Properties.Appearance.Options.UseForeColor = true;
            this.fld_med_DocumentNote_MEEmrDocumentNoteText.Screen = null;
            this.fld_med_DocumentNote_MEEmrDocumentNoteText.Size = new System.Drawing.Size(520, 137);
            this.fld_med_DocumentNote_MEEmrDocumentNoteText.TabIndex = 1;
            this.fld_med_DocumentNote_MEEmrDocumentNoteText.Tag = "DC";
            // 
            // fld_lke_DocumentNote_FK_HRDepartmentID
            // 
            this.fld_lke_DocumentNote_FK_HRDepartmentID.BOSAllowAddNew = false;
            this.fld_lke_DocumentNote_FK_HRDepartmentID.BOSAllowDummy = true;
            this.fld_lke_DocumentNote_FK_HRDepartmentID.BOSComment = "";
            this.fld_lke_DocumentNote_FK_HRDepartmentID.BOSDataMember = "FK_HRDepartmentID";
            this.fld_lke_DocumentNote_FK_HRDepartmentID.BOSDataSource = "MEEmrDocumentNotes";
            this.fld_lke_DocumentNote_FK_HRDepartmentID.BOSDescription = null;
            this.fld_lke_DocumentNote_FK_HRDepartmentID.BOSDummyText = null;
            this.fld_lke_DocumentNote_FK_HRDepartmentID.BOSError = null;
            this.fld_lke_DocumentNote_FK_HRDepartmentID.BOSFieldGroup = "";
            this.fld_lke_DocumentNote_FK_HRDepartmentID.BOSFieldParent = "";
            this.fld_lke_DocumentNote_FK_HRDepartmentID.BOSFieldRelation = "";
            this.fld_lke_DocumentNote_FK_HRDepartmentID.BOSPrivilege = "";
            this.fld_lke_DocumentNote_FK_HRDepartmentID.BOSPropertyName = "EditValue";
            this.fld_lke_DocumentNote_FK_HRDepartmentID.BOSSelectType = "";
            this.fld_lke_DocumentNote_FK_HRDepartmentID.BOSSelectTypeValue = "";
            this.fld_lke_DocumentNote_FK_HRDepartmentID.CurrentDisplayText = null;
            this.fld_lke_DocumentNote_FK_HRDepartmentID.Enabled = false;
            this.fld_lke_DocumentNote_FK_HRDepartmentID.Location = new System.Drawing.Point(95, 4);
            this.fld_lke_DocumentNote_FK_HRDepartmentID.Name = "fld_lke_DocumentNote_FK_HRDepartmentID";
            this.fld_lke_DocumentNote_FK_HRDepartmentID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lke_DocumentNote_FK_HRDepartmentID.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lke_DocumentNote_FK_HRDepartmentID.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lke_DocumentNote_FK_HRDepartmentID.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lke_DocumentNote_FK_HRDepartmentID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lke_DocumentNote_FK_HRDepartmentID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRDepartmentNo", "Mã khoa", 20, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRDepartmentName", "Tên khoa")});
            this.fld_lke_DocumentNote_FK_HRDepartmentID.Properties.DisplayMember = "HRDepartmentName";
            this.fld_lke_DocumentNote_FK_HRDepartmentID.Properties.NullText = "";
            this.fld_lke_DocumentNote_FK_HRDepartmentID.Properties.PopupWidth = 40;
            this.fld_lke_DocumentNote_FK_HRDepartmentID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lke_DocumentNote_FK_HRDepartmentID.Properties.ValueMember = "HRDepartmentID";
            this.fld_lke_DocumentNote_FK_HRDepartmentID.Screen = null;
            this.fld_lke_DocumentNote_FK_HRDepartmentID.Size = new System.Drawing.Size(242, 20);
            this.fld_lke_DocumentNote_FK_HRDepartmentID.TabIndex = 39;
            this.fld_lke_DocumentNote_FK_HRDepartmentID.Tag = "DC";
            // 
            // lblDocumentNote_FK_HRDepartmentID
            // 
            this.lblDocumentNote_FK_HRDepartmentID.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblDocumentNote_FK_HRDepartmentID.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDocumentNote_FK_HRDepartmentID.Appearance.Options.UseBackColor = true;
            this.lblDocumentNote_FK_HRDepartmentID.Appearance.Options.UseForeColor = true;
            this.lblDocumentNote_FK_HRDepartmentID.BOSComment = "";
            this.lblDocumentNote_FK_HRDepartmentID.BOSDataMember = "";
            this.lblDocumentNote_FK_HRDepartmentID.BOSDataSource = "";
            this.lblDocumentNote_FK_HRDepartmentID.BOSDescription = null;
            this.lblDocumentNote_FK_HRDepartmentID.BOSError = null;
            this.lblDocumentNote_FK_HRDepartmentID.BOSFieldGroup = "";
            this.lblDocumentNote_FK_HRDepartmentID.BOSFieldRelation = "";
            this.lblDocumentNote_FK_HRDepartmentID.BOSPrivilege = "";
            this.lblDocumentNote_FK_HRDepartmentID.BOSPropertyName = "";
            this.lblDocumentNote_FK_HRDepartmentID.Location = new System.Drawing.Point(20, 8);
            this.lblDocumentNote_FK_HRDepartmentID.Name = "lblDocumentNote_FK_HRDepartmentID";
            this.lblDocumentNote_FK_HRDepartmentID.Screen = null;
            this.lblDocumentNote_FK_HRDepartmentID.Size = new System.Drawing.Size(24, 13);
            this.lblDocumentNote_FK_HRDepartmentID.TabIndex = 38;
            this.lblDocumentNote_FK_HRDepartmentID.Tag = "";
            this.lblDocumentNote_FK_HRDepartmentID.Text = "Khoa";
            // 
            // lblDocumentNote_FK_HREmployeeID
            // 
            this.lblDocumentNote_FK_HREmployeeID.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblDocumentNote_FK_HREmployeeID.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDocumentNote_FK_HREmployeeID.Appearance.Options.UseBackColor = true;
            this.lblDocumentNote_FK_HREmployeeID.Appearance.Options.UseForeColor = true;
            this.lblDocumentNote_FK_HREmployeeID.BOSComment = "";
            this.lblDocumentNote_FK_HREmployeeID.BOSDataMember = "";
            this.lblDocumentNote_FK_HREmployeeID.BOSDataSource = "";
            this.lblDocumentNote_FK_HREmployeeID.BOSDescription = null;
            this.lblDocumentNote_FK_HREmployeeID.BOSError = null;
            this.lblDocumentNote_FK_HREmployeeID.BOSFieldGroup = "";
            this.lblDocumentNote_FK_HREmployeeID.BOSFieldRelation = "";
            this.lblDocumentNote_FK_HREmployeeID.BOSPrivilege = "";
            this.lblDocumentNote_FK_HREmployeeID.BOSPropertyName = "";
            this.lblDocumentNote_FK_HREmployeeID.Location = new System.Drawing.Point(19, 34);
            this.lblDocumentNote_FK_HREmployeeID.Name = "lblDocumentNote_FK_HREmployeeID";
            this.lblDocumentNote_FK_HREmployeeID.Screen = null;
            this.lblDocumentNote_FK_HREmployeeID.Size = new System.Drawing.Size(45, 13);
            this.lblDocumentNote_FK_HREmployeeID.TabIndex = 42;
            this.lblDocumentNote_FK_HREmployeeID.Tag = "";
            this.lblDocumentNote_FK_HREmployeeID.Text = "Người ghi";
            // 
            // fld_lke_DocumentNote_FK_HREmployeeID
            // 
            this.fld_lke_DocumentNote_FK_HREmployeeID.BOSAllowAddNew = false;
            this.fld_lke_DocumentNote_FK_HREmployeeID.BOSAllowDummy = true;
            this.fld_lke_DocumentNote_FK_HREmployeeID.BOSComment = "";
            this.fld_lke_DocumentNote_FK_HREmployeeID.BOSDataMember = "FK_HREmployeeID";
            this.fld_lke_DocumentNote_FK_HREmployeeID.BOSDataSource = "MEEmrDocumentNotes";
            this.fld_lke_DocumentNote_FK_HREmployeeID.BOSDescription = null;
            this.fld_lke_DocumentNote_FK_HREmployeeID.BOSDummyText = null;
            this.fld_lke_DocumentNote_FK_HREmployeeID.BOSError = null;
            this.fld_lke_DocumentNote_FK_HREmployeeID.BOSFieldGroup = "";
            this.fld_lke_DocumentNote_FK_HREmployeeID.BOSFieldParent = "";
            this.fld_lke_DocumentNote_FK_HREmployeeID.BOSFieldRelation = "";
            this.fld_lke_DocumentNote_FK_HREmployeeID.BOSPrivilege = "";
            this.fld_lke_DocumentNote_FK_HREmployeeID.BOSPropertyName = "EditValue";
            this.fld_lke_DocumentNote_FK_HREmployeeID.BOSSelectType = "";
            this.fld_lke_DocumentNote_FK_HREmployeeID.BOSSelectTypeValue = "";
            this.fld_lke_DocumentNote_FK_HREmployeeID.CurrentDisplayText = null;
            this.fld_lke_DocumentNote_FK_HREmployeeID.Enabled = false;
            this.fld_lke_DocumentNote_FK_HREmployeeID.Location = new System.Drawing.Point(96, 31);
            this.fld_lke_DocumentNote_FK_HREmployeeID.Name = "fld_lke_DocumentNote_FK_HREmployeeID";
            this.fld_lke_DocumentNote_FK_HREmployeeID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lke_DocumentNote_FK_HREmployeeID.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lke_DocumentNote_FK_HREmployeeID.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lke_DocumentNote_FK_HREmployeeID.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lke_DocumentNote_FK_HREmployeeID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lke_DocumentNote_FK_HREmployeeID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HREmployeeNo", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HREmployeeName", "Tên")});
            this.fld_lke_DocumentNote_FK_HREmployeeID.Properties.DisplayMember = "HREmployeeName";
            this.fld_lke_DocumentNote_FK_HREmployeeID.Properties.NullText = "";
            this.fld_lke_DocumentNote_FK_HREmployeeID.Properties.PopupWidth = 40;
            this.fld_lke_DocumentNote_FK_HREmployeeID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lke_DocumentNote_FK_HREmployeeID.Properties.ValueMember = "HREmployeeID";
            this.fld_lke_DocumentNote_FK_HREmployeeID.Screen = null;
            this.fld_lke_DocumentNote_FK_HREmployeeID.Size = new System.Drawing.Size(243, 20);
            this.fld_lke_DocumentNote_FK_HREmployeeID.TabIndex = 43;
            this.fld_lke_DocumentNote_FK_HREmployeeID.Tag = "DC";
            // 
            // lblDocumentNoteRemark
            // 
            this.lblDocumentNoteRemark.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblDocumentNoteRemark.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblDocumentNoteRemark.Appearance.Options.UseBackColor = true;
            this.lblDocumentNoteRemark.Appearance.Options.UseForeColor = true;
            this.lblDocumentNoteRemark.BOSComment = "";
            this.lblDocumentNoteRemark.BOSDataMember = "";
            this.lblDocumentNoteRemark.BOSDataSource = "";
            this.lblDocumentNoteRemark.BOSDescription = null;
            this.lblDocumentNoteRemark.BOSError = null;
            this.lblDocumentNoteRemark.BOSFieldGroup = "";
            this.lblDocumentNoteRemark.BOSFieldRelation = "";
            this.lblDocumentNoteRemark.BOSPrivilege = "";
            this.lblDocumentNoteRemark.BOSPropertyName = "";
            this.lblDocumentNoteRemark.Location = new System.Drawing.Point(95, 55);
            this.lblDocumentNoteRemark.Name = "lblDocumentNoteRemark";
            this.lblDocumentNoteRemark.Screen = null;
            this.lblDocumentNoteRemark.Size = new System.Drawing.Size(308, 13);
            this.lblDocumentNoteRemark.TabIndex = 44;
            this.lblDocumentNoteRemark.Tag = "";
            this.lblDocumentNoteRemark.Text = "Quét chọn nội dung tờ bệnh án nếu muốn ghi chú chính xác vị trí";
            // 
            // txtDocumentNoteSelectedContent
            // 
            this.txtDocumentNoteSelectedContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocumentNoteSelectedContent.BOSComment = "";
            this.txtDocumentNoteSelectedContent.BOSDataMember = "MEEmrDocumentNotes";
            this.txtDocumentNoteSelectedContent.BOSDataSource = "MEEmrDocumentNoteText";
            this.txtDocumentNoteSelectedContent.BOSDescription = null;
            this.txtDocumentNoteSelectedContent.BOSError = null;
            this.txtDocumentNoteSelectedContent.BOSFieldGroup = "";
            this.txtDocumentNoteSelectedContent.BOSFieldRelation = "";
            this.txtDocumentNoteSelectedContent.BOSPrivilege = "";
            this.txtDocumentNoteSelectedContent.BOSPropertyName = "Text";
            this.txtDocumentNoteSelectedContent.EditValue = "";
            this.txtDocumentNoteSelectedContent.Enabled = false;
            this.txtDocumentNoteSelectedContent.Location = new System.Drawing.Point(95, 74);
            this.txtDocumentNoteSelectedContent.Name = "txtDocumentNoteSelectedContent";
            this.txtDocumentNoteSelectedContent.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtDocumentNoteSelectedContent.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtDocumentNoteSelectedContent.Properties.Appearance.Options.UseBackColor = true;
            this.txtDocumentNoteSelectedContent.Properties.Appearance.Options.UseForeColor = true;
            this.txtDocumentNoteSelectedContent.Screen = null;
            this.txtDocumentNoteSelectedContent.Size = new System.Drawing.Size(520, 46);
            this.txtDocumentNoteSelectedContent.TabIndex = 45;
            this.txtDocumentNoteSelectedContent.Tag = "DC";
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
            this.bosLabel1.Location = new System.Drawing.Point(19, 75);
            this.bosLabel1.Name = "bosLabel1";
            this.bosLabel1.Screen = null;
            this.bosLabel1.Size = new System.Drawing.Size(68, 13);
            this.bosLabel1.TabIndex = 46;
            this.bosLabel1.Tag = "";
            this.bosLabel1.Text = "Nội dung chọn";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(208, 274);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(233, 13);
            this.labelControl1.TabIndex = 1000000006;
            this.labelControl1.Text = "Ghi chú đã thêm sẽ không thể xóa hay chỉnh sửa";
            // 
            // guiDocumentNoteNew
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(625, 296);
            this.ControlBox = true;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.bosLabel1);
            this.Controls.Add(this.txtDocumentNoteSelectedContent);
            this.Controls.Add(this.lblDocumentNoteRemark);
            this.Controls.Add(this.fld_lke_DocumentNote_FK_HREmployeeID);
            this.Controls.Add(this.lblDocumentNote_FK_HREmployeeID);
            this.Controls.Add(this.fld_lke_DocumentNote_FK_HRDepartmentID);
            this.Controls.Add(this.lblDocumentNote_FK_HRDepartmentID);
            this.Controls.Add(this.fld_lblLabel6);
            this.Controls.Add(this.fld_med_DocumentNote_MEEmrDocumentNoteText);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiDocumentNoteNew";
            this.Text = "Thêm ghi chú";
            this.Load += new System.EventHandler(this.DSMEEMR100_Load);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.fld_med_DocumentNote_MEEmrDocumentNoteText, 0);
            this.Controls.SetChildIndex(this.fld_lblLabel6, 0);
            this.Controls.SetChildIndex(this.lblDocumentNote_FK_HRDepartmentID, 0);
            this.Controls.SetChildIndex(this.fld_lke_DocumentNote_FK_HRDepartmentID, 0);
            this.Controls.SetChildIndex(this.lblDocumentNote_FK_HREmployeeID, 0);
            this.Controls.SetChildIndex(this.fld_lke_DocumentNote_FK_HREmployeeID, 0);
            this.Controls.SetChildIndex(this.lblDocumentNoteRemark, 0);
            this.Controls.SetChildIndex(this.txtDocumentNoteSelectedContent, 0);
            this.Controls.SetChildIndex(this.bosLabel1, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_med_DocumentNote_MEEmrDocumentNoteText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lke_DocumentNote_FK_HRDepartmentID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lke_DocumentNote_FK_HREmployeeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentNoteSelectedContent.Properties)).EndInit();
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
        private BOSLabel fld_lblLabel6;
        private BOSMemoEdit fld_med_DocumentNote_MEEmrDocumentNoteText;
        private BOSLookupEdit fld_lke_DocumentNote_FK_HRDepartmentID;
        private BOSLabel lblDocumentNote_FK_HRDepartmentID;
        private BOSLabel lblDocumentNote_FK_HREmployeeID;
        private BOSLookupEdit fld_lke_DocumentNote_FK_HREmployeeID;
        private BOSLabel lblDocumentNoteRemark;
        private BOSMemoEdit txtDocumentNoteSelectedContent;
        private BOSLabel bosLabel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
