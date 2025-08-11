/**C4585C279A88E8537C1A338EFE5484F9**/
using BOSERP;
using DevExpress.XtraRichEdit.API.Native;
using System;
using DevExpress.XtraRichEdit;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using BOSCommon;
using System.Windows.Forms;
using Clas.Business.Ftp;
using System.Configuration;
using System.IO;
using DevExpress.XtraRichEdit.Export;
using BOSLib.DataAccess;

namespace Clas.Emr.Core
{
    public class EmrAction
    {
        private RichEditControl _richEditCtrl;
        private EmrDocumentHelper _emrDocumentHelper;
        private MEEmrActionParamsController _actionParamssController;
        private METemplatesController _templateCtrl;
        private string _documentPath;
        private MEEmrActionRelationsController _actionRelationsController;
        private MEEmrActionsController _actionsController;
        public char CODES { get; private set; }
        public char TAGS { get; private set; }
        //public string B_TAG { get; private set; }
        // public string E_TAG { get; private set; }
        public string GTAG { get; private set; }
        public string BTAG { get; private set; }
        public string ETAG { get; private set; }
        private EmrParser _emrParserHelper;
        private readonly PlainTextDocumentExporterOptions _plainTextExportCfg;

        public EmrAction(RichEditControl _richEditCtrl, EmrDocumentHelper emrDocumentHelper, EmrParser emrParser)
        {
            this._richEditCtrl = _richEditCtrl;
            this._emrDocumentHelper = emrDocumentHelper;
            this._emrParserHelper = emrParser;
            this._actionParamssController = new MEEmrActionParamsController();
            this._templateCtrl = new METemplatesController();
            this._actionRelationsController = new MEEmrActionRelationsController();
            this._actionsController = new MEEmrActionsController();

            this.CODES = EmrParam.CodeSeparator;
            this.TAGS = EmrParam.TagCodeSeparator;
            //this.B_TAG = EmrParam.BeginTag;
            //this.E_TAG = EmrParam.EndTag;
            this.BTAG = EmrParam.BeginTag;
            this.ETAG = EmrParam.EndTag;
            this.GTAG = EmrParam.GuidTag;

            System.Configuration.Configuration configuration =
              ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            this._documentPath = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_TEMPLATE_SERVER_PATH);

            if (!this._documentPath.Contains(":\\")) // đường dẫn tương đối
                this._documentPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + _documentPath;

