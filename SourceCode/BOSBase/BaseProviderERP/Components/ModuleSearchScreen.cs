using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BOSLib;
using BOSComponent;

namespace BOSERP
{
    public partial class ModuleSearchScreen : DevExpress.XtraEditors.XtraForm
    {
        public IBaseModuleERP module;
        private BOSTextBox fld_txtCriteriaName;
        private BOSLabel BOSLabel1;
        private BOSMemoEdit fld_mmDesciptions;
        private BOSLabel BOSLabel2;
        private BOSButton fld_btnOK;
        private BOSButton fld_btnCancel;
        public ModuleSearchScreen()
        {
            InitializeComponent();
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModuleSearchScreen));
            this.fld_splCriteria = new DevExpress.XtraEditors.SplitContainerControl();
            this.BOSLabel2 = new BOSComponent.BOSLabel(this.components);
            this.BOSLabel1 = new BOSComponent.BOSLabel(this.components);
            this.fld_mmDesciptions = new BOSComponent.BOSMemoEdit(this.components);
            this.fld_txtCriteriaName = new BOSComponent.BOSTextBox(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.fld_btnReset = new BOSComponent.BOSButton(this.components);
            this.fld_btnOK = new BOSComponent.BOSButton(this.components);
            this.fld_btnCancel = new BOSComponent.BOSButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fld_splCriteria)).BeginInit();
            this.fld_splCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_mmDesciptions.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtCriteriaName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fld_splCriteria
            // 
            this.fld_splCriteria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_splCriteria.Horizontal = false;
            this.fld_splCriteria.Location = new System.Drawing.Point(0, 0);
            this.fld_splCriteria.Name = "fld_splCriteria";
            this.fld_splCriteria.Panel1.Controls.Add(this.BOSLabel2);
            this.fld_splCriteria.Panel1.Controls.Add(this.BOSLabel1);
            this.fld_splCriteria.Panel1.Controls.Add(this.fld_mmDesciptions);
            this.fld_splCriteria.Panel1.Controls.Add(this.fld_txtCriteriaName);
            this.fld_splCriteria.Panel1.Text = "Panel1";
            this.fld_splCriteria.Panel2.Text = "Panel2";
            this.fld_splCriteria.Size = new System.Drawing.Size(700, 494);
            this.fld_splCriteria.TabIndex = 1;
            // 
            // BOSLabel2
            // 
            this.BOSLabel2.BOSComment = null;
            this.BOSLabel2.BOSDataMember = null;
            this.BOSLabel2.BOSDataSource = null;
            this.BOSLabel2.BOSDescription = null;
            this.BOSLabel2.BOSError = null;
            this.BOSLabel2.BOSFieldGroup = null;
            this.BOSLabel2.BOSFieldRelation = null;
            this.BOSLabel2.BOSPrivilege = null;
            this.BOSLabel2.BOSPropertyName = null;
            this.BOSLabel2.Location = new System.Drawing.Point(40, 53);
            this.BOSLabel2.Name = "BOSLabel2";
            this.BOSLabel2.Screen = null;
            this.BOSLabel2.Size = new System.Drawing.Size(35, 13);
            this.BOSLabel2.TabIndex = 3;
            this.BOSLabel2.Text = "Ghi chú";
            // 
            // BOSLabel1
            // 
            this.BOSLabel1.BOSComment = null;
            this.BOSLabel1.BOSDataMember = null;
            this.BOSLabel1.BOSDataSource = null;
            this.BOSLabel1.BOSDescription = null;
            this.BOSLabel1.BOSError = null;
            this.BOSLabel1.BOSFieldGroup = null;
            this.BOSLabel1.BOSFieldRelation = null;
            this.BOSLabel1.BOSPrivilege = null;
            this.BOSLabel1.BOSPropertyName = null;
            this.BOSLabel1.Location = new System.Drawing.Point(40, 19);
            this.BOSLabel1.Name = "BOSLabel1";
            this.BOSLabel1.Screen = null;
            this.BOSLabel1.Size = new System.Drawing.Size(59, 13);
            this.BOSLabel1.TabIndex = 2;
            this.BOSLabel1.Text = "Tên tìm kiếm";
            // 
            // fld_mmDesciptions
            // 
            this.fld_mmDesciptions.BOSComment = null;
            this.fld_mmDesciptions.BOSDataMember = null;
            this.fld_mmDesciptions.BOSDataSource = null;
            this.fld_mmDesciptions.BOSDescription = null;
            this.fld_mmDesciptions.BOSError = null;
            this.fld_mmDesciptions.BOSFieldGroup = null;
            this.fld_mmDesciptions.BOSFieldRelation = null;
            this.fld_mmDesciptions.BOSPrivilege = null;
            this.fld_mmDesciptions.BOSPropertyName = null;
            this.fld_mmDesciptions.Location = new System.Drawing.Point(125, 42);
            this.fld_mmDesciptions.Name = "fld_mmDesciptions";
            this.fld_mmDesciptions.Screen = null;
            this.fld_mmDesciptions.Size = new System.Drawing.Size(537, 49);
            this.fld_mmDesciptions.TabIndex = 1;
            // 
            // fld_txtCriteriaName
            // 
            this.fld_txtCriteriaName.BOSComment = null;
            this.fld_txtCriteriaName.BOSDataMember = null;
            this.fld_txtCriteriaName.BOSDataSource = null;
            this.fld_txtCriteriaName.BOSDescription = null;
            this.fld_txtCriteriaName.BOSError = null;
            this.fld_txtCriteriaName.BOSFieldGroup = null;
            this.fld_txtCriteriaName.BOSFieldRelation = null;
            this.fld_txtCriteriaName.BOSPrivilege = null;
            this.fld_txtCriteriaName.BOSPropertyName = null;
            this.fld_txtCriteriaName.Location = new System.Drawing.Point(125, 16);
            this.fld_txtCriteriaName.Name = "fld_txtCriteriaName";
            this.fld_txtCriteriaName.Screen = null;
            this.fld_txtCriteriaName.Size = new System.Drawing.Size(323, 20);
            this.fld_txtCriteriaName.TabIndex = 0;
            this.fld_txtCriteriaName.Validated += new System.EventHandler(this.fld_txtCriteriaName_Validated);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.fld_btnReset);
            this.panelControl1.Controls.Add(this.fld_btnOK);
            this.panelControl1.Controls.Add(this.fld_btnCancel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 494);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(700, 52);
            this.panelControl1.TabIndex = 0;
            // 
            // fld_btnReset
            // 
            this.fld_btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fld_btnReset.BOSComment = null;
            this.fld_btnReset.BOSDataMember = null;
            this.fld_btnReset.BOSDataSource = null;
            this.fld_btnReset.BOSDescription = null;
            this.fld_btnReset.BOSError = null;
            this.fld_btnReset.BOSFieldGroup = null;
            this.fld_btnReset.BOSFieldRelation = null;
            this.fld_btnReset.BOSPrivilege = null;
            this.fld_btnReset.BOSPropertyName = null;
            this.fld_btnReset.Location = new System.Drawing.Point(5, 10);
            this.fld_btnReset.Name = "fld_btnReset";
            this.fld_btnReset.Screen = null;
            this.fld_btnReset.Size = new System.Drawing.Size(117, 33);
            this.fld_btnReset.TabIndex = 1;
            this.fld_btnReset.Text = "Thiết lập lại";
            this.fld_btnReset.Click += new System.EventHandler(this.fld_btnReset_Click);
            // 
            // fld_btnOK
            // 
            this.fld_btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_btnOK.BOSComment = null;
            this.fld_btnOK.BOSDataMember = null;
            this.fld_btnOK.BOSDataSource = null;
            this.fld_btnOK.BOSDescription = null;
            this.fld_btnOK.BOSError = null;
            this.fld_btnOK.BOSFieldGroup = null;
            this.fld_btnOK.BOSFieldRelation = null;
            this.fld_btnOK.BOSPrivilege = null;
            this.fld_btnOK.BOSPropertyName = null;
            this.fld_btnOK.Location = new System.Drawing.Point(510, 10);
            this.fld_btnOK.Name = "fld_btnOK";
            this.fld_btnOK.Screen = null;
            this.fld_btnOK.Size = new System.Drawing.Size(85, 33);
            this.fld_btnOK.TabIndex = 1;
            this.fld_btnOK.Text = "Tìm kiếm";
            this.fld_btnOK.Click += new System.EventHandler(this.fld_btnOK_Click);
            // 
            // fld_btnCancel
            // 
            this.fld_btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.fld_btnCancel.Location = new System.Drawing.Point(601, 10);
            this.fld_btnCancel.Name = "fld_btnCancel";
            this.fld_btnCancel.Screen = null;
            this.fld_btnCancel.Size = new System.Drawing.Size(87, 33);
            this.fld_btnCancel.TabIndex = 0;
            this.fld_btnCancel.Text = "Hủy bỏ";
            this.fld_btnCancel.Click += new System.EventHandler(this.fld_btnCancel_Click);
            // 
            // ModuleSearchScreen
            // 
            this.AcceptButton = this.fld_btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.fld_btnCancel;
            this.ClientSize = new System.Drawing.Size(700, 546);
            this.Controls.Add(this.fld_splCriteria);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModuleSearchScreen";
            this.ShowInTaskbar = false;
            this.Text = "Tìm kiếm nâng cao";
            this.Load += new System.EventHandler(this.ModuleSearchScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fld_splCriteria)).EndInit();
            this.fld_splCriteria.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_mmDesciptions.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtCriteriaName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        /// <summary>
        /// Check whether a criteria exists
        /// </summary>
        public bool IsExistCriteriaName()
        {
            bool isExist = false;
            if (new ADCriteriasController().IsExistCriteriaName(CriteriaName.Text, ((BaseModuleERP)this.module).ModuleID, BOSApp.CurrentUsersInfo.ADUserID))
            {
                isExist = true;
                MessageBox.Show("Criteria name already exists. Please enter another one.", "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return isExist;
        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl fld_splCriteria;
        #region Properties
        public BOSTextBox CriteriaName
        {
            get { return fld_txtCriteriaName; }
            set { fld_txtCriteriaName = value; }
        }
        public DevExpress.XtraEditors.PanelControl CriteriaSection
        {
            get { return fld_splCriteria.Panel2; }
            // set { fld_splContainer.Panel2 = value; }
        }
        public DevExpress.XtraEditors.PanelControl GeneralSection
        {
            get { return fld_splCriteria.Panel1; }
        }
        public BOSMemoEdit CriteriaDescription
        {
            get { return fld_mmDesciptions; }
            set { fld_mmDesciptions = value; }
        }

        #endregion

        private void fld_btnOK_Click(object sender, EventArgs e)
        {
            if (IsExistCriteriaName())
                return;
            ((BaseModuleERP)module).Search();
            this.Close();
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModuleSearchScreen_Load(object sender, EventArgs e)
        {
            fld_mmDesciptions.Text = String.Empty;
            fld_txtCriteriaName.Text = String.Empty;
        }

        private void fld_txtCriteriaName_Validated(object sender, EventArgs e)
        {
            IsExistCriteriaName();
        }

        private void fld_btnReset_Click(object sender, EventArgs e)
        {
            ((BaseModuleERP)module).ResetSearchObject();
        }
        #region Utilities
        
        #endregion
    }
}