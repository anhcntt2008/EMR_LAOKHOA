using Clas.Emr.Core;
using DevExpress.XtraCharts;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BOSERP
{
    public class EmrChartHelper
    {
        private DataAccess _dataHelper;
        public EmrChartHelper()
        {
            _dataHelper = new DataAccess();
        }
        public ChartControl GetChartControl()
        {
            var chart = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(chart)).BeginInit();
            chart.Legend.Name = "Default Legend";
            chart.Location = new System.Drawing.Point(3, 0);
            chart.Name = "fld_Chart";
            chart.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            chart.Size = new System.Drawing.Size(720, 451);
            return chart;
        }
        public ChartControl LoadChartOptions(ChartControl chartControl, string opts)
        {
            byte[] base64 = Convert.FromBase64String(opts);
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
                    }
                }
            }
            return chartControl;
        }
        private List<JToken> GetValueFromPaths(string path, JToken data)
        {
            path = "$." + path;
            return data.SelectTokens(path).ToList();
        }
        public ChartControl GetDataForSeries(ChartControl chartControl, JToken data,
            List<METemplateChartSeriesInfo> seriesConfig, ConcurrentDictionary<string, METemplateParamsInfo> templateParams)
        {

            foreach (var config in seriesConfig)
            {
                Series ser = chartControl.Series.Where(s => s.Name == config.METemplateChartSeriesName).FirstOrDefault() as Series;
                if (ser == null) continue;
                var ignoreEmptyPoint = config != null ? config.METemplateChartSerieIgnoreEmptyPoint : true;
                string[] arguments = ser.ArgumentDataMember.Split('|');
                string[] valueMembers = ser.ValueDataMembers.Cast<string>().ToArray();
                DataTable dt = new DataTable();

                dt.Columns.Add(string.Join("|", arguments), typeof(int));

                foreach (var valueMember in valueMembers)
                {
                    dt.Columns.Add(valueMember.ToString(), typeof(double));
                }
                var argValues = GetValueFromPaths(arguments.First(), data);
                //format du lieu cho giong hien thi tren mau
                templateParams.TryGetValue(arguments.First(), out METemplateParamsInfo param);
                if (param != null)
                    for (int j = 0; j < argValues.Count; j++)
                        argValues[j] = _dataHelper.GetStringFromDataValue(param.MEParamFormatType, param.MEParamFormatString, argValues[j]);

                for (int i = 1; i < arguments.Length; i++)
                {
                    var preArgParent = arguments[i - 1].Substring(0, arguments[i - 1].LastIndexOf('.') + 1);
                    var argParent = arguments[i].Substring(0, arguments[i].LastIndexOf('.'));
                    var newValues = GetValueFromPaths(arguments[i], data);
                    //dang long cap cha con thì phai nhan doi so luong argValues len
                    if (argParent.StartsWith(preArgParent))
                    {
                        var count = argValues.Count;
                        for (int j = 0; j < count; j++)
                        {
                            argValues.Insert((j * 2) + 1, argValues[j * 2]);
                        }
                    }
                    templateParams.TryGetValue(arguments[i], out METemplateParamsInfo param1);
                    for (int j = 0; j < argValues.Count; j++)
                    {
                        string value = null;
                        if (param1 != null)
                            value = _dataHelper.GetStringFromDataValue(param1.MEParamFormatType, param1.MEParamFormatString, newValues[j]);
                        else
                            value = newValues[j].ToString();

                        argValues[j] = argValues[j].ToString() + (string.IsNullOrEmpty(value) ? "-" : " " + value);
                    }
                }

                var arrValues = new List<List<JToken>>();
                var customLabels = new List<CustomAxisLabel>();
                foreach (var valueMember in valueMembers)
                    arrValues.Add(GetValueFromPaths(valueMember, data));

                for (int i = 0; i < argValues.Count; i++)
                {
                    var row = new List<object>();
                    row.Add(i + 1);

                    foreach (var arrValue in arrValues)
                    {
                        if (arrValue.Count >= i && !string.IsNullOrEmpty(arrValue[i].ToString()))
                            row.Add(arrValue[i]);
                        else
                            row.Add(null);
                    }
                    dt.Rows.Add(row.ToArray());
                    customLabels.Add(new CustomAxisLabel(name: string.IsNullOrEmpty(argValues[i].ToString()) ? " " : argValues[i].ToString(), value: row[0].ToString()));
                }
                XYDiagram diagram = chartControl.Diagram as XYDiagram;
                if (diagram != null)
                {
                    if (ser == chartControl.Series[0])
                    {
                        diagram.AxisX.CustomLabels.Clear();
                        diagram.AxisX.CustomLabels.AddRange(customLabels.ToArray());
                    }
                    else
                    {
                        var secondAxis = diagram.SecondaryAxesX.GetElementByName(ser.Name + " AxisX") as SecondaryAxisX;
                        if (secondAxis == null)
                        {
                            secondAxis = new SecondaryAxisX(ser.Name + " AxisX");
                            diagram.SecondaryAxesX.Add(secondAxis);
                        }
                        secondAxis.CustomLabels.AddRange(customLabels.ToArray());
                    }
                }
                ser.DataSource = dt;
            }
            return chartControl;
        }
        public Image GetChartImage(ChartControl chart, ImageFormat format)
        {
            // Create an image.
            Image image = null;

            // Create an image of the chart.
            using (MemoryStream s = new MemoryStream())
            {
                chart.ExportToImage(s, format);
                image = Image.FromStream(s);
            }

            return image;
        }
    }
}
