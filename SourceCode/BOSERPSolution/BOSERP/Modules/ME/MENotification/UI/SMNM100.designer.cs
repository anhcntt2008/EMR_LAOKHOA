using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.MENotification.UI
{
	/// <summary>
	/// Summary description for SMNM100
	/// </summary>
	partial class SMNM100
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
            this.fld_dgcMENotifications = new BOSERP.BOSSearchResultsGridControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMENotifications)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_dgcMENotifications
            // 
            this.fld_dgcMENotifications.BOSComment = null;
            this.fld_dgcMENotifications.BOSDataMember = null;
            this.fld_dgcMENotifications.BOSDataSource = "MENotifications";
            this.fld_dgcMENotifications.BOSDescription = null;
            this.fld_dgcMENotifications.BOSError = null;
            this.fld_dgcMENotifications.BOSFieldGroup = null;
            this.fld_dgcMENotifications.BOSFieldRelation = null;
            this.fld_dgcMENotifications.BOSPrivilege = null;
            this.fld_dgcMENotifications.BOSPropertyName = null;
            this.fld_dgcMENotifications.Location = new System.Drawing.Point(231, 183);
            this.fld_dgcMENotifications.MenuManager = this.screenToolbar;
            this.fld_dgcMENotifications.Name = "fld_dgcMENotifications";
            this.fld_dgcMENotifications.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_dgcMENotifications, true);
            this.fld_dgcMENotifications.Size = new System.Drawing.Size(400, 200);
            this.fld_dgcMENotifications.TabIndex = 10;
            this.fld_dgcMENotifications.Tag = "SR";
            // 
            // SMNM100
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(862, 567);
            this.Controls.Add(this.fld_dgcMENotifications);
            this.Name = "SMNM100";
            this.Text = "Tìm kiếm";
            this.Controls.SetChildIndex(this.fld_dgcMENotifications, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMENotifications)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private BOSSearchResultsGridControl fld_dgcMENotifications;
        private IContainer components;
	}
}
