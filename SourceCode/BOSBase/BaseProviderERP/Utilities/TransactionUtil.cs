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
        public static int UpdateInventoryStock(
                                        int productID, 
                                        int stockID,
                                        double productQty, 
                                        string updateType)
        {
            return UpdateInventoryStock(productID, stockID, 0, productQty, DateTime.MaxValue, DateTime.MaxValue, DateTime.MaxValue, 0, updateType);
        }
    

        public static int UpdateInventoryStock(
                                       int productID,
                                       int stockID,
                                       int productSerieID,
                                       double productQty,
                                       string updateType)
        {
            return UpdateInventoryStock(productID, stockID, productSerieID, productQty, DateTime.MaxValue, DateTime.MaxValue, DateTime.MaxValue, 0, updateType);
        }

        public static int UpdateInventoryStock(
                                    int productID,
                                    int stockID,
                                    int productSerieID,
                                    double productQty,
                                    double unitCost,
                                    string updateType)
        {
            return UpdateInventoryStock(productID, stockID, productSerieID, productQty, DateTime.MaxValue, DateTime.MaxValue, DateTime.MaxValue, unitCost, updateType);
        }     

        public static int UpdateInventoryStock(
                                       int productID,
                                       int stockID,
                                       int productSerieID,
                                       double productQty,
                                       DateTime stockDate,
                                       DateTime producedDate,
                                       DateTime expiryDate,
                                       double unitCost,
                                       string updateType)
        {
            ICInventoryStocksController objICInventoryStocksController = new ICInventoryStocksController();
            ICInventoryStocksInfo objICInventoryStocksInfo = objICInventoryStocksController.GetInventoryStockByStockIDAndProductIDAndSerieID(
                                                                                            stockID,
                                                                                            productID,
                                                                                            productSerieID);
            if (objICInventoryStocksInfo != null)
            {
                UpdateInventoryStockQuantity(
                    objICInventoryStocksInfo,
                    productQty,
                    updateType);
                objICInventoryStocksInfo.ICInventoryStockCost = objICInventoryStocksInfo.ICInventoryStockQuantity * objICInventoryStocksInfo.ICInventoryStockProductUnitCost;
                objICInventoryStocksController.UpdateObject(objICInventoryStocksInfo);
            }
            else
            {
                objICInventoryStocksInfo = new ICInventoryStocksInfo();
                objICInventoryStocksInfo.FK_ICStockID = stockID;
                objICInventoryStocksInfo.FK_ICProductID = productID;
                objICInventoryStocksInfo.FK_ICProductSerieID = productSerieID;
                objICInventoryStocksInfo.ICInventoryStockDate = stockDate;
                objICInventoryStocksInfo.ICInventoryStockProducedDate = producedDate;
                objICInventoryStocksInfo.ICInventoryStockExpiryDate = expiryDate;
                objICInventoryStocksInfo.ICInventoryStockProductUnitCost = unitCost;
                UpdateInventoryStockQuantity(
                    objICInventoryStocksInfo,
                    productQty,
                    updateType);
                objICInventoryStocksInfo.ICInventoryStockCost = objICInventoryStocksInfo.ICInventoryStockQuantity * objICInventoryStocksInfo.ICInventoryStockProductUnitCost;
                objICInventoryStocksController.CreateObject(objICInventoryStocksInfo);
            }

            return objICInventoryStocksInfo.ICInventoryStockID;
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
