using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.MEEmrType.UI
{
	/// <summary>
	/// Summary description for SMEMRTYP100
	/// </summary>
	partial class SMEMRTYP100
	{
		private BOSComponent.BOSTextBox fld_txtMEEmrTypeNo;
		private BOSComponent.BOSTextBox fld_txtMEEmrTypeName;
		private BOSComponent.BOSLabel fld_lblLabel;
		private BOSComponent.BOSLabel fld_lblMEEmrTypeNo;
		private BOSComponent.BOSLabel fld_lblMEEmrTypeName;
		private BOSSearchResultsGridControl fld_dgcMEEmrType;
		private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvMEEmrType;


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMEMRTYP100));
            this.fld_txtMEEmrTypeNo = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtMEEmrTypeName = new BOSComponent.BOSTextBox(this.components);
            this.fld_lblLabel = new BOSComponent.BOSLabel(this.components);
            this.fld_lblMEEmrTypeNo = new BOSComponent.BOSLabel(this.components);
            this.fld_lblMEEmrTypeName = new BOSComponent.BOSLabel(this.components);
            this.fld_dgcMEEmrType = new BOSSearchResultsGridControl();
            this.fld_dgvMEEmrType = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrTypeNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrTypeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrType)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_txtMEEmrTypeNo
            // 
            this.fld_txtMEEmrTypeNo.BOSComment = "";
            this.fld_txtMEEmrTypeNo.BOSDataMember = "MEEmrTypeNo";
            this.fld_txtMEEmrTypeNo.BOSDataSource = "MEEmrTypes";
            this.fld_txtMEEmrTypeNo.BOSDescription = null;
            this.fld_txtMEEmrTypeNo.BOSError = null;
            this.fld_txtMEEmrTypeNo.BOSFieldGroup = "";
            this.fld_txtMEEmrTypeNo.BOSFieldRelation = "";
            this.fld_txtMEEmrTypeNo.BOSPrivilege = "";
            this.fld_txtMEEmrTypeNo.BOSPropertyName = "Text";
            this.fld_txtMEEmrTypeNo.EditValue = "";
            this.fld_txtMEEmrTypeNo.Location = new System.Drawing.Point(120, 47);
            this.fld_txtMEEmrTypeNo.Name = "fld_txtMEEmrTypeNo";
            this.fld_txtMEEmrTypeNo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEEmrTypeNo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEEmrTypeNo.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEEmrTypeNo.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEEmrTypeNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEEmrTypeNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEEmrTypeNo.Screen = null;
            this.fld_txtMEEmrTypeNo.Size = new System.Drawing.Size(312, 20);
            this.fld_txtMEEmrTypeNo.TabIndex = 4;
            this.fld_txtMEEmrTypeNo.Tag = "SC";
            // 
            // fld_txtMEEmrTypeName
            // 
            this.fld_txtMEEmrTypeName.BOSComment = "";
            this.fld_txtMEEmrTypeName.BOSDataMember = "MEEmrTypeName";
            this.fld_txtMEEmrTypeName.BOSDataSource = "MEEmrTypes";
            this.fld_txtMEEmrTypeName.BOSDescription = null;
            this.fld_txtMEEmrTypeName.BOSError = null;
            this.fld_txtMEEmrTypeName.BOSFieldGroup = "";
            this.fld_txtMEEmrTypeName.BOSFieldRelation = "";
            this.fld_txtMEEmrTypeName.BOSPrivilege = "";
            this.fld_txtMEEmrTypeName.BOSPropertyName = "Text";
            this.fld_txtMEEmrTypeName.EditValue = "";
            this.fld_txtMEEmrTypeName.Location = new System.Drawing.Point(121, 80);
            this.fld_txtMEEmrTypeName.Name = "fld_txtMEEmrTypeName";
            this.fld_txtMEEmrTypeName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEEmrTypeName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEEmrTypeName.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEEmrTypeName.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEEmrTypeName.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEEmrTypeName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEEmrTypeName.Screen = null;
            this.fld_txtMEEmrTypeName.Size = new System.Drawing.Size(311, 20);
            this.fld_txtMEEmrTypeName.TabIndex = 5;
            this.fld_txtMEEmrTypeName.Tag = "SC";
            // 
            // fld_lblLabel
            // 
            this.fld_lblLabel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.fld_lblLabel.Location = new System.Drawing.Point(31, 52);
            this.fld_lblLabel.Name = "fld_lblLabel";
            this.fld_lblLabel.Screen = null;
            this.fld_lblLabel.Size = new System.Drawing.Size(75, 13);
            this.fld_lblLabel.TabIndex = 6;
            this.fld_lblLabel.Tag = "SI";
            this.fld_lblLabel.Text = "Mã loại bệnh án";
            // 
            // fld_lblMEEmrTypeNo
            // 
            this.fld_lblMEEmrTypeNo.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblMEEmrTypeNo.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblMEEmrTypeNo.BOSComment = "";
            this.fld_lblMEEmrTypeNo.BOSDataMember = "";
            this.fld_lblMEEmrTypeNo.BOSDataSource = "";
            this.fld_lblMEEmrTypeNo.BOSDescription = null;
            this.fld_lblMEEmrTypeNo.BOSError = null;
            this.fld_lblMEEmrTypeNo.BOSFieldGroup = "";
            this.fld_lblMEEmrTypeNo.BOSFieldRelation = "";
            this.fld_lblMEEmrTypeNo.BOSPrivilege = "";
            this.fld_lblMEEmrTypeNo.BOSPropertyName = "";
            this.fld_lblMEEmrTypeNo.Location = new System.Drawing.Point(46, 52);
            this.fld_lblMEEmrTypeNo.Name = "fld_lblMEEmrTypeNo";
            this.fld_lblMEEmrTypeNo.Screen = null;
            this.fld_lblMEEmrTypeNo.Size = new System.Drawing.Size(53, 13);
            this.fld_lblMEEmrTypeNo.TabIndex = 6;
            this.fld_lblMEEmrTypeNo.Tag = "";
            this.fld_lblMEEmrTypeNo.Text = "fld_lblLabel";
            // 
            // fld_lblMEEmrTypeName
            // 
            this.fld_lblMEEmrTypeName.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblMEEmrTypeName.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblMEEmrTypeName.BOSComment = "";
            this.fld_lblMEEmrTypeName.BOSDataMember = "";
            this.fld_lblMEEmrTypeName.BOSDataSource = "";
            this.fld_lblMEEmrTypeName.BOSDescription = null;
            this.fld_lblMEEmrTypeName.BOSError = null;
            this.fld_lblMEEmrTypeName.BOSFieldGroup = "";
            this.fld_lblMEEmrTypeName.BOSFieldRelation = "";
            this.fld_lblMEEmrTypeName.BOSPrivilege = "";
            this.fld_lblMEEmrTypeName.BOSPropertyName = "";
            this.fld_lblMEEmrTypeName.Location = new System.Drawing.Point(30, 84);
            this.fld_lblMEEmrTypeName.Name = "fld_lblMEEmrTypeName";
            this.fld_lblMEEmrTypeName.Screen = null;
            this.fld_lblMEEmrTypeName.Size = new System.Drawing.Size(79, 13);
            this.fld_lblMEEmrTypeName.TabIndex = 7;
            this.fld_lblMEEmrTypeName.Tag = "SI";
            this.fld_lblMEEmrTypeName.Text = "Tên loại bệnh án";
            // 
            // fld_dgcMEEmrType
            // 
            this.fld_dgcMEEmrType.AllowDrop = true;
            this.fld_dgcMEEmrType.BOSComment = "";
            this.fld_dgcMEEmrType.BOSDataMember = "";
            this.fld_dgcMEEmrType.BOSDataSource = "MEEmrTypes";
            this.fld_dgcMEEmrType.BOSDescription = null;
            this.fld_dgcMEEmrType.BOSError = null;
            this.fld_dgcMEEmrType.BOSFieldGroup = "";
            this.fld_dgcMEEmrType.BOSFieldRelation = "";
            this.fld_dgcMEEmrType.BOSPrivilege = "";
            this.fld_dgcMEEmrType.BOSPropertyName = "";
            this.fld_dgcMEEmrType.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMEEmrType.Location = new System.Drawing.Point(32, 123);
            this.fld_dgcMEEmrType.MainView = this.fld_dgvMEEmrType;
            this.fld_dgcMEEmrType.Name = "fld_dgcMEEmrType";
            this.fld_dgcMEEmrType.Screen = null;
            this.fld_dgcMEEmrType.Size = new System.Drawing.Size(400, 200);
            this.fld_dgcMEEmrType.TabIndex = 8;
            this.fld_dgcMEEmrType.Tag = "SR";
            this.fld_dgcMEEmrType.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvMEEmrType});
            // 
            // fld_dgvMEEmrType
            // 
            this.fld_dgvMEEmrType.GridControl = this.fld_dgcMEEmrType;
            this.fld_dgvMEEmrType.Name = "fld_dgvMEEmrType";
            this.fld_dgvMEEmrType.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.fld_dgvMEEmrType.PaintStyleName = "Office2003";
            // 
            // SMEMRTYP100
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(483, 363);
            this.Controls.Add(this.fld_txtMEEmrTypeNo);
            this.Controls.Add(this.fld_txtMEEmrTypeName);
            this.Controls.Add(this.fld_lblLabel);
            this.Controls.Add(this.fld_lblMEEmrTypeNo);
            this.Controls.Add(this.fld_lblMEEmrTypeName);
            this.Controls.Add(this.fld_dgcMEEmrType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SMEMRTYP100";
            this.Text = "Tìm kiếm";
            this.Load += new System.EventHandler(this.SMEMRTYP100_Load);
            this.Controls.SetChildIndex(this.fld_dgcMEEmrType, 0);
            this.Controls.SetChildIndex(this.fld_lblMEEmrTypeName, 0);
            this.Controls.SetChildIndex(this.fld_lblMEEmrTypeNo, 0);
            this.Controls.SetChildIndex(this.fld_lblLabel, 0);
            this.Controls.SetChildIndex(this.fld_txtMEEmrTypeName, 0);
            this.Controls.SetChildIndex(this.fld_txtMEEmrTypeNo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrTypeNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEEmrTypeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEEmrType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEEmrType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion

        private IContainer components;
    }
}
