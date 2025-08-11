using System;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOSLib;
using BOSCommon;

namespace BOSERP.Modules.MEImageLib
{
    public class MEImageLibEntities : ERPModuleEntities
    {
        #region Declare Constant

        #endregion

        #region Declare all entities variables
        #endregion

        #region Public Properties
        public BOSList<MEEmrImagesInfo> MEEmrImageList { get; set; }
        public BOSList<MEEmrImagePatternsInfo> MEEmrImagePatternList { get; set; }
        public BOSList<MEEmrImageParamsInfo> MEEmrImageParamsList { get; set; }

        #endregion

        #region Constructor
        public MEImageLibEntities()
            : base()
        {
            MEEmrImageList = new BOSList<MEEmrImagesInfo>();
            MEEmrImagePatternList = new BOSList<MEEmrImagePatternsInfo>();
            MEEmrImageParamsList = new BOSList<MEEmrImageParamsInfo>();
        }
        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new MEEmrGroupImagesInfo();
            SearchObject = new MEEmrGroupImagesInfo();
        }

        public override void InitModuleObjects()
        {
            ModuleObjects.Add(TableName.MEEmrImagesTableName, new MEEmrImagesInfo());
            ModuleObjects.Add(TableName.MEEmrImagePatternsTableName, new MEEmrImagePatternsInfo());
            ModuleObjects.Add(TableName.MEEmrImageParamsTableName, new MEEmrImageParamsInfo());
        }

        public override void InitModuleObjectList()
        {
            MEEmrImageList.InitBOSList(this,
                                               TableName.MEEmrGroupImagesTableName,
                                               TableName.MEEmrImagesTableName,
                                               BOSList<MEEmrImagesInfo>.cstRelationForeign);
            MEEmrImageList.ItemTableForeignKey = "FK_MEEmrGroupImageID";

            MEEmrImagePatternList.InitBOSList(this,
                                             TableName.MEEmrImagesTableName,
                                             TableName.MEEmrImagePatternsTableName,
                                             BOSList<MEEmrImagePatternsInfo>.cstRelationForeign);
            MEEmrImagePatternList.ItemTableForeignKey = "FK_MEEmrImageID";

            MEEmrImageParamsList.InitBOSList(this,
                                          TableName.MEEmrImagesTableName,
                                          TableName.MEEmrImageParamsTableName,
                                          BOSList<MEEmrImageParamsInfo>.cstRelationForeign);
            MEEmrImageParamsList.ItemTableForeignKey = "FK_MEEmrImageID";
        }

        public override void InitGridControlInBOSList()
        {
            MEEmrImageList.InitBOSListGridControl();
            MEEmrImagePatternList.InitBOSListGridControl();
            MEEmrImageParamsList.InitBOSListGridControl();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                MEEmrImageList.SetDefaultListAndRefreshGridControl();
                MEEmrImagePatternList.SetDefaultListAndRefreshGridControl();
                MEEmrImageParamsList.SetDefaultListAndRefreshGridControl();
            }
            catch (Exception)
            {
                return;
            }
        }
        #endregion

        #region Invalidate Module Objects functions
        public override void InvalidateModuleObjects(int iObjectID)
        {
            MEEmrImageList.Invalidate(iObjectID);
        }
        #endregion

        public override void SaveModuleObjects()
        {
            MEEmrImageList.SaveItemObjects();
            var img = ModuleObjects[TableName.MEEmrImagesTableName] as MEEmrImagesInfo;
            foreach (var item in MEEmrImagePatternList)
            {
                item.FK_MEEmrImageID = img.MEEmrImageID;
            }
            MEEmrImagePatternList.SaveItemObjects();

            foreach (var item in MEEmrImageParamsList)
            {
                item.FK_MEEmrImageID = img.MEEmrImageID;
            }
            MEEmrImageParamsList.SaveItemObjects();
        }
    }
}
