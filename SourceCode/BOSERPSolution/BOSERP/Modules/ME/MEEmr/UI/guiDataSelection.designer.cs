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
    partial class guiDataSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiDataSelection));
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.treeListData = new DevExpress.XtraTreeList.TreeList();
            this.chkSelectedAll = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectedAll.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnOk.Location = new System.Drawing.Point(858, 633);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(91, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK  (Alt+O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(955, 633);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // treeListData
            // 
            this.treeListData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeListData.DataSource = null;
            this.treeListData.Location = new System.Drawing.Point(0, 0);
            this.treeListData.Name = "treeListData";
            this.treeListData.Size = new System.Drawing.Size(1033, 630);
            this.treeListData.TabIndex = 9;
            this.treeListData.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.treeListData_CustomDrawNodeCell);
            this.treeListData.CustomDrawNodeCheckBox += new DevExpress.XtraTreeList.CustomDrawNodeCheckBoxEventHandler(this.treeListData_CustomDrawNodeCheckBox);
            // 
            // chkSelectedAll
            // 
            this.chkSelectedAll.Location = new System.Drawing.Point(12, 637);
            this.chkSelectedAll.MenuManager = this.screenToolbar;
            this.chkSelectedAll.Name = "chkSelectedAll";
            this.chkSelectedAll.Properties.Caption = "Chọn tất cả";
            this.chkSelectedAll.Size = new System.Drawing.Size(75, 19);
            this.chkSelectedAll.TabIndex = 10;
            this.chkSelectedAll.CheckedChanged += new System.EventHandler(this.chkSelectedAll_CheckedChanged);
            // 
            // guiDataSelection
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(1032, 661);
            this.ControlBox = true;
            this.Controls.Add(this.chkSelectedAll);
            this.Controls.Add(this.treeListData);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiDataSelection";
            this.Text = "Chọn dữ liệu";
            this.Load += new System.EventHandler(this.DSMEEMR100_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DSMEEMR106_KeyPress);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.DSMEEMR106_PreviewKeyDown);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.treeListData, 0);
            this.Controls.SetChildIndex(this.chkSelectedAll, 0);
            ((System.ComponentModel.ISupportInitialize)(this.treeListData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectedAll.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private IContainer components;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraTreeList.TreeList treeListData;
        private DevExpress.XtraEditors.CheckEdit chkSelectedAll;
    }
}
