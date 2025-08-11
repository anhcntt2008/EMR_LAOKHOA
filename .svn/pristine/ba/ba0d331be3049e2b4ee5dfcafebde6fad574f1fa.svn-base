using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;
using BOSCommon;
using BOSLib;


namespace BOSERP
{
    partial class ERPModuleEntities
    {
        #region Set Default Values from Customer, Supplier, Employee
        public virtual void SetDefaultValuesFromCustomer(ARCustomersInfo objCustomersInfo)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            String mainTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            String mainTablePrefix = mainTableName.Substring(0, mainTableName.Length - 1);
            
            dbUtil.SetPropertyValue(MainObject, String.Format("{0}PaymentMethodCombo", mainTableName.Substring(0, 2)), objCustomersInfo.ARPaymentMethodCombo);
            dbUtil.SetPropertyValue(MainObject, String.Format("{0}PaymentTerm", mainTablePrefix), objCustomersInfo.ARCustomerPaymentTerm);

            //Copy addresses
            PropertyInfo[] props = objCustomersInfo.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
                if (prop.Name.Contains("Address"))
                    dbUtil.SetPropertyValue(MainObject, String.Format("{0}{1}", mainTablePrefix, prop.Name.Substring(10)), prop.GetValue(objCustomersInfo, null));
        }

        public virtual void SetDefaultValuesFromSupplier(APSuppliersInfo objSuppliersInfo)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            String mainTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            String mainTablePrefix = mainTableName.Substring(0, mainTableName.Length - 1);

