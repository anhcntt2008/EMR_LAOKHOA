/**C4585C279A88E8537C1A338EFE5484F9**/
using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraRichEdit;
using BOSCommon;
using BOSERP;
using System.Globalization;
using System.Drawing;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using DevExpress.XtraRichEdit.Commands;
using System.Text.RegularExpressions;
using System.IO;
using DevExpress.XtraRichEdit.Export;
using QRCoder;
using DevExpress.XtraRichEdit.API.Layout;
using Emr;
using DevExpress.BarCodes;
using System.Windows.Forms;
using System.Collections.Concurrent;
using DevExpress.XtraRichEdit.API.Native.Implementation;

namespace Clas.Emr.Core
{
    public class EmrDocumentHelper
    {
        private RichEditControl _richEditCtrl;
        private METemplateParamsController _templateParamsCtrl;
        private MEEmrActionsController _actionsController;
        private DataAccess _dataHelper;
        private MEParamLookupDatasController _lookupDataCtrl;
        private MEEmrSymbolsController _symbolCtrl;

        //MD5 hash from password - uthv for detail
        private readonly string _shareEmrPassword = "4DF04D407E588A7B74C2C9E333C2F256";
        private QRCodeGenerator _qrGenerator;
        private Dictionary<string, Image> _symbolCaching;

        public char CODES { get; private set; }
        public string STAG { get; private set; }
        public string SDTAG { get; private set; }

        public char TAGS { get; private set; }
        public string GTAG { get; private set; }
        public string BTAG { get; private set; }
        public string ETAG { get; private set; }
        public string ShareEmrPassword { get { return this._shareEmrPassword; } }

        private List<METemplateParamsInfo> _templateParams { get; set; }
        private ConcurrentDictionary<string, METemplateParamsInfo> _templateParamDictPath { get; set; }
        private List<METemplateParamsInfo> _disabledTemplateParams { get; set; }
        private METemplateParamsInfo[] _signedAsGroupTemplateParams { get; set; }

        private ConcurrentDictionary<Field, EmrField> _fieldToCodeCache;
        private ConcurrentDictionary<string, Field> _codeToFieldCache;

        private readonly PlainTextDocumentExporterOptions _plainTextExportCfg;
        private List<Field> _disabledFields;
        private readonly TextFragmentOptions _notAllowExtendingDocumentRange;
        private string _hospitalProject = BOSApp.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.HOSPITAL_PROJECT);

        public EmrDocumentHelper()
        {
        }
        public EmrDocumentHelper(RichEditControl _richEditCtrl)
        {
            this._richEditCtrl = _richEditCtrl;
            this._actionsController = new MEEmrActionsController();
            this._templateParamsCtrl = new METemplateParamsController();
            this._lookupDataCtrl = new MEParamLookupDatasController();
            this._symbolCtrl = new MEEmrSymbolsController();
            this._dataHelper = new DataAccess();
            this.CODES = EmrParam.CodeSeparator;
            this.TAGS = EmrParam.TagCodeSeparator;
            this.BTAG = EmrParam.BeginTag;
            this.ETAG = EmrParam.EndTag;
            this.GTAG = EmrParam.GuidTag;
            this.STAG = EmrParam.UserSign;
            this.SDTAG = EmrParam.UserSignDate;
            _qrGenerator = new QRCodeGenerator();
            _fieldToCodeCache = new ConcurrentDictionary<Field, EmrField>();
            _codeToFieldCache = new ConcurrentDictionary<string, Field>();
            _plainTextExportCfg = new PlainTextDocumentExporterOptions() { ExportHiddenText = true, ExportBulletsAndNumbering = false };
            _disabledFields = new List<Field>();
            _notAllowExtendingDocumentRange = new DevExpress.XtraRichEdit.API.Native.Implementation.TextFragmentOptions { AllowExtendingDocumentRange = false };
        }

        #region Template
        /// <summary>
        ///  mac dinh group cua the moi add vao la template.METemplateGuid
        /// </summary>
        /// <param name="param"></param>
        /// <param name="onlyParentParam"></param>
        public void AddParamToTemplateAtCaretPosition(MEParamsInfo param, string gid, bool onlyParentParam = false)
        {
            var doc = _richEditCtrl.Document;
            AddParamAtPosition(doc.CaretPosition, param, gid, onlyParentParam);
        }
        public DocumentPosition AddParamAtPosition(DocumentPosition pos, MEParamsInfo param, string gid, bool onlyParentParam = false, string prefix = "", bool overrideOnlyParentParam = false)
        {
            var doc = _richEditCtrl.Document;
            /*TODO: Check current position is in a field will be overlap*/
            doc.BeginUpdate();
            var meParamChildren = AppMemCache.GetParamRelationsFromDict(param.MEParamID);
            // if not have children single or list is the same
            if (meParamChildren.Count == 0 || onlyParentParam)
            {
                var code = string.IsNullOrEmpty(prefix) ? param.MEParamNo : prefix + CODES + param.MEParamNo;
                var fieldRange = doc.InsertText(pos, $"{code}{TAGS}{GTAG}={gid}");
                //Convert the inserted text to the field 
                var field = doc.Fields.Create(fieldRange);
                doc.InsertText(field.ResultRange.Start, BTAG + param.MEParamValue + ETAG + param.MEParamUnit);
                field.ShowCodes = false;
                pos = field.Range.End;
            }
            else
            {
                if (param.MEParamControlType == EmrParamControlTypes.Checkbox.ToString())
                {
                    pos = this.ExtractSingleParam(doc, param, pos, prefix, gid, onlyParentParam, overrideOnlyParentParam);
                }
                else
                {
                    if (param.MEParamType == EmrParamTypes.Single.ToString())
                    {
                        //param nay co children add children the cum
                        pos = this.ExtractSingleParam(doc, param, pos, prefix, gid, onlyParentParam, overrideOnlyParentParam);
                    }
                    else if (param.MEParamType == EmrParamTypes.List.ToString())
                    {
                        pos = this.ExtractListParamV2(doc, param, pos, prefix, gid, 0, 0, onlyParentParam, overrideOnlyParentParam);
                    }
                }
            }
            doc.EndUpdate();
            return pos;
        }

        public void AddActionToTemplate(MEEmrActionsInfo action, METemplatesInfo template)
        {
            if (action == null) return;
            var doc = _richEditCtrl.Document;
            /*TODO: Check current position is in a action will be overlap*/
            doc.BeginUpdate();
            var linkRange = doc.InsertText(doc.CaretPosition, action.MEEmrActionCaption);
            //Convert the inserted text to the field 
            var link = doc.Hyperlinks.Create(linkRange);
            link.Anchor = action.MEEmrActionName;
            link.NavigateUri = $"{action.MEEmrActionNo}{TAGS}{GTAG}={template.METemplateGuid}";
            link.ToolTip = action.MEEmrActionToolTip;
            doc.EndUpdate();
        }

        #endregion

        #region Emr

        /// <summary>
        /// init param pool chua cac tham so co the lay de goi cho api, hay app hay store
        /// </summary>
        public List<RangePermission> CreateRangePermissions(DocumentRange range, string userGroup, params string[] usernames)
        {
            List<RangePermission> rangeList = new List<RangePermission>();
            foreach (string username in usernames)
            {
                RangePermission rp = new RangePermission(range);
                rp.Group = userGroup;
                rp.UserName = username;
                rangeList.Add(rp);
            }
            return rangeList;
        }

        public DocumentRange GetActionRange(string navigateUri, string group)
        {
            var doc = this._richEditCtrl.Document;
            foreach (var field in doc.Fields)
            {
                var text = doc.GetText(field.CodeRange);
                if (text.StartsWith("HYPERLINK") && text.Contains(navigateUri) && text.Contains(group))
                {
                    return field.Range;
                }
            }
            return null;
        }
        public List<Hyperlink> GetAllHyperlinkInRange(Document doc, DocumentRange range)
        {
            var links = new List<Hyperlink>();
            foreach (var field in doc.Hyperlinks)
            {
                if (field.Range.Start > range.Start && field.Range.Start < range.End &&
                    field.Range.End > range.Start && field.Range.End < range.End)
                {
                    links.Add(field);
                }
            }
            return links;
        }
        /// <summary>
        /// by pass hyperlink
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public List<Field> GetAllDataFieldInRange(DocumentRange range)
        {
            var fields = new List<Field>();
            var doc = this._richEditCtrl.Document;
            foreach (var field in doc.Fields)
            {
                _fieldToCodeCache.TryGetValue(field, out EmrField emrField);
                if (emrField == null)
                {
                    var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                    emrField = AddCacheBindingField(field, text);
                }
                var code = emrField.Tokens[0];
                if (code.Contains("HYPERLINK")) continue;
                if (field.ResultRange.Start >= range.Start && field.ResultRange.End <= range.End)
                {
                    fields.Add(field);
                }
            }
            return fields;
        }
        public List<Field> GetAllDataFieldWithoutHyperlink(Document doc)
        {
            var fields = new List<Field>();
            foreach (var field in doc.Fields)
            {
                var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                if (text.StartsWith("HYPERLINK", StringComparison.Ordinal)) continue;
                fields.Add(field);
            }
            return fields;
        }
        public void ShowAllParam()
        {
            var command = this._richEditCtrl.CreateCommand(RichEditCommandId.ShowAllFieldCodes);
            command.Execute();
        }
        public void HideAllParam()
        {
            var command = this._richEditCtrl.CreateCommand(RichEditCommandId.ShowAllFieldResults);
            command.Execute();
        }
        public void GotoNextParam(System.Windows.Forms.Keys keyCode, int chainCount = 0)
        {
            var caret = this._richEditCtrl.Document.CaretPosition;
            var currentDoc = caret.BeginUpdateDocument();
            if (currentDoc.GetSubDocumentType() != SubDocumentType.Main)
            {
                caret.EndUpdateDocument(currentDoc);
                return;
            }
            var fields = new List<Field>();
            var doc = this._richEditCtrl.Document;

            Field nextField = null;
            if (keyCode == System.Windows.Forms.Keys.Up)//up
            {
                var cell = _richEditCtrl.Document.Tables.GetTableCell(caret);
                if (cell != null)
                {
                    for (int i = cell.Row.Index - 1; i >= 0; i--)
                    {
                        if (cell.Index >= cell.Table.Rows[i].Cells.Count)
                            nextField = GetLastFieldInCell(cell.Table.Rows[i].Cells[cell.Table.Rows[i].Cells.Count - 1]);
                        else
                            nextField = GetLastFieldInCell(cell.Table.Rows[i].Cells[cell.Index]);
                        if (nextField != null) break;
                    }
                }
                if (nextField == null)
                {
                    //do nothing 
                    //will go to next case Keys.Right
                    keyCode = System.Windows.Forms.Keys.Right;
                }
            }
            else if (keyCode == System.Windows.Forms.Keys.Down)//down
            {
                var cell = _richEditCtrl.Document.Tables.GetTableCell(caret);
                if (cell != null)
                {
                    for (int i = cell.Row.Index + 1; i < cell.Table.Rows.Count; i++)
                    {
                        if (cell.Index >= cell.Table.Rows[i].Cells.Count)
                        {
                            nextField = GetFirstFieldInCell(cell.Table.Rows[i].Cells[0]);
                        }
                        else
                        {
                            nextField = GetFirstFieldInCell(cell.Table.Rows[i].Cells[cell.Index]);
                        }
                        if (nextField != null) break;
                    }
                }
                if (nextField == null)
                {
                    // do nothing 
                    // will go to next case Keys.Left
                    keyCode = System.Windows.Forms.Keys.Left;
                }
            }

            if (keyCode == System.Windows.Forms.Keys.Left)//back
            {
                var cur = GetFieldAtPosition(caret.ToInt());
                var prevFields = new List<Field>();
                foreach (var field in doc.Fields)
                {
                    if (cur != null && field != cur)
                        prevFields.Add(field);
                    else if (cur == null && field.ResultRange.Start < caret)
                        prevFields.Add(field);
                    else
                        break;
                }
                // trong truong hop table dung kieu lay field previous se sai
                prevFields.Reverse();
                foreach (var field in prevFields)
                {
                    if (doc.Tables.Get(field.Range).Count > 0) continue;
                    if (!doc.GetText(field.CodeRange).StartsWith("HYPERLINK"))
                    {
                        nextField = field;
                        break;
                    }
                }
            }
            // mac dinh la go to next field <=> Keys.Right, nen neu khong tim thay field o cac case khac thi next thoi
            if (nextField == null)
            {
                foreach (var field in doc.Fields)
                {
                    if (field.ResultRange.Start > caret)
                    {
                        if (!doc.GetText(field.CodeRange).StartsWith("HYPERLINK"))
                        {
                            nextField = field;
                            break;
                        }
                    }
                }
            }
            if (nextField != null)
            {
                if (!IsAllowEditField(nextField) || !IsAllowEditField(nextField.ResultRange.Start))
                {
                    _fieldToCodeCache.TryGetValue(nextField, out EmrField emrField);
                    if (emrField != null)
                    {
                        var param = AppMemCache.GetParamFromDictKeyNo(emrField.CodeLevelArr.Last());
                        if (param != null && param.FK_MEParamLookupID == 0)
                        {
                            this._richEditCtrl.Document.CaretPosition = nextField.ResultRange.End;
                            if (chainCount < 5)
                                GotoNextParam(keyCode, chainCount + 1);
                            return;
                        }
                    }
                }
                this._richEditCtrl.Document.CaretPosition = this._richEditCtrl.Document.CreatePosition(nextField.ResultRange.Start.ToInt() + 1);
                var text = doc.GetText(nextField.ResultRange);
                var begin = text.IndexOf(BTAG) + 1;
                if (begin == 0) return;
                var end = text.IndexOf(ETAG);
                if (end <= 0) return;
                if (text[end - 1] == '\t')
                    end = end - 1;
                if (begin == end) return;
                var offset = text.Length - end + 1;
                var range = doc.CreateRange(nextField.ResultRange.Start.ToInt() + begin, nextField.ResultRange.Length - offset);
                doc.Selections.Clear();
                doc.Selections.Add(range);
            }
        }
        public void GotoNextParamV0(System.Windows.Forms.Keys keyCode)
        {
            var fields = new List<Field>();
            var doc = this._richEditCtrl.Document;
            var caret = this._richEditCtrl.Document.CaretPosition;
            Field nextField = null;
            if (keyCode == System.Windows.Forms.Keys.M)//up
            {
                var cell = _richEditCtrl.Document.Tables.GetTableCell(caret);
                if (cell != null)
                {
                    for (int i = cell.Row.Index - 1; i >= 0; i--)
                    {
                        nextField = GetLastFieldInCell(cell.Table.Rows[i].Cells[cell.Index]);
                        if (nextField != null) break;
                    }
                }
                if (nextField == null)
                {
                    //do nothing 
                    //will go to next case Keys.Oemcomma
                    keyCode = System.Windows.Forms.Keys.Oemcomma;
                }
            }
            else if (keyCode == System.Windows.Forms.Keys.Oem2)//down
            {
                var cell = _richEditCtrl.Document.Tables.GetTableCell(caret);
                if (cell != null)
                {
                    for (int i = cell.Row.Index + 1; i < cell.Table.Rows.Count; i++)
                    {
                        nextField = GetFirstFieldInCell(cell.Table.Rows[i].Cells[cell.Index]);
                        if (nextField != null) break;
                    }
                }
                if (nextField == null)
                {
                    //do nothing 
                    //will go to next case Keys.OemPeriod
                    keyCode = System.Windows.Forms.Keys.OemPeriod;
                }
            }

            if (keyCode == System.Windows.Forms.Keys.Oemcomma)//back
            {
                var cur = GetFieldAtPosition(caret.ToInt());
                var prevFields = new List<Field>();
                foreach (var field in doc.Fields)
                {
                    if (cur != null && field != cur)
                        prevFields.Add(field);
                    else if (cur == null && field.ResultRange.Start < caret)
                        prevFields.Add(field);
                    else
                        break;
                }
                prevFields.Reverse();
                foreach (var field in prevFields)
                {
                    if (!doc.GetText(field.CodeRange).StartsWith("HYPERLINK"))
                    {
                        nextField = field;
                        break;
                    }
                }
            }
            //mac dinh la go to next field <=> Keys.Oemcomma, nen neu khong tim thay field o cac case khac thi next thoi
            if (nextField == null)
            {
                foreach (var field in doc.Fields)
                {
                    if (field.ResultRange.Start > caret)
                    {
                        if (!doc.GetText(field.CodeRange).StartsWith("HYPERLINK"))
                        {
                            nextField = field;
                            break;
                        }
                    }
                }
            }
            if (nextField != null)
            {
                this._richEditCtrl.Document.CaretPosition = this._richEditCtrl.Document.CreatePosition(nextField.ResultRange.Start.ToInt() + 1);
                var text = doc.GetText(nextField.ResultRange);
                var begin = text.IndexOf(BTAG) + 1;
                var end = text.IndexOf(ETAG);
                if (begin == end || begin == 0 || end <= 0) return;
                var range = doc.CreateRange(nextField.ResultRange.Start.ToInt() + begin, end - begin);
                doc.Selections.Clear();
                doc.Selections.Add(range);
            }

        }
        private Field GetLastFieldInCell(TableCell tableCell)
        {
            var doc = this._richEditCtrl.Document;
            Field nextField = null;
            foreach (var field in doc.Fields)
            {
                if (field.ResultRange.Start >= tableCell.ContentRange.Start
                    && field.ResultRange.End <= tableCell.ContentRange.End)
                {
                    if (!doc.GetText(field.CodeRange).StartsWith("HYPERLINK"))
                    {
                        nextField = field;
                    }
                }
            }
            return nextField;
        }
        private Field GetFirstFieldInCell(TableCell tableCell)
        {
            var doc = this._richEditCtrl.Document;
            Field nextField = null;
            foreach (var field in doc.Fields)
            {
                if (field.ResultRange.Start >= tableCell.ContentRange.Start
                    && field.ResultRange.End <= tableCell.ContentRange.End)
                {
                    if (!doc.GetText(field.CodeRange).StartsWith("HYPERLINK"))
                    {
                        nextField = field;
                        break;
                    }
                }
            }
            return nextField;
        }

