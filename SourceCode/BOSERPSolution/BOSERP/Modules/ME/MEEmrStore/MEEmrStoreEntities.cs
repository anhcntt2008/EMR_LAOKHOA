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

namespace BOSERP.Modules.MEEmrStore
{
    public class MEEmrStoreEntities : ERPModuleEntities
    {
        private readonly MEEmrDocumentsController _documentCtrl;
        private readonly MEEmrShareHistoriesController _shareHistoryCtrl;
        private readonly MEEmrTransferHistoriesController _transferHistoryCtrl;
        private readonly MEEmrsController _emrCtrl;
        private readonly MEEmrDocumentSignsController _documentSignCtrl;
        private readonly EmrDocumentManager _mongoDocumentMan;
        private readonly METemplatesController _templateCtrl;

        #region Declare Constant
        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public BOSList<MEEmrArchivesInfo> MEEmrArchiveList { get; set; }
        public BOSList<MEEmrsInfo> MEEmrList { get; set; }
        public List<METemplatesInfo> METemplateList { get; set; }

        #endregion

        #region Constructor
        public MEEmrStoreEntities()
            : base()
        {
            MEEmrArchiveList = new BOSList<MEEmrArchivesInfo>();
            MEEmrList = new BOSList<MEEmrsInfo>();
            METemplateList = new List<METemplatesInfo>();
            _emrCtrl = new MEEmrsController();
            _documentCtrl = new MEEmrDocumentsController();
            _shareHistoryCtrl = new MEEmrShareHistoriesController();
            _transferHistoryCtrl = new MEEmrTransferHistoriesController();
            _documentSignCtrl = new MEEmrDocumentSignsController();
            _mongoDocumentMan = new EmrDocumentManager();
            _templateCtrl = new METemplatesController();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitModuleObjectList()
        {
            MEEmrArchiveList.InitBOSList(this,
             TableName.MEEmrArchivesTableName,
             TableName.MEEmrArchivesTableName,
              BOSList<MEEmrArchivesInfo>.cstRelationNone);

            //MEEmrList.InitBOSList(this,
            // TableName.MEEmrsTableName,
            // TableName.MEEmrsTableName,
            //  BOSList<MEEmrsInfo>.cstRelationNone);

            //METemplateList = _templateCtrl.GetListBusinessObjects<METemplatesInfo>(_templateCtrl.GetAllObjects());
        }
        public override void InitMainObject()
        {
            MainObject = new MEEmrArchivesInfo();
            SearchObject = new MEEmrArchivesInfo();
            //MainObject = new MEEmrsInfo();
            //SearchObject = new MEEmrsInfo();
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
            MEEmrArchiveList.InitBOSListGridControl();
            //MEEmrList.InitBOSListGridControl();
        }
        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                MEEmrArchiveList.SetDefaultListAndRefreshGridControl();
                //MEEmrList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
