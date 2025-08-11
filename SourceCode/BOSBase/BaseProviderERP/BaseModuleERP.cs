using System;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Collections.Generic;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars;
using DevExpress.XtraTab;
using BOSLib;
using BOSComponent;
using Localization;

namespace BOSERP
{
    /// <summary>
    /// Declare some functions and virtual functions for each module manager.
    /// </summary>
    public partial class BaseModuleERP : BaseModule, IBaseModuleERP
    {
        #region Variables
        protected ERPModuleEntities _currentModuleEntity;
        protected ModuleParentScreen _parentScreen;
        protected ModuleSearchScreen _searchScreen;
        protected SortedList<String, ControlCollection> _fieldGroupControls;
        protected String _destinationAction = String.Empty;
        protected object[] _destinationActionParameters;
        protected BaseModuleERP _owner;
        protected String _displayModus;

        protected guiErrorMessage ErrorMessageScreen;
        protected DataTable ErrorTable = new DataTable();        
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the entity of the module that is responsible for handling business process
        /// </summary>
        public ERPModuleEntities CurrentModuleEntity
        {
            get { return _currentModuleEntity; }
            set { _currentModuleEntity = value; }
        }

        /// <summary>
        /// Gets or sets the screen containing the module's interface
        /// </summary>
        public ModuleParentScreen ParentScreen
        {
            get { return _parentScreen; }
            set { _parentScreen = value; }
        }

        /// <summary>
        /// Gets or sets the screen containing the search criteria of the module
        /// </summary>
        public ModuleSearchScreen SearchScreen
        {
            get { return _searchScreen; }
            set { _searchScreen = value; }
        }

        /// <summary>
        /// Gets or sets the control collection seperated by STFieldGroup
        /// </summary>
        public SortedList<String, ControlCollection> FieldGroupControls
        {
            get
            {
                return _fieldGroupControls;
            }
            set
            {
                _fieldGroupControls = value;
            }
        }

        /// <summary>
        /// Gets or sets the destination action of an action chain that is relative to some modules
        /// </summary>
        public String DestinationAction
        {
            get
            {
                return _destinationAction;
            }
            set
            {
                _destinationAction = value;
            }
        }

        /// <summary>
        /// Gets or sets the parameters that need to be passed to the destination action
        /// </summary>
        public object[] DestinationActionParameters
        {
            get
            {
                return _destinationActionParameters;
            }
            set
            {
                _destinationActionParameters = value;
            }
        }

        /// <summary>
        /// Gets or sets the module calls this one
        /// </summary>
        public BaseModuleERP Owner
        {
            get
            {
                return _owner;
            }
            set
            {
                _owner = value;
            }
        }

        public String DisplayModus
        {
            get { return _displayModus; }
            set { _displayModus = value; }
        }        
        #endregion

        #region Constructor
        /// <summary type="Constructor">
        /// Default Constructor
        /// </summary>
        public BaseModuleERP()
        {
            Toolbar = new BaseToolbar();
            Screens = new List<BOSScreen>();
            Controls = new ControlCollection();
            
            FieldGroupControls = new SortedList<string, ControlCollection>();           
           
            ParentScreen = new ModuleParentScreen();
            ParentScreen.Module = this;
            ParentScreen.MdiParent = BOSApp.MainScreen;            

            ParentScreen.ButtonCreateCriteria.DropDownControl = ParentScreen.ModuleUserCriteriaContainer;
            ParentScreen.ButtonCreateCriteria.ShowDropDownControl += new DevExpress.XtraEditors.ShowDropDownControlEventHandler(CreateCriteriaDropDownButton_ShowDropDownControl);
            SearchScreen = new ModuleSearchScreen();
            SearchScreen.module = this;            
            ErrorTable = InitErrorTable();

            //Add code init CurrentModuleObject
            CurrentModuleEntity = new ERPModuleEntities();

            DisplayModus = BaseModule.cstModusNormal;
        }


        /// <summary type="Initialize">
        /// Initialize Module
        /// </summary>
        public virtual void InitializeModule()
        {            
            ModuleID = new STModulesController().GetObjectIDByName(Name);
            
            CurrentModuleEntity.InitModuleEntity();

            GetFormatGroups();

            InitModuleToolbarEvents();
            BOSProgressBar.Start(BaseLocalizedResources.InitModuleMessage);            
            InitGridCotrolCriteria();
            InitializeScreens();
            BOSProgressBar.Close();

            //Init all GridControl in BOSList
            CurrentModuleEntity.InitGridControlInBOSList();

            if (CurrentModuleEntity.MainObject != null)
            {
                CurrentModuleEntity.CreateMainObjectRule();
                CurrentModuleEntity.SubcribeMainObjectEvent();
            }
        }        
        #endregion       

        /// <summary>
        /// Get format group list of table columns of the module
        /// </summary>
        public void GetFormatGroups()
        {
            STFieldFormatGroupsController objFieldFormatGroupsController = new STFieldFormatGroupsController();
            FormatGroups = objFieldFormatGroupsController.GetFormatGroupsByModuleID(ModuleID);            
        }

        #region Toolbar Manager Functions

        #region "Functions for toolbar action"

        private DataTable InitErrorTable()
        {
            DataTable tblError = new DataTable();
            tblError.TableName = "Error";

            DataColumn colErrorControl = new DataColumn();
            colErrorControl.ColumnName = "Control";
            colErrorControl.DataType = typeof(String);
            tblError.Columns.Add(colErrorControl);

            DataColumn colErrorMessage = new DataColumn();
            colErrorMessage.ColumnName = "Message";
            colErrorMessage.DataType = typeof(String);
            tblError.Columns.Add(colErrorMessage);

            DataColumn colPosition = new DataColumn();
            colPosition.ColumnName = "Position";
            colPosition.DataType = typeof(int);
            tblError.Columns.Add(colPosition);

            DataColumn colComment = new DataColumn();
            colComment.ColumnName = "Comment";
            colComment.DataType = typeof(String);
            tblError.Columns.Add(colComment);

            DataColumn[] primaryKeys = new DataColumn[3];
            primaryKeys[0] = colErrorControl;
            primaryKeys[1] = colPosition;
            primaryKeys[2] = colComment;

            tblError.PrimaryKey = primaryKeys;

            return tblError;

        }

        protected virtual DataTable CheckInvalidInputBeforeSave()
        {
            DataTable tblError = InitErrorTable();
            if (CurrentModuleEntity.MainObject != null)
            {
                foreach (BusinessRule r in CurrentModuleEntity.MainObject.BusinessRuleCollections)
                {

                    bool isRuleBroken = !r.ValidateRule(CurrentModuleEntity.MainObject);
                    if (isRuleBroken)
                    {
                        String strErrorMessage = r.Description;
                        String strMainObjectName = CurrentModuleEntity.MainObject.GetType().Name;
                        String strFieldDataSource = strMainObjectName.Substring(0, strMainObjectName.Length - 4);
                        //DDCan MOD [27/06/2012] [Only use admin user group in BOSStudio], START
                        //STFieldsInfo objSTFieldsInfo = new STFieldsController().GetFirstFieldByModuleIDAndUserGroupIDAndFieldDataSourceAndFieldDataMemberAndFieldTag(
                        //                                                        ModuleID, BOSApp.CurrentUserGroupInfo.ADUserGroupID,
                        //                                                        strFieldDataSource, r.PropertyName, BOSScreen.DataControl);
                        STFieldsInfo objSTFieldsInfo = new STFieldsController().GetFirstFieldByModuleIDAndUserGroupIDAndFieldDataSourceAndFieldDataMemberAndFieldTag(
                                                                                                        ModuleID, Contants.AdminUserGroupID,
                                                                                                        strFieldDataSource, r.PropertyName, BOSScreen.DataControl);
                        //DDCan MOD [27/06/2012] [Only use admin user group in BOSStudio], END
                        if (objSTFieldsInfo != null)
                        {
                            if (!String.IsNullOrEmpty(objSTFieldsInfo.STFieldError))
                                strErrorMessage = objSTFieldsInfo.STFieldError;
                            tblError.Rows.Add(new object[4] { objSTFieldsInfo.STFieldName, strErrorMessage, -1, String.Empty });
                        }

                    }
                }
            }

            return tblError;
        }

        protected virtual bool IsInvalidInput()
        {
            ErrorTable = InitErrorTable();

            CheckExtraInput();


            if (CurrentModuleEntity.MainObject != null)
            {
                BOSDbUtil dbUtil = new BOSDbUtil();
                ErrorTable.Rows.Clear();
                foreach (BusinessRule r in CurrentModuleEntity.MainObject.BusinessRuleCollections)
                {
                    String currentValue = dbUtil.GetPropertyValue((BusinessObject)CurrentModuleEntity.MainObject, r.PropertyName).ToString().Trim();
                    bool isRuleBroken = !r.ValidateRule(CurrentModuleEntity.MainObject);
                    if (isRuleBroken || string.IsNullOrEmpty(currentValue))
                    {
                        String strErrorMessage = r.Description;
                        String strMainObjectName = CurrentModuleEntity.MainObject.GetType().Name;
                        String strFieldDataSource = strMainObjectName.Substring(0, strMainObjectName.Length - 4);
                        //DDCan MOD [27/06/2012] [Only use admin user group in BOSStudio], START
                        //STFieldsInfo objSTFieldsInfo = new STFieldsController().GetFirstFieldByModuleIDAndUserGroupIDAndFieldDataSourceAndFieldDataMemberAndFieldTag(
                        //                                                        ModuleID, BOSApp.CurrentUserGroupInfo.ADUserGroupID,
                        //                                                        strFieldDataSource, r.PropertyName, BOSScreen.DataControl);
                        STFieldsInfo objSTFieldsInfo = new STFieldsController().GetFirstFieldByModuleIDAndUserGroupIDAndFieldDataSourceAndFieldDataMemberAndFieldTag(
                                                                                ModuleID, Contants.AdminUserGroupID,
                                                                                strFieldDataSource, r.PropertyName, BOSScreen.DataControl);
                        //DDCan MOD [27/06/2012] [Only use admin user group in BOSStudio], END
                        if (objSTFieldsInfo != null && Controls.Contains(objSTFieldsInfo.STFieldName))
                        {
                            String strCustomErrorMessage = dbUtil.GetPropertyStringValue(Controls[objSTFieldsInfo.STFieldName], "BOSError");
                            if (!String.IsNullOrEmpty(strCustomErrorMessage))
                                strErrorMessage = strCustomErrorMessage;
                            ErrorTable.Rows.Add(new object[4] { objSTFieldsInfo.STFieldName, strErrorMessage, -1, String.Empty });
                        }
                    }
                }
            }

            if (ErrorTable.Rows.Count > 0)
            {
                if (ErrorMessageScreen == null)
                {
                    ErrorMessageScreen = new guiErrorMessage(ErrorTable);
                    ErrorMessageScreen.Module = this;
                }
                else if (ErrorMessageScreen.IsDisposed)
                {
                    ErrorMessageScreen = new guiErrorMessage(ErrorTable);
                    ErrorMessageScreen.Module = this;
                }
                ErrorMessageScreen.Show();

                return true;
            }
            else
                return false;
        }

