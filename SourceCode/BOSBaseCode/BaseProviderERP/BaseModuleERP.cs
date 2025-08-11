using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using BOSCommon;
using BOSComponent;
using BOSLib;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;
using Emr.Workflow.Client;
using Emr.Workflow.Client.Models;
using Localization;
using IsolationLevel = System.Transactions.IsolationLevel;

namespace BOSERP
{
    /// <summary>
    ///     Declare some functions and virtual functions for each module manager.
    /// </summary>
    public partial class BaseModuleERP : BaseModule, IBaseModuleERP
    {
        private readonly ARCustomersController _customersController;
        private readonly BOSDbUtil _dbUtil;
        private readonly GENumberingController _geNumberingController;
        protected readonly ADUsersController _objAdUsersController;
        protected readonly ADConfigValuesController _objConfigValuesController;
        private readonly ADCriteriasController _objCriteriasController;
        protected readonly GEObjectHistoryController _geObjHistoryCtrl;
        private readonly GEHistoryDetailsController _geHistoryCtrl;
        private readonly GEUserAuditsController _objGeUserAuditsController;
        protected readonly STModulesController _objModulesController;
        private readonly STModuleFunctionParametersController _objStModuleFunctionParametersController;
        private readonly STModuleFunctionsController _objStModuleFunctionsController;
        private readonly STScreensController _objStScreensController;
        private readonly STFieldEventFunctionParametersController _stFieldEventFunctionParametersController;
        private readonly STFieldEventFunctionsController _stFieldEventFunctionsController;
        private readonly STFieldEventsController _stFieldEventsController;
        private readonly STFieldsController _stFieldsController;
        private readonly STModuleFunctionParameterValuesController _stModuleFunctionParameterValuesController;
        private readonly STToolbarFunctionParametersController _stToolbarFunctionParametersController;
        private readonly STToolbarFunctionsController _stToolbarFunctionsController;
        protected readonly STToolbarsController _stToolbarsController;
        private readonly MEParamsController _meParamsController;
        private readonly MEEmrActionsController _meEmrActionsController;

        private WorkflowClient _workflowClient;
        private WorkflowLocal _workflowLocal;
        /// <summary>
        ///     Get format group list of table columns of the module
        /// </summary>
        public void GetFormatGroups()
        {
            var objFieldFormatGroupsController = new STFieldFormatGroupsController();
            FormatGroups = objFieldFormatGroupsController.GetFormatGroupsByModuleID(ModuleID);
        }

