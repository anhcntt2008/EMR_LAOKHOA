namespace BOSERP.Modules.UserManagement
{
    partial class guiAddModules
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiAddModules));
            this.fld_dgcModuleSection = new DevExpress.XtraGrid.GridControl();
            this.fld_dgvModuleSection = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcModuleSection = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fld_dgcModuleNonSection = new DevExpress.XtraGrid.GridControl();
            this.fld_dgvModuleNonSection = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcModuleNonSection = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fld_btnForward = new DevExpress.XtraEditors.SimpleButton();
            this.fld_btnBackward = new DevExpress.XtraEditors.SimpleButton();
            this.fld_btnCloseModule = new DevExpress.XtraEditors.SimpleButton();
            this.fld_btnSaveMUGSection = new DevExpress.XtraEditors.SimpleButton();
            this.BOSLine1 = new BOSComponent.BOSLine(this.components);
            this.BOSLine2 = new BOSComponent.BOSLine(this.components);
            this.BOSLine3 = new BOSComponent.BOSLine(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcModuleSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvModuleSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcModuleNonSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvModuleNonSection)).BeginInit();
            this.BOSLine1.SuspendLayout();
            this.BOSLine2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fld_dgcModuleSection
            // 
            this.fld_dgcModuleSection.AllowDrop = true;
            this.fld_dgcModuleSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_dgcModuleSection.Location = new System.Drawing.Point(3, 17);
            this.fld_dgcModuleSection.MainView = this.fld_dgvModuleSection;
            this.fld_dgcModuleSection.Name = "fld_dgcModuleSection";
            this.fld_dgcModuleSection.Size = new System.Drawing.Size(370, 473);
            this.fld_dgcModuleSection.TabIndex = 4;
            this.fld_dgcModuleSection.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvModuleSection});
            this.fld_dgcModuleSection.DragDrop += new System.Windows.Forms.DragEventHandler(this.fld_dgcModuleSection_DragDrop);
            this.fld_dgcModuleSection.DragOver += new System.Windows.Forms.DragEventHandler(this.fld_dgcModuleSection_DragOver);
            // 
            // fld_dgvModuleSection
            // 
            this.fld_dgvModuleSection.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcModuleSection});
            this.fld_dgvModuleSection.GridControl = this.fld_dgcModuleSection;
            this.fld_dgvModuleSection.Name = "fld_dgvModuleSection";
            this.fld_dgvModuleSection.OptionsBehavior.Editable = false;
            this.fld_dgvModuleSection.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.fld_dgvModuleSection.OptionsView.ShowGroupPanel = false;
            this.fld_dgvModuleSection.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fld_dgvModuleSection_MouseDown);
            this.fld_dgvModuleSection.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fld_dgvModuleSection_MouseMove);
            // 
            // gcModuleSection
            // 
            this.gcModuleSection.Caption = "Tên module";
            this.gcModuleSection.FieldName = "STModuleDescription";
            this.gcModuleSection.Name = "gcModuleSection";
            this.gcModuleSection.Visible = true;
            this.gcModuleSection.VisibleIndex = 0;
            // 
            // fld_dgcModuleNonSection
            // 
            this.fld_dgcModuleNonSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_dgcModuleNonSection.Location = new System.Drawing.Point(3, 17);
            this.fld_dgcModuleNonSection.MainView = this.fld_dgvModuleNonSection;
            this.fld_dgcModuleNonSection.Name = "fld_dgcModuleNonSection";
            this.fld_dgcModuleNonSection.Size = new System.Drawing.Size(341, 473);
            this.fld_dgcModuleNonSection.TabIndex = 1;
            this.fld_dgcModuleNonSection.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvModuleNonSection});
            // 
            // fld_dgvModuleNonSection
            // 
            this.fld_dgvModuleNonSection.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcModuleNonSection});
            this.fld_dgvModuleNonSection.GridControl = this.fld_dgcModuleNonSection;
            this.fld_dgvModuleNonSection.Name = "fld_dgvModuleNonSection";
            this.fld_dgvModuleNonSection.OptionsBehavior.Editable = false;
            this.fld_dgvModuleNonSection.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.fld_dgvModuleNonSection.OptionsView.ShowAutoFilterRow = true;
            this.fld_dgvModuleNonSection.OptionsView.ShowGroupPanel = false;
            // 
            // gcModuleNonSection
            // 
            this.gcModuleNonSection.Caption = "Tên module";
            this.gcModuleNonSection.FieldName = "STModuleDescription";
            this.gcModuleNonSection.Name = "gcModuleNonSection";
            this.gcModuleNonSection.Visible = true;
            this.gcModuleNonSection.VisibleIndex = 0;
            // 
            // fld_btnForward
            // 
            this.fld_btnForward.Location = new System.Drawing.Point(355, 147);
            this.fld_btnForward.Name = "fld_btnForward";
            this.fld_btnForward.Size = new System.Drawing.Size(54, 36);
            this.fld_btnForward.TabIndex = 2;
            this.fld_btnForward.Text = ">>";
            this.fld_btnForward.Click += new System.EventHandler(this.fld_btnForward_Click);
            // 
            // fld_btnBackward
            // 
            this.fld_btnBackward.Location = new System.Drawing.Point(355, 189);
            this.fld_btnBackward.Name = "fld_btnBackward";
            this.fld_btnBackward.Size = new System.Drawing.Size(54, 36);
            this.fld_btnBackward.TabIndex = 3;
            this.fld_btnBackward.Text = "<<";
            this.fld_btnBackward.Click += new System.EventHandler(this.fld_btnBackward_Click);
            // 
            // fld_btnCloseModule
            // 
            this.fld_btnCloseModule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fld_btnCloseModule.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fld_btnCloseModule.Location = new System.Drawing.Point(723, 519);
            this.fld_btnCloseModule.Name = "fld_btnCloseModule";
            this.fld_btnCloseModule.Size = new System.Drawing.Size(75, 25);
            this.fld_btnCloseModule.TabIndex = 2;
            this.fld_btnCloseModule.Text = "Hủy bỏ";
            this.fld_btnCloseModule.Click += new System.EventHandler(this.fld_btnCloseModule_Click);
            // 
            // fld_btnSaveMUGSection
            // 
            this.fld_btnSaveMUGSection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fld_btnSaveMUGSection.Location = new System.Drawing.Point(642, 519);
            this.fld_btnSaveMUGSection.Name = "fld_btnSaveMUGSection";
            this.fld_btnSaveMUGSection.Size = new System.Drawing.Size(75, 25);
            this.fld_btnSaveMUGSection.TabIndex = 1;
            this.fld_btnSaveMUGSection.Text = "Đồng ý";
            this.fld_btnSaveMUGSection.Click += new System.EventHandler(this.fld_btnSaveMUGSection_Click);
            // 
            // BOSLine1
            // 
            this.BOSLine1.BOSComment = null;
            this.BOSLine1.BOSDataMember = null;
            this.BOSLine1.BOSDataSource = null;
            this.BOSLine1.BOSDescription = null;
            this.BOSLine1.BOSError = null;
            this.BOSLine1.BOSFieldGroup = null;
            this.BOSLine1.BOSFieldRelation = null;
            this.BOSLine1.BOSPrivilege = null;
            this.BOSLine1.BOSPropertyName = null;
            this.BOSLine1.Controls.Add(this.fld_dgcModuleNonSection);
            this.BOSLine1.Location = new System.Drawing.Point(2, 4);
            this.BOSLine1.Name = "BOSLine1";
            this.BOSLine1.Screen = null;
            this.BOSLine1.Size = new System.Drawing.Size(347, 493);
            this.BOSLine1.TabIndex = 6;
            this.BOSLine1.TabStop = false;
            this.BOSLine1.Text = "Danh sách module";
            // 
            // BOSLine2
            // 
            this.BOSLine2.BOSComment = null;
            this.BOSLine2.BOSDataMember = null;
            this.BOSLine2.BOSDataSource = null;
            this.BOSLine2.BOSDescription = null;
            this.BOSLine2.BOSError = null;
            this.BOSLine2.BOSFieldGroup = null;
            this.BOSLine2.BOSFieldRelation = null;
            this.BOSLine2.BOSPrivilege = null;
            this.BOSLine2.BOSPropertyName = null;
            this.BOSLine2.Controls.Add(this.fld_dgcModuleSection);
            this.BOSLine2.Location = new System.Drawing.Point(415, 4);
            this.BOSLine2.Name = "BOSLine2";
            this.BOSLine2.Screen = null;
            this.BOSLine2.Size = new System.Drawing.Size(376, 493);
            this.BOSLine2.TabIndex = 7;
            this.BOSLine2.TabStop = false;
            this.BOSLine2.Text = "Danh sách module được chọn";
            // 
            // BOSLine3
            // 
            this.BOSLine3.BOSComment = null;
            this.BOSLine3.BOSDataMember = null;
            this.BOSLine3.BOSDataSource = null;
            this.BOSLine3.BOSDescription = null;
            this.BOSLine3.BOSError = null;
            this.BOSLine3.BOSFieldGroup = null;
            this.BOSLine3.BOSFieldRelation = null;
            this.BOSLine3.BOSPrivilege = null;
            this.BOSLine3.BOSPropertyName = null;
            this.BOSLine3.Location = new System.Drawing.Point(5, 503);
            this.BOSLine3.Name = "BOSLine3";
            this.BOSLine3.Screen = null;
            this.BOSLine3.Size = new System.Drawing.Size(798, 10);
            this.BOSLine3.TabIndex = 8;
            this.BOSLine3.TabStop = false;
            // 
            // guiAddModules
            // 
            this.AcceptButton = this.fld_btnSaveMUGSection;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.fld_btnCloseModule;
            this.ClientSize = new System.Drawing.Size(803, 553);
            this.ControlBox = true;
            this.Controls.Add(this.BOSLine3);
            this.Controls.Add(this.BOSLine2);
            this.Controls.Add(this.BOSLine1);
            this.Controls.Add(this.fld_btnSaveMUGSection);
            this.Controls.Add(this.fld_btnCloseModule);
            this.Controls.Add(this.fld_btnBackward);
            this.Controls.Add(this.fld_btnForward);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "guiAddModules";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm / Xóa Module";
            this.Controls.SetChildIndex(this.fld_btnForward, 0);
            this.Controls.SetChildIndex(this.fld_btnBackward, 0);
            this.Controls.SetChildIndex(this.fld_btnCloseModule, 0);
            this.Controls.SetChildIndex(this.fld_btnSaveMUGSection, 0);
            this.Controls.SetChildIndex(this.BOSLine1, 0);
            this.Controls.SetChildIndex(this.BOSLine2, 0);
            this.Controls.SetChildIndex(this.BOSLine3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcModuleSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvModuleSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcModuleNonSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvModuleNonSection)).EndInit();
            this.BOSLine1.ResumeLayout(false);
            this.BOSLine2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl fld_dgcModuleSection;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvModuleSection;
        private DevExpress.XtraGrid.GridControl fld_dgcModuleNonSection;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvModuleNonSection;
        private DevExpress.XtraEditors.SimpleButton fld_btnForward;
        private DevExpress.XtraEditors.SimpleButton fld_btnBackward;
        private DevExpress.XtraEditors.SimpleButton fld_btnCloseModule;
        private DevExpress.XtraGrid.Columns.GridColumn gcModuleNonSection;
        private DevExpress.XtraGrid.Columns.GridColumn gcModuleSection;
        private DevExpress.XtraEditors.SimpleButton fld_btnSaveMUGSection;
        private BOSComponent.BOSLine BOSLine1;
        private BOSComponent.BOSLine BOSLine2;
        private BOSComponent.BOSLine BOSLine3;
    }
}