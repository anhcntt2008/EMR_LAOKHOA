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
    partial class DMEMRMAN01
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMEMRMAN01));
            this.panelControl1 = new BOSComponent.BOSPanel(this.components);
            this.fld_lkeMEEmrStatus = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel7 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel5 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel4 = new BOSComponent.BOSLabel(this.components);
            this.fld_dteSearchToMEEmrDateOut = new BOSComponent.BOSDateEdit(this.components);
            this.fld_dteSearchFromMEEmrDateOut = new BOSComponent.BOSDateEdit(this.components);
            this.fld_lkeMEEmrPatientGroup = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel3 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtMEPatientName = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtMEPatientNo = new BOSComponent.BOSTextBox(this.components);
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.fld_lkeFK_MEEmrTypeID = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel6 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtMEEmrNo = new BOSComponent.BOSTextBox(this.components);
            this.fld_lblLabel = new BOSComponent.BOSLabel(this.components);
            this.fld_dgcMEEmrs = new BOSERP.Modules.MEEmrManage.MEEmrSelectionGridControl();
            this.fld_dgvMEEmrs = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEEmrStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchToMEEmrDateOut.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchToMEEmrDateOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchFromMEEmrDateOut.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchFromMEEmrDateOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEEmrPatientGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEPatientName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEPatientNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_MEEmrTypeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrs)).BeginInit();
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
            this.panelControl1.Controls.Add(this.fld_lkeMEEmrStatus);
            this.panelControl1.Controls.Add(this.bosLabel7);
            this.panelControl1.Controls.Add(this.bosLabel5);
            this.panelControl1.Controls.Add(this.bosLabel4);
            this.panelControl1.Controls.Add(this.fld_dteSearchToMEEmrDateOut);
            this.panelControl1.Controls.Add(this.fld_dteSearchFromMEEmrDateOut);
            this.panelControl1.Controls.Add(this.fld_lkeMEEmrPatientGroup);
            this.panelControl1.Controls.Add(this.bosLabel3);
            this.panelControl1.Controls.Add(this.fld_txtMEPatientName);
            this.panelControl1.Controls.Add(this.fld_txtMEPatientNo);
            this.panelControl1.Controls.Add(this.btnSearch);
            this.panelControl1.Controls.Add(this.fld_lkeFK_MEEmrTypeID);
            this.panelControl1.Controls.Add(this.bosLabel6);
            this.panelControl1.Controls.Add(this.fld_txtMEEmrNo);
            this.panelControl1.Controls.Add(this.fld_lblLabel);
            this.panelControl1.Controls.Add(this.fld_dgcMEEmrs);
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
            // fld_lkeMEEmrStatus
            // 
            this.fld_lkeMEEmrStatus.BOSAllowAddNew = false;
            this.fld_lkeMEEmrStatus.BOSAllowDummy = true;
            this.fld_lkeMEEmrStatus.BOSAllowMange = false;
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
            this.fld_lkeMEEmrStatus.Location = new System.Drawing.Point(722, 120);
            this.fld_lkeMEEmrStatus.Name = "fld_lkeMEEmrStatus";
            this.fld_lkeMEEmrStatus.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeMEEmrStatus.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeMEEmrStatus.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeMEEmrStatus.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeMEEmrStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeMEEmrStatus.Properties.DisplayMember = "MEEmrStatus";
            this.fld_lkeMEEmrStatus.Properties.NullText = "";
            this.fld_lkeMEEmrStatus.Properties.PopupWidth = 40;
            this.fld_lkeMEEmrStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeMEEmrStatus.Properties.ValueMember = "MEEmrStatus";
            this.fld_lkeMEEmrStatus.Screen = null;
            this.fld_lkeMEEmrStatus.Size = new System.Drawing.Size(101, 22);
            this.fld_lkeMEEmrStatus.TabIndex = 1000000036;
            this.fld_lkeMEEmrStatus.Tag = "SC";
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
            this.bosLabel7.Location = new System.Drawing.Point(656, 123);
            this.bosLabel7.Name = "bosLabel7";
            this.bosLabel7.Screen = null;
            this.bosLabel7.Size = new System.Drawing.Size(62, 17);
            this.bosLabel7.TabIndex = 1000000037;
            this.bosLabel7.Tag = "SI";
            this.bosLabel7.Text = "Trạng thái";
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
            this.bosLabel5.Location = new System.Drawing.Point(264, 123);
            this.bosLabel5.Name = "bosLabel5";
            this.bosLabel5.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel5, true);
            this.bosLabel5.Size = new System.Drawing.Size(77, 17);
            this.bosLabel5.TabIndex = 1000000035;
            this.bosLabel5.Tag = "SI";
            this.bosLabel5.Text = "Ngày ra viện";
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
            this.bosLabel4.Location = new System.Drawing.Point(495, 123);
            this.bosLabel4.Name = "bosLabel4";
            this.bosLabel4.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel4, true);
            this.bosLabel4.Size = new System.Drawing.Size(5, 16);
            this.bosLabel4.TabIndex = 1000000033;
            this.bosLabel4.Tag = "SI";
            this.bosLabel4.Text = "-";
            // 
            // fld_dteSearchToMEEmrDateOut
            // 
            this.fld_dteSearchToMEEmrDateOut.BOSComment = "";
            this.fld_dteSearchToMEEmrDateOut.BOSDataMember = "MEEmrDateOutTo";
            this.fld_dteSearchToMEEmrDateOut.BOSDataSource = "";
            this.fld_dteSearchToMEEmrDateOut.BOSDescription = null;
            this.fld_dteSearchToMEEmrDateOut.BOSError = null;
            this.fld_dteSearchToMEEmrDateOut.BOSFieldGroup = "";
            this.fld_dteSearchToMEEmrDateOut.BOSFieldRelation = "";
            this.fld_dteSearchToMEEmrDateOut.BOSPrivilege = "";
            this.fld_dteSearchToMEEmrDateOut.BOSPropertyName = "EditValue";
            this.fld_dteSearchToMEEmrDateOut.EditValue = null;
            this.fld_dteSearchToMEEmrDateOut.Location = new System.Drawing.Point(505, 120);
            this.fld_dteSearchToMEEmrDateOut.Name = "fld_dteSearchToMEEmrDateOut";
            this.fld_dteSearchToMEEmrDateOut.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteSearchToMEEmrDateOut.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteSearchToMEEmrDateOut.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteSearchToMEEmrDateOut.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteSearchToMEEmrDateOut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteSearchToMEEmrDateOut.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteSearchToMEEmrDateOut.Screen = null;
            this.fld_dteSearchToMEEmrDateOut.Size = new System.Drawing.Size(142, 22);
            this.fld_dteSearchToMEEmrDateOut.TabIndex = 1000000034;
            this.fld_dteSearchToMEEmrDateOut.Tag = "SC";
            // 
            // fld_dteSearchFromMEEmrDateOut
            // 
            this.fld_dteSearchFromMEEmrDateOut.BOSComment = "";
            this.fld_dteSearchFromMEEmrDateOut.BOSDataMember = "MEEmrDateOutFrom";
            this.fld_dteSearchFromMEEmrDateOut.BOSDataSource = "";
            this.fld_dteSearchFromMEEmrDateOut.BOSDescription = null;
            this.fld_dteSearchFromMEEmrDateOut.BOSError = null;
            this.fld_dteSearchFromMEEmrDateOut.BOSFieldGroup = "";
            this.fld_dteSearchFromMEEmrDateOut.BOSFieldRelation = "";
            this.fld_dteSearchFromMEEmrDateOut.BOSPrivilege = "";
            this.fld_dteSearchFromMEEmrDateOut.BOSPropertyName = "EditValue";
            this.fld_dteSearchFromMEEmrDateOut.EditValue = null;
            this.fld_dteSearchFromMEEmrDateOut.Location = new System.Drawing.Point(334, 120);
            this.fld_dteSearchFromMEEmrDateOut.Name = "fld_dteSearchFromMEEmrDateOut";
            this.fld_dteSearchFromMEEmrDateOut.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteSearchFromMEEmrDateOut.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteSearchFromMEEmrDateOut.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteSearchFromMEEmrDateOut.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteSearchFromMEEmrDateOut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteSearchFromMEEmrDateOut.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteSearchFromMEEmrDateOut.Screen = null;
            this.fld_dteSearchFromMEEmrDateOut.Size = new System.Drawing.Size(155, 22);
            this.fld_dteSearchFromMEEmrDateOut.TabIndex = 1000000032;
            this.fld_dteSearchFromMEEmrDateOut.Tag = "SC";
            // 
            // fld_lkeMEEmrPatientGroup
            // 
            this.fld_lkeMEEmrPatientGroup.BOSAllowAddNew = false;
            this.fld_lkeMEEmrPatientGroup.BOSAllowDummy = true;
            this.fld_lkeMEEmrPatientGroup.BOSAllowMange = false;
            this.fld_lkeMEEmrPatientGroup.BOSComment = "";
            this.fld_lkeMEEmrPatientGroup.BOSDataMember = "MEEmrPatientGroup";
            this.fld_lkeMEEmrPatientGroup.BOSDataSource = "MEEmrs";
            this.fld_lkeMEEmrPatientGroup.BOSDescription = null;
            this.fld_lkeMEEmrPatientGroup.BOSDummyText = null;
            this.fld_lkeMEEmrPatientGroup.BOSError = null;
            this.fld_lkeMEEmrPatientGroup.BOSFieldGroup = "";
            this.fld_lkeMEEmrPatientGroup.BOSFieldParent = "";
            this.fld_lkeMEEmrPatientGroup.BOSFieldRelation = "";
            this.fld_lkeMEEmrPatientGroup.BOSPrivilege = "";
            this.fld_lkeMEEmrPatientGroup.BOSPropertyName = "EditValue";
            this.fld_lkeMEEmrPatientGroup.BOSSelectType = "";
            this.fld_lkeMEEmrPatientGroup.BOSSelectTypeValue = "";
            this.fld_lkeMEEmrPatientGroup.CurrentDisplayText = null;
            this.fld_lkeMEEmrPatientGroup.Location = new System.Drawing.Point(86, 119);
            this.fld_lkeMEEmrPatientGroup.Name = "fld_lkeMEEmrPatientGroup";
            this.fld_lkeMEEmrPatientGroup.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeMEEmrPatientGroup.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeMEEmrPatientGroup.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeMEEmrPatientGroup.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeMEEmrPatientGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeMEEmrPatientGroup.Properties.DisplayMember = "MEEmrPatientGroup";
            this.fld_lkeMEEmrPatientGroup.Properties.NullText = "";
            this.fld_lkeMEEmrPatientGroup.Properties.PopupWidth = 40;
            this.fld_lkeMEEmrPatientGroup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeMEEmrPatientGroup.Properties.ValueMember = "MEEmrPatientGroup";
            this.fld_lkeMEEmrPatientGroup.Screen = null;
            this.fld_lkeMEEmrPatientGroup.Size = new System.Drawing.Size(168, 22);
            this.fld_lkeMEEmrPatientGroup.TabIndex = 1000000030;
            this.fld_lkeMEEmrPatientGroup.Tag = "SC";
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
            this.bosLabel3.Location = new System.Drawing.Point(20, 122);
            this.bosLabel3.Name = "bosLabel3";
            this.bosLabel3.Screen = null;
            this.bosLabel3.Size = new System.Drawing.Size(62, 17);
            this.bosLabel3.TabIndex = 1000000031;
            this.bosLabel3.Tag = "SI";
            this.bosLabel3.Text = "Đối tượng";
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
            this.fld_txtMEPatientName.Size = new System.Drawing.Size(387, 22);
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
            this.fld_txtMEPatientNo.Size = new System.Drawing.Size(152, 22);
            this.fld_txtMEPatientNo.TabIndex = 1000000027;
            this.fld_txtMEPatientNo.Tag = "SC";
            this.fld_txtMEPatientNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fld_txtMEPatientNo_KeyUp);
            // 
            // btnSearch
            // 
            this.btnSearch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.ImageOptions.Image")));
            this.btnSearch.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSearch.Location = new System.Drawing.Point(86, 145);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1000000018;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // fld_lkeFK_MEEmrTypeID
            // 
            this.fld_lkeFK_MEEmrTypeID.BOSAllowAddNew = false;
            this.fld_lkeFK_MEEmrTypeID.BOSAllowDummy = true;
            this.fld_lkeFK_MEEmrTypeID.BOSAllowMange = false;
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
            this.fld_lkeFK_MEEmrTypeID.Location = new System.Drawing.Point(407, 67);
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
            this.fld_lkeFK_MEEmrTypeID.Size = new System.Drawing.Size(240, 22);
            this.fld_lkeFK_MEEmrTypeID.TabIndex = 1000000013;
            this.fld_lkeFK_MEEmrTypeID.Tag = "SC";
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
            this.bosLabel6.Size = new System.Drawing.Size(78, 17);
            this.bosLabel6.TabIndex = 1000000026;
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
            this.fld_txtMEEmrNo.Location = new System.Drawing.Point(86, 67);
            this.fld_txtMEEmrNo.Name = "fld_txtMEEmrNo";
            this.fld_txtMEEmrNo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEEmrNo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEEmrNo.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEEmrNo.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEEmrNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEEmrNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEEmrNo.Screen = null;
            this.fld_txtMEEmrNo.Size = new System.Drawing.Size(242, 22);
            this.fld_txtMEEmrNo.TabIndex = 1000000012;
            this.fld_txtMEEmrNo.Tag = "SC";
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
            this.fld_lblLabel.Size = new System.Drawing.Size(71, 17);
            this.fld_lblLabel.TabIndex = 1000000025;
            this.fld_lblLabel.Tag = "SI";
            this.fld_lblLabel.Text = "Mã bệnh án";
            // 
            // fld_dgcMEEmrs
            // 
            this.fld_dgcMEEmrs.AllowDrop = true;
            this.fld_dgcMEEmrs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcMEEmrs.BOSComment = "";
            this.fld_dgcMEEmrs.BOSDataMember = "";
            this.fld_dgcMEEmrs.BOSDataSource = "MEEmrs";
            this.fld_dgcMEEmrs.BOSDescription = null;
            this.fld_dgcMEEmrs.BOSError = null;
            this.fld_dgcMEEmrs.BOSFieldGroup = "";
            this.fld_dgcMEEmrs.BOSFieldRelation = "";
            this.fld_dgcMEEmrs.BOSGridType = null;
            this.fld_dgcMEEmrs.BOSPrivilege = "";
            this.fld_dgcMEEmrs.BOSPropertyName = "";
            this.fld_dgcMEEmrs.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMEEmrs.Location = new System.Drawing.Point(3, 174);
            this.fld_dgcMEEmrs.MainView = this.fld_dgvMEEmrs;
            this.fld_dgcMEEmrs.Name = "fld_dgcMEEmrs";
            this.fld_dgcMEEmrs.PrintReport = false;
            this.fld_dgcMEEmrs.Screen = null;
            this.fld_dgcMEEmrs.Size = new System.Drawing.Size(820, 353);
            this.fld_dgcMEEmrs.TabIndex = 1000000024;
            this.fld_dgcMEEmrs.Tag = "DC";
            this.fld_dgcMEEmrs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvMEEmrs});
            // 
            // fld_dgvMEEmrs
            // 
            this.fld_dgvMEEmrs.GridControl = this.fld_dgcMEEmrs;
            this.fld_dgvMEEmrs.Name = "fld_dgvMEEmrs";
            this.fld_dgvMEEmrs.PaintStyleName = "Office2003";
            // 
            // chkDepartmentShared
            // 
            this.chkDepartmentShared.Location = new System.Drawing.Point(554, 42);
            this.chkDepartmentShared.MenuManager = this.screenToolbar;
            this.chkDepartmentShared.Name = "chkDepartmentShared";
            this.chkDepartmentShared.Properties.Caption = "Chỉ khoa chia sẻ";
            this.chkDepartmentShared.Size = new System.Drawing.Size(120, 21);
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
            this.fld_lkeFK_MEPatientID.Size = new System.Drawing.Size(85, 22);
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
            this.fld_lblLabel100.Size = new System.Drawing.Size(66, 17);
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
            this.bosLabel1.Size = new System.Drawing.Size(5, 16);
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
            this.fld_cmbChooseView.Size = new System.Drawing.Size(242, 22);
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
            this.fld_ccbeFK_HRDepartmentID.Size = new System.Drawing.Size(462, 22);
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
            this.bosLabel2.Size = new System.Drawing.Size(56, 17);
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
            this.fld_dteSearchToMEEmrCreatedDate.Size = new System.Drawing.Size(142, 22);
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
            this.fld_lblLabel3.Size = new System.Drawing.Size(28, 16);
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
            this.fld_dteSearchFromMEEmrCreatedDate.Size = new System.Drawing.Size(155, 22);
            this.fld_dteSearchFromMEEmrCreatedDate.TabIndex = 1000000015;
            this.fld_dteSearchFromMEEmrCreatedDate.Tag = "SC";
            // 
            // DMEMRMAN01
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(826, 530);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DMEMRMAN01";
            this.Text = "Thông tin";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEEmrStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchToMEEmrDateOut.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchToMEEmrDateOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchFromMEEmrDateOut.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchFromMEEmrDateOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEEmrPatientGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEPatientName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEPatientNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_MEEmrTypeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrs)).EndInit();
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
        private BOSLookupEdit fld_lkeFK_MEEmrTypeID;
        private BOSLabel bosLabel6;
        private BOSTextBox fld_txtMEEmrNo;
        private BOSLabel fld_lblLabel;
        private MEEmrSelectionGridControl fld_dgcMEEmrs;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvMEEmrs;
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
        private BOSLookupEdit fld_lkeMEEmrPatientGroup;
        private BOSLabel bosLabel3;
        private BOSLabel bosLabel5;
        private BOSLabel bosLabel4;
        private BOSDateEdit fld_dteSearchToMEEmrDateOut;
        private BOSDateEdit fld_dteSearchFromMEEmrDateOut;
        private BOSLookupEdit fld_lkeMEEmrStatus;
        private BOSLabel bosLabel7;
    }
}
