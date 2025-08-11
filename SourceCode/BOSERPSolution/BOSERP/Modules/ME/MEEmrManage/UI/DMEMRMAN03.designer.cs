using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSComponent;

namespace BOSERP.Modules.MEEmrManage.UI
{
    /// <summary>
    /// Summary description for DMMEEMR101
    /// </summary>
    partial class DMEMRMAN03
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMEMRMAN03));
            this.panelControl1 = new BOSComponent.BOSPanel(this.components);
            this.fld_txtMEEmrSumStoreNoMAN03 = new BOSComponent.BOSTextBox(this.components);
            this.bosLabel8 = new BOSComponent.BOSLabel(this.components);
            this.chkMEEmrSumStatusMAN03 = new DevExpress.XtraEditors.CheckEdit();
            this.fld_txtMEEmrSumNoMAN03 = new BOSComponent.BOSTextBox(this.components);
            this.bosLabel7 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtMEPatientName = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtMEPatientNo = new BOSComponent.BOSTextBox(this.components);
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.fld_lkeFK_MEEmrTypeIDMAN03 = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel6 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtMEEmrNoMAN03 = new BOSComponent.BOSTextBox(this.components);
            this.fld_lblLabel = new BOSComponent.BOSLabel(this.components);
            this.fld_dgcMEEmrSums = new BOSERP.Modules.MEEmrManage.MEEmrSumSelectionGridControl();
            this.fld_dgvMEEmrSums = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.chkDepartmentShared = new DevExpress.XtraEditors.CheckEdit();
            this.fld_lkeFK_MEPatientID = new BOSComponent.BOSLookupEdit(this.components);
            this.fld_lblLabel100 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel1 = new BOSComponent.BOSLabel(this.components);
            this.fld_cmbChooseView = new DevExpress.XtraEditors.ComboBoxEdit();
            this.fld_ccbeFK_HRDepartmentID = new BOSComponent.MultiColCheckedComboBoxEdit(this.components);
            this.chkSearchByPatient = new DevExpress.XtraEditors.CheckEdit();
            this.bosLabel2 = new BOSComponent.BOSLabel(this.components);
            this.fld_dteSearchToMEEmrCreatedDate = new BOSComponent.BOSDateEdit(this.components);
            this.fld_lblLabel3 = new BOSComponent.BOSLabel(this.components);
            this.fld_dteSearchFromMEEmrCreatedDate = new BOSComponent.BOSDateEdit(this.components);
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrSumStoreNoMAN03.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMEEmrSumStatusMAN03.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrSumNoMAN03.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEPatientName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEPatientNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_MEEmrTypeIDMAN03.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrNoMAN03.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrSums)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrSums)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDepartmentShared.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_MEPatientID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_cmbChooseView.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_ccbeFK_HRDepartmentID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSearchByPatient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchToMEEmrCreatedDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchToMEEmrCreatedDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchFromMEEmrCreatedDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchFromMEEmrCreatedDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BOSComment = null;
            this.panelControl1.BOSDataMember = null;
            this.panelControl1.BOSDataSource = null;
            this.panelControl1.BOSDescription = null;
            this.panelControl1.BOSError = null;
            this.panelControl1.BOSFieldGroup = null;
            this.panelControl1.BOSFieldRelation = null;
            this.panelControl1.BOSPrivilege = null;
            this.panelControl1.BOSPropertyName = null;
            this.panelControl1.Controls.Add(this.fld_txtMEEmrSumStoreNoMAN03);
            this.panelControl1.Controls.Add(this.bosLabel8);
            this.panelControl1.Controls.Add(this.chkMEEmrSumStatusMAN03);
            this.panelControl1.Controls.Add(this.fld_txtMEEmrSumNoMAN03);
            this.panelControl1.Controls.Add(this.bosLabel7);
            this.panelControl1.Controls.Add(this.fld_txtMEPatientName);
            this.panelControl1.Controls.Add(this.fld_txtMEPatientNo);
            this.panelControl1.Controls.Add(this.btnSearch);
            this.panelControl1.Controls.Add(this.fld_lkeFK_MEEmrTypeIDMAN03);
            this.panelControl1.Controls.Add(this.bosLabel6);
            this.panelControl1.Controls.Add(this.fld_txtMEEmrNoMAN03);
            this.panelControl1.Controls.Add(this.fld_lblLabel);
            this.panelControl1.Controls.Add(this.fld_dgcMEEmrSums);
            this.panelControl1.Controls.Add(this.chkDepartmentShared);
            this.panelControl1.Controls.Add(this.fld_lkeFK_MEPatientID);
            this.panelControl1.Controls.Add(this.fld_lblLabel100);
            this.panelControl1.Controls.Add(this.bosLabel1);
            this.panelControl1.Controls.Add(this.fld_cmbChooseView);
            this.panelControl1.Controls.Add(this.fld_ccbeFK_HRDepartmentID);
            this.panelControl1.Controls.Add(this.chkSearchByPatient);
            this.panelControl1.Controls.Add(this.bosLabel2);
            this.panelControl1.Controls.Add(this.fld_dteSearchToMEEmrCreatedDate);
            this.panelControl1.Controls.Add(this.fld_lblLabel3);
            this.panelControl1.Controls.Add(this.fld_dteSearchFromMEEmrCreatedDate);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Screen = null;
            this.panelControl1.Size = new System.Drawing.Size(826, 530);
            this.panelControl1.TabIndex = 0;
            // 
            // fld_txtMEEmrSumStoreNoMAN03
            // 
            this.fld_txtMEEmrSumStoreNoMAN03.BOSComment = "";
            this.fld_txtMEEmrSumStoreNoMAN03.BOSDataMember = "";
            this.fld_txtMEEmrSumStoreNoMAN03.BOSDataSource = "";
            this.fld_txtMEEmrSumStoreNoMAN03.BOSDescription = null;
            this.fld_txtMEEmrSumStoreNoMAN03.BOSError = null;
            this.fld_txtMEEmrSumStoreNoMAN03.BOSFieldGroup = "";
            this.fld_txtMEEmrSumStoreNoMAN03.BOSFieldRelation = "";
            this.fld_txtMEEmrSumStoreNoMAN03.BOSPrivilege = "";
            this.fld_txtMEEmrSumStoreNoMAN03.BOSPropertyName = "Text";
            this.fld_txtMEEmrSumStoreNoMAN03.EditValue = "";
            this.fld_txtMEEmrSumStoreNoMAN03.Location = new System.Drawing.Point(410, 122);
            this.fld_txtMEEmrSumStoreNoMAN03.Name = "fld_txtMEEmrSumStoreNoMAN03";
            this.fld_txtMEEmrSumStoreNoMAN03.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEEmrSumStoreNoMAN03.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEEmrSumStoreNoMAN03.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEEmrSumStoreNoMAN03.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEEmrSumStoreNoMAN03.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEEmrSumStoreNoMAN03.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEEmrSumStoreNoMAN03.Screen = null;
            this.fld_txtMEEmrSumStoreNoMAN03.Size = new System.Drawing.Size(237, 26);
            this.fld_txtMEEmrSumStoreNoMAN03.TabIndex = 1000000039;
            this.fld_txtMEEmrSumStoreNoMAN03.Tag = "SC";
            // 
            // bosLabel8
            // 
            this.bosLabel8.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
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
            this.bosLabel8.Location = new System.Drawing.Point(332, 125);
            this.bosLabel8.Name = "bosLabel8";
            this.bosLabel8.Screen = null;
            this.bosLabel8.Size = new System.Drawing.Size(72, 19);
            this.bosLabel8.TabIndex = 1000000040;
            this.bosLabel8.Tag = "SI";
            this.bosLabel8.Text = "Số lưu trữ";
            // 
            // chkMEEmrSumStatusMAN03
            // 
            this.chkMEEmrSumStatusMAN03.Location = new System.Drawing.Point(649, 123);
            this.chkMEEmrSumStatusMAN03.MenuManager = this.screenToolbar;
            this.chkMEEmrSumStatusMAN03.Name = "chkMEEmrSumStatusMAN03";
            this.chkMEEmrSumStatusMAN03.Properties.Caption = "Phiếu ẩn";
            this.chkMEEmrSumStatusMAN03.Size = new System.Drawing.Size(120, 23);
            this.chkMEEmrSumStatusMAN03.TabIndex = 1000000038;
            this.chkMEEmrSumStatusMAN03.Tag = "SC";
            // 
            // fld_txtMEEmrSumNoMAN03
            // 
            this.fld_txtMEEmrSumNoMAN03.BOSComment = "";
            this.fld_txtMEEmrSumNoMAN03.BOSDataMember = "";
            this.fld_txtMEEmrSumNoMAN03.BOSDataSource = "";
            this.fld_txtMEEmrSumNoMAN03.BOSDescription = null;
            this.fld_txtMEEmrSumNoMAN03.BOSError = null;
            this.fld_txtMEEmrSumNoMAN03.BOSFieldGroup = "";
            this.fld_txtMEEmrSumNoMAN03.BOSFieldRelation = "";
            this.fld_txtMEEmrSumNoMAN03.BOSPrivilege = "";
            this.fld_txtMEEmrSumNoMAN03.BOSPropertyName = "Text";
            this.fld_txtMEEmrSumNoMAN03.EditValue = "";
            this.fld_txtMEEmrSumNoMAN03.Location = new System.Drawing.Point(86, 122);
            this.fld_txtMEEmrSumNoMAN03.Name = "fld_txtMEEmrSumNoMAN03";
            this.fld_txtMEEmrSumNoMAN03.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEEmrSumNoMAN03.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEEmrSumNoMAN03.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEEmrSumNoMAN03.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEEmrSumNoMAN03.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEEmrSumNoMAN03.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEEmrSumNoMAN03.Screen = null;
            this.fld_txtMEEmrSumNoMAN03.Size = new System.Drawing.Size(242, 26);
            this.fld_txtMEEmrSumNoMAN03.TabIndex = 1000000036;
            this.fld_txtMEEmrSumNoMAN03.Tag = "SC";
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
            this.bosLabel7.Location = new System.Drawing.Point(20, 125);
            this.bosLabel7.Name = "bosLabel7";
            this.bosLabel7.Screen = null;
            this.bosLabel7.Size = new System.Drawing.Size(39, 19);
            this.bosLabel7.TabIndex = 1000000037;
            this.bosLabel7.Tag = "SI";
            this.bosLabel7.Text = "Phiếu";
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
            this.fld_txtMEPatientName.Location = new System.Drawing.Point(260, 15);
            this.fld_txtMEPatientName.Name = "fld_txtMEPatientName";
            this.fld_txtMEPatientName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEPatientName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEPatientName.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEPatientName.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEPatientName.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEPatientName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEPatientName.Screen = null;
            this.fld_txtMEPatientName.Size = new System.Drawing.Size(387, 26);
            this.fld_txtMEPatientName.TabIndex = 1000000028;
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
            this.fld_txtMEPatientNo.Location = new System.Drawing.Point(102, 15);
            this.fld_txtMEPatientNo.Name = "fld_txtMEPatientNo";
            this.fld_txtMEPatientNo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEPatientNo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEPatientNo.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEPatientNo.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEPatientNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEPatientNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEPatientNo.Screen = null;
            this.fld_txtMEPatientNo.Size = new System.Drawing.Size(152, 26);
            this.fld_txtMEPatientNo.TabIndex = 1000000027;
            this.fld_txtMEPatientNo.Tag = "SC";
            this.fld_txtMEPatientNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fld_txtMEPatientNo_KeyUp);
            // 
            // btnSearch
            // 
            this.btnSearch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.ImageOptions.Image")));
            this.btnSearch.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSearch.Location = new System.Drawing.Point(86, 151);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1000000018;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // fld_lkeFK_MEEmrTypeIDMAN03
            // 
            this.fld_lkeFK_MEEmrTypeIDMAN03.BOSAllowAddNew = false;
            this.fld_lkeFK_MEEmrTypeIDMAN03.BOSAllowDummy = true;
            this.fld_lkeFK_MEEmrTypeIDMAN03.BOSAllowMange = false;
            this.fld_lkeFK_MEEmrTypeIDMAN03.BOSComment = "";
            this.fld_lkeFK_MEEmrTypeIDMAN03.BOSDataMember = "FK_MEEmrTypeID";
            this.fld_lkeFK_MEEmrTypeIDMAN03.BOSDataSource = "MEEmrs";
            this.fld_lkeFK_MEEmrTypeIDMAN03.BOSDescription = null;
            this.fld_lkeFK_MEEmrTypeIDMAN03.BOSDummyText = null;
            this.fld_lkeFK_MEEmrTypeIDMAN03.BOSError = null;
            this.fld_lkeFK_MEEmrTypeIDMAN03.BOSFieldGroup = "";
            this.fld_lkeFK_MEEmrTypeIDMAN03.BOSFieldParent = "";
            this.fld_lkeFK_MEEmrTypeIDMAN03.BOSFieldRelation = "";
            this.fld_lkeFK_MEEmrTypeIDMAN03.BOSPrivilege = "";
            this.fld_lkeFK_MEEmrTypeIDMAN03.BOSPropertyName = "EditValue";
            this.fld_lkeFK_MEEmrTypeIDMAN03.BOSSelectType = "";
            this.fld_lkeFK_MEEmrTypeIDMAN03.BOSSelectTypeValue = "";
            this.fld_lkeFK_MEEmrTypeIDMAN03.CurrentDisplayText = null;
            this.fld_lkeFK_MEEmrTypeIDMAN03.Location = new System.Drawing.Point(407, 67);
            this.fld_lkeFK_MEEmrTypeIDMAN03.Name = "fld_lkeFK_MEEmrTypeIDMAN03";
            this.fld_lkeFK_MEEmrTypeIDMAN03.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeFK_MEEmrTypeIDMAN03.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeFK_MEEmrTypeIDMAN03.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeFK_MEEmrTypeIDMAN03.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeFK_MEEmrTypeIDMAN03.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_MEEmrTypeIDMAN03.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MEEmrTypeNo", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MEEmrTypeName", "Tên")});
            this.fld_lkeFK_MEEmrTypeIDMAN03.Properties.DisplayMember = "MEEmrTypeName";
            this.fld_lkeFK_MEEmrTypeIDMAN03.Properties.NullText = "";
            this.fld_lkeFK_MEEmrTypeIDMAN03.Properties.PopupWidth = 40;
            this.fld_lkeFK_MEEmrTypeIDMAN03.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeFK_MEEmrTypeIDMAN03.Properties.ValueMember = "MEEmrTypeID";
            this.fld_lkeFK_MEEmrTypeIDMAN03.Screen = null;
            this.fld_lkeFK_MEEmrTypeIDMAN03.Size = new System.Drawing.Size(240, 26);
            this.fld_lkeFK_MEEmrTypeIDMAN03.TabIndex = 1000000013;
            this.fld_lkeFK_MEEmrTypeIDMAN03.Tag = "SC";
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
            this.bosLabel6.Location = new System.Drawing.Point(334, 70);
            this.bosLabel6.Name = "bosLabel6";
            this.bosLabel6.Screen = null;
            this.bosLabel6.Size = new System.Drawing.Size(91, 19);
            this.bosLabel6.TabIndex = 1000000026;
            this.bosLabel6.Tag = "SI";
            this.bosLabel6.Text = "Loại bệnh án";
            // 
            // fld_txtMEEmrNoMAN03
            // 
            this.fld_txtMEEmrNoMAN03.BOSComment = "";
            this.fld_txtMEEmrNoMAN03.BOSDataMember = "";
            this.fld_txtMEEmrNoMAN03.BOSDataSource = "";
            this.fld_txtMEEmrNoMAN03.BOSDescription = null;
            this.fld_txtMEEmrNoMAN03.BOSError = null;
            this.fld_txtMEEmrNoMAN03.BOSFieldGroup = "";
            this.fld_txtMEEmrNoMAN03.BOSFieldRelation = "";
            this.fld_txtMEEmrNoMAN03.BOSPrivilege = "";
            this.fld_txtMEEmrNoMAN03.BOSPropertyName = "Text";
            this.fld_txtMEEmrNoMAN03.EditValue = "";
            this.fld_txtMEEmrNoMAN03.Location = new System.Drawing.Point(86, 67);
            this.fld_txtMEEmrNoMAN03.Name = "fld_txtMEEmrNoMAN03";
            this.fld_txtMEEmrNoMAN03.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEEmrNoMAN03.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEEmrNoMAN03.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEEmrNoMAN03.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEEmrNoMAN03.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEEmrNoMAN03.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEEmrNoMAN03.Screen = null;
            this.fld_txtMEEmrNoMAN03.Size = new System.Drawing.Size(242, 26);
            this.fld_txtMEEmrNoMAN03.TabIndex = 1000000012;
            this.fld_txtMEEmrNoMAN03.Tag = "SC";
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
            this.fld_lblLabel.Location = new System.Drawing.Point(20, 70);
            this.fld_lblLabel.Name = "fld_lblLabel";
            this.fld_lblLabel.Screen = null;
            this.fld_lblLabel.Size = new System.Drawing.Size(82, 19);
            this.fld_lblLabel.TabIndex = 1000000025;
            this.fld_lblLabel.Tag = "SI";
            this.fld_lblLabel.Text = "Mã bệnh án";
            // 
            // fld_dgcMEEmrSums
            // 
            this.fld_dgcMEEmrSums.AllowDrop = true;
            this.fld_dgcMEEmrSums.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcMEEmrSums.BOSComment = "";
            this.fld_dgcMEEmrSums.BOSDataMember = "";
            this.fld_dgcMEEmrSums.BOSDataSource = "MEEmrSums";
            this.fld_dgcMEEmrSums.BOSDescription = null;
            this.fld_dgcMEEmrSums.BOSError = null;
            this.fld_dgcMEEmrSums.BOSFieldGroup = "";
            this.fld_dgcMEEmrSums.BOSFieldRelation = "";
            this.fld_dgcMEEmrSums.BOSGridType = null;
            this.fld_dgcMEEmrSums.BOSPrivilege = "";
            this.fld_dgcMEEmrSums.BOSPropertyName = "";
            this.fld_dgcMEEmrSums.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMEEmrSums.Location = new System.Drawing.Point(3, 180);
            this.fld_dgcMEEmrSums.MainView = this.fld_dgvMEEmrSums;
            this.fld_dgcMEEmrSums.Name = "fld_dgcMEEmrSums";
            this.fld_dgcMEEmrSums.PrintReport = false;
            this.fld_dgcMEEmrSums.Screen = null;
            this.fld_dgcMEEmrSums.Size = new System.Drawing.Size(820, 347);
            this.fld_dgcMEEmrSums.TabIndex = 1000000024;
            this.fld_dgcMEEmrSums.Tag = "DC";
            this.fld_dgcMEEmrSums.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvMEEmrSums});
            // 
            // fld_dgvMEEmrSums
            // 
            this.fld_dgvMEEmrSums.GridControl = this.fld_dgcMEEmrSums;
            this.fld_dgvMEEmrSums.Name = "fld_dgvMEEmrSums";
            this.fld_dgvMEEmrSums.PaintStyleName = "Office2003";
            // 
            // chkDepartmentShared
            // 
            this.chkDepartmentShared.Location = new System.Drawing.Point(554, 42);
            this.chkDepartmentShared.MenuManager = this.screenToolbar;
            this.chkDepartmentShared.Name = "chkDepartmentShared";
            this.chkDepartmentShared.Properties.Caption = "Chỉ khoa chia sẻ";
            this.chkDepartmentShared.Size = new System.Drawing.Size(120, 23);
            this.chkDepartmentShared.TabIndex = 1000000011;
            this.chkDepartmentShared.Tag = "SC";
            this.chkDepartmentShared.CheckedChanged += new System.EventHandler(this.chkDepartmentShared_CheckedChanged);
            // 
            // fld_lkeFK_MEPatientID
            // 
            this.fld_lkeFK_MEPatientID.BOSAllowAddNew = false;
            this.fld_lkeFK_MEPatientID.BOSAllowDummy = true;
            this.fld_lkeFK_MEPatientID.BOSAllowMange = false;
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
            this.fld_lkeFK_MEPatientID.Enabled = false;
            this.fld_lkeFK_MEPatientID.Location = new System.Drawing.Point(102, 15);
            this.fld_lkeFK_MEPatientID.Name = "fld_lkeFK_MEPatientID";
            this.fld_lkeFK_MEPatientID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeFK_MEPatientID.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeFK_MEPatientID.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeFK_MEPatientID.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeFK_MEPatientID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_MEPatientID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MEPatientNo", "Mã bệnh nhân", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.True),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MEPatientName", "Tên bệnh nhân", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.True),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MEPatientBirthday", "Ngày sinh", 20, DevExpress.Utils.FormatType.DateTime, "d", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MEGender", "Giới tính")});
            this.fld_lkeFK_MEPatientID.Properties.DisplayMember = "MEPatientName";
            this.fld_lkeFK_MEPatientID.Properties.DropDownRows = 20;
            this.fld_lkeFK_MEPatientID.Properties.NullText = "";
            this.fld_lkeFK_MEPatientID.Properties.PopupWidth = 40;
            this.fld_lkeFK_MEPatientID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeFK_MEPatientID.Properties.ValueMember = "MEPatientID";
            this.fld_lkeFK_MEPatientID.Screen = null;
            this.fld_lkeFK_MEPatientID.Size = new System.Drawing.Size(85, 26);
            this.fld_lkeFK_MEPatientID.TabIndex = 1000000017;
            this.fld_lkeFK_MEPatientID.Tag = "SC";
            this.fld_lkeFK_MEPatientID.EditValueChanged += new System.EventHandler(this.fld_lkeFK_MEPatientID_EditValueChanged_1);
            // 
            // fld_lblLabel100
            // 
            this.fld_lblLabel100.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel100.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel100.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel100.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel100.BOSComment = "";
            this.fld_lblLabel100.BOSDataMember = "";
            this.fld_lblLabel100.BOSDataSource = "";
            this.fld_lblLabel100.BOSDescription = null;
            this.fld_lblLabel100.BOSError = null;
            this.fld_lblLabel100.BOSFieldGroup = "";
            this.fld_lblLabel100.BOSFieldRelation = "";
            this.fld_lblLabel100.BOSPrivilege = "";
            this.fld_lblLabel100.BOSPropertyName = "";
            this.fld_lblLabel100.Location = new System.Drawing.Point(20, 19);
            this.fld_lblLabel100.Name = "fld_lblLabel100";
            this.fld_lblLabel100.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_lblLabel100, true);
            this.fld_lblLabel100.Size = new System.Drawing.Size(75, 19);
            this.fld_lblLabel100.TabIndex = 1000000023;
            this.fld_lblLabel100.Tag = "SI";
            this.fld_lblLabel100.Text = "Bệnh nhân";
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
            this.bosLabel1.Location = new System.Drawing.Point(495, 97);
            this.bosLabel1.Name = "bosLabel1";
            this.bosLabel1.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel1, true);
            this.bosLabel1.Size = new System.Drawing.Size(6, 19);
            this.bosLabel1.TabIndex = 1000000016;
            this.bosLabel1.Tag = "SI";
            this.bosLabel1.Text = "-";
            // 
            // fld_cmbChooseView
            // 
            this.fld_cmbChooseView.Location = new System.Drawing.Point(86, 94);
            this.fld_cmbChooseView.MenuManager = this.screenToolbar;
            this.fld_cmbChooseView.Name = "fld_cmbChooseView";
            this.fld_cmbChooseView.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_cmbChooseView.Properties.Items.AddRange(new object[] {
            "Trong ngày",
            "Trong tuần",
            "Trong tháng",
            "Trong năm",
            "Tất cả"});
            this.ScreenHelper.SetShowHelp(this.fld_cmbChooseView, true);
            this.fld_cmbChooseView.Size = new System.Drawing.Size(242, 26);
            this.fld_cmbChooseView.TabIndex = 1000000014;
            this.fld_cmbChooseView.Tag = "SC";
            this.fld_cmbChooseView.SelectedIndexChanged += new System.EventHandler(this.fld_cmbChooseView_SelectedIndexChanged);
            // 
            // fld_ccbeFK_HRDepartmentID
            // 
            this.fld_ccbeFK_HRDepartmentID.BOSComment = null;
            this.fld_ccbeFK_HRDepartmentID.BOSDataMember = null;
            this.fld_ccbeFK_HRDepartmentID.BOSDataSource = "HRDepartments";
            this.fld_ccbeFK_HRDepartmentID.BOSDescription = null;
            this.fld_ccbeFK_HRDepartmentID.BOSError = null;
            this.fld_ccbeFK_HRDepartmentID.BOSFieldGroup = null;
            this.fld_ccbeFK_HRDepartmentID.BOSFieldRelation = null;
            this.fld_ccbeFK_HRDepartmentID.BOSPrivilege = null;
            this.fld_ccbeFK_HRDepartmentID.BOSPropertyName = null;
            this.fld_ccbeFK_HRDepartmentID.DisplayField = "HRDepartmentName";
            this.fld_ccbeFK_HRDepartmentID.Location = new System.Drawing.Point(86, 41);
            this.fld_ccbeFK_HRDepartmentID.MenuManager = this.screenToolbar;
            this.fld_ccbeFK_HRDepartmentID.Name = "fld_ccbeFK_HRDepartmentID";
            this.fld_ccbeFK_HRDepartmentID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_ccbeFK_HRDepartmentID.QuickLookupField = null;
            this.fld_ccbeFK_HRDepartmentID.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_ccbeFK_HRDepartmentID, true);
            this.fld_ccbeFK_HRDepartmentID.Size = new System.Drawing.Size(462, 26);
            this.fld_ccbeFK_HRDepartmentID.TabIndex = 1000000010;
            this.fld_ccbeFK_HRDepartmentID.Tag = "SC";
            this.fld_ccbeFK_HRDepartmentID.ValueField = "HRDepartmentID";
            // 
            // chkSearchByPatient
            // 
            this.chkSearchByPatient.Location = new System.Drawing.Point(84, 16);
            this.chkSearchByPatient.MenuManager = this.screenToolbar;
            this.chkSearchByPatient.Name = "chkSearchByPatient";
            this.chkSearchByPatient.Properties.Caption = "";
            this.chkSearchByPatient.Size = new System.Drawing.Size(19, 19);
            this.chkSearchByPatient.TabIndex = 1000000022;
            this.chkSearchByPatient.Tag = "SC";
            // 
            // bosLabel2
            // 
            this.bosLabel2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.bosLabel2.Location = new System.Drawing.Point(20, 97);
            this.bosLabel2.Name = "bosLabel2";
            this.bosLabel2.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel2, true);
            this.bosLabel2.Size = new System.Drawing.Size(63, 19);
            this.bosLabel2.TabIndex = 1000000019;
            this.bosLabel2.Tag = "SI";
            this.bosLabel2.Text = "Ngày tạo";
            // 
            // fld_dteSearchToMEEmrCreatedDate
            // 
            this.fld_dteSearchToMEEmrCreatedDate.BOSComment = "";
            this.fld_dteSearchToMEEmrCreatedDate.BOSDataMember = "MEEmrCreatedDateTo";
            this.fld_dteSearchToMEEmrCreatedDate.BOSDataSource = "";
            this.fld_dteSearchToMEEmrCreatedDate.BOSDescription = null;
            this.fld_dteSearchToMEEmrCreatedDate.BOSError = null;
            this.fld_dteSearchToMEEmrCreatedDate.BOSFieldGroup = "";
            this.fld_dteSearchToMEEmrCreatedDate.BOSFieldRelation = "";
            this.fld_dteSearchToMEEmrCreatedDate.BOSPrivilege = "";
            this.fld_dteSearchToMEEmrCreatedDate.BOSPropertyName = "EditValue";
            this.fld_dteSearchToMEEmrCreatedDate.EditValue = null;
            this.fld_dteSearchToMEEmrCreatedDate.Location = new System.Drawing.Point(505, 94);
            this.fld_dteSearchToMEEmrCreatedDate.Name = "fld_dteSearchToMEEmrCreatedDate";
            this.fld_dteSearchToMEEmrCreatedDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteSearchToMEEmrCreatedDate.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteSearchToMEEmrCreatedDate.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteSearchToMEEmrCreatedDate.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteSearchToMEEmrCreatedDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteSearchToMEEmrCreatedDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteSearchToMEEmrCreatedDate.Screen = null;
            this.fld_dteSearchToMEEmrCreatedDate.Size = new System.Drawing.Size(142, 26);
            this.fld_dteSearchToMEEmrCreatedDate.TabIndex = 1000000020;
            this.fld_dteSearchToMEEmrCreatedDate.Tag = "SC";
            // 
            // fld_lblLabel3
            // 
            this.fld_lblLabel3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.fld_lblLabel3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.fld_lblLabel3.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel3.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel3.BOSComment = null;
            this.fld_lblLabel3.BOSDataMember = null;
            this.fld_lblLabel3.BOSDataSource = null;
            this.fld_lblLabel3.BOSDescription = null;
            this.fld_lblLabel3.BOSError = null;
            this.fld_lblLabel3.BOSFieldGroup = null;
            this.fld_lblLabel3.BOSFieldRelation = null;
            this.fld_lblLabel3.BOSPrivilege = null;
            this.fld_lblLabel3.BOSPropertyName = null;
            this.fld_lblLabel3.Location = new System.Drawing.Point(20, 45);
            this.fld_lblLabel3.Name = "fld_lblLabel3";
            this.fld_lblLabel3.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_lblLabel3, true);
            this.fld_lblLabel3.Size = new System.Drawing.Size(35, 19);
            this.fld_lblLabel3.TabIndex = 1000000021;
            this.fld_lblLabel3.Tag = "SI";
            this.fld_lblLabel3.Text = "Khoa";
            // 
            // fld_dteSearchFromMEEmrCreatedDate
            // 
            this.fld_dteSearchFromMEEmrCreatedDate.BOSComment = "";
            this.fld_dteSearchFromMEEmrCreatedDate.BOSDataMember = "MEEmrCreatedDateFrom";
            this.fld_dteSearchFromMEEmrCreatedDate.BOSDataSource = "";
            this.fld_dteSearchFromMEEmrCreatedDate.BOSDescription = null;
            this.fld_dteSearchFromMEEmrCreatedDate.BOSError = null;
            this.fld_dteSearchFromMEEmrCreatedDate.BOSFieldGroup = "";
            this.fld_dteSearchFromMEEmrCreatedDate.BOSFieldRelation = "";
            this.fld_dteSearchFromMEEmrCreatedDate.BOSPrivilege = "";
            this.fld_dteSearchFromMEEmrCreatedDate.BOSPropertyName = "EditValue";
            this.fld_dteSearchFromMEEmrCreatedDate.EditValue = null;
            this.fld_dteSearchFromMEEmrCreatedDate.Location = new System.Drawing.Point(334, 94);
            this.fld_dteSearchFromMEEmrCreatedDate.Name = "fld_dteSearchFromMEEmrCreatedDate";
            this.fld_dteSearchFromMEEmrCreatedDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteSearchFromMEEmrCreatedDate.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteSearchFromMEEmrCreatedDate.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteSearchFromMEEmrCreatedDate.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteSearchFromMEEmrCreatedDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteSearchFromMEEmrCreatedDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteSearchFromMEEmrCreatedDate.Screen = null;
            this.fld_dteSearchFromMEEmrCreatedDate.Size = new System.Drawing.Size(155, 26);
            this.fld_dteSearchFromMEEmrCreatedDate.TabIndex = 1000000015;
            this.fld_dteSearchFromMEEmrCreatedDate.Tag = "SC";
            // 
            // DMEMRMAN03
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(826, 530);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DMEMRMAN03";
            this.Text = "Thông tin";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrSumStoreNoMAN03.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMEEmrSumStatusMAN03.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrSumNoMAN03.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEPatientName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEPatientNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_MEEmrTypeIDMAN03.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrNoMAN03.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrSums)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrSums)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDepartmentShared.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_MEPatientID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_cmbChooseView.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_ccbeFK_HRDepartmentID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSearchByPatient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchToMEEmrCreatedDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchToMEEmrCreatedDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchFromMEEmrCreatedDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchFromMEEmrCreatedDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private IContainer components;
        private BOSPanel panelControl1;
        private BOSTextBox fld_txtMEPatientName;
        private BOSTextBox fld_txtMEPatientNo;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private BOSLookupEdit fld_lkeFK_MEEmrTypeIDMAN03;
        private BOSLabel bosLabel6;
        private BOSTextBox fld_txtMEEmrNoMAN03;
        private BOSLabel fld_lblLabel;
        private MEEmrSumSelectionGridControl fld_dgcMEEmrSums;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvMEEmrSums;
        private DevExpress.XtraEditors.CheckEdit chkDepartmentShared;
        private BOSLookupEdit fld_lkeFK_MEPatientID;
        private BOSLabel fld_lblLabel100;
        private BOSLabel bosLabel1;
        private DevExpress.XtraEditors.ComboBoxEdit fld_cmbChooseView;
        private MultiColCheckedComboBoxEdit fld_ccbeFK_HRDepartmentID;
        private DevExpress.XtraEditors.CheckEdit chkSearchByPatient;
        private BOSLabel bosLabel2;
        private BOSDateEdit fld_dteSearchToMEEmrCreatedDate;
        private BOSLabel fld_lblLabel3;
        private BOSDateEdit fld_dteSearchFromMEEmrCreatedDate;
        private BOSTextBox fld_txtMEEmrSumNoMAN03;
        private BOSLabel bosLabel7;
        private BOSTextBox fld_txtMEEmrSumStoreNoMAN03;
        private BOSLabel bosLabel8;
        private DevExpress.XtraEditors.CheckEdit chkMEEmrSumStatusMAN03;
    }
}
