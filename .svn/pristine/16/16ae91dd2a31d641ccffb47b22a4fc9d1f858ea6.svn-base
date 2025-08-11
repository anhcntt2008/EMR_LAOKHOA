using System;
using System.Collections.Generic;
using System.Text;
using BOSCommon;
using BOSLib;
using System.Linq;
using System.Windows.Forms;

namespace BOSERP.Modules.MEService
{
    public class MEServiceEntities : ERPModuleEntities
    {
        #region Declare Constant
        
        #endregion
        
        #region Declare all entities variables
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the category list of services
        /// </summary>
        public BOSTreeList ICProductGroupList { get; set; }

        /// <summary>
        /// Gets or sets the list of product employee (commission)
        /// </summary>
        public BOSList<ICProductEmployeesInfo> ICProductEmployeeList { get; set; }

        #endregion

        #region Constructor
        public MEServiceEntities()
            : base()
        {
            ICProductGroupList = new BOSTreeList();
            ICProductEmployeeList = new BOSList<ICProductEmployeesInfo>();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new ICDepartmentsInfo();
        }

        public override void InitModuleObjects()
        {
            ModuleObjects.Add(TableName.ICProductGroupsTableName, new ICProductGroupsInfo());
            ICProductEmployeeList.InitBOSList(
                                            this,
                                            string.Empty,
                                            TableName.ICProductEmployeesTableName,
                                            BOSList<ICProductEmployeesInfo>.cstRelationNone);
        }

        public override void InitModuleObjectList()
        {
            ICProductGroupList.InitBOSList(this,
                                    TableName.ICDepartmentsTableName,
                                    TableName.ICProductGroupsTableName,
                                    BOSTreeList.cstRelationForeign);           
        }

        public override void InitGridControlInBOSList()
        {
            ICProductGroupList.InitBOSTreeListControl();
            ICProductEmployeeList.InitBOSListGridControl();
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                ICProductGroupList.SetDefaultListAndRefreshTreeListControl();
            }
            catch (Exception)
            {
                return;
            }
        }

        #endregion

        #region Invalidate Module Objects functions
        public override void InvalidateMainObject(int iObjectID)
        {
            base.InvalidateMainObject(iObjectID);
        }

        public override void InvalidateModuleObjects(int iObjectID)
        {
            ICProductGroupList.InvalidateTreeList(iObjectID);
            ICProductGroupList.TreeListControl.Columns["ICProductGroupName"].SortOrder = SortOrder.Ascending;
        }
        #endregion

        #region Save Module Objects functions
        public override void SaveModuleObjects()
        {
                   
        }

        /// <summary>
        /// Save product service list
        /// </summary>
        public void SaveProductServiceList()
        {
            ServiceGridControl serviceGridControl = (ServiceGridControl)Module.Controls[MEServiceModule.ServiceGridControlName];
            ICProductGroupsInfo objProductGroupsInfo = (ICProductGroupsInfo)ModuleObjects[TableName.ICProductGroupsTableName];
            // Invalidate product list
            if (objProductGroupsInfo.ICProductList == null)
            {
                objProductGroupsInfo.ICProductList = new BOSList<ICProductsInfo>();
                objProductGroupsInfo.ICProductList.InitBOSList(
                                                            this,
                                                            TableName.ICProductGroupsTableName,
                                                            TableName.ICProductsTableName,
                                                            BOSList<ICProductsInfo>.cstRelationForeign);
                ((BOSList<ICProductsInfo>)objProductGroupsInfo.ICProductList).GridControl = serviceGridControl;
                if (objProductGroupsInfo.ICProductGroupID > 0)
                {
                    objProductGroupsInfo.ICProductList.Invalidate(objProductGroupsInfo.ICProductGroupID);
                }
            }

            if (objProductGroupsInfo.ICProductList != null)
            {
                GENumberingInfo objNumberingInfo;
                int numberingStart = 0;
                int numberingLength;

                GENumberingController objNumberingController = new GENumberingController();
                List<GENumberingInfo> nuberingList = objNumberingController.GetNumberingListByName(Module.Name);
                objNumberingInfo = nuberingList[0];
                numberingStart = objNumberingInfo.GENumberingStart;
                numberingLength = objNumberingInfo.GENumberingLength;
                
                foreach (ICProductsInfo objProductsInfo in objProductGroupsInfo.ICProductList)
                {
                    objProductsInfo.FK_ICDepartmentID = objProductGroupsInfo.FK_ICDepartmentID;
                    objProductsInfo.FK_ICProductGroupID = objProductGroupsInfo.ICProductGroupID;
                    if (objProductsInfo.ICProductDesc ==null || objProductsInfo.ICProductDesc.Trim()=="")
                    objProductsInfo.ICProductDesc = objProductsInfo.ICProductName;
                    objProductsInfo.ICProductType = ProductType.Service.ToString();

                    //Generate No for case create new
                    if (objProductsInfo.ICProductID == 0)
                    {
                        string productNo = string.Empty;
                        productNo = objProductGroupsInfo.ICProductGroupNo + "-";
                        productNo += numberingStart.ToString().PadLeft(numberingLength, '0');

                        objProductsInfo.ICProductNo = productNo;

                        numberingStart++;
                    }
                    
                }
                objProductGroupsInfo.ICProductList.SaveItemObjects();

                //Update numbering
                if (numberingStart > 0)
                {
                    UpdateNumbering(numberingStart);
                }
                
            }
        }

        private void UpdateNumbering(int numberingStart)
        {
            GENumberingInfo objNumberingInfo;

            GENumberingController objNumberingController = new GENumberingController();
            List<GENumberingInfo> nuberingList = objNumberingController.GetNumberingListByName(Module.Name);
            objNumberingInfo = nuberingList[0];
            objNumberingInfo.GENumberingStart = numberingStart;

            objNumberingController.UpdateObject(objNumberingInfo);
        }

        /// <summary>
        /// Save product service group
        /// </summary>
        /// <param name="objProductGroupsInfo">The product service group object</param>
        public int SaveServiceGroup(ICProductGroupsInfo objProductGroupsInfo)
        {
            ICProductGroupsController objProductGroupsController = new ICProductGroupsController();
            int productGroupID = 0;
            if (objProductGroupsInfo.ICProductGroupID == 0)
            {
                productGroupID = objProductGroupsController.CreateObject(objProductGroupsInfo);
            }
            else
                productGroupID = objProductGroupsController.UpdateObject(objProductGroupsInfo);
            return productGroupID;
        }

        /// <summary>
        /// Delete product service group
        /// </summary>
        /// <param name="objProductGroupsInfo">The product service group object</param>
        public void DeleteServiceGroup(ICProductGroupsInfo objProductGroupsInfo)
        {
            ICProductGroupsController objProductGroupsController = new ICProductGroupsController();
            objProductGroupsController.DeleteObject(objProductGroupsInfo.ICProductGroupID);

            ICProductsController objProductCtrl = new ICProductsController();
            if (objProductGroupsInfo.ICProductList != null)
            {
                foreach (ICProductsInfo item in objProductGroupsInfo.ICProductList)
                {
                    objProductCtrl.DeleteObject(item.ICProductID);
                }
            }
        }
        #endregion
    }
}
