using System;
using System.Data;
using BOSCommon;
using BOSLib;

namespace BOSERP
{
    partial class ERPModuleEntities
    {
        /// <summary>
        ///     Check before update inventory
        /// </summary>
        public virtual bool IsInvalidInventory()
        {
            return false;
        }

        /// <summary>
        ///     Get inventory status: empty, less than minimum quantity or greater than maximum quantity
        /// </summary>
        public virtual InventoryStatus GetInventoryStatus(BusinessObject obj, string itemTableName,
            string inventoryUpdateType)
        {
            var productID = _dbUtil.GetPropertyIntValue(obj, "FK_ICProductID");
            var stockID = _dbUtil.GetPropertyIntValue(obj, "FK_ICStockID");
            var productSerieID = _dbUtil.GetPropertyIntValue(obj, "FK_ICProductSerieID");
            double itemQty =
                Convert.ToInt32(_dbUtil.GetPropertyValue(obj,
                    itemTableName.Substring(0, itemTableName.Length - 1) + "ProductQty"));
            return GetInventoryStatus(stockID, productID, productSerieID, itemQty, inventoryUpdateType);
        }

        //DDCan [ADD] [08/06/2017] [Ordered Inventory], START
        public virtual InventoryStatus GetInventoryStatus_AvailableQty(BusinessObject obj, string itemTableName,
            string inventoryUpdateType)
        {
            var productID = _dbUtil.GetPropertyIntValue(obj, "FK_ICProductID");
            var stockID = _dbUtil.GetPropertyIntValue(obj, "FK_ICStockID");
            var productSerieID = _dbUtil.GetPropertyIntValue(obj, "FK_ICProductSerieID");
            double itemQty =
                Convert.ToInt32(_dbUtil.GetPropertyValue(obj,
                    itemTableName.Substring(0, itemTableName.Length - 1) + "ProductQty"));
            return GetInventoryStatus_AvailableQty(stockID, productID, productSerieID, itemQty, inventoryUpdateType);
        }
        //DDCan [ADD] [08/06/2017] [Ordered Inventory], END

        /// <summary>
        ///     Get inventory status: empty, less than minimum quantity or greater than maximum quantity. And return stock quantity
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="itemTableName"></param>
        /// <param name="inventoryUpdateType"></param>
        /// <param name="stockQuantity"></param>
        /// <returns>stockQuantity</returns>
        public virtual InventoryStatus GetInventoryStatus(BusinessObject obj, string itemTableName,
            string inventoryUpdateType, ref double stockQuantityCanSale)
        {
            var productID = _dbUtil.GetPropertyIntValue(obj, "FK_ICProductID");
            var stockID = _dbUtil.GetPropertyIntValue(obj, "FK_ICStockID");
            var productSerieID = _dbUtil.GetPropertyIntValue(obj, "FK_ICProductSerieID");
            double itemQty =
                Convert.ToInt32(_dbUtil.GetPropertyValue(obj,
                    itemTableName.Substring(0, itemTableName.Length - 1) + "ProductQty"));

            //Check for enough quantity

            ICInventoryStocksInfo objInventoryStocksInfo = null;
            if (productSerieID > 0)
                objInventoryStocksInfo =
                    _objInventoryStocksController.GetInventoryStockByStockIDAndProductIDAndSerieID(stockID, productID,
                        productSerieID);
            else
                objInventoryStocksInfo = _objInventoryStocksController.GetInventoryStockByProductAndStock(productID,
                    stockID);
            if (objInventoryStocksInfo == null)
                objInventoryStocksInfo = new ICInventoryStocksInfo();

            stockQuantityCanSale = objInventoryStocksInfo.ICInventoryStockQuantity -
                                   objInventoryStocksInfo.ICInventoryStockSaleOrderQuantity;

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
            if (objInventoryStocksInfo.ICInventoryStockQuantity -
                objInventoryStocksInfo.ICInventoryStockSaleOrderQuantity < 0)
                return InventoryStatus.Empty;

            //Check for min, max quantity
            objInventoryStocksInfo = _objInventoryStocksController.GetInventoryStockByProductAndStock(productID, stockID);
            if (objInventoryStocksInfo == null)
                objInventoryStocksInfo = new ICInventoryStocksInfo();

            stockQuantityCanSale = objInventoryStocksInfo.ICInventoryStockQuantity -
                                   objInventoryStocksInfo.ICInventoryStockSaleOrderQuantity;

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

            var objProductsInfo = (ICProductsInfo) _objProductsController.GetObjectByID(productID);
            if (objProductsInfo != null)
            {
                if (DateTime.Now.CompareTo(objProductsInfo.ICProductStockMinDateFrom) >= 0 &&
                    DateTime.Now.CompareTo(objProductsInfo.ICProductStockMinDateTo) <= 0)
                    if (objInventoryStocksInfo.ICInventoryStockQuantity < objProductsInfo.ICProductStockMin)
                        return InventoryStatus.LessThanMinQty;
                if (DateTime.Now.CompareTo(objProductsInfo.ICProductStockMaxDateFrom) >= 0 &&
                    DateTime.Now.CompareTo(objProductsInfo.ICProductStockMaxDateTo) <= 0)
                    if (objInventoryStocksInfo.ICInventoryStockQuantity > objProductsInfo.ICProductStockMax)
                        return InventoryStatus.GreaterThanMaxQty;
            }

            return InventoryStatus.Valid;
        }

