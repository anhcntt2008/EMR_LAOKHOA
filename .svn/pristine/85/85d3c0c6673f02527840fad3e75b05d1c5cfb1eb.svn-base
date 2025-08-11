using System;
using System.Collections.Generic;
using System.Text;
using BOSCommon;
using System.Data;
using Clas.Emr.Model;
using BOSLib;
using System.ComponentModel;
using Emr;
using System.Linq;
using Clas.Business.EmrStore;

namespace BOSERP.Modules.MEEmr
{
    public class MEEmrEntities : ERPModuleEntities
    {
        private readonly MEEmrDocumentsController _documentCtrl;
        private readonly MEEmrShareHistoriesController _shareHistoryCtrl;
        private readonly MEEmrTransferHistoriesController _transferHistoryCtrl;
        private readonly MEEmrsController _emrCtrl;
        private readonly MEEmrDocumentSignsController _documentSignCtrl;
        private readonly EmrDocumentManager _mongoDocumentMan;
        private readonly METemplatesController _templateCtrl;
        private readonly GEObjectHistoryController _geoHistoryCtrl;

        #region Declare Constant
        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public MEPatientsInfo MEPatient = new MEPatientsInfo();
        public MEEmrList<MEEmrsInfo> MEEmrsList;
        public MEEmrDocumentsList<MEEmrDocumentsInfo> MEEmrDocumentsList { get; set; }

        public MEEmrDocumentsList<MEEmrDocumentSignsInfo> MEEmrDocumentSignsList { get; set; }
        public BOSList<MEPatientsInfo> MEPatientsSearchList { get; set; }
        public List<StethoscopeData> StethoscopesDataList { get; set; }
        public List<StethoscopeData> SelectedStethoscopesDataList { get; set; }

        public List<METemplatesInfo> METemplateList { get; internal set; }
        public MEEmrDocumentsInfo MENewEmrDocument { get; internal set; }
        public BOSList<MEEmrImageParamsInfo> MEImageParamList { get; set; }
        public BOSList<MEEmrTransferHistoriesInfo> MEEmrTranfersList { get; set; }
        public BOSList<MEEmrDocumentsInfo> MEEmrDocumentDataHistoriesList { get; set; }
        public BOSList<MEEmrAbbrevsInfo> MEEmrAbbrevList { get; set; }

        public BOSList<MEEmrShareHistoriesInfo> MEEmrShareList { get; set; }

        public METemplatesInfo METemplate { get; internal set; }
        public METemplatesInfo METemplatePrimaryHeader { get; internal set; }

        public MEEmrDocumentsList<MEEmrDocumentsInfo> MEEmrPatientDocumentsList { get; set; }

        private readonly ADSystemConfigsController _systemCfgCtrl;
        private readonly MEEmrTypesController _emrTypeCtrl;
        private List<ADSystemConfigsInfo> _emrProcessConfigs;

        public List<METemplateChartsInfo> TemplateChartList { get; internal set; }

        public BOSList<MEEmrArchivesInfo> MEEmrArchiveList { get; set; }

        public bool AllowSharingTheClosedEmr = false;

        public bool HideTheTempEmrOnQuickSearch = false;

        public bool AllowAccessAllTheEmrsOfPatientAtManageDept = false;

        public bool ModeShareEmrViewAll = false;
        #endregion

