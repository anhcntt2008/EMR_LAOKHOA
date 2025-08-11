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

namespace BOSERP.Modules.MEEmrManage
{
    public class MEEmrManageEntities : ERPModuleEntities
    {
        private readonly MEEmrDocumentsController _documentCtrl;
        private readonly MEEmrShareHistoriesController _shareHistoryCtrl;
        private readonly MEEmrTransferHistoriesController _transferHistoryCtrl;
        private readonly MEEmrsController _emrCtrl;
        private readonly MEEmrDocumentSignsController _documentSignCtrl;
        private readonly EmrDocumentManager _mongoDocumentMan;
        private readonly METemplatesController _templateCtrl;
        private GEObjectHistoryController _geObjHistoryCtrl;

        #region Declare Constant
        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public BOSList<MEEmrsInfo> MEEmrList { get; set; }
        public List<METemplatesInfo> METemplateList { get; set; }

        public List<GEObjectHistoryInfo> GEObjectHistoryList { get; set; }

        public BOSList<MEEmrSumsInfo> MEEmrSumList { get; set; }
        #endregion

        #region Constructor
        public MEEmrManageEntities()
            : base()
        {
            MEEmrList = new BOSList<MEEmrsInfo>();
            METemplateList = new List<METemplatesInfo>();
            GEObjectHistoryList = new List<GEObjectHistoryInfo>();
            MEEmrSumList = new BOSList<MEEmrSumsInfo>();

            _emrCtrl = new MEEmrsController();
            _documentCtrl = new MEEmrDocumentsController();
            _shareHistoryCtrl = new MEEmrShareHistoriesController();
            _transferHistoryCtrl = new MEEmrTransferHistoriesController();
            _documentSignCtrl = new MEEmrDocumentSignsController();
            _mongoDocumentMan = new EmrDocumentManager();
            _templateCtrl = new METemplatesController();
            _geObjHistoryCtrl = new GEObjectHistoryController();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitModuleObjectList()
        {
            MEEmrList.InitBOSList(this,
             TableName.MEEmrsTableName,
             TableName.MEEmrsTableName,
              BOSList<MEEmrsInfo>.cstRelationNone);

            METemplateList = _templateCtrl.GetListBusinessObjects<METemplatesInfo>(_templateCtrl.GetAllObjects());

            GEObjectHistoryList = _templateCtrl.GetListBusinessObjects<GEObjectHistoryInfo>(_geObjHistoryCtrl.GetGEObjectHistoryByObjectName(TableName.MEEmrsTableName));

            MEEmrSumList.InitBOSList(this,
             TableName.MEEmrSumsTableName,
             TableName.MEEmrSumsTableName,
              BOSList<MEEmrSumsInfo>.cstRelationNone);
        }
        public override void InitMainObject()
        {
            MainObject = new MEEmrsInfo();
            SearchObject = new MEEmrsInfo();
        }
        #endregion
        public override int SaveMainObject()
        {
            return base.SaveMainObject();
        }
        public override void Invalidate(int iObjectID)
        {
            base.Invalidate(iObjectID);
        }
        public override void InitModuleObjects()
        {
            base.InitModuleObjects();

        }
        public override void InitGridControlInBOSList()
        {
            MEEmrList.InitBOSListGridControl();
            MEEmrSumList.InitBOSListGridControl();
        }
        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                MEEmrList.SetDefaultListAndRefreshGridControl();
                MEEmrSumList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception)
            {
                return;
            }
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
                    var template = METemplateList.Where(t => t.METemplateID == item.FK_METemplateID).FirstOrDefault();
                    if (template != null)
                        _mongoDocumentMan.Delete(item.MEEmrDocumentMongoID, template.METemplateNo, BOSApp.CurrentUsersInfo.ADUserName);
                }
                _documentCtrl.DeleteByForeignColumn("FK_MEEmrID", iObjectID);
                _shareHistoryCtrl.DeleteByForeignColumn("FK_MEEmrID", iObjectID);
                _transferHistoryCtrl.DeleteByForeignColumn("FK_MEEmrID", iObjectID);
            }
        }
    }
}
