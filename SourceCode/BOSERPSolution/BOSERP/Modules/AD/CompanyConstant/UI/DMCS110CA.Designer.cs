namespace BOSERP.Modules.CompanyConstant.UI
{
    partial class DMCS110CA

    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMCS110CA));
            this.bosPanel1 = new BOSComponent.BOSPanel(this.components);
            this.bosLabel20 = new BOSComponent.BOSLabel(this.components);
            this.fld_lkeCaProvider = new BOSComponent.BOSLookupEdit(this.components);
            this.fld_dgcCaConfigs = new BOSERP.Modules.CompanyConstant.CaConfigsGridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bosPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeCaProvider.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcCaConfigs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
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
            this.bosPanel1.Controls.Add(this.bosLabel20);
            this.bosPanel1.Controls.Add(this.fld_lkeCaProvider);
            this.bosPanel1.Controls.Add(this.fld_dgcCaConfigs);
            this.bosPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bosPanel1.Location = new System.Drawing.Point(0, 0);
            this.bosPanel1.Name = "bosPanel1";
            this.bosPanel1.Screen = null;
            this.bosPanel1.Size = new System.Drawing.Size(615, 486);
            this.bosPanel1.TabIndex = 7;
            // 
            // bosLabel20
            // 
            this.bosLabel20.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel20.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel20.Appearance.Options.UseBackColor = true;
            this.bosLabel20.Appearance.Options.UseForeColor = true;
            this.bosLabel20.BOSComment = "";
            this.bosLabel20.BOSDataMember = "";
            this.bosLabel20.BOSDataSource = "";
            this.bosLabel20.BOSDescription = null;
            this.bosLabel20.BOSError = null;
            this.bosLabel20.BOSFieldGroup = "";
            this.bosLabel20.BOSFieldRelation = "";
            this.bosLabel20.BOSPrivilege = "";
            this.bosLabel20.BOSPropertyName = null;
            this.bosLabel20.Location = new System.Drawing.Point(15, 15);
            this.bosLabel20.Name = "bosLabel20";
            this.bosLabel20.Screen = null;
            this.bosLabel20.Size = new System.Drawing.Size(114, 13);
            this.bosLabel20.TabIndex = 537;
            this.bosLabel20.Tag = "";
            this.bosLabel20.Text = "Nhà cung cấp chữ ký số";
            // 
            // fld_lkeCaProvider
            // 
            this.fld_lkeCaProvider.BOSAllowAddNew = false;
            this.fld_lkeCaProvider.BOSAllowDummy = false;
            this.fld_lkeCaProvider.BOSComment = "";
            this.fld_lkeCaProvider.BOSDataMember = "CSCompanyCaProvider";
            this.fld_lkeCaProvider.BOSDataSource = "CSCompanys";
            this.fld_lkeCaProvider.BOSDescription = null;
            this.fld_lkeCaProvider.BOSDummyText = null;
            this.fld_lkeCaProvider.BOSError = "";
            this.fld_lkeCaProvider.BOSFieldGroup = "";
            this.fld_lkeCaProvider.BOSFieldParent = "";
            this.fld_lkeCaProvider.BOSFieldRelation = "";
            this.fld_lkeCaProvider.BOSPrivilege = "";
            this.fld_lkeCaProvider.BOSPropertyName = "EditValue";
            this.fld_lkeCaProvider.BOSSelectType = "";
            this.fld_lkeCaProvider.BOSSelectTypeValue = "";
            this.fld_lkeCaProvider.CurrentDisplayText = "";
            this.fld_lkeCaProvider.Location = new System.Drawing.Point(145, 12);
            this.fld_lkeCaProvider.Name = "fld_lkeCaProvider";
            this.fld_lkeCaProvider.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fld_lkeCaProvider.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fld_lkeCaProvider.Properties.Appearance.Options.UseBackColor = true;
            this.fld_lkeCaProvider.Properties.Appearance.Options.UseForeColor = true;
            this.fld_lkeCaProvider.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_lkeCaProvider.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ICStockNo", "Mã kho", 20, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ICStockName", "Tên kho")});
            this.fld_lkeCaProvider.Properties.DisplayMember = "ICStockName";
            this.fld_lkeCaProvider.Properties.NullText = "";
            this.fld_lkeCaProvider.Properties.PopupWidth = 40;
            this.fld_lkeCaProvider.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.fld_lkeCaProvider.Properties.ValueMember = "ICStockID";
            this.fld_lkeCaProvider.Screen = null;
            this.fld_lkeCaProvider.Size = new System.Drawing.Size(208, 20);
            this.fld_lkeCaProvider.TabIndex = 536;
            this.fld_lkeCaProvider.Tag = "DC";
            this.fld_lkeCaProvider.EditValueChanged += new System.EventHandler(this.fld_lkeCaProvider_EditValueChanged);
            // 
            // fld_dgcCaConfigs
            // 
            this.fld_dgcCaConfigs.AllowDrop = true;
            this.fld_dgcCaConfigs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcCaConfigs.BOSComment = "";
            this.fld_dgcCaConfigs.BOSDataMember = null;
            this.fld_dgcCaConfigs.BOSDataSource = "ADSystemConfigs";
            this.fld_dgcCaConfigs.BOSDescription = null;
            this.fld_dgcCaConfigs.BOSError = "";
            this.fld_dgcCaConfigs.BOSFieldGroup = "";
            this.fld_dgcCaConfigs.BOSFieldRelation = null;
            this.fld_dgcCaConfigs.BOSGridType = null;
            this.fld_dgcCaConfigs.BOSPrivilege = "";
            this.fld_dgcCaConfigs.BOSPropertyName = null;
            this.fld_dgcCaConfigs.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcCaConfigs.Location = new System.Drawing.Point(12, 38);
            this.fld_dgcCaConfigs.MainView = this.gridView2;
            this.fld_dgcCaConfigs.MinimumSize = new System.Drawing.Size(0, 7);
            this.fld_dgcCaConfigs.Name = "fld_dgcCaConfigs";
            this.fld_dgcCaConfigs.PrintReport = false;
            this.fld_dgcCaConfigs.Screen = null;
            this.fld_dgcCaConfigs.Size = new System.Drawing.Size(591, 436);
            this.fld_dgcCaConfigs.TabIndex = 75;
            this.fld_dgcCaConfigs.Tag = "DC";
            this.fld_dgcCaConfigs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.fld_dgcCaConfigs;
            this.gridView2.Name = "gridView2";
            this.gridView2.PaintStyleName = "Office2003";
            // 
            // DMCS110CA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 486);
            this.Controls.Add(this.bosPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DMCS110CA";
            this.ScreenNumber = "DMCS107";
            this.Tag = "DM";
            this.Text = "Cấu hình chữ ký số - CA";
            this.Controls.SetChildIndex(this.bosPanel1, 0);
            this.bosPanel1.ResumeLayout(false);
            this.bosPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_lkeCaProvider.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcCaConfigs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BOSComponent.BOSPanel bosPanel1;
        private CaConfigsGridControl fld_dgcCaConfigs;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private BOSComponent.BOSLookupEdit fld_lkeCaProvider;
        private BOSComponent.BOSLabel bosLabel20;
    }
}