        #region Constructor
        public MEEmrEntities()
            : base()
        {
            MEEmrDocumentsList = new MEEmrDocumentsList<MEEmrDocumentsInfo>();
            MEPatientsSearchList = new BOSList<MEPatientsInfo>();
            StethoscopesDataList = new List<StethoscopeData>();
            MEEmrsList = new MEEmrList<MEEmrsInfo>();
            MEImageParamList = new BOSList<MEEmrImageParamsInfo>();
            MEEmrTranfersList = new BOSList<MEEmrTransferHistoriesInfo>();

            MEEmrDocumentDataHistoriesList = new MEEmrDocumentsList<MEEmrDocumentsInfo>();
            MEEmrDocumentSignsList = new MEEmrDocumentsList<MEEmrDocumentSignsInfo>();

            MEEmrAbbrevList = new BOSList<MEEmrAbbrevsInfo>();
            MEEmrShareList = new BOSList<MEEmrShareHistoriesInfo>();

            MEEmrPatientDocumentsList = new MEEmrDocumentsList<MEEmrDocumentsInfo>();

            _systemCfgCtrl = new ADSystemConfigsController();
            _emrTypeCtrl = new MEEmrTypesController();

            _emrCtrl = new MEEmrsController();
            _documentCtrl = new MEEmrDocumentsController();
            _shareHistoryCtrl = new MEEmrShareHistoriesController();
            _transferHistoryCtrl = new MEEmrTransferHistoriesController();
            _documentSignCtrl = new MEEmrDocumentSignsController();
            _mongoDocumentMan = new EmrDocumentManager();
            _templateCtrl = new METemplatesController();
            _geoHistoryCtrl = new GEObjectHistoryController();

            MEEmrArchiveList = new BOSList<MEEmrArchivesInfo>();

            AllowSharingTheClosedEmr = this.GetConfigAllowSharingTheClosedEmr();
            HideTheTempEmrOnQuickSearch = this.GetConfigHideTheTempEmrOnQuickSearch();
            AllowAccessAllTheEmrsOfPatientAtManageDept = this.GetConfigAccessAllTheEmrsOfPatientAtManageDept();
            ModeShareEmrViewAll = this.GetConfigModeShareEmrViewAll();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new MEEmrsInfo();
            SearchObject = new MEEmrsInfo();
        }
        #endregion
        public override int CreateMainObject()
        {
            var emr = this.MainObject as MEEmrsInfo;
            var editObjectNo = true;

            //Get Table which Business object Represent            
            var strMainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            var objMainObjectController =
                BusinessControllerFactory.GetBusinessController(strMainObjectTableName + "Controller");

            //Set Object No value
            var strPrimaryColumn = strMainObjectTableName.Substring(0, strMainObjectTableName.Length - 1) + "ID";
            var strColumnNo = strMainObjectTableName.Substring(0, strMainObjectTableName.Length - 1) + "No";
            var strMainObjectNo = _dbUtil.GetPropertyStringValue(MainObject, strColumnNo);
            var numberingStart = 0;
            if (strMainObjectNo.Equals(cstNewObjectText))
            {
                editObjectNo = false;
                strMainObjectNo = GetMainObjectNo(ref numberingStart);


                var emrType = _emrTypeCtrl.GetObjectByID(emr.FK_MEEmrTypeID) as MEEmrTypesInfo;
                if (emrType.MEEmrTypeIsTmp)
                {
                    var prefix = _emrProcessConfigs.Where(c => c.ADSystemConfigKey == EmrProcess.EMR_TYPE_TEMPORARY_PREFIX_NO).FirstOrDefault();
                    if (prefix != null && !string.IsNullOrEmpty(prefix.ADSystemConfigValue))
                    {
                        if (!strMainObjectNo.StartsWith(prefix.ADSystemConfigValue))
                            strMainObjectNo = prefix.ADSystemConfigValue + strMainObjectNo;
                    }
                }

                _dbUtil.SetPropertyValue(MainObject, strColumnNo, strMainObjectNo);
            }

            //Set Created User, Created Date
            _dbUtil.SetPropertyValue(MainObject, AACreatedUser, BOSApp.CurrentUser);
            _dbUtil.SetPropertyValue(MainObject, AACreatedDate, DateTime.Now);


            var iObjectId = _dbUtil.GetPropertyIntValue(MainObject, strPrimaryColumn);
            if (iObjectId == 0)
                iObjectId = objMainObjectController.CreateObject(MainObject);
            else
                objMainObjectController.CreateObject(MainObject, iObjectId);

            if (iObjectId <= 0) return iObjectId;
            if (!editObjectNo)
                UpdateObjectNumbering(numberingStart);

            var strMainObjectPrimaryColumnName = _dbUtil.GetTablePrimaryColumn(strMainObjectTableName);
            _dbUtil.SetPropertyValue(MainObject, strMainObjectPrimaryColumnName, iObjectId);

            return iObjectId;
        }
        public override int SaveMainObject()
        {
            return base.SaveMainObject();
        }
        public override void Invalidate(int iObjectID)
        {
            base.Invalidate(iObjectID);
        }

        public override void InvalidateMainObject(int iObjectId)
        {
            base.InvalidateMainObject(iObjectId);
        }

