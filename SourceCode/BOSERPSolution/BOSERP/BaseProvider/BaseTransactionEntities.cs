using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOSCommon;
using BOSLib;
using System.Collections;
using Localization;

namespace BOSERP
{   
    public class BaseTransactionEntities : ERPModuleEntities
    {
        #region Properties
        /// <summary>
        /// Gets or sets the transaction type
        /// </summary>
        public TransactionType TransactionType { get; set; }
               
        /// <summary>
        /// Gets or sets the document list, includes the current document and all its
        /// relative ones
        /// </summary>
        public List<ACDocumentsInfo> DocumentList { get; set; }

        /// <summary>
        /// Gets or sets all entries of all documents relating to the transaction
        /// </summary>
        public BOSList<ACDocumentEntrysInfo> DocumentEntryList { get; set; }

        /// <summary>
        /// Gets or sets the default document type id that associates with the transaction
        /// </summary>
        public int DefaultDocumentTypeID { get; set; }

        /// <summary>
        /// Gets or sets the type id of the current document
        /// </summary>
        public int DocumentTypeID { get; set; }
        #endregion

        public BaseTransactionEntities()
        {
            DocumentList = new List<ACDocumentsInfo>();
            DocumentEntryList = new BOSList<ACDocumentEntrysInfo>(this, string.Empty, TableName.ACDocumentEntrysTableName);
            
            ModuleObjects.Add(TableName.ACDocumentEntrysTableName, new ACDocumentEntrysInfo());
        }

        /// <summary>
        /// Call base.SetDefaultValuesFromCustomer() and set additional info from the customer
        /// </summary>
        /// <param name="objCustomersInfo">Given customer</param>
        public override void SetDefaultValuesFromCustomer(ARCustomersInfo objCustomersInfo)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            int priceLevelID = Convert.ToInt32(dbUtil.GetPropertyValue(MainObject, "FK_ARPriceLevelID"));
            if (objCustomersInfo.FK_ARPriceLevelID != priceLevelID)
            {
                if (MessageBox.Show(CommonLocalizedResources.ConfirmPriceLevelMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UpdatePriceLevel(objCustomersInfo);
                }
            }

            base.SetDefaultValuesFromCustomer(objCustomersInfo);

            String mainTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
            String mainTablePrefix = mainTableName.Substring(0, mainTableName.Length - 1);
            dbUtil.SetPropertyValue(MainObject, String.Format("{0}InvoiceAddressLine3", mainTablePrefix), BOSUtil.GenerateFullAddress(objCustomersInfo, AddressType.Invoice.ToString()));
            dbUtil.SetPropertyValue(MainObject, String.Format("{0}DeliveryAddressLine3", mainTablePrefix), BOSUtil.GenerateFullAddress(objCustomersInfo, AddressType.Delivery.ToString()));
            dbUtil.SetPropertyValue(MainObject, String.Format("{0}PaymentAddressLine3", mainTablePrefix), BOSUtil.GenerateFullAddress(objCustomersInfo, AddressType.Payment.ToString()));
        }

        /// <summary>
        /// Update transaction's price level from the customer, will be overriden in a specific module        
        /// </summary>
        /// <param name="objCustomersInfo">Given customer</param>
        public virtual void UpdatePriceLevel(ARCustomersInfo objCustomersInfo)
        {

        }

        public override string GetMainObjectNo(ref int numberingStart)
        {
            String strMainObjectNo = String.Empty;
            GENumberingController objGENumberingController = new GENumberingController();
            //DDCan [MOD] [18/11/2013] [DB centre] [GENumbering issue], START
            //GENumberingInfo objGENumberingInfo = (GENumberingInfo)objGENumberingController.GetObjectByName(Module.Name);
            GENumberingInfo objGENumberingInfo;
            List<GENumberingInfo> nuberingList = objGENumberingController.GetNumberingListByName(Module.Name);
            if (nuberingList.Count == 1)
            {
                objGENumberingInfo = nuberingList[0];
            }
            else
            {
                objGENumberingInfo = nuberingList.Where(i => i.FK_BRBranchID == BOSApp.CurrentCompanyInfo.FK_BRBranchID).FirstOrDefault();
            }
            //DDCan [MOD] [18/11/2013] [DB centre] [GENumbering issue], END

            if (objGENumberingInfo != null)
            {
                String mainTableName = BOSUtil.GetTableNameFromBusinessObject(MainObject);
                BaseBusinessController objMainObjectController = BusinessControllerFactory.GetBusinessController(mainTableName + "Controller");
                if (objMainObjectController != null)
                {
                    BOSDbUtil dbUtil = new BOSDbUtil();
                    DateTime currentDate = dbUtil.GetCurrentServerDate();

                    string prefixYear = "";
                    int numberStart = objGENumberingInfo.GENumberingStart;

                    if(objGENumberingInfo.GENumberingPrefixHaveYear == true)
                    {
                        prefixYear = currentDate.Year.ToString().Substring(2, 2) + ".";
                        if (objGENumberingInfo.AAUpdatedDate.Year < currentDate.Year)
                        {
                            numberStart = Convert.ToInt32(Math.Pow(10, objGENumberingInfo.GENumberingLength - 1)) + 1;
                        }
                    }

                    strMainObjectNo = String.Format("{0}{1}{2}", objGENumberingInfo.GENumberingPrefix, prefixYear, numberStart.ToString().PadLeft(objGENumberingInfo.GENumberingLength, '0'));
                    numberingStart = numberStart;

                    while (objMainObjectController.IsExist(strMainObjectNo))
                    {
                        numberStart++;
                        strMainObjectNo = String.Format("{0}{1}{2}", objGENumberingInfo.GENumberingPrefix, prefixYear, numberStart.ToString().PadLeft(objGENumberingInfo.GENumberingLength, '0'));
                        numberingStart = numberStart;
                    }
                }
            }
            return strMainObjectNo;
        }