        private void CheckAllDefaultInputFromdatabase()
        {

        }

        protected virtual void CheckExtraInput()
        {

        }

        protected virtual bool IsInvalidInventory()
        {
            return CurrentModuleEntity.IsInvalidInventory();
        }

        protected void MoveNextErrorControl(Control ctrl)
        {
            String strControlName = ctrl.Name;
            if (ErrorTable.Rows.Count > 0)
            {
                DataRow row = ErrorTable.Rows.Find(new object[3] { strControlName, -1, String.Empty });
                if (row != null)
                {

                    int iErrorIndex = ErrorTable.Rows.IndexOf(row);
                    if (iErrorIndex < ErrorTable.Rows.Count - 1)
                    {
                        String strNextErrorControl = ErrorTable.Rows[iErrorIndex + 1][0].ToString();
                        Controls[strNextErrorControl].Focus();
                    }
                    else
                    {
                        String strNextErrorControl = ErrorTable.Rows[0][0].ToString();
                        Controls[strNextErrorControl].Focus();
                    }
                }
            }
        }

        /// <summary>
        /// Function will be called when user create new object in module
        /// </summary>
        public virtual void ActionNew()
        {
            Cursor.Current = Cursors.WaitCursor;

            //Call new delegate from Toolbar
            Toolbar.New();

            //Invalidate toolbar after new object
            ParentScreen.InvalidateToolbarAfterActionNew();

            //Save User Audit New action
            SaveUserAudit(cstUserAuditNew);
            
            //Invalidate controls
            InvalidateFieldGroupControls(BaseToolbar.ModusNew);
            if (ParentScreen.IsObjectListExpanded)
            {
                ParentScreen.CollapseObjectList();
            }

            String strMainTableName = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);

            Cursor.Current = Cursors.Default;
        }
        /// <summary>
        /// Function will be called when user save the edited object in module
        /// </summary>      
        public virtual int ActionSave()
        {
            int iObjectID = 0;
            if (!Toolbar.IsNullOrNoneAction())
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsInvalidInput())
                {

                    //Call Save delegate of Toolbar
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                    {
                        try
                        {
                            iObjectID = Toolbar.Save();
                            DoActionAfterSave(iObjectID);

                            if (iObjectID > 0)
                            {
                                //Invalidate controls
                                InvalidateFieldGroupControls(BaseToolbar.ModusNone);
                            }

                            scope.Complete();
                        }
                        catch (Exception ex)
                        {
                            scope.Dispose();
                            MessageBox.Show(ex.ToString(), "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                Cursor.Current = Cursors.Default;
            }

            //If module's owner exists, activate it
            if (Owner != null)
            {
                ModuleParentScreen ownerParentScreen = Owner.ParentScreen;
                Owner = null;
                ownerParentScreen.Activate();
            }

            return iObjectID;
        }

        public virtual void ActionPost()
        {

        }

        /// <summary>
        /// Complete transaction and update inventory
        /// </summary>
        public virtual bool ActionComplete()
        {
            if (!IsInvalidInventory())
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    try
                    {
                        CurrentModuleEntity.SetPropertyChangeEventLock(false);
                        bool isComplete = CurrentModuleEntity.CompleteTransaction();
                        scope.Complete();
                        return isComplete;
                    }
                    catch (Exception)
                    {
                        scope.Dispose();
                    }
                    finally
                    {
                        CurrentModuleEntity.SetPropertyChangeEventLock(true);
                    }
                }
            }
            return false;
        }


        public virtual void DoActionAfterSave(int iObjectID)
        {
            if (iObjectID > 0)
            {

                ParentScreen.Focus();

                //Invalidate Toolbar button after save
                ParentScreen.InvalidateToolbarAfterActionSave();

                //Save User Audit is Nothing
                SaveUserAudit(cstUserAuditNothing);

                //Set modus action of toolbar to none
                Toolbar.ModusAction = BaseToolbar.ModusNone;

                // Invalidate lookup edit columns to reflect all changes of lookup table
                String mainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
                String searchResultsControlName = String.Format("fld_dgc{0}", mainObjectTableName.Substring(0, mainObjectTableName.Length - 1));
                BOSSearchResultsGridControl searchResultsGridControl = Controls[searchResultsControlName] as BOSSearchResultsGridControl;
                if (searchResultsGridControl != null)
                {
                    searchResultsGridControl.InvalidateLookupEditColumns();
                    searchResultsGridControl.RefreshDataSource();
                }
            }
        }

        public virtual void ActionDuplicate()
        {
            if (Toolbar.ObjectCollection != null)
            {
                if (Toolbar.IsNullOrNoneAction() && Toolbar.CurrentObjectID > 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    BOSDbUtil dbUtil = new BOSDbUtil();

                    Toolbar.ModusAction = BaseToolbar.ModusNew;
                    
                    //Set number of main object to ERPModuleEntities.cstNewObjectText
                    String strPrimaryColumn = dbUtil.GetTablePrimaryColumn(BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject));
                    dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, strPrimaryColumn, 0);
                    dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, strPrimaryColumn.Substring(0, strPrimaryColumn.Length - 2) + "No", ERPModuleEntities.cstNewObjectText);

                    CurrentModuleEntity.DuplicateModuleObjectList();

                    //Invalidate toolbar after new object
                    ParentScreen.InvalidateToolbarAfterActionDuplicate();

                    //Activate Data Main Screen
                    ActivateDataMainScreen();

                    //Invalidate controls
                    InvalidateFieldGroupControls(BaseToolbar.ModusNew);

                    //Save User Audit New action
                    SaveUserAudit(cstUserAuditNew);

