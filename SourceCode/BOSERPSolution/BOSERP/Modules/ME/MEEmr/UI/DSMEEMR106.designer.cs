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
    partial class DSMEEMR106
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DSMEEMR106));
            this.fld_grdMEParamLookupDatas = new BOSERP.Modules.MEEmr.DataSelectionGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.fld_dgcSelectedData = new BOSERP.Modules.MEEmr.DataSelectionGridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.fld_grdMEParamLookupDatas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcSelectedData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_grdMEParamLookupDatas
            // 
            this.fld_grdMEParamLookupDatas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_grdMEParamLookupDatas.BOSComment = null;
            this.fld_grdMEParamLookupDatas.BOSDataMember = null;
            this.fld_grdMEParamLookupDatas.BOSDataSource = "MEParamLookupDatas";
            this.fld_grdMEParamLookupDatas.BOSDescription = null;
            this.fld_grdMEParamLookupDatas.BOSError = null;
            this.fld_grdMEParamLookupDatas.BOSFieldGroup = null;
            this.fld_grdMEParamLookupDatas.BOSFieldRelation = null;
            this.fld_grdMEParamLookupDatas.BOSGridType = null;
            this.fld_grdMEParamLookupDatas.BOSPrivilege = null;
            this.fld_grdMEParamLookupDatas.BOSPropertyName = null;
            this.fld_grdMEParamLookupDatas.Location = new System.Drawing.Point(0, 0);
            this.fld_grdMEParamLookupDatas.MainView = this.gridView1;
            this.fld_grdMEParamLookupDatas.MenuManager = this.screenToolbar;
            this.fld_grdMEParamLookupDatas.Name = "fld_grdMEParamLookupDatas";
            this.fld_grdMEParamLookupDatas.PrintReport = false;
            this.fld_grdMEParamLookupDatas.Screen = null;
            this.fld_grdMEParamLookupDatas.Size = new System.Drawing.Size(594, 580);
            this.fld_grdMEParamLookupDatas.TabIndex = 0;
            this.fld_grdMEParamLookupDatas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_grdMEParamLookupDatas;
            this.gridView1.Name = "gridView1";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.Location = new System.Drawing.Point(712, 584);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK (Alt+O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(805, 584);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // fld_dgcSelectedData
            // 
            this.fld_dgcSelectedData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcSelectedData.BOSComment = null;
            this.fld_dgcSelectedData.BOSDataMember = null;
            this.fld_dgcSelectedData.BOSDataSource = "MEParamLookupDatas";
            this.fld_dgcSelectedData.BOSDescription = null;
            this.fld_dgcSelectedData.BOSError = null;
            this.fld_dgcSelectedData.BOSFieldGroup = null;
            this.fld_dgcSelectedData.BOSFieldRelation = null;
            this.fld_dgcSelectedData.BOSGridType = null;
            this.fld_dgcSelectedData.BOSPrivilege = null;
            this.fld_dgcSelectedData.BOSPropertyName = null;
            this.fld_dgcSelectedData.Location = new System.Drawing.Point(600, 0);
            this.fld_dgcSelectedData.MainView = this.gridView2;
            this.fld_dgcSelectedData.MenuManager = this.screenToolbar;
            this.fld_dgcSelectedData.Name = "fld_dgcSelectedData";
            this.fld_dgcSelectedData.PrintReport = false;
            this.fld_dgcSelectedData.Screen = null;
            this.fld_dgcSelectedData.Size = new System.Drawing.Size(281, 580);
            this.fld_dgcSelectedData.TabIndex = 9;
            this.fld_dgcSelectedData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.fld_dgcSelectedData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fld_dgcSelectedData_KeyDown);
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.fld_dgcSelectedData;
            this.gridView2.Name = "gridView2";
            // 
            // DSMEEMR106
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(884, 611);
            this.ControlBox = true;
            this.Controls.Add(this.fld_dgcSelectedData);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.fld_grdMEParamLookupDatas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DSMEEMR106";
            this.Text = "Chọn dữ liệu";
            this.Load += new System.EventHandler(this.DSMEEMR100_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DSMEEMR106_KeyPress);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.DSMEEMR106_PreviewKeyDown);
            this.Controls.SetChildIndex(this.fld_grdMEParamLookupDatas, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.fld_dgcSelectedData, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_grdMEParamLookupDatas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcSelectedData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private IContainer components;
        private DataSelectionGridControl fld_grdMEParamLookupDatas;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DataSelectionGridControl fld_dgcSelectedData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    }
}
