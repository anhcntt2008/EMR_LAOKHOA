using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.ICProduct.UI
{
	/// <summary>
	/// Summary description for SMICPR100
	/// </summary>
	partial class SMICPR100
	{
		private BOSSearchResultsGridControl fld_dgcICProduct;
		private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvICProduct;
		private BOSComponent.BOSLabel fld_lblLabel21;
		private BOSComponent.BOSLabel fld_lblLabel22;
		private BOSComponent.BOSLabel fld_lblLabel23;
		private BOSComponent.BOSLabel fld_lblLabel25;
		private BOSComponent.BOSLabel fld_lblLabel26;
		private BOSComponent.BOSLabel fld_lblLabel27;
		private BOSComponent.BOSLookupEdit fld_lkeFK_GELocationID1;
		private BOSComponent.BOSTextBox fld_txtICProductNo1;
		private BOSComponent.BOSTextBox fld_txtICProductName1;
		private BOSComponent.BOSLookupEdit fld_lkeFK_APSupplierID1;
		private BOSComponent.BOSLookupEdit fld_lkeFK_ICProductGroupID1;
        private BOSComponent.BOSLookupEdit fld_lkeLookupEdit1;


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMICPR100));
            this.fld_dgcICProduct = new BOSERP.BOSSearchResultsGridControl(this.components);
            this.fld_dgvICProduct = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_lblLabel21 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel22 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel23 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel25 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel26 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel27 = new BOSComponent.BOSLabel(this.components);
            this.fld_lkeFK_GELocationID1 = new BOSComponent.BOSLookupEdit(this.components);
            this.fld_txtICProductNo1 = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtICProductName1 = new BOSComponent.BOSTextBox(this.components);
            this.fld_lkeFK_APSupplierID1 = new BOSComponent.BOSLookupEdit(this.components);
            this.fld_lkeFK_ICProductGroupID1 = new BOSComponent.BOSLookupEdit(this.components);
            this.fld_lkeLookupEdit1 = new BOSComponent.BOSLookupEdit(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcICProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvICProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_GELocationID1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtICProductNo1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtICProductName1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_APSupplierID1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_ICProductGroupID1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeLookupEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ScreenHelper
            // 
            this.ScreenHelper.HelpNamespace = null;
            // 
            // fld_dgcICProduct
            // 
            this.fld_dgcICProduct.AccessibleDescription = null;
            this.fld_dgcICProduct.AccessibleName = null;
            this.fld_dgcICProduct.AllowDrop = true;
            resources.ApplyResources(this.fld_dgcICProduct, "fld_dgcICProduct");
            this.fld_dgcICProduct.BackgroundImage = null;
            this.fld_dgcICProduct.BOSComment = "";
            this.fld_dgcICProduct.BOSDataMember = "";
            this.fld_dgcICProduct.BOSDataSource = "ICProducts";
            this.fld_dgcICProduct.BOSDescription = null;
            this.fld_dgcICProduct.BOSError = null;
            this.fld_dgcICProduct.BOSFieldGroup = "";
            this.fld_dgcICProduct.BOSFieldRelation = "";
            this.fld_dgcICProduct.BOSPrivilege = "";
            this.fld_dgcICProduct.BOSPropertyName = "";
            this.fld_dgcICProduct.EmbeddedNavigator.AccessibleDescription = null;
            this.fld_dgcICProduct.EmbeddedNavigator.AccessibleName = null;
            this.fld_dgcICProduct.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("fld_dgcICProduct.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.fld_dgcICProduct.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("fld_dgcICProduct.EmbeddedNavigator.Anchor")));
            this.fld_dgcICProduct.EmbeddedNavigator.BackgroundImage = null;
            this.fld_dgcICProduct.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("fld_dgcICProduct.EmbeddedNavigator.BackgroundImageLayout")));
            this.fld_dgcICProduct.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("fld_dgcICProduct.EmbeddedNavigator.ImeMode")));
            this.fld_dgcICProduct.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("fld_dgcICProduct.EmbeddedNavigator.TextLocation")));
            this.fld_dgcICProduct.EmbeddedNavigator.ToolTip = resources.GetString("fld_dgcICProduct.EmbeddedNavigator.ToolTip");
            this.fld_dgcICProduct.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("fld_dgcICProduct.EmbeddedNavigator.ToolTipIconType")));
            this.fld_dgcICProduct.EmbeddedNavigator.ToolTipTitle = resources.GetString("fld_dgcICProduct.EmbeddedNavigator.ToolTipTitle");
            this.ScreenHelper.SetHelpKeyword(this.fld_dgcICProduct, null);
            this.ScreenHelper.SetHelpNavigator(this.fld_dgcICProduct, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("fld_dgcICProduct.HelpNavigator"))));
            this.ScreenHelper.SetHelpString(this.fld_dgcICProduct, null);
            this.fld_dgcICProduct.MainView = this.fld_dgvICProduct;
            this.fld_dgcICProduct.Name = "fld_dgcICProduct";
            this.fld_dgcICProduct.Screen = null;
            this.fld_dgcICProduct.Tag = "SR";
            this.fld_dgcICProduct.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvICProduct});
            // 
            // fld_dgvICProduct
            // 
            resources.ApplyResources(this.fld_dgvICProduct, "fld_dgvICProduct");
            this.fld_dgvICProduct.GridControl = this.fld_dgcICProduct;
            this.fld_dgvICProduct.Name = "fld_dgvICProduct";
            this.fld_dgvICProduct.PaintStyleName = "Office2003";
            // 
            // fld_lblLabel21
            // 
            this.fld_lblLabel21.AccessibleDescription = null;
            this.fld_lblLabel21.AccessibleName = null;
            resources.ApplyResources(this.fld_lblLabel21, "fld_lblLabel21");
            this.fld_lblLabel21.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel21.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel21.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel21.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel21.BOSComment = "";
            this.fld_lblLabel21.BOSDataMember = "";
            this.fld_lblLabel21.BOSDataSource = "";
            this.fld_lblLabel21.BOSDescription = null;
            this.fld_lblLabel21.BOSError = null;
            this.fld_lblLabel21.BOSFieldGroup = "";
            this.fld_lblLabel21.BOSFieldRelation = "";
            this.fld_lblLabel21.BOSPrivilege = "";
            this.fld_lblLabel21.BOSPropertyName = "";
            this.ScreenHelper.SetHelpKeyword(this.fld_lblLabel21, null);
            this.ScreenHelper.SetHelpNavigator(this.fld_lblLabel21, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("fld_lblLabel21.HelpNavigator"))));
            this.ScreenHelper.SetHelpString(this.fld_lblLabel21, null);
            this.fld_lblLabel21.Name = "fld_lblLabel21";
            this.fld_lblLabel21.Screen = null;
            this.fld_lblLabel21.Tag = "SI";
            // 
            // fld_lblLabel22
            // 
            this.fld_lblLabel22.AccessibleDescription = null;
            this.fld_lblLabel22.AccessibleName = null;
            resources.ApplyResources(this.fld_lblLabel22, "fld_lblLabel22");
            this.fld_lblLabel22.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel22.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel22.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel22.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel22.BOSComment = "";
            this.fld_lblLabel22.BOSDataMember = "";
            this.fld_lblLabel22.BOSDataSource = "";
            this.fld_lblLabel22.BOSDescription = null;
            this.fld_lblLabel22.BOSError = null;
            this.fld_lblLabel22.BOSFieldGroup = "";
            this.fld_lblLabel22.BOSFieldRelation = "";
            this.fld_lblLabel22.BOSPrivilege = "";
            this.fld_lblLabel22.BOSPropertyName = "";
            this.ScreenHelper.SetHelpKeyword(this.fld_lblLabel22, null);
            this.ScreenHelper.SetHelpNavigator(this.fld_lblLabel22, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("fld_lblLabel22.HelpNavigator"))));
            this.ScreenHelper.SetHelpString(this.fld_lblLabel22, null);
            this.fld_lblLabel22.Name = "fld_lblLabel22";
            this.fld_lblLabel22.Screen = null;
            this.fld_lblLabel22.Tag = "SI";
            // 
            // fld_lblLabel23
            // 
            this.fld_lblLabel23.AccessibleDescription = null;
            this.fld_lblLabel23.AccessibleName = null;
            resources.ApplyResources(this.fld_lblLabel23, "fld_lblLabel23");
            this.fld_lblLabel23.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel23.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel23.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel23.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel23.BOSComment = "";
            this.fld_lblLabel23.BOSDataMember = "";
            this.fld_lblLabel23.BOSDataSource = "";
            this.fld_lblLabel23.BOSDescription = null;
            this.fld_lblLabel23.BOSError = null;
            this.fld_lblLabel23.BOSFieldGroup = "";
            this.fld_lblLabel23.BOSFieldRelation = "";
            this.fld_lblLabel23.BOSPrivilege = "";
            this.fld_lblLabel23.BOSPropertyName = "";
            this.ScreenHelper.SetHelpKeyword(this.fld_lblLabel23, null);
            this.ScreenHelper.SetHelpNavigator(this.fld_lblLabel23, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("fld_lblLabel23.HelpNavigator"))));
            this.ScreenHelper.SetHelpString(this.fld_lblLabel23, null);
            this.fld_lblLabel23.Name = "fld_lblLabel23";
            this.fld_lblLabel23.Screen = null;
            this.fld_lblLabel23.Tag = "SI";
            // 
            // fld_lblLabel25
            // 
            this.fld_lblLabel25.AccessibleDescription = null;
            this.fld_lblLabel25.AccessibleName = null;
            resources.ApplyResources(this.fld_lblLabel25, "fld_lblLabel25");
            this.fld_lblLabel25.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel25.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel25.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel25.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel25.BOSComment = "";
            this.fld_lblLabel25.BOSDataMember = "";
            this.fld_lblLabel25.BOSDataSource = "";
            this.fld_lblLabel25.BOSDescription = null;
            this.fld_lblLabel25.BOSError = null;
            this.fld_lblLabel25.BOSFieldGroup = "";
            this.fld_lblLabel25.BOSFieldRelation = "";
            this.fld_lblLabel25.BOSPrivilege = "";
            this.fld_lblLabel25.BOSPropertyName = "";
            this.ScreenHelper.SetHelpKeyword(this.fld_lblLabel25, null);
            this.ScreenHelper.SetHelpNavigator(this.fld_lblLabel25, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("fld_lblLabel25.HelpNavigator"))));
            this.ScreenHelper.SetHelpString(this.fld_lblLabel25, null);
            this.fld_lblLabel25.Name = "fld_lblLabel25";
            this.fld_lblLabel25.Screen = null;
            this.fld_lblLabel25.Tag = "SI";
            // 
            // fld_lblLabel26
            // 
            this.fld_lblLabel26.AccessibleDescription = null;
            this.fld_lblLabel26.AccessibleName = null;
            resources.ApplyResources(this.fld_lblLabel26, "fld_lblLabel26");
            this.fld_lblLabel26.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel26.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel26.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel26.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel26.BOSComment = "";
            this.fld_lblLabel26.BOSDataMember = "";
            this.fld_lblLabel26.BOSDataSource = "";
            this.fld_lblLabel26.BOSDescription = null;
            this.fld_lblLabel26.BOSError = null;
            this.fld_lblLabel26.BOSFieldGroup = "";
            this.fld_lblLabel26.BOSFieldRelation = "";
            this.fld_lblLabel26.BOSPrivilege = "";
            this.fld_lblLabel26.BOSPropertyName = "";
            this.ScreenHelper.SetHelpKeyword(this.fld_lblLabel26, null);
            this.ScreenHelper.SetHelpNavigator(this.fld_lblLabel26, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("fld_lblLabel26.HelpNavigator"))));
            this.ScreenHelper.SetHelpString(this.fld_lblLabel26, null);
            this.fld_lblLabel26.Name = "fld_lblLabel26";
            this.fld_lblLabel26.Screen = null;
            this.fld_lblLabel26.Tag = "SI";
            // 
            // fld_lblLabel27
            // 
            this.fld_lblLabel27.AccessibleDescription = null;
            this.fld_lblLabel27.AccessibleName = null;
            resources.ApplyResources(this.fld_lblLabel27, "fld_lblLabel27");
            this.fld_lblLabel27.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel27.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel27.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel27.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel27.BOSComment = "";
            this.fld_lblLabel27.BOSDataMember = "";
            this.fld_lblLabel27.BOSDataSource = "";
            this.fld_lblLabel27.BOSDescription = null;
            this.fld_lblLabel27.BOSError = null;
            this.fld_lblLabel27.BOSFieldGroup = "";
            this.fld_lblLabel27.BOSFieldRelation = "";
            this.fld_lblLabel27.BOSPrivilege = "";
            this.fld_lblLabel27.BOSPropertyName = "";
            this.ScreenHelper.SetHelpKeyword(this.fld_lblLabel27, null);
            this.ScreenHelper.SetHelpNavigator(this.fld_lblLabel27, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("fld_lblLabel27.HelpNavigator"))));
            this.ScreenHelper.SetHelpString(this.fld_lblLabel27, null);
            this.fld_lblLabel27.Name = "fld_lblLabel27";
            this.fld_lblLabel27.Screen = null;
            this.fld_lblLabel27.Tag = "SI";
            // 
            // fld_lkeFK_GELocationID1
            // 
            resources.ApplyResources(this.fld_lkeFK_GELocationID1, "fld_lkeFK_GELocationID1");
            this.fld_lkeFK_GELocationID1.BackgroundImage = null;
            this.fld_lkeFK_GELocationID1.BOSAllowAddNew = false;
            this.fld_lkeFK_GELocationID1.BOSAllowDummy = true;
            this.fld_lkeFK_GELocationID1.BOSComment = "";
            this.fld_lkeFK_GELocationID1.BOSDataMember = "FK_GELocationID";
            this.fld_lkeFK_GELocationID1.BOSDataSource = "ICProducts";
            this.fld_lkeFK_GELocationID1.BOSDescription = null;
            this.fld_lkeFK_GELocationID1.BOSError = null;
            this.fld_lkeFK_GELocationID1.BOSFieldGroup = "";
            this.fld_lkeFK_GELocationID1.BOSFieldParent = "";
            this.fld_lkeFK_GELocationID1.BOSFieldRelation = "";
            this.fld_lkeFK_GELocationID1.BOSPrivilege = "";
            this.fld_lkeFK_GELocationID1.BOSPropertyName = "EditValue";
            this.fld_lkeFK_GELocationID1.BOSSelectType = "";
            this.fld_lkeFK_GELocationID1.BOSSelectTypeValue = "";
            this.fld_lkeFK_GELocationID1.CurrentDisplayText = null;
            this.fld_lkeFK_GELocationID1.EditValue = null;
            this.ScreenHelper.SetHelpKeyword(this.fld_lkeFK_GELocationID1, null);
            this.ScreenHelper.SetHelpNavigator(this.fld_lkeFK_GELocationID1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("fld_lkeFK_GELocationID1.HelpNavigator"))));
            this.ScreenHelper.SetHelpString(this.fld_lkeFK_GELocationID1, null);
            this.fld_lkeFK_GELocationID1.Name = "fld_lkeFK_GELocationID1";
            this.fld_lkeFK_GELocationID1.Properties.AccessibleDescription = null;
            this.fld_lkeFK_GELocationID1.Properties.AccessibleName = null;
            this.fld_lkeFK_GELocationID1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeFK_GELocationID1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeFK_GELocationID1.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeFK_GELocationID1.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeFK_GELocationID1.Properties.AutoHeight = ((bool)(resources.GetObject("fld_lkeFK_GELocationID1.Properties.AutoHeight")));
            this.fld_lkeFK_GELocationID1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("fld_lkeFK_GELocationID1.Properties.Buttons"))))});
            this.fld_lkeFK_GELocationID1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("fld_lkeFK_GELocationID1.Properties.Columns"), resources.GetString("fld_lkeFK_GELocationID1.Properties.Columns1"))});
            this.fld_lkeFK_GELocationID1.Properties.DisplayMember = "GELocationName";
            this.fld_lkeFK_GELocationID1.Properties.NullText = resources.GetString("fld_lkeFK_GELocationID1.Properties.NullText");
            this.fld_lkeFK_GELocationID1.Properties.NullValuePrompt = resources.GetString("fld_lkeFK_GELocationID1.Properties.NullValuePrompt");
            this.fld_lkeFK_GELocationID1.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("fld_lkeFK_GELocationID1.Properties.NullValuePromptShowForEmptyValue")));
            this.fld_lkeFK_GELocationID1.Properties.PopupWidth = 40;
            this.fld_lkeFK_GELocationID1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeFK_GELocationID1.Properties.ValueMember = "GELocationID";
            this.fld_lkeFK_GELocationID1.Screen = null;
            this.fld_lkeFK_GELocationID1.Tag = "SC";
            // 
            // fld_txtICProductNo1
            // 
            resources.ApplyResources(this.fld_txtICProductNo1, "fld_txtICProductNo1");
            this.fld_txtICProductNo1.BackgroundImage = null;
            this.fld_txtICProductNo1.BOSComment = "";
            this.fld_txtICProductNo1.BOSDataMember = "ICProductNo";
            this.fld_txtICProductNo1.BOSDataSource = "ICProducts";
            this.fld_txtICProductNo1.BOSDescription = null;
            this.fld_txtICProductNo1.BOSError = null;
            this.fld_txtICProductNo1.BOSFieldGroup = "";
            this.fld_txtICProductNo1.BOSFieldRelation = "";
            this.fld_txtICProductNo1.BOSPrivilege = "";
            this.fld_txtICProductNo1.BOSPropertyName = "Text";
            this.ScreenHelper.SetHelpKeyword(this.fld_txtICProductNo1, null);
            this.ScreenHelper.SetHelpNavigator(this.fld_txtICProductNo1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("fld_txtICProductNo1.HelpNavigator"))));
            this.ScreenHelper.SetHelpString(this.fld_txtICProductNo1, null);
            this.fld_txtICProductNo1.Name = "fld_txtICProductNo1";
            this.fld_txtICProductNo1.Properties.AccessibleDescription = null;
            this.fld_txtICProductNo1.Properties.AccessibleName = null;
            this.fld_txtICProductNo1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtICProductNo1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtICProductNo1.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtICProductNo1.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtICProductNo1.Properties.AutoHeight = ((bool)(resources.GetObject("fld_txtICProductNo1.Properties.AutoHeight")));
            this.fld_txtICProductNo1.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("fld_txtICProductNo1.Properties.Mask.AutoComplete")));
            this.fld_txtICProductNo1.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("fld_txtICProductNo1.Properties.Mask.BeepOnError")));
            this.fld_txtICProductNo1.Properties.Mask.EditMask = resources.GetString("fld_txtICProductNo1.Properties.Mask.EditMask");
            this.fld_txtICProductNo1.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("fld_txtICProductNo1.Properties.Mask.IgnoreMaskBlank")));
            this.fld_txtICProductNo1.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("fld_txtICProductNo1.Properties.Mask.MaskType")));
            this.fld_txtICProductNo1.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("fld_txtICProductNo1.Properties.Mask.PlaceHolder")));
            this.fld_txtICProductNo1.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("fld_txtICProductNo1.Properties.Mask.SaveLiteral")));
            this.fld_txtICProductNo1.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("fld_txtICProductNo1.Properties.Mask.ShowPlaceHolders")));
            this.fld_txtICProductNo1.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("fld_txtICProductNo1.Properties.Mask.UseMaskAsDisplayFormat")));
            this.fld_txtICProductNo1.Properties.NullValuePrompt = resources.GetString("fld_txtICProductNo1.Properties.NullValuePrompt");
            this.fld_txtICProductNo1.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("fld_txtICProductNo1.Properties.NullValuePromptShowForEmptyValue")));
            this.fld_txtICProductNo1.Screen = null;
            this.fld_txtICProductNo1.Tag = "SC";
            // 
            // fld_txtICProductName1
            // 
            resources.ApplyResources(this.fld_txtICProductName1, "fld_txtICProductName1");
            this.fld_txtICProductName1.BackgroundImage = null;
            this.fld_txtICProductName1.BOSComment = "";
            this.fld_txtICProductName1.BOSDataMember = "ICProductName";
            this.fld_txtICProductName1.BOSDataSource = "ICProducts";
            this.fld_txtICProductName1.BOSDescription = null;
            this.fld_txtICProductName1.BOSError = null;
            this.fld_txtICProductName1.BOSFieldGroup = "";
            this.fld_txtICProductName1.BOSFieldRelation = "";
            this.fld_txtICProductName1.BOSPrivilege = "";
            this.fld_txtICProductName1.BOSPropertyName = "Text";
            this.ScreenHelper.SetHelpKeyword(this.fld_txtICProductName1, null);
            this.ScreenHelper.SetHelpNavigator(this.fld_txtICProductName1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("fld_txtICProductName1.HelpNavigator"))));
            this.ScreenHelper.SetHelpString(this.fld_txtICProductName1, null);
            this.fld_txtICProductName1.Name = "fld_txtICProductName1";
            this.fld_txtICProductName1.Properties.AccessibleDescription = null;
            this.fld_txtICProductName1.Properties.AccessibleName = null;
            this.fld_txtICProductName1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtICProductName1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtICProductName1.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtICProductName1.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtICProductName1.Properties.AutoHeight = ((bool)(resources.GetObject("fld_txtICProductName1.Properties.AutoHeight")));
            this.fld_txtICProductName1.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("fld_txtICProductName1.Properties.Mask.AutoComplete")));
            this.fld_txtICProductName1.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("fld_txtICProductName1.Properties.Mask.BeepOnError")));
            this.fld_txtICProductName1.Properties.Mask.EditMask = resources.GetString("fld_txtICProductName1.Properties.Mask.EditMask");
            this.fld_txtICProductName1.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("fld_txtICProductName1.Properties.Mask.IgnoreMaskBlank")));
            this.fld_txtICProductName1.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("fld_txtICProductName1.Properties.Mask.MaskType")));
            this.fld_txtICProductName1.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("fld_txtICProductName1.Properties.Mask.PlaceHolder")));
            this.fld_txtICProductName1.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("fld_txtICProductName1.Properties.Mask.SaveLiteral")));
            this.fld_txtICProductName1.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("fld_txtICProductName1.Properties.Mask.ShowPlaceHolders")));
            this.fld_txtICProductName1.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("fld_txtICProductName1.Properties.Mask.UseMaskAsDisplayFormat")));
            this.fld_txtICProductName1.Properties.NullValuePrompt = resources.GetString("fld_txtICProductName1.Properties.NullValuePrompt");
            this.fld_txtICProductName1.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("fld_txtICProductName1.Properties.NullValuePromptShowForEmptyValue")));
            this.fld_txtICProductName1.Screen = null;
            this.fld_txtICProductName1.Tag = "SC";
            // 
            // fld_lkeFK_APSupplierID1
            // 
            resources.ApplyResources(this.fld_lkeFK_APSupplierID1, "fld_lkeFK_APSupplierID1");
            this.fld_lkeFK_APSupplierID1.BackgroundImage = null;
            this.fld_lkeFK_APSupplierID1.BOSAllowAddNew = false;
            this.fld_lkeFK_APSupplierID1.BOSAllowDummy = true;
            this.fld_lkeFK_APSupplierID1.BOSComment = "";
            this.fld_lkeFK_APSupplierID1.BOSDataMember = "FK_APSupplierID";
            this.fld_lkeFK_APSupplierID1.BOSDataSource = "ICProducts";
            this.fld_lkeFK_APSupplierID1.BOSDescription = null;
            this.fld_lkeFK_APSupplierID1.BOSError = null;
            this.fld_lkeFK_APSupplierID1.BOSFieldGroup = "";
            this.fld_lkeFK_APSupplierID1.BOSFieldParent = "";
            this.fld_lkeFK_APSupplierID1.BOSFieldRelation = "";
            this.fld_lkeFK_APSupplierID1.BOSPrivilege = "";
            this.fld_lkeFK_APSupplierID1.BOSPropertyName = "EditValue";
            this.fld_lkeFK_APSupplierID1.BOSSelectType = "";
            this.fld_lkeFK_APSupplierID1.BOSSelectTypeValue = "";
            this.fld_lkeFK_APSupplierID1.CurrentDisplayText = null;
            this.fld_lkeFK_APSupplierID1.EditValue = null;
            this.ScreenHelper.SetHelpKeyword(this.fld_lkeFK_APSupplierID1, null);
            this.ScreenHelper.SetHelpNavigator(this.fld_lkeFK_APSupplierID1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("fld_lkeFK_APSupplierID1.HelpNavigator"))));
            this.ScreenHelper.SetHelpString(this.fld_lkeFK_APSupplierID1, null);
            this.fld_lkeFK_APSupplierID1.Name = "fld_lkeFK_APSupplierID1";
            this.fld_lkeFK_APSupplierID1.Properties.AccessibleDescription = null;
            this.fld_lkeFK_APSupplierID1.Properties.AccessibleName = null;
            this.fld_lkeFK_APSupplierID1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeFK_APSupplierID1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeFK_APSupplierID1.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeFK_APSupplierID1.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeFK_APSupplierID1.Properties.AutoHeight = ((bool)(resources.GetObject("fld_lkeFK_APSupplierID1.Properties.AutoHeight")));
            this.fld_lkeFK_APSupplierID1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("fld_lkeFK_APSupplierID1.Properties.Buttons"))))});
            this.fld_lkeFK_APSupplierID1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("fld_lkeFK_APSupplierID1.Properties.Columns"), resources.GetString("fld_lkeFK_APSupplierID1.Properties.Columns1"), ((int)(resources.GetObject("fld_lkeFK_APSupplierID1.Properties.Columns2"))), ((DevExpress.Utils.FormatType)(resources.GetObject("fld_lkeFK_APSupplierID1.Properties.Columns3"))), resources.GetString("fld_lkeFK_APSupplierID1.Properties.Columns4"), ((bool)(resources.GetObject("fld_lkeFK_APSupplierID1.Properties.Columns5"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("fld_lkeFK_APSupplierID1.Properties.Columns6")))),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("fld_lkeFK_APSupplierID1.Properties.Columns7"), resources.GetString("fld_lkeFK_APSupplierID1.Properties.Columns8"))});
            this.fld_lkeFK_APSupplierID1.Properties.DisplayMember = "APSupplierName";
            this.fld_lkeFK_APSupplierID1.Properties.NullText = resources.GetString("fld_lkeFK_APSupplierID1.Properties.NullText");
            this.fld_lkeFK_APSupplierID1.Properties.NullValuePrompt = resources.GetString("fld_lkeFK_APSupplierID1.Properties.NullValuePrompt");
            this.fld_lkeFK_APSupplierID1.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("fld_lkeFK_APSupplierID1.Properties.NullValuePromptShowForEmptyValue")));
            this.fld_lkeFK_APSupplierID1.Properties.PopupWidth = 40;
            this.fld_lkeFK_APSupplierID1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeFK_APSupplierID1.Properties.ValueMember = "APSupplierID";
            this.fld_lkeFK_APSupplierID1.Screen = null;
            this.fld_lkeFK_APSupplierID1.Tag = "SC";
            // 
            // fld_lkeFK_ICProductGroupID1
            // 
            resources.ApplyResources(this.fld_lkeFK_ICProductGroupID1, "fld_lkeFK_ICProductGroupID1");
            this.fld_lkeFK_ICProductGroupID1.BackgroundImage = null;
            this.fld_lkeFK_ICProductGroupID1.BOSAllowAddNew = false;
            this.fld_lkeFK_ICProductGroupID1.BOSAllowDummy = true;
            this.fld_lkeFK_ICProductGroupID1.BOSComment = "";
            this.fld_lkeFK_ICProductGroupID1.BOSDataMember = "FK_ICProductGroupID";
            this.fld_lkeFK_ICProductGroupID1.BOSDataSource = "ICProducts";
            this.fld_lkeFK_ICProductGroupID1.BOSDescription = null;
            this.fld_lkeFK_ICProductGroupID1.BOSError = null;
            this.fld_lkeFK_ICProductGroupID1.BOSFieldGroup = "";
            this.fld_lkeFK_ICProductGroupID1.BOSFieldParent = "";
            this.fld_lkeFK_ICProductGroupID1.BOSFieldRelation = "";
            this.fld_lkeFK_ICProductGroupID1.BOSPrivilege = "";
            this.fld_lkeFK_ICProductGroupID1.BOSPropertyName = "EditValue";
            this.fld_lkeFK_ICProductGroupID1.BOSSelectType = "";
            this.fld_lkeFK_ICProductGroupID1.BOSSelectTypeValue = "";
            this.fld_lkeFK_ICProductGroupID1.CurrentDisplayText = null;
            this.fld_lkeFK_ICProductGroupID1.EditValue = null;
            this.ScreenHelper.SetHelpKeyword(this.fld_lkeFK_ICProductGroupID1, null);
            this.ScreenHelper.SetHelpNavigator(this.fld_lkeFK_ICProductGroupID1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("fld_lkeFK_ICProductGroupID1.HelpNavigator"))));
            this.ScreenHelper.SetHelpString(this.fld_lkeFK_ICProductGroupID1, null);
            this.fld_lkeFK_ICProductGroupID1.Name = "fld_lkeFK_ICProductGroupID1";
            this.fld_lkeFK_ICProductGroupID1.Properties.AccessibleDescription = null;
            this.fld_lkeFK_ICProductGroupID1.Properties.AccessibleName = null;
            this.fld_lkeFK_ICProductGroupID1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeFK_ICProductGroupID1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeFK_ICProductGroupID1.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeFK_ICProductGroupID1.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeFK_ICProductGroupID1.Properties.AutoHeight = ((bool)(resources.GetObject("fld_lkeFK_ICProductGroupID1.Properties.AutoHeight")));
            this.fld_lkeFK_ICProductGroupID1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("fld_lkeFK_ICProductGroupID1.Properties.Buttons"))))});
            this.fld_lkeFK_ICProductGroupID1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("fld_lkeFK_ICProductGroupID1.Properties.Columns"), resources.GetString("fld_lkeFK_ICProductGroupID1.Properties.Columns1"), ((int)(resources.GetObject("fld_lkeFK_ICProductGroupID1.Properties.Columns2"))), ((DevExpress.Utils.FormatType)(resources.GetObject("fld_lkeFK_ICProductGroupID1.Properties.Columns3"))), resources.GetString("fld_lkeFK_ICProductGroupID1.Properties.Columns4"), ((bool)(resources.GetObject("fld_lkeFK_ICProductGroupID1.Properties.Columns5"))), ((DevExpress.Utils.HorzAlignment)(resources.GetObject("fld_lkeFK_ICProductGroupID1.Properties.Columns6")))),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("fld_lkeFK_ICProductGroupID1.Properties.Columns7"), resources.GetString("fld_lkeFK_ICProductGroupID1.Properties.Columns8"))});
            this.fld_lkeFK_ICProductGroupID1.Properties.DisplayMember = "ICProductGroupName";
            this.fld_lkeFK_ICProductGroupID1.Properties.NullText = resources.GetString("fld_lkeFK_ICProductGroupID1.Properties.NullText");
            this.fld_lkeFK_ICProductGroupID1.Properties.NullValuePrompt = resources.GetString("fld_lkeFK_ICProductGroupID1.Properties.NullValuePrompt");
            this.fld_lkeFK_ICProductGroupID1.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("fld_lkeFK_ICProductGroupID1.Properties.NullValuePromptShowForEmptyValue")));
            this.fld_lkeFK_ICProductGroupID1.Properties.PopupWidth = 40;
            this.fld_lkeFK_ICProductGroupID1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeFK_ICProductGroupID1.Properties.ValueMember = "ICProductGroupID";
            this.fld_lkeFK_ICProductGroupID1.Screen = null;
            this.fld_lkeFK_ICProductGroupID1.Tag = "SC";
            // 
            // fld_lkeLookupEdit1
            // 
            resources.ApplyResources(this.fld_lkeLookupEdit1, "fld_lkeLookupEdit1");
            this.fld_lkeLookupEdit1.BackgroundImage = null;
            this.fld_lkeLookupEdit1.BOSAllowAddNew = false;
            this.fld_lkeLookupEdit1.BOSAllowDummy = true;
            this.fld_lkeLookupEdit1.BOSComment = "";
            this.fld_lkeLookupEdit1.BOSDataMember = "ICProductType";
            this.fld_lkeLookupEdit1.BOSDataSource = "ICProducts";
            this.fld_lkeLookupEdit1.BOSDescription = null;
            this.fld_lkeLookupEdit1.BOSError = null;
            this.fld_lkeLookupEdit1.BOSFieldGroup = "";
            this.fld_lkeLookupEdit1.BOSFieldParent = "";
            this.fld_lkeLookupEdit1.BOSFieldRelation = "";
            this.fld_lkeLookupEdit1.BOSPrivilege = "";
            this.fld_lkeLookupEdit1.BOSPropertyName = "EditValue";
            this.fld_lkeLookupEdit1.BOSSelectType = "";
            this.fld_lkeLookupEdit1.BOSSelectTypeValue = "";
            this.fld_lkeLookupEdit1.CurrentDisplayText = null;
            this.fld_lkeLookupEdit1.EditValue = null;
            this.ScreenHelper.SetHelpKeyword(this.fld_lkeLookupEdit1, null);
            this.ScreenHelper.SetHelpNavigator(this.fld_lkeLookupEdit1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("fld_lkeLookupEdit1.HelpNavigator"))));
            this.ScreenHelper.SetHelpString(this.fld_lkeLookupEdit1, null);
            this.fld_lkeLookupEdit1.Name = "fld_lkeLookupEdit1";
            this.fld_lkeLookupEdit1.Properties.AccessibleDescription = null;
            this.fld_lkeLookupEdit1.Properties.AccessibleName = null;
            this.fld_lkeLookupEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeLookupEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeLookupEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeLookupEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeLookupEdit1.Properties.AutoHeight = ((bool)(resources.GetObject("fld_lkeLookupEdit1.Properties.AutoHeight")));
            this.fld_lkeLookupEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("fld_lkeLookupEdit1.Properties.Buttons"))))});
            this.fld_lkeLookupEdit1.Properties.NullText = resources.GetString("fld_lkeLookupEdit1.Properties.NullText");
            this.fld_lkeLookupEdit1.Properties.NullValuePrompt = resources.GetString("fld_lkeLookupEdit1.Properties.NullValuePrompt");
            this.fld_lkeLookupEdit1.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("fld_lkeLookupEdit1.Properties.NullValuePromptShowForEmptyValue")));
            this.fld_lkeLookupEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeLookupEdit1.Screen = null;
            this.fld_lkeLookupEdit1.Tag = "SC";
            // 
            // SMICPR100
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.fld_dgcICProduct);
            this.Controls.Add(this.fld_lblLabel21);
            this.Controls.Add(this.fld_lblLabel22);
            this.Controls.Add(this.fld_lblLabel23);
            this.Controls.Add(this.fld_lblLabel25);
            this.Controls.Add(this.fld_lblLabel26);
            this.Controls.Add(this.fld_lblLabel27);
            this.Controls.Add(this.fld_lkeFK_GELocationID1);
            this.Controls.Add(this.fld_txtICProductNo1);
            this.Controls.Add(this.fld_txtICProductName1);
            this.Controls.Add(this.fld_lkeFK_APSupplierID1);
            this.Controls.Add(this.fld_lkeFK_ICProductGroupID1);
            this.Controls.Add(this.fld_lkeLookupEdit1);
            this.ScreenHelper.SetHelpKeyword(this, null);
            this.ScreenHelper.SetHelpNavigator(this, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("$this.HelpNavigator"))));
            this.ScreenHelper.SetHelpString(this, null);
            this.Icon = null;
            this.Name = "SMICPR100";
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcICProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvICProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_GELocationID1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtICProductNo1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtICProductName1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_APSupplierID1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_ICProductGroupID1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeLookupEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private IContainer components;
	}
}
