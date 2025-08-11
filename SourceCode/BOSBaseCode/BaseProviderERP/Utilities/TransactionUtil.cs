using System;
using System.Collections.Generic;
using System.Text;
using BOSLib;
using BOSCommon;

namespace BOSERP
{ 
    public class TransactionUtil
    {
        #region Constant
        public const string cstInventoryShipment = "Shipment";
        public const string cstInventoryProposal = "Proposal";
        public const string cstInventorySaleOrder = "SaleOrder";
        public const string cstInventoryPurchaseOrder = "PurchaseOrder";
        public const string cstInventoryReceipt = "Receipt";
        public const string cstInventoryAdjust = "Adjustment";
        #endregion

        #region Update Inventory functions
        /// <summary>
        /// Update inventory package
        /// </summary>
        /// <param name="packageID">The package id</param>
        /// <param name="stockID">The stock id</param>
        /// <param name="productID">Product id</param>
        /// <param name="qty">Qty needs to be updated</param>
        /// <param name="updateType">The update type</param>
        /// <returns>The inventory package id</returns>
        public static int UpdateInventoryPackage(int packageID, int stockID,int productID, double qty, string updateType)
        {
            int inventoryPackageID = 0;
            ICInventoryPackagesController objInventoryPackagesController = new ICInventoryPackagesController();
            ICInventoryPackagesInfo objInventoryPackagesInfo = objInventoryPackagesController.GetInventoryPackageByPackageIDAndStockIDAndProductID(packageID, stockID,productID);
            if (objInventoryPackagesInfo != null)
            {
                UpdateInventoryPackageQuantity(objInventoryPackagesInfo, qty, updateType);
                inventoryPackageID = objInventoryPackagesController.UpdateObject(objInventoryPackagesInfo);
            }
            else
            {
                objInventoryPackagesInfo = new ICInventoryPackagesInfo();
                objInventoryPackagesInfo.FK_ICStockID = stockID;
                objInventoryPackagesInfo.FK_ICPackageID = packageID;
                objInventoryPackagesInfo.FK_ICProductID = productID;
                UpdateInventoryPackageQuantity(objInventoryPackagesInfo, qty, updateType);
                inventoryPackageID = objInventoryPackagesController.CreateObject(objInventoryPackagesInfo);
            }
            return inventoryPackageID;
        }
               
        public static int UpdateInventoryStock(
                                        int productID, 
                                        int stockID,
                                        double productQty, 
                                        string updateType)
        {
            return UpdateInventoryStock(productID, stockID, 0, productQty, 0, updateType);
        }

        public static int UpdateInventoryStock(
                                        int productID,
                                        int stockID,
                                        double productQty,
                                        double unitCost,
                                        string updateType)
        {
            return UpdateInventoryStock(productID, stockID, 0, productQty, unitCost, updateType);
        }

        public static int UpdateInventoryStock(
                                       int productID,
                                       int stockID,
                                       int productSerieID,
                                       double productQty,
                                       string updateType)
        {
            return UpdateInventoryStock(productID, stockID, productSerieID, productQty, 0, updateType);
        }

