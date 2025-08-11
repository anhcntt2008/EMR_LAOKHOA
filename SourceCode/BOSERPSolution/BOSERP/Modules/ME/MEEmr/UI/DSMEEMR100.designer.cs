using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    partial class DSMEEMR100
    {
        private BOSComponent.BOSMemoEdit fld_medMEEmrDocumentDesc;
        private BOSComponent.BOSLookupEdit fld_lkeFK_METemplateID;
        private BOSComponent.BOSLabel fld_lblLabel9;
        private BOSComponent.BOSLabel fld_lblLabel10;


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DSMEEMR100));
            this.fld_medMEEmrDocumentDesc = new BOSComponent.BOSMemoEdit(this.components);
            this.fld_lkeFK_METemplateID = new BOSComponent.BOSLookupEdit(this.components);
            this.fld_lblLabel9 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel10 = new BOSComponent.BOSLabel(this.components);
            this.fld_btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.fld_btn_Ok = new DevExpress.XtraEditors.SimpleButton();
            this.bosLabel1 = new BOSComponent.BOSLabel(this.components);
            this.fld_txtFileName = new BOSComponent.BOSTextBox(this.components);
            this.fld_btnSelectFile = new DevExpress.XtraEditors.SimpleButton();
            this.fld_chkAppendToCurrentDocument = new BOSComponent.BOSCheckEdit(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fld_grdSelectionTemplate = new BOSERP.Modules.MEEmr.SelectionTemplateGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.fld_medMEEmrDocumentDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_METemplateID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkAppendToCurrentDocument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_grdSelectionTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_medMEEmrDocumentDesc
            // 
            this.fld_medMEEmrDocumentDesc.BOSComment = "";
            this.fld_medMEEmrDocumentDesc.BOSDataMember = "";
            this.fld_medMEEmrDocumentDesc.BOSDataSource = "";
            this.fld_medMEEmrDocumentDesc.BOSDescription = null;
            this.fld_medMEEmrDocumentDesc.BOSError = null;
            this.fld_medMEEmrDocumentDesc.BOSFieldGroup = "";
            this.fld_medMEEmrDocumentDesc.BOSFieldRelation = "";
            this.fld_medMEEmrDocumentDesc.BOSPrivilege = "";
            this.fld_medMEEmrDocumentDesc.BOSPropertyName = "Text";
            this.fld_medMEEmrDocumentDesc.EditValue = "";
            this.fld_medMEEmrDocumentDesc.Location = new System.Drawing.Point(71, 447);
            this.fld_medMEEmrDocumentDesc.Name = "fld_medMEEmrDocumentDesc";
            this.fld_medMEEmrDocumentDesc.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_medMEEmrDocumentDesc.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_medMEEmrDocumentDesc.Properties.Appearance.Options.UseBackColor = true;
            this.fld_medMEEmrDocumentDesc.Properties.Appearance.Options.UseForeColor = true;
            this.fld_medMEEmrDocumentDesc.Screen = null;
            this.fld_medMEEmrDocumentDesc.Size = new System.Drawing.Size(599, 68);
            this.fld_medMEEmrDocumentDesc.TabIndex = 3;
            this.fld_medMEEmrDocumentDesc.Tag = "DC";
            // 
            // fld_lkeFK_METemplateID
            // 
            this.fld_lkeFK_METemplateID.BOSAllowAddNew = false;
            this.fld_lkeFK_METemplateID.BOSAllowDummy = false;
            this.fld_lkeFK_METemplateID.BOSComment = "";
            this.fld_lkeFK_METemplateID.BOSDataMember = "FK_METemplateID";
            this.fld_lkeFK_METemplateID.BOSDataSource = "MEEmrDocuments";
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
            this.fld_lkeFK_METemplateID.Location = new System.Drawing.Point(71, 37);
            this.fld_lkeFK_METemplateID.Name = "fld_lkeFK_METemplateID";
            this.fld_lkeFK_METemplateID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeFK_METemplateID.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeFK_METemplateID.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeFK_METemplateID.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeFK_METemplateID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeFK_METemplateID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("METemplateNo", "Mã", 20, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("METemplateName", "Tên mẫu")});
            this.fld_lkeFK_METemplateID.Properties.DisplayMember = "METemplateName";
            this.fld_lkeFK_METemplateID.Properties.NullText = "";
            this.fld_lkeFK_METemplateID.Properties.PopupWidth = 40;
            this.fld_lkeFK_METemplateID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeFK_METemplateID.Properties.ValueMember = "METemplateID";
            this.fld_lkeFK_METemplateID.Screen = null;
            this.fld_lkeFK_METemplateID.Size = new System.Drawing.Size(599, 20);
            this.fld_lkeFK_METemplateID.TabIndex = 0;
            this.fld_lkeFK_METemplateID.Tag = "DC";
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
            this.fld_lblLabel9.Location = new System.Drawing.Point(12, 40);
            this.fld_lblLabel9.Name = "fld_lblLabel9";
            this.fld_lblLabel9.Screen = null;
            this.fld_lblLabel9.Size = new System.Drawing.Size(20, 13);
            this.fld_lblLabel9.TabIndex = 8;
            this.fld_lblLabel9.Tag = "";
            this.fld_lblLabel9.Text = "Mẫu";
            // 
            // fld_lblLabel10
            // 
            this.fld_lblLabel10.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel10.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel10.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel10.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel10.BOSComment = "";
            this.fld_lblLabel10.BOSDataMember = "";
            this.fld_lblLabel10.BOSDataSource = "";
            this.fld_lblLabel10.BOSDescription = null;
            this.fld_lblLabel10.BOSError = null;
            this.fld_lblLabel10.BOSFieldGroup = "";
            this.fld_lblLabel10.BOSFieldRelation = "";
            this.fld_lblLabel10.BOSPrivilege = "";
            this.fld_lblLabel10.BOSPropertyName = "";
            this.fld_lblLabel10.Location = new System.Drawing.Point(12, 462);
            this.fld_lblLabel10.Name = "fld_lblLabel10";
            this.fld_lblLabel10.Screen = null;
            this.fld_lblLabel10.Size = new System.Drawing.Size(35, 13);
            this.fld_lblLabel10.TabIndex = 9;
            this.fld_lblLabel10.Tag = "";
            this.fld_lblLabel10.Text = "Ghi chú";
            // 
            // fld_btn_Cancel
            // 
            this.fld_btn_Cancel.Location = new System.Drawing.Point(595, 523);
            this.fld_btn_Cancel.Name = "fld_btn_Cancel";
            this.fld_btn_Cancel.Size = new System.Drawing.Size(75, 31);
            this.fld_btn_Cancel.TabIndex = 5;
            this.fld_btn_Cancel.TabStop = false;
            this.fld_btn_Cancel.Text = "Hủy";
            this.fld_btn_Cancel.Click += new System.EventHandler(this.fld_btn_Cancel_Click);
            // 
            // fld_btn_Ok
            // 
            this.fld_btn_Ok.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("fld_btn_Ok.ImageOptions.Image")));
            this.fld_btn_Ok.Location = new System.Drawing.Point(494, 523);
            this.fld_btn_Ok.Name = "fld_btn_Ok";
            this.fld_btn_Ok.Size = new System.Drawing.Size(95, 31);
            this.fld_btn_Ok.TabIndex = 4;
            this.fld_btn_Ok.Text = "OK (Alt+O)";
            this.fld_btn_Ok.Click += new System.EventHandler(this.fld_btn_Ok_Click);
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
            this.bosLabel1.Location = new System.Drawing.Point(12, 422);
            this.bosLabel1.Name = "bosLabel1";
            this.bosLabel1.Screen = null;
            this.bosLabel1.Size = new System.Drawing.Size(41, 13);
            this.bosLabel1.TabIndex = 12;
            this.bosLabel1.Tag = "";
            this.bosLabel1.Text = "File mềm";
            // 
            // fld_txtFileName
            // 
            this.fld_txtFileName.BOSComment = "";
            this.fld_txtFileName.BOSDataMember = "";
            this.fld_txtFileName.BOSDataSource = "";
            this.fld_txtFileName.BOSDescription = null;
            this.fld_txtFileName.BOSError = null;
            this.fld_txtFileName.BOSFieldGroup = "";
            this.fld_txtFileName.BOSFieldRelation = "";
            this.fld_txtFileName.BOSPrivilege = "";
            this.fld_txtFileName.BOSPropertyName = "Text";
            this.fld_txtFileName.EditValue = "";
            this.fld_txtFileName.Enabled = false;
            this.fld_txtFileName.Location = new System.Drawing.Point(71, 420);
            this.fld_txtFileName.Name = "fld_txtFileName";
            this.fld_txtFileName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtFileName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtFileName.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtFileName.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtFileName.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtFileName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtFileName.Screen = null;
            this.fld_txtFileName.Size = new System.Drawing.Size(518, 20);
            this.fld_txtFileName.TabIndex = 1;
            this.fld_txtFileName.Tag = "DC";
            // 
            // fld_btnSelectFile
            // 
            this.fld_btnSelectFile.Location = new System.Drawing.Point(595, 418);
            this.fld_btnSelectFile.Name = "fld_btnSelectFile";
            this.fld_btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.fld_btnSelectFile.TabIndex = 2;
            this.fld_btnSelectFile.Text = "Chọn file";
            this.fld_btnSelectFile.Click += new System.EventHandler(this.fld_btnSelectFile_Click);
            // 
            // fld_chkAppendToCurrentDocument
            // 
            this.fld_chkAppendToCurrentDocument.BOSComment = null;
            this.fld_chkAppendToCurrentDocument.BOSDataMember = "";
            this.fld_chkAppendToCurrentDocument.BOSDataSource = "";
            this.fld_chkAppendToCurrentDocument.BOSDescription = null;
            this.fld_chkAppendToCurrentDocument.BOSError = null;
            this.fld_chkAppendToCurrentDocument.BOSFieldGroup = null;
            this.fld_chkAppendToCurrentDocument.BOSFieldRelation = null;
            this.fld_chkAppendToCurrentDocument.BOSPrivilege = null;
            this.fld_chkAppendToCurrentDocument.BOSPropertyName = "Checked";
            this.fld_chkAppendToCurrentDocument.Location = new System.Drawing.Point(70, 12);
            this.fld_chkAppendToCurrentDocument.MenuManager = this.screenToolbar;
            this.fld_chkAppendToCurrentDocument.Name = "fld_chkAppendToCurrentDocument";
            this.fld_chkAppendToCurrentDocument.Properties.Caption = "Chèn nội dung file mềm vào vị trí con trỏ  trên file hiện tại ";
            this.fld_chkAppendToCurrentDocument.Screen = null;
            this.fld_chkAppendToCurrentDocument.Size = new System.Drawing.Size(464, 19);
            this.fld_chkAppendToCurrentDocument.TabIndex = 0;
            this.fld_chkAppendToCurrentDocument.TabStop = false;
            this.fld_chkAppendToCurrentDocument.Tag = "DC";
            this.fld_chkAppendToCurrentDocument.CheckedChanged += new System.EventHandler(this.fld_chkAppendToCurrentDocument_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fld_grdSelectionTemplate
            // 
            this.fld_grdSelectionTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_grdSelectionTemplate.BOSComment = null;
            this.fld_grdSelectionTemplate.BOSDataMember = null;
            this.fld_grdSelectionTemplate.BOSDataSource = "METemplates";
            this.fld_grdSelectionTemplate.BOSDescription = null;
            this.fld_grdSelectionTemplate.BOSError = null;
            this.fld_grdSelectionTemplate.BOSFieldGroup = null;
            this.fld_grdSelectionTemplate.BOSFieldRelation = null;
            this.fld_grdSelectionTemplate.BOSGridType = null;
            this.fld_grdSelectionTemplate.BOSPrivilege = null;
            this.fld_grdSelectionTemplate.BOSPropertyName = null;
            this.fld_grdSelectionTemplate.Location = new System.Drawing.Point(71, 59);
            this.fld_grdSelectionTemplate.MainView = this.gridView1;
            this.fld_grdSelectionTemplate.MenuManager = this.screenToolbar;
            this.fld_grdSelectionTemplate.Name = "fld_grdSelectionTemplate";
            this.fld_grdSelectionTemplate.PrintReport = false;
            this.fld_grdSelectionTemplate.Screen = null;
            this.fld_grdSelectionTemplate.Size = new System.Drawing.Size(599, 355);
            this.fld_grdSelectionTemplate.TabIndex = 13;
            this.fld_grdSelectionTemplate.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_grdSelectionTemplate;
            this.gridView1.Name = "gridView1";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(259, 532);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(229, 13);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Double click trên lưới để chọn và tạo nhanh mẫu";
            // 
            // DSMEEMR100
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.ControlBox = true;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.fld_grdSelectionTemplate);
            this.Controls.Add(this.fld_chkAppendToCurrentDocument);
            this.Controls.Add(this.fld_btnSelectFile);
            this.Controls.Add(this.fld_txtFileName);
            this.Controls.Add(this.bosLabel1);
            this.Controls.Add(this.fld_btn_Ok);
            this.Controls.Add(this.fld_btn_Cancel);
            this.Controls.Add(this.fld_medMEEmrDocumentDesc);
            this.Controls.Add(this.fld_lkeFK_METemplateID);
            this.Controls.Add(this.fld_lblLabel9);
            this.Controls.Add(this.fld_lblLabel10);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DSMEEMR100";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin mẫu";
            this.Load += new System.EventHandler(this.DSMEEMR100_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DSMEEMR100_KeyPress);
            this.Controls.SetChildIndex(this.fld_lblLabel10, 0);
            this.Controls.SetChildIndex(this.fld_lblLabel9, 0);
            this.Controls.SetChildIndex(this.fld_lkeFK_METemplateID, 0);
            this.Controls.SetChildIndex(this.fld_medMEEmrDocumentDesc, 0);
            this.Controls.SetChildIndex(this.fld_btn_Cancel, 0);
            this.Controls.SetChildIndex(this.fld_btn_Ok, 0);
            this.Controls.SetChildIndex(this.bosLabel1, 0);
            this.Controls.SetChildIndex(this.fld_txtFileName, 0);
            this.Controls.SetChildIndex(this.fld_btnSelectFile, 0);
            this.Controls.SetChildIndex(this.fld_chkAppendToCurrentDocument, 0);
            this.Controls.SetChildIndex(this.fld_grdSelectionTemplate, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_medMEEmrDocumentDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeFK_METemplateID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_chkAppendToCurrentDocument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_grdSelectionTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private IContainer components;
        private DevExpress.XtraEditors.SimpleButton fld_btn_Cancel;
        private DevExpress.XtraEditors.SimpleButton fld_btn_Ok;
        private BOSComponent.BOSLabel bosLabel1;
        private BOSComponent.BOSTextBox fld_txtFileName;
        private DevExpress.XtraEditors.SimpleButton fld_btnSelectFile;
        private BOSComponent.BOSCheckEdit fld_chkAppendToCurrentDocument;
        private OpenFileDialog openFileDialog1;
        private SelectionTemplateGridControl fld_grdSelectionTemplate;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
