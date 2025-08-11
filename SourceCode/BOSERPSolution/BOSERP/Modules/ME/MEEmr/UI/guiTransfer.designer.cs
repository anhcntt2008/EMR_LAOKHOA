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
    partial class guiTransfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiTransfer));
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnBoldRemove = new DevExpress.XtraEditors.CheckButton();
            this.btnUnderlineRemove = new DevExpress.XtraEditors.CheckButton();
            this.btnItalicRemove = new DevExpress.XtraEditors.CheckButton();
            this.bosLookupEdit1 = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel2 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel6 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel4 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtMEEmrTransferHistorieNo = new BOSComponent.BOSTextBox(this.components);
            this.fld_medMEEmrTransferHistoryRemark = new BOSComponent.BOSMemoEdit(this.components);
            this.fld_lblLabel2 = new BOSComponent.BOSLabel(this.components);
            this.fld_dteMEEmrTransferHistoriesDate = new BOSComponent.BOSDateEdit(this.components);
            this.fld_lkeFK_HRDepartmentToID = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel1 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel3 = new BOSComponent.BOSLabel(this.components);
            this.bosLookupEdit4 = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel4 = new BOSComponent.BOSLabel(this.components);
            this.bosLookupEdit3 = new BOSComponent.BOSLookupEdit(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bosLookupEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrTransferHistorieNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_medMEEmrTransferHistoryRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteMEEmrTransferHistoriesDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteMEEmrTransferHistoriesDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HRDepartmentToID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosLookupEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosLookupEdit3.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.Location = new System.Drawing.Point(494, 269);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(86, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "OK (Alt+O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(586, 268);
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
            // bosLookupEdit1
            // 
            this.bosLookupEdit1.BOSAllowAddNew = false;
            this.bosLookupEdit1.BOSAllowDummy = true;
            this.bosLookupEdit1.BOSComment = "";
            this.bosLookupEdit1.BOSDataMember = "FK_HRDepartmentFromID";
            this.bosLookupEdit1.BOSDataSource = "MEEmrTransferHistories";
            this.bosLookupEdit1.BOSDescription = null;
            this.bosLookupEdit1.BOSDummyText = null;
            this.bosLookupEdit1.BOSError = null;
            this.bosLookupEdit1.BOSFieldGroup = "";
            this.bosLookupEdit1.BOSFieldParent = "";
            this.bosLookupEdit1.BOSFieldRelation = "";
            this.bosLookupEdit1.BOSPrivilege = "";
            this.bosLookupEdit1.BOSPropertyName = "EditValue";
            this.bosLookupEdit1.BOSSelectType = "";
            this.bosLookupEdit1.BOSSelectTypeValue = "";
            this.bosLookupEdit1.CurrentDisplayText = null;
            this.bosLookupEdit1.Enabled = false;
            this.bosLookupEdit1.Location = new System.Drawing.Point(95, 68);
            this.bosLookupEdit1.Name = "bosLookupEdit1";
            this.bosLookupEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLookupEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLookupEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.bosLookupEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.bosLookupEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bosLookupEdit1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRDepartmentNo", "Mã khoa", 20, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRDepartmentName", "Tên khoa")});
            this.bosLookupEdit1.Properties.DisplayMember = "HRDepartmentName";
            this.bosLookupEdit1.Properties.NullText = "";
            this.bosLookupEdit1.Properties.PopupWidth = 40;
            this.bosLookupEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.bosLookupEdit1.Properties.ValueMember = "HRDepartmentID";
            this.bosLookupEdit1.Screen = null;
            this.bosLookupEdit1.Size = new System.Drawing.Size(242, 20);
            this.bosLookupEdit1.TabIndex = 37;
            this.bosLookupEdit1.Tag = "DC";
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
            this.bosLabel2.Location = new System.Drawing.Point(11, 70);
            this.bosLabel2.Name = "bosLabel2";
            this.bosLabel2.Screen = null;
            this.bosLabel2.Size = new System.Drawing.Size(62, 13);
            this.bosLabel2.TabIndex = 36;
            this.bosLabel2.Tag = "";
            this.bosLabel2.Text = "Khoa chuyển";
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
            this.fld_lblLabel6.Location = new System.Drawing.Point(11, 122);
            this.fld_lblLabel6.Name = "fld_lblLabel6";
            this.fld_lblLabel6.Screen = null;
            this.fld_lblLabel6.Size = new System.Drawing.Size(35, 13);
            this.fld_lblLabel6.TabIndex = 33;
            this.fld_lblLabel6.Tag = "";
            this.fld_lblLabel6.Text = "Ghi chú";
            // 
            // fld_lblLabel4
            // 
            this.fld_lblLabel4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel4.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel4.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel4.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel4.BOSComment = "";
            this.fld_lblLabel4.BOSDataMember = "";
            this.fld_lblLabel4.BOSDataSource = "";
            this.fld_lblLabel4.BOSDescription = null;
            this.fld_lblLabel4.BOSError = null;
            this.fld_lblLabel4.BOSFieldGroup = "";
            this.fld_lblLabel4.BOSFieldRelation = "";
            this.fld_lblLabel4.BOSPrivilege = "";
            this.fld_lblLabel4.BOSPropertyName = "";
            this.fld_lblLabel4.Location = new System.Drawing.Point(11, 43);
            this.fld_lblLabel4.Name = "fld_lblLabel4";
            this.fld_lblLabel4.Screen = null;
            this.fld_lblLabel4.Size = new System.Drawing.Size(63, 13);
            this.fld_lblLabel4.TabIndex = 31;
            this.fld_lblLabel4.Tag = "";
            this.fld_lblLabel4.Text = "Ngày chuyển";
            // 
            // fld_txtMEEmrTransferHistorieNo
            // 
            this.fld_txtMEEmrTransferHistorieNo.BOSComment = "";
            this.fld_txtMEEmrTransferHistorieNo.BOSDataMember = "MEEmrTransferHistoryNo";
            this.fld_txtMEEmrTransferHistorieNo.BOSDataSource = "MEEmrTransferHistories";
            this.fld_txtMEEmrTransferHistorieNo.BOSDescription = null;
            this.fld_txtMEEmrTransferHistorieNo.BOSError = null;
            this.fld_txtMEEmrTransferHistorieNo.BOSFieldGroup = "";
            this.fld_txtMEEmrTransferHistorieNo.BOSFieldRelation = "";
            this.fld_txtMEEmrTransferHistorieNo.BOSPrivilege = "";
            this.fld_txtMEEmrTransferHistorieNo.BOSPropertyName = "Text";
            this.fld_txtMEEmrTransferHistorieNo.EditValue = "";
            this.fld_txtMEEmrTransferHistorieNo.Location = new System.Drawing.Point(95, 11);
            this.fld_txtMEEmrTransferHistorieNo.Name = "fld_txtMEEmrTransferHistorieNo";
            this.fld_txtMEEmrTransferHistorieNo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEEmrTransferHistorieNo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEEmrTransferHistorieNo.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEEmrTransferHistorieNo.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEEmrTransferHistorieNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEEmrTransferHistorieNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEEmrTransferHistorieNo.Screen = null;
            this.fld_txtMEEmrTransferHistorieNo.Size = new System.Drawing.Size(241, 20);
            this.fld_txtMEEmrTransferHistorieNo.TabIndex = 24;
            this.fld_txtMEEmrTransferHistorieNo.Tag = "DC";
            // 
            // fld_medMEEmrTransferHistoryRemark
            // 
            this.fld_medMEEmrTransferHistoryRemark.BOSComment = "";
            this.fld_medMEEmrTransferHistoryRemark.BOSDataMember = "MEEmrTransferHistoryRemark";
            this.fld_medMEEmrTransferHistoryRemark.BOSDataSource = "MEEmrTransferHistories";
            this.fld_medMEEmrTransferHistoryRemark.BOSDescription = null;
            this.fld_medMEEmrTransferHistoryRemark.BOSError = null;
            this.fld_medMEEmrTransferHistoryRemark.BOSFieldGroup = "";
            this.fld_medMEEmrTransferHistoryRemark.BOSFieldRelation = "";
            this.fld_medMEEmrTransferHistoryRemark.BOSPrivilege = "";
            this.fld_medMEEmrTransferHistoryRemark.BOSPropertyName = "Text";
            this.fld_medMEEmrTransferHistoryRemark.EditValue = "";
            this.fld_medMEEmrTransferHistoryRemark.Location = new System.Drawing.Point(95, 120);
            this.fld_medMEEmrTransferHistoryRemark.Name = "fld_medMEEmrTransferHistoryRemark";
            this.fld_medMEEmrTransferHistoryRemark.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_medMEEmrTransferHistoryRemark.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_medMEEmrTransferHistoryRemark.Properties.Appearance.Options.UseBackColor = true;
            this.fld_medMEEmrTransferHistoryRemark.Properties.Appearance.Options.UseForeColor = true;
            this.fld_medMEEmrTransferHistoryRemark.Screen = null;
            this.fld_medMEEmrTransferHistoryRemark.Size = new System.Drawing.Size(570, 136);
            this.fld_medMEEmrTransferHistoryRemark.TabIndex = 29;
            this.fld_medMEEmrTransferHistoryRemark.Tag = "DC";
            // 
            // fld_lblLabel2
            // 
            this.fld_lblLabel2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel2.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel2.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel2.BOSComment = "";
            this.fld_lblLabel2.BOSDataMember = "";
            this.fld_lblLabel2.BOSDataSource = "";
            this.fld_lblLabel2.BOSDescription = null;
            this.fld_lblLabel2.BOSError = null;
            this.fld_lblLabel2.BOSFieldGroup = "";
            this.fld_lblLabel2.BOSFieldRelation = "";
            this.fld_lblLabel2.BOSPrivilege = "";
            this.fld_lblLabel2.BOSPropertyName = "";
            this.fld_lblLabel2.Location = new System.Drawing.Point(12, 14);
            this.fld_lblLabel2.Name = "fld_lblLabel2";
            this.fld_lblLabel2.Screen = null;
            this.fld_lblLabel2.Size = new System.Drawing.Size(78, 13);
            this.fld_lblLabel2.TabIndex = 30;
            this.fld_lblLabel2.Tag = "";
            this.fld_lblLabel2.Text = "Mã chuyển khoa";
            // 
            // fld_dteMEEmrTransferHistoriesDate
            // 
            this.fld_dteMEEmrTransferHistoriesDate.BOSComment = "";
            this.fld_dteMEEmrTransferHistoriesDate.BOSDataMember = "MEEmrTransferHistoryDate";
            this.fld_dteMEEmrTransferHistoriesDate.BOSDataSource = "MEEmrTransferHistories";
            this.fld_dteMEEmrTransferHistoriesDate.BOSDescription = null;
            this.fld_dteMEEmrTransferHistoriesDate.BOSError = null;
            this.fld_dteMEEmrTransferHistoriesDate.BOSFieldGroup = "";
            this.fld_dteMEEmrTransferHistoriesDate.BOSFieldRelation = "";
            this.fld_dteMEEmrTransferHistoriesDate.BOSPrivilege = "";
            this.fld_dteMEEmrTransferHistoriesDate.BOSPropertyName = "EditValue";
            this.fld_dteMEEmrTransferHistoriesDate.EditValue = null;
            this.fld_dteMEEmrTransferHistoriesDate.Enabled = false;
            this.fld_dteMEEmrTransferHistoriesDate.Location = new System.Drawing.Point(95, 40);
            this.fld_dteMEEmrTransferHistoriesDate.Name = "fld_dteMEEmrTransferHistoriesDate";
            this.fld_dteMEEmrTransferHistoriesDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteMEEmrTransferHistoriesDate.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteMEEmrTransferHistoriesDate.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteMEEmrTransferHistoriesDate.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteMEEmrTransferHistoriesDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteMEEmrTransferHistoriesDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteMEEmrTransferHistoriesDate.Screen = null;
            this.fld_dteMEEmrTransferHistoriesDate.Size = new System.Drawing.Size(242, 20);
            this.fld_dteMEEmrTransferHistoriesDate.TabIndex = 26;
            this.fld_dteMEEmrTransferHistoriesDate.Tag = "DC";
            // 
            // fld_lkeFK_HRDepartmentToID
            // 
            this.fld_lkeFK_HRDepartmentToID.BOSAllowAddNew = false;
            this.fld_lkeFK_HRDepartmentToID.BOSAllowDummy = true;
            this.fld_lkeFK_HRDepartmentToID.BOSComment = "";
            this.fld_lkeFK_HRDepartmentToID.BOSDataMember = "FK_HRDepartmentToID";
            this.fld_lkeFK_HRDepartmentToID.BOSDataSource = "MEEmrTransferHistories";
            this.fld_lkeFK_HRDepartmentToID.BOSDescription = null;
            this.fld_lkeFK_HRDepartmentToID.BOSDummyText = null;
            this.fld_lkeFK_HRDepartmentToID.BOSError = null;
            this.fld_lkeFK_HRDepartmentToID.BOSFieldGroup = "";
            this.fld_lkeFK_HRDepartmentToID.BOSFieldParent = "";
            this.fld_lkeFK_HRDepartmentToID.BOSFieldRelation = "";
            this.fld_lkeFK_HRDepartmentToID.BOSPrivilege = "";
            this.fld_lkeFK_HRDepartmentToID.BOSPropertyName = "EditValue";
            this.fld_lkeFK_HRDepartmentToID.BOSSelectType = "";
            this.fld_lkeFK_HRDepartmentToID.BOSSelectTypeValue = "";
            this.fld_lkeFK_HRDepartmentToID.CurrentDisplayText = null;
            this.fld_lkeFK_HRDepartmentToID.Location = new System.Drawing.Point(423, 68);
            this.fld_lkeFK_HRDepartmentToID.Name = "fld_lkeFK_HRDepartmentToID";
            this.fld_lkeFK_HRDepartmentToID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeFK_HRDepartmentToID.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeFK_HRDepartmentToID.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeFK_HRDepartmentToID.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeFK_HRDepartmentToID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_HRDepartmentToID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRDepartmentNo", "Mã khoa", 20, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRDepartmentName", "Tên khoa")});
            this.fld_lkeFK_HRDepartmentToID.Properties.DisplayMember = "HRDepartmentName";
            this.fld_lkeFK_HRDepartmentToID.Properties.NullText = "";
            this.fld_lkeFK_HRDepartmentToID.Properties.PopupWidth = 40;
            this.fld_lkeFK_HRDepartmentToID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeFK_HRDepartmentToID.Properties.ValueMember = "HRDepartmentID";
            this.fld_lkeFK_HRDepartmentToID.Screen = null;
            this.fld_lkeFK_HRDepartmentToID.Size = new System.Drawing.Size(242, 20);
            this.fld_lkeFK_HRDepartmentToID.TabIndex = 39;
            this.fld_lkeFK_HRDepartmentToID.Tag = "DC";
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
            this.bosLabel1.Location = new System.Drawing.Point(355, 72);
            this.bosLabel1.Name = "bosLabel1";
            this.bosLabel1.Screen = null;
            this.bosLabel1.Size = new System.Drawing.Size(51, 13);
            this.bosLabel1.TabIndex = 38;
            this.bosLabel1.Tag = "";
            this.bosLabel1.Text = "Khoa nhận";
            // 
            // bosLabel3
            // 
            this.bosLabel3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.bosLabel3.Location = new System.Drawing.Point(355, 98);
            this.bosLabel3.Name = "bosLabel3";
            this.bosLabel3.Screen = null;
            this.bosLabel3.Size = new System.Drawing.Size(55, 13);
            this.bosLabel3.TabIndex = 42;
            this.bosLabel3.Tag = "";
            this.bosLabel3.Text = "Người nhận";
            // 
            // bosLookupEdit4
            // 
            this.bosLookupEdit4.BOSAllowAddNew = false;
            this.bosLookupEdit4.BOSAllowDummy = true;
            this.bosLookupEdit4.BOSComment = "";
            this.bosLookupEdit4.BOSDataMember = "FK_HREmployeeFromID";
            this.bosLookupEdit4.BOSDataSource = "MEEmrTransferHistories";
            this.bosLookupEdit4.BOSDescription = null;
            this.bosLookupEdit4.BOSDummyText = null;
            this.bosLookupEdit4.BOSError = null;
            this.bosLookupEdit4.BOSFieldGroup = "";
            this.bosLookupEdit4.BOSFieldParent = "";
            this.bosLookupEdit4.BOSFieldRelation = "";
            this.bosLookupEdit4.BOSPrivilege = "";
            this.bosLookupEdit4.BOSPropertyName = "EditValue";
            this.bosLookupEdit4.BOSSelectType = "";
            this.bosLookupEdit4.BOSSelectTypeValue = "";
            this.bosLookupEdit4.CurrentDisplayText = null;
            this.bosLookupEdit4.Enabled = false;
            this.bosLookupEdit4.Location = new System.Drawing.Point(95, 95);
            this.bosLookupEdit4.Name = "bosLookupEdit4";
            this.bosLookupEdit4.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLookupEdit4.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLookupEdit4.Properties.Appearance.Options.UseBackColor = true;
            this.bosLookupEdit4.Properties.Appearance.Options.UseForeColor = true;
            this.bosLookupEdit4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bosLookupEdit4.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HREmployeeNo", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HREmployeeName", "Tên")});
            this.bosLookupEdit4.Properties.DisplayMember = "HREmployeeName";
            this.bosLookupEdit4.Properties.NullText = "";
            this.bosLookupEdit4.Properties.PopupWidth = 40;
            this.bosLookupEdit4.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.bosLookupEdit4.Properties.ValueMember = "HREmployeeID";
            this.bosLookupEdit4.Screen = null;
            this.bosLookupEdit4.Size = new System.Drawing.Size(243, 20);
            this.bosLookupEdit4.TabIndex = 41;
            this.bosLookupEdit4.Tag = "DC";
            // 
            // bosLabel4
            // 
            this.bosLabel4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel4.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel4.Appearance.Options.UseBackColor = true;
            this.bosLabel4.Appearance.Options.UseForeColor = true;
            this.bosLabel4.BOSComment = "";
            this.bosLabel4.BOSDataMember = "";
            this.bosLabel4.BOSDataSource = "";
            this.bosLabel4.BOSDescription = null;
            this.bosLabel4.BOSError = null;
            this.bosLabel4.BOSFieldGroup = "";
            this.bosLabel4.BOSFieldRelation = "";
            this.bosLabel4.BOSPrivilege = "";
            this.bosLabel4.BOSPropertyName = "";
            this.bosLabel4.Location = new System.Drawing.Point(11, 97);
            this.bosLabel4.Name = "bosLabel4";
            this.bosLabel4.Screen = null;
            this.bosLabel4.Size = new System.Drawing.Size(66, 13);
            this.bosLabel4.TabIndex = 40;
            this.bosLabel4.Tag = "";
            this.bosLabel4.Text = "Người chuyển";
            // 
            // bosLookupEdit3
            // 
            this.bosLookupEdit3.BOSAllowAddNew = false;
            this.bosLookupEdit3.BOSAllowDummy = true;
            this.bosLookupEdit3.BOSComment = "";
            this.bosLookupEdit3.BOSDataMember = "FK_HREmployeeToID";
            this.bosLookupEdit3.BOSDataSource = "MEEmrTransferHistories";
            this.bosLookupEdit3.BOSDescription = null;
            this.bosLookupEdit3.BOSDummyText = null;
            this.bosLookupEdit3.BOSError = null;
            this.bosLookupEdit3.BOSFieldGroup = "";
            this.bosLookupEdit3.BOSFieldParent = "fld_lkeFK_HRDepartmentToID";
            this.bosLookupEdit3.BOSFieldRelation = "";
            this.bosLookupEdit3.BOSPrivilege = "";
            this.bosLookupEdit3.BOSPropertyName = "EditValue";
            this.bosLookupEdit3.BOSSelectType = "";
            this.bosLookupEdit3.BOSSelectTypeValue = "";
            this.bosLookupEdit3.CurrentDisplayText = null;
            this.bosLookupEdit3.Location = new System.Drawing.Point(423, 94);
            this.bosLookupEdit3.Name = "bosLookupEdit3";
            this.bosLookupEdit3.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLookupEdit3.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLookupEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.bosLookupEdit3.Properties.Appearance.Options.UseForeColor = true;
            this.bosLookupEdit3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bosLookupEdit3.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HREmployeeNo", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HREmployeeName", "Tên")});
            this.bosLookupEdit3.Properties.DisplayMember = "HREmployeeName";
            this.bosLookupEdit3.Properties.NullText = "";
            this.bosLookupEdit3.Properties.PopupWidth = 40;
            this.bosLookupEdit3.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.bosLookupEdit3.Properties.ValueMember = "HREmployeeID";
            this.bosLookupEdit3.Screen = null;
            this.bosLookupEdit3.Size = new System.Drawing.Size(243, 20);
            this.bosLookupEdit3.TabIndex = 43;
            this.bosLookupEdit3.Tag = "DC";
            // 
            // guiTransfer
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(671, 296);
            this.ControlBox = true;
            this.Controls.Add(this.bosLookupEdit3);
            this.Controls.Add(this.bosLabel3);
            this.Controls.Add(this.bosLookupEdit4);
            this.Controls.Add(this.bosLabel4);
            this.Controls.Add(this.fld_lkeFK_HRDepartmentToID);
            this.Controls.Add(this.bosLabel1);
            this.Controls.Add(this.bosLookupEdit1);
            this.Controls.Add(this.bosLabel2);
            this.Controls.Add(this.fld_lblLabel6);
            this.Controls.Add(this.fld_lblLabel4);
            this.Controls.Add(this.fld_txtMEEmrTransferHistorieNo);
            this.Controls.Add(this.fld_medMEEmrTransferHistoryRemark);
            this.Controls.Add(this.fld_lblLabel2);
            this.Controls.Add(this.fld_dteMEEmrTransferHistoriesDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiTransfer";
            this.Text = "Chuyển khoa";
            this.Load += new System.EventHandler(this.DSMEEMR100_Load);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.fld_dteMEEmrTransferHistoriesDate, 0);
            this.Controls.SetChildIndex(this.fld_lblLabel2, 0);
            this.Controls.SetChildIndex(this.fld_medMEEmrTransferHistoryRemark, 0);
            this.Controls.SetChildIndex(this.fld_txtMEEmrTransferHistorieNo, 0);
            this.Controls.SetChildIndex(this.fld_lblLabel4, 0);
            this.Controls.SetChildIndex(this.fld_lblLabel6, 0);
            this.Controls.SetChildIndex(this.bosLabel2, 0);
            this.Controls.SetChildIndex(this.bosLookupEdit1, 0);
            this.Controls.SetChildIndex(this.bosLabel1, 0);
            this.Controls.SetChildIndex(this.fld_lkeFK_HRDepartmentToID, 0);
            this.Controls.SetChildIndex(this.bosLabel4, 0);
            this.Controls.SetChildIndex(this.bosLookupEdit4, 0);
            this.Controls.SetChildIndex(this.bosLabel3, 0);
            this.Controls.SetChildIndex(this.bosLookupEdit3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bosLookupEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrTransferHistorieNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_medMEEmrTransferHistoryRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteMEEmrTransferHistoriesDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteMEEmrTransferHistoriesDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HRDepartmentToID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosLookupEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosLookupEdit3.Properties)).EndInit();
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
        private BOSLookupEdit bosLookupEdit1;
        private BOSLabel bosLabel2;
        private BOSLabel fld_lblLabel6;
        private BOSLabel fld_lblLabel4;
        private BOSTextBox fld_txtMEEmrTransferHistorieNo;
        private BOSMemoEdit fld_medMEEmrTransferHistoryRemark;
        private BOSLabel fld_lblLabel2;
        private BOSDateEdit fld_dteMEEmrTransferHistoriesDate;
        private BOSLookupEdit fld_lkeFK_HRDepartmentToID;
        private BOSLabel bosLabel1;
        private BOSLabel bosLabel3;
        private BOSLookupEdit bosLookupEdit4;
        private BOSLabel bosLabel4;
        private BOSLookupEdit bosLookupEdit3;
    }
}