        public static int UpdateInventoryStock(
                                          int productID,
                                          int stockID,
                                          int productSerieID,
                                          double productQty,
                                          double unitCost,
                                          string updateType)
        {
            ICProductsController objProductsController = new ICProductsController();
            ICProductsInfo objProductsInfo = (ICProductsInfo)objProductsController.GetObjectByID(productID);
            int inventoryStockID = 0;
            if (objProductsInfo != null && !objProductsInfo.HasComponent)
            {
                ICInventoryStocksController objInventoryStocksController = new ICInventoryStocksController();
                ICInventoryStocksInfo objInventoryStocksInfo = objInventoryStocksController.GetInventoryStockByStockIDAndProductIDAndSerieID(stockID, productID, productSerieID);
                if (objInventoryStocksInfo != null)
                {
                    UpdateInventoryStockQuantity(
                        objInventoryStocksInfo,
                        productQty,
                        updateType);
                    if (unitCost > 0)
                    {
                        objInventoryStocksInfo.ICInventoryStockUnitCost = unitCost;
                    }
                    inventoryStockID = objInventoryStocksController.UpdateObject(objInventoryStocksInfo);
                }
                else
                {
                    objInventoryStocksInfo = new ICInventoryStocksInfo();
                    objInventoryStocksInfo.FK_ICStockID = stockID;
                    objInventoryStocksInfo.FK_ICProductID = productID;
                    objInventoryStocksInfo.FK_ICProductSerieID = productSerieID;
                    objInventoryStocksInfo.ICInventoryStockUnitCost = unitCost;
                    UpdateInventoryStockQuantity(
                        objInventoryStocksInfo,
                        productQty,
                        updateType);

                    inventoryStockID = objInventoryStocksController.CreateObject(objInventoryStocksInfo);
                }

                ICStocksController objStocksController = new ICStocksController();
                ICStocksInfo objStocksInfo = (ICStocksInfo)objStocksController.GetObjectByID(stockID);
                BRBranchsController objBranchsController = new BRBranchsController();
                BRBranchsInfo currentBranch = objBranchsController.GetCurrentBranch();
                if (objStocksInfo != null && objStocksInfo.FK_BRBranchID != currentBranch.BRBranchID)
                {
                    UpdateInventoryAdjustment(productID, stockID, productSerieID, productQty, unitCost, updateType);
                }
            }
            return inventoryStockID;
        }


        public static int UpdateInventoryStock(
                                          int productID,
                                          int stockID,
                                          int productSerieID,
                                          double productQty,
                                          double unitCost,
                                          DateTime expiredDate,
                                          string updateType)
        {
            ICProductsController objProductsController = new ICProductsController();
            ICProductsInfo objProductsInfo = (ICProductsInfo)objProductsController.GetObjectByID(productID);
            int inventoryStockID = 0;
            if (objProductsInfo != null && !objProductsInfo.HasComponent)
            {
                ICInventoryStocksController objInventoryStocksController = new ICInventoryStocksController();
                ICInventoryStocksInfo objInventoryStocksInfo = objInventoryStocksController.GetInventoryStockByStockIDAndProductIDAndSerieID(stockID, productID, productSerieID);
                if (objInventoryStocksInfo != null)
                {
                    UpdateInventoryStockQuantity(
                        objInventoryStocksInfo,
                        productQty,
                        updateType);
                    if (unitCost > 0)
                    {
                        objInventoryStocksInfo.ICInventoryStockUnitCost = unitCost;
                    }
                    objInventoryStocksInfo.ICInventoryStockExpiryDate = expiredDate;
                    inventoryStockID = objInventoryStocksController.UpdateObject(objInventoryStocksInfo);
                }
                else
                {
                    objInventoryStocksInfo = new ICInventoryStocksInfo();
                    objInventoryStocksInfo.FK_ICStockID = stockID;
                    objInventoryStocksInfo.FK_ICProductID = productID;
                    objInventoryStocksInfo.FK_ICProductSerieID = productSerieID;
                    objInventoryStocksInfo.ICInventoryStockUnitCost = unitCost;
                    objInventoryStocksInfo.ICInventoryStockExpiryDate = expiredDate;
                    UpdateInventoryStockQuantity(
                        objInventoryStocksInfo,
                        productQty,
                        updateType);

                    inventoryStockID = objInventoryStocksController.CreateObject(objInventoryStocksInfo);
                }

                ICStocksController objStocksController = new ICStocksController();
                ICStocksInfo objStocksInfo = (ICStocksInfo)objStocksController.GetObjectByID(stockID);
                BRBranchsController objBranchsController = new BRBranchsController();
                BRBranchsInfo currentBranch = objBranchsController.GetCurrentBranch();
                if (objStocksInfo != null && objStocksInfo.FK_BRBranchID != currentBranch.BRBranchID)
                {
                    UpdateInventoryAdjustment(productID, stockID, productSerieID, productQty, unitCost, updateType);
                }
            }
            return inventoryStockID;
        }

