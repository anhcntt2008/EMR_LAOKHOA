using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.SellStaff.UI
{
	/// <summary>
	/// Summary description for DMMEEM101
	/// </summary>
	partial class DMSS100
	{
		private BOSComponent.BOSGroupControl fld_grcGroupControl3;
		private BOSComponent.BOSLabel fld_lblLabel60;
        private BOSComponent.BOSLabel fld_lblLabel34;
		private BOSComponent.BOSTextBox fld_txtHREmployeeContractSlrAmt;
        private BOSComponent.BOSTextBox fld_txtHREmployeeWorkingSlrAmt;
		private BOSComponent.BOSGroupControl fld_grcGroupControl4;
		private BOSComponent.BOSLabel fld_lblLabel40;
		private BOSComponent.BOSLabel fld_lblLabel41;
		private BOSComponent.BOSLabel fld_lblLabel42;
        private BOSComponent.BOSLabel fld_lblLabel43;
		private BOSComponent.BOSLabel fld_lblLabel45;
        private BOSComponent.BOSTextBox fld_txtHREmployeeSocialInsNo;
		private BOSComponent.BOSDateEdit fld_dteHREmployeeSocialInsRegisteredDate;
		private BOSComponent.BOSDateEdit fld_dteHREmployeeSocialInsExpiryDate;
        private BOSComponent.BOSTextBox fld_txtHREmployeeSocialInsPaymentPercent;
        private BOSComponent.BOSLookupEdit fld_lkeHRInsCalculatedSalaryType;
		private BOSComponent.BOSTextBox fld_txtHREmployeeHealthInsNo;
		private BOSComponent.BOSTextBox fld_txtHREmployeeHealthInsRegisteredPlace;
		private BOSComponent.BOSDateEdit fld_dteHREmployeeHealthInsExpiryDate;
		private BOSComponent.BOSDateEdit fld_dteHREmployeeHealthInsRegisteredDate;
		private BOSComponent.BOSLabel fld_lblLabel47;
		private BOSComponent.BOSLabel fld_lblLabel48;
		private BOSComponent.BOSLabel fld_lblLabel49;
        private BOSComponent.BOSLabel fld_lblLabel50;


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMSS100));
            this.fld_grcGroupControl3 = new BOSComponent.BOSGroupControl(this.components);
            this.bosLabel7 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtDonGiaCong = new BOSComponent.BOSTextBox(this.components);
            this.bosLabel6 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtHREmployeeExtraHarmfullSubsidies = new BOSComponent.BOSTextBox(this.components);
            this.bosLabel5 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtHREmployeeExtraResponsibility = new BOSComponent.BOSTextBox(this.components);
            this.bosLabel4 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtHREmployeeExtraLunch = new BOSComponent.BOSTextBox(this.components);
            this.bosLabel3 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtHREmployeeExtraGasolineVehicle = new BOSComponent.BOSTextBox(this.components);
            this.fld_lblLabel60 = new BOSComponent.BOSLabel(this.components);
            this.bosLookupEdit2 = new BOSComponent.BOSLookupEdit(this.components);
            this.fld_lkeHRPayRollCalculatedSalaryType = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel13 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel34 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel61 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtHREmployeeContractSlrAmt = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtHREmployeeExtraSalary1 = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtHREmployeeWorkingSlrAmt = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtHREmployeeSalaryFactor = new BOSComponent.BOSTextBox(this.components);
            this.fld_lkeFK_HREmployeePayrollFormulaID = new BOSComponent.BOSLookupEdit(this.components);
            this.fld_lkeFK_HRTimeSheetScaleID = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel1 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel2 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel9 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel8 = new BOSComponent.BOSLabel(this.components);
            this.fld_grcGroupControl4 = new BOSComponent.BOSGroupControl(this.components);
            this.fld_Line2 = new BOSComponent.BOSLine(this.components);
            this.fld_Line1 = new BOSComponent.BOSLine(this.components);
            this.fld_lblLabel38 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel36 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtHREmployeeHealthInsNo = new BOSComponent.BOSTextBox(this.components);
            this.fld_lblLabel40 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtHREmployeeHealthInsRegisteredPlace = new BOSComponent.BOSTextBox(this.components);
            this.fld_lblLabel41 = new BOSComponent.BOSLabel(this.components);
            this.fld_dteHREmployeeHealthInsExpiryDate = new BOSComponent.BOSDateEdit(this.components);
            this.fld_lblLabel42 = new BOSComponent.BOSLabel(this.components);
            this.fld_dteHREmployeeHealthInsRegisteredDate = new BOSComponent.BOSDateEdit(this.components);
            this.fld_txtHREmployeeSocialInsNo = new BOSComponent.BOSTextBox(this.components);
            this.fld_lblLabel47 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel48 = new BOSComponent.BOSLabel(this.components);
            this.fld_dteHREmployeeSocialInsRegisteredDate = new BOSComponent.BOSDateEdit(this.components);
            this.fld_lblLabel49 = new BOSComponent.BOSLabel(this.components);
            this.fld_dteHREmployeeSocialInsExpiryDate = new BOSComponent.BOSDateEdit(this.components);
            this.fld_lblLabel50 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtHREmployeeOutOfWorkInsPaymentPercent = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtHREmployeeHealthInsPaymentPercent = new BOSComponent.BOSTextBox(this.components);
            this.fld_lblLabel56 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel46 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtHREmployeeSocialInsPaymentPercent = new BOSComponent.BOSTextBox(this.components);
            this.fld_lblLabel43 = new BOSComponent.BOSLabel(this.components);
            this.fld_lkeHRInsCalculatedSalaryType = new BOSComponent.BOSLookupEdit(this.components);
            this.fld_lblLabel45 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel51 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtHREmployeeTaxPaymentAmount = new BOSComponent.BOSTextBox(this.components);
            this.fld_grcGroupControl5 = new BOSComponent.BOSGroupControl(this.components);
            this.fld_txtHREmployeeSyndicatePaymentPercent = new BOSComponent.BOSTextBox(this.components);
            this.bosLabel14 = new BOSComponent.BOSLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fld_grcGroupControl3)).BeginInit();
            this.fld_grcGroupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtDonGiaCong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeExtraHarmfullSubsidies.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeExtraResponsibility.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeExtraLunch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeExtraGasolineVehicle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosLookupEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRPayRollCalculatedSalaryType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeContractSlrAmt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeExtraSalary1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeWorkingSlrAmt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeSalaryFactor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HREmployeePayrollFormulaID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HRTimeSheetScaleID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_grcGroupControl4)).BeginInit();
            this.fld_grcGroupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeHealthInsNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeHealthInsRegisteredPlace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeHealthInsExpiryDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeHealthInsExpiryDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeHealthInsRegisteredDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeHealthInsRegisteredDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeSocialInsNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeSocialInsRegisteredDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeSocialInsRegisteredDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeSocialInsExpiryDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeSocialInsExpiryDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeOutOfWorkInsPaymentPercent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeHealthInsPaymentPercent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeSocialInsPaymentPercent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRInsCalculatedSalaryType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeTaxPaymentAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_grcGroupControl5)).BeginInit();
            this.fld_grcGroupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeSyndicatePaymentPercent.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_grcGroupControl3
            // 
            this.fld_grcGroupControl3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.fld_grcGroupControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_grcGroupControl3.Appearance.Options.UseBackColor = true;
            this.fld_grcGroupControl3.Appearance.Options.UseForeColor = true;
            this.fld_grcGroupControl3.BOSComment = "";
            this.fld_grcGroupControl3.BOSDataMember = "";
            this.fld_grcGroupControl3.BOSDataSource = "";
            this.fld_grcGroupControl3.BOSDescription = null;
            this.fld_grcGroupControl3.BOSError = null;
            this.fld_grcGroupControl3.BOSFieldGroup = "";
            this.fld_grcGroupControl3.BOSFieldRelation = "";
            this.fld_grcGroupControl3.BOSPrivilege = "";
            this.fld_grcGroupControl3.BOSPropertyName = "";
            this.fld_grcGroupControl3.Controls.Add(this.bosLabel7);
            this.fld_grcGroupControl3.Controls.Add(this.fld_txtDonGiaCong);
            this.fld_grcGroupControl3.Controls.Add(this.bosLabel6);
            this.fld_grcGroupControl3.Controls.Add(this.fld_txtHREmployeeExtraHarmfullSubsidies);
            this.fld_grcGroupControl3.Controls.Add(this.bosLabel5);
            this.fld_grcGroupControl3.Controls.Add(this.fld_txtHREmployeeExtraResponsibility);
            this.fld_grcGroupControl3.Controls.Add(this.bosLabel4);
            this.fld_grcGroupControl3.Controls.Add(this.fld_txtHREmployeeExtraLunch);
            this.fld_grcGroupControl3.Controls.Add(this.bosLabel3);
            this.fld_grcGroupControl3.Controls.Add(this.fld_txtHREmployeeExtraGasolineVehicle);
            this.fld_grcGroupControl3.Controls.Add(this.fld_lblLabel60);
            this.fld_grcGroupControl3.Controls.Add(this.bosLookupEdit2);
            this.fld_grcGroupControl3.Controls.Add(this.fld_lkeHRPayRollCalculatedSalaryType);
            this.fld_grcGroupControl3.Controls.Add(this.bosLabel13);
            this.fld_grcGroupControl3.Controls.Add(this.fld_lblLabel34);
            this.fld_grcGroupControl3.Controls.Add(this.fld_lblLabel61);
            this.fld_grcGroupControl3.Controls.Add(this.fld_txtHREmployeeContractSlrAmt);
            this.fld_grcGroupControl3.Controls.Add(this.fld_txtHREmployeeExtraSalary1);
            this.fld_grcGroupControl3.Controls.Add(this.fld_txtHREmployeeWorkingSlrAmt);
            this.fld_grcGroupControl3.Controls.Add(this.fld_txtHREmployeeSalaryFactor);
            this.fld_grcGroupControl3.Controls.Add(this.fld_lkeFK_HREmployeePayrollFormulaID);
            this.fld_grcGroupControl3.Controls.Add(this.fld_lkeFK_HRTimeSheetScaleID);
            this.fld_grcGroupControl3.Controls.Add(this.bosLabel1);
            this.fld_grcGroupControl3.Controls.Add(this.bosLabel2);
            this.fld_grcGroupControl3.Controls.Add(this.bosLabel9);
            this.fld_grcGroupControl3.Controls.Add(this.bosLabel8);
            this.fld_grcGroupControl3.Location = new System.Drawing.Point(1, 1);
            this.fld_grcGroupControl3.Name = "fld_grcGroupControl3";
            this.fld_grcGroupControl3.Screen = null;
            this.fld_grcGroupControl3.Size = new System.Drawing.Size(926, 188);
            this.fld_grcGroupControl3.TabIndex = 0;
            this.fld_grcGroupControl3.Tag = "";
            this.fld_grcGroupControl3.Text = "Chấm công && lương";
            // 
            // bosLabel7
            // 
            this.bosLabel7.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel7.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel7.Appearance.Options.UseBackColor = true;
            this.bosLabel7.Appearance.Options.UseForeColor = true;
            this.bosLabel7.BOSComment = "";
            this.bosLabel7.BOSDataMember = "";
            this.bosLabel7.BOSDataSource = "";
            this.bosLabel7.BOSDescription = null;
            this.bosLabel7.BOSError = null;
            this.bosLabel7.BOSFieldGroup = "";
            this.bosLabel7.BOSFieldRelation = "";
            this.bosLabel7.BOSPrivilege = "";
            this.bosLabel7.BOSPropertyName = "";
            this.bosLabel7.Location = new System.Drawing.Point(346, 107);
            this.bosLabel7.Name = "bosLabel7";
            this.bosLabel7.Screen = null;
            this.bosLabel7.Size = new System.Drawing.Size(63, 13);
            this.bosLabel7.TabIndex = 68;
            this.bosLabel7.Tag = "";
            this.bosLabel7.Text = "Đơn giá công";
            // 
            // fld_txtDonGiaCong
            // 
            this.fld_txtDonGiaCong.BOSComment = "";
            this.fld_txtDonGiaCong.BOSDataMember = "";
            this.fld_txtDonGiaCong.BOSDataSource = "";
            this.fld_txtDonGiaCong.BOSDescription = null;
            this.fld_txtDonGiaCong.BOSError = null;
            this.fld_txtDonGiaCong.BOSFieldGroup = "";
            this.fld_txtDonGiaCong.BOSFieldRelation = "";
            this.fld_txtDonGiaCong.BOSPrivilege = "";
            this.fld_txtDonGiaCong.BOSPropertyName = "Text";
            this.fld_txtDonGiaCong.EditValue = "";
            this.fld_txtDonGiaCong.Location = new System.Drawing.Point(468, 104);
            this.fld_txtDonGiaCong.Name = "fld_txtDonGiaCong";
            this.fld_txtDonGiaCong.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtDonGiaCong.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtDonGiaCong.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtDonGiaCong.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtDonGiaCong.Properties.Mask.EditMask = "n";
            this.fld_txtDonGiaCong.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.fld_txtDonGiaCong.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtDonGiaCong.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtDonGiaCong.Screen = null;
            this.fld_txtDonGiaCong.Size = new System.Drawing.Size(150, 20);
            this.fld_txtDonGiaCong.TabIndex = 7;
            this.fld_txtDonGiaCong.Tag = "DC";
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
            this.bosLabel6.Location = new System.Drawing.Point(346, 55);
            this.bosLabel6.Name = "bosLabel6";
            this.bosLabel6.Screen = null;
            this.bosLabel6.Size = new System.Drawing.Size(75, 13);
            this.bosLabel6.TabIndex = 66;
            this.bosLabel6.Tag = "";
            this.bosLabel6.Text = "Phụ cấp độc hại";
            // 
            // fld_txtHREmployeeExtraHarmfullSubsidies
            // 
            this.fld_txtHREmployeeExtraHarmfullSubsidies.BOSComment = "";
            this.fld_txtHREmployeeExtraHarmfullSubsidies.BOSDataMember = "HREmployeeExtraHarmfullSubsidies";
            this.fld_txtHREmployeeExtraHarmfullSubsidies.BOSDataSource = "HREmployees";
            this.fld_txtHREmployeeExtraHarmfullSubsidies.BOSDescription = null;
            this.fld_txtHREmployeeExtraHarmfullSubsidies.BOSError = null;
            this.fld_txtHREmployeeExtraHarmfullSubsidies.BOSFieldGroup = "";
            this.fld_txtHREmployeeExtraHarmfullSubsidies.BOSFieldRelation = "";
            this.fld_txtHREmployeeExtraHarmfullSubsidies.BOSPrivilege = "";
            this.fld_txtHREmployeeExtraHarmfullSubsidies.BOSPropertyName = "Text";
            this.fld_txtHREmployeeExtraHarmfullSubsidies.EditValue = "";
            this.fld_txtHREmployeeExtraHarmfullSubsidies.Location = new System.Drawing.Point(468, 52);
            this.fld_txtHREmployeeExtraHarmfullSubsidies.Name = "fld_txtHREmployeeExtraHarmfullSubsidies";
            this.fld_txtHREmployeeExtraHarmfullSubsidies.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtHREmployeeExtraHarmfullSubsidies.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtHREmployeeExtraHarmfullSubsidies.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtHREmployeeExtraHarmfullSubsidies.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtHREmployeeExtraHarmfullSubsidies.Properties.Mask.EditMask = "n";
            this.fld_txtHREmployeeExtraHarmfullSubsidies.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.fld_txtHREmployeeExtraHarmfullSubsidies.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtHREmployeeExtraHarmfullSubsidies.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtHREmployeeExtraHarmfullSubsidies.Screen = null;
            this.fld_txtHREmployeeExtraHarmfullSubsidies.Size = new System.Drawing.Size(150, 20);
            this.fld_txtHREmployeeExtraHarmfullSubsidies.TabIndex = 3;
            this.fld_txtHREmployeeExtraHarmfullSubsidies.Tag = "DC";
            this.fld_txtHREmployeeExtraHarmfullSubsidies.Leave += new System.EventHandler(this.fld_txtHREmployeeExtraHarmfullSubsidies_Leave);
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
            this.bosLabel5.Location = new System.Drawing.Point(16, 107);
            this.bosLabel5.Name = "bosLabel5";
            this.bosLabel5.Screen = null;
            this.bosLabel5.Size = new System.Drawing.Size(97, 13);
            this.bosLabel5.TabIndex = 64;
            this.bosLabel5.Tag = "";
            this.bosLabel5.Text = "Phụ cấp trách nhiệm";
            // 
            // fld_txtHREmployeeExtraResponsibility
            // 
            this.fld_txtHREmployeeExtraResponsibility.BOSComment = "";
            this.fld_txtHREmployeeExtraResponsibility.BOSDataMember = "HREmployeeExtraResponsibility";
            this.fld_txtHREmployeeExtraResponsibility.BOSDataSource = "HREmployees";
            this.fld_txtHREmployeeExtraResponsibility.BOSDescription = null;
            this.fld_txtHREmployeeExtraResponsibility.BOSError = null;
            this.fld_txtHREmployeeExtraResponsibility.BOSFieldGroup = "";
            this.fld_txtHREmployeeExtraResponsibility.BOSFieldRelation = "";
            this.fld_txtHREmployeeExtraResponsibility.BOSPrivilege = "";
            this.fld_txtHREmployeeExtraResponsibility.BOSPropertyName = "Text";
            this.fld_txtHREmployeeExtraResponsibility.EditValue = "";
            this.fld_txtHREmployeeExtraResponsibility.Location = new System.Drawing.Point(148, 104);
            this.fld_txtHREmployeeExtraResponsibility.Name = "fld_txtHREmployeeExtraResponsibility";
            this.fld_txtHREmployeeExtraResponsibility.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtHREmployeeExtraResponsibility.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtHREmployeeExtraResponsibility.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtHREmployeeExtraResponsibility.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtHREmployeeExtraResponsibility.Properties.Mask.EditMask = "n";
            this.fld_txtHREmployeeExtraResponsibility.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.fld_txtHREmployeeExtraResponsibility.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtHREmployeeExtraResponsibility.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtHREmployeeExtraResponsibility.Screen = null;
            this.fld_txtHREmployeeExtraResponsibility.Size = new System.Drawing.Size(150, 20);
            this.fld_txtHREmployeeExtraResponsibility.TabIndex = 6;
            this.fld_txtHREmployeeExtraResponsibility.Tag = "DC";
            this.fld_txtHREmployeeExtraResponsibility.Leave += new System.EventHandler(this.fld_txtHREmployeeExtraResponsibility_Leave);
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
            this.bosLabel4.Location = new System.Drawing.Point(346, 81);
            this.bosLabel4.Name = "bosLabel4";
            this.bosLabel4.Screen = null;
            this.bosLabel4.Size = new System.Drawing.Size(84, 13);
            this.bosLabel4.TabIndex = 62;
            this.bosLabel4.Tag = "";
            this.bosLabel4.Text = "Phụ cấp cơm trưa";
            // 
            // fld_txtHREmployeeExtraLunch
            // 
            this.fld_txtHREmployeeExtraLunch.BOSComment = "";
            this.fld_txtHREmployeeExtraLunch.BOSDataMember = "HREmployeeExtraLunch";
            this.fld_txtHREmployeeExtraLunch.BOSDataSource = "HREmployees";
            this.fld_txtHREmployeeExtraLunch.BOSDescription = null;
            this.fld_txtHREmployeeExtraLunch.BOSError = null;
            this.fld_txtHREmployeeExtraLunch.BOSFieldGroup = "";
            this.fld_txtHREmployeeExtraLunch.BOSFieldRelation = "";
            this.fld_txtHREmployeeExtraLunch.BOSPrivilege = "";
            this.fld_txtHREmployeeExtraLunch.BOSPropertyName = "Text";
            this.fld_txtHREmployeeExtraLunch.EditValue = "";
            this.fld_txtHREmployeeExtraLunch.Location = new System.Drawing.Point(468, 78);
            this.fld_txtHREmployeeExtraLunch.Name = "fld_txtHREmployeeExtraLunch";
            this.fld_txtHREmployeeExtraLunch.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtHREmployeeExtraLunch.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtHREmployeeExtraLunch.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtHREmployeeExtraLunch.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtHREmployeeExtraLunch.Properties.Mask.EditMask = "n";
            this.fld_txtHREmployeeExtraLunch.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.fld_txtHREmployeeExtraLunch.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtHREmployeeExtraLunch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtHREmployeeExtraLunch.Screen = null;
            this.fld_txtHREmployeeExtraLunch.Size = new System.Drawing.Size(150, 20);
            this.fld_txtHREmployeeExtraLunch.TabIndex = 5;
            this.fld_txtHREmployeeExtraLunch.Tag = "DC";
            this.fld_txtHREmployeeExtraLunch.Leave += new System.EventHandler(this.fld_txtHREmployeeExtraLunch_Leave);
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
            this.bosLabel3.Location = new System.Drawing.Point(16, 81);
            this.bosLabel3.Name = "bosLabel3";
            this.bosLabel3.Screen = null;
            this.bosLabel3.Size = new System.Drawing.Size(80, 13);
            this.bosLabel3.TabIndex = 60;
            this.bosLabel3.Tag = "";
            this.bosLabel3.Text = "Phụ cấp xăng xe";
            // 
            // fld_txtHREmployeeExtraGasolineVehicle
            // 
            this.fld_txtHREmployeeExtraGasolineVehicle.BOSComment = "";
            this.fld_txtHREmployeeExtraGasolineVehicle.BOSDataMember = "HREmployeeExtraGasolineVehicle";
            this.fld_txtHREmployeeExtraGasolineVehicle.BOSDataSource = "HREmployees";
            this.fld_txtHREmployeeExtraGasolineVehicle.BOSDescription = null;
            this.fld_txtHREmployeeExtraGasolineVehicle.BOSError = null;
            this.fld_txtHREmployeeExtraGasolineVehicle.BOSFieldGroup = "";
            this.fld_txtHREmployeeExtraGasolineVehicle.BOSFieldRelation = "";
            this.fld_txtHREmployeeExtraGasolineVehicle.BOSPrivilege = "";
            this.fld_txtHREmployeeExtraGasolineVehicle.BOSPropertyName = "Text";
            this.fld_txtHREmployeeExtraGasolineVehicle.EditValue = "";
            this.fld_txtHREmployeeExtraGasolineVehicle.Location = new System.Drawing.Point(148, 78);
            this.fld_txtHREmployeeExtraGasolineVehicle.Name = "fld_txtHREmployeeExtraGasolineVehicle";
            this.fld_txtHREmployeeExtraGasolineVehicle.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtHREmployeeExtraGasolineVehicle.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtHREmployeeExtraGasolineVehicle.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtHREmployeeExtraGasolineVehicle.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtHREmployeeExtraGasolineVehicle.Properties.Mask.EditMask = "n";
            this.fld_txtHREmployeeExtraGasolineVehicle.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.fld_txtHREmployeeExtraGasolineVehicle.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtHREmployeeExtraGasolineVehicle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtHREmployeeExtraGasolineVehicle.Screen = null;
            this.fld_txtHREmployeeExtraGasolineVehicle.Size = new System.Drawing.Size(150, 20);
            this.fld_txtHREmployeeExtraGasolineVehicle.TabIndex = 4;
            this.fld_txtHREmployeeExtraGasolineVehicle.Tag = "DC";
            this.fld_txtHREmployeeExtraGasolineVehicle.Leave += new System.EventHandler(this.fld_txtHREmployeeExtraGasolineVehicle_Leave);
            // 
            // fld_lblLabel60
            // 
            this.fld_lblLabel60.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel60.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel60.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel60.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel60.BOSComment = "";
            this.fld_lblLabel60.BOSDataMember = "";
            this.fld_lblLabel60.BOSDataSource = "";
            this.fld_lblLabel60.BOSDescription = null;
            this.fld_lblLabel60.BOSError = null;
            this.fld_lblLabel60.BOSFieldGroup = "";
            this.fld_lblLabel60.BOSFieldRelation = "";
            this.fld_lblLabel60.BOSPrivilege = "";
            this.fld_lblLabel60.BOSPropertyName = "";
            this.fld_lblLabel60.Location = new System.Drawing.Point(16, 29);
            this.fld_lblLabel60.Name = "fld_lblLabel60";
            this.fld_lblLabel60.Screen = null;
            this.fld_lblLabel60.Size = new System.Drawing.Size(71, 13);
            this.fld_lblLabel60.TabIndex = 5;
            this.fld_lblLabel60.Tag = "";
            this.fld_lblLabel60.Text = "Lương căn bản";
            // 
            // bosLookupEdit2
            // 
            this.bosLookupEdit2.BOSAllowAddNew = false;
            this.bosLookupEdit2.BOSAllowDummy = false;
            this.bosLookupEdit2.BOSComment = "";
            this.bosLookupEdit2.BOSDataMember = "FK_HRWorkingShiftID";
            this.bosLookupEdit2.BOSDataSource = "HREmployees";
            this.bosLookupEdit2.BOSDescription = null;
            this.bosLookupEdit2.BOSDummyText = null;
            this.bosLookupEdit2.BOSError = null;
            this.bosLookupEdit2.BOSFieldGroup = "";
            this.bosLookupEdit2.BOSFieldParent = "";
            this.bosLookupEdit2.BOSFieldRelation = "";
            this.bosLookupEdit2.BOSPrivilege = "";
            this.bosLookupEdit2.BOSPropertyName = "EditValue";
            this.bosLookupEdit2.BOSSelectType = "";
            this.bosLookupEdit2.BOSSelectTypeValue = "";
            this.bosLookupEdit2.CurrentDisplayText = null;
            this.bosLookupEdit2.Location = new System.Drawing.Point(753, 26);
            this.bosLookupEdit2.Name = "bosLookupEdit2";
            this.bosLookupEdit2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLookupEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLookupEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.bosLookupEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.bosLookupEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bosLookupEdit2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRWorkingShiftName", "Ca làm việc")});
            this.bosLookupEdit2.Properties.DisplayMember = "HRWorkingShiftName";
            this.bosLookupEdit2.Properties.NullText = "";
            this.bosLookupEdit2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.bosLookupEdit2.Properties.ValueMember = "HRWorkingShiftID";
            this.bosLookupEdit2.Screen = null;
            this.bosLookupEdit2.Size = new System.Drawing.Size(150, 20);
            this.bosLookupEdit2.TabIndex = 12;
            this.bosLookupEdit2.Tag = "DC";
            this.bosLookupEdit2.Visible = false;
            // 
            // fld_lkeHRPayRollCalculatedSalaryType
            // 
            this.fld_lkeHRPayRollCalculatedSalaryType.BOSAllowAddNew = false;
            this.fld_lkeHRPayRollCalculatedSalaryType.BOSAllowDummy = false;
            this.fld_lkeHRPayRollCalculatedSalaryType.BOSComment = "";
            this.fld_lkeHRPayRollCalculatedSalaryType.BOSDataMember = "HRPayRollCalculatedSalaryType";
            this.fld_lkeHRPayRollCalculatedSalaryType.BOSDataSource = "HREmployees";
            this.fld_lkeHRPayRollCalculatedSalaryType.BOSDescription = null;
            this.fld_lkeHRPayRollCalculatedSalaryType.BOSDummyText = null;
            this.fld_lkeHRPayRollCalculatedSalaryType.BOSError = null;
            this.fld_lkeHRPayRollCalculatedSalaryType.BOSFieldGroup = "";
            this.fld_lkeHRPayRollCalculatedSalaryType.BOSFieldParent = "";
            this.fld_lkeHRPayRollCalculatedSalaryType.BOSFieldRelation = "";
            this.fld_lkeHRPayRollCalculatedSalaryType.BOSPrivilege = "";
            this.fld_lkeHRPayRollCalculatedSalaryType.BOSPropertyName = "EditValue";
            this.fld_lkeHRPayRollCalculatedSalaryType.BOSSelectType = "";
            this.fld_lkeHRPayRollCalculatedSalaryType.BOSSelectTypeValue = "";
            this.fld_lkeHRPayRollCalculatedSalaryType.CurrentDisplayText = null;
            this.fld_lkeHRPayRollCalculatedSalaryType.Location = new System.Drawing.Point(148, 156);
            this.fld_lkeHRPayRollCalculatedSalaryType.Name = "fld_lkeHRPayRollCalculatedSalaryType";
            this.fld_lkeHRPayRollCalculatedSalaryType.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeHRPayRollCalculatedSalaryType.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeHRPayRollCalculatedSalaryType.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeHRPayRollCalculatedSalaryType.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeHRPayRollCalculatedSalaryType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeHRPayRollCalculatedSalaryType.Properties.NullText = "";
            this.fld_lkeHRPayRollCalculatedSalaryType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeHRPayRollCalculatedSalaryType.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_lkeHRPayRollCalculatedSalaryType, true);
            this.fld_lkeHRPayRollCalculatedSalaryType.Size = new System.Drawing.Size(150, 20);
            this.fld_lkeHRPayRollCalculatedSalaryType.TabIndex = 10;
            this.fld_lkeHRPayRollCalculatedSalaryType.Tag = "DC";
            // 
            // bosLabel13
            // 
            this.bosLabel13.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel13.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel13.Appearance.Options.UseBackColor = true;
            this.bosLabel13.Appearance.Options.UseForeColor = true;
            this.bosLabel13.BOSComment = "";
            this.bosLabel13.BOSDataMember = "";
            this.bosLabel13.BOSDataSource = "";
            this.bosLabel13.BOSDescription = null;
            this.bosLabel13.BOSError = null;
            this.bosLabel13.BOSFieldGroup = "";
            this.bosLabel13.BOSFieldRelation = "";
            this.bosLabel13.BOSPrivilege = "";
            this.bosLabel13.BOSPropertyName = "";
            this.bosLabel13.Location = new System.Drawing.Point(16, 55);
            this.bosLabel13.Name = "bosLabel13";
            this.bosLabel13.Screen = null;
            this.bosLabel13.Size = new System.Drawing.Size(38, 13);
            this.bosLabel13.TabIndex = 6;
            this.bosLabel13.Tag = "";
            this.bosLabel13.Text = "Phụ cấp";
            // 
            // fld_lblLabel34
            // 
            this.fld_lblLabel34.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel34.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel34.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel34.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel34.BOSComment = "";
            this.fld_lblLabel34.BOSDataMember = "";
            this.fld_lblLabel34.BOSDataSource = "";
            this.fld_lblLabel34.BOSDescription = null;
            this.fld_lblLabel34.BOSError = null;
            this.fld_lblLabel34.BOSFieldGroup = "";
            this.fld_lblLabel34.BOSFieldRelation = "";
            this.fld_lblLabel34.BOSPrivilege = "";
            this.fld_lblLabel34.BOSPropertyName = "";
            this.fld_lblLabel34.Location = new System.Drawing.Point(346, 133);
            this.fld_lblLabel34.Name = "fld_lblLabel34";
            this.fld_lblLabel34.Screen = null;
            this.fld_lblLabel34.Size = new System.Drawing.Size(78, 13);
            this.fld_lblLabel34.TabIndex = 6;
            this.fld_lblLabel34.Tag = "";
            this.fld_lblLabel34.Text = "Lương công việc";
            // 
            // fld_lblLabel61
            // 
            this.fld_lblLabel61.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel61.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel61.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel61.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel61.BOSComment = "";
            this.fld_lblLabel61.BOSDataMember = "";
            this.fld_lblLabel61.BOSDataSource = "";
            this.fld_lblLabel61.BOSDescription = null;
            this.fld_lblLabel61.BOSError = null;
            this.fld_lblLabel61.BOSFieldGroup = "";
            this.fld_lblLabel61.BOSFieldRelation = "";
            this.fld_lblLabel61.BOSPrivilege = "";
            this.fld_lblLabel61.BOSPropertyName = "";
            this.fld_lblLabel61.Location = new System.Drawing.Point(346, 29);
            this.fld_lblLabel61.Name = "fld_lblLabel61";
            this.fld_lblLabel61.Screen = null;
            this.fld_lblLabel61.Size = new System.Drawing.Size(27, 13);
            this.fld_lblLabel61.TabIndex = 7;
            this.fld_lblLabel61.Tag = "";
            this.fld_lblLabel61.Text = "Hệ số";
            // 
            // fld_txtHREmployeeContractSlrAmt
            // 
            this.fld_txtHREmployeeContractSlrAmt.BOSComment = "";
            this.fld_txtHREmployeeContractSlrAmt.BOSDataMember = "HREmployeeContractSlrAmt";
            this.fld_txtHREmployeeContractSlrAmt.BOSDataSource = "HREmployees";
            this.fld_txtHREmployeeContractSlrAmt.BOSDescription = null;
            this.fld_txtHREmployeeContractSlrAmt.BOSError = null;
            this.fld_txtHREmployeeContractSlrAmt.BOSFieldGroup = "";
            this.fld_txtHREmployeeContractSlrAmt.BOSFieldRelation = "";
            this.fld_txtHREmployeeContractSlrAmt.BOSPrivilege = "";
            this.fld_txtHREmployeeContractSlrAmt.BOSPropertyName = "Text";
            this.fld_txtHREmployeeContractSlrAmt.EditValue = "";
            this.fld_txtHREmployeeContractSlrAmt.Location = new System.Drawing.Point(148, 26);
            this.fld_txtHREmployeeContractSlrAmt.Name = "fld_txtHREmployeeContractSlrAmt";
            this.fld_txtHREmployeeContractSlrAmt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtHREmployeeContractSlrAmt.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtHREmployeeContractSlrAmt.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtHREmployeeContractSlrAmt.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtHREmployeeContractSlrAmt.Properties.Mask.EditMask = "n";
            this.fld_txtHREmployeeContractSlrAmt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.fld_txtHREmployeeContractSlrAmt.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtHREmployeeContractSlrAmt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtHREmployeeContractSlrAmt.Screen = null;
            this.fld_txtHREmployeeContractSlrAmt.Size = new System.Drawing.Size(150, 20);
            this.fld_txtHREmployeeContractSlrAmt.TabIndex = 0;
            this.fld_txtHREmployeeContractSlrAmt.Tag = "DC";
            this.fld_txtHREmployeeContractSlrAmt.Leave += new System.EventHandler(this.fld_txtHREmployeeContractSlrAmt_Leave);
            this.fld_txtHREmployeeContractSlrAmt.Validated += new System.EventHandler(this.fld_txtHREmployeeContractSlrAmt_Validated);
            // 
            // fld_txtHREmployeeExtraSalary1
            // 
            this.fld_txtHREmployeeExtraSalary1.BOSComment = "";
            this.fld_txtHREmployeeExtraSalary1.BOSDataMember = "HREmployeeExtraSalary1";
            this.fld_txtHREmployeeExtraSalary1.BOSDataSource = "HREmployees";
            this.fld_txtHREmployeeExtraSalary1.BOSDescription = null;
            this.fld_txtHREmployeeExtraSalary1.BOSError = null;
            this.fld_txtHREmployeeExtraSalary1.BOSFieldGroup = "";
            this.fld_txtHREmployeeExtraSalary1.BOSFieldRelation = "";
            this.fld_txtHREmployeeExtraSalary1.BOSPrivilege = "";
            this.fld_txtHREmployeeExtraSalary1.BOSPropertyName = "Text";
            this.fld_txtHREmployeeExtraSalary1.EditValue = "";
            this.fld_txtHREmployeeExtraSalary1.Location = new System.Drawing.Point(148, 52);
            this.fld_txtHREmployeeExtraSalary1.Name = "fld_txtHREmployeeExtraSalary1";
            this.fld_txtHREmployeeExtraSalary1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtHREmployeeExtraSalary1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtHREmployeeExtraSalary1.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtHREmployeeExtraSalary1.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtHREmployeeExtraSalary1.Properties.Mask.EditMask = "n";
            this.fld_txtHREmployeeExtraSalary1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.fld_txtHREmployeeExtraSalary1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtHREmployeeExtraSalary1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtHREmployeeExtraSalary1.Screen = null;
            this.fld_txtHREmployeeExtraSalary1.Size = new System.Drawing.Size(150, 20);
            this.fld_txtHREmployeeExtraSalary1.TabIndex = 2;
            this.fld_txtHREmployeeExtraSalary1.Tag = "DC";
            this.fld_txtHREmployeeExtraSalary1.Leave += new System.EventHandler(this.fld_txtHREmployeeExtraSalary1_Leave);
            this.fld_txtHREmployeeExtraSalary1.Validated += new System.EventHandler(this.fld_txtHREmployeeWorkingSlrAmt_Validated);
            // 
            // fld_txtHREmployeeWorkingSlrAmt
            // 
            this.fld_txtHREmployeeWorkingSlrAmt.BOSComment = "";
            this.fld_txtHREmployeeWorkingSlrAmt.BOSDataMember = "HREmployeeWorkingSlrAmt";
            this.fld_txtHREmployeeWorkingSlrAmt.BOSDataSource = "HREmployees";
            this.fld_txtHREmployeeWorkingSlrAmt.BOSDescription = null;
            this.fld_txtHREmployeeWorkingSlrAmt.BOSError = null;
            this.fld_txtHREmployeeWorkingSlrAmt.BOSFieldGroup = "";
            this.fld_txtHREmployeeWorkingSlrAmt.BOSFieldRelation = "";
            this.fld_txtHREmployeeWorkingSlrAmt.BOSPrivilege = "";
            this.fld_txtHREmployeeWorkingSlrAmt.BOSPropertyName = "Text";
            this.fld_txtHREmployeeWorkingSlrAmt.EditValue = "";
            this.fld_txtHREmployeeWorkingSlrAmt.Location = new System.Drawing.Point(468, 130);
            this.fld_txtHREmployeeWorkingSlrAmt.Name = "fld_txtHREmployeeWorkingSlrAmt";
            this.fld_txtHREmployeeWorkingSlrAmt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtHREmployeeWorkingSlrAmt.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtHREmployeeWorkingSlrAmt.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtHREmployeeWorkingSlrAmt.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtHREmployeeWorkingSlrAmt.Properties.Mask.EditMask = "n";
            this.fld_txtHREmployeeWorkingSlrAmt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.fld_txtHREmployeeWorkingSlrAmt.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtHREmployeeWorkingSlrAmt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtHREmployeeWorkingSlrAmt.Screen = null;
            this.fld_txtHREmployeeWorkingSlrAmt.Size = new System.Drawing.Size(150, 20);
            this.fld_txtHREmployeeWorkingSlrAmt.TabIndex = 9;
            this.fld_txtHREmployeeWorkingSlrAmt.Tag = "DC";
            this.fld_txtHREmployeeWorkingSlrAmt.Validated += new System.EventHandler(this.fld_txtHREmployeeWorkingSlrAmt_Validated);
            // 
            // fld_txtHREmployeeSalaryFactor
            // 
            this.fld_txtHREmployeeSalaryFactor.BOSComment = "";
            this.fld_txtHREmployeeSalaryFactor.BOSDataMember = "HREmployeeSalaryFactor";
            this.fld_txtHREmployeeSalaryFactor.BOSDataSource = "HREmployees";
            this.fld_txtHREmployeeSalaryFactor.BOSDescription = null;
            this.fld_txtHREmployeeSalaryFactor.BOSError = null;
            this.fld_txtHREmployeeSalaryFactor.BOSFieldGroup = "";
            this.fld_txtHREmployeeSalaryFactor.BOSFieldRelation = "";
            this.fld_txtHREmployeeSalaryFactor.BOSPrivilege = "";
            this.fld_txtHREmployeeSalaryFactor.BOSPropertyName = "Text";
            this.fld_txtHREmployeeSalaryFactor.EditValue = "";
            this.fld_txtHREmployeeSalaryFactor.Location = new System.Drawing.Point(468, 26);
            this.fld_txtHREmployeeSalaryFactor.Name = "fld_txtHREmployeeSalaryFactor";
            this.fld_txtHREmployeeSalaryFactor.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtHREmployeeSalaryFactor.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtHREmployeeSalaryFactor.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtHREmployeeSalaryFactor.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtHREmployeeSalaryFactor.Properties.Mask.EditMask = "n";
            this.fld_txtHREmployeeSalaryFactor.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.fld_txtHREmployeeSalaryFactor.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtHREmployeeSalaryFactor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtHREmployeeSalaryFactor.Screen = null;
            this.fld_txtHREmployeeSalaryFactor.Size = new System.Drawing.Size(150, 20);
            this.fld_txtHREmployeeSalaryFactor.TabIndex = 1;
            this.fld_txtHREmployeeSalaryFactor.Tag = "DC";
            this.fld_txtHREmployeeSalaryFactor.Leave += new System.EventHandler(this.fld_txtHREmployeeSalaryFactor_Leave);
            this.fld_txtHREmployeeSalaryFactor.Validated += new System.EventHandler(this.fld_txtHREmployeeSalaryFactor_Validated);
            // 
            // fld_lkeFK_HREmployeePayrollFormulaID
            // 
            this.fld_lkeFK_HREmployeePayrollFormulaID.BOSAllowAddNew = false;
            this.fld_lkeFK_HREmployeePayrollFormulaID.BOSAllowDummy = true;
            this.fld_lkeFK_HREmployeePayrollFormulaID.BOSComment = null;
            this.fld_lkeFK_HREmployeePayrollFormulaID.BOSDataMember = "FK_HREmployeePayrollFormulaID";
            this.fld_lkeFK_HREmployeePayrollFormulaID.BOSDataSource = "HREmployees";
            this.fld_lkeFK_HREmployeePayrollFormulaID.BOSDescription = null;
            this.fld_lkeFK_HREmployeePayrollFormulaID.BOSDummyText = null;
            this.fld_lkeFK_HREmployeePayrollFormulaID.BOSError = null;
            this.fld_lkeFK_HREmployeePayrollFormulaID.BOSFieldGroup = null;
            this.fld_lkeFK_HREmployeePayrollFormulaID.BOSFieldParent = null;
            this.fld_lkeFK_HREmployeePayrollFormulaID.BOSFieldRelation = null;
            this.fld_lkeFK_HREmployeePayrollFormulaID.BOSPrivilege = null;
            this.fld_lkeFK_HREmployeePayrollFormulaID.BOSPropertyName = "EditValue";
            this.fld_lkeFK_HREmployeePayrollFormulaID.BOSSelectType = null;
            this.fld_lkeFK_HREmployeePayrollFormulaID.BOSSelectTypeValue = null;
            this.fld_lkeFK_HREmployeePayrollFormulaID.CurrentDisplayText = null;
            this.fld_lkeFK_HREmployeePayrollFormulaID.Location = new System.Drawing.Point(148, 130);
            this.fld_lkeFK_HREmployeePayrollFormulaID.Name = "fld_lkeFK_HREmployeePayrollFormulaID";
            this.fld_lkeFK_HREmployeePayrollFormulaID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_HREmployeePayrollFormulaID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HREmployeePayrollFormulaName", "Nhóm chấm công")});
            this.fld_lkeFK_HREmployeePayrollFormulaID.Properties.DisplayMember = "HREmployeePayrollFormulaName";
            this.fld_lkeFK_HREmployeePayrollFormulaID.Properties.ValueMember = "HREmployeePayrollFormulaID";
            this.fld_lkeFK_HREmployeePayrollFormulaID.Screen = null;
            this.fld_lkeFK_HREmployeePayrollFormulaID.Size = new System.Drawing.Size(150, 20);
            this.fld_lkeFK_HREmployeePayrollFormulaID.TabIndex = 8;
            this.fld_lkeFK_HREmployeePayrollFormulaID.Tag = "DC";
            // 
            // fld_lkeFK_HRTimeSheetScaleID
            // 
            this.fld_lkeFK_HRTimeSheetScaleID.BOSAllowAddNew = false;
            this.fld_lkeFK_HRTimeSheetScaleID.BOSAllowDummy = true;
            this.fld_lkeFK_HRTimeSheetScaleID.BOSComment = null;
            this.fld_lkeFK_HRTimeSheetScaleID.BOSDataMember = "FK_HRTimeSheetScaleID";
            this.fld_lkeFK_HRTimeSheetScaleID.BOSDataSource = "HREmployees";
            this.fld_lkeFK_HRTimeSheetScaleID.BOSDescription = null;
            this.fld_lkeFK_HRTimeSheetScaleID.BOSDummyText = null;
            this.fld_lkeFK_HRTimeSheetScaleID.BOSError = null;
            this.fld_lkeFK_HRTimeSheetScaleID.BOSFieldGroup = null;
            this.fld_lkeFK_HRTimeSheetScaleID.BOSFieldParent = null;
            this.fld_lkeFK_HRTimeSheetScaleID.BOSFieldRelation = null;
            this.fld_lkeFK_HRTimeSheetScaleID.BOSPrivilege = null;
            this.fld_lkeFK_HRTimeSheetScaleID.BOSPropertyName = "EditValue";
            this.fld_lkeFK_HRTimeSheetScaleID.BOSSelectType = null;
            this.fld_lkeFK_HRTimeSheetScaleID.BOSSelectTypeValue = null;
            this.fld_lkeFK_HRTimeSheetScaleID.CurrentDisplayText = null;
            this.fld_lkeFK_HRTimeSheetScaleID.Location = new System.Drawing.Point(468, 156);
            this.fld_lkeFK_HRTimeSheetScaleID.MenuManager = this.screenToolbar;
            this.fld_lkeFK_HRTimeSheetScaleID.Name = "fld_lkeFK_HRTimeSheetScaleID";
            this.fld_lkeFK_HRTimeSheetScaleID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_HRTimeSheetScaleID.Properties.DisplayMember = "HRTimeSheetScaleDesc";
            this.fld_lkeFK_HRTimeSheetScaleID.Properties.ValueMember = "HRTimeSheetScaleID";
            this.fld_lkeFK_HRTimeSheetScaleID.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_lkeFK_HRTimeSheetScaleID, true);
            this.fld_lkeFK_HRTimeSheetScaleID.Size = new System.Drawing.Size(150, 20);
            this.fld_lkeFK_HRTimeSheetScaleID.TabIndex = 11;
            this.fld_lkeFK_HRTimeSheetScaleID.Tag = "DC";
            this.fld_lkeFK_HRTimeSheetScaleID.Visible = false;
            // 
            // bosLabel1
            // 
            this.bosLabel1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel1.Appearance.Options.UseBackColor = true;
            this.bosLabel1.Appearance.Options.UseForeColor = true;
            this.bosLabel1.BOSComment = null;
            this.bosLabel1.BOSDataMember = null;
            this.bosLabel1.BOSDataSource = null;
            this.bosLabel1.BOSDescription = null;
            this.bosLabel1.BOSError = null;
            this.bosLabel1.BOSFieldGroup = null;
            this.bosLabel1.BOSFieldRelation = null;
            this.bosLabel1.BOSPrivilege = null;
            this.bosLabel1.BOSPropertyName = null;
            this.bosLabel1.Location = new System.Drawing.Point(16, 137);
            this.bosLabel1.Name = "bosLabel1";
            this.bosLabel1.Screen = null;
            this.bosLabel1.Size = new System.Drawing.Size(81, 13);
            this.bosLabel1.TabIndex = 58;
            this.bosLabel1.Text = "Nhóm chấm công";
            // 
            // bosLabel2
            // 
            this.bosLabel2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel2.Appearance.Options.UseBackColor = true;
            this.bosLabel2.Appearance.Options.UseForeColor = true;
            this.bosLabel2.BOSComment = null;
            this.bosLabel2.BOSDataMember = null;
            this.bosLabel2.BOSDataSource = null;
            this.bosLabel2.BOSDescription = null;
            this.bosLabel2.BOSError = null;
            this.bosLabel2.BOSFieldGroup = null;
            this.bosLabel2.BOSFieldRelation = null;
            this.bosLabel2.BOSPrivilege = null;
            this.bosLabel2.BOSPropertyName = null;
            this.bosLabel2.Location = new System.Drawing.Point(631, 29);
            this.bosLabel2.Name = "bosLabel2";
            this.bosLabel2.Screen = null;
            this.bosLabel2.Size = new System.Drawing.Size(54, 13);
            this.bosLabel2.TabIndex = 58;
            this.bosLabel2.Text = "Ca làm việc";
            this.bosLabel2.Visible = false;
            // 
            // bosLabel9
            // 
            this.bosLabel9.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel9.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel9.Appearance.Options.UseBackColor = true;
            this.bosLabel9.Appearance.Options.UseForeColor = true;
            this.bosLabel9.BOSComment = null;
            this.bosLabel9.BOSDataMember = null;
            this.bosLabel9.BOSDataSource = null;
            this.bosLabel9.BOSDescription = null;
            this.bosLabel9.BOSError = null;
            this.bosLabel9.BOSFieldGroup = null;
            this.bosLabel9.BOSFieldRelation = null;
            this.bosLabel9.BOSPrivilege = null;
            this.bosLabel9.BOSPropertyName = null;
            this.bosLabel9.Location = new System.Drawing.Point(16, 159);
            this.bosLabel9.Name = "bosLabel9";
            this.bosLabel9.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel9, true);
            this.bosLabel9.Size = new System.Drawing.Size(75, 13);
            this.bosLabel9.TabIndex = 58;
            this.bosLabel9.Text = "Tính lương theo";
            // 
            // bosLabel8
            // 
            this.bosLabel8.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel8.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel8.Appearance.Options.UseBackColor = true;
            this.bosLabel8.Appearance.Options.UseForeColor = true;
            this.bosLabel8.BOSComment = null;
            this.bosLabel8.BOSDataMember = null;
            this.bosLabel8.BOSDataSource = null;
            this.bosLabel8.BOSDescription = null;
            this.bosLabel8.BOSError = null;
            this.bosLabel8.BOSFieldGroup = null;
            this.bosLabel8.BOSFieldRelation = null;
            this.bosLabel8.BOSPrivilege = null;
            this.bosLabel8.BOSPropertyName = null;
            this.bosLabel8.Location = new System.Drawing.Point(346, 157);
            this.bosLabel8.Name = "bosLabel8";
            this.bosLabel8.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel8, true);
            this.bosLabel8.Size = new System.Drawing.Size(84, 13);
            this.bosLabel8.TabIndex = 58;
            this.bosLabel8.Text = "Thang chấm công";
            this.bosLabel8.Visible = false;
            // 
            // fld_grcGroupControl4
            // 
            this.fld_grcGroupControl4.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.fld_grcGroupControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_grcGroupControl4.Appearance.Options.UseBackColor = true;
            this.fld_grcGroupControl4.Appearance.Options.UseForeColor = true;
            this.fld_grcGroupControl4.BOSComment = "";
            this.fld_grcGroupControl4.BOSDataMember = "";
            this.fld_grcGroupControl4.BOSDataSource = "";
            this.fld_grcGroupControl4.BOSDescription = null;
            this.fld_grcGroupControl4.BOSError = null;
            this.fld_grcGroupControl4.BOSFieldGroup = "";
            this.fld_grcGroupControl4.BOSFieldRelation = "";
            this.fld_grcGroupControl4.BOSPrivilege = "";
            this.fld_grcGroupControl4.BOSPropertyName = "";
            this.fld_grcGroupControl4.Controls.Add(this.fld_Line2);
            this.fld_grcGroupControl4.Controls.Add(this.fld_Line1);
            this.fld_grcGroupControl4.Controls.Add(this.fld_lblLabel38);
            this.fld_grcGroupControl4.Controls.Add(this.fld_lblLabel36);
            this.fld_grcGroupControl4.Controls.Add(this.fld_txtHREmployeeHealthInsNo);
            this.fld_grcGroupControl4.Controls.Add(this.fld_lblLabel40);
            this.fld_grcGroupControl4.Controls.Add(this.fld_txtHREmployeeHealthInsRegisteredPlace);
            this.fld_grcGroupControl4.Controls.Add(this.fld_lblLabel41);
            this.fld_grcGroupControl4.Controls.Add(this.fld_dteHREmployeeHealthInsExpiryDate);
            this.fld_grcGroupControl4.Controls.Add(this.fld_lblLabel42);
            this.fld_grcGroupControl4.Controls.Add(this.fld_dteHREmployeeHealthInsRegisteredDate);
            this.fld_grcGroupControl4.Controls.Add(this.fld_txtHREmployeeSocialInsNo);
            this.fld_grcGroupControl4.Controls.Add(this.fld_lblLabel47);
            this.fld_grcGroupControl4.Controls.Add(this.fld_lblLabel48);
            this.fld_grcGroupControl4.Controls.Add(this.fld_dteHREmployeeSocialInsRegisteredDate);
            this.fld_grcGroupControl4.Controls.Add(this.fld_lblLabel49);
            this.fld_grcGroupControl4.Controls.Add(this.fld_dteHREmployeeSocialInsExpiryDate);
            this.fld_grcGroupControl4.Controls.Add(this.fld_lblLabel50);
            this.fld_grcGroupControl4.Location = new System.Drawing.Point(1, 195);
            this.fld_grcGroupControl4.Name = "fld_grcGroupControl4";
            this.fld_grcGroupControl4.Screen = null;
            this.fld_grcGroupControl4.Size = new System.Drawing.Size(926, 216);
            this.fld_grcGroupControl4.TabIndex = 1;
            this.fld_grcGroupControl4.Tag = "";
            this.fld_grcGroupControl4.Text = "Thông tin bảo hiểm";
            // 
            // fld_Line2
            // 
            this.fld_Line2.BOSComment = null;
            this.fld_Line2.BOSDataMember = null;
            this.fld_Line2.BOSDataSource = null;
            this.fld_Line2.BOSDescription = null;
            this.fld_Line2.BOSError = null;
            this.fld_Line2.BOSFieldGroup = null;
            this.fld_Line2.BOSFieldRelation = null;
            this.fld_Line2.BOSPrivilege = null;
            this.fld_Line2.BOSPropertyName = null;
            this.fld_Line2.Location = new System.Drawing.Point(93, 119);
            this.fld_Line2.Name = "fld_Line2";
            this.fld_Line2.Screen = null;
            this.fld_Line2.Size = new System.Drawing.Size(480, 10);
            this.fld_Line2.TabIndex = 46;
            this.fld_Line2.TabStop = false;
            // 
            // fld_Line1
            // 
            this.fld_Line1.BOSComment = null;
            this.fld_Line1.BOSDataMember = null;
            this.fld_Line1.BOSDataSource = null;
            this.fld_Line1.BOSDescription = null;
            this.fld_Line1.BOSError = null;
            this.fld_Line1.BOSFieldGroup = null;
            this.fld_Line1.BOSFieldRelation = null;
            this.fld_Line1.BOSPrivilege = null;
            this.fld_Line1.BOSPropertyName = null;
            this.fld_Line1.Location = new System.Drawing.Point(110, 33);
            this.fld_Line1.Name = "fld_Line1";
            this.fld_Line1.Screen = null;
            this.fld_Line1.Size = new System.Drawing.Size(467, 10);
            this.fld_Line1.TabIndex = 46;
            this.fld_Line1.TabStop = false;
            // 
            // fld_lblLabel38
            // 
            this.fld_lblLabel38.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fld_lblLabel38.Appearance.Options.UseFont = true;
            this.fld_lblLabel38.BOSComment = null;
            this.fld_lblLabel38.BOSDataMember = null;
            this.fld_lblLabel38.BOSDataSource = null;
            this.fld_lblLabel38.BOSDescription = null;
            this.fld_lblLabel38.BOSError = null;
            this.fld_lblLabel38.BOSFieldGroup = null;
            this.fld_lblLabel38.BOSFieldRelation = null;
            this.fld_lblLabel38.BOSPrivilege = null;
            this.fld_lblLabel38.BOSPropertyName = null;
            this.fld_lblLabel38.Location = new System.Drawing.Point(12, 116);
            this.fld_lblLabel38.Name = "fld_lblLabel38";
            this.fld_lblLabel38.Screen = null;
            this.fld_lblLabel38.Size = new System.Drawing.Size(77, 13);
            this.fld_lblLabel38.TabIndex = 45;
            this.fld_lblLabel38.Text = "Bảo hiểm y tế";
            // 
            // fld_lblLabel36
            // 
            this.fld_lblLabel36.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fld_lblLabel36.Appearance.Options.UseFont = true;
            this.fld_lblLabel36.BOSComment = null;
            this.fld_lblLabel36.BOSDataMember = null;
            this.fld_lblLabel36.BOSDataSource = null;
            this.fld_lblLabel36.BOSDescription = null;
            this.fld_lblLabel36.BOSError = null;
            this.fld_lblLabel36.BOSFieldGroup = null;
            this.fld_lblLabel36.BOSFieldRelation = null;
            this.fld_lblLabel36.BOSPrivilege = null;
            this.fld_lblLabel36.BOSPropertyName = null;
            this.fld_lblLabel36.Location = new System.Drawing.Point(11, 30);
            this.fld_lblLabel36.Name = "fld_lblLabel36";
            this.fld_lblLabel36.Screen = null;
            this.fld_lblLabel36.Size = new System.Drawing.Size(89, 13);
            this.fld_lblLabel36.TabIndex = 45;
            this.fld_lblLabel36.Text = "Bảo hiểm xã hội";
            // 
            // fld_txtHREmployeeHealthInsNo
            // 
            this.fld_txtHREmployeeHealthInsNo.BOSComment = "";
            this.fld_txtHREmployeeHealthInsNo.BOSDataMember = "HREmployeeHealthInsNo";
            this.fld_txtHREmployeeHealthInsNo.BOSDataSource = "HREmployees";
            this.fld_txtHREmployeeHealthInsNo.BOSDescription = null;
            this.fld_txtHREmployeeHealthInsNo.BOSError = null;
            this.fld_txtHREmployeeHealthInsNo.BOSFieldGroup = "";
            this.fld_txtHREmployeeHealthInsNo.BOSFieldRelation = "";
            this.fld_txtHREmployeeHealthInsNo.BOSPrivilege = "";
            this.fld_txtHREmployeeHealthInsNo.BOSPropertyName = "Text";
            this.fld_txtHREmployeeHealthInsNo.EditValue = "";
            this.fld_txtHREmployeeHealthInsNo.Location = new System.Drawing.Point(109, 136);
            this.fld_txtHREmployeeHealthInsNo.Name = "fld_txtHREmployeeHealthInsNo";
            this.fld_txtHREmployeeHealthInsNo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtHREmployeeHealthInsNo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtHREmployeeHealthInsNo.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtHREmployeeHealthInsNo.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtHREmployeeHealthInsNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtHREmployeeHealthInsNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtHREmployeeHealthInsNo.Screen = null;
            this.fld_txtHREmployeeHealthInsNo.Size = new System.Drawing.Size(466, 20);
            this.fld_txtHREmployeeHealthInsNo.TabIndex = 3;
            this.fld_txtHREmployeeHealthInsNo.Tag = "DC";
            // 
            // fld_lblLabel40
            // 
            this.fld_lblLabel40.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel40.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel40.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel40.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel40.BOSComment = "";
            this.fld_lblLabel40.BOSDataMember = "";
            this.fld_lblLabel40.BOSDataSource = "";
            this.fld_lblLabel40.BOSDescription = null;
            this.fld_lblLabel40.BOSError = null;
            this.fld_lblLabel40.BOSFieldGroup = "";
            this.fld_lblLabel40.BOSFieldRelation = "";
            this.fld_lblLabel40.BOSPrivilege = "";
            this.fld_lblLabel40.BOSPropertyName = "";
            this.fld_lblLabel40.Location = new System.Drawing.Point(14, 55);
            this.fld_lblLabel40.Name = "fld_lblLabel40";
            this.fld_lblLabel40.Screen = null;
            this.fld_lblLabel40.Size = new System.Drawing.Size(72, 13);
            this.fld_lblLabel40.TabIndex = 21;
            this.fld_lblLabel40.Tag = "";
            this.fld_lblLabel40.Text = "Số sổ bảo hiểm";
            // 
            // fld_txtHREmployeeHealthInsRegisteredPlace
            // 
            this.fld_txtHREmployeeHealthInsRegisteredPlace.BOSComment = "";
            this.fld_txtHREmployeeHealthInsRegisteredPlace.BOSDataMember = "HREmployeeHealthInsRegisteredPlace";
            this.fld_txtHREmployeeHealthInsRegisteredPlace.BOSDataSource = "HREmployees";
            this.fld_txtHREmployeeHealthInsRegisteredPlace.BOSDescription = null;
            this.fld_txtHREmployeeHealthInsRegisteredPlace.BOSError = null;
            this.fld_txtHREmployeeHealthInsRegisteredPlace.BOSFieldGroup = "";
            this.fld_txtHREmployeeHealthInsRegisteredPlace.BOSFieldRelation = "";
            this.fld_txtHREmployeeHealthInsRegisteredPlace.BOSPrivilege = "";
            this.fld_txtHREmployeeHealthInsRegisteredPlace.BOSPropertyName = "Text";
            this.fld_txtHREmployeeHealthInsRegisteredPlace.EditValue = "";
            this.fld_txtHREmployeeHealthInsRegisteredPlace.Location = new System.Drawing.Point(109, 160);
            this.fld_txtHREmployeeHealthInsRegisteredPlace.Name = "fld_txtHREmployeeHealthInsRegisteredPlace";
            this.fld_txtHREmployeeHealthInsRegisteredPlace.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtHREmployeeHealthInsRegisteredPlace.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtHREmployeeHealthInsRegisteredPlace.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtHREmployeeHealthInsRegisteredPlace.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtHREmployeeHealthInsRegisteredPlace.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtHREmployeeHealthInsRegisteredPlace.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtHREmployeeHealthInsRegisteredPlace.Screen = null;
            this.fld_txtHREmployeeHealthInsRegisteredPlace.Size = new System.Drawing.Size(466, 20);
            this.fld_txtHREmployeeHealthInsRegisteredPlace.TabIndex = 4;
            this.fld_txtHREmployeeHealthInsRegisteredPlace.Tag = "DC";
            // 
            // fld_lblLabel41
            // 
            this.fld_lblLabel41.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel41.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel41.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel41.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel41.BOSComment = "";
            this.fld_lblLabel41.BOSDataMember = "";
            this.fld_lblLabel41.BOSDataSource = "";
            this.fld_lblLabel41.BOSDescription = null;
            this.fld_lblLabel41.BOSError = null;
            this.fld_lblLabel41.BOSFieldGroup = "";
            this.fld_lblLabel41.BOSFieldRelation = "";
            this.fld_lblLabel41.BOSPrivilege = "";
            this.fld_lblLabel41.BOSPropertyName = "";
            this.fld_lblLabel41.Location = new System.Drawing.Point(14, 79);
            this.fld_lblLabel41.Name = "fld_lblLabel41";
            this.fld_lblLabel41.Screen = null;
            this.fld_lblLabel41.Size = new System.Drawing.Size(66, 13);
            this.fld_lblLabel41.TabIndex = 22;
            this.fld_lblLabel41.Tag = "";
            this.fld_lblLabel41.Text = "Ngày đăng ký";
            // 
            // fld_dteHREmployeeHealthInsExpiryDate
            // 
            this.fld_dteHREmployeeHealthInsExpiryDate.BOSComment = "";
            this.fld_dteHREmployeeHealthInsExpiryDate.BOSDataMember = "HREmployeeHealthInsExpiryDate";
            this.fld_dteHREmployeeHealthInsExpiryDate.BOSDataSource = "HREmployees";
            this.fld_dteHREmployeeHealthInsExpiryDate.BOSDescription = null;
            this.fld_dteHREmployeeHealthInsExpiryDate.BOSError = null;
            this.fld_dteHREmployeeHealthInsExpiryDate.BOSFieldGroup = "";
            this.fld_dteHREmployeeHealthInsExpiryDate.BOSFieldRelation = "";
            this.fld_dteHREmployeeHealthInsExpiryDate.BOSPrivilege = "";
            this.fld_dteHREmployeeHealthInsExpiryDate.BOSPropertyName = "EditValue";
            this.fld_dteHREmployeeHealthInsExpiryDate.EditValue = null;
            this.fld_dteHREmployeeHealthInsExpiryDate.Location = new System.Drawing.Point(450, 184);
            this.fld_dteHREmployeeHealthInsExpiryDate.Name = "fld_dteHREmployeeHealthInsExpiryDate";
            this.fld_dteHREmployeeHealthInsExpiryDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteHREmployeeHealthInsExpiryDate.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteHREmployeeHealthInsExpiryDate.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteHREmployeeHealthInsExpiryDate.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteHREmployeeHealthInsExpiryDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHREmployeeHealthInsExpiryDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.fld_dteHREmployeeHealthInsExpiryDate.Screen = null;
            this.fld_dteHREmployeeHealthInsExpiryDate.Size = new System.Drawing.Size(125, 20);
            this.fld_dteHREmployeeHealthInsExpiryDate.TabIndex = 6;
            this.fld_dteHREmployeeHealthInsExpiryDate.Tag = "DC";
            // 
            // fld_lblLabel42
            // 
            this.fld_lblLabel42.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel42.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel42.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel42.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel42.BOSComment = "";
            this.fld_lblLabel42.BOSDataMember = "";
            this.fld_lblLabel42.BOSDataSource = "";
            this.fld_lblLabel42.BOSDescription = null;
            this.fld_lblLabel42.BOSError = null;
            this.fld_lblLabel42.BOSFieldGroup = "";
            this.fld_lblLabel42.BOSFieldRelation = "";
            this.fld_lblLabel42.BOSPrivilege = "";
            this.fld_lblLabel42.BOSPropertyName = "";
            this.fld_lblLabel42.Location = new System.Drawing.Point(365, 79);
            this.fld_lblLabel42.Name = "fld_lblLabel42";
            this.fld_lblLabel42.Screen = null;
            this.fld_lblLabel42.Size = new System.Drawing.Size(65, 13);
            this.fld_lblLabel42.TabIndex = 23;
            this.fld_lblLabel42.Tag = "";
            this.fld_lblLabel42.Text = "Ngày hết hạn";
            // 
            // fld_dteHREmployeeHealthInsRegisteredDate
            // 
            this.fld_dteHREmployeeHealthInsRegisteredDate.BOSComment = "";
            this.fld_dteHREmployeeHealthInsRegisteredDate.BOSDataMember = "HREmployeeHealthInsRegisteredDate";
            this.fld_dteHREmployeeHealthInsRegisteredDate.BOSDataSource = "HREmployees";
            this.fld_dteHREmployeeHealthInsRegisteredDate.BOSDescription = null;
            this.fld_dteHREmployeeHealthInsRegisteredDate.BOSError = null;
            this.fld_dteHREmployeeHealthInsRegisteredDate.BOSFieldGroup = "";
            this.fld_dteHREmployeeHealthInsRegisteredDate.BOSFieldRelation = "";
            this.fld_dteHREmployeeHealthInsRegisteredDate.BOSPrivilege = "";
            this.fld_dteHREmployeeHealthInsRegisteredDate.BOSPropertyName = "EditValue";
            this.fld_dteHREmployeeHealthInsRegisteredDate.EditValue = null;
            this.fld_dteHREmployeeHealthInsRegisteredDate.Location = new System.Drawing.Point(109, 184);
            this.fld_dteHREmployeeHealthInsRegisteredDate.Name = "fld_dteHREmployeeHealthInsRegisteredDate";
            this.fld_dteHREmployeeHealthInsRegisteredDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteHREmployeeHealthInsRegisteredDate.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteHREmployeeHealthInsRegisteredDate.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteHREmployeeHealthInsRegisteredDate.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteHREmployeeHealthInsRegisteredDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHREmployeeHealthInsRegisteredDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.fld_dteHREmployeeHealthInsRegisteredDate.Screen = null;
            this.fld_dteHREmployeeHealthInsRegisteredDate.Size = new System.Drawing.Size(125, 20);
            this.fld_dteHREmployeeHealthInsRegisteredDate.TabIndex = 5;
            this.fld_dteHREmployeeHealthInsRegisteredDate.Tag = "DC";
            // 
            // fld_txtHREmployeeSocialInsNo
            // 
            this.fld_txtHREmployeeSocialInsNo.BOSComment = "";
            this.fld_txtHREmployeeSocialInsNo.BOSDataMember = "HREmployeeSocialInsNo";
            this.fld_txtHREmployeeSocialInsNo.BOSDataSource = "HREmployees";
            this.fld_txtHREmployeeSocialInsNo.BOSDescription = null;
            this.fld_txtHREmployeeSocialInsNo.BOSError = null;
            this.fld_txtHREmployeeSocialInsNo.BOSFieldGroup = "";
            this.fld_txtHREmployeeSocialInsNo.BOSFieldRelation = "";
            this.fld_txtHREmployeeSocialInsNo.BOSPrivilege = "";
            this.fld_txtHREmployeeSocialInsNo.BOSPropertyName = "Text";
            this.fld_txtHREmployeeSocialInsNo.EditValue = "";
            this.fld_txtHREmployeeSocialInsNo.Location = new System.Drawing.Point(109, 52);
            this.fld_txtHREmployeeSocialInsNo.Name = "fld_txtHREmployeeSocialInsNo";
            this.fld_txtHREmployeeSocialInsNo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtHREmployeeSocialInsNo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtHREmployeeSocialInsNo.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtHREmployeeSocialInsNo.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtHREmployeeSocialInsNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtHREmployeeSocialInsNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtHREmployeeSocialInsNo.Screen = null;
            this.fld_txtHREmployeeSocialInsNo.Size = new System.Drawing.Size(466, 20);
            this.fld_txtHREmployeeSocialInsNo.TabIndex = 0;
            this.fld_txtHREmployeeSocialInsNo.Tag = "DC";
            // 
            // fld_lblLabel47
            // 
            this.fld_lblLabel47.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel47.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel47.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel47.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel47.BOSComment = "";
            this.fld_lblLabel47.BOSDataMember = "";
            this.fld_lblLabel47.BOSDataSource = "";
            this.fld_lblLabel47.BOSDescription = null;
            this.fld_lblLabel47.BOSError = null;
            this.fld_lblLabel47.BOSFieldGroup = "";
            this.fld_lblLabel47.BOSFieldRelation = "";
            this.fld_lblLabel47.BOSPrivilege = "";
            this.fld_lblLabel47.BOSPropertyName = "";
            this.fld_lblLabel47.Location = new System.Drawing.Point(16, 138);
            this.fld_lblLabel47.Name = "fld_lblLabel47";
            this.fld_lblLabel47.Screen = null;
            this.fld_lblLabel47.Size = new System.Drawing.Size(40, 13);
            this.fld_lblLabel47.TabIndex = 41;
            this.fld_lblLabel47.Tag = "";
            this.fld_lblLabel47.Text = "Số BHYT";
            // 
            // fld_lblLabel48
            // 
            this.fld_lblLabel48.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel48.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel48.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel48.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel48.BOSComment = "";
            this.fld_lblLabel48.BOSDataMember = "";
            this.fld_lblLabel48.BOSDataSource = "";
            this.fld_lblLabel48.BOSDescription = null;
            this.fld_lblLabel48.BOSError = null;
            this.fld_lblLabel48.BOSFieldGroup = "";
            this.fld_lblLabel48.BOSFieldRelation = "";
            this.fld_lblLabel48.BOSPrivilege = "";
            this.fld_lblLabel48.BOSPropertyName = "";
            this.fld_lblLabel48.Location = new System.Drawing.Point(16, 162);
            this.fld_lblLabel48.Name = "fld_lblLabel48";
            this.fld_lblLabel48.Screen = null;
            this.fld_lblLabel48.Size = new System.Drawing.Size(70, 13);
            this.fld_lblLabel48.TabIndex = 42;
            this.fld_lblLabel48.Tag = "";
            this.fld_lblLabel48.Text = "Nơi khám bệnh";
            // 
            // fld_dteHREmployeeSocialInsRegisteredDate
            // 
            this.fld_dteHREmployeeSocialInsRegisteredDate.BOSComment = "";
            this.fld_dteHREmployeeSocialInsRegisteredDate.BOSDataMember = "HREmployeeSocialInsRegisteredDate";
            this.fld_dteHREmployeeSocialInsRegisteredDate.BOSDataSource = "HREmployees";
            this.fld_dteHREmployeeSocialInsRegisteredDate.BOSDescription = null;
            this.fld_dteHREmployeeSocialInsRegisteredDate.BOSError = null;
            this.fld_dteHREmployeeSocialInsRegisteredDate.BOSFieldGroup = "";
            this.fld_dteHREmployeeSocialInsRegisteredDate.BOSFieldRelation = "";
            this.fld_dteHREmployeeSocialInsRegisteredDate.BOSPrivilege = "";
            this.fld_dteHREmployeeSocialInsRegisteredDate.BOSPropertyName = "EditValue";
            this.fld_dteHREmployeeSocialInsRegisteredDate.EditValue = null;
            this.fld_dteHREmployeeSocialInsRegisteredDate.Location = new System.Drawing.Point(109, 76);
            this.fld_dteHREmployeeSocialInsRegisteredDate.Name = "fld_dteHREmployeeSocialInsRegisteredDate";
            this.fld_dteHREmployeeSocialInsRegisteredDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteHREmployeeSocialInsRegisteredDate.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteHREmployeeSocialInsRegisteredDate.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteHREmployeeSocialInsRegisteredDate.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteHREmployeeSocialInsRegisteredDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHREmployeeSocialInsRegisteredDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.fld_dteHREmployeeSocialInsRegisteredDate.Screen = null;
            this.fld_dteHREmployeeSocialInsRegisteredDate.Size = new System.Drawing.Size(125, 20);
            this.fld_dteHREmployeeSocialInsRegisteredDate.TabIndex = 1;
            this.fld_dteHREmployeeSocialInsRegisteredDate.Tag = "DC";
            // 
            // fld_lblLabel49
            // 
            this.fld_lblLabel49.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel49.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel49.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel49.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel49.BOSComment = "";
            this.fld_lblLabel49.BOSDataMember = "";
            this.fld_lblLabel49.BOSDataSource = "";
            this.fld_lblLabel49.BOSDescription = null;
            this.fld_lblLabel49.BOSError = null;
            this.fld_lblLabel49.BOSFieldGroup = "";
            this.fld_lblLabel49.BOSFieldRelation = "";
            this.fld_lblLabel49.BOSPrivilege = "";
            this.fld_lblLabel49.BOSPropertyName = "";
            this.fld_lblLabel49.Location = new System.Drawing.Point(16, 187);
            this.fld_lblLabel49.Name = "fld_lblLabel49";
            this.fld_lblLabel49.Screen = null;
            this.fld_lblLabel49.Size = new System.Drawing.Size(45, 13);
            this.fld_lblLabel49.TabIndex = 43;
            this.fld_lblLabel49.Tag = "";
            this.fld_lblLabel49.Text = "Ngày cấp";
            // 
            // fld_dteHREmployeeSocialInsExpiryDate
            // 
            this.fld_dteHREmployeeSocialInsExpiryDate.BOSComment = "";
            this.fld_dteHREmployeeSocialInsExpiryDate.BOSDataMember = "HREmployeeSocialInsExpiryDate";
            this.fld_dteHREmployeeSocialInsExpiryDate.BOSDataSource = "HREmployees";
            this.fld_dteHREmployeeSocialInsExpiryDate.BOSDescription = null;
            this.fld_dteHREmployeeSocialInsExpiryDate.BOSError = null;
            this.fld_dteHREmployeeSocialInsExpiryDate.BOSFieldGroup = "";
            this.fld_dteHREmployeeSocialInsExpiryDate.BOSFieldRelation = "";
            this.fld_dteHREmployeeSocialInsExpiryDate.BOSPrivilege = "";
            this.fld_dteHREmployeeSocialInsExpiryDate.BOSPropertyName = "EditValue";
            this.fld_dteHREmployeeSocialInsExpiryDate.EditValue = null;
            this.fld_dteHREmployeeSocialInsExpiryDate.Location = new System.Drawing.Point(450, 76);
            this.fld_dteHREmployeeSocialInsExpiryDate.Name = "fld_dteHREmployeeSocialInsExpiryDate";
            this.fld_dteHREmployeeSocialInsExpiryDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteHREmployeeSocialInsExpiryDate.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteHREmployeeSocialInsExpiryDate.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteHREmployeeSocialInsExpiryDate.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteHREmployeeSocialInsExpiryDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteHREmployeeSocialInsExpiryDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.fld_dteHREmployeeSocialInsExpiryDate.Screen = null;
            this.fld_dteHREmployeeSocialInsExpiryDate.Size = new System.Drawing.Size(125, 20);
            this.fld_dteHREmployeeSocialInsExpiryDate.TabIndex = 2;
            this.fld_dteHREmployeeSocialInsExpiryDate.Tag = "DC";
            // 
            // fld_lblLabel50
            // 
            this.fld_lblLabel50.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel50.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel50.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel50.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel50.BOSComment = "";
            this.fld_lblLabel50.BOSDataMember = "";
            this.fld_lblLabel50.BOSDataSource = "";
            this.fld_lblLabel50.BOSDescription = null;
            this.fld_lblLabel50.BOSError = null;
            this.fld_lblLabel50.BOSFieldGroup = "";
            this.fld_lblLabel50.BOSFieldRelation = "";
            this.fld_lblLabel50.BOSPrivilege = "";
            this.fld_lblLabel50.BOSPropertyName = "";
            this.fld_lblLabel50.Location = new System.Drawing.Point(367, 187);
            this.fld_lblLabel50.Name = "fld_lblLabel50";
            this.fld_lblLabel50.Screen = null;
            this.fld_lblLabel50.Size = new System.Drawing.Size(65, 13);
            this.fld_lblLabel50.TabIndex = 44;
            this.fld_lblLabel50.Tag = "";
            this.fld_lblLabel50.Text = "Ngày hết hạn";
            // 
            // fld_txtHREmployeeOutOfWorkInsPaymentPercent
            // 
            this.fld_txtHREmployeeOutOfWorkInsPaymentPercent.BOSComment = null;
            this.fld_txtHREmployeeOutOfWorkInsPaymentPercent.BOSDataMember = "HREmployeeOutOfWorkInsPaymentPercent";
            this.fld_txtHREmployeeOutOfWorkInsPaymentPercent.BOSDataSource = "HREmployees";
            this.fld_txtHREmployeeOutOfWorkInsPaymentPercent.BOSDescription = null;
            this.fld_txtHREmployeeOutOfWorkInsPaymentPercent.BOSError = null;
            this.fld_txtHREmployeeOutOfWorkInsPaymentPercent.BOSFieldGroup = null;
            this.fld_txtHREmployeeOutOfWorkInsPaymentPercent.BOSFieldRelation = null;
            this.fld_txtHREmployeeOutOfWorkInsPaymentPercent.BOSPrivilege = null;
            this.fld_txtHREmployeeOutOfWorkInsPaymentPercent.BOSPropertyName = "Text";
            this.fld_txtHREmployeeOutOfWorkInsPaymentPercent.Location = new System.Drawing.Point(117, 110);
            this.fld_txtHREmployeeOutOfWorkInsPaymentPercent.MenuManager = this.screenToolbar;
            this.fld_txtHREmployeeOutOfWorkInsPaymentPercent.Name = "fld_txtHREmployeeOutOfWorkInsPaymentPercent";
            this.fld_txtHREmployeeOutOfWorkInsPaymentPercent.Properties.Mask.EditMask = "n";
            this.fld_txtHREmployeeOutOfWorkInsPaymentPercent.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.fld_txtHREmployeeOutOfWorkInsPaymentPercent.Screen = null;
            this.fld_txtHREmployeeOutOfWorkInsPaymentPercent.Size = new System.Drawing.Size(125, 20);
            this.fld_txtHREmployeeOutOfWorkInsPaymentPercent.TabIndex = 5;
            this.fld_txtHREmployeeOutOfWorkInsPaymentPercent.Tag = "DC";
            // 
            // fld_txtHREmployeeHealthInsPaymentPercent
            // 
            this.fld_txtHREmployeeHealthInsPaymentPercent.BOSComment = null;
            this.fld_txtHREmployeeHealthInsPaymentPercent.BOSDataMember = "HREmployeeHealthInsPaymentPercent";
            this.fld_txtHREmployeeHealthInsPaymentPercent.BOSDataSource = "HREmployees";
            this.fld_txtHREmployeeHealthInsPaymentPercent.BOSDescription = null;
            this.fld_txtHREmployeeHealthInsPaymentPercent.BOSError = null;
            this.fld_txtHREmployeeHealthInsPaymentPercent.BOSFieldGroup = null;
            this.fld_txtHREmployeeHealthInsPaymentPercent.BOSFieldRelation = null;
            this.fld_txtHREmployeeHealthInsPaymentPercent.BOSPrivilege = null;
            this.fld_txtHREmployeeHealthInsPaymentPercent.BOSPropertyName = "Text";
            this.fld_txtHREmployeeHealthInsPaymentPercent.Location = new System.Drawing.Point(117, 83);
            this.fld_txtHREmployeeHealthInsPaymentPercent.MenuManager = this.screenToolbar;
            this.fld_txtHREmployeeHealthInsPaymentPercent.Name = "fld_txtHREmployeeHealthInsPaymentPercent";
            this.fld_txtHREmployeeHealthInsPaymentPercent.Properties.Mask.EditMask = "n";
            this.fld_txtHREmployeeHealthInsPaymentPercent.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.fld_txtHREmployeeHealthInsPaymentPercent.Screen = null;
            this.fld_txtHREmployeeHealthInsPaymentPercent.Size = new System.Drawing.Size(125, 20);
            this.fld_txtHREmployeeHealthInsPaymentPercent.TabIndex = 3;
            this.fld_txtHREmployeeHealthInsPaymentPercent.Tag = "DC";
            // 
            // fld_lblLabel56
            // 
            this.fld_lblLabel56.BOSComment = null;
            this.fld_lblLabel56.BOSDataMember = null;
            this.fld_lblLabel56.BOSDataSource = null;
            this.fld_lblLabel56.BOSDescription = null;
            this.fld_lblLabel56.BOSError = null;
            this.fld_lblLabel56.BOSFieldGroup = null;
            this.fld_lblLabel56.BOSFieldRelation = null;
            this.fld_lblLabel56.BOSPrivilege = null;
            this.fld_lblLabel56.BOSPropertyName = null;
            this.fld_lblLabel56.Location = new System.Drawing.Point(11, 113);
            this.fld_lblLabel56.Name = "fld_lblLabel56";
            this.fld_lblLabel56.Screen = null;
            this.fld_lblLabel56.Size = new System.Drawing.Size(48, 13);
            this.fld_lblLabel56.TabIndex = 45;
            this.fld_lblLabel56.Text = "BHTN (%)";
            // 
            // fld_lblLabel46
            // 
            this.fld_lblLabel46.BOSComment = null;
            this.fld_lblLabel46.BOSDataMember = null;
            this.fld_lblLabel46.BOSDataSource = null;
            this.fld_lblLabel46.BOSDescription = null;
            this.fld_lblLabel46.BOSError = null;
            this.fld_lblLabel46.BOSFieldGroup = null;
            this.fld_lblLabel46.BOSFieldRelation = null;
            this.fld_lblLabel46.BOSPrivilege = null;
            this.fld_lblLabel46.BOSPropertyName = null;
            this.fld_lblLabel46.Location = new System.Drawing.Point(11, 86);
            this.fld_lblLabel46.Name = "fld_lblLabel46";
            this.fld_lblLabel46.Screen = null;
            this.fld_lblLabel46.Size = new System.Drawing.Size(47, 13);
            this.fld_lblLabel46.TabIndex = 45;
            this.fld_lblLabel46.Text = "BHYT (%)";
            // 
            // fld_txtHREmployeeSocialInsPaymentPercent
            // 
            this.fld_txtHREmployeeSocialInsPaymentPercent.BOSComment = "";
            this.fld_txtHREmployeeSocialInsPaymentPercent.BOSDataMember = "HREmployeeSocialInsPaymentPercent";
            this.fld_txtHREmployeeSocialInsPaymentPercent.BOSDataSource = "HREmployees";
            this.fld_txtHREmployeeSocialInsPaymentPercent.BOSDescription = null;
            this.fld_txtHREmployeeSocialInsPaymentPercent.BOSError = null;
            this.fld_txtHREmployeeSocialInsPaymentPercent.BOSFieldGroup = "";
            this.fld_txtHREmployeeSocialInsPaymentPercent.BOSFieldRelation = "";
            this.fld_txtHREmployeeSocialInsPaymentPercent.BOSPrivilege = "";
            this.fld_txtHREmployeeSocialInsPaymentPercent.BOSPropertyName = "Text";
            this.fld_txtHREmployeeSocialInsPaymentPercent.EditValue = "";
            this.fld_txtHREmployeeSocialInsPaymentPercent.Location = new System.Drawing.Point(117, 57);
            this.fld_txtHREmployeeSocialInsPaymentPercent.Name = "fld_txtHREmployeeSocialInsPaymentPercent";
            this.fld_txtHREmployeeSocialInsPaymentPercent.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtHREmployeeSocialInsPaymentPercent.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtHREmployeeSocialInsPaymentPercent.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtHREmployeeSocialInsPaymentPercent.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtHREmployeeSocialInsPaymentPercent.Properties.Mask.EditMask = "n";
            this.fld_txtHREmployeeSocialInsPaymentPercent.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.fld_txtHREmployeeSocialInsPaymentPercent.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtHREmployeeSocialInsPaymentPercent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtHREmployeeSocialInsPaymentPercent.Screen = null;
            this.fld_txtHREmployeeSocialInsPaymentPercent.Size = new System.Drawing.Size(125, 20);
            this.fld_txtHREmployeeSocialInsPaymentPercent.TabIndex = 1;
            this.fld_txtHREmployeeSocialInsPaymentPercent.Tag = "DC";
            // 
            // fld_lblLabel43
            // 
            this.fld_lblLabel43.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel43.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel43.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel43.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel43.BOSComment = "";
            this.fld_lblLabel43.BOSDataMember = "";
            this.fld_lblLabel43.BOSDataSource = "";
            this.fld_lblLabel43.BOSDescription = null;
            this.fld_lblLabel43.BOSError = null;
            this.fld_lblLabel43.BOSFieldGroup = "";
            this.fld_lblLabel43.BOSFieldRelation = "";
            this.fld_lblLabel43.BOSPrivilege = "";
            this.fld_lblLabel43.BOSPropertyName = "";
            this.fld_lblLabel43.Location = new System.Drawing.Point(11, 60);
            this.fld_lblLabel43.Name = "fld_lblLabel43";
            this.fld_lblLabel43.Screen = null;
            this.fld_lblLabel43.Size = new System.Drawing.Size(48, 13);
            this.fld_lblLabel43.TabIndex = 24;
            this.fld_lblLabel43.Tag = "";
            this.fld_lblLabel43.Text = "BHXH (%)";
            // 
            // fld_lkeHRInsCalculatedSalaryType
            // 
            this.fld_lkeHRInsCalculatedSalaryType.BOSAllowAddNew = false;
            this.fld_lkeHRInsCalculatedSalaryType.BOSAllowDummy = false;
            this.fld_lkeHRInsCalculatedSalaryType.BOSComment = "";
            this.fld_lkeHRInsCalculatedSalaryType.BOSDataMember = "HRInsCalculatedSalaryType";
            this.fld_lkeHRInsCalculatedSalaryType.BOSDataSource = "HREmployees";
            this.fld_lkeHRInsCalculatedSalaryType.BOSDescription = null;
            this.fld_lkeHRInsCalculatedSalaryType.BOSDummyText = null;
            this.fld_lkeHRInsCalculatedSalaryType.BOSError = null;
            this.fld_lkeHRInsCalculatedSalaryType.BOSFieldGroup = "";
            this.fld_lkeHRInsCalculatedSalaryType.BOSFieldParent = "";
            this.fld_lkeHRInsCalculatedSalaryType.BOSFieldRelation = "";
            this.fld_lkeHRInsCalculatedSalaryType.BOSPrivilege = "";
            this.fld_lkeHRInsCalculatedSalaryType.BOSPropertyName = "EditValue";
            this.fld_lkeHRInsCalculatedSalaryType.BOSSelectType = "";
            this.fld_lkeHRInsCalculatedSalaryType.BOSSelectTypeValue = "";
            this.fld_lkeHRInsCalculatedSalaryType.CurrentDisplayText = null;
            this.fld_lkeHRInsCalculatedSalaryType.Location = new System.Drawing.Point(117, 32);
            this.fld_lkeHRInsCalculatedSalaryType.Name = "fld_lkeHRInsCalculatedSalaryType";
            this.fld_lkeHRInsCalculatedSalaryType.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeHRInsCalculatedSalaryType.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeHRInsCalculatedSalaryType.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeHRInsCalculatedSalaryType.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeHRInsCalculatedSalaryType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeHRInsCalculatedSalaryType.Properties.NullText = "";
            this.fld_lkeHRInsCalculatedSalaryType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeHRInsCalculatedSalaryType.Screen = null;
            this.fld_lkeHRInsCalculatedSalaryType.Size = new System.Drawing.Size(451, 20);
            this.fld_lkeHRInsCalculatedSalaryType.TabIndex = 0;
            this.fld_lkeHRInsCalculatedSalaryType.Tag = "DC";
            // 
            // fld_lblLabel45
            // 
            this.fld_lblLabel45.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel45.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel45.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel45.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel45.BOSComment = "";
            this.fld_lblLabel45.BOSDataMember = "";
            this.fld_lblLabel45.BOSDataSource = "";
            this.fld_lblLabel45.BOSDescription = null;
            this.fld_lblLabel45.BOSError = null;
            this.fld_lblLabel45.BOSFieldGroup = "";
            this.fld_lblLabel45.BOSFieldRelation = "";
            this.fld_lblLabel45.BOSPrivilege = "";
            this.fld_lblLabel45.BOSPropertyName = "";
            this.fld_lblLabel45.Location = new System.Drawing.Point(11, 35);
            this.fld_lblLabel45.Name = "fld_lblLabel45";
            this.fld_lblLabel45.Screen = null;
            this.fld_lblLabel45.Size = new System.Drawing.Size(71, 13);
            this.fld_lblLabel45.TabIndex = 26;
            this.fld_lblLabel45.Tag = "";
            this.fld_lblLabel45.Text = "Dựa vào lương";
            // 
            // fld_lblLabel51
            // 
            this.fld_lblLabel51.BOSComment = null;
            this.fld_lblLabel51.BOSDataMember = "";
            this.fld_lblLabel51.BOSDataSource = "";
            this.fld_lblLabel51.BOSDescription = null;
            this.fld_lblLabel51.BOSError = null;
            this.fld_lblLabel51.BOSFieldGroup = null;
            this.fld_lblLabel51.BOSFieldRelation = null;
            this.fld_lblLabel51.BOSPrivilege = null;
            this.fld_lblLabel51.BOSPropertyName = "";
            this.fld_lblLabel51.Location = new System.Drawing.Point(333, 60);
            this.fld_lblLabel51.Name = "fld_lblLabel51";
            this.fld_lblLabel51.Screen = null;
            this.fld_lblLabel51.Size = new System.Drawing.Size(77, 13);
            this.fld_lblLabel51.TabIndex = 49;
            this.fld_lblLabel51.Tag = "DC";
            this.fld_lblLabel51.Text = "Tiền Thuế TNCN";
            // 
            // fld_txtHREmployeeTaxPaymentAmount
            // 
            this.fld_txtHREmployeeTaxPaymentAmount.BOSComment = null;
            this.fld_txtHREmployeeTaxPaymentAmount.BOSDataMember = "HREmployeeTaxPaymentAmount";
            this.fld_txtHREmployeeTaxPaymentAmount.BOSDataSource = "HREmployees";
            this.fld_txtHREmployeeTaxPaymentAmount.BOSDescription = null;
            this.fld_txtHREmployeeTaxPaymentAmount.BOSError = null;
            this.fld_txtHREmployeeTaxPaymentAmount.BOSFieldGroup = null;
            this.fld_txtHREmployeeTaxPaymentAmount.BOSFieldRelation = null;
            this.fld_txtHREmployeeTaxPaymentAmount.BOSPrivilege = null;
            this.fld_txtHREmployeeTaxPaymentAmount.BOSPropertyName = "Text";
            this.fld_txtHREmployeeTaxPaymentAmount.Location = new System.Drawing.Point(443, 57);
            this.fld_txtHREmployeeTaxPaymentAmount.MenuManager = this.screenToolbar;
            this.fld_txtHREmployeeTaxPaymentAmount.Name = "fld_txtHREmployeeTaxPaymentAmount";
            this.fld_txtHREmployeeTaxPaymentAmount.Properties.Mask.EditMask = "n";
            this.fld_txtHREmployeeTaxPaymentAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.fld_txtHREmployeeTaxPaymentAmount.Screen = null;
            this.fld_txtHREmployeeTaxPaymentAmount.Size = new System.Drawing.Size(125, 20);
            this.fld_txtHREmployeeTaxPaymentAmount.TabIndex = 2;
            this.fld_txtHREmployeeTaxPaymentAmount.Tag = "DC";
            // 
            // fld_grcGroupControl5
            // 
            this.fld_grcGroupControl5.BOSComment = null;
            this.fld_grcGroupControl5.BOSDataMember = null;
            this.fld_grcGroupControl5.BOSDataSource = null;
            this.fld_grcGroupControl5.BOSDescription = null;
            this.fld_grcGroupControl5.BOSError = null;
            this.fld_grcGroupControl5.BOSFieldGroup = null;
            this.fld_grcGroupControl5.BOSFieldRelation = null;
            this.fld_grcGroupControl5.BOSPrivilege = null;
            this.fld_grcGroupControl5.BOSPropertyName = null;
            this.fld_grcGroupControl5.Controls.Add(this.fld_lblLabel45);
            this.fld_grcGroupControl5.Controls.Add(this.fld_txtHREmployeeSyndicatePaymentPercent);
            this.fld_grcGroupControl5.Controls.Add(this.fld_txtHREmployeeTaxPaymentAmount);
            this.fld_grcGroupControl5.Controls.Add(this.fld_lblLabel46);
            this.fld_grcGroupControl5.Controls.Add(this.fld_lblLabel56);
            this.fld_grcGroupControl5.Controls.Add(this.fld_txtHREmployeeSocialInsPaymentPercent);
            this.fld_grcGroupControl5.Controls.Add(this.fld_lblLabel43);
            this.fld_grcGroupControl5.Controls.Add(this.bosLabel14);
            this.fld_grcGroupControl5.Controls.Add(this.fld_lblLabel51);
            this.fld_grcGroupControl5.Controls.Add(this.fld_lkeHRInsCalculatedSalaryType);
            this.fld_grcGroupControl5.Controls.Add(this.fld_txtHREmployeeHealthInsPaymentPercent);
            this.fld_grcGroupControl5.Controls.Add(this.fld_txtHREmployeeOutOfWorkInsPaymentPercent);
            this.fld_grcGroupControl5.Location = new System.Drawing.Point(1, 417);
            this.fld_grcGroupControl5.Name = "fld_grcGroupControl5";
            this.fld_grcGroupControl5.Screen = null;
            this.fld_grcGroupControl5.Size = new System.Drawing.Size(926, 140);
            this.fld_grcGroupControl5.TabIndex = 2;
            this.fld_grcGroupControl5.Text = "Các khoản khấu trừ lương";
            // 
            // fld_txtHREmployeeSyndicatePaymentPercent
            // 
            this.fld_txtHREmployeeSyndicatePaymentPercent.BOSComment = null;
            this.fld_txtHREmployeeSyndicatePaymentPercent.BOSDataMember = "HREmployeeSyndicatePaymentPercent";
            this.fld_txtHREmployeeSyndicatePaymentPercent.BOSDataSource = "HREmployees";
            this.fld_txtHREmployeeSyndicatePaymentPercent.BOSDescription = null;
            this.fld_txtHREmployeeSyndicatePaymentPercent.BOSError = null;
            this.fld_txtHREmployeeSyndicatePaymentPercent.BOSFieldGroup = null;
            this.fld_txtHREmployeeSyndicatePaymentPercent.BOSFieldRelation = null;
            this.fld_txtHREmployeeSyndicatePaymentPercent.BOSPrivilege = null;
            this.fld_txtHREmployeeSyndicatePaymentPercent.BOSPropertyName = "Text";
            this.fld_txtHREmployeeSyndicatePaymentPercent.Location = new System.Drawing.Point(443, 83);
            this.fld_txtHREmployeeSyndicatePaymentPercent.Name = "fld_txtHREmployeeSyndicatePaymentPercent";
            this.fld_txtHREmployeeSyndicatePaymentPercent.Properties.Mask.EditMask = "n";
            this.fld_txtHREmployeeSyndicatePaymentPercent.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.fld_txtHREmployeeSyndicatePaymentPercent.Screen = null;
            this.fld_txtHREmployeeSyndicatePaymentPercent.Size = new System.Drawing.Size(125, 20);
            this.fld_txtHREmployeeSyndicatePaymentPercent.TabIndex = 4;
            this.fld_txtHREmployeeSyndicatePaymentPercent.Tag = "DC";
            // 
            // bosLabel14
            // 
            this.bosLabel14.BOSComment = null;
            this.bosLabel14.BOSDataMember = "";
            this.bosLabel14.BOSDataSource = "";
            this.bosLabel14.BOSDescription = null;
            this.bosLabel14.BOSError = null;
            this.bosLabel14.BOSFieldGroup = null;
            this.bosLabel14.BOSFieldRelation = null;
            this.bosLabel14.BOSPrivilege = null;
            this.bosLabel14.BOSPropertyName = "";
            this.bosLabel14.Location = new System.Drawing.Point(333, 86);
            this.bosLabel14.Name = "bosLabel14";
            this.bosLabel14.Screen = null;
            this.bosLabel14.Size = new System.Drawing.Size(89, 13);
            this.bosLabel14.TabIndex = 49;
            this.bosLabel14.Tag = "DC";
            this.bosLabel14.Text = "Phí công đoàn (%)";
            // 
            // DMSS100
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(933, 579);
            this.Controls.Add(this.fld_grcGroupControl5);
            this.Controls.Add(this.fld_grcGroupControl3);
            this.Controls.Add(this.fld_grcGroupControl4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DMSS100";
            this.ScreenNumber = "DMSS100";
            this.Tag = "DM";
            this.Text = "Thông tin lương - bảo hiểm";
            this.Controls.SetChildIndex(this.fld_grcGroupControl4, 0);
            this.Controls.SetChildIndex(this.fld_grcGroupControl3, 0);
            this.Controls.SetChildIndex(this.fld_grcGroupControl5, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_grcGroupControl3)).EndInit();
            this.fld_grcGroupControl3.ResumeLayout(false);
            this.fld_grcGroupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtDonGiaCong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeExtraHarmfullSubsidies.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeExtraResponsibility.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeExtraLunch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeExtraGasolineVehicle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosLookupEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRPayRollCalculatedSalaryType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeContractSlrAmt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeExtraSalary1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeWorkingSlrAmt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeSalaryFactor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HREmployeePayrollFormulaID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HRTimeSheetScaleID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_grcGroupControl4)).EndInit();
            this.fld_grcGroupControl4.ResumeLayout(false);
            this.fld_grcGroupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeHealthInsNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeHealthInsRegisteredPlace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeHealthInsExpiryDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeHealthInsExpiryDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeHealthInsRegisteredDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeHealthInsRegisteredDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeSocialInsNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeSocialInsRegisteredDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeSocialInsRegisteredDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeSocialInsExpiryDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteHREmployeeSocialInsExpiryDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeOutOfWorkInsPaymentPercent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeHealthInsPaymentPercent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeSocialInsPaymentPercent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeHRInsCalculatedSalaryType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeTaxPaymentAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_grcGroupControl5)).EndInit();
            this.fld_grcGroupControl5.ResumeLayout(false);
            this.fld_grcGroupControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtHREmployeeSyndicatePaymentPercent.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private IContainer components;
        private BOSComponent.BOSLine fld_Line1;
        private BOSComponent.BOSLabel fld_lblLabel36;
        private BOSComponent.BOSLabel fld_lblLabel38;
        private BOSComponent.BOSLine fld_Line2;
        private BOSComponent.BOSLabel fld_lblLabel46;
        private BOSComponent.BOSTextBox fld_txtHREmployeeOutOfWorkInsPaymentPercent;
        private BOSComponent.BOSTextBox fld_txtHREmployeeHealthInsPaymentPercent;
        private BOSComponent.BOSLabel fld_lblLabel56;
        private BOSComponent.BOSTextBox fld_txtHREmployeeTaxPaymentAmount;
        private BOSComponent.BOSLabel fld_lblLabel51;
        private BOSComponent.BOSGroupControl fld_grcGroupControl5;
        private BOSComponent.BOSLookupEdit fld_lkeHRPayRollCalculatedSalaryType;
        private BOSComponent.BOSLookupEdit fld_lkeFK_HRTimeSheetScaleID;
        private BOSComponent.BOSLabel bosLabel9;
        private BOSComponent.BOSLabel bosLabel8;
        private BOSComponent.BOSLabel fld_lblLabel61;
        private BOSComponent.BOSTextBox fld_txtHREmployeeSalaryFactor;
        private BOSComponent.BOSLabel bosLabel13;
        private BOSComponent.BOSTextBox fld_txtHREmployeeExtraSalary1;
        private BOSComponent.BOSLabel bosLabel14;
        private BOSComponent.BOSTextBox fld_txtHREmployeeSyndicatePaymentPercent;
        private BOSComponent.BOSLookupEdit fld_lkeFK_HREmployeePayrollFormulaID;
        private BOSComponent.BOSLabel bosLabel1;
        private BOSComponent.BOSLookupEdit bosLookupEdit2;
        private BOSComponent.BOSLabel bosLabel2;
        private BOSComponent.BOSLabel bosLabel4;
        private BOSComponent.BOSTextBox fld_txtHREmployeeExtraLunch;
        private BOSComponent.BOSLabel bosLabel3;
        private BOSComponent.BOSTextBox fld_txtHREmployeeExtraGasolineVehicle;
        private BOSComponent.BOSLabel bosLabel5;
        private BOSComponent.BOSTextBox fld_txtHREmployeeExtraResponsibility;
        private BOSComponent.BOSLabel bosLabel6;
        private BOSComponent.BOSTextBox fld_txtHREmployeeExtraHarmfullSubsidies;
        private BOSComponent.BOSLabel bosLabel7;
        private BOSComponent.BOSTextBox fld_txtDonGiaCong;
	}
}
