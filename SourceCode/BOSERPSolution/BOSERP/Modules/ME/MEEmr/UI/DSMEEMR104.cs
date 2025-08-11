using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using BOSERP.Modules.MEEmr;
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

namespace BOSERP.Modules.MEEmr.UI
{
    /// <summary>
    /// Summary description for DSMEEMR100
    /// </summary>
    public partial class DSMEEMR104 : BOSERPScreen
    {
        private Dictionary<string, object> _data;
        private MEParamsController _paramsController;
        private MEParamRelationsController _paramRelationsController;
        private DocumentPosition _insertPostion;
        private string _chartTitle = "Biểu đồ ";
        private List<MEParamsInfo> _selectedParam;

        public DSMEEMR104()
        {

        }

        public DSMEEMR104(Dictionary<string, object> data, List<MEParamsInfo> selectedParam, DocumentPosition position)
        {
            InitializeComponent();
            this._data = data;
            this._insertPostion = position;
            this._paramsController = new MEParamsController();
            this._paramRelationsController = new MEParamRelationsController();
            this._selectedParam = selectedParam;
        }


        private void DSMEEMR100_Load(object sender, EventArgs e)
        {
            //this.LoadChartOptions(this._selectedParam.FirstOrDefault(), this.fld_Chart);
            try
            {
                List<CustomAxisLabel> customLabels = new List<CustomAxisLabel>();
                foreach (var ser in this._data)
                {
                    var param = this._selectedParam.Where(o => o.MEParamNo == ser.Key).FirstOrDefault();
                    if (param != null)
                    {
                        var children = _paramRelationsController.GetAllByParentID(param.MEParamID).OrderBy(p => p.MEParamRelationOrder).ToList();
                        var serRelation = children.Where(p => p.MEParamRelationChartSeries).FirstOrDefault() as MEParamRelationsInfo;
                        var chartSerie = (MEParamsInfo)this._paramsController.GetObjectByID(serRelation.FK_MEParamChildID);
                        var chartValues = children.Where(p => p.MEParamRelationChartValue01).ToList();
                        if (chartSerie != null)
                        {
                            foreach (var chartValueRelation in chartValues)
                            {
                                var chartValue1Param = (MEParamsInfo)this._paramsController.GetObjectByID(chartValueRelation.FK_MEParamChildID);
                                var idx = chartValues.IndexOf(chartValueRelation);
                                var chartValue2 = children.GetRange(idx + 1, children.Count - idx - 1).Where(p => p.MEParamRelationChartValue02).FirstOrDefault() as MEParamRelationsInfo;

                                // Create an empty Bar series and add it to the chart.
                                //TODO chart type for each series
                                var type = this.GetChartType(param.MEParamFormatType);
                                Series series = new Series(chartValue1Param.MEParamName, type);
                                series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                                series.Label.Border.Thickness = 1;
                                series.Label.LineVisibility = DevExpress.Utils.DefaultBoolean.False;
                                if (type == ViewType.Bar)
                                    (series.View as BarSeriesView).BarWidth = 0.3;
                                if (type == ViewType.RangeBar)
                                    (series.View as BarSeriesView).BarWidth = 0.2;
                                fld_Chart.Series.Add(series);
                                // Specify data members to bind the series.
                                series.ArgumentScaleType = ScaleType.Auto;
                                series.ArgumentDataMember = chartSerie.MEParamNo;
                                series.ValueScaleType = ScaleType.Numerical;
                                if (chartValue2 != null && type == ViewType.RangeBar)
                                {
                                    var chartValue2Param = (MEParamsInfo)this._paramsController.GetObjectByID(chartValue2.FK_MEParamChildID);
                                    series.ValueDataMembers.AddRange(new string[] { chartValue1Param.MEParamNo, chartValue2Param.MEParamNo });
                                }
                                else
                                {
                                    series.ValueDataMembers.AddRange(new string[] { chartValue1Param.MEParamNo });
                                }
                                // Generate a data table and bind the series to it.
                                DataTable dt = new DataTable();
                                dt.Columns.Add(chartSerie.MEParamNo, typeof(string));
                                dt.Columns.Add(chartValue1Param.MEParamNo, typeof(double));
                                var index = 1;
                                foreach (JToken item in ser.Value as JArray)
                                {
                                    var axisValue = "#" + index + "." + item[chartSerie.MEParamNo].ToString();
                                    if (string.IsNullOrEmpty(item[chartValue1Param.MEParamNo].ToString()))
                                        dt.Rows.Add(new object[] { axisValue, DBNull.Value });
                                    else
                                        dt.Rows.Add(new object[] { axisValue, item[chartValue1Param.MEParamNo] });
                                    index++;

                                    var label = item[chartSerie.MEParamNo].ToString();
                                    if (!customLabels.Any(o => o.AxisValue.ToString() == axisValue))
                                        customLabels.Add(new CustomAxisLabel(name: string.IsNullOrEmpty(label) ? " " : label, value: axisValue.ToString()));
                                }
                                series.DataSource = dt;
                                //foreach (Series s in this.fld_Chart.Series)
                                //{
                                //    if (s.Name.Equals(series.Name))
                                //    {
                                //        s.DataSource = dt;
                                //        break;
                                //    }
                                //}
                                /*bool isSeriesExist = false;
                                foreach (Series s in this.fld_Chart.Series)
                                {
                                    if (s.Name.Equals(series.Name))
                                    {
                                        s.Points.Clear();
                                        MessageBox.Show(string.Format("Points = {0}", series.Points.Count));
                                        for (int i = 0; i < series.Points.Count; i++)
                                            s.Points.Add(series.Points[i]);
                                        isSeriesExist = true;
                                        MessageBox.Show(string.Format("Mapped points = {0}", s.Points.Count));
                                        break;
                                    }
                                }
                                if (!isSeriesExist) fld_Chart.Series.Add(series);*/
                            }
                        }
                        _chartTitle += param.MEParamName + " ";
                    }
                }
                XYDiagram diagram = fld_Chart.Diagram as XYDiagram;
                diagram.AxisY.Visibility = DevExpress.Utils.DefaultBoolean.True;
                AxisX axisX = diagram.AxisX;
                axisX.CustomLabels.AddRange(customLabels.ToArray());
                // Make auto-generated and custom labels visible at the same time.
                axisX.LabelVisibilityMode = AxisLabelVisibilityMode.AutoGeneratedAndCustom;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi vẽ biểu đồ. Kiểm tra lại cấu hình thẻ dữ liệu này, quét chọn dữ liệu và thử lại. /nChi tiết: {ex.ToString()}"
                    , "Có lỗi xảy ra"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }
            // Add a title to the chart (if necessary).
            if (fld_chkVisibleChartTitle.Checked)
            {
                ChartTitle chartTitle1 = new ChartTitle();
                chartTitle1.Text = _chartTitle;
                fld_Chart.Titles.Add(chartTitle1);
            }
            //fld_Chart.Titles. fld_chkVisibleChartTitle

            fld_Chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            fld_speChartWidth.Value = fld_Chart.Width;
            fld_speChartHeight.Value = fld_Chart.Height;
        }