        /// <summary>
        /// Update the inventory cost of a product in a stock
        /// </summary>
        /// <param name="productID">Product id</param>
        /// <param name="stockID">Stock id</param>
        /// <param name="productSerieID">Serie id</param>
        /// <param name="inventoryCost">Inventory cost</param>
        public static void UpdateInventoryCost(int productID, int stockID, int productSerieID, double inventoryCost)
        {
            ICInventoryStocksController objInventoryStocksController = new ICInventoryStocksController();
            ICInventoryStocksInfo inventoryStock = objInventoryStocksController.GetInventoryStockByStockIDAndProductIDAndSerieID(
                                                                                                                        stockID,
                                                                                                                        productID,
                                                                                                                        productSerieID);
            if (inventoryStock != null)
            {
                inventoryStock.ICInventoryStockUnitCost = inventoryCost;
                objInventoryStocksController.UpdateObject(inventoryStock);
            }
        }

        /// <summary>
        /// Update inventory adjustment for a product in a stock
        /// to adjust its inventory automatically at branches
        /// </summary>
        /// <param name="productID">Product id</param>
        /// <param name="stockID">Stock id</param>
        /// <param name="productSerieID">Serie id</param>
        /// <param name="productQty">Adjusted quantity</param>
        /// <param name="unitCost">Adjusted inventory cost</param>
        /// <param name="updateType">Quantity adjustment type</param>
        public static void UpdateInventoryAdjustment(
                                        int productID, 
                                        int stockID, 
                                        int productSerieID, 
                                        double productQty, 
                                        double unitCost,
                                        string updateType)
        {
            ICInvAdjustmentsController objInvAdjustmentsController = new ICInvAdjustmentsController();
            ICInvAdjustmentsInfo objInvAdjustmentsInfo = objInvAdjustmentsController.GetInvAdjustmentByStockIDAndProductIDAndSerieID(
                                                                                                    stockID,
                                                                                                    productID,
                                                                                                    productSerieID);                                                                                                    
            if (objInvAdjustmentsInfo != null)
            {
                if (unitCost > 0)
                {
                    objInvAdjustmentsInfo.ICInvAdjustmentUnitCost = unitCost;
                }
                if (updateType == TransactionUtil.cstInventoryReceipt)
                {
                    objInvAdjustmentsInfo.ICInvAdjustmentQty += productQty;
                }
                else if (updateType == TransactionUtil.cstInventoryShipment)
                {
                    objInvAdjustmentsInfo.ICInvAdjustmentQty -= productQty;
                }                
                objInvAdjustmentsController.UpdateObject(objInvAdjustmentsInfo);
            }
            else
            {
                objInvAdjustmentsInfo = new ICInvAdjustmentsInfo();
                objInvAdjustmentsInfo.FK_ICProductID = productID;
                objInvAdjustmentsInfo.FK_ICStockID = stockID;                
                objInvAdjustmentsInfo.FK_ICProductSerieID = productSerieID;
                objInvAdjustmentsInfo.ICInvAdjustmentUnitCost = unitCost;
                if (updateType == TransactionUtil.cstInventoryReceipt)
                {
                    objInvAdjustmentsInfo.ICInvAdjustmentQty += productQty;
                }
                else if (updateType == TransactionUtil.cstInventoryShipment)
                {
                    objInvAdjustmentsInfo.ICInvAdjustmentQty -= productQty;
                }                
                objInvAdjustmentsController.CreateObject(objInvAdjustmentsInfo);
            }
        }

        /// <summary>
        /// Update inventory adjustment for a product in a stock
        /// to adjust its inventory automatically at branches
        /// </summary>
        /// <param name="productID">Product id</param>
        /// <param name="stockID">Stock id</param>
        /// <param name="productSerieID">Serie id</param>
        /// <param name="unitCost">Inventory cost</param>
        public static void UpdateInventoryAdjustment(
                                            int productID,
                                            int stockID,
                                            int productSerieID,
                                            double unitCost)
        {
            ICInvAdjustmentsController objInvAdjustmentsController = new ICInvAdjustmentsController();
            ICInvAdjustmentsInfo objInvAdjustmentsInfo = objInvAdjustmentsController.GetInvAdjustmentByStockIDAndProductIDAndSerieID(
                                                                                                    stockID,
                                                                                                    productID,
                                                                                                    productSerieID);
            if (objInvAdjustmentsInfo != null)
            {
                objInvAdjustmentsInfo.ICInvAdjustmentUnitCost = unitCost;
                objInvAdjustmentsController.UpdateObject(objInvAdjustmentsInfo);
            }
            else
            {
                objInvAdjustmentsInfo = new ICInvAdjustmentsInfo();
                objInvAdjustmentsInfo.FK_ICProductID = productID;
                objInvAdjustmentsInfo.FK_ICStockID = stockID;
                objInvAdjustmentsInfo.FK_ICProductSerieID = productSerieID;
                objInvAdjustmentsInfo.ICInvAdjustmentUnitCost = unitCost;
                objInvAdjustmentsController.CreateObject(objInvAdjustmentsInfo);
            }
        }             
                  