        /// <summary>
        ///     Get inventory status: empty, less than minimum quantity or greater than maximum quantity
        /// </summary>
        public virtual InventoryStatus GetInventoryStatus(int stockID, int productID, int productSerieID, double itemQty,
            string inventoryUpdateType)
        {
            //Check for enough quantity
            ICInventoryStocksInfo objInventoryStocksInfo = null;
            if (productSerieID > 0)
                objInventoryStocksInfo =
                    _objInventoryStocksController.GetInventoryStockByStockIDAndProductIDAndSerieID(stockID, productID,
                        productSerieID);
            else
                objInventoryStocksInfo = _objInventoryStocksController.GetInventoryStockByProductAndStock(productID,
                    stockID);
            if (objInventoryStocksInfo == null)
                objInventoryStocksInfo = new ICInventoryStocksInfo();
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
            if (objInventoryStocksInfo.ICInventoryStockQuantity < 0)
                return InventoryStatus.Empty;

            //Check for min, max quantity
            objInventoryStocksInfo = _objInventoryStocksController.GetInventoryStockByProductAndStock(productID, stockID);
            if (objInventoryStocksInfo == null)
                objInventoryStocksInfo = new ICInventoryStocksInfo();
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
            var objProductsInfo = (ICProductsInfo) _objProductsController.GetObjectByID(productID);
            if (objProductsInfo != null)
            {
                if (DateTime.Now.CompareTo(objProductsInfo.ICProductStockMinDateFrom) >= 0 &&
                    DateTime.Now.CompareTo(objProductsInfo.ICProductStockMinDateTo) <= 0)
                    if (objInventoryStocksInfo.ICInventoryStockQuantity < objProductsInfo.ICProductStockMin)
                        return InventoryStatus.LessThanMinQty;
                if (DateTime.Now.CompareTo(objProductsInfo.ICProductStockMaxDateFrom) >= 0 &&
                    DateTime.Now.CompareTo(objProductsInfo.ICProductStockMaxDateTo) <= 0)
                    if (objInventoryStocksInfo.ICInventoryStockQuantity > objProductsInfo.ICProductStockMax)
                        return InventoryStatus.GreaterThanMaxQty;
            }
            return InventoryStatus.Valid;
        }

        //DDCan [ADD] [08/06/2017] [Ordered Inventory], START
        public virtual InventoryStatus GetInventoryStatus_AvailableQty(int stockID, int productID, int productSerieID, double itemQty,
            string inventoryUpdateType)
        {
            //Check for enough quantity
            ICInventoryStocksInfo objInventoryStocksInfo = null;
            if (productSerieID > 0)
                objInventoryStocksInfo =
                    _objInventoryStocksController.GetInventoryStockByStockIDAndProductIDAndSerieID(stockID, productID,
                        productSerieID);
            else
                objInventoryStocksInfo = _objInventoryStocksController.GetInventoryStockByProductAndStock(productID,
                    stockID);
            if (objInventoryStocksInfo == null)
                objInventoryStocksInfo = new ICInventoryStocksInfo();

            //Get sale order stock
            ICInventoryStocksInfo objOrderedInventoryStocksInfo = null;
            ICStocksController objStocksController = new ICStocksController();
            ICStocksInfo objOrderedStocksInfo = objStocksController.GetStockBySaleStockID(stockID, StockType.SaleOrder.ToString());
            if (objOrderedStocksInfo != null)
            {
                
                if (productSerieID > 0)
                    objOrderedInventoryStocksInfo =
                        _objInventoryStocksController.GetInventoryStockByStockIDAndProductIDAndSerieID(objOrderedStocksInfo.ICStockID, productID,
                            productSerieID);
                else
                    objOrderedInventoryStocksInfo = _objInventoryStocksController.GetInventoryStockByProductAndStock(productID,
                        objOrderedStocksInfo.ICStockID);
            }
            if (objInventoryStocksInfo == null)
                objOrderedInventoryStocksInfo = new ICInventoryStocksInfo();
            objInventoryStocksInfo.ICInventoryStockQuantity = objInventoryStocksInfo.ICInventoryStockQuantity - objOrderedInventoryStocksInfo.ICInventoryStockQuantity;

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
            if (objInventoryStocksInfo.ICInventoryStockQuantity < 0)
                return InventoryStatus.Empty;

            return InventoryStatus.Valid;
        }
        //DDCan [ADD] [08/06/2017] [Ordered Inventory], END

