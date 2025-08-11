using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using BOSCommon;
using System.Linq;
using BOSComponent;
using BOSLib;
using Localization;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using System.Transactions;
using DevExpress.XtraEditors.Controls;
using System.Configuration;
using BOSERP.Modules.METemplate.UI;
using Clas.Business.Ftp;
using System.IO;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Clas.Emr.Intergration;
using Clas.Emr.Ipc.Net.Messaging;
using BOSERP.Modules.ME;
using Clas.Emr.Core;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraRichEdit.Services;
using Emr;
using BOSLib.DataAccess;

namespace BOSERP.Modules.METemplate
{
    public class METemplateModule : BaseModuleERP
    {

        #region Constant
        private const string _templateContentCtrlName = "richEditCtrl";
        private const string _templateBackupDir = "TemplateBackup";
        private const string _fld_dgcMEParamsCtrlName = "fld_dgcMEParams";
        private const string _fld_dgcMEEmrActionsCtrlName = "fld_dgcMEEmrActions";
        private const string _fld_lbl_RichEditMsgName = "fld_lbl_RichEditMsg";
        private readonly bool _highlightModeEmrTagBorder = false;
        private readonly bool _highlightModeEmrTagFill = false;
        #endregion

        #region Public Properties

        #endregion

        #region Private Variables
        /// <summary>
        /// server path of teplate and template visist
        /// </summary>
        private String TemplateServerPath;
        private MEEmrActionsController _actionsController;
        private MEParamsController _paramsController;
        private EmrParser _emrParser;
        private LabelControl _msgNotification;
        private RichEditControl _richEditCtrl;
        private MEParamRelationsController _paramRelationsController;
        private METemplateEntities _entity;
        private EmrDocumentHelper _emrDocumentHelper;
        private METemplateParamsController _templateParamCtrl;
        private MemoEdit _msgLogs;
        private METemplatesController _templateCtrl;
        #endregion
        public METemplateModule()
        {
            Name = "METemplate";
            CurrentModuleEntity = new METemplateEntities();
            CurrentModuleEntity.Module = this;
            InitializeModule();
            System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            TemplateServerPath = SystemMemCache.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_TEMPLATE_SERVER_PATH);

            METemplateEntities entity = (METemplateEntities)CurrentModuleEntity;
            this._paramsController = new MEParamsController();
            this._paramRelationsController = new MEParamRelationsController();

            //entity.MEParamLookupList = _paramsController.GetParamList("").Where(p => p.MEParamType != "LAB").ToList();

            /*Emr */
            _richEditCtrl = (RichEditControl)Controls[METemplateModule._templateContentCtrlName];
            var myCommandFactory = new CustomRichEditCommandFactoryService(this, this._richEditCtrl, this._richEditCtrl.GetService<IRichEditCommandFactoryService>());
            this._richEditCtrl.ReplaceService<IRichEditCommandFactoryService>(myCommandFactory);

            this._msgNotification = this.Controls[_fld_lbl_RichEditMsgName] as LabelControl;
            this._msgLogs = this.Controls["fld_msgLogs"] as MemoEdit;

            this._actionsController = new MEEmrActionsController();
            this._entity = CurrentModuleEntity as METemplateEntities;
            this._emrDocumentHelper = new EmrDocumentHelper(this._richEditCtrl);
            this._emrParser = new EmrParser(this._richEditCtrl, this._msgNotification, this._msgLogs, _emrDocumentHelper);

            this._templateParamCtrl = new METemplateParamsController();

            this._templateCtrl = new METemplatesController();

            if (BOSApp.CurrentUserGroupInfo.ADUserGroupRole == UserGroupRole.admin.ToString())
            {
                this.Controls["fld_lkeFK_HREmployeeShareID"].Enabled = true;
                this.Controls["fld_lkeFK_HRDepartmentShareID"].Enabled = true;
            }
            _richEditCtrl.Document.DefaultCharacterProperties.FontName = "Times New Roman";
            _richEditCtrl.Document.DefaultCharacterProperties.FontSize = 13;

            if (!this.TemplateServerPath.Contains(":\\")) // đường dẫn tương đối
                this.TemplateServerPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + TemplateServerPath;

            InvalidateRefreshParams();
            InvalidateRefreshActions();

            _highlightModeEmrTagBorder = GetConfigHighlightModeEmrTagBorder();
            _highlightModeEmrTagFill = GetConfigHighlightModeEmrTagFill();

            if (_highlightModeEmrTagBorder || _highlightModeEmrTagFill)
            {
                _richEditCtrl.Options.Fields.HighlightMode = FieldsHighlightMode.Always;
                _richEditCtrl.BeforePagePaint += RichEditControl_BeforePagePaint;
            }

            _richEditCtrl.KeyDown += RichEditControl_KeyDown;
            _richEditCtrl.PreviewKeyDown += RichEditControl_PreviewKeyDown;
            FileTemplateManager fileMng = new FileTemplateManager();
            fileMng.CreateDirectory("/" + _templateBackupDir);
        }

