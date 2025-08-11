namespace BOSERP.Modules.CompanyConstant.UI
{
    partial class DMCS109

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMCS109));
            this.bosPanel1 = new BOSComponent.BOSPanel();
            this.bosLabel1 = new BOSComponent.BOSLabel();
            this.fld_dgcReportTypeConfigValues = new BOSERP.Modules.CompanyConstant.ReportTypeConfigValuesGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bosLabel2 = new BOSComponent.BOSLabel();
            this.fld_dgcReportDataSourceConfigValues = new BOSERP.Modules.CompanyConstant.ReportDataSourceConfigValuesGridControl();
            this.fld_dgvPriceLevel = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_btnTestConnection = new BOSComponent.BOSButton();
            this.bosPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcReportTypeConfigValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcReportDataSourceConfigValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvPriceLevel)).BeginInit();
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
            this.bosPanel1.Controls.Add(this.fld_btnTestConnection);
            this.bosPanel1.Controls.Add(this.bosLabel1);
            this.bosPanel1.Controls.Add(this.fld_dgcReportTypeConfigValues);
            this.bosPanel1.Controls.Add(this.bosLabel2);
            this.bosPanel1.Controls.Add(this.fld_dgcReportDataSourceConfigValues);
            this.bosPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bosPanel1.Location = new System.Drawing.Point(0, 0);
            this.bosPanel1.Name = "bosPanel1";
            this.bosPanel1.Screen = null;
            this.bosPanel1.Size = new System.Drawing.Size(934, 517);
            this.bosPanel1.TabIndex = 7;
            // 
            // bosLabel1
            // 
            this.bosLabel1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.bosLabel1.Location = new System.Drawing.Point(12, 5);
            this.bosLabel1.Name = "bosLabel1";
            this.bosLabel1.Screen = null;
            this.bosLabel1.Size = new System.Drawing.Size(68, 13);
            this.bosLabel1.TabIndex = 73;
            this.bosLabel1.Tag = "";
            this.bosLabel1.Text = "Nhóm báo cáo";
            // 
            // fld_dgcReportTypeConfigValues
            // 
            this.fld_dgcReportTypeConfigValues.AllowDrop = true;
            this.fld_dgcReportTypeConfigValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcReportTypeConfigValues.BOSComment = "";
            this.fld_dgcReportTypeConfigValues.BOSDataMember = null;
            this.fld_dgcReportTypeConfigValues.BOSDataSource = "ADConfigValues";
            this.fld_dgcReportTypeConfigValues.BOSDescription = null;
            this.fld_dgcReportTypeConfigValues.BOSError = "";
            this.fld_dgcReportTypeConfigValues.BOSFieldGroup = "";
            this.fld_dgcReportTypeConfigValues.BOSFieldRelation = null;
            this.fld_dgcReportTypeConfigValues.BOSGridType = null;
            this.fld_dgcReportTypeConfigValues.BOSPrivilege = "";
            this.fld_dgcReportTypeConfigValues.BOSPropertyName = null;
            this.fld_dgcReportTypeConfigValues.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcReportTypeConfigValues.Location = new System.Drawing.Point(12, 24);
            this.fld_dgcReportTypeConfigValues.MainView = this.gridView1;
            this.fld_dgcReportTypeConfigValues.MinimumSize = new System.Drawing.Size(0, 7);
            this.fld_dgcReportTypeConfigValues.Name = "fld_dgcReportTypeConfigValues";
            this.fld_dgcReportTypeConfigValues.PrintReport = false;
            this.fld_dgcReportTypeConfigValues.Screen = null;
            this.fld_dgcReportTypeConfigValues.Size = new System.Drawing.Size(910, 265);
            this.fld_dgcReportTypeConfigValues.TabIndex = 74;
            this.fld_dgcReportTypeConfigValues.Tag = "DC";
            this.fld_dgcReportTypeConfigValues.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcReportTypeConfigValues;
            this.gridView1.Name = "gridView1";
            this.gridView1.PaintStyleName = "Office2003";
            // 
            // bosLabel2
            // 
            this.bosLabel2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bosLabel2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bosLabel2.Appearance.Options.UseBackColor = true;
            this.bosLabel2.Appearance.Options.UseForeColor = true;
            this.bosLabel2.BOSComment = "";
            this.bosLabel2.BOSDataMember = "";
            this.bosLabel2.BOSDataSource = "";
            this.bosLabel2.BOSDescription = null;
            this.bosLabel2.BOSError = null;
            this.bosLabel2.BOSFieldGroup = "";
            this.bosLabel2.BOSFieldRelation = "";
            this.bosLabel2.BOSPrivilege = "";
            this.bosLabel2.BOSPropertyName = "";
            this.bosLabel2.Location = new System.Drawing.Point(12, 305);
            this.bosLabel2.Name = "bosLabel2";
            this.bosLabel2.Screen = null;
            this.bosLabel2.Size = new System.Drawing.Size(68, 13);
            this.bosLabel2.TabIndex = 63;
            this.bosLabel2.Tag = "";
            this.bosLabel2.Text = "Kết nối dữ liệu";
            // 
            // fld_dgcReportDataSourceConfigValues
            // 
            this.fld_dgcReportDataSourceConfigValues.AllowDrop = true;
            this.fld_dgcReportDataSourceConfigValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcReportDataSourceConfigValues.BOSComment = "";
            this.fld_dgcReportDataSourceConfigValues.BOSDataMember = null;
            this.fld_dgcReportDataSourceConfigValues.BOSDataSource = "ADConfigValues";
            this.fld_dgcReportDataSourceConfigValues.BOSDescription = null;
            this.fld_dgcReportDataSourceConfigValues.BOSError = "";
            this.fld_dgcReportDataSourceConfigValues.BOSFieldGroup = "";
            this.fld_dgcReportDataSourceConfigValues.BOSFieldRelation = null;
            this.fld_dgcReportDataSourceConfigValues.BOSGridType = null;
            this.fld_dgcReportDataSourceConfigValues.BOSPrivilege = "";
            this.fld_dgcReportDataSourceConfigValues.BOSPropertyName = null;
            this.fld_dgcReportDataSourceConfigValues.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcReportDataSourceConfigValues.Location = new System.Drawing.Point(12, 327);
            this.fld_dgcReportDataSourceConfigValues.MainView = this.fld_dgvPriceLevel;
            this.fld_dgcReportDataSourceConfigValues.MinimumSize = new System.Drawing.Size(0, 7);
            this.fld_dgcReportDataSourceConfigValues.Name = "fld_dgcReportDataSourceConfigValues";
            this.fld_dgcReportDataSourceConfigValues.PrintReport = false;
            this.fld_dgcReportDataSourceConfigValues.Screen = null;
            this.fld_dgcReportDataSourceConfigValues.Size = new System.Drawing.Size(910, 178);
            this.fld_dgcReportDataSourceConfigValues.TabIndex = 72;
            this.fld_dgcReportDataSourceConfigValues.Tag = "DC";
            this.fld_dgcReportDataSourceConfigValues.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fld_dgvPriceLevel});
            // 
            // fld_dgvPriceLevel
            // 
            this.fld_dgvPriceLevel.GridControl = this.fld_dgcReportDataSourceConfigValues;
            this.fld_dgvPriceLevel.Name = "fld_dgvPriceLevel";
            this.fld_dgvPriceLevel.PaintStyleName = "Office2003";
            // 
            // fld_btnTestConnection
            // 
            this.fld_btnTestConnection.BOSComment = null;
            this.fld_btnTestConnection.BOSDataMember = null;
            this.fld_btnTestConnection.BOSDataSource = null;
            this.fld_btnTestConnection.BOSDescription = null;
            this.fld_btnTestConnection.BOSError = null;
            this.fld_btnTestConnection.BOSFieldGroup = null;
            this.fld_btnTestConnection.BOSFieldRelation = null;
            this.fld_btnTestConnection.BOSPrivilege = null;
            this.fld_btnTestConnection.BOSPropertyName = null;
            this.fld_btnTestConnection.Location = new System.Drawing.Point(86, 298);
            this.fld_btnTestConnection.Name = "fld_btnTestConnection";
            this.fld_btnTestConnection.Screen = null;
            this.fld_btnTestConnection.Size = new System.Drawing.Size(120, 26);
            this.fld_btnTestConnection.TabIndex = 75;
            this.fld_btnTestConnection.Text = "Kiểm tra kết nối";
            this.fld_btnTestConnection.Click += new System.EventHandler(this.fld_btnTestConnection_Click);
            // 
            // DMCS109
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 517);
            this.Controls.Add(this.bosPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DMCS109";
            this.ScreenNumber = "DMCS107";
            this.Tag = "DM";
            this.Text = "Bệnh án điện tử";
            this.Controls.SetChildIndex(this.bosPanel1, 0);
            this.bosPanel1.ResumeLayout(false);
            this.bosPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcReportTypeConfigValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcReportDataSourceConfigValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgvPriceLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BOSComponent.BOSPanel bosPanel1;
        private ReportDataSourceConfigValuesGridControl fld_dgcReportDataSourceConfigValues;
        private DevExpress.XtraGrid.Views.Grid.GridView fld_dgvPriceLevel;
        private BOSComponent.BOSLabel bosLabel2;
        private BOSComponent.BOSLabel bosLabel1;
        private ReportTypeConfigValuesGridControl fld_dgcReportTypeConfigValues;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private BOSComponent.BOSButton fld_btnTestConnection;
    }
}