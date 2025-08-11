using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.MEPatient.UI
{
	/// <summary>
	/// Summary description for DMMEPA103
	/// </summary>
	partial class DMMEPA103
	{
		private BOSComponent.BOSGroupControl fld_grcGroupControl7;
        private BOSComponent.BOSTextBox fld_txtMEPatientInsNo;
		private BOSComponent.BOSDateEdit fld_dteMEPatientInsRegisteredDate;
		private BOSComponent.BOSDateEdit fld_dteMEPatientInsExpiryDate;
		private BOSComponent.BOSTextBox fld_txtMEPatientInsRegisteredPlace;
        private BOSComponent.BOSLabel fld_lblLabel43;
		private BOSComponent.BOSLabel fld_lblLabel45;
		private BOSComponent.BOSLabel fld_lblLabel46;
		private BOSComponent.BOSLabel fld_lblLabel47;
		private BOSComponent.BOSLabel fld_lblLabel48;
		private BOSComponent.BOSButton fld_btnDelete103;
        private BOSComponent.BOSButton fld_btnEdit103;
		private BOSComponent.BOSGroupControl fld_grcGroupControl8;
		private BOSComponent.BOSButton fld_btnAdd103;
        private MEPatientInssGridControl fld_dgcMEPatientInss;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvMEPatientInss;


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMMEPA103));
            this.fld_grcGroupControl7 = new BOSComponent.BOSGroupControl(this.components);
            this.fld_chkMEPatientInsEnough5Year = new BOSComponent.BOSCheckEdit(this.components);
            this.fld_chkMEPatientInsIsK1K2K3 = new BOSComponent.BOSCheckEdit(this.components);
            this.fld_btnAdd103 = new BOSComponent.BOSButton(this.components);
            this.fld_btnEdit103 = new BOSComponent.BOSButton(this.components);
            this.fld_lkeMEPatientInsPlaceLevelType = new BOSComponent.BOSLookupEdit(this.components);
            this.fld_btnDelete103 = new BOSComponent.BOSButton(this.components);
            this.fld_txtMEPatientInsRegisteredPlaceNo = new BOSComponent.BOSTextBox(this.components);
            this.bosLabel3 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel2 = new BOSComponent.BOSLabel(this.components);
            this.fld_lkeFK_MECompanyID = new BOSComponent.BOSLookupEdit(this.components);
            this.fld_txtMEPatientInsNo = new BOSComponent.BOSTextBox(this.components);
            this.fld_dteMEPatientInsRegisteredDate = new BOSComponent.BOSDateEdit(this.components);
            this.fld_dteMEPatientInsExpiryDate = new BOSComponent.BOSDateEdit(this.components);
            this.fld_txtMEPatientInsRegisteredPlace = new BOSComponent.BOSTextBox(this.components);
            this.fld_lblLabel43 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel45 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel46 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel47 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel48 = new BOSComponent.BOSLabel(this.components);
            this.fld_grcGroupControl8 = new BOSComponent.BOSGroupControl(this.components);
            this.fld_dgcMEPatientInss = new BOSERP.Modules.MEPatient.MEPatientInssGridControl();
            this.fld_dgvMEPatientInss = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bosPanel1 = new BOSComponent.BOSPanel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fld_grcGroupControl7)).BeginInit();
            this.fld_grcGroupControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkMEPatientInsEnough5Year.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkMEPatientInsIsK1K2K3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEPatientInsPlaceLevelType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEPatientInsRegisteredPlaceNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_MECompanyID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEPatientInsNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteMEPatientInsRegisteredDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteMEPatientInsRegisteredDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteMEPatientInsExpiryDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteMEPatientInsExpiryDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEPatientInsRegisteredPlace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_grcGroupControl8)).BeginInit();
            this.fld_grcGroupControl8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEPatientInss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEPatientInss)).BeginInit();
            this.bosPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fld_grcGroupControl7
            // 
            resources.ApplyResources(this.fld_grcGroupControl7, "fld_grcGroupControl7");
            this.fld_grcGroupControl7.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.fld_grcGroupControl7.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_grcGroupControl7.Appearance.Options.UseBackColor = true;
            this.fld_grcGroupControl7.Appearance.Options.UseForeColor = true;
            this.fld_grcGroupControl7.BOSComment = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_grcGroupControl7.BOSDataMember = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_grcGroupControl7.BOSDataSource = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_grcGroupControl7.BOSDescription = null;
            this.fld_grcGroupControl7.BOSError = null;
            this.fld_grcGroupControl7.BOSFieldGroup = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_grcGroupControl7.BOSFieldRelation = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_grcGroupControl7.BOSPrivilege = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_grcGroupControl7.BOSPropertyName = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_grcGroupControl7.Controls.Add(this.fld_chkMEPatientInsEnough5Year);
            this.fld_grcGroupControl7.Controls.Add(this.fld_chkMEPatientInsIsK1K2K3);
            this.fld_grcGroupControl7.Controls.Add(this.fld_btnAdd103);
            this.fld_grcGroupControl7.Controls.Add(this.fld_btnEdit103);
            this.fld_grcGroupControl7.Controls.Add(this.fld_lkeMEPatientInsPlaceLevelType);
            this.fld_grcGroupControl7.Controls.Add(this.fld_btnDelete103);
            this.fld_grcGroupControl7.Controls.Add(this.fld_txtMEPatientInsRegisteredPlaceNo);
            this.fld_grcGroupControl7.Controls.Add(this.bosLabel3);
            this.fld_grcGroupControl7.Controls.Add(this.bosLabel2);
            this.fld_grcGroupControl7.Controls.Add(this.fld_lkeFK_MECompanyID);
            this.fld_grcGroupControl7.Controls.Add(this.fld_txtMEPatientInsNo);
            this.fld_grcGroupControl7.Controls.Add(this.fld_dteMEPatientInsRegisteredDate);
            this.fld_grcGroupControl7.Controls.Add(this.fld_dteMEPatientInsExpiryDate);
            this.fld_grcGroupControl7.Controls.Add(this.fld_txtMEPatientInsRegisteredPlace);
            this.fld_grcGroupControl7.Controls.Add(this.fld_lblLabel43);
            this.fld_grcGroupControl7.Controls.Add(this.fld_lblLabel45);
            this.fld_grcGroupControl7.Controls.Add(this.fld_lblLabel46);
            this.fld_grcGroupControl7.Controls.Add(this.fld_lblLabel47);
            this.fld_grcGroupControl7.Controls.Add(this.fld_lblLabel48);
            this.fld_grcGroupControl7.Name = "fld_grcGroupControl7";
            this.fld_grcGroupControl7.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_grcGroupControl7, ((bool)(resources.GetObject("fld_grcGroupControl7.ShowHelp"))));
            this.fld_grcGroupControl7.Tag = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            // 
            // fld_chkMEPatientInsEnough5Year
            // 
            this.fld_chkMEPatientInsEnough5Year.BOSComment = "";
            this.fld_chkMEPatientInsEnough5Year.BOSDataMember = "MEPatientInsEnough5Year";
            this.fld_chkMEPatientInsEnough5Year.BOSDataSource = "MEPatientInss";
            this.fld_chkMEPatientInsEnough5Year.BOSDescription = null;
            this.fld_chkMEPatientInsEnough5Year.BOSError = "";
            this.fld_chkMEPatientInsEnough5Year.BOSFieldGroup = "";
            this.fld_chkMEPatientInsEnough5Year.BOSFieldRelation = "";
            this.fld_chkMEPatientInsEnough5Year.BOSPrivilege = "";
            this.fld_chkMEPatientInsEnough5Year.BOSPropertyName = "EditValue";
            resources.ApplyResources(this.fld_chkMEPatientInsEnough5Year, "fld_chkMEPatientInsEnough5Year");
            this.fld_chkMEPatientInsEnough5Year.Name = "fld_chkMEPatientInsEnough5Year";
            this.fld_chkMEPatientInsEnough5Year.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_chkMEPatientInsEnough5Year.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_chkMEPatientInsEnough5Year.Properties.Appearance.Options.UseBackColor = true;
            this.fld_chkMEPatientInsEnough5Year.Properties.Appearance.Options.UseForeColor = true;
            this.fld_chkMEPatientInsEnough5Year.Properties.Caption = resources.GetString("fld_chkMEPatientInsEnough5Year.Properties.Caption");
            this.fld_chkMEPatientInsEnough5Year.Screen = null;
            this.fld_chkMEPatientInsEnough5Year.Tag = "DC";
            // 
            // fld_chkMEPatientInsIsK1K2K3
            // 
            this.fld_chkMEPatientInsIsK1K2K3.BOSComment = "";
            this.fld_chkMEPatientInsIsK1K2K3.BOSDataMember = "MEPatientInsIsK1K2K3";
            this.fld_chkMEPatientInsIsK1K2K3.BOSDataSource = "MEPatientInss";
            this.fld_chkMEPatientInsIsK1K2K3.BOSDescription = null;
            this.fld_chkMEPatientInsIsK1K2K3.BOSError = "";
            this.fld_chkMEPatientInsIsK1K2K3.BOSFieldGroup = "";
            this.fld_chkMEPatientInsIsK1K2K3.BOSFieldRelation = "";
            this.fld_chkMEPatientInsIsK1K2K3.BOSPrivilege = "";
            this.fld_chkMEPatientInsIsK1K2K3.BOSPropertyName = "EditValue";
            resources.ApplyResources(this.fld_chkMEPatientInsIsK1K2K3, "fld_chkMEPatientInsIsK1K2K3");
            this.fld_chkMEPatientInsIsK1K2K3.Name = "fld_chkMEPatientInsIsK1K2K3";
            this.fld_chkMEPatientInsIsK1K2K3.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_chkMEPatientInsIsK1K2K3.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_chkMEPatientInsIsK1K2K3.Properties.Appearance.Options.UseBackColor = true;
            this.fld_chkMEPatientInsIsK1K2K3.Properties.Appearance.Options.UseForeColor = true;
            this.fld_chkMEPatientInsIsK1K2K3.Properties.Caption = resources.GetString("fld_chkMEPatientInsIsK1K2K3.Properties.Caption");
            this.fld_chkMEPatientInsIsK1K2K3.Screen = null;
            this.fld_chkMEPatientInsIsK1K2K3.Tag = "DC";
            // 
            // fld_btnAdd103
            // 
            this.fld_btnAdd103.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_btnAdd103.Appearance.Options.UseForeColor = true;
            this.fld_btnAdd103.BOSComment = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_btnAdd103.BOSDataMember = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_btnAdd103.BOSDataSource = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_btnAdd103.BOSDescription = null;
            this.fld_btnAdd103.BOSError = null;
            this.fld_btnAdd103.BOSFieldGroup = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_btnAdd103.BOSFieldRelation = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_btnAdd103.BOSPrivilege = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_btnAdd103.BOSPropertyName = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            resources.ApplyResources(this.fld_btnAdd103, "fld_btnAdd103");
            this.fld_btnAdd103.Name = "fld_btnAdd103";
            this.fld_btnAdd103.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_btnAdd103, ((bool)(resources.GetObject("fld_btnAdd103.ShowHelp"))));
            this.fld_btnAdd103.Tag = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_btnAdd103.Click += new System.EventHandler(this.fld_btnAdd103_Click);
            // 
            // fld_btnEdit103
            // 
            this.fld_btnEdit103.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_btnEdit103.Appearance.Options.UseForeColor = true;
            this.fld_btnEdit103.BOSComment = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_btnEdit103.BOSDataMember = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_btnEdit103.BOSDataSource = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_btnEdit103.BOSDescription = null;
            this.fld_btnEdit103.BOSError = null;
            this.fld_btnEdit103.BOSFieldGroup = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_btnEdit103.BOSFieldRelation = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_btnEdit103.BOSPrivilege = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_btnEdit103.BOSPropertyName = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            resources.ApplyResources(this.fld_btnEdit103, "fld_btnEdit103");
            this.fld_btnEdit103.Name = "fld_btnEdit103";
            this.fld_btnEdit103.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_btnEdit103, ((bool)(resources.GetObject("fld_btnEdit103.ShowHelp"))));
            this.fld_btnEdit103.Tag = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_btnEdit103.Click += new System.EventHandler(this.fld_btnEdit103_Click);
            // 
            // fld_lkeMEPatientInsPlaceLevelType
            // 
            this.fld_lkeMEPatientInsPlaceLevelType.BOSAllowAddNew = false;
            this.fld_lkeMEPatientInsPlaceLevelType.BOSAllowDummy = true;
            this.fld_lkeMEPatientInsPlaceLevelType.BOSComment = null;
            this.fld_lkeMEPatientInsPlaceLevelType.BOSDataMember = "MEPatientInsPlaceLevelType";
            this.fld_lkeMEPatientInsPlaceLevelType.BOSDataSource = "MEPatientInss";
            this.fld_lkeMEPatientInsPlaceLevelType.BOSDescription = null;
            this.fld_lkeMEPatientInsPlaceLevelType.BOSError = null;
            this.fld_lkeMEPatientInsPlaceLevelType.BOSFieldGroup = null;
            this.fld_lkeMEPatientInsPlaceLevelType.BOSFieldParent = null;
            this.fld_lkeMEPatientInsPlaceLevelType.BOSFieldRelation = null;
            this.fld_lkeMEPatientInsPlaceLevelType.BOSPrivilege = null;
            this.fld_lkeMEPatientInsPlaceLevelType.BOSPropertyName = "EditValue";
            this.fld_lkeMEPatientInsPlaceLevelType.BOSSelectType = null;
            this.fld_lkeMEPatientInsPlaceLevelType.BOSSelectTypeValue = null;
            this.fld_lkeMEPatientInsPlaceLevelType.CurrentDisplayText = null;
            resources.ApplyResources(this.fld_lkeMEPatientInsPlaceLevelType, "fld_lkeMEPatientInsPlaceLevelType");
            this.fld_lkeMEPatientInsPlaceLevelType.Name = "fld_lkeMEPatientInsPlaceLevelType";
            this.fld_lkeMEPatientInsPlaceLevelType.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeMEPatientInsPlaceLevelType.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeMEPatientInsPlaceLevelType.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeMEPatientInsPlaceLevelType.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeMEPatientInsPlaceLevelType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("fld_lkeMEPatientInsPlaceLevelType.Properties.Buttons"))))});
            this.fld_lkeMEPatientInsPlaceLevelType.Properties.NullText = resources.GetString("fld_lkeMEPatientInsPlaceLevelType.Properties.NullText");
            this.fld_lkeMEPatientInsPlaceLevelType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeMEPatientInsPlaceLevelType.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_lkeMEPatientInsPlaceLevelType, ((bool)(resources.GetObject("fld_lkeMEPatientInsPlaceLevelType.ShowHelp"))));
            this.fld_lkeMEPatientInsPlaceLevelType.Tag = "DC";
            // 
            // fld_btnDelete103
            // 
            this.fld_btnDelete103.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_btnDelete103.Appearance.Options.UseForeColor = true;
            this.fld_btnDelete103.BOSComment = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_btnDelete103.BOSDataMember = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_btnDelete103.BOSDataSource = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_btnDelete103.BOSDescription = null;
            this.fld_btnDelete103.BOSError = null;
            this.fld_btnDelete103.BOSFieldGroup = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_btnDelete103.BOSFieldRelation = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_btnDelete103.BOSPrivilege = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_btnDelete103.BOSPropertyName = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            resources.ApplyResources(this.fld_btnDelete103, "fld_btnDelete103");
            this.fld_btnDelete103.Name = "fld_btnDelete103";
            this.fld_btnDelete103.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_btnDelete103, ((bool)(resources.GetObject("fld_btnDelete103.ShowHelp"))));
            this.fld_btnDelete103.Tag = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_btnDelete103.Click += new System.EventHandler(this.fld_btnDelete103_Click);
            // 
            // fld_txtMEPatientInsRegisteredPlaceNo
            // 
            this.fld_txtMEPatientInsRegisteredPlaceNo.BOSComment = "";
            this.fld_txtMEPatientInsRegisteredPlaceNo.BOSDataMember = "MEPatientInsRegisteredPlaceNo";
            this.fld_txtMEPatientInsRegisteredPlaceNo.BOSDataSource = "MEPatientInss";
            this.fld_txtMEPatientInsRegisteredPlaceNo.BOSDescription = null;
            this.fld_txtMEPatientInsRegisteredPlaceNo.BOSError = null;
            this.fld_txtMEPatientInsRegisteredPlaceNo.BOSFieldGroup = "";
            this.fld_txtMEPatientInsRegisteredPlaceNo.BOSFieldRelation = "";
            this.fld_txtMEPatientInsRegisteredPlaceNo.BOSPrivilege = "";
            this.fld_txtMEPatientInsRegisteredPlaceNo.BOSPropertyName = "Text";
            resources.ApplyResources(this.fld_txtMEPatientInsRegisteredPlaceNo, "fld_txtMEPatientInsRegisteredPlaceNo");
            this.fld_txtMEPatientInsRegisteredPlaceNo.Name = "fld_txtMEPatientInsRegisteredPlaceNo";
            this.fld_txtMEPatientInsRegisteredPlaceNo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEPatientInsRegisteredPlaceNo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEPatientInsRegisteredPlaceNo.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEPatientInsRegisteredPlaceNo.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEPatientInsRegisteredPlaceNo.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("fld_txtMEPatientInsRegisteredPlaceNo.Properties.Mask.UseMaskAsDisplayFormat")));
            this.fld_txtMEPatientInsRegisteredPlaceNo.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_txtMEPatientInsRegisteredPlaceNo, ((bool)(resources.GetObject("fld_txtMEPatientInsRegisteredPlaceNo.ShowHelp"))));
            this.fld_txtMEPatientInsRegisteredPlaceNo.Tag = "DC";
            this.fld_txtMEPatientInsRegisteredPlaceNo.TextChanged += new System.EventHandler(this.fld_txtMEPatientInsRegisteredPlaceNo_TextChanged);
            this.fld_txtMEPatientInsRegisteredPlaceNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fld_txtMEPatientInsRegisteredPlaceNo_KeyUp);
            // 
            // bosLabel3
            // 
            this.bosLabel3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel3.Appearance.Options.UseBackColor = true;
            this.bosLabel3.Appearance.Options.UseForeColor = true;
            this.bosLabel3.BOSComment = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.bosLabel3.BOSDataMember = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.bosLabel3.BOSDataSource = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.bosLabel3.BOSDescription = null;
            this.bosLabel3.BOSError = null;
            this.bosLabel3.BOSFieldGroup = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.bosLabel3.BOSFieldRelation = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.bosLabel3.BOSPrivilege = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.bosLabel3.BOSPropertyName = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            resources.ApplyResources(this.bosLabel3, "bosLabel3");
            this.bosLabel3.Name = "bosLabel3";
            this.bosLabel3.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel3, ((bool)(resources.GetObject("bosLabel3.ShowHelp"))));
            this.bosLabel3.Tag = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            // 
            // bosLabel2
            // 
            this.bosLabel2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel2.Appearance.Options.UseBackColor = true;
            this.bosLabel2.Appearance.Options.UseForeColor = true;
            this.bosLabel2.BOSComment = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.bosLabel2.BOSDataMember = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.bosLabel2.BOSDataSource = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.bosLabel2.BOSDescription = null;
            this.bosLabel2.BOSError = null;
            this.bosLabel2.BOSFieldGroup = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.bosLabel2.BOSFieldRelation = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.bosLabel2.BOSPrivilege = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.bosLabel2.BOSPropertyName = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            resources.ApplyResources(this.bosLabel2, "bosLabel2");
            this.bosLabel2.Name = "bosLabel2";
            this.bosLabel2.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel2, ((bool)(resources.GetObject("bosLabel2.ShowHelp"))));
            this.bosLabel2.Tag = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            // 
            // fld_lkeFK_MECompanyID
            // 
            this.fld_lkeFK_MECompanyID.BOSAllowAddNew = false;
            this.fld_lkeFK_MECompanyID.BOSAllowDummy = false;
            this.fld_lkeFK_MECompanyID.BOSComment = "";
            this.fld_lkeFK_MECompanyID.BOSDataMember = "FK_MECompanyID";
            this.fld_lkeFK_MECompanyID.BOSDataSource = "MEPatientInss";
            this.fld_lkeFK_MECompanyID.BOSDescription = null;
            this.fld_lkeFK_MECompanyID.BOSError = null;
            this.fld_lkeFK_MECompanyID.BOSFieldGroup = "";
            this.fld_lkeFK_MECompanyID.BOSFieldParent = "";
            this.fld_lkeFK_MECompanyID.BOSFieldRelation = "";
            this.fld_lkeFK_MECompanyID.BOSPrivilege = "";
            this.fld_lkeFK_MECompanyID.BOSPropertyName = "EditValue";
            this.fld_lkeFK_MECompanyID.BOSSelectType = "";
            this.fld_lkeFK_MECompanyID.BOSSelectTypeValue = "";
            this.fld_lkeFK_MECompanyID.CurrentDisplayText = null;
            resources.ApplyResources(this.fld_lkeFK_MECompanyID, "fld_lkeFK_MECompanyID");
            this.fld_lkeFK_MECompanyID.Name = "fld_lkeFK_MECompanyID";
            this.fld_lkeFK_MECompanyID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeFK_MECompanyID.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeFK_MECompanyID.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeFK_MECompanyID.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeFK_MECompanyID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("fld_lkeFK_MECompanyID.Properties.Buttons"))))});
            this.fld_lkeFK_MECompanyID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("fld_lkeFK_MECompanyID.Properties.Columns"), resources.GetString("fld_lkeFK_MECompanyID.Properties.Columns1"))});
            this.fld_lkeFK_MECompanyID.Properties.DisplayMember = "MECompanyName";
            this.fld_lkeFK_MECompanyID.Properties.NullText = resources.GetString("fld_lkeFK_MECompanyID.Properties.NullText");
            this.fld_lkeFK_MECompanyID.Properties.PopupWidth = 40;
            this.fld_lkeFK_MECompanyID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeFK_MECompanyID.Properties.ValueMember = "MECompanyID";
            this.fld_lkeFK_MECompanyID.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_lkeFK_MECompanyID, ((bool)(resources.GetObject("fld_lkeFK_MECompanyID.ShowHelp"))));
            this.fld_lkeFK_MECompanyID.Tag = "DC";
            this.fld_lkeFK_MECompanyID.EditValueChanged += new System.EventHandler(this.fld_lkeFK_MECompanyID_EditValueChanged);
            // 
            // fld_txtMEPatientInsNo
            // 
            this.fld_txtMEPatientInsNo.BOSComment = "";
            this.fld_txtMEPatientInsNo.BOSDataMember = "MEPatientInsNo";
            this.fld_txtMEPatientInsNo.BOSDataSource = "MEPatientInss";
            this.fld_txtMEPatientInsNo.BOSDescription = null;
            this.fld_txtMEPatientInsNo.BOSError = null;
            this.fld_txtMEPatientInsNo.BOSFieldGroup = "";
            this.fld_txtMEPatientInsNo.BOSFieldRelation = "";
            this.fld_txtMEPatientInsNo.BOSPrivilege = "";
            this.fld_txtMEPatientInsNo.BOSPropertyName = "Text";
            resources.ApplyResources(this.fld_txtMEPatientInsNo, "fld_txtMEPatientInsNo");
            this.fld_txtMEPatientInsNo.Name = "fld_txtMEPatientInsNo";
            this.fld_txtMEPatientInsNo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEPatientInsNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fld_txtMEPatientInsNo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEPatientInsNo.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEPatientInsNo.Properties.Appearance.Options.UseFont = true;
            this.fld_txtMEPatientInsNo.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEPatientInsNo.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("fld_txtMEPatientInsNo.Properties.Mask.UseMaskAsDisplayFormat")));
            this.fld_txtMEPatientInsNo.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_txtMEPatientInsNo, ((bool)(resources.GetObject("fld_txtMEPatientInsNo.ShowHelp"))));
            this.fld_txtMEPatientInsNo.Tag = "DC";
            // 
            // fld_dteMEPatientInsRegisteredDate
            // 
            this.fld_dteMEPatientInsRegisteredDate.BOSComment = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_dteMEPatientInsRegisteredDate.BOSDataMember = "MEPatientInsRegisteredDate";
            this.fld_dteMEPatientInsRegisteredDate.BOSDataSource = "MEPatientInss";
            this.fld_dteMEPatientInsRegisteredDate.BOSDescription = null;
            this.fld_dteMEPatientInsRegisteredDate.BOSError = null;
            this.fld_dteMEPatientInsRegisteredDate.BOSFieldGroup = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_dteMEPatientInsRegisteredDate.BOSFieldRelation = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_dteMEPatientInsRegisteredDate.BOSPrivilege = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_dteMEPatientInsRegisteredDate.BOSPropertyName = "EditValue";
            resources.ApplyResources(this.fld_dteMEPatientInsRegisteredDate, "fld_dteMEPatientInsRegisteredDate");
            this.fld_dteMEPatientInsRegisteredDate.Name = "fld_dteMEPatientInsRegisteredDate";
            this.fld_dteMEPatientInsRegisteredDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteMEPatientInsRegisteredDate.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteMEPatientInsRegisteredDate.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteMEPatientInsRegisteredDate.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteMEPatientInsRegisteredDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("fld_dteMEPatientInsRegisteredDate.Properties.Buttons"))))});
            this.fld_dteMEPatientInsRegisteredDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.fld_dteMEPatientInsRegisteredDate.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_dteMEPatientInsRegisteredDate, ((bool)(resources.GetObject("fld_dteMEPatientInsRegisteredDate.ShowHelp"))));
            this.fld_dteMEPatientInsRegisteredDate.Tag = "DC";
            this.fld_dteMEPatientInsRegisteredDate.InvalidValue += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.fld_dteMEPatientInsRegisteredDate_InvalidValue);
            this.fld_dteMEPatientInsRegisteredDate.Validating += new System.ComponentModel.CancelEventHandler(this.fld_dteMEPatientInsRegisteredDate_Validating);
            // 
            // fld_dteMEPatientInsExpiryDate
            // 
            this.fld_dteMEPatientInsExpiryDate.BOSComment = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_dteMEPatientInsExpiryDate.BOSDataMember = "MEPatientInsExpiryDate";
            this.fld_dteMEPatientInsExpiryDate.BOSDataSource = "MEPatientInss";
            this.fld_dteMEPatientInsExpiryDate.BOSDescription = null;
            this.fld_dteMEPatientInsExpiryDate.BOSError = null;
            this.fld_dteMEPatientInsExpiryDate.BOSFieldGroup = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_dteMEPatientInsExpiryDate.BOSFieldRelation = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_dteMEPatientInsExpiryDate.BOSPrivilege = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_dteMEPatientInsExpiryDate.BOSPropertyName = "EditValue";
            resources.ApplyResources(this.fld_dteMEPatientInsExpiryDate, "fld_dteMEPatientInsExpiryDate");
            this.fld_dteMEPatientInsExpiryDate.Name = "fld_dteMEPatientInsExpiryDate";
            this.fld_dteMEPatientInsExpiryDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteMEPatientInsExpiryDate.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteMEPatientInsExpiryDate.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteMEPatientInsExpiryDate.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteMEPatientInsExpiryDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("fld_dteMEPatientInsExpiryDate.Properties.Buttons"))))});
            this.fld_dteMEPatientInsExpiryDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.fld_dteMEPatientInsExpiryDate.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_dteMEPatientInsExpiryDate, ((bool)(resources.GetObject("fld_dteMEPatientInsExpiryDate.ShowHelp"))));
            this.fld_dteMEPatientInsExpiryDate.Tag = "DC";
            this.fld_dteMEPatientInsExpiryDate.InvalidValue += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.fld_dteMEPatientInsExpiryDate_InvalidValue);
            this.fld_dteMEPatientInsExpiryDate.Validating += new System.ComponentModel.CancelEventHandler(this.fld_dteMEPatientInsExpiryDate_Validating);
            // 
            // fld_txtMEPatientInsRegisteredPlace
            // 
            this.fld_txtMEPatientInsRegisteredPlace.BOSComment = "";
            this.fld_txtMEPatientInsRegisteredPlace.BOSDataMember = "MEPatientInsRegisteredPlace";
            this.fld_txtMEPatientInsRegisteredPlace.BOSDataSource = "MEPatientInss";
            this.fld_txtMEPatientInsRegisteredPlace.BOSDescription = null;
            this.fld_txtMEPatientInsRegisteredPlace.BOSError = null;
            this.fld_txtMEPatientInsRegisteredPlace.BOSFieldGroup = "";
            this.fld_txtMEPatientInsRegisteredPlace.BOSFieldRelation = "";
            this.fld_txtMEPatientInsRegisteredPlace.BOSPrivilege = "";
            this.fld_txtMEPatientInsRegisteredPlace.BOSPropertyName = "Text";
            resources.ApplyResources(this.fld_txtMEPatientInsRegisteredPlace, "fld_txtMEPatientInsRegisteredPlace");
            this.fld_txtMEPatientInsRegisteredPlace.Name = "fld_txtMEPatientInsRegisteredPlace";
            this.fld_txtMEPatientInsRegisteredPlace.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEPatientInsRegisteredPlace.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEPatientInsRegisteredPlace.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEPatientInsRegisteredPlace.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEPatientInsRegisteredPlace.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("fld_txtMEPatientInsRegisteredPlace.Properties.Mask.UseMaskAsDisplayFormat")));
            this.fld_txtMEPatientInsRegisteredPlace.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_txtMEPatientInsRegisteredPlace, ((bool)(resources.GetObject("fld_txtMEPatientInsRegisteredPlace.ShowHelp"))));
            this.fld_txtMEPatientInsRegisteredPlace.Tag = "DC";
            // 
            // fld_lblLabel43
            // 
            this.fld_lblLabel43.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel43.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.fld_lblLabel43.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel43.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel43.Appearance.Options.UseFont = true;
            this.fld_lblLabel43.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel43.BOSComment = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel43.BOSDataMember = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel43.BOSDataSource = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel43.BOSDescription = null;
            this.fld_lblLabel43.BOSError = null;
            this.fld_lblLabel43.BOSFieldGroup = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel43.BOSFieldRelation = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel43.BOSPrivilege = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel43.BOSPropertyName = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            resources.ApplyResources(this.fld_lblLabel43, "fld_lblLabel43");
            this.fld_lblLabel43.Name = "fld_lblLabel43";
            this.fld_lblLabel43.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_lblLabel43, ((bool)(resources.GetObject("fld_lblLabel43.ShowHelp"))));
            this.fld_lblLabel43.Tag = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            // 
            // fld_lblLabel45
            // 
            this.fld_lblLabel45.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel45.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel45.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel45.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel45.BOSComment = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel45.BOSDataMember = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel45.BOSDataSource = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel45.BOSDescription = null;
            this.fld_lblLabel45.BOSError = null;
            this.fld_lblLabel45.BOSFieldGroup = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel45.BOSFieldRelation = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel45.BOSPrivilege = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel45.BOSPropertyName = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            resources.ApplyResources(this.fld_lblLabel45, "fld_lblLabel45");
            this.fld_lblLabel45.Name = "fld_lblLabel45";
            this.fld_lblLabel45.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_lblLabel45, ((bool)(resources.GetObject("fld_lblLabel45.ShowHelp"))));
            this.fld_lblLabel45.Tag = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            // 
            // fld_lblLabel46
            // 
            this.fld_lblLabel46.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel46.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel46.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel46.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel46.BOSComment = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel46.BOSDataMember = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel46.BOSDataSource = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel46.BOSDescription = null;
            this.fld_lblLabel46.BOSError = null;
            this.fld_lblLabel46.BOSFieldGroup = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel46.BOSFieldRelation = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel46.BOSPrivilege = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel46.BOSPropertyName = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            resources.ApplyResources(this.fld_lblLabel46, "fld_lblLabel46");
            this.fld_lblLabel46.Name = "fld_lblLabel46";
            this.fld_lblLabel46.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_lblLabel46, ((bool)(resources.GetObject("fld_lblLabel46.ShowHelp"))));
            this.fld_lblLabel46.Tag = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            // 
            // fld_lblLabel47
            // 
            this.fld_lblLabel47.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel47.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel47.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel47.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel47.BOSComment = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel47.BOSDataMember = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel47.BOSDataSource = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel47.BOSDescription = null;
            this.fld_lblLabel47.BOSError = null;
            this.fld_lblLabel47.BOSFieldGroup = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel47.BOSFieldRelation = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel47.BOSPrivilege = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel47.BOSPropertyName = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            resources.ApplyResources(this.fld_lblLabel47, "fld_lblLabel47");
            this.fld_lblLabel47.Name = "fld_lblLabel47";
            this.fld_lblLabel47.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_lblLabel47, ((bool)(resources.GetObject("fld_lblLabel47.ShowHelp"))));
            this.fld_lblLabel47.Tag = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            // 
            // fld_lblLabel48
            // 
            this.fld_lblLabel48.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel48.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel48.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel48.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel48.BOSComment = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel48.BOSDataMember = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel48.BOSDataSource = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel48.BOSDescription = null;
            this.fld_lblLabel48.BOSError = null;
            this.fld_lblLabel48.BOSFieldGroup = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel48.BOSFieldRelation = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel48.BOSPrivilege = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_lblLabel48.BOSPropertyName = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            resources.ApplyResources(this.fld_lblLabel48, "fld_lblLabel48");
            this.fld_lblLabel48.Name = "fld_lblLabel48";
            this.fld_lblLabel48.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_lblLabel48, ((bool)(resources.GetObject("fld_lblLabel48.ShowHelp"))));
            this.fld_lblLabel48.Tag = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            // 
            // fld_grcGroupControl8
            // 
            resources.ApplyResources(this.fld_grcGroupControl8, "fld_grcGroupControl8");
            this.fld_grcGroupControl8.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.fld_grcGroupControl8.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_grcGroupControl8.Appearance.Options.UseBackColor = true;
            this.fld_grcGroupControl8.Appearance.Options.UseForeColor = true;
            this.fld_grcGroupControl8.BOSComment = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_grcGroupControl8.BOSDataMember = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_grcGroupControl8.BOSDataSource = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_grcGroupControl8.BOSDescription = null;
            this.fld_grcGroupControl8.BOSError = null;
            this.fld_grcGroupControl8.BOSFieldGroup = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_grcGroupControl8.BOSFieldRelation = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_grcGroupControl8.BOSPrivilege = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_grcGroupControl8.BOSPropertyName = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_grcGroupControl8.Controls.Add(this.fld_dgcMEPatientInss);
            this.fld_grcGroupControl8.Name = "fld_grcGroupControl8";
            this.fld_grcGroupControl8.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_grcGroupControl8, ((bool)(resources.GetObject("fld_grcGroupControl8.ShowHelp"))));
            this.fld_grcGroupControl8.Tag = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            // 
            // fld_dgcMEPatientInss
            // 
            this.fld_dgcMEPatientInss.AllowDrop = true;
            this.fld_dgcMEPatientInss.BOSComment = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_dgcMEPatientInss.BOSDataMember = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_dgcMEPatientInss.BOSDataSource = "MEPatientInss";
            this.fld_dgcMEPatientInss.BOSDescription = null;
            this.fld_dgcMEPatientInss.BOSError = null;
            this.fld_dgcMEPatientInss.BOSFieldGroup = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_dgcMEPatientInss.BOSFieldRelation = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_dgcMEPatientInss.BOSGridType = null;
            this.fld_dgcMEPatientInss.BOSPrivilege = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            this.fld_dgcMEPatientInss.BOSPropertyName = "Ngày ??ng ký không ???c l?n h?n ngày h?t h?n";
            resources.ApplyResources(this.fld_dgcMEPatientInss, "fld_dgcMEPatientInss");
            this.fld_dgcMEPatientInss.MainView = this.fld_dgvMEPatientInss;
            this.fld_dgcMEPatientInss.Name = "fld_dgcMEPatientInss";
            this.fld_dgcMEPatientInss.PrintReport = false;
            this.fld_dgcMEPatientInss.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_dgcMEPatientInss, ((bool)(resources.GetObject("fld_dgcMEPatientInss.ShowHelp"))));
            this.fld_dgcMEPatientInss.TabStop = false;
            this.fld_dgcMEPatientInss.Tag = "DC";
            this.fld_dgcMEPatientInss.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvMEPatientInss});
            // 
            // fld_dgvMEPatientInss
            // 
            this.fld_dgvMEPatientInss.GridControl = this.fld_dgcMEPatientInss;
            this.fld_dgvMEPatientInss.Name = "fld_dgvMEPatientInss";
            this.fld_dgvMEPatientInss.PaintStyleName = "Office2003";
            // 
            // bosPanel1
            // 
            this.bosPanel1.BOSComment = null;
            this.bosPanel1.BOSDataMember = null;
            this.bosPanel1.BOSDataSource = null;
            this.bosPanel1.BOSDescription = null;
            this.bosPanel1.BOSError = null;
            this.bosPanel1.BOSFieldGroup = null;
            this.bosPanel1.BOSFieldRelation = null;
            this.bosPanel1.BOSPrivilege = null;
            this.bosPanel1.BOSPropertyName = null;
            this.bosPanel1.Controls.Add(this.fld_grcGroupControl8);
            this.bosPanel1.Controls.Add(this.fld_grcGroupControl7);
            resources.ApplyResources(this.bosPanel1, "bosPanel1");
            this.bosPanel1.Name = "bosPanel1";
            this.bosPanel1.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosPanel1, ((bool)(resources.GetObject("bosPanel1.ShowHelp"))));
            // 
            // DMMEPA103
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.bosPanel1);
            this.Name = "DMMEPA103";
            this.ScreenHelper.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            this.Tag = "DM";
            this.Controls.SetChildIndex(this.bosPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_grcGroupControl7)).EndInit();
            this.fld_grcGroupControl7.ResumeLayout(false);
            this.fld_grcGroupControl7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkMEPatientInsEnough5Year.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkMEPatientInsIsK1K2K3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEPatientInsPlaceLevelType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEPatientInsRegisteredPlaceNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_MECompanyID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEPatientInsNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteMEPatientInsRegisteredDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteMEPatientInsRegisteredDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteMEPatientInsExpiryDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteMEPatientInsExpiryDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEPatientInsRegisteredPlace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_grcGroupControl8)).EndInit();
            this.fld_grcGroupControl8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEPatientInss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEPatientInss)).EndInit();
            this.bosPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        private IContainer components;
        private BOSComponent.BOSLookupEdit fld_lkeFK_MECompanyID;
        private BOSComponent.BOSPanel bosPanel1;
        private BOSComponent.BOSTextBox fld_txtMEPatientInsRegisteredPlaceNo;
        private BOSComponent.BOSLabel bosLabel2;
        private BOSComponent.BOSLabel bosLabel3;
        private BOSComponent.BOSLookupEdit fld_lkeMEPatientInsPlaceLevelType;
        private BOSComponent.BOSCheckEdit fld_chkMEPatientInsIsK1K2K3;
        private BOSComponent.BOSCheckEdit fld_chkMEPatientInsEnough5Year;
	}
}