        #region Accounting
        /// <summary>
        /// Save accounting data, includes documents, entries relating to
        /// the current transaction
        /// </summary>
        /// <returns>True if save successfully, otherwise false</returns>
        public virtual bool SaveAccountingData()
        {
            SaveDocuments();

            SaveDocumentRelationship();

            SaveDocumentEntrys();

            return true;
        }

        /// <summary>
        /// Save all documents relating to the transaction
        /// </summary>
        public virtual void SaveDocuments()
        {
            ACDocumentsController objDocumentsController = new ACDocumentsController();
            ACDocumentEntrysController objDocumentEntrysController = new ACDocumentEntrysController();
            foreach (ACDocumentsInfo document in DocumentList)
            {
                List<ACDocumentEntrysInfo> entries = DocumentEntryList.Where(e => e.FK_ACDocumentTypeID == document.FK_ACDocumentTypeID &&
                                                                            (string.IsNullOrEmpty(e.ACDocumentNo) || e.ACDocumentNo == document.ACDocumentNo)).ToList();                
                if (entries.Count > 0)
                {
                    document.ACDocumentTotalAmount = entries.Sum(e => e.ACDocumentEntryAmount);
                    document.ACDocumentExchangeAmount = entries.Sum(e => e.ACDocumentEntryExchangeAmount);
                }
                ACDocumentsInfo existingDocument = objDocumentsController.GetDocumentByDocumentTypeIDAndDocumentNo(document.FK_ACDocumentTypeID, document.ACDocumentNo);
                if (existingDocument == null)
                {
                    document.ACDocumentPostingDate = document.ACDocumentDate;
                    document.IsPosted = true;
                    objDocumentsController.CreateObject(document);
                }
                else
                {
                    document.ACDocumentID = existingDocument.ACDocumentID;
                    objDocumentsController.UpdateObject(document);
                }
            }
        }

        /// <summary>
        /// Save the relationship between documents
        /// </summary>
        public virtual void SaveDocumentRelationship()
        {             
            if (DocumentList.Count > 0)
            {
                ACRelativeDocumentsController objRelativeDocumentsController = new ACRelativeDocumentsController();
                int documentID = DocumentList[0].ACDocumentID;
                objRelativeDocumentsController.DeleteByForeignColumn("FK_ACDocumentID", documentID);
                for (int i = 1; i < DocumentList.Count; i++)
                {
                    ACRelativeDocumentsInfo existingRelativeDocument = objRelativeDocumentsController.GetObjectByDocumentIDAndRelativeDocumentID(documentID, DocumentList[i].ACDocumentID);
                    if (existingRelativeDocument == null)
                    {
                        ACRelativeDocumentsInfo relativeDocument = new ACRelativeDocumentsInfo();
                        relativeDocument.FK_ACDocumentID = documentID;
                        relativeDocument.FK_ACRelativeDocumentID = DocumentList[i].ACDocumentID;
                        objRelativeDocumentsController.CreateObject(relativeDocument);
                    }
                }
            }
        }
         
        /// <summary>
        /// Save entries of all documents
        /// </summary>
        public virtual void SaveDocumentEntrys()
        {
            foreach (ACDocumentEntrysInfo entry in DocumentEntryList)
            {                
                ACDocumentsInfo objDocumentsInfo = DocumentList.Where(d => d.FK_ACDocumentTypeID == entry.FK_ACDocumentTypeID &&
                                                                    (string.IsNullOrEmpty(entry.ACDocumentNo) || entry.ACDocumentNo == d.ACDocumentNo)).FirstOrDefault();
                if (objDocumentsInfo != null)
                {
                    entry.FK_ACDocumentID = objDocumentsInfo.ACDocumentID;
                    entry.FK_ACObjectID = objDocumentsInfo.FK_ACObjectID;
                    entry.FK_ACAssObjectID = objDocumentsInfo.FK_ACAssObjectID;
                    entry.ACObjectType = objDocumentsInfo.ACObjectType;
                    entry.ACAssObjectType = objDocumentsInfo.ACAssObjectType;                                        
                }
            }
            DocumentEntryList.SaveItemObjects();
        }

        /// <summary>
        /// Save entries of a document
        /// </summary>
        /// <param name="objDocumentsInfo">Given document</param>
        public virtual void SaveDocumentEntrys(ACDocumentsInfo objDocumentsInfo)
        {
            foreach (ACDocumentEntrysInfo entry in DocumentEntryList)
            {
                entry.FK_ACDocumentID = objDocumentsInfo.ACDocumentID;
                entry.FK_ACObjectID = objDocumentsInfo.FK_ACObjectID;
                entry.FK_ACAssObjectID = objDocumentsInfo.FK_ACAssObjectID;
                entry.ACObjectType = objDocumentsInfo.ACObjectType;
                entry.ACAssObjectType = objDocumentsInfo.ACAssObjectType;
            }
            DocumentEntryList.SaveItemObjects();
        }
        #endregion
    }
}
