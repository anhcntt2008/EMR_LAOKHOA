using DevExpress.XtraEditors;
using DevExpress.XtraTab;

namespace BOSERP.Modules.METemplate.UI
{
    partial class DMMETE102
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DMMETE102));
            this.galleryDropDown1 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
            this.richEditBarController1 = new DevExpress.XtraRichEdit.UI.RichEditBarController(this.components);
            this.contentPanel = new BOSComponent.BOSPanel(this.components);
            this.btnConfigChart = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveChartSeries = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditChartSeries = new DevExpress.XtraEditors.SimpleButton();
            this.fld_dgcMETemplateChartSeries = new BOSERP.Modules.METemplate.METemplateChartSeriesGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.fld_dgcMETemplateCharts = new BOSERP.Modules.METemplate.METemplateChartsGridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnClearConfig = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.galleryDropDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.richEditBarController1)).BeginInit();
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMETemplateChartSeries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMETemplateCharts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // galleryDropDown1
            // 
            this.galleryDropDown1.Manager = null;
            this.galleryDropDown1.Name = "galleryDropDown1";
            // 
            // contentPanel
            // 
            this.contentPanel.BOSComment = null;
            this.contentPanel.BOSDataMember = null;
            this.contentPanel.BOSDataSource = null;
            this.contentPanel.BOSDescription = null;
            this.contentPanel.BOSError = null;
            this.contentPanel.BOSFieldGroup = null;
            this.contentPanel.BOSFieldRelation = null;
            this.contentPanel.BOSPrivilege = null;
            this.contentPanel.BOSPropertyName = null;
            this.contentPanel.Controls.Add(this.btnClearConfig);
            this.contentPanel.Controls.Add(this.btnConfigChart);
            this.contentPanel.Controls.Add(this.btnSaveChartSeries);
            this.contentPanel.Controls.Add(this.btnEditChartSeries);
            this.contentPanel.Controls.Add(this.fld_dgcMETemplateChartSeries);
            this.contentPanel.Controls.Add(this.fld_dgcMETemplateCharts);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Screen = null;
            this.contentPanel.Size = new System.Drawing.Size(890, 729);
            this.contentPanel.TabIndex = 8;
            // 
            // btnConfigChart
            // 
            this.btnConfigChart.Location = new System.Drawing.Point(12, 11);
            this.btnConfigChart.Name = "btnConfigChart";
            this.btnConfigChart.Size = new System.Drawing.Size(109, 23);
            this.btnConfigChart.TabIndex = 77;
            this.btnConfigChart.Text = "Cấu hình biểu đồ";
            this.btnConfigChart.Click += new System.EventHandler(this.btnConfigChart_Click);
            // 
            // btnSaveChartSeries
            // 
            this.btnSaveChartSeries.Location = new System.Drawing.Point(127, 274);
            this.btnSaveChartSeries.Name = "btnSaveChartSeries";
            this.btnSaveChartSeries.Size = new System.Drawing.Size(75, 23);
            this.btnSaveChartSeries.TabIndex = 76;
            this.btnSaveChartSeries.Text = "Lưu Series";
            this.btnSaveChartSeries.Click += new System.EventHandler(this.btnSaveChartSeries_Click);
            // 
            // btnEditChartSeries
            // 
            this.btnEditChartSeries.Location = new System.Drawing.Point(12, 274);
            this.btnEditChartSeries.Name = "btnEditChartSeries";
            this.btnEditChartSeries.Size = new System.Drawing.Size(109, 23);
            this.btnEditChartSeries.TabIndex = 75;
            this.btnEditChartSeries.Text = "Chỉnh sửa Series";
            this.btnEditChartSeries.Click += new System.EventHandler(this.btnEditChartSeries_Click);
            // 
            // fld_dgcMETemplateChartSeries
            // 
            this.fld_dgcMETemplateChartSeries.AllowDrop = true;
            this.fld_dgcMETemplateChartSeries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcMETemplateChartSeries.BOSComment = "";
            this.fld_dgcMETemplateChartSeries.BOSDataMember = "";
            this.fld_dgcMETemplateChartSeries.BOSDataSource = "METemplateChartSeries";
            this.fld_dgcMETemplateChartSeries.BOSDescription = null;
            this.fld_dgcMETemplateChartSeries.BOSError = null;
            this.fld_dgcMETemplateChartSeries.BOSFieldGroup = "";
            this.fld_dgcMETemplateChartSeries.BOSFieldRelation = "";
            this.fld_dgcMETemplateChartSeries.BOSGridType = null;
            this.fld_dgcMETemplateChartSeries.BOSPrivilege = "";
            this.fld_dgcMETemplateChartSeries.BOSPropertyName = "";
            this.fld_dgcMETemplateChartSeries.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMETemplateChartSeries.Location = new System.Drawing.Point(0, 303);
            this.fld_dgcMETemplateChartSeries.MainView = this.gridView1;
            this.fld_dgcMETemplateChartSeries.Name = "fld_dgcMETemplateChartSeries";
            this.fld_dgcMETemplateChartSeries.PrintReport = false;
            this.fld_dgcMETemplateChartSeries.Screen = null;
            this.fld_dgcMETemplateChartSeries.Size = new System.Drawing.Size(890, 423);
            this.fld_dgcMETemplateChartSeries.TabIndex = 74;
            this.fld_dgcMETemplateChartSeries.Tag = "DC";
            this.fld_dgcMETemplateChartSeries.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.fld_dgcMETemplateChartSeries;
            this.gridView1.Name = "gridView1";
            this.gridView1.PaintStyleName = "Office2003";
            // 
            // fld_dgcMETemplateCharts
            // 
            this.fld_dgcMETemplateCharts.AllowDrop = true;
            this.fld_dgcMETemplateCharts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_dgcMETemplateCharts.BOSComment = "";
            this.fld_dgcMETemplateCharts.BOSDataMember = "";
            this.fld_dgcMETemplateCharts.BOSDataSource = "METemplateCharts";
            this.fld_dgcMETemplateCharts.BOSDescription = null;
            this.fld_dgcMETemplateCharts.BOSError = null;
            this.fld_dgcMETemplateCharts.BOSFieldGroup = "";
            this.fld_dgcMETemplateCharts.BOSFieldRelation = "";
            this.fld_dgcMETemplateCharts.BOSGridType = null;
            this.fld_dgcMETemplateCharts.BOSPrivilege = "";
            this.fld_dgcMETemplateCharts.BOSPropertyName = "";
            this.fld_dgcMETemplateCharts.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.fld_dgcMETemplateCharts.Location = new System.Drawing.Point(0, 43);
            this.fld_dgcMETemplateCharts.MainView = this.gridView2;
            this.fld_dgcMETemplateCharts.Name = "fld_dgcMETemplateCharts";
            this.fld_dgcMETemplateCharts.PrintReport = false;
            this.fld_dgcMETemplateCharts.Screen = null;
            this.fld_dgcMETemplateCharts.Size = new System.Drawing.Size(890, 225);
            this.fld_dgcMETemplateCharts.TabIndex = 73;
            this.fld_dgcMETemplateCharts.Tag = "DC";
            this.fld_dgcMETemplateCharts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.fld_dgcMETemplateCharts;
            this.gridView2.Name = "gridView2";
            this.gridView2.PaintStyleName = "Office2003";
            // 
            // btnClearConfig
            // 
            this.btnClearConfig.Location = new System.Drawing.Point(127, 11);
            this.btnClearConfig.Name = "btnClearConfig";
            this.btnClearConfig.Size = new System.Drawing.Size(109, 23);
            this.btnClearConfig.TabIndex = 78;
            this.btnClearConfig.Text = "Xóa cấu hình";
            this.btnClearConfig.Click += new System.EventHandler(this.btnClearConfig_Click);
            // 
            // DMMETE102
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 729);
            this.Controls.Add(this.contentPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DMMETE102";
            this.ScreenNumber = "DMMETE102";
            this.Text = "Cấu hình biểu đồ";
            this.Controls.SetChildIndex(this.contentPanel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.galleryDropDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.richEditBarController1)).EndInit();
            this.contentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMETemplateChartSeries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_dgcMETemplateCharts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraRichEdit.UI.RichEditBarController richEditBarController1;
        private BOSComponent.BOSPanel contentPanel;
        private DevExpress.XtraBars.Ribbon.GalleryDropDown galleryDropDown1;
        private METemplateChartSeriesGridControl fld_dgcMETemplateChartSeries;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private METemplateChartsGridControl fld_dgcMETemplateCharts;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private SimpleButton btnConfigChart;
        private SimpleButton btnSaveChartSeries;
        private SimpleButton btnEditChartSeries;
        private SimpleButton btnClearConfig;
    }
}