        /// <summary>
        ///     Synchronize serie for an object when transferring from a branch to another
        /// </summary>
        /// <param name="obj">Given object</param>
        public void SynProductSerie(BusinessObject obj)
        {
            var serieNo = _dbUtil.GetPropertyStringValue(obj, "ICProductSerieNo");
            var productID = _dbUtil.GetPropertyIntValue(obj, "FK_ICProductID");
            var receiptDate = Convert.ToDateTime(_dbUtil.GetPropertyValue(obj, "ICProductSerieReceiptDate"));
            if (!string.IsNullOrEmpty(serieNo))
            {
                var objProductSeriesInfo = _objProductSeriesController.GetSerieByProductIDAndSerieNo(productID, serieNo);
                if (objProductSeriesInfo != null)
                {
                    _dbUtil.SetPropertyValue(obj, "FK_ICProductSerieID", objProductSeriesInfo.ICProductSerieID);
                }
                else
                {
                    objProductSeriesInfo = new ICProductSeriesInfo
                    {
                        AACreatedDate = DateTime.Now,
                        FK_ICProductID = productID,
                        ICProductSerieNo = serieNo,
                        ICProductSerieReceiptDate = receiptDate
                    };
                    var serieID = _objProductSeriesController.CreateObject(objProductSeriesInfo);

                    _dbUtil.SetPropertyValue(obj, "FK_ICProductSerieID", serieID);
                }
            }
        }

        /// <summary>
        ///     Calculate costs for a given item
        /// </summary>
        /// <param name="item">Item</param>
        public virtual void CalculateItemCost(BusinessObject item)
        {
            var itemTableName = BOSUtil.GetTableNameFromBusinessObject(item);
            var itemTablePrefix = itemTableName.Substring(0, itemTableName.Length - 1);

            //Get quantity
            var columnName = itemTablePrefix + "Qty";
            var qty = Convert.ToDouble(_dbUtil.GetPropertyValue(item, columnName));
            if (qty == 0)
            {
                qty = 1;
                _dbUtil.SetPropertyValue(item, columnName, 1);
            }

            //Get unit cost            
            columnName = itemTablePrefix + "UnitCost";
            var unitCost = Convert.ToDouble(_dbUtil.GetPropertyValue(item, columnName));

            //Get item discount percent
            columnName = itemTablePrefix + "DiscountPercent";
            var itemDiscountPercent = Convert.ToDouble(_dbUtil.GetPropertyValue(item, columnName));

            //Get item tax percent
            columnName = itemTablePrefix + "TaxPercent";
            var taxPercent = Convert.ToDouble(_dbUtil.GetPropertyValue(item, columnName));

            //Set extended cost
            columnName = itemTablePrefix + "ExtCost";
            var extCost = unitCost * qty;
            _dbUtil.SetPropertyValue(item, columnName, extCost);

            //Set item discount amount            
            var discountAmount = extCost * itemDiscountPercent / 100;
            columnName = itemTablePrefix + "DiscountAmount";
            _dbUtil.SetPropertyValue(item, columnName, discountAmount);

            //Set item tax amount
            columnName = itemTablePrefix + "TaxAmount";
            var taxAmount = (extCost - discountAmount) * taxPercent / 100;
            _dbUtil.SetPropertyValue(item, columnName, taxAmount);

            //Set item total cost
            columnName = itemTablePrefix + "TotalCost";
            _dbUtil.SetPropertyValue(item, columnName, extCost + taxAmount - discountAmount);
        }

        #region Set Default Values from Customer, Supplier, Employee

        public virtual void SetDefaultValuesFromCustomer(ARCustomersInfo objCustomersInfo)
        {
            var mainTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            var mainTablePrefix = mainTableName.Substring(0, mainTableName.Length - 1);

            _dbUtil.SetPropertyValue(MainObject, string.Format("{0}PaymentMethodCombo", mainTableName.Substring(0, 2)),
                objCustomersInfo.ARPaymentMethodCombo);
            _dbUtil.SetPropertyValue(MainObject, string.Format("{0}PaymentTerm", mainTablePrefix),
                objCustomersInfo.ARCustomerPaymentTerm);
            _dbUtil.SetPropertyValue(MainObject, "FK_GECurrencyID", objCustomersInfo.FK_GECurrencyID);


            var props = objCustomersInfo.GetType().GetProperties();
            foreach (var prop in props)
            {
                //Copy addresses
                if (prop.Name.Contains("Address"))
                    _dbUtil.SetPropertyValue(MainObject,
                        string.Format("{0}{1}", mainTablePrefix, prop.Name.Substring(10)),
                        prop.GetValue(objCustomersInfo, null));

                //Copy sale order contact
                if (prop.Name.Contains("Contact"))
                    _dbUtil.SetPropertyValue(MainObject,
                        string.Format("{0}SO{1}", mainTablePrefix, prop.Name.Substring(10)),
                        prop.GetValue(objCustomersInfo, null));
            }
        }
        

        public virtual void SetDefaultValuesFromEmployee(int iEmployeeID, string strPrimaryTableName)
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

        public virtual void SetValuesAfterValidateProduct(int productID, BusinessObject item)
        {
            SetDefaultValuesFromProduct(productID, item);
            SetProductPrice(item);
        }

        public virtual void SetDefaultValuesFromProduct(int iICProductID, string strItemTableName)
        {
            if (ModuleObjects[strItemTableName] != null)
                SetDefaultValuesFromProduct(iICProductID, ModuleObjects[strItemTableName]);
        }

