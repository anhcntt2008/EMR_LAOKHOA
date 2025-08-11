using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    partial class DSMEEMR103

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DSMEEMR103));
            this.fld_grdDataSelection = new BOSERP.Modules.MEEmr.StethoscopesGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.fld_grdDataSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_grdDataSelection
            // 
            this.fld_grdDataSelection.BOSComment = null;
            this.fld_grdDataSelection.BOSDataMember = null;
            this.fld_grdDataSelection.BOSDataSource = null;
            this.fld_grdDataSelection.BOSDescription = null;
            this.fld_grdDataSelection.BOSError = null;
            this.fld_grdDataSelection.BOSFieldGroup = null;
            this.fld_grdDataSelection.BOSFieldRelation = null;
            this.fld_grdDataSelection.BOSGridType = null;
            this.fld_grdDataSelection.BOSPrivilege = null;
            this.fld_grdDataSelection.BOSPropertyName = null;
            this.fld_grdDataSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.fld_grdDataSelection.Location = new System.Drawing.Point(0, 0);
            this.fld_grdDataSelection.MainView = this.gridView1;
            this.fld_grdDataSelection.MenuManager = this.screenToolbar;
            this.fld_grdDataSelection.Name = "fld_grdDataSelection";
            this.fld_grdDataSelection.PrintReport = false;
            this.fld_grdDataSelection.Screen = null;
            this.fld_grdDataSelection.Size = new System.Drawing.Size(726, 443);
            this.fld_grdDataSelection.TabIndex = 6;
            this.fld_grdDataSelection.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_grdDataSelection;
            this.gridView1.Name = "gridView1";
            // 
            // btnOk
            // 
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.Location = new System.Drawing.Point(540, 452);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(84, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "OK (Alt+O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(630, 451);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // DSMEEMR103
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(726, 484);
            this.ControlBox = true;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.fld_grdDataSelection);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DSMEEMR103";
            this.Text = "Chọn dữ liệu";
            this.Load += new System.EventHandler(this.DSMEEMR100_Load);
            this.Controls.SetChildIndex(this.fld_grdDataSelection, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_grdDataSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private IContainer components;
        private StethoscopesGridControl fld_grdDataSelection;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