        public List<Field> GetAllDataFieldInRangeOrDocument(DocumentRange range = null)
        {
            var doc = this._richEditCtrl.Document;
            if (range == null || range.Length == 0)
            {
                return doc.Fields.ToList();
            }
            else
            {
                return GetAllDataFieldInRange(range);
            }

        }
        /// <summary>
        /// cac table duoc xem theo tang dan theo start nen func nay luon dung
        /// </summary>
        /// <param name="richEditCtrl"></param>
        /// <param name="updateField"></param>
        /// <returns></returns>
        public Table GetTableFromDocument(RichEditControl richEditCtrl, Field updateField)
        {
            Table result = null;
            if (_richEditCtrl.InvokeRequired)
            {
                _richEditCtrl.BeginInvoke((Action)(() =>
                {
                    var doc = richEditCtrl.Document;
                    foreach (var item in doc.Tables)
                    {
                        if (item.Range.Start > updateField.Range.Start
                            && item.Range.End < updateField.Range.End)
                        {
                            result = item;
                            break;
                            //return item;
                        }
                    }
                }));
            }
            else
            {
                var doc = richEditCtrl.Document;
                foreach (var item in doc.Tables)
                {
                    if (item.Range.Start > updateField.Range.Start
                        && item.Range.End < updateField.Range.End)
                    {
                        return item;
                    }
                }
                return null;
            }
            return result;
        }
        public string GetFieldPrefix(Field field)
        {
            if (field == null) return string.Empty;
            var doc = this._richEditCtrl.Document;
            var text = doc.GetText(field.CodeRange);
            if (text == null) return string.Empty;
            var tokens = text.Split(TAGS);
            if (tokens == null) return string.Empty;
            var codes = tokens[0].Split(CODES);
            return string.Join(CODES.ToString(), codes.Take(codes.Length - 1));
        }
        /// <summary>
        /// get fields from document by code
        /// check group to return
        /// </summary>
        /// <param name="group"></param>
        /// <param name="code"></param>
        /// <param name="endWith">field end with param no</param>
        /// <returns>fields not null, if there isn't any field then count=0</returns>
        public List<Field> GetBindingFields(string group, string code, string transaction, bool allowMulti = true, bool endWith = false, HashSet<Field> exlFields = null)
        {
            var doc = this._richEditCtrl.Document;
            try
            {
                var fields = new List<Field>();
                //int count = 0;
                //var start = DateTime.Now;
                foreach (var field in doc.Fields)
                {
                    if (exlFields != null && exlFields.Contains(field))
                        continue;

                    _fieldToCodeCache.TryGetValue(field, out EmrField emrField);
                    if (emrField == null)
                    {
                        var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                        emrField = AddCacheBindingField(field, text);
                        //count++;
                    }
                    var codes = emrField.Tokens;// text.Split(TAGS);
                    bool ok = false;
                    if (endWith)
                        ok = emrField.CodeLevelArr.Last() == (code);

                    if (codes != null && (code == codes[0] || ok))
                    {
                        var gid = emrField.Gid;
                        if (group.Equals(gid))
                        {
                            codes = doc.GetText(field.CodeRange, _plainTextExportCfg)?.Split(TAGS); //get lai vi co the field da dc ky ten
                            var tid = codes?.Where(t => t.StartsWith($"{EmrParam.TransactionIdTag}=")).FirstOrDefault();
                            tid = tid != null ? tid.Substring(EmrParam.TransactionIdTag.Length + 1) : string.Empty;
                            var s = codes?.Where(t => t.StartsWith($"{EmrParam.UserSign}=")).FirstOrDefault();
                            //field signed sẽ khong đc update
                            if (s == null && (string.IsNullOrEmpty(tid) || string.IsNullOrEmpty(transaction) || tid.Equals(transaction)))
                            {
                                fields.Add(field);
                                if (!allowMulti) return fields;
                            }
                        }
                    }
                }
                //Console.WriteLine("AddCacheBindingField: " + count);
                //Console.WriteLine("AddCacheBindingField: " + (DateTime.Now - start).TotalMilliseconds);
                return fields;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }
        /// <summary>
        /// giong  GetBindingFields nhung dc dieu chinh de lay ca cac field da dc ky
        /// </summary>
        /// <param name="group"></param>
        /// <param name="code"></param>
        /// <param name="transaction"></param>
        /// <param name="allowMulti"></param>
        /// <param name="endWith"></param>
        /// <param name="exlFields"></param>
        /// <returns></returns>
        public List<Field> GetActionFields(string group, string code, string transaction, bool allowMulti = true, bool endWith = false, HashSet<Field> exlFields = null)
        {
            var doc = this._richEditCtrl.Document;
            var fields = new List<Field>();
            foreach (var field in doc.Fields)
            {
                if (exlFields != null && exlFields.Contains(field))
                    continue;

                _fieldToCodeCache.TryGetValue(field, out EmrField emrField);
                if (emrField == null)
                {
                    var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                    emrField = AddCacheBindingField(field, text);
                }
                var codes = emrField.Tokens;
                bool ok = false;
                if (endWith)
                    ok = emrField.CodeLevelArr.Last() == (code);

                if (code == codes[0] || ok)
                {
                    var gid = emrField.Gid;
                    if (group.Equals(gid))
                    {
                        codes = doc.GetText(field.CodeRange, _plainTextExportCfg).Split(TAGS);
                        var tid = codes.Where(t => t.StartsWith($"{EmrParam.TransactionIdTag}=")).FirstOrDefault();
                        tid = tid != null ? tid.Substring(EmrParam.TransactionIdTag.Length + 1) : string.Empty;
                        //field signed se van dc lay vi la param
                        if ((string.IsNullOrEmpty(tid) || string.IsNullOrEmpty(transaction) || tid.Equals(transaction)))
                        {
                            fields.Add(field);
                            if (!allowMulti) return fields;
                        }
                    }
                }
            }
            return fields;
        }
        /// <summary>
        /// get all field in range
        /// </summary>
        /// <param name="range"></param>
        /// <param name="group"> can be empty will get all field</param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public List<EmrField> GetBindingFieldsInRange(DocumentRange range, string group, string transaction)
        {
            var doc = this._richEditCtrl.Document;
            List<EmrField> listFields = new List<EmrField>();
            foreach (var field in doc.Fields)
            {
                if (field.ResultRange.Start.ToInt() >= range.Start.ToInt() && field.ResultRange.End.ToInt() <= range.End.ToInt())
                {
                    _fieldToCodeCache.TryGetValue(field, out EmrField emrField);

                    if (emrField == null)
                    {
                        var fieldCode = doc.GetText(field.CodeRange, _plainTextExportCfg);
                        emrField = AddCacheBindingField(field, fieldCode);
                    }

                    var tokens = emrField.Tokens;
                    var gid = emrField.Gid;
                    var codes = emrField.CodeLevelArr;
                    if (string.IsNullOrEmpty(group) || group.Equals(gid))
                    {
                        var tid = codes.Where(t => t.StartsWith($"{EmrParam.TransactionIdTag}=")).FirstOrDefault();
                        tid = tid != null ? tid.Substring(EmrParam.TransactionIdTag.Length + 1) : string.Empty;
                        var s = codes.Where(t => t.StartsWith($"{EmrParam.UserSign}=")).FirstOrDefault();
                        //field signed sẽ khong đc update
                        if (s == null && (string.IsNullOrEmpty(tid) || string.IsNullOrEmpty(transaction) || tid.Equals(transaction)))
                        {
                            listFields.Add(new EmrField()
                            {
                                Tokens = tokens,
                                Gid = gid,
                                Field = field,
                                FieldCode = emrField.FieldCode,
                                CodeLevelStr = tokens[0],
                                CodeLevelArr = codes,
                                ParamNo = codes.Last()

                            });
                        }
                    }
                }
            }
            return listFields;
        }
        public void GroupAndPrefixesSelectParam(Document doc, DocumentRange selectedRange,
            string group, string prefix, string parentParamNo)
        {
            doc.BeginUpdate();
            var path = parentParamNo;
            if (!string.IsNullOrEmpty(prefix))
                path = prefix + CODES + parentParamNo;

            var gui = string.IsNullOrEmpty(group) ? Guid.NewGuid().ToString() : group;
            foreach (var field in doc.Fields)
            {
                if (field.ResultRange.Start >= selectedRange.Start && field.ResultRange.Start <= selectedRange.End &&
                    field.ResultRange.End >= selectedRange.Start && field.ResultRange.End <= selectedRange.End)
                {
                    var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                    //bo qua hyperlink
                    if (text.StartsWith("HYPERLINK"))
                        continue;
                    var code = text.Split(TAGS)[0];
                    //if (code.Equals(prefix)) continue;
                    if (code.Equals(path)) continue;

                    field.ShowCodes = true;
                    if (text.StartsWith(parentParamNo + TAGS))
                        // truong hop thay the todieutri_ylenh-danhsachdonthuoc bang template chua the danhsachdonthuoc
                        code = (string.IsNullOrEmpty(path) ? "" : prefix + CODES) + code;
                    else if (!string.IsNullOrEmpty(parentParamNo) && code.StartsWith(parentParamNo + CODES))
                        // truong hop thay the todieutri_ylenh-danhsachdonthuoc bang template chua danhsachdonthuoc-0-donthuoc 
                        // 2 the danh sach interset 
                        code = (string.IsNullOrEmpty(path) ? "" : prefix + CODES) + code;
                    else
                        code = (string.IsNullOrEmpty(path) ? "" : path + CODES) + code;

                    doc.Replace(field.CodeRange, $"{code}{TAGS}{GTAG}={gui}");
                    TrackDisabledField(code, field);
                    field.ShowCodes = false;
                }
            }
            foreach (var link in doc.Hyperlinks)
            {
                if (link.Range.Start >= selectedRange.Start && link.Range.Start <= selectedRange.End &&
                    link.Range.End >= selectedRange.Start && link.Range.End <= selectedRange.End)
                {
                    var code = link.NavigateUri.Split(TAGS)[0];
                    link.NavigateUri = $"{code}{TAGS}{GTAG}={gui}";
                }
            }
            doc.EndUpdate();
        }
        public void ClearGroupSelectParam(DevExpress.XtraRichEdit.API.Native.Document doc, DocumentRange selectedRange, string group)
        {
            doc.BeginUpdate();
            foreach (var field in doc.Fields)
            {
                if (field.ResultRange.Start.ToInt() > selectedRange.Start.ToInt() && field.ResultRange.Start.ToInt() < selectedRange.End.ToInt() &&
                    field.ResultRange.End.ToInt() > selectedRange.Start.ToInt() && field.ResultRange.End.ToInt() < selectedRange.End.ToInt())
                {
                    field.ShowCodes = true;
                    var code = doc.GetText(field.CodeRange).Split(TAGS)[0];
                    doc.Replace(field.CodeRange, $"{code}{TAGS}{GTAG}={group}");
                    field.ShowCodes = false;
                }
            }
            doc.EndUpdate();
        }
        public Dictionary<string, string> GetParamProperties(DevExpress.XtraRichEdit.API.Native.Document doc, int caretPosition)
        {
            int index = 0;

            foreach (var field in doc.Fields)
            {
                if (field.ResultRange.Start.ToInt() <= caretPosition && caretPosition <= field.ResultRange.End.ToInt())
                {
                    var properties = new Dictionary<string, string>();
                    var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                    //bo qua hyperlink
                    if (!text.StartsWith("HYPERLINK"))
                    {
                        var tags = text.Split(TAGS);
                        properties.Add("type", "data");
                        foreach (var tag in tags)
                        {
                            var infos = tag.Split('=');
                            if (infos.Length == 1)
                            {
                                properties.Add("code_by_level", infos[0]);
                                var noTokens = infos[0].Split(CODES);
                                MEParamsInfo param;
                                if (!int.TryParse(noTokens.Last(), out index))
                                    param = AppMemCache.GetParamFromDictKeyNo(noTokens.Last());
                                else
                                    param = AppMemCache.GetParamFromDictKeyNo(noTokens[noTokens.Length - 2 >= 0 ? noTokens.Length - 2 : 0]);
                                if (param != null)
                                {
                                    properties.Add("MEParamNo", param.MEParamNo);
                                    properties.Add("MEParamName", param.MEParamName);
                                    properties.Add("MEParamCaption", param.MEParamCaption);
                                    properties.Add("MEParamType", param.MEParamType);
                                    properties.Add("MEParamValue", param.MEParamValue);
                                }
                            }
                            else
                            {
                                //trung key 'u' neu edit 2 lan
                                if (!properties.ContainsKey(infos[0]))
                                    properties.Add(infos[0], infos[1]);
                            }
                        }
                    }
                    else
                    {
                        properties.Add("type", "action");
                        var tags = text.Split(' ');
                        foreach (var tag in tags)
                        {
                            if (tag.Contains($"|{GTAG}="))
                            {
                                var tokens = tag.Split(TAGS);
                                if (tokens.Length > 0)
                                {
                                    var actionNo = tokens[0].Replace("\"", "");
                                    properties.Add("MEEmrActionNo", actionNo);
                                    var action = _actionsController.GetObjectByNo(actionNo) as MEEmrActionsInfo;
                                    if (action != null)
                                    {
                                        properties.Add("MEEmrActionName", action.MEEmrActionName);
                                        properties.Add("MEEmrActionCaption", action.MEEmrActionCaption);
                                        properties.Add("MEEmrActionType", action.MEEmrActionType);
                                        properties.Add("MEEmrActionDataType", action.MEEmrActionDataType);
                                        properties.Add("MEEmrActionUri", action.MEEmrActionUri);
                                        properties.Add("MEEmrActionNewGuid", action.MEEmrActionNewGuid ? "Có" : "Không");
                                    }
                                    if (tokens.Length > 1)
                                        properties.Add(EmrParam.GuidTag, tokens[1].Replace($"{ GTAG }=", "").Replace("\"", ""));

                                }
                            }
                        }
                    }
                    return properties;
                }
            }
            return null;
        }
        public List<KeyValuePair<string, string>> GetParamInfos(DevExpress.XtraRichEdit.API.Native.Document doc, int caretPosition)
        {
            foreach (var field in doc.Fields)
            {
                if (field.ResultRange.Start.ToInt() <= caretPosition && caretPosition <= field.ResultRange.End.ToInt())
                {
                    var properties = new List<KeyValuePair<string, string>>();
                    var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                    //bo qua hyperlink
                    if (!text.StartsWith("HYPERLINK"))
                    {
                        var tags = text.Split(TAGS);
                        properties.Add(new KeyValuePair<string, string>("Loại", "Thẻ dữ liệu"));
                        foreach (var tag in tags)
                        {
                            var infos = tag.Split('=');
                            if (infos.Length == 1)
                            {
                                properties.Add(new KeyValuePair<string, string>("Mã theo cấp", infos[0]));
                                var noTokens = infos[0].Split(CODES);
                                var param = AppMemCache.GetParamFromDictKeyNo(noTokens.Last());
                                if (param != null)
                                {
                                    properties.Add(new KeyValuePair<string, string>("Mã thẻ", param.MEParamNo));
                                    properties.Add(new KeyValuePair<string, string>("Tên thẻ", param.MEParamName));
                                    properties.Add(new KeyValuePair<string, string>("Tiêu đề", param.MEParamCaption));
                                    properties.Add(new KeyValuePair<string, string>("Loại thẻ", param.MEParamType));
                                    properties.Add(new KeyValuePair<string, string>("Định dạng dữ liệu", param.MEParamFormatType));
                                    properties.Add(new KeyValuePair<string, string>("Định dạng", param.MEParamFormatString));
                                    properties.Add(new KeyValuePair<string, string>("Loại control", param.MEParamControlType));
                                    properties.Add(new KeyValuePair<string, string>("Không in ra", param.MEParamPrintHidden ? "Có" : "Không"));
                                    properties.Add(new KeyValuePair<string, string>("Chiều cao ảnh", param.MEParamImageHeight.ToString()));
                                    properties.Add(new KeyValuePair<string, string>("Chiều rộng ảnh", param.MEParamImageWidth.ToString()));
                                    properties.Add(new KeyValuePair<string, string>("Giá trị mặc định", param.MEParamValue));
                                    properties.Add(new KeyValuePair<string, string>("Giá trị nhỏ nhất", param.MEParamMinValue.ToString()));
                                    properties.Add(new KeyValuePair<string, string>("Giá trị lớn nhất", param.MEParamMaxValue.ToString()));

                                    if (_templateParams != null && !string.IsNullOrEmpty(infos[0]))
                                    {
                                        var fieldPath = GetTemplateFieldPath(infos[0]);// Regex.Replace(infos[0], $"\\{CODES}([\\d]*)\\{CODES}", "[*].");
                                        var tempParam = _templateParams.Where(o => o.METemplateParamPath == fieldPath).FirstOrDefault();
                                        if (tempParam != null)
                                        {
                                            properties.Add(new KeyValuePair<string, string>("Theo mẫu - Định dạng dữ liệu", tempParam.MEParamFormatType));
                                            properties.Add(new KeyValuePair<string, string>("Theo mẫu - Định dạng", tempParam.MEParamFormatString));
                                            properties.Add(new KeyValuePair<string, string>("Theo mẫu - Không in ra", tempParam.METemplateParamPrintHidden ? "Có" : "Không"));
                                            properties.Add(new KeyValuePair<string, string>("Theo mẫu - Cập nhật dữ liệu cho", tempParam.METemplateParamUpdateTo.ToString()));
                                            properties.Add(new KeyValuePair<string, string>("Theo mẫu - Trộn xuống dòng cùng cấp", tempParam.MEParamRelationAllowMerge ? "Có" : "Không"));
                                            properties.Add(new KeyValuePair<string, string>("Theo mẫu - Chiều cao ảnh", tempParam.MEParamImageHeight.ToString()));
                                            properties.Add(new KeyValuePair<string, string>("Theo mẫu - Chiều rộng ảnh", tempParam.MEParamImageWidth.ToString()));
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (EmrParam.TagsName.ContainsKey(infos[0]))
                                    properties.Add(new KeyValuePair<string, string>(EmrParam.TagsName[infos[0]], infos[1]));
                                else
                                    properties.Add(new KeyValuePair<string, string>(infos[0], infos[1]));
                            }
                        }
                    }
                    else
                    {
                        properties.Add(new KeyValuePair<string, string>("Loại", "Thẻ chức năng"));
                        var tags = text.Split(' ');
                        foreach (var tag in tags)
                        {
                            if (tag.Contains($"|{GTAG}="))
                            {
                                var tokens = tag.Split(TAGS);
                                if (tokens.Length > 0)
                                {
                                    var actionNo = tokens[0].Replace("\"", "");
                                    properties.Add(new KeyValuePair<string, string>("Mã chức năng", actionNo));
                                    var action = _actionsController.GetObjectByNo(actionNo) as MEEmrActionsInfo;
                                    if (action != null)
                                    {
                                        properties.Add(new KeyValuePair<string, string>("Tên chức năng", action.MEEmrActionName));
                                        properties.Add(new KeyValuePair<string, string>("Tiêu đề", action.MEEmrActionCaption));
                                        properties.Add(new KeyValuePair<string, string>("Loại chức năng", action.MEEmrActionType));
                                        properties.Add(new KeyValuePair<string, string>("Loại dữ liệu", action.MEEmrActionDataType));
                                        properties.Add(new KeyValuePair<string, string>("Api/Sp", action.MEEmrActionUri));
                                        properties.Add(new KeyValuePair<string, string>("Tự động sinh mã nhóm", action.MEEmrActionNewGuid ? "Có" : "Không"));
                                    }
                                    if (tokens.Length > 1)
                                        properties.Add(new KeyValuePair<string, string>("Nhóm", tokens[1].Replace($"{ GTAG }=", "").Replace("\"", "")));

                                }
                            }
                        }
                    }
                    return properties;
                }
            }
            return null;
        }
        public void ClearParagrapFormat(DevExpress.XtraRichEdit.API.Native.Document document, DocumentRange range)
        {
            document.EndUpdate();
            // Create and customize an object  
            // that sets character formatting for the selected range
            CharacterProperties cp = document.BeginUpdateCharacters(range);
            CharacterStyle pstyle = document.CharacterStyles["Default Paragraph Font"];
            if (pstyle != null)
                cp.Style = pstyle;
            else
            {
                cp.ForeColor = Color.Black;
                cp.Bold = false;
                cp.Italic = false;
                cp.Underline = UnderlineType.None;
                cp.Strikeout = StrikeoutType.None;
            }
            // Finalize modifications  
            // with this method call 
            document.EndUpdateCharacters(cp);
            document.BeginUpdate();
        }

        /// <summary>
        /// list param has children is viewed as table
        /// mac dinh group cua the moi add vao la template.METemplateGuid
        /// chi gioi han 3 cap ko recusive
        /// </summary>
        /// <param name="param"></param>
        /// <param name="postion"></param>
        /// <param name="prefix">exp: Medication_MedicationList_....</param>
        /// <returns></returns>
        public DocumentPosition ExtractListParamV2(DevExpress.XtraRichEdit.API.Native.Document doc,
            MEParamsInfo param, DocumentPosition postion, string prefix, string group, int rowCount = 0, int colCount = 0,
            bool onlyParentParam = false, bool overrideOnlyParentParam = false)
        {
            var listEmrParams = new List<MEParamsInfo>();
            var listParamRelations = new Dictionary<int, List<MEParamRelationsInfo>>();
            //field needed to append update
            var childrens = GetParamRelations(listParamRelations, param.MEParamID);

            //var range = doc.InsertText(postion, string.Format("{0}", param.MEParamCaption));
            //field needed to append update
            if (string.IsNullOrEmpty(prefix))
                prefix = param.MEParamNo;
            else
                prefix = $"{prefix}{CODES}{param.MEParamNo}";

            DocumentRange range;
            if (_richEditCtrl.InvokeRequired)
            {
                _richEditCtrl.BeginInvoke((Action)(() =>
                {
                    range = doc.InsertText(postion, string.Format("{0}", param.MEParamCaption));
                    Field parentField = doc.Fields.Create(postion, $"{prefix}{TAGS}{GTAG}={group}");
                    parentField.ShowCodes = false;
                    colCount = colCount != 0 ? colCount + 1 : param.MEParamSampleCount + 1;
                    rowCount = rowCount != 0 ? rowCount + 1 : (param.MEParamSampleCount == 0 ? 2 : param.MEParamSampleCount + 1);
                    if (!onlyParentParam || overrideOnlyParentParam)
                    {
                        //table dang bang ngang
                        if (param.MEParamListType == EmrParamListTypes.Horizontal.ToString())
                        {
                            ExtractHorizontalTable(doc, parentField, colCount, childrens, listEmrParams, prefix, group, listParamRelations, onlyParentParam);
                        }
                        else
                        {
                            ExtractVerticalTable(doc, parentField, rowCount, childrens, postion, listEmrParams, prefix, group, listParamRelations, false, overrideOnlyParentParam);
                        }
                    }
                    else
                    {
                        doc.InsertText(parentField.ResultRange.Start, $"{BTAG}{param.MEParamValue}{ETAG}{param.MEParamUnit}");
                    }
                    postion = doc.InsertText(doc.CreatePosition(parentField.Range.End.ToInt() + 1), Environment.NewLine).End;
                }));
            }
            else
            {
                range = doc.InsertText(postion, string.Format("{0}", param.MEParamCaption));
                Field parentField = doc.Fields.Create(postion, $"{prefix}{TAGS}{GTAG}={group}");
                parentField.ShowCodes = false;
                colCount = colCount != 0 ? colCount + 1 : param.MEParamSampleCount + 1;
                rowCount = rowCount != 0 ? rowCount + 1 : (param.MEParamSampleCount == 0 ? 2 : param.MEParamSampleCount + 1);
                if (!onlyParentParam || overrideOnlyParentParam)
                {
                    //table dang bang ngang
                    if (param.MEParamListType == EmrParamListTypes.Horizontal.ToString())
                    {
                        ExtractHorizontalTable(doc, parentField, colCount, childrens, listEmrParams, prefix, group, listParamRelations, onlyParentParam);
                    }
                    else
                    {
                        ExtractVerticalTable(doc, parentField, rowCount, childrens, postion, listEmrParams, prefix, group, listParamRelations, false, overrideOnlyParentParam);
                    }
                }
                else
                {
                    doc.InsertText(parentField.ResultRange.Start, $"{BTAG}{param.MEParamValue}{ETAG}{param.MEParamUnit}");
                }

                postion = doc.InsertText(doc.CreatePosition(parentField.Range.End.ToInt() + 1), Environment.NewLine).End;
            }
            return postion;
            //return parentField.Range.End;
        }

        private void ExtractVerticalTable(Document doc, Field parentField, int rowCount, List<MEParamRelationsInfo> childrens, DocumentPosition postion,
            List<MEParamsInfo> listEmrParams, string prefix, string group, Dictionary<int, List<MEParamRelationsInfo>> listParamRelations, bool onlyParentParam = false
            , bool overrideOnlyParentParam = false)
        {
            if (_richEditCtrl.InvokeRequired)
            {
                _richEditCtrl.BeginInvoke((Action)(() =>
                {
                    Table table = doc.Tables.Create(parentField.ResultRange.Start,
                   rowCount,
                   1,
                   AutoFitBehaviorType.AutoFitToWindow);
                    doc.InsertSingleLineText(table.Rows[0].Cells[0].ContentRange.Start, "#");
                    //lan luot add cac cot/ row
                    for (int colChildIdx = 1; colChildIdx <= childrens.Count(); colChildIdx++)
                    {
                        var c = childrens[colChildIdx - 1];
                        var childParam = GetParamByID(listEmrParams, c.FK_MEParamChildID);
                        var nextChildren = GetParamRelations(listParamRelations, childParam.MEParamID);
                        if (!c.MEParamRelationGroupFooter)
                        {
                            if (childParam.MEParamType == EmrParamTypes.Single.ToString())
                            {
                                var cell = table.Rows[0].Cells.Append();
                                //insert caption for param
                                doc.InsertSingleLineText(cell.ContentRange.Start, childParam.MEParamCaption);
                                // if it also have children
                                //TODO testing
                                if (nextChildren.Count > 0 && !c.MEParamRelationOnlyAddMe)
                                {
                                    for (int samp = 0; samp < rowCount - 1; samp++)
                                    {
                                        postion = this.ExtractSingleParam(doc, childParam, table.Rows[samp + 1].Cells[colChildIdx].ContentRange.Start, $"{prefix}{CODES}{samp}", group, false, overrideOnlyParentParam);
                                    }
                                }
                                else
                                {
                                    for (int samp = 0; samp < rowCount - 1; samp++)
                                    {
                                        //insert field
                                        //child param will be have code = parentCode_childCode|gid=13231233123
                                        var field = doc.Fields.Create(table.Rows[samp + 1].Cells[colChildIdx].ContentRange.Start, $"{prefix}{CODES}{samp}{CODES}{childParam.MEParamNo}{TAGS}{GTAG}={group}");
                                        // insert field result default
                                        doc.InsertText(field.ResultRange.Start, $"{BTAG}{childParam.MEParamValue}{ETAG}{childParam.MEParamUnit}");
                                        field.ShowCodes = false;
                                    }
                                }
                            }
                            else if (childParam.MEParamType == EmrParamTypes.List.ToString())
                            {
                                var cell = table.Rows[0].Cells.Append();
                                if (nextChildren.Count > 0)
                                {
                                    if (childParam.MEParamListType == EmrParamListTypes.Horizontal.ToString())
                                    {
                                        var rowNew = table.Rows.InsertAfter(0);
                                        for (int lev1Samp = 0; lev1Samp < childParam.MEParamSampleCount; lev1Samp++)
                                        {
                                            var headerPos = doc.InsertSingleLineText(table.Rows[0].LastCell.ContentRange.Start, childParam.MEParamCaption).End;
                                            for (int ci = 0; ci < nextChildren.Count; ci++)
                                            {
                                                var item = nextChildren[ci];
                                                var nextChild = GetParamByID(listEmrParams, item.FK_MEParamChildID);
                                                //loai nay thi them field vao header
                                                if (item.MEParamRelationGroupHeader)
                                                {
                                                    headerPos = doc.InsertText(headerPos, "\n").End;
                                                    headerPos = doc.InsertSingleLineText(headerPos, nextChild.MEParamCaption + ": ").End;
                                                    var field = doc.Fields.Create(headerPos, $"{prefix}{CODES}{0}{CODES}{childParam.MEParamNo}{CODES}{lev1Samp}{CODES}{nextChild.MEParamNo}{TAGS}{GTAG}={group}");
                                                    // insert field result default
                                                    doc.InsertText(field.ResultRange.Start, $"{BTAG}{nextChild.MEParamValue}{ETAG}{nextChild.MEParamUnit}");
                                                    field.ShowCodes = false;
                                                    headerPos = field.Range.End;
                                                }
                                                else if (item.MEParamRelationGroupFooter)
                                                {
                                                    //Do nothing, add later
                                                }
                                                //loai nay thi them cot
                                                else
                                                {
                                                    var mergeCells = new List<TableCell>();
                                                    var grandChildren = GetParamRelations(listParamRelations, nextChild.MEParamID);
                                                    //them nhieu cot
                                                    if (grandChildren.Count > 0)
                                                    {
                                                        for (int lev2Samp = 0; lev2Samp < nextChild.MEParamSampleCount; lev2Samp++)
                                                        {
                                                            headerPos = rowNew.Cells.Last.ContentRange.Start;
                                                            foreach (var gChild in grandChildren)
                                                            {
                                                                var grandChild = GetParamByID(listEmrParams, gChild.FK_MEParamChildID);
                                                                if (gChild.MEParamRelationGroupHeader)
                                                                {
                                                                    headerPos = doc.InsertSingleLineText(headerPos, grandChild.MEParamCaption + ": ").End;
                                                                    var field = doc.Fields.Create(headerPos, $"{prefix}{CODES}{0}{CODES}{childParam.MEParamNo}{CODES}{lev1Samp}{CODES}{nextChild.MEParamNo}{CODES}{lev2Samp}{CODES}{grandChild.MEParamNo}{TAGS}{GTAG}={group}");
                                                                    // insert field result default
                                                                    doc.InsertText(field.ResultRange.Start, $"{BTAG}{grandChild.MEParamValue}{ETAG}{grandChild.MEParamUnit}");
                                                                    field.ShowCodes = false;
                                                                    headerPos = doc.InsertText(headerPos, "\n").End;
                                                                }
                                                                else if (gChild.MEParamRelationGroupFooter)
                                                                {
                                                                    //do nothing
                                                                }
                                                                else
                                                                {
                                                                    // chi moi extend den level thu 3 ko mo rong them
                                                                    for (int lev3Samp = 0; lev3Samp < rowCount - 1; lev3Samp++)
                                                                    {
                                                                        var field = doc.Fields.Create(table.Rows[lev3Samp + rowNew.Index + 1].Cells[rowNew.Cells.Last.Index].ContentRange.Start,
                                                                             $"{prefix}{CODES}{lev3Samp}{CODES}{childParam.MEParamNo}{CODES}{lev1Samp}{CODES}{nextChild.MEParamNo}{CODES}{lev2Samp}{CODES}{grandChild.MEParamNo}{TAGS}{GTAG}={group}");
                                                                        // insert field result default
                                                                        doc.InsertText(field.ResultRange.Start, $"{BTAG}{grandChild.MEParamValue}{ETAG}{grandChild.MEParamUnit}");
                                                                        field.ShowCodes = false;
                                                                    }
                                                                    mergeCells.Add(table.Rows[rowNew.Index - 1].Cells.Last());
                                                                    cell = rowNew.Cells.Append();
                                                                }
                                                            }
                                                        }

                                                    }
                                                    //them 1 cot
                                                    else
                                                    {
                                                        for (int samp = 0; samp < rowCount - 1; samp++)
                                                        {
                                                            //insert field
                                                            var field = doc.Fields.Create(table.Rows[samp + 2].Cells[rowNew.Cells.Last.Index].ContentRange.Start,
                                                                $"{prefix}{CODES}{samp}{CODES}{childParam.MEParamNo}{CODES}{lev1Samp}{CODES}{nextChild.MEParamNo}{TAGS}{GTAG}={group}");
                                                            // insert field result default
                                                            doc.InsertText(field.ResultRange.Start, $"{BTAG}{nextChild.MEParamValue}{ETAG}{nextChild.MEParamUnit}");
                                                            field.ShowCodes = false;
                                                        }
                                                        mergeCells.Add(table.Rows[rowNew.Index - 1].Cells.Last());
                                                        cell = rowNew.Cells.Append();
                                                    }
                                                    if (mergeCells.Count > 0)
                                                        table.MergeCells(mergeCells.First(), mergeCells.Last());
                                                }
                                            }
                                        }
                                        var mergeColCount = 0;
                                        //them footer
                                        for (int ci = 0; ci < nextChildren.Count; ci++)
                                        {
                                            var item = nextChildren[ci];
                                            var nextChild = GetParamByID(listEmrParams, item.FK_MEParamChildID);
                                            var grandChildren = GetParamRelations(listParamRelations, nextChild.MEParamID);
                                            foreach (var gChild in grandChildren)
                                            {
                                                var grandChild = GetParamByID(listEmrParams, gChild.FK_MEParamChildID);
                                                if (gChild.MEParamRelationGroupFooter)
                                                {
                                                    var row = table.Rows.InsertAfter(table.Rows.Last.Index);
                                                    doc.InsertSingleLineText(row.FirstCell.ContentRange.Start, grandChild.MEParamCaption);
                                                    var samp = (childParam.MEParamSampleCount * nextChild.MEParamSampleCount);
                                                    for (int lev1Samp = 0; lev1Samp < samp; lev1Samp++)
                                                    {
                                                        var field = doc.Fields.Create(row.Cells[colChildIdx + lev1Samp].ContentRange.Start,
                                                                            $"{prefix}{CODES}{0}{CODES}{childParam.MEParamNo}{CODES}{lev1Samp / nextChild.MEParamSampleCount}{CODES}{nextChild.MEParamNo}{CODES}{lev1Samp % nextChild.MEParamSampleCount}{CODES}{grandChild.MEParamNo}{TAGS}{GTAG}={group}");
                                                        // insert field result default
                                                        doc.InsertText(field.ResultRange.Start, $"{BTAG}{grandChild.MEParamValue}{ETAG}{grandChild.MEParamUnit}");
                                                        field.ShowCodes = false;
                                                    }
                                                }
                                            }
                                            // la col thì +1 la list thi lay sample count
                                            if (!item.MEParamRelationGroupFooter && !item.MEParamRelationGroupHeader)
                                            {
                                                mergeColCount += nextChild.MEParamSampleCount > 0 ? nextChild.MEParamSampleCount : 1;
                                            }
                                        }
                                        for (int ci = 0; ci < nextChildren.Count; ci++)
                                        {
                                            var item = nextChildren[ci];
                                            var nextChild = GetParamByID(listEmrParams, item.FK_MEParamChildID);
                                            var grandChildren = GetParamRelations(listParamRelations, nextChild.MEParamID);

                                            if (item.MEParamRelationGroupFooter)
                                            {
                                                var row = table.Rows.InsertAfter(table.Rows.Last.Index);
                                                doc.InsertSingleLineText(row.FirstCell.ContentRange.Start, nextChild.MEParamCaption);
                                                for (int i = colChildIdx; i + mergeColCount < row.Cells.Count; i++)
                                                {
                                                    table.MergeCells(row.Cells[i], row.Cells[i + mergeColCount - 1]);
                                                }

                                                for (int lev1Samp = 0; lev1Samp < childParam.MEParamSampleCount; lev1Samp++)
                                                {

                                                    if (grandChildren.Count > 0 && !item.MEParamRelationOnlyAddMe)
                                                    {
                                                        this.ExtractSingleParam(doc, nextChild, row.Cells[colChildIdx + lev1Samp].ContentRange.Start,
                                                            $"{prefix}{CODES}{0}{CODES}{childParam.MEParamNo}{CODES}{lev1Samp}",
                                                            group, false, overrideOnlyParentParam, false);
                                                    }
                                                    else
                                                    {

                                                        var field = doc.Fields.Create(row.Cells[colChildIdx + lev1Samp].ContentRange.Start,
                                                                               $"{prefix}{CODES}{0}{CODES}{childParam.MEParamNo}{CODES}{lev1Samp}{CODES}{nextChild.MEParamNo}{TAGS}{GTAG}={group}");
                                                        // insert field result default
                                                        doc.InsertText(field.ResultRange.Start, $"{BTAG}{nextChild.MEParamValue}{ETAG}{nextChild.MEParamUnit}");
                                                        field.ShowCodes = false;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        var headerPos = doc.InsertSingleLineText(table.Rows[0].LastCell.ContentRange.Start, childParam.MEParamCaption).End;
                                        for (int samp = 1; samp < rowCount; samp++)
                                        {
                                            var row = table.Rows[samp]; //dong dau tien la header nen tu 1
                                            var parentCode = $"{prefix}{CODES}{samp - 1}{CODES}{childParam.MEParamNo}";
                                            var field = doc.Fields.Create(row.LastCell.ContentRange.Start, $"{parentCode}{TAGS}{GTAG}={group}");
                                            // insert field result default
                                            if (c.MEParamRelationOnlyAddMe && !overrideOnlyParentParam)
                                            {
                                                doc.InsertText(field.ResultRange.Start, $"{BTAG}{childParam.MEParamValue}{ETAG}{childParam.MEParamUnit}");
                                            }
                                            else
                                            {
                                                doc.InsertText(field.ResultRange.Start, " ");
                                                //MEParamSampleCount +1 vì có thêm header
                                                ExtractVerticalTable(doc, field, childParam.MEParamSampleCount + 1, nextChildren, postion, listEmrParams, parentCode, group, listParamRelations, false, overrideOnlyParentParam);
                                            }
                                            field.ShowCodes = false;

                                        }
                                    }
                                }
                                else
                                {

                                }
                            }
                        }
                        // them row footer cho ca table, se là merge toan bo cac cot
                        else
                        {
                            var row = table.Rows.InsertAfter(table.Rows.Last.Index);
                            var cell = row.FirstCell;
                            doc.InsertSingleLineText(cell.ContentRange.Start, childParam.MEParamCaption);
                        }
                    }
                }));
            }
            else
            {
                Table table = doc.Tables.Create(parentField.ResultRange.Start,
                    rowCount,
                    1,
                    AutoFitBehaviorType.AutoFitToWindow);
                doc.InsertSingleLineText(table.Rows[0].Cells[0].ContentRange.Start, "#");
                //lan luot add cac cot/ row
                for (int colChildIdx = 1; colChildIdx <= childrens.Count(); colChildIdx++)
                {
                    var c = childrens[colChildIdx - 1];
                    var childParam = GetParamByID(listEmrParams, c.FK_MEParamChildID);
                    var nextChildren = GetParamRelations(listParamRelations, childParam.MEParamID);
                    if (!c.MEParamRelationGroupFooter)
                    {
                        if (childParam.MEParamType == EmrParamTypes.Single.ToString())
                        {
                            var cell = table.Rows[0].Cells.Append();
                            //insert caption for param
                            doc.InsertSingleLineText(cell.ContentRange.Start, childParam.MEParamCaption);
                            // if it also have children
                            //TODO testing
                            if (nextChildren.Count > 0 && !c.MEParamRelationOnlyAddMe)
                            {
                                for (int samp = 0; samp < rowCount - 1; samp++)
                                {
                                    postion = this.ExtractSingleParam(doc, childParam, table.Rows[samp + 1].Cells[colChildIdx].ContentRange.Start, $"{prefix}{CODES}{samp}", group, false, overrideOnlyParentParam);
                                }
                            }
                            else
                            {
                                for (int samp = 0; samp < rowCount - 1; samp++)
                                {
                                    //insert field
                                    //child param will be have code = parentCode_childCode|gid=13231233123
                                    var field = doc.Fields.Create(table.Rows[samp + 1].Cells[colChildIdx].ContentRange.Start, $"{prefix}{CODES}{samp}{CODES}{childParam.MEParamNo}{TAGS}{GTAG}={group}");
                                    // insert field result default
                                    doc.InsertText(field.ResultRange.Start, $"{BTAG}{childParam.MEParamValue}{ETAG}{childParam.MEParamUnit}");
                                    field.ShowCodes = false;
                                }
                            }
                        }
                        else if (childParam.MEParamType == EmrParamTypes.List.ToString())
                        {
                            var cell = table.Rows[0].Cells.Append();
                            if (nextChildren.Count > 0)
                            {
                                if (childParam.MEParamListType == EmrParamListTypes.Horizontal.ToString())
                                {
                                    var rowNew = table.Rows.InsertAfter(0);
                                    for (int lev1Samp = 0; lev1Samp < childParam.MEParamSampleCount; lev1Samp++)
                                    {
                                        var headerPos = doc.InsertSingleLineText(table.Rows[0].LastCell.ContentRange.Start, childParam.MEParamCaption).End;
                                        for (int ci = 0; ci < nextChildren.Count; ci++)
                                        {
                                            var item = nextChildren[ci];
                                            var nextChild = GetParamByID(listEmrParams, item.FK_MEParamChildID);
                                            //loai nay thi them field vao header
                                            if (item.MEParamRelationGroupHeader)
                                            {
                                                headerPos = doc.InsertText(headerPos, "\n").End;
                                                headerPos = doc.InsertSingleLineText(headerPos, nextChild.MEParamCaption + ": ").End;
                                                var field = doc.Fields.Create(headerPos, $"{prefix}{CODES}{0}{CODES}{childParam.MEParamNo}{CODES}{lev1Samp}{CODES}{nextChild.MEParamNo}{TAGS}{GTAG}={group}");
                                                // insert field result default
                                                doc.InsertText(field.ResultRange.Start, $"{BTAG}{nextChild.MEParamValue}{ETAG}{nextChild.MEParamUnit}");
                                                field.ShowCodes = false;
                                                headerPos = field.Range.End;
                                            }
                                            else if (item.MEParamRelationGroupFooter)
                                            {
                                                //Do nothing, add later
                                            }
                                            //loai nay thi them cot
                                            else
                                            {
                                                var mergeCells = new List<TableCell>();
                                                var grandChildren = GetParamRelations(listParamRelations, nextChild.MEParamID);
                                                //them nhieu cot
                                                if (grandChildren.Count > 0)
                                                {
                                                    for (int lev2Samp = 0; lev2Samp < nextChild.MEParamSampleCount; lev2Samp++)
                                                    {
                                                        headerPos = rowNew.Cells.Last.ContentRange.Start;
                                                        foreach (var gChild in grandChildren)
                                                        {
                                                            var grandChild = GetParamByID(listEmrParams, gChild.FK_MEParamChildID);
                                                            if (gChild.MEParamRelationGroupHeader)
                                                            {
                                                                headerPos = doc.InsertSingleLineText(headerPos, grandChild.MEParamCaption + ": ").End;
                                                                var field = doc.Fields.Create(headerPos, $"{prefix}{CODES}{0}{CODES}{childParam.MEParamNo}{CODES}{lev1Samp}{CODES}{nextChild.MEParamNo}{CODES}{lev2Samp}{CODES}{grandChild.MEParamNo}{TAGS}{GTAG}={group}");
                                                                // insert field result default
                                                                doc.InsertText(field.ResultRange.Start, $"{BTAG}{grandChild.MEParamValue}{ETAG}{grandChild.MEParamUnit}");
                                                                field.ShowCodes = false;
                                                                headerPos = doc.InsertText(headerPos, "\n").End;
                                                            }
                                                            else if (gChild.MEParamRelationGroupFooter)
                                                            {
                                                                //do nothing
                                                            }
                                                            else
                                                            {
                                                                // chi moi extend den level thu 3 ko mo rong them
                                                                for (int lev3Samp = 0; lev3Samp < rowCount - 1; lev3Samp++)
                                                                {
                                                                    var field = doc.Fields.Create(table.Rows[lev3Samp + rowNew.Index + 1].Cells[rowNew.Cells.Last.Index].ContentRange.Start,
                                                                         $"{prefix}{CODES}{lev3Samp}{CODES}{childParam.MEParamNo}{CODES}{lev1Samp}{CODES}{nextChild.MEParamNo}{CODES}{lev2Samp}{CODES}{grandChild.MEParamNo}{TAGS}{GTAG}={group}");
                                                                    // insert field result default
                                                                    doc.InsertText(field.ResultRange.Start, $"{BTAG}{grandChild.MEParamValue}{ETAG}{grandChild.MEParamUnit}");
                                                                    field.ShowCodes = false;
                                                                }
                                                                mergeCells.Add(table.Rows[rowNew.Index - 1].Cells.Last());
                                                                cell = rowNew.Cells.Append();
                                                            }
                                                        }
                                                    }

                                                }
                                                //them 1 cot
                                                else
                                                {
                                                    for (int samp = 0; samp < rowCount - 1; samp++)
                                                    {
                                                        //insert field
                                                        var field = doc.Fields.Create(table.Rows[samp + 2].Cells[rowNew.Cells.Last.Index].ContentRange.Start,
                                                            $"{prefix}{CODES}{samp}{CODES}{childParam.MEParamNo}{CODES}{lev1Samp}{CODES}{nextChild.MEParamNo}{TAGS}{GTAG}={group}");
                                                        // insert field result default
                                                        doc.InsertText(field.ResultRange.Start, $"{BTAG}{nextChild.MEParamValue}{ETAG}{nextChild.MEParamUnit}");
                                                        field.ShowCodes = false;
                                                    }
                                                    mergeCells.Add(table.Rows[rowNew.Index - 1].Cells.Last());
                                                    cell = rowNew.Cells.Append();
                                                }
                                                if (mergeCells.Count > 0)
                                                    table.MergeCells(mergeCells.First(), mergeCells.Last());
                                            }
                                        }
                                    }
                                    var mergeColCount = 0;
                                    //them footer
                                    for (int ci = 0; ci < nextChildren.Count; ci++)
                                    {
                                        var item = nextChildren[ci];
                                        var nextChild = GetParamByID(listEmrParams, item.FK_MEParamChildID);
                                        var grandChildren = GetParamRelations(listParamRelations, nextChild.MEParamID);
                                        foreach (var gChild in grandChildren)
                                        {
                                            var grandChild = GetParamByID(listEmrParams, gChild.FK_MEParamChildID);
                                            if (gChild.MEParamRelationGroupFooter)
                                            {
                                                var row = table.Rows.InsertAfter(table.Rows.Last.Index);
                                                doc.InsertSingleLineText(row.FirstCell.ContentRange.Start, grandChild.MEParamCaption);
                                                var samp = (childParam.MEParamSampleCount * nextChild.MEParamSampleCount);
                                                for (int lev1Samp = 0; lev1Samp < samp; lev1Samp++)
                                                {
                                                    var field = doc.Fields.Create(row.Cells[colChildIdx + lev1Samp].ContentRange.Start,
                                                                        $"{prefix}{CODES}{0}{CODES}{childParam.MEParamNo}{CODES}{lev1Samp / nextChild.MEParamSampleCount}{CODES}{nextChild.MEParamNo}{CODES}{lev1Samp % nextChild.MEParamSampleCount}{CODES}{grandChild.MEParamNo}{TAGS}{GTAG}={group}");
                                                    // insert field result default
                                                    doc.InsertText(field.ResultRange.Start, $"{BTAG}{grandChild.MEParamValue}{ETAG}{grandChild.MEParamUnit}");
                                                    field.ShowCodes = false;
                                                }
                                            }
                                        }
                                        // la col thì +1 la list thi lay sample count
                                        if (!item.MEParamRelationGroupFooter && !item.MEParamRelationGroupHeader)
                                        {
                                            mergeColCount += nextChild.MEParamSampleCount > 0 ? nextChild.MEParamSampleCount : 1;
                                        }
                                    }
                                    for (int ci = 0; ci < nextChildren.Count; ci++)
                                    {
                                        var item = nextChildren[ci];
                                        var nextChild = GetParamByID(listEmrParams, item.FK_MEParamChildID);
                                        var grandChildren = GetParamRelations(listParamRelations, nextChild.MEParamID);

                                        if (item.MEParamRelationGroupFooter)
                                        {
                                            var row = table.Rows.InsertAfter(table.Rows.Last.Index);
                                            doc.InsertSingleLineText(row.FirstCell.ContentRange.Start, nextChild.MEParamCaption);
                                            for (int i = colChildIdx; i + mergeColCount < row.Cells.Count; i++)
                                            {
                                                table.MergeCells(row.Cells[i], row.Cells[i + mergeColCount - 1]);
                                            }

                                            for (int lev1Samp = 0; lev1Samp < childParam.MEParamSampleCount; lev1Samp++)
                                            {

                                                if (grandChildren.Count > 0 && !item.MEParamRelationOnlyAddMe)
                                                {
                                                    this.ExtractSingleParam(doc, nextChild, row.Cells[colChildIdx + lev1Samp].ContentRange.Start,
                                                        $"{prefix}{CODES}{0}{CODES}{childParam.MEParamNo}{CODES}{lev1Samp}",
                                                        group, false, overrideOnlyParentParam, false);
                                                }
                                                else
                                                {

                                                    var field = doc.Fields.Create(row.Cells[colChildIdx + lev1Samp].ContentRange.Start,
                                                                           $"{prefix}{CODES}{0}{CODES}{childParam.MEParamNo}{CODES}{lev1Samp}{CODES}{nextChild.MEParamNo}{TAGS}{GTAG}={group}");
                                                    // insert field result default
                                                    doc.InsertText(field.ResultRange.Start, $"{BTAG}{nextChild.MEParamValue}{ETAG}{nextChild.MEParamUnit}");
                                                    field.ShowCodes = false;
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    var headerPos = doc.InsertSingleLineText(table.Rows[0].LastCell.ContentRange.Start, childParam.MEParamCaption).End;
                                    for (int samp = 1; samp < rowCount; samp++)
                                    {
                                        var row = table.Rows[samp]; //dong dau tien la header nen tu 1
                                        var parentCode = $"{prefix}{CODES}{samp - 1}{CODES}{childParam.MEParamNo}";
                                        var field = doc.Fields.Create(row.LastCell.ContentRange.Start, $"{parentCode}{TAGS}{GTAG}={group}");
                                        // insert field result default
                                        if (c.MEParamRelationOnlyAddMe && !overrideOnlyParentParam)
                                        {
                                            doc.InsertText(field.ResultRange.Start, $"{BTAG}{childParam.MEParamValue}{ETAG}{childParam.MEParamUnit}");
                                        }
                                        else
                                        {
                                            doc.InsertText(field.ResultRange.Start, " ");
                                            //MEParamSampleCount +1 vì có thêm header
                                            ExtractVerticalTable(doc, field, childParam.MEParamSampleCount + 1, nextChildren, postion, listEmrParams, parentCode, group, listParamRelations, false, overrideOnlyParentParam);
                                        }
                                        field.ShowCodes = false;

                                    }
                                }
                            }
                            else
                            {

                            }
                        }
                    }
                    // them row footer cho ca table, se là merge toan bo cac cot
                    else
                    {
                        var row = table.Rows.InsertAfter(table.Rows.Last.Index);
                        var cell = row.FirstCell;
                        doc.InsertSingleLineText(cell.ContentRange.Start, childParam.MEParamCaption);
                    }
                }
            }
        }

        private void ExtractHorizontalTable(Document doc, Field parentField, int colCount, List<MEParamRelationsInfo> childrens, List<MEParamsInfo> listEmrParams,
            string prefix, string group, Dictionary<int, List<MEParamRelationsInfo>> listParamRelations, bool onlyParentParam = false)
        {
            Table table = doc.Tables.Create(parentField.ResultRange.Start,
                    1,
                    colCount, //cho phep truyen vao col Count
                    AutoFitBehaviorType.AutoFitToWindow);

            var row = table.Rows.First();
            for (int i = 0; i < childrens.Count(); i++)
            {
                var c = childrens[i];
                var childParam = GetParamByID(listEmrParams, c.FK_MEParamChildID);
                if (c.MEParamRelationGroupHeader)
                {
                    if (i > 0)
                        row = table.Rows.InsertAfter(row.Index);
                    doc.InsertSingleLineText(row.Cells[0].ContentRange.Start, childParam.MEParamCaption);
                    for (int col = 1; col < colCount; col++)
                    {
                        var field = doc.Fields.Create(row.Cells[col].ContentRange.End, $"{prefix}{CODES}{col - 1}{CODES}{childParam.MEParamNo}{TAGS}{GTAG}={group}");
                        doc.InsertText(field.ResultRange.Start, $"{BTAG}{childParam.MEParamValue}{ETAG}{childParam.MEParamUnit}");
                        field.ShowCodes = false;
                    }
                }
                else if (c.MEParamRelationGroupFooter)
                {
                    //chi ho tro footer đến level 2
                    var newRow = table.Rows.InsertAfter(table.Rows.Last.Index);
                    doc.InsertSingleLineText(newRow.Cells[0].ContentRange.Start, childParam.MEParamCaption);
                    var merge = newRow.Cells.Count / (colCount - 1);
                    for (int col = 0; col < colCount - 1; col++)
                    {
                        var field = doc.Fields.Create(newRow.Cells[col * merge + 1].ContentRange.End,
                                       $"{prefix}{CODES}{col}{CODES}{childParam.MEParamNo}{TAGS}{GTAG}={group}");
                        doc.InsertText(field.ResultRange.Start, $"{BTAG}{childParam.MEParamValue}{ETAG}{childParam.MEParamUnit}");
                        field.ShowCodes = false;
                    }
                }
                else
                {
                    if (childParam.MEParamType == EmrParamTypes.Single.ToString())
                    {
                        if (i > 0)
                            row = table.Rows.InsertAfter(row.Index);
                        doc.InsertSingleLineText(row.Cells[0].ContentRange.Start, childParam.MEParamCaption);
                        for (int col = 1; col < colCount; col++)
                        {
                            var field = doc.Fields.Create(row.Cells[col].ContentRange.End,
                                $"{prefix}{CODES}{col - 1}{CODES}{childParam.MEParamNo}{TAGS}{GTAG}={group}");
                            doc.InsertText(field.ResultRange.Start, $"{BTAG}{childParam.MEParamValue}{ETAG}{childParam.MEParamUnit}");
                            field.ShowCodes = false;
                        }
                    }
                    else
                    {
                        //kieu list nen chuyen thanh cot con nam ngang
                        var nextChildren = GetParamRelations(listParamRelations, childParam.MEParamID);
                        row = table.Rows.InsertAfter(row.Index);
                        doc.InsertSingleLineText(row.Cells[0].ContentRange.Start, childParam.MEParamCaption);
                        int currentCell = 0;
                        for (int col = 1; col < colCount; col++)
                        {
                            for (int samp = 0; samp < childParam.MEParamSampleCount; samp++)
                            {
                                if (samp > 0)
                                {
                                    row.Cells.InsertAfter(currentCell);
                                }
                                currentCell++;
                                foreach (var nC in nextChildren)
                                {
                                    if (nC.MEParamRelationGroupHeader)
                                    {
                                        var nextParam = GetParamByID(listEmrParams, nC.FK_MEParamChildID);
                                        var field = doc.Fields.Create(row.Cells[currentCell].ContentRange.End,
                                            $"{prefix}{CODES}{col - 1}{CODES}{childParam.MEParamNo}{CODES}{samp}{CODES}{nextParam.MEParamNo}{TAGS}{GTAG}={group}");
                                        doc.InsertText(field.ResultRange.Start, $"{BTAG}{nextParam.MEParamValue}{ETAG}{nextParam.MEParamUnit}");
                                        field.ShowCodes = false;
                                    }
                                }
                            }
                            currentCell = currentCell++;
                        }
                        //for (int col = 1; col < colCount; col++)
                        //{
                        //    var preRow = table.Rows[row.Index - 1];
                        //    table.MergeCells(preRow.Cells[currentCell], preRow.Cells[currentCell - (childParam.MEParamSampleCount * col)]);
                        //}
                        var headerChildren = nextChildren.Where(o => !o.MEParamRelationGroupFooter && !o.MEParamRelationGroupHeader).ToList();
                        if (headerChildren.Count > 0)
                        {
                            foreach (var nC in headerChildren)
                            {
                                var grandChildren = GetParamRelations(listParamRelations, nC.FK_MEParamChildID);
                                //chi ho tro 2 cap cho header dang col ben trai
                                //chi add them 1 cot
                                if (grandChildren.Count > 0)
                                {
                                    table.Rows.First.Cells.InsertAfter(0);
                                    break;
                                }
                            }
                        }
                        foreach (var nC in headerChildren)
                        {
                            var nextParam = GetParamByID(listEmrParams, nC.FK_MEParamChildID);
                            var grandChildren = GetParamRelations(listParamRelations, nextParam.MEParamID);
                            //them row cho loai nay
                            var newRow = table.Rows.InsertAfter(table.Rows.Last.Index);
                            doc.InsertSingleLineText(newRow.Cells[0].ContentRange.Start, nextParam.MEParamCaption);
                            if (grandChildren.Count > 0)
                            {
                                for (int j = 0; j < grandChildren.Count; j++)
                                {
                                    var grandChild = GetParamByID(listEmrParams, grandChildren[j].FK_MEParamChildID);
                                    if (j > 0) newRow = table.Rows.InsertAfter(newRow.Index);
                                    doc.InsertSingleLineText(newRow.Cells[1].ContentRange.Start, grandChild.MEParamCaption);
                                    currentCell = 2;
                                    for (int col = 1; col < colCount; col++)
                                    {
                                        for (int samp = 0; samp < childParam.MEParamSampleCount; samp++)
                                        {
                                            var field = doc.Fields.Create(newRow.Cells[currentCell].ContentRange.End,
                                                         $"{prefix}{CODES}{col - 1}{CODES}{childParam.MEParamNo}{CODES}{samp}{CODES}{nextParam.MEParamNo}{CODES}{grandChild.MEParamNo}{TAGS}{GTAG}={group}");
                                            doc.InsertText(field.ResultRange.Start, $"{BTAG}{grandChild.MEParamValue}{ETAG}{grandChild.MEParamUnit}");
                                            field.ShowCodes = false;
                                            currentCell++;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                currentCell = newRow.Cells.Count - (childParam.MEParamSampleCount * (colCount - 1));
                                for (int col = 1; col < colCount; col++)
                                {
                                    for (int samp = 0; samp < childParam.MEParamSampleCount; samp++)
                                    {
                                        var field = doc.Fields.Create(newRow.Cells[currentCell].ContentRange.End,
                                                     $"{prefix}{CODES}{col - 1}{CODES}{childParam.MEParamNo}{CODES}{samp}{CODES}{nextParam.MEParamNo}{TAGS}{GTAG}={group}");
                                        doc.InsertText(field.ResultRange.Start, $"{BTAG}{nextParam.MEParamValue}{ETAG}{nextParam.MEParamUnit}");
                                        field.ShowCodes = false;
                                        currentCell++;
                                    }
                                }
                            }
                        }
                        var footerChildren = nextChildren.Where(o => o.MEParamRelationGroupFooter).ToList();
                        foreach (var nC in footerChildren)
                        {
                            //chi ho tro footer đến level 2
                            var nextParam = GetParamByID(listEmrParams, nC.FK_MEParamChildID);
                            var newRow = table.Rows.InsertAfter(table.Rows.Last.Index);
                            doc.InsertSingleLineText(newRow.Cells[1].ContentRange.Start, nextParam.MEParamCaption);
                            currentCell = 2;
                            for (int col = 1; col < colCount; col++)
                            {
                                for (int samp = 0; samp < childParam.MEParamSampleCount; samp++)
                                {
                                    var field = doc.Fields.Create(newRow.Cells[currentCell].ContentRange.End,
                                                 $"{prefix}{CODES}{col - 1}{CODES}{childParam.MEParamNo}{CODES}{samp}{CODES}{nextParam.MEParamNo}{TAGS}{GTAG}={group}");
                                    doc.InsertText(field.ResultRange.Start, $"{BTAG}{nextParam.MEParamValue}{ETAG}{nextParam.MEParamUnit}");
                                    field.ShowCodes = false;
                                    currentCell++;
                                }
                            }
                            table.MergeCells(newRow.Cells[0], newRow.Cells[1]);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// insert image vao vi tri chu ky cuoi cung tim dc
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="hREmployeeSignature"></param>
        /// <param name="group"></param>
        public void InsertSignature(List<Field> fields, byte[] hREmployeeSignature, string fullName, string lastName, string role, string userName, List<METemplateParamsInfo> templateParamList)
        {
            MemoryStream s = new MemoryStream(hREmployeeSignature);
            Image image = Image.FromStream(s);
            InsertSignature(fields, image, fullName, lastName, role, userName, templateParamList);
        }
        public void InsertSignature(List<Field> fields, Image image, string fullName, string lastName, string role, string userName, List<METemplateParamsInfo> templateParamList, bool newLine = true)
        {
            var doc = _richEditCtrl.Document;
            Field signField = null, nameField = null, fullField = null, userNameField = null, timeField = null;
            foreach (var field in fields)
            {
                var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                var codes = text.Split(TAGS);
                string[] codeLevels = codes[0].Split(EmrParam.CodeSeparator);
                if (codeLevels.Last() == EmrParam.ChuKyHinh)
                {
                    signField = field;
                    //cho phep ky chong
                }
                else if (codeLevels.Last() == EmrParam.ChuKyTen)
                {
                    nameField = field;
                    //cho phep ky chong
                }
                else if (codeLevels.Last() == EmrParam.ChuKyHoTen)
                {
                    fullField = field;
                    //cho phep ky chong
                }
                else if (codeLevels.Last() == EmrParam.ChuKyNguoiDung)
                {
                    userNameField = field;
                    //cho phep ky chong
                }
                else if (codeLevels.Last() == EmrParam.ChuKyThoiGian)
                {
                    timeField = field;
                    //cho phep ky chong
                }
                if (!string.IsNullOrEmpty(role) && (signField != null
                    || fullField != null
                    || nameField != null
                    || userNameField != null
                    || timeField != null))
                {
                    if (codeLevels.Length > 1)
                    {
                        var parent = codeLevels[codeLevels.Length - 2];
                        if (int.TryParse(parent, out int idx))
                            if (codeLevels.Length > 2)
                                parent = codeLevels[codeLevels.Length - 3];
                        //the cha xac dinh role
                        if (role != parent)
                            continue;
                    }
                }

                if (signField != null && image != null)
                {
                    doc.Replace(signField.ResultRange, string.Empty);

                    var fieldPath = GetTemplateFieldPath(codes[0]);
                    var tempParam = templateParamList.Where(o => o.METemplateParamPath == fieldPath).FirstOrDefault();
                    int width = 0, height = 0;
                    if (tempParam != null)
                    {
                        var newImage = (Image)image.Clone();
                        if (tempParam.MEParamFormatType == EmrParamFormatTypes.ImageRotate90.ToString())
                        {
                            newImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        }
                        if (tempParam.MEParamImageWidth > 0 || tempParam.MEParamImageHeight > 0)
                        {
                            width = tempParam.MEParamImageWidth;
                            height = tempParam.MEParamImageHeight;
                        }
                        else if (int.TryParse(tempParam.MEParamFormatString, out width))
                        {
                            height = 0;// (int)(image.Width / (float)width) * image.Height;
                        }

                        doc.Replace(signField.ResultRange, BTAG + ETAG);
                        var pos = doc.CreatePosition(signField.ResultRange.Start.ToInt() + 1);
                        InsertImageToDocument(newImage, pos, width, height, newLine);
                    }
                    else
                    {
                        doc.Replace(signField.ResultRange, BTAG + ETAG);
                        var pos = doc.CreatePosition(signField.ResultRange.Start.ToInt() + 1);
                        InsertImageToDocument(image, pos, width, height, newLine);
                    }
                }
                if (fullField != null)
                {
                    doc.Replace(fullField.ResultRange, BTAG + fullName + ETAG);
                }
                if (nameField != null)
                {
                    doc.Replace(nameField.ResultRange, BTAG + lastName + ETAG);
                }
                if (userNameField != null)
                {
                    doc.Replace(userNameField.ResultRange, BTAG + userName + ETAG);
                }
                if (timeField != null)
                {
                    doc.Replace(timeField.ResultRange, BTAG + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture) + ETAG);
                }

                signField = null;
                nameField = null;
                fullField = null;
                userNameField = null;
                timeField = null;
            }
        }
        public string VerifySignRange(Document doc, Dictionary<string, List<EmrField>> roles)
        {
            var allFields = roles.SelectMany(r => r.Value).Select(f => f.Field).ToList();
            var rAround = new int[] { -1, 0, 1, 1, 1, 0, -1, -1 };
            var cAround = new int[] { -1, -1, -1, 0, 1, 1, 1, 0 };

            foreach (var role in roles)
            {
                foreach (var item in role.Value)
                {
                    var curParent = item.CodeLevelArr.Length > 1 ? string.Join(CODES.ToString(), item.CodeLevelArr.Take(item.CodeLevelArr.Length - 1).ToArray()) : string.Empty;
                    List<EmrField> emrFields;
                    var cell = doc.Tables.GetTableCell(item.Field.ResultRange.Start);
                    if (cell != null)
                    {
                        //tìm vùng chữ nhật xung quanh, nếu có thẻ cùng thẻ cha thì người dùng đang quét bị thiếu
                        var table = cell.Table;
                        for (int i = 0; i < rAround.Length; i++)
                        {
                            var r = rAround[i] + cell.Row.Index;
                            var c = cAround[i] + cell.Index;
                            if (r < 0 || c < 0 || c >= cell.Row.Cells.Count || r >= table.Rows.Count) continue;
                            TableCell treatedCell = null;
                            try
                            {
                                treatedCell = table.Cell(r, c);
                            }
                            catch (Exception) { }
                            if (treatedCell == null) continue;
                            emrFields = GetAllSignerFields(_richEditCtrl.Document, treatedCell.ContentRange);
                            var considers = emrFields.Where(f => !allFields.Contains(f.Field)).ToArray();
                            foreach (var consider in considers)
                            {
                                var considerParent = consider.CodeLevelArr.Length > 1 ? string.Join(CODES.ToString(), consider.CodeLevelArr.Take(item.CodeLevelArr.Length - 1).ToArray()) : string.Empty;
                                if (curParent == considerParent)
                                {
                                    return "Vùng quét chọn bị thiếu thẻ. \nVui lòng quét chọn đầy đủ các thẻ chữ ký lân cận. \nKIỂM TRA [CÁC Ô XUNG QUANH] VÙNG ĐANG CHỌN";
                                }
                            }
                        }
                    }

                    var curPgp = _richEditCtrl.Document.Paragraphs.Get(item.Field.ResultRange.Start);
                    var extPgp = GetNotEmptyPreviousParagraph(_richEditCtrl.Document, curPgp.Index, includeFieldMaker: true);
                    if (extPgp != null)
                    {
                        emrFields = GetAllSignerFields(_richEditCtrl.Document, extPgp.Range);
                        var considers = emrFields.Where(f => !allFields.Contains(f.Field)).ToArray();
                        foreach (var consider in considers)
                        {
                            var considerParent = consider.CodeLevelArr.Length > 1 ? string.Join(CODES.ToString(), consider.CodeLevelArr.Take(item.CodeLevelArr.Length - 1).ToArray()) : string.Empty;
                            if (curParent == considerParent)
                            {
                                return "Vùng quét chọn bị thiếu thẻ. \nVui lòng quét chọn đầy đủ các thẻ chữ ký lân cận. \nKIỂM TRA THẺ PHÍA [TRƯỚC] VÙNG ĐANG CHỌN";
                            }
                        }
                    }
                    extPgp = GetNotEmptyNextParagraph(_richEditCtrl.Document, curPgp.Index, includeFieldMaker: true);
                    if (extPgp != null)
                    {
                        emrFields = GetAllSignerFields(_richEditCtrl.Document, extPgp.Range);
                        var considers = emrFields.Where(f => !allFields.Contains(f.Field)).ToArray();
                        foreach (var consider in considers)
                        {
                            var considerParent = consider.CodeLevelArr.Length > 1 ? string.Join(CODES.ToString(), consider.CodeLevelArr.Take(item.CodeLevelArr.Length - 1).ToArray()) : string.Empty;
                            if (curParent == considerParent)
                            {
                                return "Vùng quét chọn bị thiếu thẻ. \nVui lòng quét chọn đầy đủ các thẻ chữ ký lân cận. \nKIỂM TRA THẺ PHÍA [SAU] VÙNG ĐANG CHỌN";
                            }
                        }
                    }

                }
            }
            return null;
        }
        public METemplateParamsInfo VerifySignAsOneGroup(Document doc, Dictionary<string, List<EmrField>> roles, IEnumerable<DocumentRange> selectedRanges)
        {
            if (_signedAsGroupTemplateParams.Length == 0) return null;
            foreach (var role in roles)
            {
                foreach (var item in role.Value)
                {
                    var config = _signedAsGroupTemplateParams.Where(o => o.METemplateParamPath == GetTemplateFieldPath(item.Tokens[0])).FirstOrDefault();
                    if (config == null) continue;
                    if (string.IsNullOrEmpty(config.METemplateParamSignAsGroup)) continue;
                    var requiredParams = _signedAsGroupTemplateParams.Where(c => c.METemplateParamSignAsGroup == config.METemplateParamSignAsGroup).ToArray();
                    foreach (var requiredParam in requiredParams)
                    {
                        var key = MapIndexToOtherToken(item.CodeLevelArr, requiredParam.METemplateParamPath);
                        var field = GetFirstFieldByPath(key, item.Gid);
                        if (field != null)
                        {
                            if (selectedRanges.Any(s => s.Start <= field.Range.Start && field.Range.End <= s.End))
                                continue;
                            else
                                return requiredParam;
                        }
                    }
                }
            }
            return null;
        }
        public string MapIndexToOtherToken(string[] fromArr, string to)
        {
            /*
             * from: tdt_dienbienvaylenh-0-tdt_ylenh-tdt_ylenh_chuky-chuky_hoten
               to: tdt_dienbienvaylenh[*].tdt_ylenh.khoa / tdt_dienbienvaylenh[*].ngaykhambenh
             */
            to = to.Replace('[', '.');
            to = to.Replace("]", string.Empty);
            var toArr = to.Split('.');
            var counter = toArr.Length > fromArr.Length ? fromArr.Length : toArr.Length;
            for (int i = 0; i < counter; i++)
            {
                if (int.TryParse(fromArr[i], out int idx))
                {
                    toArr[i] = fromArr[i];
                }
                else if (toArr[i] != fromArr[i])
                {
                    break;
                }
            }
            return string.Join(CODES.ToString(), toArr);
        }
        /// <summary>
        /// ký tên theo phan
        /// </summary>
        /// <param name="range"></param>
        /// <param name="hasComment">trường hợp ký tên theo cột thì lấy cái cuối cùng để thêm comment</param>
        public void SignRange(DocumentRange range, bool hasComment, string commentName = "Signature", string commentByPrefix = "Được ký bởi")
        {
            var doc = this._richEditCtrl.Document;
            var rangePermissions = doc.BeginUpdateRangePermissions();
            doc.BeginUpdate();
            foreach (var field in doc.Fields)
            {
                if (field.ResultRange.Start > range.Start && field.ResultRange.Start < range.End &&
                    field.ResultRange.End > range.Start && field.ResultRange.End < range.End)
                {
                    _fieldToCodeCache.TryGetValue(field, out EmrField emrField);
                    if (emrField == null)
                    {
                        var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                        emrField = AddCacheBindingField(field, text);
                    }
                    var code = emrField.FieldCode; /*doc.GetText(field.CodeRange, _plainTextExportCfg)/*.Split(TAGS)[0]*/;
                    if (code.StartsWith("HYPERLINK"))
                        continue;
                    else if (code.Contains("SYMBOL"))
                        continue;
                    doc.InsertText(field.CodeRange.End, $"|s={BOSApp.CurrentUsersInfo.ADUserName}|sd={DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
                }
            }
            var spacing = range.Start.ToInt() > 0 ? doc.GetText(doc.CreateRange(range.Start.ToInt() - 1, 1), _plainTextExportCfg) : string.Empty;
            var padding = 0;
            if (!string.IsNullOrWhiteSpace(spacing))
            {
                doc.InsertText(range.Start, " ");
            }
            else
            {
                var cell = doc.Tables.GetTableCell(range.Start);
                if (cell != null && cell.ContentRange.Start == range.Start)
                {
                    doc.InsertText(cell.ContentRange.Start, " ");
                }
            }
            spacing = doc.GetText(doc.CreateRange(range.End.ToInt(), 1));
            if (!string.IsNullOrWhiteSpace(spacing) || spacing == @"\r\n")
            {
                doc.InsertText(range.End, "");
                padding++;
            }
            else if (spacing == Environment.NewLine)
            {
                padding++;
            }
            else
            {
                doc.InsertText(range.End, "");
                padding++;
            }
            range = doc.CreateRange(range.Start.ToInt(), range.Length - padding);
            if (hasComment)
            {
                Comment comment = doc.Comments.Create(range, BOSApp.CurrentUsersInfo.ADUserName, DateTime.Now);
                comment.Name = commentName;
                SubDocument commentDocument = comment.BeginUpdate();
                commentDocument.InsertText(commentDocument.CreatePosition(0), $"{commentByPrefix}: {BOSApp.CurrentEmployeesInfo.HREmployeeName} lúc {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");
                comment.EndUpdate(commentDocument);
            }
            rangePermissions.AddRange(this.CreateRangePermissions(range, BOSApp.CurrentUsersInfo.ADUserGroupID.ToString(), BOSApp.CurrentUsersInfo.ADUserName));
            doc.EndUpdateRangePermissions(rangePermissions);
            doc.EndUpdate();
        }

        private string[] GetFieldTokens(Document doc, Field field)
        {
            var text = doc.GetText(field.CodeRange);
            return text.Split(TAGS);
        }
        public string GetTemplateFieldPath(string rawPath)
        {
            rawPath = Regex.Replace(rawPath, $"\\{EmrParam.CodeSeparator}([\\d]*)\\{EmrParam.CodeSeparator}", "[*].");
            rawPath = rawPath.Replace(EmrParam.CodeSeparator, '.');
            return rawPath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="contanerParam"></param>
        /// <param name="gid"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="newLine"></param>
        /// <param name="scaleX"></param>
        public DocumentImage InsertImageToDocumentAtParam(Image image, string contanerParam, string gid, int width = 0, int height = 0, bool newLine = true, bool scaleX = true)
        {
            var position = this._richEditCtrl.Document.CaretPosition;
            var doc = this._richEditCtrl.Document;
            var field = this.GetFirstFieldByPath(contanerParam, gid);
            if (field != null)
            {
                doc.Replace(field.ResultRange, EmrParam.BeginTag + EmrParam.EndTag);
                position = doc.CreatePosition(field.ResultRange.Start.ToInt() + 1);
            }
            return this.InsertImageToDocument(image, position, width, height, newLine, scaleX);
        }
        public DocumentImage InsertImageToDocumentAtParamWithHidenContent(Image image, string contanerParam, string gid, string content, int width = 0, int height = 0, bool newLine = true, bool scaleX = true)
        {
            //TODO find closest param on document from caret position in case multi images on a document
            Field imageField = this.GetFirstFieldByPath(contanerParam, gid);
            var position = this._richEditCtrl.Document.CaretPosition;
            var doc = this._richEditCtrl.Document;
            if (imageField != null)
            {
                doc.Replace(imageField.ResultRange, EmrParam.BeginTag + content + EmrParam.EndTag);
                position = doc.CreatePosition(imageField.ResultRange.Start.ToInt() + 1);

                var properties = doc.BeginUpdateCharacters(position, content.Length);
                properties.Hidden = true;
                doc.EndUpdateCharacters(properties);

                position = doc.CreatePosition(imageField.ResultRange.End.ToInt() - 1);

                var fieldPath = GetTemplateFieldPath(GetFieldTokens(doc, imageField)[0]);
                _templateParamDictPath.TryGetValue(fieldPath, out METemplateParamsInfo tempParam);
                if (tempParam != null)
                {
                    if (tempParam.MEParamImageWidth > 0 || tempParam.MEParamImageHeight > 0)
                    {
                        width = tempParam.MEParamImageWidth;
                        height = tempParam.MEParamImageHeight;
                    }
                }
            }
            return this.InsertImageToDocument(image, position, width, height, newLine, scaleX);
        }
        /// <summary>
        /// Insert image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="postion"></param>
        /// <param name="width">if = 0 will auto scale </param>
        /// <param name="height">if = 0 will auto scale </param>
        /// <returns></returns>
        public DocumentImage InsertImageToDocument(Image image, DocumentPosition postion, int width = 0, int height = 0, bool newLine = true, bool scaleX = true)
        {
            var doc = this._richEditCtrl.Document;
            if (_richEditCtrl.InvokeRequired)
            {
                _richEditCtrl.BeginInvoke((Action)(() =>
                {
                    doc.BeginUpdate();
                }));
            }
            else
            {
                doc.BeginUpdate();
            }
            if (newLine)
                postion = doc.InsertText(postion, "\n").Start;
            var img = doc.Images.Insert(postion, image);
            if (width > 0 && height > 0)
            {
                img.Size = new SizeF(width, height);
            }
            else if (height > 0)
            {
                width = (int)(height / img.Size.Height * img.Size.Width);
                img.Size = new SizeF(width, height);
            }
            else if (width > 0)
            {
                height = (int)(width / img.Size.Width * img.Size.Height);
                img.Size = new SizeF(width, height);
            }
            else
            {
                if (scaleX)
                {
                    //if size> width then edit scale otherwise do nothing
                    var docWidth = doc.Sections[0].Page.Width - (doc.Sections[0].Margins.Left + doc.Sections[0].Margins.Right);
                    if (img.Size.Width > docWidth)
                    {
                        img.ScaleX /= (img.Size.Width / docWidth);
                        //img.ScaleY /= (img.Size.Height / docWidth);
                    }
                }
            }
            if (_richEditCtrl.InvokeRequired)
            {
                _richEditCtrl.BeginInvoke((Action)(() =>
                {
                    doc.EndUpdate();
                }));
            }
            else
            {
                doc.EndUpdate();
            }
            return img;
        }
        public void RemoveAllParamMarkup(Document document)
        {
            try
            {
                document.BeginUpdate();
                List<EmrField> listFields = new List<EmrField>();
                foreach (var field in document.Fields)
                {
                    var fieldCode = document.GetText(field.CodeRange).Split(TAGS);
                    listFields.Add(new EmrField()
                    {
                        Field = field,
                        FieldCode = fieldCode[0],
                    });
                }
                listFields = listFields.OrderByDescending(o => o.FieldCode.Length).ToList();
                //var opts = new RtfDocumentExporterOptions()
                //{
                //    ExportFinalParagraphMark = DevExpress.XtraRichEdit.Export.Rtf.ExportFinalParagraphMark.SelectedOnly
                //};
                for (int i = 0; i < listFields.Count; i++)
                {
                    var field = listFields[i].Field;
                    if ((field as DevExpress.XtraRichEdit.API.Native.Implementation.NativeField).IsValid)
                    {
                        var content = document.GetRtfText(field.ResultRange);
                        //some time content is null but field invalid
                        if (string.IsNullOrEmpty(content)) continue;
                        var pos = field.ResultRange.End;
                        document.Replace(field.Range, string.Empty);
                        document.InsertRtfText(pos, content);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                document.EndUpdate();
            }
        }

        public MEParamsInfo GetParamByID(List<MEParamsInfo> listEmrParams, int id)
        {
            var p = listEmrParams.Where(o => o.MEParamID == id).FirstOrDefault();
            if (p != null) return p;
            p = AppMemCache.GetParamFromDictKeyID(id);
            if (p != null)
                listEmrParams.Add(p);
            return p;
        }

        public List<MEParamRelationsInfo> GetParamRelations(Dictionary<int, List<MEParamRelationsInfo>> listParamRelations, int mEParamID)
        {
            if (listParamRelations.ContainsKey(mEParamID)) return listParamRelations[mEParamID];
            else
            {
                var list = AppMemCache.GetParamRelationsFromDict(mEParamID).OrderBy(p => p.MEParamRelationOrder).ToList();
                listParamRelations.Add(mEParamID, list);
                return list;
            }
        }

        public bool CheckIfAnyListChild(int paramID)
        {
            var children = AppMemCache.GetParamRelationsFromDict(paramID).ToList();
            foreach (var item in children)
            {
                var childParam = AppMemCache.GetParamFromDictKeyID(item.FK_MEParamChildID);
                if (childParam != null && childParam.MEParamType == EmrParamTypes.List.ToString())
                    return true;
            }
            return false;
        }

        /// <summary>
        /// insert thẻ single co childrend vào doc
        /// mac dinh group cua the moi add vao la template.METemplateGuid
        /// </summary>
        /// <param name="param">Param</param>
        /// <param name="postion">current postion where insert</param>
        /// <param name="onlyParentParam">override MEParamRelationOnlyAddMe</param>
        public DocumentPosition ExtractSingleParam(DevExpress.XtraRichEdit.API.Native.Document doc, MEParamsInfo param,
            DocumentPosition postion, string prefix, string group, bool onlyParentParam = false, bool overrideOnlyParentParam = false, bool caption = true)
        {
            var childrens = AppMemCache.GetParamRelationsFromDict(param.MEParamID).OrderBy(p => p.MEParamRelationOrder).ToList();
            //field needed to append update
            if (string.IsNullOrEmpty(prefix))
                prefix = param.MEParamNo;
            else
                prefix = $"{prefix}{CODES}{param.MEParamNo}";

            //insert caption for param
            DocumentRange range;
            if (caption)
            {
                range = doc.InsertText(postion, string.Format("{0}: ", param.MEParamCaption));
                if (childrens != null && childrens.Count > 0)
                {
                    range = doc.InsertText(range.End, " ");
                    //this.ClearParagrapFormat(doc, range);
                }
            }
            else
            {
                range = doc.InsertText(postion, " ");
            }
            //insert field
            var field = doc.Fields.Create(range.End, $"{prefix}{TAGS}{GTAG}={group}");
            // insert field result default
            if (childrens == null || childrens.Count == 0)
                range = doc.InsertText(field.ResultRange.Start, $"{BTAG}{param.MEParamValue}{ETAG}{param.MEParamUnit}");
            postion = field.ResultRange.Start;
            field.ShowCodes = false;

            if (onlyParentParam && !overrideOnlyParentParam) return postion;

            foreach (var c in childrens)
            {
                var childParam = AppMemCache.GetParamFromDictKeyID(c.FK_MEParamChildID);
                var nextChildren = AppMemCache.GetParamRelationsFromDict(childParam.MEParamID).OrderBy(p => p.MEParamRelationOrder).ToList();
                if (nextChildren.Count > 0 && (!c.MEParamRelationOnlyAddMe || overrideOnlyParentParam))
                {
                    // if it also have children
                    if (childParam.MEParamType == EmrParamTypes.Single.ToString())
                    {
                        //param nay co children add children the cum
                        postion = this.ExtractSingleParam(doc, childParam, postion, prefix, group, c.MEParamRelationOnlyAddMe, overrideOnlyParentParam);
                    }
                    else if (childParam.MEParamType == EmrParamTypes.List.ToString())
                    {
                        postion = this.ExtractListParamV2(doc, childParam, postion, prefix, group, 0, 0, c.MEParamRelationOnlyAddMe, overrideOnlyParentParam);
                    }
                }
                else
                {
                    //insert caption for param
                    range = doc.InsertText(postion, string.Format("{0}: ", childParam.MEParamCaption));
                    //insert field
                    //child param will be have code = parentCode_childCode
                    field = doc.Fields.Create(range.End, $"{prefix}{CODES}{childParam.MEParamNo}{TAGS}{GTAG}={group}");
                    // insert field result default
                    range = doc.InsertText(field.ResultRange.Start, $"{BTAG}{childParam.MEParamValue}{ETAG}{childParam.MEParamUnit}");
                    // insert newline for field code
                    range = doc.InsertText(field.Range.End, Environment.NewLine);
                    // go next postion
                    postion = range.End;
                    field.ShowCodes = false;
                }
            }
            return postion;
        }

        public MEParamsInfo GetParamByNo(List<MEParamsInfo> listEmrParams, string paramNo)
        {
            var p = listEmrParams.Where(o => o.MEParamNo == paramNo).FirstOrDefault();
            if (p != null) return p;
            p = AppMemCache.GetParamFromDictKeyNo(paramNo);
            if (p != null) listEmrParams.Add(p);
            return p;
        }

        public MEParamsInfo GetParamByNoV3(ConcurrentDictionary<string, MEParamsInfo> dictParams, string paramNo)
        {
            if (dictParams.TryGetValue(paramNo, out MEParamsInfo p))
                return p;
            p = AppMemCache.GetParamFromDictKeyNo(paramNo);
            if (p != null)
            {
                dictParams.TryAdd(paramNo, p);
            }
            return p;
        }
        /// <summary>
        /// uthv neu sai format se ko thong bao loi ma tra ve string
        /// </summary>
        /// <param name="type"></param>
        /// <param name="format"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetStringFromDataValue(string type, string format, object value, string fieldPath)
        {
            //26042019 ưu tiên lấy format theo template
            if (_templateParamDictPath != null && !string.IsNullOrEmpty(fieldPath))
            {
                fieldPath = GetTemplateFieldPath(fieldPath);
                _templateParamDictPath.TryGetValue(fieldPath, out METemplateParamsInfo tempParam);
                if (tempParam != null)

                {
                    if (!string.IsNullOrEmpty(tempParam.MEParamFormatString))
                        format = tempParam.MEParamFormatString;
                    if (!string.IsNullOrEmpty(tempParam.MEParamFormatType))
                        type = tempParam.MEParamFormatType;
                }
            }
            return this._dataHelper.GetStringFromDataValue(type, format, value);
        }

        public void BindingDataToFieldV2(MEParamsInfo param, Field updateField, object data, string prefix,
            string transaction, string group, MEEmrActionParamsInfo config, string formatStyle, HashSet<Field> exlFields = null,
            bool allowRecursive = false, MEEmrActionsInfo action = null, bool paramUnit = true)
        {
            var doc = this._richEditCtrl.Document;
            if (_richEditCtrl.InvokeRequired)
            {
                _richEditCtrl.BeginInvoke((Action)(() =>
                {
                    doc = this._richEditCtrl.Document;
                }));
            }
            var listEmrParams = new List<MEParamsInfo>();
            if (exlFields == null)
                exlFields = new HashSet<Field>();
            if (string.IsNullOrEmpty(prefix))
                prefix = param.MEParamNo;
            else
                prefix = $"{prefix}{CODES}{param.MEParamNo}";

            var updateMeta = $"{TAGS}{EmrParam.UserUpdate}={BOSApp.CurrentUsersInfo.ADUserName}{TAGS}{EmrParam.UserUpdateDate}={DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";
            //neu chua co transation thi gan transaction id
            if (!doc.GetText(updateField.CodeRange).Contains($"{EmrParam.TransactionIdTag}=") && !string.IsNullOrEmpty(transaction))
                updateMeta = $"{TAGS}{EmrParam.TransactionIdTag}={transaction}{updateMeta}";

            var groupMeta = $"{TAGS}{GTAG}={group}";

            if (_richEditCtrl.InvokeRequired)
            {
                _richEditCtrl.BeginInvoke((Action)(() =>
                {
                    doc.InsertText(updateField.CodeRange.End, updateMeta);
                }));
            }
            else
            {
                doc.InsertText(updateField.CodeRange.End, updateMeta);
            }
            var childrens = AppMemCache.GetParamRelationsFromDict(param.MEParamID).OrderBy(p => p.MEParamRelationOrder).ToList();

            #region EmrParamTypes.Single
            if (param.MEParamType == EmrParamTypes.Single.ToString())
            {
                if (childrens.Count == 0)
                {
                    //truong hop the don chi can update string la xong
                    BindingValueToField(doc, param, updateField, data, prefix, formatStyle, paramUnit);
                    updateField.ShowCodes = false;
                    exlFields.Add(updateField);
                    FormatToQrBarcode(updateField, param);
                }
                else
                {
                    if (param.MEParamControlType == EmrParamControlTypes.Radio.ToString())
                    {
                        if (data != null)
                        {
                            var foundChild = false;
                            //get value from return data
                            var parentValue = data.ToString();
                            foreach (var c in childrens)
                            {
                                var childParam = AppMemCache.GetParamFromDictKeyID(c.FK_MEParamChildID);
                                //child param will be have code = parentCode_childCode
                                var updateFields = this.GetBindingFields(group, $"{prefix}{CODES}{childParam.MEParamNo}", transaction, true, false, exlFields);
                                if (updateFields.Count > 0) foundChild = true;
                                //fix bug must be clear previous check
                                var value = (childParam.MEParamValue.ToUpper() == parentValue.ToUpper()) ? param.MEParamValue : "";
                                foreach (var uField in updateFields)
                                {
                                    BindingDataToFieldV2(childParam, uField, value, prefix, transaction, group, config, formatStyle, exlFields);
                                    exlFields.Add(uField);
                                }

                            }
                            // khong tim thay the con nao tren mau thi gan gia tri luon
                            if (!foundChild)
                            {
                                BindingValueToField(doc, param, updateField, data, prefix, formatStyle);
                                updateField.ShowCodes = false;
                                exlFields.Add(updateField);
                            }
                        }
                    }
                    else
                    {
                        var foundChild = false;
                        foreach (var c in childrens)
                        {
                            var childParam = AppMemCache.GetParamFromDictKeyID(c.FK_MEParamChildID);
                            //get update field from doc can have multi fields
                            //child param will be have code = parentCode_childCode
                            var updateFields = this.GetBindingFields(group, $"{prefix}{CODES}{childParam.MEParamNo}", transaction, true, false, exlFields);
                            //get value from return data
                            var parentValue = (data as JObject);
                            if (parentValue != null)
                            {
                                var dictData = parentValue.ToObject<IDictionary<string, object>>();
                                var childValue = this._dataHelper.GetValueToBinding(dictData, childParam.MEParamNo);
                                var childStyle = this._dataHelper.GetValueToBinding(dictData, childParam.MEParamNo + EmrConsts.FORMAT_STYLE_PREFIX)?.ToString();
                                if (childValue != null)
                                {
                                    foreach (var uField in updateFields)
                                    {
                                        BindingDataToFieldV2(childParam, uField, childValue, prefix, transaction, group, config, childStyle, exlFields);
                                        exlFields.Add(uField);
                                    }
                                }
                            }
                            if (!foundChild)
                                foundChild = updateFields.Count > 0;
                        }
                        //truong hop co du lieu can biding nhung lai ko tim thay the con thi do du lieu vao the cha luon
                        if (!foundChild)
                        {
                            BindingValueToField(doc, param, updateField, data, prefix, formatStyle);
                            updateField.ShowCodes = false;
                            exlFields.Add(updateField);
                            FormatToQrBarcode(updateField, param);
                        }
                        //
                        if (allowRecursive)
                        {
                            var subData = new Dictionary<string, JToken>();
                            this._dataHelper.DiscoverListSubData(data as JToken, prefix, subData);
                            exlFields = new HashSet<Field>();
                            this.BindingListDataToDoc(group, subData, listEmrParams, exlFields);
                        }
                    }
                }
            }
            #endregion

            #region EmrParamTypes.List
            else if (param.MEParamType == EmrParamTypes.List.ToString())
            {
                if (childrens.Count == 0)
                {
                    if (param.MEParamFormatType == EmrParamFormatTypes.Image.ToString() || param.MEParamFormatType == EmrParamFormatTypes.ImageRotate90.ToString())
                    {
                        BindingValueToField(doc, param, updateField, data, prefix, formatStyle);
                        updateField.ShowCodes = false;
                        exlFields.Add(updateField);
                    }
                    else
                    {
                        List<JToken> list = null;
                        if (data is JArray)
                            list = (data as JArray).ToList();
                        else if (data is List<JToken>)
                            list = data as List<JToken>;

                        if (list != null)
                        {
                            var postion = updateField.ResultRange.Start;
                            if (_richEditCtrl.InvokeRequired)
                            {
                                _richEditCtrl.BeginInvoke((Action)(() =>
                                {
                                    doc.Replace(updateField.ResultRange, string.Empty);
                                    for (int i = 0; i < list.Count; i++)
                                    {
                                        var field = doc.Fields.Create(postion, $"{prefix}{CODES}{i}{groupMeta}{updateMeta}");
                                        // insert field result default
                                        var value = new object();
                                        if (list[i].Type == JTokenType.Object)
                                            value = this._dataHelper.GetValueToBinding(list[i].ToObject<Dictionary<string, object>>(), param.MEParamNo);
                                        else
                                            value = list[i];

                                        if (value != null)
                                        {
                                            doc.InsertText(field.ResultRange.Start, $"{BTAG}{GetStringFromDataValue(param.MEParamFormatType, param.MEParamFormatString, value, prefix)}{ETAG}{param.MEParamUnit}");
                                        }
                                        field.ShowCodes = false;
                                        //list cau hinh dang hien thi du lieu ngang
                                        if (i < list.Count - 1 && param.MEParamListType != EmrParamListTypes.Horizontal.ToString())
                                        {
                                            postion = doc.InsertText(field.Range.End, "\n").End;
                                        }
                                        else
                                        {
                                            postion = field.Range.End;
                                        }
                                    }
                                }));
                            }
                            else
                            {
                                doc.Replace(updateField.ResultRange, string.Empty);
                                for (int i = 0; i < list.Count; i++)
                                {
                                    var field = doc.Fields.Create(postion, $"{prefix}{CODES}{i}{groupMeta}{updateMeta}");
                                    // insert field result default
                                    var value = new object();
                                    if (list[i].Type == JTokenType.Object)
                                        value = this._dataHelper.GetValueToBinding(list[i].ToObject<Dictionary<string, object>>(), param.MEParamNo);
                                    else
                                        value = list[i];

                                    if (value != null)
                                    {
                                        doc.InsertText(field.ResultRange.Start, $"{BTAG}{GetStringFromDataValue(param.MEParamFormatType, param.MEParamFormatString, value, prefix)}{ETAG}{param.MEParamUnit}");
                                    }
                                    field.ShowCodes = false;
                                    //list cau hinh dang hien thi du lieu ngang
                                    if (i < list.Count - 1 && param.MEParamListType != EmrParamListTypes.Horizontal.ToString())
                                    {
                                        postion = doc.InsertText(field.Range.End, "\n").End;
                                    }
                                    else
                                    {
                                        postion = field.Range.End;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (param.MEParamControlType == EmrParamControlTypes.Checkbox.ToString())
                    {
                        if (data is JArray)
                        {
                            var listValues = (data as JArray).Select(v => v.ToString()).ToArray();
                            foreach (var c in childrens)
                            {
                                var childParam = AppMemCache.GetParamFromDictKeyID(c.FK_MEParamChildID);
                                //child param will be have code = parentCode_childCode
                                var updateFields = this.GetBindingFields(group, $"{prefix}{CODES}{childParam.MEParamNo}", transaction, true, false, exlFields);
                                foreach (var uField in updateFields)
                                {
                                    var bidingValue = listValues.Contains(childParam.MEParamValue) ? param.MEParamValue : string.Empty;
                                    BindingDataToFieldV2(childParam, uField, bidingValue, prefix, transaction, group, config, formatStyle, exlFields);
                                    exlFields.Add(uField);
                                }
                            }
                        }
                    }
                    else
                    {
                        //truong hop copy dong TDT danhsachthuoc=""
                        if (data is String) return;

                        var listParamRelations = new Dictionary<int, List<MEParamRelationsInfo>>();
                        //uthv 03042019 nhom du lieu
                        var children = this.GetParamRelations(listParamRelations, param.MEParamID);
                        var groupParams = children.Where(c => c.MEParamRelationGroup).OrderBy(c => c.MEParamRelationOrder).ToList();
                        var groupParamRvs = children.Where(c => c.MEParamRelationGroup).OrderByDescending(c => c.MEParamRelationOrder).ToList();
                        MEParamsInfo groupParam = null;
                        if (groupParamRvs.Count > 0)
                        {
                            groupParam = GetParamByID(listEmrParams, groupParamRvs[0].FK_MEParamChildID);
                        }

                        var values = this._dataHelper.FlattenListData(prefix, data);
                        var postion = updateField.Range.Start;
                        Table table = this.GetTableFromDocument(this._richEditCtrl, updateField);
                        if (_richEditCtrl.InvokeRequired)
                        {
                            _richEditCtrl.BeginInvoke((Action)(() =>
                            {
                                table = this.GetTableFromDocument(this._richEditCtrl, updateField);
                            }));
                        }
                        var parentField = updateField;
                        parentField.ShowCodes = false;
                        if (table == null)
                        {
                            //tao table moi
                            if (param.MEParamListType == EmrParamListTypes.Horizontal.ToString())
                            {
                                ExtractListParamV2(doc, param, parentField.ResultRange.Start, "", group, childrens.Count, values.Count, false, true);
                            }
                            else
                            {
                                ExtractListParamV2(doc, param, parentField.ResultRange.Start, "", group, values.Count + 1, childrens.Count + 1, false, true);
                            }
                            table = this.GetTableFromDocument(this._richEditCtrl, updateField);
                            if (_richEditCtrl.InvokeRequired)
                            {
                                _richEditCtrl.BeginInvoke((Action)(() =>
                                {
                                    table = this.GetTableFromDocument(this._richEditCtrl, updateField);
                                }));
                            }
                        }

                        //04042019 uthv xoa toan bo dong nhom du lieu
                        if (groupParamRvs.Count > 0)
                        {
                            foreach (var g in groupParamRvs)
                            {
                                groupParam = GetParamByID(listEmrParams, g.FK_MEParamChildID);
                                RemoveAllTableGroupRow(table, prefix, groupParam.MEParamNo);
                            }
                            //neu co group ko chap nhan MEEmrActionParamAppendOnly hay MEEmrActionParamEditFromEnd
                            if (table.Rows.Count > 2)
                                for (var i = table.Rows.Count - 1; i >= 1; i--)
                                    RemoveTableRow(table, prefix, i);
                        }
                        else
                        {
                            //neu cau hinh cho phep xoa du lieu cu
                            //neu cau hinh chinh sua cac dong cuoi
                            if (config == null || (!config.MEEmrActionParamAppendOnly && !config.MEEmrActionParamEditFromEnd && !config.MEEmrActionParamUpdateOnly))
                                if (table != null && table.Rows.Count - 1 > values.Count)
                                {
                                    for (var i = table.Rows.Count - 1; i >= values.Count; i--)
                                    {
                                        RemoveTableRow(table, prefix, i);
                                    }
                                }
                        }

                        if (param.MEParamListType == EmrParamListTypes.Horizontal.ToString())
                        {
                            //ko tu dong them cot
                            for (int i = 0; i < values.Count; i++)
                            {
                                var row = values[i];
                                foreach (var cel in row)
                                {
                                    var p = GetParamByNo(listEmrParams, cel.Key.Split(CODES).Last());
                                    var childStyle = this._dataHelper.GetValueToBinding(row, cel.Key + EmrConsts.FORMAT_STYLE_PREFIX)?.ToString();
                                    this.BindingValueToField(doc, p, cel, transaction, group, exlFields, childStyle);
                                }
                            }
                        }
                        else
                        {
                            values = PreProgressDataBeforeBinding(values, listParamRelations, listEmrParams, param, prefix);
                            var startIdx = 0;
                            if (config != null && config.MEEmrActionParamAppendOnly)
                            {
                                startIdx = GetMaxRowIndex(prefix) + 1;
                                values = IncreaseIndexBeforeBinding(values, prefix, startIdx);
                            }
                            else if (config != null && config.MEEmrActionParamEditFromEnd)
                            {
                                startIdx = GetMaxRowIndex(prefix) - values.Count + 1;
                                values = IncreaseIndexBeforeBinding(values, prefix, startIdx);
                            }
                            var normalChilds = children.Where(r => !r.MEParamRelationGroup && !r.MEParamRelationGroupHeader && !r.MEParamRelationGroupFooter).ToArray();
                            var normalParamNos = normalChilds.Select(c => GetParamByID(listEmrParams, c.FK_MEParamChildID)?.MEParamNo).ToArray();

                            for (int i = 0; i < values.Count; i++)
                            {
                                var row = values[i];
                                // check truoc khi them group row
                                // tim toan bo the con do bug #2004
                                var rowIdx = HasTableRow(table, prefix, i + startIdx, normalParamNos);
                                var newG = group;
                                if (rowIdx < 0)
                                    rowIdx = this.AddTableRow(action, param, group, group, listEmrParams, listParamRelations, prefix);
                                else // truong hop nay dung cho truong hop TDT lay du lieu danh sach ma table moi dong lai co group khac nhau 
                                {
                                    var f = GetFirstEmrFieldByPrefix($"{prefix}{CODES}{i + startIdx}");
                                    if (f != null) newG = f.Gid;
                                }

                                //uthv 03042019 nhom du lieu
                                groupParams = children.Where(c => c.MEParamRelationGroup).ToList();
                                for (int gi = 0; gi < groupParams.Count; gi++)
                                {
                                    groupParam = GetParamByID(listEmrParams, groupParams[gi].FK_MEParamChildID);
                                    var dataIdx = i + startIdx;
                                    var groupValue = row[$"{prefix}{CODES}{dataIdx}{CODES}{groupParam.MEParamNo}"].ToString();
                                    // hoi bi phuc tap
                                    if (!HasTableGroupRow(prefix, dataIdx, groupParam.MEParamNo, groupValue))
                                    {
                                        var groupLevelValue = groupValue;
                                        for (int preg = gi - 1; preg >= 0; preg--)
                                        {
                                            var gr = GetParamByID(listEmrParams, groupParams[preg].FK_MEParamChildID);
                                            groupLevelValue += (EmrParam.BeginTag + row[$"{prefix}{CODES}{dataIdx}{CODES}{gr.MEParamNo}"].ToString());
                                        }
                                        var groupIdxs = new List<int>();
                                        for (int nextIdx = i + 1; nextIdx < values.Count; nextIdx++)
                                        {
                                            var nextRowValue = values[nextIdx][$"{prefix}{CODES}{nextIdx + startIdx}{CODES}{groupParam.MEParamNo}"].ToString();
                                            for (int preg = gi - 1; preg >= 0; preg--)
                                            {
                                                var gr = GetParamByID(listEmrParams, groupParams[preg].FK_MEParamChildID);
                                                nextRowValue += (EmrParam.BeginTag + values[nextIdx][$"{prefix}{CODES}{nextIdx + startIdx}{CODES}{gr.MEParamNo}"].ToString());
                                            }
                                            if (groupLevelValue == nextRowValue)
                                                groupIdxs.Add(nextIdx + startIdx);
                                        }
                                        this.InsertTableGroupRow(table, action, groupParams, newG, prefix, rowIdx, dataIdx, groupParam.MEParamNo, groupValue, groupIdxs);
                                        rowIdx++;
                                    }
                                }

                                foreach (var cel in row)
                                {
                                    var p = GetParamByNo(listEmrParams, cel.Key.Split(CODES).Last());
                                    var childStyle = string.Empty;
                                    if (p != null)
                                    {
                                        if (p.MEParamFormatType == EmrParamFormatTypes.Symbol.ToString())
                                            this.InsertSymbolByData(doc, p, cel, transaction, newG, listParamRelations, listEmrParams);

                                        childStyle = this._dataHelper.GetValueToBinding(row, cel.Key + EmrConsts.FORMAT_STYLE_PREFIX)?.ToString();
                                    }
                                    this.BindingValueToField(doc, p, cel, transaction, newG, exlFields, childStyle);
                                }
                                if (allowRecursive)
                                {
                                    var subData = new Dictionary<string, JToken>();
                                    this._dataHelper.DiscoverListSubData(JToken.FromObject(JArray.FromObject(data)[i]), $"{prefix}{CODES}{i + startIdx}{CODES}", subData);
                                    //exlFields = new HashSet<Field>();
                                    this.BindingListDataToDoc(newG, subData, listEmrParams, exlFields);
                                }
                            }
                        }
                    }
                }
            }
            #endregion
        }

        private void InsertTableGroupRow(Table table, MEEmrActionsInfo action, List<MEParamRelationsInfo> groupParams,
            string group, string prefix, int rowIdx, int dataIdx, string groupParamNo, string groupValue, List<int> groupIdxs)
        {
            var doc = this._richEditCtrl.Document;
            var row = table.Rows.InsertBefore(rowIdx);
            table.MergeCells(row.FirstCell, row.LastCell);
            var cell = row.FirstCell;
            var groupMeta = $"{TAGS}{GTAG}={group}";
            var field = doc.Fields.Create(cell.ContentRange.Start, $"{prefix}{CODES}{dataIdx}{CODES}{groupParamNo}{groupMeta}");
            field.ShowCodes = false;
            doc.InsertText(field.ResultRange.Start, $"{BTAG} {groupValue} {ETAG}");
            CharacterProperties cp = doc.BeginUpdateCharacters(field.ResultRange);
            cp.Bold = true;
            doc.EndUpdateCharacters(cp);
            if (groupIdxs.Count == 0) return;
            doc.InsertText(field.Range.End, " ");
            foreach (var item in groupIdxs)
            {
                field = doc.Fields.Create(cell.ContentRange.End, $"{prefix}{CODES}{item}{CODES}{groupParamNo}{groupMeta}");
                field.ShowCodes = false;
                doc.InsertText(field.ResultRange.Start, $"{BTAG} {groupValue} {ETAG}");
                cp = doc.BeginUpdateCharacters(field.ResultRange);
                cp.Hidden = true;
                doc.EndUpdateCharacters(cp);
            }
        }

        private void InsertSymbolByData(Document doc, MEParamsInfo p, KeyValuePair<string, object> cel, string transaction, string group,
             Dictionary<int, List<MEParamRelationsInfo>> listParamRelations, List<MEParamsInfo> listEmrParams)
        {
            if (_symbolCaching == null)
                _symbolCaching = new Dictionary<string, Image>();

            List<Field> updateFields;
            if (!listParamRelations.ContainsKey(p.MEParamID))
            {
                var children = this.GetParamRelations(listParamRelations, p.MEParamID);
            }
            //neu co the con thi chen vao the con, neu khong co the con thi bao the hien tai
            if (listParamRelations.ContainsKey(p.MEParamID) && listParamRelations[p.MEParamID].Count > 0)
            {
                //chen ky hieu vao the con thay vi the cha
                var child = GetParamByID(listEmrParams, listParamRelations[p.MEParamID].First().FK_MEParamChildID);
                updateFields = this.GetBindingFields(group, cel.Key.Replace(CODES + p.MEParamNo, CODES + child.MEParamNo), transaction, false, false, null);
            }
            else
                updateFields = this.GetBindingFields(group, cel.Key, transaction, false, false, null);
            if (!_symbolCaching.ContainsKey(p.MEParamNo + cel.Value.ToString()))
                GetAllSymbol(p.FK_MEParamLookupID, p.MEParamNo);
            if (_symbolCaching.ContainsKey(p.MEParamNo + cel.Value.ToString()))
            {
                var img = _symbolCaching[p.MEParamNo + cel.Value.ToString()];
                foreach (var updateField in updateFields)
                {
                    for (int i = 0; i < doc.Shapes.Count; i++)
                    {
                        var s = doc.Shapes[i];
                        if (s.Range.Start.ToInt() == updateField.ResultRange.Start.ToInt())
                            doc.Delete(s.Range);
                    }
                    var pic = doc.Shapes.InsertPicture(updateField.ResultRange.Start, img);
                    pic.RelativeHorizontalPosition = ShapeRelativeHorizontalPosition.Character;
                    pic.HorizontalAlignment = ShapeHorizontalAlignment.Left;
                    pic.RelativeVerticalPosition = ShapeRelativeVerticalPosition.Line;
                    pic.VerticalAlignment = ShapeVerticalAlignment.Center;
                    pic.TextWrapping = TextWrappingType.BehindText;
                }
            }
        }

        private void GetAllSymbol(int fK_MEParamLookupID, string paramNo)
        {
            var lookupDatas = _lookupDataCtrl.GetListBusinessObjects<MEParamLookupDatasInfo>(_lookupDataCtrl.GetAllDataByForeignColumn("FK_MEParamLookupID", fK_MEParamLookupID));
            foreach (var item in lookupDatas)
            {
                var symbol = _symbolCtrl.GetObjectByID(item.FK_MEEmrSymbolID) as MEEmrSymbolsInfo;
                if (symbol != null && symbol.MEEmrSymbolIcon != null)
                {
                    using (MemoryStream ms = new MemoryStream(symbol.MEEmrSymbolIcon))
                    {
                        if (!_symbolCaching.ContainsKey(paramNo + item.MEParamLookupDataValue))
                            _symbolCaching.Add(paramNo + item.MEParamLookupDataValue, Image.FromStream(ms));
                    }
                }
            }
        }

        private void FormatToQrBarcode(Field updateField, MEParamsInfo param)
        {
            var doc = this._richEditCtrl.Document;
            if (param.MEParamFormatType == EmrParamFormatTypes.Barcode.ToString())
            {
                if (string.IsNullOrEmpty(param.MEParamFormatString)) return;
                var text = doc.GetText(updateField.ResultRange);
                text = text.TrimStart(BTAG.ToCharArray()).TrimEnd(ETAG.ToCharArray());
                var font = FontFamily.Families.Where(f => f.Name == param.MEParamFormatString).FirstOrDefault();
                if (font != null)
                {
                    if (_richEditCtrl.InvokeRequired)
                    {
                        _richEditCtrl.BeginInvoke((Action)(() =>
                        {
                            doc.Replace(updateField.ResultRange, text);
                        }));
                    }
                    else
                    {
                        doc.Replace(updateField.ResultRange, text);
                    }
                    var barcodeCharStyle = doc.CharacterStyles.CreateNew();
                    var cf = doc.BeginUpdateCharacters(updateField.ResultRange);
                    barcodeCharStyle.Assign(cf);
                    doc.EndUpdateCharacters(cf);

                    var barcodeStyle = doc.ParagraphStyles["Barcode"];
                    if (barcodeStyle == null)
                    {
                        if (_richEditCtrl.InvokeRequired)
                        {
                            _richEditCtrl.BeginInvoke((Action)(() =>
                            {
                                doc.BeginUpdate();
                            }));
                        }
                        else
                        {
                            doc.BeginUpdate();
                        }
                        barcodeStyle = doc.ParagraphStyles.CreateNew();
                        barcodeStyle.Assign(barcodeCharStyle);
                        barcodeStyle.Name = "Barcode";
                        doc.ParagraphStyles.Add(barcodeStyle);
                        barcodeCharStyle.Name = "BarcodeChar";
                        doc.CharacterStyles.Add(barcodeCharStyle);
                        barcodeCharStyle.LinkedStyle = barcodeStyle;
                        barcodeCharStyle.FontName = param.MEParamFormatString;
                        if (_richEditCtrl.InvokeRequired)
                        {
                            _richEditCtrl.BeginInvoke((Action)(() =>
                            {
                                doc.EndUpdate();
                            }));
                        }
                        else
                        {
                            doc.EndUpdate();
                        }
                    }
                    cf = doc.BeginUpdateCharacters(updateField.ResultRange);
                    cf.Style = barcodeStyle.LinkedStyle;
                    doc.EndUpdateCharacters(cf);
                }
                else
                {
                    Symbology symbology;
                    var hasText = param.MEParamFormatString.ToLower().EndsWith("-text");
                    var symbologyStr = param.MEParamFormatString.Replace("-Text", string.Empty);
                    symbologyStr = param.MEParamFormatString.Replace("-text", string.Empty);

                    if (!Enum.TryParse(symbologyStr, out symbology))
                        symbology = Symbology.Code128;

                    BarCode barCode = new BarCode
                    {
                        Symbology = symbology,
                        CodeText = text,
                        BackColor = Color.White,
                        ForeColor = Color.Black,
                        RotationAngle = 0,
                        DpiX = 72,
                        DpiY = 72,
                        Module = 1f,
                        //BarHeight = param.MEParamImageHeight
                    };
                    barCode = FormatToQrBarcodeWithText(barCode, hasText);
                    var cf = doc.BeginUpdateCharacters(updateField.ResultRange);
                    var fontSize = cf.FontSize.HasValue ? cf.FontSize.Value : 12;
                    barCode.CodeTextFont = new Font(cf.FontName, fontSize);
                    barCode.CodeBinaryData = Encoding.Default.GetBytes(text);
                    var pic = doc.Shapes.InsertPicture(updateField.ResultRange.Start, barCode.BarCodeImage);
                    pic.RelativeHorizontalPosition = ShapeRelativeHorizontalPosition.Character;
                    pic.RelativeVerticalPosition = ShapeRelativeVerticalPosition.Line;
                    pic.Offset = new PointF(0, 0);
                    pic.ScaleX /= (pic.Size.Width / (param.MEParamImageWidth > 0 ? param.MEParamImageWidth : 300));
                    pic.ScaleY /= (pic.Size.Height / (param.MEParamImageHeight > 0 ? param.MEParamImageHeight : 150));
                    doc.EndUpdateCharacters(cf);
                }
            }
            else if (param.MEParamFormatType == EmrParamFormatTypes.QRCode.ToString())
            {
                var text = doc.GetText(updateField.ResultRange);
                text = text.TrimStart(BTAG.ToCharArray()).TrimEnd(ETAG.ToCharArray());
                QRCodeData qrCodeData = _qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                var pic = doc.Shapes.InsertPicture(updateField.ResultRange.Start, qrCodeImage);
                pic.RelativeHorizontalPosition = ShapeRelativeHorizontalPosition.Character;
                pic.RelativeVerticalPosition = ShapeRelativeVerticalPosition.Line;
                pic.Offset = new PointF(0, 0);
                var size = param.MEParamImageWidth > 0 ? param.MEParamImageWidth : 300;
                pic.ScaleX /= (pic.Size.Width / size);
                pic.ScaleY /= (pic.Size.Height / size);
            }
        }
        private BarCode FormatToQrBarcodeWithText(BarCode barCode, bool hasText)
        {
            switch (barCode.Symbology)
            {
                case Symbology.Codabar:
                    barCode.Options.Codabar.ShowCodeText = hasText;
                    break;
                case Symbology.Industrial2of5:
                    barCode.Options.Industrial2of5.ShowCodeText = hasText;
                    break;
                case Symbology.Interleaved2of5:
                    barCode.Options.Interleaved2of5.ShowCodeText = hasText;
                    break;
                case Symbology.Code39:
                    barCode.Options.Code39.ShowCodeText = hasText;
                    break;
                case Symbology.Code39Extended:
                    barCode.Options.Code39Extended.ShowCodeText = hasText;
                    break;
                case Symbology.Code93:
                    barCode.Options.Code93.ShowCodeText = hasText;
                    break;
                case Symbology.Code93Extended:
                    barCode.Options.Code93Extended.ShowCodeText = hasText;
                    break;
                case Symbology.Code128:
                    barCode.Options.Code128.ShowCodeText = hasText;
                    break;
                case Symbology.Code11:
                    barCode.Options.Code11.ShowCodeText = hasText;
                    break;
                case Symbology.CodeMSI:
                    barCode.Options.CodeMSI.ShowCodeText = hasText;
                    break;
                case Symbology.PostNet:
                    barCode.Options.PostNet.ShowCodeText = hasText;
                    break;
                case Symbology.EAN13:
                    barCode.Options.EAN13.ShowCodeText = hasText;
                    break;
                case Symbology.UPCA:
                    barCode.Options.UPCA.ShowCodeText = hasText;
                    break;
                case Symbology.EAN8:
                    barCode.Options.EAN8.ShowCodeText = hasText;
                    break;
                case Symbology.EAN128:
                    barCode.Options.EAN128.ShowCodeText = hasText;
                    break;
                case Symbology.UPCSupplemental2:
                    barCode.Options.UPCSupplemental2.ShowCodeText = hasText;
                    break;
                case Symbology.UPCSupplemental5:
                    barCode.Options.UPCSupplemental5.ShowCodeText = hasText;
                    break;
                case Symbology.UPCE0:
                    barCode.Options.UPCE0.ShowCodeText = hasText;
                    break;
                case Symbology.UPCE1:
                    barCode.Options.UPCE1.ShowCodeText = hasText;
                    break;
                case Symbology.Matrix2of5:
                    barCode.Options.Matrix2of5.ShowCodeText = hasText;
                    break;
                case Symbology.PDF417:
                    barCode.Options.PDF417.ShowCodeText = hasText;
                    break;
                case Symbology.DataMatrix:
                    barCode.Options.DataMatrix.ShowCodeText = hasText;
                    break;
                case Symbology.QRCode:
                    barCode.Options.QRCode.ShowCodeText = hasText;
                    break;
                case Symbology.IntelligentMail:
                    barCode.Options.IntelligentMail.ShowCodeText = hasText;
                    break;
                case Symbology.DataMatrixGS1:
                    barCode.Options.DataMatrixGS1.ShowCodeText = hasText;
                    break;
                case Symbology.DataBar:
                    barCode.Options.DataBar.ShowCodeText = hasText;
                    break;
                case Symbology.ITF14:
                    barCode.Options.ITF14.ShowCodeText = hasText;
                    break;
                default:
                    break;
            }
            return barCode;
        }
        public List<Field> GetFieldsByPrefix(string group, string prefix, string transaction)
        {
            var doc = this._richEditCtrl.Document;
            var fields = new List<Field>();
            foreach (var field in doc.Fields)
            {
                _fieldToCodeCache.TryGetValue(field, out EmrField emrField);

                if (emrField == null)
                {
                    var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                    emrField = AddCacheBindingField(field, text);
                }
                var codes = emrField.Tokens;
                if (codes[0].StartsWith(prefix + CODES))
                {
                    var gid = emrField.Gid;
                    if (group.Equals(gid))
                    {
                        codes = doc.GetText(field.CodeRange, _plainTextExportCfg).Split(TAGS); //get lai vi co the field da dc thay doi
                        var tid = codes.Where(t => t.StartsWith($"{EmrParam.TransactionIdTag}=")).FirstOrDefault();
                        tid = tid != null ? tid.Substring(EmrParam.TransactionIdTag.Length + 1) : string.Empty;
                        if ((string.IsNullOrEmpty(tid) || string.IsNullOrEmpty(transaction) || tid.Equals(transaction)))
                        {
                            fields.Add(field);
                        }
                    }
                }
            }
            return fields;
        }
        public List<Field> GetFieldsByGroup(string group)
        {
            var doc = this._richEditCtrl.Document;
            var fields = new List<Field>();
            foreach (var field in doc.Fields)
            {
                _fieldToCodeCache.TryGetValue(field, out EmrField emrField);
                if (emrField == null)
                {
                    var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                    emrField = AddCacheBindingField(field, text);
                }
                var codes = emrField.Tokens;// text.Split(TAGS);
                if (group.Equals(emrField.Gid))
                {
                    fields.Add(field);
                }
            }
            return fields;
        }

        private int GetMaxRowIndex(string prefix)
        {
            var doc = this._richEditCtrl.Document;
            int maxIdx = 0;
            Regex rdr = new Regex(string.Format(@"{0}{1}([\d]*){2}", prefix, CODES, CODES));
            foreach (var field in doc.Fields)
            {
                _fieldToCodeCache.TryGetValue(field, out EmrField emrField);
                if (emrField == null)
                {
                    var text = doc.GetText(field.CodeRange);
                    emrField = AddCacheBindingField(field, text);
                }
                var mt = rdr.Match(emrField.FieldCode);
                if (mt.Success)
                {
                    if (int.TryParse(mt.Groups[1].Value, out int idx))
                        if (idx > maxIdx)
                            maxIdx = idx;

                }
            }
            return maxIdx;
        }
        private TableRow GetRowWithMaxIndex(Table table, string prefix)
        {
            var doc = this._richEditCtrl.Document;
            int maxIdx = 0;
            TableRow maxRow = null;
            Regex rdr = new Regex(string.Format(@"{0}{1}([\d]*){2}", prefix, CODES, CODES));
            foreach (var field in doc.Fields)
            {
                _fieldToCodeCache.TryGetValue(field, out EmrField emrField);
                if (emrField == null)
                {
                    var text = doc.GetText(field.CodeRange);
                    emrField = AddCacheBindingField(field, text);
                }
                var mt = rdr.Match(emrField.FieldCode);
                if (mt.Success)
                {
                    if (int.TryParse(mt.Groups[1].Value, out int idx))
                    {
                        if (idx >= maxIdx)
                        {
                            maxIdx = idx;
                            maxRow = table.Rows.Where(r => r.Range.Start < field.Range.Start && r.Range.End > field.Range.End).FirstOrDefault();
                        }
                    }
                }
            }
            return maxRow;
        }
        private List<Dictionary<string, object>> IncreaseIndexBeforeBinding(List<Dictionary<string, object>> values, string prefix, int startIdx)
        {
            var result = new List<Dictionary<string, object>>();
            for (int i = 0; i < values.Count; i++)
            {
                var v = values[i];
                var newV = new Dictionary<string, object>();
                foreach (var key in v.Keys)
                {
                    var newKey = Regex.Replace(key, string.Format(@"{0}{1}([\d]*){2}", prefix, CODES, CODES), prefix + CODES + (startIdx + i) + CODES);
                    newV.Add(newKey, v[key]);
                }
                result.Add(newV);
            }
            return result;
        }
        private void RemoveAllTableGroupRow(Table table, string prefix, string groupParamNo)
        {
            var doc = this._richEditCtrl.Document;
            for (int f = 0; f < doc.Fields.Count; f++)
            {
                var field = doc.Fields[f];
                var text = doc.GetText(field.CodeRange);
                if (Regex.IsMatch(text, $"^{prefix}{CODES}([\\d]*){CODES}{groupParamNo}\\{TAGS}"))
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        var row = table.Rows[i];
                        if (row.Range.Start.ToInt() < field.ResultRange.Start.ToInt() && row.Range.End.ToInt() > field.ResultRange.End.ToInt())
                        {
                            table.Rows.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }

        private void RemoveTableRow(Table table, string prefix, int idx)
        {
            var doc = this._richEditCtrl.Document;
            var prf = $"{prefix}{CODES}{idx}";
            for (int f = 0; f < doc.Fields.Count; f++)
            {
                var field = doc.Fields[f];
                // cac field cung row da bi remove se bao loi nen can check valid
                if (!(field as DevExpress.XtraRichEdit.API.Native.Implementation.NativeField).IsValid) continue;
                _fieldToCodeCache.TryGetValue(field, out EmrField emrField);
                if (emrField == null)
                {
                    var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                    emrField = AddCacheBindingField(field, text);
                }
                if (emrField.FieldCode.StartsWith(prf, StringComparison.Ordinal))
                {
                    for (int i = idx; i < table.Rows.Count; i++)
                    {
                        if (!(field as DevExpress.XtraRichEdit.API.Native.Implementation.NativeField).IsValid) break;
                        var row = table.Rows[i];
                        if (row.Range.Start < field.Range.Start && row.Range.End > field.Range.End)
                        {
                            table.Rows.RemoveAt(i);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// UtHV chỉ mới xét dữ liệu 2 cấp, tránh đệ quy
        /// </summary>
        /// <param name="values"></param>
        /// <param name="listParamRelations"></param>
        /// <param name="listEmrParams"></param>
        /// <param name="param"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        private List<Dictionary<string, object>> PreProgressDataBeforeBinding(List<Dictionary<string, object>> values, Dictionary<int, List<MEParamRelationsInfo>> listParamRelations, List<MEParamsInfo> listEmrParams, MEParamsInfo param, string prefix)
        {
            // if (values.Count < 2) return values;
            var children = this.GetParamRelations(listParamRelations, param.MEParamID);
            foreach (var child in children)
            {
                var nextParam = this.GetParamByID(listEmrParams, child.FK_MEParamChildID);
                if (nextParam == null) continue;

                //Symbol Symbol phai la cot cuoi cung
                if (nextParam.MEParamFormatType == EmrParamFormatTypes.Symbol.ToString())
                {
                    for (int i = 0; i < values.Count; i++)
                    {
                        var v = values[i];
                        var code = (prefix + CODES + i + CODES + nextParam.MEParamNo);
                        if (v.ContainsKey(code))
                        {
                            var value = v[code];
                            v.Remove(code);
                            var newDict = new Dictionary<string, object>(v);
                            newDict.Add(code, value);
                            values[i] = newDict;
                        }
                    }
                }
                if (child.MEParamRelationGroupHeader)
                {
                    if (values.Count > 1)
                    {
                        var v = values[0];
                        for (int i = 1; i < values.Count; i++)
                        {
                            //TODO xem lại cho nay
                            var code = (prefix + CODES + i + CODES + nextParam.MEParamNo);
                            if (v.ContainsKey(code) && !values[i].ContainsKey(code))
                                values[i].Add(code, v[code]);
                        }
                    }
                }
                else
                {
                    var nextChilds = this.GetParamRelations(listParamRelations, nextParam.MEParamID);
                    if (nextChilds.Count > 0)
                    {
                        foreach (var nextChild in nextChilds)
                        {
                            var nextChildParam = this.GetParamByID(listEmrParams, nextChild.FK_MEParamChildID);
                            if (nextChildParam == null) continue;
                            if (nextChild.MEParamRelationGroupHeader)
                            {
                                for (int i = 1; i < values.Count; i++)
                                {
                                    var v = values[i];
                                    for (int j = 0; j < nextParam.MEParamSampleCount; j++)
                                    {
                                        var code = (prefix + CODES + i + CODES + nextParam.MEParamNo + CODES + j + CODES + nextChildParam.MEParamNo);
                                        var code0 = (prefix + CODES + 0 + CODES + nextParam.MEParamNo + CODES + j + CODES + nextChildParam.MEParamNo);
                                        if (v.ContainsKey(code) && !values[0].ContainsKey(code0))
                                            values[0].Add(code0, v[code]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return values;
        }
        /// <summary>
        /// group row khong check index, chi check value
        /// </summary>
        /// <param name="path"></param>
        /// <param name="i"></param>
        /// <param name="groupParamNo"></param>
        /// <param name="groupValue"></param>
        /// <returns></returns>
        public bool HasTableGroupRow(string path, int i, string groupParamNo, string groupValue)
        {
            var doc = this._richEditCtrl.Document;
            var fields = new List<Field>();
            foreach (var field in doc.Fields)
            {
                _fieldToCodeCache.TryGetValue(field, out EmrField emrField);
                if (emrField == null)
                {
                    var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                    emrField = AddCacheBindingField(field, text);
                }

                //if (Regex.IsMatch(emrField.FieldCode, $"^{path}{CODES}([\\d]*){CODES}{groupParamNo}\\{TAGS}"))
                if (emrField.FieldCode.StartsWith($"{path}{CODES}{i}{CODES}{groupParamNo}{TAGS}"))
                {
                    var value = doc.GetText(field.ResultRange, _plainTextExportCfg).Trim();
                    value = value.TrimEnd(ETAG.ToCharArray()).TrimStart(BTAG.ToCharArray());
                    if (value.Trim() == groupValue)
                        return true;
                }
            }
            return false;
        }
        public int HasTableRow(Table table, string path, int dataIndex, string[] normalParamNos)
        {
            var result = -1;
            if (_richEditCtrl.InvokeRequired)
            {
                _richEditCtrl.BeginInvoke((Action)(() =>
                {
                    var doc = this._richEditCtrl.Document;
                    var fields = new List<Field>();
                    foreach (var field in doc.Fields)
                    {
                        _fieldToCodeCache.TryGetValue(field, out EmrField emrField);
                        if (emrField == null)
                        {
                            var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                            emrField = AddCacheBindingField(field, text);
                        }
                        foreach (var paramNo in normalParamNos)
                        {
                            var prf = $"{path}{CODES}{dataIndex}{CODES}{paramNo}";
                            if (emrField.FieldCode.StartsWith(prf, StringComparison.Ordinal))
                            {
                                for (int i = 0; i < table.Rows.Count; i++)
                                {
                                    var row = table.Rows[i];
                                    if (row.Range.Start < field.ResultRange.Start && row.Range.End > field.ResultRange.End)
                                    {
                                        result = i;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    result = -1;
                }));
            }
            else
            {
                var doc = this._richEditCtrl.Document;
                var fields = new List<Field>();
                foreach (var field in doc.Fields)
                {
                    _fieldToCodeCache.TryGetValue(field, out EmrField emrField);
                    if (emrField == null)
                    {
                        var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                        emrField = AddCacheBindingField(field, text);
                    }
                    foreach (var paramNo in normalParamNos)
                    {
                        var prf = $"{path}{CODES}{dataIndex}{CODES}{paramNo}";
                        if (emrField.FieldCode.StartsWith(prf, StringComparison.Ordinal))
                        {
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                var row = table.Rows[i];
                                if (row.Range.Start < field.ResultRange.Start && row.Range.End > field.ResultRange.End)
                                {
                                    return i;
                                }
                            }
                        }
                    }
                }
                return -1;
            }
            return result;
        }
        /// <summary>
        /// them moi dong cho table
        /// </summary>
        /// <param name="param"></param>
        /// <param name="actionGroup">group của action</param>
        /// <param name="group">group moi, neu action co phat sinh nhom moi thi se sinh group moi</param>
        /// <param name="listEmrParams"></param>
        /// <param name="listParamRelations"></param>
        /// <param name="path"></param>
        public int AddTableRow(MEEmrActionsInfo action, MEParamsInfo param, string actionGroup, string group, List<MEParamsInfo> listEmrParams,
            Dictionary<int, List<MEParamRelationsInfo>> listParamRelations, string path = "", bool hiddenRow = false)
        {
            var doc = this._richEditCtrl.Document;
            var rowIdx = -1;
            try
            {
                if (_richEditCtrl.InvokeRequired)
                {
                    _richEditCtrl.BeginInvoke((Action)(() =>
                    {
                        doc.BeginUpdate();
                        //get update field from doc can have multi fields
                        var updateFields = this.GetBindingFields(actionGroup, string.IsNullOrEmpty(path) ? param.MEParamNo : path, string.Empty, false);
                        //change gid if must be change
                        var newGroup = actionGroup.Equals(group) ? actionGroup : group;
                        //fix vi trong mot so truong hop tim duoc 2 the giong nhau vi chuc nang thay the the bang template
                        var updateField = updateFields.FirstOrDefault();
                        if (updateField != null)
                        {
                            Table table = this.GetTableFromDocument(this._richEditCtrl, updateField);
                            if (table == null) 
                            {
                                rowIdx = 0;
                                //return 0;
                            }
                            else
                            {
                                //do moi param dc check la footer se la mot dong trong table
                                //truong hop user tu them dong moi se co loi
                                int footerRowCount = this.GetFooterRowCount(param, listEmrParams, listParamRelations);
                                var row = table.Rows.InsertAfter(table.Rows.Count - footerRowCount - 1);

                                rowIdx = row.Index;
                                var maxRow = GetRowWithMaxIndex(table, string.IsNullOrEmpty(path) ? param.MEParamNo : path);
                                var preRow = table.Rows[row.Index - 1];
                                if (hiddenRow)
                                {
                                    //them 1 dong moi dung de cho phep ky theo dong ko bi loi
                                    var hidenRow = table.Rows.InsertAfter(table.Rows.Count - footerRowCount - 1);
                                    foreach (var cell in hidenRow.Cells)
                                    {
                                        cell.Borders.Top.LineStyle = TableBorderLineStyle.None;
                                        if (action != null)
                                        {
                                            cell.Borders.Bottom.LineStyle = (TableBorderLineStyle)Enum.Parse(typeof(TableBorderLineStyle), action.MEEmrActionBorderBottomStyle, true);
                                            cell.Borders.Bottom.LineColor = Color.FromArgb(action.MEEmrActionBorderBottomColor);
                                            cell.Borders.Bottom.LineThickness = (float)action.MEEmrActionBorderBottomThickness;

                                            if (!action.MEEmrActionBorderOuterOnly)
                                            {
                                                cell.Borders.Right.LineStyle = (TableBorderLineStyle)Enum.Parse(typeof(TableBorderLineStyle), action.MEEmrActionBorderRightStyle, true);
                                                cell.Borders.Left.LineStyle = (TableBorderLineStyle)Enum.Parse(typeof(TableBorderLineStyle), action.MEEmrActionBorderLeftStyle, true);
                                                cell.Borders.Right.LineThickness = (float)action.MEEmrActionBorderRightThickness;
                                                cell.Borders.Left.LineThickness = (float)action.MEEmrActionBorderLeftThickness;
                                                cell.Borders.Right.LineColor = Color.FromArgb(action.MEEmrActionBorderRightColor);
                                                cell.Borders.Left.LineColor = Color.FromArgb(action.MEEmrActionBorderLeftColor);
                                            }
                                        }
                                    }
                                    if (action != null && action.MEEmrActionBorderOuterOnly)
                                    {
                                        var first = hidenRow.Cells.First();
                                        first.Borders.Left.LineStyle = (TableBorderLineStyle)Enum.Parse(typeof(TableBorderLineStyle), action.MEEmrActionBorderLeftStyle, true);
                                        first.Borders.Left.LineThickness = (float)action.MEEmrActionBorderLeftThickness;
                                        first.Borders.Left.LineColor = Color.FromArgb(action.MEEmrActionBorderLeftColor);
                                        var last = hidenRow.Cells.Last();
                                        last.Borders.Right.LineStyle = (TableBorderLineStyle)Enum.Parse(typeof(TableBorderLineStyle), action.MEEmrActionBorderRightStyle, true);
                                        last.Borders.Right.LineThickness = (float)action.MEEmrActionBorderRightThickness;
                                        last.Borders.Right.LineColor = Color.FromArgb(action.MEEmrActionBorderRightColor);
                                    }

                                    if (preRow != null && action != null)
                                    {
                                        foreach (var preCell in preRow.Cells)
                                        {
                                            preCell.Borders.Bottom.LineStyle = (TableBorderLineStyle)Enum.Parse(typeof(TableBorderLineStyle), action.MEEmrActionBorderTopStyle, true);
                                            preCell.Borders.Bottom.LineColor = Color.FromArgb(action.MEEmrActionBorderTopColor);
                                            preCell.Borders.Bottom.LineThickness = (float)action.MEEmrActionBorderTopThickness;
                                        }
                                    }
                                    foreach (var cell in row.Cells)
                                    {
                                        cell.Borders.Bottom.LineStyle = TableBorderLineStyle.None;
                                        if (action != null)
                                        {
                                            cell.Borders.Top.LineStyle = (TableBorderLineStyle)Enum.Parse(typeof(TableBorderLineStyle), action.MEEmrActionBorderTopStyle, true);
                                            cell.Borders.Top.LineColor = Color.FromArgb(action.MEEmrActionBorderTopColor);
                                            cell.Borders.Top.LineThickness = (float)action.MEEmrActionBorderTopThickness;
                                            if (!action.MEEmrActionBorderOuterOnly)
                                            {
                                                cell.Borders.Right.LineStyle = (TableBorderLineStyle)Enum.Parse(typeof(TableBorderLineStyle), action.MEEmrActionBorderRightStyle, true);
                                                cell.Borders.Left.LineStyle = (TableBorderLineStyle)Enum.Parse(typeof(TableBorderLineStyle), action.MEEmrActionBorderLeftStyle, true);
                                                cell.Borders.Right.LineColor = Color.FromArgb(action.MEEmrActionBorderRightColor);
                                                cell.Borders.Left.LineColor = Color.FromArgb(action.MEEmrActionBorderLeftColor);
                                                cell.Borders.Right.LineThickness = (float)action.MEEmrActionBorderRightThickness;
                                                cell.Borders.Left.LineThickness = (float)action.MEEmrActionBorderLeftThickness;
                                            }
                                        }
                                    }
                                    if (action != null && action.MEEmrActionBorderOuterOnly)
                                    {
                                        var first = row.Cells.First();
                                        first.Borders.Left.LineStyle = (TableBorderLineStyle)Enum.Parse(typeof(TableBorderLineStyle), action.MEEmrActionBorderLeftStyle, true);
                                        first.Borders.Left.LineThickness = (float)action.MEEmrActionBorderLeftThickness;
                                        first.Borders.Left.LineColor = Color.FromArgb(action.MEEmrActionBorderLeftColor);
                                        var last = row.Cells.Last();
                                        last.Borders.Right.LineStyle = (TableBorderLineStyle)Enum.Parse(typeof(TableBorderLineStyle), action.MEEmrActionBorderRightStyle, true);
                                        last.Borders.Right.LineThickness = (float)action.MEEmrActionBorderRightThickness;
                                        last.Borders.Right.LineColor = Color.FromArgb(action.MEEmrActionBorderRightColor);
                                    }
                                    preRow = table.Rows[row.Index - 2];
                                }
                                if (maxRow != null && maxRow.Cells.Count() >= preRow.Cells.Count()) //Them dieu kien de tranh xay ra loi 2380
                                    preRow = maxRow;
                                using (var cloneRich = new RichEditDocumentServer())
                                {
                                    foreach (var cell in row.Cells)
                                    {
                                        cloneRich.CreateNewDocument(false);
                                        var cloneDoc = cloneRich.Document;
                                        var range = cloneDoc.InsertDocumentContent(cloneDoc.Range.Start, preRow.Cells[cell.Index].ContentRange, InsertOptions.KeepSourceFormatting);
                                        //change gid if must be change
                                        if (!actionGroup.Equals(group))
                                        {
                                            var links = cloneDoc.Hyperlinks;
                                            for (int i = 0; i < links.Count; i++)
                                            {
                                                var tags = links[i].NavigateUri.Split(TAGS);
                                                for (int t = 1; t < tags.Length; t++)
                                                {
                                                    if (tags[t].StartsWith(GTAG + "="))
                                                    {
                                                        tags[t] = GTAG + "=" + group;
                                                        break;
                                                    }
                                                }
                                                links[i].NavigateUri = string.Join(TAGS.ToString(), tags);
                                            }
                                        }
                                        var fields = cloneDoc.Fields.ToArray();
                                        for (int i = 0; i < fields.Length; i++)
                                        {
                                            var field = fields[i];
                                            if (!(field as DevExpress.XtraRichEdit.API.Native.Implementation.NativeField).IsValid) continue;
                                            var text = cloneDoc.GetText(field.CodeRange, _plainTextExportCfg);
                                            if (text.StartsWith("HYPERLINK", StringComparison.Ordinal)) continue;

                                            var emrField = CreateEmrFieldObj(field, text);
                                            var code = emrField.FieldCode;
                                            if (code.StartsWith(param.MEParamNo, StringComparison.Ordinal) || code.StartsWith(path, StringComparison.Ordinal))
                                            {
                                                fields[i].ShowCodes = true;
                                                var tokens = emrField.CodeLevelArr;
                                                if (tokens.Last() == EmrParam.MedicationGroup)
                                                {
                                                    RemoveShapesInTableColumn(cloneDoc, field);
                                                    UnmergeTableColumn(cloneDoc, field);
                                                }
                                                var leafParam = this.GetParamByNo(listEmrParams, tokens.Last());
                                                MEParamsInfo parentParam = null;
                                                int index = 0;
                                                if (tokens.Length > 2 && int.TryParse(tokens[tokens.Length - 1], out index))
                                                    parentParam = this.GetParamByNo(listEmrParams, tokens[tokens.Length - 3]);
                                                else if (tokens.Length >= 2)
                                                    parentParam = this.GetParamByNo(listEmrParams, tokens[tokens.Length - 2]);

                                                var conf = (parentParam != null && listParamRelations.ContainsKey(parentParam.MEParamID) && leafParam != null) ?
                                                    listParamRelations[parentParam.MEParamID].Where(r => r.FK_MEParamChildID == leafParam.MEParamID).FirstOrDefault()
                                                    : null;

                                                var posIndex = (string.IsNullOrEmpty(path) ? param.MEParamNo : path).Split(CODES).Length;
                                                if (tokens.Length > posIndex && int.TryParse(tokens[posIndex], out index))
                                                {
                                                    index++;
                                                    tokens[posIndex] = index.ToString();
                                                }
                                                var newCode = string.Join(CODES.ToString(), tokens);
                                                cloneDoc.Replace(fields[i].CodeRange, newCode + TAGS.ToString() + GTAG + "=" + newGroup);
                                                fields[i].ShowCodes = false;
                                                // insert field result default
                                                if (leafParam != null)
                                                {
                                                    var content = cloneDoc.GetText(fields[i].ResultRange, _plainTextExportCfg).Trim();
                                                    if (content.StartsWith(BTAG) && content.EndsWith($"{ETAG}{leafParam.MEParamUnit}"))
                                                    {
                                                        cloneDoc.Replace(fields[i].ResultRange, $"{BTAG}{(leafParam != null ? leafParam.MEParamValue : "")}{ETAG}{leafParam.MEParamUnit}");
                                                    }
                                                }
                                                if (conf != null && conf.MEParamRelationOnlyAddMe)
                                                    cloneDoc.Replace(fields[i].ResultRange, $"{BTAG}{(leafParam != null ? leafParam.MEParamValue : "")}{ETAG}{leafParam.MEParamUnit}");
                                            }
                                        }
                                        //du thua mot paragraph o cuoi
                                        var copyRange = cloneDoc.Range;
                                        if (cloneDoc.Paragraphs.Count == 1)
                                        {
                                            copyRange = cloneDoc.CreateRange(cloneDoc.Range.Start, cloneDoc.Length - 1);
                                        }
                                        else
                                        {
                                            var lastText = cloneDoc.GetText(cloneDoc.Paragraphs.Last().Range, _notAllowExtendingDocumentRange);
                                            if (string.IsNullOrEmpty(lastText))
                                                copyRange = cloneDoc.CreateRange(cloneDoc.Range.Start, cloneDoc.Length - cloneDoc.Paragraphs.Last().Range.Length);
                                        }
                                        cell.VerticalAlignment = preRow.Cells[cell.Index].VerticalAlignment;
                                        cell.Height = preRow.Cells[cell.Index].Height;
                                        range = doc.InsertDocumentContent(cell.ContentRange.Start, copyRange, InsertOptions.KeepSourceFormatting);
                                        var preParagraph = doc.Paragraphs.Get(preRow.Cells[cell.Index].ContentRange);
                                        if (preParagraph.Count > 0)
                                        {
                                            var pp = doc.BeginUpdateParagraphs(range);
                                            pp.Alignment = preParagraph.First().Alignment;
                                            doc.EndUpdateParagraphs(pp);
                                        }
                                    }
                                }

                                //remove all ky ten
                                var rangePermissions = doc.BeginUpdateRangePermissions();
                                for (int i = 0; i < rangePermissions.Count; i++)
                                {
                                    var rangePermis = rangePermissions[i];
                                    var range = rangePermis.Range;
                                    if (range.Start >= row.Range.Start && range.End <= row.Range.End)
                                    {
                                        rangePermissions.Remove(rangePermis);
                                        i--;
                                    }
                                }
                                doc.EndUpdateRangePermissions(rangePermissions);

                                //remote all comment
                                for (int i = 0; i < doc.Comments.Count; i++)
                                {
                                    var comment = doc.Comments[i];
                                    var range = comment.Range;
                                    if (range.Start >= row.Range.Start && range.End <= row.Range.End)
                                    {
                                        doc.Comments.Remove(comment);
                                        i--;
                                    }
                                }
                            }
                        }
                    }));
                }
                else
                {
                    doc.BeginUpdate();
                    //get update field from doc can have multi fields
                    var updateFields = this.GetBindingFields(actionGroup, string.IsNullOrEmpty(path) ? param.MEParamNo : path, string.Empty, false);
                    //change gid if must be change
                    var newGroup = actionGroup.Equals(group) ? actionGroup : group;
                    //fix vi trong mot so truong hop tim duoc 2 the giong nhau vi chuc nang thay the the bang template
                    var updateField = updateFields.FirstOrDefault();
                    if (updateField != null)
                    {
                        Table table = this.GetTableFromDocument(this._richEditCtrl, updateField);
                        if (table == null) return 0;
                        //do moi param dc check la footer se la mot dong trong table
                        //truong hop user tu them dong moi se co loi
                        int footerRowCount = this.GetFooterRowCount(param, listEmrParams, listParamRelations);
                        var row = table.Rows.InsertAfter(table.Rows.Count - footerRowCount - 1);

                        rowIdx = row.Index;
                        var maxRow = GetRowWithMaxIndex(table, string.IsNullOrEmpty(path) ? param.MEParamNo : path);
                        var preRow = table.Rows[row.Index - 1];
                        if (hiddenRow)
                        {
                            //them 1 dong moi dung de cho phep ky theo dong ko bi loi
                            var hidenRow = table.Rows.InsertAfter(table.Rows.Count - footerRowCount - 1);
                            foreach (var cell in hidenRow.Cells)
                            {
                                cell.Borders.Top.LineStyle = TableBorderLineStyle.None;
                                if (action != null)
                                {
                                    cell.Borders.Bottom.LineStyle = (TableBorderLineStyle)Enum.Parse(typeof(TableBorderLineStyle), action.MEEmrActionBorderBottomStyle, true);
                                    cell.Borders.Bottom.LineColor = Color.FromArgb(action.MEEmrActionBorderBottomColor);
                                    cell.Borders.Bottom.LineThickness = (float)action.MEEmrActionBorderBottomThickness;

                                    if (!action.MEEmrActionBorderOuterOnly)
                                    {
                                        cell.Borders.Right.LineStyle = (TableBorderLineStyle)Enum.Parse(typeof(TableBorderLineStyle), action.MEEmrActionBorderRightStyle, true);
                                        cell.Borders.Left.LineStyle = (TableBorderLineStyle)Enum.Parse(typeof(TableBorderLineStyle), action.MEEmrActionBorderLeftStyle, true);
                                        cell.Borders.Right.LineThickness = (float)action.MEEmrActionBorderRightThickness;
                                        cell.Borders.Left.LineThickness = (float)action.MEEmrActionBorderLeftThickness;
                                        cell.Borders.Right.LineColor = Color.FromArgb(action.MEEmrActionBorderRightColor);
                                        cell.Borders.Left.LineColor = Color.FromArgb(action.MEEmrActionBorderLeftColor);
                                    }
                                }
                            }
                            if (action != null && action.MEEmrActionBorderOuterOnly)
                            {
                                var first = hidenRow.Cells.First();
                                first.Borders.Left.LineStyle = (TableBorderLineStyle)Enum.Parse(typeof(TableBorderLineStyle), action.MEEmrActionBorderLeftStyle, true);
                                first.Borders.Left.LineThickness = (float)action.MEEmrActionBorderLeftThickness;
                                first.Borders.Left.LineColor = Color.FromArgb(action.MEEmrActionBorderLeftColor);
                                var last = hidenRow.Cells.Last();
                                last.Borders.Right.LineStyle = (TableBorderLineStyle)Enum.Parse(typeof(TableBorderLineStyle), action.MEEmrActionBorderRightStyle, true);
                                last.Borders.Right.LineThickness = (float)action.MEEmrActionBorderRightThickness;
                                last.Borders.Right.LineColor = Color.FromArgb(action.MEEmrActionBorderRightColor);
                            }

                            if (preRow != null && action != null)
                            {
                                foreach (var preCell in preRow.Cells)
                                {
                                    preCell.Borders.Bottom.LineStyle = (TableBorderLineStyle)Enum.Parse(typeof(TableBorderLineStyle), action.MEEmrActionBorderTopStyle, true);
                                    preCell.Borders.Bottom.LineColor = Color.FromArgb(action.MEEmrActionBorderTopColor);
                                    preCell.Borders.Bottom.LineThickness = (float)action.MEEmrActionBorderTopThickness;
                                }
                            }
                            foreach (var cell in row.Cells)
                            {
                                cell.Borders.Bottom.LineStyle = TableBorderLineStyle.None;
                                if (action != null)
                                {
                                    cell.Borders.Top.LineStyle = (TableBorderLineStyle)Enum.Parse(typeof(TableBorderLineStyle), action.MEEmrActionBorderTopStyle, true);
                                    cell.Borders.Top.LineColor = Color.FromArgb(action.MEEmrActionBorderTopColor);
                                    cell.Borders.Top.LineThickness = (float)action.MEEmrActionBorderTopThickness;
                                    if (!action.MEEmrActionBorderOuterOnly)
                                    {
                                        cell.Borders.Right.LineStyle = (TableBorderLineStyle)Enum.Parse(typeof(TableBorderLineStyle), action.MEEmrActionBorderRightStyle, true);
                                        cell.Borders.Left.LineStyle = (TableBorderLineStyle)Enum.Parse(typeof(TableBorderLineStyle), action.MEEmrActionBorderLeftStyle, true);
                                        cell.Borders.Right.LineColor = Color.FromArgb(action.MEEmrActionBorderRightColor);
                                        cell.Borders.Left.LineColor = Color.FromArgb(action.MEEmrActionBorderLeftColor);
                                        cell.Borders.Right.LineThickness = (float)action.MEEmrActionBorderRightThickness;
                                        cell.Borders.Left.LineThickness = (float)action.MEEmrActionBorderLeftThickness;
                                    }
                                }
                            }
                            if (action != null && action.MEEmrActionBorderOuterOnly)
                            {
                                var first = row.Cells.First();
                                first.Borders.Left.LineStyle = (TableBorderLineStyle)Enum.Parse(typeof(TableBorderLineStyle), action.MEEmrActionBorderLeftStyle, true);
                                first.Borders.Left.LineThickness = (float)action.MEEmrActionBorderLeftThickness;
                                first.Borders.Left.LineColor = Color.FromArgb(action.MEEmrActionBorderLeftColor);
                                var last = row.Cells.Last();
                                last.Borders.Right.LineStyle = (TableBorderLineStyle)Enum.Parse(typeof(TableBorderLineStyle), action.MEEmrActionBorderRightStyle, true);
                                last.Borders.Right.LineThickness = (float)action.MEEmrActionBorderRightThickness;
                                last.Borders.Right.LineColor = Color.FromArgb(action.MEEmrActionBorderRightColor);
                            }
                            preRow = table.Rows[row.Index - 2];
                        }
                        if (maxRow != null && maxRow.Cells.Count() >= preRow.Cells.Count()) //Them dieu kien de tranh xay ra loi 2380
                            preRow = maxRow;
                        using (var cloneRich = new RichEditDocumentServer())
                        {
                            foreach (var cell in row.Cells)
                            {
                                cloneRich.CreateNewDocument(false);
                                var cloneDoc = cloneRich.Document;
                                var range = cloneDoc.InsertDocumentContent(cloneDoc.Range.Start, preRow.Cells[cell.Index].ContentRange, InsertOptions.KeepSourceFormatting);
                                //change gid if must be change
                                if (!actionGroup.Equals(group))
                                {
                                    var links = cloneDoc.Hyperlinks;
                                    for (int i = 0; i < links.Count; i++)
                                    {
                                        var tags = links[i].NavigateUri.Split(TAGS);
                                        for (int t = 1; t < tags.Length; t++)
                                        {
                                            if (tags[t].StartsWith(GTAG + "="))
                                            {
                                                tags[t] = GTAG + "=" + group;
                                                break;
                                            }
                                        }
                                        links[i].NavigateUri = string.Join(TAGS.ToString(), tags);
                                    }
                                }
                                var fields = cloneDoc.Fields.ToArray();
                                for (int i = 0; i < fields.Length; i++)
                                {
                                    var field = fields[i];
                                    if (!(field as DevExpress.XtraRichEdit.API.Native.Implementation.NativeField).IsValid) continue;
                                    var text = cloneDoc.GetText(field.CodeRange, _plainTextExportCfg);
                                    if (text.StartsWith("HYPERLINK", StringComparison.Ordinal)) continue;

                                    var emrField = CreateEmrFieldObj(field, text);
                                    var code = emrField.FieldCode;
                                    if (code.StartsWith(param.MEParamNo, StringComparison.Ordinal) || code.StartsWith(path, StringComparison.Ordinal))
                                    {
                                        fields[i].ShowCodes = true;
                                        var tokens = emrField.CodeLevelArr;
                                        if (tokens.Last() == EmrParam.MedicationGroup)
                                        {
                                            RemoveShapesInTableColumn(cloneDoc, field);
                                            UnmergeTableColumn(cloneDoc, field);
                                        }
                                        var leafParam = this.GetParamByNo(listEmrParams, tokens.Last());
                                        MEParamsInfo parentParam = null;
                                        int index = 0;
                                        if (tokens.Length > 2 && int.TryParse(tokens[tokens.Length - 1], out index))
                                            parentParam = this.GetParamByNo(listEmrParams, tokens[tokens.Length - 3]);
                                        else if (tokens.Length >= 2)
                                            parentParam = this.GetParamByNo(listEmrParams, tokens[tokens.Length - 2]);

                                        var conf = (parentParam != null && listParamRelations.ContainsKey(parentParam.MEParamID) && leafParam != null) ?
                                            listParamRelations[parentParam.MEParamID].Where(r => r.FK_MEParamChildID == leafParam.MEParamID).FirstOrDefault()
                                            : null;

                                        var posIndex = (string.IsNullOrEmpty(path) ? param.MEParamNo : path).Split(CODES).Length;
                                        if (tokens.Length > posIndex && int.TryParse(tokens[posIndex], out index))
                                        {
                                            index++;
                                            tokens[posIndex] = index.ToString();
                                        }
                                        var newCode = string.Join(CODES.ToString(), tokens);
                                        cloneDoc.Replace(fields[i].CodeRange, newCode + TAGS.ToString() + GTAG + "=" + newGroup);
                                        fields[i].ShowCodes = false;
                                        // insert field result default
                                        if (leafParam != null)
                                        {
                                            var content = cloneDoc.GetText(fields[i].ResultRange, _plainTextExportCfg).Trim();
                                            if (content.StartsWith(BTAG) && content.EndsWith($"{ETAG}{leafParam.MEParamUnit}"))
                                            {
                                                cloneDoc.Replace(fields[i].ResultRange, $"{BTAG}{(leafParam != null ? leafParam.MEParamValue : "")}{ETAG}{leafParam.MEParamUnit}");
                                            }
                                        }
                                        if (conf != null && conf.MEParamRelationOnlyAddMe)
                                            cloneDoc.Replace(fields[i].ResultRange, $"{BTAG}{(leafParam != null ? leafParam.MEParamValue : "")}{ETAG}{leafParam.MEParamUnit}");
                                    }
                                }
                                //du thua mot paragraph o cuoi
                                var copyRange = cloneDoc.Range;
                                if (cloneDoc.Paragraphs.Count == 1)
                                {
                                    copyRange = cloneDoc.CreateRange(cloneDoc.Range.Start, cloneDoc.Length - 1);
                                }
                                else
                                {
                                    var lastText = cloneDoc.GetText(cloneDoc.Paragraphs.Last().Range, _notAllowExtendingDocumentRange);
                                    if (string.IsNullOrEmpty(lastText))
                                        copyRange = cloneDoc.CreateRange(cloneDoc.Range.Start, cloneDoc.Length - cloneDoc.Paragraphs.Last().Range.Length);
                                }
                                cell.VerticalAlignment = preRow.Cells[cell.Index].VerticalAlignment;
                                cell.Height = preRow.Cells[cell.Index].Height;
                                range = doc.InsertDocumentContent(cell.ContentRange.Start, copyRange, InsertOptions.KeepSourceFormatting);
                                var preParagraph = doc.Paragraphs.Get(preRow.Cells[cell.Index].ContentRange);
                                if (preParagraph.Count > 0)
                                {
                                    var pp = doc.BeginUpdateParagraphs(range);
                                    pp.Alignment = preParagraph.First().Alignment;
                                    doc.EndUpdateParagraphs(pp);
                                }
                            }
                        }

                        //remove all ky ten
                        var rangePermissions = doc.BeginUpdateRangePermissions();
                        for (int i = 0; i < rangePermissions.Count; i++)
                        {
                            var rangePermis = rangePermissions[i];
                            var range = rangePermis.Range;
                            if (range.Start >= row.Range.Start && range.End <= row.Range.End)
                            {
                                rangePermissions.Remove(rangePermis);
                                i--;
                            }
                        }
                        doc.EndUpdateRangePermissions(rangePermissions);
                        //remote all comment
                        for (int i = 0; i < doc.Comments.Count; i++)
                        {
                            var comment = doc.Comments[i];
                            var range = comment.Range;
                            if (range.Start >= row.Range.Start && range.End <= row.Range.End)
                            {
                                doc.Comments.Remove(comment);
                                i--;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("ADD TABLE ROW ERROR: {0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ex);
                throw;
            }
            finally
            {
                if (_richEditCtrl.InvokeRequired)
                {
                    _richEditCtrl.BeginInvoke((Action)(() =>
                    {
                        doc.EndUpdate();
                    }));
                }
                else
                {
                    doc.EndUpdate();
                }
            }
            return rowIdx;
        }
        private void BindingValueToField(Document doc, MEParamsInfo param, KeyValuePair<string, object> cel, string transaction, string group, HashSet<Field> exlFields, string formatStyle, bool paramUnit = true)
        {
            var updateFields = this.GetBindingFields(group, cel.Key, transaction, false, false, exlFields);
            foreach (var updateField in updateFields)
            {
                BindingValueToField(doc, param, updateField, cel.Value, cel.Key, formatStyle);
                exlFields.Add(updateField);
                FormatToQrBarcode(updateField, param);
            }
        }
        private void BindingValueToField(Document doc, MEParamsInfo param, Field f, object value, string fieldPath, string formatStyle, bool paramUnit = true)
        {
            if (param.MEParamFormatType == EmrParamFormatTypes.Rtf.ToString())
            {
                string textVal = value.ToString();
                if (textVal.StartsWith("{\\rtf1\\"))
                {
                    if (_richEditCtrl.InvokeRequired)
                    {
                        _richEditCtrl.BeginInvoke((Action)(() =>
                        {
                            doc.Replace(f.ResultRange, $"{BTAG}{ETAG}");
                            var position = doc.CreatePosition(f.ResultRange.Start.ToInt() + 1);
                            position = doc.InsertText(position, Environment.NewLine).End;
                            doc.InsertRtfText(position, textVal);
                        }));
                    }
                    else
                    {
                        doc.Replace(f.ResultRange, $"{BTAG}{ETAG}");
                        var position = doc.CreatePosition(f.ResultRange.Start.ToInt() + 1);
                        position = doc.InsertText(position, Environment.NewLine).End;
                        doc.InsertRtfText(position, textVal);
                    }
                    return;
                }
            }
            if (param.MEParamFormatType == EmrParamFormatTypes.Image.ToString()
                || param.MEParamFormatType == EmrParamFormatTypes.ImageRotate90.ToString())
            {
                InsertImageToParam(doc, param, f, value, fieldPath);
                return;
            }

            var newText = GetStringFromDataValue(param.MEParamFormatType, param.MEParamFormatString, value, fieldPath);
            ReplaceFieldText(doc, f, newText, paramUnit ? param.MEParamUnit : string.Empty);

            if (!string.IsNullOrEmpty(formatStyle))
            {
                var cp = doc.BeginUpdateCharacters(f.Range);
                cp.Reset(CharacterPropertiesMask.All);
                doc.EndUpdateCharacters(cp);

                var pStyle = doc.ParagraphStyles[formatStyle];
                if (pStyle != null)
                {
                    var pra = doc.BeginUpdateParagraphs(f.Range);
                    pra.Style = pStyle;
                    doc.EndUpdateParagraphs(pra);
                }
            }
        }
        #endregion

        private void ReplaceFieldText(Document doc, Field field, string text, string unit)
        {
            var oldText = doc.GetText(field.ResultRange);
            if (oldText != null && oldText.EndsWith("\t" + ETAG) && !text.EndsWith("\t"))
                text += "\t";
            if (_richEditCtrl.InvokeRequired)
            {
                _richEditCtrl.BeginInvoke((Action)(() =>
                {
                    doc.Replace(field.ResultRange, $"{BTAG}{text}{ETAG}{unit}");
                }));
            }
            else
            {
                doc.Replace(field.ResultRange, $"{BTAG}{text}{ETAG}{unit}");
            }
        }
        public int GetFooterRowCount(MEParamsInfo param, List<MEParamsInfo> listEmrParams, Dictionary<int, List<MEParamRelationsInfo>> listParamRelations)
        {
            if (param.MEParamID <= 0) return 0;
            int count = 0;
            var children = this.GetParamRelations(listParamRelations, param.MEParamID);
            foreach (var child in children)
            {
                if (child.MEParamRelationGroupFooter) count++;
                else
                {
                    var nextParam = this.GetParamByID(listEmrParams, child.FK_MEParamChildID);
                    if (nextParam != null)
                        count += GetFooterRowCount(nextParam, listEmrParams, listParamRelations);
                }
            }
            return count;
        }
        /// <summary>
        /// lay cac param co kha nang dung de ve chart
        /// uthv 03052019 khong dung chuc nang nay nua
        /// </summary>
        /// <returns></returns>
        public List<MEParamsInfo> GetAllParamsForChart()
        {
            var doc = this._richEditCtrl.Document;
            List<MEParamsInfo> listCacheParams = new List<MEParamsInfo>();
            List<MEParamsInfo> listParams = new List<MEParamsInfo>();
            var json = new object();
            var fieldCode = string.Empty;
            List<EmrField> listFields = new List<EmrField>();
            var listParamRelations = new Dictionary<int, List<MEParamRelationsInfo>>();
            foreach (var field in doc.Fields)
            {
                _fieldToCodeCache.TryGetValue(field, out EmrField emrField);
                if (emrField == null)
                {
                    fieldCode = doc.GetText(field.CodeRange);
                    emrField = AddCacheBindingField(field, fieldCode);
                }
                var tokens = emrField.Tokens;
                var codes = emrField.CodeLevelArr;
                var codeLevel = new List<string>();
                var nameLevel = new List<string>();
                int idx = 0;
                foreach (var code in codes)
                {
                    if (!int.TryParse(code, out idx))
                    {
                        var param = this.GetParamByNo(listCacheParams, code);
                        if (param != null)
                        {
                            codeLevel.Add(param.MEParamNo);
                            nameLevel.Add(param.MEParamCaption);
                        }
                    }
                }
                string path = string.Join(EmrParam.CodeSeparator.ToString(), codeLevel);
                if (!listParams.Exists(p => p.MEParamNo == path))
                    listParams.Add(new MEParamsInfo()
                    {
                        MEParamNo = path,
                        MEParamName = string.Join(" " + EmrParam.CodeSeparator.ToString() + " ", nameLevel),
                    });
            }

            return listParams;
        }
        public void RemoveAllHiddenDataForPrint(RichEditControl tempRichEditCtrl, int templateId)
        {
            RemoveAllHiddenDataForPrint(tempRichEditCtrl, templateId, _templateParams);
        }
        public void RemoveAllHiddenDataForPrint(RichEditControl tempRichEditCtrl, int templateId, List<METemplateParamsInfo> templateParams)
        {
            var doc = tempRichEditCtrl.Document;
            var hiddenParams = AppMemCache.GetHiddenParamsDictKeyNo();
            var hiddenPaths = new List<METemplateParamsInfo>();
            if (templateParams != null)
            {
                hiddenPaths = templateParams.Where(p => p.METemplateParamPrintHidden).ToList();
            }
            var fieldCode = string.Empty;
            doc.BeginUpdate();
            var totalField = doc.Fields.Count;
            for (int i = 0; i < totalField; i++)
            {
                var field = doc.Fields[i];

                fieldCode = doc.GetText(field.CodeRange);
                var tokens = fieldCode.Split(EmrParam.TagCodeSeparator);
                var path = System.Text.RegularExpressions.Regex.Replace(tokens[0], @"\-([\d]*)\-", "[*].").Replace('-', '.');
                var codes = path.Split('.');
                var paramNo = codes.Last();

                var parent = string.Empty;
                if (codes.Length > 1)
                    parent = codes[codes.Length - 2];

                if (hiddenParams.ContainsKey(paramNo))
                    doc.Replace(field.ResultRange, string.Empty);

                if (hiddenPaths.Any(o => o.METemplateParamPath == path))
                {
                    doc.Replace(field.ResultRange, string.Empty);
                    if (!string.IsNullOrEmpty(parent) && field.Parent != null)
                    {
                        Table table = GetTableFromDocument(tempRichEditCtrl, field.Parent);
                        var cell = GetTableCellByField(table, field);
                        if (cell != null)
                        {
                            var cellText = doc.GetText(cell.ContentRange).Trim();
                            if (string.IsNullOrEmpty(cellText))
                            {
                                var remainCell = cell.Row.Cells.Count - 1; //chi xoa 1 cot, trong truong hop cot bi merge se loi nen them remainCell
                                table.ForEachRow(new TableRowProcessorDelegate((r, k) => DeleteCells(r, k, cell.Index, remainCell)));
                            }
                        }
                    }
                }
                var countRemove = (totalField - doc.Fields.Count);
                if (countRemove > 0)
                    i = i - 1;
                totalField = doc.Fields.Count;
            }
            doc.EndUpdate();
        }
        //Declare a method that deletes the second cell in every table row
        public static void DeleteCells(TableRow row, int i, int j, int remainCell)
        {
            if (row.Cells.Count > remainCell)
                row.Cells[j].Delete();
        }
        private TableCell GetTableCellByField(Table table, Field field)
        {
            if (table != null)
            {
                foreach (var row in table.Rows)
                {
                    foreach (var cel in row.Cells)
                    {
                        if (cel.ContentRange.Start.ToInt() <= field.Range.Start.ToInt()
                            && cel.ContentRange.End.ToInt() >= field.Range.End.ToInt())
                        {
                            return cel;
                        }
                    }
                }
            }
            return null;
        }
        public void AddSymbol(string mEEmrSymbolFont, int mEEmrSymbolChar, string mEEmrSymbolStr)
        {
            var doc = this._richEditCtrl.Document;
            doc.BeginUpdate();
            if (mEEmrSymbolChar > 0)
            {
                var sym = string.Format(" SYMBOL {0} \\f \"{1}\" ", mEEmrSymbolChar, mEEmrSymbolFont);
                var rang = doc.InsertText(doc.CaretPosition, sym);
                var field = doc.Fields.Create(rang);
                field.ShowCodes = false;
                field.Update();
            }
            else
            {
                var range = doc.InsertText(doc.CaretPosition, mEEmrSymbolStr);
                CharacterProperties cp = doc.BeginUpdateCharacters(range);
                cp.FontName = mEEmrSymbolFont;
                doc.EndUpdateCharacters(cp);
            }
            doc.EndUpdate();
        }
        public Field GetFieldAtPosition(int pos)
        {
            var doc = this._richEditCtrl.Document;
            foreach (var field in doc.Fields)
            {
                if (field.ResultRange.Start.ToInt() <= pos && pos <= field.ResultRange.End.ToInt())
                {
                    return field;
                }
            }
            return null;
        }
        public DocumentRange AddParamsToTemplateAtCaretPosition(List<string> paramList, ref string group, ref string prefix, bool overrideOnlyParentParam = false)
        {
            var doc = this._richEditCtrl.Document;
            var field = GetFieldAtPosition(doc.CaretPosition.ToInt());
            var start = doc.CaretPosition.ToInt();
            var end = doc.CaretPosition;
            if (field != null)
            {
                start = field.ResultRange.Start.ToInt();
                end = field.ResultRange.End;
                doc.Replace(field.ResultRange, string.Empty);
                var text = doc.GetText(field.CodeRange);
                var tokens = text.Split(TAGS);
                var codes = tokens.First().Split(CODES);
                var gid = tokens.Where(t => t.StartsWith($"{GTAG}=")).FirstOrDefault();
                group = gid == null ? group : gid.Substring(GTAG.Length + 1);
                prefix = this.GetFieldPrefix(field) + CODES + codes.Last();
            }
            foreach (var item in paramList)
            {
                var param = AppMemCache.GetParamFromDictKeyNo(item);
                end = AddParamAtPosition(end, param, group, false, prefix, overrideOnlyParentParam);
                end = doc.InsertText(end, Environment.NewLine).End;
            }
            return doc.CreateRange(start, end.ToInt() - start);
        }
        public void BindingDataToRange(JObject data, DocumentRange range, string group, string prefix)
        {
            var fields = GetBindingFieldsInRange(range, group, string.Empty);
            if (fields.Count == 0) return;
            foreach (var p in data)
            {
                var value = data.GetValue(p.Key);
                var field = fields.Where(f => f.ParamNo == p.Key).FirstOrDefault();
                if (field != null)
                {
                    var param = AppMemCache.GetParamFromDictKeyNo(field.ParamNo);
                    var childStyle = data.GetValue(p.Key + EmrConsts.FORMAT_STYLE_PREFIX)?.ToString();
                    BindingDataToFieldV2(param, field.Field, value, prefix, string.Empty, group, null, childStyle);
                }
            }
        }
        public void BindingDataToRanges(JObject data, SelectionCollection ranges, string group, string prefix)
        {
            if (ranges.Count == 0) return;
            List<EmrField> fields = new List<EmrField>();
            //chon tat ca dong cua 1 table
            var doc = _richEditCtrl.Document;
            var cell = doc.Tables.GetTableCell(ranges.First().Start);
            Table table = null;
            if (cell != null && cell.Table.Range.End == ranges.First().End)
            {
                table = cell.Table;
            }
            else if (ranges.Count > 1)
            {
                cell = doc.Tables.GetTableCell(ranges.Last().Start);
                if (cell != null && cell.Table.Range.End == ranges.Last().End)
                {
                    table = cell.Table;
                }
            }
            if (table != null)
            {
                var tbWraper = doc.CreateRange(doc.CreatePosition(table.Range.Start.ToInt() - 1), table.Range.Length + 1);
                fields.AddRange(GetBindingFieldsInRange(tbWraper, group, string.Empty));
            }

            if (fields.Count == 0)
            {
                foreach (var range in ranges)
                {
                    fields.AddRange(GetBindingFieldsInRange(range, group, string.Empty));
                }
            }
            if (fields.Count == 0) return;
            List<EmrField> notRoots = new List<EmrField>();
            foreach (var field in fields)
            {
                if (fields.Any(f => field.CodeLevelStr.StartsWith(f.CodeLevelStr + CODES)))
                    notRoots.Add(field);
            }
            fields = fields.Except(notRoots).ToList();
            foreach (var field in fields)
            {
                if (field.CodeLevelStr.StartsWith("HYPERLINK")) continue;
                if (!IsAllowEditField(field.Field)) continue;
                var path = "$." + string.Join(".", field.CodeLevelArr.Select(r => !int.TryParse(r, out int n) ? r : "[*]"));
                var values = data.SelectTokens(path);
                if (values == null) continue;
                int count = values.Count();
                if (count > 0)
                {
                    var value = values.First();
                    if (count > 1)
                    {
                        if (int.TryParse(field.CodeLevelArr[field.CodeLevelArr.Length - 2], out int idx))
                        {
                            if (idx < count)
                                value = values.ElementAt(idx);
                        }
                    }
                    var param = AppMemCache.GetParamFromDictKeyNo(field.ParamNo) as MEParamsInfo;
                    var childStyle = data.SelectToken(path + EmrConsts.FORMAT_STYLE_PREFIX)?.ToString();
                    prefix = field.CodeLevelStr == field.ParamNo ? string.Empty : field.CodeLevelStr.Replace(CODES + field.ParamNo, string.Empty);
                    BindingDataToFieldV2(param, field.Field, value, prefix, string.Empty, field.Gid, null, childStyle);
                }
            }
        }
        public void BindingListDataToDoc(string group, Dictionary<string, JToken> data, List<MEParamsInfo> listEmrParams, HashSet<Field> exlFields)
        {
            foreach (var item in data)
            {
                var field = GetFirstFieldByPath(item.Key, group);
                if (field != null)
                {
                    var param = GetParamByNo(listEmrParams, item.Key.Split(CODES).Last());
                    BindingDataToFieldV2(param, field, item.Value, item.Key.Substring(0, item.Key.Length - param.MEParamNo.Length - 1), string.Empty, group, null, string.Empty, exlFields);
                }
            }
        }
        public Field GetFirstFieldByPath(string key, string group)
        {
            var doc = this._richEditCtrl.Document;

            foreach (var field in doc.Fields)
            {
                _fieldToCodeCache.TryGetValue(field, out EmrField emrField);
                if (emrField == null)
                {
                    var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                    emrField = AddCacheBindingField(field, text);
                }
                var codes = emrField.Tokens;
                if (codes[0] == key)
                {
                    if (group.Equals(emrField.Gid))
                    {
                        return field;
                    }
                }
            }
            return null;
        }
        private Field GetFirstFieldByPrefixAndGroup(string prefix, string group)
        {
            var doc = this._richEditCtrl.Document;

            foreach (var field in doc.Fields)
            {
                _fieldToCodeCache.TryGetValue(field, out EmrField emrField);
                if (emrField == null)
                {
                    var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                    emrField = AddCacheBindingField(field, text);
                }
                var codes = emrField.Tokens;
                if (codes[0].StartsWith(prefix + CODES))
                {
                    if (group.Equals(emrField.Gid))
                    {
                        return field;
                    }
                }
            }
            return null;
        }
        public EmrField GetFirstEmrFieldByPrefix(string prefix)
        {
            var doc = this._richEditCtrl.Document;

            foreach (var field in doc.Fields)
            {
                _fieldToCodeCache.TryGetValue(field, out EmrField emrField);
                if (emrField == null)
                {
                    var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                    emrField = AddCacheBindingField(field, text);
                }
                var tokens = emrField.Tokens;// text.Split(TAGS);
                if (tokens[0].StartsWith(prefix + CODES))
                {
                    return new EmrField()
                    {
                        Tokens = tokens,
                        Gid = emrField.Gid,
                        Field = field,
                        FieldCode = emrField.FieldCode,
                        CodeLevelStr = tokens[0],
                        CodeLevelArr = emrField.CodeLevelArr,
                        ParamNo = emrField.CodeLevelArr.Last()

                    };
                }
            }
            return null;
        }
        public EmrField GetFirstEmrFieldByCode(string code)
        {
            var doc = this._richEditCtrl.Document;

            foreach (var field in doc.Fields)
            {
                _fieldToCodeCache.TryGetValue(field, out EmrField emrField);
                if (emrField == null)
                {
                    var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                    emrField = AddCacheBindingField(field, text);
                }
                var tokens = emrField.Tokens;// text.Split(TAGS);
                if (tokens[0] == (code))
                {
                    var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                    return new EmrField()
                    {
                        Tokens = text.Split(TAGS),
                        Gid = emrField.Gid,
                        Field = field,
                        FieldCode = emrField.FieldCode,
                        CodeLevelStr = tokens[0],
                        CodeLevelArr = emrField.CodeLevelArr,
                        ParamNo = emrField.CodeLevelArr.Last()

                    };
                }
            }
            return null;
        }
        public void DoubleStrikeThroughAllParam()
        {
            var doc = this._richEditCtrl.Document;
            doc.BeginUpdate();
            foreach (var range in doc.Selections)
            {
                var fields = GetBindingFieldsInRange(range, string.Empty, string.Empty);
                foreach (var item in fields)
                {
                    CharacterProperties strike = doc.BeginUpdateCharacters(item.Field.ResultRange);
                    strike.Strikeout = StrikeoutType.Double;
                    doc.EndUpdateCharacters(strike);
                }
            }
            doc.EndUpdate();
        }
        public void InsertCircleToRound()
        {
            var doc = this._richEditCtrl.Document;
            doc.BeginUpdate();
            var img = System.Drawing.Image.FromFile(@"img\symbols\ngung_su_dung_thuoc.png");
            foreach (var range in doc.Selections)
            {
                var fields = GetBindingFieldsInRange(range, string.Empty, string.Empty);
                foreach (var item in fields)
                {
                    var pic = doc.Shapes.InsertPicture(item.Field.ResultRange.Start, img);
                    pic.RelativeHorizontalPosition = ShapeRelativeHorizontalPosition.Character;
                    pic.RelativeVerticalPosition = ShapeRelativeVerticalPosition.Line;
                }
            }
            doc.EndUpdate();
        }
        #region Group Thuoc
        public void GroupingList(JArray data, string groupCol, int formatType, string prefix, MEParamsInfo param, string gid)
        {
            var doc = this._richEditCtrl.Document;
            if (data.All(o => string.IsNullOrEmpty(o[groupCol].ToString())))
            {
                RemoveShapeAndUnmergeGroupCol(data, groupCol, formatType, prefix, param, gid);
                return;
            }

            var tbField = GetFirstFieldByPath(string.IsNullOrEmpty(prefix) ? param.MEParamNo : prefix, gid);
            if (tbField != null)
            {
                Table tb = this.GetTableFromDocument(this._richEditCtrl, tbField);
                if (tb != null)
                {
                    var colWidth = 0f;
                    var colIdx = 0;
                    var firstCode = string.Empty;
                    if (string.IsNullOrEmpty(prefix))
                        firstCode = param.MEParamNo + CODES;
                    else if (prefix.EndsWith(CODES + param.MEParamNo))
                        firstCode = prefix + CODES;
                    else
                        firstCode = prefix + CODES + param.MEParamNo + CODES;

                    for (int i = 0; i < data.Count; i++)
                    {
                        var groupCode = firstCode + i + CODES + groupCol;
                        var groupField = GetFirstFieldByPath(groupCode, gid);
                        if (groupField != null)
                        {
                            var cell = _richEditCtrl.Document.Tables.GetTableCell(groupField.ResultRange.Start);
                            colWidth = cell.PreferredWidth;
                            colIdx = cell.Index;
                            RemoveTableColumn(doc, groupField);
                            break;
                        }
                    }

                    firstCode += "0";
                    var field = GetFirstFieldByPrefixAndGroup(firstCode, gid);
                    var firstRow = -1;
                    foreach (var row in tb.Rows)
                    {
                        if (row.Range.Start <= field.Range.Start && row.Range.End >= field.Range.End)
                        {
                            firstRow = row.Index;
                            break;
                        }
                    }
                    //tim thay row
                    if (firstRow >= 0)
                    {
                        //luon luon them cot moi
                        tb.Rows[0].Cells.InsertBefore(colIdx);
                        var groupValue = data[0][groupCol].ToString();
                        var mergeCells = new List<TableCell>();
                        var listGroup = new List<List<TableCell>>();
                        var listGroupValue = new List<string>();
                        for (int i = firstRow; i < tb.Rows.Count; i++)
                        {
                            if (i - firstRow >= data.Count) break;
                            JToken item = data[i - firstRow];
                            var row = tb.Rows[i];
                            if (item[groupCol].ToString() != string.Empty)
                            {
                                var groupCell = row.Cells[colIdx];
                                if (groupValue != item[groupCol].ToString())
                                {
                                    if (mergeCells.Count > 0)
                                    {
                                        listGroup.Add(mergeCells);
                                        listGroupValue.Add(groupValue);
                                    }
                                    mergeCells = new List<TableCell>();
                                    mergeCells.Add(groupCell);
                                    groupValue = item[groupCol].ToString();
                                }
                                else
                                {
                                    mergeCells.Add(groupCell);
                                }
                                var code = string.Empty;

                                if (string.IsNullOrEmpty(prefix))
                                    code = $"{param.MEParamNo}{CODES}{groupCell.Row.Index - firstRow}{CODES}{groupCol}{TAGS}{GTAG}={gid}";
                                else if (prefix.EndsWith(CODES + param.MEParamNo))
                                    code = $"{prefix}{CODES}{groupCell.Row.Index - firstRow}{CODES}{groupCol}{TAGS}{GTAG}={gid}";
                                else
                                    code = $"{prefix}{CODES}{param.MEParamNo}{CODES}{groupCell.Row.Index - firstRow}{CODES}{groupCol}{TAGS}{GTAG}={gid}";

                                var f = doc.Fields.Create(groupCell.ContentRange.Start, code);
                                // insert field result default
                                doc.InsertText(f.ResultRange.Start, $"{BTAG}{groupValue}{ETAG}");
                                f.ShowCodes = false;
                                //CharacterProperties cp = doc.BeginUpdateCharacters(f.ResultRange);
                                //cp.Hidden = true;
                                //doc.EndUpdateCharacters(cp);
                            }
                        }
                        if (mergeCells.Count > 0)
                        {
                            listGroup.Add(mergeCells);
                            listGroupValue.Add(groupValue);
                        }
                        for (int i = 0; i < listGroup.Count; i++)
                        {
                            var item = listGroup[i];
                            var cell = item.First();
                            tb.MergeCells(cell, item.Last());
                            var cp = doc.BeginUpdateCharacters(cell.ContentRange);
                            cp.Hidden = true;
                            doc.EndUpdateCharacters(cp);

                            var height = item.Sum(c => c.Height);
                            //  var height = CalRowHeight(tb.Rows[cell.Row.Index])* item.Count;// * item.Count; // (pic.Size.Width / img.Width)
                            if (formatType == 0)
                            {
                                //neu chi co 1 dong thi ko chen ngoac kep
                                if (item.Count == 1) continue;
                                var img = Image.FromFile(@"img\symbols\ngoac_kep.png");
                                var pic = doc.Shapes.InsertPicture(cell.ContentRange.Start, img);
                                //var pic = doc.Images.Insert(cell.ContentRange.Start, img);
                                pic.TextWrapping = TextWrappingType.InFrontOfText;
                                pic.HorizontalAlignment = ShapeHorizontalAlignment.None;
                                pic.RelativeHorizontalPosition = ShapeRelativeHorizontalPosition.Character;
                                pic.VerticalAlignment = ShapeVerticalAlignment.None;
                                pic.RelativeVerticalPosition = ShapeRelativeVerticalPosition.Line;
                                pic.Offset = new PointF(0, 0);
                                if (height == 0) height = (int)pic.Size.Height;
                                pic.Size = new SizeF(pic.Size.Width, height);
                                height -= (int)(cell.TopPadding + cell.BottomPadding);
                                pic.ScaleY = height / pic.OriginalSize.Height;
                                //pic.ScaleX = pic.ScaleY;

                                if (colWidth == 0f) colWidth = pic.Size.Width + cell.RightPadding + cell.LeftPadding;
                            }
                            else
                            {
                                cell.VerticalAlignment = TableCellVerticalAlignment.Center;
                                var code = string.Empty;
                                if (string.IsNullOrEmpty(prefix))
                                    code = $"{param.MEParamNo}{CODES}{cell.Row.Index - firstRow}{CODES}{groupCol}";
                                else if (prefix.EndsWith(CODES + param.MEParamNo))
                                    code = $"{prefix}{CODES}{cell.Row.Index - firstRow}{CODES}{groupCol}";
                                else
                                    code = $"{prefix}{CODES}{param.MEParamNo}{CODES}{cell.Row.Index - firstRow}{CODES}{groupCol}";

                                var f = GetFirstFieldByPath(code, gid);
                                cp = doc.BeginUpdateCharacters(f.ResultRange);
                                cp.Hidden = false;
                                doc.EndUpdateCharacters(cp);
                                if (colWidth == 0f) colWidth = CalRangeWidth(f.ResultRange) + cell.RightPadding + cell.LeftPadding;
                            }
                            doc.ReplaceAll(Environment.NewLine, string.Empty, SearchOptions.None, cell.ContentRange);
                        }
                        foreach (var row in tb.Rows)
                        {
                            row.Cells[colIdx].PreferredWidthType = WidthType.Fixed;
                            row.Cells[colIdx].PreferredWidth = colWidth;
                        }
                    }
                }
            }
        }
        private void RemoveShapeAndUnmergeGroupCol(JArray data, string groupCol, int formatType, string prefix, MEParamsInfo param, string gid)
        {
            var doc = this._richEditCtrl.Document;
            var tbField1 = GetFirstFieldByPath(string.IsNullOrEmpty(prefix) ? param.MEParamNo : prefix, gid);
            if (tbField1 != null)
            {
                Table tb = this.GetTableFromDocument(this._richEditCtrl, tbField1);
                if (tb != null)
                {
                    var firstCode = string.Empty;
                    if (string.IsNullOrEmpty(prefix))
                        firstCode = param.MEParamNo + CODES;
                    else if (prefix.EndsWith(CODES + param.MEParamNo))
                        firstCode = prefix + CODES;
                    else
                        firstCode = prefix + CODES + param.MEParamNo + CODES;

                    for (int i = 0; i < data.Count; i++)
                    {
                        var groupCode = firstCode + i + CODES + groupCol;
                        var groupField = GetFirstFieldByPath(groupCode, gid);
                        if (groupField != null)
                        {
                            var cell = _richEditCtrl.Document.Tables.GetTableCell(groupField.ResultRange.Start);
                            RemoveShapesInTableColumn(doc, groupField);
                            UnmergeTableColumn(doc, groupField);
                            break;
                        }
                    }
                }
            }
        }

        private int CalRowHeight(DocumentLayout documentLayout, TableRow r)
        {
            if (r.Range.Length == 0) return 0;
            LayoutIterator iterator = new LayoutIterator(documentLayout, r.Range);
            int height = 0;
            iterator.Reset(InitialState.Start);
            while (iterator.MoveNext(LayoutLevel.Row))
                height += iterator.Current.Bounds.Height;

            return height;
        }
        private int CalRangeWidth(DocumentRange range)
        {
            if (range.Length == 0) return 0;
            LayoutIterator iterator = new LayoutIterator(this._richEditCtrl.DocumentLayout, range);
            int w = 0;
            while (iterator.MoveNext(LayoutLevel.Row))
                w += iterator.Current.Bounds.Width;
            return w;
        }
        #endregion
        private T GetFieldValue<T>(MEParamsInfo param, string fpath, string group)
        {
            if (param == null) return default(T);
            var doc = this._richEditCtrl.Document;
            var f = this.GetFirstFieldByPath(fpath, group);
            if (f == null) return default(T);
            var textValue = doc.GetText(f.ResultRange);
            if (!string.IsNullOrEmpty(param.MEParamUnit) && textValue.EndsWith(param.MEParamUnit))
                textValue = textValue.Substring(0, textValue.Length - param.MEParamUnit.Length);
            textValue = textValue.TrimEnd(EmrParam.EndTag.ToCharArray()).TrimStart(EmrParam.BeginTag.ToCharArray());
            textValue = textValue.Trim();
            var value = _dataHelper.ConvertDataType(param.MEParamFormatType, param.MEParamFormatString, textValue);
            try
            {
                return (T)value;
            }
            catch
            {
                return default(T);
            }
        }
        /// <summary>
        /// chỉ moi tinh BMI cho TWCT
        /// </summary>
        /// <param name="group"></param>
        public void CalculateParamValueBeforeSave(string group)
        {
            var bmiF = GetFirstFieldByPath("BMI", group);
            var bmiP = AppMemCache.GetParamFromDictKeyNo("BMI");
            if (bmiF == null) return;
            var doc = this._richEditCtrl.Document;

            var hObj = GetFieldValue<decimal?>(AppMemCache.GetParamFromDictKeyNo("ChieuCao"), "ChieuCao", group);
            var wObj = GetFieldValue<decimal?>(AppMemCache.GetParamFromDictKeyNo("CanNang"), "CanNang", group);
            if (!wObj.HasValue || !hObj.HasValue || hObj.Value == 0)
            {
                BindingValueToField(doc, bmiP, bmiF, string.Empty, "BMI", string.Empty);
                return;
            };
            var h = (decimal)hObj;
            var w = (decimal)wObj;
            var bmi = Math.Round(w / (h * h), 2);
            BindingValueToField(doc, bmiP, bmiF, bmi, "BMI", string.Empty);
        }

        public void InsertImageToParam(MEParamsInfo param, MEEmrActionsInfo action, string group, List<string> paths)
        {
            var fields = GetBindingFields(group, param.MEParamNo, string.Empty, false, true);
            if (fields.Count == 0) return;
            var field = fields.First();
            var doc = this._richEditCtrl.Document;
            var fieldPath = GetTemplateFieldPath(GetFieldTokens(doc, field)[0]);

            if (_richEditCtrl.InvokeRequired)
            {
                _richEditCtrl.BeginInvoke((Action)(() =>
                {
                    doc.BeginUpdate();
                }));
            }
            else
            {
                doc.BeginUpdate();
            }
            InsertImageToParam(doc, param, field, paths, fieldPath);
            if (_richEditCtrl.InvokeRequired)
            {
                _richEditCtrl.BeginInvoke((Action)(() =>
                {
                    doc.EndUpdate();
                }));
            }
            else
            {
                doc.EndUpdate();
            }
        }
        private void InsertImageToParam(Document doc, MEParamsInfo param, Field field, object value, string fieldPath)
        {
            var paths = new List<string>();
            if (value is JArray)
                foreach (var path in (value as JArray))
                    paths.Add(path.ToString());
            else
                paths.Add(value.ToString());

            InsertImageToParam(doc, param, field, paths, fieldPath);
        }
        private void InsertImageToParam(Document doc, MEParamsInfo param, Field field, List<string> paths, string fieldPath)
        {
            var width = param.MEParamImageWidth;
            var height = param.MEParamImageHeight;
            _templateParamDictPath.TryGetValue(fieldPath, out METemplateParamsInfo templateParam);
            var type = param.MEParamFormatType;
            if (templateParam != null)
            {
                if (templateParam.MEParamImageWidth > 0 || templateParam.MEParamImageHeight > 0)
                {
                    width = templateParam.MEParamImageWidth;
                    height = templateParam.MEParamImageHeight;
                }
                if (!string.IsNullOrEmpty(templateParam.MEParamFormatType))
                    type = templateParam.MEParamFormatType;
            }

            if (_richEditCtrl.InvokeRequired)
            {
                _richEditCtrl.BeginInvoke((Action)(() =>
                {
                    doc.Replace(field.ResultRange, BTAG + ETAG);
                }));
            }
            else
            {
                doc.Replace(field.ResultRange, BTAG + ETAG);
            }
            foreach (var path in paths)
            {
                var pos = doc.CreatePosition(field.ResultRange.End.ToInt() - 1);
                if (path.StartsWith("http://") || path.StartsWith("https://"))
                {
                    try
                    {
                        using (var client = new System.Net.Http.HttpClient())
                        {
                            client.Timeout = TimeSpan.FromSeconds(30);
                            var stream = client.GetStreamAsync(path).Result;
                            var image = Image.FromStream(stream);
                            if (type == EmrParamFormatTypes.ImageRotate90.ToString())
                                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            InsertImageToDocument(image, pos, width, height, false);
                        }
                    }
                    catch (Exception)
                    {
                        if (_richEditCtrl.InvokeRequired)
                        {
                            _richEditCtrl.BeginInvoke((Action)(() =>
                            {
                                doc.InsertText(pos, "Không tìm thấy file: " + path);
                            }));
                        }
                        else
                        {
                            doc.InsertText(pos, "Không tìm thấy file: " + path);
                        }
                    }
                }
                else
                {
                    var localPath = path;
                    if (!File.Exists(localPath))
                    {
                        //TODO support
                        //localPath = System.Web.Hosting.HostingEnvironment.MapPath(path);
                    }

                    if (File.Exists(localPath))
                    {
                        var image = Image.FromFile(localPath);
                        if (type == EmrParamFormatTypes.ImageRotate90.ToString())
                            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        InsertImageToDocument(image, pos, width, height, false);
                    }
                    else
                    {
                        if (_richEditCtrl.InvokeRequired)
                        {
                            _richEditCtrl.BeginInvoke((Action)(() =>
                            {
                                doc.InsertText(pos, "Không tìm thấy file: " + path);
                            }));
                        }
                        else
                        {
                            doc.InsertText(pos, "Không tìm thấy file: " + path);
                        }
                    }
                }
            }
        }
        public void ShowParamCode(Document document)
        {
            var fields = document.Fields.OrderBy(f => f.CodeRange.Length).ToList();
            foreach (var field in fields)
            {
                if (field.Parent != null)
                    field.Parent.ShowCodes = false;
                field.ShowCodes = true;
            }
        }
        public Task<int> GenCacheBindingFields(MemoryStream inStream)
        {
            var doc = this._richEditCtrl.Document;
            var fields = doc.Fields.ToArray();
            var stream = new MemoryStream();
            inStream.Position = 0;
            inStream.CopyTo(stream);
            var taskCode = Task.Factory.StartNew<int>(() =>
            {
                using (var rich = new RichEditDocumentServer())
                {
                    stream.Position = 0;
                    rich.LoadDocument(stream, DocumentFormat.OpenXml);
                    foreach (var field in fields)
                    {
                        try
                        {
                            if (field.CodeRange.Length < 5)
                            {
                                continue;
                            }
                            var text = rich.Document.GetText(rich.Document.CreateRange(field.CodeRange.Start.ToInt(), field.CodeRange.Length), _plainTextExportCfg);
                            var emrField = AddCacheBindingField(field, text);
                            TrackDisabledField(emrField, field);
                        }
                        catch (Exception)
                        {
                            throw;
                            /*do nothing*/
                        }
                    }
                }
                stream.Close();
                stream.Dispose();
                return doc.Fields.Count;
            });
            return taskCode;
            //var doc = this._richEditCtrl.Document;
            //foreach (var field in doc.Fields)
            //{
            //    if (field.CodeRange.Length < 5)
            //    {
            //        continue;
            //    }
            //    var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
            //    var emrField = AddCacheBindingField(field, text);
            //    TrackDisabledField(emrField, field);
            //}
        }
        private EmrField CreateEmrFieldObj(Field field, string text)
        {
            var tokens = text?.Split(TAGS);
            var emrField = new EmrField { Tokens = tokens };
            //if (emrField.Tokens.Length < 2)
            //{
            //    var doc = this._richEditCtrl.Document;
            //    var length = field.ResultRange.Start.ToInt() + 200 > doc.Length ? doc.Length - field.ResultRange.Start.ToInt() : 200;
            //    var preText = doc.GetText(doc.CreateRange(doc.CreatePosition(field.ResultRange.Start.ToInt() - 100), length));
            //    MessageBox.Show($"Tờ bệnh án chứa thẻ dữ liệu lỗi, thẻ lỗi ở vị trí trước đoạn sau: \n \"{field.ResultRange.Start}<Thẻ lỗi>{field.ResultRange.End} {preText}\"", "Có lỗi trên tờ bệnh án.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            emrField.FieldCode = emrField.Tokens[0] + TAGS + emrField.Tokens[1];
            emrField.CodeLevelArr = emrField.Tokens[0].Split(EmrParam.CodeSeparator);
            emrField.Gid = emrField.Tokens[1];
            emrField.Gid = string.IsNullOrEmpty(emrField.Gid) ? string.Empty : emrField.Gid.Substring(GTAG.Length + 1);

            return emrField;
        }
        private EmrField AddCacheBindingField(Field field, string text)
        {
            var emrField = CreateEmrFieldObj(field, text);
            if (!_codeToFieldCache.ContainsKey(emrField.FieldCode))
            {
                _codeToFieldCache.TryAdd(emrField.FieldCode, field);
                _fieldToCodeCache.TryAdd(field, emrField);
            }
            else
            {
                _codeToFieldCache[emrField.FieldCode] = field;
                _fieldToCodeCache[field] = emrField;
            }
            return emrField;
        }
        public void ClearCacheBindingFields()
        {
            _disabledFields.Clear();
            _fieldToCodeCache.Clear();
            _codeToFieldCache.Clear();
        }
        public EmrField GetAndAddCacheBindingField(Document doc, Field field)
        {
            _fieldToCodeCache.TryGetValue(field, out EmrField emrField);
            if (emrField == null)
            {
                var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                emrField = AddCacheBindingField(field, text);
            }
            return emrField;
        }
        public void CheckRadioOrCheckbox(MEParamsInfo param, MEParamsInfo parent, EmrField field)
        {
            if (param == null) return;
            var doc = this._richEditCtrl.Document;
            var prefix = field.CodeLevelStr.Replace($"{parent.MEParamNo}{CODES}{param.MEParamNo}", string.Empty);
            if (_hospitalProject == "ChamCuu" && _disabledTemplateParams != null && _disabledTemplateParams.Count > 0)
            {
                if (_disabledTemplateParams.Where(p => p.FK_MEParamID == parent.MEParamID).ToList().Count() > 0)
                    return;
            }
            if (parent.MEParamControlType == EmrParamControlTypes.Radio.ToString())
            {
                var textValue = doc.GetText(field.Field.ResultRange);
                if (textValue.EndsWith(param.MEParamUnit))
                    textValue = textValue.Substring(0, textValue.Length - param.MEParamUnit.Length);
                textValue = textValue.TrimEnd(EmrParam.EndTag.ToCharArray()).TrimStart(EmrParam.BeginTag.ToCharArray());
                textValue = textValue.Trim();

                var childrens = AppMemCache.GetParamRelationsFromDict(parent.MEParamID).OrderBy(p => p.MEParamRelationOrder).ToList();
                foreach (var c in childrens)
                {
                    var childParam = AppMemCache.GetParamFromDictKeyID(c.FK_MEParamChildID);
                    //child param will be have code = parentCode_childCode
                    var updateFields = this.GetBindingFields(field.Gid, $"{prefix}{parent.MEParamNo}{CODES}{childParam.MEParamNo}", string.Empty, false, false);
                    if (updateFields.Count == 0) continue;
                    doc.Replace(updateFields[0].ResultRange, $"{BTAG} {ETAG}{childParam.MEParamUnit}");
                }
                if (textValue.ToUpper() == parent.MEParamValue.ToUpper()) //da check thi uncheck
                    doc.Replace(field.Field.ResultRange, $"{BTAG} {ETAG}{parent.MEParamUnit}");
                else
                    doc.Replace(field.Field.ResultRange, $"{BTAG}{parent.MEParamValue}{ETAG}{parent.MEParamUnit}");
            }
            else if (parent.MEParamControlType == EmrParamControlTypes.Checkbox.ToString())
            {
                var textValue = doc.GetText(field.Field.ResultRange);
                if (textValue.EndsWith(param.MEParamUnit))
                    textValue = textValue.Substring(0, textValue.Length - param.MEParamUnit.Length);
                textValue = textValue.TrimEnd(EmrParam.EndTag.ToCharArray()).TrimStart(EmrParam.BeginTag.ToCharArray());
                textValue = textValue.Trim();
                if (textValue.ToUpper() == parent.MEParamValue.ToUpper()) //da check thi uncheck
                    doc.Replace(field.Field.ResultRange, $"{BTAG} {ETAG}{parent.MEParamUnit}");
                else
                    doc.Replace(field.Field.ResultRange, $"{BTAG}{parent.MEParamValue}{ETAG}{parent.MEParamUnit}");

            }
        }
        private void RemoveTableColumn(Document doc, Field field)
        {
            var cell = doc.Tables.GetTableCell(field.ResultRange.Start);
            if (cell != null)
            {
                var tb = cell.Table;
                var cellIdx = cell.Index;
                var remainCell = cell.Row.Cells.Count - 1;
                tb.ForEachRow(new TableRowProcessorDelegate((r, k) => DeleteCells(r, k, cellIdx, remainCell)));
            }
        }

        private void RemoveShapesInTableColumn(Document doc, Field field)
        {
            var cell = doc.Tables.GetTableCell(field.ResultRange.Start);
            if (cell != null)
            {
                var tb = cell.Table;
                var cellIdx = cell.Index;
                tb.ForEachRow(new TableRowProcessorDelegate((r, k) => RemoveShapesInRange(doc, r.Cells[cellIdx].ContentRange)));
            }
        }
        private void RemoveShapesInRange(Document doc, DocumentRange range)
        {
            var shapes = doc.Shapes;
            for (int i = 0; i < shapes.Count; i++)
            {
                var item = shapes[i];
                if (item.Range.Start >= range.Start && item.Range.End <= range.End)
                    doc.Delete(((Shape)item).Range);
            }
        }
        private void UnmergeTableColumn(Document doc, Field field)
        {
            var cell = doc.Tables.GetTableCell(field.ResultRange.Start);
            if (cell != null)
            {
                var tb = cell.Table;
                var cellIdx = cell.Index;
                tb.ForEachRow(new TableRowProcessorDelegate((r, k) => UnmergeTableColumn(r, cellIdx)));
            }
        }
        private void UnmergeTableColumn(TableRow r, int cellIdx)
        {
            if (r.Cells[cellIdx].VerticalMerging == VerticalMergingState.Restart)
            {
                int rowCount = 1;
                var rowNext = r.Next;
                while (rowNext != null)
                {
                    if (rowNext.Cells[cellIdx].VerticalMerging == VerticalMergingState.Continue)
                    {
                        rowCount++;
                        rowNext = rowNext.Next;
                    }
                    else
                        break;
                }
                if (rowCount > 1)
                    r.Cells[cellIdx].Split(rowCount, 1);
            }
        }
        public int MedicationInfutionTakenNote()
        {
            var doc = this._richEditCtrl.Document;
            var countRow = 0;
            foreach (var range in doc.Selections)
            {
                var fields = GetBindingFieldsInRange(range, string.Empty, string.Empty);
                var textValue = string.Empty;
                foreach (var item in fields)
                {
                    textValue = doc.GetText(item.Field.ResultRange);
                    textValue = textValue.Trim();
                    textValue = textValue.TrimEnd(ETAG.ToCharArray()).TrimStart(BTAG.ToCharArray());
                    textValue = textValue.Trim();
                    if (!string.IsNullOrEmpty(textValue) && textValue != ".")
                        break;
                }
                //khong tim dc gia tri nhap thi ko lam gi ca
                if (!string.IsNullOrEmpty(textValue))
                {
                    try
                    {
                        doc.BeginUpdate();
                        foreach (var item in fields)
                        {
                            doc.Replace(item.Field.ResultRange, $"{BTAG}{ETAG}");
                        }
                        doc.Replace(fields.First().Field.ResultRange, $"{BTAG}.{ETAG}");
                        doc.Replace(fields.Last().Field.ResultRange, $"{BTAG}.{ETAG}");
                        var middle = fields[fields.Count / 2];
                        doc.Replace(middle.Field.ResultRange, $"{BTAG}{textValue}{ETAG}");

                        var beginCell = doc.Tables.GetTableCell(range.Start);
                        var endCell = doc.Tables.GetTableCell(fields.Last().Field.ResultRange.End);
                        if (beginCell != null && endCell != null)
                        {
                            //cung table va phai cung row
                            if (beginCell.Table == endCell.Table && beginCell.Row == endCell.Row)
                            {
                                for (int i = beginCell.Index; i <= endCell.Index; i++)
                                {
                                    var cell = beginCell.Row.Cells[i];
                                    cell.Borders.Bottom.LineStyle = TableBorderLineStyle.Single;
                                    cell.Borders.Bottom.LineColor = Color.DarkBlue;
                                    cell.Borders.Bottom.LineThickness = 2;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        doc.EndUpdate();
                        countRow++;
                    }
                }
            }
            return countRow;
        }
        public void ClearMedicationInfutionTakenNote()
        {
            var doc = this._richEditCtrl.Document;
            doc.BeginUpdate();
            foreach (var range in doc.Selections)
            {
                var fields = GetBindingFieldsInRange(range, string.Empty, string.Empty);
                foreach (var item in fields)
                {
                    doc.Replace(item.Field.ResultRange, $"{BTAG}{ETAG}");
                }
                var beginCell = doc.Tables.GetTableCell(range.Start);
                var endCell = doc.Tables.GetTableCell(fields.Last().Field.ResultRange.End);
                if (beginCell != null && endCell != null)
                {
                    //cung table va phai cung row
                    if (beginCell.Table == endCell.Table && beginCell.Row == endCell.Row)
                    {
                        var lastCell = endCell.Row.LastCell;
                        for (int i = beginCell.Index; i <= endCell.Index; i++)
                        {
                            var cell = beginCell.Row.Cells[i];
                            cell.Borders.Bottom.LineStyle = lastCell.Borders.Bottom.LineStyle;
                            cell.Borders.Bottom.LineColor = lastCell.Borders.Bottom.LineColor;
                            cell.Borders.Bottom.LineThickness = lastCell.Borders.Bottom.LineThickness;
                        }
                    }
                }
            }
            doc.EndUpdate();
        }

        public bool PasteParamValue(string group)
        {
            if (Clipboard.ContainsText(TextDataFormat.UnicodeText))
            {
                string clipboardText = Clipboard.GetText(TextDataFormat.UnicodeText);
                var doc = _richEditCtrl.Document;

                if (!clipboardText.StartsWith("JSON:"))
                {
                    var listField = new List<Field>();
                    foreach (var selection in doc.Selections)
                    {
                        listField.AddRange(GetAllDataFieldInRange(selection));
                    }
                    if (listField.Count > 0)
                    {
                        doc.BeginUpdate();
                        foreach (var field in listField)
                        {
                            if (IsAllowEditField(field))
                            {
                                ReplaceFieldText(doc, field, clipboardText, string.Empty);
                            }
                        }
                        doc.EndUpdate();
                        return true;
                    }
                }
                else
                {
                    clipboardText = clipboardText.Substring(5);
                    var json = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(clipboardText);
                    BindingDataToRanges(json, doc.Selections, string.Empty, string.Empty);
                    return true;
                }
            }
            return false;
        }

        public Dictionary<string, List<EmrField>> GetAllSignerRoles(Document doc, IEnumerable<DocumentRange> selectedRanges)
        {
            var roles = new Dictionary<string, List<EmrField>>();
            for (int i = 0; i < selectedRanges.Count(); i++)
            {
                var fields = GetAllDataFieldInRange(selectedRanges.ElementAt(i));
                foreach (var field in fields)
                {
                    _fieldToCodeCache.TryGetValue(field, out EmrField emrField);
                    if (emrField == null)
                    {
                        var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                        emrField = AddCacheBindingField(field, text);
                    }
                    var codeLevels = emrField.CodeLevelArr;
                    if (codeLevels.Last() == EmrParam.ChuKyHinh
                        || codeLevels.Last() == EmrParam.ChuKyTen
                        || codeLevels.Last() == EmrParam.ChuKyHoTen
                        || codeLevels.Last() == EmrParam.ChuKyNguoiDung
                        || codeLevels.Last() == EmrParam.ChuKyThoiGian)
                    {
                        var parent = EmrParam.Anonymous;
                        if (codeLevels.Length > 1)
                        {
                            parent = codeLevels[codeLevels.Length - 2];
                            if (int.TryParse(parent, out int idx))
                                if (codeLevels.Length > 2)
                                    parent = codeLevels[codeLevels.Length - 3];

                        }
                        if (!roles.ContainsKey(parent))
                            roles.Add(parent, new List<EmrField>());

                        emrField.Field = field;
                        roles[parent].Add(emrField);
                    }
                }
            }
            return roles;
        }
        public List<EmrField> GetAllSignerFields(Document doc, DocumentRange range)
        {
            var emrFields = new List<EmrField>();
            var fields = GetAllDataFieldInRange(range);
            foreach (var field in fields)
            {
                _fieldToCodeCache.TryGetValue(field, out EmrField emrField);
                if (emrField == null)
                {
                    var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                    emrField = AddCacheBindingField(field, text);
                }
                var codeLevels = emrField.CodeLevelArr;
                if (codeLevels.Last() == EmrParam.ChuKyHinh
                    || codeLevels.Last() == EmrParam.ChuKyTen
                    || codeLevels.Last() == EmrParam.ChuKyHoTen
                    || codeLevels.Last() == EmrParam.ChuKyNguoiDung
                    || codeLevels.Last() == EmrParam.ChuKyThoiGian)
                {
                    emrField.Field = field;
                    emrFields.Add(emrField);
                }
            }
            return emrFields;
        }
        public List<EmrField> GetAllFields(Document doc, DocumentRange range)
        {
            var emrFields = new List<EmrField>();
            var fields = GetAllDataFieldInRange(range);
            foreach (var field in fields)
            {
                _fieldToCodeCache.TryGetValue(field, out EmrField emrField);
                if (emrField == null)
                {
                    var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                    emrField = AddCacheBindingField(field, text);
                }
                emrField.Field = field;
                emrFields.Add(emrField);
            }
            return emrFields;
        }
        #region header and footer
        public void DeleteAllPageKeepFirst(Document doc, DocumentLayout documentLayout)
        {
            var head = doc.Bookmarks.Where(b => b.Name == "header").FirstOrDefault();
            var footer = doc.Bookmarks.Where(b => b.Name == "footer").FirstOrDefault();
            //only template has header and footer need
            if (head != null || footer != null)
            {
                doc.BeginUpdate();
                while (documentLayout.GetPageCount() > 2)
                {
                    var page = documentLayout.GetPage(1);
                    var frange = page.MainContentRange;
                    var range = doc.CreateRange(frange.Start, frange.Length);
                    if (range != null)
                        doc.Delete(range);
                }
                if (documentLayout.GetPageCount() > 1)
                {
                    var page = documentLayout.GetPage(1);
                    var frange = page.MainContentRange;
                    var range = doc.CreateRange(frange.Start, frange.Length);
                    if (range != null)
                        doc.Delete(range);
                    doc.ReplaceAll(DevExpress.Office.Characters.PageBreak.ToString(), /*"\r\n"*/ string.Empty, SearchOptions.None);
                }
                doc.EndUpdate();
            }
        }

        public void AutoAddHeaderAndFooter(Document doc, DocumentLayout documentLayout, DocumentLayoutUnit layoutUnit)
        {
            if (!documentLayout.IsDocumentFormattingCompleted) return;
            var footer = doc.Bookmarks.Where(b => b.Name == "footer").FirstOrDefault();
            if (footer == null) return;
            var header = doc.Bookmarks.Where(b => b.Name == "header").FirstOrDefault();

            LayoutIterator iterator = new LayoutIterator(documentLayout, footer.Range);
            int height = 40;//padding + page break
            if (layoutUnit == DocumentLayoutUnit.Twip)
            {
                height = height * (1440 / 96);
            }
            while (iterator.MoveNext(LayoutLevel.TableRow))
                height += iterator.Current.Bounds.Height;

            var pageCount = documentLayout.GetPageCount();
            if (pageCount == 1) return;
            var pageIdx = 0;
            while (pageIdx < pageCount)
            {
                var page = documentLayout.GetPage(pageIdx);
                var frange = page.MainContentRange;
                //tu trang thu 2 moi co header
                if (pageIdx > 0 && header != null)
                {
                    var posHead = doc.CreatePosition(frange.Start);
                    posHead = doc.InsertDocumentContent(posHead, header.Range).End;
                    // xoa dau pagragraph do split table sinh ra
                    doc.Replace(doc.CreateRange(posHead, 1), string.Empty);
                }

                //trang cuoi ko co footer
                pageCount = documentLayout.GetPageCount();
                if (pageIdx == pageCount - 1) break;
                page = documentLayout.GetPage(pageIdx);
                frange = page.MainContentRange;

                iterator = new LayoutIterator(documentLayout, doc, frange);
                int h = 0;
                FixedRange range = null;
                iterator.Reset(InitialState.End);
                while (iterator.MovePrevious(LayoutLevel.TableRow))
                {
                    var row = (iterator.Current as LayoutTableRow);
                    h += iterator.Current.Bounds.Height;
                    if (h > height)
                    {
                        range = row.Range;
                        break;
                    }
                    //var txtx = doc.GetText(server.Document.CreateRange(row.Range.Start, row.Range.Length));
                }
                if (range == null) return;
                //var txt = doc.GetText(server.Document.CreateRange(range.Start, range.Length));
                TableCell cell = doc.Tables.GetTableCell(doc.CreatePosition(range.Start));
                if (cell != null && cell.Row.Previous != null)
                {
                    //doc.InsertText(cell.ContentRange.End, "SPLIT HERE");
                    var table = cell.Row.Table;
                    var newTable = SplitTable(doc, table, cell.Row.Index);
                    var r = doc.InsertSingleLineText(doc.CreatePosition(table.Range.End.ToInt() + 1), "\r");
                    var pos = doc.InsertDocumentContent(r.End, footer.Range, InsertOptions.KeepSourceFormatting).End;
                    InsertPageBreak(doc, pos);
                }
                else
                {
                    //find paragraph by pos
                }
                pageCount = documentLayout.GetPageCount();
                pageIdx++;

                //tranh lap vo tan
                if (pageCount > 30) break;
            }
        }
        public Table SplitTable(Document document, Table table, int rowIndex)
        {
            var r = document.InsertSingleLineText(document.CreatePosition(table.Range.End.ToInt()), "\r");
            DocumentRange newTableRange = document.InsertDocumentContent(r.End, table.Range);
            Table newTable = document.Tables.GetTableCell(document.CreatePosition(newTableRange.Start.ToInt() + 1))?.Table;

            if (newTable == null)
                return null;
            // remove rows in original table  
            int rowsCount = table.Rows.Count;
            for (int i = rowIndex; i < rowsCount; i++)
            {
                table.Rows.RemoveAt(table.Rows.Count - 1);
            }
            // remove rows in new table  
            for (int i = 0; i < rowIndex; i++)
            {
                newTable.Rows.RemoveAt(0);
            }
            return newTable;
        }
        public void InsertPageBreak(Document document, DocumentPosition position)
        {
            var r = document.InsertSingleLineText(document.CreatePosition(position.ToInt()), "\r");
            var strPageBrake = new string('\u000C', 1);
            document.InsertText(r.End, strPageBrake);
        }
        #endregion
        public string GetFieldValueAtPosition(Document doc, int pos)
        {
            var field = GetFieldAtPosition(pos);
            return GetFieldValue(doc, field);
        }
        public string GetFieldValue(Document doc, Field field)
        {
            if (field == null) return string.Empty;
            var text = doc.GetText(field.ResultRange, _plainTextExportCfg);
            return text.Trim().TrimEnd(EmrParam.EndTag[0]).TrimStart(EmrParam.BeginTag[0]);
        }
        public void RemoveAllPermisionRanges(Document doc)
        {
            //remove all ky ten
            var rangePermissions = doc.BeginUpdateRangePermissions();
            for (int i = 0; i < rangePermissions.Count; i++)
            {
                var rangePermis = rangePermissions[i];
                rangePermissions.Remove(rangePermis);
            }
            doc.EndUpdateRangePermissions(rangePermissions);
        }

        public void GotoEndOfParam(Document doc, Field last)
        {
            if (last == null) return;
            var text = doc.GetText(last.ResultRange, _plainTextExportCfg).TrimEnd();
            if (text.IndexOf(EmrParam.EndTag[0]) > 2 && text.LastIndexOf(EmrParam.BeginTag[0]) > 2)
            {
                // the cha chua nhieu the con, nhay ra khoi the cha luon
                doc.CaretPosition = last.Range.End;
                return;
            }
            if (text.EndsWith(EmrParam.EndTag))
            {
                doc.CaretPosition = doc.CreatePosition(last.Range.End.ToInt() - 2);
                return;
            }
        }

        #region Disabled Fields
        public void TrackDisabledField(EmrField emrField, Field field)
        {
            if (_disabledTemplateParams == null) return;
            TrackDisabledField(emrField.Tokens[0], field);
        }
        public void TrackDisabledField(string code, Field field)
        {
            if (_disabledTemplateParams == null) return;
            var path = Regex.Replace(code, @"\-([\d]*)\-", "[*].").Replace('-', '.');
            if (_disabledTemplateParams.Any(p => p.METemplateParamPath == path))
                _disabledFields.Add(field);
        }
        public bool IsAllowEditField(DocumentPosition position)
        {
            //if (_disabledFields.Count == 0) return true;

            //foreach (var field in _disabledFields)
            //{
            //    if (!(field as DevExpress.XtraRichEdit.API.Native.Implementation.NativeField).IsValid)
            //        continue;
            //    if (position >= field.ResultRange.Start && position <= field.ResultRange.End)
            //        return false;

            //}
            if (_disabledTemplateParams == null) return true;
            var list = GetParamInfos(_richEditCtrl.Document, position.ToInt());
            var path = Regex.Replace(list[1].Value, @"\-([\d]*)\-", "[*].").Replace('-', '.');
            if (_disabledTemplateParams.Any(p => p.METemplateParamPath == path))
                return false;
            return true;
        }
        public bool IsAllowEditField(Field fieldIn)
        {
            if (_disabledFields.Count == 0) return true;
            foreach (var field in _disabledFields)
            {
                if (field == fieldIn)
                    return false;
            }
            return true;
        }
        public bool IsAllowEditSelections(SelectionCollection selections)
        {
            if (_disabledFields.Count == 0) return true;
            foreach (var field in _disabledFields)
            {
                if (!(field as DevExpress.XtraRichEdit.API.Native.Implementation.NativeField).IsValid) continue;
                foreach (var range in selections)
                {
                    if (field.ResultRange.Start >= range.Start
                        && field.ResultRange.End <= range.End)
                        return false;
                }
            }
            return true;
        }

        #endregion
        public void SetTemplateParamList(List<METemplateParamsInfo> templateParams, ConcurrentDictionary<string, METemplateParamsInfo> dictByPath)
        {
            this._templateParams = templateParams;
            this._templateParamDictPath = dictByPath;
            this._disabledTemplateParams = templateParams.Where(p => p.METemplateParamDisabled).ToList();
            this._signedAsGroupTemplateParams = templateParams.Where(p => !string.IsNullOrEmpty(p.METemplateParamSignAsGroup)).ToArray();
        }
        /// <summary>
        /// xu ly hyperlink de xem ket qua PACS
        /// </summary>
        /// <param name="doc"></param>
        public void ProgressHyperlinksParamForPrint(Document doc)
        {
            doc.BeginUpdate();
            var fields = doc.Fields.ToArray();
            foreach (var field in fields)
            {
                var text = doc.GetText(field.ResultRange);
                if (string.IsNullOrEmpty(text)) continue;
                text = text.Trim();
                if (text.StartsWith("http://") || text.StartsWith("https://"))
                {
                    var link = doc.Hyperlinks.Create(field.ResultRange);
                    link.Anchor = null;
                    link.NavigateUri = text;
                    link.ToolTip = "Xem kết quả";
                }
            }
            doc.EndUpdate();
        }
        public void InsertPrimaryHeader(Document doc, string filePath)
        {
            Section firstSection = doc.Sections[0];
            //if (!firstSection.HasHeader(HeaderFooterType.Primary))
            {
                var hasFooterFirst = false;
                if (firstSection.HasFooter(HeaderFooterType.Primary) || firstSection.HasFooter(HeaderFooterType.First))
                {
                    hasFooterFirst = true;
                }
                firstSection.DifferentFirstPage = true;
                SubDocument newHeader = firstSection.BeginUpdateHeader();
                firstSection.EndUpdateHeader(newHeader);
                if (firstSection.HasHeader(HeaderFooterType.Primary))
                {
                    SubDocument headerDocument = firstSection.BeginUpdateHeader();
                    CharacterProperties cp = headerDocument.BeginUpdateCharacters(headerDocument.Range);
                    cp.FontSize = 0.5f;
                    headerDocument.EndUpdateCharacters(cp);
                    headerDocument.InsertDocumentContent(headerDocument.Range.End, filePath, DocumentFormat.OpenXml, InsertOptions.KeepSourceFormatting);
                    firstSection.EndUpdateHeader(headerDocument);
                }
                if (hasFooterFirst)
                {
                    SubDocument footerPrimary = firstSection.BeginUpdateFooter(HeaderFooterType.Primary);
                    SubDocument footerFirst = firstSection.BeginUpdateFooter(HeaderFooterType.First);
                    footerFirst.InsertDocumentContent(footerFirst.Range.Start, footerPrimary.Range);
                    firstSection.EndUpdateHeader(footerFirst);
                    firstSection.EndUpdateHeader(footerPrimary);
                }
            }
        }
        public void SignatureAndContentOnTheSamePage(RichEditControl richContrl, Document doc, DocumentLayout documentLayout)
        {
            for (int i = 0; i < doc.Fields.Count; i++)
            {
                var field = doc.Fields[i];
                _fieldToCodeCache.TryGetValue(field, out EmrField emrField);
                if (emrField == null)
                {
                    var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                    emrField = AddCacheBindingField(field, text);
                }
                var codeLevels = emrField.CodeLevelArr;
                var signed = false;
                if (codeLevels.Last() == EmrParam.ChuKyHinh)
                {
                    var signature = doc.Shapes.Get(field.ResultRange);
                    if (signature != null && signature.Count > 0)
                        signed = true;
                    if (!signed)
                    {
                        var imgs = doc.Images.Get(field.ResultRange);
                        if (imgs != null && imgs.Count > 0)
                            signed = true;
                    }
                }
                else if (codeLevels.Last() == EmrParam.ChuKyTen || codeLevels.Last() == EmrParam.ChuKyHoTen)
                {
                    var text = doc.GetText(field.ResultRange);
                    text = text.TrimEnd(EmrParam.EndTag.ToCharArray()).TrimStart(EmrParam.BeginTag.ToCharArray());
                    text = text.TrimEnd('\r', '\n', ' ', '\t').TrimStart('\r', '\n', ' ', '\t');
                    if (!string.IsNullOrEmpty(text))
                        signed = true;
                }
                if (signed)
                {
                    var paragraph = doc.Paragraphs.Get(field.ResultRange.Start);

                    var preParagraph = GetNotEmptyPreviousParagraph(doc, paragraph.Index);
                    if (preParagraph == null) continue;
                    var preParagraphPos = doc.CreatePosition(preParagraph.Range.Start.ToInt() + (preParagraph.Range.Length / 2));
                    LayoutRow preRow = documentLayout.GetElement<LayoutRow>(preParagraphPos);
                    if (preRow == null) continue;
                    var paragraphPos = doc.CreatePosition(field.ResultRange.Start.ToInt() + (field.ResultRange.Length / 2));
                    LayoutRow nextRow = documentLayout.GetElement<LayoutRow>(paragraphPos);
                    if (nextRow == null) continue;
                    int prePageIndex = documentLayout.GetPageIndex(preRow);
                    int nextPageIndex = documentLayout.GetPageIndex(nextRow);
                    if (prePageIndex < nextPageIndex)
                    {
                        // chu ky va noi dung truoc do thuoc 2 trang khac nhau
                        Console.WriteLine(prePageIndex + "/" + nextPageIndex);
                        var cell = doc.Tables.GetTableCell(preParagraph.Range.Start);
                        if (cell != null)
                        {
                            // Table có dòng đầu tiên là dòng title, dòng thứ 2 là dòng dữ liệu => Dòng thứ 2 của table sẽ không bao giờ được xử lý
                            if (prePageIndex == 0 && cell.Row.Index < 2) continue;
                            // Dòng thứ 3 của table trở đi có chiều cao > chiều cao của 1 trang sẽ không được xử lý => khi split table sẽ thành row index = 0
                            if (prePageIndex > 0 && cell.Row.Index < 1) continue;
                            // Dòng thứ 3 của table trở đi có chiều cao > chiều cao của 1 trang sẽ không được xử lý => Split sai
                            doc.CaretPosition = cell.ContentRange.Start;
                            var preParagraphIdx = preParagraph.Index;
                            var docFieldCount = doc.Fields.Count;
                            var docParagraphCount = doc.Paragraphs.Count;
                            // RichEditCommandId.SplitTable not run on RicheditDocumentServer
                            richContrl.CreateCommand(RichEditCommandId.SplitTable).Execute();
                            richContrl.CreateCommand(RichEditCommandId.InsertPageBreak).Execute();
                            paragraph = doc.Paragraphs.Get(doc.CaretPosition);
                            if (WrongSplitPage(doc, documentLayout,
                                doc.Paragraphs[preParagraphIdx + (doc.Paragraphs.Count - docParagraphCount)],
                                doc.Fields[i + (doc.Fields.Count - docFieldCount)]))
                            {
                                doc.Delete(paragraph.Range);
                                continue;
                            }
                            CharacterProperties cp = doc.BeginUpdateCharacters(paragraph.Range);
                            cp.FontSize = 0.5f;
                            doc.EndUpdateCharacters(cp);
                        }
                        else
                        {
                            var preContent = doc.GetText(preParagraph.Range);
                            if (preContent.Length < 50)
                                preParagraph = GetNotEmptyPreviousParagraph(doc, preParagraph.Index);
                            doc.CaretPosition = preParagraph.Range.Start;
                            richContrl.CreateCommand(RichEditCommandId.InsertPageBreak).Execute();
                        }
                    }
                }
            }
        }

        private bool WrongSplitPage(Document doc, DocumentLayout documentLayout, Paragraph preParagraph, Field field)
        {
            if (preParagraph == null) return true;
            var preParagraphPos = doc.CreatePosition(preParagraph.Range.Start.ToInt() + (preParagraph.Range.Length / 2));
            LayoutRow preRow = documentLayout.GetElement<LayoutRow>(preParagraphPos);
            if (preRow == null) return true;
            var paragraphPos = doc.CreatePosition(field.ResultRange.Start.ToInt() + (field.ResultRange.Length / 2));
            LayoutRow nextRow = documentLayout.GetElement<LayoutRow>(paragraphPos);
            if (nextRow == null) return true;
            int prePageIndex = documentLayout.GetPageIndex(preRow);
            int nextPageIndex = documentLayout.GetPageIndex(nextRow);
            if (prePageIndex != nextPageIndex)
            {
                return true;
            }
            return false;
        }

        private Paragraph GetNotEmptyPreviousParagraph(Document doc, int index, bool includeFieldMaker = false)
        {
            var fragment = new DevExpress.XtraRichEdit.API.Native.Implementation.TextFragmentOptions { AllowExtendingDocumentRange = false };
            for (int i = index - 1; i >= 0; i--)
            {
                var preParagraph = doc.Paragraphs[i];
                if (CheckIfNotEmptyParagraph(doc, preParagraph, fragment, includeFieldMaker))
                    return preParagraph;
            }
            return null;
        }
        private Paragraph GetNotEmptyNextParagraph(Document doc, int index, bool includeFieldMaker = false)
        {
            var fragment = new DevExpress.XtraRichEdit.API.Native.Implementation.TextFragmentOptions { AllowExtendingDocumentRange = false };
            for (int i = index + 1; i < doc.Paragraphs.Count; i++)
            {
                var nextParagraph = doc.Paragraphs[i];
                if (CheckIfNotEmptyParagraph(doc, nextParagraph, fragment, includeFieldMaker))
                    return nextParagraph;
            }
            return null;
        }
        private bool CheckIfNotEmptyParagraph(Document doc, Paragraph paragraph, DevExpress.XtraRichEdit.API.Native.Implementation.TextFragmentOptions fragment, bool includeFieldMaker)
        {
            var content = doc.GetText(paragraph.Range, fragment);
            if (string.IsNullOrEmpty(content))
            {
                Console.WriteLine(paragraph.Range.Start);
                return false;
            }
            if (!includeFieldMaker)
                content = content.TrimEnd(EmrParam.EndTag.ToCharArray()).TrimStart(EmrParam.BeginTag.ToCharArray());
            content = content.TrimEnd('\r', '\n', ' ', '\t').TrimStart('\r', '\n', ' ', '\t');
            if (!string.IsNullOrEmpty(content))
                return true;

            return false;
        }
        public DocumentPosition GetErrorPosition()
        {
            var doc = this._richEditCtrl.Document;
            foreach (var field in doc.Fields)
            {
                if (field.ResultRange.Length == 0)
                {
                    return field.ResultRange.Start;
                }
            }
            return null;
        }
        #region Chuyen dong TDT len xuong
        public int FindTableRowIdx(Table table, string path, string paramNo, int beginIdx = 0)
        {
            var doc = this._richEditCtrl.Document;
            Regex reg = new Regex($"^{path}{CODES}([\\d]*){CODES}{paramNo}");
            foreach (var field in doc.Fields)
            {
                _fieldToCodeCache.TryGetValue(field, out EmrField emrField);
                if (emrField == null)
                {
                    var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                    emrField = AddCacheBindingField(field, text);
                }
                if (reg.IsMatch(emrField.FieldCode))
                {
                    for (int i = beginIdx; i < table.Rows.Count; i++)
                    {
                        var row = table.Rows[i];
                        if (row.Range.Start < field.ResultRange.Start && row.Range.End > field.ResultRange.End)
                        {
                            return i;
                        }
                    }
                }
            }
            return -1;
        }
        public Dictionary<int, int> GetTableRowIdxs(Table table, string path, string paramNo)
        {
            var listIdxs = new Dictionary<int, int>();
            var doc = this._richEditCtrl.Document;
            Regex reg = new Regex($"^{path}{CODES}([\\d]*){CODES}{paramNo}");

            foreach (var field in doc.Fields)
            {
                _fieldToCodeCache.TryGetValue(field, out EmrField emrField);
                if (emrField == null)
                {
                    var text = doc.GetText(field.CodeRange, _plainTextExportCfg);
                    emrField = AddCacheBindingField(field, text);
                }
                var match = reg.Match(emrField.FieldCode);
                if (match.Success)
                {
                    var idxStr = emrField.FieldCode.Remove(0, $"{path}{CODES}".Length);
                    idxStr = idxStr.Substring(0, idxStr.IndexOf(CODES));
                    if (int.TryParse(idxStr, out int dataIndex))
                    {
                        if (listIdxs.ContainsKey(dataIndex)) continue;
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            var row = table.Rows[i];
                            if (row.Range.Start < field.ResultRange.Start && row.Range.End > field.ResultRange.End)
                            {
                                listIdxs.Add(dataIndex, i);
                                break;
                            }
                        }
                    }
                }
            }
            return listIdxs;
        }
        public void MoveTableRow(Table table, int oldIdx, int newIdx, bool hiddenRow)
        {
            if (oldIdx == newIdx) return;
            var doc = _richEditCtrl.Document;
            try
            {
                doc.BeginUpdate();
                //move up
                if (oldIdx > newIdx)
                {
                    oldIdx = oldIdx + 1;
                }

                var newRow = table.Rows.InsertBefore(newIdx);
                for (int i = 0; i < newRow.Cells.Count; i++)
                {
                    var cell = newRow.Cells[i];
                    var oldCell = table.Rows[oldIdx].Cells[i];
                    //them dong nay de dam bao khong bi be vung ky ten
                    doc.InsertSingleLineText(cell.ContentRange.Start, " ");
                    doc.InsertDocumentContent(cell.ContentRange.Start, oldCell.ContentRange, InsertOptions.KeepSourceFormatting);

                    cell.Borders.Bottom.LineStyle = oldCell.Borders.Bottom.LineStyle;
                    cell.Borders.Bottom.LineColor = oldCell.Borders.Bottom.LineColor;
                    cell.Borders.Bottom.LineThickness = oldCell.Borders.Bottom.LineThickness;

                    cell.Borders.Right.LineStyle = oldCell.Borders.Right.LineStyle;
                    cell.Borders.Right.LineColor = oldCell.Borders.Right.LineColor;
                    cell.Borders.Right.LineThickness = oldCell.Borders.Right.LineThickness;

                    cell.Borders.Left.LineStyle = oldCell.Borders.Left.LineStyle;
                    cell.Borders.Left.LineColor = oldCell.Borders.Left.LineColor;
                    cell.Borders.Left.LineThickness = oldCell.Borders.Left.LineThickness;
                }

                var oldRow = table.Rows[oldIdx];
                var rangePermissions = doc.BeginUpdateRangePermissions();
                for (int i = 0; i < rangePermissions.Count; i++)
                {
                    var rangePermis = rangePermissions[i];
                    var range = rangePermis.Range;
                    if (range.Start <= newRow.Range.Start && range.End >= newRow.Range.End)
                    {
                        throw new Exception("CÓ 2 DÒNG ĐƯỢC GOM THÀNH 1 VÙNG KÝ. KHÔNG THỂ CHÈN DÒNG MỚI VÀO GIỮA 2 DÒNG NÀY. VUI LÒNG HỦY KÝ 2 DÒNG NÀY TRƯỚC KHI THỰC HIỆN.");
                    }
                    var cellStart = doc.Tables.GetTableCell(range.Start);
                    var cellEnd = doc.Tables.GetTableCell(range.End);
                    if (cellStart != cellEnd && range.Start >= oldRow.Range.Start && range.End <= oldRow.Range.End)
                    {
                        var offset = range.Start.ToInt() - oldRow.Range.Start.ToInt();
                        var newRange = doc.CreateRange(doc.CreatePosition(newRow.Range.Start.ToInt() + offset), range.Length);
                        rangePermissions.AddRange(this.CreateRangePermissions(newRange, BOSApp.CurrentUsersInfo.ADUserGroupID.ToString(), BOSApp.CurrentUsersInfo.ADUserName));
                        var commentCount = doc.Comments.Count;
                        for (int c = 0; c < commentCount; c++)
                        {
                            var comment = doc.Comments[c];
                            if (comment.Range.Start == range.Start && comment.Range.Length == range.Length)
                            {
                                Comment newComment = doc.Comments.Create(newRange, BOSApp.CurrentUsersInfo.ADUserName, DateTime.Now);
                                newComment.Name = comment.Name;
                                SubDocument commentDocument = newComment.BeginUpdate();
                                SubDocument oldCommentDocument = comment.BeginUpdate();
                                commentDocument.InsertDocumentContent(commentDocument.Range.Start, oldCommentDocument.Range);
                                newComment.EndUpdate(commentDocument);
                                comment.EndUpdate(oldCommentDocument);
                                break;
                            }
                        }
                    }
                }
                doc.EndUpdateRangePermissions(rangePermissions);
                table.Rows.RemoveAt(oldIdx);
                if (hiddenRow)
                {
                    var hidenRow = table.Rows.InsertAfter(newRow.Index);
                    var oldHidenRow = table.Rows[oldIdx + 1];
                    foreach (var hidenCell in hidenRow.Cells)
                    {
                        var oldCell = oldHidenRow[hidenCell.Index];
                        hidenCell.Borders.Top.LineStyle = TableBorderLineStyle.None;

                        hidenCell.Borders.Bottom.LineStyle = oldCell.Borders.Bottom.LineStyle;
                        hidenCell.Borders.Bottom.LineColor = oldCell.Borders.Bottom.LineColor;
                        hidenCell.Borders.Bottom.LineThickness = oldCell.Borders.Bottom.LineThickness;

                        hidenCell.Borders.Right.LineStyle = oldCell.Borders.Right.LineStyle;
                        hidenCell.Borders.Right.LineColor = oldCell.Borders.Right.LineColor;
                        hidenCell.Borders.Right.LineThickness = oldCell.Borders.Right.LineThickness;

                        hidenCell.Borders.Left.LineStyle = oldCell.Borders.Left.LineStyle;
                        hidenCell.Borders.Left.LineColor = oldCell.Borders.Left.LineColor;
                        hidenCell.Borders.Left.LineThickness = oldCell.Borders.Left.LineThickness;
                        hidenCell.Height = oldCell.Height;
                        hidenCell.HeightType = oldCell.HeightType;
                    }
                    table.Rows.RemoveAt(oldIdx + 1);
                    //neu chuyen dong cuoi cua table di den noi khac
                    if (table.Rows.Count == oldIdx + 1)
                    {
                        var lastRow = table.Rows.Last();
                        foreach (var cell in lastRow.Cells)
                        {
                            if (cell.Borders.Bottom.LineStyle == TableBorderLineStyle.None)
                            {
                                var hidenCell = hidenRow[cell.Index];
                                cell.Borders.Bottom.LineStyle = hidenCell.Borders.Bottom.LineStyle;
                                cell.Borders.Bottom.LineColor = hidenCell.Borders.Bottom.LineColor;
                                cell.Borders.Bottom.LineThickness = hidenCell.Borders.Bottom.LineThickness;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                doc.EndUpdate();
            }
        }
        #endregion

        /// <summary>
        /// lay param value cho request tu doc
        /// </summary>
        /// <param name="listParam"></param>
        /// <param name="action"></param>
        /// <param name="actionRange"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public Dictionary<string, object> GetActionParamFromDoc(List<MEEmrActionParamsInfo> listParam, MEEmrActionsInfo action, DocumentRange actionRange, string group)
        {
            var result = new Dictionary<string, object>();
            if (listParam.Count == 0) return result;
            var doc = this._richEditCtrl.Document;

            foreach (var item in listParam)
            {
                var param = AppMemCache.GetParamFromDictKeyID(item.FK_MEParamID) as MEParamsInfo;
                if (param != null)
                {
                    var field = this.GetActionFields(group, param.MEParamNo, string.Empty, false, true).FirstOrDefault();
                    if (field != null)
                    {
                        var textValue = doc.GetText(field.ResultRange, _plainTextExportCfg);
                        object value = textValue;
                        textValue = textValue.TrimEnd('\r', '\n', ' ', '\t').TrimStart('\r', '\n', ' ', '\t');

                        if (!string.IsNullOrEmpty(param.MEParamUnit) && textValue.EndsWith(param.MEParamUnit))
                            textValue = textValue.Substring(0, textValue.Length - param.MEParamUnit.Length);

                        textValue = textValue.TrimEnd(EmrParam.EndTag.ToCharArray()).TrimStart(EmrParam.BeginTag.ToCharArray());
                        textValue = textValue.Trim();

                        var formatType = param.MEParamFormatType;
                        var formatStr = param.MEParamFormatString;
                        if (_templateParams != null)
                        {
                            _fieldToCodeCache.TryGetValue(field, out EmrField emrField);
                            if (emrField != null)
                            {
                                var fieldPath = GetTemplateFieldPath(emrField.Tokens[0]);
                                _templateParamDictPath.TryGetValue(fieldPath, out METemplateParamsInfo tempParam);
                                if (tempParam != null)
                                {
                                    if (!string.IsNullOrEmpty(tempParam.MEParamFormatString))
                                        formatStr = tempParam.MEParamFormatString;
                                    if (!string.IsNullOrEmpty(tempParam.MEParamFormatType))
                                        formatType = tempParam.MEParamFormatType;
                                }
                            }
                        }
                        value = this._dataHelper.ConvertDataType(formatType, formatStr, textValue);
                        result.Add(param.MEParamNo, value);
                    }
                }
            }
            return result;
        }
    }
}


