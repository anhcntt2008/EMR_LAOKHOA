using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP.Modules.MEParamLookup.UI
{
    /// <summary>
    /// Summary description for SMMEPL100
    /// </summary>
    partial class SMMEPL100
    {
        private BOSComponent.BOSTextBox fld_txtMEParamLookupNo;
        private BOSComponent.BOSTextBox fld_txtMEParamLookupName;
        private BOSComponent.BOSLabel fld_lblLabel;
        private BOSComponent.BOSLabel fld_lblLabel1;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvin;
        private BOSSearchResultsGridControl fld_dgcMEParamLookups;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvMEParamLookups;


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMMEPL100));
            this.fld_txtMEParamLookupNo = new BOSComponent.BOSTextBox(this.components);
            this.fld_txtMEParamLookupName = new BOSComponent.BOSTextBox(this.components);
            this.fld_lblLabel = new BOSComponent.BOSLabel(this.components);
            this.fld_lblLabel1 = new BOSComponent.BOSLabel(this.components);
            this.fld_dgvin = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_dgcMEParamLookups = new BOSERP.BOSSearchResultsGridControl(this.components);
            this.fld_dgvMEParamLookups = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamLookupNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamLookupName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEParamLookups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEParamLookups)).BeginInit();
            this.SuspendLayout();
            // 
            // fld_txtMEParamLookupNo
            // 
            this.fld_txtMEParamLookupNo.BOSComment = "";
            this.fld_txtMEParamLookupNo.BOSDataMember = "MEParamLookupNo";
            this.fld_txtMEParamLookupNo.BOSDataSource = "MEParamLookups";
            this.fld_txtMEParamLookupNo.BOSDescription = null;
            this.fld_txtMEParamLookupNo.BOSError = null;
            this.fld_txtMEParamLookupNo.BOSFieldGroup = "";
            this.fld_txtMEParamLookupNo.BOSFieldRelation = "";
            this.fld_txtMEParamLookupNo.BOSPrivilege = "";
            this.fld_txtMEParamLookupNo.BOSPropertyName = "Text";
            this.fld_txtMEParamLookupNo.EditValue = "";
            this.fld_txtMEParamLookupNo.Location = new System.Drawing.Point(53, 13);
            this.fld_txtMEParamLookupNo.Name = "fld_txtMEParamLookupNo";
            this.fld_txtMEParamLookupNo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEParamLookupNo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEParamLookupNo.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEParamLookupNo.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEParamLookupNo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEParamLookupNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEParamLookupNo.Screen = null;
            this.fld_txtMEParamLookupNo.Size = new System.Drawing.Size(374, 20);
            this.fld_txtMEParamLookupNo.TabIndex = 4;
            this.fld_txtMEParamLookupNo.Tag = "SC";
            // 
            // fld_txtMEParamLookupName
            // 
            this.fld_txtMEParamLookupName.BOSComment = "";
            this.fld_txtMEParamLookupName.BOSDataMember = "MEParamLookupName";
            this.fld_txtMEParamLookupName.BOSDataSource = "MEParamLookups";
            this.fld_txtMEParamLookupName.BOSDescription = null;
            this.fld_txtMEParamLookupName.BOSError = null;
            this.fld_txtMEParamLookupName.BOSFieldGroup = "";
            this.fld_txtMEParamLookupName.BOSFieldRelation = "";
            this.fld_txtMEParamLookupName.BOSPrivilege = "";
            this.fld_txtMEParamLookupName.BOSPropertyName = "Text";
            this.fld_txtMEParamLookupName.EditValue = "";
            this.fld_txtMEParamLookupName.Location = new System.Drawing.Point(53, 39);
            this.fld_txtMEParamLookupName.Name = "fld_txtMEParamLookupName";
            this.fld_txtMEParamLookupName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_txtMEParamLookupName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_txtMEParamLookupName.Properties.Appearance.Options.UseBackColor = true;
            this.fld_txtMEParamLookupName.Properties.Appearance.Options.UseForeColor = true;
            this.fld_txtMEParamLookupName.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.fld_txtMEParamLookupName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fld_txtMEParamLookupName.Screen = null;
            this.fld_txtMEParamLookupName.Size = new System.Drawing.Size(373, 20);
            this.fld_txtMEParamLookupName.TabIndex = 5;
            this.fld_txtMEParamLookupName.Tag = "SC";
            // 
            // fld_lblLabel
            // 
            this.fld_lblLabel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel.BOSComment = "";
            this.fld_lblLabel.BOSDataMember = "";
            this.fld_lblLabel.BOSDataSource = "";
            this.fld_lblLabel.BOSDescription = null;
            this.fld_lblLabel.BOSError = null;
            this.fld_lblLabel.BOSFieldGroup = "";
            this.fld_lblLabel.BOSFieldRelation = "";
            this.fld_lblLabel.BOSPrivilege = "";
            this.fld_lblLabel.BOSPropertyName = "";
            this.fld_lblLabel.Location = new System.Drawing.Point(20, 20);
            this.fld_lblLabel.Name = "fld_lblLabel";
            this.fld_lblLabel.Screen = null;
            this.fld_lblLabel.Size = new System.Drawing.Size(14, 13);
            this.fld_lblLabel.TabIndex = 7;
            this.fld_lblLabel.Tag = "SI";
            this.fld_lblLabel.Text = "Mã";
            // 
            // fld_lblLabel1
            // 
            this.fld_lblLabel1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lblLabel1.Appearance.Options.UseBackColor = true;
            this.fld_lblLabel1.Appearance.Options.UseForeColor = true;
            this.fld_lblLabel1.BOSComment = "";
            this.fld_lblLabel1.BOSDataMember = "";
            this.fld_lblLabel1.BOSDataSource = "";
            this.fld_lblLabel1.BOSDescription = null;
            this.fld_lblLabel1.BOSError = null;
            this.fld_lblLabel1.BOSFieldGroup = "";
            this.fld_lblLabel1.BOSFieldRelation = "";
            this.fld_lblLabel1.BOSPrivilege = "";
            this.fld_lblLabel1.BOSPropertyName = "";
            this.fld_lblLabel1.Location = new System.Drawing.Point(19, 44);
            this.fld_lblLabel1.Name = "fld_lblLabel1";
            this.fld_lblLabel1.Screen = null;
            this.fld_lblLabel1.Size = new System.Drawing.Size(18, 13);
            this.fld_lblLabel1.TabIndex = 8;
            this.fld_lblLabel1.Tag = "SI";
            this.fld_lblLabel1.Text = "Tên";
            // 
            // fld_dgvin
            // 
            this.fld_dgvin.Name = "fld_dgvin";
            this.fld_dgvin.PaintStyleName = "Office2003";
            // 
            // fld_dgcMEParamLookups
            // 
            this.fld_dgcMEParamLookups.AllowDrop = true;
            this.fld_dgcMEParamLookups.BOSComment = "";
            this.fld_dgcMEParamLookups.BOSDataMember = "";
            this.fld_dgcMEParamLookups.BOSDataSource = "MEParamLookups";
            this.fld_dgcMEParamLookups.BOSDescription = null;
            this.fld_dgcMEParamLookups.BOSError = null;
            this.fld_dgcMEParamLookups.BOSFieldGroup = "";
            this.fld_dgcMEParamLookups.BOSFieldRelation = "";
            this.fld_dgcMEParamLookups.BOSPrivilege = "";
            this.fld_dgcMEParamLookups.BOSPropertyName = "";
            this.fld_dgcMEParamLookups.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMEParamLookups.Location = new System.Drawing.Point(36, 109);
            this.fld_dgcMEParamLookups.MainView = this.fld_dgvMEParamLookups;
            this.fld_dgcMEParamLookups.Name = "fld_dgcMEParamLookups";
            this.fld_dgcMEParamLookups.Screen = null;
            this.fld_dgcMEParamLookups.Size = new System.Drawing.Size(400, 200);
            this.fld_dgcMEParamLookups.TabIndex = 10;
            this.fld_dgcMEParamLookups.Tag = "SR";
            this.fld_dgcMEParamLookups.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvMEParamLookups});
            // 
            // fld_dgvMEParamLookups
            // 
            this.fld_dgvMEParamLookups.GridControl = this.fld_dgcMEParamLookups;
            this.fld_dgvMEParamLookups.Name = "fld_dgvMEParamLookups";
            this.fld_dgvMEParamLookups.PaintStyleName = "Office2003";
            // 
            // SMMEPL100
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(488, 351);
            this.Controls.Add(this.fld_txtMEParamLookupNo);
            this.Controls.Add(this.fld_txtMEParamLookupName);
            this.Controls.Add(this.fld_lblLabel);
            this.Controls.Add(this.fld_lblLabel1);
            this.Controls.Add(this.fld_dgcMEParamLookups);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SMMEPL100";
            this.ScreenNumber = "SMMEPL100";
            this.Tag = "SM";
            this.Text = "Tìm Kiếm";
            this.Controls.SetChildIndex(this.fld_dgcMEParamLookups, 0);
            this.Controls.SetChildIndex(this.fld_lblLabel1, 0);
            this.Controls.SetChildIndex(this.fld_lblLabel, 0);
            this.Controls.SetChildIndex(this.fld_txtMEParamLookupName, 0);
            this.Controls.SetChildIndex(this.fld_txtMEParamLookupNo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamLookupNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_txtMEParamLookupName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMEParamLookups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvMEParamLookups)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private IContainer components;
    }
}