                    Cursor.Current = Cursors.Default;
                }
            }

        }     

        /// <summary>
        /// Function will be called when user edit object in module
        /// </summary>
        public virtual void ActionEdit()
        {
            if (ObjectIsEditingByOtherUser(this.Name, Toolbar.CurrentObjectID))
            {
                return;
            }

            //Call Edit delegate from Toolbar
            if (Toolbar.Edit())
            {
                //Invalidate toolbar after edit action
                ParentScreen.InvalidateToolbarAfterActionEdit();

                //Activate Main Screen
                if (ActiveScreen.IsSearchMainScreen())
                {
                    BOSERPScreen _guiDataMain = (BOSERPScreen)GetDataMainScreen(null, String.Empty);
                    ActiveScreen = _guiDataMain;
                }

                //Invalidate controls
                InvalidateFieldGroupControls(BaseToolbar.ModusEdit);
                if (ParentScreen.IsObjectListExpanded)
                {
                    ParentScreen.CollapseObjectList();
                }

                //Save User Audit
                SaveUserAudit(cstUserAuditEdit);
            }
            else
            {
                DevExpress.XtraBars.BarButtonItem barbtnEdit = ParentScreen.GetToolbarButton(BaseToolbar.ToolbarAction, BaseToolbar.ToolbarButtonEdit);
                barbtnEdit.Down = false;
            }
        }

        public void ActionEdit(String moduleName, int objectID)
        {
            BaseModuleERP module = BOSApp.ShowModule(moduleName);
            String tableName = BOSUtil.GetTableNameFromBusinessObject(module.CurrentModuleEntity.MainObject);
            String primaryKey = new BOSDbUtil().GetTablePrimaryColumn(tableName);
            if (module != null)
            {
                for (int i = 0; i < module.Toolbar.ObjectCollection.Tables[0].Rows.Count; i++)
                    if (objectID == Convert.ToInt32(module.Toolbar.ObjectCollection.Tables[0].Rows[i][primaryKey]))
                    {
                        module.Owner = this;
                        module.Toolbar.CurrentIndex = i;
                        module.FocusRowOfGridSearchResultByToolbarCurrentIndex();
                        module.Invalidate(objectID);
                        module.ActionEdit();
                        return;
                    }
            }
        }

        /// <summary>
        /// Function will be called when user delete object in module
        /// </summary>
        public virtual void ActionDelete()
        {
            if (Toolbar.CurrentObjectID > 0)
            {
                Toolbar.Delete();
                ParentScreen.InvalidateToolbarAfterActionDelete();
                BOSApp.MainScreen.OpenModulesToolStrip.Enabled = true;

                //Invalidate controls
                InvalidateFieldGroupControls(BaseToolbar.ModusNone);
            }

            //Save User Audit is Nothing
            SaveUserAudit(cstUserAuditNothing);
        }

        public virtual void ActionEditTemplate()
        {

            String strMainTable = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
            BaseBusinessController objBusinessController = BusinessControllerFactory.GetBusinessController(strMainTable + "Controller");
            CurrentModuleEntity.MainObject = (BusinessObject)objBusinessController.GetTemplateObject();
            if (CurrentModuleEntity.MainObject != null)
            {
                CurrentModuleEntity.UpdateMainObjectBindingSource();

                ParentScreen.InvalidateToolbarAfterActionEditTemplate();

                Toolbar.ModusAction = BaseToolbar.ModusEdit;
                ActivateDataMainScreen();
            }
            else
            {
                CurrentModuleEntity.MainObject = BusinessObjectFactory.GetBusinessObject(strMainTable + "Info");
                if (CurrentModuleEntity.MainObject != null)
                {
                    BOSDbUtil dbUtil = new BOSDbUtil();

                    dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, ERPModuleEntities.AAStatusColumn, BusinessObject.TemplateAAStatus);

                    String strColumnNoName = strMainTable.Substring(0, strMainTable.Length - 1) + "No";
                    dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, strColumnNoName, ERPModuleEntities.cstTemplateObjectText);
                    CurrentModuleEntity.UpdateMainObjectBindingSource();

                    ParentScreen.InvalidateToolbarAfterActionEditTemplate();

                    Toolbar.ModusAction = BaseToolbar.ModusNew;
                    ActivateDataMainScreen();
                }
            }

        }

        /// <summary>
        /// Function will be called when user cancel edit object in module
        /// </summary>
        public virtual void ActionCancel()
        {
            // cal Cancel delegate from toolbar
            Toolbar.Cancel();

            //Invalidate toolbar after Cancel 
            ParentScreen.InvalidateToolbarAfterActionCancel();

            //Save User Audit is Nothing
            SaveUserAudit(cstUserAuditNothing);

            //Invalidate controls
            InvalidateFieldGroupControls(BaseToolbar.ModusNone);

            //If module's owner exists, activate it
            if (Owner != null)
            {
                ModuleParentScreen ownerParentScreen = Owner.ParentScreen; 
                Owner = null;
                ownerParentScreen.Activate();
            }
        }

        /// <summary>
        /// Function will be called when invalidate module
        /// </summary>
        public virtual void ActionInvalidate()
        {
            Toolbar.Invalidate();
        }

        /// <summary>
        /// Function will be call when user go to previous object 
        /// </summary>
        public virtual void ActionGoPrevious()
        {
            //Toolbar.Previous();
            if (Toolbar.IsNullOrNoneAction())
            {
                if (Toolbar.ObjectCollectionLength > 0)
                {
                    if (Toolbar.CurrentIndex > 0)
                        Toolbar.CurrentIndex--;
                    Toolbar.Invalidate();
                }
            }
            else
                if (Toolbar.ModusAction != BaseToolbar.ModusNone)
                {
                    DialogResult dlgResult;
                    if (Toolbar.ModusAction == BaseToolbar.ModusNew)
                        dlgResult = MessageBox.Show("Do you want to save the new record?", "Save Record", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    else
                    {
                        BOSDbUtil dbUtil = new BOSDbUtil();
                        String strMainTableName = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
                        String strObjectNoColumnName = strMainTableName.Substring(0, strMainTableName.Length - 1) + "No";
                        String strObjectNo = dbUtil.GetPropertyValue(CurrentModuleEntity.MainObject, strObjectNoColumnName).ToString();

                        dlgResult = MessageBox.Show("Do you want to save the current record?", "Save Record", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    }
                    if (dlgResult == DialogResult.Yes || dlgResult == DialogResult.No)
                    {
                        if (dlgResult == DialogResult.Yes)
                            ActionSave();
                        else
                            ActionCancel();
                        if (Toolbar.ModusAction == BaseToolbar.ModusNone)
                        {
                            if (Toolbar.ObjectCollectionLength > 0)
                            {
                                if (Toolbar.CurrentIndex > 0)
                                    Toolbar.CurrentIndex--;
                                Toolbar.Invalidate();
                            }
                        }
                    }
                }

            if (Toolbar.ModusAction == BaseToolbar.ModusNone)
                FocusRowOfGridSearchResultByToolbarCurrentIndex();
        }

        public virtual void ActionGoFirst()
        {
            Toolbar.First();
            if (Toolbar.IsNullOrNoneAction())
            {
                FocusRowOfGridSearchResultByToolbarCurrentIndex();
            }

        }

        /// <summary>
        /// Function will be call when user go to next object
        /// </summary>
        public virtual void ActionGoNext()
        {
            if (Toolbar.IsNullOrNoneAction())
            {
                if (Toolbar.ObjectCollectionLength > 0)
                {
                    if (Toolbar.CurrentIndex < Toolbar.ObjectCollectionLength - 1)
                        Toolbar.CurrentIndex++;
                    Toolbar.Invalidate();
                }
            }
            else
                if (Toolbar.ModusAction != BaseToolbar.ModusNone)
                {
                    DialogResult dlgResult;
                    if (Toolbar.ModusAction == BaseToolbar.ModusNew)
                        dlgResult = MessageBox.Show("Do you want to save the new record?", "Save Record", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    else
                        dlgResult = MessageBox.Show("Do you want to save the current record?", "Save Record", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dlgResult == DialogResult.Yes || dlgResult == DialogResult.No)
                    {
                        if (dlgResult == DialogResult.Yes)
                            ActionSave();
                        else
                            ActionCancel();
                        if (Toolbar.ModusAction == BaseToolbar.ModusNone)
                        {
                            if (Toolbar.ObjectCollectionLength > 0)
                                if (Toolbar.CurrentIndex < Toolbar.ObjectCollectionLength - 1)
                                    Toolbar.CurrentIndex++;
                            Toolbar.Invalidate();
                        }
                    }
                }

            if (Toolbar.ModusAction == BaseToolbar.ModusNone)
                FocusRowOfGridSearchResultByToolbarCurrentIndex();
        }

        /// <summary>
        /// Function will be call when user Print.
        /// </summary>
        public virtual void ActionPrint()
        {
           
        }

        public virtual void ActionExport()
        {
            guiExcelExport _guiExceExport = new guiExcelExport();
            _guiExceExport.Module = this;
            _guiExceExport.ShowDialog();
        }

        public virtual void ActionImport()
        {
            guiExcelImport _guiExcelImport = new guiExcelImport();
            _guiExcelImport.Module = this;
            _guiExcelImport.ShowDialog();
        }


        public virtual void ActionShowError()
        {
            if (ErrorTable.Rows.Count > 0)
            {
                if (ErrorMessageScreen == null)
                {
                    ErrorMessageScreen = new guiErrorMessage(ErrorTable);
                    ErrorMessageScreen.Module = this;
                    ErrorMessageScreen.Show();
                }
                else if (ErrorMessageScreen.IsDisposed)
                {
                    ErrorMessageScreen = new guiErrorMessage(ErrorTable);
                    ErrorMessageScreen.Module = this;
                    ErrorMessageScreen.Show();
                }
                else
                    ErrorMessageScreen.Activate();
            }
        }

        /// <summary>
        /// Function will be call when user click User Audit
        /// </summary>
        public virtual void ActionUserAudit()
        {
            guiUserAudit _guiUserAudit = new guiUserAudit();
            _guiUserAudit.Show();
        }        
        #endregion

        #region "Delegate Functions for Toolbar Events"
        /// <summary type="Toolbar">
        /// Initialize the delegate functions and events for toolbar buttons
        /// </summary>
        /// <functiontype>Toolbar Function</functiontype>
        public void InitModuleToolbarEvents()
        {
            Toolbar = new BaseToolbar();
            BaseToolbar.InvalidateHandler InvalidateHandler = new BaseToolbar.InvalidateHandler(Invalidate);
            BaseToolbar.NewHandler NewHandler = new BaseToolbar.NewHandler(New);
            BaseToolbar.SaveHandler SaveHandler = new BaseToolbar.SaveHandler(Save);
            BaseToolbar.DeleteHandler DeleteHandler = new BaseToolbar.DeleteHandler(Delete);
            BaseToolbar.PrintHandler PrintHandler = new BaseToolbar.PrintHandler(Print);

            Toolbar.InvalidateEvent += InvalidateHandler;
            Toolbar.NewEvent += NewHandler;
            Toolbar.SaveEvent += SaveHandler;
            Toolbar.DeleteEvent += DeleteHandler;
            Toolbar.PrintEvent += PrintHandler;
        }

        #region Function For Invalidate action
        /// <summary type="Invalidate">
        /// Invalidate module
        /// </summary>
        /// <param name="iObjectID">Current Object ID</param>        
        public virtual void Invalidate(int iObjectID)
        {
            CurrentModuleEntity.Invalidate(iObjectID);
            InvalidateAllModuleGridControls();

            //ParentScreen.Text = ParentScreen.GetParentScreenTextByLanguage(BOSApp.CurrentLang) + " - " + MessageInfo.ShowInfoForCurrentObject(this.Name, BOSApp.CurrentLang, strAANumberString);

            if (CurrentModuleEntity.MainObject != null)
            {
                BOSDbUtil dbUtil = new BOSDbUtil();
                String tablename = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
                string number = dbUtil.GetPropertyStringValue(CurrentModuleEntity.MainObject, tablename.Substring(0, tablename.Length - 1) + "No");
                BOSApp.MainScreen.nameItem.Caption = number;
            }
        }

        /// <summary>
        /// Invalidate All Grid Controls From Module
        /// </summary>
        public virtual void InvalidateAllModuleGridControls()
        {
            DataSet dsGridControls = new STFieldsController().GetFieldByModuleNameAndUserGroupIDAndFieldType(this.Name, BOSApp.CurrentUserGroupInfo.ADUserGroupID, "BOSGridControl");
            if (dsGridControls.Tables.Count > 0)
            {
                foreach (DataRow rowGridControl in dsGridControls.Tables[0].Rows)
                {
                    STFieldsInfo objSTFieldsInfo = (STFieldsInfo)new STFieldsController().GetObjectFromDataRow(rowGridControl);
                    String strGridControlName = objSTFieldsInfo.STFieldName;
                    int iFieldID = objSTFieldsInfo.STFieldID;
                    String strMainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
                    if (objSTFieldsInfo.STFieldTag != BOSScreen.SearchResultControl)
                    {

                        if (!String.IsNullOrEmpty(objSTFieldsInfo.STFieldDataSource))
                        {
                            BOSGridControl BOSGridControl = BOSGridControl.Instance(objSTFieldsInfo.STFieldDataSource, this.Name);
                            BOSGridControl.Screen = (BOSERPScreen)GetScreenOfControl(strGridControlName);
                            if (BOSGridControl.Screen != null)
                            {
                                DevExpress.XtraGrid.GridControl gridControl = Controls[strGridControlName] as DevExpress.XtraGrid.GridControl;
                                try
                                {
                                    gridControl.RefreshDataSource();
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    gridControl.RefreshDataSource();
                                }
                            }
                        }

                    }


                }
            }

            dsGridControls.Dispose();
        }

        #endregion

        #region Functions for New Action

        /// <summary type="New">
        /// New object in module
        /// </summary>
        public virtual void New()
        {
            CurrentModuleEntity.New();

            BOSERPScreen _guiDataMainScreen = GetDataMainScreen(null, String.Empty);
            if (_guiDataMainScreen != null)
            {
                ActiveScreen = _guiDataMainScreen;
            }
        }
        #endregion

        #region Function For Save Action

        public virtual int Save()
        {
            int iObjectID = 0;
            bool isContinue = true;

            BOSDbUtil dbUtil = new BOSDbUtil();

            BaseBusinessController objCurrentObjectController = BusinessControllerFactory.GetBusinessController(CurrentModuleEntity.MainObject.GetType().Name.Substring(0, CurrentModuleEntity.MainObject.GetType().Name.Length - 4) + "Controller");
            GENumberingInfo objNumberingInfo = (GENumberingInfo)new GENumberingController().GetObjectByName(this.Name);

            String strMainTable = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
            String strMainTablePrimaryColumn = strMainTable.Substring(0, strMainTable.Length - 1) + "ID";
            String strMainTableNoColumn = strMainTablePrimaryColumn.Substring(0, strMainTablePrimaryColumn.Length - 2) + "No";
            String strObjectNo = dbUtil.GetPropertyStringValue(CurrentModuleEntity.MainObject, strMainTableNoColumn);

            if (!String.IsNullOrEmpty(strObjectNo))
            {
                if (this.Toolbar.ModusAction == BaseToolbar.ModusNew)
                {
                    if (objCurrentObjectController.IsExist(strObjectNo))
                    {
                        MessageBox.Show(BaseLocalizedResources.NumberAlreadyExistsMessage, "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isContinue = false;
                    }
                }
                else if (this.Toolbar.ModusAction == BaseToolbar.ModusEdit)
                {
                    BusinessObject objExistingMainObject = (BusinessObject)objCurrentObjectController.GetObjectByNo(strObjectNo);
                    if (objExistingMainObject != null)
                    {
                        int objectID = dbUtil.GetPropertyIntValue(CurrentModuleEntity.MainObject, strMainTablePrimaryColumn);
                        int existingObjectID = dbUtil.GetPropertyIntValue(objExistingMainObject, strMainTablePrimaryColumn);                        
                        if (existingObjectID != objectID)
                        {
                            MessageBox.Show(BaseLocalizedResources.NumberAlreadyExistsMessage, "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            isContinue = false;
                        }
                    }
                }
            }

            if (isContinue)
            {
                iObjectID = CurrentModuleEntity.SaveMainObject();

                if (iObjectID > 0)
                {
                    //Save Module Objects
                    CurrentModuleEntity.SaveModuleObjects();

                    //Save Object History
                    if (Toolbar.ModusAction == BaseToolbar.ModusNew)
                        SaveObjectHistory(cstObjectHistoryActionNew, iObjectID);
                    else
                        SaveObjectHistory(cstObjectHistoryActionChange, iObjectID);
                }

                InvalidateSearchResultsControl(null, String.Empty);

                return iObjectID;
            }
            else
                return 0;
        }

        #endregion

        #region Function for Delete action
        /// <summary type="Delete">
        /// Delete object in module
        /// </summary>
        /// <param name="iObjectID">Object ID will be deleted</param>
        /// <returns>true if delete successfull, otherwise return false</returns>
        public virtual bool Delete(int iObjectID)
        {
            bool result = false;

            if (MessageBox.Show(BaseLocalizedResources.ConfirmDeleteObjectMessage, "#Message#", MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                == DialogResult.Yes)
            {
                //Save Object History with action delete 
                SaveObjectHistory(cstObjectHistoryActionDelete, Toolbar.CurrentObjectID);

                //Delete object from CurrentModuleEntity
                CurrentModuleEntity.Delete(iObjectID);

                Search();
                result = true;
            }
            return result;
        }
        #endregion

        /// <summary type="Print">
        /// Print Module
        /// </summary>
        public virtual void Print()
        {

        }
        #endregion
        #endregion

        #region Module Functions
        #region Virtual Functions

        #region Init Screen functions
        private static int NummerComparer(STScreensInfo i1, STScreensInfo i2)
        {
            return String.Compare(i1.STScreenNumber, i2.STScreenNumber) * -1;
        }
        /// <summary type="Initialize">
        /// Initialize all screens belong to module
        /// </summary>        
        public virtual void InitializeScreens()
        {                       
            STScreensController objSTScreensController = new STScreensController();
            List<STScreensInfo> lstScreenInfo = new List<STScreensInfo>();

            DataSet dsScreens = objSTScreensController.GetScreenByModuleNameAndUserGroupName(this.Name, BOSApp.cstUserGroupAdmin);
            if (dsScreens.Tables.Count > 0)
            {
                foreach (DataRow row in dsScreens.Tables[0].Rows)
                {
                    STScreensInfo objSTScreensInfo = (STScreensInfo)objSTScreensController.GetObjectFromDataRow(row);
                    if (objSTScreensInfo.STScreenVisible)
                    {
                        if (!objSTScreensInfo.STScreenNumber.StartsWith("DS"))
                        {
                            lstScreenInfo.Add(objSTScreensInfo);
                        }
                    }
                }

                //Add all screens to the screen list of module, make them available for customization
                foreach (STScreensInfo objSTScreensInfo in lstScreenInfo)
                {
                    BOSERPScreen scr = BOSERPScreenFactory.GetScreen(objSTScreensInfo.STScreenNumber, this.Name);
                    scr.ScreenID = objSTScreensInfo.STScreenID;
                    scr.Name = objSTScreensInfo.STScreenName;
                    scr.Module = this;
                    scr.Text = objSTScreensInfo.STScreenText;
                    Screens.Add(scr);
                }
                
                //Initialize and customize all screens
                for (int i = 0; i < Screens.Count; i++)
                {
                    BOSERPScreen screen = (BOSERPScreen)Screens[i];
                    screen.InitializeScreen(lstScreenInfo[i]);
                }

                //Add controls of all screens to parent screen
                foreach (BOSERPScreen screen in Screens)
                    screen.AddControlsToParentScreen();
            }
            dsScreens.Dispose();

            //Save User Audits
            SaveUserAudit(cstUserAuditNothing);            
        }      

        /// <summary type="Initialize">
        /// Initialize Screen by Screen Name and Screen Number
        /// </summary>        
        /// <param name="objSTScreensInfo"></param>        
        /// <returns></returns>        
        public BOSScreen InitializeScreen(STScreensInfo objSTScreensInfo)
        {
            BOSERPScreen scr = BOSERPScreenFactory.GetScreen(objSTScreensInfo.STScreenNumber, this.Name);
            scr.Name = objSTScreensInfo.STScreenName;
            scr.Module = this;
            scr.Text = objSTScreensInfo.STScreenText;
            scr.InitializeScreen(objSTScreensInfo);
            return scr;
        }

        public BOSScreen InitializeScreen(String strScreenName, String strScreenNumber)
        {
            BOSERPScreen scr = BOSERPScreenFactory.GetScreen(strScreenNumber, this.Name);
            scr.Name = strScreenName;
            scr.Module = this;

            scr.InitializeScreen();
            return scr;
        }

        public BOSScreen InitializeScreen(String strScreenNumber)
        {
            if (ModuleID > 0 && BOSApp.CurrentUserGroupInfo.ADUserGroupID > 0)
            {
                STScreensController objSTScreensController = new STScreensController();
                STScreensInfo objSTScreensInfo = objSTScreensController.GetSTScreensByModuleIDAndUserGroupIDAndScreenNumber(ModuleID, BOSApp.CurrentUserGroupInfo.ADUserGroupID, strScreenNumber);
                if (objSTScreensInfo != null)
                    return InitializeScreen(objSTScreensInfo.STScreenName, strScreenNumber);
            }
            return null;
        }

        #endregion

        #region Search and Invalidate after search functions
        public virtual void Search()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;                
                //Get Controller object of Main Object
                String strMainObjectControllerName = BOSUtil.GetBusinessControllerNameFromBusinessObject(CurrentModuleEntity.MainObject);
                String strMainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
                BaseBusinessController objCurrentObjectController = BusinessControllerFactory.GetBusinessController(strMainObjectControllerName);
                Cursor.Current = Cursors.WaitCursor;

                String strSearchQuery = GenerateSearchQuery(strMainObjectTableName);
                DataSet ds = objCurrentObjectController.GetDataSet(strSearchQuery);
                Toolbar.SetToolbar(ds);
                InvalidateAfterSearch(null, String.Empty);
                Cursor.Current = Cursors.Default;

                //Create search criteria
                if (!String.IsNullOrEmpty(strSearchQuery))
                {
                    if (!String.IsNullOrEmpty(SearchScreen.CriteriaName.Text))
                    {
                        ADCriteriasController objCriteriasController = new ADCriteriasController();
                        ADCriteriasInfo objADCriteriasInfo = new ADCriteriasInfo();
                        objADCriteriasInfo.AACreatedUser = BOSApp.CurrentUser;
                        objADCriteriasInfo.ADCriteriaName = SearchScreen.CriteriaName.Text;
                        objADCriteriasInfo.FK_STModuleID = ModuleID;
                        objADCriteriasInfo.ADCriteriaQueryString = strSearchQuery;
                        objADCriteriasInfo.FK_ADUserID = BOSApp.CurrentUsersInfo.ADUserID;
                        objADCriteriasInfo.ADCriteriaDesc = SearchScreen.CriteriaDescription.Text;
                        objCriteriasController.CreateObject(objADCriteriasInfo);
                        ParentScreen.GridModuleUserCriteria.InitGridControlDataSource();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
        }       

        /// <summary type="Invalidate">
        /// Invalidate module after search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="strEventName"></param>
        /// <BOSparam name="SearchResultsControlName" type="String"></BOSparam>
        public virtual void InvalidateAfterSearch(object sender, String strEventName)
        {
            Cursor.Current = Cursors.WaitCursor;
            //Get Main Object Table Name
            String strMainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);

            String strSearchResultsControlName = String.Format("fld_dgc{0}", strMainObjectTableName.Substring(0, strMainObjectTableName.Length - 1));

            DevExpress.XtraGrid.GridControl gridControl = Controls[strSearchResultsControlName] as DevExpress.XtraGrid.GridControl;

            if (Toolbar.ObjectCollectionLength > 0 && !Toolbar.IsNewAction())
                Invalidate(Toolbar.CurrentObjectID);


            BOSSearchResultsGridControl.BindingSearchResultGridControl((DevExpress.XtraGrid.GridControl)gridControl, Toolbar.ObjectCollection);

            Cursor.Current = Cursors.Default;
        }

        /// <summary type="Invalidate">
        /// Invalidate Search Results Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="strEventName"></param>        
        /// <BOSparam name="SearchResultsControlName" type="String"></BOSparam>
        public virtual void InvalidateSearchResultsControl(object sender, String strEventName)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                String strMainTableName = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
                String strSearchResultsControlName = "fld_dgc" + strMainTableName.Substring(0, strMainTableName.Length - 1);
                BaseBusinessController objMainObjectController = BusinessControllerFactory.GetBusinessController(strMainTableName + "Controller");

                if (Controls.Contains(strSearchResultsControlName))
                {

                    DevExpress.XtraGrid.GridControl gridControl = Controls[strSearchResultsControlName] as DevExpress.XtraGrid.GridControl;
                    DevExpress.XtraGrid.Views.Grid.GridView gridView = gridControl.Views[0] as DevExpress.XtraGrid.Views.Grid.GridView;
                    BOSDbUtil dbUtil = new BOSDbUtil();
                    PropertyInfo[] properties;
                    DataRow newRow;
                    String strMainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
                    int iObjectID = Convert.ToInt32(dbUtil.GetPropertyValue(CurrentModuleEntity.MainObject, SqlDatabaseHelper.GetPrimaryKeyColumn(strMainObjectTableName)));

                    if (Toolbar.ObjectCollection == null)
                    {
                        DataSet ds = objMainObjectController.GetDataSetByID(iObjectID);
                        Toolbar.SetToolbar(ds);
                        BOSSearchResultsGridControl.BindingSearchResultGridControl(gridControl, Toolbar.ObjectCollection);
                    }
                    else
                    {
                        //if Toolbar.ModusAction is new, add new object to object collection of toolbar
                        if (Toolbar.ModusAction == BaseToolbar.ModusNew)
                        {
                            newRow = Toolbar.ObjectCollection.Tables[0].NewRow();
                            newRow = objMainObjectController.GetDataRowFromBusinessObject(newRow, CurrentModuleEntity.MainObject);
                            Toolbar.ObjectCollection.Tables[0].Rows.Add(newRow);
                            Toolbar.CurrentIndex = Toolbar.ObjectCollection.Tables[0].Rows.Count - 1;
                        }
                        else
                        {
                            //Update object in object collection of toolbar
                            properties = CurrentModuleEntity.MainObject.GetType().GetProperties();
                            int iCurrIndex = Toolbar.CurrentIndex;
                            for (int i = 0; i < properties.Length; i++)
                                if (dbUtil.ColumnIsExist(strMainObjectTableName, properties[i].Name))
                                    Toolbar.ObjectCollection.Tables[0].Rows[iCurrIndex][properties[i].Name] = properties[i].GetValue(CurrentModuleEntity.MainObject, null);
                        }
                    }


                    gridView.RefreshData();
                    gridView.FocusedRowHandle = gridView.GetRowHandle(Toolbar.CurrentIndex);
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion      
        #endregion

        #region Public Functions


        #region Funtions to show,activate,close,hibernate module
        /// <summary type="Show">
        /// Show Module
        /// </summary>        
        public virtual void Show()
        {
            //First,show parent screen      
            BOSProgressBar.Start(BaseLocalizedResources.InitModuleMessage);
            ParentScreen.ShowInTaskbar = false;

            ParentScreen.ModuleParentScreen_Init();
            if (BOSApp.OpenModules.ContainsKey(BOSApp.CurrentModule))
                ((BaseModuleERP)BOSApp.OpenModules[BOSApp.CurrentModule]).ParentScreen.WindowState = FormWindowState.Minimized;
            ParentScreen.Show();
            ParentScreen.Focus();
            
            //Invalidate module for additional adjustments
            InvalidateModule();

            ParentScreen.SearchContainer.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;

            //Hide inventory container, just show with transaction module            
            ParentScreen.InventoryContainer.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;            

            //Show search result panel
            ParentScreen.ShowSearchResultsPanel();
            if (ParentScreen.IsExistsGridSearchResult() && Toolbar.CurrentObjectID <= 0)
                Search();
            BOSProgressBar.Close();
        }

        public void ActivateDataMainScreen()
        {
            BOSERPScreen _guiDataMainScreen = (BOSERPScreen)GetDataMainScreen();
            ActivateScreen(_guiDataMainScreen.ScreenNumber);
        }

        /// <summary>
        /// Activate a screen
        /// </summary>
        /// <param name="screenNumber">Screen number</param>
        public void ActivateScreen(string screenNumber)
        {
            XtraTabPage page = ParentScreen.ScreenContainer.TabPages.Where(p => p.Name == screenNumber).FirstOrDefault();
            if (page != null)
            {
                ParentScreen.ScreenContainer.SelectedTabPage = page;
                BOSScreen screen = Screens.Where(s => s.ScreenNumber == screenNumber).FirstOrDefault();
                if (screen != null)
                {
                    ActiveScreen = screen;
                    ((BOSERPScreen)ActiveScreen).Activate();
                }
            }
        }

        public override void ShowScreen(BOSScreen scr, bool bIsChild)
        {
            try
            {   
                //Does not show screen if it has no permission or its sort order =-1
                BOSERPScreen screen = (BOSERPScreen)scr;
                if (screen.ScreenInfo != null)
                {
                    if (screen.ScreenInfo.STScreenSortOrder < 0)
                        return;
                }
                Cursor.Current = Cursors.WaitCursor;
                if (bIsChild)
                    screen.MdiParent = ParentScreen;
                if (screen.IsDataSubScreen())
                {
                    if (screen.ScreenInfo != null)
                    {
                        screen.SizeGripStyle = SizeGripStyle.Hide;
                        screen.MinimizeBox = false;
                        screen.MaximizeBox = false;
                        screen.StartPosition = FormStartPosition.Manual;
                        screen.Size = new Size(screen.ScreenInfo.STScreenSizeWidth, screen.ScreenInfo.STScreenSizeHeight);
                        screen.Location = new Point(screen.ScreenInfo.STScreenLocationX, screen.ScreenInfo.STScreenLocationY);
                        screen.TopMost = screen.ScreenInfo.STScreenTopMost;
                        if (screen.ScreenInfo.STScreenShowModal == true)
                            screen.ShowDialog();
                        else
                            screen.Show();
                    }
                }
                else
                    screen.Show();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception e)
            {
                MessageBox.Show(this.GetType().FullName + ".ShowScreen:" + e.Message);
            }
        }

        /// <summary type="Invalidate">
        /// Invalidate Module in modus Normal
        /// </summary>        
        /// <BOSparam name="SearchResultsControlName" type="String"></BOSparam>
        public virtual void InvalidateModule()
        {            
            BOSApp.UpdateOpenedModule(this);
            ModuleAfterLoaded();
        }


        /// <summary type="Close">
        /// Close Module.Close all screens in module
        /// </summary>
        public void Close()
        {
            //Remove Module in OpenModules
            BOSApp.MainScreen.OpenModulesToolStrip.Items.RemoveByKey(Name);            
            BOSApp.RemoveOpenedModule(Name);
            if (BOSApp.CurrentUser != null)
                DeleteUserAudit(Name);

            //Active last open modules
            if (BOSApp.MainScreen.OpenModulesToolStrip.Items.Count > 0)
            {
                int index = BOSApp.MainScreen.OpenModulesToolStrip.Items.Count - 1;
                String strModuleName = BOSApp.MainScreen.OpenModulesToolStrip.Items[index].Name;
                BOSApp.ShowModule(strModuleName);
            }            
        }

        /// <summary type="Show">
        /// Show Sub Screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="strEventName"></param>
        /// <BOSparam name="DataSubScreenName" type="String"></BOSparam>
        public void ShowSubScreen(object sender, String strEventName)
        {
            if (Toolbar.CurrentObjectID > 0)
            {
                String strSubScreenNumber = GetBOSParameterValueFromFunctionNameAndParameterName(
                                        sender, strEventName,
                                        "ShowSubScreen", "DataSubScreenName");

                BOSERPScreen scr = (BOSERPScreen)GetScreenByScreenNumber(strSubScreenNumber);
                if (scr != null)
                {
                    if (scr.IsDisposed)
                    {
                        scr = (BOSERPScreen)scr.Recreate();
                        scr.ControlBox = true;
                        ShowScreen(scr, false);
                    }
                    else
                    {

                        scr.ControlBox = true;
                        ShowScreen(scr, false);
                    }
                }
                else
                {
                    BOSProgressBar.Start(BaseLocalizedResources.Loading);
                    scr = (BOSERPScreen)InitializeScreen(strSubScreenNumber);
                    Screens.Add(scr);
                    BOSProgressBar.Close();
                    scr.ControlBox = true;
                    ShowScreen(scr, false);
                }
            }
            else
            {
                MessageBox.Show(BaseLocalizedResources.ChooseObjectToEditMessage, "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        /// <summary type="Show">
        /// Show Column Selector
        /// </summary>        
        /// <param name="ctrlSearchResults">Search Results Control to show Column</param>
        /// <param name="showForm"></param>
        public void ShowColumnSelector(DevExpress.XtraGrid.GridControl ctrlSearchResults, bool showForm)
        {
            if (showForm)
            {
                ((DevExpress.XtraGrid.Views.Grid.GridView)ctrlSearchResults.ViewCollection[0]).ColumnsCustomization();
            }
            else
            {
                ((DevExpress.XtraGrid.Views.Grid.GridView)ctrlSearchResults.ViewCollection[0]).DestroyCustomization();
            }
        }

        public void GoNextScreen()
        {
            int index = Screens.IndexOf(ActiveScreen);
            if (index >= 0)
            {
                index++;
                if (index >= Screens.Count)
                    index = 0;
                //Just active screen when screen is not data sub screen
                if (Toolbar.IsNullOrNoneAction())
                {
                    while (Screens[index].IsDataSubScreen())
                    {
                        index++;
                        if (index >= Screens.Count)
                            index = 0;
                    }
                }
                else
                {
                    while (Screens[index].IsDataSubScreen() || Screens[index].IsSearchMainScreen())
                    {
                        index++;
                        if (index >= Screens.Count)
                            index = 0;
                    }
                }
                ActiveScreen = Screens[index];
            }

        }

        private int GetIndexOfCurrentScreen(String strScreenNumber, String[] arrScreenKeys)
        {
            for (int i = 0; i < arrScreenKeys.Length; i++)
            {
                if (arrScreenKeys[i] == strScreenNumber)
                {
                    return i;
                }
            }
            return -1;
        }

        public virtual void SetDisplaySearchScreen(bool bDisplay)
        {
            BOSERPScreen searchScreen = (BOSERPScreen)GetSearchMainScreen();
            if (searchScreen != null)
                searchScreen.Visible = bDisplay;
        }

        #endregion

        #region Function for Set,Reset,Save Module Search Fields
        public void ResetSearchObject()
        {
            try
            {
                BOSDbUtil dbUtil = new BOSDbUtil();
                foreach (Control ctrl in SearchScreen.CriteriaSection.Controls)
                {
                    string dataSource = dbUtil.GetPropertyStringValue(ctrl, BOSERPScreen.cstDataSourcePropertyName);
                    string dataMember = dbUtil.GetPropertyStringValue(ctrl, BOSERPScreen.cstDataMemberPropertyName);
                    if (dataMember == "TopResults")
                    {
                        ctrl.Text = BOSApp.cstTopResults.ToString();
                    }
                    else
                    {
                        if (ctrl.Enabled)
                        {
                            if (ctrl is DevExpress.XtraEditors.DateEdit)
                            {
                                if (ctrl.Name.Contains("SearchFrom"))
                                    (ctrl as DevExpress.XtraEditors.DateEdit).DateTime = BOSUtil.GetYearBeginDate();
                                else if (ctrl.Name.Contains("SearchTo"))
                                    (ctrl as DevExpress.XtraEditors.DateEdit).DateTime = BOSUtil.GetYearEndDate();
                                else
                                    (ctrl as DevExpress.XtraEditors.DateEdit).EditValue = string.Empty;
                            }
                            else if (ctrl is DevExpress.XtraEditors.LookUpEdit)
                            {
                                String strDataType = dbUtil.GetColumnDataType(dataSource, dataMember);
                                if (strDataType == "int" || strDataType == "float")
                                    (ctrl as DevExpress.XtraEditors.LookUpEdit).EditValue = 0;
                                else
                                    (ctrl as DevExpress.XtraEditors.LookUpEdit).EditValue = String.Empty;
                            }
                            else if (ctrl is DevExpress.XtraEditors.TextEdit)
                                (ctrl as DevExpress.XtraEditors.TextEdit).EditValue = String.Empty;
                            else if (ctrl is DevExpress.XtraEditors.ComboBoxEdit)
                                (ctrl as DevExpress.XtraEditors.ComboBoxEdit).SelectedIndex = -1;
                        }
                    }
                }

                //Reset Filter on Grid Search Result Control
                String strMainTable = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
                //DDCan MOD [27/06/2012] [Only use admin user group in BOSStudio], START
                //STFieldsInfo objGridSearchResultFieldsInfo = (STFieldsInfo)new STFieldsController().GetFirstFieldByModuleIDAndUserGroupIDAndFieldDataSourceAndFieldTypeAndFieldTag(
                //                                                        ModuleID, BOSApp.CurrentUserGroupInfo.ADUserGroupID,
                //                                                        strMainTable, "BOSGridControl", BOSERPScreen.SearchControl);
                STFieldsInfo objGridSearchResultFieldsInfo = (STFieldsInfo)new STFieldsController().GetFirstFieldByModuleIDAndUserGroupIDAndFieldDataSourceAndFieldTypeAndFieldTag(
                                                                                        ModuleID, Contants.AdminUserGroupID,
                                                                                        strMainTable, "BOSGridControl", BOSERPScreen.SearchControl);
                //DDCan MOD [27/06/2012] [Only use admin user group in BOSStudio], END
                if (objGridSearchResultFieldsInfo != null)
                {
                    DevExpress.XtraGrid.GridControl gridControl = Controls[objGridSearchResultFieldsInfo.STFieldName] as DevExpress.XtraGrid.GridControl;
                    DevExpress.XtraGrid.Views.Grid.GridView gridView = gridControl.Views[0] as DevExpress.XtraGrid.Views.Grid.GridView;
                    for (int i = 0; i < gridView.VisibleColumns.Count; i++)
                    {
                        String strFieldName = gridView.VisibleColumns[i].FieldName;
                        gridView.Columns[strFieldName].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        #region FuntionsModuleAfterLoaded
        public virtual void ModuleAfterLoaded()
        {
            //Add extra controls for data screens such as asterisk, search button...
            foreach (BOSERPScreen scr in Screens)
                if (scr.IsDataMainScreen())
                {
                    foreach (DevExpress.XtraTab.XtraTabPage page in ParentScreen.ScreenContainer.TabPages)
                        if (page.Name == scr.ScreenNumber)
                        {
                            scr.AddExtraControls(page.Controls);
                            break;
                        }
                }
        }
        #endregion
        #endregion

        #region Functions to Get Screen of Module

        /// <summary>
        /// Get Data Main Screen
        /// </summary>
        /// <returns></returns>
        public BOSScreen GetDataMainScreen()
        {
            BOSERPScreen _guiDataMainScreen = new BOSERPScreen();
            for (int i = 0; i < Screens.Count; i++)
            {
                String strScreenNumber = Screens[i].ScreenNumber;
                if (strScreenNumber.StartsWith("DM") && strScreenNumber.EndsWith("100"))
                {
                    _guiDataMainScreen = (BOSERPScreen)Screens[i];
                    break;
                }
            }
            return _guiDataMainScreen;
        }
        public void SetScreentoForegroundByScreenName(String strScreenName)
        {

            BOSERPScreen _guiDataMainScreen = new BOSERPScreen();
            for (int i = 0; i < Screens.Count; i++)
            {
                if (strScreenName == Screens[i].Name)
                {

                    BOSERPScreen _guiScreen = (BOSERPScreen)Screens[i];
                    _guiScreen.Activate();
                }
            }
        }

        /// <summary type="GetScreen">
        /// Get Main Search Screen of Module
        /// </summary>        
        /// <returns>Main Search Screen</returns>
        public BOSScreen GetSearchMainScreen()
        {
            BOSScreen _guiSearchMainScreen = new BOSERPScreen();
            for (int i = 0; i < Screens.Count; i++)
            {
                String strScreenNumber = Screens[i].ScreenNumber;
                if (strScreenNumber.StartsWith("SM"))
                {
                    _guiSearchMainScreen = (BOSERPScreen)Screens[i];
                    break;
                }
            }
            return _guiSearchMainScreen;
        }

        /// <summary type="GetScreen">
        /// Get Data Main Screen of Module
        /// </summary>
        /// <BOSparam name="DataMainScreenNumber" type="String"></BOSparam>
        /// <returns>Data Main Screen</returns>
        public BOSERPScreen GetDataMainScreen(object sender, String strEventName)
        {
            String strDataMainScreenNumber = GetBOSParameterValueFromFunctionNameAndParameterName(
                                                sender, strEventName,
                                                "GetDataMainScreen", "DataMainScreenNumber");
            BOSERPScreen scr = (BOSERPScreen)GetScreenByScreenNumber(strDataMainScreenNumber);
            if (scr == null)
            {
                for (int i = 0; i < Screens.Count; i++)
                {
                    String strScreenNumber = Screens[i].ScreenNumber;
                    if (strScreenNumber.StartsWith("DM") && strScreenNumber.EndsWith("100"))
                        scr = (BOSERPScreen)Screens[i];
                }
            }
            return (BOSERPScreen)scr;

        }

        /// <summary type="GetScreen">
        /// Get Data Sub Screen of module
        /// </summary>
        /// <returns>Data Sub Screen</returns>
        public BOSScreen GetDataSubScreen()
        {
            BOSERPScreen _guiDataSubScreen = new BOSERPScreen();
            for (int i = 0; i < Screens.Count; i++)
            {

                if (Screens[i].ScreenNumber.StartsWith("DS"))
                {
                    _guiDataSubScreen = (BOSERPScreen)Screens[i];
                    break;
                }
            }
            return _guiDataSubScreen;
        }

        /// <summary type="GetScreen">
        /// Get Search Results Screen of Module
        /// </summary>
        /// <returns>Search Result Screen</returns>
        public BOSScreen GetSearchResultScreen()
        {
            BOSERPScreen _guiSearchResultsScreen = new BOSERPScreen();
            for (int i = 0; i < Screens.Count; i++)
            {
                if (Screens[i].ScreenNumber.StartsWith("SR"))
                {
                    _guiSearchResultsScreen = (BOSERPScreen)Screens[i];
                    break;
                }
            }
            return _guiSearchResultsScreen;
        }


        /// <summary type="GetScreen">
        /// Get Screen of Control
        /// </summary>
        /// <param name="strControlName"></param>
        /// <returns></returns>
        public BOSScreen GetScreenOfControl(String strControlName)
        {
            Control ctrl = GetControlByName(strControlName);
            if (ctrl != null)
            {
                if (ctrl.FindForm() != null)
                {
                    String strScreenName = ctrl.FindForm().Name;
                    STScreensInfo objSTScreensInfo = new STScreensController().GetScreenByModuleNameAndUserGroupNameAndScreenName(Name, BOSApp.CurrentUserGroupInfo.ADUserGroupName, strScreenName);
                    if (objSTScreensInfo != null)
                    {
                        BOSScreen scr = GetScreenByScreenNumber(objSTScreensInfo.STScreenNumber);
                        return scr;
                    }
                    else
                        return null;
                }
                else
                    return null;

            }
            else
                return null;
        }
        #endregion

        #region Functions for Control of Module
        public void FocusRowOfGridSearchResultByToolbarCurrentIndex()
        {
            BOSScreen screen = GetSearchMainScreen();
            if (screen != null)
            {
                STFieldsInfo objFieldsInfo = screen.Fields.Where(f => f.Value.STFieldType == "BOSSearchResultGridControl" && f.Value.STFieldTag == "SR").FirstOrDefault().Value;
                if (objFieldsInfo != null && Controls.Contains(objFieldsInfo.STFieldName))
                {
                    GridControl gridControl = (GridControl)Controls[objFieldsInfo.STFieldName];
                    GridView gridView = (GridView)gridControl.MainView;
                    gridView.FocusedRowHandle = gridView.GetRowHandle(Toolbar.CurrentIndex);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="strEventName"></param>
        /// <BOSparam name="DisplaySearchResultsControlName" type="String"></BOSparam>
        public void ShowSearchResults(object sender, String strEventName)
        {
            String strControlName = GetBOSParameterValueFromFunctionNameAndParameterName(
                                        sender, strEventName,
                                        "ShowSearchResults", "DisplaySearchResultsControlName");
            if (Controls[strControlName] != null)
                Controls[strControlName].Text = this.Toolbar.ObjectCollectionLength.ToString();
        }


        public void RefreshGridControl(String strGridControlDataSource)
        {
            //DDCan MOD [27/06/2012] [Only use admin user group in BOSStudio], START
            //STFieldsInfo objGridControlFieldsInfo = new STFieldsController().GetFirstFieldByModuleIDAndUserGroupIDAndFieldDataSourceAndFieldTypeAndFieldTag(
            //                                                    ModuleID, BOSApp.CurrentUserGroupInfo.ADUserGroupID, strGridControlDataSource, "BOSGridControl", BOSScreen.DataControl);
            STFieldsInfo objGridControlFieldsInfo = new STFieldsController().GetFirstFieldByModuleIDAndUserGroupIDAndFieldDataSourceAndFieldTypeAndFieldTag(
                                                                ModuleID, Contants.AdminUserGroupID, strGridControlDataSource, "BOSGridControl", BOSScreen.DataControl);
            //DDCan MOD [27/06/2012] [Only use admin user group in BOSStudio], END
            if (objGridControlFieldsInfo != null)
            {
                DevExpress.XtraGrid.GridControl gridControl = Controls[objGridControlFieldsInfo.STFieldName] as DevExpress.XtraGrid.GridControl;
                DevExpress.XtraGrid.Views.Grid.GridView gridView = gridControl.Views[0] as DevExpress.XtraGrid.Views.Grid.GridView;
                gridView.RefreshData();
            }
        }

        #region Functions of invalidating controls after doing action
        public void InvalidateFieldGroupControls(String strAction)
        {
            switch (strAction)
            {
                case BaseToolbar.ModusNew:
                    EnableFieldGroupControls(BOSERPScreen.cstFieldGroupNonEditable, true);
                    EnableFieldGroupControls(BOSERPScreen.cstFieldGroupAction, true);
                    EnableFieldGroupControls(BOSERPScreen.cstFieldGroupNonAction, false);

                    EnableSearchMainScreens(false);
                    break;
                case BaseToolbar.ModusEdit:
                    EnableFieldGroupControls(BOSERPScreen.cstFieldGroupNonCreatable, true);
                    EnableFieldGroupControls(BOSERPScreen.cstFieldGroupAction, true);
                    EnableFieldGroupControls(BOSERPScreen.cstFieldGroupNonAction, false);

                    EnableSearchMainScreens(false);
                    break;
                case BaseToolbar.ModusNone:
                    EnableFieldGroupControls(BOSERPScreen.cstFieldGroupNonCreatable, false);
                    EnableFieldGroupControls(BOSERPScreen.cstFieldGroupNonEditable, false);
                    EnableFieldGroupControls(BOSERPScreen.cstFieldGroupAction, false);
                    EnableFieldGroupControls(BOSERPScreen.cstFieldGroupNonAction, true);

                    EnableSearchMainScreens(true);
                    break;
            }
        }

        public void EnableFieldGroupControls(String strGroup, bool enable)
        {
            if (FieldGroupControls.ContainsKey(strGroup))
            {
                foreach (Control ctrl in FieldGroupControls[strGroup].Values)
                    ctrl.Enabled = enable;
            }
        }

        public void DisplayFieldGroupControls(String strGroup, bool visible)
        {
            if (FieldGroupControls.ContainsKey(strGroup))
            {
                foreach (Control ctrl in FieldGroupControls[strGroup].Values)
                    ctrl.Visible = visible;
            }
        }

        public void EnableSearchMainScreens(bool enable)
        {
            foreach (BOSScreen screen in Screens)
                if (screen.IsSearchMainScreen())
                    screen.Enabled = enable;
        }
        #endregion

        #region Get Parameter Value

        /// <summary type="GetParameterValue">
        /// Get Parameter Value of Module Function by Function Full Name,Function Class and Parameter Name
        /// </summary>
        /// <param name="strModuleFunctionFullName"></param>
        /// <param name="strModuleFunctionClass"></param>
        /// <param name="strModuleFunctionParameterName"></param>
        /// <returns></returns>
        public String GetModuleFunctionParameterValue(String strModuleFunctionFullName, String strModuleFunctionClass, String strModuleFunctionParameterName)
        {
            String strModuleFunctionParameterValue = String.Empty;

            STModuleFunctionsController objSTModuleFunctionsController = new STModuleFunctionsController();
            //Get Module Function
            STModuleFunctionsInfo objSTModuleFunctionsInfo = objSTModuleFunctionsController.GetModuleFunctionByModuleIDAndModuleFunctionFullNameAndModuleFunctionClass(ModuleID, strModuleFunctionFullName, strModuleFunctionClass);
            if (objSTModuleFunctionsInfo != null)
            {
                STModuleFunctionParametersController objSTModuleFunctionParametersController = new STModuleFunctionParametersController();
                //Get Module Function Parameter
                STModuleFunctionParametersInfo objSTModuleFunctionParametersInfo = objSTModuleFunctionParametersController.GetModuleFunctionParameterByModuleFunctionIDAndModuleFunctionParameterName(objSTModuleFunctionsInfo.STModuleFunctionID, strModuleFunctionParameterName);
                if (objSTModuleFunctionParametersInfo != null)
                {
                    //Get Module Function Parameter Value
                    //DDCan MOD [27/06/2012] [Only use admin user group in BOSStudio], START
                    //STModuleFunctionParameterValuesInfo objSTModuleFunctionParameterValuesInfo = new STModuleFunctionParameterValuesController().GetModuleFunctionParameterValueByModuleFunctionParameterIDAndUserGroupID(objSTModuleFunctionParametersInfo.STModuleFunctionParameterID, BOSApp.CurrentUserGroupInfo.ADUserGroupID);
                    STModuleFunctionParameterValuesInfo objSTModuleFunctionParameterValuesInfo = new STModuleFunctionParameterValuesController().GetModuleFunctionParameterValueByModuleFunctionParameterIDAndUserGroupID(objSTModuleFunctionParametersInfo.STModuleFunctionParameterID, Contants.AdminUserGroupID);
                    //DDCan MOD [27/06/2012] [Only use admin user group in BOSStudio], END
                    if (objSTModuleFunctionParameterValuesInfo != null)
                        strModuleFunctionParameterValue = objSTModuleFunctionParameterValuesInfo.STModuleFunctionParameterValue;
                }
            }

            return strModuleFunctionParameterValue;
        }

        /// <summary type="GetParameterValue">
        /// Get BOS Parameter Value
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="strEventName"></param>
        /// <param name="strFieldEventFunctionFullName"></param>
        /// <param name="strFieldEventFunctionClass"></param>
        /// <param name="strFieldEventFunctionParameterName"></param>
        /// <returns></returns>
        public String GetBOSParameterValue(Control ctrl, String strEventName, String strFieldEventFunctionFullName, String strFieldEventFunctionClass, String strFieldEventFunctionParameterName)
        {
            String strParameterValue = String.Empty;
            //If Get Parameter Value from Field Event Function
            if ((ctrl != null) && (!String.IsNullOrEmpty(strEventName)))
            {
                int iScreenID = ((BOSERPScreen)ctrl.FindForm()).ScreenID;
                if (iScreenID > 0)
                {
                    //DDCan MOD [27/06/2012] [Only use admin user group in BOSStudio], START
                    //STFieldsInfo objSTFieldsInfo = new STFieldsController().GetFieldByFieldNameAndScreenIDAndUserGroupID(
                    //                                                            ctrl.Name, iScreenID, BOSApp.CurrentUserGroupInfo.ADUserGroupID);
                    STFieldsInfo objSTFieldsInfo = new STFieldsController().GetFieldByFieldNameAndScreenIDAndUserGroupID(
                                                                                ctrl.Name, iScreenID, Contants.AdminUserGroupID);
                    //DDCan MOD [27/06/2012] [Only use admin user group in BOSStudio], END
                    if (objSTFieldsInfo != null)
                    {
                        STFieldEventsInfo objSTFieldEventsInfo = new STFieldEventsController().GetFieldEventByFieldIDAndEventName(objSTFieldsInfo.STFieldID, strEventName);
                        if (objSTFieldEventsInfo != null)
                        {
                            STFieldEventFunctionsInfo objSTFieldEventFunctionsInfo = new STFieldEventFunctionsController().GetFieldEventFunctionByFieldEventIDAndFunctionFullNameAndFunctionClass(
                                                                                    objSTFieldEventsInfo.STFieldEventID,
                                                                                    strFieldEventFunctionFullName,
                                                                                    strFieldEventFunctionClass);
                            if (objSTFieldEventFunctionsInfo != null)
                            {
                                STFieldEventFunctionParametersInfo objSTFieldEventFunctionParametersInfo = new STFieldEventFunctionParametersController().GetFieldEventFunctionParameterByFieldEventIDAndFieldEventFunctionParameterName(
                                                                                                                                                            objSTFieldEventFunctionsInfo.STFieldEventFunctionID,
                                                                                                                                                            strFieldEventFunctionParameterName);
                                if (objSTFieldEventFunctionParametersInfo != null)
                                    strParameterValue = objSTFieldEventFunctionParametersInfo.STFieldEventFunctionParameterValue;
                            }
                        }
                    }
                }
            }
            //if get parameter value from module function
            else
            {
                strParameterValue = GetModuleFunctionParameterValue(
                                        strFieldEventFunctionFullName,
                                        strFieldEventFunctionClass,
                                        strFieldEventFunctionParameterName);
            }

            return strParameterValue;
        }

        /// <summary type="GetParameterValue">
        /// Get BOS Parameter Value with object sender is Bar Manager
        /// </summary>
        /// <param name="barManager"></param>
        /// <param name="strEventName"></param>
        /// <param name="strFieldEventFunctionFullName"></param>
        /// <param name="strFieldEventFunctionClass"></param>
        /// <param name="strFieldEventFunctionParameterName"></param>
        /// <returns></returns>
        public String GetBOSParameterValue(DevExpress.XtraBars.BarManager barManager, String strEventName, String strFieldEventFunctionFullName, String strFieldEventFunctionClass, String strFieldEventFunctionParameterName)
        {
            String strParameterValue = String.Empty;
            //If Get Parameter Value from Field Event Function
            if ((barManager != null) && (!String.IsNullOrEmpty(strEventName)))
            {

                //if Toolbar of Parent Form of Module
                if (barManager.Form.GetType() == typeof(ModuleParentScreen))
                {
                    String strToolbarTag = barManager.PressedLink.Item.Tag.ToString();
                    String strToolbarGroup = barManager.PressedLink.Item.Hint;

                    STToolbarsInfo objSTToolbarsInfo = new STToolbarsController().GetSTToolbarsBySTModuleIDAndSTUserGroupIDAndSTToolbarGroupAndSTToolbarTag(
                                                                                ModuleID, Contants.AdminUserGroupID, strToolbarGroup, strToolbarTag);
                    STToolbarFunctionsInfo objSTToolbarFunctionsInfo = new STToolbarFunctionsController().GetToolbarFunctionByToolbarIDAndFunctionFullNameAndFunctionClass(objSTToolbarsInfo.STToolbarID, strFieldEventFunctionFullName, strFieldEventFunctionClass);
                    if (objSTToolbarFunctionsInfo != null)
                    {
                        STToolbarFunctionParametersInfo objSTToolbarFunctionParametersInfo = new STToolbarFunctionParametersController().GetToolbarFunctionParameterByToolbarIDAndToolbarFunctionParameterName(objSTToolbarFunctionsInfo.STToolbarFunctionID, strFieldEventFunctionParameterName);
                        if (objSTToolbarFunctionParametersInfo != null)
                            strParameterValue = objSTToolbarFunctionParametersInfo.STToolbarFunctionParameterValue;
                    }
                }
                //if is toolbar of sub screen
                else
                {
                    //DDCan MOD [27/06/2012] [Only use admin user group in BOSStudio], START
                    //int iScreenID = new STScreensController().GetScreenIDByModuleIDAndUserGroupIDAndScreenName(ModuleID, BOSApp.CurrentUserGroupInfo.ADUserGroupID, barManager.Form.Name);
                    int iScreenID = new STScreensController().GetScreenIDByModuleIDAndUserGroupIDAndScreenName(ModuleID, Contants.AdminUserGroupID, barManager.Form.Name);
                    //DDCan MOD [27/06/2012] [Only use admin user group in BOSStudio], END
                    if (iScreenID > 0)
                    {
                        //DDCan MOD [27/06/2012] [Only use admin user group in BOSStudio], START
                        //BOSLib.STFieldsInfo objSTFieldsInfo = new STFieldsController().GetFieldByFieldNameAndScreenIDAndUserGroupID(barManager.PressedLink.Item.Name, iScreenID, BOSApp.CurrentUserGroupInfo.ADUserGroupID);
                        BOSLib.STFieldsInfo objSTFieldsInfo = new STFieldsController().GetFieldByFieldNameAndScreenIDAndUserGroupID(barManager.PressedLink.Item.Name, iScreenID, Contants.AdminUserGroupID);
                        //DDCan MOD [27/06/2012] [Only use admin user group in BOSStudio], END
                        if (objSTFieldsInfo != null)
                        {
                            STFieldEventsInfo objSTFieldEventsInfo = new STFieldEventsController().GetFieldEventByFieldIDAndEventName(objSTFieldsInfo.STFieldID, strEventName);
                            if (objSTFieldEventsInfo != null)
                            {
                                STFieldEventFunctionsInfo objSTFieldEventFunctionsInfo = new STFieldEventFunctionsController().GetFieldEventFunctionByFieldEventIDAndFunctionFullNameAndFunctionClass(objSTFieldEventsInfo.STFieldEventID, strFieldEventFunctionFullName, strFieldEventFunctionClass);
                                if (objSTFieldEventFunctionsInfo != null)
                                {
                                    STFieldEventFunctionParametersInfo objSTFieldEventFunctionParametersInfo = new STFieldEventFunctionParametersController().GetFieldEventFunctionParameterByFieldEventIDAndFieldEventFunctionParameterName(objSTFieldEventFunctionsInfo.STFieldEventFunctionID, strFieldEventFunctionParameterName);
                                    if (objSTFieldEventFunctionParametersInfo != null)
                                        strParameterValue = objSTFieldEventFunctionParametersInfo.STFieldEventFunctionParameterValue;
                                }
                            }
                        }
                    }
                }
            }
            //if get parameter value from module function
            else
            {
                strParameterValue = GetModuleFunctionParameterValue(strFieldEventFunctionFullName, strFieldEventFunctionClass, strFieldEventFunctionParameterName);
            }

            return strParameterValue;
        }

        /// <summary>
        /// Get BOS Paramter Value by object sender,Event Name,FieldEventFunction Full Name,Field Event Function Class And Field Event Function Parameter Name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="strEventName"></param>
        /// <param name="strFieldEventFunctionFullName"></param>
        /// <param name="strFieldEventFunctionClass"></param>
        /// <param name="strFieldEventFunctionParameterName"></param>
        /// <returns></returns>
        public String GetBOSParameterValue(object sender, String strEventName, String strFieldEventFunctionFullName, String strFieldEventFunctionClass, String strFieldEventFunctionParameterName)
        {
            if (sender != null)
            {
                if (sender.GetType() == typeof(DevExpress.XtraBars.BarManager))
                {
                    return GetBOSParameterValue((DevExpress.XtraBars.BarManager)sender, strEventName, strFieldEventFunctionFullName, strFieldEventFunctionClass, strFieldEventFunctionParameterName);
                }
                else
                    return GetBOSParameterValue((Control)sender, strEventName, strFieldEventFunctionFullName, strFieldEventFunctionClass, strFieldEventFunctionParameterName);
            }
            else
            {
                return GetModuleFunctionParameterValue(strFieldEventFunctionFullName, strFieldEventFunctionClass, strFieldEventFunctionParameterName);
            }

        }


        public String GetBOSParameterValueFromFunctionNameAndParameterName(
                            object sender, String strEventName,
                            String strFunctionName, String strParameterName)
        {
            MethodInfo method = GetMethodInfoByMethodNameAndParametersType(
                                    strFunctionName,
                                    new Type[2] { typeof(object), typeof(String) });
            String strParameterValue = GetBOSParameterValue(
                                        sender,
                                        strEventName,
                                        method.ToString(),
                                        method.DeclaringType.ToString(),
                                        strParameterName);
            return strParameterValue;
        }
        #endregion        

        #region Functions for User Audits, Object History
        public bool ObjectIsEditingByOtherUser(String strModuleName, int iObjectID)
        {
            if (iObjectID > 0)
            {
                GEUserAuditsController objGEUserAuditsController = new GEUserAuditsController();
                GEUserAuditsInfo objGEUserAuditsInfo = objGEUserAuditsController.GetGEUserAuditsByModuleNameAndParameterAndAction(
                                                                                    strModuleName,
                                                                                    iObjectID.ToString(),
                                                                                    BaseToolbar.ModusEdit); 
                if (objGEUserAuditsInfo != null)
                {
                    String strEditUser = objGEUserAuditsInfo.ADUserName;
                    MessageBox.Show(String.Format("This record has been locked by user {0}", strEditUser.ToUpper()), "#Message#", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }

            return false;
        }

        public void SaveUserAudit(String strUserAction)
        {
            ADUsersController objADUsersController = new ADUsersController();
            GEUserAuditsController objGEUserAuditsController = new GEUserAuditsController();

            //Get ADUserID            
            int iADUserID = objADUsersController.GetObjectIDByName(BOSApp.CurrentUser);

            //Get GEUserAuditsInfo Object
            GEUserAuditsInfo objGEUserAuditsInfo = new GEUserAuditsInfo();
            objGEUserAuditsInfo.ADUserID = iADUserID;
            objGEUserAuditsInfo.ADUserName = BOSApp.CurrentUser;
            objGEUserAuditsInfo.GEUserAuditModuleName = this.Name;
            objGEUserAuditsInfo.GEUserAuditBeginDate = DateTime.Now;
            objGEUserAuditsInfo.GEUserAuditAction = strUserAction;
            if (strUserAction.Equals(cstUserAuditEdit))
                objGEUserAuditsInfo.GEUserAuditParameter = Toolbar.CurrentObjectID.ToString();

            //check if is exist user in user audit-->update, else add
            GEUserAuditsInfo objCurrentADUserAuditsInfo = objGEUserAuditsController.GetGEUserAuditsByADUserIDAndModuleName(iADUserID, this.Name);

            if (objCurrentADUserAuditsInfo != null)
            {
                objGEUserAuditsInfo.GEUserAuditID = objCurrentADUserAuditsInfo.GEUserAuditID;

                objGEUserAuditsController.UpdateObject(objGEUserAuditsInfo);
            }
            else
                objGEUserAuditsController.CreateObject(objGEUserAuditsInfo);
        }

        public void DeleteUserAudit()
        {
            ADUsersController objADUsersController = new ADUsersController();
            GEUserAuditsController objGEUserAuditsController = new GEUserAuditsController();

            int iADUserID = objADUsersController.GetObjectIDByName(BOSApp.CurrentUser);
            objGEUserAuditsController.DeleteGEUserAuditsByADUserID(iADUserID);
        }

        public void DeleteUserAudit(String strModuleName)
        {
            ADUsersController objADUsersController = new ADUsersController();
            GEUserAuditsController objGEUserAuditsController = new GEUserAuditsController();

            int iADUserID = objADUsersController.GetObjectIDByName(BOSApp.CurrentUser);
            objGEUserAuditsController.DeleteGEUserAuditsByADUserIDAndModuleName(iADUserID, this.Name);
        }

        public virtual int SaveObjectHistory(String strUserAction, int iObjectID)
        {
            ADUsersController objADUsersController = new ADUsersController();
            int iADUserID = objADUsersController.GetObjectIDByName(BOSApp.CurrentUser);
            String strMainObjecControllerName = BOSUtil.GetBusinessControllerNameFromBusinessObject(CurrentModuleEntity.MainObject);
            BaseBusinessController objController = BusinessControllerFactory.GetBusinessController(strMainObjecControllerName);

            //int iAANumberInt = objController.GetAANumberIntByID(iObjectID);
            String strObjectNo = objController.GetObjectNoByID(iObjectID);

            GEObjectHistoryController objGEObjectHistoryController = new GEObjectHistoryController();

            //Get Object History Info
            GEObjectHistoryInfo objGEObjectHistoryInfo = new GEObjectHistoryInfo();
            objGEObjectHistoryInfo.ADUserID = iADUserID;
            objGEObjectHistoryInfo.ADUserName = BOSApp.CurrentUser;
            objGEObjectHistoryInfo.GEObjectHistoryAction = strUserAction;
            objGEObjectHistoryInfo.GEObjectHistoryObjectName = this.Name;
            objGEObjectHistoryInfo.GEObjectHistoryObjectNumber = strObjectNo;
            objGEObjectHistoryInfo.GEObjectHistoryDate = DateTime.Now;

            objGEObjectHistoryController.CreateObject(objGEObjectHistoryInfo);
            return objGEObjectHistoryInfo.GEObjectHistoryID;
        }
        #endregion

        #endregion

        #region Functions for DropDownButton
       
        /// <summary>
        /// Show DropDownControl of button Criteria
        /// </summary>
        bool IsShowPopup = false;
        private void CreateCriteriaDropDownButton_ShowDropDownControl(object sender, DevExpress.XtraEditors.ShowDropDownControlEventArgs e)
        {
            ModuleUserCriteriaContainer(e.DropDownControl);
        }

        /// <summary>
        /// Show,hide PopupControlContainer
        /// </summary>
        public void ModuleUserCriteriaContainer(object obj)
        {
            if (IsShowPopup)
            {
                ((DevExpress.XtraBars.PopupControlContainer)obj).HidePopup();
                IsShowPopup = false;
            }
            else
            {
                ((DevExpress.XtraBars.PopupControlContainer)obj).Show();
                IsShowPopup = true;
            }
        }

        public void InitGridCotrolCriteria()
        {
            ((BaseModuleERP)this).ParentScreen.GridModuleUserCriteria.Screen = (BOSERPScreen)this.GetDataMainScreen();
            ((BaseModuleERP)this).ParentScreen.GridModuleUserCriteria.Screen.Module = this;
            ((BaseModuleERP)this).ParentScreen.GridModuleUserCriteria.InitializeControl();
        }

        /// <summary>
        /// Search by Criteria
        /// </summary>
        /// <param name="strQuery"></param>
        public void SearchByCriteriaName(String strQuery)
        {
            String strTableName = BOSUtil.GetTableNameFromBusinessObject(this.CurrentModuleEntity.MainObject);
            BaseBusinessController objBusinessController = BusinessControllerFactory.GetBusinessController(strTableName + "Controller");
            if (objBusinessController != null)
            {
                DataSet dsSearchResults = objBusinessController.GetDataSet(strQuery);
                this.Toolbar.SetToolbar(dsSearchResults);
                InvalidateAfterSearch(null, null);
            }
            ParentScreen.ModuleUserCriteriaContainer.HidePopup();
            IsShowPopup = false;
        }

        public void InvalidateModuleUserCriterias()
        {
            ADCriteriasController objCriteriasController = new ADCriteriasController();
            List<ADCriteriasInfo> criteriaList = objCriteriasController.GetAllObjectByModuleAndUser(ModuleID, BOSApp.CurrentUsersInfo.ADUserID);
            ParentScreen.GridModuleUserCriteria.DataSource = criteriaList;
            ParentScreen.GridModuleUserCriteria.RefreshDataSource();
        }
        #endregion
        #endregion

        #region Method for get Method Info

        /// <summary>
        /// GetAssembly Name From Method Class
        /// </summary>
        /// <functiontype>Get Method</functiontype>        
        /// <returns></returns>
        public override string GetAssemblyName()
        {
            return "BOSERP";
        }

        public override Type GetClassType(String strClassName)
        {
            return BaseClassFactory.GetClassType(strClassName);
        }
        #endregion        
        #endregion

        #region Utilities
        /// <summary>
        /// Get lookup tables through BOSApp
        /// </summary>
        /// <returns></returns>
        public SortedList GetLookupTableCollection()
        {
            return BOSApp.LookupTables;
        }

        /// <summary>
        /// Get the last created/updated date of all lookup tables through BOSApp
        /// </summary>
        /// <returns></returns>
        public SortedList GetLookupTableUpdatedDateCollection()
        {
            return BOSApp.LookupTablesUpdatedDate;
        }

        public SortedList<string, GELookupTablesInfo> GetLookupTableObjects()
        {
            return BOSApp.LookupTableObjects;
        }

        public GELanguagesInfo GetAppLanguage()
        {
            return BOSApp.CurrentLanguage;
        }
        #endregion

    }
}
