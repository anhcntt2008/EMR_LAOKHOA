using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BOSERP
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    partial class guiChartConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(guiChartConfig));
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.fld_Chart = new DevExpress.XtraCharts.ChartControl();
            this.fld_btnEditChart = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.fld_speChartWidth = new DevExpress.XtraEditors.SpinEdit();
            this.fld_speChartHeight = new DevExpress.XtraEditors.SpinEdit();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.btnInsertImage = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.fld_Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_speChartWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_speChartHeight.Properties)).BeginInit();
            this.xtraScrollableControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(744, 390);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(109, 29);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Lưu cấu hình";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(744, 425);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 29);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // fld_Chart
            // 
            this.fld_Chart.Legend.Name = "Default Legend";
            this.fld_Chart.Location = new System.Drawing.Point(3, 0);
            this.fld_Chart.Name = "fld_Chart";
            this.fld_Chart.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.fld_Chart.Size = new System.Drawing.Size(720, 451);
            this.fld_Chart.TabIndex = 9;
            // 
            // fld_btnEditChart
            // 
            this.fld_btnEditChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_btnEditChart.Location = new System.Drawing.Point(747, 83);
            this.fld_btnEditChart.Name = "fld_btnEditChart";
            this.fld_btnEditChart.Size = new System.Drawing.Size(109, 30);
            this.fld_btnEditChart.TabIndex = 1;
            this.fld_btnEditChart.Text = "Chỉnh sửa biểu đồ";
            this.fld_btnEditChart.Click += new System.EventHandler(this.fld_btnEditChart_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(747, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Chiều rộng";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Location = new System.Drawing.Point(747, 47);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "Chiều cao";
            // 
            // fld_speChartWidth
            // 
            this.fld_speChartWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_speChartWidth.EditValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.fld_speChartWidth.Location = new System.Drawing.Point(805, 12);
            this.fld_speChartWidth.MenuManager = this.screenToolbar;
            this.fld_speChartWidth.Name = "fld_speChartWidth";
            this.fld_speChartWidth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_speChartWidth.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.fld_speChartWidth.Properties.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.fld_speChartWidth.Properties.IsFloatValue = false;
            this.fld_speChartWidth.Properties.Mask.EditMask = "N00";
            this.fld_speChartWidth.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.fld_speChartWidth.Properties.MaxValue = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.fld_speChartWidth.Properties.MinValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.fld_speChartWidth.Size = new System.Drawing.Size(48, 20);
            this.fld_speChartWidth.TabIndex = 2;
            this.fld_speChartWidth.EditValueChanged += new System.EventHandler(this.fld_speChartWidth_EditValueChanged);
            // 
            // fld_speChartHeight
            // 
            this.fld_speChartHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fld_speChartHeight.EditValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.fld_speChartHeight.Location = new System.Drawing.Point(805, 44);
            this.fld_speChartHeight.MenuManager = this.screenToolbar;
            this.fld_speChartHeight.Name = "fld_speChartHeight";
            this.fld_speChartHeight.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fld_speChartHeight.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.fld_speChartHeight.Properties.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.fld_speChartHeight.Properties.IsFloatValue = false;
            this.fld_speChartHeight.Properties.Mask.EditMask = "N00";
            this.fld_speChartHeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.fld_speChartHeight.Properties.MaxValue = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.fld_speChartHeight.Properties.MinValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.fld_speChartHeight.Size = new System.Drawing.Size(48, 20);
            this.fld_speChartHeight.TabIndex = 3;
            this.fld_speChartHeight.EditValueChanged += new System.EventHandler(this.fld_speChartHeight_EditValueChanged);
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraScrollableControl1.Controls.Add(this.fld_Chart);
            this.xtraScrollableControl1.Location = new System.Drawing.Point(3, 2);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(738, 473);
            this.xtraScrollableControl1.TabIndex = 16;
            // 
            // btnInsertImage
            // 
            this.btnInsertImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsertImage.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnInsertImage.Appearance.Options.UseFont = true;
            this.btnInsertImage.Location = new System.Drawing.Point(747, 119);
            this.btnInsertImage.Name = "btnInsertImage";
            this.btnInsertImage.Size = new System.Drawing.Size(109, 29);
            this.btnInsertImage.TabIndex = 0;
            this.btnInsertImage.Text = "Chèn vào tài liệu";
            this.btnInsertImage.Click += new System.EventHandler(this.btnInsertImage_Click);
            // 
            // guiChartConfig
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Appearance.Options.UseForeColor = true;
            this.ClientSize = new System.Drawing.Size(865, 478);
            this.ControlBox = true;
            this.Controls.Add(this.btnInsertImage);
            this.Controls.Add(this.xtraScrollableControl1);
            this.Controls.Add(this.fld_speChartHeight);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.fld_btnEditChart);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.fld_speChartWidth);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "guiChartConfig";
            this.Text = "Biểu đồ";
            this.Activated += new System.EventHandler(this.guiChartConfig_Activated);
            this.Load += new System.EventHandler(this.DSMEEMR100_Load);
            this.Shown += new System.EventHandler(this.guiChartConfig_Shown);
            this.Controls.SetChildIndex(this.fld_speChartWidth, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.fld_btnEditChart, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            this.Controls.SetChildIndex(this.fld_speChartHeight, 0);
            this.Controls.SetChildIndex(this.xtraScrollableControl1, 0);
            this.Controls.SetChildIndex(this.btnInsertImage, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fld_Chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_speChartWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fld_speChartHeight.Properties)).EndInit();
            this.xtraScrollableControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private IContainer components;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraCharts.ChartControl fld_Chart;
        private DevExpress.XtraEditors.SimpleButton fld_btnEditChart;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SpinEdit fld_speChartWidth;
        private DevExpress.XtraEditors.SpinEdit fld_speChartHeight;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraEditors.SimpleButton btnInsertImage;
    }
}
