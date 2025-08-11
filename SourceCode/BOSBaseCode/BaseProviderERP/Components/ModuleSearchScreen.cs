using System;
using System.Windows.Forms;
using BOSComponent;
using BOSLib;
using DevExpress.XtraEditors;
using Localization;

namespace BOSERP
{
    public enum SearchType
    {
        SearchFrom,
        SearchTo
    }

    public partial class ModuleSearchScreen : XtraForm
    {
        private BOSLabel BOSLabel1;
        private BOSLabel BOSLabel2;
        private BOSButton fld_btnCancel;
        private BOSButton fld_btnOK;

        private SplitContainerControl fld_splCriteria;

        public ModuleSearchScreen()
        {
            InitializeComponent();
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModuleSearchScreen));
            this.fld_splCriteria = new DevExpress.XtraEditors.SplitContainerControl();
            this.BOSLabel2 = new BOSComponent.BOSLabel(this.components);
            this.BOSLabel1 = new BOSComponent.BOSLabel(this.components);
            this.CriteriaDescription = new BOSComponent.BOSMemoEdit(this.components);
            this.CriteriaName = new BOSComponent.BOSTextBox(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.fld_btnReset = new BOSComponent.BOSButton(this.components);
            this.fld_btnOK = new BOSComponent.BOSButton(this.components);
            this.fld_btnCancel = new BOSComponent.BOSButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fld_splCriteria)).BeginInit();
            this.fld_splCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CriteriaDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CriteriaName.Properties)).BeginInit();
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
            this.fld_splCriteria.Panel1.Controls.Add(this.CriteriaDescription);
            this.fld_splCriteria.Panel1.Controls.Add(this.CriteriaName);
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
            // CriteriaDescription
            // 
            this.CriteriaDescription.BOSComment = null;
            this.CriteriaDescription.BOSDataMember = null;
            this.CriteriaDescription.BOSDataSource = null;
            this.CriteriaDescription.BOSDescription = null;
            this.CriteriaDescription.BOSError = null;
            this.CriteriaDescription.BOSFieldGroup = null;
            this.CriteriaDescription.BOSFieldRelation = null;
            this.CriteriaDescription.BOSPrivilege = null;
            this.CriteriaDescription.BOSPropertyName = null;
            this.CriteriaDescription.Location = new System.Drawing.Point(125, 42);
            this.CriteriaDescription.Name = "CriteriaDescription";
            this.CriteriaDescription.Screen = null;
            this.CriteriaDescription.Size = new System.Drawing.Size(537, 49);
            this.CriteriaDescription.TabIndex = 1;
            // 
            // CriteriaName
            // 
            this.CriteriaName.BOSComment = null;
            this.CriteriaName.BOSDataMember = null;
            this.CriteriaName.BOSDataSource = null;
            this.CriteriaName.BOSDescription = null;
            this.CriteriaName.BOSError = null;
            this.CriteriaName.BOSFieldGroup = null;
            this.CriteriaName.BOSFieldRelation = null;
            this.CriteriaName.BOSPrivilege = null;
            this.CriteriaName.BOSPropertyName = null;
            this.CriteriaName.Location = new System.Drawing.Point(125, 16);
            this.CriteriaName.Name = "CriteriaName";
            this.CriteriaName.Screen = null;
            this.CriteriaName.Size = new System.Drawing.Size(323, 20);
            this.CriteriaName.TabIndex = 0;
            this.CriteriaName.Validated += new System.EventHandler(this.fld_txtCriteriaName_Validated);
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
            this.panelControl1.TabIndex = 2;
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
            this.fld_btnReset.TabIndex = 3;
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
            this.fld_btnCancel.TabIndex = 2;
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
            ((System.ComponentModel.ISupportInitialize)(this.CriteriaDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CriteriaName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private void fld_btnOK_Click(object sender, EventArgs e)
        {
            if (IsExistCriteriaName())
                return;

            ((BaseModuleERP) Module).Search();
            Close();
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ModuleSearchScreen_Load(object sender, EventArgs e)
        {
            CriteriaDescription.Text = string.Empty;
            CriteriaName.Text = string.Empty;
        }

        private void fld_txtCriteriaName_Validated(object sender, EventArgs e)
        {
            IsExistCriteriaName();
        }

        private void fld_btnReset_Click(object sender, EventArgs e)
        {
            ((BaseModuleERP) Module).ResetSearch();
        }

        /// <summary>
        ///     Check whether a criteria exists
        /// </summary>
        public bool IsExistCriteriaName()
        {
            var isExist = false;
            if (new ADCriteriasController().IsExistCriteriaName(CriteriaName.Text, ((BaseModuleERP) Module).ModuleID,
                BOSApp.CurrentUsersInfo.ADUserID))
            {
                isExist = true;
                MessageBox.Show("Criteria name already exists. Please enter another one.",
                    CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return isExist;
        }

        #region Properties

        /// <summary>
        ///     Gets or sets the module the search screen belongs to
        /// </summary>
        public IBaseModuleERP Module { get; set; }

        public BOSTextBox CriteriaName;// { get; set; }

        public PanelControl CriteriaSection
        {
            get { return fld_splCriteria.Panel2; }
            // set { fld_splContainer.Panel2 = value; }
        }

        public PanelControl GeneralSection
        {
            get { return fld_splCriteria.Panel1; }
        }

        public BOSMemoEdit CriteriaDescription;// { get; set; }

        #endregion
    }
}