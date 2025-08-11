/**C4585C279A88E8537C1A338EFE5484F9**/
using BOSCommon;
using Emr;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clas.Emr.Core
{
    public class DataAccess
    {
        private CultureInfo _vNCultureInfo;
        private CultureInfo _eNCultureInfo;

        public DataAccess()
        {
            _vNCultureInfo = new CultureInfo("vi-VN");
            _vNCultureInfo.NumberFormat.NumberDecimalSeparator = ",";
            _vNCultureInfo.NumberFormat.NumberGroupSeparator = ".";

            _eNCultureInfo = new CultureInfo("en-US");
            _eNCultureInfo.NumberFormat.NumberDecimalSeparator = ".";
            _eNCultureInfo.NumberFormat.NumberGroupSeparator = ",";
        }
        public object GetValueToBinding(IDictionary<string, object> data, string mEParamNo)
        {
            if (data.TryGetValue(mEParamNo, out object value))
                return value;
            return null;
        }
        public List<Dictionary<string, object>> FlattenListData(string rootPath, object data)
        {
            var results = new List<Dictionary<string, object>>();
            var list = JArray.FromObject(data).ToList();
            foreach (JToken item in list)
            {
                if (item.Type != JTokenType.Null)
                    results.Add(FlattenObjData(rootPath, item as JObject));
                else
                {
                    var obj = new Dictionary<string, object>();
                    //obj.Add()
                    results.Add(obj);
                }
            }
            return results;
        }
        public Dictionary<string, object> FlattenObjData(string rootPath, JObject data)
        {
            if (data == null) return new Dictionary<string, object>();
            var tag = EmrParam.CodeSeparator.ToString();
            IEnumerable<JToken> jTokens = data.Descendants().Where(p => p.Count() == 0);
            Dictionary<string, object> r = jTokens.Aggregate(new Dictionary<string, object>(), (properties, jToken) =>
            {
                properties.Add(rootPath + jToken.Path.Replace("[", tag).Replace("].", tag).Replace(".", tag), jToken);
                return properties;
            });
            return r;

        }
        public Dictionary<string, object> FlattenObjDataWithoutChangeName(string rootPath, JObject data)
        {
            if (data == null) return null;
            IEnumerable<JToken> jTokens = data.Descendants().Where(p => p.Count() == 0);
            Dictionary<string, object> r = jTokens.Aggregate(new Dictionary<string, object>(), (properties, jToken) =>
            {
                properties.Add(rootPath + jToken.Path, jToken);
                return properties;
            });
            return r;

        }
        public void DiscoverListSubData(JToken data, string prefix, Dictionary<string, JToken> subData)
        {
            if (data == null) return;

            var tag = EmrParam.CodeSeparator.ToString();

            if (data.Type == JTokenType.Object)
            {
                foreach (JToken child in data.Children())
                    DiscoverListSubData(child, prefix, subData);
                return;
            }
            else if (data.Type == JTokenType.Property)
            {
                var p = (data as JProperty);
                if (p.Value is JObject)
                    DiscoverListSubData(p.Value, prefix, subData);
                else if (p.Value is JArray)
                {
                    subData.Add(prefix + p.Path.Replace("[", tag).Replace("].", tag).Replace(".", tag), p.Value);
                    for (int i = 0; i < p.Value.Count(); i++)
                        DiscoverListSubData(p.Value[i], prefix, subData);
                }
                return;
            }
            else if (data.Type == JTokenType.Array)
            {
                if (!string.IsNullOrEmpty(data.Path))
                {
                    subData.Add(prefix + data.Path.Replace("[", tag).Replace("].", tag).Replace(".", tag), data);
                }
                for (int i = 0; i < data.Count(); i++)
                    DiscoverListSubData(data[i], prefix, subData);
                return;
            }
        }

        /// <summary>
        /// uthv co gang convert kieu, ko dc thi tra ve string thong thuong
        /// </summary>
        /// <param name="formatType"></param>
        /// <param name="textValue"></param>
        /// <returns></returns>
        public object ConvertDataType(string formatType, string formatStr, string textValue)
        {
            if (string.IsNullOrEmpty(textValue)) return textValue;

            if (formatType == EmrParamFormatTypes.Number.ToString())
            {
                decimal value;
                var ok = false;
                // 37.5 or 37.45
                var pointIdx = textValue.LastIndexOf('.');
                if (pointIdx >= 0 && (pointIdx == textValue.Length - 3 || pointIdx == textValue.Length - 2))
                {
                    ok = decimal.TryParse(textValue, NumberStyles.Any, _eNCultureInfo, out value);
                    if (ok) return value;
                }
                ok = decimal.TryParse(textValue, NumberStyles.Any, _vNCultureInfo, out value);
                if (ok) return value;
                return textValue;
            }
            else if (formatType == EmrParamFormatTypes.DateTime.ToString())
            {
                DateTime value = new DateTime();
                var ok = false;
                if (!string.IsNullOrEmpty(formatStr))
                {
                    var formatArr = new List<string>();
                    var valueArr = new List<string>();
                    formatStr = formatStr.Trim(); //value is trimed also
                    var fSet = formatStr.Split('{');
                    var pointer = 0;
                    foreach (var token in fSet)
                    {
                        if (string.IsNullOrEmpty(token))
                            continue;
                        var parts = token.Split('}');
                        if (parts.Length == 1)
                        {
                            pointer += token.Length;
                            continue;
                        }
                        var f = parts[0].Replace("0:", string.Empty);
                        formatArr.Add(f);

                        if (textValue.Length >= (pointer + f.Length + 1))
                            valueArr.Add(textValue.Substring(pointer, f.Length));
                        else if (textValue.Length > pointer)
                            valueArr.Add(textValue.Substring(pointer));

                        pointer += (f.Length + (parts.Length > 1 ? parts[1].Length : 0));
                    }
                    ok = DateTime.TryParseExact(string.Join(string.Empty, valueArr), string.Join(string.Empty, formatArr), CultureInfo.InvariantCulture, DateTimeStyles.None, out value);

                    if (!ok)
                    {
                        //backwark compatible 
                        //dung de fix loi mot so truong hop sai trong qua khu
                        var idx = formatArr.FindIndex(f => f == "dd/MM/yyyy");
                        if (idx >= 0)
                            formatArr[idx] = "dd-MM-yyyy";
                        idx = formatArr.FindIndex(f => f == "dd/MM");
                        if (idx >= 0)
                            formatArr[idx] = "dd-MM";
                        idx = formatArr.FindIndex(f => f == "MM/yyyy");
                        if (idx >= 0)
                            formatArr[idx] = "MM-yyyy";

                        ok = DateTime.TryParseExact(string.Join(string.Empty, valueArr), string.Join(string.Empty, formatArr), CultureInfo.InvariantCulture, DateTimeStyles.None, out value);
                    }
                }
                if (!ok)
                    ok = DateTime.TryParseExact(textValue, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out value);
                if (!ok)
                    ok = DateTime.TryParseExact(textValue, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out value);
                if (ok) return value.ToUniversalTime().ToLocalTime();
                return textValue;
            }
            else
            {
                return textValue;
            }

        }
        public string GetStringFromDataValue(string type, string format, object value)
        {
            try
            {
                if (type == EmrParamFormatTypes.Number.ToString())
                {
                    if (string.IsNullOrEmpty(format)) format = EmrConsts.NUMBER_DEFAULT_FORMAT_STR;

                    if (value is decimal || value is int || value is double || value is float)
                        return string.Format(_vNCultureInfo, format, value);
                    else if (value is JToken && (value as JToken).Type == JTokenType.Integer)
                        return string.Format(_vNCultureInfo, format, value);
                    else if (value is JToken && (value as JToken).Type == JTokenType.Float)
                        return string.Format(_vNCultureInfo, format, value);
                    else
                    {
                        decimal num = 0;
                        var ok = false;
                        var textValue = value.ToString();
                        // 37.5 or 37.45
                        var pointIdx = textValue.LastIndexOf('.');
                        if (pointIdx >= 0 && (pointIdx == textValue.Length - 3 || pointIdx == textValue.Length - 2))
                            ok = decimal.TryParse(textValue, NumberStyles.Any, _eNCultureInfo, out num);
                        if (!ok)
                            ok = decimal.TryParse(value.ToString(), NumberStyles.Any, _vNCultureInfo, out num);
                        if (ok) return string.Format(_vNCultureInfo, format, num);
                    }
                    return value.ToString();
                }
                else if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(format))
                    return value.ToString();
                else if (type == EmrParamFormatTypes.DateTime.ToString())
                {
                    DateTime date;
                    var ok = false;
                    if (value is DateTime)
                        return string.Format(CultureInfo.InvariantCulture, format, value);
                    else if (value is JToken && (value as JToken).Type == JTokenType.Date)
                        return string.Format(CultureInfo.InvariantCulture, format, value);
                    else
                    {
                        ok = DateTime.TryParseExact(value.ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
                        if (!ok)
                            ok = DateTime.TryParseExact(value.ToString(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
                        if (!ok)
                            ok = DateTime.TryParseExact(value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

                        // ho tro them vi HIS FPT choi kieu du lieu nay
                        if (!ok)
                            ok = DateTime.TryParseExact(value.ToString(), "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
                        if (!ok)
                            ok = DateTime.TryParseExact(value.ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
                        if (!ok)
                            ok = DateTime.TryParseExact(value.ToString(), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
                        if (!ok)
                            ok = DateTime.TryParseExact(value.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

                        if (ok) return string.Format(CultureInfo.InvariantCulture, format, date);
                        return value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("GET FORMAT STRING FROM VALUE ERROR: {0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ex);
            }
            return value.ToString();
        }
    }
}
