using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using eMASLib;

namespace eMASERP
{
    public class ProductHistory
    {
        #region Variables
        protected int _maProductID;
        protected String _maProductSerieName;
        protected DataTable tblProductSerieNumberHistory = new DataTable();
        #endregion

        #region Constants
        public const string CustomerText = "Kunden";
        public const string SupplierText = "Lieferant";
        public const string ReceiptText = "Einl. Nr.";
        public const string ShipmentText = "Lief. Nr.";
        public const string TransferText = "Uml. Nr.";
        public const string StockText = "Lager";
        public const string StockSlotText = "Lagerplatz";
        #endregion

        #region Enum
        public enum TransactionType
        {
            General=0,
            Receipt=1,
            Shipment=2,
            Transfer=3
        }
        #endregion

        #region Public properties
        public int MAProductID
        {
            get
            {
                return _maProductID;
            }
            set
            {
                _maProductID = value;
            }
        }

        public String MAProductSerieName
        {
            get
            {
                return _maProductSerieName;
            }
            set
            {
                _maProductSerieName = value;
            }
        }

        public DataTable ProductSerieNumberHistoryTable
        {
            get
            {
                return tblProductSerieNumberHistory;
            }
        }
        #endregion

        #region Constructor
        public ProductHistory()
        {
            InitProductSerieNumberHistoryTable();
        }

        public ProductHistory(int iMAProductID, String strMAProductSerieName)
        {
            MAProductID = iMAProductID;
            MAProductSerieName = strMAProductSerieName;
            InitProductSerieNumberHistoryTable();
        }

        public ProductHistory(int iMAProductID)
        {
            MAProductID = iMAProductID;
            InitProductSerieNumberHistoryTable();
        }
        #endregion

        #region Init Table ProductSerieNumberHistory
        private void InitProductSerieNumberHistoryTable()
        {
            tblProductSerieNumberHistory.TableName = "ProductSerieNumberHistory";

            DataColumn colID = new DataColumn();
            colID.ColumnName = "ID";
            colID.DataType = typeof(int);
            tblProductSerieNumberHistory.Columns.Add(colID);

            DataColumn colParentID = new DataColumn();
            colParentID.ColumnName = "ParentID";
            colParentID.Caption = "ParentID";
            colParentID.DataType = typeof(int);
            tblProductSerieNumberHistory.Columns.Add(colParentID);

            DataColumn colTransactionType = new DataColumn();
            colTransactionType.ColumnName = "TransactionType";
            colTransactionType.Caption = "Typ";
            colTransactionType.DataType = typeof(int);
            tblProductSerieNumberHistory.Columns.Add(colTransactionType);

            DataColumn colMAProductID = new DataColumn();
            colMAProductID.ColumnName = "MAProductID";
            colMAProductID.Caption = "Art. Nr.";
            colMAProductID.DataType = typeof(string);
            tblProductSerieNumberHistory.Columns.Add(colMAProductID);

            DataColumn colMAProductSerieName = new DataColumn();
            colMAProductSerieName.ColumnName = "MAProductSerieName";
            colMAProductSerieName.Caption = "Charge Nummer";
            colMAProductSerieName.DataType = typeof(string);
            tblProductSerieNumberHistory.Columns.Add(colMAProductSerieName);

            DataColumn colDate = new DataColumn();
            colDate.ColumnName = "Date";
            colDate.Caption = "Datum";
            colDate.DataType = typeof(DateTime);
            tblProductSerieNumberHistory.Columns.Add(colDate);

            DataColumn colQty = new DataColumn();
            colQty.ColumnName = "Qty";
            colQty.Caption = "Menge";
            colQty.DataType = typeof(double);
            tblProductSerieNumberHistory.Columns.Add(colQty);

            //DataColumn colMAStockID = new DataColumn();
            //colMAStockID.ColumnName = "MAStockID";
            //colMAStockID.Caption = "Lager";
            //colMAStockID.DataType = typeof(int);
            //tblProductSerieNumberHistory.Columns.Add(colMAStockID);


            //DataColumn colMAStockSlotID = new DataColumn();
            //colMAStockSlotID.ColumnName = "MAStockSlotID";
            //colMAStockSlotID.Caption = "Lagerplatz";
            //colMAStockSlotID.DataType = typeof(int);
            //tblProductSerieNumberHistory.Columns.Add(colMAStockSlotID);

            DataColumn colComment1 = new DataColumn();
            colComment1.ColumnName = "Comment1";
            colComment1.Caption = "Kommentar 1";
            colComment1.DataType = typeof(string);
            tblProductSerieNumberHistory.Columns.Add(colComment1);

            DataColumn colComment2 = new DataColumn();
            colComment2.ColumnName = "Comment2";
            colComment2.Caption = "Kommentar 2";
            colComment2.DataType = typeof(string);
            tblProductSerieNumberHistory.Columns.Add(colComment2);

            DataColumn colComment3 = new DataColumn();
            colComment3.ColumnName = "Comment3";
            colComment3.Caption = "Kommentar 3";
            colComment3.DataType = typeof(string);
            tblProductSerieNumberHistory.Columns.Add(colComment3);

            DataColumn[] primaryKeys = new DataColumn[1];
            primaryKeys[0] = colID;

            tblProductSerieNumberHistory.PrimaryKey = primaryKeys;
            
        }
        #endregion


