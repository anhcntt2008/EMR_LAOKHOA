namespace BOSERP.Modules.UserManagement
{
    partial class guiManageUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiManageUser));
            this.fld_lkeUserGroup = new BOSComponent.BOSLookupEdit(this.components);
            this.fld_lkeStaff = new BOSComponent.BOSLookupEdit(this.components);
            this.fld_btnCancel = new BOSComponent.BOSButton(this.components);
            this.fld_btnSave = new BOSComponent.BOSButton(this.components);
            this.fld_txtConfirmPassword = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtPassword = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtUserName = new BOSComponent.BOSTextBox(this.components);
            this.fld_lblUserGroup = new BOSComponent.BOSLabel(this.components);
            this.fld_lblStaff = new BOSComponent.BOSLabel(this.components);
            this.fld_lblConfirmPassword = new BOSComponent.BOSLabel(this.components);
            this.fld_lblPassword = new BOSComponent.BOSLabel(this.components);
            this.fld_lblUserName = new BOSComponent.BOSLabel(this.components);
            this.bosLabel1 = new BOSComponent.BOSLabel(this.components);
            this.fld_lkeEndTime = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel2 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel3 = new BOSComponent.BOSLabel(this.components);
            this.bosTextBox1 = new BOSComponent.BOSTextBox(this.components);
            this.bosLookupEdit1 = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel4 = new BOSComponent.BOSLabel(this.components);
            this.lblADUserCaIdentity = new BOSComponent.BOSLabel(this.components);
            this.bosTextBox2 = new BOSComponent.BOSTextBox(this.components);
            this.bosTextBox3 = new BOSComponent.BOSTextBox(this.components);
            this.lblADUserCaPasscode = new BOSComponent.BOSLabel(this.components);
            this.bosLabel5 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel6 = new BOSComponent.BOSLabel(this.components);
            this.fld_chkADUserActiveCheck = new BOSComponent.BOSCheckEdit(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeUserGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeStaff.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtConfirmPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosTextBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosLookupEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosTextBox2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosTextBox3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkADUserActiveCheck.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_lkeUserGroup
            // 
            this.fld_lkeUserGroup.BOSAllowAddNew = false;
            this.fld_lkeUserGroup.BOSAllowDummy = false;
            this.fld_lkeUserGroup.BOSAllowMange = false;
            this.fld_lkeUserGroup.BOSComment = null;
            this.fld_lkeUserGroup.BOSDataMember = "ADUserGroupID";
            this.fld_lkeUserGroup.BOSDataSource = "ADUsers";
            this.fld_lkeUserGroup.BOSDescription = null;
            this.fld_lkeUserGroup.BOSDummyText = null;
            this.fld_lkeUserGroup.BOSError = null;
            this.fld_lkeUserGroup.BOSFieldGroup = null;
            this.fld_lkeUserGroup.BOSFieldParent = null;
            this.fld_lkeUserGroup.BOSFieldRelation = null;
            this.fld_lkeUserGroup.BOSPrivilege = null;
            this.fld_lkeUserGroup.BOSPropertyName = "EditValue";
            this.fld_lkeUserGroup.BOSSelectType = null;
            this.fld_lkeUserGroup.BOSSelectTypeValue = null;
            this.fld_lkeUserGroup.CurrentDisplayText = null;
            this.fld_lkeUserGroup.Location = new System.Drawing.Point(142, 189);
            this.fld_lkeUserGroup.Name = "fld_lkeUserGroup";
            this.fld_lkeUserGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeUserGroup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ADUserGroupName", "Tên nhóm")});
            this.fld_lkeUserGroup.Properties.DisplayMember = "ADUserGroupName";
            this.fld_lkeUserGroup.Properties.NullText = "";
            this.fld_lkeUserGroup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeUserGroup.Properties.ValueMember = "ADUserGroupID";
            this.fld_lkeUserGroup.Screen = null;
            this.fld_lkeUserGroup.Size = new System.Drawing.Size(276, 20);
            this.fld_lkeUserGroup.TabIndex = 5;
            this.fld_lkeUserGroup.Tag = "DC";
            this.fld_lkeUserGroup.EditValueChanged += new System.EventHandler(this.fld_lkeUserGroup_EditValueChanged);
            // 
            // fld_lkeStaff
            // 
            this.fld_lkeStaff.BOSAllowAddNew = false;
            this.fld_lkeStaff.BOSAllowDummy = true;
            this.fld_lkeStaff.BOSAllowMange = false;
            this.fld_lkeStaff.BOSComment = null;
            this.fld_lkeStaff.BOSDataMember = "FK_HREmployeeID";
            this.fld_lkeStaff.BOSDataSource = "ADUsers";
            this.fld_lkeStaff.BOSDescription = null;
            this.fld_lkeStaff.BOSDummyText = null;
            this.fld_lkeStaff.BOSError = null;
            this.fld_lkeStaff.BOSFieldGroup = null;
            this.fld_lkeStaff.BOSFieldParent = null;
            this.fld_lkeStaff.BOSFieldRelation = null;
            this.fld_lkeStaff.BOSPrivilege = null;
            this.fld_lkeStaff.BOSPropertyName = "EditValue";
            this.fld_lkeStaff.BOSSelectType = null;
            this.fld_lkeStaff.BOSSelectTypeValue = null;
            this.fld_lkeStaff.CurrentDisplayText = "";
            this.fld_lkeStaff.Location = new System.Drawing.Point(142, 163);
            this.fld_lkeStaff.Name = "fld_lkeStaff";
            this.fld_lkeStaff.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeStaff.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HREmployeeNo", "Mã nhân viên"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HREmployeeName", "Tên nhân viên")});
            this.fld_lkeStaff.Properties.DisplayMember = "HREmployeeName";
            this.fld_lkeStaff.Properties.NullText = "";
            this.fld_lkeStaff.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeStaff.Properties.ValueMember = "HREmployeeID";
            this.fld_lkeStaff.Screen = null;
            this.fld_lkeStaff.Size = new System.Drawing.Size(276, 20);
            this.fld_lkeStaff.TabIndex = 4;
            this.fld_lkeStaff.Tag = "DC";
            // 
            // fld_btnCancel
            // 
            this.fld_btnCancel.BOSComment = null;
            this.fld_btnCancel.BOSDataMember = null;
            this.fld_btnCancel.BOSDataSource = null;
            this.fld_btnCancel.BOSDescription = null;
            this.fld_btnCancel.BOSError = null;
            this.fld_btnCancel.BOSFieldGroup = null;
            this.fld_btnCancel.BOSFieldRelation = null;
            this.fld_btnCancel.BOSPrivilege = null;
            this.fld_btnCancel.BOSPropertyName = null;
            this.fld_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fld_btnCancel.Location = new System.Drawing.Point(223, 379);
            this.fld_btnCancel.Name = "fld_btnCancel";
            this.fld_btnCancel.Screen = null;
            this.fld_btnCancel.Size = new System.Drawing.Size(75, 27);
            this.fld_btnCancel.TabIndex = 7;
            this.fld_btnCancel.Tag = "";
            this.fld_btnCancel.Text = "Hủy bỏ";
            this.fld_btnCancel.Click += new System.EventHandler(this.fld_btnCancel_Click);
            // 
            // fld_btnSave
            // 
            this.fld_btnSave.BOSComment = null;
            this.fld_btnSave.BOSDataMember = null;
            this.fld_btnSave.BOSDataSource = null;
            this.fld_btnSave.BOSDescription = null;
            this.fld_btnSave.BOSError = null;
            this.fld_btnSave.BOSFieldGroup = null;
            this.fld_btnSave.BOSFieldRelation = null;
            this.fld_btnSave.BOSPrivilege = null;
            this.fld_btnSave.BOSPropertyName = null;
            this.fld_btnSave.Location = new System.Drawing.Point(142, 379);
            this.fld_btnSave.Name = "fld_btnSave";
            this.fld_btnSave.Screen = null;
            this.fld_btnSave.Size = new System.Drawing.Size(75, 27);
            this.fld_btnSave.TabIndex = 6;
            this.fld_btnSave.Tag = "";
            this.fld_btnSave.Text = "Lưu";
            this.fld_btnSave.Click += new System.EventHandler(this.fld_btnSave_Click);
            // 
            // fld_txtConfirmPassword
            // 
            this.fld_txtConfirmPassword.BOSComment = null;
            this.fld_txtConfirmPassword.BOSDataMember = null;
            this.fld_txtConfirmPassword.BOSDataSource = null;
            this.fld_txtConfirmPassword.BOSDescription = null;
            this.fld_txtConfirmPassword.BOSError = null;
            this.fld_txtConfirmPassword.BOSFieldGroup = null;
            this.fld_txtConfirmPassword.BOSFieldRelation = null;
            this.fld_txtConfirmPassword.BOSPrivilege = null;
            this.fld_txtConfirmPassword.BOSPropertyName = null;
            this.fld_txtConfirmPassword.Location = new System.Drawing.Point(142, 72);
            this.fld_txtConfirmPassword.Name = "fld_txtConfirmPassword";
            this.fld_txtConfirmPassword.Properties.PasswordChar = '*';
            this.fld_txtConfirmPassword.Screen = null;
            this.fld_txtConfirmPassword.Size = new System.Drawing.Size(276, 20);
            this.fld_txtConfirmPassword.TabIndex = 3;
            this.fld_txtConfirmPassword.Tag = "";
            // 
            // fld_txtPassword
            // 
            this.fld_txtPassword.BOSComment = null;
            this.fld_txtPassword.BOSDataMember = "ADPassword";
            this.fld_txtPassword.BOSDataSource = "ADUsers";
            this.fld_txtPassword.BOSDescription = null;
            this.fld_txtPassword.BOSError = null;
            this.fld_txtPassword.BOSFieldGroup = null;
            this.fld_txtPassword.BOSFieldRelation = null;
            this.fld_txtPassword.BOSPrivilege = null;
            this.fld_txtPassword.BOSPropertyName = "EditValue";
            this.fld_txtPassword.Location = new System.Drawing.Point(142, 46);
            this.fld_txtPassword.Name = "fld_txtPassword";
            this.fld_txtPassword.Properties.PasswordChar = '*';
            this.fld_txtPassword.Screen = null;
            this.fld_txtPassword.Size = new System.Drawing.Size(276, 20);
            this.fld_txtPassword.TabIndex = 2;
            this.fld_txtPassword.Tag = "DC";
            // 
            // fld_txtUserName
            // 
            this.fld_txtUserName.BOSComment = null;
            this.fld_txtUserName.BOSDataMember = "ADUserName";
            this.fld_txtUserName.BOSDataSource = "ADUsers";
            this.fld_txtUserName.BOSDescription = null;
            this.fld_txtUserName.BOSError = null;
            this.fld_txtUserName.BOSFieldGroup = null;
            this.fld_txtUserName.BOSFieldRelation = null;
            this.fld_txtUserName.BOSPrivilege = null;
            this.fld_txtUserName.BOSPropertyName = "EditValue";
            this.fld_txtUserName.Location = new System.Drawing.Point(142, 20);
            this.fld_txtUserName.Name = "fld_txtUserName";
            this.fld_txtUserName.Screen = null;
            this.fld_txtUserName.Size = new System.Drawing.Size(276, 20);
            this.fld_txtUserName.TabIndex = 1;
            this.fld_txtUserName.Tag = "DC";
            // 
            // fld_lblUserGroup
            // 
            this.fld_lblUserGroup.BOSComment = null;
            this.fld_lblUserGroup.BOSDataMember = null;
            this.fld_lblUserGroup.BOSDataSource = null;
            this.fld_lblUserGroup.BOSDescription = null;
            this.fld_lblUserGroup.BOSError = null;
            this.fld_lblUserGroup.BOSFieldGroup = null;
            this.fld_lblUserGroup.BOSFieldRelation = null;
            this.fld_lblUserGroup.BOSPrivilege = null;
            this.fld_lblUserGroup.BOSPropertyName = null;
            this.fld_lblUserGroup.Location = new System.Drawing.Point(17, 192);
            this.fld_lblUserGroup.Name = "fld_lblUserGroup";
            this.fld_lblUserGroup.Screen = null;
            this.fld_lblUserGroup.Size = new System.Drawing.Size(27, 13);
            this.fld_lblUserGroup.TabIndex = 19;
            this.fld_lblUserGroup.Text = "Nhóm";
            // 
            // fld_lblStaff
            // 
            this.fld_lblStaff.BOSComment = null;
            this.fld_lblStaff.BOSDataMember = null;
            this.fld_lblStaff.BOSDataSource = null;
            this.fld_lblStaff.BOSDescription = null;
            this.fld_lblStaff.BOSError = null;
            this.fld_lblStaff.BOSFieldGroup = null;
            this.fld_lblStaff.BOSFieldRelation = null;
            this.fld_lblStaff.BOSPrivilege = null;
            this.fld_lblStaff.BOSPropertyName = null;
            this.fld_lblStaff.Location = new System.Drawing.Point(15, 166);
            this.fld_lblStaff.Name = "fld_lblStaff";
            this.fld_lblStaff.Screen = null;
            this.fld_lblStaff.Size = new System.Drawing.Size(48, 13);
            this.fld_lblStaff.TabIndex = 18;
            this.fld_lblStaff.Text = "Nhân viên";
            // 
            // fld_lblConfirmPassword
            // 
            this.fld_lblConfirmPassword.BOSComment = null;
            this.fld_lblConfirmPassword.BOSDataMember = null;
            this.fld_lblConfirmPassword.BOSDataSource = null;
            this.fld_lblConfirmPassword.BOSDescription = null;
            this.fld_lblConfirmPassword.BOSError = null;
            this.fld_lblConfirmPassword.BOSFieldGroup = null;
            this.fld_lblConfirmPassword.BOSFieldRelation = null;
            this.fld_lblConfirmPassword.BOSPrivilege = null;
            this.fld_lblConfirmPassword.BOSPropertyName = null;
            this.fld_lblConfirmPassword.Location = new System.Drawing.Point(16, 75);
            this.fld_lblConfirmPassword.Name = "fld_lblConfirmPassword";
            this.fld_lblConfirmPassword.Screen = null;
            this.fld_lblConfirmPassword.Size = new System.Drawing.Size(91, 13);
            this.fld_lblConfirmPassword.TabIndex = 17;
            this.fld_lblConfirmPassword.Text = "Xác nhận mật khẩu";
            // 
            // fld_lblPassword
            // 
            this.fld_lblPassword.BOSComment = null;
            this.fld_lblPassword.BOSDataMember = null;
            this.fld_lblPassword.BOSDataSource = null;
            this.fld_lblPassword.BOSDescription = null;
            this.fld_lblPassword.BOSError = null;
            this.fld_lblPassword.BOSFieldGroup = null;
            this.fld_lblPassword.BOSFieldRelation = null;
            this.fld_lblPassword.BOSPrivilege = null;
            this.fld_lblPassword.BOSPropertyName = null;
            this.fld_lblPassword.Location = new System.Drawing.Point(16, 49);
            this.fld_lblPassword.Name = "fld_lblPassword";
            this.fld_lblPassword.Screen = null;
            this.fld_lblPassword.Size = new System.Drawing.Size(44, 13);
            this.fld_lblPassword.TabIndex = 16;
            this.fld_lblPassword.Text = "Mật khẩu";
            // 
            // fld_lblUserName
            // 
            this.fld_lblUserName.BOSComment = null;
            this.fld_lblUserName.BOSDataMember = null;
            this.fld_lblUserName.BOSDataSource = null;
            this.fld_lblUserName.BOSDescription = null;
            this.fld_lblUserName.BOSError = null;
            this.fld_lblUserName.BOSFieldGroup = null;
            this.fld_lblUserName.BOSFieldRelation = null;
            this.fld_lblUserName.BOSPrivilege = null;
            this.fld_lblUserName.BOSPropertyName = null;
            this.fld_lblUserName.Location = new System.Drawing.Point(16, 23);
            this.fld_lblUserName.Name = "fld_lblUserName";
            this.fld_lblUserName.Screen = null;
            this.fld_lblUserName.Size = new System.Drawing.Size(65, 13);
            this.fld_lblUserName.TabIndex = 15;
            this.fld_lblUserName.Text = "Tên tài khoản";
            // 
            // bosLabel1
            // 
            this.bosLabel1.BOSComment = null;
            this.bosLabel1.BOSDataMember = null;
            this.bosLabel1.BOSDataSource = null;
            this.bosLabel1.BOSDescription = null;
            this.bosLabel1.BOSError = null;
            this.bosLabel1.BOSFieldGroup = null;
            this.bosLabel1.BOSFieldRelation = null;
            this.bosLabel1.BOSPrivilege = null;
            this.bosLabel1.BOSPropertyName = null;
            this.bosLabel1.Location = new System.Drawing.Point(16, 249);
            this.bosLabel1.Name = "bosLabel1";
            this.bosLabel1.Screen = null;
            this.bosLabel1.Size = new System.Drawing.Size(102, 13);
            this.bosLabel1.TabIndex = 21;
            this.bosLabel1.Text = "Giờ kết thúc mặc định";
            // 
            // fld_lkeEndTime
            // 
            this.fld_lkeEndTime.BOSAllowAddNew = false;
            this.fld_lkeEndTime.BOSAllowDummy = false;
            this.fld_lkeEndTime.BOSAllowMange = false;
            this.fld_lkeEndTime.BOSComment = null;
            this.fld_lkeEndTime.BOSDataMember = "ADUserEndTimeDefault";
            this.fld_lkeEndTime.BOSDataSource = "MEEndTimeFrameValues";
            this.fld_lkeEndTime.BOSDescription = null;
            this.fld_lkeEndTime.BOSDummyText = null;
            this.fld_lkeEndTime.BOSError = null;
            this.fld_lkeEndTime.BOSFieldGroup = null;
            this.fld_lkeEndTime.BOSFieldParent = null;
            this.fld_lkeEndTime.BOSFieldRelation = null;
            this.fld_lkeEndTime.BOSPrivilege = null;
            this.fld_lkeEndTime.BOSPropertyName = "EditValue";
            this.fld_lkeEndTime.BOSSelectType = null;
            this.fld_lkeEndTime.BOSSelectTypeValue = null;
            this.fld_lkeEndTime.CurrentDisplayText = null;
            this.fld_lkeEndTime.Location = new System.Drawing.Point(142, 246);
            this.fld_lkeEndTime.Name = "fld_lkeEndTime";
            this.fld_lkeEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeEndTime.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MEEndTimeFrameValue", "Thời gian")});
            this.fld_lkeEndTime.Properties.DisplayMember = "MEEndTimeFrameValue";
            this.fld_lkeEndTime.Properties.NullText = "";
            this.fld_lkeEndTime.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeEndTime.Properties.ValueMember = "ADUserEndTimeDefault";
            this.fld_lkeEndTime.Screen = null;
            this.fld_lkeEndTime.Size = new System.Drawing.Size(276, 20);
            this.fld_lkeEndTime.TabIndex = 22;
            this.fld_lkeEndTime.Tag = "DC";
            // 
            // bosLabel2
            // 
            this.bosLabel2.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.bosLabel2.Appearance.Options.UseForeColor = true;
            this.bosLabel2.Appearance.Options.UseTextOptions = true;
            this.bosLabel2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.bosLabel2.BOSComment = null;
            this.bosLabel2.BOSDataMember = null;
            this.bosLabel2.BOSDataSource = null;
            this.bosLabel2.BOSDescription = null;
            this.bosLabel2.BOSError = null;
            this.bosLabel2.BOSFieldGroup = null;
            this.bosLabel2.BOSFieldRelation = null;
            this.bosLabel2.BOSPrivilege = null;
            this.bosLabel2.BOSPropertyName = null;
            this.bosLabel2.Location = new System.Drawing.Point(15, 101);
            this.bosLabel2.Name = "bosLabel2";
            this.bosLabel2.Screen = null;
            this.bosLabel2.Size = new System.Drawing.Size(360, 13);
            this.bosLabel2.TabIndex = 23;
            this.bosLabel2.Text = "Mật khẩu sẽ tự động đồng bộ khi người dùng đăng nhập thông qua API HIS";
            // 
            // bosLabel3
            // 
            this.bosLabel3.BOSComment = null;
            this.bosLabel3.BOSDataMember = null;
            this.bosLabel3.BOSDataSource = null;
            this.bosLabel3.BOSDescription = null;
            this.bosLabel3.BOSError = null;
            this.bosLabel3.BOSFieldGroup = null;
            this.bosLabel3.BOSFieldRelation = null;
            this.bosLabel3.BOSPrivilege = null;
            this.bosLabel3.BOSPropertyName = null;
            this.bosLabel3.Location = new System.Drawing.Point(16, 123);
            this.bosLabel3.Name = "bosLabel3";
            this.bosLabel3.Screen = null;
            this.bosLabel3.Size = new System.Drawing.Size(111, 13);
            this.bosLabel3.TabIndex = 25;
            this.bosLabel3.Text = "ID người dùng trên HIS";
            // 
            // bosTextBox1
            // 
            this.bosTextBox1.BOSComment = null;
            this.bosTextBox1.BOSDataMember = "ADUserHISID";
            this.bosTextBox1.BOSDataSource = "ADUsers";
            this.bosTextBox1.BOSDescription = null;
            this.bosTextBox1.BOSError = null;
            this.bosTextBox1.BOSFieldGroup = null;
            this.bosTextBox1.BOSFieldRelation = null;
            this.bosTextBox1.BOSPrivilege = null;
            this.bosTextBox1.BOSPropertyName = "EditValue";
            this.bosTextBox1.Location = new System.Drawing.Point(142, 120);
            this.bosTextBox1.Name = "bosTextBox1";
            this.bosTextBox1.Screen = null;
            this.bosTextBox1.Size = new System.Drawing.Size(276, 20);
            this.bosTextBox1.TabIndex = 24;
            this.bosTextBox1.Tag = "DC";
            // 
            // bosLookupEdit1
            // 
            this.bosLookupEdit1.BOSAllowAddNew = false;
            this.bosLookupEdit1.BOSAllowDummy = false;
            this.bosLookupEdit1.BOSAllowMange = false;
            this.bosLookupEdit1.BOSComment = null;
            this.bosLookupEdit1.BOSDataMember = "ADUserEmrView";
            this.bosLookupEdit1.BOSDataSource = "ADUsers";
            this.bosLookupEdit1.BOSDescription = null;
            this.bosLookupEdit1.BOSDummyText = null;
            this.bosLookupEdit1.BOSError = null;
            this.bosLookupEdit1.BOSFieldGroup = null;
            this.bosLookupEdit1.BOSFieldParent = null;
            this.bosLookupEdit1.BOSFieldRelation = null;
            this.bosLookupEdit1.BOSPrivilege = null;
            this.bosLookupEdit1.BOSPropertyName = "EditValue";
            this.bosLookupEdit1.BOSSelectType = null;
            this.bosLookupEdit1.BOSSelectTypeValue = null;
            this.bosLookupEdit1.CurrentDisplayText = null;
            this.bosLookupEdit1.Location = new System.Drawing.Point(142, 218);
            this.bosLookupEdit1.Name = "bosLookupEdit1";
            this.bosLookupEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bosLookupEdit1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MEEndTimeFrameValue", "Thời gian")});
            this.bosLookupEdit1.Properties.DisplayMember = "MEEndTimeFrameValue";
            this.bosLookupEdit1.Properties.NullText = "";
            this.bosLookupEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.bosLookupEdit1.Properties.ValueMember = "ADUserEndTimeDefault";
            this.bosLookupEdit1.Screen = null;
            this.bosLookupEdit1.Size = new System.Drawing.Size(276, 20);
            this.bosLookupEdit1.TabIndex = 27;
            this.bosLookupEdit1.Tag = "DC";
            // 
            // bosLabel4
            // 
            this.bosLabel4.BOSComment = null;
            this.bosLabel4.BOSDataMember = null;
            this.bosLabel4.BOSDataSource = null;
            this.bosLabel4.BOSDescription = null;
            this.bosLabel4.BOSError = null;
            this.bosLabel4.BOSFieldGroup = null;
            this.bosLabel4.BOSFieldRelation = null;
            this.bosLabel4.BOSPrivilege = null;
            this.bosLabel4.BOSPropertyName = null;
            this.bosLabel4.Location = new System.Drawing.Point(16, 221);
            this.bosLabel4.Name = "bosLabel4";
            this.bosLabel4.Screen = null;
            this.bosLabel4.Size = new System.Drawing.Size(122, 13);
            this.bosLabel4.TabIndex = 26;
            this.bosLabel4.Text = "Quyền truy xuất bệnh án";
            // 
            // lblADUserCaIdentity
            // 
            this.lblADUserCaIdentity.BOSComment = null;
            this.lblADUserCaIdentity.BOSDataMember = null;
            this.lblADUserCaIdentity.BOSDataSource = null;
            this.lblADUserCaIdentity.BOSDescription = null;
            this.lblADUserCaIdentity.BOSError = null;
            this.lblADUserCaIdentity.BOSFieldGroup = null;
            this.lblADUserCaIdentity.BOSFieldRelation = null;
            this.lblADUserCaIdentity.BOSPrivilege = null;
            this.lblADUserCaIdentity.BOSPropertyName = null;
            this.lblADUserCaIdentity.Location = new System.Drawing.Point(16, 293);
            this.lblADUserCaIdentity.Name = "lblADUserCaIdentity";
            this.lblADUserCaIdentity.Screen = null;
            this.lblADUserCaIdentity.Size = new System.Drawing.Size(66, 13);
            this.lblADUserCaIdentity.TabIndex = 29;
            this.lblADUserCaIdentity.Text = "Định danh CA";
            // 
            // bosTextBox2
            // 
            this.bosTextBox2.BOSComment = null;
            this.bosTextBox2.BOSDataMember = "ADUserCaIdentity";
            this.bosTextBox2.BOSDataSource = "ADUsers";
            this.bosTextBox2.BOSDescription = null;
            this.bosTextBox2.BOSError = null;
            this.bosTextBox2.BOSFieldGroup = null;
            this.bosTextBox2.BOSFieldRelation = null;
            this.bosTextBox2.BOSPrivilege = null;
            this.bosTextBox2.BOSPropertyName = "EditValue";
            this.bosTextBox2.Location = new System.Drawing.Point(142, 290);
            this.bosTextBox2.Name = "bosTextBox2";
            this.bosTextBox2.Screen = null;
            this.bosTextBox2.Size = new System.Drawing.Size(276, 20);
            this.bosTextBox2.TabIndex = 28;
            this.bosTextBox2.Tag = "DC";
            // 
            // bosTextBox3
            // 
            this.bosTextBox3.BOSComment = null;
            this.bosTextBox3.BOSDataMember = "ADUserCaPasscode";
            this.bosTextBox3.BOSDataSource = "ADUsers";
            this.bosTextBox3.BOSDescription = null;
            this.bosTextBox3.BOSError = null;
            this.bosTextBox3.BOSFieldGroup = null;
            this.bosTextBox3.BOSFieldRelation = null;
            this.bosTextBox3.BOSPrivilege = null;
            this.bosTextBox3.BOSPropertyName = "EditValue";
            this.bosTextBox3.Location = new System.Drawing.Point(142, 328);
            this.bosTextBox3.Name = "bosTextBox3";
            this.bosTextBox3.Screen = null;
            this.bosTextBox3.Size = new System.Drawing.Size(276, 20);
            this.bosTextBox3.TabIndex = 30;
            this.bosTextBox3.Tag = "DC";
            // 
            // lblADUserCaPasscode
            // 
            this.lblADUserCaPasscode.BOSComment = null;
            this.lblADUserCaPasscode.BOSDataMember = null;
            this.lblADUserCaPasscode.BOSDataSource = null;
            this.lblADUserCaPasscode.BOSDescription = null;
            this.lblADUserCaPasscode.BOSError = null;
            this.lblADUserCaPasscode.BOSFieldGroup = null;
            this.lblADUserCaPasscode.BOSFieldRelation = null;
            this.lblADUserCaPasscode.BOSPrivilege = null;
            this.lblADUserCaPasscode.BOSPropertyName = null;
            this.lblADUserCaPasscode.Location = new System.Drawing.Point(16, 328);
            this.lblADUserCaPasscode.Name = "lblADUserCaPasscode";
            this.lblADUserCaPasscode.Screen = null;
            this.lblADUserCaPasscode.Size = new System.Drawing.Size(61, 13);
            this.lblADUserCaPasscode.TabIndex = 31;
            this.lblADUserCaPasscode.Text = "Mật khẩu CA";
            // 
            // bosLabel5
            // 
            this.bosLabel5.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.bosLabel5.Appearance.Options.UseForeColor = true;
            this.bosLabel5.Appearance.Options.UseTextOptions = true;
            this.bosLabel5.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.bosLabel5.BOSComment = null;
            this.bosLabel5.BOSDataMember = null;
            this.bosLabel5.BOSDataSource = null;
            this.bosLabel5.BOSDescription = null;
            this.bosLabel5.BOSError = null;
            this.bosLabel5.BOSFieldGroup = null;
            this.bosLabel5.BOSFieldRelation = null;
            this.bosLabel5.BOSPrivilege = null;
            this.bosLabel5.BOSPropertyName = null;
            this.bosLabel5.Location = new System.Drawing.Point(143, 274);
            this.bosLabel5.Name = "bosLabel5";
            this.bosLabel5.Screen = null;
            this.bosLabel5.Size = new System.Drawing.Size(176, 13);
            this.bosLabel5.TabIndex = 32;
            this.bosLabel5.Text = "Serial Number hoặc Agreement UUID";
            // 
            // bosLabel6
            // 
            this.bosLabel6.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.bosLabel6.Appearance.Options.UseForeColor = true;
            this.bosLabel6.Appearance.Options.UseTextOptions = true;
            this.bosLabel6.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.bosLabel6.BOSComment = null;
            this.bosLabel6.BOSDataMember = null;
            this.bosLabel6.BOSDataSource = null;
            this.bosLabel6.BOSDescription = null;
            this.bosLabel6.BOSError = null;
            this.bosLabel6.BOSFieldGroup = null;
            this.bosLabel6.BOSFieldRelation = null;
            this.bosLabel6.BOSPrivilege = null;
            this.bosLabel6.BOSPropertyName = null;
            this.bosLabel6.Location = new System.Drawing.Point(144, 314);
            this.bosLabel6.Name = "bosLabel6";
            this.bosLabel6.Screen = null;
            this.bosLabel6.Size = new System.Drawing.Size(161, 13);
            this.bosLabel6.TabIndex = 33;
            this.bosLabel6.Text = "Passcode (nếu BKAV thì để trống)";
            // 
            // fld_chkADUserActiveCheck
            // 
            this.fld_chkADUserActiveCheck.BOSComment = "";
            this.fld_chkADUserActiveCheck.BOSDataMember = "ADUserActiveCheck";
            this.fld_chkADUserActiveCheck.BOSDataSource = "ADUsers";
            this.fld_chkADUserActiveCheck.BOSDescription = null;
            this.fld_chkADUserActiveCheck.BOSError = null;
            this.fld_chkADUserActiveCheck.BOSFieldGroup = "";
            this.fld_chkADUserActiveCheck.BOSFieldRelation = "";
            this.fld_chkADUserActiveCheck.BOSPrivilege = "";
            this.fld_chkADUserActiveCheck.BOSPropertyName = "EditValue";
            this.fld_chkADUserActiveCheck.Location = new System.Drawing.Point(142, 353);
            this.fld_chkADUserActiveCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fld_chkADUserActiveCheck.Name = "fld_chkADUserActiveCheck";
            this.fld_chkADUserActiveCheck.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.fld_chkADUserActiveCheck.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.fld_chkADUserActiveCheck.Properties.Appearance.Options.UseBackColor = true;
            this.fld_chkADUserActiveCheck.Properties.Appearance.Options.UseForeColor = true;
            this.fld_chkADUserActiveCheck.Properties.Caption = "Hoạt động";
            this.fld_chkADUserActiveCheck.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_chkADUserActiveCheck, true);
            this.fld_chkADUserActiveCheck.Size = new System.Drawing.Size(99, 19);
            this.fld_chkADUserActiveCheck.TabIndex = 36;
            this.fld_chkADUserActiveCheck.Tag = "DC";
            // 
            // guiManageUser
            // 
            this.AcceptButton = this.fld_btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.fld_btnCancel;
            this.ClientSize = new System.Drawing.Size(438, 421);
            this.ControlBox = true;
            this.Controls.Add(this.fld_chkADUserActiveCheck);
            this.Controls.Add(this.bosLabel6);
            this.Controls.Add(this.bosLabel5);
            this.Controls.Add(this.bosTextBox3);
            this.Controls.Add(this.lblADUserCaPasscode);
            this.Controls.Add(this.lblADUserCaIdentity);
            this.Controls.Add(this.bosTextBox2);
            this.Controls.Add(this.bosLookupEdit1);
            this.Controls.Add(this.bosLabel4);
            this.Controls.Add(this.bosLabel3);
            this.Controls.Add(this.bosTextBox1);
            this.Controls.Add(this.bosLabel2);
            this.Controls.Add(this.fld_lkeEndTime);
            this.Controls.Add(this.bosLabel1);
            this.Controls.Add(this.fld_lkeUserGroup);
            this.Controls.Add(this.fld_lkeStaff);
            this.Controls.Add(this.fld_lblUserGroup);
            this.Controls.Add(this.fld_lblStaff);
            this.Controls.Add(this.fld_lblUserName);
            this.Controls.Add(this.fld_txtConfirmPassword);
            this.Controls.Add(this.fld_btnCancel);
            this.Controls.Add(this.fld_btnSave);
            this.Controls.Add(this.fld_txtPassword);
            this.Controls.Add(this.fld_lblConfirmPassword);
            this.Controls.Add(this.fld_lblPassword);
            this.Controls.Add(this.fld_txtUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "guiManageUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý tài khoản";
            this.Load += new System.EventHandler(this.guiManageUser_Load);
            this.Controls.SetChildIndex(this.fld_txtUserName, 0);
            this.Controls.SetChildIndex(this.fld_lblPassword, 0);
            this.Controls.SetChildIndex(this.fld_lblConfirmPassword, 0);
            this.Controls.SetChildIndex(this.fld_txtPassword, 0);
            this.Controls.SetChildIndex(this.fld_btnSave, 0);
            this.Controls.SetChildIndex(this.fld_btnCancel, 0);
            this.Controls.SetChildIndex(this.fld_txtConfirmPassword, 0);
            this.Controls.SetChildIndex(this.fld_lblUserName, 0);
            this.Controls.SetChildIndex(this.fld_lblStaff, 0);
            this.Controls.SetChildIndex(this.fld_lblUserGroup, 0);
            this.Controls.SetChildIndex(this.fld_lkeStaff, 0);
            this.Controls.SetChildIndex(this.fld_lkeUserGroup, 0);
            this.Controls.SetChildIndex(this.bosLabel1, 0);
            this.Controls.SetChildIndex(this.fld_lkeEndTime, 0);
            this.Controls.SetChildIndex(this.bosLabel2, 0);
            this.Controls.SetChildIndex(this.bosTextBox1, 0);
            this.Controls.SetChildIndex(this.bosLabel3, 0);
            this.Controls.SetChildIndex(this.bosLabel4, 0);
            this.Controls.SetChildIndex(this.bosLookupEdit1, 0);
            this.Controls.SetChildIndex(this.bosTextBox2, 0);
            this.Controls.SetChildIndex(this.lblADUserCaIdentity, 0);
            this.Controls.SetChildIndex(this.lblADUserCaPasscode, 0);
            this.Controls.SetChildIndex(this.bosTextBox3, 0);
            this.Controls.SetChildIndex(this.bosLabel5, 0);
            this.Controls.SetChildIndex(this.bosLabel6, 0);
            this.Controls.SetChildIndex(this.fld_chkADUserActiveCheck, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeUserGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeStaff.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtConfirmPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosTextBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosLookupEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosTextBox2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosTextBox3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkADUserActiveCheck.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BOSComponent.BOSLookupEdit fld_lkeUserGroup;
        private BOSComponent.BOSLookupEdit fld_lkeStaff;
        private BOSComponent.BOSButton fld_btnCancel;
        private BOSComponent.BOSButton fld_btnSave;
        private BOSComponent.BOSTextBox fld_txtConfirmPassword;
        private BOSComponent.BOSTextBox fld_txtPassword;
        private BOSComponent.BOSTextBox fld_txtUserName;
        private BOSComponent.BOSLabel fld_lblUserGroup;
        private BOSComponent.BOSLabel fld_lblStaff;
        private BOSComponent.BOSLabel fld_lblConfirmPassword;
        private BOSComponent.BOSLabel fld_lblPassword;
        private BOSComponent.BOSLabel fld_lblUserName;
        private BOSComponent.BOSLabel bosLabel1;
        private BOSComponent.BOSLookupEdit fld_lkeEndTime;
        private BOSComponent.BOSLabel bosLabel2;
        private BOSComponent.BOSLabel bosLabel3;
        private BOSComponent.BOSTextBox bosTextBox1;
        private BOSComponent.BOSLookupEdit bosLookupEdit1;
        private BOSComponent.BOSLabel bosLabel4;
        private BOSComponent.BOSLabel lblADUserCaIdentity;
        private BOSComponent.BOSTextBox bosTextBox2;
        private BOSComponent.BOSTextBox bosTextBox3;
        private BOSComponent.BOSLabel lblADUserCaPasscode;
        private BOSComponent.BOSLabel bosLabel5;
        private BOSComponent.BOSLabel bosLabel6;
        private BOSComponent.BOSCheckEdit fld_chkADUserActiveCheck;
    }
}