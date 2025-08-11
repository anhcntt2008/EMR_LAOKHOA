using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.MEParamReports.UI
{
    /// <summary>
    /// Summary description for DMMPR100
    /// </summary>
    partial class DMMPR100
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMMPR100));
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_grcGroupControl2 = new BOSComponent.BOSGroupControl(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fld_txtMEParamReportMapFilter = new BOSComponent.BOSTextBox(this.components);
            this.bosLabel20 = new BOSComponent.BOSLabel(this.components);
            this.fld_lkeMEParamReportRelationEncode = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel19 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel12 = new BOSComponent.BOSLabel(this.components);
            this.fld_lkeMEParamReportMap3 = new BOSComponent.BOSLookupEdit(this.components);
            this.fld_lkeFK_METemplateIDRelation3 = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel5 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel6 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel4 = new BOSComponent.BOSLabel(this.components);
            this.fld_lkeMEParamReportMap2 = new BOSComponent.BOSLookupEdit(this.components);
            this.fld_lkeFK_METemplateIDRelation2 = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel1 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel3 = new BOSComponent.BOSLabel(this.components);
            this.fld_lkeFK_MEEmrTypeIDRelation = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel14 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel11 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtMEParamReportRelationXMLOrder = new BOSComponent.BOSTextBox(this.components);
            this.bosLabel10 = new BOSComponent.BOSLabel(this.components);
            this.fld_lkeMEParamReportMap = new BOSComponent.BOSLookupEdit(this.components);
            this.fld_lkeFK_METemplateIDRelation = new BOSComponent.BOSLookupEdit(this.components);
            this.fld_chkMEParamReportRelationXML = new BOSComponent.BOSCheckEdit(this.components);
            this.bosLabel8 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel9 = new BOSComponent.BOSLabel(this.components);
            this.fld_btnRemoveRelation = new DevExpress.XtraEditors.SimpleButton();
            this.fld_dgcMEParamReportRelations = new BOSERP.Modules.MEParamReports.MEParamReportRelationsGridControl();
            this.fld_dgvMEParamReportRelations = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_btnUpdateRelation = new DevExpress.XtraEditors.SimpleButton();
            this.bosPanel1 = new BOSComponent.BOSPanel(this.components);
            this.fld_lkeMEParamFormatType = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel18 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtMEParamMaxLength = new BOSComponent.BOSTextBox(this.components);
            this.bosLabel17 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtMEParamFormatString = new BOSComponent.BOSTextBox(this.components);
            this.bosLabel13 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtMEParamXMLTag = new BOSComponent.BOSTextBox(this.components);
            this.bosLabel16 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtMEParamCaption = new BOSComponent.BOSTextBox(this.components);
            this.bosLabel15 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtMEParamName = new BOSComponent.BOSTextBox(this.components);
            this.bosLabel2 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtMEParamNo = new BOSComponent.BOSTextBox(this.components);
            this.bosLabel7 = new BOSComponent.BOSLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_grcGroupControl2)).BeginInit();
            this.fld_grcGroupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamReportMapFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEParamReportRelationEncode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEParamReportMap3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_METemplateIDRelation3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEParamReportMap2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_METemplateIDRelation2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_MEEmrTypeIDRelation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamReportRelationXMLOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEParamReportMap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_METemplateIDRelation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkMEParamReportRelationXML.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEParamReportRelations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEParamReportRelations)).BeginInit();
            this.bosPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEParamFormatType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamMaxLength.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamFormatString.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamXMLTag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamCaption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.Name = "gridView2";
            this.gridView2.PaintStyleName = "Office2003";
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // fld_grcGroupControl2
            // 
            this.fld_grcGroupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_grcGroupControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.fld_grcGroupControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.fld_grcGroupControl2.Appearance.Options.UseBackColor = true;
            this.fld_grcGroupControl2.Appearance.Options.UseForeColor = true;
            this.fld_grcGroupControl2.BOSComment = null;
            this.fld_grcGroupControl2.BOSDataMember = null;
            this.fld_grcGroupControl2.BOSDataSource = null;
            this.fld_grcGroupControl2.BOSDescription = null;
            this.fld_grcGroupControl2.BOSError = null;
            this.fld_grcGroupControl2.BOSFieldGroup = null;
            this.fld_grcGroupControl2.BOSFieldRelation = null;
            this.fld_grcGroupControl2.BOSPrivilege = null;
            this.fld_grcGroupControl2.BOSPropertyName = null;
            this.fld_grcGroupControl2.Controls.Add(this.splitContainer1);
            this.fld_grcGroupControl2.Location = new System.Drawing.Point(3, 97);
            this.fld_grcGroupControl2.Name = "fld_grcGroupControl2";
            this.fld_grcGroupControl2.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_grcGroupControl2, true);
            this.fld_grcGroupControl2.Size = new System.Drawing.Size(1333, 519);
            this.fld_grcGroupControl2.TabIndex = 131;
            this.fld_grcGroupControl2.Text = "Cấu hình";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 30);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fld_txtMEParamReportMapFilter);
            this.splitContainer1.Panel1.Controls.Add(this.bosLabel20);
            this.splitContainer1.Panel1.Controls.Add(this.fld_lkeMEParamReportRelationEncode);
            this.splitContainer1.Panel1.Controls.Add(this.bosLabel19);
            this.splitContainer1.Panel1.Controls.Add(this.bosLabel12);
            this.splitContainer1.Panel1.Controls.Add(this.fld_lkeMEParamReportMap3);
            this.splitContainer1.Panel1.Controls.Add(this.fld_lkeFK_METemplateIDRelation3);
            this.splitContainer1.Panel1.Controls.Add(this.bosLabel5);
            this.splitContainer1.Panel1.Controls.Add(this.bosLabel6);
            this.splitContainer1.Panel1.Controls.Add(this.bosLabel4);
            this.splitContainer1.Panel1.Controls.Add(this.fld_lkeMEParamReportMap2);
            this.splitContainer1.Panel1.Controls.Add(this.fld_lkeFK_METemplateIDRelation2);
            this.splitContainer1.Panel1.Controls.Add(this.bosLabel1);
            this.splitContainer1.Panel1.Controls.Add(this.bosLabel3);
            this.splitContainer1.Panel1.Controls.Add(this.fld_lkeFK_MEEmrTypeIDRelation);
            this.splitContainer1.Panel1.Controls.Add(this.bosLabel14);
            this.splitContainer1.Panel1.Controls.Add(this.bosLabel11);
            this.splitContainer1.Panel1.Controls.Add(this.fld_txtMEParamReportRelationXMLOrder);
            this.splitContainer1.Panel1.Controls.Add(this.bosLabel10);
            this.splitContainer1.Panel1.Controls.Add(this.fld_lkeMEParamReportMap);
            this.splitContainer1.Panel1.Controls.Add(this.fld_lkeFK_METemplateIDRelation);
            this.splitContainer1.Panel1.Controls.Add(this.fld_chkMEParamReportRelationXML);
            this.splitContainer1.Panel1.Controls.Add(this.bosLabel8);
            this.splitContainer1.Panel1.Controls.Add(this.bosLabel9);
            this.ScreenHelper.SetShowHelp(this.splitContainer1.Panel1, true);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.fld_btnRemoveRelation);
            this.splitContainer1.Panel2.Controls.Add(this.fld_dgcMEParamReportRelations);
            this.splitContainer1.Panel2.Controls.Add(this.fld_btnUpdateRelation);
            this.ScreenHelper.SetShowHelp(this.splitContainer1.Panel2, true);
            this.ScreenHelper.SetShowHelp(this.splitContainer1, true);
            this.splitContainer1.Size = new System.Drawing.Size(1327, 486);
            this.splitContainer1.SplitterDistance = 520;
            this.splitContainer1.TabIndex = 77;
            // 
            // fld_txtMEParamReportMapFilter
            // 
            this.fld_txtMEParamReportMapFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_txtMEParamReportMapFilter.BOSComment = null;
            this.fld_txtMEParamReportMapFilter.BOSDataMember = "MEParamReportMapFilter";
            this.fld_txtMEParamReportMapFilter.BOSDataSource = "";
            this.fld_txtMEParamReportMapFilter.BOSDescription = null;
            this.fld_txtMEParamReportMapFilter.BOSError = null;
            this.fld_txtMEParamReportMapFilter.BOSFieldGroup = null;
            this.fld_txtMEParamReportMapFilter.BOSFieldRelation = null;
            this.fld_txtMEParamReportMapFilter.BOSPrivilege = null;
            this.fld_txtMEParamReportMapFilter.BOSPropertyName = "Text";
            this.fld_txtMEParamReportMapFilter.Enabled = false;
            this.fld_txtMEParamReportMapFilter.Location = new System.Drawing.Point(102, 115);
            this.fld_txtMEParamReportMapFilter.Name = "fld_txtMEParamReportMapFilter";
            this.fld_txtMEParamReportMapFilter.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_txtMEParamReportMapFilter, true);
            this.fld_txtMEParamReportMapFilter.Size = new System.Drawing.Size(410, 26);
            this.fld_txtMEParamReportMapFilter.TabIndex = 175;
            this.fld_txtMEParamReportMapFilter.Tag = "DC";
            // 
            // bosLabel20
            // 
            this.bosLabel20.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel20.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel20.Appearance.Options.UseBackColor = true;
            this.bosLabel20.Appearance.Options.UseForeColor = true;
            this.bosLabel20.BOSComment = null;
            this.bosLabel20.BOSDataMember = null;
            this.bosLabel20.BOSDataSource = null;
            this.bosLabel20.BOSDescription = null;
            this.bosLabel20.BOSError = null;
            this.bosLabel20.BOSFieldGroup = null;
            this.bosLabel20.BOSFieldRelation = null;
            this.bosLabel20.BOSPrivilege = null;
            this.bosLabel20.BOSPropertyName = null;
            this.bosLabel20.Location = new System.Drawing.Point(7, 118);
            this.bosLabel20.Name = "bosLabel20";
            this.bosLabel20.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel20, true);
            this.bosLabel20.Size = new System.Drawing.Size(51, 19);
            this.bosLabel20.TabIndex = 176;
            this.bosLabel20.Text = "Lọc thẻ";
            // 
            // fld_lkeMEParamReportRelationEncode
            // 
            this.fld_lkeMEParamReportRelationEncode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_lkeMEParamReportRelationEncode.BOSAllowAddNew = false;
            this.fld_lkeMEParamReportRelationEncode.BOSAllowDummy = false;
            this.fld_lkeMEParamReportRelationEncode.BOSAllowMange = false;
            this.fld_lkeMEParamReportRelationEncode.BOSComment = null;
            this.fld_lkeMEParamReportRelationEncode.BOSDataMember = "MEParamReportRelationEncode";
            this.fld_lkeMEParamReportRelationEncode.BOSDataSource = "";
            this.fld_lkeMEParamReportRelationEncode.BOSDescription = null;
            this.fld_lkeMEParamReportRelationEncode.BOSDummyText = null;
            this.fld_lkeMEParamReportRelationEncode.BOSError = null;
            this.fld_lkeMEParamReportRelationEncode.BOSFieldGroup = null;
            this.fld_lkeMEParamReportRelationEncode.BOSFieldParent = null;
            this.fld_lkeMEParamReportRelationEncode.BOSFieldRelation = null;
            this.fld_lkeMEParamReportRelationEncode.BOSPrivilege = null;
            this.fld_lkeMEParamReportRelationEncode.BOSPropertyName = "EditValue";
            this.fld_lkeMEParamReportRelationEncode.BOSSelectType = null;
            this.fld_lkeMEParamReportRelationEncode.BOSSelectTypeValue = null;
            this.fld_lkeMEParamReportRelationEncode.CurrentDisplayText = null;
            this.fld_lkeMEParamReportRelationEncode.Enabled = false;
            this.fld_lkeMEParamReportRelationEncode.Location = new System.Drawing.Point(102, 89);
            this.fld_lkeMEParamReportRelationEncode.MenuManager = this.screenToolbar;
            this.fld_lkeMEParamReportRelationEncode.Name = "fld_lkeMEParamReportRelationEncode";
            this.fld_lkeMEParamReportRelationEncode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeMEParamReportRelationEncode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MEParamLookupNo", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MEParamLookupName", "Tên")});
            this.fld_lkeMEParamReportRelationEncode.Properties.DisplayMember = "MEParamLookupNo";
            this.fld_lkeMEParamReportRelationEncode.Properties.NullText = "";
            this.fld_lkeMEParamReportRelationEncode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeMEParamReportRelationEncode.Properties.ValueMember = "MEParamLookupNo";
            this.fld_lkeMEParamReportRelationEncode.Screen = null;
            this.fld_lkeMEParamReportRelationEncode.Size = new System.Drawing.Size(410, 26);
            this.fld_lkeMEParamReportRelationEncode.TabIndex = 184;
            this.fld_lkeMEParamReportRelationEncode.Tag = "DC";
            // 
            // bosLabel19
            // 
            this.bosLabel19.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel19.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel19.Appearance.Options.UseBackColor = true;
            this.bosLabel19.Appearance.Options.UseForeColor = true;
            this.bosLabel19.BOSComment = "";
            this.bosLabel19.BOSDataMember = "";
            this.bosLabel19.BOSDataSource = "";
            this.bosLabel19.BOSDescription = null;
            this.bosLabel19.BOSError = null;
            this.bosLabel19.BOSFieldGroup = "";
            this.bosLabel19.BOSFieldRelation = "";
            this.bosLabel19.BOSPrivilege = "";
            this.bosLabel19.BOSPropertyName = "";
            this.bosLabel19.Location = new System.Drawing.Point(5, 90);
            this.bosLabel19.Name = "bosLabel19";
            this.bosLabel19.Screen = null;
            this.bosLabel19.Size = new System.Drawing.Size(51, 19);
            this.bosLabel19.TabIndex = 185;
            this.bosLabel19.Tag = "";
            this.bosLabel19.Text = "Mã hóa";
            // 
            // bosLabel12
            // 
            this.bosLabel12.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel12.Appearance.Font = new System.Drawing.Font("Tahoma", 6F);
            this.bosLabel12.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel12.Appearance.Options.UseBackColor = true;
            this.bosLabel12.Appearance.Options.UseFont = true;
            this.bosLabel12.Appearance.Options.UseForeColor = true;
            this.bosLabel12.BOSComment = null;
            this.bosLabel12.BOSDataMember = null;
            this.bosLabel12.BOSDataSource = null;
            this.bosLabel12.BOSDescription = null;
            this.bosLabel12.BOSError = null;
            this.bosLabel12.BOSFieldGroup = null;
            this.bosLabel12.BOSFieldRelation = null;
            this.bosLabel12.BOSPrivilege = null;
            this.bosLabel12.BOSPropertyName = null;
            this.bosLabel12.Location = new System.Drawing.Point(228, 149);
            this.bosLabel12.Name = "bosLabel12";
            this.bosLabel12.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel12, true);
            this.bosLabel12.Size = new System.Drawing.Size(140, 14);
            this.bosLabel12.TabIndex = 183;
            this.bosLabel12.Text = "* Mặc định nếu để trống.";
            // 
            // fld_lkeMEParamReportMap3
            // 
            this.fld_lkeMEParamReportMap3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_lkeMEParamReportMap3.BOSAllowAddNew = false;
            this.fld_lkeMEParamReportMap3.BOSAllowDummy = false;
            this.fld_lkeMEParamReportMap3.BOSAllowMange = false;
            this.fld_lkeMEParamReportMap3.BOSComment = null;
            this.fld_lkeMEParamReportMap3.BOSDataMember = "MEParamReportRelationEncode3";
            this.fld_lkeMEParamReportMap3.BOSDataSource = "";
            this.fld_lkeMEParamReportMap3.BOSDescription = null;
            this.fld_lkeMEParamReportMap3.BOSDummyText = null;
            this.fld_lkeMEParamReportMap3.BOSError = null;
            this.fld_lkeMEParamReportMap3.BOSFieldGroup = null;
            this.fld_lkeMEParamReportMap3.BOSFieldParent = null;
            this.fld_lkeMEParamReportMap3.BOSFieldRelation = null;
            this.fld_lkeMEParamReportMap3.BOSPrivilege = null;
            this.fld_lkeMEParamReportMap3.BOSPropertyName = "EditValue";
            this.fld_lkeMEParamReportMap3.BOSSelectType = null;
            this.fld_lkeMEParamReportMap3.BOSSelectTypeValue = null;
            this.fld_lkeMEParamReportMap3.CurrentDisplayText = null;
            this.fld_lkeMEParamReportMap3.Enabled = false;
            this.fld_lkeMEParamReportMap3.Location = new System.Drawing.Point(116, 286);
            this.fld_lkeMEParamReportMap3.MenuManager = this.screenToolbar;
            this.fld_lkeMEParamReportMap3.Name = "fld_lkeMEParamReportMap3";
            this.fld_lkeMEParamReportMap3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeMEParamReportMap3.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MEParamNo", "Mã thẻ"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MEParamName", "Tên thẻ")});
            this.fld_lkeMEParamReportMap3.Properties.DisplayMember = "MEParamNo";
            this.fld_lkeMEParamReportMap3.Properties.NullText = "";
            this.fld_lkeMEParamReportMap3.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeMEParamReportMap3.Properties.ValueMember = "MEParamNo";
            this.fld_lkeMEParamReportMap3.Screen = null;
            this.fld_lkeMEParamReportMap3.Size = new System.Drawing.Size(396, 26);
            this.fld_lkeMEParamReportMap3.TabIndex = 181;
            this.fld_lkeMEParamReportMap3.Tag = "DC";
            // 
            // fld_lkeFK_METemplateIDRelation3
            // 
            this.fld_lkeFK_METemplateIDRelation3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_lkeFK_METemplateIDRelation3.BOSAllowAddNew = false;
            this.fld_lkeFK_METemplateIDRelation3.BOSAllowDummy = false;
            this.fld_lkeFK_METemplateIDRelation3.BOSAllowMange = false;
            this.fld_lkeFK_METemplateIDRelation3.BOSComment = null;
            this.fld_lkeFK_METemplateIDRelation3.BOSDataMember = "FK_METemplateID3";
            this.fld_lkeFK_METemplateIDRelation3.BOSDataSource = "";
            this.fld_lkeFK_METemplateIDRelation3.BOSDescription = null;
            this.fld_lkeFK_METemplateIDRelation3.BOSDummyText = null;
            this.fld_lkeFK_METemplateIDRelation3.BOSError = null;
            this.fld_lkeFK_METemplateIDRelation3.BOSFieldGroup = null;
            this.fld_lkeFK_METemplateIDRelation3.BOSFieldParent = null;
            this.fld_lkeFK_METemplateIDRelation3.BOSFieldRelation = null;
            this.fld_lkeFK_METemplateIDRelation3.BOSPrivilege = null;
            this.fld_lkeFK_METemplateIDRelation3.BOSPropertyName = "EditValue";
            this.fld_lkeFK_METemplateIDRelation3.BOSSelectType = null;
            this.fld_lkeFK_METemplateIDRelation3.BOSSelectTypeValue = null;
            this.fld_lkeFK_METemplateIDRelation3.CurrentDisplayText = null;
            this.fld_lkeFK_METemplateIDRelation3.Location = new System.Drawing.Point(116, 259);
            this.fld_lkeFK_METemplateIDRelation3.MenuManager = this.screenToolbar;
            this.fld_lkeFK_METemplateIDRelation3.Name = "fld_lkeFK_METemplateIDRelation3";
            this.fld_lkeFK_METemplateIDRelation3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_METemplateIDRelation3.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("METemplateNo", "Mã mẫu"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("METemplateName", "Tên mẫu")});
            this.fld_lkeFK_METemplateIDRelation3.Properties.DisplayMember = "METemplateNo";
            this.fld_lkeFK_METemplateIDRelation3.Properties.NullText = "";
            this.fld_lkeFK_METemplateIDRelation3.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeFK_METemplateIDRelation3.Properties.ValueMember = "METemplateID";
            this.fld_lkeFK_METemplateIDRelation3.Screen = null;
            this.fld_lkeFK_METemplateIDRelation3.Size = new System.Drawing.Size(396, 26);
            this.fld_lkeFK_METemplateIDRelation3.TabIndex = 179;
            this.fld_lkeFK_METemplateIDRelation3.Tag = "DC";
            this.fld_lkeFK_METemplateIDRelation3.EditValueChanged += new System.EventHandler(this.fld_lkeFK_METemplateIDRelation3_EditValueChanged);
            // 
            // bosLabel5
            // 
            this.bosLabel5.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.bosLabel5.Location = new System.Drawing.Point(5, 288);
            this.bosLabel5.Name = "bosLabel5";
            this.bosLabel5.Screen = null;
            this.bosLabel5.Size = new System.Drawing.Size(95, 19);
            this.bosLabel5.TabIndex = 182;
            this.bosLabel5.Tag = "";
            this.bosLabel5.Text = "Thẻ dữ liệu 3";
            // 
            // bosLabel6
            // 
            this.bosLabel6.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.bosLabel6.Location = new System.Drawing.Point(5, 262);
            this.bosLabel6.Name = "bosLabel6";
            this.bosLabel6.Screen = null;
            this.bosLabel6.Size = new System.Drawing.Size(105, 19);
            this.bosLabel6.TabIndex = 180;
            this.bosLabel6.Tag = "";
            this.bosLabel6.Text = "Mẫu bệnh án 3";
            // 
            // bosLabel4
            // 
            this.bosLabel4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.bosLabel4.Location = new System.Drawing.Point(5, 178);
            this.bosLabel4.Name = "bosLabel4";
            this.bosLabel4.Screen = null;
            this.bosLabel4.Size = new System.Drawing.Size(93, 19);
            this.bosLabel4.TabIndex = 178;
            this.bosLabel4.Tag = "";
            this.bosLabel4.Text = "Thêm giá trị:";
            // 
            // fld_lkeMEParamReportMap2
            // 
            this.fld_lkeMEParamReportMap2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_lkeMEParamReportMap2.BOSAllowAddNew = false;
            this.fld_lkeMEParamReportMap2.BOSAllowDummy = false;
            this.fld_lkeMEParamReportMap2.BOSAllowMange = false;
            this.fld_lkeMEParamReportMap2.BOSComment = null;
            this.fld_lkeMEParamReportMap2.BOSDataMember = "MEParamReportMap2";
            this.fld_lkeMEParamReportMap2.BOSDataSource = "";
            this.fld_lkeMEParamReportMap2.BOSDescription = null;
            this.fld_lkeMEParamReportMap2.BOSDummyText = null;
            this.fld_lkeMEParamReportMap2.BOSError = null;
            this.fld_lkeMEParamReportMap2.BOSFieldGroup = null;
            this.fld_lkeMEParamReportMap2.BOSFieldParent = null;
            this.fld_lkeMEParamReportMap2.BOSFieldRelation = null;
            this.fld_lkeMEParamReportMap2.BOSPrivilege = null;
            this.fld_lkeMEParamReportMap2.BOSPropertyName = "EditValue";
            this.fld_lkeMEParamReportMap2.BOSSelectType = null;
            this.fld_lkeMEParamReportMap2.BOSSelectTypeValue = null;
            this.fld_lkeMEParamReportMap2.CurrentDisplayText = null;
            this.fld_lkeMEParamReportMap2.Enabled = false;
            this.fld_lkeMEParamReportMap2.Location = new System.Drawing.Point(116, 227);
            this.fld_lkeMEParamReportMap2.MenuManager = this.screenToolbar;
            this.fld_lkeMEParamReportMap2.Name = "fld_lkeMEParamReportMap2";
            this.fld_lkeMEParamReportMap2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeMEParamReportMap2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MEParamNo", "Mã thẻ"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MEParamName", "Tên thẻ")});
            this.fld_lkeMEParamReportMap2.Properties.DisplayMember = "MEParamNo";
            this.fld_lkeMEParamReportMap2.Properties.NullText = "";
            this.fld_lkeMEParamReportMap2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeMEParamReportMap2.Properties.ValueMember = "MEParamNo";
            this.fld_lkeMEParamReportMap2.Screen = null;
            this.fld_lkeMEParamReportMap2.Size = new System.Drawing.Size(396, 26);
            this.fld_lkeMEParamReportMap2.TabIndex = 176;
            this.fld_lkeMEParamReportMap2.Tag = "DC";
            // 
            // fld_lkeFK_METemplateIDRelation2
            // 
            this.fld_lkeFK_METemplateIDRelation2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_lkeFK_METemplateIDRelation2.BOSAllowAddNew = false;
            this.fld_lkeFK_METemplateIDRelation2.BOSAllowDummy = false;
            this.fld_lkeFK_METemplateIDRelation2.BOSAllowMange = false;
            this.fld_lkeFK_METemplateIDRelation2.BOSComment = null;
            this.fld_lkeFK_METemplateIDRelation2.BOSDataMember = "FK_METemplateID2";
            this.fld_lkeFK_METemplateIDRelation2.BOSDataSource = "";
            this.fld_lkeFK_METemplateIDRelation2.BOSDescription = null;
            this.fld_lkeFK_METemplateIDRelation2.BOSDummyText = null;
            this.fld_lkeFK_METemplateIDRelation2.BOSError = null;
            this.fld_lkeFK_METemplateIDRelation2.BOSFieldGroup = null;
            this.fld_lkeFK_METemplateIDRelation2.BOSFieldParent = null;
            this.fld_lkeFK_METemplateIDRelation2.BOSFieldRelation = null;
            this.fld_lkeFK_METemplateIDRelation2.BOSPrivilege = null;
            this.fld_lkeFK_METemplateIDRelation2.BOSPropertyName = "EditValue";
            this.fld_lkeFK_METemplateIDRelation2.BOSSelectType = null;
            this.fld_lkeFK_METemplateIDRelation2.BOSSelectTypeValue = null;
            this.fld_lkeFK_METemplateIDRelation2.CurrentDisplayText = null;
            this.fld_lkeFK_METemplateIDRelation2.Location = new System.Drawing.Point(116, 200);
            this.fld_lkeFK_METemplateIDRelation2.MenuManager = this.screenToolbar;
            this.fld_lkeFK_METemplateIDRelation2.Name = "fld_lkeFK_METemplateIDRelation2";
            this.fld_lkeFK_METemplateIDRelation2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_METemplateIDRelation2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("METemplateNo", "Mã mẫu"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("METemplateName", "Tên mẫu")});
            this.fld_lkeFK_METemplateIDRelation2.Properties.DisplayMember = "METemplateNo";
            this.fld_lkeFK_METemplateIDRelation2.Properties.NullText = "";
            this.fld_lkeFK_METemplateIDRelation2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeFK_METemplateIDRelation2.Properties.ValueMember = "METemplateID";
            this.fld_lkeFK_METemplateIDRelation2.Screen = null;
            this.fld_lkeFK_METemplateIDRelation2.Size = new System.Drawing.Size(396, 26);
            this.fld_lkeFK_METemplateIDRelation2.TabIndex = 174;
            this.fld_lkeFK_METemplateIDRelation2.Tag = "DC";
            this.fld_lkeFK_METemplateIDRelation2.EditValueChanged += new System.EventHandler(this.fld_lkeFK_METemplateIDRelation2_EditValueChanged);
            // 
            // bosLabel1
            // 
            this.bosLabel1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.bosLabel1.Location = new System.Drawing.Point(5, 229);
            this.bosLabel1.Name = "bosLabel1";
            this.bosLabel1.Screen = null;
            this.bosLabel1.Size = new System.Drawing.Size(95, 19);
            this.bosLabel1.TabIndex = 177;
            this.bosLabel1.Tag = "";
            this.bosLabel1.Text = "Thẻ dữ liệu 2";
            // 
            // bosLabel3
            // 
            this.bosLabel3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.bosLabel3.Location = new System.Drawing.Point(5, 203);
            this.bosLabel3.Name = "bosLabel3";
            this.bosLabel3.Screen = null;
            this.bosLabel3.Size = new System.Drawing.Size(105, 19);
            this.bosLabel3.TabIndex = 175;
            this.bosLabel3.Tag = "";
            this.bosLabel3.Text = "Mẫu bệnh án 2";
            // 
            // fld_lkeFK_MEEmrTypeIDRelation
            // 
            this.fld_lkeFK_MEEmrTypeIDRelation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_lkeFK_MEEmrTypeIDRelation.BOSAllowAddNew = false;
            this.fld_lkeFK_MEEmrTypeIDRelation.BOSAllowDummy = false;
            this.fld_lkeFK_MEEmrTypeIDRelation.BOSAllowMange = false;
            this.fld_lkeFK_MEEmrTypeIDRelation.BOSComment = null;
            this.fld_lkeFK_MEEmrTypeIDRelation.BOSDataMember = "FK_MEEmrTypeID";
            this.fld_lkeFK_MEEmrTypeIDRelation.BOSDataSource = "";
            this.fld_lkeFK_MEEmrTypeIDRelation.BOSDescription = null;
            this.fld_lkeFK_MEEmrTypeIDRelation.BOSDummyText = null;
            this.fld_lkeFK_MEEmrTypeIDRelation.BOSError = null;
            this.fld_lkeFK_MEEmrTypeIDRelation.BOSFieldGroup = null;
            this.fld_lkeFK_MEEmrTypeIDRelation.BOSFieldParent = null;
            this.fld_lkeFK_MEEmrTypeIDRelation.BOSFieldRelation = null;
            this.fld_lkeFK_MEEmrTypeIDRelation.BOSPrivilege = null;
            this.fld_lkeFK_MEEmrTypeIDRelation.BOSPropertyName = "EditValue";
            this.fld_lkeFK_MEEmrTypeIDRelation.BOSSelectType = null;
            this.fld_lkeFK_MEEmrTypeIDRelation.BOSSelectTypeValue = null;
            this.fld_lkeFK_MEEmrTypeIDRelation.CurrentDisplayText = null;
            this.fld_lkeFK_MEEmrTypeIDRelation.Location = new System.Drawing.Point(102, 8);
            this.fld_lkeFK_MEEmrTypeIDRelation.MenuManager = this.screenToolbar;
            this.fld_lkeFK_MEEmrTypeIDRelation.Name = "fld_lkeFK_MEEmrTypeIDRelation";
            this.fld_lkeFK_MEEmrTypeIDRelation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_MEEmrTypeIDRelation.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MEEmrTypeNo", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MEEmrTypeName", "Tên")});
            this.fld_lkeFK_MEEmrTypeIDRelation.Properties.DisplayMember = "MEEmrTypeNo";
            this.fld_lkeFK_MEEmrTypeIDRelation.Properties.NullText = "";
            this.fld_lkeFK_MEEmrTypeIDRelation.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeFK_MEEmrTypeIDRelation.Properties.ValueMember = "MEEmrTypeID";
            this.fld_lkeFK_MEEmrTypeIDRelation.Screen = null;
            this.fld_lkeFK_MEEmrTypeIDRelation.Size = new System.Drawing.Size(410, 26);
            this.fld_lkeFK_MEEmrTypeIDRelation.TabIndex = 173;
            this.fld_lkeFK_MEEmrTypeIDRelation.Tag = "DC";
            this.fld_lkeFK_MEEmrTypeIDRelation.EditValueChanged += new System.EventHandler(this.fld_lkeFK_MEEmrTypeIDRelation_EditValueChanged);
            // 
            // bosLabel14
            // 
            this.bosLabel14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bosLabel14.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel14.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel14.Appearance.Options.UseBackColor = true;
            this.bosLabel14.Appearance.Options.UseForeColor = true;
            this.bosLabel14.BOSComment = "";
            this.bosLabel14.BOSDataMember = "";
            this.bosLabel14.BOSDataSource = "";
            this.bosLabel14.BOSDescription = null;
            this.bosLabel14.BOSError = null;
            this.bosLabel14.BOSFieldGroup = "";
            this.bosLabel14.BOSFieldRelation = "";
            this.bosLabel14.BOSPrivilege = "";
            this.bosLabel14.BOSPropertyName = "";
            this.bosLabel14.Location = new System.Drawing.Point(7, 321);
            this.bosLabel14.Name = "bosLabel14";
            this.bosLabel14.Screen = null;
            this.bosLabel14.Size = new System.Drawing.Size(407, 76);
            this.bosLabel14.TabIndex = 172;
            this.bosLabel14.Tag = "";
            this.bosLabel14.Text = "(*) Dữ liệu lưu vào lưới kế bên.\nCó giá trị khi bấm nút Lưu trên thanh công cụ.\nX" +
    "ML (Thứ tự, nhóm, bậc) để trống sẽ áp dụng mặc định.\nGía trị {2}{3} để trống nếu" +
    " không gộp giá trị thẻ dữ liệu.";
            // 
            // bosLabel11
            // 
            this.bosLabel11.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel11.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel11.Appearance.Options.UseBackColor = true;
            this.bosLabel11.Appearance.Options.UseForeColor = true;
            this.bosLabel11.BOSComment = null;
            this.bosLabel11.BOSDataMember = null;
            this.bosLabel11.BOSDataSource = null;
            this.bosLabel11.BOSDescription = null;
            this.bosLabel11.BOSError = null;
            this.bosLabel11.BOSFieldGroup = null;
            this.bosLabel11.BOSFieldRelation = null;
            this.bosLabel11.BOSPrivilege = null;
            this.bosLabel11.BOSPropertyName = null;
            this.bosLabel11.Location = new System.Drawing.Point(66, 148);
            this.bosLabel11.Name = "bosLabel11";
            this.bosLabel11.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel11, true);
            this.bosLabel11.Size = new System.Drawing.Size(49, 19);
            this.bosLabel11.TabIndex = 170;
            this.bosLabel11.Text = "Thứ tự";
            // 
            // fld_txtMEParamReportRelationXMLOrder
            // 
            this.fld_txtMEParamReportRelationXMLOrder.BOSComment = null;
            this.fld_txtMEParamReportRelationXMLOrder.BOSDataMember = "MEParamReportRelationXMLOrder";
            this.fld_txtMEParamReportRelationXMLOrder.BOSDataSource = "MEParamReportRelations";
            this.fld_txtMEParamReportRelationXMLOrder.BOSDescription = null;
            this.fld_txtMEParamReportRelationXMLOrder.BOSError = null;
            this.fld_txtMEParamReportRelationXMLOrder.BOSFieldGroup = null;
            this.fld_txtMEParamReportRelationXMLOrder.BOSFieldRelation = null;
            this.fld_txtMEParamReportRelationXMLOrder.BOSPrivilege = null;
            this.fld_txtMEParamReportRelationXMLOrder.BOSPropertyName = "Text";
            this.fld_txtMEParamReportRelationXMLOrder.Enabled = false;
            this.fld_txtMEParamReportRelationXMLOrder.Location = new System.Drawing.Point(121, 144);
            this.fld_txtMEParamReportRelationXMLOrder.Name = "fld_txtMEParamReportRelationXMLOrder";
            this.fld_txtMEParamReportRelationXMLOrder.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fld_txtMEParamReportRelationXMLOrder.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_txtMEParamReportRelationXMLOrder, true);
            this.fld_txtMEParamReportRelationXMLOrder.Size = new System.Drawing.Size(101, 26);
            this.fld_txtMEParamReportRelationXMLOrder.TabIndex = 169;
            this.fld_txtMEParamReportRelationXMLOrder.Tag = "DC";
            // 
            // bosLabel10
            // 
            this.bosLabel10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bosLabel10.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel10.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel10.Appearance.Options.UseBackColor = true;
            this.bosLabel10.Appearance.Options.UseForeColor = true;
            this.bosLabel10.BOSComment = "";
            this.bosLabel10.BOSDataMember = "";
            this.bosLabel10.BOSDataSource = "";
            this.bosLabel10.BOSDescription = null;
            this.bosLabel10.BOSError = null;
            this.bosLabel10.BOSFieldGroup = "";
            this.bosLabel10.BOSFieldRelation = "";
            this.bosLabel10.BOSPrivilege = "";
            this.bosLabel10.BOSPropertyName = "";
            this.bosLabel10.Location = new System.Drawing.Point(5, 11);
            this.bosLabel10.Name = "bosLabel10";
            this.bosLabel10.Screen = null;
            this.bosLabel10.Size = new System.Drawing.Size(91, 19);
            this.bosLabel10.TabIndex = 171;
            this.bosLabel10.Tag = "";
            this.bosLabel10.Text = "Loại bệnh án";
            // 
            // fld_lkeMEParamReportMap
            // 
            this.fld_lkeMEParamReportMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_lkeMEParamReportMap.BOSAllowAddNew = false;
            this.fld_lkeMEParamReportMap.BOSAllowDummy = false;
            this.fld_lkeMEParamReportMap.BOSAllowMange = false;
            this.fld_lkeMEParamReportMap.BOSComment = null;
            this.fld_lkeMEParamReportMap.BOSDataMember = "MEParamReportMap";
            this.fld_lkeMEParamReportMap.BOSDataSource = "";
            this.fld_lkeMEParamReportMap.BOSDescription = null;
            this.fld_lkeMEParamReportMap.BOSDummyText = null;
            this.fld_lkeMEParamReportMap.BOSError = null;
            this.fld_lkeMEParamReportMap.BOSFieldGroup = null;
            this.fld_lkeMEParamReportMap.BOSFieldParent = null;
            this.fld_lkeMEParamReportMap.BOSFieldRelation = null;
            this.fld_lkeMEParamReportMap.BOSPrivilege = null;
            this.fld_lkeMEParamReportMap.BOSPropertyName = "EditValue";
            this.fld_lkeMEParamReportMap.BOSSelectType = null;
            this.fld_lkeMEParamReportMap.BOSSelectTypeValue = null;
            this.fld_lkeMEParamReportMap.CurrentDisplayText = null;
            this.fld_lkeMEParamReportMap.Enabled = false;
            this.fld_lkeMEParamReportMap.Location = new System.Drawing.Point(102, 62);
            this.fld_lkeMEParamReportMap.MenuManager = this.screenToolbar;
            this.fld_lkeMEParamReportMap.Name = "fld_lkeMEParamReportMap";
            this.fld_lkeMEParamReportMap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeMEParamReportMap.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MEParamNo", "Mã thẻ"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MEParamName", "Tên thẻ")});
            this.fld_lkeMEParamReportMap.Properties.DisplayMember = "MEParamNo";
            this.fld_lkeMEParamReportMap.Properties.NullText = "";
            this.fld_lkeMEParamReportMap.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeMEParamReportMap.Properties.ValueMember = "MEParamNo";
            this.fld_lkeMEParamReportMap.Screen = null;
            this.fld_lkeMEParamReportMap.Size = new System.Drawing.Size(410, 26);
            this.fld_lkeMEParamReportMap.TabIndex = 168;
            this.fld_lkeMEParamReportMap.Tag = "DC";
            // 
            // fld_lkeFK_METemplateIDRelation
            // 
            this.fld_lkeFK_METemplateIDRelation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_lkeFK_METemplateIDRelation.BOSAllowAddNew = false;
            this.fld_lkeFK_METemplateIDRelation.BOSAllowDummy = false;
            this.fld_lkeFK_METemplateIDRelation.BOSAllowMange = false;
            this.fld_lkeFK_METemplateIDRelation.BOSComment = null;
            this.fld_lkeFK_METemplateIDRelation.BOSDataMember = "";
            this.fld_lkeFK_METemplateIDRelation.BOSDataSource = "";
            this.fld_lkeFK_METemplateIDRelation.BOSDescription = null;
            this.fld_lkeFK_METemplateIDRelation.BOSDummyText = null;
            this.fld_lkeFK_METemplateIDRelation.BOSError = null;
            this.fld_lkeFK_METemplateIDRelation.BOSFieldGroup = null;
            this.fld_lkeFK_METemplateIDRelation.BOSFieldParent = null;
            this.fld_lkeFK_METemplateIDRelation.BOSFieldRelation = null;
            this.fld_lkeFK_METemplateIDRelation.BOSPrivilege = null;
            this.fld_lkeFK_METemplateIDRelation.BOSPropertyName = "EditValue";
            this.fld_lkeFK_METemplateIDRelation.BOSSelectType = null;
            this.fld_lkeFK_METemplateIDRelation.BOSSelectTypeValue = null;
            this.fld_lkeFK_METemplateIDRelation.CurrentDisplayText = null;
            this.fld_lkeFK_METemplateIDRelation.Location = new System.Drawing.Point(102, 35);
            this.fld_lkeFK_METemplateIDRelation.MenuManager = this.screenToolbar;
            this.fld_lkeFK_METemplateIDRelation.Name = "fld_lkeFK_METemplateIDRelation";
            this.fld_lkeFK_METemplateIDRelation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_METemplateIDRelation.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("METemplateNo", "Mã mẫu"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("METemplateName", "Tên mẫu")});
            this.fld_lkeFK_METemplateIDRelation.Properties.DisplayMember = "METemplateNo";
            this.fld_lkeFK_METemplateIDRelation.Properties.NullText = "";
            this.fld_lkeFK_METemplateIDRelation.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeFK_METemplateIDRelation.Properties.ValueMember = "METemplateID";
            this.fld_lkeFK_METemplateIDRelation.Screen = null;
            this.fld_lkeFK_METemplateIDRelation.Size = new System.Drawing.Size(410, 26);
            this.fld_lkeFK_METemplateIDRelation.TabIndex = 166;
            this.fld_lkeFK_METemplateIDRelation.Tag = "DC";
            this.fld_lkeFK_METemplateIDRelation.EditValueChanged += new System.EventHandler(this.fld_lkeFK_METemplateIDRelation_EditValueChanged);
            // 
            // fld_chkMEParamReportRelationXML
            // 
            this.fld_chkMEParamReportRelationXML.BOSComment = null;
            this.fld_chkMEParamReportRelationXML.BOSDataMember = "MEParamReportRelationXML";
            this.fld_chkMEParamReportRelationXML.BOSDataSource = "MEParamReportRelations";
            this.fld_chkMEParamReportRelationXML.BOSDescription = null;
            this.fld_chkMEParamReportRelationXML.BOSError = null;
            this.fld_chkMEParamReportRelationXML.BOSFieldGroup = null;
            this.fld_chkMEParamReportRelationXML.BOSFieldRelation = null;
            this.fld_chkMEParamReportRelationXML.BOSPrivilege = null;
            this.fld_chkMEParamReportRelationXML.BOSPropertyName = "Checked";
            this.fld_chkMEParamReportRelationXML.EditValue = true;
            this.fld_chkMEParamReportRelationXML.Enabled = false;
            this.fld_chkMEParamReportRelationXML.Location = new System.Drawing.Point(7, 146);
            this.fld_chkMEParamReportRelationXML.MenuManager = this.screenToolbar;
            this.fld_chkMEParamReportRelationXML.Name = "fld_chkMEParamReportRelationXML";
            this.fld_chkMEParamReportRelationXML.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.fld_chkMEParamReportRelationXML.Properties.Appearance.Options.UseBackColor = true;
            this.fld_chkMEParamReportRelationXML.Properties.Caption = "XML";
            this.fld_chkMEParamReportRelationXML.Screen = null;
            this.fld_chkMEParamReportRelationXML.Size = new System.Drawing.Size(53, 23);
            this.fld_chkMEParamReportRelationXML.TabIndex = 166;
            this.fld_chkMEParamReportRelationXML.Tag = "DC";
            // 
            // bosLabel8
            // 
            this.bosLabel8.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel8.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel8.Appearance.Options.UseBackColor = true;
            this.bosLabel8.Appearance.Options.UseForeColor = true;
            this.bosLabel8.BOSComment = "";
            this.bosLabel8.BOSDataMember = "";
            this.bosLabel8.BOSDataSource = "";
            this.bosLabel8.BOSDescription = null;
            this.bosLabel8.BOSError = null;
            this.bosLabel8.BOSFieldGroup = "";
            this.bosLabel8.BOSFieldRelation = "";
            this.bosLabel8.BOSPrivilege = "";
            this.bosLabel8.BOSPropertyName = "";
            this.bosLabel8.Location = new System.Drawing.Point(5, 63);
            this.bosLabel8.Name = "bosLabel8";
            this.bosLabel8.Screen = null;
            this.bosLabel8.Size = new System.Drawing.Size(81, 19);
            this.bosLabel8.TabIndex = 169;
            this.bosLabel8.Tag = "";
            this.bosLabel8.Text = "Thẻ dữ liệu";
            // 
            // bosLabel9
            // 
            this.bosLabel9.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel9.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel9.Appearance.Options.UseBackColor = true;
            this.bosLabel9.Appearance.Options.UseForeColor = true;
            this.bosLabel9.BOSComment = "";
            this.bosLabel9.BOSDataMember = "";
            this.bosLabel9.BOSDataSource = "";
            this.bosLabel9.BOSDescription = null;
            this.bosLabel9.BOSError = null;
            this.bosLabel9.BOSFieldGroup = "";
            this.bosLabel9.BOSFieldRelation = "";
            this.bosLabel9.BOSPrivilege = "";
            this.bosLabel9.BOSPropertyName = "";
            this.bosLabel9.Location = new System.Drawing.Point(5, 38);
            this.bosLabel9.Name = "bosLabel9";
            this.bosLabel9.Screen = null;
            this.bosLabel9.Size = new System.Drawing.Size(91, 19);
            this.bosLabel9.TabIndex = 167;
            this.bosLabel9.Tag = "";
            this.bosLabel9.Text = "Mẫu bệnh án";
            // 
            // fld_btnRemoveRelation
            // 
            this.fld_btnRemoveRelation.Location = new System.Drawing.Point(6, 162);
            this.fld_btnRemoveRelation.Name = "fld_btnRemoveRelation";
            this.ScreenHelper.SetShowHelp(this.fld_btnRemoveRelation, true);
            this.fld_btnRemoveRelation.Size = new System.Drawing.Size(55, 27);
            this.fld_btnRemoveRelation.TabIndex = 174;
            this.fld_btnRemoveRelation.Text = "<<";
            this.fld_btnRemoveRelation.Click += new System.EventHandler(this.fld_btnRemoveRelation_Click);
            // 
            // fld_dgcMEParamReportRelations
            // 
            this.fld_dgcMEParamReportRelations.AllowDrop = true;
            this.fld_dgcMEParamReportRelations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcMEParamReportRelations.BOSComment = "";
            this.fld_dgcMEParamReportRelations.BOSDataMember = "";
            this.fld_dgcMEParamReportRelations.BOSDataSource = "MEParamReportRelations";
            this.fld_dgcMEParamReportRelations.BOSDescription = null;
            this.fld_dgcMEParamReportRelations.BOSError = null;
            this.fld_dgcMEParamReportRelations.BOSFieldGroup = "";
            this.fld_dgcMEParamReportRelations.BOSFieldRelation = "";
            this.fld_dgcMEParamReportRelations.BOSGridType = null;
            this.fld_dgcMEParamReportRelations.BOSPrivilege = "";
            this.fld_dgcMEParamReportRelations.BOSPropertyName = "";
            this.fld_dgcMEParamReportRelations.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMEParamReportRelations.Location = new System.Drawing.Point(66, 0);
            this.fld_dgcMEParamReportRelations.MainView = this.fld_dgvMEParamReportRelations;
            this.fld_dgcMEParamReportRelations.Name = "fld_dgcMEParamReportRelations";
            this.fld_dgcMEParamReportRelations.PrintReport = false;
            this.fld_dgcMEParamReportRelations.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_dgcMEParamReportRelations.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_dgcMEParamReportRelations, true);
            this.fld_dgcMEParamReportRelations.Size = new System.Drawing.Size(737, 486);
            this.fld_dgcMEParamReportRelations.TabIndex = 12;
            this.fld_dgcMEParamReportRelations.Tag = "DC";
            this.fld_dgcMEParamReportRelations.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvMEParamReportRelations});
            // 
            // fld_dgvMEParamReportRelations
            // 
            this.fld_dgvMEParamReportRelations.GridControl = this.fld_dgcMEParamReportRelations;
            this.fld_dgvMEParamReportRelations.Name = "fld_dgvMEParamReportRelations";
            this.fld_dgvMEParamReportRelations.PaintStyleName = "Office2003";
            // 
            // fld_btnUpdateRelation
            // 
            this.fld_btnUpdateRelation.Location = new System.Drawing.Point(6, 129);
            this.fld_btnUpdateRelation.Name = "fld_btnUpdateRelation";
            this.ScreenHelper.SetShowHelp(this.fld_btnUpdateRelation, true);
            this.fld_btnUpdateRelation.Size = new System.Drawing.Size(55, 27);
            this.fld_btnUpdateRelation.TabIndex = 173;
            this.fld_btnUpdateRelation.Text = ">>";
            this.fld_btnUpdateRelation.Click += new System.EventHandler(this.fld_btnUpdateRelation_Click);
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
            this.bosPanel1.Controls.Add(this.fld_lkeMEParamFormatType);
            this.bosPanel1.Controls.Add(this.bosLabel18);
            this.bosPanel1.Controls.Add(this.fld_txtMEParamMaxLength);
            this.bosPanel1.Controls.Add(this.bosLabel17);
            this.bosPanel1.Controls.Add(this.fld_txtMEParamFormatString);
            this.bosPanel1.Controls.Add(this.bosLabel13);
            this.bosPanel1.Controls.Add(this.fld_txtMEParamXMLTag);
            this.bosPanel1.Controls.Add(this.bosLabel16);
            this.bosPanel1.Controls.Add(this.fld_txtMEParamCaption);
            this.bosPanel1.Controls.Add(this.bosLabel15);
            this.bosPanel1.Controls.Add(this.fld_txtMEParamName);
            this.bosPanel1.Controls.Add(this.bosLabel2);
            this.bosPanel1.Controls.Add(this.fld_txtMEParamNo);
            this.bosPanel1.Controls.Add(this.bosLabel7);
            this.bosPanel1.Controls.Add(this.fld_grcGroupControl2);
            this.bosPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bosPanel1.Location = new System.Drawing.Point(0, 0);
            this.bosPanel1.Name = "bosPanel1";
            this.bosPanel1.Screen = null;
            this.bosPanel1.Size = new System.Drawing.Size(1336, 619);
            this.bosPanel1.TabIndex = 83;
            // 
            // fld_lkeMEParamFormatType
            // 
            this.fld_lkeMEParamFormatType.BOSAllowAddNew = false;
            this.fld_lkeMEParamFormatType.BOSAllowDummy = true;
            this.fld_lkeMEParamFormatType.BOSAllowMange = false;
            this.fld_lkeMEParamFormatType.BOSComment = null;
            this.fld_lkeMEParamFormatType.BOSDataMember = "MEParamFormatType";
            this.fld_lkeMEParamFormatType.BOSDataSource = "MEParams";
            this.fld_lkeMEParamFormatType.BOSDescription = null;
            this.fld_lkeMEParamFormatType.BOSDummyText = null;
            this.fld_lkeMEParamFormatType.BOSError = null;
            this.fld_lkeMEParamFormatType.BOSFieldGroup = null;
            this.fld_lkeMEParamFormatType.BOSFieldParent = null;
            this.fld_lkeMEParamFormatType.BOSFieldRelation = null;
            this.fld_lkeMEParamFormatType.BOSPrivilege = null;
            this.fld_lkeMEParamFormatType.BOSPropertyName = "EditValue";
            this.fld_lkeMEParamFormatType.BOSSelectType = null;
            this.fld_lkeMEParamFormatType.BOSSelectTypeValue = null;
            this.fld_lkeMEParamFormatType.CurrentDisplayText = null;
            this.fld_lkeMEParamFormatType.Location = new System.Drawing.Point(513, 38);
            this.fld_lkeMEParamFormatType.MenuManager = this.screenToolbar;
            this.fld_lkeMEParamFormatType.Name = "fld_lkeMEParamFormatType";
            this.fld_lkeMEParamFormatType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeMEParamFormatType.Properties.NullText = "";
            this.fld_lkeMEParamFormatType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeMEParamFormatType.Screen = null;
            this.fld_lkeMEParamFormatType.Size = new System.Drawing.Size(350, 26);
            this.fld_lkeMEParamFormatType.TabIndex = 174;
            this.fld_lkeMEParamFormatType.Tag = "DC";
            // 
            // bosLabel18
            // 
            this.bosLabel18.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel18.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel18.Appearance.Options.UseBackColor = true;
            this.bosLabel18.Appearance.Options.UseForeColor = true;
            this.bosLabel18.BOSComment = null;
            this.bosLabel18.BOSDataMember = null;
            this.bosLabel18.BOSDataSource = null;
            this.bosLabel18.BOSDescription = null;
            this.bosLabel18.BOSError = null;
            this.bosLabel18.BOSFieldGroup = null;
            this.bosLabel18.BOSFieldRelation = null;
            this.bosLabel18.BOSPrivilege = null;
            this.bosLabel18.BOSPropertyName = null;
            this.bosLabel18.Location = new System.Drawing.Point(423, 44);
            this.bosLabel18.Name = "bosLabel18";
            this.bosLabel18.Screen = null;
            this.bosLabel18.Size = new System.Drawing.Size(84, 19);
            this.bosLabel18.TabIndex = 173;
            this.bosLabel18.Text = "Kiểu dữ liệu";
            // 
            // fld_txtMEParamMaxLength
            // 
            this.fld_txtMEParamMaxLength.BOSComment = null;
            this.fld_txtMEParamMaxLength.BOSDataMember = "MEParamMaxLength";
            this.fld_txtMEParamMaxLength.BOSDataSource = "MEParams";
            this.fld_txtMEParamMaxLength.BOSDescription = null;
            this.fld_txtMEParamMaxLength.BOSError = null;
            this.fld_txtMEParamMaxLength.BOSFieldGroup = null;
            this.fld_txtMEParamMaxLength.BOSFieldRelation = null;
            this.fld_txtMEParamMaxLength.BOSPrivilege = null;
            this.fld_txtMEParamMaxLength.BOSPropertyName = "Text";
            this.fld_txtMEParamMaxLength.Enabled = false;
            this.fld_txtMEParamMaxLength.Location = new System.Drawing.Point(750, 65);
            this.fld_txtMEParamMaxLength.Name = "fld_txtMEParamMaxLength";
            this.fld_txtMEParamMaxLength.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_txtMEParamMaxLength, true);
            this.fld_txtMEParamMaxLength.Size = new System.Drawing.Size(113, 26);
            this.fld_txtMEParamMaxLength.TabIndex = 171;
            this.fld_txtMEParamMaxLength.Tag = "DC";
            // 
            // bosLabel17
            // 
            this.bosLabel17.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel17.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel17.Appearance.Options.UseBackColor = true;
            this.bosLabel17.Appearance.Options.UseForeColor = true;
            this.bosLabel17.BOSComment = null;
            this.bosLabel17.BOSDataMember = null;
            this.bosLabel17.BOSDataSource = null;
            this.bosLabel17.BOSDescription = null;
            this.bosLabel17.BOSError = null;
            this.bosLabel17.BOSFieldGroup = null;
            this.bosLabel17.BOSFieldRelation = null;
            this.bosLabel17.BOSPrivilege = null;
            this.bosLabel17.BOSPropertyName = null;
            this.bosLabel17.Location = new System.Drawing.Point(697, 67);
            this.bosLabel17.Name = "bosLabel17";
            this.bosLabel17.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel17, true);
            this.bosLabel17.Size = new System.Drawing.Size(48, 19);
            this.bosLabel17.TabIndex = 172;
            this.bosLabel17.Text = "Length";
            // 
            // fld_txtMEParamFormatString
            // 
            this.fld_txtMEParamFormatString.BOSComment = null;
            this.fld_txtMEParamFormatString.BOSDataMember = "MEParamFormatString";
            this.fld_txtMEParamFormatString.BOSDataSource = "MEParams";
            this.fld_txtMEParamFormatString.BOSDescription = null;
            this.fld_txtMEParamFormatString.BOSError = null;
            this.fld_txtMEParamFormatString.BOSFieldGroup = null;
            this.fld_txtMEParamFormatString.BOSFieldRelation = null;
            this.fld_txtMEParamFormatString.BOSPrivilege = null;
            this.fld_txtMEParamFormatString.BOSPropertyName = "Text";
            this.fld_txtMEParamFormatString.Enabled = false;
            this.fld_txtMEParamFormatString.Location = new System.Drawing.Point(513, 65);
            this.fld_txtMEParamFormatString.Name = "fld_txtMEParamFormatString";
            this.fld_txtMEParamFormatString.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_txtMEParamFormatString, true);
            this.fld_txtMEParamFormatString.Size = new System.Drawing.Size(178, 26);
            this.fld_txtMEParamFormatString.TabIndex = 169;
            this.fld_txtMEParamFormatString.Tag = "DC";
            // 
            // bosLabel13
            // 
            this.bosLabel13.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel13.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel13.Appearance.Options.UseBackColor = true;
            this.bosLabel13.Appearance.Options.UseForeColor = true;
            this.bosLabel13.BOSComment = null;
            this.bosLabel13.BOSDataMember = null;
            this.bosLabel13.BOSDataSource = null;
            this.bosLabel13.BOSDescription = null;
            this.bosLabel13.BOSError = null;
            this.bosLabel13.BOSFieldGroup = null;
            this.bosLabel13.BOSFieldRelation = null;
            this.bosLabel13.BOSPrivilege = null;
            this.bosLabel13.BOSPropertyName = null;
            this.bosLabel13.Location = new System.Drawing.Point(423, 71);
            this.bosLabel13.Name = "bosLabel13";
            this.bosLabel13.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel13, true);
            this.bosLabel13.Size = new System.Drawing.Size(73, 19);
            this.bosLabel13.TabIndex = 170;
            this.bosLabel13.Text = "Định dạng";
            // 
            // fld_txtMEParamXMLTag
            // 
            this.fld_txtMEParamXMLTag.BOSComment = null;
            this.fld_txtMEParamXMLTag.BOSDataMember = "MEParamXMLTag";
            this.fld_txtMEParamXMLTag.BOSDataSource = "MEParams";
            this.fld_txtMEParamXMLTag.BOSDescription = null;
            this.fld_txtMEParamXMLTag.BOSError = null;
            this.fld_txtMEParamXMLTag.BOSFieldGroup = null;
            this.fld_txtMEParamXMLTag.BOSFieldRelation = null;
            this.fld_txtMEParamXMLTag.BOSPrivilege = null;
            this.fld_txtMEParamXMLTag.BOSPropertyName = "Text";
            this.fld_txtMEParamXMLTag.Enabled = false;
            this.fld_txtMEParamXMLTag.Location = new System.Drawing.Point(513, 11);
            this.fld_txtMEParamXMLTag.Name = "fld_txtMEParamXMLTag";
            this.fld_txtMEParamXMLTag.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_txtMEParamXMLTag, true);
            this.fld_txtMEParamXMLTag.Size = new System.Drawing.Size(350, 26);
            this.fld_txtMEParamXMLTag.TabIndex = 167;
            this.fld_txtMEParamXMLTag.Tag = "DC";
            // 
            // bosLabel16
            // 
            this.bosLabel16.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel16.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel16.Appearance.Options.UseBackColor = true;
            this.bosLabel16.Appearance.Options.UseForeColor = true;
            this.bosLabel16.BOSComment = null;
            this.bosLabel16.BOSDataMember = null;
            this.bosLabel16.BOSDataSource = null;
            this.bosLabel16.BOSDescription = null;
            this.bosLabel16.BOSError = null;
            this.bosLabel16.BOSFieldGroup = null;
            this.bosLabel16.BOSFieldRelation = null;
            this.bosLabel16.BOSPrivilege = null;
            this.bosLabel16.BOSPropertyName = null;
            this.bosLabel16.Location = new System.Drawing.Point(423, 15);
            this.bosLabel16.Name = "bosLabel16";
            this.bosLabel16.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel16, true);
            this.bosLabel16.Size = new System.Drawing.Size(61, 19);
            this.bosLabel16.TabIndex = 168;
            this.bosLabel16.Text = "Thẻ XML";
            // 
            // fld_txtMEParamCaption
            // 
            this.fld_txtMEParamCaption.BOSComment = null;
            this.fld_txtMEParamCaption.BOSDataMember = "MEParamCaption";
            this.fld_txtMEParamCaption.BOSDataSource = "MEParams";
            this.fld_txtMEParamCaption.BOSDescription = null;
            this.fld_txtMEParamCaption.BOSError = null;
            this.fld_txtMEParamCaption.BOSFieldGroup = null;
            this.fld_txtMEParamCaption.BOSFieldRelation = null;
            this.fld_txtMEParamCaption.BOSPrivilege = null;
            this.fld_txtMEParamCaption.BOSPropertyName = "Text";
            this.fld_txtMEParamCaption.Enabled = false;
            this.fld_txtMEParamCaption.Location = new System.Drawing.Point(71, 40);
            this.fld_txtMEParamCaption.Name = "fld_txtMEParamCaption";
            this.fld_txtMEParamCaption.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_txtMEParamCaption, true);
            this.fld_txtMEParamCaption.Size = new System.Drawing.Size(344, 26);
            this.fld_txtMEParamCaption.TabIndex = 165;
            this.fld_txtMEParamCaption.Tag = "DC";
            // 
            // bosLabel15
            // 
            this.bosLabel15.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel15.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel15.Appearance.Options.UseBackColor = true;
            this.bosLabel15.Appearance.Options.UseForeColor = true;
            this.bosLabel15.BOSComment = null;
            this.bosLabel15.BOSDataMember = null;
            this.bosLabel15.BOSDataSource = null;
            this.bosLabel15.BOSDescription = null;
            this.bosLabel15.BOSError = null;
            this.bosLabel15.BOSFieldGroup = null;
            this.bosLabel15.BOSFieldRelation = null;
            this.bosLabel15.BOSPrivilege = null;
            this.bosLabel15.BOSPropertyName = null;
            this.bosLabel15.Location = new System.Drawing.Point(11, 42);
            this.bosLabel15.Name = "bosLabel15";
            this.bosLabel15.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel15, true);
            this.bosLabel15.Size = new System.Drawing.Size(53, 19);
            this.bosLabel15.TabIndex = 166;
            this.bosLabel15.Text = "Tiêu đề";
            // 
            // fld_txtMEParamName
            // 
            this.fld_txtMEParamName.BOSComment = null;
            this.fld_txtMEParamName.BOSDataMember = "MEParamName";
            this.fld_txtMEParamName.BOSDataSource = "MEParams";
            this.fld_txtMEParamName.BOSDescription = null;
            this.fld_txtMEParamName.BOSError = null;
            this.fld_txtMEParamName.BOSFieldGroup = null;
            this.fld_txtMEParamName.BOSFieldRelation = null;
            this.fld_txtMEParamName.BOSPrivilege = null;
            this.fld_txtMEParamName.BOSPropertyName = "Text";
            this.fld_txtMEParamName.Enabled = false;
            this.fld_txtMEParamName.Location = new System.Drawing.Point(71, 68);
            this.fld_txtMEParamName.Name = "fld_txtMEParamName";
            this.fld_txtMEParamName.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_txtMEParamName, true);
            this.fld_txtMEParamName.Size = new System.Drawing.Size(344, 26);
            this.fld_txtMEParamName.TabIndex = 163;
            this.fld_txtMEParamName.Tag = "DC";
            // 
            // bosLabel2
            // 
            this.bosLabel2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.bosLabel2.Location = new System.Drawing.Point(11, 70);
            this.bosLabel2.Name = "bosLabel2";
            this.bosLabel2.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel2, true);
            this.bosLabel2.Size = new System.Drawing.Size(54, 19);
            this.bosLabel2.TabIndex = 164;
            this.bosLabel2.Text = "Tên thẻ";
            // 
            // fld_txtMEParamNo
            // 
            this.fld_txtMEParamNo.BOSComment = null;
            this.fld_txtMEParamNo.BOSDataMember = "MEParamNo";
            this.fld_txtMEParamNo.BOSDataSource = "MEParams";
            this.fld_txtMEParamNo.BOSDescription = null;
            this.fld_txtMEParamNo.BOSError = null;
            this.fld_txtMEParamNo.BOSFieldGroup = null;
            this.fld_txtMEParamNo.BOSFieldRelation = null;
            this.fld_txtMEParamNo.BOSPrivilege = null;
            this.fld_txtMEParamNo.BOSPropertyName = "Text";
            this.fld_txtMEParamNo.Enabled = false;
            this.fld_txtMEParamNo.Location = new System.Drawing.Point(71, 12);
            this.fld_txtMEParamNo.Name = "fld_txtMEParamNo";
            this.fld_txtMEParamNo.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_txtMEParamNo, true);
            this.fld_txtMEParamNo.Size = new System.Drawing.Size(344, 26);
            this.fld_txtMEParamNo.TabIndex = 148;
            this.fld_txtMEParamNo.Tag = "DC";
            // 
            // bosLabel7
            // 
            this.bosLabel7.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel7.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel7.Appearance.Options.UseBackColor = true;
            this.bosLabel7.Appearance.Options.UseForeColor = true;
            this.bosLabel7.BOSComment = null;
            this.bosLabel7.BOSDataMember = null;
            this.bosLabel7.BOSDataSource = null;
            this.bosLabel7.BOSDescription = null;
            this.bosLabel7.BOSError = null;
            this.bosLabel7.BOSFieldGroup = null;
            this.bosLabel7.BOSFieldRelation = null;
            this.bosLabel7.BOSPrivilege = null;
            this.bosLabel7.BOSPropertyName = null;
            this.bosLabel7.Location = new System.Drawing.Point(11, 14);
            this.bosLabel7.Name = "bosLabel7";
            this.bosLabel7.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel7, true);
            this.bosLabel7.Size = new System.Drawing.Size(47, 19);
            this.bosLabel7.TabIndex = 149;
            this.bosLabel7.Text = "Mã thẻ";
            // 
            // DMMPR100
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(1336, 619);
            this.Controls.Add(this.bosPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DMMPR100";
            this.Text = "Thông tin";
            this.Load += new System.EventHandler(this.DMMPR100_Load);
            this.Controls.SetChildIndex(this.bosPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_grcGroupControl2)).EndInit();
            this.fld_grcGroupControl2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamReportMapFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEParamReportRelationEncode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEParamReportMap3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_METemplateIDRelation3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEParamReportMap2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_METemplateIDRelation2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_MEEmrTypeIDRelation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamReportRelationXMLOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEParamReportMap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_METemplateIDRelation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkMEParamReportRelationXML.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEParamReportRelations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEParamReportRelations)).EndInit();
            this.bosPanel1.ResumeLayout(false);
            this.bosPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEParamFormatType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamMaxLength.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamFormatString.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamXMLTag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamCaption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamNo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
        private IContainer components;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private BOSComponent.BOSGroupControl fld_grcGroupControl2;
        private SplitContainer splitContainer1;
        private MEParamReportRelationsGridControl fld_dgcMEParamReportRelations;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvMEParamReportRelations;
        private BOSComponent.BOSPanel bosPanel1;
        private BOSComponent.BOSTextBox fld_txtMEParamNo;
        private BOSComponent.BOSLabel bosLabel7;
        private BOSComponent.BOSLabel bosLabel10;
        private BOSComponent.BOSLookupEdit fld_lkeMEParamReportMap;
        private BOSComponent.BOSLookupEdit fld_lkeFK_METemplateIDRelation;
        private BOSComponent.BOSLabel bosLabel8;
        private BOSComponent.BOSLabel bosLabel9;
        private BOSComponent.BOSLabel bosLabel14;
        private BOSComponent.BOSLabel bosLabel11;
        private BOSComponent.BOSTextBox fld_txtMEParamReportRelationXMLOrder;
        private BOSComponent.BOSCheckEdit fld_chkMEParamReportRelationXML;
        private DevExpress.XtraEditors.SimpleButton fld_btnRemoveRelation;
        private DevExpress.XtraEditors.SimpleButton fld_btnUpdateRelation;
        private BOSComponent.BOSLookupEdit fld_lkeFK_MEEmrTypeIDRelation;
        private BOSComponent.BOSTextBox fld_txtMEParamName;
        private BOSComponent.BOSLabel bosLabel2;
        private BOSComponent.BOSTextBox fld_txtMEParamCaption;
        private BOSComponent.BOSLabel bosLabel15;
        private BOSComponent.BOSLookupEdit fld_lkeMEParamReportMap3;
        private BOSComponent.BOSLookupEdit fld_lkeFK_METemplateIDRelation3;
        private BOSComponent.BOSLabel bosLabel5;
        private BOSComponent.BOSLabel bosLabel6;
        private BOSComponent.BOSLabel bosLabel4;
        private BOSComponent.BOSLookupEdit fld_lkeMEParamReportMap2;
        private BOSComponent.BOSLookupEdit fld_lkeFK_METemplateIDRelation2;
        private BOSComponent.BOSLabel bosLabel1;
        private BOSComponent.BOSLabel bosLabel3;
        private BOSComponent.BOSTextBox fld_txtMEParamXMLTag;
        private BOSComponent.BOSLabel bosLabel16;
        private BOSComponent.BOSLabel bosLabel12;
        private BOSComponent.BOSTextBox fld_txtMEParamMaxLength;
        private BOSComponent.BOSLabel bosLabel17;
        private BOSComponent.BOSTextBox fld_txtMEParamFormatString;
        private BOSComponent.BOSLabel bosLabel13;
        private BOSComponent.BOSLookupEdit fld_lkeMEParamFormatType;
        private BOSComponent.BOSLabel bosLabel18;
        private BOSComponent.BOSLookupEdit fld_lkeMEParamReportRelationEncode;
        private BOSComponent.BOSLabel bosLabel19;
        private BOSComponent.BOSTextBox fld_txtMEParamReportMapFilter;
        private BOSComponent.BOSLabel bosLabel20;
    }
}