        #region Utility Functions
        public void GetProductHistoryForward()
        {
            tblProductSerieNumberHistory.Rows.Clear();

            int iParentID = tblProductSerieNumberHistory.Rows.Count;
            GetProductHistoryForward(MAProductID, MAProductSerieName, iParentID);
        }

        private void GetProductHistoryForward(int iMAProductID,String strMAProductSerieName, int iParentID)
        {
            FATransactionsController objFATransactionsController = new FATransactionsController();
            MAStocksController objMAStocksController= new MAStocksController();
            MAStockSlotsController objMAStockSlotsController= new MAStockSlotsController();

            int iNextParentID = iParentID;
            String strComment1 = String.Empty;
            String strComment2 = String.Empty;
            String strComment3 = String.Empty;

            //If iParentID=0,get all receipt have item is MAProductID And SerieNumber is strMAProductSerieName            
            FAReceiptsController objFAReceiptsController= new FAReceiptsController();
            FAReceiptItemsController objFAReceiptItemsController = new FAReceiptItemsController();
            MASuppliersController objMASuppliersController = new MASuppliersController();
            if (iParentID == 0)
            {
                DataSet dsReceipts = objFAReceiptsController.GetFAReceiptsByMAProductIDAndMAProductSerieName(iMAProductID, strMAProductSerieName);
                if (dsReceipts.Tables[0].Rows.Count > 0)
                {
                    FAReceiptsInfo objFAReceiptsInfo = (FAReceiptsInfo)objFAReceiptsController.GetObjectFromDataRow(dsReceipts.Tables[0].Rows[0]);
                    String strMASupplierName = objMASuppliersController.GetObjectNameByID(objFAReceiptsInfo.FASupplierIDCombo);

                    DataSet dsTransactions = objFATransactionsController.GetFATransactionsByFAReceiptIDAndMAProductIDAndMAProductSerieName(
                                                                            objFAReceiptsInfo.FAReceiptID,
                                                                            iMAProductID,
                                                                            strMAProductSerieName);
                    double dbQty = 0;
                    foreach (DataRow rowTransaction in dsTransactions.Tables[0].Rows)
                    {
                        FATransactionsInfo objFATransactionsInfo = (FATransactionsInfo)objFATransactionsController.GetObjectFromDataRow(rowTransaction);
                        dbQty += objFATransactionsInfo.FATransactionQuantity;
                    }

                    FATransactionsInfo objFirstTransactionsInfo = (FATransactionsInfo)objFATransactionsController.GetObjectFromDataRow(dsTransactions.Tables[0].Rows[0]);
                    FAReceiptItemsInfo objFAReceiptItemsInfo = objFAReceiptItemsController.GetFAReceiptItemsByFAReceiptIDAndFATransactionID(
                                                                                            objFAReceiptsInfo.FAReceiptID,
                                                                                            objFirstTransactionsInfo.FATransactionID);
                    String strStockName = objMAStocksController.GetObjectNameByID(objFAReceiptItemsInfo.FAStockIDCombo);
                    String strStockSlotName = objMAStockSlotsController.GetObjectNameByID(objFAReceiptItemsInfo.FAStockSlotIDCombo);


                    strComment1 = String.Format("{0} {1}-{2} {3} {4}", ReceiptText, objFAReceiptsInfo.AANumberInt, SupplierText, strMASupplierName, objFAReceiptsInfo.FASupplierIDCombo);
                    strComment2 = objFAReceiptsInfo.FAReceiptInfo;
                    strComment3 = String.Format("{0}:{1}-{2}:{3}", StockText, strStockName, StockSlotText, strStockSlotName);

                    tblProductSerieNumberHistory.Rows.Add(
                        new object[] { 
                            tblProductSerieNumberHistory.Rows.Count + 1, 
                            iParentID, 
                            Convert.ToInt32(TransactionType.Receipt),
                            iMAProductID.ToString(), 
                            strMAProductSerieName,
                            objFAReceiptsInfo.FAReceiptStartDate, 
                            dbQty,                            
                            strComment1,
                            strComment2,
                            strComment3});
                }
                else
                {
                    strComment1 = String.Empty;
                    strComment2 = String.Empty;
                    strComment3 = String.Empty;
                    tblProductSerieNumberHistory.Rows.Add(
                        new object[] { 
                            tblProductSerieNumberHistory.Rows.Count + 1, 
                            iParentID, 
                            Convert.ToInt32(TransactionType.General),
                            iMAProductID.ToString(), 
                            strMAProductSerieName,
                            null, 
                            0, 
                            strComment1, 
                            strComment2,
                            strComment3});
                }
                iNextParentID = tblProductSerieNumberHistory.Rows.Count;
            }



            //Get all shipment have item is iMAProductID and SerieNumber is strMAProductSerieName
            FAShipmentsController objFAShipmentsController = new FAShipmentsController();
            FAShipmentItemsController objFAShipmentItemsController = new FAShipmentItemsController();
            MACustomersController objMACustomersController = new MACustomersController();
            DataSet dsShipments = objFAShipmentsController.GetFAShipmentsByMAProductIDAndMAProductSerieName(iMAProductID, strMAProductSerieName);
            if (dsShipments.Tables[0].Rows.Count > 0)
            {
                FAShipmentsInfo objFAShipmentsInfo = (FAShipmentsInfo)objFAShipmentsController.GetObjectFromDataRow(dsShipments.Tables[0].Rows[0]);

                String strMACustomerName = objMACustomersController.GetObjectNameByID(objFAShipmentsInfo.FACustomerIDCombo);

                DataSet dsTransactions = objFATransactionsController.GetFATransactionsByFAShipmentIDAndMAProductIDAndMAProductSerieName(
                                                                        objFAShipmentsInfo.FAShipmentID,
                                                                        iMAProductID,
                                                                        strMAProductSerieName);                
                double dbQty = 0;
                foreach (DataRow rowTransaction in dsTransactions.Tables[0].Rows)
                {
                    FATransactionsInfo objFATransactionsInfo = (FATransactionsInfo)objFATransactionsController.GetObjectFromDataRow(rowTransaction);
                    dbQty += objFATransactionsInfo.FATransactionQuantity;
                }

                FATransactionsInfo objFirstTransactionsInfo = (FATransactionsInfo)objFATransactionsController.GetObjectFromDataRow(dsTransactions.Tables[0].Rows[0]);
                FAShipmentItemsInfo objFAShipmentItemsInfo = objFAShipmentItemsController.GetFAShipmentItemsByFAShipmentIDAndFATransactionID(
                                                                                        objFAShipmentsInfo.FAShipmentID,
                                                                                        objFirstTransactionsInfo.FATransactionID);
                String strStockName = objMAStocksController.GetObjectNameByID(objFAShipmentItemsInfo.FAStockIDCombo);
                String strStockSlotName = objMAStockSlotsController.GetObjectNameByID(objFAShipmentItemsInfo.FAStockSlotIDCombo);



                strComment1=String.Format("{0} {1}-{2} {3} {4}",ShipmentText, objFAShipmentsInfo.AANumberInt,CustomerText,strMACustomerName,objFAShipmentsInfo.FACustomerIDCombo);
                strComment2 = objFAShipmentsInfo.FAShipmentInfo;
                strComment3 = String.Format("{0}:{1}-{2}:{3}", StockText, strStockName, StockSlotText, strStockSlotName);

                tblProductSerieNumberHistory.Rows.Add(
                    new object[] { 
                        tblProductSerieNumberHistory.Rows.Count + 1, 
                        iParentID, 
                        Convert.ToInt32(TransactionType.Shipment),
                        iMAProductID.ToString(), 
                        strMAProductSerieName, 
                        objFAShipmentsInfo.FAShipmentStartDate, 
                        dbQty, 
                        strComment1,
                        strComment2,
                        strComment3});
            }



            //Get all product in transfer with stock out item is iMAProductID and SerieNumber is strMAProductSerieName
            FATransfersController objFATransfersController = new FATransfersController();
            FATransferStockInItemsController objFATransferStockInItemsController = new FATransferStockInItemsController();                        

            //DataSet dsTransfers = objFATransfersController.GetFATransfersWithStockOutItemIsMAProductIDAndMAProductSerieName(
            //                                                iMAProductID, strMAProductSerieName);
            DataSet dsTransfers = objFATransfersController.GetCompletedFATransfersWithStockOutItemIsMAProductIDAndMAProductSerieName(
                                                            iMAProductID, strMAProductSerieName);
            if (dsTransfers.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow rowTransfer in dsTransfers.Tables[0].Rows)
                {
                    FATransfersInfo objFATransfersInfo = (FATransfersInfo)objFATransfersController.GetObjectFromDataRow(rowTransfer);

                    

                    DataSet dsTransferStockInItems = objFATransferStockInItemsController.GetAllDataByForeignColumn("FATransferID", objFATransfersInfo.FATransferID);
                    foreach (DataRow rowFATransferStockInItem in dsTransferStockInItems.Tables[0].Rows)
                    {
                        FATransferStockInItemsInfo objFATransferStockInItemsInfo = (FATransferStockInItemsInfo)objFATransferStockInItemsController.GetObjectFromDataRow(rowFATransferStockInItem);
                        int iStockInProductID = objFATransferStockInItemsInfo.FAProductIDCombo;
                        DataSet dsTransactions = objFATransactionsController.GetFATransactionsByFATransferStockInItemID(objFATransferStockInItemsInfo.FATransferStockInItemID);
                        foreach (DataRow rowTransaction in dsTransactions.Tables[0].Rows)
                        {
                            FATransactionsInfo objFATransactionsInfo = (FATransactionsInfo)objFATransactionsController.GetObjectFromDataRow(rowTransaction);
                            
                            String strStockName=new MAStocksController().GetObjectNameByID(objFATransferStockInItemsInfo.FAStockIDCombo);
                            String strStockSlotName=new MAStockSlotsController().GetObjectNameByID(objFATransferStockInItemsInfo.FAStockSlotIDCombo);

                            strComment1 = String.Format("{0} {1}-{2}", TransferText, objFATransfersInfo.FATransferID, objFATransfersInfo.FATransferMatchCode01Combo);
                            strComment2 = objFATransfersInfo.FATransferInfo;
                            strComment3 = String.Format("{0}:{1}-{2}:{3}", StockText, strStockName, StockSlotText, strStockSlotName);

                            tblProductSerieNumberHistory.Rows.Add(
                                new object[] { 
                                    tblProductSerieNumberHistory.Rows.Count + 1,
                                    iNextParentID,
                                    Convert.ToInt32(TransactionType.Transfer),
                                    iStockInProductID.ToString(),
                                    objFATransactionsInfo.FAProductSerieName,
                                    objFATransfersInfo.FATransferStockInDate,
                                    objFATransactionsInfo.FATransactionQuantity,                                    
                                    strComment1, 
                                    strComment2,
                                    strComment3});

                            GetProductHistoryForward(
                                iStockInProductID, 
                                objFATransactionsInfo.FAProductSerieName, 
                                tblProductSerieNumberHistory.Rows.Count);
                        }
                        
                    }
                }
            }
            else
            {
                return;
            }                      
        }


