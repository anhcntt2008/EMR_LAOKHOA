using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Globalization;
using System.Reflection;
using BOSLib;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.IO;
using Clas.Business.Ftp;

namespace BOSERP.Utilities
{
    public class MainHelper
    {
        public MainHelper()
        {
        }

        public JArray MergeChildArrayData(JArray data)
        {
            if (data == null) return null;
            var values = new JArray();
            var first = new JObject();
            foreach (JToken item in data)
            {
                var obj = new JObject();
                foreach (JProperty pro in item)
                {
                    if (pro.Value.Type == JTokenType.Array)
                    {
                        if (pro.Value.Count() > 0 && pro.Value.Any(i => i is JArray))
                        {
                            pro.Value = DecreaseArrLevel(pro.Value as JArray);
                        }
                        if (!first.ContainsKey(pro.Name))
                            first.Add(pro);
                        else
                        {
                            foreach (var v in pro.Value)
                                (first[pro.Name] as JArray).Add(v);
                        }
                    }
                    else
                    {
                        obj.Add(pro);
                    }
                }
                if (obj.Count > 1)
                    values.Add(obj);
            }
            if (first.Count > 0)
                values.Insert(0, first);
            return values;
        }

        public JToken MergeChildArrayData(JToken data)
        {
            if (data == null) return null;
            foreach (JProperty pro in data)
            {
                if (pro.Value.Type == JTokenType.Array
                    && pro.Value.Count() > 0
                    && pro.Value.Any(i => i is JArray))
                {
                    pro.Value = DecreaseArrLevel(pro.Value as JArray);
                }
            }
            return data;
        }

        private JArray DecreaseArrLevel(JArray arr)
        {
            var data = new JArray();
            foreach (JToken v in arr)
            {
                if (v.Type == JTokenType.Array)
                {
                    var subArr = v as JArray;
                    if (subArr.Count() > 0 && subArr.Any(i => i is JArray))
                    {
                        foreach (var item in DecreaseArrLevel(subArr))
                        {
                            data.Add(item);
                        }
                    }
                    else
                    {
                        foreach (JToken s in subArr)
                        {
                            data.Add(s);
                        }
                    }
                }
                else
                {
                    data.Add(v);
                }
            }
            return data;
        }

        public string DownloadTemplate(string fileName, string localPath, FileTemplateManager ftpFileMng)
        {
            string fullFileName = string.Format(@"{0}\Template\{1}.docx", localPath, fileName);
            try
            {
                ftpFileMng.DownloadFile("/Template/", fileName + ".docx", fullFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không tải được tờ bệnh án từ máy chủ.",
                     "CÓ LỖI XẢY RA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }

            if (!File.Exists(fullFileName))
            {
                MessageBox.Show("File mẫu bệnh án không tồn tại ở địa chỉ. " + fileName);
                return string.Empty;
            }
            return fullFileName;
        }

        public void GetParamsValue(JToken data, List<string> values)
        {
            if (data.Type == JTokenType.Object)
            {
                foreach (JToken child in data.Children())
                    GetParamsValue(child, values);
                return;
            }
            else if (data.Type == JTokenType.Property)
            {
                var p = (data as JProperty);
                if (p.Value is JObject || p.Value is JArray)
                    GetParamsValue(p.Value, values);
                else
                    values.Add((data as JProperty).Value.ToString());
                return;
            }
            else if (data.Type == JTokenType.Array)
            {
                for (int i = 0; i < data.Count(); i++)
                    GetParamsValue(data[i], values);
                return;
            }
            else
            {
                values.Add(data.ToString());
            }
        }
    }
}
