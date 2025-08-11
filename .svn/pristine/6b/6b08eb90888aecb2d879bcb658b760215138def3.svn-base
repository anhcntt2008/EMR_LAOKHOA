using System;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOSLib;
using BOSCommon;

namespace BOSERP.Modules.Product
{
    public class ProductEntities : ERPModuleEntities
    {
        #region Declare Constant
        public const String strICProductsObjectName = "ICProducts";

        public const String strICProductAlternativesObjectName = "ICProductAlternatives";
        public const String strICProductComponentsObjectName = "ICProductComponents";
        public const String strICProductAttributesObjectName = "ICProductAttributes";
        public const String strICProductUnitsObjectName = "ICProductUnits";
        #endregion
        
        #region Declare all entities variables
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets product branch price list
        /// </summary>
        public BOSList<ICProductBranchPricesInfo> ProductBranchPriceList { get; set; }

        /// <summary>
        /// Gets or sets edit purchase price by currency list
        /// </summary>
        public BOSList<ICProductBranchPricesInfo> ProductPurchasePriceList { get; set; }

        /// <summary>
        /// Gets or sets history detail list
        /// </summary>
        public BOSList<GEHistoryDetailsInfo> HistoryDetailList { get; set; }

        public BOSList<ICProductComponentsInfo> ICProductComponentsList {get;set;}

        public BOSList<ICProductPricesInfo> ICProductPricesList {get;set;}

        public ICProductUnitsInfo ICProductUnitsObject { get; set; }

        public BOSList<ICProductUnitsInfo> ICProductUnitsList { get; set; }

        public BOSList<ICProductsInfo> SameProductList { get; set; }

        /// <summary>
        /// Gets or sets suppliers of product
        /// </summary>
        public BOSList<ICProductSuppliersInfo> ICProductSuppliersList { get; set; }
        #endregion

        #region Constructor
        public ProductEntities()
            : base()
        {
            ICProductUnitsObject = new ICProductUnitsInfo();

            ICProductComponentsList = new BOSList<ICProductComponentsInfo>();
            ICProductPricesList = new BOSList<ICProductPricesInfo>();
            ICProductUnitsList = new BOSList<ICProductUnitsInfo>();
            ICProductSuppliersList = new BOSList<ICProductSuppliersInfo>();
            ProductBranchPriceList = new BOSList<ICProductBranchPricesInfo>();
            HistoryDetailList = new BOSList<GEHistoryDetailsInfo>();
            ProductPurchasePriceList = new BOSList<ICProductBranchPricesInfo>();
            SameProductList = new BOSList<ICProductsInfo>();
        }

        #endregion

        #region Init Main Object,Module Objects functions
        public override void InitMainObject()
        {
            MainObject = new ICProductsInfo();
            SearchObject = new ICProductsInfo();
        }

        public override void InitModuleObjects()
        {
            ModuleObjects.Add(TableName.ICProductComponentsTableName, new ICProductComponentsInfo());
            ModuleObjects.Add(TableName.ICProductPricesTableName, new ICProductPricesInfo());
            ModuleObjects.Add(TableName.ICProductUnitsTableName, new ICProductUnitsInfo());
            ModuleObjects.Add(TableName.ICProductSuppliersTableName, new ICProductSuppliersInfo());
            ModuleObjects.Add(TableName.ICProductBranchPricesTableName, new ICProductBranchPricesInfo());
        }

        public override void InitModuleObjectList()     
        {            
            ICProductComponentsList.InitBOSList(this, 
                                                TableName.ICProductsTableName, 
                                                TableName.ICProductComponentsTableName,
                                                BOSList<ICProductComponentsInfo>.cstRelationForeign);
            ICProductComponentsList.ItemTableForeignKey = "FK_ICProductID";

            ICProductPricesList.InitBOSList(
                                            this, 
                                            TableName.ICProductsTableName, 
                                            TableName.ICProductPricesTableName,
                                            BOSList<ICProductPricesInfo>.cstRelationForeign);
            ICProductPricesList.ItemTableForeignKey = "FK_ICProductID";

            ICProductUnitsList.InitBOSList(
                                            this, 
                                            TableName.ICProductsTableName, 
                                            TableName.ICProductUnitsTableName,
                                            BOSList<ICProductUnitsInfo>.cstRelationForeign);
            ICProductPricesList.ItemTableForeignKey = "FK_ICProductID";

            ICProductSuppliersList.InitBOSList(this, 
                                               TableName.ICProductsTableName,
                                               TableName.ICProductSuppliersTableName,
                                               BOSList<ICProductSuppliersInfo>.cstRelationForeign);
            ICProductSuppliersList.ItemTableForeignKey = "FK_ICProductID";

            ProductBranchPriceList.InitBOSList(this, 
                                                    TableName.ICProductsTableName,
                                                    TableName.ICProductBranchPricesTableName,
                                                    BOSList<ICProductBranchPricesInfo>.cstRelationForeign);
            ProductBranchPriceList.ItemTableForeignKey = "FK_ICProductID";

            ProductPurchasePriceList.InitBOSList(this,
                                                    TableName.ICProductsTableName,
                                                    TableName.ICProductBranchPricesTableName,
                                                    BOSList<ICProductBranchPricesInfo>.cstRelationForeign);
            ProductPurchasePriceList.ItemTableForeignKey = "FK_ICProductID";

            HistoryDetailList.InitBOSList(this,
                                           TableName.GEObjectHistoryTableName,
                                           TableName.GEHistoryDetailsTableName,
                                           BOSList<GEHistoryDetailsInfo>.cstRelationForeign);

            SameProductList.InitBOSList(
                                            this,
                                            null,
                                            null, null);
            //SameProductList.Invalidate(new BOSList<ICProductsInfo>());

        }