        public override void InitModuleObjects()
        {
            base.InitModuleObjects();
            ModuleObjects.Add(TableName.MEEmrDocumentsTableName, new MEEmrDocumentsInfo());
            ModuleObjects.Add(TableName.MEEmrImagesTableName, new MEEmrImagesInfo());
            ModuleObjects.Add(TableName.MEEmrImageParamsTableName, new MEEmrImageParamsInfo());
            ModuleObjects.Add(TableName.MEEmrTransferHistoriesTableName, new MEEmrTransferHistoriesInfo());
            ModuleObjects.Add(TableName.MEEmrShareHistoriesTableName, new MEEmrShareHistoriesInfo());
            ModuleObjects.Add(TableName.MEPatientsTableName, new MEPatientsInfo());

            ModuleObjects.Add(TableName.GEObjectHistoryTableName, new GEObjectHistoryInfo());
            //PatientProfile
            ModuleObjects.Add(TableName.MEEmrsTableName, new MEEmrsInfo());
            ModuleObjects.Add(TableName.MEEmrDocumentNotesTableName, new MEEmrDocumentNotesInfo());

        }
        public override void ModuleObject_OnChanged(object sender, PropertyChangedEventArgs e)
        {
            if ((sender is MEEmrImageParamsInfo)) return;
            if ((sender is MEEmrDocumentsInfo)) return;
            if ((sender is MEEmrTransferHistoriesInfo)) return;
            base.ModuleObject_OnChanged(sender, e);
        }
        public override void InitModuleObjectList()
        {
            base.InitModuleObjectList();
            MEEmrDocumentsList.InitBOSList(this,
               TableName.MEEmrsTableName,
               TableName.MEEmrDocumentsTableName,
                BOSList<MEEmrDocumentsInfo>.cstRelationForeign);
            MEEmrDocumentsList.ItemTableForeignKey = "FK_MEEmrID";


            MEEmrPatientDocumentsList.InitBOSList(this,
               TableName.MEEmrsTableName,
               TableName.MEEmrDocumentsTableName,
               BOSList<MEEmrDocumentsInfo>.cstRelationNone);
            //MEEmrPatientDocumentsList.ItemTableForeignKey = "FK_MEEmrID";

            MEPatientsSearchList.InitBOSList(this,
             TableName.MEEmrsTableName,
             TableName.MEPatientsTableName,
              BOSList<MEPatientsInfo>.cstRelationNone);

            MEEmrsList.InitBOSList(this,
              TableName.MEPatientsTableName,
              TableName.MEEmrsTableName,
               BOSList<MEEmrsInfo>.cstRelationNone);

            MEImageParamList.InitBOSList(this,
            TableName.MEEmrImagesTableName,
            TableName.MEEmrImageParamsTableName,
             BOSList<MEEmrImageParamsInfo>.cstRelationForeign);
            MEImageParamList.ItemTableForeignKey = "FK_MEEmrImageID";

            MEEmrTranfersList.InitBOSList(this,
              TableName.MEEmrsTableName,
              TableName.MEEmrTransferHistoriesTableName,
               BOSList<MEEmrTransferHistoriesInfo>.cstRelationForeign);
            MEEmrTranfersList.ItemTableForeignKey = "FK_MEEmrID";

            MEEmrDocumentDataHistoriesList.InitBOSList(this,
             TableName.MEEmrsTableName,
             TableName.MEEmrDocumentsTableName,
              BOSList<MEEmrDocumentsInfo>.cstRelationForeign);
            MEEmrDocumentDataHistoriesList.ItemTableForeignKey = "FK_MEEmrID";

            MEEmrDocumentSignsList.InitBOSList(this,
             TableName.MEEmrDocumentsTableName,
             TableName.MEEmrDocumentSignsTableName,
              BOSList<MEEmrDocumentSignsInfo>.cstRelationForeign);
            MEEmrDocumentSignsList.ItemTableForeignKey = "FK_MEEmrDocumentID";

            MEEmrAbbrevList.InitBOSList(this, TableName.HREmployeesTableName,
                                            TableName.MEEmrAbbrevsTableName,
                                            BOSList<MEEmrAbbrevsInfo>.cstRelationForeign);
            MEEmrAbbrevList.ItemTableForeignKey = "FK_HREmployeeID";

            MEEmrShareList.InitBOSList(this,
             TableName.MEEmrsTableName,
             TableName.MEEmrShareHistoriesTableName,
             BOSList<MEEmrShareHistoriesInfo>.cstRelationForeign);
            MEEmrShareList.ItemTableForeignKey = "FK_MEEmrID";

            MEEmrArchiveList.InitBOSList(this,
            TableName.MEEmrsTableName,
            TableName.MEEmrArchivesTableName,
             BOSList<MEEmrArchivesInfo>.cstRelationForeign);
            MEEmrArchiveList.ItemTableForeignKey = "FK_MEEmrID";
        }
        public override void InitGridControlInBOSList()
        {
            MEEmrDocumentsList.InitBOSListGridControl();
            MEEmrsList.InitBOSListGridControl();
            MEImageParamList.InitBOSListGridControl();
            MEEmrTranfersList.InitBOSListGridControl();
            MEEmrDocumentDataHistoriesList.InitBOSListGridControl("fld_dgcEmrDocumentsDataHistory");
            MEEmrDocumentSignsList.InitBOSListGridControl();
            MEEmrShareList.InitBOSListGridControl();

            MEEmrPatientDocumentsList.InitBOSListGridControl("fld_dgcEmrPatientDocuments");
            MEEmrArchiveList.InitBOSListGridControl();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                MEEmrDocumentsList.SetDefaultListAndRefreshGridControl();
                MEEmrsList.SetDefaultListAndRefreshGridControl();
                MEImageParamList.SetDefaultListAndRefreshGridControl();
                MEEmrTranfersList.SetDefaultListAndRefreshGridControl();
                MEEmrDocumentDataHistoriesList.SetDefaultListAndRefreshGridControl();
                MEEmrDocumentSignsList.SetDefaultListAndRefreshGridControl();
                MEEmrShareList.SetDefaultListAndRefreshGridControl();

                MEEmrPatientDocumentsList.SetDefaultListAndRefreshGridControl();
                MEEmrArchiveList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception)
            {
                return;
            }
        }
        public override void InvalidateModuleObject(BusinessObject obj)
        {
            base.InvalidateModuleObject(obj);
        }
        public override void InvalidateModuleObjects(int iObjectID)
        {
            MEEmrTranfersList.Invalidate(iObjectID);
            MEEmrShareList.Invalidate(iObjectID);
        }

