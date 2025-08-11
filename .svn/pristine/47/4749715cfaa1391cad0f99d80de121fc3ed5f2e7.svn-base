using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BOSCommon;
using BOSLib;
using Localization;

namespace BOSERP
{
    public class ServiceTreeList : BOSTreeList
    {
        public override void InvalidateTreeList(int iObjectID)
        {
            base.InvalidateTreeList(iObjectID);

            AddServicesToList(this);

            AddPackagesToList();
        }
        /*
         Lọc SP theo BHYT
         */
        public void InvalidateFilterTreeList(int iObjectID, int companyID, int insLevelID)
        {
            base.InvalidateTreeList(iObjectID);

            AddFilterServicesToList(this, companyID, insLevelID);

            AddPackagesToList(companyID, insLevelID);
        }
        private void AddFilterServicesToList(IBOSTreeList list, int companyID, int insLevelID)
        {
            ICProductsController objProductsController = new ICProductsController();
            ICProductGroupsInfo service;
            List<ICProductsInfo> productList;
            foreach (ICProductGroupsInfo objProductGroupsInfo in list)
            {
                if (objProductGroupsInfo.HasChildren())
                {
                    AddFilterServicesToList(objProductGroupsInfo.SubList, companyID, insLevelID);
                }

                productList = objProductsController.GetProductByCompanyIDAndInsLevelIDAndProductGroupID(companyID, insLevelID, objProductGroupsInfo.ICProductGroupID);
                if (productList != null && productList.Count > 0)
                {
                    foreach (ICProductsInfo objProductsInfo in productList)
                    {
                        if (objProductsInfo.ICProductActiveCheck)
                        {
                            service = new ICProductGroupsInfo();
                            service.ICProductGroupID = objProductsInfo.ICProductID;
                            service.ICProductGroupName = objProductsInfo.ICProductName;
                            service.IsService = true;
                            objProductGroupsInfo.SubList.Add(service);
                        }
                    }
                }
            }
        }

        private void AddPackagesToList(int companyID, int insLevelID)
        {
            ICProductGroupsInfo packageGroup = new ICProductGroupsInfo(CommonLocalizedResources.Package);
            packageGroup.SubList = new BOSTreeList();
            Add(packageGroup);
            ICProductsController objProductsController = new ICProductsController();
            List<ICProductsInfo> productList = objProductsController.GetProductsByTypeAndCompanyIDAndInsLevelID(ProductType.Package.ToString(), companyID, insLevelID);

            foreach (ICProductsInfo objProductsInfo in productList)
            {
                ICProductGroupsInfo service = new ICProductGroupsInfo();
                service.ICProductGroupID = objProductsInfo.ICProductID;
                service.ICProductGroupName = objProductsInfo.ICProductName;
                packageGroup.SubList.Add(service);
            }
        }


        private void AddServicesToList(IBOSTreeList list)
        {
            ICProductsController objProductsController = new ICProductsController();
            ICProductsInfo objProductsInfo;
            ICProductGroupsInfo service;
            foreach (ICProductGroupsInfo objProductGroupsInfo in list)
            {
                if (objProductGroupsInfo.HasChildren())
                {
                    AddServicesToList(objProductGroupsInfo.SubList);
                }
                DataSet ds = objProductsController.GetAllDataByForeignColumn("FK_ICProductGroupID", objProductGroupsInfo.ICProductGroupID);
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        objProductsInfo = (ICProductsInfo)objProductsController.GetObjectFromDataRow(row);
                        if (objProductsInfo.ICProductActiveCheck)
                        {
                            service = new ICProductGroupsInfo();
                            service.ICProductGroupID = objProductsInfo.ICProductID;
                            service.ICProductGroupName = objProductsInfo.ICProductName;
                            service.IsService = true;
                            objProductGroupsInfo.SubList.Add(service);
                        }
                    }
                }
            }
        }
        
        private void AddPackagesToList()
        {
            ICProductGroupsInfo packageGroup = new ICProductGroupsInfo(CommonLocalizedResources.Package);
            packageGroup.SubList = new BOSTreeList();
            Add(packageGroup);
            ICProductsController objProductsController = new ICProductsController();
            DataSet ds = objProductsController.GetProductsByType(ProductType.Package.ToString());
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ICProductsInfo objProductsInfo = (ICProductsInfo)objProductsController.GetObjectFromDataRow(row);
                    ICProductGroupsInfo service = new ICProductGroupsInfo();
                    service.ICProductGroupID = objProductsInfo.ICProductID;
                    service.ICProductGroupName = objProductsInfo.ICProductName;
                    packageGroup.SubList.Add(service);
                }
            }
        }
    }
}
