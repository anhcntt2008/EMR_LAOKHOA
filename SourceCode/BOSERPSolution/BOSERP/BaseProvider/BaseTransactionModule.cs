using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Transactions;
using System.Windows.Forms;
using BOSCommon;
using BOSComponent;
using BOSLib;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTab;
using Localization;
using Microsoft.Practices.EnterpriseLibrary.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace BOSERP
{
    public class BaseTransactionModule : BaseModuleERP
    {
        #region Variables
        private String MainTableName;
        private String MainTablePrefix;

        /// <summary>
        /// A variable indicates whether the toolbar is being invalidated
        /// </summary>
        private bool ToolbarIsInvalidated = false;

        /// <summary>
        /// A variable to keep a thread of getting inventory from centre
        /// The thread will be started whenever a transaction module is loaded
        /// </summary>
        private Thread GettingInventoryThread;        
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the inventory stocks gotten from centre,
        /// is used to view inventory quickly in a transaction
        /// </summary>
        public List<ICInventoryStocksInfo> CentralInventoryStocks { get; set; }

        private BOSList<ACDocumentEntrysInfo> DEList { get; set; }
        private BaseTransactionEntities Entity { get; set; }

        #endregion

        public BaseTransactionModule()
        {
            CentralInventoryStocks = new List<ICInventoryStocksInfo>();
            DEList = new BOSList<ACDocumentEntrysInfo>();
        }

        /// <summary>
        /// Call base.InitializeModule() and initialize additional info
        /// </summary>
        public override void InitializeModule()
        {
            base.InitializeModule();    

            MainTableName = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
            MainTablePrefix = MainTableName.Substring(0, MainTableName.Length - 1);

            InitEmployeeControls();            

            InitStatusControls();

            if (BOSApp.CurrentUsersInfo.FK_HREmployeeID > 0)
            {    
                //Set default employee to the transaction
                SetDefaultEmployee();
            }

            DisplayLabelText(CurrentModuleEntity.MainObject);

            BaseTransactionEntities entity = (BaseTransactionEntities)CurrentModuleEntity;
            entity.DefaultDocumentTypeID = GetDocumentTypeID();
            entity.DocumentTypeID = entity.DefaultDocumentTypeID;
            if (entity.DocumentEntryList.GridControl != null)
            {
                (entity.DocumentEntryList.GridControl as BaseDocumentEntryGridControl).InvalidateDataSource(entity.DocumentEntryList);
            }            
        }        
        
        /// <summary>
        /// Get inventory from centre in the context of another thread.
        /// Leave the main thread run normally 
        /// </summary>
        protected void StartGettingInventoryThread()
        {            
            GettingInventoryThread = new Thread(new ThreadStart(GetInventoryFromCentre));
            GettingInventoryThread.Priority = ThreadPriority.Normal;
            GettingInventoryThread.Start();
        }
        /// <summary>
        /// Get Employee by username
        /// </summary>
        public HREmployeesInfo GetEmployeeByUsername(string username)
        {
            ADUsersController objUsersController = new ADUsersController();
            ADUsersInfo objUsersInfo = (ADUsersInfo)objUsersController.GetObjectByName(username);
            HREmployeesController objEmployeesController = new HREmployeesController();
            HREmployeesInfo objEmployeesInfo = (HREmployeesInfo)objEmployeesController.GetObjectByID(objUsersInfo.FK_HREmployeeID);
            if (objEmployeesInfo == null)
                objEmployeesInfo = new HREmployeesInfo();
            return objEmployeesInfo;
        }
        /// <summary>
        /// Get inventory from centre, allow a branch to be able to see
        /// the inventory of all other branches
        /// </summary>
        private void GetInventoryFromCentre()
        {
            BRBranchsController objBranchsController = new BRBranchsController();
            BRBranchsInfo centre = objBranchsController.GetCentre();            
            if (centre != null && centre.BRBranchID != BOSApp.CurrentCompanyInfo.FK_BRBranchID)
            {
                BOSDbUtil dbUtil = new BOSDbUtil();                        
                ICInvAdjustmentsController objInvAdjustmentsController = new ICInvAdjustmentsController();
                List<ICInvAdjustmentsInfo> invAdjustments = new List<ICInvAdjustmentsInfo>();                
                try
                {                    
                    SqlDatabase database = BOSApp.CreateConnectionToBranch(centre.BRBranchID);
                    if (BOSApp.TestConnection(database))
                    {
                        ICInventoryStocksController objInventoryStocksController = new ICInventoryStocksController();
                        DataSet ds = dbUtil.GetDataSet(database, "ICInventoryStocks_GetInventoryStocksByUserGroupID", BOSApp.CurrentUserGroupInfo.ADUserGroupID);
                        CentralInventoryStocks.Clear();
                        if (ds.Tables.Count > 0)
                        {                            
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                ICInventoryStocksInfo objInventoryStocksInfo = (ICInventoryStocksInfo)objInventoryStocksController.GetObjectFromDataRow(row);
                                CentralInventoryStocks.Add(objInventoryStocksInfo);
                            }
                        }

                        //Get inventory adjustments from centre to adjust at branch                        
                        ds = dbUtil.GetDataSet(database, "ICInvAdjustments_GetInvAdjustmentsByBranchID", BOSApp.CurrentCompanyInfo.FK_BRBranchID);                        
                        if (ds.Tables.Count > 0)
                        {
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                ICInvAdjustmentsInfo invAdjustment = (ICInvAdjustmentsInfo)objInvAdjustmentsController.GetObjectFromDataRow(row);
                                invAdjustments.Add(invAdjustment);
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }

                //Create inventory adjustments at branch first, then switch to the centre delete all 
                //the branch's adjustments. This ensures the integrity of the data                
                List<ICInvAdjustmentsInfo> transferredAdjustments = new List<ICInvAdjustmentsInfo>();
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    ICProductSeriesController objProductSeriesController = new ICProductSeriesController();
                    ICProductsController objProductsController = new ICProductsController();                    
                    foreach (ICInvAdjustmentsInfo invAdjustment in invAdjustments)                        
                    {                        
                        if (objProductsController.IsExist(invAdjustment.FK_ICProductID))
                        {
                            ICInvAdjustmentsInfo transferredAdjustment = (ICInvAdjustmentsInfo)invAdjustment.Clone();

                            SynProductSerie(invAdjustment);

                            ICInvAdjustmentsInfo existingInvAdjustment = objInvAdjustmentsController.GetInvAdjustmentByStockIDAndProductIDAndSerieID(
                                                                                                            invAdjustment.FK_ICStockID,
                                                                                                            invAdjustment.FK_ICProductID,
                                                                                                            invAdjustment.FK_ICProductSerieID);
                            if (existingInvAdjustment != null)
                            {
                                invAdjustment.ICInvAdjustmentID = existingInvAdjustment.ICInvAdjustmentID;                                
                                objInvAdjustmentsController.UpdateObject(invAdjustment);
                            }
                            else
                            {                                
                                objInvAdjustmentsController.CreateObject(invAdjustment);
                            }
                            transferredAdjustments.Add(transferredAdjustment);
                        }
                    }
                    scope.Complete();
                }

                try
                {
                    SqlDatabase database = BOSApp.CreateConnectionToBranch(centre.BRBranchID);
                    if (BOSApp.TestConnection(database))
                    {
                        foreach (ICInvAdjustmentsInfo invAdjustment in transferredAdjustments)
                        {
                            dbUtil.ExecuteNonQuery(database, "ICInvAdjustments_Delete", invAdjustment.ICInvAdjustmentID);
                        }
                    }
                }
                catch (Exception)
                {

                }

                //Adjust inventory at branch
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    invAdjustments = objInvAdjustmentsController.GetInvAdjustmentsByBranchID(BOSApp.CurrentCompanyInfo.FK_BRBranchID);
                    foreach (ICInvAdjustmentsInfo invAdjustment in invAdjustments)
                    {
                        TransactionUtil.UpdateInventoryStock(
                                                            invAdjustment.FK_ICProductID,
                                                            invAdjustment.FK_ICStockID,
                                                            invAdjustment.FK_ICProductSerieID,
                                                            invAdjustment.ICInvAdjustmentQty,
                                                            invAdjustment.ICInvAdjustmentUnitCost,
                                                            TransactionUtil.cstInventoryReceipt);                        
                    }                    
                    objInvAdjustmentsController.DeleteByBranchID(BOSApp.CurrentCompanyInfo.FK_BRBranchID);
                    scope.Complete();
                }
            }
        }

        /// <summary>
        /// Init controls bound to employee info in the transaction's context
        /// </summary>
        private void InitEmployeeControls()
        {
            foreach (XtraTabPage page in ParentScreen.ScreenContainer.TabPages)
            {                
                InitEmployeeControls(page.Controls);
            }
        }      

        /// <summary>
        /// Init controls bound to employee info in the transaction's context
        /// </summary>
        /// <param name="controls">Given controls</param>
        private void InitEmployeeControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                BOSDbUtil dbUtil = new BOSDbUtil();
                string dataMember = dbUtil.GetPropertyStringValue(ctrl, BOSScreen.cstDataMemberPropertyName);
                if (!string.IsNullOrEmpty(dataMember) && dataMember == "FK_HREmployeeID")
                {
                    if (ctrl.Tag == null || ctrl.Tag.Equals(BOSScreen.DataControl))
                    {
                        BOSLookupEdit lke = ctrl as BOSLookupEdit;
                        lke.Properties.ValueMember = "HREmployeeID";
                        lke.Properties.DisplayMember = "HREmployeeName";
                        lke.Properties.Columns.Clear();
                        LookUpColumnInfo column = new LookUpColumnInfo();
                        column.Caption = CommonLocalizedResources.HREmployeeNo;
                        column.FieldName = "HREmployeeNo";
                        lke.Properties.Columns.Add(column);

                        column = new LookUpColumnInfo();
                        column.Caption = CommonLocalizedResources.HREmployeeName2;
                        column.FieldName = "HREmployeeName";
                        lke.Properties.Columns.Add(column);

                        column = new LookUpColumnInfo();
                        column.Caption = CommonLocalizedResources.HREmployeeCardNumber;
                        column.FieldName = "HREmployeeCardNumber";
                        lke.Properties.Columns.Add(column);
                        if (BOSApp.CurrentUsersInfo.FK_HREmployeeID > 0)
                        {
                            lke.EditValue = BOSApp.CurrentUsersInfo.FK_HREmployeeID;
                            lke.Enabled = false;
                        }
                    }
                }

                if (ctrl.Controls.Count > 0)
                {
                    InitEmployeeControls(ctrl.Controls);
                }
            }
        }      

        /// <summary>
        /// Init controls bound to the status of the transaction
        /// </summary>
        private void InitStatusControls()
        {
            foreach (XtraTabPage page in ParentScreen.ScreenContainer.TabPages)
            {
                InitStatusControls(page.Controls);
            }
        }

        /// <summary>
        /// Init controls bound to the status of the transaction
        /// </summary>
        /// <param name="controls">Control collection</param>
        private void InitStatusControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                BOSDbUtil dbUtil = new BOSDbUtil();
                string dataMember = dbUtil.GetPropertyStringValue(ctrl, BOSScreen.cstDataMemberPropertyName);
                if (!string.IsNullOrEmpty(dataMember) && dataMember.Contains("Status"))
                {
                    if (ctrl.Tag == null || ctrl.Tag.Equals(BOSScreen.DataControl))
                    {
                        BOSLookupEdit lke = ctrl as BOSLookupEdit;
                        lke.CloseUp += new CloseUpEventHandler(StatusLookupEdit_CloseUp);
                    }
                }

                if (ctrl.Controls.Count > 0)
                {
                    InitStatusControls(ctrl.Controls);
                }
            }
        }

        protected void StatusLookupEdit_CloseUp(object sender, CloseUpEventArgs e)
        {
            BOSLookupEdit lke = (BOSLookupEdit)sender;
            if (e.Value != null && e.Value != lke.OldEditValue)
            {
                if (MessageBox.Show(CommonLocalizedResources.ConfirmChangeDocumentStatusMessage,
                                CommonLocalizedResources.MessageBoxDefaultCaption,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    BOSDbUtil dbUtil = new BOSDbUtil();
                    string dataMember = dbUtil.GetPropertyStringValue(lke, BOSScreen.cstDataMemberPropertyName);
                    ChangeObjectStatus(dataMember, e.Value.ToString());                    
                }
                else
                {
                    e.AcceptValue = false;
                }
            }
        }

        /// <summary>
        /// Change the status of the current main object
        /// </summary>
        /// <param name="dataMember">Data member represents the status property of the object</param>
        /// <param name="status">Selected status</param>
        protected virtual void ChangeObjectStatus(string dataMember, string status)
        {
            BaseBusinessController controller = BusinessControllerFactory.GetBusinessController(MainTableName + "Controller");
            if (controller != null)
            {
                BOSDbUtil dbUtil = new BOSDbUtil();                
                BusinessObject obj = (BusinessObject)CurrentModuleEntity.MainObject;
                dbUtil.SetPropertyValue(obj, dataMember, status);
                controller.UpdateObject(obj);
            }
        }

        /// <summary>
        /// Call base.ActionNew() and set additional info for a new transaction
        /// </summary>
        public override void ActionNew()
        {                                    
            base.ActionNew();

            SetDefaultEmployee();
            GenerateAccountingData();            
            DisplayLabelText(CurrentModuleEntity.MainObject);                                    
        }        

        public override int ActionSave()
        {
            if (!IsTransactionLocked())
            {
                SetValuesFromAccountingObject();

                BaseTransactionEntities entity = (BaseTransactionEntities)CurrentModuleEntity;
                int documentTypeID = GetDocumentTypeID();
                foreach (ACDocumentEntrysInfo entry in entity.DocumentEntryList)
                {
                    if (entry.FK_ACDocumentTypeID == 0)
                    {
                        entry.FK_ACDocumentTypeID = documentTypeID;
                    }
                }
                ClearDocumentEntryList();

                return base.ActionSave();
            }
            else
            {
                MessageBox.Show("Dữ liệu trong thời gian này đã bị khóa.",
                                CommonLocalizedResources.MessageBoxDefaultCaption,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return 0;
            }
        }        

        /// <summary>
        /// Set values from the selected accounting object
        /// to the current document
        /// </summary>
        protected void SetValuesFromAccountingObject()
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            string mainTableName = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
            string mainTablePrefix = mainTableName.Substring(0, 2);
            ACObjectsController objObjectsController = new ACObjectsController();
            string objectKey = dbUtil.GetPropertyStringValue(CurrentModuleEntity.MainObject, "ACObjectAccessKey");
            ACObjectsInfo obj = objObjectsController.GetObjectByAccessKey(objectKey);
            obj = objObjectsController.GetObjectByIDAndType(obj.ACObjectID, obj.ACObjectType);
            if (obj != null)
            {
                dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, "FK_ACObjectID", obj.ACObjectID);
                dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, mainTablePrefix + "ObjectType", obj.ACObjectType);
                dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, "ACObjectName", obj.ACObjectName);
            }
            else
            {
                dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, "FK_ACObjectID", 0);
                dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, mainTablePrefix + "ObjectType", string.Empty);
                dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, "ACObjectName", string.Empty);
            }


            objectKey = dbUtil.GetPropertyStringValue(CurrentModuleEntity.MainObject, "ACAssObjectAccessKey");
            obj = objObjectsController.GetObjectByAccessKey(objectKey);
            obj = objObjectsController.GetObjectByIDAndType(obj.ACObjectID, obj.ACObjectType);
            if (obj != null)
            {
                dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, "FK_ACAssObjectID", obj.ACObjectID);
                dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, mainTablePrefix + "AssObjectType", obj.ACObjectType);
            }
            else
            {
                dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, "FK_ACAssObjectID", 0);
                dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, mainTablePrefix + "AssObjectType", string.Empty);
            }
        }
             
        /// <summary>
        /// Call base.Invalidate() and set additional info for the current transaction
        /// </summary>
        /// <param name="iObjectID"></param>
        public override void Invalidate(int iObjectID)
        {
            base.Invalidate(iObjectID);

            CurrentModuleEntity.SetPropertyChangeEventLock(false);
            InvalidateEmployee();
            InvalidateAccountingObject();
            InvalidateAccountingEntries();
            DisplayLabelText(CurrentModuleEntity.MainObject);
            CurrentModuleEntity.SetPropertyChangeEventLock(true);
        }

        public override void InvalidateToolbar()
        {            
            if (IsTransactionLocked())
            {
                ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, false);
                ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonComplete, false);
                ParentScreen.SetEnableOfToolbarButton("EditAfterCompleting", false);
                ParentScreen.SetEnableOfToolbarButton("EditDeliveryDate", false);
                ParentScreen.SetEnableOfToolbarButton("TakePayment", false);
                ParentScreen.SetEnableOfToolbarButton("EditPayment", false);
                ParentScreen.SetEnableOfToolbarButton("TransferDeposit", false);
            }
            else
            {
                if (!ToolbarIsInvalidated)
                {                    
                    ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonEdit, true);
                    ParentScreen.SetEnableOfToolbarButton(BaseToolbar.ToolbarButtonComplete, true);
                    ParentScreen.SetEnableOfToolbarButton("EditAfterCompleting", true);
                    ParentScreen.SetEnableOfToolbarButton("EditDeliveryDate", true);
                    ParentScreen.SetEnableOfToolbarButton("TakePayment", true);
                    ParentScreen.SetEnableOfToolbarButton("EditPayment", true);
                    ParentScreen.SetEnableOfToolbarButton("TransferDeposit", true);
                    ToolbarIsInvalidated = true;
                    InvalidateToolbar();
                }
                else
                {
                    ToolbarIsInvalidated = false;
                }
            }

            base.InvalidateToolbar();
        }

        /// <summary>
        /// Set default employee from the current user
        /// </summary>
        protected void SetDefaultEmployee()
        {            
            BOSDbUtil dbUtil = new BOSDbUtil();
            dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, "FK_HREmployeeID", BOSApp.CurrentUsersInfo.FK_HREmployeeID);
            HREmployeesController objEmployeesController = new HREmployeesController();
            HREmployeesInfo objHREmployeesInfo = (HREmployeesInfo)objEmployeesController.GetObjectByID(BOSApp.CurrentUsersInfo.FK_HREmployeeID);
            if (objHREmployeesInfo != null)
            {
                dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, String.Format("{0}EmployeePicture", MainTablePrefix), objHREmployeesInfo.HREmployeePicture);
                CurrentModuleEntity.UpdateMainObjectBindingSource();
            }
        }

        /// <summary>
        /// Invalidate employee
        /// </summary>
        protected void InvalidateEmployee()
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            int employeeID = dbUtil.GetPropertyIntValue(CurrentModuleEntity.MainObject, "FK_HREmployeeID");
            HREmployeesController objEmployeesController = new HREmployeesController();
            HREmployeesInfo objHREmployeesInfo = (HREmployeesInfo)objEmployeesController.GetObjectByID(employeeID);
            if (objHREmployeesInfo != null)
            {
                dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, String.Format("{0}EmployeePicture", MainTablePrefix), objHREmployeesInfo.HREmployeePicture);
                CurrentModuleEntity.UpdateMainObjectBindingSource();
            }
        }      

        /// <summary>
        /// Show customer info of the current transaction
        /// </summary>
        protected virtual void ShowCustomerInfo()
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            ARCustomersController objCustomersController = new ARCustomersController();
            int customerID = Convert.ToInt32(dbUtil.GetPropertyValue(CurrentModuleEntity.MainObject, "FK_ARCustomerID"));
            ARCustomersInfo objCustomersInfo = (ARCustomersInfo)objCustomersController.GetObjectByID(customerID);
            if (objCustomersInfo != null)
                DisplayLabelText(objCustomersInfo);
        }        

        /// <summary>
        /// Called when user changes the staff of the transaction
        /// </summary>
        public void ChangeStaff(object sender, EventArgs e)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            BOSComponent.BOSLookupEdit lke = (BOSComponent.BOSLookupEdit)sender;
            if (lke != null && lke.EditValue != lke.OldEditValue)
            {
                HREmployeesController objEmployeesController = new HREmployeesController();
                HREmployeesInfo objHREmployeesInfo = (HREmployeesInfo)objEmployeesController.GetObjectByID(Convert.ToInt32(lke.EditValue));
                if (objHREmployeesInfo != null)
                {
                    dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, String.Format("{0}EmployeePicture", MainTablePrefix), objHREmployeesInfo.HREmployeePicture);
                    CurrentModuleEntity.UpdateMainObjectBindingSource();
                }
            }
        }

        /// <summary>
        /// Get document type id of the current document
        /// </summary>
        /// <returns>Document type id</returns>
        public virtual int GetDocumentTypeID()
        {
            return 0;
        }

        /// <summary>
        /// Get current document no
        /// </summary>
        /// <returns>The document no</returns>
        public virtual string GetCurrentDocumentNo()
        {
            string documentNo = string.Empty;
            if (Toolbar.CurrentObjectID > 0)
            {
                BOSDbUtil dbUtil = new BOSDbUtil();
                String mainTableName = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
                String objectNoColumnName = mainTableName.Substring(0, mainTableName.Length - 1) + "No";
                documentNo = dbUtil.GetPropertyValue(CurrentModuleEntity.MainObject, objectNoColumnName).ToString();
            }
            return documentNo;
        }

        /// <summary>
        /// Invalidate serie column with the corresponding item
        /// </summary>
        /// <param name="column">Grid column</param>
        /// <param name="item">Item</param>
        /// <param name="itemTableName">Table name of item</param>
        public virtual void InvalidateSerieColumn(GridColumn column, BusinessObject item, string itemTableName)
        {
            ICProductSeriesController objProductSeriesController = new ICProductSeriesController();
            BOSDbUtil dbUtil = new BOSDbUtil();
            int productID = dbUtil.GetPropertyIntValue(item, "FK_ICProductID");
            int stockID = dbUtil.GetPropertyIntValue(item, "FK_ICStockID");
            List<ICProductSeriesInfo> series = objProductSeriesController.GetSeriesByProductIDAndStockID(productID, stockID);
            if (series.Count > 0)
            {
                series.Insert(0, new ICProductSeriesInfo());
            }
            RepositoryItemComboBox rep = new RepositoryItemComboBox();
            foreach (ICProductSeriesInfo serie in series)
            {
                rep.Items.Add(serie.ICProductSerieNo);
            }
            column.ColumnEdit = rep;
        }

        /// <summary>
        /// Invalidate item serie no
        /// </summary>
        /// <param name="item">Item</param>
        /// <param name="itemTableName">Table name of item</param>
        public virtual void InvalidateItemSerieNo(BusinessObject item, string itemTableName, string serieColumnName)
        {
            string itemTablePrefix = itemTableName.Substring(0, itemTableName.Length - 1);
            BOSDbUtil dbUtil = new BOSDbUtil();
            int productID = dbUtil.GetPropertyIntValue(item, "FK_ICProductID");
            int stockID = dbUtil.GetPropertyIntValue(item, "FK_ICStockID");            
            string serieNo = dbUtil.GetPropertyStringValue(item, serieColumnName);
            ICProductSeriesController objProductSeriesController = new ICProductSeriesController();
            ICProductSeriesInfo serie = objProductSeriesController.GetSerieByProductIDAndSerieNo(productID, serieNo);             
            if (serie != null)
            {
                dbUtil.SetPropertyValue(item, "FK_ICProductSerieID", serie.ICProductSerieID);      
            }
            else
            {
                dbUtil.SetPropertyValue(item, "FK_ICProductSerieID", 0);
                //dbUtil.SetPropertyValue(item, serieColumnName, string.Empty);
            }
        }        

        public override void ShowInventory(int productID)
        {
            ICProductsController objProductsController = new ICProductsController();
            ICProductsInfo objProductsInfo = (ICProductsInfo)objProductsController.GetObjectByID(productID);
            if (objProductsInfo != null)
            {
                int userGroupID = BOSApp.CurrentUserGroupInfo.ADUserGroupID;
                guiInventoryStockQuantity guiInventoryStockQuantity = new guiInventoryStockQuantity();
                guiInventoryStockQuantity.Module = this;
                List<ICInventoryStocksInfo> inventoryStocks = new List<ICInventoryStocksInfo>();
                ICInventoryStocksController objInventoryStocksController = new ICInventoryStocksController();
                inventoryStocks = objInventoryStocksController.GetInventoryStocksByProductIDAndGroupByStockID(productID, userGroupID);

                //Collect inventory from the centre                
                List<ICInventoryStocksInfo> centralInventoryStocks = CentralInventoryStocks.Where(i => i.FK_ICProductID == productID).ToList();
                foreach (ICInventoryStocksInfo centralInventoryStock in centralInventoryStocks)
                {
                    if (centralInventoryStock.FK_BRBranchID != BOSApp.CurrentCompanyInfo.FK_BRBranchID &&
                        centralInventoryStock.BRBranchParentID != BOSApp.CurrentCompanyInfo.FK_BRBranchID)
                    {
                        ICInventoryStocksInfo objInventoryStocksInfo = inventoryStocks.Where(i => i.FK_ICStockID == centralInventoryStock.FK_ICStockID &&
                                                                                                    i.FK_ICProductID == centralInventoryStock.FK_ICProductID).FirstOrDefault();
                        if (objInventoryStocksInfo != null)
                        {
                            objInventoryStocksInfo.ICInventoryStockQuantity = centralInventoryStock.ICInventoryStockQuantity;
                        }
                        else
                        {
                            inventoryStocks.Add(centralInventoryStock);
                        }
                    }
                }
                
                if (objProductsInfo.HasComponent)
                {
                    ICStocksController objStocksController = new ICStocksController();
                    List<ICStocksInfo> stocks = objStocksController.GetStocksByUserGroupID(BOSApp.CurrentUserGroupInfo.ADUserGroupID);
                    foreach (ICStocksInfo objStocksInfo in stocks)
                    {
                        ICInventoryStocksInfo existingInventoryStock = inventoryStocks.Where(inv => inv.FK_ICStockID == objStocksInfo.ICStockID &&
                                                                                            inv.FK_ICProductID == productID).FirstOrDefault();
                        if (existingInventoryStock == null)
                        {
                            existingInventoryStock = new ICInventoryStocksInfo();
                            existingInventoryStock.FK_BRBranchID = objStocksInfo.FK_BRBranchID;
                            existingInventoryStock.BRBranchName = objStocksInfo.BRBranchName;
                            existingInventoryStock.FK_ICStockID = objStocksInfo.ICStockID;
                            existingInventoryStock.ICStockType = objStocksInfo.ICStockType;
                            existingInventoryStock.FK_ICProductID = productID;
                            inventoryStocks.Add(existingInventoryStock);
                        }
                    }

                    foreach (ICInventoryStocksInfo objInventoryStocksInfo in inventoryStocks)
                    {
                        if (objInventoryStocksInfo.FK_ICProductID == productID)
                        {
                            objInventoryStocksInfo.ICInventoryStockQuantity = CalculateProductQtyByComponent(inventoryStocks, productID, objInventoryStocksInfo.FK_ICStockID);
                        }
                    }
                }

                inventoryStocks = inventoryStocks.Where(inv => inv.FK_ICProductID == productID).ToList();
                inventoryStocks.Where(i => i.ICStockType == StockType.Sale.ToString() || i.ICStockType == StockType.Central.ToString())
                                .ToList()
                                .ForEach(i => i.InventoryType = InventoryType.OnHand.ToString());                 

                inventoryStocks.Where(i => i.ICStockType == StockType.SaleOrder.ToString())
                                .ToList()
                                .ForEach(i => i.InventoryType = InventoryType.SaleOrder.ToString());       

                inventoryStocks.Where(i => i.ICStockType == StockType.Purchase.ToString())
                               .ToList()                                   
                               .ForEach(i => i.InventoryType = InventoryType.PurchaseOrder.ToString());

                inventoryStocks.Where(i => i.ICStockType == StockType.TransitIn.ToString())
                                .ToList()
                                .ForEach(i => i.InventoryType = InventoryType.TransitIn.ToString());

                inventoryStocks.Where(i => i.ICStockType == StockType.TransitOut.ToString())
                                .ToList()
                                .ForEach(i => i.InventoryType = InventoryType.TransitOut.ToString());

                inventoryStocks = inventoryStocks.Where(i => i.ICInventoryStockQuantity > 0).ToList();
                guiInventoryStockQuantity.InventoryStockQuantityGridControl.DataSource = inventoryStocks;                
                guiInventoryStockQuantity.ShowDialog();
            }
        }       

        /// <summary>
        /// Calculate the quantity of a product based on its inventory components in a stock
        /// </summary>        
        /// <param name="inventory">Inventory data</param>
        /// <param name="productID">Product id</param>
        /// <param name="stockID">Stock id</param>
        /// <returns>On-hand quantity of the product</returns>
        private double CalculateProductQtyByComponent(List<ICInventoryStocksInfo> inventoryStocks, int productID, int stockID)
        {
            ICProductComponentsController objProductComponentsController = new ICProductComponentsController();
            List<ICProductComponentsInfo> components = objProductComponentsController.GetProductComponentListByProductID(productID);
            double productQty = Int32.MaxValue;
            foreach (ICProductComponentsInfo component in components)
            {
                double inventoryStockQty = inventoryStocks.Where(inv => inv.FK_ICProductID == component.FK_ICProductComponentChildID && inv.FK_ICStockID == stockID).Sum(inv => inv.ICInventoryStockQuantity);
                if (component.ICProductComponentQty > 0)
                {
                    double qty = Math.Floor(inventoryStockQty / component.ICProductComponentQty);
                    if (qty < productQty)
                    {
                        productQty = qty;
                    }
                }
            }
            if (productQty == Int32.MaxValue)
            {
                productQty = 0;
            }
            return productQty;
        }

        #region Accounting
        /// <summary>
        /// Invaldiate accounting object
        /// </summary>
        protected void InvalidateAccountingObject()
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            string mainTableName = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
            string mainTablePrefix = mainTableName.Substring(0, 2);
            int objectID = dbUtil.GetPropertyIntValue(CurrentModuleEntity.MainObject, "FK_ACObjectID");
            string objectType = dbUtil.GetPropertyStringValue(CurrentModuleEntity.MainObject, mainTablePrefix + "ObjectType");                                    
            dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, "ACObjectAccessKey", string.Format("{0};{1}", objectID, objectType));

            objectID = dbUtil.GetPropertyIntValue(CurrentModuleEntity.MainObject, "FK_ACAssObjectID");
            objectType = dbUtil.GetPropertyStringValue(CurrentModuleEntity.MainObject, mainTablePrefix + "AssObjectType");
            dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, "ACAssObjectAccessKey", string.Format("{0};{1}", objectID, objectType));
            CurrentModuleEntity.UpdateMainObjectBindingSource();
        }

        /// <summary>
        /// Invalidate accounting entries of all documents relating to the transaction
        /// </summary>
        protected virtual void InvalidateAccountingEntries()
        {
            BaseTransactionEntities entity = (BaseTransactionEntities)CurrentModuleEntity;
            ACDocumentsController objDocumentsController = new ACDocumentsController();
            ACDocumentEntrysController objDocumentEntrysController = new ACDocumentEntrysController();
            string documentNo = GetCurrentDocumentNo();
            entity.DocumentTypeID = GetDocumentTypeID();
            entity.DocumentList = objDocumentsController.GetRelativeDocumentsByDocumentTypeIDAndDocumentNo(entity.DocumentTypeID, documentNo);            
            List<ACDocumentEntrysInfo> entries = new List<ACDocumentEntrysInfo>();
            foreach (ACDocumentsInfo objDocumentsInfo in entity.DocumentList)
            {
                List<ACDocumentEntrysInfo> result = objDocumentEntrysController.GetDocumentEntryByDocumentID(objDocumentsInfo.ACDocumentID);
                entries = entries.Concat(result).ToList();
            }
            entity.DocumentEntryList.Invalidate(entries);            
        }

        /// <summary>
        /// Generate accounting data, includes documents, entries relating to
        /// the current transaction
        /// </summary>
        public virtual void GenerateAccountingData()
        {
            
        }


        /// <summary>
        /// Update all accounting entries relating to the transaction        
        /// </summary>
        protected virtual void UpdateDocumentEntries()
        {
            
        }
        #endregion

        public override bool IsEditable()
        {
            bool isEditable = base.IsEditable();
            if (isEditable)
            {
                isEditable = !IsTransactionLocked();                
            }
            return isEditable;
        }

        /// <summary>
        /// Check whether the transaction is locked
        /// </summary>
        /// <returns>True if the transaction is locked, otherwise false</returns>
        protected virtual bool IsTransactionLocked()
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            object value = dbUtil.GetPropertyValue(CurrentModuleEntity.MainObject, MainTablePrefix + "Date");
            if (value != null)
            {
                DateTime transactionDate = Convert.ToDateTime(value);
                ADLocksController objLocksController = new ADLocksController();
                ADLocksInfo lockInfo = objLocksController.GetActiveLockByDate(transactionDate);
                if (lockInfo != null)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Update Document Entry when add a product
        /// </summary>
        /// <param name="accountID">AccountID of product</param>
        /// <param name="totalAmount">amount</param>
        /// <param name="entity">current entity</param>
        public void UpdateDocumentEntryList(int accountID, double totalAmount, BaseTransactionEntities entity, double exchangeRate)
        {
            Entity = entity;
            bool swap = false;
            ACAccountsController objAccountsController = new ACAccountsController();
            ACAccountsInfo objDefaultAccount = (ACAccountsInfo)objAccountsController.GetObjectByNo(AccountDefault.DefaultAccount.ToString());
            if (accountID == 0)
            {
                accountID = objDefaultAccount.ACAccountID;
            }

            ACDocumentEntrysInfo obj = entity.DocumentEntryList.Where(p => p.FK_ACDebitAccountID == accountID).FirstOrDefault();

            if (obj == null)
            {
                obj = entity.DocumentEntryList.Where(p => p.FK_ACCreditAccountID == accountID).FirstOrDefault();
                if (obj == null)
                {
                    obj = entity.DocumentEntryList.Where(p => p.FK_ACCreditAccountID == objDefaultAccount.ACAccountID).FirstOrDefault();
                    ACDocumentEntrysInfo objNewDocumentEntrysInfo = new ACDocumentEntrysInfo();
                    if (obj == null)
                    {
                        obj = entity.DocumentEntryList.Where(p => p.FK_ACDebitAccountID == objDefaultAccount.ACAccountID).FirstOrDefault();
                        BOSUtil.CopyObject(obj, objNewDocumentEntrysInfo);
                        objNewDocumentEntrysInfo.FK_ACDebitAccountID = accountID;
                        objNewDocumentEntrysInfo.FK_ACCreditAccountID = obj.FK_ACCreditAccountID;
                    }
                    else
                    {
                        BOSUtil.CopyObject(obj, objNewDocumentEntrysInfo);
                        objNewDocumentEntrysInfo.FK_ACDebitAccountID = obj.FK_ACDebitAccountID;
                        objNewDocumentEntrysInfo.FK_ACCreditAccountID = accountID;
                    }
                    objNewDocumentEntrysInfo.ACDocumentEntryDesc = obj.ACDocumentEntryDesc;
                    if (!swap)
                    {
                        objNewDocumentEntrysInfo.ACDocumentEntryAmount = totalAmount;
                        objNewDocumentEntrysInfo.ACDocumentEntryExchangeAmount = totalAmount * exchangeRate;
                    }
                    else
                    {
                        objNewDocumentEntrysInfo.ACDocumentEntryAmount = totalAmount / exchangeRate;
                        objNewDocumentEntrysInfo.ACDocumentEntryExchangeAmount = totalAmount;
                    }
                    objNewDocumentEntrysInfo.ACEntryTypeName = obj.ACEntryTypeName;
                    int index = entity.DocumentEntryList.IndexOf(obj);
                    entity.DocumentEntryList.Insert(index, objNewDocumentEntrysInfo);
                }
                else
                {
                    if (!swap)
                    {
                        obj.ACDocumentEntryAmount += totalAmount;
                        obj.ACDocumentEntryExchangeAmount = obj.ACDocumentEntryAmount * exchangeRate;
                    }
                    else
                    {
                        obj.ACDocumentEntryAmount += totalAmount / exchangeRate;
                        obj.ACDocumentEntryExchangeAmount += totalAmount;
                    }
                }
            }
            else
            {
                if (!swap)
                {
                    obj.ACDocumentEntryAmount += totalAmount;
                    obj.ACDocumentEntryExchangeAmount = obj.ACDocumentEntryAmount * exchangeRate;
                }
                else
                {
                    obj.ACDocumentEntryAmount += totalAmount / exchangeRate;
                    obj.ACDocumentEntryExchangeAmount += totalAmount;
                }
            }
            if (DEList.IndexOf(obj) == -1)
            {
                DEList.Add(obj);
            }
        }

        /// <summary>
        /// delete an account with amount = 0
        /// </summary>
        private void ClearDocumentEntryList()
        {
            if (DEList == null || DEList.Count == 0) return;
            bool nullValue = true;
            while (nullValue)
            {
                nullValue = false;
                ACAccountsController objAccountsController = new ACAccountsController();
            ACAccountsInfo objDefaultAccount = (ACAccountsInfo)objAccountsController.GetObjectByNo(AccountDefault.DefaultAccount.ToString());
                foreach (var item in DEList)
                {
                    if (item.ACDocumentEntryAmount == 0)
                    {
                        if(item.FK_ACCreditAccountID == objDefaultAccount.ACAccountID ||
                            item.FK_ACDebitAccountID == objDefaultAccount.ACAccountID)
                        Entity.DocumentEntryList.Remove(item);
                        DEList.Remove(item);
                        nullValue = true;
                        break;
                    }
                }
            }
        }

        public ICStocksInfo GetSaleStockByStockID(int stockID)
        {
            if (stockID == 0) return new ICStocksInfo();
            ICStocksController objStocksController = new ICStocksController();
            ICStocksInfo objStock = (ICStocksInfo)objStocksController.GetObjectByID(stockID);

            List<ICStocksInfo> list = objStocksController.GetAllStocks();
            ICStocksInfo objStocksInfo = list.Where(p => p.ICStockID == objStock.ICStockParentID).FirstOrDefault();
            if (objStocksInfo != null)
            {
                objStocksInfo = list.Where(p => p.ICStockID == objStocksInfo.ICStockTemporaryParentID).FirstOrDefault();
                if (objStocksInfo != null)
                {
                    return objStocksInfo;
                }
            }
            return null;
        }

        public ICStocksInfo GetStockBySaleStockID(int stockID, string stockType)
        {
            if (stockID == 0) return new ICStocksInfo();
            ICStocksController objStocksController = new ICStocksController();
            List<ICStocksInfo> list = objStocksController.GetAllStocks();
            ICStocksInfo obj = list.Where(p => p.ICStockTemporaryParentID == stockID).FirstOrDefault();
            if (obj != null)
            {
                obj = list.Where(p => (p.ICStockParentID == obj.ICStockID &&
                                        p.ICStockType == stockType)).FirstOrDefault();
                return obj;
            }
            return null;
        }
    }
}
