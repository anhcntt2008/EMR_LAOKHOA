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
    partial class guiCreateNewPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiCreateNewPatient));
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnBoldRemove = new DevExpress.XtraEditors.CheckButton();
            this.btnUnderlineRemove = new DevExpress.XtraEditors.CheckButton();
            this.btnItalicRemove = new DevExpress.XtraEditors.CheckButton();
            this.fld_lbMEPantientType = new BOSComponent.BOSLabel(this.components);
            this.guiCreateNewPatient_fld_lkeMEPatientType = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel5 = new BOSComponent.BOSLabel(this.components);
            this.guiCreateNewPatient_fld_txtMEPatientIDCard = new BOSComponent.BOSTextBox(this.components);
            this.bosLabel1 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel7 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel8 = new BOSComponent.BOSLabel(this.components);
            this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone = new BOSComponent.BOSTextBox(this.components);
            this.guiCreateNewPatient_fld_lkeMEGender = new BOSComponent.BOSLookupEdit(this.components);
            this.fld_lblLabel11 = new BOSComponent.BOSLabel(this.components);
            this.guiCreateNewPatient_fld_dteMEPatientBirthday = new BOSComponent.BOSDateEdit(this.components);
            this.fld_lblLabel19 = new BOSComponent.BOSLabel(this.components);
            this.guiCreateNewPatient_fld_medMEPatientDesc = new BOSComponent.BOSMemoEdit(this.components);
            this.guiCreateNewPatient_fld_txtMEPatientNo1 = new BOSComponent.BOSTextBox(this.components);
            this.guiCreateNewPatient_fld_txtMEPatientName1 = new BOSComponent.BOSTextBox(this.components);
            this.bosLabel2 = new BOSComponent.BOSLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.guiCreateNewPatient_fld_lkeMEPatientType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guiCreateNewPatient_fld_txtMEPatientIDCard.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guiCreateNewPatient_fld_lkeMEGender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guiCreateNewPatient_fld_dteMEPatientBirthday.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guiCreateNewPatient_fld_dteMEPatientBirthday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guiCreateNewPatient_fld_medMEPatientDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guiCreateNewPatient_fld_txtMEPatientNo1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guiCreateNewPatient_fld_txtMEPatientName1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnOk.Location = new System.Drawing.Point(313, 182);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(98, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Tạo (Alt+O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(417, 181);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Hủy";
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
            // fld_lbMEPantientType
            // 
            this.fld_lbMEPantientType.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lbMEPantientType.Appearance.ForeColor = System.Drawing.Color.Black;
            this.fld_lbMEPantientType.Appearance.Options.UseBackColor = true;
            this.fld_lbMEPantientType.Appearance.Options.UseForeColor = true;
            this.fld_lbMEPantientType.BOSComment = "";
            this.fld_lbMEPantientType.BOSDataMember = "";
            this.fld_lbMEPantientType.BOSDataSource = "";
            this.fld_lbMEPantientType.BOSDescription = null;
            this.fld_lbMEPantientType.BOSError = null;
            this.fld_lbMEPantientType.BOSFieldGroup = "";
            this.fld_lbMEPantientType.BOSFieldRelation = "";
            this.fld_lbMEPantientType.BOSPrivilege = "";
            this.fld_lbMEPantientType.BOSPropertyName = "";
            this.fld_lbMEPantientType.Location = new System.Drawing.Point(276, 95);
            this.fld_lbMEPantientType.Name = "fld_lbMEPantientType";
            this.fld_lbMEPantientType.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_lbMEPantientType, true);
            this.fld_lbMEPantientType.Size = new System.Drawing.Size(73, 13);
            this.fld_lbMEPantientType.TabIndex = 52;
            this.fld_lbMEPantientType.Tag = "";
            this.fld_lbMEPantientType.Text = "Loại bệnh nhân";
            // 
            // guiCreateNewPatient_fld_lkeMEPatientType
            // 
            this.guiCreateNewPatient_fld_lkeMEPatientType.BOSAllowAddNew = false;
            this.guiCreateNewPatient_fld_lkeMEPatientType.BOSAllowDummy = false;
            this.guiCreateNewPatient_fld_lkeMEPatientType.BOSComment = "";
            this.guiCreateNewPatient_fld_lkeMEPatientType.BOSDataMember = "MEPatientType";
            this.guiCreateNewPatient_fld_lkeMEPatientType.BOSDataSource = "MEPatients";
            this.guiCreateNewPatient_fld_lkeMEPatientType.BOSDescription = null;
            this.guiCreateNewPatient_fld_lkeMEPatientType.BOSDummyText = null;
            this.guiCreateNewPatient_fld_lkeMEPatientType.BOSError = null;
            this.guiCreateNewPatient_fld_lkeMEPatientType.BOSFieldGroup = "";
            this.guiCreateNewPatient_fld_lkeMEPatientType.BOSFieldParent = "";
            this.guiCreateNewPatient_fld_lkeMEPatientType.BOSFieldRelation = "";
            this.guiCreateNewPatient_fld_lkeMEPatientType.BOSPrivilege = "";
            this.guiCreateNewPatient_fld_lkeMEPatientType.BOSPropertyName = "EditValue";
            this.guiCreateNewPatient_fld_lkeMEPatientType.BOSSelectType = "";
            this.guiCreateNewPatient_fld_lkeMEPatientType.BOSSelectTypeValue = "";
            this.guiCreateNewPatient_fld_lkeMEPatientType.CurrentDisplayText = null;
            this.guiCreateNewPatient_fld_lkeMEPatientType.Enabled = false;
            this.guiCreateNewPatient_fld_lkeMEPatientType.Location = new System.Drawing.Point(352, 90);
            this.guiCreateNewPatient_fld_lkeMEPatientType.Name = "guiCreateNewPatient_fld_lkeMEPatientType";
            this.guiCreateNewPatient_fld_lkeMEPatientType.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.guiCreateNewPatient_fld_lkeMEPatientType.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.guiCreateNewPatient_fld_lkeMEPatientType.Properties.Appearance.Options.UseBackColor = true;
            this.guiCreateNewPatient_fld_lkeMEPatientType.Properties.Appearance.Options.UseForeColor = true;
            this.guiCreateNewPatient_fld_lkeMEPatientType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.guiCreateNewPatient_fld_lkeMEPatientType.Properties.NullText = "";
            this.guiCreateNewPatient_fld_lkeMEPatientType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.guiCreateNewPatient_fld_lkeMEPatientType.Screen = null;
            this.ScreenHelper.SetShowHelp(this.guiCreateNewPatient_fld_lkeMEPatientType, true);
            this.guiCreateNewPatient_fld_lkeMEPatientType.Size = new System.Drawing.Size(141, 20);
            this.guiCreateNewPatient_fld_lkeMEPatientType.TabIndex = 51;
            this.guiCreateNewPatient_fld_lkeMEPatientType.Tag = "DC";
            // 
            // bosLabel5
            // 
            this.bosLabel5.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel5.Appearance.ForeColor = System.Drawing.Color.Black;
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
            this.bosLabel5.Location = new System.Drawing.Point(276, 67);
            this.bosLabel5.Name = "bosLabel5";
            this.bosLabel5.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel5, true);
            this.bosLabel5.Size = new System.Drawing.Size(44, 13);
            this.bosLabel5.TabIndex = 55;
            this.bosLabel5.Tag = "";
            this.bosLabel5.Text = "Số CMND";
            // 
            // guiCreateNewPatient_fld_txtMEPatientIDCard
            // 
            this.guiCreateNewPatient_fld_txtMEPatientIDCard.BOSComment = "";
            this.guiCreateNewPatient_fld_txtMEPatientIDCard.BOSDataMember = "MEPatientIDCard";
            this.guiCreateNewPatient_fld_txtMEPatientIDCard.BOSDataSource = "MEPatients";
            this.guiCreateNewPatient_fld_txtMEPatientIDCard.BOSDescription = null;
            this.guiCreateNewPatient_fld_txtMEPatientIDCard.BOSError = null;
            this.guiCreateNewPatient_fld_txtMEPatientIDCard.BOSFieldGroup = "";
            this.guiCreateNewPatient_fld_txtMEPatientIDCard.BOSFieldRelation = "";
            this.guiCreateNewPatient_fld_txtMEPatientIDCard.BOSPrivilege = "";
            this.guiCreateNewPatient_fld_txtMEPatientIDCard.BOSPropertyName = "Text";
            this.guiCreateNewPatient_fld_txtMEPatientIDCard.EditValue = "";
            this.guiCreateNewPatient_fld_txtMEPatientIDCard.Location = new System.Drawing.Point(352, 64);
            this.guiCreateNewPatient_fld_txtMEPatientIDCard.Name = "guiCreateNewPatient_fld_txtMEPatientIDCard";
            this.guiCreateNewPatient_fld_txtMEPatientIDCard.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.guiCreateNewPatient_fld_txtMEPatientIDCard.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.guiCreateNewPatient_fld_txtMEPatientIDCard.Properties.Appearance.Options.UseBackColor = true;
            this.guiCreateNewPatient_fld_txtMEPatientIDCard.Properties.Appearance.Options.UseForeColor = true;
            this.guiCreateNewPatient_fld_txtMEPatientIDCard.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.guiCreateNewPatient_fld_txtMEPatientIDCard.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.guiCreateNewPatient_fld_txtMEPatientIDCard.Screen = null;
            this.ScreenHelper.SetShowHelp(this.guiCreateNewPatient_fld_txtMEPatientIDCard, true);
            this.guiCreateNewPatient_fld_txtMEPatientIDCard.Size = new System.Drawing.Size(141, 20);
            this.guiCreateNewPatient_fld_txtMEPatientIDCard.TabIndex = 3;
            this.guiCreateNewPatient_fld_txtMEPatientIDCard.Tag = "DC";
            // 
            // bosLabel1
            // 
            this.bosLabel1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel1.Appearance.ForeColor = System.Drawing.Color.Black;
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
            this.bosLabel1.Location = new System.Drawing.Point(12, 41);
            this.bosLabel1.Name = "bosLabel1";
            this.bosLabel1.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel1, true);
            this.bosLabel1.Size = new System.Drawing.Size(72, 13);
            this.bosLabel1.TabIndex = 40;
            this.bosLabel1.Tag = "";
            this.bosLabel1.Text = "Tên bệnh nhân";
            // 
            // fld_lblLabel7
            // 
            this.fld_lblLabel7.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel7.Appearance.ForeColor = System.Drawing.Color.Black;
            this.fld_lblLabel7.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel7.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel7.BOSComment = "";
            this.fld_lblLabel7.BOSDataMember = "";
            this.fld_lblLabel7.BOSDataSource = "";
            this.fld_lblLabel7.BOSDescription = null;
            this.fld_lblLabel7.BOSError = null;
            this.fld_lblLabel7.BOSFieldGroup = "";
            this.fld_lblLabel7.BOSFieldRelation = "";
            this.fld_lblLabel7.BOSPrivilege = "";
            this.fld_lblLabel7.BOSPropertyName = "";
            this.fld_lblLabel7.Location = new System.Drawing.Point(276, 41);
            this.fld_lblLabel7.Name = "fld_lblLabel7";
            this.fld_lblLabel7.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_lblLabel7, true);
            this.fld_lblLabel7.Size = new System.Drawing.Size(38, 13);
            this.fld_lblLabel7.TabIndex = 49;
            this.fld_lblLabel7.Tag = "";
            this.fld_lblLabel7.Text = "Giới tính";
            // 
            // fld_lblLabel8
            // 
            this.fld_lblLabel8.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel8.Appearance.ForeColor = System.Drawing.Color.Black;
            this.fld_lblLabel8.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel8.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel8.BOSComment = "";
            this.fld_lblLabel8.BOSDataMember = "";
            this.fld_lblLabel8.BOSDataSource = "";
            this.fld_lblLabel8.BOSDescription = null;
            this.fld_lblLabel8.BOSError = null;
            this.fld_lblLabel8.BOSFieldGroup = "";
            this.fld_lblLabel8.BOSFieldRelation = "";
            this.fld_lblLabel8.BOSPrivilege = "";
            this.fld_lblLabel8.BOSPropertyName = "";
            this.fld_lblLabel8.Location = new System.Drawing.Point(12, 95);
            this.fld_lblLabel8.Name = "fld_lblLabel8";
            this.fld_lblLabel8.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_lblLabel8, true);
            this.fld_lblLabel8.Size = new System.Drawing.Size(49, 13);
            this.fld_lblLabel8.TabIndex = 53;
            this.fld_lblLabel8.Tag = "";
            this.fld_lblLabel8.Text = "Điện thoại";
            // 
            // guiCreateNewPatient_fld_txtMEPatientContactCellPhone
            // 
            this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone.BOSComment = "";
            this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone.BOSDataMember = "MEPatientContactCellPhone";
            this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone.BOSDataSource = "MEPatients";
            this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone.BOSDescription = null;
            this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone.BOSError = null;
            this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone.BOSFieldGroup = "";
            this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone.BOSFieldRelation = "";
            this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone.BOSPrivilege = "";
            this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone.BOSPropertyName = "Text";
            this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone.EditValue = "";
            this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone.Location = new System.Drawing.Point(98, 92);
            this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone.Name = "guiCreateNewPatient_fld_txtMEPatientContactCellPhone";
            this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone.Properties.Appearance.Options.UseBackColor = true;
            this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone.Properties.Appearance.Options.UseForeColor = true;
            this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone.Screen = null;
            this.ScreenHelper.SetShowHelp(this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone, true);
            this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone.Size = new System.Drawing.Size(172, 20);
            this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone.TabIndex = 4;
            this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone.Tag = "DC";
            // 
            // guiCreateNewPatient_fld_lkeMEGender
            // 
            this.guiCreateNewPatient_fld_lkeMEGender.BOSAllowAddNew = false;
            this.guiCreateNewPatient_fld_lkeMEGender.BOSAllowDummy = false;
            this.guiCreateNewPatient_fld_lkeMEGender.BOSComment = "";
            this.guiCreateNewPatient_fld_lkeMEGender.BOSDataMember = "MEGender";
            this.guiCreateNewPatient_fld_lkeMEGender.BOSDataSource = "MEPatients";
            this.guiCreateNewPatient_fld_lkeMEGender.BOSDescription = null;
            this.guiCreateNewPatient_fld_lkeMEGender.BOSDummyText = null;
            this.guiCreateNewPatient_fld_lkeMEGender.BOSError = null;
            this.guiCreateNewPatient_fld_lkeMEGender.BOSFieldGroup = "";
            this.guiCreateNewPatient_fld_lkeMEGender.BOSFieldParent = "";
            this.guiCreateNewPatient_fld_lkeMEGender.BOSFieldRelation = "";
            this.guiCreateNewPatient_fld_lkeMEGender.BOSPrivilege = "";
            this.guiCreateNewPatient_fld_lkeMEGender.BOSPropertyName = "EditValue";
            this.guiCreateNewPatient_fld_lkeMEGender.BOSSelectType = "";
            this.guiCreateNewPatient_fld_lkeMEGender.BOSSelectTypeValue = "";
            this.guiCreateNewPatient_fld_lkeMEGender.CurrentDisplayText = null;
            this.guiCreateNewPatient_fld_lkeMEGender.Location = new System.Drawing.Point(352, 38);
            this.guiCreateNewPatient_fld_lkeMEGender.Name = "guiCreateNewPatient_fld_lkeMEGender";
            this.guiCreateNewPatient_fld_lkeMEGender.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.guiCreateNewPatient_fld_lkeMEGender.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.guiCreateNewPatient_fld_lkeMEGender.Properties.Appearance.Options.UseBackColor = true;
            this.guiCreateNewPatient_fld_lkeMEGender.Properties.Appearance.Options.UseForeColor = true;
            this.guiCreateNewPatient_fld_lkeMEGender.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.guiCreateNewPatient_fld_lkeMEGender.Properties.NullText = "";
            this.guiCreateNewPatient_fld_lkeMEGender.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.guiCreateNewPatient_fld_lkeMEGender.Screen = null;
            this.ScreenHelper.SetShowHelp(this.guiCreateNewPatient_fld_lkeMEGender, true);
            this.guiCreateNewPatient_fld_lkeMEGender.Size = new System.Drawing.Size(141, 20);
            this.guiCreateNewPatient_fld_lkeMEGender.TabIndex = 1;
            this.guiCreateNewPatient_fld_lkeMEGender.Tag = "DC";
            // 
            // fld_lblLabel11
            // 
            this.fld_lblLabel11.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel11.Appearance.ForeColor = System.Drawing.Color.Black;
            this.fld_lblLabel11.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel11.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel11.BOSComment = "";
            this.fld_lblLabel11.BOSDataMember = "";
            this.fld_lblLabel11.BOSDataSource = "";
            this.fld_lblLabel11.BOSDescription = null;
            this.fld_lblLabel11.BOSError = null;
            this.fld_lblLabel11.BOSFieldGroup = "";
            this.fld_lblLabel11.BOSFieldRelation = "";
            this.fld_lblLabel11.BOSPrivilege = "";
            this.fld_lblLabel11.BOSPropertyName = "";
            this.fld_lblLabel11.Location = new System.Drawing.Point(12, 67);
            this.fld_lblLabel11.Name = "fld_lblLabel11";
            this.fld_lblLabel11.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_lblLabel11, true);
            this.fld_lblLabel11.Size = new System.Drawing.Size(47, 13);
            this.fld_lblLabel11.TabIndex = 48;
            this.fld_lblLabel11.Tag = "";
            this.fld_lblLabel11.Text = "Ngày sinh";
            // 
            // guiCreateNewPatient_fld_dteMEPatientBirthday
            // 
            this.guiCreateNewPatient_fld_dteMEPatientBirthday.BOSComment = "";
            this.guiCreateNewPatient_fld_dteMEPatientBirthday.BOSDataMember = "MEPatientBirthday";
            this.guiCreateNewPatient_fld_dteMEPatientBirthday.BOSDataSource = "MEPatients";
            this.guiCreateNewPatient_fld_dteMEPatientBirthday.BOSDescription = null;
            this.guiCreateNewPatient_fld_dteMEPatientBirthday.BOSError = null;
            this.guiCreateNewPatient_fld_dteMEPatientBirthday.BOSFieldGroup = "";
            this.guiCreateNewPatient_fld_dteMEPatientBirthday.BOSFieldRelation = "";
            this.guiCreateNewPatient_fld_dteMEPatientBirthday.BOSPrivilege = "";
            this.guiCreateNewPatient_fld_dteMEPatientBirthday.BOSPropertyName = "EditValue";
            this.guiCreateNewPatient_fld_dteMEPatientBirthday.EditValue = null;
            this.guiCreateNewPatient_fld_dteMEPatientBirthday.Location = new System.Drawing.Point(98, 66);
            this.guiCreateNewPatient_fld_dteMEPatientBirthday.Name = "guiCreateNewPatient_fld_dteMEPatientBirthday";
            this.guiCreateNewPatient_fld_dteMEPatientBirthday.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.guiCreateNewPatient_fld_dteMEPatientBirthday.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.guiCreateNewPatient_fld_dteMEPatientBirthday.Properties.Appearance.Options.UseBackColor = true;
            this.guiCreateNewPatient_fld_dteMEPatientBirthday.Properties.Appearance.Options.UseForeColor = true;
            this.guiCreateNewPatient_fld_dteMEPatientBirthday.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.guiCreateNewPatient_fld_dteMEPatientBirthday.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.guiCreateNewPatient_fld_dteMEPatientBirthday.Screen = null;
            this.ScreenHelper.SetShowHelp(this.guiCreateNewPatient_fld_dteMEPatientBirthday, true);
            this.guiCreateNewPatient_fld_dteMEPatientBirthday.Size = new System.Drawing.Size(172, 20);
            this.guiCreateNewPatient_fld_dteMEPatientBirthday.TabIndex = 2;
            this.guiCreateNewPatient_fld_dteMEPatientBirthday.Tag = "DC";
            // 
            // fld_lblLabel19
            // 
            this.fld_lblLabel19.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.fld_lblLabel19.Appearance.ForeColor = System.Drawing.Color.Black;
            this.fld_lblLabel19.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel19.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel19.BOSComment = "";
            this.fld_lblLabel19.BOSDataMember = "";
            this.fld_lblLabel19.BOSDataSource = "";
            this.fld_lblLabel19.BOSDescription = null;
            this.fld_lblLabel19.BOSError = null;
            this.fld_lblLabel19.BOSFieldGroup = "";
            this.fld_lblLabel19.BOSFieldRelation = "";
            this.fld_lblLabel19.BOSPrivilege = "";
            this.fld_lblLabel19.BOSPropertyName = "";
            this.fld_lblLabel19.Location = new System.Drawing.Point(12, 120);
            this.fld_lblLabel19.Name = "fld_lblLabel19";
            this.fld_lblLabel19.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_lblLabel19, true);
            this.fld_lblLabel19.Size = new System.Drawing.Size(35, 13);
            this.fld_lblLabel19.TabIndex = 54;
            this.fld_lblLabel19.Tag = "";
            this.fld_lblLabel19.Text = "Ghi chú";
            // 
            // guiCreateNewPatient_fld_medMEPatientDesc
            // 
            this.guiCreateNewPatient_fld_medMEPatientDesc.BOSComment = "";
            this.guiCreateNewPatient_fld_medMEPatientDesc.BOSDataMember = "MEPatientDesc";
            this.guiCreateNewPatient_fld_medMEPatientDesc.BOSDataSource = "MEPatients";
            this.guiCreateNewPatient_fld_medMEPatientDesc.BOSDescription = null;
            this.guiCreateNewPatient_fld_medMEPatientDesc.BOSError = null;
            this.guiCreateNewPatient_fld_medMEPatientDesc.BOSFieldGroup = "";
            this.guiCreateNewPatient_fld_medMEPatientDesc.BOSFieldRelation = "";
            this.guiCreateNewPatient_fld_medMEPatientDesc.BOSPrivilege = "";
            this.guiCreateNewPatient_fld_medMEPatientDesc.BOSPropertyName = "Text";
            this.guiCreateNewPatient_fld_medMEPatientDesc.EditValue = "";
            this.guiCreateNewPatient_fld_medMEPatientDesc.Location = new System.Drawing.Point(98, 118);
            this.guiCreateNewPatient_fld_medMEPatientDesc.Name = "guiCreateNewPatient_fld_medMEPatientDesc";
            this.guiCreateNewPatient_fld_medMEPatientDesc.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.guiCreateNewPatient_fld_medMEPatientDesc.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.guiCreateNewPatient_fld_medMEPatientDesc.Properties.Appearance.Options.UseBackColor = true;
            this.guiCreateNewPatient_fld_medMEPatientDesc.Properties.Appearance.Options.UseForeColor = true;
            this.guiCreateNewPatient_fld_medMEPatientDesc.Screen = null;
            this.ScreenHelper.SetShowHelp(this.guiCreateNewPatient_fld_medMEPatientDesc, true);
            this.guiCreateNewPatient_fld_medMEPatientDesc.Size = new System.Drawing.Size(395, 57);
            this.guiCreateNewPatient_fld_medMEPatientDesc.TabIndex = 5;
            this.guiCreateNewPatient_fld_medMEPatientDesc.Tag = "DC";
            // 
            // guiCreateNewPatient_fld_txtMEPatientNo1
            // 
            this.guiCreateNewPatient_fld_txtMEPatientNo1.BOSComment = "";
            this.guiCreateNewPatient_fld_txtMEPatientNo1.BOSDataMember = "MEPatientNo";
            this.guiCreateNewPatient_fld_txtMEPatientNo1.BOSDataSource = "MEPatients";
            this.guiCreateNewPatient_fld_txtMEPatientNo1.BOSDescription = null;
            this.guiCreateNewPatient_fld_txtMEPatientNo1.BOSError = null;
            this.guiCreateNewPatient_fld_txtMEPatientNo1.BOSFieldGroup = "";
            this.guiCreateNewPatient_fld_txtMEPatientNo1.BOSFieldRelation = "";
            this.guiCreateNewPatient_fld_txtMEPatientNo1.BOSPrivilege = "";
            this.guiCreateNewPatient_fld_txtMEPatientNo1.BOSPropertyName = "Text";
            this.guiCreateNewPatient_fld_txtMEPatientNo1.EditValue = "";
            this.guiCreateNewPatient_fld_txtMEPatientNo1.Enabled = false;
            this.guiCreateNewPatient_fld_txtMEPatientNo1.Location = new System.Drawing.Point(98, 12);
            this.guiCreateNewPatient_fld_txtMEPatientNo1.Name = "guiCreateNewPatient_fld_txtMEPatientNo1";
            this.guiCreateNewPatient_fld_txtMEPatientNo1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.guiCreateNewPatient_fld_txtMEPatientNo1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.guiCreateNewPatient_fld_txtMEPatientNo1.Properties.Appearance.Options.UseBackColor = true;
            this.guiCreateNewPatient_fld_txtMEPatientNo1.Properties.Appearance.Options.UseForeColor = true;
            this.guiCreateNewPatient_fld_txtMEPatientNo1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.guiCreateNewPatient_fld_txtMEPatientNo1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.guiCreateNewPatient_fld_txtMEPatientNo1.Screen = null;
            this.ScreenHelper.SetShowHelp(this.guiCreateNewPatient_fld_txtMEPatientNo1, true);
            this.guiCreateNewPatient_fld_txtMEPatientNo1.Size = new System.Drawing.Size(172, 20);
            this.guiCreateNewPatient_fld_txtMEPatientNo1.TabIndex = 41;
            this.guiCreateNewPatient_fld_txtMEPatientNo1.TabStop = false;
            this.guiCreateNewPatient_fld_txtMEPatientNo1.Tag = "DC";
            // 
            // guiCreateNewPatient_fld_txtMEPatientName1
            // 
            this.guiCreateNewPatient_fld_txtMEPatientName1.BOSComment = "";
            this.guiCreateNewPatient_fld_txtMEPatientName1.BOSDataMember = "MEPatientName";
            this.guiCreateNewPatient_fld_txtMEPatientName1.BOSDataSource = "MEPatients";
            this.guiCreateNewPatient_fld_txtMEPatientName1.BOSDescription = null;
            this.guiCreateNewPatient_fld_txtMEPatientName1.BOSError = null;
            this.guiCreateNewPatient_fld_txtMEPatientName1.BOSFieldGroup = "";
            this.guiCreateNewPatient_fld_txtMEPatientName1.BOSFieldRelation = "";
            this.guiCreateNewPatient_fld_txtMEPatientName1.BOSPrivilege = "";
            this.guiCreateNewPatient_fld_txtMEPatientName1.BOSPropertyName = "Text";
            this.guiCreateNewPatient_fld_txtMEPatientName1.EditValue = "";
            this.guiCreateNewPatient_fld_txtMEPatientName1.Location = new System.Drawing.Point(98, 38);
            this.guiCreateNewPatient_fld_txtMEPatientName1.Name = "guiCreateNewPatient_fld_txtMEPatientName1";
            this.guiCreateNewPatient_fld_txtMEPatientName1.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.guiCreateNewPatient_fld_txtMEPatientName1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.guiCreateNewPatient_fld_txtMEPatientName1.Properties.Appearance.Options.UseBackColor = true;
            this.guiCreateNewPatient_fld_txtMEPatientName1.Properties.Appearance.Options.UseForeColor = true;
            this.guiCreateNewPatient_fld_txtMEPatientName1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.guiCreateNewPatient_fld_txtMEPatientName1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.guiCreateNewPatient_fld_txtMEPatientName1.Screen = null;
            this.ScreenHelper.SetShowHelp(this.guiCreateNewPatient_fld_txtMEPatientName1, true);
            this.guiCreateNewPatient_fld_txtMEPatientName1.Size = new System.Drawing.Size(172, 20);
            this.guiCreateNewPatient_fld_txtMEPatientName1.TabIndex = 0;
            this.guiCreateNewPatient_fld_txtMEPatientName1.Tag = "DC";
            // 
            // bosLabel2
            // 
            this.bosLabel2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel2.Appearance.ForeColor = System.Drawing.Color.Black;
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
            this.ScreenHelper.SetShowHelp(this.bosLabel2, true);
            this.bosLabel2.Size = new System.Drawing.Size(68, 13);
            this.bosLabel2.TabIndex = 56;
            this.bosLabel2.Tag = "";
            this.bosLabel2.Text = "Mã bệnh nhân";
            // 
            // guiCreateNewPatient
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(502, 209);
            this.ControlBox = true;
            this.Controls.Add(this.bosLabel2);
            this.Controls.Add(this.fld_lbMEPantientType);
            this.Controls.Add(this.guiCreateNewPatient_fld_lkeMEPatientType);
            this.Controls.Add(this.bosLabel5);
            this.Controls.Add(this.guiCreateNewPatient_fld_txtMEPatientIDCard);
            this.Controls.Add(this.bosLabel1);
            this.Controls.Add(this.fld_lblLabel7);
            this.Controls.Add(this.fld_lblLabel8);
            this.Controls.Add(this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone);
            this.Controls.Add(this.guiCreateNewPatient_fld_lkeMEGender);
            this.Controls.Add(this.fld_lblLabel11);
            this.Controls.Add(this.guiCreateNewPatient_fld_dteMEPatientBirthday);
            this.Controls.Add(this.fld_lblLabel19);
            this.Controls.Add(this.guiCreateNewPatient_fld_medMEPatientDesc);
            this.Controls.Add(this.guiCreateNewPatient_fld_txtMEPatientNo1);
            this.Controls.Add(this.guiCreateNewPatient_fld_txtMEPatientName1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiCreateNewPatient";
            this.Text = "Tạo mới bệnh nhân";
            this.Load += new System.EventHandler(this.DSMEEMR100_Load);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.guiCreateNewPatient_fld_txtMEPatientName1, 0);
            this.Controls.SetChildIndex(this.guiCreateNewPatient_fld_txtMEPatientNo1, 0);
            this.Controls.SetChildIndex(this.guiCreateNewPatient_fld_medMEPatientDesc, 0);
            this.Controls.SetChildIndex(this.fld_lblLabel19, 0);
            this.Controls.SetChildIndex(this.guiCreateNewPatient_fld_dteMEPatientBirthday, 0);
            this.Controls.SetChildIndex(this.fld_lblLabel11, 0);
            this.Controls.SetChildIndex(this.guiCreateNewPatient_fld_lkeMEGender, 0);
            this.Controls.SetChildIndex(this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone, 0);
            this.Controls.SetChildIndex(this.fld_lblLabel8, 0);
            this.Controls.SetChildIndex(this.fld_lblLabel7, 0);
            this.Controls.SetChildIndex(this.bosLabel1, 0);
            this.Controls.SetChildIndex(this.guiCreateNewPatient_fld_txtMEPatientIDCard, 0);
            this.Controls.SetChildIndex(this.bosLabel5, 0);
            this.Controls.SetChildIndex(this.guiCreateNewPatient_fld_lkeMEPatientType, 0);
            this.Controls.SetChildIndex(this.fld_lbMEPantientType, 0);
            this.Controls.SetChildIndex(this.bosLabel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.guiCreateNewPatient_fld_lkeMEPatientType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guiCreateNewPatient_fld_txtMEPatientIDCard.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guiCreateNewPatient_fld_txtMEPatientContactCellPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guiCreateNewPatient_fld_lkeMEGender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guiCreateNewPatient_fld_dteMEPatientBirthday.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guiCreateNewPatient_fld_dteMEPatientBirthday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guiCreateNewPatient_fld_medMEPatientDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guiCreateNewPatient_fld_txtMEPatientNo1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guiCreateNewPatient_fld_txtMEPatientName1.Properties)).EndInit();
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
        private BOSLabel fld_lbMEPantientType;
        private BOSLookupEdit guiCreateNewPatient_fld_lkeMEPatientType;
        private BOSLabel bosLabel5;
        private BOSTextBox guiCreateNewPatient_fld_txtMEPatientIDCard;
        private BOSLabel bosLabel1;
        private BOSLabel fld_lblLabel7;
        private BOSLabel fld_lblLabel8;
        private BOSTextBox guiCreateNewPatient_fld_txtMEPatientContactCellPhone;
        private BOSLookupEdit guiCreateNewPatient_fld_lkeMEGender;
        private BOSLabel fld_lblLabel11;
        private BOSDateEdit guiCreateNewPatient_fld_dteMEPatientBirthday;
        private BOSLabel fld_lblLabel19;
        private BOSMemoEdit guiCreateNewPatient_fld_medMEPatientDesc;
        private BOSTextBox guiCreateNewPatient_fld_txtMEPatientNo1;
        private BOSTextBox guiCreateNewPatient_fld_txtMEPatientName1;
        private BOSLabel bosLabel2;
    }
}
