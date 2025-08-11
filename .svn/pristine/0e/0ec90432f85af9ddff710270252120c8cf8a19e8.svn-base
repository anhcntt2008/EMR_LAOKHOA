/**C4585C279A88E8537C1A338EFE5484F9**/
using BOSCommon;
using BOSERP;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Clas.Emr.Core
{
    public class EmrParser
    {
        private RichEditControl _richEditCtrl;
        private DataAccess _dataHelper;
        private EmrDocumentHelper _emrDocumentHelper;
        private DevExpress.XtraEditors.LabelControl _msgNotification;
        private DevExpress.XtraEditors.MemoEdit _msgLogs;
        public EmrParser(RichEditControl _richEditCtrl, DevExpress.XtraEditors.LabelControl _msgNotification, DevExpress.XtraEditors.MemoEdit msgLogs, EmrDocumentHelper emrDocumentHelper)
        {
            this._richEditCtrl = _richEditCtrl;
            this._dataHelper = new DataAccess();
            this._emrDocumentHelper = emrDocumentHelper;
            this._msgNotification = _msgNotification;
            this._msgLogs = msgLogs;
        }
        #region V2
        /// <summary>
        /// uthv
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        public string ParserFieldsToJson(List<Field> fields, List<METemplateParamsInfo> templateParamList, bool parseCheckBox = true)
        {
            return ParserFieldsToJToken(fields, templateParamList, parseCheckBox).ToString();
        }
        public JToken ParserFieldsToJToken(List<Field> fields, List<METemplateParamsInfo> templateParamList, bool parseCheckBox = true)
        {
            var meta = new Dictionary<string, object>();
            var doc = this._richEditCtrl.Document;
            List<MEParamsInfo> listEmrParams = new List<MEParamsInfo>();
            var json = new object();
            var fieldCode = string.Empty;
            List<EmrField> listFields = new List<EmrField>();
            try
            {
                meta = ParserDocumentToJsonV2Step01(fields, listEmrParams, templateParamList);
                json = ParserDocumentToJsonV2Step02(meta, listEmrParams, parseCheckBox);
                if (!string.IsNullOrEmpty(_msgNotification.Text))
                    _msgNotification.Text = "Không tìm thấy thẻ: " + _msgNotification.Text;
                return ParserDocumentToJsonV2Step03(json, listEmrParams, templateParamList);
            }
            catch (Exception ex)
            {
                Trace.TraceError("JSON PARSER ERROR: {0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ex);
                _msgLogs.Text += ("\r\n" + string.Format("JSON PARSER ERROR: {0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ex));
                throw;
            }
        }
        public Dictionary<string, object> ParserFieldsToDict(List<Field> fields, List<METemplateParamsInfo> templateParamList)
        {
            var meta = new Dictionary<string, object>();
            var doc = this._richEditCtrl.Document;
            List<MEParamsInfo> listEmrParams = new List<MEParamsInfo>();
            var json = new object();
            var fieldCode = string.Empty;
            List<EmrField> listFields = new List<EmrField>();
            try
            {
                meta = ParserDocumentToJsonV2Step01(fields, listEmrParams, templateParamList);
                return (Dictionary<string, object>)ParserDocumentToJsonV2Step02(meta, listEmrParams);
            }
            catch (Exception ex)
            {
                Trace.TraceError("JSON PARSER TO DICT ERROR: {0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ex);
                _msgLogs.Text += ("\r\n" + string.Format("JSON PARSER TO DICT ERROR: {0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ex));
                throw;
            }
        }
        public Dictionary<string, object> ParserDocumentToJsonV2Step01(List<Field> fields, List<MEParamsInfo> listEmrParams, List<METemplateParamsInfo> templateParamList)
        {
            var meta = new Dictionary<string, object>();
            var doc = this._richEditCtrl.Document;
            var json = new object();
            var fieldCode = string.Empty;
            var expConfig = new DevExpress.XtraRichEdit.Export.PlainTextDocumentExporterOptions() { ExportHiddenText = true, ExportBulletsAndNumbering = false };
            List<EmrField> listFields = new List<EmrField>();
            var gToken = $"{EmrParam.GuidTag}=";
            try
            {
                foreach (var field in fields)
                {
                    fieldCode = doc.GetText(field.CodeRange, expConfig);
                    var tokens = fieldCode.Split(EmrParam.TagCodeSeparator);
                    var gid = tokens.Where(t => t.Contains(gToken)).FirstOrDefault();
                    gid = gid == null ? string.Empty : gid.Replace(gToken, string.Empty);
                    var codes = tokens[0].Split(EmrParam.CodeSeparator);
                    // BUG #1123 Hủy ký bị lỗi khi mẫu có thẻ bị sai cấu trúc => Bỏ qua những thẻ bị sai cấu trúc từ bước Lưu
                    // UtHV: dự định fix tuy nhiên có thể gây chậm nên bỏ qua => thay bằng ràng buộc mã thẻ không được empty
                    //for (int c = 0; c < codes.Length; c++)
                    //{
                    //    if (string.IsNullOrEmpty(codes[c]))
                    //        codes[c] = "__invalid__";
                    //}
                    var i = -1;
                    listFields.Add(new EmrField()
                    {
                        Tokens = tokens,
                        Gid = gid,
                        Field = field,
                        FieldCode = fieldCode,
                        CodeLevelStr = tokens[0],
                        CodeLevelArr = codes,
                        ParamNo = int.TryParse(codes.Last(), out i) ? codes[codes.Length - 2] : codes.Last(),
                    });
                }
                foreach (var field in listFields)
                {
                    //field code co dang Medication_MedicationList_0_MedicationName|u=uthv|ud=10/10/2017|s=uthv
                    if (field.Tokens.Length > 0)
                    {
                        if (field.CodeLevelStr.Contains("HYPERLINK")) continue;
                        if (field.CodeLevelStr.Contains("SYMBOL")) continue;
                    }
                    var childCode = field.CodeLevelStr + EmrParam.CodeSeparator;
                    //neu day la the cha, khong co chua noi dung thi ko can add vao
                    if (listFields.Any(k => k.CodeLevelStr.StartsWith(childCode, StringComparison.Ordinal))) continue;

                    var textValue = doc.GetText(field.Field.ResultRange, expConfig);
                    object value = textValue;
                    var param = this._emrDocumentHelper.GetParamByNo(listEmrParams, field.ParamNo);
                    if (param != null)
                    {
                        textValue = textValue.TrimEnd('\r', '\n', ' ', '\t').TrimStart('\r', '\n', ' ', '\t');

                        if (!string.IsNullOrEmpty(param.MEParamUnit) && textValue.EndsWith(param.MEParamUnit))
                            textValue = textValue.Substring(0, textValue.Length - param.MEParamUnit.Length);

                        textValue = textValue.TrimEnd(EmrParam.EndTag.ToCharArray()).TrimStart(EmrParam.BeginTag.ToCharArray());
                        textValue = textValue.Trim();

                        var formatType = param.MEParamFormatType;
                        var formatStr = param.MEParamFormatString;
                        if (templateParamList != null)
                        {
                            var fieldPath = _emrDocumentHelper.GetTemplateFieldPath(field.CodeLevelStr);
                            var tempParam = templateParamList.Where(o => o.METemplateParamPath == fieldPath).FirstOrDefault();
                            if (tempParam != null)
                            {
                                if (!string.IsNullOrEmpty(tempParam.MEParamFormatString))
                                    formatStr = tempParam.MEParamFormatString;
                                if (!string.IsNullOrEmpty(tempParam.MEParamFormatType))
                                    formatType = tempParam.MEParamFormatType;
                            }
                        }
                        value = this._dataHelper.ConvertDataType(formatType, formatStr, textValue);
                    }
                    else
                    {
                        textValue = textValue.TrimEnd(EmrParam.EndTag.ToCharArray()).TrimStart(EmrParam.BeginTag.ToCharArray());
                        textValue = textValue.Trim();
                        value = textValue;
                    }
                    var container = meta;
                    for (int i = 0; i < field.CodeLevelArr.Length; i++)
                    {
                        var code = field.CodeLevelArr[i];
                        //add value
                        if (i == field.CodeLevelArr.Length - 1)
                        {
                            if (!container.ContainsKey(code))
                            {
                                var data = new Dictionary<string, object>
                                {
                                    { field.Gid, value }
                                };
                                container.Add(code, data);
                            }
                            else
                            {
                                var data = (Dictionary<string, object>)container[code];
                                //neu da co nhung lai co gid khac thi add tao thanh array
                                if (!data.ContainsKey(field.Gid))
                                {
                                    data.Add(field.Gid, value);
                                }
                            }
                        }
                        //add container
                        else
                        {
                            if (!container.ContainsKey(code))
                            {
                                var data = new Dictionary<string, object>();
                                var grp = new Dictionary<string, object>();
                                data.Add(field.Gid, grp);
                                container.Add(code, data);
                                container = grp;

                            }
                            else
                            {
                                var data = (Dictionary<string, object>)container[code];
                                //neu da co nhung lai co gid khac thi add tao thanh array
                                if (!data.ContainsKey(field.Gid))
                                {
                                    var grp = new Dictionary<string, object>();
                                    data.Add(field.Gid, grp);
                                    container = grp;
                                }
                                else
                                {
                                    container = (Dictionary<string, object>)data[field.Gid];
                                }
                            }
                        }
                    }
                }
                _msgNotification.Text = string.Empty;
                return meta;
            }
            catch (Exception ex)
            {
                Trace.TraceError("JSON PARSER ERROR STEP 01: {0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ex);
                _msgLogs.Text += ("\r\n" + string.Format("JSON PARSER ERROR STEP 01: {0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ex));
                throw;
            }
        }
        public object ParserDocumentToJsonV2Step02(Dictionary<string, object> meta, List<MEParamsInfo> listEmrParams, bool parseCheckBox = true)
        {
            var obj = new Dictionary<string, object>();
            var array = new List<object>();
            int index;
            foreach (var property in meta)
            {
                var values = (Dictionary<string, object>)property.Value;
                if (values == null) return null;
                //index array
                if (int.TryParse(property.Key, out index))
                {
                    if (array.Count <= index)
                    {
                        var newArray = new object[index + 1].ToList();
                        for (int i = 0; i < array.Count; i++)
                            newArray[i] = array[i];
                        array = newArray;
                    }
                    var value = values.First();
                    if (value.Value.GetType() == typeof(Dictionary<string, object>))
                        array[index] = ParserDocumentToJsonV2Step02((Dictionary<string, object>)value.Value, listEmrParams);
                    else
                        array[index] = value.Value;
                }
                else
                {
                    //uthv ko can the du lieu nay co trong db hay ko, chi can co tren file word la trich xuat
                    //vi trong truong hop nguoi dung thay doi ma the co the anh huong den cac template da tao
                    var param = this._emrDocumentHelper.GetParamByNo(listEmrParams, property.Key);
                    if (param == null)
                    {
                        _msgNotification.Text += (property.Key + "; ");
                    }
                    //doi voi 2 loai control Radio va Checkbox can lay value cua cac con gan cho value cua cha
                    else if (param.MEParamControlType == EmrParamControlTypes.Radio.ToString())
                    {
                        var value = values.First();
                        obj.Add(property.Key, ParserRadio(value.Value, listEmrParams, param));
                    }
                    else if (param.MEParamControlType == EmrParamControlTypes.Checkbox.ToString() && parseCheckBox)
                    {
                        var value = values.First();
                        obj.Add(property.Key, ParserCheckbox(value.Value, listEmrParams, param));
                    }
                    else
                    {
                        if (values.Count > 1)
                        {
                            var list = new List<object>();
                            foreach (var value in values)
                            {
                                if (value.Value.GetType() == typeof(Dictionary<string, object>))
                                {
                                    var nextMeta = (Dictionary<string, object>)value.Value;
                                    if (param != null && param.MEParamType == EmrParamTypes.List.ToString())
                                    {
                                        //TODO hard xu ly truong hop array in array [[]]
                                        //uthv chua toi uu hoa nhung tam chap nhan
                                        foreach (var prop in nextMeta)
                                        {
                                            var nextValues = (Dictionary<string, object>)prop.Value;
                                            if (nextValues == null) continue;
                                            //index array
                                            if (int.TryParse(prop.Key, out index))
                                            {
                                                var nextValue = nextValues.First();
                                                if (nextValue.Value.GetType() == typeof(Dictionary<string, object>))
                                                    list.Add(ParserDocumentToJsonV2Step02((Dictionary<string, object>)nextValue.Value, listEmrParams));
                                                else
                                                    list.Add(nextValue.Value);
                                            }
                                            else
                                            {
                                                if (nextValues.GetType() == typeof(Dictionary<string, object>))
                                                    list.Add(ParserDocumentToJsonV2Step02((Dictionary<string, object>)nextValues, listEmrParams));
                                                else
                                                    list.Add(nextValues);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        list.Add(ParserDocumentToJsonV2Step02(nextMeta, listEmrParams));
                                    }
                                }
                                else
                                    list.Add(value.Value);
                            }
                            obj.Add(property.Key, list);
                        }
                        else
                        {
                            var value = values.First();
                            if (value.Value.GetType() == typeof(Dictionary<string, object>))
                                obj.Add(property.Key, ParserDocumentToJsonV2Step02((Dictionary<string, object>)value.Value, listEmrParams));
                            else
                                obj.Add(property.Key, value.Value);
                        }
                    }
                }
            }

            if (obj.Count > 0) return obj;
            //uthv 12/11 loai bo ca item null trong array
            array.RemoveAll(o => o == null);
            return array;

        }
        private object ParserCheckbox(object data, List<MEParamsInfo> listEmrParams, MEParamsInfo parent)
        {
            if (data.GetType() != typeof(Dictionary<string, object>)) return data.ToString();
            var meta = (Dictionary<string, object>)data;

            var list = new List<object>();
            foreach (var property in meta)
            {
                var values = (Dictionary<string, object>)property.Value;
                if (values == null) return null;
                var value = values.First();
                var param = this._emrDocumentHelper.GetParamByNo(listEmrParams, property.Key);
                //ko tim thay param con tren mau
                if (param == null)
                    list.Add(value.Value);
                else
                {
                    // tim thay thi kiem tra co dc check ko
                    if (parent.MEParamValue.ToUpper() == value.Value.ToString().ToUpper())
                        list.Add(param.MEParamValue);
                }
            }
            return list;
        }
        private object ParserRadio(object data, List<MEParamsInfo> listEmrParams, MEParamsInfo parent)
        {
            if (data.GetType() != typeof(Dictionary<string, object>)) return data.ToString();
            var meta = (Dictionary<string, object>)data;
            foreach (var property in meta)
            {
                var values = (Dictionary<string, object>)property.Value;
                if (values == null) return null;
                var param = this._emrDocumentHelper.GetParamByNo(listEmrParams, property.Key);
                if (param == null) _msgNotification.Text += (property.Key + "; ");
                var value = values.First();
                if (parent.MEParamValue.ToUpper() == value.Value.ToString().ToUpper())
                    return param.MEParamValue;
            }
            return ParserDocumentToJsonV2Step02(meta, listEmrParams);
        }
        public JToken ParserDocumentToJsonV2Step03(object data, List<MEParamsInfo> listEmrParams, List<METemplateParamsInfo> templateParamList)
        {
            var json = JsonConvert.SerializeObject(data);
            var obj = JsonConvert.DeserializeObject(json) as JToken;
            var mergeOpt = new JsonMergeSettings()
            {
                MergeNullValueHandling = MergeNullValueHandling.Ignore,
                MergeArrayHandling = MergeArrayHandling.Merge
            };
            foreach (JToken item in obj)
            {
                var param = this._emrDocumentHelper.GetParamByNo(listEmrParams, item.Path);
                //chi xet kieu du lieu list moi co group
                if (param != null)
                {
                    if (templateParamList != null)
                    {
                        var tempParam = templateParamList.Where(o => o.METemplateParamPath == item.Path).FirstOrDefault();
                        if (param.MEParamType == EmrParamTypes.List.ToString() && tempParam != null && tempParam.MEParamRelationAllowMerge)
                        {
                            var array = obj[item.Path] as JArray;
                            if (array != null && array.Count > 0)
                            {
                                if (array[0].Type == JTokenType.Object)
                                {
                                    var objIdx0 = array[0] as JObject;
                                    for (int i = 1; i < array.Count; i++)
                                    {
                                        var to = array[i] as JObject;
                                        var v = (JObject)to.DeepClone();
                                        to.Merge(objIdx0, mergeOpt);
                                        to.Merge(v, mergeOpt);
                                        array[i] = to;
                                    }
                                    obj[item.Path] = array;
                                }
                            }
                        }
                    }
                }
            }
            return obj;//.ToString();
        }
        #endregion

        public EmrField ParseField(Field field)
        {
            var doc = this._richEditCtrl.Document;
            var fieldCode = doc.GetText(field.CodeRange);
            var tokens = fieldCode.Split(EmrParam.TagCodeSeparator);
            var gid = tokens.Where(t => t.Contains($"{EmrParam.GuidTag}=")).FirstOrDefault();
            gid = gid == null ? string.Empty : gid.Replace($"{EmrParam.GuidTag}=", "");
            var codes = tokens[0].Split(EmrParam.CodeSeparator);
            var i = -1;
            return new EmrField()
            {
                Tokens = tokens,
                Gid = gid,
                Field = field,
                FieldCode = fieldCode,
                CodeLevelStr = tokens[0],
                CodeLevelArr = codes,
                ParamNo = int.TryParse(codes.Last(), out i) ? codes[codes.Length - 2] : codes.Last(),
            };
        }
        public string GetFieldValue(Field field)
        {
            var doc = this._richEditCtrl.Document;
            if (field != null)
            {
                var textValue = doc.GetText(field.ResultRange);
                textValue = textValue.Substring(0, textValue.IndexOf(EmrParam.EndTag));
                return textValue.TrimEnd(EmrParam.EndTag.ToCharArray()).TrimStart(EmrParam.BeginTag.ToCharArray());
                // return textValue.Trim();
            }
            return string.Empty;
        }
        public string GetDataByPrefix(string gid, string prefix, List<METemplateParamsInfo> templateParamList)
        {
            var fields = this._emrDocumentHelper.GetFieldsByPrefix(gid, prefix, string.Empty);
            return this.ParserFieldsToJson(fields, templateParamList);
        }
        public List<T> GetArrayValFromParam<T>(string[] codeLevelArr, string gid, List<METemplateParamsInfo> templateParamList)
        {
            int y, idx = 0;
            for (int i = codeLevelArr.Length - 1; i >= 0; i--)
                if (int.TryParse(codeLevelArr[i], out y))
                {
                    idx = i; break;
                }
            var prefix = string.Join(EmrParam.CodeSeparator.ToString(), codeLevelArr.Take(idx));
            var json = GetDataByPrefix(gid, prefix, templateParamList);
            try
            {
                if (JsonConvert.DeserializeObject(json) is JObject obj)
                {
                    if (obj.ContainsKey(prefix))
                    {
                        if (obj[prefix].Type == JTokenType.Array)
                        {
                            return obj[prefix].ToObject<List<T>>();
                        }
                    }
                    else
                    {
                        var tokens = obj.SelectTokens(_emrDocumentHelper.GetTemplateFieldPath(prefix)).ToArray();
                        if (tokens.Length > 0)
                        {
                            return tokens[0].ToObject<List<T>>();
                        }

                    }
                }
            }
            catch { /*do nothing*/}
            return default(List<T>);
        }

        #region V3
        public string ParserFieldsToJsonV3(List<Field> fields, ConcurrentDictionary<string, MEParamsInfo> dictParams, ConcurrentDictionary<string, METemplateParamsInfo> templateParams, bool parseCheckBox = true)
        {
            return ParserFieldsToJTokenV3(fields, dictParams, templateParams, parseCheckBox).ToString();
        }
        public JToken ParserFieldsToJTokenV3(List<Field> fields, ConcurrentDictionary<string, MEParamsInfo> dictParams, ConcurrentDictionary<string, METemplateParamsInfo> templateParams, bool parseCheckBox = true)
        {
            var doc = this._richEditCtrl.Document;
            var fieldCode = string.Empty;
            List<EmrField> listFields = new List<EmrField>();
            try
            {
                Dictionary<string, object> meta = ParserDocumentToJsonV3Step01(fields, dictParams, templateParams);
                object json = ParserDocumentToJsonV3Step02Start(meta, dictParams, parseCheckBox);
                if (!string.IsNullOrEmpty(_msgNotification.Text))
                    _msgNotification.Text = "Không tìm thấy thẻ: " + _msgNotification.Text;
                return ParserDocumentToJsonV3Step03(json, dictParams, templateParams);
            }
            catch (Exception ex)
            {
                Trace.TraceError("JSON PARSER ERROR: {0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ex);
                _msgLogs.Text += ("\r\n" + string.Format("JSON PARSER ERROR: {0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ex));
                throw;
            }
        }
        public Dictionary<string, object> ParserDocumentToJsonV3Step01(List<Field> fields, ConcurrentDictionary<string, MEParamsInfo> dictParams, ConcurrentDictionary<string, METemplateParamsInfo> templateParams)
        {
            var meta = new Dictionary<string, object>();
            var doc = this._richEditCtrl.Document;
            var expConfig = new DevExpress.XtraRichEdit.Export.PlainTextDocumentExporterOptions() { ExportHiddenText = true, ExportBulletsAndNumbering = false };
            var listFields = new EmrField[fields.Count];
            for (int idx = 0; idx < fields.Count; idx++)
            {
                listFields[idx] = new EmrField();
            }
            if (fields.Count == doc.Fields.Count)
            {
                using (var stream = new System.IO.MemoryStream())
                {
                    this._richEditCtrl.SaveDocument(stream, DocumentFormat.OpenXml);
                    using (var newMemoryStream = new System.IO.MemoryStream())
                    {
                        stream.Position = 0;
                        stream.CopyTo(newMemoryStream);
                        newMemoryStream.Position = 0;
                        var taskCode = Task.Factory.StartNew<int>(() =>
                        {
                            using (var rich = new RichEditDocumentServer())
                            {
                                rich.LoadDocument(newMemoryStream, DocumentFormat.OpenXml);
                                var field1s = rich.Document.Fields.ToList();
                                for (int idx = 0; idx < field1s.Count; idx++)
                                {
                                    listFields[idx].FieldCode = rich.Document.GetText(field1s[idx].CodeRange, expConfig);
                                }
                                return field1s.Count;
                            }
                        });
                        var taskValue = Task.Factory.StartNew<int>(() =>
                        {
                            using (var rich = new RichEditDocumentServer())
                            {
                                stream.Position = 0;
                                rich.LoadDocument(stream, DocumentFormat.OpenXml);
                                var field2s = rich.Document.Fields.ToList();
                                for (int idx = 0; idx < field2s.Count; idx++)
                                {
                                    listFields[idx].StrValue = rich.Document.GetText(field2s[idx].ResultRange, expConfig);
                                }
                                return field2s.Count;
                            }
                        });
                        Task.WaitAll(taskCode, taskValue);
                    }
                }
            }
            //TODO optimization later
            else
            {
                for (int idx = 0; idx < fields.Count; idx++)
                {
                    listFields[idx].FieldCode = doc.GetText(fields[idx].CodeRange, expConfig);
                    listFields[idx].StrValue = doc.GetText(fields[idx].ResultRange, expConfig);
                }
            }

            var json = new object();
            var gToken = $"{EmrParam.GuidTag}=";

            var tasks = new Task[fields.Count];
            for (int idx = 0; idx < fields.Count; idx++)
            {
                var index = idx;
                tasks[index] = Task.Factory.StartNew<int>(() =>
                {
                    var field = listFields[index];
                    var tokens = field.FieldCode.Split(EmrParam.TagCodeSeparator);
                    var gid = tokens.Where(t => t.Contains(gToken)).FirstOrDefault();
                    gid = gid == null ? string.Empty : gid.Replace(gToken, string.Empty);
                    var codes = tokens[0].Split(EmrParam.CodeSeparator);
                    var i = -1;
                    field.Tokens = tokens;
                    field.Gid = gid;
                    field.Field = fields[index];
                    field.CodeLevelStr = tokens[0];
                    field.CodeLevelArr = codes;
                    field.ParamNo = int.TryParse(codes.Last(), out i) ? codes[codes.Length - 2] : codes.Last();
                    return index;
                });
            }
            Task.WaitAll(tasks);

            for (int idx = 0; idx < fields.Count; idx++)
            {
                var index = idx;
                tasks[index] = Task.Factory.StartNew<int>(() =>
                {
                    var field = listFields[index];
                    // neu day la the cha, khong co chua noi dung thi ko can add vao
                    // 2% CPU TODO optimization
                    var childCode = field.CodeLevelStr + EmrParam.CodeSeparator;
                    if (listFields.Any(k => k.CodeLevelStr.StartsWith(childCode, StringComparison.Ordinal)))
                    {
                        field.ParamNo = string.Empty;
                        return index;
                    };

                    //field code co dang Medication_MedicationList_0_MedicationName|u=uthv|ud=10/10/2017|s=uthv
                    if (field.Tokens.Length > 0)
                    {
                        if (field.CodeLevelStr.Contains("HYPERLINK"))
                        {
                            field.ParamNo = string.Empty;
                            return index;
                        }
                        if (field.CodeLevelStr.Contains("SYMBOL"))
                        {
                            field.ParamNo = string.Empty;
                            return index;
                        }
                    }
                    var textValue = field.StrValue;// doc.GetText(field.Field.ResultRange, expConfig);
                    field.Value = textValue;
                    var param = this._emrDocumentHelper.GetParamByNoV3(dictParams, field.ParamNo);
                    if (param != null)
                    {
                        textValue = textValue.TrimEnd('\r', '\n', ' ', '\t').TrimStart('\r', '\n', ' ', '\t');

                        if (!string.IsNullOrEmpty(param.MEParamUnit) && textValue.EndsWith(param.MEParamUnit))
                            textValue = textValue.Substring(0, textValue.Length - param.MEParamUnit.Length);

                        textValue = textValue.TrimEnd(EmrParam.EndTag.ToCharArray()).TrimStart(EmrParam.BeginTag.ToCharArray());
                        textValue = textValue.Trim();

                        var formatType = param.MEParamFormatType;
                        var formatStr = param.MEParamFormatString;
                        if (templateParams != null)
                        {
                            var fieldPath = _emrDocumentHelper.GetTemplateFieldPath(field.CodeLevelStr);
                            templateParams.TryGetValue(fieldPath, out METemplateParamsInfo tempParam);
                            if (tempParam != null)
                            {
                                if (!string.IsNullOrEmpty(tempParam.MEParamFormatString))
                                    formatStr = tempParam.MEParamFormatString;
                                if (!string.IsNullOrEmpty(tempParam.MEParamFormatType))
                                    formatType = tempParam.MEParamFormatType;
                            }
                        }
                        field.Value = this._dataHelper.ConvertDataType(formatType, formatStr, textValue);
                    }
                    else
                    {
                        textValue = textValue.TrimEnd(EmrParam.EndTag.ToCharArray()).TrimStart(EmrParam.BeginTag.ToCharArray());
                        textValue = textValue.Trim();
                        field.Value = textValue;
                    }

                    return index;
                });
            }
            Task.WaitAll(tasks);

            try
            {
                foreach (var field in listFields)
                {
                    if (string.IsNullOrEmpty(field.ParamNo)) continue;

                    var container = meta;
                    for (int i = 0; i < field.CodeLevelArr.Length; i++)
                    {
                        var code = field.CodeLevelArr[i];
                        //add value
                        if (i == field.CodeLevelArr.Length - 1)
                        {
                            if (!container.ContainsKey(code))
                            {
                                var data = new Dictionary<string, object>
                                    {
                                        { field.Gid, field.Value }
                                    };
                                container.Add(code, data);
                            }
                            else
                            {
                                var data = (Dictionary<string, object>)container[code];
                                //neu da co nhung lai co gid khac thi add tao thanh array
                                if (!data.ContainsKey(field.Gid))
                                {
                                    data.Add(field.Gid, field.Value);
                                }
                            }
                        }
                        //add container
                        else
                        {
                            if (!container.ContainsKey(code))
                            {
                                var data = new Dictionary<string, object>();
                                var grp = new Dictionary<string, object>();
                                data.Add(field.Gid, grp);
                                container.Add(code, data);
                                container = grp;
                            }
                            else
                            {
                                var data = (Dictionary<string, object>)container[code];
                                //neu da co nhung lai co gid khac thi add tao thanh array
                                if (!data.ContainsKey(field.Gid))
                                {
                                    var grp = new Dictionary<string, object>();
                                    data.Add(field.Gid, grp);
                                    container = grp;
                                }
                                else
                                {
                                    container = (Dictionary<string, object>)data[field.Gid];
                                }
                            }
                        }
                    }
                }
                _msgNotification.Text = string.Empty;
                return meta;
            }
            catch (Exception ex)
            {
                Trace.TraceError("JSON PARSER ERROR STEP 01: {0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ex);
                _msgLogs.Text += ("\r\n" + string.Format("JSON PARSER ERROR STEP 01: {0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ex));
                throw;
            }
        }
        public object ParserDocumentToJsonV3Step02Start(Dictionary<string, object> meta, ConcurrentDictionary<string, MEParamsInfo> dictParams, bool parseCheckBox = true)
        {
            var obj = new ConcurrentDictionary<string, object>();
            var tasks = new Task[meta.Count];
            Func<object, int> action = (object element) =>
            {
                int idx = (int)element;
                var property = meta.ElementAt(idx);
                var values = (Dictionary<string, object>)property.Value;
                if (values == null)
                    return -1;
                try
                {
                    //uthv ko can the du lieu nay co trong db hay ko, chi can co tren file word la trich xuat
                    //vi trong truong hop nguoi dung thay doi ma the co the anh huong den cac template da tao
                    var param = this._emrDocumentHelper.GetParamByNoV3(dictParams, property.Key);
                    if (param == null) AppendParamNotFoundNotify(property.Key + "; ");
                    //doi voi 2 loai control Radio va Checkbox can lay value cua cac con gan cho value cua cha
                    else if (param.MEParamControlType == EmrParamControlTypes.Radio.ToString())
                    {
                        var value = values.First();
                        obj.TryAdd(property.Key, ParserRadioV3(value.Value, dictParams, param));
                    }
                    else if (param.MEParamControlType == EmrParamControlTypes.Checkbox.ToString() && parseCheckBox)
                    {
                        var value = values.First();
                        obj.TryAdd(property.Key, ParserCheckboxV3(value.Value, dictParams, param));
                    }
                    else
                    {
                        if (values.Count > 1)
                        {
                            var list = new List<object>();
                            foreach (var value in values)
                            {
                                if (value.Value.GetType() == typeof(Dictionary<string, object>))
                                {
                                    var nextMeta = (Dictionary<string, object>)value.Value;
                                    if (param != null && param.MEParamType == EmrParamTypes.List.ToString())
                                    {
                                        //TODO hard xu ly truong hop array in array [[]]
                                        //uthv chua toi uu hoa nhung tam chap nhan
                                        foreach (var prop in nextMeta)
                                        {
                                            var nextValues = (Dictionary<string, object>)prop.Value;
                                            if (nextValues == null) continue;
                                            //index array
                                            if (int.TryParse(prop.Key, out int index))
                                            {
                                                var nextValue = nextValues.First();
                                                if (nextValue.Value.GetType() == typeof(Dictionary<string, object>))
                                                    list.Add(ParserDocumentToJsonV3Step02Next((Dictionary<string, object>)nextValue.Value, dictParams));
                                                else
                                                    list.Add(nextValue.Value);
                                            }
                                            else
                                            {
                                                if (nextValues.GetType() == typeof(Dictionary<string, object>))
                                                    list.Add(ParserDocumentToJsonV3Step02Next((Dictionary<string, object>)nextValues, dictParams));
                                                else
                                                    list.Add(nextValues);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        list.Add(ParserDocumentToJsonV3Step02Next(nextMeta, dictParams));
                                    }
                                }
                                else
                                    list.Add(value.Value);
                            }
                            obj.TryAdd(property.Key, list);
                        }
                        else
                        {
                            var value = values.First();
                            if (value.Value.GetType() == typeof(Dictionary<string, object>))
                                obj.TryAdd(property.Key, ParserDocumentToJsonV3Step02Next((Dictionary<string, object>)value.Value, dictParams));
                            else
                                obj.TryAdd(property.Key, value.Value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return idx;
            };

            for (int index = 0; index < meta.Count; index++)
            {
                tasks[index] = Task<int>.Factory.StartNew(action, index);
            }
            try
            {
                Task.WaitAll(tasks);
            }
            catch (AggregateException e)
            {
                throw e;
            }
            return obj;
        }
        public object ParserDocumentToJsonV3Step02Next(Dictionary<string, object> meta, ConcurrentDictionary<string, MEParamsInfo> dictParams, bool parseCheckBox = true)
        {
            var obj = new Dictionary<string, object>();
            var array = new List<object>();
            int index;
            foreach (var property in meta)
            {
                var values = (Dictionary<string, object>)property.Value;
                if (values == null) return null;
                //index array
                if (int.TryParse(property.Key, out index))
                {
                    if (array.Count <= index)
                    {
                        var newArray = new object[index + 1].ToList();
                        for (int i = 0; i < array.Count; i++)
                            newArray[i] = array[i];
                        array = newArray;
                    }
                    var value = values.First();
                    if (value.Value.GetType() == typeof(Dictionary<string, object>))
                        array[index] = ParserDocumentToJsonV3Step02Next((Dictionary<string, object>)value.Value, dictParams);
                    else
                        array[index] = value.Value;
                }
                else
                {
                    //uthv ko can the du lieu nay co trong db hay ko, chi can co tren file word la trich xuat
                    //vi trong truong hop nguoi dung thay doi ma the co the anh huong den cac template da tao
                    var param = this._emrDocumentHelper.GetParamByNoV3(dictParams, property.Key);
                    if (param == null) AppendParamNotFoundNotify(property.Key + "; ");
                    //doi voi 2 loai control Radio va Checkbox can lay value cua cac con gan cho value cua cha
                    else if (param.MEParamControlType == EmrParamControlTypes.Radio.ToString())
                    {
                        var value = values.First();
                        obj.Add(property.Key, ParserRadioV3(value.Value, dictParams, param));
                    }
                    else if (param.MEParamControlType == EmrParamControlTypes.Checkbox.ToString() && parseCheckBox)
                    {
                        var value = values.First();
                        obj.Add(property.Key, ParserCheckboxV3(value.Value, dictParams, param));
                    }
                    else
                    {
                        if (values.Count > 1)
                        {
                            var list = new List<object>();
                            foreach (var value in values)
                            {
                                if (value.Value.GetType() == typeof(Dictionary<string, object>))
                                {
                                    var nextMeta = (Dictionary<string, object>)value.Value;
                                    if (param != null && param.MEParamType == EmrParamTypes.List.ToString())
                                    {
                                        //TODO hard xu ly truong hop array in array [[]]
                                        //uthv chua toi uu hoa nhung tam chap nhan
                                        foreach (var prop in nextMeta)
                                        {
                                            var nextValues = (Dictionary<string, object>)prop.Value;
                                            if (nextValues == null) continue;
                                            //index array
                                            if (int.TryParse(prop.Key, out index))
                                            {
                                                var nextValue = nextValues.First();
                                                if (nextValue.Value.GetType() == typeof(Dictionary<string, object>))
                                                    list.Add(ParserDocumentToJsonV3Step02Next((Dictionary<string, object>)nextValue.Value, dictParams));
                                                else
                                                    list.Add(nextValue.Value);
                                            }
                                            else
                                            {
                                                if (nextValues.GetType() == typeof(Dictionary<string, object>))
                                                    list.Add(ParserDocumentToJsonV3Step02Next((Dictionary<string, object>)nextValues, dictParams));
                                                else
                                                    list.Add(nextValues);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        list.Add(ParserDocumentToJsonV3Step02Next(nextMeta, dictParams));
                                    }
                                }
                                else
                                    list.Add(value.Value);
                            }
                            obj.Add(property.Key, list);
                        }
                        else
                        {
                            var value = values.First();
                            if (value.Value.GetType() == typeof(Dictionary<string, object>))
                                obj.Add(property.Key, ParserDocumentToJsonV3Step02Next((Dictionary<string, object>)value.Value, dictParams));
                            else
                                obj.Add(property.Key, value.Value);
                        }
                    }
                }
            }
            if (obj.Count > 0) return obj;
            array.RemoveAll(o => o == null);
            return array;
        }
        public JToken ParserDocumentToJsonV3Step03(object data, ConcurrentDictionary<string, MEParamsInfo> dictParams, ConcurrentDictionary<string, METemplateParamsInfo> templateParams)
        {
            var json = JsonConvert.SerializeObject(data);
            var obj = JsonConvert.DeserializeObject(json) as JToken;
            var mergeOpt = new JsonMergeSettings()
            {
                MergeNullValueHandling = MergeNullValueHandling.Ignore,
                MergeArrayHandling = MergeArrayHandling.Merge
            };
            foreach (JToken item in obj)
            {
                var param = this._emrDocumentHelper.GetParamByNoV3(dictParams, item.Path);
                //chi xet kieu du lieu list moi co group
                if (param != null)
                {
                    if (templateParams != null)
                    {
                        templateParams.TryGetValue(item.Path, out METemplateParamsInfo temptParam);
                        if (param.MEParamType == EmrParamTypes.List.ToString() && temptParam != null && temptParam.MEParamRelationAllowMerge)
                        {
                            var array = obj[item.Path] as JArray;
                            if (array != null && array.Count > 0)
                            {
                                if (array[0].Type == JTokenType.Object)
                                {
                                    var objIdx0 = array[0] as JObject;
                                    for (int i = 1; i < array.Count; i++)
                                    {
                                        var to = array[i] as JObject;
                                        var v = (JObject)to.DeepClone();
                                        to.Merge(objIdx0, mergeOpt);
                                        to.Merge(v, mergeOpt);
                                        array[i] = to;
                                    }
                                    obj[item.Path] = array;
                                }
                            }
                        }
                    }
                }
            }
            return obj;//.ToString();
        }
        private object ParserCheckboxV3(object data, ConcurrentDictionary<string, MEParamsInfo> dictParams, MEParamsInfo parent)
        {
            if (data.GetType() != typeof(Dictionary<string, object>)) return data.ToString();
            var meta = (Dictionary<string, object>)data;

            var list = new List<object>();
            foreach (var property in meta)
            {
                var values = (Dictionary<string, object>)property.Value;
                if (values == null) return null;
                var value = values.First();
                var param = this._emrDocumentHelper.GetParamByNoV3(dictParams, property.Key);
                //ko tim thay param con tren mau
                if (param == null)
                    list.Add(value.Value);
                else
                {
                    // tim thay thi kiem tra co dc check ko
                    if (parent.MEParamValue == value.Value.ToString())
                        list.Add(param.MEParamValue);
                }
            }
            return list;
        }
        private object ParserRadioV3(object data, ConcurrentDictionary<string, MEParamsInfo> dictParams, MEParamsInfo parent)
        {
            if (data.GetType() != typeof(Dictionary<string, object>)) return data.ToString();
            var meta = (Dictionary<string, object>)data;
            foreach (var property in meta)
            {
                var values = (Dictionary<string, object>)property.Value;
                if (values == null) return null;
                var param = this._emrDocumentHelper.GetParamByNoV3(dictParams, property.Key);
                if (param == null) AppendParamNotFoundNotify(property.Key + "; ");
                var value = values.First();
                if (parent.MEParamValue.ToUpper() == value.Value.ToString().ToUpper())
                    return param.MEParamValue;
            }
            return ParserDocumentToJsonV3Step02Next(meta, dictParams);
        }
        private void AppendParamNotFoundNotify(string text)
        {
            var label = " Không tìm thấy thẻ: ";
            if (this._msgNotification.InvokeRequired)
            {
                this._msgNotification.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate ()
                {
                    if (this._msgNotification.Text.Contains(label))
                        this._msgNotification.Text += text;
                    else
                        this._msgNotification.Text += label + text;
                });
            }
            else
            {
                if (this._msgNotification.Text.Contains(label))
                    this._msgNotification.Text += text;
                else
                    this._msgNotification.Text += label + text;
            }
        }
        #endregion
    }

    public class IgnoreEmptyProNameSerializerContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (string.IsNullOrEmpty(property.PropertyName))
            {
                property.ShouldSerialize = i => false;
                property.Ignored = true;
            }
            return property;
        }
    }
}
