using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.Location.UI
{
	/// <summary>
	/// Summary description for DMLO100
	/// </summary>
	partial class DMLO100
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
            this.bosPanel1 = new BOSComponent.BOSPanel(this.components);
            this.fld_trlGELocations = new BOSERP.Modules.Location.GELocationsTreeListControl();
            this.bosPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_trlGELocations)).BeginInit();
            this.SuspendLayout();
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
            this.bosPanel1.Controls.Add(this.fld_trlGELocations);
            this.bosPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bosPanel1.Location = new System.Drawing.Point(0, 0);
            this.bosPanel1.Name = "bosPanel1";
            this.bosPanel1.Screen = null;
            this.bosPanel1.Size = new System.Drawing.Size(862, 567);
            this.bosPanel1.TabIndex = 6;
            // 
            // fld_trlGELocations
            // 
            this.fld_trlGELocations.BOSComment = null;
            this.fld_trlGELocations.BOSDataMember = null;
            this.fld_trlGELocations.BOSDataSource = "GELocations";
            this.fld_trlGELocations.BOSDescription = null;
            this.fld_trlGELocations.BOSDisplayOption = false;
            this.fld_trlGELocations.BOSDisplayRoot = false;
            this.fld_trlGELocations.BOSError = null;
            this.fld_trlGELocations.BOSFieldGroup = null;
            this.fld_trlGELocations.BOSFieldRelation = null;
            this.fld_trlGELocations.BOSPrivilege = null;
            this.fld_trlGELocations.BOSPropertyName = null;
            this.fld_trlGELocations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fld_trlGELocations.Location = new System.Drawing.Point(0, 0);
            this.fld_trlGELocations.Name = "fld_trlGELocations";
            this.fld_trlGELocations.OptionsView.ShowColumns = false;
            this.fld_trlGELocations.Screen = null;
            this.fld_trlGELocations.Size = new System.Drawing.Size(862, 567);
            this.fld_trlGELocations.TabIndex = 0;
            // 
            // DMLO100
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(862, 567);
            this.Controls.Add(this.bosPanel1);
            this.Name = "DMLO100";
            this.Text = "Quản lý địa chỉ";
            this.bosPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_trlGELocations)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private BOSComponent.BOSPanel bosPanel1;
        private IContainer components;
        private GELocationsTreeListControl fld_trlGELocations;
	}
}
