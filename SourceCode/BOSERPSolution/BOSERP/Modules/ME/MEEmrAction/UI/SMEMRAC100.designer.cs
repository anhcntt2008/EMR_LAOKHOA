using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.MEEmrAction.UI
{
	/// <summary>
	/// Summary description for SMEMRAC100
	/// </summary>
	partial class SMEMRAC100
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMEMRAC100));
            this.bosTextBox1 = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtMEEmrActionNo = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtMEEmrActionUri = new BOSComponent.BOSTextBox(this.components);
            this.fld_lblLabel = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel1 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel2 = new BOSComponent.BOSLabel(this.components);
            this.fld_lkeMEEmrActionScope = new BOSComponent.BOSLookupEdit(this.components);
            this.fld_lblLabel6 = new BOSComponent.BOSLabel(this.components);
            this.fld_lkeMEEmrActionType = new BOSComponent.BOSLookupEdit(this.components);
            this.fld_lblLabel7 = new BOSComponent.BOSLabel(this.components);
            this.fld_dgcMEEmrAction = new BOSSearchResultsGridControl(this.components);
            this.fld_dgvMEEmrAction = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.bosTextBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrActionNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrActionUri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEEmrActionScope.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEEmrActionType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrAction)).BeginInit();
            this.SuspendLayout();
            // 
            // bosTextBox1
            // 
            this.bosTextBox1.BOSComment = "";
            this.bosTextBox1.BOSDataMember = "MEEmrActionName";
            this.bosTextBox1.BOSDataSource = "MEEmrActions";
            this.bosTextBox1.BOSDescription = null;
            this.bosTextBox1.BOSError = null;
            this.bosTextBox1.BOSFieldGroup = "";
            this.bosTextBox1.BOSFieldRelation = "";
            this.bosTextBox1.BOSPrivilege = "";
            this.bosTextBox1.BOSPropertyName = "Text";
            this.bosTextBox1.EditValue = "";
            this.bosTextBox1.Location = new System.Drawing.Point(143, 61);
            this.bosTextBox1.Name = "bosTextBox1";
            this.bosTextBox1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosTextBox1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosTextBox1.Properties.Appearance.Options.UseBackColor = true;
            this.bosTextBox1.Properties.Appearance.Options.UseForeColor = true;
            this.bosTextBox1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.bosTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bosTextBox1.Screen = null;
            this.bosTextBox1.Size = new System.Drawing.Size(274, 20);
            this.bosTextBox1.TabIndex = 52;
            this.bosTextBox1.Tag = "SC";
            // 
            // fld_txtMEEmrActionNo
            // 
            this.fld_txtMEEmrActionNo.BOSComment = "";
            this.fld_txtMEEmrActionNo.BOSDataMember = "MEEmrActionNo";
            this.fld_txtMEEmrActionNo.BOSDataSource = "MEEmrActions";
            this.fld_txtMEEmrActionNo.BOSDescription = null;
            this.fld_txtMEEmrActionNo.BOSError = null;
            this.fld_txtMEEmrActionNo.BOSFieldGroup = "";
            this.fld_txtMEEmrActionNo.BOSFieldRelation = "";
            this.fld_txtMEEmrActionNo.BOSPrivilege = "";
            this.fld_txtMEEmrActionNo.BOSPropertyName = "Text";
            this.fld_txtMEEmrActionNo.EditValue = "";
            this.fld_txtMEEmrActionNo.Location = new System.Drawing.Point(143, 27);
            this.fld_txtMEEmrActionNo.Name = "fld_txtMEEmrActionNo";
            this.fld_txtMEEmrActionNo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEEmrActionNo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEEmrActionNo.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEEmrActionNo.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEEmrActionNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEEmrActionNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEEmrActionNo.Screen = null;
            this.fld_txtMEEmrActionNo.Size = new System.Drawing.Size(274, 20);
            this.fld_txtMEEmrActionNo.TabIndex = 43;
            this.fld_txtMEEmrActionNo.Tag = "SC";
            // 
            // fld_txtMEEmrActionUri
            // 
            this.fld_txtMEEmrActionUri.BOSComment = "";
            this.fld_txtMEEmrActionUri.BOSDataMember = "MEEmrActionUri";
            this.fld_txtMEEmrActionUri.BOSDataSource = "MEEmrActions";
            this.fld_txtMEEmrActionUri.BOSDescription = null;
            this.fld_txtMEEmrActionUri.BOSError = null;
            this.fld_txtMEEmrActionUri.BOSFieldGroup = "";
            this.fld_txtMEEmrActionUri.BOSFieldRelation = "";
            this.fld_txtMEEmrActionUri.BOSPrivilege = "";
            this.fld_txtMEEmrActionUri.BOSPropertyName = "Text";
            this.fld_txtMEEmrActionUri.EditValue = "";
            this.fld_txtMEEmrActionUri.Location = new System.Drawing.Point(143, 92);
            this.fld_txtMEEmrActionUri.Name = "fld_txtMEEmrActionUri";
            this.fld_txtMEEmrActionUri.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEEmrActionUri.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEEmrActionUri.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEEmrActionUri.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEEmrActionUri.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEEmrActionUri.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEEmrActionUri.Screen = null;
            this.fld_txtMEEmrActionUri.Size = new System.Drawing.Size(274, 20);
            this.fld_txtMEEmrActionUri.TabIndex = 44;
            this.fld_txtMEEmrActionUri.Tag = "SC";
            // 
            // fld_lblLabel
            // 
            this.fld_lblLabel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel.BOSComment = "";
            this.fld_lblLabel.BOSDataMember = "";
            this.fld_lblLabel.BOSDataSource = "";
            this.fld_lblLabel.BOSDescription = null;
            this.fld_lblLabel.BOSError = null;
            this.fld_lblLabel.BOSFieldGroup = "";
            this.fld_lblLabel.BOSFieldRelation = "";
            this.fld_lblLabel.BOSPrivilege = "";
            this.fld_lblLabel.BOSPropertyName = "";
            this.fld_lblLabel.Location = new System.Drawing.Point(41, 34);
            this.fld_lblLabel.Name = "fld_lblLabel";
            this.fld_lblLabel.Screen = null;
            this.fld_lblLabel.Size = new System.Drawing.Size(67, 13);
            this.fld_lblLabel.TabIndex = 45;
            this.fld_lblLabel.Tag = "SI";
            this.fld_lblLabel.Text = "Mã chức năng";
            // 
            // fld_lblLabel1
            // 
            this.fld_lblLabel1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel1.BOSComment = "";
            this.fld_lblLabel1.BOSDataMember = "";
            this.fld_lblLabel1.BOSDataSource = "";
            this.fld_lblLabel1.BOSDescription = null;
            this.fld_lblLabel1.BOSError = null;
            this.fld_lblLabel1.BOSFieldGroup = "";
            this.fld_lblLabel1.BOSFieldRelation = "";
            this.fld_lblLabel1.BOSPrivilege = "";
            this.fld_lblLabel1.BOSPropertyName = "";
            this.fld_lblLabel1.Location = new System.Drawing.Point(41, 64);
            this.fld_lblLabel1.Name = "fld_lblLabel1";
            this.fld_lblLabel1.Screen = null;
            this.fld_lblLabel1.Size = new System.Drawing.Size(71, 13);
            this.fld_lblLabel1.TabIndex = 46;
            this.fld_lblLabel1.Tag = "SI";
            this.fld_lblLabel1.Text = "Tên chức năng";
            // 
            // fld_lblLabel2
            // 
            this.fld_lblLabel2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel2.BOSComment = "";
            this.fld_lblLabel2.BOSDataMember = "";
            this.fld_lblLabel2.BOSDataSource = "";
            this.fld_lblLabel2.BOSDescription = null;
            this.fld_lblLabel2.BOSError = null;
            this.fld_lblLabel2.BOSFieldGroup = "";
            this.fld_lblLabel2.BOSFieldRelation = "";
            this.fld_lblLabel2.BOSPrivilege = "";
            this.fld_lblLabel2.BOSPropertyName = "";
            this.fld_lblLabel2.Location = new System.Drawing.Point(41, 95);
            this.fld_lblLabel2.Name = "fld_lblLabel2";
            this.fld_lblLabel2.Screen = null;
            this.fld_lblLabel2.Size = new System.Drawing.Size(95, 13);
            this.fld_lblLabel2.TabIndex = 47;
            this.fld_lblLabel2.Tag = "SI";
            this.fld_lblLabel2.Text = "Uri/Store Procedure";
            // 
            // fld_lkeMEEmrActionScope
            // 
            this.fld_lkeMEEmrActionScope.BOSAllowAddNew = false;
            this.fld_lkeMEEmrActionScope.BOSAllowDummy = false;
            this.fld_lkeMEEmrActionScope.BOSComment = "";
            this.fld_lkeMEEmrActionScope.BOSDataMember = "MEEmrActionScope";
            this.fld_lkeMEEmrActionScope.BOSDataSource = "MEEmrActions";
            this.fld_lkeMEEmrActionScope.BOSDescription = null;
            this.fld_lkeMEEmrActionScope.BOSError = null;
            this.fld_lkeMEEmrActionScope.BOSFieldGroup = "";
            this.fld_lkeMEEmrActionScope.BOSFieldParent = "";
            this.fld_lkeMEEmrActionScope.BOSFieldRelation = "";
            this.fld_lkeMEEmrActionScope.BOSPrivilege = "";
            this.fld_lkeMEEmrActionScope.BOSPropertyName = "EditValue";
            this.fld_lkeMEEmrActionScope.BOSSelectType = "";
            this.fld_lkeMEEmrActionScope.BOSSelectTypeValue = "";
            this.fld_lkeMEEmrActionScope.CurrentDisplayText = null;
            this.fld_lkeMEEmrActionScope.Location = new System.Drawing.Point(142, 131);
            this.fld_lkeMEEmrActionScope.Name = "fld_lkeMEEmrActionScope";
            this.fld_lkeMEEmrActionScope.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeMEEmrActionScope.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeMEEmrActionScope.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeMEEmrActionScope.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeMEEmrActionScope.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeMEEmrActionScope.Properties.NullText = "";
            this.fld_lkeMEEmrActionScope.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeMEEmrActionScope.Screen = null;
            this.fld_lkeMEEmrActionScope.Size = new System.Drawing.Size(274, 20);
            this.fld_lkeMEEmrActionScope.TabIndex = 48;
            this.fld_lkeMEEmrActionScope.Tag = "SC";
            // 
            // fld_lblLabel6
            // 
            this.fld_lblLabel6.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel6.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel6.BOSComment = "";
            this.fld_lblLabel6.BOSDataMember = "";
            this.fld_lblLabel6.BOSDataSource = "";
            this.fld_lblLabel6.BOSDescription = null;
            this.fld_lblLabel6.BOSError = null;
            this.fld_lblLabel6.BOSFieldGroup = "";
            this.fld_lblLabel6.BOSFieldRelation = "";
            this.fld_lblLabel6.BOSPrivilege = "";
            this.fld_lblLabel6.BOSPropertyName = "";
            this.fld_lblLabel6.Location = new System.Drawing.Point(41, 134);
            this.fld_lblLabel6.Name = "fld_lblLabel6";
            this.fld_lblLabel6.Screen = null;
            this.fld_lblLabel6.Size = new System.Drawing.Size(82, 13);
            this.fld_lblLabel6.TabIndex = 49;
            this.fld_lblLabel6.Tag = "SI";
            this.fld_lblLabel6.Text = "Phạm vi tác động";
            // 
            // fld_lkeMEEmrActionType
            // 
            this.fld_lkeMEEmrActionType.BOSAllowAddNew = false;
            this.fld_lkeMEEmrActionType.BOSAllowDummy = false;
            this.fld_lkeMEEmrActionType.BOSComment = "";
            this.fld_lkeMEEmrActionType.BOSDataMember = "MEEmrActionType";
            this.fld_lkeMEEmrActionType.BOSDataSource = "MEEmrActions";
            this.fld_lkeMEEmrActionType.BOSDescription = null;
            this.fld_lkeMEEmrActionType.BOSError = null;
            this.fld_lkeMEEmrActionType.BOSFieldGroup = "";
            this.fld_lkeMEEmrActionType.BOSFieldParent = "";
            this.fld_lkeMEEmrActionType.BOSFieldRelation = "";
            this.fld_lkeMEEmrActionType.BOSPrivilege = "";
            this.fld_lkeMEEmrActionType.BOSPropertyName = "EditValue";
            this.fld_lkeMEEmrActionType.BOSSelectType = "";
            this.fld_lkeMEEmrActionType.BOSSelectTypeValue = "";
            this.fld_lkeMEEmrActionType.CurrentDisplayText = null;
            this.fld_lkeMEEmrActionType.Location = new System.Drawing.Point(142, 163);
            this.fld_lkeMEEmrActionType.Name = "fld_lkeMEEmrActionType";
            this.fld_lkeMEEmrActionType.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeMEEmrActionType.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeMEEmrActionType.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeMEEmrActionType.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeMEEmrActionType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeMEEmrActionType.Properties.NullText = "";
            this.fld_lkeMEEmrActionType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeMEEmrActionType.Screen = null;
            this.fld_lkeMEEmrActionType.Size = new System.Drawing.Size(274, 20);
            this.fld_lkeMEEmrActionType.TabIndex = 50;
            this.fld_lkeMEEmrActionType.Tag = "SC";
            // 
            // fld_lblLabel7
            // 
            this.fld_lblLabel7.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel7.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel7.BOSComment = "";
            this.fld_lblLabel7.BOSDataMember = "";
            this.fld_lblLabel7.BOSDataSource = "";
            this.fld_lblLabel7.BOSDescription = null;
            this.fld_lblLabel7.BOSError = null;
            this.fld_lblLabel7.BOSFieldGroup = "";
            this.fld_lblLabel7.BOSFieldRelation = "";
            this.fld_lblLabel7.BOSPrivilege = "";
            this.fld_lblLabel7.BOSPropertyName = "";
            this.fld_lblLabel7.Location = new System.Drawing.Point(41, 166);
            this.fld_lblLabel7.Name = "fld_lblLabel7";
            this.fld_lblLabel7.Screen = null;
            this.fld_lblLabel7.Size = new System.Drawing.Size(72, 13);
            this.fld_lblLabel7.TabIndex = 51;
            this.fld_lblLabel7.Tag = "SI";
            this.fld_lblLabel7.Text = "Loại chức năng";
            // 
            // fld_dgcMEEmrAction
            // 
            this.fld_dgcMEEmrAction.AllowDrop = true;
            this.fld_dgcMEEmrAction.BOSComment = "";
            this.fld_dgcMEEmrAction.BOSDataMember = "";
            this.fld_dgcMEEmrAction.BOSDataSource = "MEEmrActions";
            this.fld_dgcMEEmrAction.BOSDescription = null;
            this.fld_dgcMEEmrAction.BOSError = null;
            this.fld_dgcMEEmrAction.BOSFieldGroup = "";
            this.fld_dgcMEEmrAction.BOSFieldRelation = "";
            this.fld_dgcMEEmrAction.BOSPrivilege = "";
            this.fld_dgcMEEmrAction.BOSPropertyName = "";
            this.fld_dgcMEEmrAction.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMEEmrAction.Location = new System.Drawing.Point(41, 222);
            this.fld_dgcMEEmrAction.MainView = this.fld_dgvMEEmrAction;
            this.fld_dgcMEEmrAction.Name = "fld_dgcMEEmrAction";
            this.fld_dgcMEEmrAction.Screen = null;
            this.fld_dgcMEEmrAction.Size = new System.Drawing.Size(400, 200);
            this.fld_dgcMEEmrAction.TabIndex = 53;
            this.fld_dgcMEEmrAction.Tag = "SR";
            this.fld_dgcMEEmrAction.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvMEEmrAction});
            // 
            // fld_dgvMEEmrAction
            // 
            this.fld_dgvMEEmrAction.GridControl = this.fld_dgcMEEmrAction;
            this.fld_dgvMEEmrAction.Name = "fld_dgvMEEmrAction";
            this.fld_dgvMEEmrAction.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.fld_dgvMEEmrAction.PaintStyleName = "Office2003";
            // 
            // SMEMRAC100
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(862, 567);
            this.Controls.Add(this.fld_dgcMEEmrAction);
            this.Controls.Add(this.bosTextBox1);
            this.Controls.Add(this.fld_txtMEEmrActionNo);
            this.Controls.Add(this.fld_txtMEEmrActionUri);
            this.Controls.Add(this.fld_lblLabel);
            this.Controls.Add(this.fld_lblLabel1);
            this.Controls.Add(this.fld_lblLabel2);
            this.Controls.Add(this.fld_lkeMEEmrActionScope);
            this.Controls.Add(this.fld_lblLabel6);
            this.Controls.Add(this.fld_lkeMEEmrActionType);
            this.Controls.Add(this.fld_lblLabel7);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SMEMRAC100";
            this.Text = "Danh sách chức năng";
            this.Controls.SetChildIndex(this.fld_lblLabel7, 0);
            this.Controls.SetChildIndex(this.fld_lkeMEEmrActionType, 0);
            this.Controls.SetChildIndex(this.fld_lblLabel6, 0);
            this.Controls.SetChildIndex(this.fld_lkeMEEmrActionScope, 0);
            this.Controls.SetChildIndex(this.fld_lblLabel2, 0);
            this.Controls.SetChildIndex(this.fld_lblLabel1, 0);
            this.Controls.SetChildIndex(this.fld_lblLabel, 0);
            this.Controls.SetChildIndex(this.fld_txtMEEmrActionUri, 0);
            this.Controls.SetChildIndex(this.fld_txtMEEmrActionNo, 0);
            this.Controls.SetChildIndex(this.bosTextBox1, 0);
            this.Controls.SetChildIndex(this.fld_dgcMEEmrAction, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bosTextBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrActionNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrActionUri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEEmrActionScope.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeMEEmrActionType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrAction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion
        private IContainer components;
        private BOSComponent.BOSTextBox bosTextBox1;
        private BOSComponent.BOSTextBox fld_txtMEEmrActionNo;
        private BOSComponent.BOSTextBox fld_txtMEEmrActionUri;
        private BOSComponent.BOSLabel fld_lblLabel;
        private BOSComponent.BOSLabel fld_lblLabel1;
        private BOSComponent.BOSLabel fld_lblLabel2;
        private BOSComponent.BOSLookupEdit fld_lkeMEEmrActionScope;
        private BOSComponent.BOSLabel fld_lblLabel6;
        private BOSComponent.BOSLookupEdit fld_lkeMEEmrActionType;
        private BOSComponent.BOSLabel fld_lblLabel7;
        private BOSSearchResultsGridControl fld_dgcMEEmrAction;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvMEEmrAction;
    }
}
