using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.SellStaff.UI
{
	/// <summary>
	/// Summary description for DMSS102
	/// </summary>
	partial class DMSS102
	{
		private BOSComponent.BOSGroupControl fld_grcGroupControl9;
		private BOSComponent.BOSLabel fld_lblLabel59;
		private BOSComponent.BOSLabel fld_lblLabel60;
		private BOSComponent.BOSDateEdit fld_dteDateFrom;
        private BOSComponent.BOSDateEdit fld_dteDateTo;


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMSS102));
            this.fld_grcGroupControl9 = new BOSComponent.BOSGroupControl(this.components);
            this.fld_dgcHREmployeeWorkingShifts = new BOSERP.Modules.SellStaff.HREmployeeWorkingShiftsGridControl();
            this.fld_dgvGridControl = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_btnShow = new BOSComponent.BOSButton(this.components);
            this.fld_lblLabel59 = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel60 = new BOSComponent.BOSLabel(this.components);
            this.fld_dteDateFrom = new BOSComponent.BOSDateEdit(this.components);
            this.fld_dteDateTo = new BOSComponent.BOSDateEdit(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fld_grcGroupControl9)).BeginInit();
            this.fld_grcGroupControl9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHREmployeeWorkingShifts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteDateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteDateTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteDateTo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_grcGroupControl9
            // 
            this.fld_grcGroupControl9.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.fld_grcGroupControl9.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_grcGroupControl9.Appearance.Options.UseBackColor = true;
            this.fld_grcGroupControl9.Appearance.Options.UseForeColor = true;
            this.fld_grcGroupControl9.BOSComment = "";
            this.fld_grcGroupControl9.BOSDataMember = "";
            this.fld_grcGroupControl9.BOSDataSource = "";
            this.fld_grcGroupControl9.BOSDescription = null;
            this.fld_grcGroupControl9.BOSError = null;
            this.fld_grcGroupControl9.BOSFieldGroup = "";
            this.fld_grcGroupControl9.BOSFieldRelation = "";
            this.fld_grcGroupControl9.BOSPrivilege = "";
            this.fld_grcGroupControl9.BOSPropertyName = "";
            this.fld_grcGroupControl9.Controls.Add(this.fld_dgcHREmployeeWorkingShifts);
            this.fld_grcGroupControl9.Controls.Add(this.fld_btnShow);
            this.fld_grcGroupControl9.Controls.Add(this.fld_lblLabel59);
            this.fld_grcGroupControl9.Controls.Add(this.fld_lblLabel60);
            this.fld_grcGroupControl9.Controls.Add(this.fld_dteDateFrom);
            this.fld_grcGroupControl9.Controls.Add(this.fld_dteDateTo);
            resources.ApplyResources(this.fld_grcGroupControl9, "fld_grcGroupControl9");
            this.fld_grcGroupControl9.Name = "fld_grcGroupControl9";
            this.fld_grcGroupControl9.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_grcGroupControl9, ((bool)(resources.GetObject("fld_grcGroupControl9.ShowHelp"))));
            this.fld_grcGroupControl9.Tag = "";
            // 
            // fld_dgcHREmployeeWorkingShifts
            // 
            this.fld_dgcHREmployeeWorkingShifts.AllowDrop = true;
            resources.ApplyResources(this.fld_dgcHREmployeeWorkingShifts, "fld_dgcHREmployeeWorkingShifts");
            this.fld_dgcHREmployeeWorkingShifts.BOSComment = "";
            this.fld_dgcHREmployeeWorkingShifts.BOSDataMember = "";
            this.fld_dgcHREmployeeWorkingShifts.BOSDataSource = "HREmployeeWorkingShifts";
            this.fld_dgcHREmployeeWorkingShifts.BOSDescription = null;
            this.fld_dgcHREmployeeWorkingShifts.BOSError = null;
            this.fld_dgcHREmployeeWorkingShifts.BOSFieldGroup = "";
            this.fld_dgcHREmployeeWorkingShifts.BOSFieldRelation = "";
            this.fld_dgcHREmployeeWorkingShifts.BOSGridType = null;
            this.fld_dgcHREmployeeWorkingShifts.BOSPrivilege = "";
            this.fld_dgcHREmployeeWorkingShifts.BOSPropertyName = "";
            this.fld_dgcHREmployeeWorkingShifts.MainView = this.fld_dgvGridControl;
            this.fld_dgcHREmployeeWorkingShifts.Name = "fld_dgcHREmployeeWorkingShifts";
            this.fld_dgcHREmployeeWorkingShifts.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_dgcHREmployeeWorkingShifts, ((bool)(resources.GetObject("fld_dgcHREmployeeWorkingShifts.ShowHelp"))));
            this.fld_dgcHREmployeeWorkingShifts.Tag = "DC";
            this.fld_dgcHREmployeeWorkingShifts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvGridControl});
            // 
            // fld_dgvGridControl
            // 
            this.fld_dgvGridControl.GridControl = this.fld_dgcHREmployeeWorkingShifts;
            this.fld_dgvGridControl.Name = "fld_dgvGridControl";
            this.fld_dgvGridControl.PaintStyleName = "Office2003";
            // 
            // fld_btnShow
            // 
            this.fld_btnShow.BOSComment = null;
            this.fld_btnShow.BOSDataMember = null;
            this.fld_btnShow.BOSDataSource = null;
            this.fld_btnShow.BOSDescription = null;
            this.fld_btnShow.BOSError = null;
            this.fld_btnShow.BOSFieldGroup = null;
            this.fld_btnShow.BOSFieldRelation = null;
            this.fld_btnShow.BOSPrivilege = null;
            this.fld_btnShow.BOSPropertyName = null;
            resources.ApplyResources(this.fld_btnShow, "fld_btnShow");
            this.fld_btnShow.Name = "fld_btnShow";
            this.fld_btnShow.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_btnShow, ((bool)(resources.GetObject("fld_btnShow.ShowHelp"))));
            this.fld_btnShow.Click += new System.EventHandler(this.fld_btnShow_Click);
            // 
            // fld_lblLabel59
            // 
            this.fld_lblLabel59.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel59.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel59.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel59.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel59.BOSComment = "";
            this.fld_lblLabel59.BOSDataMember = "";
            this.fld_lblLabel59.BOSDataSource = "";
            this.fld_lblLabel59.BOSDescription = null;
            this.fld_lblLabel59.BOSError = null;
            this.fld_lblLabel59.BOSFieldGroup = "";
            this.fld_lblLabel59.BOSFieldRelation = "";
            this.fld_lblLabel59.BOSPrivilege = "";
            this.fld_lblLabel59.BOSPropertyName = "";
            resources.ApplyResources(this.fld_lblLabel59, "fld_lblLabel59");
            this.fld_lblLabel59.Name = "fld_lblLabel59";
            this.fld_lblLabel59.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_lblLabel59, ((bool)(resources.GetObject("fld_lblLabel59.ShowHelp"))));
            this.fld_lblLabel59.Tag = "";
            // 
            // fld_lblLabel60
            // 
            this.fld_lblLabel60.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel60.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel60.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel60.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel60.BOSComment = "";
            this.fld_lblLabel60.BOSDataMember = "";
            this.fld_lblLabel60.BOSDataSource = "";
            this.fld_lblLabel60.BOSDescription = null;
            this.fld_lblLabel60.BOSError = null;
            this.fld_lblLabel60.BOSFieldGroup = "";
            this.fld_lblLabel60.BOSFieldRelation = "";
            this.fld_lblLabel60.BOSPrivilege = "";
            this.fld_lblLabel60.BOSPropertyName = "";
            resources.ApplyResources(this.fld_lblLabel60, "fld_lblLabel60");
            this.fld_lblLabel60.Name = "fld_lblLabel60";
            this.fld_lblLabel60.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_lblLabel60, ((bool)(resources.GetObject("fld_lblLabel60.ShowHelp"))));
            this.fld_lblLabel60.Tag = "";
            // 
            // fld_dteDateFrom
            // 
            this.fld_dteDateFrom.BOSComment = "";
            this.fld_dteDateFrom.BOSDataMember = "EditValue";
            this.fld_dteDateFrom.BOSDataSource = "";
            this.fld_dteDateFrom.BOSDescription = null;
            this.fld_dteDateFrom.BOSError = null;
            this.fld_dteDateFrom.BOSFieldGroup = "";
            this.fld_dteDateFrom.BOSFieldRelation = "";
            this.fld_dteDateFrom.BOSPrivilege = "";
            this.fld_dteDateFrom.BOSPropertyName = "EditValue";
            this.fld_dteDateFrom.EditValue = null;
            resources.ApplyResources(this.fld_dteDateFrom, "fld_dteDateFrom");
            this.fld_dteDateFrom.Name = "fld_dteDateFrom";
            this.fld_dteDateFrom.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteDateFrom.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteDateFrom.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteDateFrom.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("fld_dteDateFrom.Properties.Buttons"))))});
            this.fld_dteDateFrom.Properties.DisplayFormat.FormatString = "MM/dd/yyyy";
            this.fld_dteDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fld_dteDateFrom.Properties.EditFormat.FormatString = "MM/dd/yyyy";
            this.fld_dteDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fld_dteDateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.fld_dteDateFrom.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_dteDateFrom, ((bool)(resources.GetObject("fld_dteDateFrom.ShowHelp"))));
            this.fld_dteDateFrom.Tag = "DC";
            // 
            // fld_dteDateTo
            // 
            this.fld_dteDateTo.BOSComment = "";
            this.fld_dteDateTo.BOSDataMember = "EditValue";
            this.fld_dteDateTo.BOSDataSource = "";
            this.fld_dteDateTo.BOSDescription = null;
            this.fld_dteDateTo.BOSError = null;
            this.fld_dteDateTo.BOSFieldGroup = "";
            this.fld_dteDateTo.BOSFieldRelation = "";
            this.fld_dteDateTo.BOSPrivilege = "";
            this.fld_dteDateTo.BOSPropertyName = "EditValue";
            this.fld_dteDateTo.EditValue = null;
            resources.ApplyResources(this.fld_dteDateTo, "fld_dteDateTo");
            this.fld_dteDateTo.Name = "fld_dteDateTo";
            this.fld_dteDateTo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_dteDateTo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_dteDateTo.Properties.Appearance.Options.UseBackColor = true;
            this.fld_dteDateTo.Properties.Appearance.Options.UseForeColor = true;
            this.fld_dteDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("fld_dteDateTo.Properties.Buttons"))))});
            this.fld_dteDateTo.Properties.DisplayFormat.FormatString = "MM/dd/yyyy";
            this.fld_dteDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fld_dteDateTo.Properties.EditFormat.FormatString = "MM/dd/yyyy";
            this.fld_dteDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fld_dteDateTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.fld_dteDateTo.Screen = null;
            this.ScreenHelper.SetShowHelp(this.fld_dteDateTo, ((bool)(resources.GetObject("fld_dteDateTo.ShowHelp"))));
            this.fld_dteDateTo.Tag = "DC";
            // 
            // DMSS102
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.fld_grcGroupControl9);
            this.Name = "DMSS102";
            this.ScreenHelper.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            this.Controls.SetChildIndex(this.fld_grcGroupControl9, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_grcGroupControl9)).EndInit();
            this.fld_grcGroupControl9.ResumeLayout(false);
            this.fld_grcGroupControl9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcHREmployeeWorkingShifts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteDateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteDateTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dteDateTo.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private IContainer components;
        private BOSComponent.BOSButton fld_btnShow;
        private HREmployeeWorkingShiftsGridControl fld_dgcHREmployeeWorkingShifts;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvGridControl;
	}
}
