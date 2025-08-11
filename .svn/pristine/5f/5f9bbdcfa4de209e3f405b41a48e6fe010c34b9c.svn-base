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

namespace BOSERP.Modules.MEDocumentManage
{
    public class MEDocumentManageEntities : ERPModuleEntities
    {
        private readonly METemplatesController _templateCtrl;
        #region Declare Constant
        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public BOSList<MEEmrDocumentsInfo> MEEmrDocumentList { get; set; }

        public List<METemplatesInfo> METemplateList { get; set; }
        #endregion

        #region Constructor
        public MEDocumentManageEntities()
            : base()
        {
            MEEmrDocumentList = new BOSList<MEEmrDocumentsInfo>();
            METemplateList = new List<METemplatesInfo>();
            _templateCtrl = new METemplatesController();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitModuleObjectList()
        {
            MEEmrDocumentList.InitBOSList(this,
             TableName.MEEmrDocumentsTableName, 
             TableName.MEEmrDocumentsTableName,
              BOSList<MEEmrDocumentsInfo>.cstRelationNone);

            METemplateList = _templateCtrl.GetListBusinessObjects<METemplatesInfo>(_templateCtrl.GetAllObjects());
        }
        public override void InitMainObject()
        {
            MainObject = new MEEmrDocumentsInfo();
            SearchObject = new MEEmrDocumentsInfo();
        }
        #endregion
        public override void InitGridControlInBOSList()
        {
            MEEmrDocumentList.InitBOSListGridControl();
        }
        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                MEEmrDocumentList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
