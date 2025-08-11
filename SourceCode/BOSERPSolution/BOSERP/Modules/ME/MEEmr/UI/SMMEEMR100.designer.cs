using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for SMMEEMR100
    /// </summary>
    partial class SMMEEMR100
    {
        private BOSComponent.BOSTextBox fld_txtMEEmrNo;
        private BOSComponent.BOSLookupEdit fld_lkeFK_MEPatientID;
        private BOSComponent.BOSLabel fld_lblLabel;
        private BOSComponent.BOSLabel fld_lblLabel1;


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMMEEMR100));
            this.bosLabel4 = new BOSComponent.BOSLabel(this.components);
            this.fld_dteMEEmrCreatedDateSearchTo = new BOSComponent.BOSDateEdit(this.components);
            this.fld_dteMEEmrCreatedDateSearchFrom = new BOSComponent.BOSDateEdit(this.components);
            this.bosLabel3 = new BOSComponent.BOSLabel(this.components);
            this.fld_lkeFK_MEEmrTypeID = new BOSComponent.BOSLookupEdit(this.components);
            this.fld_lkeMEEmrStatus = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel5 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel6 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtMEEmrNo = new BOSComponent.BOSTextBox(this.components);
            this.fld_lkeFK_MEPatientID = new BOSComponent.BOSLookupEdit(this.components);
            this.fld_lblLabel = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel1 = new BOSComponent.BOSLabel(this.components);
            this.fld_dgcMEEmr = new BOSERP.Modules.MEEmr.MEEmrsSearchResultGridControl(this.components);
            this.chkDepartmentShared = new DevExpress.XtraEditors.CheckEdit();
            this.fld_ccbeFK_HRDepartmentID1 = new BOSComponent.MultiColCheckedComboBoxEdit(this.components);
            this.chkEmrCurrentShared = new DevExpress.XtraEditors.CheckEdit();
            this.fld_txtMEPatientName = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtMEPatientNo = new BOSComponent.BOSTextBox(this.components);
            this.btnSearchPatient = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteMEEmrCreatedDateSearchTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteMEEmrCreatedDateSearchTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteMEEmrCreatedDateSearchFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteMEEmrCreatedDateSearchFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_MEEmrTypeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEEmrStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_MEPatientID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDepartmentShared.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_ccbeFK_HRDepartmentID1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEmrCurrentShared.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEPatientName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEPatientNo.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.bosLabel4.Location = new System.Drawing.Point(334, 56);
            this.bosLabel4.Name = "bosLabel4";
            this.bosLabel4.Screen = null;
            this.bosLabel4.Size = new System.Drawing.Size(44, 13);
            this.bosLabel4.TabIndex = 52;
            this.bosLabel4.Tag = "SI";
            this.bosLabel4.Text = "Ngày tạo";
            // 
            // fld_dteMEEmrCreatedDateSearchTo
            // 
            this.fld_dteMEEmrCreatedDateSearchTo.BOSComment = "";
            this.fld_dteMEEmrCreatedDateSearchTo.BOSDataMember = "MEEmrCreatedDate";
            this.fld_dteMEEmrCreatedDateSearchTo.BOSDataSource = "";
            this.fld_dteMEEmrCreatedDateSearchTo.BOSDescription = null;
            this.fld_dteMEEmrCreatedDateSearchTo.BOSError = null;
            this.fld_dteMEEmrCreatedDateSearchTo.BOSFieldGroup = "";
            this.fld_dteMEEmrCreatedDateSearchTo.BOSFieldRelation = "";
            this.fld_dteMEEmrCreatedDateSearchTo.BOSPrivilege = "";
            this.fld_dteMEEmrCreatedDateSearchTo.BOSPropertyName = "EditValue";
            this.fld_dteMEEmrCreatedDateSearchTo.EditValue = null;
            this.fld_dteMEEmrCreatedDateSearchTo.Location = new System.Drawing.Point(522, 54);
            this.fld_dteMEEmrCreatedDateSearchTo.Name = "fld_dteMEEmrCreatedDateSearchTo";
            this.fld_dteMEEmrCreatedDateSearchTo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteMEEmrCreatedDateSearchTo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteMEEmrCreatedDateSearchTo.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteMEEmrCreatedDateSearchTo.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteMEEmrCreatedDateSearchTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteMEEmrCreatedDateSearchTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteMEEmrCreatedDateSearchTo.Screen = null;
            this.fld_dteMEEmrCreatedDateSearchTo.Size = new System.Drawing.Size(102, 20);
            this.fld_dteMEEmrCreatedDateSearchTo.TabIndex = 4;
            this.fld_dteMEEmrCreatedDateSearchTo.Tag = "SC";
            // 
            // fld_dteMEEmrCreatedDateSearchFrom
            // 
            this.fld_dteMEEmrCreatedDateSearchFrom.BOSComment = "";
            this.fld_dteMEEmrCreatedDateSearchFrom.BOSDataMember = "MEEmrCreatedDate";
            this.fld_dteMEEmrCreatedDateSearchFrom.BOSDataSource = "";
            this.fld_dteMEEmrCreatedDateSearchFrom.BOSDescription = null;
            this.fld_dteMEEmrCreatedDateSearchFrom.BOSError = null;
            this.fld_dteMEEmrCreatedDateSearchFrom.BOSFieldGroup = "";
            this.fld_dteMEEmrCreatedDateSearchFrom.BOSFieldRelation = "";
            this.fld_dteMEEmrCreatedDateSearchFrom.BOSPrivilege = "";
            this.fld_dteMEEmrCreatedDateSearchFrom.BOSPropertyName = "EditValue";
            this.fld_dteMEEmrCreatedDateSearchFrom.EditValue = null;
            this.fld_dteMEEmrCreatedDateSearchFrom.Location = new System.Drawing.Point(417, 54);
            this.fld_dteMEEmrCreatedDateSearchFrom.Name = "fld_dteMEEmrCreatedDateSearchFrom";
            this.fld_dteMEEmrCreatedDateSearchFrom.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteMEEmrCreatedDateSearchFrom.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteMEEmrCreatedDateSearchFrom.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteMEEmrCreatedDateSearchFrom.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteMEEmrCreatedDateSearchFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteMEEmrCreatedDateSearchFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteMEEmrCreatedDateSearchFrom.Screen = null;
            this.fld_dteMEEmrCreatedDateSearchFrom.Size = new System.Drawing.Size(99, 20);
            this.fld_dteMEEmrCreatedDateSearchFrom.TabIndex = 3;
            this.fld_dteMEEmrCreatedDateSearchFrom.Tag = "SC";
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
            this.bosLabel3.Location = new System.Drawing.Point(24, 33);
            this.bosLabel3.Name = "bosLabel3";
            this.bosLabel3.Screen = null;
            this.bosLabel3.Size = new System.Drawing.Size(24, 13);
            this.bosLabel3.TabIndex = 49;
            this.bosLabel3.Tag = "SI";
            this.bosLabel3.Text = "Khoa";
            // 
            // fld_lkeFK_MEEmrTypeID
            // 
            this.fld_lkeFK_MEEmrTypeID.BOSAllowAddNew = false;
            this.fld_lkeFK_MEEmrTypeID.BOSAllowDummy = true;
            this.fld_lkeFK_MEEmrTypeID.BOSComment = "";
            this.fld_lkeFK_MEEmrTypeID.BOSDataMember = "FK_MEEmrTypeID";
            this.fld_lkeFK_MEEmrTypeID.BOSDataSource = "MEEmrs";
            this.fld_lkeFK_MEEmrTypeID.BOSDescription = null;
            this.fld_lkeFK_MEEmrTypeID.BOSDummyText = null;
            this.fld_lkeFK_MEEmrTypeID.BOSError = null;
            this.fld_lkeFK_MEEmrTypeID.BOSFieldGroup = "";
            this.fld_lkeFK_MEEmrTypeID.BOSFieldParent = "";
            this.fld_lkeFK_MEEmrTypeID.BOSFieldRelation = "";
            this.fld_lkeFK_MEEmrTypeID.BOSPrivilege = "";
            this.fld_lkeFK_MEEmrTypeID.BOSPropertyName = "EditValue";
            this.fld_lkeFK_MEEmrTypeID.BOSSelectType = "";
            this.fld_lkeFK_MEEmrTypeID.BOSSelectTypeValue = "";
            this.fld_lkeFK_MEEmrTypeID.CurrentDisplayText = null;
            this.fld_lkeFK_MEEmrTypeID.Location = new System.Drawing.Point(103, 80);
            this.fld_lkeFK_MEEmrTypeID.Name = "fld_lkeFK_MEEmrTypeID";
            this.fld_lkeFK_MEEmrTypeID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeFK_MEEmrTypeID.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeFK_MEEmrTypeID.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeFK_MEEmrTypeID.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeFK_MEEmrTypeID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_MEEmrTypeID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MEEmrTypeNo", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MEEmrTypeName", "Tên")});
            this.fld_lkeFK_MEEmrTypeID.Properties.DisplayMember = "MEEmrTypeName";
            this.fld_lkeFK_MEEmrTypeID.Properties.NullText = "";
            this.fld_lkeFK_MEEmrTypeID.Properties.PopupWidth = 40;
            this.fld_lkeFK_MEEmrTypeID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeFK_MEEmrTypeID.Properties.ValueMember = "MEEmrTypeID";
            this.fld_lkeFK_MEEmrTypeID.Screen = null;
            this.fld_lkeFK_MEEmrTypeID.Size = new System.Drawing.Size(207, 20);
            this.fld_lkeFK_MEEmrTypeID.TabIndex = 5;
            this.fld_lkeFK_MEEmrTypeID.Tag = "SC";
            // 
            // fld_lkeMEEmrStatus
            // 
            this.fld_lkeMEEmrStatus.BOSAllowAddNew = false;
            this.fld_lkeMEEmrStatus.BOSAllowDummy = true;
            this.fld_lkeMEEmrStatus.BOSComment = "";
            this.fld_lkeMEEmrStatus.BOSDataMember = "MEEmrStatus";
            this.fld_lkeMEEmrStatus.BOSDataSource = "MEEmrs";
            this.fld_lkeMEEmrStatus.BOSDescription = null;
            this.fld_lkeMEEmrStatus.BOSDummyText = null;
            this.fld_lkeMEEmrStatus.BOSError = null;
            this.fld_lkeMEEmrStatus.BOSFieldGroup = "";
            this.fld_lkeMEEmrStatus.BOSFieldParent = "";
            this.fld_lkeMEEmrStatus.BOSFieldRelation = "";
            this.fld_lkeMEEmrStatus.BOSPrivilege = "";
            this.fld_lkeMEEmrStatus.BOSPropertyName = "EditValue";
            this.fld_lkeMEEmrStatus.BOSSelectType = "";
            this.fld_lkeMEEmrStatus.BOSSelectTypeValue = "";
            this.fld_lkeMEEmrStatus.CurrentDisplayText = null;
            this.fld_lkeMEEmrStatus.Location = new System.Drawing.Point(417, 78);
            this.fld_lkeMEEmrStatus.Name = "fld_lkeMEEmrStatus";
            this.fld_lkeMEEmrStatus.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeMEEmrStatus.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeMEEmrStatus.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeMEEmrStatus.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeMEEmrStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeMEEmrStatus.Properties.DisplayMember = "MEPatientName";
            this.fld_lkeMEEmrStatus.Properties.NullText = "";
            this.fld_lkeMEEmrStatus.Properties.PopupWidth = 40;
            this.fld_lkeMEEmrStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeMEEmrStatus.Properties.ValueMember = "MEPatientID";
            this.fld_lkeMEEmrStatus.Screen = null;
            this.fld_lkeMEEmrStatus.Size = new System.Drawing.Size(207, 20);
            this.fld_lkeMEEmrStatus.TabIndex = 6;
            this.fld_lkeMEEmrStatus.Tag = "SC";
            // 
            // bosLabel5
            // 
            this.bosLabel5.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel5.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel5.Appearance.Options.UseBackColor = true;
            this.bosLabel5.Appearance.Options.UseForeColor = true;
            this.bosLabel5.BOSComment = "";
            this.bosLabel5.BOSDataMember = "";
            this.bosLabel5.BOSDataSource = "";
            this.bosLabel5.BOSDescription = null;
            this.bosLabel5.BOSError = null;
            this.bosLabel5.BOSFieldGroup = "";
            this.bosLabel5.BOSFieldRelation = "";
            this.bosLabel5.BOSPrivilege = "";
            this.bosLabel5.BOSPropertyName = "";
            this.bosLabel5.Location = new System.Drawing.Point(334, 81);
            this.bosLabel5.Name = "bosLabel5";
            this.bosLabel5.Screen = null;
            this.bosLabel5.Size = new System.Drawing.Size(49, 13);
            this.bosLabel5.TabIndex = 45;
            this.bosLabel5.Tag = "SI";
            this.bosLabel5.Text = "Trạng thái";
            // 
            // bosLabel6
            // 
            this.bosLabel6.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel6.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel6.Appearance.Options.UseBackColor = true;
            this.bosLabel6.Appearance.Options.UseForeColor = true;
            this.bosLabel6.BOSComment = "";
            this.bosLabel6.BOSDataMember = "";
            this.bosLabel6.BOSDataSource = "";
            this.bosLabel6.BOSDescription = null;
            this.bosLabel6.BOSError = null;
            this.bosLabel6.BOSFieldGroup = "";
            this.bosLabel6.BOSFieldRelation = "";
            this.bosLabel6.BOSPrivilege = "";
            this.bosLabel6.BOSPropertyName = "";
            this.bosLabel6.Location = new System.Drawing.Point(24, 83);
            this.bosLabel6.Name = "bosLabel6";
            this.bosLabel6.Screen = null;
            this.bosLabel6.Size = new System.Drawing.Size(61, 13);
            this.bosLabel6.TabIndex = 47;
            this.bosLabel6.Tag = "SI";
            this.bosLabel6.Text = "Loại bệnh án";
            // 
            // fld_txtMEEmrNo
            // 
            this.fld_txtMEEmrNo.BOSComment = "";
            this.fld_txtMEEmrNo.BOSDataMember = "MEEmrNo";
            this.fld_txtMEEmrNo.BOSDataSource = "MEEmrs";
            this.fld_txtMEEmrNo.BOSDescription = null;
            this.fld_txtMEEmrNo.BOSError = null;
            this.fld_txtMEEmrNo.BOSFieldGroup = "";
            this.fld_txtMEEmrNo.BOSFieldRelation = "";
            this.fld_txtMEEmrNo.BOSPrivilege = "";
            this.fld_txtMEEmrNo.BOSPropertyName = "Text";
            this.fld_txtMEEmrNo.EditValue = "";
            this.fld_txtMEEmrNo.Location = new System.Drawing.Point(103, 54);
            this.fld_txtMEEmrNo.Name = "fld_txtMEEmrNo";
            this.fld_txtMEEmrNo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEEmrNo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEEmrNo.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEEmrNo.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEEmrNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEEmrNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEEmrNo.Screen = null;
            this.fld_txtMEEmrNo.Size = new System.Drawing.Size(206, 20);
            this.fld_txtMEEmrNo.TabIndex = 2;
            this.fld_txtMEEmrNo.Tag = "SC";
            // 
            // fld_lkeFK_MEPatientID
            // 
            this.fld_lkeFK_MEPatientID.BOSAllowAddNew = false;
            this.fld_lkeFK_MEPatientID.BOSAllowDummy = true;
            this.fld_lkeFK_MEPatientID.BOSComment = "";
            this.fld_lkeFK_MEPatientID.BOSDataMember = "FK_MEPatientID";
            this.fld_lkeFK_MEPatientID.BOSDataSource = "MEEmrs";
            this.fld_lkeFK_MEPatientID.BOSDescription = null;
            this.fld_lkeFK_MEPatientID.BOSDummyText = null;
            this.fld_lkeFK_MEPatientID.BOSError = null;
            this.fld_lkeFK_MEPatientID.BOSFieldGroup = "";
            this.fld_lkeFK_MEPatientID.BOSFieldParent = "";
            this.fld_lkeFK_MEPatientID.BOSFieldRelation = "";
            this.fld_lkeFK_MEPatientID.BOSPrivilege = "";
            this.fld_lkeFK_MEPatientID.BOSPropertyName = "EditValue";
            this.fld_lkeFK_MEPatientID.BOSSelectType = "";
            this.fld_lkeFK_MEPatientID.BOSSelectTypeValue = "";
            this.fld_lkeFK_MEPatientID.CurrentDisplayText = null;
            this.fld_lkeFK_MEPatientID.Location = new System.Drawing.Point(104, 106);
            this.fld_lkeFK_MEPatientID.Name = "fld_lkeFK_MEPatientID";
            this.fld_lkeFK_MEPatientID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeFK_MEPatientID.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeFK_MEPatientID.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeFK_MEPatientID.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeFK_MEPatientID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_MEPatientID.Properties.DisplayMember = "MEPatientName";
            this.fld_lkeFK_MEPatientID.Properties.NullText = "";
            this.fld_lkeFK_MEPatientID.Properties.PopupWidth = 40;
            this.fld_lkeFK_MEPatientID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeFK_MEPatientID.Properties.ValueMember = "MEPatientID";
            this.fld_lkeFK_MEPatientID.Screen = null;
            this.fld_lkeFK_MEPatientID.Size = new System.Drawing.Size(73, 20);
            this.fld_lkeFK_MEPatientID.TabIndex = 1;
            this.fld_lkeFK_MEPatientID.Tag = "SC";
            // 
            // fld_lblLabel
            // 
            this.fld_lblLabel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel.BOSComment = "";
            this.fld_lblLabel.BOSDataMember = "";
            this.fld_lblLabel.BOSDataSource = "";
            this.fld_lblLabel.BOSDescription = null;
            this.fld_lblLabel.BOSError = null;
            this.fld_lblLabel.BOSFieldGroup = "";
            this.fld_lblLabel.BOSFieldRelation = "";
            this.fld_lblLabel.BOSPrivilege = "";
            this.fld_lblLabel.BOSPropertyName = "";
            this.fld_lblLabel.Location = new System.Drawing.Point(24, 57);
            this.fld_lblLabel.Name = "fld_lblLabel";
            this.fld_lblLabel.Screen = null;
            this.fld_lblLabel.Size = new System.Drawing.Size(56, 13);
            this.fld_lblLabel.TabIndex = 6;
            this.fld_lblLabel.Tag = "SI";
            this.fld_lblLabel.Text = "Mã bệnh án";
            // 
            // fld_lblLabel1
            // 
            this.fld_lblLabel1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel1.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel1.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel1.BOSComment = "";
            this.fld_lblLabel1.BOSDataMember = "";
            this.fld_lblLabel1.BOSDataSource = "";
            this.fld_lblLabel1.BOSDescription = null;
            this.fld_lblLabel1.BOSError = null;
            this.fld_lblLabel1.BOSFieldGroup = "";
            this.fld_lblLabel1.BOSFieldRelation = "";
            this.fld_lblLabel1.BOSPrivilege = "";
            this.fld_lblLabel1.BOSPropertyName = "";
            this.fld_lblLabel1.Location = new System.Drawing.Point(25, 109);
            this.fld_lblLabel1.Name = "fld_lblLabel1";
            this.fld_lblLabel1.Screen = null;
            this.fld_lblLabel1.Size = new System.Drawing.Size(51, 13);
            this.fld_lblLabel1.TabIndex = 7;
            this.fld_lblLabel1.Tag = "SI";
            this.fld_lblLabel1.Text = "Bệnh nhân";
            // 
            // fld_dgcMEEmr
            // 
            this.fld_dgcMEEmr.BOSComment = null;
            this.fld_dgcMEEmr.BOSDataMember = null;
            this.fld_dgcMEEmr.BOSDataSource = "MEEmrs";
            this.fld_dgcMEEmr.BOSDescription = null;
            this.fld_dgcMEEmr.BOSError = null;
            this.fld_dgcMEEmr.BOSFieldGroup = null;
            this.fld_dgcMEEmr.BOSFieldRelation = null;
            this.fld_dgcMEEmr.BOSPrivilege = null;
            this.fld_dgcMEEmr.BOSPropertyName = null;
            this.fld_dgcMEEmr.Location = new System.Drawing.Point(12, 216);
            this.fld_dgcMEEmr.MenuManager = this.screenToolbar;
            this.fld_dgcMEEmr.Name = "fld_dgcMEEmr";
            this.fld_dgcMEEmr.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_dgcMEEmr, true);
            this.fld_dgcMEEmr.Size = new System.Drawing.Size(600, 203);
            this.fld_dgcMEEmr.TabIndex = 11;
            this.fld_dgcMEEmr.TabStop = false;
            this.fld_dgcMEEmr.Tag = "SR";
            // 
            // chkDepartmentShared
            // 
            this.chkDepartmentShared.Location = new System.Drawing.Point(527, 26);
            this.chkDepartmentShared.MenuManager = this.screenToolbar;
            this.chkDepartmentShared.Name = "chkDepartmentShared";
            this.chkDepartmentShared.Properties.Caption = "Chỉ khoa chia sẻ";
            this.chkDepartmentShared.Size = new System.Drawing.Size(97, 19);
            this.chkDepartmentShared.TabIndex = 1;
            this.chkDepartmentShared.Tag = "SC";
            this.chkDepartmentShared.CheckedChanged += new System.EventHandler(this.chkDepartmentShared_CheckedChanged);
            // 
            // fld_ccbeFK_HRDepartmentID1
            // 
            this.fld_ccbeFK_HRDepartmentID1.Location = new System.Drawing.Point(103, 26);
            this.fld_ccbeFK_HRDepartmentID1.MenuManager = this.screenToolbar;
            this.fld_ccbeFK_HRDepartmentID1.Name = "fld_ccbeFK_HRDepartmentID1";
            this.fld_ccbeFK_HRDepartmentID1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ScreenHelper.SetShowHelp(this.fld_ccbeFK_HRDepartmentID1, true);
            this.fld_ccbeFK_HRDepartmentID1.Size = new System.Drawing.Size(413, 20);
            this.fld_ccbeFK_HRDepartmentID1.TabIndex = 0;
            this.fld_ccbeFK_HRDepartmentID1.Tag = "SC";
            this.fld_ccbeFK_HRDepartmentID1.BOSComment = null;
            this.fld_ccbeFK_HRDepartmentID1.BOSDataMember = null;
            this.fld_ccbeFK_HRDepartmentID1.BOSDataSource = "HRDepartments";
            this.fld_ccbeFK_HRDepartmentID1.BOSDescription = null;
            this.fld_ccbeFK_HRDepartmentID1.BOSError = null;
            this.fld_ccbeFK_HRDepartmentID1.BOSFieldGroup = null;
            this.fld_ccbeFK_HRDepartmentID1.BOSFieldRelation = null;
            this.fld_ccbeFK_HRDepartmentID1.BOSPrivilege = null;
            this.fld_ccbeFK_HRDepartmentID1.BOSPropertyName = null;
            this.fld_ccbeFK_HRDepartmentID1.DisplayField = "HRDepartmentName";
            this.fld_ccbeFK_HRDepartmentID1.ValueField = "HRDepartmentID";

            // 
            // chkEmrCurrentShared
            // 
            this.chkEmrCurrentShared.Location = new System.Drawing.Point(522, 106);
            this.chkEmrCurrentShared.MenuManager = this.screenToolbar;
            this.chkEmrCurrentShared.Name = "chkEmrCurrentShared";
            this.chkEmrCurrentShared.Properties.Caption = "Khoa tôi chia sẻ";
            this.chkEmrCurrentShared.Size = new System.Drawing.Size(99, 19);
            this.chkEmrCurrentShared.TabIndex = 9;
            this.chkEmrCurrentShared.Tag = "SC";
            this.chkEmrCurrentShared.CheckedChanged += new System.EventHandler(this.chkEmrCurrentShared_CheckedChanged);
            // 
            // fld_txtMEPatientName
            // 
            this.fld_txtMEPatientName.BOSComment = "";
            this.fld_txtMEPatientName.BOSDataMember = "MEPatientName";
            this.fld_txtMEPatientName.BOSDataSource = "MEPatients";
            this.fld_txtMEPatientName.BOSDescription = null;
            this.fld_txtMEPatientName.BOSError = null;
            this.fld_txtMEPatientName.BOSFieldGroup = "";
            this.fld_txtMEPatientName.BOSFieldRelation = "";
            this.fld_txtMEPatientName.BOSPrivilege = "";
            this.fld_txtMEPatientName.BOSPropertyName = "Text";
            this.fld_txtMEPatientName.EditValue = "";
            this.fld_txtMEPatientName.Enabled = false;
            this.fld_txtMEPatientName.Location = new System.Drawing.Point(196, 106);
            this.fld_txtMEPatientName.Name = "fld_txtMEPatientName";
            this.fld_txtMEPatientName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEPatientName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEPatientName.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEPatientName.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEPatientName.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEPatientName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEPatientName.Screen = null;
            this.fld_txtMEPatientName.Size = new System.Drawing.Size(222, 20);
            this.fld_txtMEPatientName.TabIndex = 1000000011;
            this.fld_txtMEPatientName.Tag = "SC";
            // 
            // fld_txtMEPatientNo
            // 
            this.fld_txtMEPatientNo.BOSComment = "";
            this.fld_txtMEPatientNo.BOSDataMember = "MEPatientNo";
            this.fld_txtMEPatientNo.BOSDataSource = "MEPatients";
            this.fld_txtMEPatientNo.BOSDescription = null;
            this.fld_txtMEPatientNo.BOSError = null;
            this.fld_txtMEPatientNo.BOSFieldGroup = "";
            this.fld_txtMEPatientNo.BOSFieldRelation = "";
            this.fld_txtMEPatientNo.BOSPrivilege = "";
            this.fld_txtMEPatientNo.BOSPropertyName = "Text";
            this.fld_txtMEPatientNo.EditValue = "";
            this.fld_txtMEPatientNo.Location = new System.Drawing.Point(103, 106);
            this.fld_txtMEPatientNo.Name = "fld_txtMEPatientNo";
            this.fld_txtMEPatientNo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEPatientNo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEPatientNo.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEPatientNo.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEPatientNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEPatientNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEPatientNo.Screen = null;
            this.fld_txtMEPatientNo.Size = new System.Drawing.Size(87, 20);
            this.fld_txtMEPatientNo.TabIndex = 7;
            this.fld_txtMEPatientNo.Tag = "SC";
            // 
            // btnSearchPatient
            // 
            this.btnSearchPatient.Location = new System.Drawing.Point(425, 105);
            this.btnSearchPatient.Name = "btnSearchPatient";
            this.btnSearchPatient.Size = new System.Drawing.Size(91, 23);
            this.btnSearchPatient.TabIndex = 8;
            this.btnSearchPatient.Tag = "SC";
            this.btnSearchPatient.Text = "Chọn bệnh nhân";
            this.btnSearchPatient.Click += new System.EventHandler(this.btnSearchPatient_Click);
            // 
            // SMMEEMR100
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(673, 420);
            this.Controls.Add(this.btnSearchPatient);
            this.Controls.Add(this.fld_txtMEPatientName);
            this.Controls.Add(this.fld_txtMEPatientNo);
            this.Controls.Add(this.chkEmrCurrentShared);
            this.Controls.Add(this.chkDepartmentShared);
            this.Controls.Add(this.fld_ccbeFK_HRDepartmentID1);
            this.Controls.Add(this.bosLabel4);
            this.Controls.Add(this.fld_dteMEEmrCreatedDateSearchTo);
            this.Controls.Add(this.fld_dteMEEmrCreatedDateSearchFrom);
            this.Controls.Add(this.bosLabel3);
            this.Controls.Add(this.fld_lkeFK_MEEmrTypeID);
            this.Controls.Add(this.fld_lkeMEEmrStatus);
            this.Controls.Add(this.bosLabel5);
            this.Controls.Add(this.bosLabel6);
            this.Controls.Add(this.fld_dgcMEEmr);
            this.Controls.Add(this.fld_txtMEEmrNo);
            this.Controls.Add(this.fld_lkeFK_MEPatientID);
            this.Controls.Add(this.fld_lblLabel);
            this.Controls.Add(this.fld_lblLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SMMEEMR100";
            this.Text = "Tìm kiếm";
            this.Controls.SetChildIndex(this.fld_lblLabel1, 0);
            this.Controls.SetChildIndex(this.fld_lblLabel, 0);
            this.Controls.SetChildIndex(this.fld_lkeFK_MEPatientID, 0);
            this.Controls.SetChildIndex(this.fld_txtMEEmrNo, 0);
            this.Controls.SetChildIndex(this.fld_dgcMEEmr, 0);
            this.Controls.SetChildIndex(this.bosLabel6, 0);
            this.Controls.SetChildIndex(this.bosLabel5, 0);
            this.Controls.SetChildIndex(this.fld_lkeMEEmrStatus, 0);
            this.Controls.SetChildIndex(this.fld_lkeFK_MEEmrTypeID, 0);
            this.Controls.SetChildIndex(this.bosLabel3, 0);
            this.Controls.SetChildIndex(this.fld_dteMEEmrCreatedDateSearchFrom, 0);
            this.Controls.SetChildIndex(this.fld_dteMEEmrCreatedDateSearchTo, 0);
            this.Controls.SetChildIndex(this.bosLabel4, 0);
            this.Controls.SetChildIndex(this.fld_ccbeFK_HRDepartmentID1, 0);
            this.Controls.SetChildIndex(this.chkDepartmentShared, 0);
            this.Controls.SetChildIndex(this.chkEmrCurrentShared, 0);
            this.Controls.SetChildIndex(this.fld_txtMEPatientNo, 0);
            this.Controls.SetChildIndex(this.fld_txtMEPatientName, 0);
            this.Controls.SetChildIndex(this.btnSearchPatient, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteMEEmrCreatedDateSearchTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteMEEmrCreatedDateSearchTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteMEEmrCreatedDateSearchFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteMEEmrCreatedDateSearchFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_MEEmrTypeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEEmrStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_MEPatientID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDepartmentShared.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_ccbeFK_HRDepartmentID1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEmrCurrentShared.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEPatientName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEPatientNo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private MEEmrsSearchResultGridControl fld_dgcMEEmr;
        private IContainer components;
        private BOSComponent.BOSLabel bosLabel4;
        private BOSComponent.BOSDateEdit fld_dteMEEmrCreatedDateSearchTo;
        private BOSComponent.BOSDateEdit fld_dteMEEmrCreatedDateSearchFrom;
        private BOSComponent.BOSLabel bosLabel3;
        private BOSComponent.BOSLookupEdit fld_lkeFK_MEEmrTypeID;
        private BOSComponent.BOSLookupEdit fld_lkeMEEmrStatus;
        private BOSComponent.BOSLabel bosLabel5;
        private BOSComponent.BOSLabel bosLabel6;
        private DevExpress.XtraEditors.CheckEdit chkDepartmentShared;
        private BOSComponent.MultiColCheckedComboBoxEdit fld_ccbeFK_HRDepartmentID1;
        private DevExpress.XtraEditors.CheckEdit chkEmrCurrentShared;
        private BOSComponent.BOSTextBox fld_txtMEPatientName;
        private BOSComponent.BOSTextBox fld_txtMEPatientNo;
        private DevExpress.XtraEditors.SimpleButton btnSearchPatient;
    }
}