        public virtual void SetDefaultValuesFromProduct(int iICProductID)
        {
            var strMainTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            var strItemTableName = strMainTableName.Substring(0, strMainTableName.Length - 1) + "Items";
            SetDefaultValuesFromProduct(iICProductID, strItemTableName);
        }

        public virtual void SetDefaultValuesFromProduct(int productID, BusinessObject item)
        {
            var objProductsInfo = (ICProductsInfo) _objProductsController.GetObjectByID(productID);

            var itemTableName = BOSUtil.GetTableNameFromBusinessObject(item);
            var columnName = string.Empty;

            if (objProductsInfo != null)
            {
                //Set product id                    
                _dbUtil.SetPropertyValue(item, "FK_ICProductID", objProductsInfo.ICProductID);

                //Set department id
                _dbUtil.SetPropertyValue(item, "FK_ICDepartmentID", objProductsInfo.FK_ICDepartmentID);

                //Set product group id
                _dbUtil.SetPropertyValue(item, "FK_ICProductGroupID", objProductsInfo.FK_ICProductGroupID);

                //Set product no
                _dbUtil.SetPropertyValue(item, "ICProductNo", objProductsInfo.ICProductNo);

                //Set Product Name
                columnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductName";
                _dbUtil.SetPropertyValue(item, columnName, objProductsInfo.ICProductName);
                _dbUtil.SetPropertyValue(item, "ICProductName", objProductsInfo.ICProductName);

                //Set product supplier no
                columnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductSupplierNo";
                _dbUtil.SetPropertyValue(item, columnName, objProductsInfo.ICProductSupplierNumber);

                // Set Product Description
                columnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductDesc";
                _dbUtil.SetPropertyValue(item, columnName, objProductsInfo.ICProductDesc);

                //Set product attribute
                columnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductAttribute";
                _dbUtil.SetPropertyValue(item, columnName, objProductsInfo.ICProductAttribute);

                //Set Product Type
                columnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductType";
                _dbUtil.SetPropertyValue(item, columnName, objProductsInfo.ICProductType);

                //Set Product Unit Cost
                columnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductUnitCost";
                _dbUtil.SetPropertyValue(item, columnName, objProductsInfo.ICProductSupplierPrice);

                //Set Product Picture
                columnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductPicture";
                _dbUtil.SetPropertyValue(item, columnName, objProductsInfo.ICProductPicture);

                //Set Product Default Tax Percent   
                var dbTaxPercent = SetDefaultProductTaxPercent(objProductsInfo);
                columnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductTaxPercent";
                _dbUtil.SetPropertyValue(item, columnName, dbTaxPercent);

                //Set Product Qty
                columnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductQty";
                _dbUtil.SetPropertyValue(item, columnName, 1);

                //Set default serial no
                _dbUtil.SetPropertyValue(item, "FK_ICProductSerieID", 0);
                columnName = itemTableName.Substring(0, itemTableName.Length - 1) + "ProductSerialNo";
                _dbUtil.SetPropertyValue(item, columnName, string.Empty);
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
            var iGEVATID = objICProductsInfo.FK_GEVATID;
            if (iGEVATID > 0)
            {
                var objGEVATsController = new GEVATsController();
                var objGEVATsInfo = (GEVATsInfo) objGEVATsController.GetObjectByID(iGEVATID);
                if (objGEVATsInfo != null)
                    dbTaxPercent = objGEVATsInfo.GEVATPercentValue;
            }
            return dbTaxPercent;
        }

        #region Set Product Price

        public virtual void SetProductPrice(ERPModuleItemsEntity entItem, string strItemTableName)
        {
            SetProductPrice(entItem);
        }

        public virtual void SetProductPrice()
        {
            var strMainTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            var strItemTableName = strMainTableName.Substring(0, strMainTableName.Length - 1) + "Items";
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

        public virtual void SetProductPrice(BusinessObject item)
        {
            var mainTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            var itemTableName = BOSUtil.GetTableNameFromBusinessObject(item);
            var itemTablePrefix = itemTableName.Substring(0, itemTableName.Length - 1);
            var productID = Convert.ToInt32(_dbUtil.GetPropertyValue(item, "FK_ICProductID"));

            var columnName = mainTableName.Substring(0, mainTableName.Length - 1) + "Date";
            var date = Convert.ToDateTime(_dbUtil.GetPropertyValue(MainObject, columnName));

            //Get Item Qty
            columnName = itemTablePrefix + "ProductQty";
            var qty = Convert.ToDouble(_dbUtil.GetPropertyValue(item, columnName));
            if (qty == 0)
            {
                qty = 1;
                _dbUtil.SetPropertyValue(item, columnName, 1);
            }

            //Get Item Tax Percent
            columnName = itemTablePrefix + "ProductTaxPercent";
            var taxPercent = Convert.ToDouble(_dbUtil.GetPropertyValue(item, columnName));

            //Get Item Unit Price
            var measureUnitID = _dbUtil.GetPropertyIntValue(item, "FK_ICMeasureUnitID");
            var unitPrice = CalculateProductPrice(productID, measureUnitID);

            //Get Item Unit Cost
            columnName = itemTablePrefix + "ProductUnitCost";
            var unitCost = Convert.ToDouble(_dbUtil.GetPropertyValue(item, columnName));

            //Set Item Unit Price
            columnName = itemTablePrefix + "ProductUnitPrice";
            _dbUtil.SetPropertyValue(item, columnName, unitPrice);

            //Set Item Extended Price
            columnName = itemTablePrefix + "Price";
            var extPrice = unitPrice * qty;
            _dbUtil.SetPropertyValue(item, columnName, extPrice);

            //Set Item Net Amount
            columnName = itemTablePrefix + "NetAmount";
            var netAmount = extPrice;
            _dbUtil.SetPropertyValue(item, columnName, netAmount);

            //Set Item Discount Amount                
            var discountAmount = CalculateItemDiscountAmount(item, productID, unitPrice, date, qty);
            columnName = itemTablePrefix + "DiscountAmount";
            _dbUtil.SetPropertyValue(item, columnName, discountAmount);

            //Set item discount percent
            double discountPercent = 0;
            if (extPrice != 0)
                discountPercent = discountAmount / extPrice * 100;
            columnName = itemTablePrefix + "ProductDiscount";
            _dbUtil.SetPropertyValue(item, columnName, discountPercent);

            //Set Item Tax Amount
            columnName = itemTablePrefix + "TaxAmount";
            var taxAmount = (netAmount - discountAmount) * taxPercent / 100;
            _dbUtil.SetPropertyValue(item, columnName, taxAmount);

            //Set Item Total Amount
            columnName = itemTablePrefix + "TotalAmount";
            _dbUtil.SetPropertyValue(item, columnName, netAmount + taxAmount - discountAmount);

            //Set Item Total Cost
            columnName = itemTablePrefix + "TotalCost";
            _dbUtil.SetPropertyValue(item, columnName, qty * unitCost);
            //Set Item TotalAmount4Share
            columnName = itemTablePrefix + "TotalAmount4Share";
            _dbUtil.SetPropertyValue(item, columnName, netAmount + taxAmount - discountAmount);
        }

        public virtual void SetProductPriceByProductUnitPrice(ERPModuleItemsEntity entItem, string strItemTableName)
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
            var strMainTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            var strItemTableName = strMainTableName.Substring(0, strMainTableName.Length - 1) + "Items";
            if (ModuleObjects[strItemTableName] != null)
            {
                SetProductPriceByProductUnitPrice(ModuleObjects[strItemTableName]);
                UpdateModuleObjectBindingSource(strItemTableName);
            }
        }

        public virtual void SetProductPriceByProductUnitPrice(BusinessObject item)
        {
            var itemTableName = BOSUtil.GetTableNameFromBusinessObject(item);
            var itemTablePrefix = itemTableName.Substring(0, itemTableName.Length - 1);
            var productID = Convert.ToInt32(_dbUtil.GetPropertyValue(item, "FK_ICProductID"));

            //Get Item Unit Price
            var columnName = itemTablePrefix + "ProductUnitPrice";
            var unitPrice = Convert.ToDouble(_dbUtil.GetPropertyValue(item, columnName));

            //Get Item Qty
            columnName = itemTablePrefix + "ProductQty";
            var qty = Convert.ToDouble(_dbUtil.GetPropertyValue(item, columnName));

            //Get Item Unit Cost
            columnName = itemTablePrefix + "ProductUnitCost";
            var unitCost = Convert.ToDouble(_dbUtil.GetPropertyValue(item, columnName));

            //Set Item Extended Price
            columnName = itemTablePrefix + "Price";
            //double extPrice = unitPrice * qty;
            var extPrice = unitPrice;
            _dbUtil.SetPropertyValue(item, columnName, extPrice);

            //Set Item Net Amount
            columnName = itemTablePrefix + "NetAmount";
            var netAmount = extPrice * qty;
            _dbUtil.SetPropertyValue(item, columnName, netAmount);

            //Get or set item discount percent and amount
            var discountPercentColumnName = itemTablePrefix + "ProductDiscount";
            var discountAmountColumnName = itemTablePrefix + "DiscountAmount";
            var discountPercent = Convert.ToDouble(_dbUtil.GetPropertyValue(item, discountPercentColumnName));
            var discountAmount = Convert.ToDouble(_dbUtil.GetPropertyValue(item, discountAmountColumnName));
            double oldDiscountAmount = 0;
            if (item.OldObject == null)
                item.OldObject = (BusinessObject) item.Clone();
            if (item.OldObject != null)
                oldDiscountAmount = Convert.ToDouble(_dbUtil.GetPropertyValue(item.OldObject, discountAmountColumnName));
            if (discountAmount != oldDiscountAmount)
            {
                if (extPrice > 0)
                {
                    discountPercent = discountAmount / extPrice * 100;
                    _dbUtil.SetPropertyValue(item, discountPercentColumnName, discountPercent);
                }
            }
            else
            {
                discountAmount = extPrice * discountPercent / 100;
                discountAmount = BOSApp.RoundingAmount(discountAmount, 1000);
                _dbUtil.SetPropertyValue(item, discountAmountColumnName, discountAmount);
            }

            //Get or set tax percent and amount
            var taxPercentColumnName = itemTablePrefix + "ProductTaxPercent";
            var taxAmountColumnName = itemTablePrefix + "TaxAmount";
            var taxPercent = Convert.ToDouble(_dbUtil.GetPropertyValue(item, taxPercentColumnName));
            var taxAmount = Convert.ToDouble(_dbUtil.GetPropertyValue(item, taxAmountColumnName));
            double oldTaxAmount = 0;
            if (item.OldObject != null)
                oldTaxAmount = Convert.ToDouble(_dbUtil.GetPropertyValue(item.OldObject, taxAmountColumnName));
            if (taxAmount != oldTaxAmount)
            {
                if (netAmount - discountAmount > 0)
                {
                    taxPercent = taxAmount / (netAmount - discountAmount) * 100;
                    _dbUtil.SetPropertyValue(item, taxPercentColumnName, taxPercent);
                }
            }
            else
            {
                taxAmount = (netAmount - discountAmount) * taxPercent / 100;
                _dbUtil.SetPropertyValue(item, taxAmountColumnName, taxAmount);
            }

            //Set Item Total Amount
            columnName = itemTablePrefix + "TotalAmount";
            _dbUtil.SetPropertyValue(item, columnName, netAmount + taxAmount - discountAmount);

            //Set Item Total Cost
            columnName = itemTablePrefix + "TotalCost";
            _dbUtil.SetPropertyValue(item, columnName, qty * unitCost);

            //Set Item TotalAmount4Share
            columnName = itemTablePrefix + "TotalAmount4Share";
            _dbUtil.SetPropertyValue(item, columnName, netAmount + taxAmount - discountAmount);

            item.OldObject = (BusinessObject) item.Clone();
        }

        #endregion

        #region Set Product Cost

        /// <summary>
        ///     Set cost for a new item
        /// </summary>
        /// <param name="item">Given item</param>
        public virtual void SetProductCost(BusinessObject item)
        {
            var itemTableName = BOSUtil.GetTableNameFromBusinessObject(item);
            var itemTablePrefix = itemTableName.Substring(0, itemTableName.Length - 1);
            var productID = _dbUtil.GetPropertyIntValue(item, "FK_ICProductID");

            //Get Item Qty
            var columnName = itemTablePrefix + "ProductQty";
            var qty = Convert.ToDouble(_dbUtil.GetPropertyValue(item, columnName));
            if (qty == 0)
            {
                qty = 1;
                _dbUtil.SetPropertyValue(item, columnName, 1);
            }

            //Get Item Tax Percent
            columnName = itemTablePrefix + "ProductTaxPercent";
            var taxPercent = Convert.ToDouble(_dbUtil.GetPropertyValue(item, columnName));

            //Set Item Unit Cost                            
            columnName = itemTablePrefix + "ProductUnitCost";
            var unitCost = CalculateProductCost(productID);
            _dbUtil.SetPropertyValue(item, columnName, unitCost);

            //Set Extended Cost
            columnName = itemTablePrefix + "ExtCost";
            var extCost = unitCost * qty;
            _dbUtil.SetPropertyValue(item, columnName, extCost);

            //Set Item Tax Amount
            columnName = itemTablePrefix + "TaxAmount";
            var taxAmount = extCost * taxPercent / 100;
            _dbUtil.SetPropertyValue(item, columnName, taxAmount);

            //Set Item Total Cost
            columnName = itemTablePrefix + "TotalCost";
            _dbUtil.SetPropertyValue(item, columnName, extCost + taxAmount);
        }

        /// <summary>
        ///     Set product cost for a new item
        /// </summary>
        /// <param name="item">Given item</param>
        /// <param name="itemTableName">Table name of item</param>
        public virtual void SetProductCost(ERPModuleItemsEntity item, string itemTableName)
        {
            SetProductCost(item);
        }

        public void SetProductCostByProductUnitCost(BusinessObject objItem)
        {
            var itemTableName = BOSUtil.GetTableNameFromBusinessObject(objItem);
            var itemTablePrefix = itemTableName.Substring(0, itemTableName.Length - 1);

            //Get Item Qty
            var columnName = itemTablePrefix + "ProductQty";
            var qty = Convert.ToDouble(_dbUtil.GetPropertyValue(objItem, columnName));

            //Get Item Unit Cost            
            columnName = itemTablePrefix + "ProductUnitCost";
            var unitCost = Convert.ToDouble(_dbUtil.GetPropertyValue(objItem, columnName));

            //Get item discount percent
            columnName = itemTablePrefix + "ProductDiscount";
            var discountPercent = Convert.ToDouble(_dbUtil.GetPropertyValue(objItem, columnName));

            //Get Item Tax Percent
            columnName = itemTablePrefix + "ProductTaxPercent";
            var taxPercent = Convert.ToDouble(_dbUtil.GetPropertyValue(objItem, columnName));

            //Set Extended Cost
            columnName = itemTablePrefix + "ExtCost";
            var extCost = unitCost * qty;
            _dbUtil.SetPropertyValue(objItem, columnName, extCost);

            //Set item discount amount
            var discountAmount = extCost * discountPercent / 100;
            columnName = itemTablePrefix + "DiscountAmount";
            _dbUtil.SetPropertyValue(objItem, columnName, discountAmount);

            //Set Item Tax Amount
            columnName = itemTablePrefix + "TaxAmount";
            var taxAmount = (extCost - discountAmount) * taxPercent / 100;
            _dbUtil.SetPropertyValue(objItem, columnName, taxAmount);

            //Set Item Total Cost
            columnName = itemTablePrefix + "TotalCost";
            _dbUtil.SetPropertyValue(objItem, columnName, extCost + taxAmount - discountAmount);
        }

        public virtual void SetProductCostByProductUnitCost(ERPModuleItemsEntity entItem, string strItemTableName)
        {
            SetProductCostByProductUnitCost(entItem);
        }

        public virtual void SetProductCostByProductUnitCost()
        {
            var strMainTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            var strItemTableName = strMainTableName.Substring(0, strMainTableName.Length - 1) + "Items";
            if (ModuleObjects[strItemTableName] != null)
            {
                SetProductCostByProductUnitCost(ModuleObjects[strItemTableName]);
                UpdateModuleObjectBindingSource(strItemTableName);
            }
        }

        /// <summary>
        ///     Calculate the product cost
        /// </summary>
        /// <param name="productID">Product id</param>
        private double CalculateProductCost(int productID)
        {
            double productCost = 0;
            var objProductsInfo = (ICProductsInfo) _objProductsController.GetObjectByID(productID);
            if (objProductsInfo != null)
            {
                productCost = objProductsInfo.ICProductSupplierPrice;

                var objProductBranchPricesController = new ICProductBranchPricesController();
                var currencyID = _dbUtil.GetPropertyIntValue(MainObject, "FK_GECurrencyID");
                var objProductBranchPricesInfo = objProductBranchPricesController
                    .GetProductPriceByProductIDAndBranchIDAndCurrencyIDAndType(
                        productID,
                        0,
                        currencyID,
                        ProductBranchPriceType.Purchase.ToString());
                if (objProductBranchPricesInfo != null)
                    productCost = objProductBranchPricesInfo.ICProductBranchPrice;
            }
            return productCost;
        }

        #endregion

        public virtual double CalculateItemDiscountAmount(BusinessObject item, int productID, double productPrice,
            DateTime transactionDate, double itemQty)
        {
            double discountAmount = 0;
            var objProductsInfo = (ICProductsInfo) _objProductsController.GetObjectByID(productID);
            if (objProductsInfo != null)
            {
                objProductsInfo.ICProductPrice01 = productPrice;
                objProductsInfo.ICProductPrice01 = CalculateProductPriceBaseOnProductPriceLevel(objProductsInfo);
                discountAmount += CalculateDiscountAmountFromCustomer(objProductsInfo, transactionDate, itemQty);
                discountAmount += CalculateDiscountAmountFromPromotion(item, objProductsInfo, transactionDate, itemQty);
            }
            return discountAmount;
        }

        public virtual double CalculateDiscountAmountFromCustomer(ICProductsInfo objProductsInfo,
            DateTime transactionDate, double itemQty)
        {
            double discountAmount = 0;
            var mainTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            var customerID = Convert.ToInt32(_dbUtil.GetPropertyValue(MainObject, "FK_ARCustomerID"));
            if (customerID > 0)
            {
                var objCustomersInfo = (ARCustomersInfo) _objCustomersController.GetObjectByID(customerID);
                if (objCustomersInfo != null)
                    discountAmount += objProductsInfo.ICProductPrice01 * objCustomersInfo.ARCustomerDiscount / 100 *
                                      itemQty;
            }
            return discountAmount;
        }

        public virtual double CalculateDiscountAmountFromPromotion(BusinessObject item, ICProductsInfo objProductsInfo,
            DateTime transactionDate, double itemQty)
        {
            //Change the quantity of current unit to the quantity of basic unit
            var measureUnitID = _dbUtil.GetPropertyIntValue(item, "FK_ICMeasureUnitID");
            var objProductUnitsInfo =
                _objProductUnitsController.GetProductUnitByProductIDAndUnitID(objProductsInfo.ICProductID, measureUnitID);
            if (objProductUnitsInfo != null)
                itemQty = itemQty * objProductUnitsInfo.ICProductUnitFactor;

            double discountAmount = 0;

            var ds = _objPromotionItemsController.GetAllDataByForeignColumn("FK_ICProductID", objProductsInfo.ICProductID);
            if (ds.Tables.Count > 0)
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var objPromotionItemsInfo =
                        (ICPromotionItemsInfo) _objPromotionItemsController.GetObjectFromDataRow(row);
                    var objPromotionsInfo =
                        (ICPromotionsInfo) _objPromotionsController.GetObjectByID(objPromotionItemsInfo.FK_ICPromotionID);
                    if (transactionDate.Date.CompareTo(objPromotionsInfo.ICPromotionStartDate.Date) >= 0 &&
                        transactionDate.Date.CompareTo(objPromotionsInfo.ICPromotionEndDate.Date) <= 0)
                        if (objPromotionsInfo.ICPromotionDiscountPercent > 0)
                            discountAmount += Math.Floor(itemQty / objPromotionsInfo.ICPromotionDiscountQty) *
                                              (objPromotionsInfo.ICPromotionDiscountQty *
                                               objProductsInfo.ICProductPrice01 *
                                               (objPromotionsInfo.ICPromotionDiscountPercent / 100));
                        else if (objPromotionsInfo.ICPromotionDiscountAmount > 0)
                            discountAmount += Math.Floor(itemQty / objPromotionsInfo.ICPromotionDiscountQty) *
                                              objPromotionsInfo.ICPromotionDiscountAmount;
                }
            return discountAmount;
        }