        public override void SaveModuleObjects()
        {
            base.SaveModuleObjects();
            MEEmrTranfersList.SaveItemObjects();
            MEEmrShareList.SaveItemObjects();
        }
        public override void MainObject_OnChanged(object sender, PropertyChangedEventArgs e)
        {
            base.MainObject_OnChanged(sender, e);
        }
        #region System Config
        public List<ADSystemConfigsInfo> GetEmrProcessSystemConfigs()
        {
            _emrProcessConfigs = _systemCfgCtrl.GetListByGroups($"'{EmrProcess.GROUP}'");
            return _emrProcessConfigs;
        }
        public int GetConfigMaxCountEmrPerPatient(string type)
        {
            var count = _emrProcessConfigs.Where(c => c.ADSystemConfigKey == $"{EmrProcess.EMR_TYPE_MAX_COUNT}_{type.ToString().ToUpper()}").FirstOrDefault();
            if (count != null)
            {
                if (int.TryParse(count.ADSystemConfigValue, out int value))
                    return value;
            }
            return 0;
        }
        public string GetRelativeEmrNo(string emrNo)
        {
            // benh an tam tu them EMR_TYPE_TEMPORARY_PREFIX_NO vao truoc
            var prefix = _emrProcessConfigs.Where(c => c.ADSystemConfigKey == EmrProcess.EMR_TYPE_TEMPORARY_PREFIX_NO).FirstOrDefault();
            if (prefix != null && emrNo.StartsWith(prefix.ADSystemConfigValue))
            {
                return emrNo.Substring(prefix.ADSystemConfigValue.Length);
            }
            return emrNo;
        }
        public override void DeleteObjectRelations(string strTableName, int iObjectID)
        {
            if (strTableName == TableName.MEEmrsTableName)
            {
                var documents = _documentCtrl.GetByEmrId(iObjectID);
                foreach (var item in documents)
                {
                    _documentSignCtrl.DeleteByForeignColumn("FK_MEEmrDocumentID", item.MEEmrDocumentID);

                    if (string.IsNullOrEmpty(item.MEEmrDocumentMongoID)) continue;
                    var template = _templateCtrl.GetObjectByID(item.FK_METemplateID) as METemplatesInfo;
                    if (template != null)
                        _mongoDocumentMan.Delete(item.MEEmrDocumentMongoID, template.METemplateNo, BOSApp.CurrentUsersInfo.ADUserName);
                }
                _documentCtrl.DeleteByForeignColumn("FK_MEEmrID", iObjectID);
                _shareHistoryCtrl.DeleteByForeignColumn("FK_MEEmrID", iObjectID);
                _transferHistoryCtrl.DeleteByForeignColumn("FK_MEEmrID", iObjectID);
            }
        }