        public void GetProductHistoryBackward()
        {
            tblProductSerieNumberHistory.Rows.Clear();

            int iParentID = tblProductSerieNumberHistory.Rows.Count;
            GetProductHistoryBackward(MAProductID, MAProductSerieName, iParentID);
        }

        private void GetProductHistoryBackward(int iMAProductID, String strMAProductSerieName, int iParentID)
        {
            FATransactionsController objFATransactionsController = new FATransactionsController();
            MAStocksController objMAStocksController = new MAStocksController();
            MAStockSlotsController objMAStockSlotsController = new MAStockSlotsController();

            int iNextParentID = iParentID;
            String strComment1 = String.Empty;
            String strComment2 = String.Empty;
            String strComment3 = String.Empty;

            if (iParentID == 0)
            {
                 tblProductSerieNumberHistory.Rows.Add(
                        new object[] { 
                            tblProductSerieNumberHistory.Rows.Count + 1, 
                            iParentID, 
                            Convert.ToInt32(TransactionType.General),
                            iMAProductID.ToString(), 
                            strMAProductSerieName,
                            null, 
                            0, 
                            strComment1, 
                            strComment2,
                            strComment3});
                 iNextParentID = tblProductSerieNumberHistory.Rows.Count;
            }



            //Get all shipment have item is iMAProductID and SerieNumber is strMAProductSerieName
            FAShipmentsController objFAShipmentsController = new FAShipmentsController();
            FAShipmentItemsController objFAShipmentItemsController = new FAShipmentItemsController();
            MACustomersController objMACustomersController = new MACustomersController();
            DataSet dsShipments = objFAShipmentsController.GetFAShipmentsByMAProductIDAndMAProductSerieName(iMAProductID, strMAProductSerieName);
            if (dsShipments.Tables[0].Rows.Count > 0)
            {
                FAShipmentsInfo objFAShipmentsInfo = (FAShipmentsInfo)objFAShipmentsController.GetObjectFromDataRow(dsShipments.Tables[0].Rows[0]);

                String strMACustomerName = objMACustomersController.GetObjectNameByID(objFAShipmentsInfo.FACustomerIDCombo);

                DataSet dsTransactions = objFATransactionsController.GetFATransactionsByFAShipmentIDAndMAProductIDAndMAProductSerieName(
                                                                        objFAShipmentsInfo.FAShipmentID,
                                                                        iMAProductID,
                                                                        strMAProductSerieName);
                double dbQty = 0;
                foreach (DataRow rowTransaction in dsTransactions.Tables[0].Rows)
                {
                    FATransactionsInfo objFATransactionsInfo = (FATransactionsInfo)objFATransactionsController.GetObjectFromDataRow(rowTransaction);
                    dbQty += objFATransactionsInfo.FATransactionQuantity;
                }

                FATransactionsInfo objFirstTransactionsInfo = (FATransactionsInfo)objFATransactionsController.GetObjectFromDataRow(dsTransactions.Tables[0].Rows[0]);
                FAShipmentItemsInfo objFAShipmentItemsInfo = objFAShipmentItemsController.GetFAShipmentItemsByFAShipmentIDAndFATransactionID(
                                                                                        objFAShipmentsInfo.FAShipmentID,
                                                                                        objFirstTransactionsInfo.FATransactionID);
                String strStockName = objMAStocksController.GetObjectNameByID(objFAShipmentItemsInfo.FAStockIDCombo);
                String strStockSlotName = objMAStockSlotsController.GetObjectNameByID(objFAShipmentItemsInfo.FAStockSlotIDCombo);



                strComment1 = String.Format("{0} {1}-{2} {3} {4}", ShipmentText, objFAShipmentsInfo.AANumberInt, CustomerText, strMACustomerName, objFAShipmentsInfo.FACustomerIDCombo);
                strComment2 = objFAShipmentsInfo.FAShipmentInfo;
                strComment3 = String.Format("{0}:{1}-{2}:{3}", StockText, strStockName, StockSlotText, strStockSlotName);

                tblProductSerieNumberHistory.Rows.Add(
                    new object[] { 
                        tblProductSerieNumberHistory.Rows.Count + 1, 
                        iParentID, 
                        Convert.ToInt32(TransactionType.Shipment),
                        iMAProductID.ToString(), 
                        strMAProductSerieName, 
                        objFAShipmentsInfo.FAShipmentStartDate, 
                        dbQty, 
                        strComment1,
                        strComment2,
                        strComment3});
            }



            //Get all product in transfer with stock in item is iMAProductID and SerieNumber is strMAProductSerieName
            FATransfersController objFATransfersController = new FATransfersController();
            FATransferStockOutItemsController objFATransferStockOutItemsController = new FATransferStockOutItemsController();

            
            DataSet dsTransfers = objFATransfersController.GetCompletedFATransfersWithStockInItemIsMAProductIDAndMAProductSerieName(
                                                            iMAProductID, strMAProductSerieName);
            if (dsTransfers.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow rowTransfer in dsTransfers.Tables[0].Rows)
                {
                    FATransfersInfo objFATransfersInfo = (FATransfersInfo)objFATransfersController.GetObjectFromDataRow(rowTransfer);



                    DataSet dsTransferStockOutItems = objFATransferStockOutItemsController.GetAllDataByForeignColumn("FATransferID", objFATransfersInfo.FATransferID);
                    foreach (DataRow rowFATransferStockOutItem in dsTransferStockOutItems.Tables[0].Rows)
                    {
                        FATransferStockOutItemsInfo objFATransferStockOutItemsInfo = (FATransferStockOutItemsInfo)objFATransferStockOutItemsController.GetObjectFromDataRow(rowFATransferStockOutItem);
                        int iStockOutProductID = objFATransferStockOutItemsInfo.FAProductIDCombo;
                        DataSet dsTransactions = objFATransactionsController.GetFATransactionsByFATransferStockOutItemID(objFATransferStockOutItemsInfo.FATransferStockOutItemID);
                        foreach (DataRow rowTransaction in dsTransactions.Tables[0].Rows)
                        {
                            FATransactionsInfo objFATransactionsInfo = (FATransactionsInfo)objFATransactionsController.GetObjectFromDataRow(rowTransaction);

                            String strStockName = new MAStocksController().GetObjectNameByID(objFATransferStockOutItemsInfo.FAStockIDCombo);
                            String strStockSlotName = new MAStockSlotsController().GetObjectNameByID(objFATransferStockOutItemsInfo.FAStockSlotIDCombo);

                            strComment1 = String.Format("{0} {1}-{2}", TransferText, objFATransfersInfo.FATransferID, objFATransfersInfo.FATransferMatchCode01Combo);
                            strComment2 = objFATransfersInfo.FATransferInfo;
                            strComment3 = String.Format("{0}:{1}-{2}:{3}", StockText, strStockName, StockSlotText, strStockSlotName);

                            tblProductSerieNumberHistory.Rows.Add(
                                new object[] { 
                                    tblProductSerieNumberHistory.Rows.Count + 1,
                                    iNextParentID,
                                    Convert.ToInt32(TransactionType.Transfer),
                                    iStockOutProductID.ToString(),
                                    objFATransactionsInfo.FAProductSerieName,
                                    objFATransfersInfo.FATransferStockInDate,
                                    objFATransactionsInfo.FATransactionQuantity,                                    
                                    strComment1, 
                                    strComment2,
                                    strComment3});

                            GetProductHistoryBackward(
                                iStockOutProductID,
                                objFATransactionsInfo.FAProductSerieName,
                                tblProductSerieNumberHistory.Rows.Count);
                        }

                    }
                }
            }
            else
            {
                //get all receipt have item is MAProductID And SerieNumber is strMAProductSerieName            
                FAReceiptsController objFAReceiptsController = new FAReceiptsController();
                FAReceiptItemsController objFAReceiptItemsController = new FAReceiptItemsController();
                MASuppliersController objMASuppliersController = new MASuppliersController();
                
                DataSet dsReceipts = objFAReceiptsController.GetFAReceiptsByMAProductIDAndMAProductSerieName(iMAProductID, strMAProductSerieName);
                if (dsReceipts.Tables[0].Rows.Count > 0)
                {
                    FAReceiptsInfo objFAReceiptsInfo = (FAReceiptsInfo)objFAReceiptsController.GetObjectFromDataRow(dsReceipts.Tables[0].Rows[0]);
                    String strMASupplierName = objMASuppliersController.GetObjectNameByID(objFAReceiptsInfo.FASupplierIDCombo);

                    DataSet dsTransactions = objFATransactionsController.GetFATransactionsByFAReceiptIDAndMAProductIDAndMAProductSerieName(
                                                                            objFAReceiptsInfo.FAReceiptID,
                                                                            iMAProductID,
                                                                            strMAProductSerieName);
                    double dbQty = 0;
                    foreach (DataRow rowTransaction in dsTransactions.Tables[0].Rows)
                    {
                        FATransactionsInfo objFATransactionsInfo = (FATransactionsInfo)objFATransactionsController.GetObjectFromDataRow(rowTransaction);
                        dbQty += objFATransactionsInfo.FATransactionQuantity;
                    }

                    FATransactionsInfo objFirstTransactionsInfo = (FATransactionsInfo)objFATransactionsController.GetObjectFromDataRow(dsTransactions.Tables[0].Rows[0]);
                    FAReceiptItemsInfo objFAReceiptItemsInfo = objFAReceiptItemsController.GetFAReceiptItemsByFAReceiptIDAndFATransactionID(
                                                                                            objFAReceiptsInfo.FAReceiptID,
                                                                                            objFirstTransactionsInfo.FATransactionID);
                    String strStockName = objMAStocksController.GetObjectNameByID(objFAReceiptItemsInfo.FAStockIDCombo);
                    String strStockSlotName = objMAStockSlotsController.GetObjectNameByID(objFAReceiptItemsInfo.FAStockSlotIDCombo);


                    strComment1 = String.Format("{0} {1}-{2} {3} {4}", ReceiptText, objFAReceiptsInfo.AANumberInt, SupplierText, strMASupplierName, objFAReceiptsInfo.FASupplierIDCombo);
                    strComment2 = objFAReceiptsInfo.FAReceiptInfo;
                    strComment3 = String.Format("{0}:{1}-{2}:{3}", StockText, strStockName, StockSlotText, strStockSlotName);

                    tblProductSerieNumberHistory.Rows.Add(
                        new object[] { 
                        tblProductSerieNumberHistory.Rows.Count + 1, 
                        iParentID, 
                        Convert.ToInt32(TransactionType.Receipt),
                        iMAProductID.ToString(), 
                        strMAProductSerieName,
                        objFAReceiptsInfo.FAReceiptStartDate, 
                        dbQty,                            
                        strComment1,
                        strComment2,
                        strComment3});
                }                               
                return;
            }
        }
        #endregion

    }
}
