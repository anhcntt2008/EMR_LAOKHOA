using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSComponent;

namespace BOSERP.Modules.MEDocumentManage.UI
{
    partial class DMEMRDOCMAN02
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMEMRDOCMAN02));
            this.panelControl1 = new BOSComponent.BOSPanel(this.components);
            this.fld_lkeMEEmrDocumentStatus = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel4 = new BOSComponent.BOSLabel(this.components);
            this.fld_ccbeMETemplateID = new BOSComponent.MultiColCheckedComboBoxEdit(this.components);
            this.fld_dgcMEEmrDocuments = new BOSERP.Modules.MEDocumentManage.MEEmrDocumentToolSelectionGridControl();
            this.fld_dgvMEEmrDocuments = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_lblLabel9 = new BOSComponent.BOSLabel(this.components);
            this.fld_dteSearchToMEEmrDocumentCreatedDate = new BOSComponent.BOSDateEdit(this.components);
            this.bosLabel2 = new BOSComponent.BOSLabel(this.components);
            this.fld_dteSearchFromMEEmrDocumentCreatedDate = new BOSComponent.BOSDateEdit(this.components);
            this.bosLabel3 = new BOSComponent.BOSLabel(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fld_btnRefreshDocument = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEEmrDocumentStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_ccbeMETemplateID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchToMEEmrDocumentCreatedDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchToMEEmrDocumentCreatedDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchFromMEEmrDocumentCreatedDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchFromMEEmrDocumentCreatedDate.Properties)).BeginInit();
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
            this.panelControl1.Controls.Add(this.fld_lkeMEEmrDocumentStatus);
            this.panelControl1.Controls.Add(this.bosLabel4);
            this.panelControl1.Controls.Add(this.fld_ccbeMETemplateID);
            this.panelControl1.Controls.Add(this.fld_dgcMEEmrDocuments);
            this.panelControl1.Controls.Add(this.fld_lblLabel9);
            this.panelControl1.Controls.Add(this.fld_dteSearchToMEEmrDocumentCreatedDate);
            this.panelControl1.Controls.Add(this.bosLabel2);
            this.panelControl1.Controls.Add(this.fld_dteSearchFromMEEmrDocumentCreatedDate);
            this.panelControl1.Controls.Add(this.bosLabel3);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.fld_btnRefreshDocument);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Screen = null;
            this.panelControl1.Size = new System.Drawing.Size(826, 530);
            this.panelControl1.TabIndex = 0;
            // 
            // fld_lkeMEEmrDocumentStatus
            // 
            this.fld_lkeMEEmrDocumentStatus.BOSAllowAddNew = false;
            this.fld_lkeMEEmrDocumentStatus.BOSAllowDummy = true;
            this.fld_lkeMEEmrDocumentStatus.BOSComment = "";
            this.fld_lkeMEEmrDocumentStatus.BOSDataMember = "MEEmrDocumentStatus";
            this.fld_lkeMEEmrDocumentStatus.BOSDataSource = "MEEmrDocuments";
            this.fld_lkeMEEmrDocumentStatus.BOSDescription = null;
            this.fld_lkeMEEmrDocumentStatus.BOSDummyText = null;
            this.fld_lkeMEEmrDocumentStatus.BOSError = null;
            this.fld_lkeMEEmrDocumentStatus.BOSFieldGroup = "";
            this.fld_lkeMEEmrDocumentStatus.BOSFieldParent = "";
            this.fld_lkeMEEmrDocumentStatus.BOSFieldRelation = "";
            this.fld_lkeMEEmrDocumentStatus.BOSPrivilege = "";
            this.fld_lkeMEEmrDocumentStatus.BOSPropertyName = "EditValue";
            this.fld_lkeMEEmrDocumentStatus.BOSSelectType = "";
            this.fld_lkeMEEmrDocumentStatus.BOSSelectTypeValue = "";
            this.fld_lkeMEEmrDocumentStatus.CurrentDisplayText = null;
            this.fld_lkeMEEmrDocumentStatus.Location = new System.Drawing.Point(557, 12);
            this.fld_lkeMEEmrDocumentStatus.Name = "fld_lkeMEEmrDocumentStatus";
            this.fld_lkeMEEmrDocumentStatus.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeMEEmrDocumentStatus.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeMEEmrDocumentStatus.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeMEEmrDocumentStatus.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeMEEmrDocumentStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeMEEmrDocumentStatus.Properties.DisplayMember = "MEEmrDocumentStatus";
            this.fld_lkeMEEmrDocumentStatus.Properties.NullText = "";
            this.fld_lkeMEEmrDocumentStatus.Properties.PopupWidth = 40;
            this.fld_lkeMEEmrDocumentStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeMEEmrDocumentStatus.Properties.ValueMember = "MEEmrDocumentStatus";
            this.fld_lkeMEEmrDocumentStatus.Screen = null;
            this.fld_lkeMEEmrDocumentStatus.Size = new System.Drawing.Size(249, 20);
            this.fld_lkeMEEmrDocumentStatus.TabIndex = 1000000038;
            this.fld_lkeMEEmrDocumentStatus.Tag = "SC";
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
            this.bosLabel4.Location = new System.Drawing.Point(478, 15);
            this.bosLabel4.Name = "bosLabel4";
            this.bosLabel4.Screen = null;
            this.bosLabel4.Size = new System.Drawing.Size(49, 13);
            this.bosLabel4.TabIndex = 1000000033;
            this.bosLabel4.Tag = "SI";
            this.bosLabel4.Text = "Trạng thái";
            // 
            // fld_ccbeMETemplateID
            // 
            this.fld_ccbeMETemplateID.BOSComment = null;
            this.fld_ccbeMETemplateID.BOSDataMember = null;
            this.fld_ccbeMETemplateID.BOSDataSource = "METemplates";
            this.fld_ccbeMETemplateID.BOSDescription = null;
            this.fld_ccbeMETemplateID.BOSError = null;
            this.fld_ccbeMETemplateID.BOSFieldGroup = null;
            this.fld_ccbeMETemplateID.BOSFieldRelation = null;
            this.fld_ccbeMETemplateID.BOSPrivilege = null;
            this.fld_ccbeMETemplateID.BOSPropertyName = null;
            this.fld_ccbeMETemplateID.DisplayField = "METemplateNo";
            this.fld_ccbeMETemplateID.Location = new System.Drawing.Point(79, 40);
            this.fld_ccbeMETemplateID.MenuManager = this.screenToolbar;
            this.fld_ccbeMETemplateID.Name = "fld_ccbeMETemplateID";
            this.fld_ccbeMETemplateID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_ccbeMETemplateID.QuickLookupField = null;
            this.fld_ccbeMETemplateID.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_ccbeMETemplateID, true);
            this.fld_ccbeMETemplateID.Size = new System.Drawing.Size(727, 20);
            this.fld_ccbeMETemplateID.TabIndex = 1000000037;
            this.fld_ccbeMETemplateID.Tag = "SC";
            this.fld_ccbeMETemplateID.ValueField = "METemplateID";
            // 
            // fld_dgcMEEmrDocuments
            // 
            this.fld_dgcMEEmrDocuments.AllowDrop = true;
            this.fld_dgcMEEmrDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcMEEmrDocuments.BOSComment = "";
            this.fld_dgcMEEmrDocuments.BOSDataMember = "";
            this.fld_dgcMEEmrDocuments.BOSDataSource = "MEEmrDocuments";
            this.fld_dgcMEEmrDocuments.BOSDescription = null;
            this.fld_dgcMEEmrDocuments.BOSError = null;
            this.fld_dgcMEEmrDocuments.BOSFieldGroup = "";
            this.fld_dgcMEEmrDocuments.BOSFieldRelation = "";
            this.fld_dgcMEEmrDocuments.BOSGridType = null;
            this.fld_dgcMEEmrDocuments.BOSPrivilege = "";
            this.fld_dgcMEEmrDocuments.BOSPropertyName = "";
            this.fld_dgcMEEmrDocuments.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMEEmrDocuments.Location = new System.Drawing.Point(3, 102);
            this.fld_dgcMEEmrDocuments.MainView = this.fld_dgvMEEmrDocuments;
            this.fld_dgcMEEmrDocuments.Name = "fld_dgcMEEmrDocuments";
            this.fld_dgcMEEmrDocuments.PrintReport = false;
            this.fld_dgcMEEmrDocuments.Screen = null;
            this.fld_dgcMEEmrDocuments.Size = new System.Drawing.Size(820, 425);
            this.fld_dgcMEEmrDocuments.TabIndex = 1000000036;
            this.fld_dgcMEEmrDocuments.Tag = "DC";
            this.fld_dgcMEEmrDocuments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvMEEmrDocuments});
            // 
            // fld_dgvMEEmrDocuments
            // 
            this.fld_dgvMEEmrDocuments.GridControl = this.fld_dgcMEEmrDocuments;
            this.fld_dgvMEEmrDocuments.Name = "fld_dgvMEEmrDocuments";
            this.fld_dgvMEEmrDocuments.PaintStyleName = "Office2003";
            // 
            // fld_lblLabel9
            // 
            this.fld_lblLabel9.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel9.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel9.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel9.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel9.BOSComment = "";
            this.fld_lblLabel9.BOSDataMember = "";
            this.fld_lblLabel9.BOSDataSource = "";
            this.fld_lblLabel9.BOSDescription = null;
            this.fld_lblLabel9.BOSError = null;
            this.fld_lblLabel9.BOSFieldGroup = "";
            this.fld_lblLabel9.BOSFieldRelation = "";
            this.fld_lblLabel9.BOSPrivilege = "";
            this.fld_lblLabel9.BOSPropertyName = "";
            this.fld_lblLabel9.Location = new System.Drawing.Point(9, 43);
            this.fld_lblLabel9.Name = "fld_lblLabel9";
            this.fld_lblLabel9.Screen = null;
            this.fld_lblLabel9.Size = new System.Drawing.Size(20, 13);
            this.fld_lblLabel9.TabIndex = 1000000035;
            this.fld_lblLabel9.Tag = "";
            this.fld_lblLabel9.Text = "Mẫu";
            // 
            // fld_dteSearchToMEEmrDocumentCreatedDate
            // 
            this.fld_dteSearchToMEEmrDocumentCreatedDate.BOSComment = "";
            this.fld_dteSearchToMEEmrDocumentCreatedDate.BOSDataMember = "MEEmrDocumentCreatedDateTo";
            this.fld_dteSearchToMEEmrDocumentCreatedDate.BOSDataSource = "";
            this.fld_dteSearchToMEEmrDocumentCreatedDate.BOSDescription = null;
            this.fld_dteSearchToMEEmrDocumentCreatedDate.BOSError = null;
            this.fld_dteSearchToMEEmrDocumentCreatedDate.BOSFieldGroup = "";
            this.fld_dteSearchToMEEmrDocumentCreatedDate.BOSFieldRelation = "";
            this.fld_dteSearchToMEEmrDocumentCreatedDate.BOSPrivilege = "";
            this.fld_dteSearchToMEEmrDocumentCreatedDate.BOSPropertyName = "EditValue";
            this.fld_dteSearchToMEEmrDocumentCreatedDate.EditValue = null;
            this.fld_dteSearchToMEEmrDocumentCreatedDate.Location = new System.Drawing.Point(288, 12);
            this.fld_dteSearchToMEEmrDocumentCreatedDate.Name = "fld_dteSearchToMEEmrDocumentCreatedDate";
            this.fld_dteSearchToMEEmrDocumentCreatedDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteSearchToMEEmrDocumentCreatedDate.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteSearchToMEEmrDocumentCreatedDate.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteSearchToMEEmrDocumentCreatedDate.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteSearchToMEEmrDocumentCreatedDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteSearchToMEEmrDocumentCreatedDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteSearchToMEEmrDocumentCreatedDate.Screen = null;
            this.fld_dteSearchToMEEmrDocumentCreatedDate.Size = new System.Drawing.Size(178, 20);
            this.fld_dteSearchToMEEmrDocumentCreatedDate.TabIndex = 1000000030;
            this.fld_dteSearchToMEEmrDocumentCreatedDate.Tag = "SC";
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
            this.bosLabel2.Location = new System.Drawing.Point(7, 15);
            this.bosLabel2.Name = "bosLabel2";
            this.bosLabel2.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel2, true);
            this.bosLabel2.Size = new System.Drawing.Size(43, 13);
            this.bosLabel2.TabIndex = 1000000031;
            this.bosLabel2.Tag = "SI";
            this.bosLabel2.Text = "Thời gian";
            // 
            // fld_dteSearchFromMEEmrDocumentCreatedDate
            // 
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.BOSComment = "";
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.BOSDataMember = "MEEmrDocumentCreatedDateFrom";
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.BOSDataSource = "";
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.BOSDescription = null;
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.BOSError = null;
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.BOSFieldGroup = "";
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.BOSFieldRelation = "";
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.BOSPrivilege = "";
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.BOSPropertyName = "EditValue";
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.EditValue = null;
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.Location = new System.Drawing.Point(79, 12);
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.Name = "fld_dteSearchFromMEEmrDocumentCreatedDate";
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.Screen = null;
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.Size = new System.Drawing.Size(193, 20);
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.TabIndex = 1000000028;
            this.fld_dteSearchFromMEEmrDocumentCreatedDate.Tag = "SC";
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
            this.bosLabel3.Location = new System.Drawing.Point(278, 15);
            this.bosLabel3.Name = "bosLabel3";
            this.bosLabel3.Screen = null;
            this.ScreenHelper.SetShowHelp(this.bosLabel3, true);
            this.bosLabel3.Size = new System.Drawing.Size(4, 13);
            this.bosLabel3.TabIndex = 1000000029;
            this.bosLabel3.Tag = "SI";
            this.bosLabel3.Text = "-";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DarkGray;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(190, 75);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(186, 13);
            this.labelControl1.TabIndex = 1000000026;
            this.labelControl1.Text = "Bấm làm mới để lấy danh sách mới nhất";
            // 
            // fld_btnRefreshDocument
            // 
            this.fld_btnRefreshDocument.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("fld_btnRefreshDocument.ImageOptions.Image")));
            this.fld_btnRefreshDocument.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.fld_btnRefreshDocument.Location = new System.Drawing.Point(77, 68);
            this.fld_btnRefreshDocument.Name = "fld_btnRefreshDocument";
            this.fld_btnRefreshDocument.Size = new System.Drawing.Size(104, 28);
            this.fld_btnRefreshDocument.TabIndex = 1000000025;
            this.fld_btnRefreshDocument.Text = "Làm mới";
            this.fld_btnRefreshDocument.Click += new System.EventHandler(this.fld_btnRefreshDocument_Click);
            // 
            // DMEMRDOCMAN02
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(826, 530);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DMEMRDOCMAN02";
            this.Text = "Danh sách tờ bệnh án";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEEmrDocumentStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_ccbeMETemplateID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchToMEEmrDocumentCreatedDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchToMEEmrDocumentCreatedDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchFromMEEmrDocumentCreatedDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteSearchFromMEEmrDocumentCreatedDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private IContainer components;
        private BOSPanel panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton fld_btnRefreshDocument;
        private BOSDateEdit fld_dteSearchToMEEmrDocumentCreatedDate;
        private BOSLabel bosLabel2;
        private BOSDateEdit fld_dteSearchFromMEEmrDocumentCreatedDate;
        private BOSLabel bosLabel3;
        private BOSLabel fld_lblLabel9;
        private MEEmrDocumentToolSelectionGridControl fld_dgcMEEmrDocuments;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvMEEmrDocuments;
        private MultiColCheckedComboBoxEdit fld_ccbeMETemplateID;
        private BOSLabel bosLabel4;
        private BOSLookupEdit fld_lkeMEEmrDocumentStatus;
    }
}