        private void RichEditControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Tab)
            {
                //uthv Disable CTRL+TAB navigates between ToolStrip modules controls
                e.IsInputKey = true;
            }
        }

        private void RichEditControl_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void RichEditControl_BeforePagePaint(object sender, BeforePagePaintEventArgs e)
        {
            if (e.CanvasOwnerType == DevExpress.XtraRichEdit.API.Layout.CanvasOwnerType.Printer)
            {
                return;
            }
            e.Painter = new FieldPainter(_richEditCtrl, true, _highlightModeEmrTagBorder, _highlightModeEmrTagFill);
        }

        internal void RemoveItemFromTemplateParamList()
        {
            _entity.METemplateParamList.RemoveSelectedRowObjectFromList();
        }

        public override void ActionNew()
        {
            base.ActionNew();
            var template = ((METemplateEntities)CurrentModuleEntity).MainObject as METemplatesInfo;
            template.METemplateGuid = Guid.NewGuid().ToString();
            // mac dinh la private
            template.METemplateShareMode = TemplateShareMode.privated.ToString();
            template.FK_HREmployeeShareID = BOSApp.CurrentEmployeesInfo.HREmployeeID;
            template.FK_HRDepartmentShareID = BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID;
            _richEditCtrl.CreateNewDocument(false);
            _richEditCtrl.Document.DefaultCharacterProperties.FontName = "Times New Roman";
            _richEditCtrl.Document.DefaultCharacterProperties.FontSize = 13;
        }

        public override int ActionSave()
        {
            var entity = ((METemplateEntities)CurrentModuleEntity);
            entity.METemplateUserGroupList.EndCurrentEdit();
            foreach (var g in entity.METemplateUserGroupList.GroupBy(info => info.FK_ADUserGroupID)
                        .Select(group => new
                        {
                            Group = group.Key,
                            Count = group.Count()
                        }))
            {
                if (g.Count > 1)
                {
                    MessageBox.Show("Không được thêm 1 nhóm người dùng vào danh sách 2 lần.", "Trùng nhóm người dùng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;
                }
            }

            var template = entity.MainObject as METemplatesInfo;
            if (string.IsNullOrEmpty(template.METemplateGuid))
                template.METemplateGuid = Guid.NewGuid().ToString();

            entity.METemplateParamList.EndCurrentEdit();
            var requiredParams = entity.METemplateParamList.Where(m => m.METemplateParamRequired == true).ToList();
            var childs = requiredParams.Where(m => m.METemplateParamPath.Contains('.')).ToList();
            var parents = requiredParams.Where(m => !m.METemplateParamPath.Contains('.')).ToList();
            if (childs != null && childs.Count > 0)
            {
                foreach (var child in childs)
                {
                    var parentOfChild = child.METemplateParamPath.Split('.')[0].Replace("[*]", string.Empty);
                    var existParent = parents.Count(m => m.METemplateParamPath.Equals(parentOfChild));
                    if (existParent > 0)
                    {
                        MessageBox.Show($"Không được đánh dấu bắt buộc cho thẻ cha khi đã bắt buộc thẻ con.{Environment.NewLine}Chi tiết thẻ: {parentOfChild}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return 0;
                    }
                }
            }

            var hidenParams = entity.METemplateParamList.Where(m => m.METemplateParamPrintHidden == true).ToArray();
            if (hidenParams.Length > 0)
            {
                var paths = hidenParams.Select(h => h.METemplateParamPath).ToArray();
                if (MessageBox.Show($"Các thẻ dữ liệu sau được đánh dấu [KHÔNG IN RA].{Environment.NewLine}- "
                    + string.Join(Environment.NewLine + "- ", paths) +
                    $"{Environment.NewLine}Vui lòng xác nhận [OK] hoặc kiểm tra lại [Cancel].",
                     "CẢNH BÁO THẺ KHÔNG IN RA", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    return 0;
                }
            }

            int templateID = base.ActionSave();
            if (templateID > 0)
            {
                SaveTemplate(_richEditCtrl.Modified, true);
            }
            return templateID;
        }

        public override void ActionEdit()
        {
            base.ActionEdit();
            OpenTemplate();
        }

        public override void ActionDelete()
        {
            var entity = ((METemplateEntities)CurrentModuleEntity);
            var template = entity.MainObject as METemplatesInfo;
            var templateID = template.METemplateID;
            base.ActionDelete();

            var templateDb = _templateCtrl.GetDeletedObjectByID(templateID) as METemplatesInfo;
            if (templateDb != null)
            {
                _templateCtrl.UpdateRelationTableOnDelete(templateID, BOSApp.CurrentUser);
            }
        }

        private void OpenTemplate()
        {
            if (!Toolbar.IsNewAction())
            {
                METemplateEntities entity = (METemplateEntities)CurrentModuleEntity;
                METemplatesInfo objTemplatesInfo = (METemplatesInfo)entity.MainObject;
                string templateNo = objTemplatesInfo.METemplateNo;
                string pathTemplate = string.Format(@"{0}\Template\{1}.docx", TemplateServerPath, templateNo);
                try
                {
                    //UtHV 11042017 download file from ftp server
                    FileTemplateManager fileMng = new FileTemplateManager();
                    fileMng.DownloadFile("/Template/", objTemplatesInfo.METemplateNo + ".docx", pathTemplate);

                    if (!File.Exists(pathTemplate))
                    {
                        MessageBox.Show("File mẫu bệnh án không tồn tại ở địa chỉ. " + pathTemplate);
                        return;
                    }
                    _richEditCtrl.LoadDocument(pathTemplate);
                    //uthv 11/02/2019
                    _richEditCtrl.ReadOnly = !IsAllowEditTemplate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        public override void Invalidate(int iObjectID)
        {
            base.Invalidate(iObjectID);
            ParentScreen.SetEnableOfToolbarButton("Edit", IsAllowEditTemplate());
            OpenTemplate();
            InvalidateChartSeries();
        }
        private bool IsAllowEditTemplate()
        {
            //uthv 11/02/2019
            if (BOSApp.CurrentUserGroupInfo.ADUserGroupRole != UserGroupRole.admin.ToString())
            {
                var template = _entity.MainObject as METemplatesInfo;
                if (template.AACreatedUser == BOSApp.CurrentUsersInfo.ADUserName)
                    return true;
                else
                    //Chỉnh sửa phân quyền Mẫu bệnh án con - Những mẫu công khai thì user không được phép chỉnh sửa
                    return false;
            }
            else
            {
                return true;
            }
        }
        public bool ServerBackup()
        {
            var objTemplatesInfo = _entity.MainObject as METemplatesInfo;
            string templateNo = objTemplatesInfo.METemplateNo;
            string pathTemplate = string.Format(@"{0}\Template\{1}.docx", TemplateServerPath, templateNo);
            if (File.Exists(pathTemplate))
            {
                FileTemplateManager fileMng = new FileTemplateManager();
                fileMng.UploadFile($"/{_templateBackupDir}/", $"{objTemplatesInfo.METemplateNo}_bk_{BOSApp.CurrentUser}_{DateTime.Now.ToString("yyyyMMddhhmmss")}.docx", pathTemplate);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Save Template
        /// </summary>
        public void SaveTemplate(bool hasChangeDocxContent, bool mustBackup)
        {
            var error = this._emrDocumentHelper.GetErrorPosition();
            if (error != null)
            {
                var result = MessageBox.Show($"Tờ bệnh án chứa thẻ dữ liệu lỗi không có nội dung (không có cả dấu ‹›). Đến vị trí thẻ và xóa thẻ lỗi để sửa" +
                      $"\n\nYES: Để tiếp tục lưu. \nCANCEL: Để hủy. \nNO: Đưa con trỏ đến vị trí trước thẻ lỗi.", "[CẢNH BÁO] CÓ LỖI CẤU HÌNH TRÊN TỜ BỆNH ÁN.",
                      MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Cancel)
                {
                    _richEditCtrl.Modified = true;
                    return;
                }
                else if (result == DialogResult.No)
                {
                    _richEditCtrl.Document.CaretPosition = error;
                    _richEditCtrl.ScrollToCaret();
                    _richEditCtrl.Modified = true;
                    return;
                }
            }

            //uthv 11/02/2019
            if (!IsAllowEditTemplate())
            {
                MessageBox.Show("Bạn không có quyền chỉnh sửa mẫu bệnh án này. Chỉ Admin hay người tạo mới có quyền chỉnh sửa bệnh án.", "Thiếu quyền");
                return;
            }
            var objTemplatesInfo = _entity.MainObject as METemplatesInfo;
            if (objTemplatesInfo != null)
            {
                BOSProgressBar.Start("Đang lưu dữ liệu");
                try
                {
                    if (hasChangeDocxContent)
                    {
                        var templateDb = _templateCtrl.GetObjectByID(objTemplatesInfo.METemplateID) as METemplatesInfo;
                        templateDb.AAUpdatedUser = BOSApp.CurrentUser;
                        _templateCtrl.UpdateObject(templateDb);
                        string templateNo = objTemplatesInfo.METemplateNo;
                        string pathTemplate = string.Format(@"{0}\Template\{1}.docx", TemplateServerPath, templateNo);
                        FileTemplateManager fileMng = new FileTemplateManager();
                        if (mustBackup)
                        {
                            if (File.Exists(pathTemplate))
                                fileMng.UploadFile($"/{_templateBackupDir}/", $"{objTemplatesInfo.METemplateNo}_bk_{templateDb.AAUpdatedUser}_{DateTime.Now.ToString("yyyyMMddhhmmss")}.docx", pathTemplate);
                        }

                        _richEditCtrl.SaveDocument(pathTemplate, DocumentFormat.OpenXml);
                        _richEditCtrl.Modified = false;
                        if (File.Exists(pathTemplate))
                            fileMng.UploadFile("/Template/", objTemplatesInfo.METemplateNo + ".docx", pathTemplate);

                        var document = this._emrDocumentHelper.GetAllDataFieldInRangeOrDocument();
                        string jsonDocument = this._emrParser.ParserFieldsToJson(document, _entity.METemplateParamList);
                        JToken data = JsonConvert.DeserializeObject<JToken>(jsonDocument);
                        _paramPaths = new List<string>();
                        this.SaveParamsOfDocument(data, objTemplatesInfo);
                        for (int i = 0; i < _entity.METemplateParamList.Count; i++)
                        {
                            if (!_entity.METemplateParamList[i].METemplateParamManualAdded)
                                if (!_paramPaths.Contains(_entity.METemplateParamList[i].METemplateParamPath))
                                    _entity.METemplateParamList.RemoveAt(i);
                        }
                        _entity.METemplateParamList.SaveItemObjects();
                        _entity.METemplateParamList.Invalidate(objTemplatesInfo.METemplateID);
                        // CODE ERROR. FIX LATER
                        var manualActIds = new List<int>();
                        foreach (var hyperlink in _richEditCtrl.Document.Hyperlinks)
                        {
                            var tokens = hyperlink.NavigateUri.Split(EmrParam.TagCodeSeparator);
                            if (tokens.Length == 0) continue;
                            var action = _actionsController.GetObjectByNo(tokens[0]) as MEEmrActionsInfo;
                            if (action != null)
                            {
                                var templateAction = _entity.MEEmrTemplateActionList.Where(
                                    a => a.FK_MEEmrActionID == action.MEEmrActionID
                                    && a.MEEmrTemplateActionWhen == EmrTemplateActionWhen.Manual.ToString()).FirstOrDefault();
                                if (templateAction == null)
                                {
                                    _entity.MEEmrTemplateActionList.Add(new MEEmrTemplateActionsInfo()
                                    {
                                        MEEmrTemplateActionDo = EmrTemplateActionDo.UpdateDoc.ToString(),
                                        MEEmrTemplateActionWhen = EmrTemplateActionWhen.Manual.ToString(),
                                        FK_MEEmrActionID = action.MEEmrActionID,
                                        FK_METemplateID = templateDb.METemplateID,
                                        MEEmrTemplateActionOrder = 999
                                    });
                                }
                                manualActIds.Add(action.MEEmrActionID);
                            }
                        }
                        // Xoá trên docx => cập nhật lại
                        for (int i = 0; i < _entity.MEEmrTemplateActionList.Count; i++)
                        {
                            if (_entity.MEEmrTemplateActionList[i].MEEmrTemplateActionWhen == EmrTemplateActionWhen.Manual.ToString())
                            {
                                if (!manualActIds.Contains(_entity.MEEmrTemplateActionList[i].FK_MEEmrActionID))
                                {
                                    _entity.MEEmrTemplateActionList.RemoveAt(i);
                                }
                            }
                        }
                        _entity.MEEmrTemplateActionList.SaveItemObjects();
                        _entity.MEEmrTemplateActionList.Invalidate(objTemplatesInfo.METemplateID);
                    }
                    else
                    {
                        // Fix miss file
                        FileTemplateManager fileMng = new FileTemplateManager();
                        string templateNo = objTemplatesInfo.METemplateNo;
                        if (!fileMng.FileExists($"/Template/", $"{templateNo}.docx"))
                        {
                            string pathTemplate = string.Format(@"{0}\Template\{1}.docx", TemplateServerPath, templateNo);
                            _richEditCtrl.SaveDocument(pathTemplate, DocumentFormat.OpenXml);
                            _richEditCtrl.Modified = false;
                            if (File.Exists(pathTemplate))
                                fileMng.UploadFile("/Template/", objTemplatesInfo.METemplateNo + ".docx", pathTemplate);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    BOSProgressBar.Close();
                }
            }
        }

        /// <summary>
        ///  mac dinh group cua the moi add vao la template.METemplateGuid
        /// </summary>
        /// <param name="param"></param>
        /// <param name="onlyParentParam"></param>
        public void AddParamToTemplateAtCaretPosition(MEParamsInfo param, bool onlyParentParam = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            var template = ((METemplateEntities)CurrentModuleEntity).MainObject as METemplatesInfo;

            var doc = _richEditCtrl.Document;
            doc.BeginUpdate();
            var range = doc.InsertText(doc.CaretPosition, param.MEParamCaption + ": ");
            doc.CaretPosition = range.End;
            doc.EndUpdate();

            this._emrDocumentHelper.AddParamToTemplateAtCaretPosition(param, template.METemplateGuid, onlyParentParam);
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// mac dinh group cua the moi add vao la template.METemplateGuid
        /// </summary>
        /// <param name="action"></param>
        public void AddActionToTemplate(MEEmrActionsInfo action)
        {
            if (action == null) return;
            var template = ((METemplateEntities)CurrentModuleEntity).MainObject as METemplatesInfo;
            this._emrDocumentHelper.AddActionToTemplate(action, template);
        }
        #region Start up Action
        internal void AddStartupActionToTemplate(MEEmrActionsInfo mEEmrActionsInfo)
        {
            if (mEEmrActionsInfo == null) return;
            var template = _entity.MainObject as METemplatesInfo;
            _entity.MEEmrTemplateActionList.Add(new MEEmrTemplateActionsInfo()
            {
                FK_MEEmrActionID = mEEmrActionsInfo.MEEmrActionID,
                FK_METemplateID = template.METemplateID,
                MEEmrTemplateActionWhen = EmrTemplateActionWhen.Init.ToString(),
                MEEmrTemplateActionDo = EmrTemplateActionDo.UpdateDoc.ToString(),
            });
            //uthv thêm chức năng được gọi khi init/open/print/save
            //_entity.MEEmrStartupActionList.Remove(mEEmrActionsInfo);
            //_entity.MEEmrStartupActionList.GridControl.RefreshDataSource();
            _entity.MEEmrTemplateActionList.GridControl.RefreshDataSource();
        }
        internal void RemoteStartupActionToTemplate(MEEmrTemplateActionsInfo mEEmrTemplateActionsInfo)
        {
            if (mEEmrTemplateActionsInfo == null) return;
            var template = _entity.MainObject as METemplatesInfo;
            _entity.MEEmrTemplateActionList.Remove(mEEmrTemplateActionsInfo);
            _entity.MEEmrTemplateActionList.GridControl.RefreshDataSource();

            //uthv thêm chức năng được gọi khi init/open/print/save
            //_entity.InvalidateActionList(template.METemplateID);
            //_entity.MEEmrStartupActionList.GridControl.RefreshDataSource();
        }
        #endregion
        #region Config Grouping param
        internal void GroupSelectParam()
        {
            var doc = _richEditCtrl.Document;
            var selectedRanges = doc.Selections;
            if (selectedRanges.Count == 1 && selectedRanges[0].Length == 0)
            {
                MessageBox.Show("Quét chọn các thẻ dữ liệu và thẻ chức năng bạn muốn nhóm", "Chọn nội dung");
                return;
            }
            var group = Guid.NewGuid().ToString();
            foreach (var range in selectedRanges)
            {
                this._emrDocumentHelper.GroupAndPrefixesSelectParam(doc, range, group, string.Empty, string.Empty);
            }
        }
        internal void ClearGroupSelectParam()
        {
            var template = ((METemplateEntities)CurrentModuleEntity).MainObject as METemplatesInfo;
            var doc = _richEditCtrl.Document;
            var selectedRanges = doc.Selections;
            if (selectedRanges.Count == 1 && selectedRanges[0].Length == 0)
            {
                MessageBox.Show("Quét chọn các thẻ dữ liệu và thẻ chức năng bạn bỏ nhóm", "Chọn nội dung");
                return;
            }
            foreach (var range in selectedRanges)
            {
                this._emrDocumentHelper.ClearGroupSelectParam(doc, range, template.METemplateGuid);
            }

        }
        #endregion
        internal void ViewParamInfo()
        {
            var doc = _richEditCtrl.Document;
            var caretPosition = doc.CaretPosition.ToInt();
            var properties = this._emrDocumentHelper.GetParamInfos(doc, caretPosition);
            if (properties != null)
            {
                var gui = new guiParamProperties(properties);
                gui.ShowDialog();
            }
            else
                MessageBox.Show("Đặt con trỏ giữa một thẻ dữ liệu.", "Không tìm thấy thẻ tương ứng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region Chart config
        private void GetAllListParamAndData(JObject data, Dictionary<string, object> results)
        {
            if (data == null) return;
            foreach (var token in data)
            {
                if (token.Value.Type == JTokenType.Array)
                {
                    if (!results.ContainsKey(token.Key))
                        results.Add(token.Key, token.Value);
                }
                else if (token.Value.Type == JTokenType.Object)
                {
                    GetAllListParamAndData(token.Value as JObject, results);
                }
            }
        }
        #endregion

        private List<string> _paramPaths;
        private void SaveParamsOfDocument(JToken data, METemplatesInfo templateInfo)
        {
            if (data == null) return;
            if (data.Type == JTokenType.Object)
            {
                foreach (JToken child in data.Children())
                    this.SaveParamsOfDocument(child, templateInfo);
                return;
            }
            else if (data.Type == JTokenType.Property)
            {
                string paramNo = data.GetType().GetProperty("Name").GetValue(data).ToString();
                var info = _paramsController.GetParamByNo(paramNo);
                if (info != null)
                {
                    var path = System.Text.RegularExpressions.Regex.Replace(data.Path, @"\[([\d]*)\]", "[*]");
                    var tPram = _entity.METemplateParamList.Where(o => o.METemplateParamPath == path).FirstOrDefault();
                    _paramPaths.Add(path);
                    if (tPram != null)
                    {
                        tPram.FK_MEParamID = info.MEParamID;
                        tPram.FK_METemplateID = templateInfo.METemplateID;
                    }
                    else
                    {
                        METemplateParamsInfo rInfo = new METemplateParamsInfo();
                        rInfo.FK_MEParamID = info.MEParamID;
                        rInfo.FK_METemplateID = templateInfo.METemplateID;
                        rInfo.METemplateParamPath = path;
                        _entity.METemplateParamList.Add(rInfo);
                    }
                    var val = (data as JProperty).Value;
                    if (val.Type == JTokenType.Object)
                    {
                        this.SaveParamsOfDocument(val, templateInfo);
                    }
                    else if (val.Type == JTokenType.Array)
                    {
                        this.SaveParamsOfDocument(data.FirstOrDefault(), templateInfo);
                    }
                    return;
                }
            }
            else if (data.Type == JTokenType.Array)
            {
                this.SaveParamsOfDocument(data.FirstOrDefault(), templateInfo);
                return;
            }
        }

        public void GetParamsTree(TreeList list)
        {
            var document = this._emrDocumentHelper.GetAllDataFieldInRangeOrDocument();
            string jsonDocument = this._emrParser.ParserFieldsToJson(document, _entity.METemplateParamList, false);
            JToken data = JsonConvert.DeserializeObject<JToken>(jsonDocument);

            list.BeginUnboundLoad();
            this.GetParamsTree(data, list, null);
            list.EndUnboundLoad();
        }

        private void GetParamsTree(JToken data, TreeList list, TreeListNode parent)
        {
            if (data == null) return;
            if (data.Type == JTokenType.Object)
            {
                foreach (JToken child in data.Children())
                    this.GetParamsTree(child, list, parent);
                return;
            }
            if (data.Type == JTokenType.Property)
            {
                string paramNo = data.GetType().GetProperty("Name").GetValue(data).ToString();
                var info = (new MEParamsController()).GetParamByNo(paramNo);
                if (info != null)
                {
                    var obj = new object[] {
                        info.MEParamName,
                        info.MEParamCaption,
                        info.MEParamType,
                        info.MEParamNo,
                        info.MEParamValue,
                        info.MEParamMinValue,
                        info.MEParamMaxValue,
                        info.MEParamMatchCode01Combo,
                        info.MEParamFormatType,
                        info.MEParamFormatString,
                        info.MEParamControlType,
                        info.MEParamPrintHidden,
                        info.MEParamImageHeight,
                        info.MEParamImageWidth
                    };
                    this.GetParamsTree(data.FirstOrDefault(), list, list.AppendNode(obj, parent));
                }
                else this.GetParamsTree(data.FirstOrDefault(), list, parent);
                return;
            }
            if (data.Type == JTokenType.Array)
            {
                this.GetParamsTree(data.FirstOrDefault(), list, parent);
                return;
            }
        }
        #region User Group
        internal void DeleteTemplateUserGroupList()
        {
            _entity.METemplateUserGroupList.RemoveSelectedRowObjectFromList();
        }
        #endregion

        #region Config Chart
        internal void InvalidateChartSeries()
        {
            if (_entity.METemplateChartList.CurrentIndex < 0) return;
            var chart = _entity.METemplateChartList[_entity.METemplateChartList.CurrentIndex];
            if (chart.METemplateChartID > 0)
            {
                _entity.METemplateChartSeriesList.Invalidate(chart.METemplateChartID);
                InitTemplateParamLookupEdit();
            }
            else
                MessageBox.Show("Lưu thông tin biểu đồ trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private RepositoryItemBOSLookupEdit InitTemplateChartSeriesColumnLookupEdit(List<MEParamsInfo> data)
        {
            var rep = new RepositoryItemBOSLookupEdit
            {
                TextEditStyle = TextEditStyles.Standard,
                SearchMode = SearchMode.AutoFilter,
                NullText = string.Empty,
                BestFitMode = BestFitMode.BestFitResizePopup,
                Tag = "MEParams",
                ValueMember = "MEParamNo",
                DisplayMember = "MEParamName",
                DataSource = data
            };
            var colName = new LookUpColumnInfo();
            colName.Caption = "Tên thẻ dữ liệu";
            colName.FieldName = rep.DisplayMember;
            colName.Width = 100;
            rep.Columns.Add(colName);
            return rep;
        }
        private void InitTemplateParamLookupEdit()
        {
            if (_entity.METemplateParamList.Count == 0)
            {
                return;
            }
            //var data = _emrDocumentHelper.GetAllParamsForChart();
            var data = new List<MEParamsInfo>();
            foreach (var item in _entity.METemplateParamList)
            {
                var param = _entity.MEParamList.Where(p => p.MEParamID == item.FK_MEParamID).FirstOrDefault();
                data.Add(new MEParamsInfo()
                {
                    MEParamNo = item.METemplateParamPath,
                    MEParamName = param != null ? param.MEParamName : item.METemplateParamPath
                });
            }
            var gridView = _entity.METemplateChartSeriesList.GridView;
            foreach (GridColumn col in gridView.Columns)
            {
                if (col.FieldName == "MEParamArgument1"
                    || col.FieldName == "MEParamArgument2"
                    || col.FieldName == "MEParamArgument3"
                    || col.FieldName == "MEParamValue1"
                    || col.FieldName == "MEParamValue2")
                {
                    col.ColumnEdit = InitTemplateChartSeriesColumnLookupEdit(data);
                }
            }
            gridView = _entity.METemplateChartList.GridView;
            foreach (GridColumn col in gridView.Columns)
            {
                if (col.FieldName == "METemplateChartContainerParam")
                {
                    col.ColumnEdit = InitTemplateChartSeriesColumnLookupEdit(data);
                }
            }
        }

        internal void SaveChartSeries()
        {
            var chart = _entity.METemplateChartList[_entity.METemplateChartList.CurrentIndex];
            foreach (var item in _entity.METemplateChartSeriesList)
            {
                item.FK_METemplateChartID = chart.METemplateChartID;
            }
            _entity.METemplateChartSeriesList.SaveItemObjects();
        }
        public void InsertImageToDocument(Image image)
        {
            this.InsertImageToDocument(image, this._richEditCtrl.Document.CaretPosition);
        }
        internal void InsertImageToDocument(Image image, DocumentPosition postion)
        {
            var doc = this._richEditCtrl.Document;
            doc.BeginUpdate();
            var range = doc.InsertText(postion, "\n");
            var img = doc.Images.Insert(range.Start, image);

            //if size> width then edit scale otherwise do nothing
            var docWidth = doc.Sections[0].Page.Width - (doc.Sections[0].Margins.Left + doc.Sections[0].Margins.Right);
            if (img.Size.Width > docWidth)
            {
                //img.ScaleX /= (img.Size.Width / docWidth); bieu do se ko scale
                //img.ScaleY /= (img.Size.Height / docWidth);
            }
            doc.EndUpdate();

        }
        internal void ConfigChart()
        {
            if (_entity.METemplateChartList.CurrentIndex < 0) return;
            var chart = _entity.METemplateChartList[_entity.METemplateChartList.CurrentIndex];
            if (chart.METemplateChartID > 0)
            {
                foreach (var series in _entity.METemplateChartSeriesList)
                {
                    if (series.METemplateChartSeriesID <= 0)
                    {
                        MessageBox.Show("Lưu danh sách series trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                _entity.METemplateChartSeriesList.Invalidate(chart.METemplateChartID);
                var document = this._emrDocumentHelper.GetAllDataFieldInRangeOrDocument();
                string jsonDocument = this._emrParser.ParserFieldsToJson(document, _entity.METemplateParamList);
                JToken data = JsonConvert.DeserializeObject<JToken>(jsonDocument);
                var temp = _entity.MainObject as METemplatesInfo;
                var gui = new guiChartConfig(
                    data,
                    chart,
                    _entity.METemplateChartSeriesList.ToList(),
                    AppMemCache.GetTemplateParamsDictPath(temp.METemplateID));
                gui.Module = this;
                if (gui.ShowDialog() == DialogResult.OK)
                    this.InsertImageToDocument(gui.ChartImage);
            }
            else
                MessageBox.Show("Lưu thông tin biểu đồ trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        internal void ClearConfigChart()
        {
            if (_entity.METemplateChartList.CurrentIndex < 0) return;
            var chart = _entity.METemplateChartList[_entity.METemplateChartList.CurrentIndex];
            if (chart.METemplateChartID > 0)
            {
                chart.METemplateChartOpts = string.Empty;
                (new METemplateChartsController()).UpdateObject(chart);
            }
        }
        internal void DeleteTemplateChart()
        {
            _entity.METemplateChartList.RemoveSelectedRowObjectFromList();
        }

        internal void DeleteTemplateChartSeriesList()
        {
            _entity.METemplateChartSeriesList.RemoveSelectedRowObjectFromList();
        }

        #endregion

        #region Share Mode
        internal void ChangeShareMode(string mode)
        {
            if (this.Toolbar.IsNullOrNoneAction()) return;
            var temp = _entity.MainObject as METemplatesInfo;
            temp.METemplateShareMode = mode;
            if (mode == TemplateShareMode.privated.ToString())
            {
                temp.FK_HREmployeeShareID = BOSApp.CurrentEmployeesInfo.HREmployeeID;
                temp.FK_HRDepartmentShareID = BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID;
            }
            else if (mode == TemplateShareMode.department.ToString())
            {
                temp.FK_HREmployeeShareID = 0;
                temp.FK_HRDepartmentShareID = BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID;
            }
            else
            {
                temp.FK_HREmployeeShareID = 0;
                temp.FK_HRDepartmentShareID = 0;
            }
            //_entity.UpdateMainObjectBindingSource();
        }
        #endregion

        public override void Search()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = SqlDatabaseHelper.RunStoredProcedure("METemplates_SearchByRole",
                    BOSApp.CurrentUserGroupInfo.ADUserGroupRole,
                    BOSApp.CurrentEmployeesInfo.HREmployeeID,
                    BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID);
                Toolbar.SetToolbar(ds);
                InvalidateAfterSearch(null, string.Empty);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void Duplicate()
        {
            var temp = _entity.MainObject.Clone() as METemplatesInfo;
            var copyNo = temp.METemplateNo;
            var fromID = temp.METemplateID;
            this.ActionNew();
            temp = (new METemplatesController()).GetObjectByID(fromID) as METemplatesInfo;
            temp.METemplateID = 0;
            temp.METemplateNo = temp.METemplateNo + ".1";
            temp.METemplateName = temp.METemplateName + ".1";
            temp.METemplateGuid = Guid.NewGuid().ToString();
            temp.AAUpdatedUser = null;
            temp.AAUpdatedDate = DateTime.MaxValue;
            _entity.MainObject = temp;
            _entity.UpdateMainObjectBindingSource();
            _entity.MEEmrTemplateActionList.Invalidate(fromID);
            foreach (var item in _entity.MEEmrTemplateActionList)
            {
                item.FK_METemplateID = 0;
                item.MEEmrTemplateActionID = 0;
            }
            _entity.MEEmrTemplateActionList.OriginalList.Clear();
            _entity.METemplateUserGroupList.Invalidate(fromID);
            foreach (var item in _entity.METemplateUserGroupList)
            {
                item.FK_METemplateID = 0;
                item.METemplateUserGroupID = 0;
            }
            _entity.METemplateUserGroupList.OriginalList.Clear();
            _entity.METemplateChartList.Clear();
            _entity.METemplateParamList.Clear();

            string templateNo = temp.METemplateNo;
            string pathTemplate = string.Format(@"{0}\Template\{1}.docx", TemplateServerPath, templateNo);
            try
            {
                FileTemplateManager fileMng = new FileTemplateManager();
                fileMng.DownloadFile("/Template/", copyNo + ".docx", pathTemplate);
                if (!File.Exists(pathTemplate))
                {
                    MessageBox.Show("File mẫu bệnh án không tồn tại ở địa chỉ. " + pathTemplate);
                    return;
                }
                _richEditCtrl.LoadDocument(pathTemplate);

                this._emrDocumentHelper.ClearGroupSelectParam(_richEditCtrl.Document, _richEditCtrl.Document.Range, temp.METemplateGuid);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        internal void InvalidateRefreshParams()
        {
            var ds = (new MEParamsController()).GetAllObjects();
            _entity.MEParamList.Invalidate(ds);
            _entity.MEParamList.GridControl.RefreshDataSource();
            _entity.MEParamList.GridControl.Refresh();
        }

        internal void InvalidateRefreshActions()
        {
            var ds = _actionsController.GetAllObjects();
            _entity.MEEmrActionList.Invalidate(ds);
            _entity.MEEmrActionList.GridControl.RefreshDataSource();
            _entity.MEEmrActionList.GridControl.Refresh();
        }

        internal void ShowParamCode()
        {
            this._emrDocumentHelper.ShowParamCode(_richEditCtrl.Document);
        }

        private void CheckKnownColor()
        {
            var entity = ((METemplateEntities)CurrentModuleEntity);
            var template = entity.MainObject as METemplatesInfo;
            var knownColor = false;
            var argb = Color.FromArgb(template.METemplateDgtSignatureTextColor);
            foreach (KnownColor kc in Enum.GetValues(typeof(KnownColor)))
            {
                Color known = Color.FromKnownColor(kc);
                if (argb.ToArgb() == known.ToArgb())
                {
                    knownColor = true;
                    break;
                }
            }
            if (!knownColor)
            {
                MessageBox.Show("Màu không hợp lệ");
            }
        }
        internal bool GetConfigHighlightModeEmrTagBorder()
        {
            return BOSApp.GetSystemConfigValue(DocumentProcess.GROUP, DocumentProcess.HIGHLIGHT_MODE_EMR_TAG_BORDER).ToUpper() == "TRUE";
        }
        internal bool GetConfigHighlightModeEmrTagFill()
        {
            return BOSApp.GetSystemConfigValue(DocumentProcess.GROUP, DocumentProcess.HIGHLIGHT_MODE_EMR_TAG_FILL).ToUpper() == "TRUE";
        }
    }
}