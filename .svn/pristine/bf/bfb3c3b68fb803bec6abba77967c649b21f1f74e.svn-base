using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraGrid.Views.Grid;
using Clas.Emr.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using DevExpress.XtraGrid.Columns;
using System.Linq;
using Newtonsoft.Json;
using DevExpress.XtraCharts.Designer;
using DevExpress.XtraCharts;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using DevExpress.XtraRichEdit.API.Native;
using BOSCommon;
using Clas.Emr.Core;
using System.Collections.Concurrent;

namespace BOSERP
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class guiChartConfig : BOSERPScreen
    {
        private METemplateChartsInfo _chartConfig;
        private List<METemplateChartSeriesInfo> _seriesConfig;
        private readonly ConcurrentDictionary<string, METemplateParamsInfo> _templateParams;
        private JToken _data;
        private DataAccess _dataHelper;
        private EmrChartHelper _chartHelper;
        private bool _backgroundRender = false;

        public Image ChartImage { get; private set; }
        public bool AllowSaveConfig = true;
        public guiChartConfig(JToken data, METemplateChartsInfo chart,
            List<METemplateChartSeriesInfo> list,
             ConcurrentDictionary<string, METemplateParamsInfo> templateParams, bool background = false)
        {
            InitializeComponent();
            this._data = data;
            this._chartConfig = chart;
            this._seriesConfig = list;
            this._templateParams = templateParams;
            _dataHelper = new DataAccess();
            _chartHelper = new EmrChartHelper();
            _backgroundRender = background;
        }

        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            //if (_backgroundRender) fld_Chart.Dock = DockStyle.Fill;
            btnOk.Visible = AllowSaveConfig;
            fld_speChartWidth.Value = this._chartConfig.METemplateChartWidth;
            fld_speChartHeight.Value = this._chartConfig.METemplateChartHeight;

            if (!string.IsNullOrEmpty(_chartConfig.METemplateChartOpts))
                _chartHelper.LoadChartOptions(fld_Chart, this._chartConfig.METemplateChartOpts);
            else
            {
                //init chart series
                foreach (var ser in _seriesConfig)
                {
                    Series series = new Series(ser.METemplateChartSeriesName, ViewType.Line);
                    fld_Chart.Series.Add(series);
                    series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                    series.Label.Border.Thickness = 1;
                    series.ArgumentScaleType = ScaleType.Auto;
                    series.ArgumentDataMember = ser.MEParamArgument1
                        + (string.IsNullOrEmpty(ser.MEParamArgument2) ? "" : "|" + ser.MEParamArgument2)
                         + (string.IsNullOrEmpty(ser.MEParamArgument3) ? "" : "|" + ser.MEParamArgument3);
                    series.ValueScaleType = ScaleType.Numerical;
                    if (!string.IsNullOrEmpty(ser.MEParamValue2))
                    {
                        series.ValueDataMembers.AddRange(new string[] { ser.MEParamValue1, ser.MEParamValue2 });
                        if (!ser.METemplateChartSerieIgnoreEmptyPoint)
                        {
                            series.DataFilters.Add(ser.MEParamValue1, typeof(double).Name, DevExpress.XtraCharts.DataFilterCondition.NotEqual, null);
                            series.DataFilters.Add(ser.MEParamValue2, typeof(double).Name, DevExpress.XtraCharts.DataFilterCondition.NotEqual, null);
                        }

                    }
                    else
                    {
                        series.ValueDataMembers.AddRange(new string[] { ser.MEParamValue1 });
                        if (!ser.METemplateChartSerieIgnoreEmptyPoint)
                        {
                            series.DataFilters.Add(ser.MEParamValue1, typeof(double).Name, DevExpress.XtraCharts.DataFilterCondition.NotEqual, null);
                        }
                    }
                }
            }
            try
            {
                _chartHelper.GetDataForSeries(fld_Chart, _data, _seriesConfig, _templateParams);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Dữ liệu nhập trên tờ bệnh án không đúng định dạng. Vui lòng kiểm tra lại." +
                    "\n" + ex.Message, "Kiểm tra dữ liệu nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            SaveChartOptions(fld_Chart);
            this.ChartImage = _chartHelper.GetChartImage(this.fld_Chart, ImageFormat.Png);
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void fld_btnEditChart_Click(object sender, EventArgs e)
        {
            ChartDesigner designer = new ChartDesigner(fld_Chart);
            designer.ShowDialog();
        }

        private void fld_speChartWidth_EditValueChanged(object sender, EventArgs e)
        {
            fld_Chart.Width = (int)fld_speChartWidth.Value;
        }

        private void fld_speChartHeight_EditValueChanged(object sender, EventArgs e)
        {
            fld_Chart.Height = (int)fld_speChartHeight.Value;
        }
        private void SaveChartOptions(ChartControl chartControl)
        {
            using (var stream = new MemoryStream())
            {
                chartControl.SaveToStream(stream);
                stream.Seek(0, SeekOrigin.Begin);
                using (var streamReader = new StreamReader(stream))
                {
                    string layout = streamReader.ReadToEnd();
                    string base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(layout));

                    this._chartConfig.METemplateChartWidth = fld_Chart.Width;
                    this._chartConfig.METemplateChartHeight = fld_Chart.Height;
                    this._chartConfig.METemplateChartOpts = base64;
                    (new METemplateChartsController()).UpdateObject(this._chartConfig);
                }
            }
        }

        private void InsertImage()
        {
            this.ChartImage = _chartHelper.GetChartImage(this.fld_Chart, ImageFormat.Png);
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnInsertImage_Click(object sender, EventArgs e)
        {
            InsertImage();
        }

        private void guiChartConfig_Activated(object sender, EventArgs e)
        {

        }

        private void guiChartConfig_Shown(object sender, EventArgs e)
        {
            if (_backgroundRender)
                InsertImage();
        }
    }
}
