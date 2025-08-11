using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSComponent;

namespace BOSERP.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    partial class guiSearchPatient

    {
        private BOSComponent.BOSLabel fld_lblLabel9;


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiSearchPatient));
            this.fld_lblLabel9 = new BOSComponent.BOSLabel(this.components);
            this.fld_btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.fld_btn_Ok = new DevExpress.XtraEditors.SimpleButton();
            this.fld_txtSearchCriteria = new System.Windows.Forms.TextBox();
            this.fld_tbnSearchPatient = new DevExpress.XtraEditors.SimpleButton();
            this.fld_grdPatientSearchLocalResult = new BOSGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bosLabel1 = new BOSComponent.BOSLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fld_grdPatientSearchLocalResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_lblLabel9
            // 
            this.fld_lblLabel9.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lblLabel9.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel9.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel9.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel9.BOSComment = "";
            this.fld_lblLabel9.BOSDataMember = "";
            this.fld_lblLabel9.BOSDataSource = "";
            this.fld_lblLabel9.BOSDescription = null;
            this.fld_lblLabel9.BOSError = null;
            this.fld_lblLabel9.BOSFieldGroup = "";
            this.fld_lblLabel9.BOSFieldRelation = "";
            this.fld_lblLabel9.BOSPrivilege = "";
            this.fld_lblLabel9.BOSPropertyName = "";
            this.fld_lblLabel9.Location = new System.Drawing.Point(24, 26);
            this.fld_lblLabel9.Name = "fld_lblLabel9";
            this.fld_lblLabel9.Screen = null;
            this.fld_lblLabel9.Size = new System.Drawing.Size(44, 13);
            this.fld_lblLabel9.TabIndex = 8;
            this.fld_lblLabel9.Tag = "";
            this.fld_lblLabel9.Text = "Điều kiện";
            // 
            // fld_btn_Cancel
            // 
            this.fld_btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_btn_Cancel.Location = new System.Drawing.Point(797, 499);
            this.fld_btn_Cancel.Name = "fld_btn_Cancel";
            this.fld_btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.fld_btn_Cancel.TabIndex = 10;
            this.fld_btn_Cancel.Text = "Hủy";
            this.fld_btn_Cancel.Click += new System.EventHandler(this.fld_btn_Cancel_Click);
            // 
            // fld_btn_Ok
            // 
            this.fld_btn_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_btn_Ok.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("fld_btn_Ok.ImageOptions.Image")));
            this.fld_btn_Ok.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.fld_btn_Ok.Location = new System.Drawing.Point(708, 499);
            this.fld_btn_Ok.Name = "fld_btn_Ok";
            this.fld_btn_Ok.Size = new System.Drawing.Size(83, 23);
            this.fld_btn_Ok.TabIndex = 2;
            this.fld_btn_Ok.Text = "OK (Alt+O)";
            this.fld_btn_Ok.Click += new System.EventHandler(this.fld_btn_Ok_Click);
            // 
            // fld_txtSearchCriteria
            // 
            this.fld_txtSearchCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_txtSearchCriteria.Location = new System.Drawing.Point(74, 21);
            this.fld_txtSearchCriteria.Name = "fld_txtSearchCriteria";
            this.fld_txtSearchCriteria.Size = new System.Drawing.Size(701, 21);
            this.fld_txtSearchCriteria.TabIndex = 0;
            this.fld_txtSearchCriteria.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fld_txtSearchCriteria_KeyUp);
            // 
            // fld_tbnSearchPatient
            // 
            this.fld_tbnSearchPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_tbnSearchPatient.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("fld_tbnSearchPatient.ImageOptions.Image")));
            this.fld_tbnSearchPatient.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.fld_tbnSearchPatient.Location = new System.Drawing.Point(781, 20);
            this.fld_tbnSearchPatient.Name = "fld_tbnSearchPatient";
            this.fld_tbnSearchPatient.Size = new System.Drawing.Size(75, 23);
            this.fld_tbnSearchPatient.TabIndex = 1;
            this.fld_tbnSearchPatient.Text = "Tìm";
            this.fld_tbnSearchPatient.Click += new System.EventHandler(this.fld_tbnSearchPatient_Click);
            // 
            // fld_grdPatientSearchLocalResult
            // 
            this.fld_grdPatientSearchLocalResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_grdPatientSearchLocalResult.BOSComment = null;
            this.fld_grdPatientSearchLocalResult.BOSDataMember = null;
            this.fld_grdPatientSearchLocalResult.BOSDataSource = "MEPatients";
            this.fld_grdPatientSearchLocalResult.BOSDescription = null;
            this.fld_grdPatientSearchLocalResult.BOSError = null;
            this.fld_grdPatientSearchLocalResult.BOSFieldGroup = null;
            this.fld_grdPatientSearchLocalResult.BOSFieldRelation = null;
            this.fld_grdPatientSearchLocalResult.BOSGridType = null;
            this.fld_grdPatientSearchLocalResult.BOSPrivilege = null;
            this.fld_grdPatientSearchLocalResult.BOSPropertyName = null;
            this.fld_grdPatientSearchLocalResult.Location = new System.Drawing.Point(12, 53);
            this.fld_grdPatientSearchLocalResult.MainView = this.gridView1;
            this.fld_grdPatientSearchLocalResult.MenuManager = this.screenToolbar;
            this.fld_grdPatientSearchLocalResult.Name = "fld_grdPatientSearchLocalResult";
            this.fld_grdPatientSearchLocalResult.PrintReport = false;
            this.fld_grdPatientSearchLocalResult.Screen = null;
            this.fld_grdPatientSearchLocalResult.Size = new System.Drawing.Size(860, 436);
            this.fld_grdPatientSearchLocalResult.TabIndex = 19;
            this.fld_grdPatientSearchLocalResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_grdPatientSearchLocalResult;
            this.gridView1.Name = "gridView1";
            // 
            // bosLabel1
            // 
            this.bosLabel1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel1.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.bosLabel1.Appearance.Options.UseBackColor = true;
            this.bosLabel1.Appearance.Options.UseForeColor = true;
            this.bosLabel1.BOSComment = "";
            this.bosLabel1.BOSDataMember = "";
            this.bosLabel1.BOSDataSource = "";
            this.bosLabel1.BOSDescription = null;
            this.bosLabel1.BOSError = null;
            this.bosLabel1.BOSFieldGroup = "";
            this.bosLabel1.BOSFieldRelation = "";
            this.bosLabel1.BOSPrivilege = "";
            this.bosLabel1.BOSPropertyName = "";
            this.bosLabel1.Location = new System.Drawing.Point(12, 504);
            this.bosLabel1.Name = "bosLabel1";
            this.bosLabel1.Screen = null;
            this.bosLabel1.Size = new System.Drawing.Size(295, 13);
            this.bosLabel1.TabIndex = 20;
            this.bosLabel1.Tag = "";
            this.bosLabel1.Text = "Điều kiện: Mã, họ tên, số điện thoại, số CMND của bệnh nhân";
            // 
            // guiSearchPatient
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(884, 529);
            this.ControlBox = true;
            this.Controls.Add(this.bosLabel1);
            this.Controls.Add(this.fld_grdPatientSearchLocalResult);
            this.Controls.Add(this.fld_tbnSearchPatient);
            this.Controls.Add(this.fld_txtSearchCriteria);
            this.Controls.Add(this.fld_btn_Ok);
            this.Controls.Add(this.fld_btn_Cancel);
            this.Controls.Add(this.fld_lblLabel9);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiSearchPatient";
            this.Text = "Tìm bệnh nhân";
            this.Load += new System.EventHandler(this.DSMEEMR100_Load);
            this.Controls.SetChildIndex(this.fld_lblLabel9, 0);
            this.Controls.SetChildIndex(this.fld_btn_Cancel, 0);
            this.Controls.SetChildIndex(this.fld_btn_Ok, 0);
            this.Controls.SetChildIndex(this.fld_txtSearchCriteria, 0);
            this.Controls.SetChildIndex(this.fld_tbnSearchPatient, 0);
            this.Controls.SetChildIndex(this.fld_grdPatientSearchLocalResult, 0);
            this.Controls.SetChildIndex(this.bosLabel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_grdPatientSearchLocalResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private IContainer components;
        private DevExpress.XtraEditors.SimpleButton fld_btn_Cancel;
        private DevExpress.XtraEditors.SimpleButton fld_btn_Ok;
        private TextBox fld_txtSearchCriteria;
        private DevExpress.XtraEditors.SimpleButton fld_tbnSearchPatient;
        private BOSGridControl fld_grdPatientSearchLocalResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private BOSComponent.BOSLabel bosLabel1;
    }
}
