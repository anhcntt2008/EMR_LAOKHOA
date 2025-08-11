using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BOSLib
{
    public class ADConfigValueUtility
    {
        public static readonly string ADConfigValueTable = "ADConfigValues";

        static ADConfigValueUtility()
        {
            ConfigValues = new DataSet();
        }

        /// <summary>
        ///     Gets or sets all config values of the application
        /// </summary>
        public static DataSet ConfigValues { get; set; }

        public static void UpdateValueToADConfigValueTable(string strKey, string strText)
        {
            try
            {
                var dbUtil = new BOSDbUtil();
                var strUpdateQuery =
                    string.Format("UPDATE [ADConfigValues] SET [ADConfigText]='{0}' WHERE [ADConfigKey]='{1}'", strText,
                        strKey);
                dbUtil.ExecuteQuery(strUpdateQuery);
            }
            catch (Exception)
            {
                MessageBox.Show("CommonLocalizedResources.MessageBoxDefaultCaption Exception");
            }
        }

        private static DataTable InitConfigValueTableStructure(string strConfigKey)
        {
            var tbl = new DataTable(strConfigKey);
            var columnKey = new DataColumn();
            var keys = new DataColumn[1];
            columnKey.ColumnName = "Key";
            columnKey.DataType = typeof(string);

            tbl.Columns.Add(columnKey);
            keys[0] = columnKey;

            var columnKeyValue = new DataColumn
            {
                ColumnName = "Value",
                DataType = typeof(string)
            };
            tbl.Columns.Add(columnKeyValue);


            var columnText = new DataColumn
            {
                ColumnName = "Text",
                DataType = typeof(string)
            };

            tbl.Columns.Add(columnText);
            tbl.PrimaryKey = keys;

            return tbl;
        }

        public static DataTable InitConfigValueTable(string strAdConfigValueGroup)
        {
            var tbl = InitConfigValueTableStructure(strAdConfigValueGroup);
            if (strAdConfigValueGroup == ADConfigValueAll)
                strAdConfigValueGroup = string.Empty;

            var objConfigValuesController = new ADConfigValuesController();
            var dsAdConfigValues = objConfigValuesController.GetADConfigValuesByGroup(strAdConfigValueGroup);

            if (dsAdConfigValues.Tables.Count <= 0) return tbl;
            foreach (DataRow row in dsAdConfigValues.Tables[0].Rows)
            {
                var objConfigValuesInfo = (ADConfigValuesInfo) objConfigValuesController.GetObjectFromDataRow(row);
                if (objConfigValuesInfo.IsActive)
                    tbl.Rows.Add(objConfigValuesInfo.ADConfigKey, objConfigValuesInfo.ADConfigKeyValue,
                        objConfigValuesInfo.ADConfigText);
            }

            return tbl;
        }


        public static string GetTextFromKey(string strKey, string strConfigValueTableName)
        {
            foreach (DataRow row in ConfigValues.Tables[strConfigValueTableName].Rows)
                if (row["Key"].ToString() == strKey)
                    return row["Text"].ToString();
            return string.Empty;
        }


        public static string GetTextFromKey(string strKey)
        {
            foreach (DataTable tblConfigValues in ConfigValues.Tables)
                foreach (DataRow row in tblConfigValues.Rows)
                    if (row["Key"].ToString() == strKey)
                        return row["Text"].ToString();

            return string.Empty;
        }

        public static void InitGlobalConfigValueTables()
        {
            ConfigValues.Tables.Clear();
            ConfigValues.Clear();

            var objAdConfigValuesController = new ADConfigValuesController();
            var strAdConfigValueGroups = objAdConfigValuesController.GetADConfigValueGroups();
            var listAdConfigValueGroup = objAdConfigValuesController.ListAdConfigValueByGroups();
            foreach (var strAdConfigValueGroup in strAdConfigValueGroups)
            {
                var group = strAdConfigValueGroup;
                if (string.IsNullOrEmpty(group)) continue;
                var tblNew = InitConfigValueTableStructure(group);
                if (group == ADConfigValueAll)
                    group = string.Empty;

                
                var dsAdConfigValues = listAdConfigValueGroup.Where(x=>x.ADConfigKeyGroup == group).ToList();
                foreach (var objConfigValuesInfo in dsAdConfigValues)
                {
                    if (objConfigValuesInfo.IsActive)
                        tblNew.Rows.Add(objConfigValuesInfo.ADConfigKey, objConfigValuesInfo.ADConfigKeyValue,
                            objConfigValuesInfo.ADConfigText);
                }
                //var tbl = InitConfigValueTable(strAdConfigValueGroup);
                ConfigValues.Tables.Add(tblNew);

                var tblSearch = tblNew.Copy();
                tblSearch.TableName = strAdConfigValueGroup + "Search";
                var dummyRow = tblSearch.NewRow();
                dummyRow["Key"] = string.Empty;
                dummyRow["Value"] = string.Empty;
                dummyRow["Text"] = string.Empty;
                tblSearch.Rows.InsertAt(dummyRow, 0);
                ConfigValues.Tables.Add(tblSearch);


                var tblDummyAll = tblNew.Copy();
                tblDummyAll.TableName = strAdConfigValueGroup + "DummySearch";
                var dummyAllRow = tblDummyAll.NewRow();
                dummyAllRow["Key"] = string.Empty;
                dummyAllRow["Value"] = string.Empty;
                dummyAllRow["Text"] = "Tất cả";
                tblDummyAll.Rows.InsertAt(dummyAllRow, 0);
                ConfigValues.Tables.Add(tblDummyAll);
            }
        }

        /// <summary>
        ///     Get first config value of a group
        /// </summary>
        /// <param name="group">Group name</param>
        /// <returns>Value in string format</returns>
        public static string GetFirstConfigValueByGroup(string group)
        {
            if ((ConfigValues.Tables[group] != null) && (ConfigValues.Tables[group].Rows.Count > 0))
                return ConfigValues.Tables[group].Rows[0]["Value"].ToString();
            return string.Empty;
        }

        /// <summary>
        ///     Get a config displayed text by its group and value
        /// </summary>
        /// <param name="group">Group</param>
        /// <param name="value">Value</param>
        /// <returns>Displayed text of the config value</returns>
        public static string GetConfigTextByGroupAndValue(string group, string value)
        {
            if (ConfigValues.Tables[group] != null)
                foreach (DataRow row in ConfigValues.Tables[group].Rows)
                    if (value == Convert.ToString(row["Value"]))
                        return Convert.ToString(row["Text"]);
            return string.Empty;
        }

        #region constant for ADConfigValue

        public const string ADConfigValueAll = "All";
        public const string ADConfigValueSellPrice = "SellPrice";
        public const string ADConfigValueBuyPrice = "BuyPrice";
        public const string ADConfigValuePaymentMethod = "PaymentMethod";
        public const string ADConfigValueCustomerType = "CustomerType";
        public const string ADConfigValueCustomerInvoiceType = "CustomerInvoiceType";
        public const string ADConfigValueCustomerOrderType = "CustomerOrderType";
        public const string ADConfigValueSupplierType = "SupplierType";
        public const string ADConfigValueProductCostingMethod = "ProductCostingMethod";
        public const string ADConfigValueProductType = "ProductType";
        public const string ADConfigValueStockType = "StockType";
        public const string ADConfigValueContactType = "ContactType";
        public const string ADConfigValueSellOrderItemType = "SellOrderItemType";
        public const string ADConfigValueShipmentType = "ShipmentType";
        public const string ADConfigValueReceiptType = "ReceiptType";

        public const string ADConfigValuePOSType = "POSType";
        public const string ADConfigValuePOSStatus = "POSStatus";
        public const string ADConfigValueTransferType = "TransferType";

        public const string ADConfigValueLayBy = "LayBy";
        public const string ADConfigValueWorkingShift = "EmployeeWorkingShift";
        public const string ADConfigValueCreditNote = "CreditNote";

        public const string ADConfigValueRegionState = "AddressStateProvince";
        public const string ADConfigValueRegionPostCode = "AddressPostalCode";

        #endregion

        #region ContactType Constant

        public const string cstContactTypeInvoice = "Invoice";
        public const string cstContactTypeProposal = "Proposal";
        public const string cstContactTypeSaleOrder = "SaleOrder";
        public const string cstContactTypePurchaseOrder = "PurchaseOrder";
        public const string cstContactTypeDelivery = "Delivery";
        public const string cstContactTypeReceipt = "Receipt";
        public const string cstContactTypeSaleReturn = "SaleReturn";
        public const string cstContactTypeCreditNote = "CreditNote";
        public const string cstContactTypeInvoiceCopy = "InvoiceCopy";
        public const string cstContactTypeProposalCopy = "ProposalCopy";
        public const string cstContactTypeSaleOrderCopy = "SaleOrderCopy";
        public const string cstContactTypeDeliveryCopy = "DeliveryCopy";
        public const string cstContactTypeReceiptCopy = "ReceiptCopy";
        public const string cstContactTypeSaleReturnCopy = "SaleReturnCopy";
        public const string cstContactTypeCreditNoteCopy = "CreditNoteCopy";

        #endregion

        #region Constant HistoryAction

        public const string cstHistoryActionCreate = "Create";
        public const string cstHistoryActionChange = "Change";
        public const string cstHistoryActionGenerate = "Generate";

        #endregion

        #region Constant for Proposal

        #region ProposalType Constant

        public const string cstProposalTypeManual = "Manual";

        #endregion

        #region ProposalStatus Constant

        public const string cstProposalStatusNew = "New";
        public const string cstProposalStatusIncomplete = "Incomplete";
        public const string cstProposalStatusComplete = "Complete";

        #endregion

        #region ProposalRelate Constant

        public const string cstProposalRelateManual = "Manual";
        public const string cstProposalRelateSellOrder = "SellOrder";

        #endregion

        #endregion

        #region Constant for Commission

        #region CommissionType Constant

        public const string cstCommissionTypeManual = "Manual";
        public const string cstCommissionTypeFromSellOrder = "FromSellOrder";

        #endregion

        #region CommissionStatus Constant

        public const string cstCommissionStatusNew = "New";
        public const string cstCommissionStatusIncomplete = "Incomplete";
        public const string cstCommissionStatusComplete = "Complete";

        #endregion

        #region CommissionRelate Constant

        public const string cstCommissionRelateManual = "Manual";
        public const string cstCommissionRelateSellOrder = "SellOrder";
        public const string cstCommissionRelateShipment = "Shipment";

        #endregion

        #endregion

        #region Constant for SellReturn

        #region SellReturnType Constant

        public const string cstSellReturnTypeManual = "Manual";
        public const string cstSellReturnTypeFromInvoice = "FromInvoice";
        public const string cstSellReturnTypeFromCreditNote = "FromCreditNote";

        #endregion

        #region SellReturnStatus Constant

        public const string cstSellReturnStatusNew = "New";
        public const string cstSellReturnStatusIncomplete = "Incomplete";
        public const string cstSellReturnStatusComplete = "Complete";

        #endregion

        #region SellReturnRelate Constant

        public const string cstSellReturnRelateManual = "Manual";
        public const string cstSellReturnRelateInvoice = "Invoice";
        public const string cstSellReturnRelateCreditNote = "CreditNote";
        public const string cstSellReturnRelateReceipt = "Receipt";

        #endregion

        #endregion

        #region Constant for CreditNote

        #region CreditNoteType constant

        public const string cstCreditNoteTypeManual = "Manual";
        public const string cstCreditNoteTypeFromSellReturn = "FromSellReturn";
        public const string cstCreditNoteTypeFromInvoice = "FromInvoice";
        public const string cstCreditNoteTypeFromInvoiceAffectStock = "FromInvoiceAffectStock";

        #endregion

        #region CreditNoteStatus constant

        public const string cstCreditNoteStatusNew = "New";
        public const string cstCreditNoteStatusIncomplete = "Incomplete";
        public const string cstCreditNoteStatusComplete = "Complete";

        #endregion

        #region CreditNoteRelate Constant

        public const string cstCreditNoteRelateManual = "Manual";
        public const string cstCreditNoteRelateReceipt = "Receipt";
        public const string cstCreditNoteRelateInvoice = "Invoice";

        #endregion

        #endregion

        #region Constant for Transaction Type

        public const string cstTransactionTypeProposal = "Proposal";
        public const string cstTransactionTypeSellOrder = "SellOrder";
        public const string cstTransactionTypeCommission = "Commission";
        public const string cstTransactionTypeShipment = "Shipment";
        public const string cstTransactionTypeInvoice = "Invoice";
        public const string cstTransactionTypePurchaseOrder = "PurchaseOrder";
        public const string cstTransactionTypeReceipt = "Receipt";
        public const string cstTransactionTypeSellReturn = "SellReturn";
        public const string cstTransactionTypeCreditNote = "CreditNote";
        public const string cstTransactionTypeTransfer = "Transfer";
        public const string cstTransactionTypeTransferStockIn = "TransferStockIn";
        public const string cstTransactionTypeTransferStockOut = "TransferStockOut";
        public const string cstTransactionTypeZerlegung = "Zerlegung";
        public const string cstTransactionTypeRezeptur = "Rezeptur";

        #endregion

        #region Constant for SupplierType

        public const string cstStatusActiv = "StatusActiv";
        public const string cstStatusInActiv = "StatusInActiv";

        #endregion

        #region Constant ItemType

        public const string cstItemTypeProduct = "Product";
        public const string cstItemTypeText = "Text";

        #endregion

        #region Constant for Open Document

        public const string cstOpenDocumentTypeSaleReceipt = "SaleReceipt";
        public const string cstOpenDocumentTypeGoodsRefund = "GoodsRefund";
        public const string cstOpenDocumentTypeLayBy = "LayBy";
        public const string cstOpenDocumentTypeSaleOrder = "SaleOrder";
        public const string cstOpenDocumentTypeServiceReceipt = "ServiceReceipt";
        public const string cstOpenDocumentTypeMedicationReceipt = "MedicationReceipt";

        public const string cstOpenDocumentStatusNew = "New";
        public const string cstOpenDocumentStatusCancel = "Cancel";
        public const string cstOpenDocumentStatusComplete = "Complete";

        #endregion

        #region Constant for Payment Method

        public const string cstPaymentMethodCash = "Cash";
        public const string cstPaymentMethodEFTPOS = "EFTPOS";
        public const string cstPaymentMethodCheck = "Check";
        public const string cstPaymentMethodCreditCard = "CreditCard";
        public const string cstPaymentMethodAccount = "Account";
        public const string cstPaymentMethodCreditNote = "CreditNote";
        public const string cstPaymentMethodGiftVoucher = "GiftVoucher";

        #endregion

        #region Constant for Stock Type

        public const string cstStockTypeCentral = "Central";
        public const string cstStockTypeBranch = "Branch";
        public const string cstStockTypeMaintenance = "Maintenance";
        public const string cstStockTypeRedemption = "Redemption";
        public const string cstStockTypeTransit = "Transit";

        #endregion
    }
}