        public override void InitGridControlInBOSList()
        {
            ICProductComponentsList.InitBOSListGridControl();
            ICProductSuppliersList.InitBOSListGridControl();
            ProductBranchPriceList.InitBOSListGridControl();
            HistoryDetailList.InitBOSListGridControl();
            ProductPurchasePriceList.InitBOSListGridControl();
            SameProductList.InitBOSListGridControl(ProductModule.SameProductGridControlName);
        }

        public override void SetDefaultMainObject()
        {
            base.SetDefaultMainObject();

            ICProductsInfo objProductsInfo = (ICProductsInfo)MainObject;
            objProductsInfo.ICProductType = ADConfigValueUtility.GetFirstConfigValueByGroup(ConfigValueGroup.ProductType);
            ICMeasureUnitsInfo objMeasureUnitsInfo = (ICMeasureUnitsInfo)BOSApp.GetFirstObjectFromLookupTable(TableName.ICMeasureUnitsTableName);
            if (objMeasureUnitsInfo != null)
            {
                objProductsInfo.FK_ICProductBasicUnitID = objMeasureUnitsInfo.ICMeasureUnitID;
            }
        }

        public override void SetDefaultModuleObjectsList()
        {
            try
            {
                ICProductComponentsList.SetDefaultListAndRefreshGridControl();
                ICProductSuppliersList.SetDefaultListAndRefreshGridControl();                
                ICProductUnitsList.SetDefaultListAndRefreshGridControl();

                ICProductPricesList.SetDefaultListAndRefreshGridControl();
                SynProductPriceLevels();

                ProductBranchPriceList.SetDefaultListAndRefreshGridControl();

                ProductPurchasePriceList.SetDefaultListAndRefreshGridControl();
                SynProductPurchasePrices();
                //((ProductModule)Module).sameProductGridControl.RefreshDataSource();
                SameProductList.GridControl.RefreshDataSource();
            }
            catch (Exception)
            {
                return;
            }
        }

        /// <summary>
        /// Invalidate the product's price levels
        /// </summary>
        /// <param name="productID">Product id</param>
        public void InvalidateProductPriceLevels(int productID)
        {
            ICProductPricesList.Invalidate(productID);

            SynProductPriceLevels();
        }