        /// <summary>
        ///     Check whether the module can switch to edit mode
        /// </summary>
        /// <returns>True if can, otherwise false</returns>
        public virtual bool IsEditable()
        {
            var barItem = ParentScreen.GetToolbarButton(BaseToolbar.ToolbarButtonEdit);
            if (barItem != null && barItem.Visibility != BarItemVisibility.Never && barItem.Enabled)
            {
                if (Toolbar.IsNullOrNoneAction() && Toolbar.CurrentObjectID > 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        ///     Automatically switch module to edit mode whenever an object is changed
        /// </summary>
        /// <param name="obj">Business object is changed</param>
        /// <param name="strPropertyName">Property name whose value is changed</param>
        /// <returns>True if can switch module to edit mode, otherwise false</returns>
        public virtual bool SwitchToEditMode(BusinessObject obj, string strPropertyName)
        {
            if (IsEditable())
                if (obj.AllowPropertyChangedEvent)
                {
                    var dbUtil = new BOSDbUtil();
                    if (string.IsNullOrEmpty(strPropertyName) ||
                        dbUtil.ColumnIsExist(BOSUtil.GetTableNameFromBusinessObject(obj), strPropertyName))
                    {
                        ActionEdit();
                        return true;
                    }
                }
            return false;
        }
        /// <summary>
        ///     Check whether the selected search objects is valid
        ///     in a specified module's context
        /// </summary>
        /// <param name="tableName">Name of the table objects are searched in</param>
        /// <param name="objects">Selected objects</param>
        /// <returns>True if valid, otherwise false</returns>
        public virtual bool CheckSelectedSearchObjects(string tableName, object objects)
        {
            return true;
        }

        private void InitControls()
        {
            foreach (XtraTabPage page in ParentScreen.ScreenContainer.TabPages)
                InitControls(page.Controls);
        }

        private void InitControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                var dbUtil = new BOSDbUtil();
                var dataMember = dbUtil.GetPropertyStringValue(ctrl, BOSScreen.cstDataMemberPropertyName);
                if (!string.IsNullOrEmpty(dataMember))
                    if (dataMember.Equals("HREmployeeID") || dataMember.Equals("FK_HREmployeeID") ||
                            dataMember.Equals("ARSellerID") || dataMember.Equals("FK_ARSellerID"))
                    {
                        if (ctrl.Tag == null || ctrl.Tag.Equals(BOSScreen.DataControl))
                        {
                            var lke = ctrl as BOSLookupEdit;
                            if (lke != null)
                            {
                                lke.Properties.ValueMember = "HREmployeeID";
                                lke.Properties.DisplayMember = "HREmployeeName";
                                lke.Properties.Columns.Clear();
                                var column = new LookUpColumnInfo();
                                column.Caption = BaseLocalizedResources.HREmployeeNo;
                                column.FieldName = "HREmployeeNo";
                                lke.Properties.Columns.Add(column);

                                column = new LookUpColumnInfo();
                                column.Caption = BaseLocalizedResources.HREmployeeName2;
                                column.FieldName = "HREmployeeName";
                                lke.Properties.Columns.Add(column);

                                column = new LookUpColumnInfo();
                                column.Caption = BaseLocalizedResources.HREmployeeCardNumber;
                                column.FieldName = "HREmployeeCardNumber";
                                lke.Properties.Columns.Add(column);
                            }
                        }
                    }

                if (ctrl.Controls.Count > 0)
                    InitControls(ctrl.Controls);
            }
        }

        #region Variables

        protected ERPModuleEntities _currentModuleEntity;
        protected ModuleParentScreen _parentScreen;
        protected ModuleSearchScreen _searchScreen;
        protected SortedList<string, ControlCollection> _fieldGroupControls;
        protected string _destinationAction = string.Empty;
        protected object[] _destinationActionParameters;
        protected BaseModuleERP _owner;
        protected string _displayModus;

        protected guiErrorMessage ErrorMessageScreen;
        protected DataTable ErrorTable;
        protected bool IsShowPopup;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the entity of the module that is responsible for handling business process
        /// </summary>
        public ERPModuleEntities CurrentModuleEntity
        {
            get { return _currentModuleEntity; }
            set { _currentModuleEntity = value; }
        }

        public virtual bool BeforeClosing()
        {
            return true;
        }

        /// <summary>
        ///     Gets or sets the screen containing the module's interface
        /// </summary>
        public ModuleParentScreen ParentScreen
        {
            get { return _parentScreen; }
            set { _parentScreen = value; }
        }

        /// <summary>
        ///     Gets or sets the screen containing the search criteria of the module
        /// </summary>
        public ModuleSearchScreen SearchScreen
        {
            get { return _searchScreen; }
            set { _searchScreen = value; }
        }

        /// <summary>
        ///     Gets or sets the control collection seperated by STFieldGroup
        /// </summary>
        public SortedList<string, ControlCollection> FieldGroupControls
        {
            get { return _fieldGroupControls; }
            set { _fieldGroupControls = value; }
        }

        /// <summary>
        ///     Gets or sets the destination action of an action chain that is relative to some modules
        /// </summary>
        public string DestinationAction
        {
            get { return _destinationAction; }
            set { _destinationAction = value; }
        }

        /// <summary>
        ///     Gets or sets the parameters that need to be passed to the destination action
        /// </summary>
        public object[] DestinationActionParameters
        {
            get { return _destinationActionParameters; }
            set { _destinationActionParameters = value; }
        }

        /// <summary>
        ///     Gets or sets the module calls this one
        /// </summary>
        public BaseModuleERP Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public string DisplayModus
        {
            get { return _displayModus; }
            set { _displayModus = value; }
        }

        #endregion

        #region Constructor

        /// <summary type="Constructor">
        ///     Default Constructor
        /// </summary>
        public BaseModuleERP()
        {
            Toolbar = new BaseToolbar();
            Screens = new List<BOSScreen>();
            Controls = new ControlCollection();

            FieldGroupControls = new SortedList<string, ControlCollection>();

            ParentScreen = new ModuleParentScreen
            {
                Module = this,
                MdiParent = BOSApp.MainScreen,
                //WindowState = FormWindowState.Maximized
            };

            ParentScreen.ButtonCreateCriteria.DropDownControl = ParentScreen.ModuleUserCriteriaContainer;
            ParentScreen.ButtonCreateCriteria.ShowDropDownControl += CreateCriteriaDropDownButton_ShowDropDownControl;
            SearchScreen = new ModuleSearchScreen { Module = this };
            ErrorTable = InitErrorTable();
            DisplayModus = cstModusNormal;
            //Add code init CurrentModuleObject
            CurrentModuleEntity = new ERPModuleEntities();
            _objModulesController = new STModulesController();
            _dbUtil = new BOSDbUtil();
            _objConfigValuesController = new ADConfigValuesController();
            _objStScreensController = new STScreensController();
            _objCriteriasController = new ADCriteriasController();
            _stFieldsController = new STFieldsController();
            _objStModuleFunctionsController = new STModuleFunctionsController();
            _objStModuleFunctionParametersController = new STModuleFunctionParametersController();
            _stModuleFunctionParameterValuesController = new STModuleFunctionParameterValuesController();
            _stFieldEventsController = new STFieldEventsController();
            _stFieldEventFunctionsController = new STFieldEventFunctionsController();
            _stFieldEventFunctionParametersController = new STFieldEventFunctionParametersController();
            _stToolbarsController = new STToolbarsController();
            _stToolbarFunctionsController = new STToolbarFunctionsController();
            _stToolbarFunctionParametersController = new STToolbarFunctionParametersController();
            _objGeUserAuditsController = new GEUserAuditsController();
            _objAdUsersController = new ADUsersController();
            _geObjHistoryCtrl = new GEObjectHistoryController();
            _geHistoryCtrl = new GEHistoryDetailsController();
            _geNumberingController = new GENumberingController();
            _customersController = new ARCustomersController();
            _meParamsController = new MEParamsController();
            _meEmrActionsController = new MEEmrActionsController();

            Task.Run(() =>
            {
                var emrEndpoint = BOSApp.GetSystemConfigValue(SysCfgConsts.PRIVATE, SysCfgConsts.PRIVATE_EMR_API_ENDPOINT);
                if (!string.IsNullOrEmpty(emrEndpoint) && !string.IsNullOrEmpty(BOSApp.EmrApiAuthToken))
                    _workflowClient = new WorkflowClient(emrEndpoint, BOSApp.EmrApiAuthToken);
            });

            Task.Run(() =>
            {
                var checkWWfActionLocal = BOSApp.GetSystemConfigValue(SysCfgConsts.WORKFLOW_CONFIGS, SysCfgConsts.WORKFLOW_CONFIG_CHECK_ALLOW_ACTION_LOCAL);
                if (checkWWfActionLocal.ToUpper() == "TRUE")
                    _workflowLocal = new WorkflowLocal(BOSApp.AppLocation);
            });
        }
        //public bool IsBackgroundWorker()
        //{
        //    return BOSApp.MainScreen.InvokeRequired;
        //}

        /// <summary type="Initialize">
        ///     Initialize Module
        /// </summary>
        public virtual void InitializeModule()
        {
            ModuleID = _objModulesController.GetObjectIDByName(Name);

            //if (!IsBackgroundWorker())
            {
                CurrentModuleEntity.InitModuleEntity();

                GetFormatGroups();

                InitModuleToolbarEvents();

                BOSProgressBar.Start(BaseLocalizedResources.InitModuleMessage);

                InitGridCotrolCriteria();
            }
            InitializeScreens();

            //if (!IsBackgroundWorker())
            {
                //Init all GridControl in BOSList
                CurrentModuleEntity.InitGridControlInBOSList();

                if (CurrentModuleEntity.MainObject != null)
                {
                    CurrentModuleEntity.CreateMainObjectRule();
                    CurrentModuleEntity.SubcribeMainObjectEvent();
                }

                //Move from BaseTransactionModule
                DisplayLabelText(CurrentModuleEntity.MainObject);
                InitControls();

                BOSProgressBar.Close();
            }
        }

        #endregion

        #region Toolbar Manager Functions

        #region "Functions for toolbar action"

        private DataTable InitErrorTable()
        {
            var tblError = new DataTable { TableName = "Error" };

            var colErrorControl = new DataColumn
            {
                ColumnName = "Control",
                DataType = typeof(string)
            };
            tblError.Columns.Add(colErrorControl);

            var colErrorMessage = new DataColumn
            {
                ColumnName = "Message",
                DataType = typeof(string)
            };
            tblError.Columns.Add(colErrorMessage);

            var colPosition = new DataColumn
            {
                ColumnName = "Position",
                DataType = typeof(int)
            };
            tblError.Columns.Add(colPosition);

            var colComment = new DataColumn
            {
                ColumnName = "Comment",
                DataType = typeof(string)
            };
            tblError.Columns.Add(colComment);

            return tblError;
        }

        protected virtual DataTable CheckInvalidInputBeforeSave()
        {
            var tblError = InitErrorTable();
            if (CurrentModuleEntity.MainObject != null)
            {
                var objFieldsController = new STFieldsController();
                foreach (var r in CurrentModuleEntity.MainObject.BusinessRuleCollections)
                {
                    var isRuleBroken = !r.ValidateRule(CurrentModuleEntity.MainObject);
                    if (isRuleBroken)
                    {
                        var strErrorMessage = r.Description;
                        var strMainObjectName = CurrentModuleEntity.MainObject.GetType().Name;
                        var strFieldDataSource = strMainObjectName.Substring(0, strMainObjectName.Length - 4);
                        var objStFieldsInfo = objFieldsController
                            .GetFirstFieldByModuleIDAndUserGroupIDAndFieldDataSourceAndFieldDataMemberAndFieldTag(
                                ModuleID, BOSApp.CurrentUserGroupInfo.ADUserGroupID,
                                strFieldDataSource, r.PropertyName, BOSScreen.DataControl);
                        if (objStFieldsInfo != null)
                        {
                            if (!string.IsNullOrEmpty(objStFieldsInfo.STFieldError))
                                strErrorMessage = objStFieldsInfo.STFieldError;
                            tblError.Rows.Add(objStFieldsInfo.STFieldName, strErrorMessage, -1, string.Empty);
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
                ErrorTable.Rows.Clear();
                var dataSource = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
                foreach (var r in CurrentModuleEntity.MainObject.BusinessRuleCollections)
                {
                    var isRuleBroken = !r.ValidateRule(CurrentModuleEntity.MainObject);
                    if (isRuleBroken)
                        AddErrorToErrorScreen(r.Description, dataSource, r.PropertyName);
                }

                //Check from required property of main object
                var props = CurrentModuleEntity.MainObject.GetType().GetProperties();
                foreach (var prop in props)
                {
                    //Find property binding to this column then get its required attribute
                    RequiredAttribute requiredAttr = null;
                    var attrs = prop.GetCustomAttributes(typeof(RequiredAttribute), true);
                    if (attrs.Length > 0)
                        requiredAttr = (RequiredAttribute)attrs[0];
                    if (requiredAttr != null)
                        if (!CurrentModuleEntity.IsValidNonForeignKeyPropety(prop.Name))
                            AddErrorToErrorScreen(requiredAttr.ErrorMessage, dataSource, prop.Name);
                }
            }

            if (ErrorTable.Rows.Count > 0)
            {
                ErrorMessageScreen = new guiErrorMessage(ErrorTable) { Module = this };
                ErrorMessageScreen.ShowDialog();
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Add an error to error screen
        /// </summary>
        /// <param name="errorMessage">Error message is displayed to user</param>
        /// <param name="dataSource">Data source the error occurs at</param>
        /// <param name="dataMember">Data member the error occurs at</param>
        private void AddErrorToErrorScreen(string errorMessage, string dataSource, string dataMember)
        {
            STFieldsInfo objFieldsInfo = null;
            foreach (var bosScreen in Screens)
            {
                var screen = (BOSERPScreen)bosScreen;
                objFieldsInfo =
                    screen.Fields.Values.Where(
                        f =>
                            f.STFieldDataSource == dataSource && f.STFieldDataMember == dataMember &&
                            f.STFieldTag == BOSScreen.DataControl).FirstOrDefault();
                if (objFieldsInfo != null)
                    break;
            }
            if (objFieldsInfo != null)
            {
                if (Controls.Contains(objFieldsInfo.STFieldName))
                {
                    var strCustomErrorMessage = _dbUtil.GetPropertyStringValue(Controls[objFieldsInfo.STFieldName],
                        "BOSError");
                    if (!string.IsNullOrEmpty(strCustomErrorMessage))
                        errorMessage = strCustomErrorMessage;
                }
                ErrorTable.Rows.Add(objFieldsInfo.STFieldName, errorMessage, -1, string.Empty);
            }
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
            var strControlName = ctrl.Name;
            if (ErrorTable.Rows.Count > 0)
            {
                var row = ErrorTable.Rows.Find(new object[3] { strControlName, -1, string.Empty });
                if (row != null)
                {
                    var iErrorIndex = ErrorTable.Rows.IndexOf(row);
                    if (iErrorIndex < ErrorTable.Rows.Count - 1)
                    {
                        var strNextErrorControl = ErrorTable.Rows[iErrorIndex + 1][0].ToString();
                        Controls[strNextErrorControl].Focus();
                    }
                    else
                    {
                        var strNextErrorControl = ErrorTable.Rows[0][0].ToString();
                        Controls[strNextErrorControl].Focus();
                    }
                }
            }
        }

        /// <summary>
        ///     Function will be called when user create new object in module
        /// </summary>
        public virtual void ActionNew()
        {
            Cursor.Current = Cursors.WaitCursor;

            //Call new delegate from Toolbar
            Toolbar.New();

            //Invalidate toolbar in the module's context
            InvalidateToolbar();

            //Invalidate toolbar after new object
            ParentScreen.InvalidateToolbarAfterActionNew();

            ResetFocus();

            //Save User Audit New action
            SaveUserAudit(cstUserAuditNew);

            //Invalidate controls
            InvalidateFieldGroupControls(BaseToolbar.ModusNew);
            if (ParentScreen.IsObjectListExpanded)
                ParentScreen.CollapseObjectList();

            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        ///     Function will be called when user save the edited object in module
        /// </summary>
        public virtual int ActionSave()
        {
            var iObjectId = 0;
            if (!Toolbar.IsNullOrNoneAction())
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!IsInvalidInput())
                {
                    var options = new TransactionOptions { IsolationLevel = IsolationLevel.Serializable };

                    //Call Save delegate of Toolbar
                    using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
                    {
                        try
                        {
                            iObjectId = Toolbar.Save();
                            if (iObjectId > 0)
                            {
                                scope.Complete();
                                CurrentModuleEntity.MainObject.OldObject =
                                    (BusinessObject)CurrentModuleEntity.MainObject.Clone();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(BaseLocalizedResources.SaveObjectErrorMessage + "\r\n"
                                + ex.ToString(),
                                CommonLocalizedResources.MessageBoxDefaultCaption,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        finally
                        {

                            scope.Dispose();
                        }
                    }

                    if (iObjectId > 0)
                    {
                        ModuleAfterSaved(iObjectId);

                        //If module's owner exists, activate it
                        if (Owner != null)
                        {
                            var ownerParentScreen = Owner.ParentScreen;
                            Owner = null;
                            ownerParentScreen.Activate();
                        }
                    }
                }

                Cursor.Current = Cursors.Default;
            }
            return iObjectId;
        }

        /// <summary>
        ///     Complete transaction and update inventory
        /// </summary>
        public virtual bool ActionComplete()
        {
            var isComplete = false;
            if (!IsInvalidInventory())
                using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    try
                    {
                        CurrentModuleEntity.SetPropertyChangeEventLock(false);
                        isComplete = CurrentModuleEntity.CompleteTransaction();
                        scope.Complete();
                    }
                    catch (Exception)
                    {
                        scope.Dispose();
                        MessageBox.Show(BaseLocalizedResources.CompleteObjectErrorMessage,
                            CommonLocalizedResources.MessageBoxDefaultCaption,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    finally
                    {
                        CurrentModuleEntity.SetPropertyChangeEventLock(true);
                    }
                }

            if (isComplete)
                ModuleAfterCompleted();
            return isComplete;
        }

        /// <summary>
        ///     Called when the transaction module has been completed,
        ///     give a chance to add corresponding behaviours
        /// </summary>
        public virtual void ModuleAfterCompleted()
        {
            ParentScreen.InvalidateToolbarAfterActionComplete();

            //Invalidate toolbar in the module's context
            InvalidateToolbar();
        }

        /// <summary>
        ///     Transfer the current object and relative data to a branch
        /// </summary>
        /// <param name="defaultBranchConfigKey">Key is used to get default branch id from config values</param>
        public virtual void ActionTransfer(string defaultBranchConfigKey)
        {
            if (Toolbar.IsNullOrNoneAction() && Toolbar.CurrentObjectID > 0)
            {
                var objConfigValuesInfo = _objConfigValuesController.GetObjectByConfigKey(defaultBranchConfigKey);
                var defaultBranchId = 0;
                if (objConfigValuesInfo != null)
                    defaultBranchId = Convert.ToInt32(objConfigValuesInfo.ADConfigKeyValue);

                var guiChooseBranch = new guiChooseBranch(defaultBranchId) { Module = this };
                if (guiChooseBranch.ShowDialog() == DialogResult.OK)
                {
                    BOSProgressBar.Start(string.Format(BaseLocalizedResources.TransferringDataToBranchMessage,
                        guiChooseBranch.SelectedBranch.BRBranchName));
                    CurrentModuleEntity.SetPropertyChangeEventLock(false);
                    var isCompleted = TransferData(guiChooseBranch.SelectedBranch);
                    CurrentModuleEntity.SetPropertyChangeEventLock(true);
                    BOSProgressBar.Close();

                    if (!guiChooseBranch.IsDefaultBranch)
                    {
                        if (objConfigValuesInfo != null)
                        {
                            objConfigValuesInfo.ADConfigKeyValue = Convert.ToString(0);
                            _objConfigValuesController.UpdateObject(objConfigValuesInfo);
                        }
                    }
                    else
                    {
                        if (objConfigValuesInfo != null)
                        {
                            objConfigValuesInfo.ADConfigKeyValue =
                                Convert.ToString(guiChooseBranch.SelectedBranch.BRBranchID);
                            _objConfigValuesController.UpdateObject(objConfigValuesInfo);
                        }
                    }

                    if (isCompleted)
                    {
                        ParentScreen.InvalidateToolbarAfterActionTransfer();

                        //Invalidate toolbar in the module's context
                        InvalidateToolbar();
                    }
                }
            }
        }

        /// <summary>
        ///     Transfer the current object and relative data to a branch
        /// </summary>
        /// <param name="objBranchsInfo">Target branch</param>
        protected virtual bool TransferData(BRBranchsInfo objBranchsInfo)
        {
            return true;
        }

        /// <summary>
        ///     Called when the module has been saved, give a chance
        ///     to add corresponding behaviours
        /// </summary>
        /// <param name="iObjectId">Main object id</param>
        public virtual void ModuleAfterSaved(int iObjectId)
        {
            ParentScreen.Focus();

            //Invalidate Toolbar button after save
            ParentScreen.InvalidateToolbarAfterActionSave();

            //Invalidate toolbar in the module's context
            InvalidateToolbar();

            //Invalidate controls
            InvalidateFieldGroupControls(BaseToolbar.ModusNone);

            //Invalidate search result control
            InvalidateSearchResultsControl(null, string.Empty);

            //Save User Audit is Nothing
            SaveUserAudit(cstUserAuditNothing);

            //Set modus action of toolbar to none
            Toolbar.ModusAction = BaseToolbar.ModusNone;
        }

        public virtual void ActionDuplicate()
        {
            if (Toolbar.ObjectCollection != null)
                if (Toolbar.IsNullOrNoneAction() && Toolbar.CurrentObjectID > 0)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    Toolbar.ModusAction = BaseToolbar.ModusNew;

                    //Set number of main object to ERPModuleEntities.cstNewObjectText
                    var strPrimaryColumn =
                        _dbUtil.GetTablePrimaryColumn(
                            BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject));
                    _dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, strPrimaryColumn, 0);
                    _dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject,
                        strPrimaryColumn.Substring(0, strPrimaryColumn.Length - 2) + "No",
                        ERPModuleEntities.cstNewObjectText);

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

        /// <summary>
        ///     Function will be called when user edit object in module
        /// </summary>
        public virtual void ActionEdit()
        {
            if (!IsAllowEdit(CurrentModuleEntity.MainObject))
            {
                MessageBox.Show("Thiếu quyền sửa trên đối tượng này", "Thiếu quyền", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (ObjectIsEditingByOtherUser(Name, Toolbar.CurrentObjectID))
                return;

            //Call Edit delegate from Toolbar
            if (Toolbar.Edit())
            {
                //Invalidate toolbar after edit action
                ParentScreen.InvalidateToolbarAfterActionEdit();

                //Activate Main Screen
                if (ActiveScreen.IsSearchMainScreen())
                {
                    var guiDataMain = GetDataMainScreen(null, string.Empty);
                    ActiveScreen = guiDataMain;
                }

                //Invalidate controls
                InvalidateFieldGroupControls(BaseToolbar.ModusEdit);
                if (ParentScreen.IsObjectListExpanded)
                    ParentScreen.CollapseObjectList();

                //Save User Audit
                SaveUserAudit(cstUserAuditEdit);
            }
            else
            {
                var barbtnEdit = (BarButtonItem)ParentScreen.GetToolbarButton(BaseToolbar.ToolbarButtonEdit);
                barbtnEdit.Down = false;
            }
        }

        public void ActionEdit(string moduleName, int objectId)
        {
            var module = BOSApp.ShowModule(moduleName);
            var tableName = BOSUtil.GetTableNameFromBusinessObject(module.CurrentModuleEntity.MainObject);
            var primaryKey = _dbUtil.GetTablePrimaryColumn(tableName);
            for (var i = 0; i < module.Toolbar.ObjectCollection.Tables[0].Rows.Count; i++)
                if (objectId == Convert.ToInt32(module.Toolbar.ObjectCollection.Tables[0].Rows[i][primaryKey]))
                {
                    module.Owner = this;
                    module.Toolbar.CurrentIndex = i;
                    module.FocusRowOfGridSearchResultByToolbarCurrentIndex();
                    module.ActionEdit();
                    return;
                }
        }

        /// <summary>
        ///     Focus pointer to the first control of data main screen
        /// </summary>
        protected virtual void ResetFocus()
        {
            foreach (XtraTabPage page in ParentScreen.ScreenContainer.TabPages)
                if (page.Name.Contains("DM"))
                {
                    var minIndex = int.MaxValue;
                    ResetFocus(page.Controls, 0, ref minIndex);
                    return;
                }
        }

        /// <summary>
        ///     Focus pointer to the first control of data main screen
        /// </summary>
        /// <param name="controls">Control collection</param>
        /// <returns>True if find out a focusable control, otherwise false</returns>
        private bool ResetFocus(Control.ControlCollection controls, int parentIndex, ref int minIndex)
        {
            var focusable = false;
            foreach (Control ctrl in controls)
            {
                if (ctrl is BaseEdit && ctrl.TabIndex > 0 && !ctrl.Name.Contains("No") && ctrl.Enabled)
                    if (parentIndex * 10 + ctrl.TabIndex < minIndex)
                    {
                        ctrl.Focus();
                        minIndex = parentIndex * 10 + ctrl.TabIndex;
                        focusable = true;
                    }

                if (ctrl.Controls.Count > 0)
                    focusable = ResetFocus(ctrl.Controls, parentIndex * 10 + ctrl.TabIndex, ref minIndex);
            }

            return focusable;
        }

        /// <summary>
        ///     Function will be called when user delete object in module
        /// </summary>
        public virtual void ActionDelete()
        {
            if (!IsAllowDelete(CurrentModuleEntity.MainObject))
            {
                MessageBox.Show("Thiếu quyền xóa trên đối tượng này", "Thiếu quyền", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (Toolbar.CurrentObjectID > 0)
            {
                Toolbar.Delete();
                ParentScreen.InvalidateToolbarAfterActionDelete();
                //Invalidate the toolbar in the module's context
                InvalidateToolbar();
                BOSApp.MainScreen.OpenModulesToolStrip.Enabled = true;

                //Invalidate controls
                InvalidateFieldGroupControls(BaseToolbar.ModusNone);
            }

            //Save User Audit is Nothing
            SaveUserAudit(cstUserAuditNothing);
        }

        public virtual void ActionEditTemplate()
        {
            var strMainTable = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
            var objBusinessController = BusinessControllerFactory.GetBusinessController(strMainTable + "Controller");
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
                    _dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, ERPModuleEntities.AAStatusColumn,
                        BusinessObject.TemplateAAStatus);

                    var strColumnNoName = strMainTable.Substring(0, strMainTable.Length - 1) + "No";
                    _dbUtil.SetPropertyValue(CurrentModuleEntity.MainObject, strColumnNoName,
                        ERPModuleEntities.cstTemplateObjectText);
                    CurrentModuleEntity.UpdateMainObjectBindingSource();

                    ParentScreen.InvalidateToolbarAfterActionEditTemplate();

                    Toolbar.ModusAction = BaseToolbar.ModusNew;
                    ActivateDataMainScreen();
                }
            }
        }

        /// <summary>
        ///     Function will be called when user cancel edit object in module
        /// </summary>
        public virtual void ActionCancel()
        {
            // cal Cancel delegate from toolbar
            Toolbar.Cancel();

            //Invalidate toolbar after Cancel 
            ParentScreen.InvalidateToolbarAfterActionCancel();

            //Invalidate toolbar in the module's context
            InvalidateToolbar();

            //Save User Audit is Nothing
            SaveUserAudit(cstUserAuditNothing);

            //Invalidate controls
            InvalidateFieldGroupControls(BaseToolbar.ModusNone);

            //If module's owner exists, activate it
            if (Owner != null)
            {
                var ownerParentScreen = Owner.ParentScreen;
                Owner = null;
                ownerParentScreen.Activate();
            }
        }

        /// <summary>
        ///     Function will be called when invalidate module
        /// </summary>
        public virtual void ActionInvalidate()
        {
            Toolbar.Invalidate();
        }

        /// <summary>
        ///     Invalidate module by a given object
        /// </summary>
        /// <param name="objectId">Object id</param>
        public virtual void ActionInvalidate(int objectId)
        {
            var tableName = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
            var primaryKey = _dbUtil.GetTablePrimaryColumn(tableName);
            if (Toolbar.ObjectCollection != null)
                for (var i = 0; i < Toolbar.ObjectCollection.Tables[0].Rows.Count; i++)
                    if (objectId == Convert.ToInt32(Toolbar.ObjectCollection.Tables[0].Rows[i][primaryKey]))
                    {
                        Toolbar.CurrentIndex = i;
                        FocusRowOfGridSearchResultByToolbarCurrentIndex();
                        return;
                    }

            //If can't find the object in toolbar's collection
            var controller = BusinessControllerFactory.GetBusinessController(tableName + "Controller");
            if (controller != null)
            {
                var ds = controller.GetDataSetByID(objectId);
                Toolbar.SetToolbar(ds);
                InvalidateAfterSearch(null, string.Empty);
            }
        }

        /// <summary>
        ///     Function will be call when user go to previous object
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
            else if (Toolbar.ModusAction != BaseToolbar.ModusNone)
            {
                var dlgResult =
                    MessageBox.Show(
                        Toolbar.ModusAction == BaseToolbar.ModusNew
                            ? "Do you want to save the new record?"
                            : "Do you want to save the current record?", "Save Record", MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question);
                if (dlgResult == DialogResult.Yes || dlgResult == DialogResult.No)
                {
                    if (dlgResult == DialogResult.Yes)
                        ActionSave();
                    else
                        ActionCancel();
                    if (Toolbar.ModusAction == BaseToolbar.ModusNone)
                        if (Toolbar.ObjectCollectionLength > 0)
                        {
                            if (Toolbar.CurrentIndex > 0)
                                Toolbar.CurrentIndex--;
                            Toolbar.Invalidate();
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
                FocusRowOfGridSearchResultByToolbarCurrentIndex();
        }

        /// <summary>
        ///     Function will be call when user go to next object
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
            else if (Toolbar.ModusAction != BaseToolbar.ModusNone)
            {
                DialogResult dlgResult;
                if (Toolbar.ModusAction == BaseToolbar.ModusNew)
                    dlgResult = MessageBox.Show("Do you want to save the new record?", "Save Record",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                else
                    dlgResult = MessageBox.Show("Do you want to save the current record?", "Save Record",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
        ///     Function will be call when user Print.
        /// </summary>
        public virtual void ActionPrint()
        {
        }

        public virtual void ActionExport()
        {
            //var guiExceExport = new guiExcelExport { Module = this };
            //guiExceExport.ShowDialog();
        }

        public virtual void ActionImport()
        {
            //var guiExcelImport = new guiExcelImport { Module = this };
            //guiExcelImport.ShowDialog();
        }


        public virtual void ActionShowError()
        {
            if (ErrorTable.Rows.Count > 0)
                if (ErrorMessageScreen == null)
                {
                    ErrorMessageScreen = new guiErrorMessage(ErrorTable) { Module = this };
                    ErrorMessageScreen.Show();
                }
                else if (ErrorMessageScreen.IsDisposed)
                {
                    ErrorMessageScreen = new guiErrorMessage(ErrorTable) { Module = this };
                    ErrorMessageScreen.Show();
                }
                else
                {
                    ErrorMessageScreen.Activate();
                }
        }

        /// <summary>
        ///     Function will be call when user click User Audit
        /// </summary>
        public virtual void ActionUserAudit()
        {
            var guiUserAudit = new guiUserAudit();
            guiUserAudit.Show();
        }

        #endregion

        #region "Delegate Functions for Toolbar Events"

        /// <summary type="Toolbar">
        ///     Initialize the delegate functions and events for toolbar buttons
        /// </summary>
        /// <functiontype>Toolbar Function</functiontype>
        public void InitModuleToolbarEvents()
        {
            Toolbar = new BaseToolbar();
            BaseToolbar.InvalidateHandler InvalidateHandler = Invalidate;
            BaseToolbar.NewHandler NewHandler = New;
            BaseToolbar.SaveHandler SaveHandler = Save;
            BaseToolbar.DeleteHandler DeleteHandler = Delete;
            BaseToolbar.PrintHandler PrintHandler = Print;

            Toolbar.InvalidateEvent += InvalidateHandler;
            Toolbar.NewEvent += NewHandler;
            Toolbar.SaveEvent += SaveHandler;
            Toolbar.DeleteEvent += DeleteHandler;
            Toolbar.PrintEvent += PrintHandler;
        }

        #region Function For Invalidate action

        /// <summary type="Invalidate">
        ///     Invalidate module
        /// </summary>
        /// <param name="iObjectId">Current Object ID</param>
        public virtual void Invalidate(int iObjectId)
        {
            var typMainObjectType = CurrentModuleEntity.MainObject.GetType();
            var objMainObjectController = new BaseBusinessController(typMainObjectType);
            var mainObject = (BusinessObject)objMainObjectController.GetObjectByID(iObjectId);
            if (mainObject != null)
            {
                CurrentModuleEntity.Invalidate(iObjectId);

                CurrentModuleEntity.MainObject.OldObject = (BusinessObject)CurrentModuleEntity.MainObject.Clone();

                //ParentScreen.Text = ParentScreen.GetParentScreenTextByLanguage(BOSApp.CurrentLang) + " - " + MessageInfo.ShowInfoForCurrentObject(this.Name, BOSApp.CurrentLang, strAANumberString);

                if (CurrentModuleEntity.MainObject != null)
                {
                    var tablename = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
                    var number = _dbUtil.GetPropertyStringValue(CurrentModuleEntity.MainObject,
                        tablename.Substring(0, tablename.Length - 1) + "No");
                    BOSApp.MainScreen.nameItem.Caption = number;
                }

                InvalidateToolbar();
            }
        }

        /// <summary>
        ///     Invalidate toolbar corresponding to the context of a specific module
        /// </summary>
        public virtual void InvalidateToolbar()
        {
        }

        #endregion

        #region Functions for New Action

        /// <summary type="New">
        ///     New object in module
        /// </summary>
        public virtual void New()
        {
            CurrentModuleEntity.New();

            var guiDataMainScreen = GetDataMainScreen(null, string.Empty);
            if (guiDataMainScreen != null)
                ActiveScreen = guiDataMainScreen;
        }

        #endregion

        #region Function For Save Action

        public virtual int Save()
        {
            var strMainTable = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
            var strMainTablePrimaryColumn = strMainTable.Substring(0, strMainTable.Length - 1) + "ID";
            var strMainTableNoColumn = strMainTablePrimaryColumn.Substring(0, strMainTablePrimaryColumn.Length - 2) +
                                       "No";
            var strObjectNo = _dbUtil.GetPropertyStringValue(CurrentModuleEntity.MainObject, strMainTableNoColumn);

            var isContinue = IsValidObjectNo(strObjectNo);
            if (!isContinue) return 0;
            var iObjectId = CurrentModuleEntity.SaveMainObject();

            if (iObjectId <= 0) return iObjectId;
            //Save Module Objects
            CurrentModuleEntity.SaveModuleObjects();

            //Save Object History
            SaveObjectHistory(
                Toolbar.ModusAction == BaseToolbar.ModusNew ? cstObjectHistoryActionNew : cstObjectHistoryActionChange,
                iObjectId);
            return iObjectId;
        }

        /// <summary>
        ///     Check whether the inputed object no is valid
        /// </summary>
        /// <param name="objectNo">Object no</param>
        protected virtual bool IsValidObjectNo(string objectNo)
        {
            var objCurrentObjectController =
                BusinessControllerFactory.GetBusinessController(
                    CurrentModuleEntity.MainObject.GetType()
                        .Name.Substring(0, CurrentModuleEntity.MainObject.GetType().Name.Length - 4) + "Controller");
            var mainTable = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
            var mainTablePrimaryColumn = _dbUtil.GetTablePrimaryColumn(mainTable);
            var isValid = true;
            if (string.IsNullOrEmpty(objectNo)) return true;
            switch (Toolbar.ModusAction)
            {
                case BaseToolbar.ModusNew:
                    if (!objCurrentObjectController.IsExist(objectNo)) return true;
                    MessageBox.Show(BaseLocalizedResources.NumberAlreadyExistsMessage,
                        CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    isValid = false;
                    break;
                case BaseToolbar.ModusEdit:
                    var objMainObject = (BusinessObject)objCurrentObjectController.GetObjectByNo(objectNo);
                    if (objMainObject == null) return true;
                    var iMainObjectId =
                        Convert.ToInt32(_dbUtil.GetPropertyValue(objMainObject, mainTablePrimaryColumn));
                    if (iMainObjectId == Toolbar.CurrentObjectID) return true;
                    MessageBox.Show(BaseLocalizedResources.NumberAlreadyExistsMessage,
                        CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    isValid = false;
                    break;
            }
            return isValid;
        }

        #endregion

        #region Function for Delete action

        /// <summary type="Delete">
        ///     Delete object in module
        /// </summary>
        /// <param name="iObjectId">Object ID will be deleted</param>
        /// <returns>true if delete successfull, otherwise return false</returns>
        public virtual bool Delete(int iObjectId)
        {
            //Khi xoa the du lieu hoac the chuc nang thi kiem tra xem da duoc cau hinh vao template nao chua
            if (CurrentModuleEntity.GetType().Name.Substring(0, CurrentModuleEntity.GetType().Name.Length - 8) == "MEParams")
            {
                if (_meParamsController.CheckParamUsed(iObjectId))
                {
                    MessageBox.Show("Thẻ dữ liệu đã được sử dụng, không thể xóa!", CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else if (CurrentModuleEntity.GetType().Name.Substring(0, CurrentModuleEntity.GetType().Name.Length - 8) == "MEEmrAction")
            {
                if (_meEmrActionsController.CheckActionUsed(iObjectId))
                {
                    MessageBox.Show("Thẻ chức năng đã được sử dụng, không thể xóa!", CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (MessageBox.Show(BaseLocalizedResources.ConfirmDeleteObjectMessage,
                    CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes) return false;
            //Save Object History with action delete 
            SaveObjectHistory(cstObjectHistoryActionDelete, Toolbar.CurrentObjectID);

            //Delete object from CurrentModuleEntity
            CurrentModuleEntity.Delete(iObjectId);

            Search();
            return true;
        }

        #endregion

        /// <summary type="Print">
        ///     Print Module
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
            return string.Compare(i1.STScreenNumber, i2.STScreenNumber) * -1;
        }

        /// <summary type="Initialize">
        ///     Initialize all screens belong to module
        /// </summary>
        public virtual void InitializeScreens()
        {
            var lstScreenInfo = new List<STScreensInfo>();
            var dsScreens = _objStScreensController.GetScreenByModuleNameAndUserGroupID(Name,
                BOSApp.CurrentUserGroupInfo.ADUserGroupID);
            if (dsScreens.Tables.Count > 0)
            {
                lstScreenInfo.AddRange(from DataRow row in dsScreens.Tables[0].Rows
                                       select (STScreensInfo)_objStScreensController.GetObjectFromDataRow(row)
                    into objStScreensInfo
                                       where objStScreensInfo.STScreenVisible
                                       where !objStScreensInfo.STScreenNumber.StartsWith("DS")
                                       select objStScreensInfo);
                // if (!IsBackgroundWorker())
                // {
                //Add all screens to the screen list of module, make them available for customization
                foreach (var objStScreensInfo in lstScreenInfo)
                {
                    BOSERPScreen scr = BOSERPScreenFactory.GetScreen(objStScreensInfo.STScreenNumber, Name);
                    //scr.WindowState = FormWindowState.Minimized;
                    scr.ScreenInfo = objStScreensInfo;
                    scr.ScreenID = objStScreensInfo.STScreenID;
                    scr.Name = objStScreensInfo.STScreenName;
                    scr.Module = this;
                    scr.Text = objStScreensInfo.STScreenText;
                    Screens.Add(scr);
                }

                //Initialize and customize all screens
                for (var i = 0; i < Screens.Count; i++)
                {
                    var screen = (BOSERPScreen)Screens[i];
                    screen.InitializeScreen(lstScreenInfo[i]);
                }
                //}
                //else
                //{
                //    //Tang het toc do co the
                //    List<Task> taskArray = new List<Task>();
                //    var begin = DateTime.Now;
                //    var screens = new Dictionary<string, BOSERPScreen>();
                //    foreach (var objStScreensInfo in lstScreenInfo)
                //    {
                //        taskArray.Add(GetScreen(objStScreensInfo.STScreenNumber, Name, screens));
                //    }
                //    Task.WaitAll(taskArray.ToArray());

                //    foreach (var objStScreensInfo in lstScreenInfo)
                //    {
                //        //scr.WindowState = FormWindowState.Minimized;
                //        var scr = screens[objStScreensInfo.STScreenNumber];
                //        scr.ScreenInfo = objStScreensInfo;
                //        scr.ScreenID = objStScreensInfo.STScreenID;
                //        scr.Name = objStScreensInfo.STScreenName;
                //        scr.Module = this;
                //        scr.Text = objStScreensInfo.STScreenText;
                //        Screens.Add(scr);
                //    }

                //    taskArray.Clear();
                //    for (var i = 0; i < Screens.Count; i++)
                //    {
                //        var screen = (BOSERPScreen)Screens[i];
                //        taskArray.Add(InitializeScreen(lstScreenInfo[i], screen));
                //    }
                //    Task.WaitAll(taskArray.ToArray());
                //    //MessageBox.Show("InitializeScreens:" + (DateTime.Now - begin).TotalMilliseconds);
                //}

                //Add controls of all screens to parent screen
                foreach (var bosScreen in Screens)
                {
                    var screen = (BOSERPScreen)bosScreen;
                    if (screen.ScreenInfo.STScreenPermissionType == Convert.ToByte(FieldPermissionType.None))
                        screen.AddControlsToParentScreen();
                }
            }
            dsScreens.Dispose();

            //Save User Audits
            //if (!IsBackgroundWorker())
            SaveUserAudit(cstUserAuditNothing);
        }
        private static Task InitializeScreen(STScreensInfo lstScreenInfo, BOSERPScreen screen)
        {
            var task = Task.Factory.StartNew(() =>
            {
                screen.InitializeScreen(lstScreenInfo);
            });
            return task;
        }
        private static Task GetScreen(string sreenNumber, string sreenName, Dictionary<string, BOSERPScreen> container)
        {
            var task = Task.Factory.StartNew(() =>
            {
                BOSERPScreen scr = BOSERPScreenFactory.GetScreen(sreenNumber, sreenName);
                container.Add(sreenNumber, scr);
            });
            return task;
        }
        /// <summary type="Initialize">
        ///     Initialize Screen by Screen Name and Screen Number
        /// </summary>
        /// <param name="objStScreensInfo"></param>
        /// <returns></returns>
        public BOSScreen InitializeScreen(STScreensInfo objStScreensInfo)
        {
            var scr = BOSERPScreenFactory.GetScreen(objStScreensInfo.STScreenNumber, Name);
            scr.Name = objStScreensInfo.STScreenName;
            scr.Module = this;
            scr.Text = objStScreensInfo.STScreenText;
            scr.InitializeScreen(objStScreensInfo);
            return scr;
        }

        public BOSScreen InitializeScreen(string strScreenName, string strScreenNumber)
        {
            var scr = BOSERPScreenFactory.GetScreen(strScreenNumber, Name);
            scr.Name = strScreenName;
            scr.Module = this;

            scr.InitializeScreen();
            return scr;
        }

        public BOSScreen InitializeScreen(string strScreenNumber)
        {
            if (ModuleID > 0 && BOSApp.CurrentUserGroupInfo.ADUserGroupID > 0)
            {
                var objStScreensInfo =
                    _objStScreensController.GetSTScreensByModuleIDAndUserGroupIDAndScreenNumber(ModuleID,
                        BOSApp.CurrentUserGroupInfo.ADUserGroupID, strScreenNumber);
                if (objStScreensInfo != null)
                    return InitializeScreen(objStScreensInfo.STScreenName, strScreenNumber);
            }
            return null;
        }

        #endregion

        #region Search and Invalidate after search functions

        /// <summary>
        ///     Search for all objects
        /// </summary>
        /// <param name="query">Query string for getting all objects</param>
        public virtual void SearchAll(string query)
        {
            if (CurrentModuleEntity.SearchObject == null)
            {
                SearchByQuery(query);
            }
            else
            {
                ResetSearch();

                var props =
                    CurrentModuleEntity.SearchObject.GetType()
                        .GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var prop in props)
                    if (prop.PropertyType == typeof(DateTime))
                        if (prop.Name.Contains("From"))
                            _dbUtil.SetPropertyValue(CurrentModuleEntity.SearchObject, prop.Name,
                                new DateTime(1987, 1, 1));
                        else if (prop.Name.Contains("To"))
                            _dbUtil.SetPropertyValue(CurrentModuleEntity.SearchObject, prop.Name, DateTime.MaxValue);
                Search();
                ParentScreen.ModuleUserCriteriaContainer.HidePopup();
                IsShowPopup = false;
            }
        }

        /// <summary>
        ///     Search by a query
        /// </summary>
        /// <param name="strQuery">Given query</param>
        public void SearchByQuery(string strQuery)
        {
            var dsSearchResults = GetSearchData(ref strQuery);
            Toolbar.SetToolbar(dsSearchResults);
            InvalidateAfterSearch(null, null);
            ParentScreen.ModuleUserCriteriaContainer.HidePopup();
            IsShowPopup = false;
        }

        public virtual void Search()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //Get Controller object of Main Object
                //Comment for not using
                //                String strMainObjectControllerName = BOSUtil.GetBusinessControllerNameFromBusinessObject(CurrentModuleEntity.MainObject);
                //                String strMainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
                //                BaseBusinessController objCurrentObjectController = BusinessControllerFactory.GetBusinessController(strMainObjectControllerName);
                Cursor.Current = Cursors.WaitCursor;

                var searchQuery = string.Empty;
                var ds = GetSearchData(ref searchQuery);
                Toolbar.SetToolbar(ds);
                InvalidateAfterSearch(null, string.Empty);
                Cursor.Current = Cursors.Default;

                //Create search criteria
                if (!string.IsNullOrEmpty(searchQuery))
                    if (!string.IsNullOrEmpty(SearchScreen.CriteriaName.Text))
                    {
                        var objAdCriteriasInfo = new ADCriteriasInfo
                        {
                            AACreatedUser = BOSApp.CurrentUser,
                            ADCriteriaName = SearchScreen.CriteriaName.Text,
                            FK_STModuleID = ModuleID,
                            ADCriteriaQueryString = searchQuery,
                            FK_ADUserID = BOSApp.CurrentUsersInfo.ADUserID,
                            ADCriteriaDesc = SearchScreen.CriteriaDescription.Text
                        };
                        _objCriteriasController.CreateObject(objAdCriteriasInfo);
                        ParentScreen.GridModuleUserCriteria.InitGridControlDataSource();
                    }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        /// <summary>
        ///     Get search data based on search criteria
        /// </summary>
        /// <param name="searchQuery">Get out search query generated from criteria</param>
        /// <returns>Search data</returns>
        protected virtual DataSet GetSearchData(ref string searchQuery)
        {
            var mainObjectControllerName =
                BOSUtil.GetBusinessControllerNameFromBusinessObject(CurrentModuleEntity.MainObject);
            var mainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
            if (string.IsNullOrEmpty(searchQuery))
                searchQuery = GenerateSearchQuery(mainObjectTableName); //GenerateGetTop(mainObjectTableName, 10); 

            var objCurrentObjectController = BusinessControllerFactory.GetBusinessController(mainObjectControllerName);
            var ds = objCurrentObjectController.GetDataSet(searchQuery);
            return ds;
        }

        /// <summary type="Invalidate">
        ///     Invalidate module after search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="strEventName"></param>
        /// <BOSparam name="SearchResultsControlName" type="String"></BOSparam>
        public virtual void InvalidateAfterSearch(object sender, string strEventName)
        {
            Cursor.Current = Cursors.WaitCursor;

            //Invalidate module by current object id
            //uthv comment do invalidate double
            //if (Toolbar.ObjectCollectionLength > 0 && !Toolbar.IsNewAction())
            //Invalidate(Toolbar.CurrentObjectID);

            //Binding data to search result control
            var searchResultControl =
                Controls.Values.Cast<Control>()
                    .FirstOrDefault(ctrl => (string)ctrl.Tag == BOSScreen.SearchResultControl);

            if (searchResultControl != null)
            {
                var control = searchResultControl as GridControl;
                if (control != null)
                {
                    BOSSearchResultsGridControl.BindingSearchResultGridControl(control,
                        Toolbar.ObjectCollection);
                }
                else if (searchResultControl is TreeList)
                {
                    var bosSearchResultsTreeListControl = searchResultControl as BOSSearchResultsTreeListControl;
                    bosSearchResultsTreeListControl?.BindingSearchResult(
                        Toolbar.ObjectCollection);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary type="Invalidate">
        ///     Invalidate Search Results Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="strEventName"></param>
        /// <BOSparam name="SearchResultsControlName" type="String"></BOSparam>
        public virtual void InvalidateSearchResultsControl(object sender, string strEventName)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var strMainTableName = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
                var mainTablePrimaryColumn = _dbUtil.GetTablePrimaryColumn(strMainTableName);
                var objMainObjectController =
                    BusinessControllerFactory.GetBusinessController(strMainTableName + "Controller");

                //Invalidate toolbar collection
                var strMainObjectTableName = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
                var iObjectId =
                    Convert.ToInt32(_dbUtil.GetPropertyValue(CurrentModuleEntity.MainObject,
                        SqlDatabaseHelper.GetPrimaryKeyColumn(strMainObjectTableName)));

                if (Toolbar.ObjectCollection == null)
                {
                    var ds = objMainObjectController.GetDataSetByID(iObjectId);
                    Toolbar.SetToolbar(ds);
                }
                else
                {
                    //if Toolbar.ModusAction is new, add new object to object collection of toolbar
                    if (Toolbar.ModusAction == BaseToolbar.ModusNew)
                    {
                        var newRow = Toolbar.ObjectCollection.Tables[0].NewRow();
                        newRow = objMainObjectController.GetDataRowFromBusinessObject(newRow,
                            CurrentModuleEntity.MainObject);
                        Toolbar.ObjectCollection.Tables[0].Rows.InsertAt(newRow, 0);
                        //uthv fix truong hop dang chon dong dau tien -> them moi -> khong goi invalidate
                        if (Toolbar.CurrentIndex == 0)
                        {
                            Invalidate(iObjectId);
                        }
                        Toolbar.CurrentIndex = 0;
                    }
                    else
                    {
                        //Update object in object collection of toolbar
                        var properties = CurrentModuleEntity.MainObject.GetType().GetProperties();
                        var iCurrIndex = Toolbar.CurrentIndex;
                        foreach (var t in properties)
                            if (Toolbar.ObjectCollection.Tables[0].Columns[t.Name] != null)
                                Toolbar.ObjectCollection.Tables[0].Rows[iCurrIndex][t.Name] =
                                    t.GetValue(CurrentModuleEntity.MainObject, null);
                    }
                }


                //Invalidate search result control                
                var searchResultControl =
                    Controls.Values.Cast<Control>()
                        .FirstOrDefault(ctrl => (string)ctrl.Tag == BOSScreen.SearchResultControl);

                if (searchResultControl != null)
                    if (searchResultControl is GridControl)
                    {
                        var gridControl = searchResultControl as BOSSearchResultsGridControl;
                        if (gridControl != null)
                        {
                            var gridView = gridControl.Views[0] as GridView;
                            if (gridControl.DataSource == null)
                                BOSSearchResultsGridControl.BindingSearchResultGridControl(gridControl,
                                    Toolbar.ObjectCollection);
                            gridControl.InvalidateLookupEditColumns();
                            if (gridView == null) return;
                            gridView.RefreshData();
                            gridView.FocusedRowHandle = gridView.GetRowHandle(Toolbar.CurrentIndex);
                        }
                    }
                    else if (searchResultControl is TreeList)
                    {
                        var treeListControl = searchResultControl as BOSSearchResultsTreeListControl;
                        if (treeListControl != null)
                        {
                            treeListControl.BindingSearchResult(Toolbar.ObjectCollection);
                            var node = treeListControl.FindNodeByFieldValue(mainTablePrimaryColumn,
                                Toolbar.CurrentObjectID);
                            treeListControl.SetFocusedNode(node);
                        }
                    }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        #region Search criteria functions

        /// <summary>
        ///     Show DropDownControl of button Criteria
        /// </summary>
        private void CreateCriteriaDropDownButton_ShowDropDownControl(object sender, ShowDropDownControlEventArgs e)
        {
            ModuleUserCriteriaContainer(e.DropDownControl);
        }

        /// <summary>
        ///     Show,hide PopupControlContainer
        /// </summary>
        public void ModuleUserCriteriaContainer(object obj)
        {
            if (IsShowPopup)
            {
                ((PopupControlContainer)obj).HidePopup();
                IsShowPopup = false;
            }
            else
            {
                ((PopupControlContainer)obj).Show();
                IsShowPopup = true;
            }
        }

        public void InitGridCotrolCriteria()
        {
            ParentScreen.GridModuleUserCriteria.Screen = (BOSERPScreen)GetDataMainScreen();
            ParentScreen.GridModuleUserCriteria.Screen.Module = this;
            ParentScreen.GridModuleUserCriteria.InitializeControl();
        }

        public void InvalidateModuleUserCriterias()
        {
            var criteriaList = _objCriteriasController.GetAllObjectByModuleAndUser(ModuleID,
                BOSApp.CurrentUsersInfo.ADUserID);
            ParentScreen.GridModuleUserCriteria.DataSource = criteriaList;
            ParentScreen.GridModuleUserCriteria.RefreshDataSource();
        }

        #endregion

        #endregion

        #endregion

        #region Public Functions

        #region Funtions to show,activate,close,hibernate module

        /// <summary type="Show">
        ///     Show Module
        /// </summary>
        public virtual void Show()
        {
            //First,show parent screen      
            //BOSProgressBar.Start(BaseLocalizedResources.InitModuleMessage);
            ParentScreen.ShowInTaskbar = false;
            ParentScreen.ModuleParentScreen_Init();
            if (BOSApp.OpenModules.ContainsKey(BOSApp.CurrentModule))
                ((BaseModuleERP)BOSApp.OpenModules[BOSApp.CurrentModule]).ParentScreen.WindowState = FormWindowState.Minimized;

            ParentScreen.Show();
            ParentScreen.Focus();
            //Invalidate module for additional adjustments
            ModuleAfterLoaded();
            ParentScreen.SearchContainer.Visibility = DockVisibility.AutoHide;
            //Hide inventory container, just show with transaction module            
            ParentScreen.InventoryContainer.Visibility = DockVisibility.Hidden;
            //Show search result panel
            ParentScreen.ShowSearchResultsPanel();
            if (ParentScreen.IsExistsGridSearchResult() && Toolbar.CurrentObjectID <= 0)
            {
                ResetSearch();
                if (ParentScreen.SearchQuickContainer.Controls.Count > 1)
                {
                    System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(QuickSearch));
                    thread.Start();
                }
                else
                    Search();
            }
            BOSProgressBar.Close();
        }

        public void ActivateDataMainScreen()
        {
            var guiDataMainScreen = (BOSERPScreen)GetDataMainScreen();
            ActivateScreen(guiDataMainScreen.ScreenNumber);
        }

        /// <summary>
        ///     Activate a screen
        /// </summary>
        /// <param name="screenNumber">Screen number</param>
        public void ActivateScreen(string screenNumber)
        {
            var page = ParentScreen.ScreenContainer.TabPages.FirstOrDefault(p => p.Name == screenNumber);
            if (page == null) return;
            ParentScreen.ScreenContainer.SelectedTabPage = page;
            var screen = Screens.FirstOrDefault(s => s.ScreenNumber == screenNumber);
            if (screen == null) return;
            ActiveScreen = screen;
            ((BOSERPScreen)ActiveScreen).Activate();
        }

        public override void ShowScreen(BOSScreen scr, bool bIsChild)
        {
            try
            {
                //Does not show screen if it has no permission or its sort order =-1
                var screen = (BOSERPScreen)scr;
                if (screen.ScreenInfo?.STScreenSortOrder < 0)
                    return;
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
                        screen.Location = new Point(screen.ScreenInfo.STScreenLocationX,
                            screen.ScreenInfo.STScreenLocationY);
                        screen.TopMost = screen.ScreenInfo.STScreenTopMost;
                        if (screen.ScreenInfo.STScreenShowModal)
                            screen.ShowDialog();
                        else
                            screen.Show();
                    }
                }
                else
                {
                    screen.Show();
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception e)
            {
                MessageBox.Show(GetType().FullName + ".ShowScreen:" + e.Message);
            }
        }

        /// <summary type="Close">
        ///     Close Module.Close all screens in module
        /// </summary>
        public void Close()
        {
            BeforeClose();
            //Remove Module in OpenModules
            BOSApp.MainScreen.OpenModulesToolStrip.Items.RemoveByKey(Name);
            BOSApp.RemoveOpenedModule(Name);
            if (BOSApp.CurrentUser != null)
                DeleteUserAudit(Name);

            //Active last open modules
            if (BOSApp.MainScreen.OpenModulesToolStrip.Items.Count <= 0) return;
            var index = BOSApp.MainScreen.OpenModulesToolStrip.Items.Count - 1;
            var strModuleName = BOSApp.MainScreen.OpenModulesToolStrip.Items[index].Name;
            BOSApp.ShowModule(strModuleName);

            AfterClose();
        }
        public virtual void BeforeClose()
        {

        }
        public virtual void AfterClose()
        {

        }
        /// <summary type="Show">
        ///     Show Sub Screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="strEventName"></param>
        /// <BOSparam name="DataSubScreenName" type="String"></BOSparam>
        public void ShowSubScreen(object sender, string strEventName)
        {
            if (Toolbar.CurrentObjectID > 0)
            {
                var strSubScreenNumber = GetBOSParameterValueFromFunctionNameAndParameterName(
                    sender, strEventName,
                    "ShowSubScreen", "DataSubScreenName");

                var scr = (BOSERPScreen)GetScreenByScreenNumber(strSubScreenNumber);
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
                MessageBox.Show(BaseLocalizedResources.ChooseObjectToEditMessage,
                    CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary type="Show">
        ///     Show Column Selector
        /// </summary>
        /// <param name="ctrlSearchResults">Search Results Control to show Column</param>
        /// <param name="showForm"></param>
        public void ShowColumnSelector(GridControl ctrlSearchResults, bool showForm)
        {
            if (showForm)
                ((GridView)ctrlSearchResults.ViewCollection[0]).ColumnsCustomization();
            else
                ((GridView)ctrlSearchResults.ViewCollection[0]).DestroyCustomization();
        }

        public virtual void ShowModule(string strModuleName, int id)
        {
            BOSApp.ShowModule(strModuleName, id);
        }

        public void GoNextScreen()
        {
            var index = Screens.IndexOf(ActiveScreen);
            if (index < 0) return;
            index++;
            if (index >= Screens.Count)
                index = 0;
            //Just active screen when screen is not data sub screen
            if (Toolbar.IsNullOrNoneAction())
                while (Screens[index].IsDataSubScreen())
                {
                    index++;
                    if (index >= Screens.Count)
                        index = 0;
                }
            else
                while (Screens[index].IsDataSubScreen() || Screens[index].IsSearchMainScreen())
                {
                    index++;
                    if (index >= Screens.Count)
                        index = 0;
                }
            ActiveScreen = Screens[index];
        }

        private int GetIndexOfCurrentScreen(string strScreenNumber, string[] arrScreenKeys)
        {
            for (var i = 0; i < arrScreenKeys.Length; i++)
                if (arrScreenKeys[i] == strScreenNumber)
                    return i;
            return -1;
        }

        public virtual void SetDisplaySearchScreen(bool bDisplay)
        {
            var searchScreen = (BOSERPScreen)GetSearchMainScreen();
            if (searchScreen != null)
                searchScreen.Visible = bDisplay;
        }

        #endregion

        #region Function for Set,Reset,Save Module Search Fields

        public virtual void ResetSearch()
        {
            if (CurrentModuleEntity.SearchObject != null)
                ResetSearchObject();
            else
                ResetSearchControls();

            //Reset Filter on Grid Search Result Control
            var strMainTable = BOSUtil.GetTableNameFromBusinessObject(CurrentModuleEntity.MainObject);
            var objGridSearchResultFieldsInfo =
                _stFieldsController.GetFirstFieldByModuleIDAndUserGroupIDAndFieldDataSourceAndFieldTypeAndFieldTag(
                    ModuleID, BOSApp.CurrentUserGroupInfo.ADUserGroupID,
                    strMainTable, "BOSGridControl", BOSScreen.SearchControl);
            if (objGridSearchResultFieldsInfo != null)
            {
                var gridControl = Controls[objGridSearchResultFieldsInfo.STFieldName] as GridControl;
                var gridView = gridControl.Views[0] as GridView;
                for (var i = 0; i < gridView.VisibleColumns.Count; i++)
                {
                    var strFieldName = gridView.VisibleColumns[i].FieldName;
                    gridView.Columns[strFieldName].FilterInfo = new ColumnFilterInfo();
                }
            }
        }

        public virtual void ResetSearchControls()
        {
            foreach (Control ctrl in SearchScreen.CriteriaSection.Controls)
            {
                var dataSource = _dbUtil.GetPropertyStringValue(ctrl, BOSScreen.cstDataSourcePropertyName);
                var dataMember = _dbUtil.GetPropertyStringValue(ctrl, BOSScreen.cstDataMemberPropertyName);
                if (dataMember == "TopResults")
                {
                    ctrl.Text = BOSApp.cstTopResults.ToString();
                }
                else
                {
                    if (ctrl.Enabled)
                        if (ctrl is DateEdit)
                        {
                            if (ctrl.Name.Contains("SearchFrom"))
                                (ctrl as DateEdit).DateTime = DateTime.Now.AddDays(-15);
                            else if (ctrl.Name.Contains("SearchTo"))
                                (ctrl as DateEdit).DateTime = DateTime.Now;
                            else
                                (ctrl as DateEdit).EditValue = string.Empty;
                        }
                        else if (ctrl is LookUpEdit)
                        {
                            var strDataType = _dbUtil.GetColumnDataType(dataSource, dataMember);
                            if (strDataType == "int" || strDataType == "float")
                                (ctrl as LookUpEdit).EditValue = 0;
                            else
                                (ctrl as LookUpEdit).EditValue = string.Empty;
                        }
                        else if (ctrl is TextEdit)
                        {
                            (ctrl as TextEdit).EditValue = string.Empty;
                        }
                        else if (ctrl is ComboBoxEdit)
                        {
                            (ctrl as ComboBoxEdit).SelectedIndex = -1;
                        }
                }
            }
        }

        public virtual void ResetSearchObject()
        {
            var props =
                CurrentModuleEntity.SearchObject.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props)
                if (prop.PropertyType == typeof(string))
                    _dbUtil.SetPropertyValue(CurrentModuleEntity.SearchObject, prop.Name, string.Empty);
                else if (prop.PropertyType == typeof(int))
                    _dbUtil.SetPropertyValue(CurrentModuleEntity.SearchObject, prop.Name, 0);
                else if (prop.PropertyType == typeof(DateTime))
                    if (prop.Name.Contains("From"))
                        _dbUtil.SetPropertyValue(CurrentModuleEntity.SearchObject, prop.Name, DateTime.Now.AddDays(-15));
                    else if (prop.Name.Contains("To"))
                        _dbUtil.SetPropertyValue(CurrentModuleEntity.SearchObject, prop.Name, DateTime.Now);
            CurrentModuleEntity.UpdateSearchObjectBindingSource();
        }

        /// <summary>
        ///     Called when the module has been loaded,
        ///     give a chance to add handling
        /// </summary>
        public virtual void ModuleAfterLoaded()
        {
            //Add extra controls for data screens such as asterisk, search button...
            foreach (var bosScreen in Screens)
            {
                var scr = (BOSERPScreen)bosScreen;
                if (scr.IsDataMainScreen())
                    foreach (XtraTabPage page in ParentScreen.ScreenContainer.TabPages)
                        if (page.Name == scr.ScreenNumber)
                        {
                            scr.AddExtraControls(page.Controls);
                            break;
                        }
            }

            //Reset focus
            ResetFocus();
        }

        #endregion

        #endregion

        #region Functions to Get Screen of Module

        /// <summary>
        ///     Get Data Main Screen
        /// </summary>
        /// <returns></returns>
        public BOSScreen GetDataMainScreen()
        {
            var guiDataMainScreen = new BOSERPScreen();
            foreach (var t in Screens)
            {
                var strScreenNumber = t.ScreenNumber;
                if (!strScreenNumber.StartsWith("DM") || !strScreenNumber.EndsWith("100")) continue;
                guiDataMainScreen = (BOSERPScreen)t;
                break;
            }
            return guiDataMainScreen;
        }

        public void SetScreentoForegroundByScreenName(string strScreenName)
        {
            foreach (var t in Screens)
                if (strScreenName == t.Name)
                {
                    var guiScreen = (BOSERPScreen)t;
                    guiScreen.Activate();
                }
        }

        /// <summary type="GetScreen">
        ///     Get Main Search Screen of Module
        /// </summary>
        /// <returns>Main Search Screen</returns>
        public BOSScreen GetSearchMainScreen()
        {
            BOSScreen guiSearchMainScreen = new BOSERPScreen();
            foreach (var t in Screens)
            {
                var strScreenNumber = t.ScreenNumber;
                if (!strScreenNumber.StartsWith("SM")) continue;
                guiSearchMainScreen = (BOSERPScreen)t;
                break;
            }
            return guiSearchMainScreen;
        }

        /// <summary type="GetScreen">
        ///     Get Data Main Screen of Module
        /// </summary>
        /// <BOSparam name="DataMainScreenNumber" type="String"></BOSparam>
        /// <returns>Data Main Screen</returns>
        public BOSERPScreen GetDataMainScreen(object sender, string strEventName)
        {
            var strDataMainScreenNumber = GetBOSParameterValueFromFunctionNameAndParameterName(
                sender, strEventName,
                "GetDataMainScreen", "DataMainScreenNumber");
            var scr = (BOSERPScreen)GetScreenByScreenNumber(strDataMainScreenNumber);
            if (scr != null) return scr;
            foreach (var t in Screens)
            {
                var strScreenNumber = t.ScreenNumber;
                if (strScreenNumber.StartsWith("DM") && strScreenNumber.EndsWith("100"))
                    scr = (BOSERPScreen)t;
            }
            return scr;
        }

        /// <summary type="GetScreen">
        ///     Get Data Sub Screen of module
        /// </summary>
        /// <returns>Data Sub Screen</returns>
        public BOSScreen GetDataSubScreen()
        {
            var guiDataSubScreen = new BOSERPScreen();
            foreach (var t in Screens)
                if (t.ScreenNumber.StartsWith("DS"))
                {
                    guiDataSubScreen = (BOSERPScreen)t;
                    break;
                }
            return guiDataSubScreen;
        }

        /// <summary type="GetScreen">
        ///     Get Search Results Screen of Module
        /// </summary>
        /// <returns>Search Result Screen</returns>
        public BOSScreen GetSearchResultScreen()
        {
            var guiSearchResultsScreen = new BOSERPScreen();
            foreach (var t in Screens)
                if (t.ScreenNumber.StartsWith("SR"))
                {
                    guiSearchResultsScreen = (BOSERPScreen)t;
                    break;
                }
            return guiSearchResultsScreen;
        }

        #endregion

        #region Functions for Control of Module

        public void FocusRowOfGridSearchResultByToolbarCurrentIndex()
        {
            var screen = GetSearchMainScreen();
            var objFieldsInfo =
                screen?.Fields?.FirstOrDefault(f => f.Value.STFieldType == typeof(BOSSearchResultsGridControl).Name &&
                                                    f.Value.STFieldTag == "SR").Value;
            if (objFieldsInfo == null || !Controls.Contains(objFieldsInfo.STFieldName)) return;
            var gridControl = (GridControl)Controls[objFieldsInfo.STFieldName];
            var gridView = (GridView)gridControl.MainView;
            gridView.FocusedRowHandle = gridView.GetRowHandle(Toolbar.CurrentIndex);
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="strEventName"></param>
        /// <BOSparam name="DisplaySearchResultsControlName" type="String"></BOSparam>
        public void ShowSearchResults(object sender, string strEventName)
        {
            var strControlName = GetBOSParameterValueFromFunctionNameAndParameterName(
                sender, strEventName,
                "ShowSearchResults", "DisplaySearchResultsControlName");
            if (Controls[strControlName] != null)
                Controls[strControlName].Text = Toolbar.ObjectCollectionLength.ToString();
        }


        public void RefreshGridControl(string strGridControlDataSource)
        {
            var objGridControlFieldsInfo = _stFieldsController
                .GetFirstFieldByModuleIDAndUserGroupIDAndFieldDataSourceAndFieldTypeAndFieldTag(
                    ModuleID, BOSApp.CurrentUserGroupInfo.ADUserGroupID, strGridControlDataSource, "BOSGridControl",
                    BOSScreen.DataControl);
            if (objGridControlFieldsInfo == null) return;
            var gridControl = Controls[objGridControlFieldsInfo.STFieldName] as GridControl;
            var gridView = gridControl.Views[0] as GridView;
            gridView.RefreshData();
        }

        #region Functions of invalidating controls after doing action

        public void InvalidateFieldGroupControls(string strAction)
        {
            switch (strAction)
            {
                case BaseToolbar.ModusNew:
                    EnableFieldGroupControls(BOSScreen.cstFieldGroupNonEditable, true);
                    EnableFieldGroupControls(BOSScreen.cstFieldGroupAction, true);
                    EnableFieldGroupControls(BOSScreen.cstFieldGroupNonAction, false);

                    EnableSearchMainScreens(false);
                    break;
                case BaseToolbar.ModusEdit:
                    EnableFieldGroupControls(BOSScreen.cstFieldGroupNonCreatable, true);
                    EnableFieldGroupControls(BOSScreen.cstFieldGroupAction, true);
                    EnableFieldGroupControls(BOSScreen.cstFieldGroupNonAction, false);

                    EnableSearchMainScreens(false);
                    break;
                case BaseToolbar.ModusNone:
                    EnableFieldGroupControls(BOSScreen.cstFieldGroupNonCreatable, false);
                    EnableFieldGroupControls(BOSScreen.cstFieldGroupNonEditable, false);
                    EnableFieldGroupControls(BOSScreen.cstFieldGroupAction, false);
                    EnableFieldGroupControls(BOSScreen.cstFieldGroupNonAction, true);

                    EnableSearchMainScreens(true);
                    break;
            }
        }

        public void EnableFieldGroupControls(string strGroup, bool enable)
        {
            if (!FieldGroupControls.ContainsKey(strGroup)) return;
            foreach (Control ctrl in FieldGroupControls[strGroup].Values)
                ctrl.Enabled = enable;
        }

        public void DisplayFieldGroupControls(string strGroup, bool visible)
        {
            if (FieldGroupControls.ContainsKey(strGroup))
                foreach (Control ctrl in FieldGroupControls[strGroup].Values)
                    ctrl.Visible = visible;
        }

        public void EnableSearchMainScreens(bool enable)
        {
            foreach (var screen in Screens)
                if (screen.IsSearchMainScreen())
                    screen.Enabled = enable;
        }

        #endregion

        #region Get Parameter Value

        /// <summary type="GetParameterValue">
        ///     Get Parameter Value of Module Function by Function Full Name,Function Class and Parameter Name
        /// </summary>
        /// <param name="strModuleFunctionFullName"></param>
        /// <param name="strModuleFunctionClass"></param>
        /// <param name="strModuleFunctionParameterName"></param>
        /// <returns></returns>
        public string GetModuleFunctionParameterValue(string strModuleFunctionFullName, string strModuleFunctionClass,
            string strModuleFunctionParameterName)
        {
            var strModuleFunctionParameterValue = string.Empty;


            //Get Module Function
            var objStModuleFunctionsInfo =
                _objStModuleFunctionsController
                    .GetModuleFunctionByModuleIDAndModuleFunctionFullNameAndModuleFunctionClass(ModuleID,
                        strModuleFunctionFullName, strModuleFunctionClass);
            if (objStModuleFunctionsInfo == null) return strModuleFunctionParameterValue;
            //Get Module Function Parameter
            var objStModuleFunctionParametersInfo =
                _objStModuleFunctionParametersController
                    .GetModuleFunctionParameterByModuleFunctionIDAndModuleFunctionParameterName(
                        objStModuleFunctionsInfo.STModuleFunctionID, strModuleFunctionParameterName);
            if (objStModuleFunctionParametersInfo == null) return strModuleFunctionParameterValue;
            //Get Module Function Parameter Value
            var objStModuleFunctionParameterValuesInfo =
                _stModuleFunctionParameterValuesController
                    .GetModuleFunctionParameterValueByModuleFunctionParameterIDAndUserGroupID(
                        objStModuleFunctionParametersInfo.STModuleFunctionParameterID,
                        BOSApp.CurrentUserGroupInfo.ADUserGroupID);
            if (objStModuleFunctionParameterValuesInfo != null)
                strModuleFunctionParameterValue =
                    objStModuleFunctionParameterValuesInfo.STModuleFunctionParameterValue;

            return strModuleFunctionParameterValue;
        }

        /// <summary type="GetParameterValue">
        ///     Get BOS Parameter Value
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="strEventName"></param>
        /// <param name="strFieldEventFunctionFullName"></param>
        /// <param name="strFieldEventFunctionClass"></param>
        /// <param name="strFieldEventFunctionParameterName"></param>
        /// <returns></returns>
        public string GetBOSParameterValue(Control ctrl, string strEventName, string strFieldEventFunctionFullName,
            string strFieldEventFunctionClass, string strFieldEventFunctionParameterName)
        {
            var strParameterValue = string.Empty;
            //If Get Parameter Value from Field Event Function
            if (ctrl != null && !string.IsNullOrEmpty(strEventName))
            {
                var boserpScreen = (BOSERPScreen)ctrl.FindForm();
                if (boserpScreen == null) return strParameterValue;
                var iScreenId = boserpScreen.ScreenID;
                if (iScreenId <= 0) return strParameterValue;
                var objStFieldsInfo = _stFieldsController.GetFieldByFieldNameAndScreenIDAndUserGroupID(
                    ctrl.Name, iScreenId, BOSApp.CurrentUserGroupInfo.ADUserGroupID);
                if (objStFieldsInfo == null) return strParameterValue;
                var objStFieldEventsInfo =
                    _stFieldEventsController.GetFieldEventByFieldIDAndEventName(objStFieldsInfo.STFieldID,
                        strEventName);
                if (objStFieldEventsInfo == null) return strParameterValue;
                var objStFieldEventFunctionsInfo =
                    _stFieldEventFunctionsController
                        .GetFieldEventFunctionByFieldEventIDAndFunctionFullNameAndFunctionClass(
                            objStFieldEventsInfo.STFieldEventID,
                            strFieldEventFunctionFullName,
                            strFieldEventFunctionClass);
                if (objStFieldEventFunctionsInfo == null) return strParameterValue;
                var objStFieldEventFunctionParametersInfo =
                    _stFieldEventFunctionParametersController
                        .GetFieldEventFunctionParameterByFieldEventIDAndFieldEventFunctionParameterName(
                            objStFieldEventFunctionsInfo.STFieldEventFunctionID,
                            strFieldEventFunctionParameterName);
                if (objStFieldEventFunctionParametersInfo != null)
                    strParameterValue =
                        objStFieldEventFunctionParametersInfo.STFieldEventFunctionParameterValue;
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
        ///     Get BOS Parameter Value with object sender is Bar Manager
        /// </summary>
        /// <param name="barManager"></param>
        /// <param name="strEventName"></param>
        /// <param name="strFieldEventFunctionFullName"></param>
        /// <param name="strFieldEventFunctionClass"></param>
        /// <param name="strFieldEventFunctionParameterName"></param>
        /// <returns></returns>
        public string GetBOSParameterValue(BarManager barManager, string strEventName,
            string strFieldEventFunctionFullName, string strFieldEventFunctionClass,
            string strFieldEventFunctionParameterName)
        {
            var strParameterValue = string.Empty;
            //If Get Parameter Value from Field Event Function
            if (barManager != null && !string.IsNullOrEmpty(strEventName))
                if (barManager.Form.GetType() == typeof(ModuleParentScreen))
                {
                    var strToolbarTag = barManager.PressedLink.Item.Tag.ToString();
                    var strToolbarGroup = barManager.PressedLink.Item.Hint;

                    var objStToolbarsInfo =
                        _stToolbarsController.GetSTToolbarsBySTModuleIDAndSTUserGroupIDAndSTToolbarGroupAndSTToolbarTag(
                            ModuleID, BOSApp.CurrentUserGroupInfo.ADUserGroupID, strToolbarGroup, strToolbarTag);
                    var objStToolbarFunctionsInfo =
                        _stToolbarFunctionsController.GetToolbarFunctionByToolbarIDAndFunctionFullNameAndFunctionClass(
                            objStToolbarsInfo.STToolbarID, strFieldEventFunctionFullName, strFieldEventFunctionClass);
                    if (objStToolbarFunctionsInfo == null) return strParameterValue;
                    var objStToolbarFunctionParametersInfo =
                        _stToolbarFunctionParametersController
                            .GetToolbarFunctionParameterByToolbarIDAndToolbarFunctionParameterName(
                                objStToolbarFunctionsInfo.STToolbarFunctionID, strFieldEventFunctionParameterName);
                    if (objStToolbarFunctionParametersInfo != null)
                        strParameterValue = objStToolbarFunctionParametersInfo.STToolbarFunctionParameterValue;
                }
                //if is toolbar of sub screen
                else
                {
                    var iScreenId = _objStScreensController.GetScreenIDByModuleIDAndUserGroupIDAndScreenName(
                        ModuleID, BOSApp.CurrentUserGroupInfo.ADUserGroupID, barManager.Form.Name);
                    if (iScreenId <= 0) return strParameterValue;
                    var objStFieldsInfo =
                        _stFieldsController.GetFieldByFieldNameAndScreenIDAndUserGroupID(
                            barManager.PressedLink.Item.Name, iScreenId, BOSApp.CurrentUserGroupInfo.ADUserGroupID);
                    if (objStFieldsInfo == null) return strParameterValue;
                    var objStFieldEventsInfo =
                        _stFieldEventsController.GetFieldEventByFieldIDAndEventName(
                            objStFieldsInfo.STFieldID, strEventName);
                    if (objStFieldEventsInfo == null) return strParameterValue;
                    var objStFieldEventFunctionsInfo =
                        _stFieldEventFunctionsController
                            .GetFieldEventFunctionByFieldEventIDAndFunctionFullNameAndFunctionClass(
                                objStFieldEventsInfo.STFieldEventID, strFieldEventFunctionFullName,
                                strFieldEventFunctionClass);
                    if (objStFieldEventFunctionsInfo == null) return strParameterValue;
                    var objStFieldEventFunctionParametersInfo =
                        _stFieldEventFunctionParametersController
                            .GetFieldEventFunctionParameterByFieldEventIDAndFieldEventFunctionParameterName
                            (objStFieldEventFunctionsInfo.STFieldEventFunctionID,
                                strFieldEventFunctionParameterName);
                    if (objStFieldEventFunctionParametersInfo != null)
                        strParameterValue =
                            objStFieldEventFunctionParametersInfo.STFieldEventFunctionParameterValue;
                }
            //if get parameter value from module function
            else
                strParameterValue = GetModuleFunctionParameterValue(strFieldEventFunctionFullName,
                    strFieldEventFunctionClass, strFieldEventFunctionParameterName);

            return strParameterValue;
        }

        /// <summary>
        ///     Get BOS Paramter Value by object sender,Event Name,FieldEventFunction Full Name,Field Event Function Class And
        ///     Field Event Function Parameter Name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="strEventName"></param>
        /// <param name="strFieldEventFunctionFullName"></param>
        /// <param name="strFieldEventFunctionClass"></param>
        /// <param name="strFieldEventFunctionParameterName"></param>
        /// <returns></returns>
        public string GetBOSParameterValue(object sender, string strEventName, string strFieldEventFunctionFullName,
            string strFieldEventFunctionClass, string strFieldEventFunctionParameterName)
        {
            if (sender != null)
                if (sender.GetType() == typeof(BarManager))
                    return GetBOSParameterValue((BarManager)sender, strEventName, strFieldEventFunctionFullName,
                        strFieldEventFunctionClass, strFieldEventFunctionParameterName);
                else
                    return GetBOSParameterValue((Control)sender, strEventName, strFieldEventFunctionFullName,
                        strFieldEventFunctionClass, strFieldEventFunctionParameterName);
            return GetModuleFunctionParameterValue(strFieldEventFunctionFullName, strFieldEventFunctionClass,
                strFieldEventFunctionParameterName);
        }


        public string GetBOSParameterValueFromFunctionNameAndParameterName(
            object sender, string strEventName,
            string strFunctionName, string strParameterName)
        {
            var method = GetMethodInfoByMethodNameAndParametersType(
                strFunctionName,
                new Type[2] { typeof(object), typeof(string) });
            var strParameterValue = GetBOSParameterValue(
                sender,
                strEventName,
                method.ToString(),
                method.DeclaringType.ToString(),
                strParameterName);
            return strParameterValue;
        }

        #endregion

        #region Functions for User Audits, Object History

        public bool ObjectIsEditingByOtherUser(string strModuleName, int iObjectId)
        {
            if (iObjectId <= 0) return false;
            var objGeUserAuditsInfo = _objGeUserAuditsController.GetGEUserAuditsByModuleNameAndParameterAndAction(
                strModuleName,
                iObjectId.ToString(),
                BaseToolbar.ModusEdit);
            if (objGeUserAuditsInfo == null) return false;
            var strEditUser = objGeUserAuditsInfo.ADUserName;
            MessageBox.Show(
                string.Format(BaseLocalizedResources.ObjectHasBeenLockedMessage, strEditUser.ToUpper()),
                CommonLocalizedResources.MessageBoxDefaultCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            return true;
        }

        public void SaveUserAudit(string strUserAction)
        {
            //Get ADUserID            
            var iAdUserId = _objAdUsersController.GetObjectIDByName(BOSApp.CurrentUser);

            //Get GEUserAuditsInfo Object
            var objGeUserAuditsInfo = new GEUserAuditsInfo
            {
                ADUserID = iAdUserId,
                ADUserName = BOSApp.CurrentUser,
                GEUserAuditModuleName = Name,
                GEUserAuditBeginDate = DateTime.Now,
                GEUserAuditAction = strUserAction
            };
            if (strUserAction.Equals(cstUserAuditEdit))
                objGeUserAuditsInfo.GEUserAuditParameter = Toolbar.CurrentObjectID.ToString();

            //check if is exist user in user audit-->update, else add
            var objCurrentAdUserAuditsInfo = _objGeUserAuditsController.GetGEUserAuditsByADUserIDAndModuleName(
                iAdUserId, Name);

            if (objCurrentAdUserAuditsInfo != null)
            {
                objGeUserAuditsInfo.GEUserAuditID = objCurrentAdUserAuditsInfo.GEUserAuditID;

                _objGeUserAuditsController.UpdateObject(objGeUserAuditsInfo);
            }
            else
            {
                _objGeUserAuditsController.CreateObject(objGeUserAuditsInfo);
            }
        }

        public void DeleteUserAudit()
        {
            var iAdUserId = _objAdUsersController.GetObjectIDByName(BOSApp.CurrentUser);
            _objGeUserAuditsController.DeleteGEUserAuditsByADUserID(iAdUserId);
        }

        public void DeleteUserAudit(string strModuleName)
        {
            var iAdUserId = _objAdUsersController.GetObjectIDByName(BOSApp.CurrentUser);
            _objGeUserAuditsController.DeleteGEUserAuditsByADUserIDAndModuleName(iAdUserId, Name);
        }

        public virtual int SaveObjectHistory(string strUserAction, int iObjectId)
        {
            var iAdUserId = _objAdUsersController.GetObjectIDByName(BOSApp.CurrentUser);
            var strMainObjecControllerName =
                BOSUtil.GetBusinessControllerNameFromBusinessObject(CurrentModuleEntity.MainObject);
            var objController = BusinessControllerFactory.GetBusinessController(strMainObjecControllerName);

            //int iAANumberInt = objController.GetAANumberIntByID(iObjectID);
            var strObjectNo = objController.GetObjectNoByID(iObjectId);
            //Get Object History Info
            var objGeObjectHistoryInfo = new GEObjectHistoryInfo
            {
                ADUserID = iAdUserId,
                ADUserName = BOSApp.CurrentUser,
                GEObjectHistoryAction = strUserAction,
                GEObjectHistoryObjectID = iObjectId,
                GEObjectHistoryObjectName = Name,
                GEObjectHistoryObjectNumber = strObjectNo,
                GEObjectHistoryDate = DateTime.Now
            };
            _geObjHistoryCtrl.CreateObject(objGeObjectHistoryInfo);
            return objGeObjectHistoryInfo.GEObjectHistoryID;
        }

        #endregion

        #endregion

        #endregion

        #region Method for get Method Info

        /// <summary>
        ///     GetAssembly Name From Method Class
        /// </summary>
        /// <functiontype>Get Method</functiontype>
        /// <returns></returns>
        public override string GetAssemblyName()
        {
            return "CHC.EMR";
        }

        public override Type GetClassType(string strClassName)
        {
            return BaseClassFactory.GetClassType(strClassName);
        }

        #endregion

        #region Utilities

        /// <summary>
        ///     Get lookup tables through BOSApp
        /// </summary>
        /// <returns></returns>
        public SortedList GetLookupTableCollection()
        {
            return BOSApp.LookupTables;
        }

        /// <summary>
        ///     Get the last created/updated date of all lookup tables through BOSApp
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


        public void GetLookupTableByName(string tableName)
        {
            BOSApp.InitLookupByTable(tableName);
        }

        /// <summary>
        ///     Get the id of current user group that the logging-in user belongs to
        /// </summary>
        /// <returns>User group id</returns>
        public int GetCurrentUserGroupID()
        {
            return BOSApp.CurrentUserGroupInfo.ADUserGroupID;
        }
        public int GetCurrentUserID()
        {
            return BOSApp.CurrentUsersInfo.ADUserID;
        }
        public bool UserIsAdmin()
        {
            return BOSApp.CurrentUserGroupInfo.ADUserGroupRole == UserGroupRole.admin.ToString();
        }
        /// <summary>
        ///     Get data of a lookup table
        /// </summary>
        /// <param name="lookupTableName">Lookup table name</param>
        /// <returns>Data of the lookup table</returns>
        public DataSet GetLookupTableData(string lookupTableName)
        {
            return BOSApp.GetLookupTableData(lookupTableName);
        }

        /// <summary>
        /// UtHV 24032017 
        /// </summary>
        /// <param name="lookupTableName"></param>
        public DataSet InitLookupByTable(string lookupTableName)
        {
            return BOSApp.InitLookupByTable(lookupTableName);
        }

        #endregion

        #region Accounting        

        #endregion

        public virtual void QuickSearch()
        {
            //uthv chua viet ham dung chung, chi moi overide dung cho module MEEmrModule
        }

        #region Workflow
        public virtual void TriggerWorkflow(object sender, string eventName, object toolbar)
        {
            if (_workflowClient == null)
            {
                MessageBox.Show("Tính năng bị giới hạn, Có thể do không kết nối được đến máy chủ EMR API", "Tính năng bị giới hạn", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            var action = toolbar as STToolbarsInfo;
            var parentBar = _stToolbarsController.GetObjectByID(action.STToolbarParentID) as STToolbarsInfo;
            if (parentBar == null)
            {
                MessageBox.Show("Cấu hình thanh công cụ sai. Vui lòng kiểm tra cấu hình", "Cấu hình sai", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            var workflowName = parentBar.STToolbarTag;
            var objectName = parentBar.STToolbarPrivilege;

            var entity = CurrentModuleEntity;
            BusinessObject businessObject = GetWorkflowBusinessObject(objectName);
            bool isMainObj = string.IsNullOrEmpty(objectName);
            if (businessObject == null)
            {
                MessageBox.Show("Không tìm thấy đối tượng xử lý hoặc giá trị đối tượng = null. Vui lòng kiểm tra cấu hình", "Không tìm thấy đối tượng cần xử lý", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            objectName = BOSUtil.GetTableNameFromBusinessObject(businessObject);

            // get extra parammeter from sp
            var bussinessCtrl = BusinessControllerFactory.GetBusinessController(objectName + "Controller");
            var tablePrimaryCol = _dbUtil.GetTablePrimaryColumn(objectName);
            var objectId = Convert.ToInt32(_dbUtil.GetPropertyValue(businessObject, tablePrimaryCol));

            Dictionary<string, object> poolParams = GetWorkflowPoolParams(action.STToolbarTag, workflowName, objectName, businessObject, bussinessCtrl, objectId);
            var inputParams = poolParams.Where(p => p.Key.StartsWith("?")).Select(p => new MEParamsInfo()
            {
                MEParamNo = p.Key.TrimStart('?'),
                MEParamCaption = p.Value.ToString(),
                MEParamValue = string.Empty,
            }).ToArray();

            if (inputParams.Length > 0)
            {
                if (inputParams.Length == 1)
                {
                    var lblTitle = inputParams.FirstOrDefault().MEParamCaption;
                    var gui = new guiGetOneStrNoCondition(lblTitle);
                    if (gui.ShowDialog() != DialogResult.OK) return;
                    var gEObjectHistoryRemark = gui.Value ?? string.Empty;
                    foreach (var item in inputParams)
                    {
                        poolParams.Remove("?" + item.MEParamNo);
                        poolParams.Add(item.MEParamNo, gEObjectHistoryRemark);
                        item.MEParamValue = gEObjectHistoryRemark;
                    }
                }
                else
                {
                    var gui = new guiInputWorkflowParam(inputParams) { Module = this };
                    if (gui.ShowDialog() == DialogResult.OK)
                    {
                        foreach (var item in inputParams)
                        {
                            poolParams.Remove("?" + item.MEParamNo);
                            poolParams.Add(item.MEParamNo, item.MEParamValue);
                            item.MEParamValue = item.MEParamValue;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            InvokeResult result = null;
            try
            {
                result = _workflowClient.Invoke(workflowName, poolParams);
            }
            catch (Emr.Base.Models.Abp.UserFriendlyException ex)
            {
                MessageBox.Show($"Có lỗi khi gọi API Workflow. Chi tiết lỗi: \n" +
                    $"{ex.Code}: {ex.Message} \n {ex.Details}",
                    "Thông báo lỗi từ API Workflow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(result.ErrorCode))
            {
                MessageBox.Show($"Có lỗi khi gọi Workflow. Chi tiết lỗi: \n" +
                    $"{result.ErrorCode}: {result.Message}",
                    "Thông báo lỗi từ Workflow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // mac dinh sau khi trigger wf se luu data vao db tru khi wf cau hinh ko luu
            if (result.IsPersistent)
            {
                var strColumnNo = objectName.Substring(0, objectName.Length - 1) + "No";
                businessObject.AllowPropertyChangedEvent = false;
                _dbUtil.SetPropertyValue(businessObject, "AAUpdatedUser", BOSApp.CurrentUser);

                var history = new GEObjectHistoryInfo
                {
                    ADUserID = BOSApp.CurrentUsersInfo.ADUserID,
                    ADUserName = BOSApp.CurrentUser,
                    GEObjectHistoryAction = action.STToolbarTag,
                    GEObjectHistoryObjectID = objectId,
                    GEObjectHistoryObjectName = objectName,
                    GEObjectHistoryObjectNumber = string.Empty,
                    GEObjectHistoryDate = DateTime.Now,
                    FK_HREmployeeFromID = BOSApp.CurrentEmployeesInfo.HREmployeeID,
                    FK_HRDepartmentFromID = BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID,
                };

                foreach (var p in result)
                {
                    if (p.Key.StartsWith("_")) continue;
                    // khong cho phep cap nhat ColumnNo
                    if (p.Key.Equals(strColumnNo)) continue;
                    _dbUtil.SetPropertyValue(businessObject, p.Key, p.Value);
                    _dbUtil.SetPropertyValue(history, p.Key, p.Value);
                }
                bussinessCtrl.UpdateObject(businessObject);
                businessObject.AllowPropertyChangedEvent = true;

                var remark = string.Empty;
                foreach (var item in inputParams)
                {
                    if (string.IsNullOrEmpty(item.MEParamValue)) continue;
                    remark += string.IsNullOrEmpty(remark) ? item.MEParamValue : "; " + item.MEParamValue;
                }
                history.GEObjectHistoryRemark = remark;
                _geObjHistoryCtrl.CreateObject(history);

                foreach (var item in inputParams)
                {
                    if (string.IsNullOrEmpty(item.MEParamValue)) continue;
                    var historyDetail = new GEHistoryDetailsInfo
                    {
                        FK_GEObjectHistoryID = history.GEObjectHistoryID,
                        GEHistoryDetailTableName = objectName,// "GEObjectHistory",
                        GEHistoryDetailColumnName = item.MEParamNo,// "GEObjectHistoryRemark",
                        GEHistoryDetailNewValue = item.MEParamValue,
                        GEHistoryDetailParentID = 0,
                        IsApproved = false
                    };
                    _geHistoryCtrl.CreateObject(historyDetail);
                }

                if (isMainObj)
                {
                    entity.InvalidateMainObject(objectId);
                    BeforeInvalidateSearchResultsControl();
                    InvalidateSearchResultsControl(null, string.Empty);
                }
                else
                {
                    entity.InvalidateModuleObject(businessObject);
                }
            }
            else
            {
                foreach (var p in result)
                {
                    if (p.Key.StartsWith("_")) continue;
                    _dbUtil.SetPropertyValue(businessObject, p.Key, p.Value);
                }
            }

            MessageBox.Show(string.IsNullOrEmpty(result.Message) ? $"Đã xử lý" : result.Message, "Đã xử lý dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public virtual void TriggerWorkflowMulti(object sender, string eventName, object toolbar)
        {
            if (_workflowClient == null)
            {
                MessageBox.Show("Tính năng bị giới hạn, Có thể do không kết nối được đến máy chủ EMR API", "Tính năng bị giới hạn", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            var action = toolbar as STToolbarsInfo;
            var parentBar = _stToolbarsController.GetObjectByID(action.STToolbarParentID) as STToolbarsInfo;
            if (parentBar == null)
            {
                MessageBox.Show("Cấu hình thanh công cụ sai. Vui lòng kiểm tra cấu hình", "Cấu hình sai", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            var workflowName = parentBar.STToolbarTag;
            var objectName = parentBar.STToolbarPrivilege;

            BusinessObject businessObject = GetWorkflowBusinessObject(objectName);
            if (businessObject == null)
            {
                MessageBox.Show("Không tìm thấy đối tượng xử lý hoặc giá trị đối tượng = null. Vui lòng kiểm tra cấu hình", "Không tìm thấy đối tượng cần xử lý", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            objectName = BOSUtil.GetTableNameFromBusinessObject(businessObject);

            var bussinessCtrl = BusinessControllerFactory.GetBusinessController(objectName + "Controller");
            var tablePrimaryCol = _dbUtil.GetTablePrimaryColumn(objectName);
            var objectId = Convert.ToInt32(_dbUtil.GetPropertyValue(businessObject, tablePrimaryCol));

            Dictionary<string, object> poolParams = GetWorkflowPoolParams(action.STToolbarTag, workflowName, objectName, businessObject, bussinessCtrl, objectId);
            var inputParams = poolParams.Where(p => p.Key.StartsWith("?")).Select(p => new MEParamsInfo()
            {
                MEParamNo = p.Key.TrimStart('?'),
                MEParamCaption = p.Value.ToString(),
                MEParamValue = string.Empty,
            }).ToArray();

            if (inputParams.Length > 0)
            {
                foreach (var item in inputParams)
                {
                    poolParams.Remove("?" + item.MEParamNo);
                    poolParams.Add(item.MEParamNo, item.MEParamValue);
                    item.MEParamValue = item.MEParamValue;
                }
            }

            InvokeResult result = null;
            try
            {
                result = _workflowClient.Invoke(workflowName, poolParams);
            }
            catch (Emr.Base.Models.Abp.UserFriendlyException ex)
            {
                MessageBox.Show($"Có lỗi khi gọi API Workflow. Chi tiết lỗi: \n" +
                    $"{ex.Code}: {ex.Message} \n {ex.Details}",
                    "Thông báo lỗi từ API Workflow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(result.ErrorCode))
            {
                MessageBox.Show($"Có lỗi khi gọi Workflow. Chi tiết lỗi: \n" +
                    $"{result.ErrorCode}: {result.Message}",
                    "Thông báo lỗi từ Workflow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (result.IsPersistent)
            {
                var strColumnNo = objectName.Substring(0, objectName.Length - 1) + "No";
                businessObject.AllowPropertyChangedEvent = false;
                _dbUtil.SetPropertyValue(businessObject, "AAUpdatedUser", BOSApp.CurrentUser);

                var history = new GEObjectHistoryInfo
                {
                    ADUserID = BOSApp.CurrentUsersInfo.ADUserID,
                    ADUserName = BOSApp.CurrentUser,
                    GEObjectHistoryAction = action.STToolbarTag,
                    GEObjectHistoryObjectID = objectId,
                    GEObjectHistoryObjectName = objectName,
                    GEObjectHistoryObjectNumber = string.Empty,
                    GEObjectHistoryDate = DateTime.Now,
                    FK_HREmployeeFromID = BOSApp.CurrentEmployeesInfo.HREmployeeID,
                    FK_HRDepartmentFromID = BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID,
                };

                foreach (var p in result)
                {
                    if (p.Key.StartsWith("_")) continue;
                    if (p.Key.Equals(strColumnNo)) continue;
                    _dbUtil.SetPropertyValue(businessObject, p.Key, p.Value);
                    _dbUtil.SetPropertyValue(history, p.Key, p.Value);
                }
                bussinessCtrl.UpdateObject(businessObject);
                businessObject.AllowPropertyChangedEvent = true;

                var remark = string.Empty;
                foreach (var item in inputParams)
                {
                    if (string.IsNullOrEmpty(item.MEParamValue)) continue;
                    remark += string.IsNullOrEmpty(remark) ? item.MEParamValue : ";" + item.MEParamValue;
                }
                history.GEObjectHistoryRemark = remark;
                _geObjHistoryCtrl.CreateObject(history);

                foreach (var item in inputParams)
                {
                    if (string.IsNullOrEmpty(item.MEParamValue)) continue;
                    var historyDetail = new GEHistoryDetailsInfo
                    {
                        FK_GEObjectHistoryID = history.GEObjectHistoryID,
                        GEHistoryDetailTableName = "GEObjectHistory",
                        GEHistoryDetailColumnName = "GEObjectHistoryRemark",
                        GEHistoryDetailNewValue = item.MEParamValue,
                        GEHistoryDetailParentID = 0,
                        IsApproved = false
                    };
                    _geHistoryCtrl.CreateObject(historyDetail);
                }
            }
            else
            {
                foreach (var p in result)
                {
                    if (p.Key.StartsWith("_")) continue;
                    _dbUtil.SetPropertyValue(businessObject, p.Key, p.Value);
                }
            }
        }

        private BusinessObject GetWorkflowBusinessObject(string objectName)
        {
            var entity = CurrentModuleEntity;

            if (string.IsNullOrEmpty(objectName))
            {
                return entity.MainObject;
            }
            else
            {
                if (entity.ModuleObjects[objectName] != null)
                    return entity.ModuleObjects[objectName];
            }
            return null;
        }
        private Dictionary<string, object> GetWorkflowPoolParams(string action, string workflowName, string objectName, BusinessObject businessObject, BaseBusinessController bussinessCtrl, int objectId)
        {
            var poolParams = businessObject
                             .GetType()
                             .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                             .Where(p => !p.PropertyType.IsClass || p.PropertyType == typeof(String))
                             .ToDictionary(prop => prop.Name, prop => prop.GetValue(businessObject, null));

            object[] paramList = new object[] {
                    objectName,
                    objectId,
                    action,
                    BOSApp.CurrentUsersInfo.ADUserID,
                    BOSApp.CurrentUsersInfo.ADUserGroupID,
                    BOSApp.CurrentEmployeesInfo.HREmployeeID,
                    BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID
                };
            poolParams.Add("_Action", action);
            poolParams.Add("_ADUserID", BOSApp.CurrentUsersInfo.ADUserID);
            poolParams.Add("_ADUserGroupID", BOSApp.CurrentUsersInfo.ADUserGroupID);
            poolParams.Add("_HREmployeeID", BOSApp.CurrentEmployeesInfo.HREmployeeID);
            poolParams.Add("_HRDepartmentID", BOSApp.CurrentEmployeesInfo.FK_HRDepartmentID);

            var ds = bussinessCtrl.GetDataSet($"{objectName}_{workflowName}_GetWorkflowParams", paramList);
            if (ds.Tables.Count > 0)
            {
                var tb = ds.Tables[0];
                if (tb.Rows.Count > 0)
                {
                    var extraParams = tb.Columns.Cast<DataColumn>().ToDictionary(c => c.ColumnName, c => tb.Rows[0][c]);
                    foreach (var item in extraParams)
                    {
                        if (poolParams.ContainsKey(item.Key))
                            poolParams[item.Key] = item.Value;
                        else
                            poolParams.Add(item.Key, item.Value);
                    }
                }
            }

            return poolParams;
        }
        public virtual void InvalidateWorkflowToolbar(string objectName = "")
        {
            if (_workflowClient == null) return;
            var groupToolbars = ParentScreen.GetWorkflowParentToolbarsInfo(objectName);
            if (groupToolbars.Count == 0) return;

            var entity = CurrentModuleEntity;
            BusinessObject businessObject = GetWorkflowBusinessObject(objectName);
            bool isMainObj = string.IsNullOrEmpty(objectName);
            if (businessObject == null)
                return;

            objectName = BOSUtil.GetTableNameFromBusinessObject(businessObject);

            foreach (var group in groupToolbars)
            {
                var workflowName = group.STToolbarTag;
                // get extra parammeter from sp
                var bussinessCtrl = BusinessControllerFactory.GetBusinessController(objectName + "Controller");
                var tablePrimaryCol = _dbUtil.GetTablePrimaryColumn(objectName);
                var objectId = Convert.ToInt32(_dbUtil.GetPropertyValue(businessObject, tablePrimaryCol));

                Dictionary<string, object> poolParams = GetWorkflowPoolParams("CheckAllowActions", workflowName, objectName, businessObject, bussinessCtrl, objectId);

                var actions = ParentScreen.GetChildrentToolbarsInfo(group.STToolbarID);
                foreach (var item in actions)
                {
                    ParentScreen.SetEnableOfToolbarButton(item.STToolbarTag, false);
                }
                try
                {
                    string[] allowActions;
                    if (_workflowLocal != null)
                        allowActions = _workflowLocal.GetAllowActions(workflowName, poolParams);
                    else
                        allowActions = _workflowClient.GetAllowActions(workflowName, poolParams);
                    // allowActions = null tat ca cac button se bi disable luon
                    if (allowActions == null) return;
                    foreach (var action in allowActions)
                    {
                        ParentScreen.SetEnableOfToolbarButton(action, true);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi khi gọi Workflow. Chi tiết lỗi: \n {ex.ToString()}", "Có lỗi khi gọi Workflow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }

        public virtual bool InvalidateWorkflow(object toolbar)
        {
            if (_workflowClient == null)
            {
                MessageBox.Show("Tính năng bị giới hạn, Có thể do không kết nối được đến máy chủ EMR API", "Tính năng bị giới hạn", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            var action = toolbar as STToolbarsInfo;
            var parentBar = _stToolbarsController.GetObjectByID(action.STToolbarParentID) as STToolbarsInfo;
            if (parentBar == null)
            {
                MessageBox.Show("Cấu hình thanh công cụ sai. Vui lòng kiểm tra cấu hình", "Cấu hình sai", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            var workflowName = parentBar.STToolbarTag;
            var objectName = parentBar.STToolbarPrivilege;

            BusinessObject businessObject = GetWorkflowBusinessObject(objectName);
            if (businessObject == null)
            {
                MessageBox.Show("Không tìm thấy đối tượng xử lý hoặc giá trị đối tượng = null. Vui lòng kiểm tra cấu hình", "Không tìm thấy đối tượng cần xử lý", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            objectName = BOSUtil.GetTableNameFromBusinessObject(businessObject);

            // get extra parammeter from sp
            var bussinessCtrl = BusinessControllerFactory.GetBusinessController(objectName + "Controller");
            var tablePrimaryCol = _dbUtil.GetTablePrimaryColumn(objectName);
            var objectId = Convert.ToInt32(_dbUtil.GetPropertyValue(businessObject, tablePrimaryCol));

            Dictionary<string, object> poolParams = GetWorkflowPoolParams("CheckAllowActions", workflowName, objectName, businessObject, bussinessCtrl, objectId);

            try
            {
                var allowActions = _workflowLocal != null ? _workflowLocal.GetAllowActions(workflowName, poolParams) : _workflowClient.GetAllowActions(workflowName, poolParams);
                var isAllow = false;
                if (allowActions != null)
                {
                    foreach (var x in allowActions)
                    {
                        if (action.STToolbarTag == x)
                        {
                            isAllow = true;
                        }
                    }
                }
                return isAllow;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi gọi Workflow. Chi tiết lỗi: \n {ex.ToString()}", "Có lỗi khi gọi Workflow", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        protected virtual void BeforeInvalidateSearchResultsControl()
        {

        }
        #endregion

        #region Object State Permission
        public string GetStatePermiQueryConditionStr(string tableName, bool hasTablePrefix = true)
        {
            var viewStatePerms = BOSApp.GetObjectStatePermisions(tableName, ObjectStatePermissionAction.View);
            if (viewStatePerms == null) return string.Empty;
            var stateConds = new StringBuilder();
            var tbPrefix = hasTablePrefix ? $"[{tableName}]." : string.Empty;
            foreach (var perm in viewStatePerms)
            {
                stateConds.Append($" AND {tbPrefix}[{perm.Key}] IN ('{ string.Join("', '", perm.Value)}')");
                stateConds.AppendLine();
            }
            return stateConds.ToString();
        }
        /// <summary>
        /// cau hinh editable theo nhom nguoi dung
        /// </summary>
        /// <param name="businessObject"></param>
        /// <returns></returns>
        protected virtual bool IsAllowEdit(BusinessObject businessObject)
        {
            return IsAllowAction(businessObject, ObjectStatePermissionAction.Edit);
        }
        protected virtual bool IsAllowDelete(BusinessObject businessObject)
        {
            return IsAllowAction(businessObject, ObjectStatePermissionAction.Delete);
        }
        protected virtual bool IsAllowAction(BusinessObject businessObject, ObjectStatePermissionAction action)
        {
            if (businessObject == null) return false;
            var objectName = BOSUtil.GetTableNameFromBusinessObject(businessObject);
            var statePerms = BOSApp.GetObjectStatePermisions(objectName, action);
            if (statePerms == null) return true;
            var type = businessObject.GetType();
            foreach (var col in statePerms)
            {
                var value = type.GetProperty(col.Key, BindingFlags.Instance | BindingFlags.Public).GetValue(businessObject, null);
                if (value != null && !col.Value.Contains(value.ToString()))
                {
                    return false;
                }
            }
            return true;
        }
        protected virtual bool IsStatePermission(BusinessObject businessObject)
        {
            if (businessObject == null) return false;

            var objectName = BOSUtil.GetTableNameFromBusinessObject(businessObject);
            var objectStatePermisions = BOSApp.ObjectStatePermisions;
            if (objectStatePermisions == null) return false;

            if (!objectStatePermisions.ContainsKey(objectName)) return false;

            return true;
        }
        #endregion

        public ADUserGroupsInfo[] ShowUserGroupSelections()
        {
            var gui = new guiSelectUserGroups()
            {
                Module = this,
                StartPosition = FormStartPosition.CenterParent
            };
            if (gui.ShowDialog() == DialogResult.OK)
            {
                return gui.Selections.ToArray();
            }
            return null;
        }
    }
}