        internal string GetConfigCustomRuleForNewEmr()
        {
            var sp = _emrProcessConfigs.Where(c => c.ADSystemConfigKey == EmrProcess.EMR_SP_CUSTOM_RULE_FOR_NEW).FirstOrDefault();
            if (sp != null)
            {
                return sp.ADSystemConfigValue;
            }
            return string.Empty;
        }
        internal bool GetConfigAllowEditOuterEmrTag()
        {
            return BOSApp.GetSystemConfigValue(DocumentProcess.GROUP, DocumentProcess.ALLOW_EDIT_OUTER_EMR_TAG).ToUpper() == "TRUE";
        }
        internal bool GetConfigNotAllowCopyEmrTag()
        {
            return BOSApp.GetSystemConfigValue(DocumentProcess.GROUP, DocumentProcess.NOT_ALLOW_COPY_EMR_TAG).ToUpper() == "TRUE";
        }
        internal bool GetConfigHighlightModeEmrTagBorder()
        {
            return BOSApp.GetSystemConfigValue(DocumentProcess.GROUP, DocumentProcess.HIGHLIGHT_MODE_EMR_TAG_BORDER).ToUpper() == "TRUE";
        }
        internal bool GetConfigHighlightModeEmrTagFill()
        {
            return BOSApp.GetSystemConfigValue(DocumentProcess.GROUP, DocumentProcess.HIGHLIGHT_MODE_EMR_TAG_FILL).ToUpper() == "TRUE";
        }
        internal bool GetConfigAllowNormalUserHideDocument()
        {
            return BOSApp.GetSystemConfigValue(DocumentProcess.GROUP, DocumentProcess.ALLOW_NORMAL_USER_HIDE_DOCUMENT).ToUpper() == "TRUE";
        }
        internal bool GetConfigAllowSharingTheClosedEmr()
        {
            return BOSApp.GetSystemConfigValue(EmrProcess.GROUP, EmrProcess.ALLOW_SHARING_THE_CLOSED_EMR).ToUpper() == "TRUE";
        }
        internal bool GetConfigHideTheTempEmrOnQuickSearch()
        {
            return BOSApp.GetSystemConfigValue(EmrProcess.GROUP, EmrProcess.HIDE_THE_TEMP_EMR_ON_QUICK_SEARCH).ToUpper() == "TRUE";
        }
        internal bool GetConfigAccessAllTheEmrsOfPatientAtManageDept()
        {
            return BOSApp.GetSystemConfigValue(EmrProcess.GROUP, EmrProcess.ALLOW_MANAGE_DEPT_ACCESS_ALL_THE_EMRS_OF_PATIENT).ToUpper() == "TRUE";
        }
        internal bool GetConfigPagePainterVersion()
        {
            return BOSApp.GetSystemConfigValue(SysCfgConsts.SYSTEM_CONFIGS, SysCfgConsts.SYSTEM_CONFIGS_PAGE_PAINTER_VER).ToUpper() == "V2";
        }
        internal string GetConfigPagePrintPainterVersion()
        {
            return BOSApp.GetSystemConfigValue(SysCfgConsts.SYSTEM_CONFIGS, SysCfgConsts.SYSTEM_CONFIGS_PAGE_PRINT_PAINTER_VER)?.ToUpper();
        }
        internal int GetConfigDaysRemainCloseEmr()
        {
            return BOSApp.GetSystemConfigValueInt(EmrProcess.GROUP, EmrProcess.DAYS_REMAIN_FORGET_RECLOSE_EMR, 0);
        }
        internal bool GetConfigFingerPrintHashWatermark()
        {
            var value = BOSApp.GetSystemConfigValue(DocumentProcess.GROUP, DocumentProcess.FINGER_PRINT_HASH_WATERMARK);
            if (string.IsNullOrEmpty(value)) return true;
            return value.ToUpper() == "TRUE";
        }
        internal bool GetConfigModeShareEmrViewAll()
        {
            return BOSApp.GetSystemConfigValue(EmrProcess.GROUP, EmrProcess.MODE_SHARE_EMR_VIEW_ALL).ToUpper() == "TRUE";
        }
        #endregion
    }
}