            _plainTextExportCfg = new PlainTextDocumentExporterOptions() { ExportHiddenText = true, ExportBulletsAndNumbering = false };
        }
        public string AddTableRow(MEEmrActionsInfo action, DocumentRange actionRange, string group)
        {
            var listEmrParams = new List<MEParamsInfo>();
            var listParamRelations = new Dictionary<int, List<MEParamRelationsInfo>>();
            var paramses = _actionParamssController.GetAllByActionID(action.MEEmrActionID).Where(o => !o.MEEmrActionParamRequest && o.FK_MEParamID > 0).Select(p => p.FK_MEParamID);
            var newGroup = action.MEEmrActionNewGuid ? Guid.NewGuid().ToString() : group;
            foreach (var f in paramses)
            {
                var param = this._emrDocumentHelper.GetParamByID(listEmrParams, f);
                if (param == null) continue;
                if (param.MEParamType != EmrParamTypes.List.ToString()) continue;
                //phat sinh gid moi cho row neu action them row yeu cau phat sinh du lieu
                this._emrDocumentHelper.AddTableRow(action, param, group, newGroup, listEmrParams, listParamRelations, string.Empty, true);
            }
            return newGroup;
        }
        public void AddTableCol(MEEmrActionsInfo action, DocumentRange actionRange, string group)
        {
            var doc = this._richEditCtrl.Document;
            doc.BeginUpdate();
            var listEmrParams = new List<MEParamsInfo>();
            var listParamRelations = new Dictionary<int, List<MEParamRelationsInfo>>();
            var paramses = _actionParamssController.GetAllByActionID(action.MEEmrActionID).Where(o => !o.MEEmrActionParamRequest && o.FK_MEParamID > 0).Select(p => p.FK_MEParamID);
            try
            {
                foreach (var f in paramses)
                {
                    var param = this._emrDocumentHelper.GetParamByID(listEmrParams, f);
                    if (param == null) continue;
                    //get update field from doc can have multi fields
                    var updateFields = this._emrDocumentHelper.GetBindingFields(group, param.MEParamNo, string.Empty);
                    foreach (var updateField in updateFields)
                    {
                        Table table = this._emrDocumentHelper.GetTableFromDocument(this._richEditCtrl, updateField);
                        var row = table.Rows[0];
                        row.Cells.InsertAfter(row.Cells.Last.Index);
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("ADD TABLE COL ERROR: {0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ex);
                throw;
            }
            doc.EndUpdate();
        }



        /// <summary>
        /// chen template vao vi tri con trỏ
        /// </summary>
        /// <param name="template"></param>
        public void InsertTemplate(METemplatesInfo template, string group)
        {
            var doc = this._richEditCtrl.Document;
            var field = this._emrDocumentHelper.GetFieldAtPosition(doc.CaretPosition.ToInt());
            var paramNo = string.Empty;
            var firstUpdate = true;
            var pos = doc.CaretPosition;
            if (field != null)
            {
                var text = doc.GetText(field.CodeRange);
                var tokens = text.Split(TAGS);
                var codes = tokens.First().Split(CODES);
                paramNo = codes.Last();
                pos = field.ResultRange.Start;
                var gid = tokens.Where(t => t.StartsWith($"{GTAG}=")).FirstOrDefault();
                group = gid == null ? group : gid.Substring(GTAG.Length + 1);
            }
            this.InsertTemplate(template, group, pos, paramNo, firstUpdate);
        }
        /// <summary>
        /// chen template vao document
        /// </summary>
        /// <param name="template"></param>
        /// <param name="group"></param>
        /// <param name="pos">vi tri se insert neu ko tim thay the</param>
        /// <param name="paramNo">the cha chứa toàn bộ template khi insert vao, neu ko co the chứa thì = string.Emplty</param>
        /// <param name="firstUpdate">cap nhat the dau tien tim duoc</param>
        /// <returns></returns>
        public DocumentRange InsertTemplate(METemplatesInfo template, string group, DocumentPosition pos, string paramNo, bool firstUpdate)
        {
            var doc = this._richEditCtrl.Document;
            string fileName = string.Format(@"{0}\Template\{1}.docx", _documentPath, template.METemplateNo);
            var fileMng = new FileTemplateManager();
            fileMng.DownloadFile("/Template/", template.METemplateNo + ".docx", fileName);
            if (!File.Exists(fileName))
            {
                MessageBox.Show("File không tồn tại ở địa chỉ. " + fileName, "Không tìm được file thay thế");
                return null;
            }
            //replace tại vị trí thẻ đc add vào, ko tìm dc the thi moi insert tai vi tri truoc action
            var fields = this._emrDocumentHelper.GetBindingFields(group, paramNo, string.Empty, !firstUpdate, true);
            var prefix = this._emrDocumentHelper.GetFieldPrefix(fields.FirstOrDefault());
            var range = doc.Range;
            if (fields.Count == 0 && pos != null)
            {
                range = doc.InsertSingleLineText(doc.CreatePosition(pos.ToInt() + 1), "");
                range = doc.InsertDocumentContent(range.Start, fileName, DocumentFormat.OpenXml, InsertOptions.KeepSourceFormatting);
            }
            else if (fields.Count > 0)
            {
                //co the co nhieu vi tri
                foreach (var field in fields)
                {
                    doc.Replace(field.ResultRange, string.Empty);
                    range = doc.InsertDocumentContent(field.ResultRange.End, fileName, DocumentFormat.OpenXml, InsertOptions.KeepSourceFormatting);
                    //bo dau paragraph cu
                    doc.Replace(doc.CreateRange(doc.CreatePosition(range.End.ToInt() - 1), 1), string.Empty);
                }
            }
            this._emrDocumentHelper.GroupAndPrefixesSelectParam(doc, range, group, prefix, paramNo);
            return range;
        }

        /// <summary>
        /// loại action replace
        /// </summary>
        /// <param name="f"></param>
        /// <param name="action"></param>
        /// <param name="actionRange"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public DocumentPosition ReplaceEmrParam(MEEmrActionParamsInfo f, MEEmrActionsInfo action, DocumentRange actionRange, string group)
        {
            var doc = this._richEditCtrl.Document;
            try
            {
                doc.BeginUpdate();
                var param = AppMemCache.GetParamFromDictKeyID(f.FK_MEParamID);
                var children = AppMemCache.GetParamRelationsFromDict(param.MEParamID).OrderBy(p => p.MEParamRelationOrder).ToList();
                var actionPosition = doc.Range.Start;
                // uu tien the co template thay the
                if (param.FK_METemplateID > 0)
                {
                    var template = _templateCtrl.GetObjectByID(param.FK_METemplateID) as METemplatesInfo;
                    var range = InsertTemplate(template, group, actionRange != null ? actionRange.Start : null, param.MEParamNo, f.MEEmrActionParamUpdateFirst);
                    actionPosition = range.End;
                }
                else
                {
                    //if (children == null || children.Count <= 0) return;
                    var fields = this._emrDocumentHelper.GetBindingFields(group, param.MEParamNo, string.Empty, true, true);
                    var postion = doc.Range.Start;
                    //ko tìm dc the insert tai vi tri truoc action
                    if (fields.Count == 0 && actionRange != null)
                    {
                        var range = doc.InsertText(actionRange.Start, " ");
                        this._emrDocumentHelper.ClearParagrapFormat(doc, range);
                        postion = range.Start;
                        // if not have children single or list is the same
                        if (children.Count == 0)
                        {
                            range = doc.InsertText(postion, param.MEParamCaption + ": ");
                            var field = doc.Fields.Create(postion, $"{param.MEParamNo}{TAGS}{EmrParam.GuidTag}={group}");
                            doc.InsertText(field.ResultRange.Start, BTAG + param.MEParamValue + ETAG + param.MEParamUnit);
                            field.ShowCodes = false;
                            postion = field.Range.End;
                        }
                        else
                        {
                            if (param.MEParamType == EmrParamTypes.Single.ToString())
                            {
                                //param nay co children add children the cum
                                postion = this._emrDocumentHelper.ExtractSingleParam(doc, param, postion, "", group);
                            }
                            else if (param.MEParamType == EmrParamTypes.List.ToString())
                            {
                                postion = this._emrDocumentHelper.ExtractListParamV2(doc, param, postion, "", group);
                            }
                        }

                    }
                    //replace tại vị trí thẻ đc add vào, 
                    else if (fields.Count > 0)
                    {
                        //co the co nhieu vi tri
                        foreach (var field in fields)
                        {
                            postion = field.ResultRange.Start;
                            doc.Replace(field.ResultRange, "");
                            if (param.MEParamType == EmrParamTypes.Single.ToString())
                            {
                                //param nay co children add children the cum
                                postion = this._emrDocumentHelper.ExtractSingleParam(doc, param, postion, "", group);
                            }
                            else if (param.MEParamType == EmrParamTypes.List.ToString())
                            {
                                postion = this._emrDocumentHelper.ExtractListParamV2(doc, param, postion, "", group);
                            }
                        }
                    }
                    //bo dau paragraph
                    var removeRange = doc.CreateRange(doc.CreatePosition(postion.ToInt() - 1), 1);
                    doc.Replace(removeRange, string.Empty);

                    actionPosition = postion;
                }
                return actionPosition;
            }
            catch (Exception ex)
            {
                Trace.TraceError("REPLACE ERROR: {0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ex);
                throw;
            }
            finally
            {

                doc.EndUpdate();
            }

        }
        /// <summary>
        /// Loại action replace
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="action"></param>
        /// <param name="actionRange"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public DocumentPosition ReplaceEmrAction(DocumentPosition pos, MEEmrActionsInfo action, DocumentRange actionRange, string group)
        {
            var doc = this._richEditCtrl.Document;
            try
            {
                doc.BeginUpdate();
                var childActions = this._actionRelationsController.GetAllByParentID(action.MEEmrActionID);
                if (childActions.Count > 0)
                {
                    pos = doc.InsertText(pos, "\n").End;
                    for (int i = 0; i < childActions.Count; i++)
                    {
                        var childAction = this._actionsController.GetObjectByID(childActions[i].FK_MEEmrActionChildID) as MEEmrActionsInfo;
                        if (childAction == null) continue;
                        var linkRange = doc.InsertText(pos, childAction.MEEmrActionCaption);
                        //Convert the inserted text to the field 
                        var link = doc.Hyperlinks.Create(linkRange);
                        link.Anchor = childAction.MEEmrActionName;
                        link.NavigateUri = $"{childAction.MEEmrActionNo}{TAGS}{EmrParam.GuidTag}={group}";
                        link.ToolTip = childAction.MEEmrActionToolTip;
                        if (i + 1 < childActions.Count)
                        {
                            var range = doc.InsertText(pos, " / ");
                            this._emrDocumentHelper.ClearParagrapFormat(doc, range);
                            pos = range.End;
                        }
                    }
                    doc.InsertText(pos, "\n");
                }
                return pos;
            }
            catch (Exception ex)
            {
                Trace.TraceError("REPLACE ERROR: {0}:{1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), ex);
                throw;
            }
            finally
            {

                doc.EndUpdate();
            }

        }
        public void AssignEmrParamValue(MEEmrActionParamsInfo f, MEEmrActionsInfo action, DocumentRange actionRange, string group)
        {
            var doc = this._richEditCtrl.Document;
            var log = $"{TAGS}{EmrParam.UserUpdate}={BOSApp.CurrentUsersInfo.ADUserName}{TAGS}{EmrParam.UserUpdateDate}={DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";

            doc.BeginUpdate();
            var param = AppMemCache.GetParamFromDictKeyID(f.FK_MEParamID);
            var fields = this._emrDocumentHelper.GetBindingFields(group, param.MEParamNo, string.Empty, true, true);
            //ko tìm dc the insert tai vi tri truoc action
            if (fields.Count == 0)
            {
                var range = doc.InsertSingleLineText(actionRange.Start, " ");
                var code = $"{param.MEParamNo}{TAGS}{EmrParam.GuidTag}={group}";
                var field = doc.Fields.Create(range.Start, code);
                doc.InsertText(field.CodeRange.End, log);
                doc.InsertText(field.ResultRange.Start, BTAG + f.MEEmrActionParamValue + ETAG + param.MEParamUnit);
                field.ShowCodes = false;
            }
            else
            {
                foreach (var field in fields)
                {
                    doc.Replace(field.ResultRange, BTAG + f.MEEmrActionParamValue + ETAG + param.MEParamUnit);
                    doc.InsertText(field.CodeRange.End, log);
                    field.ShowCodes = false;
                }
            }
            doc.EndUpdate();
        }
        public void AssignEmrImageParamValue(List<MEEmrImageParamsInfo> paramList, DocumentRange actionRange, string group)
        {
            if (paramList.Count == 0) return;
            var doc = this._richEditCtrl.Document;
            var log = $"{TAGS}{EmrParam.UserUpdate}={BOSApp.CurrentUsersInfo.ADUserName}{TAGS}{EmrParam.UserUpdateDate}={DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";
            doc.BeginUpdate();
            foreach (var f in paramList)
            {
                if (string.IsNullOrEmpty(f.MEEmrImageParamValue)) continue;
                var param = AppMemCache.GetParamFromDictKeyID(f.FK_MEParamID);
                var fields = this._emrDocumentHelper.GetBindingFields(group, param.MEParamNo, string.Empty, false, true);
                var value = (string.IsNullOrEmpty(f.MEEmrImageParamCaption) ? "" : f.MEEmrImageParamCaption + ": ") + f.MEEmrImageParamValue;
                //ko tìm dc the insert tai vi tri sau image
                if (fields.Count == 0)
                {
                    var range = doc.InsertText(actionRange.End, "\r\n");
                    range = doc.InsertText(range.End, param.MEParamCaption + ": ");
                    var code = $"{param.MEParamNo}{TAGS}{EmrParam.GuidTag}={group}";
                    var field = doc.Fields.Create(range.End, code);
                    doc.InsertText(field.CodeRange.End, log);
                    doc.InsertText(field.ResultRange.Start, BTAG + value + ETAG + param.MEParamUnit);
                    field.ShowCodes = false;
                    actionRange = range;
                }
                else
                {
                    foreach (var field in fields)
                    {
                        this._emrDocumentHelper.BindingDataToFieldV2(param, field, value, string.Empty, string.Empty, group, null, string.Empty);
                        actionRange = field.Range;
                    }
                }
            }
            doc.EndUpdate();
        }

        /// <summary>
        /// uthv huy ky ten bang cach gach ngang
        /// Can Tho ko dung
        /// </summary>
        public bool UnsignRangeStrikeThrough(RangePermission range, string currentUser)
        {
            var doc = this._richEditCtrl.Document;
            try
            {
                doc.BeginUpdate();
                var beginCell = doc.Tables.GetTableCell(range.Range.Start);
                var endCell = doc.Tables.GetTableCell(range.Range.End);
                DocumentPosition pos = null;
                DocumentRange newRange = null, removeRange = null;
                if (beginCell != null && endCell != null)
                {
                    //cung cell
                    if (beginCell == endCell)
                    {
                        if (beginCell.ContentRange.Start.ToInt() <= range.Range.Start.ToInt()
                            && beginCell.ContentRange.End.ToInt() > range.Range.End.ToInt())
                        {
                            //xu ly nhu thong thuong
                            //copy all content to new 
                            pos = doc.CreatePosition(range.Range.End.ToInt() + 1);
                            var paragraph = doc.Paragraphs.Insert(pos, InsertOptions.MatchDestinationFormatting);
                            pos = doc.CreatePosition(paragraph.Range.Start.ToInt() - 1);
                            newRange = doc.InsertDocumentContent(pos, range.Range);
                            removeRange = range.Range;
                        }
                        else
                        {
                            //loai nay phai copy ca row
                            //TODO: them dong se bi loi
                            var row = beginCell.Table.Rows.InsertBefore(beginCell.Row.Index + 1);
                            foreach (var cell in row.Cells)
                            {
                                cell.VerticalAlignment = beginCell.Row.Cells[cell.Index].VerticalAlignment;
                                cell.Height = beginCell.Row.Cells[cell.Index].Height;
                                var r = doc.InsertDocumentContent(cell.ContentRange.Start, beginCell.Row.Cells[cell.Index].ContentRange, InsertOptions.KeepSourceFormatting);
                                var prePP = doc.Paragraphs.Get(beginCell.Row.Cells[cell.Index].ContentRange);
                                if (prePP.Count > 0)
                                {
                                    var pp = doc.BeginUpdateParagraphs(r);
                                    pp.Alignment = prePP.First().Alignment;
                                    doc.EndUpdateParagraphs(pp);
                                }
                            }
                            newRange = row.Cells[beginCell.Index].ContentRange;
                            removeRange = doc.CreateRange(beginCell.Row.Range.Start.ToInt() - 1, beginCell.Row.Range.Length + 1);
                        }
                    }
                    //cung row
                    else if (beginCell.Row == endCell.Row)
                    {
                        //TODO: them dong se bi loi
                        var row = beginCell.Table.Rows.InsertBefore(beginCell.Row.Index + 1);
                        foreach (var cell in row.Cells)
                        {
                            cell.VerticalAlignment = beginCell.Row.Cells[cell.Index].VerticalAlignment;
                            cell.Height = beginCell.Row.Cells[cell.Index].Height;
                            var r = doc.InsertDocumentContent(cell.ContentRange.Start, beginCell.Row.Cells[cell.Index].ContentRange, InsertOptions.KeepSourceFormatting);
                            var prePP = doc.Paragraphs.Get(beginCell.Row.Cells[cell.Index].ContentRange);
                            if (prePP.Count > 0)
                            {
                                var pp = doc.BeginUpdateParagraphs(r);
                                pp.Alignment = prePP.First().Alignment;
                                doc.EndUpdateParagraphs(pp);
                            }
                        }
                        newRange = row.Cells[beginCell.Index].ContentRange;
                        removeRange = doc.CreateRange(beginCell.Row.Range.Start.ToInt() - 1, beginCell.Row.Range.Length + 1);
                    }
                    //cung table
                    else if (beginCell.Table == endCell.Table)
                    {
                        //khong co truong hop nay vi moi dong la 1 range rieng biet
                        return false;
                    }
                    //khac table
                    else
                    {
                        //TODO: không duoc phep phap sinh lenh ky cho loai nay
                        return false;
                    }
                }
                else if (beginCell == null && endCell == null)
                {
                    //xu ly nhu thong thuong
                    //copy all content to new 
                    pos = doc.CreatePosition(range.Range.End.ToInt() + 1);
                    var paragraph = doc.Paragraphs.Insert(pos, InsertOptions.MatchDestinationFormatting);
                    pos = doc.CreatePosition(paragraph.Range.Start.ToInt() - 1);
                    newRange = doc.InsertDocumentContent(pos, range.Range);
                    removeRange = range.Range;
                }
                else
                {
                    //TODO: không duoc phep phap sinh lenh ky cho loai nay
                    return false;
                }

                //remove all field of unsign range
                List<EmrField> listFields = new List<EmrField>();
                foreach (var field in this._emrDocumentHelper.GetAllDataFieldInRange(removeRange))
                {
                    var fieldCode = doc.GetText(field.CodeRange, _plainTextExportCfg);
                    listFields.Add(new EmrField()
                    {
                        Field = field,
                        FieldCode = fieldCode,
                    });
                }
                listFields = listFields.OrderByDescending(o => o.FieldCode.Length).ToList();
                var opts = new DevExpress.XtraRichEdit.Export.RtfDocumentExporterOptions()
                {
                    ExportFinalParagraphMark = DevExpress.XtraRichEdit.Export.Rtf.ExportFinalParagraphMark.SelectedOnly
                };
                for (int i = 0; i < listFields.Count; i++)
                {
                    var field = listFields[i].Field;
                    if ((field as DevExpress.XtraRichEdit.API.Native.Implementation.NativeField).IsValid)
                    {
                        field.ShowCodes = true;
                        var content = doc.GetRtfText(field.ResultRange);
                        pos = field.ResultRange.End;
                        doc.Replace(field.Range, string.Empty);
                        doc.InsertRtfText(pos, content);
                    }
                }
                // gach ngang toan bo noi dung unsign range
                CharacterProperties strike = doc.BeginUpdateCharacters(removeRange);
                strike.Strikeout = StrikeoutType.Double;
                strike.ForeColor = System.Drawing.Color.Gray;
                doc.EndUpdateCharacters(strike);
                //remove comment of copy range
                Comment comment = null;
                foreach (var c in doc.Comments)
                {
                    if (c.Range.Start.ToInt() == newRange.Start.ToInt()
                        && (c.Range.End.ToInt() == newRange.End.ToInt()
                        || c.Range.End.ToInt() + 1 == newRange.End.ToInt()
                        || c.Range.End.ToInt() - 1 == newRange.End.ToInt()))
                    {
                        comment = c;
                        break;
                    }
                }
                if (comment != null)
                    doc.Comments.Remove(comment);

                RangePermission newRangPermission = null;
                var rangePermissions = doc.BeginUpdateRangePermissions();
                foreach (var rangePermis in rangePermissions)
                {
                    if (newRange.Start.ToInt() == rangePermis.Range.Start.ToInt()
                        && (newRange.End.ToInt() == rangePermis.Range.End.ToInt()
                        || newRange.End.ToInt() - 1 == rangePermis.Range.End.ToInt()
                        || newRange.End.ToInt() + 1 == rangePermis.Range.End.ToInt()))
                    {
                        newRangPermission = rangePermis;
                        break;
                    }
                }
                if (newRangPermission != null)
                    rangePermissions.Remove(newRangPermission);
                doc.EndUpdateRangePermissions(rangePermissions);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                doc.EndUpdate();
            }
            return true;
        }
        public bool UnsignRange(RangePermission pRange, string currentUser)
        {
            var doc = this._richEditCtrl.Document;
            try
            {
                doc.BeginUpdate();
                var range = pRange.Range;
                
                RangePermission removeRange = null;
                var rangePermissions = doc.BeginUpdateRangePermissions();
                foreach (var rangePermis in rangePermissions)
                {
                    if (range.Start.ToInt() == rangePermis.Range.Start.ToInt()
                        && range.End.ToInt() == rangePermis.Range.End.ToInt())
                    {
                        removeRange = rangePermis;
                        break;
                    }
                }
                var user = string.Empty;
                if (removeRange != null)
                {
                    user = removeRange.UserName;
                    //remove comment of range
                    for (int i = 0; i < doc.Comments.Count; i++)
                    {
                        var c = doc.Comments[i];
                        if (c.Range.Start.ToInt() >= range.Start.ToInt() && c.Range.End.ToInt() <= range.End.ToInt())
                        {
                            // cho phep huy ky nhieu range cua cung 1 user
                            if (c.Author == user)
                            {
                                doc.Comments.Remove(c);
                                i--;
                            }
                        }
                        // Neu duoc ky tu api thi c.Range.Start = 0
                        else if (c.Range.Start.ToInt() == 0 && range.Start.ToInt() == 1 && c.Range.End.ToInt() <= range.End.ToInt())
                        {
                            if (c.Author == user)
                            {
                                doc.Comments.Remove(c);
                                i--;
                            }
                        }
                    }
                    rangePermissions.Remove(removeRange);
                    doc.EndUpdateRangePermissions(rangePermissions);
                    //remove all sign mark
                    var fields = this._emrDocumentHelper.GetAllDataFieldInRange(range);
                    var stag = EmrParam.UserSign + "=" + user;
                    //var sdtag = EmrParam.UserSignDate + "=";
                    foreach (var field in fields)
                    {
                        field.ShowCodes = true;
                        var code = doc.GetText(field.CodeRange, _plainTextExportCfg);
                        var tokens = code.Split(TAGS);
                        var newTokens = new List<string>();
                        for (int i = 0; i < tokens.Length; i++)
                        {
                            if (tokens[i].StartsWith(stag))
                            {
                                i++;
                                continue;
                            }
                            else
                                newTokens.Add(tokens[i]);

                        }
                        code = string.Join(TAGS.ToString(), newTokens);
                        doc.Replace(field.CodeRange, code);
                        field.ShowCodes = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                doc.EndUpdate();
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caretPosition"></param>
        /// <returns></returns>
        public EmrField GetEmrtFieldAtPosition(DocumentPosition pos)
        {
            var f = this._emrDocumentHelper.GetFieldAtPosition(pos.ToInt());
            if (f == null) return null;
            return this._emrParserHelper.ParseField(f);
        }

        public Dictionary<string, object> MapToRequestParams(string strParam, Dictionary<string, object> requestParams)
        {
            var query = new Dictionary<string, object>();
            var parames = strParam.Split('|');
            if (parames.Length > 0)
            {
                foreach (var p in parames)
                {
                    var tokens = p.Split('=');
                    if (tokens.Length == 2)
                    {
                        var docParam = tokens[1].TrimStart('{').TrimEnd('}');
                        if (requestParams.ContainsKey(docParam))
                        {
                            query.Add(tokens[0].Trim(), requestParams[docParam]);
                            requestParams.Remove(docParam);
                        }
                    }

                }
            }
            foreach (var item in requestParams)
                query.Add(item.Key, item.Value);

            return query;
        }
    }
}
