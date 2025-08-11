using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using Localization;
using BOSCommon;
using System.Data;
using System.Collections;
using BOSLib;
using System.Text.RegularExpressions;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using DevExpress.XtraRichEdit;

namespace BOSERP.Modules.ImportData
{
    public class ImportDataModule : BaseModuleERP
    {
        public ImportDataModule()
        {
            Name = "ImportData";
            InitializeModule();
        }

        #region Private variable
        private Microsoft.Office.Interop.Excel.Application App;
        /// <summary>
        /// Define work book in excel
        /// </summary>
        private Workbook WorkBook;
        /// <summary>
        /// Define work sheet in excel
        /// </summary>
        private Worksheet WorkSheet;
        #endregion

        /// <summary>
        /// Initialize data import from file excel
        /// </summary>
        /// <returns>Range of file excel</returns>
        public Range InitializeDataImport()
        {
            string filePath = string.Empty;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = ImportDataLocalizedResources.DialogFilter;
            if (dialog.ShowDialog() != DialogResult.Cancel)
                filePath = dialog.FileName;
            if (!String.IsNullOrEmpty(filePath))
            {
                App = new Microsoft.Office.Interop.Excel.ApplicationClass();
                WorkBook = App.Workbooks.Open(filePath, 0, true, 5, string.Empty, string.Empty, true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                WorkSheet = (Worksheet)WorkBook.Worksheets.get_Item(1);
                Range range = WorkSheet.UsedRange;
                return range;
            }
            return null;
        }

        /// <summary>
        /// Release data import from file excel
        /// </summary>
        public void ReleaseDataImport()
        {
            WorkBook.Close(true, null, null);
            App.Quit();
            ReleaseObject(WorkSheet);
            ReleaseObject(WorkBook);
            ReleaseObject(App);
        }

        /// <summary>
        /// Release object
        /// </summary>
        /// <param name="obj">Given object</param>
        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        /// <summary>
        /// Import product to database from excel
        /// </summary>
        public void ImportProductFromExcel()
        {
            Range range = InitializeDataImport();
            if (range != null)
            {
                if (MessageBox.Show(ImportDataLocalizedResources.QuestionImportDataMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BOSProgressBar.Start(ImportDataLocalizedResources.ProgressBarMessage);
                    ICProductsController objProductsController = new ICProductsController();
                    ICProductSeriesController objProductSeriesController = new ICProductSeriesController();
                    ICInventoryStocksController objInventoryStocksController = new ICInventoryStocksController();
                    ICDepartmentsController objDepartmentsController = new ICDepartmentsController();
                    ICProductGroupsController objProductGroupsController = new ICProductGroupsController();
                    APSuppliersController objSuppliersController = new APSuppliersController();
                    ICStocksController objStocksController = new ICStocksController();
                    ICMeasureUnitsController objMeasureUnitsController = new ICMeasureUnitsController();
                    ADConfigValuesController objConfigValueController = new ADConfigValuesController();
                    GENumberingController numberingController = new GENumberingController();
                    ICProductOriginsController productOriginController = new ICProductOriginsController();


                    BOSList<ICDepartmentsInfo> departmentList = new BOSList<ICDepartmentsInfo>();
                    departmentList.InitBOSList(CurrentModuleEntity, String.Empty, TableName.ICDepartmentsTableName, BOSList<ICDepartmentsInfo>.cstRelationNone);
                    DataSet ds = objDepartmentsController.GetAllObjects();
                    departmentList.Invalidate(ds);

                    ICDepartmentAttributesController objDepartmentAttributesController = new ICDepartmentAttributesController();
                    List<ICDepartmentAttributesInfo> attributes = objDepartmentAttributesController.GetAllAttributes();
                    ICDepartmentAttributeValuesController objDepartmentAttributeValuesController = new ICDepartmentAttributeValuesController();
                    List<ICDepartmentAttributeValuesInfo> attributeValues = objDepartmentAttributeValuesController.GetDepartmentAttributeValuesList();

                    BOSList<ICProductGroupsInfo> productGroupList = new BOSList<ICProductGroupsInfo>();
                    productGroupList.InitBOSList(CurrentModuleEntity, String.Empty, TableName.ICProductGroupsTableName, BOSList<ICProductGroupsInfo>.cstRelationNone);
                    ds = objProductGroupsController.GetAllObjects();
                    productGroupList.Invalidate(ds);

                    BOSList<APSuppliersInfo> supplierList = new BOSList<APSuppliersInfo>();
                    supplierList.InitBOSList(CurrentModuleEntity, String.Empty, TableName.APSuppliersTableName, BOSList<APSuppliersInfo>.cstRelationNone);
                    ds = objSuppliersController.GetAllObjects();
                    supplierList.Invalidate(ds);

                    BOSList<ICMeasureUnitsInfo> measureUnitList = new BOSList<ICMeasureUnitsInfo>();
                    measureUnitList.InitBOSList(CurrentModuleEntity, String.Empty, TableName.ICMeasureUnitsTableName, BOSList<ICStocksInfo>.cstRelationNone);
                    ds = objMeasureUnitsController.GetAllObjects();
                    measureUnitList.Invalidate(ds);

                    BOSList<ICInventoryStocksInfo> inventoryStockList = new BOSList<ICInventoryStocksInfo>();
                    inventoryStockList.InitBOSList(CurrentModuleEntity, string.Empty, TableName.ICInventoryStocksTableName, BOSList<ICInventoryStocksInfo>.cstRelationNone);
                    ds = objInventoryStocksController.GetAllObjects();
                    inventoryStockList.Invalidate(ds);

                    //product types 
                    BOSList<ADConfigValuesInfo> productTypeList = new BOSList<ADConfigValuesInfo>();
                    productTypeList.InitBOSList(CurrentModuleEntity, string.Empty, TableName.ADConfigValuesTableName, BOSList<ICInventoryStocksInfo>.cstRelationNone);
                    ds = objConfigValueController.GetADConfigValuesByGroup("ProductType");
                    productTypeList.Invalidate(ds);

                    //product status
                    BOSList<ADConfigValuesInfo> productStatusList = new BOSList<ADConfigValuesInfo>();
                    productStatusList.InitBOSList(CurrentModuleEntity, string.Empty, TableName.ADConfigValuesTableName, BOSList<ICInventoryStocksInfo>.cstRelationNone);
                    ds = objConfigValueController.GetADConfigValuesByGroup("ProductStatus");
                    productStatusList.Invalidate(ds);

                    BOSList<ICProductOriginsInfo> productOriginList = new BOSList<ICProductOriginsInfo>();
                    productOriginList.InitBOSList(CurrentModuleEntity, string.Empty, TableName.ICProductOriginsTableName, BOSList<ICProductOriginsInfo>.cstRelationNone);
                    ds = productOriginController.GetAllObjects();
                    productOriginList.Invalidate(ds);

                    //numbering
                    GENumberingInfo numberingInfo;
                    int count = 0;

                    List<ICProductsInfo> products = objProductsController.GetAllProducts();
                    SortedList<string, int> productKeyList = new SortedList<string, int>();
                    foreach (ICProductsInfo product in products)
                    {
                        string productKey = string.Format("{0}{1}{2}", product.ICProductSupplierNumber, product.ICProductName, product.ICProductAttributeNo);
                        if (!productKeyList.ContainsKey(productKey))
                        {
                            productKeyList.Add(productKey, product.ICProductID);
                        }
                    }
                    string prevProductKey = string.Empty;

                    //Get stock list include stock id and column index in excel
                    SortedList<int, int> stockList = new SortedList<int, int>();
                    //SortedList<string, string> productSupplierNumberAndProductNameList = new SortedList<string, string>();
                    for (int column = 1; column <= range.Columns.Count; column++)
                    {
                        string stockName = (range.Cells[1, column] as Range).Text.ToString().Trim();
                        ICStocksInfo objStocksInfo = (ICStocksInfo)objStocksController.GetObjectByName(stockName);
                        if (objStocksInfo != null)
                            stockList.Add(objStocksInfo.ICStockID, column);
                    }

                    for (int row = 2; row <= range.Rows.Count; row++)
                    {
                        ICProductsInfo product = new ICProductsInfo();
                        product.ICProductSupplierNumber = (range.Cells[row, 3] as Range).Text.ToString().Trim();
                        product.ICProductName = (range.Cells[row, 4] as Range).Text.ToString().Trim();
                        product.ICProductDesc = product.ICProductName;
                        string description = (range.Cells[row, 22] as Range).Text.ToString().Trim();
                        if (!string.IsNullOrEmpty(description))
                            product.ICProductDesc += ", " + description;
                        //ICProductOrigin
                        //product.ICProductOrigin = (range.Cells[row, 5] as Range).Text.ToString().Trim();
                        string productOriginNo = (range.Cells[row, 5] as Range).Text.ToString().Trim();
                        ICProductOriginsInfo productOrigin = productOriginList.FirstOrDefault(po => po.ICProductOriginNo == productOriginNo);
                        if (productOrigin != null)
                            product.FK_ICProductOriginID = productOrigin.ICProductOriginID;
                        else
                            product.FK_ICProductOriginID = 0;

                        //ICProductStatus
                        string productStatus = (range.Cells[row, 6] as Range).Text.ToString().Trim().ToLower();
                        ADConfigValuesInfo configValue = productStatusList.FirstOrDefault(ps => ps.ADConfigText.ToLower() == productStatus);
                        if (configValue != null)
                            product.ICProductStatus = configValue.ADConfigKeyValue;
                        else
                            product.ICProductStatus = string.Empty;

                        //Set foreign key department id 
                        //change from col5-> col8
                        string departmentNo = (range.Cells[row, 8] as Range).Text.ToString().Trim().ToLower();
                        ICDepartmentsInfo objDepartmentsInfo = (ICDepartmentsInfo)departmentList.Where(d => d.ICDepartmentNo.ToLower() == departmentNo).FirstOrDefault();
                        if (objDepartmentsInfo != null)
                            product.FK_ICDepartmentID = objDepartmentsInfo.ICDepartmentID;

                        //Set product attribute
                        string productAttributeKey = string.Empty;
                        string productAttribute = string.Empty;
                        string productAttributeNo = string.Empty;

                        //change from col9-> col11
                        string shape = (range.Cells[row, 11] as Range).Text.ToString().Trim().ToLower();
                        if (!string.IsNullOrEmpty(shape))
                        {
                            ICDepartmentAttributeValuesInfo attributeValue = attributeValues.Where(da => da.ICDepartmentAttributeValueValue.ToLower() == shape && da.FK_ICDepartmentID == product.FK_ICDepartmentID).FirstOrDefault();
                            if (attributeValue == null)
                            {
                                ICDepartmentAttributesInfo attribute = attributes.Where(a => a.FK_ICDepartmentID == product.FK_ICDepartmentID &&
                                                                                      a.ICDepartmentAttributeName == "Hình dáng").FirstOrDefault();
                                if (attribute != null)
                                {
                                    attributeValue = CreateAttributeValue(attribute, shape);
                                    attributeValues.Add(attributeValue);
                                }
                            }
                            if (attributeValue != null)
                            {
                                productAttributeKey += String.Format("{0}_", attributeValue.ICDepartmentAttributeValueID);
                                productAttributeNo += attributeValue.ICDepartmentAttributeValueNo;
                                productAttribute += String.Format("{0}: {1}; ", attributeValue.ICDepartmentAttributeName, attributeValue.ICDepartmentAttributeValueValue);
                                //product.ICProductDesc += string.Format(", {0}", attributeValue.ICDepartmentAttributeValueValue);
                            }
                        }

                        //change from col8-> col12
                        string material = (range.Cells[row, 12] as Range).Text.ToString().Trim().ToLower();
                        if (!string.IsNullOrEmpty(material))
                        {
                            ICDepartmentAttributeValuesInfo attributeValue = attributeValues.Where(da => da.ICDepartmentAttributeValueValue.ToLower() == material &&
                                                                                                                da.FK_ICDepartmentID == product.FK_ICDepartmentID).FirstOrDefault();
                            if (attributeValue == null)
                            {
                                ICDepartmentAttributesInfo attribute = attributes.Where(a => a.FK_ICDepartmentID == product.FK_ICDepartmentID &&
                                                                                        a.ICDepartmentAttributeName == "Loại vật liệu").FirstOrDefault();
                                if (attribute != null)
                                {
                                    attributeValue = CreateAttributeValue(attribute, material);
                                    attributeValues.Add(attributeValue);
                                }
                            }
                            if (attributeValue != null)
                            {
                                productAttributeKey += String.Format("{0}_", attributeValue.ICDepartmentAttributeValueID);
                                productAttributeNo += attributeValue.ICDepartmentAttributeValueNo;
                                productAttribute += String.Format("{0}: {1}; ", attributeValue.ICDepartmentAttributeName, attributeValue.ICDepartmentAttributeValueValue);
                                //product.ICProductDesc += string.Format(", {0}", attributeValue.ICDepartmentAttributeValueValue);
                            }
                        }


                        //composition attribute
                        ////string composition = (range.Cells[row, 13] as Range).Text.ToString().Trim().ToLower();
                        //string composition = (range.Cells[row, 22] as Range).Text.ToString().Trim().ToLower();
                        //if (!string.IsNullOrEmpty(composition))
                        //{
                        //    ICDepartmentAttributeValuesInfo attributeValue = attributeValues.Where(da => da.ICDepartmentAttributeValueValue.ToLower() == composition &&
                        //                                                                                        da.FK_ICDepartmentID == product.FK_ICDepartmentID).FirstOrDefault();
                        //    if (attributeValue == null)
                        //    {
                        //        ICDepartmentAttributesInfo attribute = attributes.Where(a => a.FK_ICDepartmentID == product.FK_ICDepartmentID &&
                        //                                                                a.ICDepartmentAttributeName == "Đặc điểm cấu tạo").FirstOrDefault();
                        //        if (attribute != null)
                        //        {
                        //            attributeValue = CreateAttributeValue(attribute, composition);
                        //            attributeValues.Add(attributeValue);
                        //        }
                        //    }
                        //    if (attributeValue != null)
                        //    {
                        //        productAttributeKey += String.Format("{0}_", attributeValue.ICDepartmentAttributeValueID);
                        //        productAttributeNo += attributeValue.ICDepartmentAttributeValueNo;
                        //        productAttribute += String.Format("{0}: {1}; ", attributeValue.ICDepartmentAttributeName, attributeValue.ICDepartmentAttributeValueValue);
                        //        product.ICProductDesc += string.Format(", {0}", attributeValue.ICDepartmentAttributeValueValue);
                        //    }
                        //}

                        //change from col10-> col14
                        string size = (range.Cells[row, 14] as Range).Text.ToString().Trim().ToLower();
                        if (!string.IsNullOrEmpty(size))
                        {
                            ICDepartmentAttributeValuesInfo attributeValue = attributeValues.Where(da => da.ICDepartmentAttributeValueValue.ToLower() == size && da.FK_ICDepartmentID == product.FK_ICDepartmentID).FirstOrDefault();
                            if (attributeValue == null)
                            {
                                ICDepartmentAttributesInfo attribute = attributes.Where(a => a.FK_ICDepartmentID == product.FK_ICDepartmentID &&
                                                                                        a.ICDepartmentAttributeName == "Kích thước").FirstOrDefault();
                                if (attribute != null)
                                {
                                    attributeValue = CreateAttributeValue(attribute, size);
                                    attributeValues.Add(attributeValue);
                                }
                            }
                            if (attributeValue != null)
                            {
                                productAttributeKey += String.Format("{0}_", attributeValue.ICDepartmentAttributeValueID);
                                productAttributeNo += attributeValue.ICDepartmentAttributeValueNo;
                                productAttribute += String.Format("{0}: {1}; ", attributeValue.ICDepartmentAttributeName, attributeValue.ICDepartmentAttributeValueValue);
                                //product.ICProductDesc += string.Format(", {0}", attributeValue.ICDepartmentAttributeValueValue);
                            }
                        }

                        //change from col11-> col15
                        string color = (range.Cells[row, 15] as Range).Text.ToString().Trim().ToLower();
                        if (!string.IsNullOrEmpty(color))
                        {
                            ICDepartmentAttributeValuesInfo attributeValue = attributeValues.Where(da => da.ICDepartmentAttributeValueValue.ToLower() == color && da.FK_ICDepartmentID == product.FK_ICDepartmentID).FirstOrDefault();
                            if (attributeValue == null)
                            {
                                ICDepartmentAttributesInfo attribute = attributes.Where(a => a.FK_ICDepartmentID == product.FK_ICDepartmentID &&
                                                                                        a.ICDepartmentAttributeName == "Màu sắc").FirstOrDefault();
                                if (attribute != null)
                                {
                                    attributeValue = CreateAttributeValue(attribute, color);
                                    attributeValues.Add(attributeValue);
                                }
                            }
                            if (attributeValue != null)
                            {
                                productAttributeKey += String.Format("{0}_", attributeValue.ICDepartmentAttributeValueID);
                                productAttributeNo += attributeValue.ICDepartmentAttributeValueNo;
                                productAttribute += String.Format("{0}: {1}; ", attributeValue.ICDepartmentAttributeName, attributeValue.ICDepartmentAttributeValueValue);
                                //product.ICProductDesc += string.Format(", {0}", attributeValue.ICDepartmentAttributeValueValue);
                            }
                        }

                        if (productAttributeKey.Length > 0)
                            productAttributeKey = productAttributeKey.Substring(0, productAttributeKey.Length - 1);
                        if (productAttribute.Length > 0)
                            productAttribute = productAttribute.Substring(0, productAttribute.Length - 2);
                        product.ICProductAttributeKey = productAttributeKey;
                        product.ICProductAttribute = productAttribute;
                        product.ICProductAttributeNo = productAttributeNo;
                        //Set product price
                        //change from col14-> col18
                        string productPrice01 = (range.Cells[row, 18] as Range).Text.ToString().Trim();
                        if (!string.IsNullOrEmpty(productPrice01))
                        {
                            double productPrice01Value = 0;
                            double.TryParse(productPrice01, out productPrice01Value);
                            product.ICProductPrice01 = productPrice01Value;
                            //product.ICProductPrice01 = Convert.ToDouble(productPrice01);
                        }

                        //Set product supplier price          
                        product.ICProductSupplierPrice = 0;
                        //string productSupplierPrice = (range.Cells[row, 17] as Range).Text.ToString().Trim();
                        //if (!string.IsNullOrEmpty(productSupplierPrice))
                        //{
                        //    double productSupplierPriceValue = 0;
                        //    double.TryParse(productSupplierPrice, out productSupplierPriceValue);
                        //    product.ICProductSupplierPrice = productSupplierPriceValue;
                        //    //product.ICProductPrice01 = Convert.ToDouble(productPrice01);
                        //}
                        #region Create product
                        int productID = 0;
                        if (!string.IsNullOrEmpty((range.Cells[row, 1] as Range).Text.ToString().Trim()))
                        {
                            int.TryParse((range.Cells[row, 1] as Range).Text.ToString().Trim(), out productID);
                            //productID = Convert.ToInt32((range.Cells[row, 1] as Range).Text.ToString().Trim());
                        }
                        string productKey = string.Format("{0}{1}{2}", product.ICProductSupplierNumber, product.ICProductName, product.ICProductAttributeNo);
                        if (string.IsNullOrEmpty(productKey))
                        {
                            productKey = prevProductKey;
                        }
                        else
                        {
                            prevProductKey = productKey;
                        }
                        if (productID == 0 && !string.IsNullOrEmpty(productKey))
                        {
                            //if (!productKeyList.ContainsKey(productKey))
                            //{
                            //get from excel
                            //product.ICProductType = ProductType.Product.ToString();                                
                            string productType = (range.Cells[row, 7] as Range).Text.ToString().Trim().ToLower();
                            configValue = productTypeList.FirstOrDefault(ps => ps.ADConfigText.ToLower() == productType);
                            if (configValue != null)
                                product.ICProductType = configValue.ADConfigKeyValue;
                            //Set foreign key product group id
                            //change from col7->col10
                            string productGroupChildNo = (range.Cells[row, 10] as Range).Text.ToString().Trim().ToLower();
                            string productSubNo = string.Empty;
                            if (string.IsNullOrEmpty(productGroupChildNo))
                            {
                                //change from col6->col9
                                string productGroupNo = (range.Cells[row, 9] as Range).Text.ToString().Trim().ToLower();
                                ICProductGroupsInfo objProductGroupsInfo = productGroupList.Where(pg => pg.ICProductGroupNo.ToLower() == productGroupNo).FirstOrDefault();
                                if (objProductGroupsInfo != null)
                                {
                                    product.FK_ICProductGroupID = objProductGroupsInfo.ICProductGroupID;
                                    productSubNo = productGroupNo;
                                }
                            }
                            else
                            {
                                ICProductGroupsInfo objProductGroupsInfo = productGroupList.Where(pg => pg.ICProductGroupNo.ToLower() == productGroupChildNo).FirstOrDefault();
                                if (objProductGroupsInfo != null)
                                {
                                    product.FK_ICProductGroupID = objProductGroupsInfo.ICProductGroupID;
                                    productSubNo = productGroupChildNo;
                                }
                            }
                            //Set foreign key supplier id
                            //change from col12-> col16
                            string supplierName = (range.Cells[row, 16] as Range).Text.ToString().Trim().ToLower();
                            APSuppliersInfo objSuppliersInfo = supplierList.Where(s => s.APSupplierName.ToLower() == supplierName).FirstOrDefault();
                            if (objSuppliersInfo != null)
                                product.FK_APSupplierID = objSuppliersInfo.APSupplierID;

                            //Set foreign key measure unit
                            //change from col15-> col19
                            string measureUnitName = (range.Cells[row, 19] as Range).Text.ToString().Trim().ToLower();
                            ICMeasureUnitsInfo objMeasureUnitsInfo = measureUnitList.Where(m => m.ICMeasureUnitName.ToLower() == measureUnitName).FirstOrDefault();
                            if (objMeasureUnitsInfo != null)
                            {
                                product.FK_ICProductBasicUnitID = objMeasureUnitsInfo.ICMeasureUnitID;
                                product.FK_ICProductPurchaseUnitID = product.FK_ICProductBasicUnitID;
                                product.FK_ICProductSaleUnitID = product.FK_ICProductBasicUnitID;
                            }
                            //Set stock min, max
                            //change from col16-> col20
                            string productStockMin = (range.Cells[row, 20] as Range).Text.ToString().Trim();
                            if (!string.IsNullOrEmpty(productStockMin))
                            {
                                double productStockMinValue = 0;
                                double.TryParse(productStockMin, out productStockMinValue);
                                product.ICProductStockMin = productStockMinValue;
                                //product.ICProductStockMin = Convert.ToDouble(productStockMin);
                            }

                            //change from col17-> col21
                            string productStockMax = (range.Cells[row, 21] as Range).Text.ToString().Trim();
                            if (!string.IsNullOrEmpty(productStockMax))
                            {
                                double productStockMaxValue = 0;
                                double.TryParse(productStockMax, out productStockMaxValue);
                                product.ICProductStockMax = productStockMaxValue;
                                //product.ICProductStockMax = Convert.ToDouble(productStockMax);
                            }

                            //Set product no and add product to database                                    
                            string productNo = departmentNo + productOriginNo;
                            if (!string.IsNullOrEmpty(productNo))
                                productNo += "-";
                            if (!string.IsNullOrEmpty(productSubNo))
                            {
                                productNo += productSubNo + "-";
                            }

                            //DDCan [MOD] [18/11/2013] [DB centre] [GENumbering issue], START
                            //numberingInfo = numberingController.GetObjectByName(ModuleName.Product) as GENumberingInfo;
                            List<GENumberingInfo> nuberingList = numberingController.GetNumberingListByName(ModuleName.Product);
                            if (nuberingList.Count == 1)
                            {
                                numberingInfo = nuberingList[0];
                            }
                            else
                            {
                                numberingInfo = nuberingList.Where(i => i.FK_BRBranchID == BOSApp.CurrentCompanyInfo.FK_BRBranchID).FirstOrDefault();
                            }
                            //DDCan [MOD] [18/11/2013] [DB centre] [GENumbering issue], END

                            if (numberingInfo != null)
                            {
                                string productNumbering = numberingInfo.GENumberingStart.ToString().PadLeft(numberingInfo.GENumberingLength, '0');
                                productNo += productNumbering;
                            }

                            product.ICProductNo = productNo.ToUpper().Trim('-');
                            productID = objProductsController.CreateObject(product);
                            if (productID != 0)
                            {
                                BOSApp.UpdateObjectNumbering(ModuleName.Product);
                                count++;
                            }
                            //productKeyList.Add(productKey, productID);
                            //}
                            //else
                            //{
                            //    productID = productKeyList[productKey];
                            //}
                        }
                        #endregion

                        //Add inventory stock
                        for (int i = 0; i < stockList.Count; i++)
                        {
                            int column = stockList.Values[i];
                            double qty = 0;
                            if (!string.IsNullOrEmpty((range.Cells[row, column] as Range).Text.ToString().Trim()))
                            {
                                //qty = Convert.ToDouble((range.Cells[row, column] as Range).Text.ToString().Trim());
                                double.TryParse((range.Cells[row, column] as Range).Text.ToString().Trim(), out qty);
                            }
                            if (qty > 0)
                            {
                                //Add product serie to database 
                                string productSerieNo = (range.Cells[row, 2] as Range).Text.ToString().Trim().ToLower();
                                if (string.IsNullOrEmpty(productSerieNo))
                                    productSerieNo = "xxx";
                                ICProductSeriesInfo serie = objProductSeriesController.GetSerieByProductIDAndSerieNo(productID, productSerieNo);
                                if (serie == null)
                                {
                                    serie = new ICProductSeriesInfo();
                                    serie.FK_ICProductID = productID;
                                    serie.ICProductSerieNo = productSerieNo;
                                    objProductSeriesController.CreateObject(serie);
                                }

                                int stockID = stockList.Keys[i];
                                int serieID = serie.ICProductSerieID;
                                ICInventoryStocksInfo objInventoryStocksInfo = inventoryStockList.Where(e => e.FK_ICStockID == stockID
                                                                                                        && e.FK_ICProductID == productID
                                                                                                        && e.FK_ICProductSerieID == serieID).FirstOrDefault();
                                if (objInventoryStocksInfo == null)
                                {
                                    objInventoryStocksInfo = new ICInventoryStocksInfo();
                                    objInventoryStocksInfo.FK_ICStockID = stockID;
                                    objInventoryStocksInfo.FK_ICProductID = productID;
                                    objInventoryStocksInfo.FK_ICProductSerieID = serieID;
                                    objInventoryStocksInfo.ICInventoryStockQuantity = qty;

                                    //ICInventoryStockUnitCost
                                    string inventoryStockUnitCost = (range.Cells[row, 17] as Range).Text.ToString().Trim();
                                    if (!string.IsNullOrEmpty(inventoryStockUnitCost))
                                    {
                                        double inventoryStockUnitCostValue = 0;
                                        double.TryParse(inventoryStockUnitCost, out inventoryStockUnitCostValue);
                                        objInventoryStocksInfo.ICInventoryStockUnitCost = inventoryStockUnitCostValue;
                                        //product.ICProductPrice01 = Convert.ToDouble(productPrice01);
                                    }

                                    objInventoryStocksController.CreateObject(objInventoryStocksInfo);
                                    inventoryStockList.Add(objInventoryStocksInfo);
                                }
                                else
                                {
                                    objInventoryStocksInfo.ICInventoryStockQuantity += qty;
                                    objInventoryStocksController.UpdateObject(objInventoryStocksInfo);
                                }
                            }
                        }
                    }
                    BOSProgressBar.Close();
                    //string resultMessage = ImportDataLocalizedResources.TotalRecordNumberImportSuccessMessage.Replace("{0}", productKeyList.Count.ToString());
                    string resultMessage = ImportDataLocalizedResources.TotalRecordNumberImportSuccessMessage.Replace("{0}", count.ToString());
                    MessageBox.Show(resultMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ReleaseDataImport();
            }
        }

        /// <summary>
        /// Create an attribute value
        /// </summary>
        /// <param name="attribute">Attribute object</param>
        /// <param name="value">Value</param>
        /// <returns>Created attribute value object</returns>
        private ICDepartmentAttributeValuesInfo CreateAttributeValue(ICDepartmentAttributesInfo attribute, string value)
        {
            ICDepartmentAttributeValuesController objDepartmentAttributeValuesController = new ICDepartmentAttributeValuesController();
            ICDepartmentAttributeValuesInfo attributeValue = new ICDepartmentAttributeValuesInfo();
            attributeValue.FK_ICDepartmentAttributeID = attribute.ICDepartmentAttributeID;
            attributeValue.ICDepartmentAttributeName = attribute.ICDepartmentAttributeName;
            int count = objDepartmentAttributeValuesController.GetValueCountByAttributeID(attribute.ICDepartmentAttributeID) + 1;
            if (count < 10)
            {
                attributeValue.ICDepartmentAttributeValueNo = "0" + count.ToString();
            }
            else
            {
                attributeValue.ICDepartmentAttributeValueNo = count.ToString();
            }
            attributeValue.ICDepartmentAttributeValueValue = value;
            attributeValue.FK_ICDepartmentID = attribute.FK_ICDepartmentID;
            objDepartmentAttributeValuesController.CreateObject(attributeValue);
            return attributeValue;
        }

        /// <summary>
        /// Import supplier to database from excel
        /// </summary>
        public void ImportSupplierFromExcel()
        {
            Range range = InitializeDataImport();
            if (range != null)
            {
                if (MessageBox.Show(ImportDataLocalizedResources.QuestionImportDataMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BOSProgressBar.Start(ImportDataLocalizedResources.ProgressBarMessage);
                    DataSet ds = new DataSet();
                    int numberOfImportedRecords = 0;
                    APSuppliersController objSuppliersController = new APSuppliersController();
                    GECurrenciesController objCurrenciesController = new GECurrenciesController();
                    ADConfigValuesController objConfigValuesController = new ADConfigValuesController();

                    BOSList<APSuppliersInfo> supplierList = new BOSList<APSuppliersInfo>();
                    supplierList.InitBOSList(CurrentModuleEntity, String.Empty, TableName.APSuppliersTableName, BOSList<APSuppliersInfo>.cstRelationNone);
                    ds = objSuppliersController.GetAllObjects();
                    supplierList.Invalidate(ds);

                    BOSList<ADConfigValuesInfo> configValueList = new BOSList<ADConfigValuesInfo>();
                    configValueList.InitBOSList(CurrentModuleEntity, String.Empty, TableName.ADConfigValuesTableName, BOSList<ADConfigValuesInfo>.cstRelationNone);
                    ds = objConfigValuesController.GetAllObjects();
                    configValueList.Invalidate(ds);

                    for (int rowIndex = 2; rowIndex <= range.Rows.Count; rowIndex++)
                    {
                        string aPSupplierName = (range.Cells[rowIndex, 2] as Range).Text.ToString();
                        if (aPSupplierName != string.Empty && aPSupplierName != null)
                        {
                            APSuppliersInfo objSuppliersInfo = new APSuppliersInfo();
                            objSuppliersInfo.APSupplierNo = BOSApp.GetMainObjectNo(ModuleName.Supplier);
                            objSuppliersInfo.APSupplierName = (range.Cells[rowIndex, 2] as Range).Text.ToString();
                            objSuppliersInfo.APSupplierName1 = (range.Cells[rowIndex, 3] as Range).Text.ToString();
                            objSuppliersInfo.APSupplierName2 = (range.Cells[rowIndex, 4] as Range).Text.ToString();
                            objSuppliersInfo.APSupplierContactPhone = (range.Cells[rowIndex, 6] as Range).Text.ToString();
                            objSuppliersInfo.APSupplierContactPhone1 = (range.Cells[rowIndex, 7] as Range).Text.ToString();
                            objSuppliersInfo.APSupplierContactPhone2 = (range.Cells[rowIndex, 8] as Range).Text.ToString();
                            objSuppliersInfo.APSupplierContactPhone3 = (range.Cells[rowIndex, 9] as Range).Text.ToString();
                            objSuppliersInfo.APSupplierContactPhone4 = (range.Cells[rowIndex, 10] as Range).Text.ToString();
                            objSuppliersInfo.APSupplierContactFax = (range.Cells[rowIndex, 11] as Range).Text.ToString();
                            objSuppliersInfo.APSupplierContactCellPhone = (range.Cells[rowIndex, 12] as Range).Text.ToString();
                            objSuppliersInfo.APSupplierContactCellPhone1 = (range.Cells[rowIndex, 13] as Range).Text.ToString();
                            objSuppliersInfo.APSupplierContactEmail1 = (range.Cells[rowIndex, 14] as Range).Text.ToString();
                            objSuppliersInfo.APSupplierContactAddressLine1 = (range.Cells[rowIndex, 15] as Range).Text.ToString();
                            objSuppliersInfo.APSupplierContactAddressCity = (range.Cells[rowIndex, 16] as Range).Text.ToString();
                            objSuppliersInfo.APSupplierContactAddressStateProvince = (range.Cells[rowIndex, 17] as Range).Text.ToString();
                            objSuppliersInfo.APSupplierContactAddressCountry = (range.Cells[rowIndex, 18] as Range).Text.ToString();
                            objSuppliersInfo.APSupplierContactAddressLine3 = BOSUtil.GenerateFullAddress(objSuppliersInfo, AddressType.Contact.ToString());
                            objSuppliersInfo.APSupplierTaxNumber = (range.Cells[rowIndex, 20] as Range).Text.ToString();

                            string supplierType = (range.Cells[rowIndex, 5] as Range).Text.ToString();
                            if (!string.IsNullOrEmpty(supplierType))
                            {
                                ADConfigValuesInfo objConfigValuesInfo = configValueList.Where(cv => cv.ADConfigText == supplierType && cv.ADConfigKeyGroup == ConfigValueGroup.SupplierType).FirstOrDefault();
                                if (objConfigValuesInfo != null)
                                {
                                    objSuppliersInfo.APSupplierTypeCombo = objConfigValuesInfo.ADConfigKeyValue;
                                }
                            }

                            string paymentMethod = (range.Cells[rowIndex, 19] as Range).Text.ToString();
                            if (!string.IsNullOrEmpty(paymentMethod))
                            {
                                ADConfigValuesInfo objConfigValuesInfo = configValueList.Where(cv => cv.ADConfigText == paymentMethod && cv.ADConfigKeyGroup == ConfigValueGroup.PaymentMethod).FirstOrDefault();
                                if (objConfigValuesInfo != null)
                                {
                                    objSuppliersInfo.APPaymentMethodCombo = objConfigValuesInfo.ADConfigKeyValue;
                                }
                            }

                            string currencyName = (range.Cells[rowIndex, 21] as Range).Text.ToString();
                            if (!string.IsNullOrEmpty(currencyName))
                            {
                                GECurrenciesInfo objCurrenciesInfo = (GECurrenciesInfo)objCurrenciesController.GetObjectByName(currencyName);
                                if (objCurrenciesInfo != null)
                                {
                                    objSuppliersInfo.FK_GECurrencyID = objCurrenciesInfo.GECurrencyID;
                                }
                            }
                            objSuppliersController.CreateObject(objSuppliersInfo);
                            BOSApp.UpdateObjectNumbering(ModuleName.Supplier);
                            supplierList.Add(objSuppliersInfo);
                            numberOfImportedRecords++;
                        }
                    }
                    BOSProgressBar.Close();
                    string resultMessage = ImportDataLocalizedResources.TotalRecordNumberImportSuccessMessage.Replace("{0}", numberOfImportedRecords.ToString());
                    MessageBox.Show(resultMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ReleaseDataImport();
            }
        }

        /// <summary>
        /// Import Stock to database from excel
        /// </summary>
        public void ImportStockFromExcel()
        {
            Range range = InitializeDataImport();
            if (range != null)
            {
                if (MessageBox.Show(ImportDataLocalizedResources.QuestionImportDataMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BOSProgressBar.Start(ImportDataLocalizedResources.ProgressBarMessage);
                    DataSet ds = new DataSet();
                    int numberOfImportedRecords = 0;
                    BRBranchsController objBranchsController = new BRBranchsController();
                    ICStocksController objStocksController = new ICStocksController();

                    BOSList<ICStocksInfo> stockList = new BOSList<ICStocksInfo>();
                    stockList.InitBOSList(CurrentModuleEntity, String.Empty, TableName.ICStocksTableName, BOSList<ICStocksInfo>.cstRelationNone);
                    ds = objStocksController.GetAllObjects();
                    stockList.Invalidate(ds);

                    for (int rowIndex = 2; rowIndex <= range.Rows.Count; rowIndex++)
                    {
                        string stockName = (range.Cells[rowIndex, 1] as Range).Text.ToString();
                        if (!string.IsNullOrEmpty(stockName))
                        {
                            ICStocksInfo objStockInfo = stockList.Where(st => st.ICStockName == stockName).FirstOrDefault();
                            if (objStockInfo == null)
                            {
                                objStockInfo = new ICStocksInfo();

                                int parentStockID = 0;
                                string parentStockName = (range.Cells[rowIndex, 2] as Range).Text.ToString();
                                if (!string.IsNullOrEmpty(parentStockName))
                                {
                                    ICStocksInfo objParentStockInfo = stockList.Where(st => st.ICStockName == parentStockName).FirstOrDefault();
                                    if (objParentStockInfo != null)
                                    {
                                        parentStockID = objParentStockInfo.ICStockID;
                                    }
                                }

                                int branchID = 0;
                                string branchName = (range.Cells[rowIndex, 3] as Range).Text.ToString();
                                if (!string.IsNullOrEmpty(branchName))
                                {
                                    BRBranchsInfo objBranchsInfo = objBranchsController.GetObjectByName(branchName) as BRBranchsInfo;
                                    if (objBranchsInfo != null)
                                    {
                                        branchID = objBranchsInfo.BRBranchID;
                                    }
                                }
                                objStockInfo.ICStockNo = BOSApp.GetMainObjectNo(ModuleName.Stock);
                                objStockInfo.ICStockName = stockName;
                                objStockInfo.ICStockParentID = parentStockID;
                                objStockInfo.FK_BRBranchID = branchID;
                                objStockInfo.ICStockContactAddressStreet = (range.Cells[rowIndex, 4] as Range).Text.ToString();
                                objStockInfo.ICStockContactAddressCity = (range.Cells[rowIndex, 5] as Range).Text.ToString();
                                objStockInfo.ICStockContactAddressStateProvince = (range.Cells[rowIndex, 6] as Range).Text.ToString();
                                objStockInfo.ICStockContactAddressCountry = (range.Cells[rowIndex, 7] as Range).Text.ToString();
                                objStockInfo.ICStockContactName = (range.Cells[rowIndex, 8] as Range).Text.ToString();
                                objStockInfo.ICStockContactPhone = (range.Cells[rowIndex, 9] as Range).Text.ToString();
                                objStockInfo.ICStockContactFax = (range.Cells[rowIndex, 10] as Range).Text.ToString();
                                objStockInfo.ICStockContactEmail1 = (range.Cells[rowIndex, 11] as Range).Text.ToString();
                                objStocksController.CreateObject(objStockInfo);
                                BOSApp.UpdateObjectNumbering(ModuleName.Stock);
                                stockList.Add(objStockInfo);
                                numberOfImportedRecords++;
                            }
                        }
                    }
                    BOSProgressBar.Close();
                    string resultMessage = ImportDataLocalizedResources.TotalRecordNumberImportSuccessMessage.Replace("{0}", numberOfImportedRecords.ToString());
                    MessageBox.Show(resultMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ReleaseDataImport();
            }
        }

        /// <summary>
        /// Import Branch to database from excel
        /// </summary>
        public void ImportBranchFromExcel()
        {
            Range range = InitializeDataImport();
            if (range != null)
            {
                if (MessageBox.Show(ImportDataLocalizedResources.QuestionImportDataMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BOSProgressBar.Start(ImportDataLocalizedResources.ProgressBarMessage);
                    DataSet ds = new DataSet();
                    int numberOfImportedRecords = 0;
                    BRBranchsController objBranchsController = new BRBranchsController();

                    for (int rowIndex = 2; rowIndex <= range.Rows.Count; rowIndex++)
                    {
                        string branchName = (range.Cells[rowIndex, 1] as Range).Text.ToString();
                        if (!string.IsNullOrEmpty(branchName))
                        {
                            BRBranchsInfo objBranchsInfo = objBranchsController.GetObjectByName(branchName) as BRBranchsInfo;
                            if (objBranchsInfo == null)
                            {
                                objBranchsInfo = new BRBranchsInfo();
                                objBranchsInfo.BRBranchNo = BOSApp.GetMainObjectNo(ModuleName.Branch);
                                objBranchsInfo.BRBranchName = branchName;
                                objBranchsInfo.BRBranchContactAddressStreet = (range.Cells[rowIndex, 2] as Range).Text.ToString();
                                objBranchsInfo.BRBranchContactAddressCity = (range.Cells[rowIndex, 3] as Range).Text.ToString();
                                objBranchsInfo.BRBranchContactAddressStateProvince = (range.Cells[rowIndex, 4] as Range).Text.ToString();
                                objBranchsInfo.BRBranchContactAddressCountry = (range.Cells[rowIndex, 5] as Range).Text.ToString();
                                objBranchsInfo.BRBranchContactName = (range.Cells[rowIndex, 6] as Range).Text.ToString();
                                objBranchsInfo.BRBranchContactPhone = (range.Cells[rowIndex, 7] as Range).Text.ToString();
                                objBranchsInfo.BRBranchContactFax = (range.Cells[rowIndex, 8] as Range).Text.ToString();
                                objBranchsInfo.BRBranchContactEmail1 = (range.Cells[rowIndex, 9] as Range).Text.ToString();
                                objBranchsController.CreateObject(objBranchsInfo);
                                BOSApp.UpdateObjectNumbering(ModuleName.Branch);
                                numberOfImportedRecords++;
                            }
                        }
                    }
                    BOSProgressBar.Close();
                    string resultMessage = ImportDataLocalizedResources.TotalRecordNumberImportSuccessMessage.Replace("{0}", numberOfImportedRecords.ToString());
                    MessageBox.Show(resultMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ReleaseDataImport();
            }
        }

        /// <summary>
        /// Imports the employee from excel
        /// </summary>
        public void ImportEmployeeFromExcel()
        {
            Range range = InitializeDataImport();
            if (range != null)
            {
                if (MessageBox.Show(ImportDataLocalizedResources.QuestionImportDataMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BOSProgressBar.Start(ImportDataLocalizedResources.ProgressBarMessage);
                    int numberOfImportedRecords = 0;
                    HREmployeesController objEmployeesController = new HREmployeesController();
                    HRDepartmentRoomsController objDepartmentRoomsController = new HRDepartmentRoomsController();
                    HRLevelsController objLevelsController = new HRLevelsController();
                    HRDepartmentsController objDepartmenController = new HRDepartmentsController();
                    BRBranchsController objBranchController = new BRBranchsController();

                    BOSList<HRDepartmentRoomsInfo> departmentRoomList = new BOSList<HRDepartmentRoomsInfo>();
                    departmentRoomList.InitBOSList(CurrentModuleEntity, String.Empty, TableName.HRDepartmentRoomsTableName, BOSList<HRDepartmentsInfo>.cstRelationNone);
                    DataSet ds = objDepartmentRoomsController.GetAllObjects();
                    departmentRoomList.Invalidate(ds);

                    BOSList<HRLevelsInfo> levelList = new BOSList<HRLevelsInfo>();
                    levelList.InitBOSList(CurrentModuleEntity, String.Empty, TableName.HRLevelsTableName, BOSList<HRLevelsInfo>.cstRelationNone);
                    ds = objLevelsController.GetAllObjects();
                    levelList.Invalidate(ds);
                    BOSList<HRDepartmentsInfo> departmentList = new BOSList<HRDepartmentsInfo>();
                    departmentList.InitBOSList(CurrentModuleEntity, String.Empty, TableName.HRDepartmentsTableName, BOSList<HRLevelsInfo>.cstRelationNone);
                    ds = objDepartmenController.GetAllObjects();
                    departmentList.Invalidate(ds);

                    BOSList<BRBranchsInfo> branchList = new BOSList<BRBranchsInfo>();
                    branchList.InitBOSList(CurrentModuleEntity, String.Empty, TableName.BRBranchsTableName, BOSList<HRLevelsInfo>.cstRelationNone);
                    ds = objBranchController.GetAllObjects();
                    branchList.Invalidate(ds);

                    BOSList<HREmployeesInfo> employeeList = new BOSList<HREmployeesInfo>();
                    employeeList.InitBOSList(CurrentModuleEntity, string.Empty, TableName.HREmployeesTableName, BOSList<HREmployeesInfo>.cstRelationNone);
                    ds = objEmployeesController.GetAllObjects();
                    employeeList.Invalidate(ds);

                    ADConfigValuesController objConfigValuesController = new ADConfigValuesController();
                    int daysPerMonth = Convert.ToInt32(objConfigValuesController.GetValueByConfigKey(ConfigValueKey.DaysPerMonth));
                    int hoursPerDay = Convert.ToInt32(objConfigValuesController.GetValueByConfigKey(ConfigValueKey.HoursPerDay));

                    List<ADConfigValuesInfo> genderList = GetConfigValuesByConfigKeyGroup(ConfigValueGroup.EmployeeGender);
                    Regex reg = new Regex("^([0-9]{1,2})/([0-9]{1,2})/([0-9]{4,4})$");
                    for (int rowIndex = 2; rowIndex <= range.Rows.Count; rowIndex++)
                    {
                        string employeeName = (range.Cells[rowIndex, 2] as Range).Text.ToString().Trim();
                        if (!string.IsNullOrEmpty(employeeName))
                        {
                            HREmployeesInfo employee = new HREmployeesInfo();
                            employee.HREmployeeName = employeeName;

                            string departmentRoomName = (range.Cells[rowIndex, 3] as Range).Text.ToString().Trim().ToLower();
                            if (!string.IsNullOrEmpty(departmentRoomName))
                            {
                                HRDepartmentRoomsInfo room = departmentRoomList.Where(d => d.HRDepartmentRoomName.Trim().ToLower() == departmentRoomName).FirstOrDefault();
                                if (room != null)
                                {
                                    //employee.FK_HRDepartmentID = room.FK_HRDepartmentID;
                                    employee.FK_HRDepartmentRoomID = room.HRDepartmentRoomID;
                                    //employee.FK_BRBranchID = room.FK_BRBranchID;
                                }
                            }

                            //Department
                            string departmentName = (range.Cells[rowIndex, 20] as Range).Text.ToString().Trim().ToLower();
                            if (!string.IsNullOrEmpty(departmentName))
                            {
                                HRDepartmentsInfo department = departmentList.Where(d => d.HRDepartmentName.Trim().ToLower() == departmentName).FirstOrDefault();
                                if (department != null)
                                {
                                    employee.FK_HRDepartmentID = department.HRDepartmentID;
                                }
                            }

                            //Branch
                            string branchNo = (range.Cells[rowIndex, 21] as Range).Text.ToString().Trim().ToLower();
                            if (!string.IsNullOrEmpty(branchNo))
                            {
                                BRBranchsInfo branch = branchList.Where(d => d.BRBranchNo.Trim().ToLower() == branchNo).FirstOrDefault();
                                if (branch != null)
                                {
                                    employee.FK_BRBranchID = branch.BRBranchID;
                                }
                            }

                            int levelID = 0;
                            string levelName = (range.Cells[rowIndex, 4] as Range).Text.ToString().Trim().ToLower();
                            if (!string.IsNullOrEmpty(levelName))
                            {
                                HRLevelsInfo objLevel = levelList.Where(l => l.HRLevelName.Trim().ToLower() == levelName).FirstOrDefault();
                                if (objLevel != null)
                                    levelID = objLevel.HRLevelID;
                            }
                            employee.FK_HRLevelID = levelID;

                            employee.HREmployeeIDNumber = (range.Cells[rowIndex, 5] as Range).Text.ToString().Trim();
                            string genderName = (range.Cells[rowIndex, 6] as Range).Text.ToString().Trim().ToLower();
                            if (!string.IsNullOrEmpty(genderName))
                            {
                                ADConfigValuesInfo objConfigValuesInfo = genderList.Where(g => g.ADConfigText.ToLower() == genderName).FirstOrDefault();
                                if (objConfigValuesInfo != null)
                                    employee.HREmployeeGenderCombo = objConfigValuesInfo.ADConfigKeyValue;
                            }

                            if (reg.IsMatch((range.Cells[rowIndex, 7] as Range).Text.ToString().Trim()))
                            {
                                employee.HREmployeeDob = Convert.ToDateTime((range.Cells[rowIndex, 7] as Range).Text);
                            }
                            employee.HREmployeeTel2 = (range.Cells[rowIndex, 8] as Range).Text.ToString().Trim();
                            employee.HREmployeeEmail1 = (range.Cells[rowIndex, 9] as Range).Text.ToString().Trim();
                            employee.HREmployeeContactAddressLine1 = (range.Cells[rowIndex, 10] as Range).Text.ToString().Trim();
                            employee.HREmployeeContactAddressLine3 = (range.Cells[rowIndex, 10] as Range).Text.ToString().Trim();
                            if (reg.IsMatch((range.Cells[rowIndex, 11] as Range).Text.ToString()))
                            {
                                employee.HREmployeeStartWorkingDate = Convert.ToDateTime((range.Cells[rowIndex, 11] as Range).Text.ToString().Trim());
                            }
                            employee.HREmployeeTaxNumber = (range.Cells[rowIndex, 12] as Range).Text.ToString().Trim();

                            employee.HREmployeeBankName = (range.Cells[rowIndex, 14] as Range).Text.ToString().Trim();
                            employee.HREmployeeBankAccount1 = (range.Cells[rowIndex, 15] as Range).Text.ToString().Trim();
                            if (!string.IsNullOrEmpty((range.Cells[rowIndex, 16] as Range).Text.ToString().Trim()))
                            {
                                double contractSalaryAmt = 0;
                                double.TryParse((range.Cells[rowIndex, 16] as Range).Text.ToString().Trim(), out contractSalaryAmt);
                                employee.HREmployeeContractSlrAmt = contractSalaryAmt;
                                //employee.HREmployeeContractSlrAmt = Convert.ToDouble((range.Cells[rowIndex, 16] as Range).Text.ToString().Trim());
                            }
                            if (!string.IsNullOrEmpty((range.Cells[rowIndex, 17] as Range).Text.ToString()))
                            {
                                double salaryFactor = 0;
                                double.TryParse((range.Cells[rowIndex, 17] as Range).Text.ToString().Trim(), out salaryFactor);
                                employee.HREmployeeSalaryFactor = salaryFactor;
                                //employee.HREmployeeSalaryFactor = Convert.ToDouble((range.Cells[rowIndex, 17] as Range).Text.ToString().Trim());
                            }
                            if (!string.IsNullOrEmpty((range.Cells[rowIndex, 18] as Range).Text.ToString()))
                            {
                                double workingSlrAmt = 0;
                                double.TryParse((range.Cells[rowIndex, 18] as Range).Text.ToString().Trim(), out workingSlrAmt);
                                employee.HREmployeeWorkingSlrAmt = workingSlrAmt;
                                //employee.HREmployeeWorkingSlrAmt = Convert.ToDouble((range.Cells[rowIndex, 18] as Range).Text.ToString().Trim());
                            }
                            if (!string.IsNullOrEmpty((range.Cells[rowIndex, 19] as Range).Text.ToString()))
                            {
                                employee.HREmployeeStatusCombo = (range.Cells[rowIndex, 19] as Range).Text.ToString().Trim();
                            }
                            else
                            {
                                employee.HREmployeeStatusCombo = EmployeeStatus.Working.ToString();
                            }

                            //Set default salary info
                            employee.HRPayRollCalculatedSalaryType = CalculatedSalaryType.Working.ToString();
                            employee.HREmployeeDaysPerMonth = daysPerMonth;
                            employee.HREmployeeHoursPerDay = hoursPerDay;
                            employee.HREmployeeContractDailySalary = (employee.HREmployeeContractSlrAmt * employee.HREmployeeSalaryFactor) / employee.HREmployeeDaysPerMonth;
                            employee.HREmployeeContractHourlySalary = (employee.HREmployeeContractSlrAmt * employee.HREmployeeSalaryFactor) / (employee.HREmployeeDaysPerMonth * employee.HREmployeeHoursPerDay);
                            employee.HREmployeeWorkingDailySalary = employee.HREmployeeWorkingSlrAmt / employee.HREmployeeDaysPerMonth;
                            employee.HREmployeeWorkingHourlySalary = employee.HREmployeeWorkingSlrAmt / (employee.HREmployeeDaysPerMonth * employee.HREmployeeHoursPerDay);

                            //Set default insuarance info
                            employee.HRInsCalculatedSalaryType = CalculatedSalaryType.Basic.ToString();
                            employee.HREmployeeSocialInsPaymentPercent = 6;
                            employee.HREmployeeHealthInsPaymentPercent = 1.5;
                            employee.HREmployeeOutOfWorkInsPaymentPercent = 1;
                            employee.HREmployeeSyndicatePaymentPercent = 1;

                            HREmployeesInfo existingEmployee = employeeList.Where(e => e.HREmployeeName.Trim() == employee.HREmployeeName &&
                                                                                e.FK_HRDepartmentRoomID == employee.FK_HRDepartmentRoomID).FirstOrDefault();
                            if (existingEmployee != null)
                            {
                                employee.HREmployeeID = existingEmployee.HREmployeeID;
                                employee.HREmployeeNo = existingEmployee.HREmployeeNo;
                                objEmployeesController.UpdateObject(employee);
                            }
                            else
                            {
                                employee.HREmployeeNo = BOSApp.GetMainObjectNo(ModuleName.SellStaff);
                                objEmployeesController.CreateObject(employee);
                                BOSApp.UpdateObjectNumbering(ModuleName.SellStaff);
                                employeeList.Add(employee);
                            }
                            numberOfImportedRecords++;
                        }
                    }
                    BOSProgressBar.Close();
                    string resultMessage = ImportDataLocalizedResources.TotalRecordNumberImportSuccessMessage.Replace("{0}", numberOfImportedRecords.ToString());
                    MessageBox.Show(resultMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ReleaseDataImport();
            }
        }

        /// <summary>
        /// Gets the config values by config key group
        /// </summary>
        /// <param name="configKeyGroup">The config key group</param>
        /// <returns>The config value list</returns>
        public List<ADConfigValuesInfo> GetConfigValuesByConfigKeyGroup(string configKeyGroup)
        {
            List<ADConfigValuesInfo> configValueList = new List<ADConfigValuesInfo>();
            ADConfigValuesController objConfigValuesController = new ADConfigValuesController();
            DataSet ds = objConfigValuesController.GetADConfigValuesByGroup(configKeyGroup);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ADConfigValuesInfo objConfigValuesInfo = (ADConfigValuesInfo)objConfigValuesController.GetObjectFromDataRow(row);
                    configValueList.Add(objConfigValuesInfo);
                }
            }
            return configValueList;
        }

        /// <summary>
        /// Imports the customer from excel
        /// </summary>
        public void ImportCustomerFromExcel()
        {
            Range range = InitializeDataImport();
            if (range != null)
            {
                if (MessageBox.Show(ImportDataLocalizedResources.QuestionImportDataMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BOSProgressBar.Start(ImportDataLocalizedResources.ProgressBarMessage);
                    int numberOfImportedRecords = 0;
                    GECurrenciesController objCurrenciesController = new GECurrenciesController();
                    ARCustomersController objCustomersController = new ARCustomersController();
                    GELocationsController objLocationsController = new GELocationsController();

                    List<GECurrenciesInfo> currencyList = objCurrenciesController.GetAllCurrencys();
                    List<GELocationsInfo> locationList = objLocationsController.GetAllLocationList();
                    List<ADConfigValuesInfo> customerTypeList = GetConfigValuesByConfigKeyGroup(ConfigValueGroup.CustomerType);
                    List<ADConfigValuesInfo> paymentMenthodList = GetConfigValuesByConfigKeyGroup(ConfigValueGroup.PaymentMethod);
                    List<string> customerKeyList = new List<string>();
                    for (int rowIndex = 2; rowIndex <= range.Rows.Count; rowIndex++)
                    {
                        string customerName = (range.Cells[rowIndex, 2] as Range).Text.ToString().Trim();
                        if (!string.IsNullOrEmpty(customerName))
                        {
                            ARCustomersInfo objCustomersInfo = new ARCustomersInfo();
                            objCustomersInfo.ARCustomerNo = BOSApp.GetMainObjectNo(ModuleName.Customer);
                            objCustomersInfo.ARCustomerName = customerName;
                            string customerTypeText = (range.Cells[rowIndex, 3] as Range).Text.ToString().Trim().ToLower();
                            if (!string.IsNullOrEmpty(customerTypeText))
                            {
                                ADConfigValuesInfo objConfigValuesInfo = customerTypeList.Where(g => g.ADConfigText.ToLower() == customerTypeText).FirstOrDefault();
                                if (objConfigValuesInfo != null)
                                    objCustomersInfo.ARCustomerTypeCombo = objConfigValuesInfo.ADConfigKeyValue;
                            }

                            objCustomersInfo.ARCustomerContactName = (range.Cells[rowIndex, 5] as Range).Text.ToString().Trim();
                            if (string.IsNullOrEmpty(objCustomersInfo.ARCustomerContactName))
                                objCustomersInfo.ARCustomerContactName = customerName;

                            objCustomersInfo.ARCustomerContactPhone = (range.Cells[rowIndex, 6] as Range).Text.ToString().Trim();
                            objCustomersInfo.ARCustomerContactCellPhone = (range.Cells[rowIndex, 7] as Range).Text.ToString().Trim();
                            if (string.IsNullOrEmpty(objCustomersInfo.ARCustomerContactPhone))
                            {
                                objCustomersInfo.ARCustomerContactPhone = objCustomersInfo.ARCustomerContactCellPhone;
                                objCustomersInfo.ARCustomerContactCellPhone = string.Empty;
                            }
                            objCustomersInfo.ARCustomerContactFax = (range.Cells[rowIndex, 8] as Range).Text.ToString().Trim();
                            objCustomersInfo.ARCustomerContactAddressLine1 = (range.Cells[rowIndex, 9] as Range).Text.ToString().Trim();
                            objCustomersInfo.ARCustomerContactAddressLine3 = objCustomersInfo.ARCustomerContactAddressLine1;

                            //Set location
                            string districName = (range.Cells[rowIndex, 10] as Range).Text.ToString().Trim().ToLower();
                            string cityName = (range.Cells[rowIndex, 11] as Range).Text.ToString().Trim().ToLower();
                            string countryName = (range.Cells[rowIndex, 12] as Range).Text.ToString().Trim().ToLower();
                            int locationID = 0;
                            if (string.IsNullOrEmpty(districName) && string.IsNullOrEmpty(cityName))
                            {
                                GELocationsInfo objLocationsInfo = locationList.Where(l => l.GELocationName.ToLower() == countryName).FirstOrDefault();
                                if (objLocationsInfo != null)
                                    locationID = objLocationsInfo.GELocationID;
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(districName))
                                {
                                    GELocationsInfo locationParent = locationList.Where(l => l.GELocationName.ToLower() == countryName).FirstOrDefault();
                                    if (locationParent != null)
                                    {
                                        GELocationsInfo objLocationsInfo = locationList.Where(l => l.GELocationName.ToLower() == cityName && l.GELocationParentID == locationParent.GELocationID).FirstOrDefault();
                                        if (objLocationsInfo != null)
                                            locationID = objLocationsInfo.GELocationID;
                                        else
                                            locationID = locationParent.GELocationID;
                                    }
                                    else
                                    {
                                        GELocationsInfo objLocationsInfo = locationList.Where(l => l.GELocationName.ToLower() == cityName).FirstOrDefault();
                                        if (objLocationsInfo != null)
                                            locationID = objLocationsInfo.GELocationID;
                                    }
                                }
                                else
                                {
                                    GELocationsInfo locationParent = locationList.Where(l => l.GELocationName.ToLower() == cityName).FirstOrDefault();
                                    if (locationParent != null)
                                    {
                                        GELocationsInfo objLocationsInfo = locationList.Where(l => l.GELocationName.ToLower() == districName && l.GELocationParentID == locationParent.GELocationID).FirstOrDefault();
                                        if (objLocationsInfo != null)
                                            locationID = objLocationsInfo.GELocationID;
                                        else
                                            locationID = locationParent.GELocationID;
                                    }
                                    else
                                    {
                                        GELocationsInfo objLocationsInfo = locationList.Where(l => l.GELocationName.ToLower() == districName).FirstOrDefault();
                                        if (objLocationsInfo != null)
                                            locationID = objLocationsInfo.GELocationID;
                                    }
                                }
                            }

                            objCustomersInfo.FK_GELocationID = locationID;
                            objCustomersInfo.ARCustomerInvoiceAddressLine1 = (range.Cells[rowIndex, 13] as Range).Text.ToString().Trim();
                            objCustomersInfo.ARCustomerInvoiceAddressLine3 = objCustomersInfo.ARCustomerInvoiceAddressLine1;
                            objCustomersInfo.ARCustomerDeliveryAddressLine1 = (range.Cells[rowIndex, 14] as Range).Text.ToString().Trim();
                            objCustomersInfo.ARCustomerDeliveryAddressLine3 = objCustomersInfo.ARCustomerDeliveryAddressLine1;
                            objCustomersInfo.ARCustomerPaymentAddressLine1 = (range.Cells[rowIndex, 15] as Range).Text.ToString().Trim();
                            objCustomersInfo.ARCustomerPaymentAddressLine3 = objCustomersInfo.ARCustomerPaymentAddressLine1;
                            ARPriceLevelsInfo defaultPriceLevel = (ARPriceLevelsInfo)BOSApp.GetFirstObjectFromLookupTable(TableName.ARPriceLevelsTableName);
                            if (defaultPriceLevel != null)
                            {
                                objCustomersInfo.FK_ARPriceLevelID = defaultPriceLevel.ARPriceLevelID;
                            }

                            string paymentMethodText = (range.Cells[rowIndex, 16] as Range).Text.ToString().Trim().ToLower();
                            if (!string.IsNullOrEmpty(customerTypeText))
                            {
                                ADConfigValuesInfo objConfigValuesInfo = paymentMenthodList.Where(g => g.ADConfigText.ToLower() == paymentMethodText).FirstOrDefault();
                                if (objConfigValuesInfo != null)
                                    objCustomersInfo.ARPaymentMethodCombo = objConfigValuesInfo.ADConfigKeyValue;
                            }
                            objCustomersInfo.ARCustomerTaxNumber = (range.Cells[rowIndex, 17] as Range).Text.ToString().Trim();
                            string currencyNo = (range.Cells[rowIndex, 18] as Range).Text.ToString().Trim().ToLower();
                            if (!string.IsNullOrEmpty(customerTypeText))
                            {
                                GECurrenciesInfo objCurrenciesInfo = currencyList.Where(c => c.GECurrencyNo.ToLower() == currencyNo).FirstOrDefault();
                                if (objCurrenciesInfo != null)
                                    objCustomersInfo.FK_GECurrencyID = objCurrenciesInfo.GECurrencyID;
                            }

                            string customerKey = string.Format("{0};{1};{2};{3}", objCustomersInfo.ARCustomerContactPhone.Replace(" ", string.Empty), objCustomersInfo.ARCustomerContactCellPhone.Replace(" ", string.Empty), districName, cityName);
                            if (!customerKeyList.Exists(e => e == customerKey))
                            {
                                customerKeyList.Add(customerKey);
                                objCustomersController.CreateObject(objCustomersInfo);
                                BOSApp.UpdateObjectNumbering(ModuleName.Customer);
                                numberOfImportedRecords++;
                            }
                        }
                    }
                    BOSProgressBar.Close();
                    string resultMessage = ImportDataLocalizedResources.TotalRecordNumberImportSuccessMessage.Replace("{0}", numberOfImportedRecords.ToString());
                    MessageBox.Show(resultMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ReleaseDataImport();
            }
        }

        /// <summary>
        /// Export product
        /// </summary>
        public void ExportProduct()
        {
            guiExportProduct guiExportProduct = new guiExportProduct();
            guiExportProduct.Module = this;
            guiExportProduct.ShowDialog();
        }

        /// <summary>
        /// Update the inventory cost
        /// </summary>
        public void UpdateInventoryCost()
        {
            Range range = InitializeDataImport();
            if (range != null)
            {
                BOSProgressBar.Start(ImportDataLocalizedResources.ProgressBarMessage);
                ICInventoryStocksController objInventoryStocksController = new ICInventoryStocksController();
                for (int row = 2; row <= range.Rows.Count; row++)
                {
                    int productID = Convert.ToInt32((range.Cells[row, 1] as Range).Text.ToString().Trim());
                    double cost = 0;
                    if (double.TryParse((range.Cells[row, 5] as Range).Text.ToString().Trim(), out cost))
                    {
                        if (cost > 0)
                        {
                            objInventoryStocksController.UpdateInventoryCostByProductID(productID, cost);
                        }
                    }
                }
                BOSProgressBar.Close();
            }
        }

        /// <summary>
        /// Update the product price
        /// </summary>
        public void UpdateProductPrice()
        {
            guiChooseBranch guiChooseBranch = new guiChooseBranch();
            guiChooseBranch.Module = this;
            if (guiChooseBranch.ShowDialog() == DialogResult.OK)
            {
                BOSProgressBar.Start(ImportDataLocalizedResources.ProgressBarMessage);
                ICProductsController objProductsController = new ICProductsController();
                List<ICProductsInfo> products = objProductsController.GetAllProducts();
                ICProductBranchPricesController objProductBranchPricesController = new ICProductBranchPricesController();
                int branchID = guiChooseBranch.SelectedBranchID;
                foreach (ICProductsInfo product in products)
                {
                    int productID = product.ICProductID;
                    ICProductBranchPricesInfo productPrice = objProductBranchPricesController.GetProductPriceByProductIDAndBranchIDAndCurrencyIDAndType(
                                                                                                                                        productID,
                                                                                                                                        branchID,
                                                                                                                                        100000,
                                                                                                                                        ProductBranchPriceType.Sale.ToString());
                    if (productPrice == null)
                    {
                        productPrice = new ICProductBranchPricesInfo();
                        productPrice.FK_ICProductID = productID;
                        productPrice.FK_BRBranchID = branchID;
                        productPrice.FK_GECurrencyID = 100000;
                        productPrice.ICProductBranchPrice = 0;
                        productPrice.ICProductBranchPriceType = ProductBranchPriceType.Sale.ToString();
                        objProductBranchPricesController.CreateObject(productPrice);
                    }
                }
                BOSProgressBar.Close();
            }
        }

        public void SyncInventory()
        {
            guiChooseBranch guiChooseBranch = new guiChooseBranch();
            guiChooseBranch.Module = this;
            if (guiChooseBranch.ShowDialog() == DialogResult.OK)
            {
                BOSProgressBar.Start(ImportDataLocalizedResources.ProgressBarMessage);
                BRBranchsController objBranchsController = new BRBranchsController();
                BRBranchsInfo centre = objBranchsController.GetCentre();
                if (centre != null)
                {
                    int branchID = guiChooseBranch.SelectedBranchID;
                    SqlDatabase database = BOSApp.CreateConnectionToBranch(centre.BRBranchID);
                    if (BOSApp.TestConnection(database))
                    {
                        DataSet ds = database.ExecuteDataSet("ICInventoryStocks_GetInventoryStocksByBranchID", branchID);
                        if (ds.Tables.Count > 0)
                        {
                            ICInventoryStocksController objInventoryStocksController = new ICInventoryStocksController();
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                ICInventoryStocksInfo inventoryStock = (ICInventoryStocksInfo)objInventoryStocksController.GetObjectFromDataRow(row);
                                CurrentModuleEntity.SynProductSerie(inventoryStock);
                                ICInventoryStocksInfo existingInventoryStock = objInventoryStocksController.GetInventoryStockByStockIDAndProductIDAndSerieID(
                                                                                                                        inventoryStock.FK_ICStockID,
                                                                                                                        inventoryStock.FK_ICProductID,
                                                                                                                        inventoryStock.FK_ICProductSerieID);
                                if (existingInventoryStock == null)
                                {
                                    inventoryStock.AAUpdatedDate = DateTime.Now;
                                    inventoryStock.IsTransferred = true;
                                    inventoryStock.ICInventoryStockTransferredDate = DateTime.Now.AddSeconds(BOSCommon.App.UpdateSeconds);
                                    objInventoryStocksController.CreateObject(inventoryStock);
                                }
                            }
                        }
                    }
                }
                BOSProgressBar.Close();
            }
        }

        public void CreateProgessNote()
        {
            try
            {
                //string fileData = "E:\\CLAS\\MS Access\\BENHAN_4CreateProgessNote.xlsx";

                Range range = InitializeDataImport();
                if (range != null)
                {
                    BOSProgressBar.Start("Dang tao file benh an");

                    for (int row = 2; row <= range.Rows.Count; row++)
                    {
                        string fileName = (range.Cells[row, 3] as Range).Text.ToString();
                        fileName = "E:\\CLAS\\MS Access\\RFTs\\" + fileName;

                        string content = (range.Cells[row, 2] as Range).Text.ToString();

                        //RichTextBoxExtended richTextBox = new RichTextBoxExtended();
                        //richTextBox.rtb1.Rtf = content;
                        //richTextBox.SaveFile(fileName);

                        //RichTextBox richTextBox2 = new RichTextBox();
                        //richTextBox2.Rtf = content;
                        //richTextBox2.SaveFile(fileName, RichTextBoxStreamType.RichText);

                        DevExpress.XtraRichEdit.RichEditControl r = new RichEditControl();
                        r.Text = content;
                        r.SaveDocument(fileName, DocumentFormat.Rtf);
                    }
                    BOSProgressBar.Close();
                    MessageBox.Show("Tao benh an thanh cong!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
