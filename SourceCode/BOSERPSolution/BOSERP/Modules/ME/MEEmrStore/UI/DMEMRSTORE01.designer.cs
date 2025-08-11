using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSComponent;

namespace BOSERP.Modules.MEEmrStore.UI
{
    /// <summary>
    /// Summary description for DMEMRSTORE01
    /// </summary>
    partial class DMEMRSTORE01
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMEMRSTORE01));
            this.panelControl1 = new BOSComponent.BOSPanel(this.components);
            this.bosLabel6 = new BOSComponent.BOSLabel(this.components);
            this.fld_cmbChooseViewStoreDate = new DevExpress.XtraEditors.ComboBoxEdit();
            this.bosLabel8 = new BOSComponent.BOSLabel(this.components);
            this.fld_dteSearchToMEEmrArchiveBackupDate = new BOSComponent.BOSDateEdit(this.components);
            this.fld_dteSearchFromMEEmrArchiveBackupDate = new BOSComponent.BOSDateEdit(this.components);
            this.fld_lkeMEEmrArchiveBackupStatus = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel7 = new BOSComponent.BOSLabel(this.components);
            this.fld_lkeMEEmrArchiveStatus = new BOSComponent.BOSLookupEdit(this.components);
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.fld_dgcMEEmrArchives = new BOSERP.Modules.MEEmrStore.MEEmrArchivesSelectionGridControl();
            this.fld_dgvMEEmrArchives = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_lblLabel100 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel1 = new BOSComponent.BOSLabel(this.components);
            this.fld_cmbChooseView = new DevExpress.XtraEditors.ComboBoxEdit();
            this.bosLabel2 = new BOSComponent.BOSLabel(this.components);
            this.fld_dteSearchToMEEmrCreatedDate = new BOSComponent.BOSDateEdit(this.components);
            this.fld_dteSearchFromMEEmrCreatedDate = new BOSComponent.BOSDateEdit(this.components);
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_cmbChooseViewStoreDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchToMEEmrArchiveBackupDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchToMEEmrArchiveBackupDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchFromMEEmrArchiveBackupDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchFromMEEmrArchiveBackupDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEEmrArchiveBackupStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEEmrArchiveStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrArchives)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrArchives)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_cmbChooseView.Properties)).BeginInit();
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
            this.panelControl1.Controls.Add(this.bosLabel6);
            this.panelControl1.Controls.Add(this.fld_cmbChooseViewStoreDate);
            this.panelControl1.Controls.Add(this.bosLabel8);
            this.panelControl1.Controls.Add(this.fld_dteSearchToMEEmrArchiveBackupDate);
            this.panelControl1.Controls.Add(this.fld_dteSearchFromMEEmrArchiveBackupDate);
            this.panelControl1.Controls.Add(this.fld_lkeMEEmrArchiveBackupStatus);
            this.panelControl1.Controls.Add(this.bosLabel7);
            this.panelControl1.Controls.Add(this.fld_lkeMEEmrArchiveStatus);
            this.panelControl1.Controls.Add(this.btnSearch);
            this.panelControl1.Controls.Add(this.fld_dgcMEEmrArchives);
            this.panelControl1.Controls.Add(this.fld_lblLabel100);
            this.panelControl1.Controls.Add(this.bosLabel1);
            this.panelControl1.Controls.Add(this.fld_cmbChooseView);
            this.panelControl1.Controls.Add(this.bosLabel2);
            this.panelControl1.Controls.Add(this.fld_dteSearchToMEEmrCreatedDate);
            this.panelControl1.Controls.Add(this.fld_dteSearchFromMEEmrCreatedDate);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Screen = null;
            this.panelControl1.Size = new System.Drawing.Size(826, 530);
            this.panelControl1.TabIndex = 0;
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
            this.bosLabel6.Location = new System.Drawing.Point(495, 70);
            this.bosLabel6.Name = "bosLabel6";
            this.bosLabel6.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel6, true);
            this.bosLabel6.Size = new System.Drawing.Size(4, 13);
            this.bosLabel6.TabIndex = 1000000041;
            this.bosLabel6.Tag = "SI";
            this.bosLabel6.Text = "-";
            // 
            // fld_cmbChooseViewStoreDate
            // 
            this.fld_cmbChooseViewStoreDate.Location = new System.Drawing.Point(86, 67);
            this.fld_cmbChooseViewStoreDate.MenuManager = this.screenToolbar;
            this.fld_cmbChooseViewStoreDate.Name = "fld_cmbChooseViewStoreDate";
            this.fld_cmbChooseViewStoreDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_cmbChooseViewStoreDate.Properties.Items.AddRange(new object[] {
            "Trong ngày",
            "Trong tuần",
            "Trong tháng",
            "Trong năm",
            "Tất cả"});
            this.ScreenHelper.SetShowHelp(this.fld_cmbChooseViewStoreDate, true);
            this.fld_cmbChooseViewStoreDate.Size = new System.Drawing.Size(242, 20);
            this.fld_cmbChooseViewStoreDate.TabIndex = 1000000039;
            this.fld_cmbChooseViewStoreDate.Tag = "SC";
            this.fld_cmbChooseViewStoreDate.SelectedIndexChanged += new System.EventHandler(this.fld_cmbChooseViewStoreDate_SelectedIndexChanged);
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
            this.bosLabel8.Location = new System.Drawing.Point(20, 70);
            this.bosLabel8.Name = "bosLabel8";
            this.bosLabel8.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel8, true);
            this.bosLabel8.Size = new System.Drawing.Size(61, 13);
            this.bosLabel8.TabIndex = 1000000042;
            this.bosLabel8.Tag = "SI";
            this.bosLabel8.Text = "Ngày lưu trữ";
            // 
            // fld_dteSearchToMEEmrArchiveBackupDate
            // 
            this.fld_dteSearchToMEEmrArchiveBackupDate.BOSComment = "";
            this.fld_dteSearchToMEEmrArchiveBackupDate.BOSDataMember = "MEEmrArchiveBackupDateTo";
            this.fld_dteSearchToMEEmrArchiveBackupDate.BOSDataSource = "";
            this.fld_dteSearchToMEEmrArchiveBackupDate.BOSDescription = null;
            this.fld_dteSearchToMEEmrArchiveBackupDate.BOSError = null;
            this.fld_dteSearchToMEEmrArchiveBackupDate.BOSFieldGroup = "";
            this.fld_dteSearchToMEEmrArchiveBackupDate.BOSFieldRelation = "";
            this.fld_dteSearchToMEEmrArchiveBackupDate.BOSPrivilege = "";
            this.fld_dteSearchToMEEmrArchiveBackupDate.BOSPropertyName = "EditValue";
            this.fld_dteSearchToMEEmrArchiveBackupDate.EditValue = null;
            this.fld_dteSearchToMEEmrArchiveBackupDate.Location = new System.Drawing.Point(505, 67);
            this.fld_dteSearchToMEEmrArchiveBackupDate.Name = "fld_dteSearchToMEEmrArchiveBackupDate";
            this.fld_dteSearchToMEEmrArchiveBackupDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteSearchToMEEmrArchiveBackupDate.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteSearchToMEEmrArchiveBackupDate.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteSearchToMEEmrArchiveBackupDate.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteSearchToMEEmrArchiveBackupDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteSearchToMEEmrArchiveBackupDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteSearchToMEEmrArchiveBackupDate.Screen = null;
            this.fld_dteSearchToMEEmrArchiveBackupDate.Size = new System.Drawing.Size(142, 20);
            this.fld_dteSearchToMEEmrArchiveBackupDate.TabIndex = 1000000043;
            this.fld_dteSearchToMEEmrArchiveBackupDate.Tag = "SC";
            // 
            // fld_dteSearchFromMEEmrArchiveBackupDate
            // 
            this.fld_dteSearchFromMEEmrArchiveBackupDate.BOSComment = "";
            this.fld_dteSearchFromMEEmrArchiveBackupDate.BOSDataMember = "MEEmrArchiveBackupDateFrom";
            this.fld_dteSearchFromMEEmrArchiveBackupDate.BOSDataSource = "";
            this.fld_dteSearchFromMEEmrArchiveBackupDate.BOSDescription = null;
            this.fld_dteSearchFromMEEmrArchiveBackupDate.BOSError = null;
            this.fld_dteSearchFromMEEmrArchiveBackupDate.BOSFieldGroup = "";
            this.fld_dteSearchFromMEEmrArchiveBackupDate.BOSFieldRelation = "";
            this.fld_dteSearchFromMEEmrArchiveBackupDate.BOSPrivilege = "";
            this.fld_dteSearchFromMEEmrArchiveBackupDate.BOSPropertyName = "EditValue";
            this.fld_dteSearchFromMEEmrArchiveBackupDate.EditValue = null;
            this.fld_dteSearchFromMEEmrArchiveBackupDate.Location = new System.Drawing.Point(334, 67);
            this.fld_dteSearchFromMEEmrArchiveBackupDate.Name = "fld_dteSearchFromMEEmrArchiveBackupDate";
            this.fld_dteSearchFromMEEmrArchiveBackupDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteSearchFromMEEmrArchiveBackupDate.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteSearchFromMEEmrArchiveBackupDate.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteSearchFromMEEmrArchiveBackupDate.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteSearchFromMEEmrArchiveBackupDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteSearchFromMEEmrArchiveBackupDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteSearchFromMEEmrArchiveBackupDate.Screen = null;
            this.fld_dteSearchFromMEEmrArchiveBackupDate.Size = new System.Drawing.Size(155, 20);
            this.fld_dteSearchFromMEEmrArchiveBackupDate.TabIndex = 1000000040;
            this.fld_dteSearchFromMEEmrArchiveBackupDate.Tag = "SC";
            // 
            // fld_lkeMEEmrArchiveBackupStatus
            // 
            this.fld_lkeMEEmrArchiveBackupStatus.BOSAllowAddNew = false;
            this.fld_lkeMEEmrArchiveBackupStatus.BOSAllowDummy = true;
            this.fld_lkeMEEmrArchiveBackupStatus.BOSComment = "";
            this.fld_lkeMEEmrArchiveBackupStatus.BOSDataMember = "MEEmrArchiveBackupStatus";
            this.fld_lkeMEEmrArchiveBackupStatus.BOSDataSource = "MEEmrArchives";
            this.fld_lkeMEEmrArchiveBackupStatus.BOSDescription = null;
            this.fld_lkeMEEmrArchiveBackupStatus.BOSDummyText = null;
            this.fld_lkeMEEmrArchiveBackupStatus.BOSError = null;
            this.fld_lkeMEEmrArchiveBackupStatus.BOSFieldGroup = "";
            this.fld_lkeMEEmrArchiveBackupStatus.BOSFieldParent = "";
            this.fld_lkeMEEmrArchiveBackupStatus.BOSFieldRelation = "";
            this.fld_lkeMEEmrArchiveBackupStatus.BOSPrivilege = "";
            this.fld_lkeMEEmrArchiveBackupStatus.BOSPropertyName = "EditValue";
            this.fld_lkeMEEmrArchiveBackupStatus.BOSSelectType = "";
            this.fld_lkeMEEmrArchiveBackupStatus.BOSSelectTypeValue = "";
            this.fld_lkeMEEmrArchiveBackupStatus.CurrentDisplayText = null;
            this.fld_lkeMEEmrArchiveBackupStatus.Location = new System.Drawing.Point(407, 15);
            this.fld_lkeMEEmrArchiveBackupStatus.Name = "fld_lkeMEEmrArchiveBackupStatus";
            this.fld_lkeMEEmrArchiveBackupStatus.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeMEEmrArchiveBackupStatus.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeMEEmrArchiveBackupStatus.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeMEEmrArchiveBackupStatus.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeMEEmrArchiveBackupStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeMEEmrArchiveBackupStatus.Properties.DisplayMember = "MEEmrArchiveBackupStatus";
            this.fld_lkeMEEmrArchiveBackupStatus.Properties.NullText = "";
            this.fld_lkeMEEmrArchiveBackupStatus.Properties.PopupWidth = 40;
            this.fld_lkeMEEmrArchiveBackupStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeMEEmrArchiveBackupStatus.Properties.ValueMember = "MEEmrArchiveBackupStatus";
            this.fld_lkeMEEmrArchiveBackupStatus.Screen = null;
            this.fld_lkeMEEmrArchiveBackupStatus.Size = new System.Drawing.Size(240, 20);
            this.fld_lkeMEEmrArchiveBackupStatus.TabIndex = 1000000038;
            this.fld_lkeMEEmrArchiveBackupStatus.Tag = "SC";
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
            this.bosLabel7.Location = new System.Drawing.Point(334, 18);
            this.bosLabel7.Name = "bosLabel7";
            this.bosLabel7.Screen = null;
            this.bosLabel7.Size = new System.Drawing.Size(36, 13);
            this.bosLabel7.TabIndex = 1000000037;
            this.bosLabel7.Tag = "SI";
            this.bosLabel7.Text = "Lưu trữ";
            // 
            // fld_lkeMEEmrArchiveStatus
            // 
            this.fld_lkeMEEmrArchiveStatus.BOSAllowAddNew = false;
            this.fld_lkeMEEmrArchiveStatus.BOSAllowDummy = true;
            this.fld_lkeMEEmrArchiveStatus.BOSComment = "";
            this.fld_lkeMEEmrArchiveStatus.BOSDataMember = "MEEmrArchiveStatus";
            this.fld_lkeMEEmrArchiveStatus.BOSDataSource = "MEEmrArchives";
            this.fld_lkeMEEmrArchiveStatus.BOSDescription = null;
            this.fld_lkeMEEmrArchiveStatus.BOSDummyText = null;
            this.fld_lkeMEEmrArchiveStatus.BOSError = null;
            this.fld_lkeMEEmrArchiveStatus.BOSFieldGroup = "";
            this.fld_lkeMEEmrArchiveStatus.BOSFieldParent = "";
            this.fld_lkeMEEmrArchiveStatus.BOSFieldRelation = "";
            this.fld_lkeMEEmrArchiveStatus.BOSPrivilege = "";
            this.fld_lkeMEEmrArchiveStatus.BOSPropertyName = "EditValue";
            this.fld_lkeMEEmrArchiveStatus.BOSSelectType = "";
            this.fld_lkeMEEmrArchiveStatus.BOSSelectTypeValue = "";
            this.fld_lkeMEEmrArchiveStatus.CurrentDisplayText = null;
            this.fld_lkeMEEmrArchiveStatus.Location = new System.Drawing.Point(86, 15);
            this.fld_lkeMEEmrArchiveStatus.Name = "fld_lkeMEEmrArchiveStatus";
            this.fld_lkeMEEmrArchiveStatus.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeMEEmrArchiveStatus.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeMEEmrArchiveStatus.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeMEEmrArchiveStatus.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeMEEmrArchiveStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeMEEmrArchiveStatus.Properties.DisplayMember = "MEEmrArchiveStatus";
            this.fld_lkeMEEmrArchiveStatus.Properties.NullText = "";
            this.fld_lkeMEEmrArchiveStatus.Properties.PopupWidth = 40;
            this.fld_lkeMEEmrArchiveStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeMEEmrArchiveStatus.Properties.ValueMember = "MEEmrArchiveStatus";
            this.fld_lkeMEEmrArchiveStatus.Screen = null;
            this.fld_lkeMEEmrArchiveStatus.Size = new System.Drawing.Size(242, 20);
            this.fld_lkeMEEmrArchiveStatus.TabIndex = 1000000036;
            this.fld_lkeMEEmrArchiveStatus.Tag = "SC";
            // 
            // btnSearch
            // 
            this.btnSearch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.ImageOptions.Image")));
            this.btnSearch.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSearch.Location = new System.Drawing.Point(86, 93);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1000000018;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // fld_dgcMEEmrArchives
            // 
            this.fld_dgcMEEmrArchives.AllowDrop = true;
            this.fld_dgcMEEmrArchives.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcMEEmrArchives.BOSComment = "";
            this.fld_dgcMEEmrArchives.BOSDataMember = "";
            this.fld_dgcMEEmrArchives.BOSDataSource = "MEEmrArchives";
            this.fld_dgcMEEmrArchives.BOSDescription = null;
            this.fld_dgcMEEmrArchives.BOSError = null;
            this.fld_dgcMEEmrArchives.BOSFieldGroup = "";
            this.fld_dgcMEEmrArchives.BOSFieldRelation = "";
            this.fld_dgcMEEmrArchives.BOSGridType = null;
            this.fld_dgcMEEmrArchives.BOSPrivilege = "";
            this.fld_dgcMEEmrArchives.BOSPropertyName = "";
            this.fld_dgcMEEmrArchives.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMEEmrArchives.Location = new System.Drawing.Point(3, 122);
            this.fld_dgcMEEmrArchives.MainView = this.fld_dgvMEEmrArchives;
            this.fld_dgcMEEmrArchives.Name = "fld_dgcMEEmrArchives";
            this.fld_dgcMEEmrArchives.PrintReport = false;
            this.fld_dgcMEEmrArchives.Screen = null;
            this.fld_dgcMEEmrArchives.Size = new System.Drawing.Size(820, 405);
            this.fld_dgcMEEmrArchives.TabIndex = 1000000024;
            this.fld_dgcMEEmrArchives.Tag = "DC";
            this.fld_dgcMEEmrArchives.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvMEEmrArchives});
            // 
            // fld_dgvMEEmrArchives
            // 
            this.fld_dgvMEEmrArchives.GridControl = this.fld_dgcMEEmrArchives;
            this.fld_dgvMEEmrArchives.Name = "fld_dgvMEEmrArchives";
            this.fld_dgvMEEmrArchives.PaintStyleName = "Office2003";
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
            this.fld_lblLabel100.Size = new System.Drawing.Size(26, 13);
            this.fld_lblLabel100.TabIndex = 1000000023;
            this.fld_lblLabel100.Tag = "SI";
            this.fld_lblLabel100.Text = "Ký số";
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
            this.bosLabel1.Location = new System.Drawing.Point(495, 44);
            this.bosLabel1.Name = "bosLabel1";
            this.bosLabel1.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel1, true);
            this.bosLabel1.Size = new System.Drawing.Size(4, 13);
            this.bosLabel1.TabIndex = 1000000016;
            this.bosLabel1.Tag = "SI";
            this.bosLabel1.Text = "-";
            // 
            // fld_cmbChooseView
            // 
            this.fld_cmbChooseView.Location = new System.Drawing.Point(86, 41);
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
            this.fld_cmbChooseView.Size = new System.Drawing.Size(242, 20);
            this.fld_cmbChooseView.TabIndex = 1000000014;
            this.fld_cmbChooseView.Tag = "SC";
            this.fld_cmbChooseView.SelectedIndexChanged += new System.EventHandler(this.fld_cmbChooseView_SelectedIndexChanged);
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
            this.bosLabel2.Location = new System.Drawing.Point(20, 44);
            this.bosLabel2.Name = "bosLabel2";
            this.bosLabel2.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel2, true);
            this.bosLabel2.Size = new System.Drawing.Size(44, 13);
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
            this.fld_dteSearchToMEEmrCreatedDate.Location = new System.Drawing.Point(505, 41);
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
            this.fld_dteSearchToMEEmrCreatedDate.Size = new System.Drawing.Size(142, 20);
            this.fld_dteSearchToMEEmrCreatedDate.TabIndex = 1000000020;
            this.fld_dteSearchToMEEmrCreatedDate.Tag = "SC";
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
            this.fld_dteSearchFromMEEmrCreatedDate.Location = new System.Drawing.Point(334, 41);
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
            this.fld_dteSearchFromMEEmrCreatedDate.Size = new System.Drawing.Size(155, 20);
            this.fld_dteSearchFromMEEmrCreatedDate.TabIndex = 1000000015;
            this.fld_dteSearchFromMEEmrCreatedDate.Tag = "SC";
            // 
            // DMEMRSTORE01
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(826, 530);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DMEMRSTORE01";
            this.Text = "Thông tin";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_cmbChooseViewStoreDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchToMEEmrArchiveBackupDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchToMEEmrArchiveBackupDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchFromMEEmrArchiveBackupDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchFromMEEmrArchiveBackupDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEEmrArchiveBackupStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEEmrArchiveStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrArchives)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrArchives)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_cmbChooseView.Properties)).EndInit();
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
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private MEEmrArchivesSelectionGridControl fld_dgcMEEmrArchives;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvMEEmrArchives;
        private BOSLabel bosLabel1;
        private DevExpress.XtraEditors.ComboBoxEdit fld_cmbChooseView;
        private BOSLabel bosLabel2;
        private BOSDateEdit fld_dteSearchToMEEmrCreatedDate;
        private BOSDateEdit fld_dteSearchFromMEEmrCreatedDate;
        private BOSLookupEdit fld_lkeMEEmrArchiveStatus;
        private BOSLabel fld_lblLabel100;
        private BOSLabel bosLabel7;
        private BOSLookupEdit fld_lkeMEEmrArchiveBackupStatus;
        private BOSLabel bosLabel6;
        private DevExpress.XtraEditors.ComboBoxEdit fld_cmbChooseViewStoreDate;
        private BOSLabel bosLabel8;
        private BOSDateEdit fld_dteSearchToMEEmrArchiveBackupDate;
        private BOSDateEdit fld_dteSearchFromMEEmrArchiveBackupDate;
    }
}
