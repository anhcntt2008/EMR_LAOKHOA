using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSERP.Modules.ME.METemplate;
using BOSComponent;

namespace BOSERP.Modules.METemplate.UI
{
    /// <summary>
    /// Summary description for DMMETE100
    /// </summary>
    partial class DMMETE100
    {
        private BOSComponent.BOSLabel fld_lblMETemplateNo100;
        private BOSComponent.BOSLabel fld_lblMETemplateName100;
        private BOSComponent.BOSTextBox fld_txtMETemplateNo1;
        private BOSComponent.BOSTextBox fld_txtMETemplateName1;


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMMETE100));
            this.fld_lblMETemplateNo100 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblMETemplateName100 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtMETemplateNo1 = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtMETemplateName1 = new BOSComponent.BOSTextBox(this.components);
            this.bosPanel1 = new BOSComponent.BOSPanel(this.components);
            this.chkMETemplateRemoveEmptyParagraph = new BOSComponent.BOSCheckEdit(this.components);
            this.chkHighlightEmrTag = new BOSComponent.BOSCheckEdit(this.components);
            this.chkMETemplateNightlyPdfExport = new BOSComponent.BOSCheckEdit(this.components);
            this.chkTemplateSignatureNotAlone = new BOSComponent.BOSCheckEdit(this.components);
            this.bosTextBox2 = new BOSComponent.BOSTextBox(this.components);
            this.bosLabel6 = new BOSComponent.BOSLabel(this.components);
            this.fld_lkeFK_METemplateID = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel5 = new BOSComponent.BOSLabel(this.components);
            this.fld_lkeFK_HREmployeeShareID = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel4 = new BOSComponent.BOSLabel(this.components);
            this.fld_lkeFK_HRDepartmentShareID = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel3 = new BOSComponent.BOSLabel(this.components);
            this.fld_lkeMETemplateShareMode = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel2 = new BOSComponent.BOSLabel(this.components);
            this.xtraTabControl1 = new BOSComponent.BOSTabControl(this.components);
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.bosPanel2 = new BOSComponent.BOSPanel(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.fld_dgcMEEmrActions = new BOSERP.Modules.METemplate.MEEmrStartupActionsGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_btnAddAction = new DevExpress.XtraEditors.SimpleButton();
            this.fld_dgcMEEmrTemplateActions = new BOSERP.Modules.METemplate.MEEmrTemplateActionsGridControl();
            this.fld_dgvGridControl = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_btnRemoveAction = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.fld_dgcMETemplateUserGroups = new BOSERP.Modules.METemplate.METemplateUserGroupsGridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.fld_dgcMETemplateParams = new BOSERP.Modules.METemplate.METemplateParamsGridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.bosLabel19 = new BOSComponent.BOSLabel(this.components);
            this.bosLabel18 = new BOSComponent.BOSLabel(this.components);
            this.clpMETemplateDgtSignatureTextColor = new BOSComponent.ClasColorPicker(this.components);
            this.bosLabel8 = new BOSComponent.BOSLabel(this.components);
            this.chkMETemplateDgtSignatureVisible = new BOSComponent.BOSCheckEdit(this.components);
            this.chkMETemplateDgtSignatureImage = new BOSComponent.BOSCheckEdit(this.components);
            this.txtMETemplateDgtSignatureReason = new BOSComponent.BOSTextBox(this.components);
            this.lblMETemplateDgtSignatureReason = new BOSComponent.BOSLabel(this.components);
            this.txtMETemplateDgtSignaturePage = new BOSComponent.BOSTextBox(this.components);
            this.lblMETemplateDgtSignaturePage = new BOSComponent.BOSLabel(this.components);
            this.lblMETemplateDgtSignatureFontSize = new BOSComponent.BOSTextBox(this.components);
            this.lblMETemplateDgtSignatureFontSize1 = new BOSComponent.BOSLabel(this.components);
            this.lblMETemplateDgtSignatureTextColor = new BOSComponent.BOSLabel(this.components);
            this.txtMETemplateDgtSignatureHeight = new BOSComponent.BOSTextBox(this.components);
            this.lblMETemplateDgtSignatureHeight = new BOSComponent.BOSLabel(this.components);
            this.txtMETemplateDgtSignatureWidth = new BOSComponent.BOSTextBox(this.components);
            this.lblMETemplateDgtSignatureWidth = new BOSComponent.BOSLabel(this.components);
            this.txtMETemplateDgtSignatureY = new BOSComponent.BOSTextBox(this.components);
            this.lblMETemplateDgtSignatureY = new BOSComponent.BOSLabel(this.components);
            this.txtMETemplateDgtSignatureX1 = new BOSComponent.BOSTextBox(this.components);
            this.lblMETemplateDgtSignatureX = new BOSComponent.BOSLabel(this.components);
            this.bosTextBox1 = new BOSComponent.BOSTextBox(this.components);
            this.bosLabel1 = new BOSComponent.BOSLabel(this.components);
            this.fld_lkeMETemplateType = new BOSComponent.BOSLookupEdit(this.components);
            this.bosLabel201 = new BOSComponent.BOSLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMETemplateNo1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMETemplateName1.Properties)).BeginInit();
            this.bosPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMETemplateRemoveEmptyParagraph.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHighlightEmrTag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMETemplateNightlyPdfExport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTemplateSignatureNotAlone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosTextBox2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_METemplateID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HREmployeeShareID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HRDepartmentShareID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMETemplateShareMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.bosPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrActions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrTemplateActions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvGridControl)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMETemplateUserGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMETemplateParams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.xtraTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clpMETemplateDgtSignatureTextColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMETemplateDgtSignatureVisible.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMETemplateDgtSignatureImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMETemplateDgtSignatureReason.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMETemplateDgtSignaturePage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMETemplateDgtSignatureFontSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMETemplateDgtSignatureHeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMETemplateDgtSignatureWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMETemplateDgtSignatureY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMETemplateDgtSignatureX1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosTextBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMETemplateType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_lblMETemplateNo100
            // 
            this.fld_lblMETemplateNo100.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblMETemplateNo100.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblMETemplateNo100.Appearance.Options.UseBackColor = true;
            this.fld_lblMETemplateNo100.Appearance.Options.UseForeColor = true;
            this.fld_lblMETemplateNo100.BOSComment = "";
            this.fld_lblMETemplateNo100.BOSDataMember = "";
            this.fld_lblMETemplateNo100.BOSDataSource = "";
            this.fld_lblMETemplateNo100.BOSDescription = null;
            this.fld_lblMETemplateNo100.BOSError = null;
            this.fld_lblMETemplateNo100.BOSFieldGroup = "";
            this.fld_lblMETemplateNo100.BOSFieldRelation = "";
            this.fld_lblMETemplateNo100.BOSPrivilege = "";
            this.fld_lblMETemplateNo100.BOSPropertyName = "";
            this.fld_lblMETemplateNo100.Location = new System.Drawing.Point(44, 14);
            this.fld_lblMETemplateNo100.Name = "fld_lblMETemplateNo100";
            this.fld_lblMETemplateNo100.Screen = null;
            this.fld_lblMETemplateNo100.Size = new System.Drawing.Size(79, 13);
            this.fld_lblMETemplateNo100.TabIndex = 4;
            this.fld_lblMETemplateNo100.Tag = "";
            this.fld_lblMETemplateNo100.Text = "Mã mẫu bệnh án";
            // 
            // fld_lblMETemplateName100
            // 
            this.fld_lblMETemplateName100.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblMETemplateName100.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblMETemplateName100.Appearance.Options.UseBackColor = true;
            this.fld_lblMETemplateName100.Appearance.Options.UseForeColor = true;
            this.fld_lblMETemplateName100.BOSComment = "";
            this.fld_lblMETemplateName100.BOSDataMember = "";
            this.fld_lblMETemplateName100.BOSDataSource = "";
            this.fld_lblMETemplateName100.BOSDescription = null;
            this.fld_lblMETemplateName100.BOSError = null;
            this.fld_lblMETemplateName100.BOSFieldGroup = "";
            this.fld_lblMETemplateName100.BOSFieldRelation = "";
            this.fld_lblMETemplateName100.BOSPrivilege = "";
            this.fld_lblMETemplateName100.BOSPropertyName = "";
            this.fld_lblMETemplateName100.Location = new System.Drawing.Point(44, 40);
            this.fld_lblMETemplateName100.Name = "fld_lblMETemplateName100";
            this.fld_lblMETemplateName100.Screen = null;
            this.fld_lblMETemplateName100.Size = new System.Drawing.Size(83, 13);
            this.fld_lblMETemplateName100.TabIndex = 6;
            this.fld_lblMETemplateName100.Tag = "";
            this.fld_lblMETemplateName100.Text = "Tên mẫu bệnh án";
            // 
            // fld_txtMETemplateNo1
            // 
            this.fld_txtMETemplateNo1.BOSComment = "";
            this.fld_txtMETemplateNo1.BOSDataMember = "METemplateNo";
            this.fld_txtMETemplateNo1.BOSDataSource = "METemplates";
            this.fld_txtMETemplateNo1.BOSDescription = null;
            this.fld_txtMETemplateNo1.BOSError = null;
            this.fld_txtMETemplateNo1.BOSFieldGroup = "";
            this.fld_txtMETemplateNo1.BOSFieldRelation = "";
            this.fld_txtMETemplateNo1.BOSPrivilege = "";
            this.fld_txtMETemplateNo1.BOSPropertyName = "Text";
            this.fld_txtMETemplateNo1.EditValue = "";
            this.fld_txtMETemplateNo1.Location = new System.Drawing.Point(141, 11);
            this.fld_txtMETemplateNo1.Name = "fld_txtMETemplateNo1";
            this.fld_txtMETemplateNo1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMETemplateNo1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMETemplateNo1.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMETemplateNo1.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMETemplateNo1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMETemplateNo1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMETemplateNo1.Screen = null;
            this.fld_txtMETemplateNo1.Size = new System.Drawing.Size(343, 20);
            this.fld_txtMETemplateNo1.TabIndex = 0;
            this.fld_txtMETemplateNo1.Tag = "DC";
            // 
            // fld_txtMETemplateName1
            // 
            this.fld_txtMETemplateName1.BOSComment = "";
            this.fld_txtMETemplateName1.BOSDataMember = "METemplateName";
            this.fld_txtMETemplateName1.BOSDataSource = "METemplates";
            this.fld_txtMETemplateName1.BOSDescription = null;
            this.fld_txtMETemplateName1.BOSError = null;
            this.fld_txtMETemplateName1.BOSFieldGroup = "";
            this.fld_txtMETemplateName1.BOSFieldRelation = "";
            this.fld_txtMETemplateName1.BOSPrivilege = "";
            this.fld_txtMETemplateName1.BOSPropertyName = "Text";
            this.fld_txtMETemplateName1.EditValue = "";
            this.fld_txtMETemplateName1.Location = new System.Drawing.Point(141, 36);
            this.fld_txtMETemplateName1.Name = "fld_txtMETemplateName1";
            this.fld_txtMETemplateName1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMETemplateName1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMETemplateName1.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMETemplateName1.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMETemplateName1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMETemplateName1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMETemplateName1.Screen = null;
            this.fld_txtMETemplateName1.Size = new System.Drawing.Size(343, 20);
            this.fld_txtMETemplateName1.TabIndex = 2;
            this.fld_txtMETemplateName1.Tag = "DC";
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
            this.bosPanel1.Controls.Add(this.chkMETemplateRemoveEmptyParagraph);
            this.bosPanel1.Controls.Add(this.chkHighlightEmrTag);
            this.bosPanel1.Controls.Add(this.chkMETemplateNightlyPdfExport);
            this.bosPanel1.Controls.Add(this.chkTemplateSignatureNotAlone);
            this.bosPanel1.Controls.Add(this.bosTextBox2);
            this.bosPanel1.Controls.Add(this.bosLabel6);
            this.bosPanel1.Controls.Add(this.fld_lkeFK_METemplateID);
            this.bosPanel1.Controls.Add(this.bosLabel5);
            this.bosPanel1.Controls.Add(this.fld_lkeFK_HREmployeeShareID);
            this.bosPanel1.Controls.Add(this.bosLabel4);
            this.bosPanel1.Controls.Add(this.fld_lkeFK_HRDepartmentShareID);
            this.bosPanel1.Controls.Add(this.bosLabel3);
            this.bosPanel1.Controls.Add(this.fld_lkeMETemplateShareMode);
            this.bosPanel1.Controls.Add(this.bosLabel2);
            this.bosPanel1.Controls.Add(this.xtraTabControl1);
            this.bosPanel1.Controls.Add(this.bosTextBox1);
            this.bosPanel1.Controls.Add(this.bosLabel1);
            this.bosPanel1.Controls.Add(this.fld_lkeMETemplateType);
            this.bosPanel1.Controls.Add(this.bosLabel201);
            this.bosPanel1.Controls.Add(this.fld_lblMETemplateNo100);
            this.bosPanel1.Controls.Add(this.fld_txtMETemplateName1);
            this.bosPanel1.Controls.Add(this.fld_txtMETemplateNo1);
            this.bosPanel1.Controls.Add(this.fld_lblMETemplateName100);
            this.bosPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bosPanel1.Location = new System.Drawing.Point(0, 0);
            this.bosPanel1.Name = "bosPanel1";
            this.bosPanel1.Screen = null;
            this.bosPanel1.Size = new System.Drawing.Size(905, 490);
            this.bosPanel1.TabIndex = 9;
            // 
            // chkMETemplateRemoveEmptyParagraph
            // 
            this.chkMETemplateRemoveEmptyParagraph.BOSComment = null;
            this.chkMETemplateRemoveEmptyParagraph.BOSDataMember = "METemplateRemoveEmptyParagraph";
            this.chkMETemplateRemoveEmptyParagraph.BOSDataSource = "METemplates";
            this.chkMETemplateRemoveEmptyParagraph.BOSDescription = null;
            this.chkMETemplateRemoveEmptyParagraph.BOSError = null;
            this.chkMETemplateRemoveEmptyParagraph.BOSFieldGroup = null;
            this.chkMETemplateRemoveEmptyParagraph.BOSFieldRelation = null;
            this.chkMETemplateRemoveEmptyParagraph.BOSPrivilege = null;
            this.chkMETemplateRemoveEmptyParagraph.BOSPropertyName = "Checked";
            this.chkMETemplateRemoveEmptyParagraph.Location = new System.Drawing.Point(330, 138);
            this.chkMETemplateRemoveEmptyParagraph.MenuManager = this.screenToolbar;
            this.chkMETemplateRemoveEmptyParagraph.Name = "chkMETemplateRemoveEmptyParagraph";
            this.chkMETemplateRemoveEmptyParagraph.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkMETemplateRemoveEmptyParagraph.Properties.Appearance.Options.UseBackColor = true;
            this.chkMETemplateRemoveEmptyParagraph.Properties.Caption = "Xóa dòng trống khi in (do thẻ chức năng)";
            this.chkMETemplateRemoveEmptyParagraph.Screen = null;
            this.chkMETemplateRemoveEmptyParagraph.Size = new System.Drawing.Size(265, 19);
            this.chkMETemplateRemoveEmptyParagraph.TabIndex = 123;
            this.chkMETemplateRemoveEmptyParagraph.Tag = "DC";
            // 
            // chkHighlightEmrTag
            // 
            this.chkHighlightEmrTag.BOSComment = null;
            this.chkHighlightEmrTag.BOSDataMember = "METemplateHighlightDataTag";
            this.chkHighlightEmrTag.BOSDataSource = "METemplates";
            this.chkHighlightEmrTag.BOSDescription = null;
            this.chkHighlightEmrTag.BOSError = null;
            this.chkHighlightEmrTag.BOSFieldGroup = null;
            this.chkHighlightEmrTag.BOSFieldRelation = null;
            this.chkHighlightEmrTag.BOSPrivilege = null;
            this.chkHighlightEmrTag.BOSPropertyName = "Checked";
            this.chkHighlightEmrTag.Location = new System.Drawing.Point(330, 111);
            this.chkHighlightEmrTag.MenuManager = this.screenToolbar;
            this.chkHighlightEmrTag.Name = "chkHighlightEmrTag";
            this.chkHighlightEmrTag.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkHighlightEmrTag.Properties.Appearance.Options.UseBackColor = true;
            this.chkHighlightEmrTag.Properties.Caption = "Tô màu thẻ dữ liệu";
            this.chkHighlightEmrTag.Screen = null;
            this.chkHighlightEmrTag.Size = new System.Drawing.Size(154, 19);
            this.chkHighlightEmrTag.TabIndex = 122;
            this.chkHighlightEmrTag.Tag = "DC";
            // 
            // chkMETemplateNightlyPdfExport
            // 
            this.chkMETemplateNightlyPdfExport.BOSComment = null;
            this.chkMETemplateNightlyPdfExport.BOSDataMember = "METemplateNightlyPdfExport";
            this.chkMETemplateNightlyPdfExport.BOSDataSource = "METemplates";
            this.chkMETemplateNightlyPdfExport.BOSDescription = null;
            this.chkMETemplateNightlyPdfExport.BOSError = null;
            this.chkMETemplateNightlyPdfExport.BOSFieldGroup = null;
            this.chkMETemplateNightlyPdfExport.BOSFieldRelation = null;
            this.chkMETemplateNightlyPdfExport.BOSPrivilege = null;
            this.chkMETemplateNightlyPdfExport.BOSPropertyName = "Checked";
            this.chkMETemplateNightlyPdfExport.Location = new System.Drawing.Point(140, 136);
            this.chkMETemplateNightlyPdfExport.MenuManager = this.screenToolbar;
            this.chkMETemplateNightlyPdfExport.Name = "chkMETemplateNightlyPdfExport";
            this.chkMETemplateNightlyPdfExport.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkMETemplateNightlyPdfExport.Properties.Appearance.Options.UseBackColor = true;
            this.chkMETemplateNightlyPdfExport.Properties.Caption = "Tự động kết xuất PDF hằng ngày";
            this.chkMETemplateNightlyPdfExport.Screen = null;
            this.chkMETemplateNightlyPdfExport.Size = new System.Drawing.Size(265, 19);
            this.chkMETemplateNightlyPdfExport.TabIndex = 122;
            this.chkMETemplateNightlyPdfExport.Tag = "DC";
            // 
            // chkTemplateSignatureNotAlone
            // 
            this.chkTemplateSignatureNotAlone.BOSComment = null;
            this.chkTemplateSignatureNotAlone.BOSDataMember = "METemplateSignatureNotAlone";
            this.chkTemplateSignatureNotAlone.BOSDataSource = "METemplates";
            this.chkTemplateSignatureNotAlone.BOSDescription = null;
            this.chkTemplateSignatureNotAlone.BOSError = null;
            this.chkTemplateSignatureNotAlone.BOSFieldGroup = null;
            this.chkTemplateSignatureNotAlone.BOSFieldRelation = null;
            this.chkTemplateSignatureNotAlone.BOSPrivilege = null;
            this.chkTemplateSignatureNotAlone.BOSPropertyName = "Checked";
            this.chkTemplateSignatureNotAlone.Location = new System.Drawing.Point(140, 111);
            this.chkTemplateSignatureNotAlone.MenuManager = this.screenToolbar;
            this.chkTemplateSignatureNotAlone.Name = "chkTemplateSignatureNotAlone";
            this.chkTemplateSignatureNotAlone.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkTemplateSignatureNotAlone.Properties.Appearance.Options.UseBackColor = true;
            this.chkTemplateSignatureNotAlone.Properties.Caption = "Giữ nội dung và chữ ký gần nhau";
            this.chkTemplateSignatureNotAlone.Screen = null;
            this.chkTemplateSignatureNotAlone.Size = new System.Drawing.Size(265, 19);
            this.chkTemplateSignatureNotAlone.TabIndex = 121;
            this.chkTemplateSignatureNotAlone.Tag = "DC";
            // 
            // bosTextBox2
            // 
            this.bosTextBox2.BOSComment = "";
            this.bosTextBox2.BOSDataMember = "METemplateMaximumPage";
            this.bosTextBox2.BOSDataSource = "METemplates";
            this.bosTextBox2.BOSDescription = null;
            this.bosTextBox2.BOSError = null;
            this.bosTextBox2.BOSFieldGroup = "";
            this.bosTextBox2.BOSFieldRelation = "";
            this.bosTextBox2.BOSPrivilege = "";
            this.bosTextBox2.BOSPropertyName = "Text";
            this.bosTextBox2.EditValue = "";
            this.bosTextBox2.Location = new System.Drawing.Point(640, 116);
            this.bosTextBox2.Name = "bosTextBox2";
            this.bosTextBox2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosTextBox2.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosTextBox2.Properties.Appearance.Options.UseBackColor = true;
            this.bosTextBox2.Properties.Appearance.Options.UseForeColor = true;
            this.bosTextBox2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.bosTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bosTextBox2.Screen = null;
            this.bosTextBox2.Size = new System.Drawing.Size(243, 20);
            this.bosTextBox2.TabIndex = 86;
            this.bosTextBox2.Tag = "DC";
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
            this.bosLabel6.Location = new System.Drawing.Point(517, 119);
            this.bosLabel6.Name = "bosLabel6";
            this.bosLabel6.Screen = null;
            this.bosLabel6.Size = new System.Drawing.Size(71, 13);
            this.bosLabel6.TabIndex = 87;
            this.bosLabel6.Tag = "";
            this.bosLabel6.Text = "Số trang tối đa";
            // 
            // fld_lkeFK_METemplateID
            // 
            this.fld_lkeFK_METemplateID.BOSAllowAddNew = false;
            this.fld_lkeFK_METemplateID.BOSAllowDummy = true;
            this.fld_lkeFK_METemplateID.BOSComment = "";
            this.fld_lkeFK_METemplateID.BOSDataMember = "FK_METemplateID";
            this.fld_lkeFK_METemplateID.BOSDataSource = "METemplates";
            this.fld_lkeFK_METemplateID.BOSDescription = null;
            this.fld_lkeFK_METemplateID.BOSDummyText = null;
            this.fld_lkeFK_METemplateID.BOSError = null;
            this.fld_lkeFK_METemplateID.BOSFieldGroup = "";
            this.fld_lkeFK_METemplateID.BOSFieldParent = "";
            this.fld_lkeFK_METemplateID.BOSFieldRelation = "";
            this.fld_lkeFK_METemplateID.BOSPrivilege = "";
            this.fld_lkeFK_METemplateID.BOSPropertyName = "EditValue";
            this.fld_lkeFK_METemplateID.BOSSelectType = "";
            this.fld_lkeFK_METemplateID.BOSSelectTypeValue = "";
            this.fld_lkeFK_METemplateID.CurrentDisplayText = null;
            this.fld_lkeFK_METemplateID.Location = new System.Drawing.Point(640, 90);
            this.fld_lkeFK_METemplateID.Name = "fld_lkeFK_METemplateID";
            this.fld_lkeFK_METemplateID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeFK_METemplateID.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeFK_METemplateID.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeFK_METemplateID.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeFK_METemplateID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_METemplateID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("METemplateNo", "Mã mẫu bệnh án", 20, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("METemplateName", "Tên mẫu bệnh án")});
            this.fld_lkeFK_METemplateID.Properties.DisplayMember = "METemplateName";
            this.fld_lkeFK_METemplateID.Properties.NullText = "";
            this.fld_lkeFK_METemplateID.Properties.PopupWidth = 40;
            this.fld_lkeFK_METemplateID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeFK_METemplateID.Properties.ValueMember = "METemplateID";
            this.fld_lkeFK_METemplateID.Screen = null;
            this.fld_lkeFK_METemplateID.Size = new System.Drawing.Size(243, 20);
            this.fld_lkeFK_METemplateID.TabIndex = 85;
            this.fld_lkeFK_METemplateID.Tag = "DC";
            // 
            // bosLabel5
            // 
            this.bosLabel5.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
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
            this.bosLabel5.Location = new System.Drawing.Point(517, 93);
            this.bosLabel5.Name = "bosLabel5";
            this.bosLabel5.Screen = null;
            this.bosLabel5.Size = new System.Drawing.Size(82, 13);
            this.bosLabel5.TabIndex = 84;
            this.bosLabel5.Tag = "";
            this.bosLabel5.Text = "Mẫu bệnh án cha";
            // 
            // fld_lkeFK_HREmployeeShareID
            // 
            this.fld_lkeFK_HREmployeeShareID.BOSAllowAddNew = false;
            this.fld_lkeFK_HREmployeeShareID.BOSAllowDummy = true;
            this.fld_lkeFK_HREmployeeShareID.BOSComment = "";
            this.fld_lkeFK_HREmployeeShareID.BOSDataMember = "FK_HREmployeeShareID";
            this.fld_lkeFK_HREmployeeShareID.BOSDataSource = "METemplates";
            this.fld_lkeFK_HREmployeeShareID.BOSDescription = null;
            this.fld_lkeFK_HREmployeeShareID.BOSDummyText = null;
            this.fld_lkeFK_HREmployeeShareID.BOSError = null;
            this.fld_lkeFK_HREmployeeShareID.BOSFieldGroup = "";
            this.fld_lkeFK_HREmployeeShareID.BOSFieldParent = "";
            this.fld_lkeFK_HREmployeeShareID.BOSFieldRelation = "";
            this.fld_lkeFK_HREmployeeShareID.BOSPrivilege = "";
            this.fld_lkeFK_HREmployeeShareID.BOSPropertyName = "EditValue";
            this.fld_lkeFK_HREmployeeShareID.BOSSelectType = "";
            this.fld_lkeFK_HREmployeeShareID.BOSSelectTypeValue = "";
            this.fld_lkeFK_HREmployeeShareID.CurrentDisplayText = null;
            this.fld_lkeFK_HREmployeeShareID.Enabled = false;
            this.fld_lkeFK_HREmployeeShareID.Location = new System.Drawing.Point(640, 39);
            this.fld_lkeFK_HREmployeeShareID.Name = "fld_lkeFK_HREmployeeShareID";
            this.fld_lkeFK_HREmployeeShareID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeFK_HREmployeeShareID.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeFK_HREmployeeShareID.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeFK_HREmployeeShareID.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeFK_HREmployeeShareID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_HREmployeeShareID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HREmployeeNo", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HREmployeeName", "Tên")});
            this.fld_lkeFK_HREmployeeShareID.Properties.DisplayMember = "HREmployeeName";
            this.fld_lkeFK_HREmployeeShareID.Properties.NullText = "";
            this.fld_lkeFK_HREmployeeShareID.Properties.PopupWidth = 40;
            this.fld_lkeFK_HREmployeeShareID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeFK_HREmployeeShareID.Properties.ValueMember = "HREmployeeID";
            this.fld_lkeFK_HREmployeeShareID.Screen = null;
            this.fld_lkeFK_HREmployeeShareID.Size = new System.Drawing.Size(243, 20);
            this.fld_lkeFK_HREmployeeShareID.TabIndex = 83;
            this.fld_lkeFK_HREmployeeShareID.Tag = "DC";
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
            this.bosLabel4.Location = new System.Drawing.Point(517, 42);
            this.bosLabel4.Name = "bosLabel4";
            this.bosLabel4.Screen = null;
            this.bosLabel4.Size = new System.Drawing.Size(102, 13);
            this.bosLabel4.TabIndex = 82;
            this.bosLabel4.Tag = "";
            this.bosLabel4.Text = "Trực thuộc nhân viên";
            // 
            // fld_lkeFK_HRDepartmentShareID
            // 
            this.fld_lkeFK_HRDepartmentShareID.BOSAllowAddNew = false;
            this.fld_lkeFK_HRDepartmentShareID.BOSAllowDummy = true;
            this.fld_lkeFK_HRDepartmentShareID.BOSComment = "";
            this.fld_lkeFK_HRDepartmentShareID.BOSDataMember = "FK_HRDepartmentShareID";
            this.fld_lkeFK_HRDepartmentShareID.BOSDataSource = "METemplates";
            this.fld_lkeFK_HRDepartmentShareID.BOSDescription = null;
            this.fld_lkeFK_HRDepartmentShareID.BOSDummyText = null;
            this.fld_lkeFK_HRDepartmentShareID.BOSError = null;
            this.fld_lkeFK_HRDepartmentShareID.BOSFieldGroup = "";
            this.fld_lkeFK_HRDepartmentShareID.BOSFieldParent = "";
            this.fld_lkeFK_HRDepartmentShareID.BOSFieldRelation = "";
            this.fld_lkeFK_HRDepartmentShareID.BOSPrivilege = "";
            this.fld_lkeFK_HRDepartmentShareID.BOSPropertyName = "EditValue";
            this.fld_lkeFK_HRDepartmentShareID.BOSSelectType = "";
            this.fld_lkeFK_HRDepartmentShareID.BOSSelectTypeValue = "";
            this.fld_lkeFK_HRDepartmentShareID.CurrentDisplayText = null;
            this.fld_lkeFK_HRDepartmentShareID.Enabled = false;
            this.fld_lkeFK_HRDepartmentShareID.Location = new System.Drawing.Point(640, 64);
            this.fld_lkeFK_HRDepartmentShareID.Name = "fld_lkeFK_HRDepartmentShareID";
            this.fld_lkeFK_HRDepartmentShareID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeFK_HRDepartmentShareID.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeFK_HRDepartmentShareID.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeFK_HRDepartmentShareID.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeFK_HRDepartmentShareID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_HRDepartmentShareID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRDepartmentNo", "Mã khoa", 20, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HRDepartmentName", "Tên khoa")});
            this.fld_lkeFK_HRDepartmentShareID.Properties.DisplayMember = "HRDepartmentName";
            this.fld_lkeFK_HRDepartmentShareID.Properties.NullText = "";
            this.fld_lkeFK_HRDepartmentShareID.Properties.PopupWidth = 40;
            this.fld_lkeFK_HRDepartmentShareID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeFK_HRDepartmentShareID.Properties.ValueMember = "HRDepartmentID";
            this.fld_lkeFK_HRDepartmentShareID.Screen = null;
            this.fld_lkeFK_HRDepartmentShareID.Size = new System.Drawing.Size(243, 20);
            this.fld_lkeFK_HRDepartmentShareID.TabIndex = 81;
            this.fld_lkeFK_HRDepartmentShareID.Tag = "DC";
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
            this.bosLabel3.Location = new System.Drawing.Point(517, 67);
            this.bosLabel3.Name = "bosLabel3";
            this.bosLabel3.Screen = null;
            this.bosLabel3.Size = new System.Drawing.Size(78, 13);
            this.bosLabel3.TabIndex = 80;
            this.bosLabel3.Tag = "";
            this.bosLabel3.Text = "Trực thuộc khoa";
            // 
            // fld_lkeMETemplateShareMode
            // 
            this.fld_lkeMETemplateShareMode.BOSAllowAddNew = false;
            this.fld_lkeMETemplateShareMode.BOSAllowDummy = false;
            this.fld_lkeMETemplateShareMode.BOSComment = null;
            this.fld_lkeMETemplateShareMode.BOSDataMember = "METemplateShareMode";
            this.fld_lkeMETemplateShareMode.BOSDataSource = "METemplates";
            this.fld_lkeMETemplateShareMode.BOSDescription = null;
            this.fld_lkeMETemplateShareMode.BOSDummyText = null;
            this.fld_lkeMETemplateShareMode.BOSError = null;
            this.fld_lkeMETemplateShareMode.BOSFieldGroup = null;
            this.fld_lkeMETemplateShareMode.BOSFieldParent = null;
            this.fld_lkeMETemplateShareMode.BOSFieldRelation = null;
            this.fld_lkeMETemplateShareMode.BOSPrivilege = null;
            this.fld_lkeMETemplateShareMode.BOSPropertyName = "EditValue";
            this.fld_lkeMETemplateShareMode.BOSSelectType = null;
            this.fld_lkeMETemplateShareMode.BOSSelectTypeValue = null;
            this.fld_lkeMETemplateShareMode.CurrentDisplayText = null;
            this.fld_lkeMETemplateShareMode.Location = new System.Drawing.Point(640, 11);
            this.fld_lkeMETemplateShareMode.MenuManager = this.screenToolbar;
            this.fld_lkeMETemplateShareMode.Name = "fld_lkeMETemplateShareMode";
            this.fld_lkeMETemplateShareMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeMETemplateShareMode.Properties.NullText = "";
            this.fld_lkeMETemplateShareMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeMETemplateShareMode.Screen = null;
            this.fld_lkeMETemplateShareMode.Size = new System.Drawing.Size(243, 20);
            this.fld_lkeMETemplateShareMode.TabIndex = 78;
            this.fld_lkeMETemplateShareMode.Tag = "DC";
            this.fld_lkeMETemplateShareMode.EditValueChanged += new System.EventHandler(this.fld_lkeMETemplateShareMode_EditValueChanged);
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
            this.bosLabel2.Location = new System.Drawing.Point(517, 14);
            this.bosLabel2.Name = "bosLabel2";
            this.bosLabel2.Screen = null;
            this.bosLabel2.Size = new System.Drawing.Size(57, 13);
            this.bosLabel2.TabIndex = 79;
            this.bosLabel2.Tag = "";
            this.bosLabel2.Text = "Phân quyền";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.BOSComment = null;
            this.xtraTabControl1.BOSDataMember = null;
            this.xtraTabControl1.BOSDataSource = null;
            this.xtraTabControl1.BOSDescription = null;
            this.xtraTabControl1.BOSError = null;
            this.xtraTabControl1.BOSFieldGroup = null;
            this.xtraTabControl1.BOSFieldRelation = null;
            this.xtraTabControl1.BOSPrivilege = null;
            this.xtraTabControl1.BOSPropertyName = null;
            this.xtraTabControl1.Location = new System.Drawing.Point(3, 161);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.Screen = null;
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(899, 329);
            this.xtraTabControl1.TabIndex = 77;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.xtraTabPage4});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.bosPanel2);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(893, 301);
            this.xtraTabPage1.Text = "Chức năng tự động chạy";
            // 
            // bosPanel2
            // 
            this.bosPanel2.BOSComment = null;
            this.bosPanel2.BOSDataMember = null;
            this.bosPanel2.BOSDataSource = null;
            this.bosPanel2.BOSDescription = null;
            this.bosPanel2.BOSError = null;
            this.bosPanel2.BOSFieldGroup = null;
            this.bosPanel2.BOSFieldRelation = null;
            this.bosPanel2.BOSPrivilege = null;
            this.bosPanel2.BOSPropertyName = null;
            this.bosPanel2.Controls.Add(this.splitContainerControl1);
            this.bosPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bosPanel2.Location = new System.Drawing.Point(0, 0);
            this.bosPanel2.Name = "bosPanel2";
            this.bosPanel2.Screen = null;
            this.bosPanel2.Size = new System.Drawing.Size(893, 301);
            this.bosPanel2.TabIndex = 74;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.fld_dgcMEEmrActions);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.fld_btnAddAction);
            this.splitContainerControl1.Panel2.Controls.Add(this.fld_dgcMEEmrTemplateActions);
            this.splitContainerControl1.Panel2.Controls.Add(this.fld_btnRemoveAction);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(893, 301);
            this.splitContainerControl1.SplitterPosition = 365;
            this.splitContainerControl1.TabIndex = 75;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // fld_dgcMEEmrActions
            // 
            this.fld_dgcMEEmrActions.AllowDrop = true;
            this.fld_dgcMEEmrActions.BOSComment = "";
            this.fld_dgcMEEmrActions.BOSDataMember = "";
            this.fld_dgcMEEmrActions.BOSDataSource = "MEEmrActions";
            this.fld_dgcMEEmrActions.BOSDescription = null;
            this.fld_dgcMEEmrActions.BOSError = null;
            this.fld_dgcMEEmrActions.BOSFieldGroup = "";
            this.fld_dgcMEEmrActions.BOSFieldRelation = "";
            this.fld_dgcMEEmrActions.BOSGridType = null;
            this.fld_dgcMEEmrActions.BOSPrivilege = "";
            this.fld_dgcMEEmrActions.BOSPropertyName = "";
            this.fld_dgcMEEmrActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_dgcMEEmrActions.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMEEmrActions.Location = new System.Drawing.Point(0, 0);
            this.fld_dgcMEEmrActions.MainView = this.gridView1;
            this.fld_dgcMEEmrActions.Name = "fld_dgcMEEmrActions";
            this.fld_dgcMEEmrActions.PrintReport = false;
            this.fld_dgcMEEmrActions.Screen = null;
            this.fld_dgcMEEmrActions.Size = new System.Drawing.Size(365, 301);
            this.fld_dgcMEEmrActions.TabIndex = 72;
            this.fld_dgcMEEmrActions.Tag = "DC";
            this.fld_dgcMEEmrActions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcMEEmrActions;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.PaintStyleName = "Office2003";
            // 
            // fld_btnAddAction
            // 
            this.fld_btnAddAction.Location = new System.Drawing.Point(1, 178);
            this.fld_btnAddAction.Name = "fld_btnAddAction";
            this.fld_btnAddAction.Size = new System.Drawing.Size(45, 23);
            this.fld_btnAddAction.TabIndex = 73;
            this.fld_btnAddAction.Text = ">>";
            this.fld_btnAddAction.Click += new System.EventHandler(this.fld_btnAddAction_Click);
            // 
            // fld_dgcMEEmrTemplateActions
            // 
            this.fld_dgcMEEmrTemplateActions.AllowDrop = true;
            this.fld_dgcMEEmrTemplateActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcMEEmrTemplateActions.BOSComment = "";
            this.fld_dgcMEEmrTemplateActions.BOSDataMember = "";
            this.fld_dgcMEEmrTemplateActions.BOSDataSource = "MEEmrTemplateActions";
            this.fld_dgcMEEmrTemplateActions.BOSDescription = null;
            this.fld_dgcMEEmrTemplateActions.BOSError = null;
            this.fld_dgcMEEmrTemplateActions.BOSFieldGroup = "";
            this.fld_dgcMEEmrTemplateActions.BOSFieldRelation = "";
            this.fld_dgcMEEmrTemplateActions.BOSGridType = null;
            this.fld_dgcMEEmrTemplateActions.BOSPrivilege = "";
            this.fld_dgcMEEmrTemplateActions.BOSPropertyName = "";
            this.fld_dgcMEEmrTemplateActions.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMEEmrTemplateActions.Location = new System.Drawing.Point(52, 0);
            this.fld_dgcMEEmrTemplateActions.MainView = this.fld_dgvGridControl;
            this.fld_dgcMEEmrTemplateActions.Name = "fld_dgcMEEmrTemplateActions";
            this.fld_dgcMEEmrTemplateActions.PrintReport = false;
            this.fld_dgcMEEmrTemplateActions.Screen = null;
            this.fld_dgcMEEmrTemplateActions.Size = new System.Drawing.Size(471, 303);
            this.fld_dgcMEEmrTemplateActions.TabIndex = 71;
            this.fld_dgcMEEmrTemplateActions.Tag = "DC";
            this.fld_dgcMEEmrTemplateActions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvGridControl});
            // 
            // fld_dgvGridControl
            // 
            this.fld_dgvGridControl.GridControl = this.fld_dgcMEEmrTemplateActions;
            this.fld_dgvGridControl.Name = "fld_dgvGridControl";
            this.fld_dgvGridControl.PaintStyleName = "Office2003";
            // 
            // fld_btnRemoveAction
            // 
            this.fld_btnRemoveAction.Location = new System.Drawing.Point(1, 207);
            this.fld_btnRemoveAction.Name = "fld_btnRemoveAction";
            this.fld_btnRemoveAction.Size = new System.Drawing.Size(45, 23);
            this.fld_btnRemoveAction.TabIndex = 74;
            this.fld_btnRemoveAction.Text = "<<";
            this.fld_btnRemoveAction.Click += new System.EventHandler(this.fld_btnRemoveAction_Click);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.fld_dgcMETemplateUserGroups);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(893, 301);
            this.xtraTabPage2.Text = "Người dùng";
            // 
            // fld_dgcMETemplateUserGroups
            // 
            this.fld_dgcMETemplateUserGroups.AllowDrop = true;
            this.fld_dgcMETemplateUserGroups.BOSComment = "";
            this.fld_dgcMETemplateUserGroups.BOSDataMember = "";
            this.fld_dgcMETemplateUserGroups.BOSDataSource = "METemplateUserGroups";
            this.fld_dgcMETemplateUserGroups.BOSDescription = null;
            this.fld_dgcMETemplateUserGroups.BOSError = null;
            this.fld_dgcMETemplateUserGroups.BOSFieldGroup = "";
            this.fld_dgcMETemplateUserGroups.BOSFieldRelation = "";
            this.fld_dgcMETemplateUserGroups.BOSGridType = null;
            this.fld_dgcMETemplateUserGroups.BOSPrivilege = "";
            this.fld_dgcMETemplateUserGroups.BOSPropertyName = "";
            this.fld_dgcMETemplateUserGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_dgcMETemplateUserGroups.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMETemplateUserGroups.Location = new System.Drawing.Point(0, 0);
            this.fld_dgcMETemplateUserGroups.MainView = this.gridView2;
            this.fld_dgcMETemplateUserGroups.Name = "fld_dgcMETemplateUserGroups";
            this.fld_dgcMETemplateUserGroups.PrintReport = false;
            this.fld_dgcMETemplateUserGroups.Screen = null;
            this.fld_dgcMETemplateUserGroups.Size = new System.Drawing.Size(893, 301);
            this.fld_dgcMETemplateUserGroups.TabIndex = 72;
            this.fld_dgcMETemplateUserGroups.Tag = "DC";
            this.fld_dgcMETemplateUserGroups.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.fld_dgcMETemplateUserGroups;
            this.gridView2.Name = "gridView2";
            this.gridView2.PaintStyleName = "Office2003";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.fld_dgcMETemplateParams);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(893, 301);
            this.xtraTabPage3.Text = "Thẻ dữ liệu";
            // 
            // fld_dgcMETemplateParams
            // 
            this.fld_dgcMETemplateParams.AllowDrop = true;
            this.fld_dgcMETemplateParams.BOSComment = "";
            this.fld_dgcMETemplateParams.BOSDataMember = "";
            this.fld_dgcMETemplateParams.BOSDataSource = "METemplateParams";
            this.fld_dgcMETemplateParams.BOSDescription = null;
            this.fld_dgcMETemplateParams.BOSError = null;
            this.fld_dgcMETemplateParams.BOSFieldGroup = "";
            this.fld_dgcMETemplateParams.BOSFieldRelation = "";
            this.fld_dgcMETemplateParams.BOSGridType = null;
            this.fld_dgcMETemplateParams.BOSPrivilege = "";
            this.fld_dgcMETemplateParams.BOSPropertyName = "";
            this.fld_dgcMETemplateParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_dgcMETemplateParams.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMETemplateParams.Location = new System.Drawing.Point(0, 0);
            this.fld_dgcMETemplateParams.MainView = this.gridView3;
            this.fld_dgcMETemplateParams.Name = "fld_dgcMETemplateParams";
            this.fld_dgcMETemplateParams.PrintReport = false;
            this.fld_dgcMETemplateParams.Screen = null;
            this.fld_dgcMETemplateParams.Size = new System.Drawing.Size(893, 301);
            this.fld_dgcMETemplateParams.TabIndex = 73;
            this.fld_dgcMETemplateParams.Tag = "DC";
            this.fld_dgcMETemplateParams.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.fld_dgcMETemplateParams;
            this.gridView3.Name = "gridView3";
            this.gridView3.PaintStyleName = "Office2003";
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.bosLabel19);
            this.xtraTabPage4.Controls.Add(this.bosLabel18);
            this.xtraTabPage4.Controls.Add(this.clpMETemplateDgtSignatureTextColor);
            this.xtraTabPage4.Controls.Add(this.bosLabel8);
            this.xtraTabPage4.Controls.Add(this.chkMETemplateDgtSignatureVisible);
            this.xtraTabPage4.Controls.Add(this.chkMETemplateDgtSignatureImage);
            this.xtraTabPage4.Controls.Add(this.txtMETemplateDgtSignatureReason);
            this.xtraTabPage4.Controls.Add(this.lblMETemplateDgtSignatureReason);
            this.xtraTabPage4.Controls.Add(this.txtMETemplateDgtSignaturePage);
            this.xtraTabPage4.Controls.Add(this.lblMETemplateDgtSignaturePage);
            this.xtraTabPage4.Controls.Add(this.lblMETemplateDgtSignatureFontSize);
            this.xtraTabPage4.Controls.Add(this.lblMETemplateDgtSignatureFontSize1);
            this.xtraTabPage4.Controls.Add(this.lblMETemplateDgtSignatureTextColor);
            this.xtraTabPage4.Controls.Add(this.txtMETemplateDgtSignatureHeight);
            this.xtraTabPage4.Controls.Add(this.lblMETemplateDgtSignatureHeight);
            this.xtraTabPage4.Controls.Add(this.txtMETemplateDgtSignatureWidth);
            this.xtraTabPage4.Controls.Add(this.lblMETemplateDgtSignatureWidth);
            this.xtraTabPage4.Controls.Add(this.txtMETemplateDgtSignatureY);
            this.xtraTabPage4.Controls.Add(this.lblMETemplateDgtSignatureY);
            this.xtraTabPage4.Controls.Add(this.txtMETemplateDgtSignatureX1);
            this.xtraTabPage4.Controls.Add(this.lblMETemplateDgtSignatureX);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(893, 301);
            this.xtraTabPage4.Text = "Cấu hình ký số CA";
            // 
            // bosLabel19
            // 
            this.bosLabel19.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel19.Appearance.ForeColor = System.Drawing.Color.Gray;
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
            this.bosLabel19.Location = new System.Drawing.Point(387, 173);
            this.bosLabel19.Name = "bosLabel19";
            this.bosLabel19.Screen = null;
            this.bosLabel19.Size = new System.Drawing.Size(201, 13);
            this.bosLabel19.TabIndex = 129;
            this.bosLabel19.Tag = "";
            this.bosLabel19.Text = "eSign Viettel CA chỉ hỗ trợ các màu cơ bản";
            // 
            // bosLabel18
            // 
            this.bosLabel18.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel18.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.bosLabel18.Appearance.Options.UseBackColor = true;
            this.bosLabel18.Appearance.Options.UseForeColor = true;
            this.bosLabel18.BOSComment = "";
            this.bosLabel18.BOSDataMember = "";
            this.bosLabel18.BOSDataSource = "";
            this.bosLabel18.BOSDescription = null;
            this.bosLabel18.BOSError = null;
            this.bosLabel18.BOSFieldGroup = "";
            this.bosLabel18.BOSFieldRelation = "";
            this.bosLabel18.BOSPrivilege = "";
            this.bosLabel18.BOSPropertyName = "";
            this.bosLabel18.Location = new System.Drawing.Point(387, 199);
            this.bosLabel18.Name = "bosLabel18";
            this.bosLabel18.Screen = null;
            this.bosLabel18.Size = new System.Drawing.Size(140, 13);
            this.bosLabel18.TabIndex = 128;
            this.bosLabel18.Tag = "";
            this.bosLabel18.Text = "eSign Viettel CA không hỗ trợ";
            // 
            // clpMETemplateDgtSignatureTextColor
            // 
            this.clpMETemplateDgtSignatureTextColor.BOSComment = null;
            this.clpMETemplateDgtSignatureTextColor.BOSDataMember = "METemplateDgtSignatureTextColor";
            this.clpMETemplateDgtSignatureTextColor.BOSDataSource = "METemplates";
            this.clpMETemplateDgtSignatureTextColor.BOSDescription = null;
            this.clpMETemplateDgtSignatureTextColor.BOSError = null;
            this.clpMETemplateDgtSignatureTextColor.BOSFieldGroup = null;
            this.clpMETemplateDgtSignatureTextColor.BOSFieldRelation = null;
            this.clpMETemplateDgtSignatureTextColor.BOSPrivilege = null;
            this.clpMETemplateDgtSignatureTextColor.BOSPropertyName = "EditValue";
            this.clpMETemplateDgtSignatureTextColor.EditValue = System.Drawing.Color.Empty;
            this.clpMETemplateDgtSignatureTextColor.Location = new System.Drawing.Point(150, 170);
            this.clpMETemplateDgtSignatureTextColor.MenuManager = this.screenToolbar;
            this.clpMETemplateDgtSignatureTextColor.Name = "clpMETemplateDgtSignatureTextColor";
            this.clpMETemplateDgtSignatureTextColor.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.clpMETemplateDgtSignatureTextColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.clpMETemplateDgtSignatureTextColor.Screen = null;
            this.clpMETemplateDgtSignatureTextColor.Size = new System.Drawing.Size(231, 20);
            this.clpMETemplateDgtSignatureTextColor.TabIndex = 127;
            this.clpMETemplateDgtSignatureTextColor.Tag = "DC";
            // 
            // bosLabel8
            // 
            this.bosLabel8.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel8.Appearance.ForeColor = System.Drawing.Color.Gray;
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
            this.bosLabel8.Location = new System.Drawing.Point(387, 43);
            this.bosLabel8.Name = "bosLabel8";
            this.bosLabel8.Screen = null;
            this.bosLabel8.Size = new System.Drawing.Size(251, 13);
            this.bosLabel8.TabIndex = 126;
            this.bosLabel8.Tag = "";
            this.bosLabel8.Text = "Cấu hình số thật lớn (vd: 999999) để ký ở trang cuối";
            // 
            // chkMETemplateDgtSignatureVisible
            // 
            this.chkMETemplateDgtSignatureVisible.BOSComment = null;
            this.chkMETemplateDgtSignatureVisible.BOSDataMember = "METemplateDgtSignatureVisible";
            this.chkMETemplateDgtSignatureVisible.BOSDataSource = "METemplates";
            this.chkMETemplateDgtSignatureVisible.BOSDescription = null;
            this.chkMETemplateDgtSignatureVisible.BOSError = null;
            this.chkMETemplateDgtSignatureVisible.BOSFieldGroup = null;
            this.chkMETemplateDgtSignatureVisible.BOSFieldRelation = null;
            this.chkMETemplateDgtSignatureVisible.BOSPrivilege = null;
            this.chkMETemplateDgtSignatureVisible.BOSPropertyName = "Checked";
            this.chkMETemplateDgtSignatureVisible.Location = new System.Drawing.Point(150, 15);
            this.chkMETemplateDgtSignatureVisible.MenuManager = this.screenToolbar;
            this.chkMETemplateDgtSignatureVisible.Name = "chkMETemplateDgtSignatureVisible";
            this.chkMETemplateDgtSignatureVisible.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkMETemplateDgtSignatureVisible.Properties.Appearance.Options.UseBackColor = true;
            this.chkMETemplateDgtSignatureVisible.Properties.Caption = "Hiển thị stamp";
            this.chkMETemplateDgtSignatureVisible.Screen = null;
            this.chkMETemplateDgtSignatureVisible.Size = new System.Drawing.Size(159, 19);
            this.chkMETemplateDgtSignatureVisible.TabIndex = 125;
            this.chkMETemplateDgtSignatureVisible.Tag = "DC";
            // 
            // chkMETemplateDgtSignatureImage
            // 
            this.chkMETemplateDgtSignatureImage.BOSComment = null;
            this.chkMETemplateDgtSignatureImage.BOSDataMember = "METemplateDgtSignatureImage";
            this.chkMETemplateDgtSignatureImage.BOSDataSource = "METemplates";
            this.chkMETemplateDgtSignatureImage.BOSDescription = null;
            this.chkMETemplateDgtSignatureImage.BOSError = null;
            this.chkMETemplateDgtSignatureImage.BOSFieldGroup = null;
            this.chkMETemplateDgtSignatureImage.BOSFieldRelation = null;
            this.chkMETemplateDgtSignatureImage.BOSPrivilege = null;
            this.chkMETemplateDgtSignatureImage.BOSPropertyName = "Checked";
            this.chkMETemplateDgtSignatureImage.Location = new System.Drawing.Point(150, 218);
            this.chkMETemplateDgtSignatureImage.MenuManager = this.screenToolbar;
            this.chkMETemplateDgtSignatureImage.Name = "chkMETemplateDgtSignatureImage";
            this.chkMETemplateDgtSignatureImage.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkMETemplateDgtSignatureImage.Properties.Appearance.Options.UseBackColor = true;
            this.chkMETemplateDgtSignatureImage.Properties.Caption = "Có chèn hình chữ ký";
            this.chkMETemplateDgtSignatureImage.Screen = null;
            this.chkMETemplateDgtSignatureImage.Size = new System.Drawing.Size(159, 19);
            this.chkMETemplateDgtSignatureImage.TabIndex = 120;
            this.chkMETemplateDgtSignatureImage.Tag = "DC";
            // 
            // txtMETemplateDgtSignatureReason
            // 
            this.txtMETemplateDgtSignatureReason.BOSComment = "";
            this.txtMETemplateDgtSignatureReason.BOSDataMember = "METemplateDgtSignatureReason";
            this.txtMETemplateDgtSignatureReason.BOSDataSource = "METemplates";
            this.txtMETemplateDgtSignatureReason.BOSDescription = null;
            this.txtMETemplateDgtSignatureReason.BOSError = null;
            this.txtMETemplateDgtSignatureReason.BOSFieldGroup = "";
            this.txtMETemplateDgtSignatureReason.BOSFieldRelation = "";
            this.txtMETemplateDgtSignatureReason.BOSPrivilege = "";
            this.txtMETemplateDgtSignatureReason.BOSPropertyName = "Text";
            this.txtMETemplateDgtSignatureReason.EditValue = "";
            this.txtMETemplateDgtSignatureReason.Location = new System.Drawing.Point(150, 241);
            this.txtMETemplateDgtSignatureReason.Name = "txtMETemplateDgtSignatureReason";
            this.txtMETemplateDgtSignatureReason.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtMETemplateDgtSignatureReason.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtMETemplateDgtSignatureReason.Properties.Appearance.Options.UseBackColor = true;
            this.txtMETemplateDgtSignatureReason.Properties.Appearance.Options.UseForeColor = true;
            this.txtMETemplateDgtSignatureReason.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtMETemplateDgtSignatureReason.Screen = null;
            this.txtMETemplateDgtSignatureReason.Size = new System.Drawing.Size(468, 20);
            this.txtMETemplateDgtSignatureReason.TabIndex = 122;
            this.txtMETemplateDgtSignatureReason.Tag = "DC";
            // 
            // lblMETemplateDgtSignatureReason
            // 
            this.lblMETemplateDgtSignatureReason.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblMETemplateDgtSignatureReason.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMETemplateDgtSignatureReason.Appearance.Options.UseBackColor = true;
            this.lblMETemplateDgtSignatureReason.Appearance.Options.UseForeColor = true;
            this.lblMETemplateDgtSignatureReason.BOSComment = "";
            this.lblMETemplateDgtSignatureReason.BOSDataMember = "";
            this.lblMETemplateDgtSignatureReason.BOSDataSource = "";
            this.lblMETemplateDgtSignatureReason.BOSDescription = null;
            this.lblMETemplateDgtSignatureReason.BOSError = null;
            this.lblMETemplateDgtSignatureReason.BOSFieldGroup = "";
            this.lblMETemplateDgtSignatureReason.BOSFieldRelation = "";
            this.lblMETemplateDgtSignatureReason.BOSPrivilege = "";
            this.lblMETemplateDgtSignatureReason.BOSPropertyName = "";
            this.lblMETemplateDgtSignatureReason.Location = new System.Drawing.Point(27, 244);
            this.lblMETemplateDgtSignatureReason.Name = "lblMETemplateDgtSignatureReason";
            this.lblMETemplateDgtSignatureReason.Screen = null;
            this.lblMETemplateDgtSignatureReason.Size = new System.Drawing.Size(79, 13);
            this.lblMETemplateDgtSignatureReason.TabIndex = 124;
            this.lblMETemplateDgtSignatureReason.Tag = "";
            this.lblMETemplateDgtSignatureReason.Text = "Lý do (mặc định)";
            // 
            // txtMETemplateDgtSignaturePage
            // 
            this.txtMETemplateDgtSignaturePage.BOSComment = "";
            this.txtMETemplateDgtSignaturePage.BOSDataMember = "METemplateDgtSignaturePage";
            this.txtMETemplateDgtSignaturePage.BOSDataSource = "METemplates";
            this.txtMETemplateDgtSignaturePage.BOSDescription = null;
            this.txtMETemplateDgtSignaturePage.BOSError = null;
            this.txtMETemplateDgtSignaturePage.BOSFieldGroup = "";
            this.txtMETemplateDgtSignaturePage.BOSFieldRelation = "";
            this.txtMETemplateDgtSignaturePage.BOSPrivilege = "";
            this.txtMETemplateDgtSignaturePage.BOSPropertyName = "Text";
            this.txtMETemplateDgtSignaturePage.EditValue = "";
            this.txtMETemplateDgtSignaturePage.Location = new System.Drawing.Point(150, 40);
            this.txtMETemplateDgtSignaturePage.Name = "txtMETemplateDgtSignaturePage";
            this.txtMETemplateDgtSignaturePage.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtMETemplateDgtSignaturePage.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtMETemplateDgtSignaturePage.Properties.Appearance.Options.UseBackColor = true;
            this.txtMETemplateDgtSignaturePage.Properties.Appearance.Options.UseForeColor = true;
            this.txtMETemplateDgtSignaturePage.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtMETemplateDgtSignaturePage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMETemplateDgtSignaturePage.Screen = null;
            this.txtMETemplateDgtSignaturePage.Size = new System.Drawing.Size(231, 20);
            this.txtMETemplateDgtSignaturePage.TabIndex = 121;
            this.txtMETemplateDgtSignaturePage.Tag = "DC";
            // 
            // lblMETemplateDgtSignaturePage
            // 
            this.lblMETemplateDgtSignaturePage.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblMETemplateDgtSignaturePage.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMETemplateDgtSignaturePage.Appearance.Options.UseBackColor = true;
            this.lblMETemplateDgtSignaturePage.Appearance.Options.UseForeColor = true;
            this.lblMETemplateDgtSignaturePage.BOSComment = "";
            this.lblMETemplateDgtSignaturePage.BOSDataMember = "";
            this.lblMETemplateDgtSignaturePage.BOSDataSource = "";
            this.lblMETemplateDgtSignaturePage.BOSDescription = null;
            this.lblMETemplateDgtSignaturePage.BOSError = null;
            this.lblMETemplateDgtSignaturePage.BOSFieldGroup = "";
            this.lblMETemplateDgtSignaturePage.BOSFieldRelation = "";
            this.lblMETemplateDgtSignaturePage.BOSPrivilege = "";
            this.lblMETemplateDgtSignaturePage.BOSPropertyName = "";
            this.lblMETemplateDgtSignaturePage.Location = new System.Drawing.Point(27, 43);
            this.lblMETemplateDgtSignaturePage.Name = "lblMETemplateDgtSignaturePage";
            this.lblMETemplateDgtSignaturePage.Screen = null;
            this.lblMETemplateDgtSignaturePage.Size = new System.Drawing.Size(50, 13);
            this.lblMETemplateDgtSignaturePage.TabIndex = 123;
            this.lblMETemplateDgtSignaturePage.Tag = "";
            this.lblMETemplateDgtSignaturePage.Text = "Ký ở trang";
            // 
            // lblMETemplateDgtSignatureFontSize
            // 
            this.lblMETemplateDgtSignatureFontSize.BOSComment = "";
            this.lblMETemplateDgtSignatureFontSize.BOSDataMember = "METemplateDgtSignatureFontSize";
            this.lblMETemplateDgtSignatureFontSize.BOSDataSource = "METemplates";
            this.lblMETemplateDgtSignatureFontSize.BOSDescription = null;
            this.lblMETemplateDgtSignatureFontSize.BOSError = null;
            this.lblMETemplateDgtSignatureFontSize.BOSFieldGroup = "";
            this.lblMETemplateDgtSignatureFontSize.BOSFieldRelation = "";
            this.lblMETemplateDgtSignatureFontSize.BOSPrivilege = "";
            this.lblMETemplateDgtSignatureFontSize.BOSPropertyName = "Text";
            this.lblMETemplateDgtSignatureFontSize.EditValue = "";
            this.lblMETemplateDgtSignatureFontSize.Location = new System.Drawing.Point(150, 196);
            this.lblMETemplateDgtSignatureFontSize.Name = "lblMETemplateDgtSignatureFontSize";
            this.lblMETemplateDgtSignatureFontSize.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblMETemplateDgtSignatureFontSize.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMETemplateDgtSignatureFontSize.Properties.Appearance.Options.UseBackColor = true;
            this.lblMETemplateDgtSignatureFontSize.Properties.Appearance.Options.UseForeColor = true;
            this.lblMETemplateDgtSignatureFontSize.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.lblMETemplateDgtSignatureFontSize.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMETemplateDgtSignatureFontSize.Screen = null;
            this.lblMETemplateDgtSignatureFontSize.Size = new System.Drawing.Size(231, 20);
            this.lblMETemplateDgtSignatureFontSize.TabIndex = 118;
            this.lblMETemplateDgtSignatureFontSize.Tag = "DC";
            // 
            // lblMETemplateDgtSignatureFontSize1
            // 
            this.lblMETemplateDgtSignatureFontSize1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblMETemplateDgtSignatureFontSize1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMETemplateDgtSignatureFontSize1.Appearance.Options.UseBackColor = true;
            this.lblMETemplateDgtSignatureFontSize1.Appearance.Options.UseForeColor = true;
            this.lblMETemplateDgtSignatureFontSize1.BOSComment = "";
            this.lblMETemplateDgtSignatureFontSize1.BOSDataMember = "";
            this.lblMETemplateDgtSignatureFontSize1.BOSDataSource = "";
            this.lblMETemplateDgtSignatureFontSize1.BOSDescription = null;
            this.lblMETemplateDgtSignatureFontSize1.BOSError = null;
            this.lblMETemplateDgtSignatureFontSize1.BOSFieldGroup = "";
            this.lblMETemplateDgtSignatureFontSize1.BOSFieldRelation = "";
            this.lblMETemplateDgtSignatureFontSize1.BOSPrivilege = "";
            this.lblMETemplateDgtSignatureFontSize1.BOSPropertyName = "";
            this.lblMETemplateDgtSignatureFontSize1.Location = new System.Drawing.Point(27, 199);
            this.lblMETemplateDgtSignatureFontSize1.Name = "lblMETemplateDgtSignatureFontSize1";
            this.lblMETemplateDgtSignatureFontSize1.Screen = null;
            this.lblMETemplateDgtSignatureFontSize1.Size = new System.Drawing.Size(34, 13);
            this.lblMETemplateDgtSignatureFontSize1.TabIndex = 119;
            this.lblMETemplateDgtSignatureFontSize1.Tag = "";
            this.lblMETemplateDgtSignatureFontSize1.Text = "Cỡ chữ";
            // 
            // lblMETemplateDgtSignatureTextColor
            // 
            this.lblMETemplateDgtSignatureTextColor.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblMETemplateDgtSignatureTextColor.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMETemplateDgtSignatureTextColor.Appearance.Options.UseBackColor = true;
            this.lblMETemplateDgtSignatureTextColor.Appearance.Options.UseForeColor = true;
            this.lblMETemplateDgtSignatureTextColor.BOSComment = "";
            this.lblMETemplateDgtSignatureTextColor.BOSDataMember = "";
            this.lblMETemplateDgtSignatureTextColor.BOSDataSource = "";
            this.lblMETemplateDgtSignatureTextColor.BOSDescription = null;
            this.lblMETemplateDgtSignatureTextColor.BOSError = null;
            this.lblMETemplateDgtSignatureTextColor.BOSFieldGroup = "";
            this.lblMETemplateDgtSignatureTextColor.BOSFieldRelation = "";
            this.lblMETemplateDgtSignatureTextColor.BOSPrivilege = "";
            this.lblMETemplateDgtSignatureTextColor.BOSPropertyName = "";
            this.lblMETemplateDgtSignatureTextColor.Location = new System.Drawing.Point(27, 173);
            this.lblMETemplateDgtSignatureTextColor.Name = "lblMETemplateDgtSignatureTextColor";
            this.lblMETemplateDgtSignatureTextColor.Screen = null;
            this.lblMETemplateDgtSignatureTextColor.Size = new System.Drawing.Size(41, 13);
            this.lblMETemplateDgtSignatureTextColor.TabIndex = 117;
            this.lblMETemplateDgtSignatureTextColor.Tag = "";
            this.lblMETemplateDgtSignatureTextColor.Text = "Màu chữ";
            // 
            // txtMETemplateDgtSignatureHeight
            // 
            this.txtMETemplateDgtSignatureHeight.BOSComment = "";
            this.txtMETemplateDgtSignatureHeight.BOSDataMember = "METemplateDgtSignatureHeight";
            this.txtMETemplateDgtSignatureHeight.BOSDataSource = "METemplates";
            this.txtMETemplateDgtSignatureHeight.BOSDescription = null;
            this.txtMETemplateDgtSignatureHeight.BOSError = null;
            this.txtMETemplateDgtSignatureHeight.BOSFieldGroup = "";
            this.txtMETemplateDgtSignatureHeight.BOSFieldRelation = "";
            this.txtMETemplateDgtSignatureHeight.BOSPrivilege = "";
            this.txtMETemplateDgtSignatureHeight.BOSPropertyName = "Text";
            this.txtMETemplateDgtSignatureHeight.EditValue = "";
            this.txtMETemplateDgtSignatureHeight.Location = new System.Drawing.Point(150, 144);
            this.txtMETemplateDgtSignatureHeight.Name = "txtMETemplateDgtSignatureHeight";
            this.txtMETemplateDgtSignatureHeight.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtMETemplateDgtSignatureHeight.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtMETemplateDgtSignatureHeight.Properties.Appearance.Options.UseBackColor = true;
            this.txtMETemplateDgtSignatureHeight.Properties.Appearance.Options.UseForeColor = true;
            this.txtMETemplateDgtSignatureHeight.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtMETemplateDgtSignatureHeight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMETemplateDgtSignatureHeight.Screen = null;
            this.txtMETemplateDgtSignatureHeight.Size = new System.Drawing.Size(231, 20);
            this.txtMETemplateDgtSignatureHeight.TabIndex = 115;
            this.txtMETemplateDgtSignatureHeight.Tag = "DC";
            // 
            // lblMETemplateDgtSignatureHeight
            // 
            this.lblMETemplateDgtSignatureHeight.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblMETemplateDgtSignatureHeight.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMETemplateDgtSignatureHeight.Appearance.Options.UseBackColor = true;
            this.lblMETemplateDgtSignatureHeight.Appearance.Options.UseForeColor = true;
            this.lblMETemplateDgtSignatureHeight.BOSComment = "";
            this.lblMETemplateDgtSignatureHeight.BOSDataMember = "";
            this.lblMETemplateDgtSignatureHeight.BOSDataSource = "";
            this.lblMETemplateDgtSignatureHeight.BOSDescription = null;
            this.lblMETemplateDgtSignatureHeight.BOSError = null;
            this.lblMETemplateDgtSignatureHeight.BOSFieldGroup = "";
            this.lblMETemplateDgtSignatureHeight.BOSFieldRelation = "";
            this.lblMETemplateDgtSignatureHeight.BOSPrivilege = "";
            this.lblMETemplateDgtSignatureHeight.BOSPropertyName = "";
            this.lblMETemplateDgtSignatureHeight.Location = new System.Drawing.Point(27, 147);
            this.lblMETemplateDgtSignatureHeight.Name = "lblMETemplateDgtSignatureHeight";
            this.lblMETemplateDgtSignatureHeight.Screen = null;
            this.lblMETemplateDgtSignatureHeight.Size = new System.Drawing.Size(79, 13);
            this.lblMETemplateDgtSignatureHeight.TabIndex = 116;
            this.lblMETemplateDgtSignatureHeight.Tag = "";
            this.lblMETemplateDgtSignatureHeight.Text = "Chiều cao stamp";
            // 
            // txtMETemplateDgtSignatureWidth
            // 
            this.txtMETemplateDgtSignatureWidth.BOSComment = "";
            this.txtMETemplateDgtSignatureWidth.BOSDataMember = "METemplateDgtSignatureWidth";
            this.txtMETemplateDgtSignatureWidth.BOSDataSource = "METemplates";
            this.txtMETemplateDgtSignatureWidth.BOSDescription = null;
            this.txtMETemplateDgtSignatureWidth.BOSError = null;
            this.txtMETemplateDgtSignatureWidth.BOSFieldGroup = "";
            this.txtMETemplateDgtSignatureWidth.BOSFieldRelation = "";
            this.txtMETemplateDgtSignatureWidth.BOSPrivilege = "";
            this.txtMETemplateDgtSignatureWidth.BOSPropertyName = "Text";
            this.txtMETemplateDgtSignatureWidth.EditValue = "";
            this.txtMETemplateDgtSignatureWidth.Location = new System.Drawing.Point(150, 118);
            this.txtMETemplateDgtSignatureWidth.Name = "txtMETemplateDgtSignatureWidth";
            this.txtMETemplateDgtSignatureWidth.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtMETemplateDgtSignatureWidth.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtMETemplateDgtSignatureWidth.Properties.Appearance.Options.UseBackColor = true;
            this.txtMETemplateDgtSignatureWidth.Properties.Appearance.Options.UseForeColor = true;
            this.txtMETemplateDgtSignatureWidth.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtMETemplateDgtSignatureWidth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMETemplateDgtSignatureWidth.Screen = null;
            this.txtMETemplateDgtSignatureWidth.Size = new System.Drawing.Size(231, 20);
            this.txtMETemplateDgtSignatureWidth.TabIndex = 113;
            this.txtMETemplateDgtSignatureWidth.Tag = "DC";
            // 
            // lblMETemplateDgtSignatureWidth
            // 
            this.lblMETemplateDgtSignatureWidth.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblMETemplateDgtSignatureWidth.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMETemplateDgtSignatureWidth.Appearance.Options.UseBackColor = true;
            this.lblMETemplateDgtSignatureWidth.Appearance.Options.UseForeColor = true;
            this.lblMETemplateDgtSignatureWidth.BOSComment = "";
            this.lblMETemplateDgtSignatureWidth.BOSDataMember = "";
            this.lblMETemplateDgtSignatureWidth.BOSDataSource = "";
            this.lblMETemplateDgtSignatureWidth.BOSDescription = null;
            this.lblMETemplateDgtSignatureWidth.BOSError = null;
            this.lblMETemplateDgtSignatureWidth.BOSFieldGroup = "";
            this.lblMETemplateDgtSignatureWidth.BOSFieldRelation = "";
            this.lblMETemplateDgtSignatureWidth.BOSPrivilege = "";
            this.lblMETemplateDgtSignatureWidth.BOSPropertyName = "";
            this.lblMETemplateDgtSignatureWidth.Location = new System.Drawing.Point(27, 121);
            this.lblMETemplateDgtSignatureWidth.Name = "lblMETemplateDgtSignatureWidth";
            this.lblMETemplateDgtSignatureWidth.Screen = null;
            this.lblMETemplateDgtSignatureWidth.Size = new System.Drawing.Size(84, 13);
            this.lblMETemplateDgtSignatureWidth.TabIndex = 114;
            this.lblMETemplateDgtSignatureWidth.Tag = "";
            this.lblMETemplateDgtSignatureWidth.Text = "Chiều rộng stamp";
            // 
            // txtMETemplateDgtSignatureY
            // 
            this.txtMETemplateDgtSignatureY.BOSComment = "";
            this.txtMETemplateDgtSignatureY.BOSDataMember = "METemplateDgtSignatureY";
            this.txtMETemplateDgtSignatureY.BOSDataSource = "METemplates";
            this.txtMETemplateDgtSignatureY.BOSDescription = null;
            this.txtMETemplateDgtSignatureY.BOSError = null;
            this.txtMETemplateDgtSignatureY.BOSFieldGroup = "";
            this.txtMETemplateDgtSignatureY.BOSFieldRelation = "";
            this.txtMETemplateDgtSignatureY.BOSPrivilege = "";
            this.txtMETemplateDgtSignatureY.BOSPropertyName = "Text";
            this.txtMETemplateDgtSignatureY.EditValue = "";
            this.txtMETemplateDgtSignatureY.Location = new System.Drawing.Point(150, 92);
            this.txtMETemplateDgtSignatureY.Name = "txtMETemplateDgtSignatureY";
            this.txtMETemplateDgtSignatureY.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtMETemplateDgtSignatureY.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtMETemplateDgtSignatureY.Properties.Appearance.Options.UseBackColor = true;
            this.txtMETemplateDgtSignatureY.Properties.Appearance.Options.UseForeColor = true;
            this.txtMETemplateDgtSignatureY.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtMETemplateDgtSignatureY.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMETemplateDgtSignatureY.Screen = null;
            this.txtMETemplateDgtSignatureY.Size = new System.Drawing.Size(231, 20);
            this.txtMETemplateDgtSignatureY.TabIndex = 111;
            this.txtMETemplateDgtSignatureY.Tag = "DC";
            // 
            // lblMETemplateDgtSignatureY
            // 
            this.lblMETemplateDgtSignatureY.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblMETemplateDgtSignatureY.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMETemplateDgtSignatureY.Appearance.Options.UseBackColor = true;
            this.lblMETemplateDgtSignatureY.Appearance.Options.UseForeColor = true;
            this.lblMETemplateDgtSignatureY.BOSComment = "";
            this.lblMETemplateDgtSignatureY.BOSDataMember = "";
            this.lblMETemplateDgtSignatureY.BOSDataSource = "";
            this.lblMETemplateDgtSignatureY.BOSDescription = null;
            this.lblMETemplateDgtSignatureY.BOSError = null;
            this.lblMETemplateDgtSignatureY.BOSFieldGroup = "";
            this.lblMETemplateDgtSignatureY.BOSFieldRelation = "";
            this.lblMETemplateDgtSignatureY.BOSPrivilege = "";
            this.lblMETemplateDgtSignatureY.BOSPropertyName = "";
            this.lblMETemplateDgtSignatureY.Location = new System.Drawing.Point(27, 95);
            this.lblMETemplateDgtSignatureY.Name = "lblMETemplateDgtSignatureY";
            this.lblMETemplateDgtSignatureY.Screen = null;
            this.lblMETemplateDgtSignatureY.Size = new System.Drawing.Size(109, 13);
            this.lblMETemplateDgtSignatureY.TabIndex = 112;
            this.lblMETemplateDgtSignatureY.Tag = "";
            this.lblMETemplateDgtSignatureY.Text = "Tọa độ Y góc Dưới-Trái";
            // 
            // txtMETemplateDgtSignatureX1
            // 
            this.txtMETemplateDgtSignatureX1.BOSComment = "";
            this.txtMETemplateDgtSignatureX1.BOSDataMember = "METemplateDgtSignatureX";
            this.txtMETemplateDgtSignatureX1.BOSDataSource = "METemplates";
            this.txtMETemplateDgtSignatureX1.BOSDescription = null;
            this.txtMETemplateDgtSignatureX1.BOSError = null;
            this.txtMETemplateDgtSignatureX1.BOSFieldGroup = "";
            this.txtMETemplateDgtSignatureX1.BOSFieldRelation = "";
            this.txtMETemplateDgtSignatureX1.BOSPrivilege = "";
            this.txtMETemplateDgtSignatureX1.BOSPropertyName = "Text";
            this.txtMETemplateDgtSignatureX1.EditValue = "";
            this.txtMETemplateDgtSignatureX1.Location = new System.Drawing.Point(150, 66);
            this.txtMETemplateDgtSignatureX1.Name = "txtMETemplateDgtSignatureX1";
            this.txtMETemplateDgtSignatureX1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtMETemplateDgtSignatureX1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtMETemplateDgtSignatureX1.Properties.Appearance.Options.UseBackColor = true;
            this.txtMETemplateDgtSignatureX1.Properties.Appearance.Options.UseForeColor = true;
            this.txtMETemplateDgtSignatureX1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtMETemplateDgtSignatureX1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMETemplateDgtSignatureX1.Screen = null;
            this.txtMETemplateDgtSignatureX1.Size = new System.Drawing.Size(231, 20);
            this.txtMETemplateDgtSignatureX1.TabIndex = 109;
            this.txtMETemplateDgtSignatureX1.Tag = "DC";
            // 
            // lblMETemplateDgtSignatureX
            // 
            this.lblMETemplateDgtSignatureX.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblMETemplateDgtSignatureX.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMETemplateDgtSignatureX.Appearance.Options.UseBackColor = true;
            this.lblMETemplateDgtSignatureX.Appearance.Options.UseForeColor = true;
            this.lblMETemplateDgtSignatureX.BOSComment = "";
            this.lblMETemplateDgtSignatureX.BOSDataMember = "";
            this.lblMETemplateDgtSignatureX.BOSDataSource = "";
            this.lblMETemplateDgtSignatureX.BOSDescription = null;
            this.lblMETemplateDgtSignatureX.BOSError = null;
            this.lblMETemplateDgtSignatureX.BOSFieldGroup = "";
            this.lblMETemplateDgtSignatureX.BOSFieldRelation = "";
            this.lblMETemplateDgtSignatureX.BOSPrivilege = "";
            this.lblMETemplateDgtSignatureX.BOSPropertyName = "";
            this.lblMETemplateDgtSignatureX.Location = new System.Drawing.Point(27, 69);
            this.lblMETemplateDgtSignatureX.Name = "lblMETemplateDgtSignatureX";
            this.lblMETemplateDgtSignatureX.Screen = null;
            this.lblMETemplateDgtSignatureX.Size = new System.Drawing.Size(109, 13);
            this.lblMETemplateDgtSignatureX.TabIndex = 110;
            this.lblMETemplateDgtSignatureX.Tag = "";
            this.lblMETemplateDgtSignatureX.Text = "Tọa độ X góc Dưới-Trái";
            // 
            // bosTextBox1
            // 
            this.bosTextBox1.BOSComment = "";
            this.bosTextBox1.BOSDataMember = "METemplateGuid";
            this.bosTextBox1.BOSDataSource = "METemplates";
            this.bosTextBox1.BOSDescription = null;
            this.bosTextBox1.BOSError = null;
            this.bosTextBox1.BOSFieldGroup = "";
            this.bosTextBox1.BOSFieldRelation = "";
            this.bosTextBox1.BOSPrivilege = "";
            this.bosTextBox1.BOSPropertyName = "Text";
            this.bosTextBox1.EditValue = "";
            this.bosTextBox1.Location = new System.Drawing.Point(141, 62);
            this.bosTextBox1.Name = "bosTextBox1";
            this.bosTextBox1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosTextBox1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosTextBox1.Properties.Appearance.Options.UseBackColor = true;
            this.bosTextBox1.Properties.Appearance.Options.UseForeColor = true;
            this.bosTextBox1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.bosTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bosTextBox1.Screen = null;
            this.bosTextBox1.Size = new System.Drawing.Size(343, 20);
            this.bosTextBox1.TabIndex = 75;
            this.bosTextBox1.Tag = "DC";
            // 
            // bosLabel1
            // 
            this.bosLabel1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
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
            this.bosLabel1.Location = new System.Drawing.Point(44, 64);
            this.bosLabel1.Name = "bosLabel1";
            this.bosLabel1.Screen = null;
            this.bosLabel1.Size = new System.Drawing.Size(27, 13);
            this.bosLabel1.TabIndex = 76;
            this.bosLabel1.Tag = "";
            this.bosLabel1.Text = "Nhóm";
            // 
            // fld_lkeMETemplateType
            // 
            this.fld_lkeMETemplateType.BOSAllowAddNew = false;
            this.fld_lkeMETemplateType.BOSAllowDummy = false;
            this.fld_lkeMETemplateType.BOSComment = null;
            this.fld_lkeMETemplateType.BOSDataMember = "METemplateType";
            this.fld_lkeMETemplateType.BOSDataSource = "METemplates";
            this.fld_lkeMETemplateType.BOSDescription = null;
            this.fld_lkeMETemplateType.BOSDummyText = null;
            this.fld_lkeMETemplateType.BOSError = null;
            this.fld_lkeMETemplateType.BOSFieldGroup = null;
            this.fld_lkeMETemplateType.BOSFieldParent = null;
            this.fld_lkeMETemplateType.BOSFieldRelation = null;
            this.fld_lkeMETemplateType.BOSPrivilege = null;
            this.fld_lkeMETemplateType.BOSPropertyName = "EditValue";
            this.fld_lkeMETemplateType.BOSSelectType = null;
            this.fld_lkeMETemplateType.BOSSelectTypeValue = null;
            this.fld_lkeMETemplateType.CurrentDisplayText = null;
            this.fld_lkeMETemplateType.Location = new System.Drawing.Point(141, 86);
            this.fld_lkeMETemplateType.MenuManager = this.screenToolbar;
            this.fld_lkeMETemplateType.Name = "fld_lkeMETemplateType";
            this.fld_lkeMETemplateType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeMETemplateType.Properties.NullText = "";
            this.fld_lkeMETemplateType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeMETemplateType.Screen = null;
            this.fld_lkeMETemplateType.Size = new System.Drawing.Size(343, 20);
            this.fld_lkeMETemplateType.TabIndex = 1;
            this.fld_lkeMETemplateType.Tag = "DC";
            // 
            // bosLabel201
            // 
            this.bosLabel201.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel201.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel201.Appearance.Options.UseBackColor = true;
            this.bosLabel201.Appearance.Options.UseForeColor = true;
            this.bosLabel201.BOSComment = "";
            this.bosLabel201.BOSDataMember = "";
            this.bosLabel201.BOSDataSource = "";
            this.bosLabel201.BOSDescription = null;
            this.bosLabel201.BOSError = null;
            this.bosLabel201.BOSFieldGroup = "";
            this.bosLabel201.BOSFieldRelation = "";
            this.bosLabel201.BOSPrivilege = "";
            this.bosLabel201.BOSPropertyName = "";
            this.bosLabel201.Location = new System.Drawing.Point(44, 90);
            this.bosLabel201.Name = "bosLabel201";
            this.bosLabel201.Screen = null;
            this.bosLabel201.Size = new System.Drawing.Size(84, 13);
            this.bosLabel201.TabIndex = 4;
            this.bosLabel201.Tag = "";
            this.bosLabel201.Text = "Loại mẫu bệnh án";
            // 
            // DMMETE100
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(905, 490);
            this.Controls.Add(this.bosPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DMMETE100";
            this.Text = "Thông tin mẫu bệnh án";
            this.Controls.SetChildIndex(this.bosPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMETemplateNo1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMETemplateName1.Properties)).EndInit();
            this.bosPanel1.ResumeLayout(false);
            this.bosPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMETemplateRemoveEmptyParagraph.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHighlightEmrTag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMETemplateNightlyPdfExport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTemplateSignatureNotAlone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosTextBox2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_METemplateID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HREmployeeShareID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_HRDepartmentShareID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMETemplateShareMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.bosPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrActions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrTemplateActions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvGridControl)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMETemplateUserGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMETemplateParams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.xtraTabPage4.ResumeLayout(false);
            this.xtraTabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clpMETemplateDgtSignatureTextColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMETemplateDgtSignatureVisible.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMETemplateDgtSignatureImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMETemplateDgtSignatureReason.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMETemplateDgtSignaturePage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMETemplateDgtSignatureFontSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMETemplateDgtSignatureHeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMETemplateDgtSignatureWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMETemplateDgtSignatureY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMETemplateDgtSignatureX1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bosTextBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMETemplateType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private IContainer components;
        private BOSComponent.BOSPanel bosPanel1;
        private BOSComponent.BOSLookupEdit fld_lkeMETemplateType;
        private BOSComponent.BOSLabel bosLabel201;
        private BOSComponent.BOSTextBox bosTextBox1;
        private BOSComponent.BOSLabel bosLabel1;
        private BOSTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private BOSComponent.BOSPanel bosPanel2;
        private DevExpress.XtraEditors.SimpleButton fld_btnRemoveAction;
        private DevExpress.XtraEditors.SimpleButton fld_btnAddAction;
        private MEEmrStartupActionsGridControl fld_dgcMEEmrActions;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private MEEmrTemplateActionsGridControl fld_dgcMEEmrTemplateActions;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvGridControl;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private METemplateUserGroupsGridControl fld_dgcMETemplateUserGroups;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private METemplateParamsGridControl fld_dgcMETemplateParams;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private BOSLookupEdit fld_lkeMETemplateShareMode;
        private BOSLabel bosLabel2;
        private BOSLookupEdit fld_lkeFK_HRDepartmentShareID;
        private BOSLabel bosLabel3;
        private BOSLookupEdit fld_lkeFK_HREmployeeShareID;
        private BOSLabel bosLabel4;
        private BOSLookupEdit fld_lkeFK_METemplateID;
        private BOSLabel bosLabel5;
        private BOSTextBox bosTextBox2;
        private BOSLabel bosLabel6;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private BOSLabel bosLabel19;
        private BOSLabel bosLabel18;
        private ClasColorPicker clpMETemplateDgtSignatureTextColor;
        private BOSLabel bosLabel8;
        private BOSCheckEdit chkMETemplateDgtSignatureVisible;
        private BOSCheckEdit chkMETemplateDgtSignatureImage;
        private BOSTextBox txtMETemplateDgtSignatureReason;
        private BOSLabel lblMETemplateDgtSignatureReason;
        private BOSTextBox txtMETemplateDgtSignaturePage;
        private BOSLabel lblMETemplateDgtSignaturePage;
        private BOSTextBox lblMETemplateDgtSignatureFontSize;
        private BOSLabel lblMETemplateDgtSignatureFontSize1;
        private BOSLabel lblMETemplateDgtSignatureTextColor;
        private BOSTextBox txtMETemplateDgtSignatureHeight;
        private BOSLabel lblMETemplateDgtSignatureHeight;
        private BOSTextBox txtMETemplateDgtSignatureWidth;
        private BOSLabel lblMETemplateDgtSignatureWidth;
        private BOSTextBox txtMETemplateDgtSignatureY;
        private BOSLabel lblMETemplateDgtSignatureY;
        private BOSTextBox txtMETemplateDgtSignatureX1;
        private BOSLabel lblMETemplateDgtSignatureX;
        private BOSCheckEdit chkTemplateSignatureNotAlone;
        private BOSCheckEdit chkHighlightEmrTag;
        private BOSCheckEdit chkMETemplateRemoveEmptyParagraph;
        private BOSCheckEdit chkMETemplateNightlyPdfExport;
    }
}
