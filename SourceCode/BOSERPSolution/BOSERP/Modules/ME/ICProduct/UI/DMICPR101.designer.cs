using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.ICProduct.UI
{
	/// <summary>
	/// Summary description for DMICPR101
	/// </summary>
	partial class DMICPR101
	{
		private BOSComponent.BOSGroupControl fld_grcGroupControl5;
		private InteractingMedicinesGridControl fld_dgcInteractingProducts;
		private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvInteractingProducts;
        private BOSComponent.BOSMemoEdit fld_medMEInteractingMedicineDesc;


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
            this.fld_grcGroupControl5 = new BOSComponent.BOSGroupControl(this.components);
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.fld_dgcInteractingProducts = new InteractingMedicinesGridControl();
            this.fld_dgvInteractingProducts = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_medMEInteractingMedicineDesc = new BOSComponent.BOSMemoEdit(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fld_grcGroupControl5)).BeginInit();
            this.fld_grcGroupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcInteractingProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvInteractingProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_medMEInteractingMedicineDesc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_grcGroupControl5
            // 
            this.fld_grcGroupControl5.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.fld_grcGroupControl5.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_grcGroupControl5.Appearance.Options.UseBackColor = true;
            this.fld_grcGroupControl5.Appearance.Options.UseForeColor = true;
            this.fld_grcGroupControl5.BOSComment = "";
            this.fld_grcGroupControl5.BOSDataMember = "";
            this.fld_grcGroupControl5.BOSDataSource = "";
            this.fld_grcGroupControl5.BOSDescription = null;
            this.fld_grcGroupControl5.BOSError = null;
            this.fld_grcGroupControl5.BOSFieldGroup = "";
            this.fld_grcGroupControl5.BOSFieldRelation = "";
            this.fld_grcGroupControl5.BOSPrivilege = "";
            this.fld_grcGroupControl5.BOSPropertyName = "";
            this.fld_grcGroupControl5.Controls.Add(this.splitterControl1);
            this.fld_grcGroupControl5.Controls.Add(this.fld_dgcInteractingProducts);
            this.fld_grcGroupControl5.Controls.Add(this.fld_medMEInteractingMedicineDesc);
            this.fld_grcGroupControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_grcGroupControl5.Location = new System.Drawing.Point(0, 0);
            this.fld_grcGroupControl5.Name = "fld_grcGroupControl5";
            this.fld_grcGroupControl5.Screen = null;
            this.fld_grcGroupControl5.Size = new System.Drawing.Size(862, 567);
            this.fld_grcGroupControl5.TabIndex = 4;
            this.fld_grcGroupControl5.Tag = "";
            this.fld_grcGroupControl5.Text = "Danh sách thuốc tương tác";
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterControl1.Location = new System.Drawing.Point(550, 22);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(6, 543);
            this.splitterControl1.TabIndex = 7;
            this.splitterControl1.TabStop = false;
            // 
            // fld_dgcInteractingProducts
            // 
            this.fld_dgcInteractingProducts.AllowDrop = true;
            this.fld_dgcInteractingProducts.BOSComment = "";
            this.fld_dgcInteractingProducts.BOSDataMember = "";
            this.fld_dgcInteractingProducts.BOSDataSource = "MEInteractingMedicines";
            this.fld_dgcInteractingProducts.BOSDescription = null;
            this.fld_dgcInteractingProducts.BOSError = null;
            this.fld_dgcInteractingProducts.BOSFieldGroup = "";
            this.fld_dgcInteractingProducts.BOSFieldRelation = "";
            this.fld_dgcInteractingProducts.BOSGridType = null;
            this.fld_dgcInteractingProducts.BOSPrivilege = "";
            this.fld_dgcInteractingProducts.BOSPropertyName = "";
            this.fld_dgcInteractingProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_dgcInteractingProducts.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcInteractingProducts.Location = new System.Drawing.Point(2, 22);
            this.fld_dgcInteractingProducts.MainView = this.fld_dgvInteractingProducts;
            this.fld_dgcInteractingProducts.Name = "fld_dgcInteractingProducts";
            this.fld_dgcInteractingProducts.Screen = null;
            this.fld_dgcInteractingProducts.Size = new System.Drawing.Size(554, 543);
            this.fld_dgcInteractingProducts.TabIndex = 5;
            this.fld_dgcInteractingProducts.Tag = "DC";
            this.fld_dgcInteractingProducts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvInteractingProducts});
            // 
            // fld_dgvInteractingProducts
            // 
            this.fld_dgvInteractingProducts.GridControl = this.fld_dgcInteractingProducts;
            this.fld_dgvInteractingProducts.Name = "fld_dgvInteractingProducts";
            this.fld_dgvInteractingProducts.PaintStyleName = "Office2003";
            // 
            // fld_medMEInteractingMedicineDesc
            // 
            this.fld_medMEInteractingMedicineDesc.BOSComment = "";
            this.fld_medMEInteractingMedicineDesc.BOSDataMember = "MEInteractingMedicineDesc";
            this.fld_medMEInteractingMedicineDesc.BOSDataSource = "MEInteractingMedicines";
            this.fld_medMEInteractingMedicineDesc.BOSDescription = null;
            this.fld_medMEInteractingMedicineDesc.BOSError = null;
            this.fld_medMEInteractingMedicineDesc.BOSFieldGroup = "";
            this.fld_medMEInteractingMedicineDesc.BOSFieldRelation = "";
            this.fld_medMEInteractingMedicineDesc.BOSPrivilege = "";
            this.fld_medMEInteractingMedicineDesc.BOSPropertyName = "Text";
            this.fld_medMEInteractingMedicineDesc.Dock = System.Windows.Forms.DockStyle.Right;
            this.fld_medMEInteractingMedicineDesc.EditValue = "";
            this.fld_medMEInteractingMedicineDesc.Location = new System.Drawing.Point(556, 22);
            this.fld_medMEInteractingMedicineDesc.Name = "fld_medMEInteractingMedicineDesc";
            this.fld_medMEInteractingMedicineDesc.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_medMEInteractingMedicineDesc.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_medMEInteractingMedicineDesc.Properties.Appearance.Options.UseBackColor = true;
            this.fld_medMEInteractingMedicineDesc.Properties.Appearance.Options.UseForeColor = true;
            this.fld_medMEInteractingMedicineDesc.Screen = null;
            this.fld_medMEInteractingMedicineDesc.Size = new System.Drawing.Size(304, 543);
            this.fld_medMEInteractingMedicineDesc.TabIndex = 6;
            this.fld_medMEInteractingMedicineDesc.Tag = "DC";
            // 
            // DMICPR101
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(862, 567);
            this.Controls.Add(this.fld_grcGroupControl5);
            this.Name = "DMICPR101";
            this.Text = "Tương tác thuốc";
            ((System.ComponentModel.ISupportInitialize)(this.fld_grcGroupControl5)).EndInit();
            this.fld_grcGroupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcInteractingProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvInteractingProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_medMEInteractingMedicineDesc.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private IContainer components;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
	}
}