        private static void UpdateInventoryStockQuantity(
                                ICInventoryStocksInfo objICInventoryStocksInfo,
                                double dbProductQuantity,                                
                                String strUpdateType)
        {
            switch (strUpdateType)
            {
                case cstInventoryProposal:
                    {                        
                        objICInventoryStocksInfo.ICInventoryStockProposalQuantity += dbProductQuantity;
                        break;
                    }
                case cstInventoryPurchaseOrder:
                    {                        
                        objICInventoryStocksInfo.ICInventoryStockPurchaseOrderQuantity += dbProductQuantity;
                        break;
                    }
                case cstInventorySaleOrder:
                    {                        
                        objICInventoryStocksInfo.ICInventoryStockSaleOrderQuantity += dbProductQuantity;
                        break;
                    }
                case cstInventoryShipment:
                    {                        
                        objICInventoryStocksInfo.ICInventoryStockQuantity -= dbProductQuantity;                        
                        break;
                    }

                case cstInventoryReceipt:
                    {                        
                        objICInventoryStocksInfo.ICInventoryStockQuantity += dbProductQuantity;                        
                        break;
                    }
                case cstInventoryAdjust:
                    {
                        objICInventoryStocksInfo.ICInventoryStockQuantity = dbProductQuantity;
                        break;
                    }

            }
        }

        /// <summary>
        /// Update inventory package quantity
        /// </summary>
        /// <param name="objInventoryPackagesInfo">Info of package</param>
        /// <param name="packageQuantity">The package quantity</param>
        /// <param name="updateType">The update type</param>
        private static void UpdateInventoryPackageQuantity(ICInventoryPackagesInfo objInventoryPackagesInfo,
                                                            double packageQuantity,
                                                            string updateType)
        {
            if (updateType.Equals(TransactionUtil.cstInventoryShipment.ToString()))
            {
                objInventoryPackagesInfo.ICInventoryPackageQty -= packageQuantity;
            }
            if (updateType.Equals(TransactionUtil.cstInventoryReceipt.ToString()))
            {
                objInventoryPackagesInfo.ICInventoryPackageQty += packageQuantity;
            }
        }


        private static void UpdateInventoryStockSlotQuantity(
                                ICInventoryStockSlotsInfo objICInventoryStockSlotsInfo,
                                double dbProductQuantity,                                
                                String strUpdateType)
        {
            switch (strUpdateType)
            {
                case cstInventoryProposal:
                    {                        
                        objICInventoryStockSlotsInfo.ICInventoryStockSlotProposalQuantity += dbProductQuantity;
                        break;
                    }
                case cstInventoryPurchaseOrder:
                    {                        
                        objICInventoryStockSlotsInfo.ICInventoryStockSlotPurchaseOrderQuantity += dbProductQuantity;
                        break;
                    }
                case cstInventorySaleOrder:
                    {                        
                        objICInventoryStockSlotsInfo.ICInventoryStockSlotSaleOrderQuantity += dbProductQuantity;
                        break;
                    }
                case cstInventoryShipment:
                    {                        
                        objICInventoryStockSlotsInfo.ICInventoryStockSlotQuantity -= dbProductQuantity;                        
                        break;
                    }

                case cstInventoryReceipt:
                    {                        
                        objICInventoryStockSlotsInfo.ICInventoryStockSlotQuantity += dbProductQuantity;                        
                        break;
                    }
                case cstInventoryAdjust:
                    {
                        objICInventoryStockSlotsInfo.ICInventoryStockSlotQuantity = dbProductQuantity;
                        break;
                    }
            }
        }       
        #endregion        
    }
}