            dbUtil.SetPropertyValue(MainObject, String.Format("{0}PaymentMethodCombo", mainTableName.Substring(0, 2)), objSuppliersInfo.APPaymentMethodCombo);
            dbUtil.SetPropertyValue(MainObject, String.Format("{0}PaymentTerm", mainTablePrefix), objSuppliersInfo.APSupplierPaymentTerm);
        }

        public virtual void SetDefaultValuesFromEmployee(int iEmployeeID, String strPrimaryTableName)
        {

        }
        #endregion

        #region Set Default Values From Product
        public virtual void SetValuesAfterValidateProduct(int iICProductID)
        {
            SetDefaultValuesFromProduct(iICProductID);
            SetProductPrice();
        }

        public virtual void SetValuesAfterValidateProduct(int productID, string itemTableName)
        {
            SetDefaultValuesFromProduct(productID, itemTableName);
            SetProductPrice(itemTableName);
        }

        public virtual void SetValuesAfterValidateProduct(BusinessObject item)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            int productID = dbUtil.GetPropertyIntValue(item, "FK_ICProductID");            
            string itemTableName = BOSUtil.GetTableNameFromBusinessObject(item);
            SetDefaultValuesFromProduct(productID, item);
            SetProductPrice(item);
        }

        public virtual void SetDefaultValuesFromProduct(int iICProductID, string strItemTableName)
        {
            if (ModuleObjects[strItemTableName] != null)
            {
                SetDefaultValuesFromProduct(iICProductID, ModuleObjects[strItemTableName]);
            }
        }

        public virtual void SetDefaultValuesFromProduct(int iICProductID)
        {
            String strMainTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            String strItemTableName = strMainTableName.Substring(0, strMainTableName.Length - 1) + "Items";
            SetDefaultValuesFromProduct(iICProductID, strItemTableName);
        }

        public virtual void SetDefaultValuesFromProduct(int productID, BusinessObject item)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            ICProductsController objICProductsController = new ICProductsController();
            ICProductsInfo objICProductsInfo = (ICProductsInfo)objICProductsController.GetObjectByID(productID);
            string itemTableName = BOSUtil.GetTableNameFromBusinessObject(item);            
            if (objICProductsInfo != null)
            {
                //Set product id                    
                dbUtil.SetPropertyValue(item, "FK_ICProductID", objICProductsInfo.ICProductID);

                //Set department id
                dbUtil.SetPropertyValue(item, "FK_ICDepartmentID", objICProductsInfo.FK_ICDepartmentID);

                //Set product group id
                dbUtil.SetPropertyValue(item, "FK_ICProductGroupID", objICProductsInfo.FK_ICProductGroupID);

                //Set Product Name
                String strColumnName = strColumnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductName";
                dbUtil.SetPropertyValue(item, strColumnName, objICProductsInfo.ICProductName);

                // Set Product Description
                strColumnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductDesc";
                dbUtil.SetPropertyValue(item, strColumnName, objICProductsInfo.ICProductDesc);

                // Set product attribute
                strColumnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductAttribute";
                dbUtil.SetPropertyValue(item, strColumnName, objICProductsInfo.ICProductAttribute);

                //Set Product Type
                strColumnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductType";
                dbUtil.SetPropertyValue(item, strColumnName, objICProductsInfo.ICProductType);

                //Set Product Unit Cost
                strColumnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductUnitCost";
                dbUtil.SetPropertyValue(item, strColumnName, objICProductsInfo.ICProductSupplierPrice);

                //Set Product Sell Unit
                strColumnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductSellUnit";
                dbUtil.SetPropertyValue(item, strColumnName, objICProductsInfo.ICProductSellUnit);

                //Set Product Basic Unit
                strColumnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductBasicUnit";
                dbUtil.SetPropertyValue(item, strColumnName, objICProductsInfo.ICProductBasicUnit);

                //Set Product Packaging Unit
                strColumnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductPackagingUnit";
                dbUtil.SetPropertyValue(item, strColumnName, objICProductsInfo.ICProductPackUnit);

                //Set Product Sell Factor
                strColumnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductSellFactor";
                dbUtil.SetPropertyValue(item, strColumnName, objICProductsInfo.ICProductBasicToSell);

                //Set Product Packaging Factor
                strColumnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductPackagingFactor";
                dbUtil.SetPropertyValue(item, strColumnName, objICProductsInfo.ICProductPackToBasic);

                //Set Product Picture
                strColumnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductPicture";
                dbUtil.SetPropertyValue(item, strColumnName, objICProductsInfo.ICProductPicture);

                //Set Product Stock and Slot
                dbUtil.SetPropertyValue(item, "FK_ICStockID", objICProductsInfo.FK_ICStockID);
                dbUtil.SetPropertyValue(item, "FK_ICStockSlotID", objICProductsInfo.FK_ICStockSlotID);

                //Set Product Default Tax Percent   
                double dbTaxPercent = SetDefaultProductTaxPercent(objICProductsInfo);
                strColumnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductTaxPercent";
                dbUtil.SetPropertyValue(item, strColumnName, dbTaxPercent);

                //Set default serial no
                dbUtil.SetPropertyValue(item, "FK_ICProductSerieID", 0);
                strColumnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductSerialNo";
                dbUtil.SetPropertyValue(item, strColumnName, string.Empty);
            }
        }

        public virtual void SetValuesAfterValidateProductQty()
        {
            SetProductPrice();
        }

        public virtual void SetValuesAfterValidateProductUnitPrice()
        {
            SetProductPriceByProductUnitPrice();
        }
      
        public virtual double SetDefaultProductTaxPercent(ICProductsInfo objICProductsInfo)
        {
            double dbTaxPercent = 0;
            int iGEVATID = objICProductsInfo.FK_GEVATID;
            if (iGEVATID > 0)
            {
                GEVATsController objGEVATsController = new GEVATsController();
                GEVATsInfo objGEVATsInfo = (GEVATsInfo)objGEVATsController.GetObjectByID(iGEVATID);
                if (objGEVATsInfo != null)
                {
                    dbTaxPercent = objGEVATsInfo.GEVATPercentValue;

                }
            }
            return dbTaxPercent;

        }

        #region Set Product Price
        public virtual void SetProductPrice(ERPModuleItemsEntity entItem, String strItemTableName)
        {
            SetProductPrice(entItem);
        }

        public virtual void SetProductPrice()
        {
            String strMainTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            String strItemTableName = strMainTableName.Substring(0, strMainTableName.Length - 1) + "Items";
            SetProductPrice(strItemTableName);
        }

        public virtual void SetProductPrice(string strItemTableName)
        {
            if (ModuleObjects[strItemTableName] != null)
            {
                SetProductPrice(ModuleObjects[strItemTableName]);
                UpdateModuleObjectBindingSource(strItemTableName);
            }
        }

        public virtual void SetProductPrice(BusinessObject objItem)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();

            String strMainTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            String strItemTableName = BOSUtil.GetTableNameFromBusinessObject(objItem);

            int iICProductID = Convert.ToInt32(dbUtil.GetPropertyValue(objItem, "FK_ICProductID"));

            String strColumnName = strMainTableName.Substring(0, strMainTableName.Length - 1) + "Date";
            DateTime dtMainObjectDate = Convert.ToDateTime(dbUtil.GetPropertyValue(MainObject, strColumnName));

            //Get Item Qty
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "ProductQty";
            double dbItemProductQty = Convert.ToDouble(dbUtil.GetPropertyValue(objItem, strColumnName));
            if (dbItemProductQty == 0)
            {
                dbItemProductQty = 1;
                dbUtil.SetPropertyValue(objItem, strColumnName, 1);
            }

            //Get Item Tax Percent
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "ProductTaxPercent";
            double dbItemProductTaxPercent = Convert.ToDouble(dbUtil.GetPropertyValue(objItem, strColumnName));

            //Get Item Unit Price
            int measureUnitID = dbUtil.GetPropertyIntValue(objItem, "FK_ICMeasureUnitID");
            double dbItemProductUnitPrice = CalculateProductPrice(iICProductID, measureUnitID);

            //Get Item Unit Cost
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "ProductUnitCost";
            double dbItemProductUnitCost = Convert.ToDouble(dbUtil.GetPropertyValue(objItem, strColumnName));

            //Set Item Unit Price
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "ProductUnitPrice";
            dbUtil.SetPropertyValue(objItem, strColumnName, dbItemProductUnitPrice);

            //Set Item Extended Price
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "Price";
            double dbItemPrice = dbItemProductUnitPrice * dbItemProductQty;
            dbUtil.SetPropertyValue(objItem, strColumnName, dbItemPrice);

            //Set Item Net Amount
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "NetAmount";
            double dbItemNetAmount = dbItemPrice;
            dbUtil.SetPropertyValue(objItem, strColumnName, dbItemNetAmount);

            //Set Item Discount Amount                
            double dbItemDiscountAmount = CalculateItemDiscountAmount(objItem, iICProductID, dbItemProductUnitPrice, dtMainObjectDate, dbItemProductQty);
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "DiscountAmount";
            dbUtil.SetPropertyValue(objItem, strColumnName, dbItemDiscountAmount);

            //Set item discount percent
            double itemDiscountPercent = 0;
            if (dbItemPrice != 0)
            {
                itemDiscountPercent = dbItemDiscountAmount / dbItemPrice * 100;
            }
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "ProductDiscount";
            dbUtil.SetPropertyValue(objItem, strColumnName, itemDiscountPercent);

            //Set Item Tax Amount
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "TaxAmount";
            double dbItemTaxAmount = ((dbItemNetAmount - dbItemDiscountAmount) * dbItemProductTaxPercent) / 100;
            dbUtil.SetPropertyValue(objItem, strColumnName, dbItemTaxAmount);

            //Set Item Total Amount
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "TotalAmount";
            dbUtil.SetPropertyValue(objItem, strColumnName, dbItemNetAmount + dbItemTaxAmount - dbItemDiscountAmount);

            //Set Item Total Cost
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "TotalCost";
            dbUtil.SetPropertyValue(objItem, strColumnName, dbItemProductQty * dbItemProductUnitCost);
        }

        public virtual void SetProductPriceByProductUnitPrice(ERPModuleItemsEntity entItem, String strItemTableName)
        {
            SetProductPriceByProductUnitPrice(entItem);
        }

        public virtual void SetProductPriceByProductUnitPrice(string itemTableName)
        {
            if (ModuleObjects[itemTableName] != null)
            {
                SetProductPriceByProductUnitPrice(ModuleObjects[itemTableName]);
                UpdateModuleObjectBindingSource(itemTableName);
            }
        }

        public virtual void SetProductPriceByProductUnitPrice()
        {
            String strMainTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            String strItemTableName = strMainTableName.Substring(0, strMainTableName.Length - 1) + "Items";
            if (ModuleObjects[strItemTableName] != null)
            {
                SetProductPriceByProductUnitPrice(ModuleObjects[strItemTableName]);
                UpdateModuleObjectBindingSource(strItemTableName);
            }
        }

        public virtual void SetProductPriceByProductUnitPrice(BusinessObject objItem)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();

            String strMainTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            String strItemTableName = BOSUtil.GetTableNameFromBusinessObject(objItem);

            int iICProductID = Convert.ToInt32(dbUtil.GetPropertyValue(objItem, "FK_ICProductID"));

            String strColumnName = strMainTableName.Substring(0, strMainTableName.Length - 1) + "Date";
            DateTime dtMainObjectStartDate = Convert.ToDateTime(dbUtil.GetPropertyValue(MainObject, strColumnName));

            //Get Item Unit Price
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "ProductUnitPrice";
            double dbProductUnitPrice = Convert.ToDouble(dbUtil.GetPropertyValue(objItem, strColumnName));

            //Get Item Qty
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "ProductQty";
            double dbProductQty = Convert.ToDouble(dbUtil.GetPropertyValue(objItem, strColumnName));

            //Get item discount percent
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "ProductDiscount";
            double itemDiscountPercent = Convert.ToDouble(dbUtil.GetPropertyValue(objItem, strColumnName));

            //Get Item Tax Percent
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "ProductTaxPercent";
            double dbItemProductTaxPercent = Convert.ToDouble(dbUtil.GetPropertyValue(objItem, strColumnName));

            //Get Item Unit Cost
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "ProductUnitCost";
            double dbProductUnitCost = Convert.ToDouble(dbUtil.GetPropertyValue(objItem, strColumnName));

            //Set Item Extended Price
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "Price";
            double dbItemPrice = dbProductUnitPrice * dbProductQty;
            dbUtil.SetPropertyValue(objItem, strColumnName, dbItemPrice);

            //Set Item Net Amount
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "NetAmount";
            double dbItemNetAmount = dbItemPrice;
            dbUtil.SetPropertyValue(objItem, strColumnName, dbItemNetAmount);

            //Set Item Discount Amount                        
            double dbItemDiscountAmount = dbItemPrice * itemDiscountPercent / 100;
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "DiscountAmount";
            dbUtil.SetPropertyValue(objItem, strColumnName, dbItemDiscountAmount);

            //Set Item Tax Amount
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "TaxAmount";
            double dbItemTaxAmount = ((dbItemNetAmount - dbItemDiscountAmount) * dbItemProductTaxPercent) / 100;
            dbUtil.SetPropertyValue(objItem, strColumnName, dbItemTaxAmount);

            //Set Item Total Amount
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "TotalAmount";
            dbUtil.SetPropertyValue(objItem, strColumnName, dbItemNetAmount + dbItemTaxAmount - dbItemDiscountAmount);

            //Set Item Total Cost
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "TotalCost";
            dbUtil.SetPropertyValue(objItem, strColumnName, dbProductQty * dbProductUnitCost);
        }
        #endregion

        #region Set Product Cost
        /// <summary>
        /// Set cost for a new item
        /// </summary>
        /// <param name="item">Given item</param>
        public virtual void SetProductCost(BusinessObject item)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();

            string itemTableName = BOSUtil.GetTableNameFromBusinessObject(item);
            int productID = dbUtil.GetPropertyIntValue(item, "FK_ICProductID");

            //Get Item Qty
            String strColumnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductQty";
            double dbProductQty = Convert.ToDouble(dbUtil.GetPropertyValue(item, strColumnName));
            if (dbProductQty == 0)
            {
                dbProductQty = 1;
                dbUtil.SetPropertyValue(item, strColumnName, 1);
            }

            //Get Item Tax Percent
            strColumnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductTaxPercent";
            double dbItemProductTaxPercent = Convert.ToDouble(dbUtil.GetPropertyValue(item, strColumnName));

            //Set Item Unit Cost                            
            strColumnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductUnitCost";
            double dbProductUnitCost = CalculateProductCost(productID);
            dbUtil.SetPropertyValue(item, strColumnName, dbProductUnitCost);

            //Set Extended Cost
            strColumnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ExtCost";
            double dbItemExtCost = dbProductUnitCost * dbProductQty;
            dbUtil.SetPropertyValue(item, strColumnName, dbItemExtCost);

            //Set Item Tax Amount
            strColumnName = itemTableName.Substring(0, itemTableName.Length - 1) + "TaxAmount";
            double dbItemTaxAmount = (dbItemExtCost * dbItemProductTaxPercent) / 100;
            dbUtil.SetPropertyValue(item, strColumnName, dbItemTaxAmount);

            //Set Item Total Cost
            strColumnName = itemTableName.Substring(0, itemTableName.Length - 1) + "TotalCost";
            dbUtil.SetPropertyValue(item, strColumnName, dbItemExtCost + dbItemTaxAmount);
        }

        /// <summary>
        /// Set product cost for a new item
        /// </summary>
        /// <param name="item">Given item</param>
        /// <param name="itemTableName">Table name of item</param>
        public virtual void SetProductCost(ERPModuleItemsEntity item, string itemTableName)
        {
            SetProductCost(item);
        }

        public virtual void SetProductCostByProductUnitCost(BusinessObject objItem)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();

            String strItemTableName = BOSUtil.GetTableNameFromBusinessObject(objItem);

            //Get Item Qty
            String strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "ProductQty";
            double dbProductQty = Convert.ToDouble(dbUtil.GetPropertyValue(objItem, strColumnName));

            //Get Item Unit Cost            
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "ProductUnitCost";
            double dbProductUnitCost = Convert.ToDouble(dbUtil.GetPropertyValue(objItem, strColumnName));

            //Get item discount percent
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "ProductDiscount";
            double itemDiscountPercent = Convert.ToDouble(dbUtil.GetPropertyValue(objItem, strColumnName));

            //Get Item Tax Percent
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "ProductTaxPercent";
            double dbItemProductTaxPercent = Convert.ToDouble(dbUtil.GetPropertyValue(objItem, strColumnName));

            //Set Extended Cost
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "ExtCost";
            double dbItemExtCost = dbProductUnitCost * dbProductQty;
            dbUtil.SetPropertyValue(objItem, strColumnName, dbItemExtCost);

            //Set item discount amount
            double dbItemDiscountAmount = dbItemExtCost * itemDiscountPercent / 100;
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "DiscountAmount";
            dbUtil.SetPropertyValue(objItem, strColumnName, dbItemDiscountAmount);

            //Set Item Tax Amount
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "TaxAmount";
            double dbItemTaxAmount = ((dbItemExtCost - dbItemDiscountAmount) * dbItemProductTaxPercent) / 100;
            dbUtil.SetPropertyValue(objItem, strColumnName, dbItemTaxAmount);

            //Set Item Total Cost
            strColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "TotalCost";
            dbUtil.SetPropertyValue(objItem, strColumnName, dbItemExtCost + dbItemTaxAmount - dbItemDiscountAmount);
        }

        public virtual void SetProductCostByProductUnitCost(ERPModuleItemsEntity entItem, String strItemTableName)
        {
            SetProductCostByProductUnitCost(entItem);
        }

        public virtual void SetProductCostByProductUnitCost()
        {
            String strMainTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            String strItemTableName = strMainTableName.Substring(0, strMainTableName.Length - 1) + "Items";
            if (ModuleObjects[strItemTableName] != null)
            {
                SetProductCostByProductUnitCost(ModuleObjects[strItemTableName]);
                UpdateModuleObjectBindingSource(strItemTableName);
            }
        }

        /// <summary>
        /// Calculate the product cost
        /// </summary>
        /// <param name="productID">Product id</param>
        private double CalculateProductCost(int productID)
        {
            double productCost = 0;
            ICProductsController objProductsController = new ICProductsController();
            ICProductsInfo objProductsInfo = (ICProductsInfo)objProductsController.GetObjectByID(productID);
            if (objProductsInfo != null)
            {
                productCost = objProductsInfo.ICProductSupplierPrice;
            }
            return productCost;
        }
        #endregion

        public virtual double CalculateItemDiscountAmount(BusinessObject item, int productID, double productPrice, DateTime transactionDate, double itemQty)
        {
            double discountAmount = 0;
            ICProductsController objProductsController = new ICProductsController();
            ICProductsInfo objProductsInfo = (ICProductsInfo)objProductsController.GetObjectByID(productID);
            if (objProductsInfo != null)
            {
                objProductsInfo.ICProductPrice01 = productPrice;
                objProductsInfo.ICProductPrice01 = CalculateProductPriceBaseOnProductPriceLevel(objProductsInfo);
                discountAmount += CalculateDiscountAmountFromCustomer(objProductsInfo, transactionDate, itemQty);
                discountAmount += CalculateDiscountAmountFromPromotion(item, objProductsInfo, transactionDate, itemQty);
            }
            return discountAmount;
        }

        public virtual double CalculateDiscountAmountFromCustomer(ICProductsInfo objProductsInfo, DateTime transactionDate, double itemQty)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            double discountAmount = 0;
            String mainTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            int customerID = Convert.ToInt32(dbUtil.GetPropertyValue(MainObject, "FK_ARCustomerID"));
            if (customerID > 0)
            {
                ARCustomersController objCustomersController = new ARCustomersController();
                ARCustomersInfo objCustomersInfo = (ARCustomersInfo)objCustomersController.GetObjectByID(customerID);
                if (objCustomersInfo != null)
                    discountAmount += (objProductsInfo.ICProductPrice01 * objCustomersInfo.ARCustomerDiscount / 100) * itemQty;
            }
            return discountAmount;
        }

        public virtual double CalculateDiscountAmountFromPromotion(BusinessObject item, ICProductsInfo objProductsInfo, DateTime transactionDate, double itemQty)
        {
            //Change the quantity of current unit to the quantity of basic unit
            BOSDbUtil dbUtil = new BOSDbUtil();
            int measureUnitID = dbUtil.GetPropertyIntValue(item, "FK_ICMeasureUnitID");
            ICProductUnitsController objProductUnitsController = new ICProductUnitsController();
            ICProductUnitsInfo objProductUnitsInfo = objProductUnitsController.GetProductUnitByProductIDAndUnitID(objProductsInfo.ICProductID, measureUnitID);
            if (objProductUnitsInfo != null)
            {
                itemQty = itemQty * objProductUnitsInfo.ICProductUnitFactor;
            }

            double discountAmount = 0;
            ICPromotionsController objPromotionsController = new ICPromotionsController();
            ICPromotionItemsController objPromotionItemsController = new ICPromotionItemsController();
            DataSet ds = objPromotionItemsController.GetAllDataByForeignColumn("FK_ICProductID", objProductsInfo.ICProductID);
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ICPromotionItemsInfo objPromotionItemsInfo = (ICPromotionItemsInfo)objPromotionItemsController.GetObjectFromDataRow(row);
                    ICPromotionsInfo objPromotionsInfo = (ICPromotionsInfo)objPromotionsController.GetObjectByID(objPromotionItemsInfo.FK_ICPromotionID);
                    if (transactionDate.Date.CompareTo(objPromotionsInfo.ICPromotionStartDate.Date) >= 0 && transactionDate.Date.CompareTo(objPromotionsInfo.ICPromotionEndDate.Date) <= 0)
                    {
                        if (objPromotionsInfo.ICPromotionDiscountPercent > 0)
                            discountAmount += Math.Floor(itemQty / objPromotionsInfo.ICPromotionDiscountQty) * (objPromotionsInfo.ICPromotionDiscountQty * objProductsInfo.ICProductPrice01 * (objPromotionsInfo.ICPromotionDiscountPercent / 100));
                        else if (objPromotionsInfo.ICPromotionDiscountAmount > 0)
                            discountAmount += Math.Floor(itemQty / objPromotionsInfo.ICPromotionDiscountQty) * objPromotionsInfo.ICPromotionDiscountAmount;
                    }
                }
            }
            return discountAmount;
        }


        public void SetBasicAndPackageQty()
        {
            try
            {
                BOSDbUtil dbUtil = new BOSDbUtil();

                String strMainTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
                String strItemTableName = strMainTableName.Substring(0, strMainTableName.Length - 1) + "Items";

                String strItemProductQtyColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "ProductQty";
                String strItemProductSellFactorColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "ProductSellFactor";
                String strItemProductPackagingFactorColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "ProductPackagingFactor";
                String strItemProductBasicQtyColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "ProductBasicQty";
                String strItemProductPackagingQtyColumnName = strItemTableName.Substring(0, strItemTableName.Length - 1) + "ProductPakagingQty";

                int iICProductID = Convert.ToInt32(dbUtil.GetPropertyValue(ModuleObjects[strItemTableName], "FK_ICProductID"));

                double dbItemSellQty = Convert.ToDouble(dbUtil.GetPropertyValue(ModuleObjects[strItemTableName], strItemProductQtyColumnName));
                double dbSellFactor = Convert.ToDouble(dbUtil.GetPropertyValue(ModuleObjects[strItemTableName], strItemProductSellFactorColumnName));
                double dbItemPackagingFactor = Convert.ToDouble(dbUtil.GetPropertyValue(ModuleObjects[strItemTableName], strItemProductPackagingFactorColumnName));

                if (dbSellFactor > 0)
                {
                    double dbItemBasicQty = dbItemSellQty / dbSellFactor;
                    double dbItemPackagingQty = 0;
                    if (dbItemPackagingFactor > 0)
                        dbItemPackagingQty = dbItemBasicQty / dbItemPackagingFactor;

                    dbUtil.SetPropertyValue(ModuleObjects[strItemTableName], strItemProductBasicQtyColumnName, dbItemBasicQty);
                    dbUtil.SetPropertyValue(ModuleObjects[strItemTableName], strItemProductPackagingQtyColumnName, dbItemPackagingQty);
                }
                else
                {
                    dbUtil.SetPropertyValue(ModuleObjects[strItemTableName], strItemProductBasicQtyColumnName, 0);
                    dbUtil.SetPropertyValue(ModuleObjects[strItemTableName], strItemProductPackagingQtyColumnName, 0);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("SetBasicAndPackageQty ", "BOS Bug");
                return;
            }
        }        

        #region Calculate Product Price

        public virtual double CalculateProductPrice(int iICProductID, int measureUnitID)
        {
            double dbProductPrice = 0;
            ICProductsController objICProductsController = new ICProductsController();
            ICProductsInfo objICProductsInfo = (ICProductsInfo)objICProductsController.GetObjectByID(iICProductID);
            if (objICProductsInfo != null)
            {
                //Update the product's price by its unit
                ICProductUnitsController objProductUnitsController = new ICProductUnitsController();
                ICProductUnitsInfo objProductUnitsInfo = objProductUnitsController.GetProductUnitByProductIDAndUnitID(iICProductID, measureUnitID);
                if (objProductUnitsInfo != null)
                {
                    objICProductsInfo.ICProductPrice01 = objProductUnitsInfo.ICProductUnitPrice;
                }

                //Get Price from Product Price Level
                dbProductPrice = CalculateProductPriceBaseOnProductPriceLevel(objICProductsInfo);
            }

            return dbProductPrice;
        }

        protected virtual double CalculateProductPriceBaseOnProductPriceLevel(ICProductsInfo objICProductsInfo)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            double dbProductPrice = objICProductsInfo.ICProductPrice01;
            int priceLevelID = Convert.ToInt32(dbUtil.GetPropertyValue(MainObject, "FK_ARPriceLevelID"));
            if (priceLevelID > 0)
            {
                ICProductPricesController objProductPricesController = new ICProductPricesController();
                ICProductPricesInfo objProductPricesInfo = objProductPricesController.GetProductPriceByProductIDAndPriceLevelID(objICProductsInfo.ICProductID, priceLevelID);
                //If product has own price level
                if (objProductPricesInfo != null)
                    dbProductPrice = (1 - objProductPricesInfo.ICProductPriceMarkDown / 100) * objICProductsInfo.ICProductPrice01;
                //Else, get default price level
                else
                {
                    ARPriceLevelsController objPriceLevelsController = new ARPriceLevelsController();
                    ARPriceLevelsInfo objPriceLevelsInfo = (ARPriceLevelsInfo)objPriceLevelsController.GetObjectByID(priceLevelID);
                    if (objPriceLevelsInfo != null)
                        dbProductPrice = (1 - objPriceLevelsInfo.ARPriceLevelMarkDown / 100) * objICProductsInfo.ICProductPrice01;
                }
            }
            return dbProductPrice;
        }
        #endregion
        #endregion

        #region Get Range Days and Discount Percent from Payment Term
        public int GetRangeDays1FromPaymentTerm(String strPaymentTerm)
        {
            String strRangeDays1 = strPaymentTerm.Substring(0, 3);
            return Convert.ToInt32(strRangeDays1);
        }

        public double GetPercentDiscount1FromPaymentTerm(String strPaymentTerm)
        {
            int index = strPaymentTerm.IndexOf("%");
            String strPercentDiscount = strPaymentTerm.Substring(index - 4, 3);
            return Convert.ToDouble(strPercentDiscount);
        }

        public int GetRangeDays2FromPaymentTerm(String strPaymentTerm)
        {
            int index = strPaymentTerm.IndexOf(";");
            String strRangeDays2 = strPaymentTerm.Substring(index + 2, 3);
            return Convert.ToInt32(strRangeDays2);
        }

        public double GetPercentDiscount2FromPaymentTerm(String strPaymentTerm)
        {
            int index = strPaymentTerm.LastIndexOf("%");

            String strPercentDiscount = strPaymentTerm.Substring(index - 4, 3);
            return Convert.ToDouble(strPercentDiscount);
        }

        public int GetRangeDays3FromPaymentTerm(String strPaymentTerm)
        {
            int index = strPaymentTerm.LastIndexOf(";");
            String strRangeDays3 = strPaymentTerm.Substring(index + 2, 3);
            return Convert.ToInt32(strRangeDays3);
        }
        #endregion               

        /// <summary>
        /// Check before update inventory
        /// </summary>
        public virtual bool IsInvalidInventory()
        {
            return false;
        }        

        /// <summary>
        /// Get inventory status: empty, less than minimum quantity or greater than maximum quantity
        /// </summary>
        public virtual InventoryStatus GetInventoryStatus(BusinessObject obj, String itemTableName, String inventoryUpdateType)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            int productID = dbUtil.GetPropertyIntValue(obj, "FK_ICProductID");
            int stockID = dbUtil.GetPropertyIntValue(obj, "FK_ICStockID");
            int productSerieID = dbUtil.GetPropertyIntValue(obj, "FK_ICProductSerieID");
            double itemQty = Convert.ToInt32(dbUtil.GetPropertyValue(obj, itemTableName.Substring(0, itemTableName.Length - 1) + "ProductQty"));

            //Check for enough quantity
            ICInventoryStocksController objInventoryStocksController = new ICInventoryStocksController();
            ICInventoryStocksInfo objInventoryStocksInfo = null;
            if (productSerieID > 0)
            {
                objInventoryStocksInfo = objInventoryStocksController.GetInventoryStockByStockIDAndProductIDAndSerieID(stockID, productID, productSerieID);
            }
            else
            {
                objInventoryStocksInfo = objInventoryStocksController.GetInventoryStockByProductAndStock(productID, stockID);
            }
            if (objInventoryStocksInfo == null)
            {
                objInventoryStocksInfo = new ICInventoryStocksInfo();
            }
            switch (inventoryUpdateType)
            {
                case TransactionUtil.cstInventoryReceipt:
                    objInventoryStocksInfo.ICInventoryStockQuantity += itemQty;
                    break;
                case TransactionUtil.cstInventoryShipment:
                    objInventoryStocksInfo.ICInventoryStockQuantity -= itemQty;
                    break;
                case TransactionUtil.cstInventoryAdjust:
                    objInventoryStocksInfo.ICInventoryStockQuantity = itemQty;
                    break;
            }
            if (objInventoryStocksInfo.ICInventoryStockQuantity - objInventoryStocksInfo.ICInventoryStockSaleOrderQuantity < 0)
                return InventoryStatus.Empty;

            //Check for min, max quantity
            objInventoryStocksInfo = objInventoryStocksController.GetInventoryStockByProductAndStock(productID, stockID);
            if (objInventoryStocksInfo == null)
            {
                objInventoryStocksInfo = new ICInventoryStocksInfo();
            }
            switch (inventoryUpdateType)
            {
                case TransactionUtil.cstInventoryReceipt:
                    objInventoryStocksInfo.ICInventoryStockQuantity += itemQty;
                    break;
                case TransactionUtil.cstInventoryShipment:
                    objInventoryStocksInfo.ICInventoryStockQuantity -= itemQty;
                    break;
                case TransactionUtil.cstInventoryAdjust:
                    objInventoryStocksInfo.ICInventoryStockQuantity = itemQty;
                    break;
            }
            ICProductsController objProductsController = new ICProductsController();
            ICProductsInfo objProductsInfo = (ICProductsInfo)objProductsController.GetObjectByID(productID);
            if (objProductsInfo != null)
            {
                if (DateTime.Now.CompareTo(objProductsInfo.ICProductStockMinDateFrom) >= 0 && DateTime.Now.CompareTo(objProductsInfo.ICProductStockMinDateTo) <= 0)
                {
                    if (objInventoryStocksInfo.ICInventoryStockQuantity < objProductsInfo.ICProductStockMin)
                        return InventoryStatus.LessThanMinQty;
                }
                if (DateTime.Now.CompareTo(objProductsInfo.ICProductStockMaxDateFrom) >= 0 && DateTime.Now.CompareTo(objProductsInfo.ICProductStockMaxDateTo) <= 0)
                {
                    if (objInventoryStocksInfo.ICInventoryStockQuantity > objProductsInfo.ICProductStockMax)
                        return InventoryStatus.GreaterThanMaxQty;
                }
            }
            return InventoryStatus.Valid;
        }

        /// <summary>
        /// Get inventory status: empty, less than minimum quantity or greater than maximum quantity. And return stock quantity
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="itemTableName"></param>
        /// <param name="inventoryUpdateType"></param>
        /// <param name="stockQuantity"></param>
        /// <returns>stockQuantity</returns>
        public virtual InventoryStatus GetInventoryStatus(BusinessObject obj, String itemTableName, String inventoryUpdateType, ref double stockQuantityCanSale)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            int productID = dbUtil.GetPropertyIntValue(obj, "FK_ICProductID");
            int stockID = dbUtil.GetPropertyIntValue(obj, "FK_ICStockID");
            int productSerieID = dbUtil.GetPropertyIntValue(obj, "FK_ICProductSerieID");
            double itemQty = Convert.ToInt32(dbUtil.GetPropertyValue(obj, itemTableName.Substring(0, itemTableName.Length - 1) + "ProductQty"));

            //Check for enough quantity
            ICInventoryStocksController objInventoryStocksController = new ICInventoryStocksController();
            ICInventoryStocksInfo objInventoryStocksInfo = null;
            if (productSerieID > 0)
            {
                objInventoryStocksInfo = objInventoryStocksController.GetInventoryStockByStockIDAndProductIDAndSerieID(stockID, productID, productSerieID);
            }
            else
            {
                objInventoryStocksInfo = objInventoryStocksController.GetInventoryStockByProductAndStock(productID, stockID);
            }
            if (objInventoryStocksInfo == null)
            {
                objInventoryStocksInfo = new ICInventoryStocksInfo();
            }

            stockQuantityCanSale = objInventoryStocksInfo.ICInventoryStockQuantity - objInventoryStocksInfo.ICInventoryStockSaleOrderQuantity;

            switch (inventoryUpdateType)
            {
                case TransactionUtil.cstInventoryReceipt:
                    objInventoryStocksInfo.ICInventoryStockQuantity += itemQty;
                    break;
                case TransactionUtil.cstInventoryShipment:
                    objInventoryStocksInfo.ICInventoryStockQuantity -= itemQty;
                    break;
                case TransactionUtil.cstInventoryAdjust:
                    objInventoryStocksInfo.ICInventoryStockQuantity = itemQty;
                    break;
            }
            if (objInventoryStocksInfo.ICInventoryStockQuantity - objInventoryStocksInfo.ICInventoryStockSaleOrderQuantity < 0)
                return InventoryStatus.Empty;

            //Check for min, max quantity
            objInventoryStocksInfo = objInventoryStocksController.GetInventoryStockByProductAndStock(productID, stockID);
            if (objInventoryStocksInfo == null)
            {
                objInventoryStocksInfo = new ICInventoryStocksInfo();
            }

            stockQuantityCanSale = objInventoryStocksInfo.ICInventoryStockQuantity - objInventoryStocksInfo.ICInventoryStockSaleOrderQuantity;

            switch (inventoryUpdateType)
            {
                case TransactionUtil.cstInventoryReceipt:
                    objInventoryStocksInfo.ICInventoryStockQuantity += itemQty;
                    break;
                case TransactionUtil.cstInventoryShipment:
                    objInventoryStocksInfo.ICInventoryStockQuantity -= itemQty;
                    break;
                case TransactionUtil.cstInventoryAdjust:
                    objInventoryStocksInfo.ICInventoryStockQuantity = itemQty;
                    break;
            }
            ICProductsController objProductsController = new ICProductsController();
            ICProductsInfo objProductsInfo = (ICProductsInfo)objProductsController.GetObjectByID(productID);
            if (objProductsInfo != null)
            {
                if (DateTime.Now.CompareTo(objProductsInfo.ICProductStockMinDateFrom) >= 0 && DateTime.Now.CompareTo(objProductsInfo.ICProductStockMinDateTo) <= 0)
                {
                    if (objInventoryStocksInfo.ICInventoryStockQuantity < objProductsInfo.ICProductStockMin)
                        return InventoryStatus.LessThanMinQty;
                }
                if (DateTime.Now.CompareTo(objProductsInfo.ICProductStockMaxDateFrom) >= 0 && DateTime.Now.CompareTo(objProductsInfo.ICProductStockMaxDateTo) <= 0)
                {
                    if (objInventoryStocksInfo.ICInventoryStockQuantity > objProductsInfo.ICProductStockMax)
                        return InventoryStatus.GreaterThanMaxQty;
                }
            }

            return InventoryStatus.Valid;
        }

        /// <summary>
        /// Synchronize serie for an object when transferring from a branch to another
        /// </summary>
        /// <param name="obj">Given object</param>
        public void SynProductSerie(BusinessObject obj)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            string serieNo = dbUtil.GetPropertyStringValue(obj, "ICProductSerieNo");
            int productID = dbUtil.GetPropertyIntValue(obj, "FK_ICProductID");
            DateTime receiptDate = Convert.ToDateTime(dbUtil.GetPropertyValue(obj, "ICProductSerieReceiptDate"));
            if (!string.IsNullOrEmpty(serieNo))
            {
                ICProductSeriesController objProductSeriesController = new ICProductSeriesController();
                ICProductSeriesInfo objProductSeriesInfo = objProductSeriesController.GetSerieByProductIDAndSerieNo(productID, serieNo);
                if (objProductSeriesInfo != null)
                {
                    dbUtil.SetPropertyValue(obj, "FK_ICProductSerieID", objProductSeriesInfo.ICProductSerieID);
                }
                else
                {
                    objProductSeriesInfo = new ICProductSeriesInfo();
                    objProductSeriesInfo.AACreatedDate = DateTime.Now;
                    objProductSeriesInfo.FK_ICProductID = productID;
                    objProductSeriesInfo.ICProductSerieNo = serieNo;
                    int serieID = objProductSeriesController.CreateObject(objProductSeriesInfo);

                    dbUtil.SetPropertyValue(obj, "FK_ICProductSerieID", serieID);
                }
            }
        }
    }
}
