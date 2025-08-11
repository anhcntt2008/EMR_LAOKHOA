using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.MENotification.UI
{
	/// <summary>
	/// Summary description for DMNM100
	/// </summary>
	partial class DMNM100
	{
		private BOSComponent.BOSMemoEdit fld_medMENotificationContent;
		private BOSComponent.BOSLabel fld_lblLabel3;


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMNM100));
            this.fld_medMENotificationContent = new BOSComponent.BOSMemoEdit(this.components);
            this.fld_lblLabel3 = new BOSComponent.BOSLabel(this.components);
            this.bosPanel1 = new BOSComponent.BOSPanel(this.components);
            this.bosPictureEdit1 = new BOSComponent.BOSPictureEdit(this.components);
            this.bosLabel2 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel1 = new BOSComponent.BOSLabel(this.components);
            this.fld_chkMENotificationActive = new BOSComponent.BOSCheckEdit(this.components);
            this.fld_txtMENotificationName = new BOSComponent.BOSTextBox(this.components);
            this.fld_lkeMENotificationType = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel6 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel = new BOSComponent.BOSLabel(this.components);
            this.fld_ccbeMENotificationDepartment = new BOSComponent.MultiColCheckedComboBoxEdit(this.components);
            this.bosLabel3 = new BOSComponent.BOSLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fld_medMENotificationContent.Properties)).BeginInit();
            this.bosPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bosPictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkMENotificationActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMENotificationName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMENotificationType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_ccbeMENotificationDepartment.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_medMENotificationContent
            // 
            this.fld_medMENotificationContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_medMENotificationContent.BOSComment = "";
            this.fld_medMENotificationContent.BOSDataMember = "MENotificationContent";
            this.fld_medMENotificationContent.BOSDataSource = "MENotifications";
            this.fld_medMENotificationContent.BOSDescription = null;
            this.fld_medMENotificationContent.BOSError = null;
            this.fld_medMENotificationContent.BOSFieldGroup = "";
            this.fld_medMENotificationContent.BOSFieldRelation = "";
            this.fld_medMENotificationContent.BOSPrivilege = "";
            this.fld_medMENotificationContent.BOSPropertyName = "Text";
            this.fld_medMENotificationContent.EditValue = "";
            this.fld_medMENotificationContent.Enabled = false;
            this.fld_medMENotificationContent.Location = new System.Drawing.Point(129, 135);
            this.fld_medMENotificationContent.Name = "fld_medMENotificationContent";
            this.fld_medMENotificationContent.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_medMENotificationContent.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_medMENotificationContent.Properties.Appearance.Options.UseBackColor = true;
            this.fld_medMENotificationContent.Properties.Appearance.Options.UseForeColor = true;
            this.fld_medMENotificationContent.Screen = null;
            this.fld_medMENotificationContent.Size = new System.Drawing.Size(915, 203);
            this.fld_medMENotificationContent.TabIndex = 8;
            this.fld_medMENotificationContent.Tag = "DC";
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
            this.fld_lblLabel3.Location = new System.Drawing.Point(18, 137);
            this.fld_lblLabel3.Name = "fld_lblLabel3";
            this.fld_lblLabel3.Screen = null;
            this.fld_lblLabel3.Size = new System.Drawing.Size(42, 13);
            this.fld_lblLabel3.TabIndex = 9;
            this.fld_lblLabel3.Tag = "";
            this.fld_lblLabel3.Text = "Nội dung";
            // 
            // bosPanel1
            // 
            this.bosPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bosPanel1.BOSComment = null;
            this.bosPanel1.BOSDataMember = null;
            this.bosPanel1.BOSDataSource = null;
            this.bosPanel1.BOSDescription = null;
            this.bosPanel1.BOSError = null;
            this.bosPanel1.BOSFieldGroup = null;
            this.bosPanel1.BOSFieldRelation = null;
            this.bosPanel1.BOSPrivilege = null;
            this.bosPanel1.BOSPropertyName = null;
            this.bosPanel1.Controls.Add(this.bosPictureEdit1);
            this.bosPanel1.Controls.Add(this.bosLabel2);
            this.bosPanel1.Controls.Add(this.bosLabel1);
            this.bosPanel1.Controls.Add(this.fld_chkMENotificationActive);
            this.bosPanel1.Controls.Add(this.fld_txtMENotificationName);
            this.bosPanel1.Controls.Add(this.fld_lkeMENotificationType);
            this.bosPanel1.Controls.Add(this.bosLabel6);
            this.bosPanel1.Controls.Add(this.fld_lblLabel);
            this.bosPanel1.Controls.Add(this.fld_ccbeMENotificationDepartment);
            this.bosPanel1.Controls.Add(this.bosLabel3);
            this.bosPanel1.Controls.Add(this.fld_medMENotificationContent);
            this.bosPanel1.Controls.Add(this.fld_lblLabel3);
            this.bosPanel1.Location = new System.Drawing.Point(0, 0);
            this.bosPanel1.Name = "bosPanel1";
            this.bosPanel1.Screen = null;
            this.bosPanel1.Size = new System.Drawing.Size(1092, 547);
            this.bosPanel1.TabIndex = 54;
            // 
            // bosPictureEdit1
            // 
            this.bosPictureEdit1.BOSComment = null;
            this.bosPictureEdit1.BOSDataMember = "MENotificationImg";
            this.bosPictureEdit1.BOSDataSource = "MENotifications";
            this.bosPictureEdit1.BOSDescription = null;
            this.bosPictureEdit1.BOSError = null;
            this.bosPictureEdit1.BOSFieldGroup = null;
            this.bosPictureEdit1.BOSFieldRelation = null;
            this.bosPictureEdit1.BOSPrivilege = null;
            this.bosPictureEdit1.BOSPropertyName = "Image";
            this.bosPictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.bosPictureEdit1.Enabled = false;
            this.bosPictureEdit1.Location = new System.Drawing.Point(129, 364);
            this.bosPictureEdit1.Name = "bosPictureEdit1";
            this.bosPictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.bosPictureEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.bosPictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.bosPictureEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.bosPictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.bosPictureEdit1.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosPictureEdit1, true);
            this.bosPictureEdit1.Size = new System.Drawing.Size(150, 150);
            this.bosPictureEdit1.TabIndex = 115;
            this.bosPictureEdit1.Tag = "DC";
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
            this.bosLabel2.Location = new System.Drawing.Point(18, 364);
            this.bosLabel2.Name = "bosLabel2";
            this.bosLabel2.Screen = null;
            this.bosLabel2.Size = new System.Drawing.Size(42, 13);
            this.bosLabel2.TabIndex = 114;
            this.bosLabel2.Tag = "";
            this.bosLabel2.Text = "Hình ảnh";
            // 
            // bosLabel1
            // 
            this.bosLabel1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.bosLabel1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.bosLabel1.Appearance.Options.UseBackColor = true;
            this.bosLabel1.Appearance.Options.UseFont = true;
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
            this.bosLabel1.Location = new System.Drawing.Point(129, 344);
            this.bosLabel1.Name = "bosLabel1";
            this.bosLabel1.Screen = null;
            this.bosLabel1.Size = new System.Drawing.Size(584, 14);
            this.bosLabel1.TabIndex = 112;
            this.bosLabel1.Tag = "";
            this.bosLabel1.Text = "(*) Nhập nội dung và cần canh chỉnh sao cho khi hiển thị ngoài màn hình Welcome đ" +
    "ược đầy đủ nội dung.";
            // 
            // fld_chkMENotificationActive
            // 
            this.fld_chkMENotificationActive.BOSComment = "";
            this.fld_chkMENotificationActive.BOSDataMember = "MENotificationActive";
            this.fld_chkMENotificationActive.BOSDataSource = "MENotifications";
            this.fld_chkMENotificationActive.BOSDescription = null;
            this.fld_chkMENotificationActive.BOSError = null;
            this.fld_chkMENotificationActive.BOSFieldGroup = "";
            this.fld_chkMENotificationActive.BOSFieldRelation = "";
            this.fld_chkMENotificationActive.BOSPrivilege = "";
            this.fld_chkMENotificationActive.BOSPropertyName = "EditValue";
            this.fld_chkMENotificationActive.EditValue = true;
            this.fld_chkMENotificationActive.Enabled = false;
            this.fld_chkMENotificationActive.Location = new System.Drawing.Point(129, 107);
            this.fld_chkMENotificationActive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fld_chkMENotificationActive.Name = "fld_chkMENotificationActive";
            this.fld_chkMENotificationActive.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.fld_chkMENotificationActive.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.fld_chkMENotificationActive.Properties.Appearance.Options.UseBackColor = true;
            this.fld_chkMENotificationActive.Properties.Appearance.Options.UseForeColor = true;
            this.fld_chkMENotificationActive.Properties.Caption = "Hiệu lực";
            this.fld_chkMENotificationActive.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_chkMENotificationActive, true);
            this.fld_chkMENotificationActive.Size = new System.Drawing.Size(99, 19);
            this.fld_chkMENotificationActive.TabIndex = 111;
            this.fld_chkMENotificationActive.Tag = "DC";
            // 
            // fld_txtMENotificationName
            // 
            this.fld_txtMENotificationName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_txtMENotificationName.BOSComment = "";
            this.fld_txtMENotificationName.BOSDataMember = "MENotificationName";
            this.fld_txtMENotificationName.BOSDataSource = "MENotifications";
            this.fld_txtMENotificationName.BOSDescription = null;
            this.fld_txtMENotificationName.BOSError = null;
            this.fld_txtMENotificationName.BOSFieldGroup = "";
            this.fld_txtMENotificationName.BOSFieldRelation = "";
            this.fld_txtMENotificationName.BOSPrivilege = "";
            this.fld_txtMENotificationName.BOSPropertyName = "Text";
            this.fld_txtMENotificationName.EditValue = "";
            this.fld_txtMENotificationName.Enabled = false;
            this.fld_txtMENotificationName.Location = new System.Drawing.Point(129, 76);
            this.fld_txtMENotificationName.Name = "fld_txtMENotificationName";
            this.fld_txtMENotificationName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMENotificationName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMENotificationName.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMENotificationName.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMENotificationName.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMENotificationName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMENotificationName.Screen = null;
            this.fld_txtMENotificationName.Size = new System.Drawing.Size(915, 20);
            this.fld_txtMENotificationName.TabIndex = 110;
            this.fld_txtMENotificationName.Tag = "DC";
            // 
            // fld_lkeMENotificationType
            // 
            this.fld_lkeMENotificationType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_lkeMENotificationType.BOSAllowAddNew = false;
            this.fld_lkeMENotificationType.BOSAllowDummy = false;
            this.fld_lkeMENotificationType.BOSAllowMange = false;
            this.fld_lkeMENotificationType.BOSComment = null;
            this.fld_lkeMENotificationType.BOSDataMember = "MENotificationType";
            this.fld_lkeMENotificationType.BOSDataSource = "MENotifications";
            this.fld_lkeMENotificationType.BOSDescription = null;
            this.fld_lkeMENotificationType.BOSDummyText = null;
            this.fld_lkeMENotificationType.BOSError = null;
            this.fld_lkeMENotificationType.BOSFieldGroup = null;
            this.fld_lkeMENotificationType.BOSFieldParent = null;
            this.fld_lkeMENotificationType.BOSFieldRelation = null;
            this.fld_lkeMENotificationType.BOSPrivilege = null;
            this.fld_lkeMENotificationType.BOSPropertyName = "EditValue";
            this.fld_lkeMENotificationType.BOSSelectType = null;
            this.fld_lkeMENotificationType.BOSSelectTypeValue = null;
            this.fld_lkeMENotificationType.CurrentDisplayText = null;
            this.fld_lkeMENotificationType.Enabled = false;
            this.fld_lkeMENotificationType.Location = new System.Drawing.Point(129, 12);
            this.fld_lkeMENotificationType.MenuManager = this.screenToolbar;
            this.fld_lkeMENotificationType.Name = "fld_lkeMENotificationType";
            this.fld_lkeMENotificationType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeMENotificationType.Properties.NullText = "";
            this.fld_lkeMENotificationType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeMENotificationType.Screen = null;
            this.fld_lkeMENotificationType.Size = new System.Drawing.Size(469, 20);
            this.fld_lkeMENotificationType.TabIndex = 109;
            this.fld_lkeMENotificationType.Tag = "DC";
            this.fld_lkeMENotificationType.EditValueChanged += new System.EventHandler(this.fld_lkeMENotificationType_EditValueChanged);
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
            this.bosLabel6.Location = new System.Drawing.Point(18, 15);
            this.bosLabel6.Name = "bosLabel6";
            this.bosLabel6.Screen = null;
            this.bosLabel6.Size = new System.Drawing.Size(61, 13);
            this.bosLabel6.TabIndex = 108;
            this.bosLabel6.Tag = "SI";
            this.bosLabel6.Text = "Loại bảng tin";
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
            this.fld_lblLabel.Location = new System.Drawing.Point(15, 79);
            this.fld_lblLabel.Name = "fld_lblLabel";
            this.fld_lblLabel.Screen = null;
            this.fld_lblLabel.Size = new System.Drawing.Size(18, 13);
            this.fld_lblLabel.TabIndex = 107;
            this.fld_lblLabel.Tag = "SI";
            this.fld_lblLabel.Text = "Tên";
            // 
            // fld_ccbeMENotificationDepartment
            // 
            this.fld_ccbeMENotificationDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_ccbeMENotificationDepartment.BOSComment = null;
            this.fld_ccbeMENotificationDepartment.BOSDataMember = null;
            this.fld_ccbeMENotificationDepartment.BOSDataSource = "HRDepartments";
            this.fld_ccbeMENotificationDepartment.BOSDescription = null;
            this.fld_ccbeMENotificationDepartment.BOSError = null;
            this.fld_ccbeMENotificationDepartment.BOSFieldGroup = null;
            this.fld_ccbeMENotificationDepartment.BOSFieldRelation = null;
            this.fld_ccbeMENotificationDepartment.BOSPrivilege = null;
            this.fld_ccbeMENotificationDepartment.BOSPropertyName = null;
            this.fld_ccbeMENotificationDepartment.DisplayField = "HRDepartmentName";
            this.fld_ccbeMENotificationDepartment.Enabled = false;
            this.fld_ccbeMENotificationDepartment.Location = new System.Drawing.Point(129, 44);
            this.fld_ccbeMENotificationDepartment.MenuManager = this.screenToolbar;
            this.fld_ccbeMENotificationDepartment.Name = "fld_ccbeMENotificationDepartment";
            this.fld_ccbeMENotificationDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_ccbeMENotificationDepartment.QuickLookupField = null;
            this.fld_ccbeMENotificationDepartment.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_ccbeMENotificationDepartment, true);
            this.fld_ccbeMENotificationDepartment.Size = new System.Drawing.Size(469, 20);
            this.fld_ccbeMENotificationDepartment.TabIndex = 105;
            this.fld_ccbeMENotificationDepartment.Tag = "SC";
            this.fld_ccbeMENotificationDepartment.ValueField = "HRDepartmentID";
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
            this.bosLabel3.Location = new System.Drawing.Point(16, 47);
            this.bosLabel3.Name = "bosLabel3";
            this.bosLabel3.Screen = null;
            this.bosLabel3.Size = new System.Drawing.Size(57, 13);
            this.bosLabel3.TabIndex = 106;
            this.bosLabel3.Tag = "SI";
            this.bosLabel3.Text = "Khoa phòng";
            // 
            // DMNM100
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(1092, 547);
            this.Controls.Add(this.bosPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DMNM100";
            this.Text = "Thông tin";
            this.Controls.SetChildIndex(this.bosPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_medMENotificationContent.Properties)).EndInit();
            this.bosPanel1.ResumeLayout(false);
            this.bosPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bosPictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkMENotificationActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMENotificationName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMENotificationType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_ccbeMENotificationDepartment.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion
        private IContainer components;
        private BOSComponent.BOSPanel bosPanel1;
        private BOSComponent.BOSCheckEdit fld_chkMENotificationActive;
        private BOSComponent.BOSTextBox fld_txtMENotificationName;
        private BOSComponent.BOSLookupEdit fld_lkeMENotificationType;
        private BOSComponent.BOSLabel bosLabel6;
        private BOSComponent.BOSLabel fld_lblLabel;
        private BOSComponent.MultiColCheckedComboBoxEdit fld_ccbeMENotificationDepartment;
        private BOSComponent.BOSLabel bosLabel3;
        private BOSComponent.BOSLabel bosLabel1;
        private BOSComponent.BOSLabel bosLabel2;
        private BOSComponent.BOSPictureEdit bosPictureEdit1;
    }
}