        private ViewType GetChartType(string mEParamFormatType)
        {
            switch (mEParamFormatType)
            {
                case "LineChart": return ViewType.Line;
                case "BarChart": return ViewType.Bar;
                case "AreaChart": return ViewType.Area;
                case "RangeBarChart": return ViewType.RangeBar;
                case "PieChart": return ViewType.Pie;
                default: return ViewType.Bar;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var module = (MEEmrModule)Module;
            module.InsertImageToDocument(GetChartImage(this.fld_Chart, ImageFormat.Png), this._insertPostion);
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private Image GetChartImage(ChartControl chart, ImageFormat format)
        {
            // Create an image.
            Image image = null;

            // Create an image of the chart.
            using (MemoryStream s = new MemoryStream())
            {
                chart.ExportToImage(s, format);
                image = Image.FromStream(s);
            }

            // Return the image.
            return image;
        }

        private void SaveChartImageToFile(ChartControl chart, ImageFormat format, String fileName)
        {
            // Create an image in the specified format from the chart
            // and save it to the specified path.
            chart.ExportToImage(fileName, format);
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

        private void fld_chkVisibleChartTitle_CheckedChanged(object sender, EventArgs e)
        {
            // Add a title to the chart (if necessary).
            if (fld_chkVisibleChartTitle.Checked)
            {
                ChartTitle chartTitle1 = new ChartTitle();
                chartTitle1.Text = _chartTitle;
                fld_Chart.Titles.Add(chartTitle1);
            }
            else
            {
                fld_Chart.Titles.Clear();
            }
        }


        private void SaveChartOptions(MEParamsInfo param, ChartControl chartControl)
        {
            using (var stream = new MemoryStream())
            {
                chartControl.SaveToStream(stream);
                stream.Seek(0, SeekOrigin.Begin);
                using (var streamReader = new StreamReader(stream))
                {
                    string layout = streamReader.ReadToEnd();
                    string base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(layout));
                    param.MEParamChartOption = base64;
                    (new MEParamsController()).UpdateObject(param);
                }
            }
        }

        private void LoadChartOptions(MEParamsInfo param, ChartControl chartControl)
        {
            byte[] base64 = Convert.FromBase64String(param.MEParamChartOption);
            string layout = Encoding.UTF8.GetString(base64);
            using (var stream = new MemoryStream())
            {
                stream.Seek(0, SeekOrigin.Begin);
                using (var streamWriter = new StreamWriter(stream, Encoding.UTF8))
                {
                    streamWriter.Write(layout);
                    streamWriter.Flush();
                    try
                    {
                        chartControl.LoadFromStream(stream);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        chartControl = new ChartControl();
                    }
                }
            }
        }
    }
}
