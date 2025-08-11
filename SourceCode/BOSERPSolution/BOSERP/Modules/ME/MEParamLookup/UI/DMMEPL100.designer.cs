using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSComponent;

namespace BOSERP.Modules.MEParamLookup.UI
{
	/// <summary>
	/// Summary description for DMMEPL100
	/// </summary>
	partial class DMMEPL100
	{
		private MEParamLookupDatasGridControl fld_dgcMEParamLookupDatas;
		private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvGridControl;
		private BOSComponent.BOSTextBox fld_txtMEParamLookupNo1;
		private BOSComponent.BOSTextBox fld_txtMEParamLookupName1;
		private BOSComponent.BOSLabel fld_lblLabel3;
		private BOSComponent.BOSLabel fld_lblLabel4;
		private BOSComponent.BOSLabel fld_lblLabel5;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMMEPL100));
            this.fld_dgcMEParamLookupDatas = new BOSERP.Modules.MEParamLookup.MEParamLookupDatasGridControl();
            this.fld_dgvGridControl = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_txtMEParamLookupNo1 = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtMEParamLookupName1 = new BOSComponent.BOSTextBox(this.components);
            this.fld_lblLabel3 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel4 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel5 = new BOSComponent.BOSLabel(this.components);
            this.bosPanel1 = new BOSComponent.BOSPanel(this.components);
            this.fld_chkMEParamLookupPart = new BOSComponent.BOSCheckEdit(this.components);
            this.fld_chkMEParamLookupSort = new BOSComponent.BOSCheckEdit(this.components);
            this.bosTextBox1 = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtMEParamLookupMaximumSelect = new BOSComponent.BOSTextBox(this.components);
            this.fld_lblMEParamLookupMaximumSelect = new BOSComponent.BOSLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEParamLookupDatas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamLookupNo1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamLookupName1.Properties)).BeginInit();
            this.bosPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkMEParamLookupPart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkMEParamLookupSort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosTextBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamLookupMaximumSelect.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_dgcMEParamLookupDatas
            // 
            this.fld_dgcMEParamLookupDatas.AllowDrop = true;
            this.fld_dgcMEParamLookupDatas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcMEParamLookupDatas.BOSComment = "";
            this.fld_dgcMEParamLookupDatas.BOSDataMember = "";
            this.fld_dgcMEParamLookupDatas.BOSDataSource = "MEParamLookupDatas";
            this.fld_dgcMEParamLookupDatas.BOSDescription = null;
            this.fld_dgcMEParamLookupDatas.BOSError = null;
            this.fld_dgcMEParamLookupDatas.BOSFieldGroup = "";
            this.fld_dgcMEParamLookupDatas.BOSFieldRelation = "";
            this.fld_dgcMEParamLookupDatas.BOSGridType = null;
            this.fld_dgcMEParamLookupDatas.BOSPrivilege = "";
            this.fld_dgcMEParamLookupDatas.BOSPropertyName = "";
            this.fld_dgcMEParamLookupDatas.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMEParamLookupDatas.Location = new System.Drawing.Point(8, 83);
            this.fld_dgcMEParamLookupDatas.MainView = this.fld_dgvGridControl;
            this.fld_dgcMEParamLookupDatas.Name = "fld_dgcMEParamLookupDatas";
            this.fld_dgcMEParamLookupDatas.PrintReport = false;
            this.fld_dgcMEParamLookupDatas.Screen = null;
            this.fld_dgcMEParamLookupDatas.Size = new System.Drawing.Size(1017, 424);
            this.fld_dgcMEParamLookupDatas.TabIndex = 10;
            this.fld_dgcMEParamLookupDatas.Tag = "DC";
            this.fld_dgcMEParamLookupDatas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvGridControl});
            // 
            // fld_dgvGridControl
            // 
            this.fld_dgvGridControl.GridControl = this.fld_dgcMEParamLookupDatas;
            this.fld_dgvGridControl.Name = "fld_dgvGridControl";
            this.fld_dgvGridControl.PaintStyleName = "Office2003";
            // 
            // fld_txtMEParamLookupNo1
            // 
            this.fld_txtMEParamLookupNo1.BOSComment = "";
            this.fld_txtMEParamLookupNo1.BOSDataMember = "MEParamLookupNo";
            this.fld_txtMEParamLookupNo1.BOSDataSource = "MEParamLookups";
            this.fld_txtMEParamLookupNo1.BOSDescription = null;
            this.fld_txtMEParamLookupNo1.BOSError = null;
            this.fld_txtMEParamLookupNo1.BOSFieldGroup = "";
            this.fld_txtMEParamLookupNo1.BOSFieldRelation = "";
            this.fld_txtMEParamLookupNo1.BOSPrivilege = "";
            this.fld_txtMEParamLookupNo1.BOSPropertyName = "Text";
            this.fld_txtMEParamLookupNo1.EditValue = "";
            this.fld_txtMEParamLookupNo1.Location = new System.Drawing.Point(56, 18);
            this.fld_txtMEParamLookupNo1.Name = "fld_txtMEParamLookupNo1";
            this.fld_txtMEParamLookupNo1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEParamLookupNo1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEParamLookupNo1.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEParamLookupNo1.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEParamLookupNo1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEParamLookupNo1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEParamLookupNo1.Screen = null;
            this.fld_txtMEParamLookupNo1.Size = new System.Drawing.Size(296, 20);
            this.fld_txtMEParamLookupNo1.TabIndex = 0;
            this.fld_txtMEParamLookupNo1.Tag = "DC";
            // 
            // fld_txtMEParamLookupName1
            // 
            this.fld_txtMEParamLookupName1.BOSComment = "";
            this.fld_txtMEParamLookupName1.BOSDataMember = "MEParamLookupName";
            this.fld_txtMEParamLookupName1.BOSDataSource = "MEParamLookups";
            this.fld_txtMEParamLookupName1.BOSDescription = null;
            this.fld_txtMEParamLookupName1.BOSError = null;
            this.fld_txtMEParamLookupName1.BOSFieldGroup = "";
            this.fld_txtMEParamLookupName1.BOSFieldRelation = "";
            this.fld_txtMEParamLookupName1.BOSPrivilege = "";
            this.fld_txtMEParamLookupName1.BOSPropertyName = "Text";
            this.fld_txtMEParamLookupName1.EditValue = "";
            this.fld_txtMEParamLookupName1.Location = new System.Drawing.Point(56, 47);
            this.fld_txtMEParamLookupName1.Name = "fld_txtMEParamLookupName1";
            this.fld_txtMEParamLookupName1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEParamLookupName1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEParamLookupName1.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEParamLookupName1.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEParamLookupName1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEParamLookupName1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEParamLookupName1.Screen = null;
            this.fld_txtMEParamLookupName1.Size = new System.Drawing.Size(493, 20);
            this.fld_txtMEParamLookupName1.TabIndex = 1;
            this.fld_txtMEParamLookupName1.Tag = "DC";
            // 
            // fld_lblLabel3
            // 
            this.fld_lblLabel3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel3.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel3.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel3.BOSComment = "";
            this.fld_lblLabel3.BOSDataMember = "";
            this.fld_lblLabel3.BOSDataSource = "";
            this.fld_lblLabel3.BOSDescription = null;
            this.fld_lblLabel3.BOSError = null;
            this.fld_lblLabel3.BOSFieldGroup = "";
            this.fld_lblLabel3.BOSFieldRelation = "";
            this.fld_lblLabel3.BOSPrivilege = "";
            this.fld_lblLabel3.BOSPropertyName = "";
            this.fld_lblLabel3.Location = new System.Drawing.Point(19, 22);
            this.fld_lblLabel3.Name = "fld_lblLabel3";
            this.fld_lblLabel3.Screen = null;
            this.fld_lblLabel3.Size = new System.Drawing.Size(14, 13);
            this.fld_lblLabel3.TabIndex = 7;
            this.fld_lblLabel3.Tag = "Empty";
            this.fld_lblLabel3.Text = "Mã";
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
            this.fld_lblLabel4.Location = new System.Drawing.Point(18, 51);
            this.fld_lblLabel4.Name = "fld_lblLabel4";
            this.fld_lblLabel4.Screen = null;
            this.fld_lblLabel4.Size = new System.Drawing.Size(18, 13);
            this.fld_lblLabel4.TabIndex = 8;
            this.fld_lblLabel4.Tag = "Empty";
            this.fld_lblLabel4.Text = "Tên";
            // 
            // fld_lblLabel5
            // 
            this.fld_lblLabel5.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel5.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel5.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel5.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel5.BOSComment = "";
            this.fld_lblLabel5.BOSDataMember = "";
            this.fld_lblLabel5.BOSDataSource = "";
            this.fld_lblLabel5.BOSDescription = null;
            this.fld_lblLabel5.BOSError = null;
            this.fld_lblLabel5.BOSFieldGroup = "";
            this.fld_lblLabel5.BOSFieldRelation = "";
            this.fld_lblLabel5.BOSPrivilege = "";
            this.fld_lblLabel5.BOSPropertyName = "";
            this.fld_lblLabel5.Location = new System.Drawing.Point(370, 22);
            this.fld_lblLabel5.Name = "fld_lblLabel5";
            this.fld_lblLabel5.Screen = null;
            this.fld_lblLabel5.Size = new System.Drawing.Size(133, 13);
            this.fld_lblLabel5.TabIndex = 2;
            this.fld_lblLabel5.Tag = "Empty";
            this.fld_lblLabel5.Text = "Tự động gom nhóm đến cấp";
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
            this.bosPanel1.Controls.Add(this.fld_txtMEParamLookupMaximumSelect);
            this.bosPanel1.Controls.Add(this.fld_lblMEParamLookupMaximumSelect);
            this.bosPanel1.Controls.Add(this.fld_chkMEParamLookupPart);
            this.bosPanel1.Controls.Add(this.fld_chkMEParamLookupSort);
            this.bosPanel1.Controls.Add(this.bosTextBox1);
            this.bosPanel1.Controls.Add(this.fld_dgcMEParamLookupDatas);
            this.bosPanel1.Controls.Add(this.fld_lblLabel5);
            this.bosPanel1.Controls.Add(this.fld_lblLabel4);
            this.bosPanel1.Controls.Add(this.fld_txtMEParamLookupNo1);
            this.bosPanel1.Controls.Add(this.fld_lblLabel3);
            this.bosPanel1.Controls.Add(this.fld_txtMEParamLookupName1);
            this.bosPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bosPanel1.Location = new System.Drawing.Point(0, 0);
            this.bosPanel1.Name = "bosPanel1";
            this.bosPanel1.Screen = null;
            this.bosPanel1.Size = new System.Drawing.Size(1032, 510);
            this.bosPanel1.TabIndex = 84;
            // 
            // fld_chkMEParamLookupPart
            // 
            this.fld_chkMEParamLookupPart.BOSComment = "";
            this.fld_chkMEParamLookupPart.BOSDataMember = "MEParamLookupPart";
            this.fld_chkMEParamLookupPart.BOSDataSource = "MEParamLookups";
            this.fld_chkMEParamLookupPart.BOSDescription = null;
            this.fld_chkMEParamLookupPart.BOSError = null;
            this.fld_chkMEParamLookupPart.BOSFieldGroup = "";
            this.fld_chkMEParamLookupPart.BOSFieldRelation = "";
            this.fld_chkMEParamLookupPart.BOSPrivilege = "";
            this.fld_chkMEParamLookupPart.BOSPropertyName = "EditValue";
            this.fld_chkMEParamLookupPart.Location = new System.Drawing.Point(564, 46);
            this.fld_chkMEParamLookupPart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fld_chkMEParamLookupPart.Name = "fld_chkMEParamLookupPart";
            this.fld_chkMEParamLookupPart.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.fld_chkMEParamLookupPart.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.fld_chkMEParamLookupPart.Properties.Appearance.Options.UseBackColor = true;
            this.fld_chkMEParamLookupPart.Properties.Appearance.Options.UseForeColor = true;
            this.fld_chkMEParamLookupPart.Properties.Caption = "Dữ liệu theo thẻ";
            this.fld_chkMEParamLookupPart.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_chkMEParamLookupPart, true);
            this.fld_chkMEParamLookupPart.Size = new System.Drawing.Size(99, 19);
            this.fld_chkMEParamLookupPart.TabIndex = 73;
            this.fld_chkMEParamLookupPart.Tag = "DC";
            // 
            // fld_chkMEParamLookupSort
            // 
            this.fld_chkMEParamLookupSort.BOSComment = "";
            this.fld_chkMEParamLookupSort.BOSDataMember = "MEParamLookupSort";
            this.fld_chkMEParamLookupSort.BOSDataSource = "MEParamLookups";
            this.fld_chkMEParamLookupSort.BOSDescription = null;
            this.fld_chkMEParamLookupSort.BOSError = null;
            this.fld_chkMEParamLookupSort.BOSFieldGroup = "";
            this.fld_chkMEParamLookupSort.BOSFieldRelation = "";
            this.fld_chkMEParamLookupSort.BOSPrivilege = "";
            this.fld_chkMEParamLookupSort.BOSPropertyName = "EditValue";
            this.fld_chkMEParamLookupSort.EditValue = true;
            this.fld_chkMEParamLookupSort.Location = new System.Drawing.Point(564, 20);
            this.fld_chkMEParamLookupSort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fld_chkMEParamLookupSort.Name = "fld_chkMEParamLookupSort";
            this.fld_chkMEParamLookupSort.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.fld_chkMEParamLookupSort.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.fld_chkMEParamLookupSort.Properties.Appearance.Options.UseBackColor = true;
            this.fld_chkMEParamLookupSort.Properties.Appearance.Options.UseForeColor = true;
            this.fld_chkMEParamLookupSort.Properties.Caption = "Sắp xếp tự động";
            this.fld_chkMEParamLookupSort.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_chkMEParamLookupSort, true);
            this.fld_chkMEParamLookupSort.Size = new System.Drawing.Size(99, 19);
            this.fld_chkMEParamLookupSort.TabIndex = 72;
            this.fld_chkMEParamLookupSort.Tag = "DC";
            // 
            // bosTextBox1
            // 
            this.bosTextBox1.BOSComment = "";
            this.bosTextBox1.BOSDataMember = "MEParamLookupAutoGroupLevel";
            this.bosTextBox1.BOSDataSource = "MEParamLookups";
            this.bosTextBox1.BOSDescription = null;
            this.bosTextBox1.BOSError = null;
            this.bosTextBox1.BOSFieldGroup = "";
            this.bosTextBox1.BOSFieldRelation = "";
            this.bosTextBox1.BOSPrivilege = "";
            this.bosTextBox1.BOSPropertyName = "Text";
            this.bosTextBox1.EditValue = "";
            this.bosTextBox1.Location = new System.Drawing.Point(509, 19);
            this.bosTextBox1.Name = "bosTextBox1";
            this.bosTextBox1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosTextBox1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosTextBox1.Properties.Appearance.Options.UseBackColor = true;
            this.bosTextBox1.Properties.Appearance.Options.UseForeColor = true;
            this.bosTextBox1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.bosTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bosTextBox1.Screen = null;
            this.bosTextBox1.Size = new System.Drawing.Size(40, 20);
            this.bosTextBox1.TabIndex = 71;
            this.bosTextBox1.Tag = "DC";
            // 
            // fld_txtMEParamLookupMaximumSelect
            // 
            this.fld_txtMEParamLookupMaximumSelect.BOSComment = "";
            this.fld_txtMEParamLookupMaximumSelect.BOSDataMember = "MEParamLookupMaximumSelect";
            this.fld_txtMEParamLookupMaximumSelect.BOSDataSource = "MEParamLookups";
            this.fld_txtMEParamLookupMaximumSelect.BOSDescription = null;
            this.fld_txtMEParamLookupMaximumSelect.BOSError = null;
            this.fld_txtMEParamLookupMaximumSelect.BOSFieldGroup = "";
            this.fld_txtMEParamLookupMaximumSelect.BOSFieldRelation = "";
            this.fld_txtMEParamLookupMaximumSelect.BOSPrivilege = "";
            this.fld_txtMEParamLookupMaximumSelect.BOSPropertyName = "Text";
            this.fld_txtMEParamLookupMaximumSelect.EditValue = "";
            this.fld_txtMEParamLookupMaximumSelect.Location = new System.Drawing.Point(808, 20);
            this.fld_txtMEParamLookupMaximumSelect.Name = "fld_txtMEParamLookupMaximumSelect";
            this.fld_txtMEParamLookupMaximumSelect.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEParamLookupMaximumSelect.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEParamLookupMaximumSelect.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEParamLookupMaximumSelect.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEParamLookupMaximumSelect.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEParamLookupMaximumSelect.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEParamLookupMaximumSelect.Screen = null;
            this.fld_txtMEParamLookupMaximumSelect.Size = new System.Drawing.Size(40, 20);
            this.fld_txtMEParamLookupMaximumSelect.TabIndex = 75;
            this.fld_txtMEParamLookupMaximumSelect.Tag = "DC";
            // 
            // fld_lblMEParamLookupMaximumSelect
            // 
            this.fld_lblMEParamLookupMaximumSelect.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblMEParamLookupMaximumSelect.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblMEParamLookupMaximumSelect.Appearance.Options.UseBackColor = true;
            this.fld_lblMEParamLookupMaximumSelect.Appearance.Options.UseForeColor = true;
            this.fld_lblMEParamLookupMaximumSelect.BOSComment = "";
            this.fld_lblMEParamLookupMaximumSelect.BOSDataMember = "";
            this.fld_lblMEParamLookupMaximumSelect.BOSDataSource = "";
            this.fld_lblMEParamLookupMaximumSelect.BOSDescription = null;
            this.fld_lblMEParamLookupMaximumSelect.BOSError = null;
            this.fld_lblMEParamLookupMaximumSelect.BOSFieldGroup = "";
            this.fld_lblMEParamLookupMaximumSelect.BOSFieldRelation = "";
            this.fld_lblMEParamLookupMaximumSelect.BOSPrivilege = "";
            this.fld_lblMEParamLookupMaximumSelect.BOSPropertyName = "";
            this.fld_lblMEParamLookupMaximumSelect.Location = new System.Drawing.Point(669, 23);
            this.fld_lblMEParamLookupMaximumSelect.Name = "fld_lblMEParamLookupMaximumSelect";
            this.fld_lblMEParamLookupMaximumSelect.Screen = null;
            this.fld_lblMEParamLookupMaximumSelect.Size = new System.Drawing.Size(127, 13);
            this.fld_lblMEParamLookupMaximumSelect.TabIndex = 74;
            this.fld_lblMEParamLookupMaximumSelect.Tag = "Empty";
            this.fld_lblMEParamLookupMaximumSelect.Text = "Số dòng dữ liệu được chọn";
            // 
            // DMMEPL100
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(1032, 510);
            this.Controls.Add(this.bosPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DMMEPL100";
            this.ScreenNumber = "DMMEPL100";
            this.Text = "Thông Tin";
            this.Controls.SetChildIndex(this.bosPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEParamLookupDatas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamLookupNo1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamLookupName1.Properties)).EndInit();
            this.bosPanel1.ResumeLayout(false);
            this.bosPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkMEParamLookupPart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkMEParamLookupSort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosTextBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamLookupMaximumSelect.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion

        private IContainer components;
        private BOSPanel bosPanel1;
        private BOSTextBox bosTextBox1;
        private BOSCheckEdit fld_chkMEParamLookupSort;
        private BOSCheckEdit fld_chkMEParamLookupPart;
        private BOSTextBox fld_txtMEParamLookupMaximumSelect;
        private BOSLabel fld_lblMEParamLookupMaximumSelect;
    }
}
