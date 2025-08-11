using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.SellStaff.UI
{
	/// <summary>
	/// Summary description for DMSS104
	/// </summary>
	partial class DMSS104
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
            this.fld_dgcEmployeeOTFactors = new EmployeeOTFactorGridControl();
            this.bosPanel1 = new BOSComponent.BOSPanel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcEmployeeOTFactors)).BeginInit();
            this.bosPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fld_dgcEmployeeOTFactors
            // 
            this.fld_dgcEmployeeOTFactors.BOSComment = null;
            this.fld_dgcEmployeeOTFactors.BOSDataMember = null;
            this.fld_dgcEmployeeOTFactors.BOSDataSource = "HREmployeeOTFactors";
            this.fld_dgcEmployeeOTFactors.BOSDescription = null;
            this.fld_dgcEmployeeOTFactors.BOSError = null;
            this.fld_dgcEmployeeOTFactors.BOSFieldGroup = null;
            this.fld_dgcEmployeeOTFactors.BOSFieldRelation = null;
            this.fld_dgcEmployeeOTFactors.BOSGridType = null;
            this.fld_dgcEmployeeOTFactors.BOSPrivilege = null;
            this.fld_dgcEmployeeOTFactors.BOSPropertyName = null;
            this.fld_dgcEmployeeOTFactors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_dgcEmployeeOTFactors.Location = new System.Drawing.Point(0, 0);
            this.fld_dgcEmployeeOTFactors.MenuManager = this.screenToolbar;
            this.fld_dgcEmployeeOTFactors.Name = "fld_dgcEmployeeOTFactors";
            this.fld_dgcEmployeeOTFactors.Screen = null;
            this.fld_dgcEmployeeOTFactors.Size = new System.Drawing.Size(862, 567);
            this.fld_dgcEmployeeOTFactors.TabIndex = 6;
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
            this.bosPanel1.Controls.Add(this.fld_dgcEmployeeOTFactors);
            this.bosPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bosPanel1.Location = new System.Drawing.Point(0, 0);
            this.bosPanel1.Name = "bosPanel1";
            this.bosPanel1.Screen = null;
            this.bosPanel1.Size = new System.Drawing.Size(862, 567);
            this.bosPanel1.TabIndex = 7;
            // 
            // DMSS104
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(862, 567);
            this.Controls.Add(this.bosPanel1);
            this.Name = "DMSS104";
            this.Text = "Hệ số tăng ca";
            this.Controls.SetChildIndex(this.bosPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcEmployeeOTFactors)).EndInit();
            this.bosPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        private EmployeeOTFactorGridControl fld_dgcEmployeeOTFactors;
        private IContainer components;
        private BOSComponent.BOSPanel bosPanel1;
	}
}