        /// <summary>
        /// Synchronize the product's price levels with the master ones
        /// </summary>
        private void SynProductPriceLevels()
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            ARPriceLevelsController objPriceLevelsController = new ARPriceLevelsController();
            BOSList<ARPriceLevelsInfo> priceLevels = new BOSList<ARPriceLevelsInfo>();
            DataSet ds = objPriceLevelsController.GetAllObjects();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ARPriceLevelsInfo objPriceLevelsInfo = (ARPriceLevelsInfo)objPriceLevelsController.GetObjectFromDataRow(row);
                    priceLevels.Add(objPriceLevelsInfo);
                }
            }

            //Add new price levels to product price level list
            ICProductsInfo objProductsInfo = (ICProductsInfo)MainObject;
            foreach (ARPriceLevelsInfo objPriceLevelsInfo in priceLevels)
                if (!ICProductPricesList.Exists("FK_ARPriceLevelID", objPriceLevelsInfo.ARPriceLevelID))
                {
                    ICProductPricesInfo objProductPricesInfo = new ICProductPricesInfo();
                    objProductPricesInfo.FK_ARPriceLevelID = objPriceLevelsInfo.ARPriceLevelID;
                    objProductPricesInfo.FK_ICProductID = objProductsInfo.ICProductID;
                    objProductPricesInfo.ICProductPriceMarkDown = objPriceLevelsInfo.ARPriceLevelMarkDown;
                    ICProductPricesList.Add(objProductPricesInfo);
                }

            //Delete old price levels from product price level list
            for (int i = 0; i < ICProductPricesList.Count; i++)
                if (!priceLevels.Exists("ARPriceLevelID", ICProductPricesList[i].FK_ARPriceLevelID))
                {
                    ICProductPricesList.RemoveAt(i);
                    i--;
                }
        }

        /// <summary>
        /// Invalidate the product's purchase prices
        /// </summary>
        /// <param name="productID">Product id</param>
        public void InvalidateProductPurchasePrices(int productID)   
        {
            ICProductBranchPricesController objProductBranchPricesController = new ICProductBranchPricesController();
            List<ICProductBranchPricesInfo> productPurchasePrices = objProductBranchPricesController.GetProductBranchPriceByProductIDAndType(productID, ProductBranchPriceType.Purchase.ToString());
            ProductPurchasePriceList.Invalidate(productPurchasePrices);

            SynProductPurchasePrices();
        }

        /// <summary>
        /// Synchronize the product's purchase prices with currencies
        /// </summary>
        private void SynProductPurchasePrices()
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            GECurrenciesController objCurrenciesController = new GECurrenciesController();
            List<GECurrenciesInfo> currencies = new List<GECurrenciesInfo>();
            DataSet ds = objCurrenciesController.GetAllObjects();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    GECurrenciesInfo objCurrenciesInfo = (GECurrenciesInfo)objCurrenciesController.GetObjectFromDataRow(row);
                    currencies.Add(objCurrenciesInfo);
                }
            }

            //Add new currency to product purchase prices            
            ICProductsInfo objProductsInfo = (ICProductsInfo)MainObject;
            foreach (GECurrenciesInfo objCurrenciesInfo in currencies)
            {
                if (!ProductPurchasePriceList.Exists("FK_GECurrencyID", objCurrenciesInfo.GECurrencyID))
                {
                    ICProductBranchPricesInfo objProductBranchPricesInfo = new ICProductBranchPricesInfo();
                    objProductBranchPricesInfo.FK_BRBranchID = 0;
                    objProductBranchPricesInfo.FK_ICProductID = objProductsInfo.ICProductID;
                    if (objCurrenciesInfo.GECurrencyID == BOSApp.CurrentCompanyInfo.FK_GEPurchaseCurrencyID)
                    {
                        objProductBranchPricesInfo.ICProductBranchPrice = objProductsInfo.ICProductSupplierPrice;
                    }
                    else
                    {
                        objProductBranchPricesInfo.ICProductBranchPrice = 0;
                    }

                    objProductBranchPricesInfo.FK_GECurrencyID = objCurrenciesInfo.GECurrencyID;
                    objProductBranchPricesInfo.ICProductBranchPriceType = ProductBranchPriceType.Purchase.ToString();
                    ProductPurchasePriceList.Add(objProductBranchPricesInfo);
                    ProductPurchasePriceList.BackupList.Add(objProductBranchPricesInfo);
                }
            }

            //Delete old currencies from product branch prices
            for (int i = 0; i < ProductPurchasePriceList.Count; i++)
            {
                GECurrenciesInfo objCurrencyInfo = currencies.Where(c => c.GECurrencyID == ProductPurchasePriceList[i].FK_GECurrencyID).FirstOrDefault();
                if (objCurrencyInfo == null)
                {
                    ProductPurchasePriceList.RemoveAt(i);
                    ProductPurchasePriceList.BackupList.RemoveAt(i);
                    i--;
                }
            }            
        }

        public override void DuplicateModuleObjectList()
        {
            ICProductComponentsList.Duplicate();
            ICProductPricesList.Duplicate();
            ICProductSuppliersList.Duplicate();
            ProductBranchPriceList.Duplicate();
            foreach (ICProductBranchPricesInfo productPrice in ProductBranchPriceList)
            {
                productPrice.ICProductBranchPrice = 0;
            }
            ProductPurchasePriceList.Duplicate();
        }
        #endregion

        #region Invalidate Module Objects functions
        public override void InvalidateModuleObjects(int iObjectID)
        {
            InvalidateProductPriceLevels(iObjectID);
            
            ICProductUnitsList.Invalidate(iObjectID);

            ICProductSuppliersList.Invalidate(iObjectID);


            SameProductList.Invalidate(new BOSList<ICProductsInfo>());

            ICProductBranchPricesController objProductBranchPricesController = new ICProductBranchPricesController();
            List<ICProductBranchPricesInfo> productSellingPrices = objProductBranchPricesController.GetProductBranchPriceByProductIDAndType(iObjectID, ProductBranchPriceType.Sale.ToString());
            ProductBranchPriceList.Invalidate(productSellingPrices);

            InvalidateProductPurchasePrices(iObjectID);
        }
        #endregion

        #region Save Module Objects functions
        public override int SaveMainObject()
        {
            //Boolean newProduct = false;
            ICProductsInfo objProductsInfo = (ICProductsInfo)MainObject;
            objProductsInfo.FK_ICProductSaleUnitID = objProductsInfo.FK_ICProductBasicUnitID;
            objProductsInfo.FK_ICProductPurchaseUnitID = objProductsInfo.FK_ICProductBasicUnitID;
            objProductsInfo.HasComponent = false;
            if (ICProductComponentsList.Count > 0)
            {
                objProductsInfo.HasComponent = true;
            }
            
            //if (objProductsInfo.ICProductID == 0)
            //{
            //    newProduct = true;
            //}

            //int rtn = base.SaveMainObject();
            //if (newProduct)
            //{
            //    GENumberingController objNumberingController = new GENumberingController();
            //    GENumberingInfo objNumberingInfo = (GENumberingInfo)objNumberingController.GetObjectByName(Module.Name);
            //    objNumberingInfo.GENumberingStart++;
            //    objNumberingController.UpdateObject(objNumberingInfo);
            //}


            return base.SaveMainObject();
        }

        public override string GetMainObjectNo(ref int numberingStart)
        {
            string productNo = string.Empty;
            //string numberingStartValue = base.GetMainObjectNo(ref numberingStart);                        
            ICProductsInfo objProductsInfo = (ICProductsInfo)MainObject;

            ICDepartmentsController departmentsController = new ICDepartmentsController();
            ICDepartmentsInfo departmentsInfo = departmentsController.GetObjectByID(objProductsInfo.FK_ICDepartmentID) as ICDepartmentsInfo;                
            ICProductGroupsController objProductGroupsController = new ICProductGroupsController();
            ICProductGroupsInfo objProductGroupsInfo = (ICProductGroupsInfo)objProductGroupsController.GetObjectByID(objProductsInfo.FK_ICProductGroupID);
             GENumberingController objNumberingController = new GENumberingController();
            //DDCan [MOD] [18/11/2013] [DB centre] [GENumbering issue], START
            //GENumberingInfo objNumberingInfo = (GENumberingInfo)objNumberingController.GetObjectByName(Module.Name);
            GENumberingInfo objNumberingInfo;
            List<GENumberingInfo> nuberingList = objNumberingController.GetNumberingListByName(Module.Name);
            if (nuberingList.Count == 1)
            {
                objNumberingInfo = nuberingList[0];
            }
            else
            {
                objNumberingInfo = nuberingList.Where(i => i.FK_BRBranchID == BOSApp.CurrentCompanyInfo.FK_BRBranchID).FirstOrDefault();
            }
            //DDCan [MOD] [18/11/2013] [DB centre] [GENumbering issue], END

            if (departmentsInfo!= null && objProductGroupsInfo != null && objNumberingInfo != null)
            {
                productNo = departmentsInfo.ICDepartmentNo;
                if (!string.IsNullOrEmpty(objProductsInfo.ICProductOrigin))
                {
                    productNo += objProductsInfo.ICProductOrigin;
                }
                productNo += "-";
                productNo += objProductGroupsInfo.ICProductGroupNo + "-";
                productNo += objNumberingInfo.GENumberingStart.ToString().PadLeft(objNumberingInfo.GENumberingLength, '0');
            }
            numberingStart = objNumberingInfo.GENumberingStart;

            return productNo.Trim('-');
        }

        public override void SaveModuleObjects()
        {
            SaveProductComponent();
            ICProductPricesList.SaveItemObjects();
            ICProductUnitsList.SaveItemObjects();
            ICProductSuppliersList.SaveItemObjects();

            ProductBranchPriceList.SaveItemObjects();
            ProductPurchasePriceList.SaveItemObjects();
        }

        /// <summary>
        /// Save product component list
        /// </summary>
        public void SaveProductComponent()
        {
            ICProductsInfo objProductsInfo = (ICProductsInfo)MainObject;
            int sortOrder = 0;
            foreach (ICProductComponentsInfo objProductComponentsInfo in ICProductComponentsList)
            {
                sortOrder++;
                objProductComponentsInfo.FK_ICProductComponentParentID = objProductsInfo.ICProductID;
                objProductComponentsInfo.ICProductComponentSortOrder = sortOrder;
            }
            ICProductComponentsList.SaveItemObjects();
        }
        #endregion              
    }
}