        #region Calculate Product Price

        public virtual double CalculateProductPrice(int productID, int measureUnitID)
        {
            double dbProductPrice = 0;
            var objICProductsInfo = (ICProductsInfo) _objProductsController.GetObjectByID(productID);
            if (objICProductsInfo != null)
            {
                //Update the product's price by its unit
                var objProductUnitsInfo = _objProductUnitsController.GetProductUnitByProductIDAndUnitID(productID,
                    measureUnitID);
                if (objProductUnitsInfo != null)
                    objICProductsInfo.ICProductPrice01 = objProductUnitsInfo.ICProductUnitPrice;

                //Update the product's price by the branch and currency
                var currencyID = _dbUtil.GetPropertyIntValue(MainObject, "FK_GECurrencyID");
                var objProductBranchPricesInfo = _objProductBranchPricesController
                    .GetProductPriceByProductIDAndBranchIDAndCurrencyIDAndType(
                        productID,
                        BOSApp.CurrentCompanyInfo.FK_BRBranchID,
                        currencyID,
                        ProductBranchPriceType.Sale.ToString());
                if (objProductBranchPricesInfo != null)
                    objICProductsInfo.ICProductPrice01 = objProductBranchPricesInfo.ICProductBranchPrice;

                //Update the product's price based on price levels
                dbProductPrice = CalculateProductPriceBaseOnProductPriceLevel(objICProductsInfo);
            }

            return dbProductPrice;
        }

