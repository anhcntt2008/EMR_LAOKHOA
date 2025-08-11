using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.MEEmr.UI
{
    partial class guiMETemplateParams
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiMETemplateParams));
            this.fld_dgcMETemplateParams = new BOSERP.Modules.MEEmr.METemplateParamsGridControl();
            this.fld_dgvMETemplateParams = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMETemplateParams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMETemplateParams)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_dgcMETemplateParams
            // 
            this.fld_dgcMETemplateParams.AllowDrop = true;
            this.fld_dgcMETemplateParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcMETemplateParams.BOSComment = "";
            this.fld_dgcMETemplateParams.BOSDataMember = "";
            this.fld_dgcMETemplateParams.BOSDataSource = "METemplateParams";
            this.fld_dgcMETemplateParams.BOSDescription = null;
            this.fld_dgcMETemplateParams.BOSError = null;
            this.fld_dgcMETemplateParams.BOSFieldGroup = "";
            this.fld_dgcMETemplateParams.BOSFieldRelation = "";
            this.fld_dgcMETemplateParams.BOSGridType = null;
            this.fld_dgcMETemplateParams.BOSPrivilege = "";
            this.fld_dgcMETemplateParams.BOSPropertyName = "";
            this.fld_dgcMETemplateParams.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMETemplateParams.Location = new System.Drawing.Point(2, 2);
            this.fld_dgcMETemplateParams.MainView = this.fld_dgvMETemplateParams;
            this.fld_dgcMETemplateParams.Name = "fld_dgcMETemplateParams";
            this.fld_dgcMETemplateParams.PrintReport = false;
            this.fld_dgcMETemplateParams.Screen = null;
            this.fld_dgcMETemplateParams.Size = new System.Drawing.Size(933, 350);
            this.fld_dgcMETemplateParams.TabIndex = 15;
            this.fld_dgcMETemplateParams.Tag = "DC";
            this.fld_dgcMETemplateParams.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvMETemplateParams});
            // 
            // fld_dgvMETemplateParams
            // 
            this.fld_dgvMETemplateParams.GridControl = this.fld_dgcMETemplateParams;
            this.fld_dgvMETemplateParams.Name = "fld_dgvMETemplateParams";
            this.fld_dgvMETemplateParams.PaintStyleName = "Office2003";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.Location = new System.Drawing.Point(863, 361);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(72, 23);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "Đóng";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // guiMETemplateParams
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(937, 393);
            this.ControlBox = true;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.fld_dgcMETemplateParams);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiMETemplateParams";
            this.Load += new System.EventHandler(this.guiMETemplateParams_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.guiMETemplateParams_PreviewKeyDown);
            this.Controls.SetChildIndex(this.fld_dgcMETemplateParams, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMETemplateParams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMETemplateParams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private IContainer components;
        private METemplateParamsGridControl fld_dgcMETemplateParams;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvMETemplateParams;
        private DevExpress.XtraEditors.SimpleButton btnOk;
    }
}