        protected virtual double CalculateProductPriceBaseOnProductPriceLevel(ICProductsInfo objICProductsInfo)
        {
            var dbProductPrice = objICProductsInfo.ICProductPrice01;
            var priceLevelID = Convert.ToInt32(_dbUtil.GetPropertyValue(MainObject, "FK_ARPriceLevelID"));
            if (priceLevelID > 0)
            {
                var objProductPricesInfo =
                    _objProductPricesController.GetProductPriceByProductIDAndPriceLevelID(objICProductsInfo.ICProductID,
                        priceLevelID);
                //If product has own price level
                if (objProductPricesInfo != null)
                {
                    dbProductPrice = (1 - objProductPricesInfo.ICProductPriceMarkDown / 100) *
                                     objICProductsInfo.ICProductPrice01;
                }
                //Else, get default price level
                else
                {
                    var objPriceLevelsInfo = (ARPriceLevelsInfo) _objPriceLevelsController.GetObjectByID(priceLevelID);
                    if (objPriceLevelsInfo != null)
                        dbProductPrice = (1 - objPriceLevelsInfo.ARPriceLevelMarkDown / 100) *
                                         objICProductsInfo.ICProductPrice01;
                }
            }
            return dbProductPrice;
        }

        #endregion

        #endregion

        #region Get Range Days and Discount Percent from Payment Term

        public int GetRangeDays1FromPaymentTerm(string strPaymentTerm)
        {
            var strRangeDays1 = strPaymentTerm.Substring(0, 3);
            return Convert.ToInt32(strRangeDays1);
        }

        public double GetPercentDiscount1FromPaymentTerm(string strPaymentTerm)
        {
            var index = strPaymentTerm.IndexOf("%");
            var strPercentDiscount = strPaymentTerm.Substring(index - 4, 3);
            return Convert.ToDouble(strPercentDiscount);
        }

        public int GetRangeDays2FromPaymentTerm(string strPaymentTerm)
        {
            var index = strPaymentTerm.IndexOf(";");
            var strRangeDays2 = strPaymentTerm.Substring(index + 2, 3);
            return Convert.ToInt32(strRangeDays2);
        }

        public double GetPercentDiscount2FromPaymentTerm(string strPaymentTerm)
        {
            var index = strPaymentTerm.LastIndexOf("%");

            var strPercentDiscount = strPaymentTerm.Substring(index - 4, 3);
            return Convert.ToDouble(strPercentDiscount);
        }

        public int GetRangeDays3FromPaymentTerm(string strPaymentTerm)
        {
            var index = strPaymentTerm.LastIndexOf(";");
            var strRangeDays3 = strPaymentTerm.Substring(index + 2, 3);
            return Convert.ToInt32(strRangeDays3);
        }

        #endregion

        
    }
}