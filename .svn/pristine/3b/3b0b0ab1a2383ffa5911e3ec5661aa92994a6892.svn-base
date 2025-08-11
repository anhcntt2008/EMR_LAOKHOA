using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BOSComponent;
using BOSLib;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Localization;
using RepositoryItem = DevExpress.XtraEditors.Repository.RepositoryItem;

namespace BOSERP
{

    public partial class BOSSearchResultsGridControl : GridControl, ICloneable, IBOSControl
    {
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        ///     Customize columns of BOSGridSearchResultsControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NavigatorButton_Click(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
                if (e.Button.Tag.ToString() == "CustomizeColumn")
                    CustomizeColumnGridSearchResults();
                else if (e.Button.Tag.ToString() == "SaveColumnCustomization")
                    SaveCustomizeColumnGridSearchResults(e.Button.Tag.ToString());
        }

        /// <summary type="Customize">
        ///     Customize Column on Search Results Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="strEventName"></param>
        /// <BOSparam name="SearchResultsControlName" type="String"></BOSparam>
        private void CustomizeColumnGridSearchResults()
        {
            ((GridView)MainView).ColumnsCustomization();
        }

        /// <summary type="Save">
        ///     Save customize column of Search Results Control
        /// </summary>
        /// <BOSparam name="SearchResultsControlName" type="String"></BOSparam>
        private void SaveCustomizeColumnGridSearchResults(string tag)
        {
            var module = ((IBaseModuleERP)Screen.Module);
            if (tag != "SaveColumnCustomizationForGroups")
            {
                var userGroupID = 0;
                var userId = 0;

                if (tag == "SaveColumnCustomization")
                {
                    userGroupID = module.GetCurrentUserGroupID();
                    userId = module.GetCurrentUserID();
                }

                _objFieldColumnsController.DeleteGridSearchResultColsByIDStringAndUser(_sTFieldColumnsIdStr, userGroupID, userId);
                foreach (GridColumn gridColumn in ((GridView)MainView).Columns)
                    if (gridColumn.Visible)
                    {
                        var col = new STFieldColumnsInfo
                        {
                            STFieldColumnName = gridColumn.Name,
                            STFieldColumnFieldName = gridColumn.FieldName,
                            STFieldColumnCaption = gridColumn.Caption,
                            STFieldColumnWidth = gridColumn.Width,
                            STFieldID = 0,
                            STFieldColumnIDString = _sTFieldColumnsIdStr,
                            STFieldColumnVisibleIndex = gridColumn.VisibleIndex,
                            FK_ADUserGroupID = userGroupID,
                            FK_ADUserID = userId
                        };
                        _objFieldColumnsController.CreateObject(col);
                    }

                MessageBox.Show(ComponentLocalizedResources.SaveSuccessfully,
                       CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var userGroups = module.ShowUserGroupSelections();
                if (userGroups != null && userGroups.Length > 0)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        foreach (var group in userGroups)
                        {
                            _objFieldColumnsController.DeleteGridSearchResultColsByIDStringAndUser(_sTFieldColumnsIdStr, group.ADUserGroupID, 0);
                        }
                        foreach (GridColumn gridColumn in ((GridView)MainView).Columns)
                            if (gridColumn.Visible)
                            {
                                foreach (var group in userGroups)
                                {
                                    var col = new STFieldColumnsInfo
                                    {
                                        STFieldColumnName = gridColumn.Name,
                                        STFieldColumnFieldName = gridColumn.FieldName,
                                        STFieldColumnCaption = gridColumn.Caption,
                                        STFieldColumnWidth = gridColumn.Width,
                                        STFieldID = 0,
                                        STFieldColumnIDString = _sTFieldColumnsIdStr,
                                        STFieldColumnVisibleIndex = gridColumn.VisibleIndex,
                                        FK_ADUserGroupID = group.ADUserGroupID,
                                        FK_ADUserID = 0
                                    };
                                    _objFieldColumnsController.CreateObject(col);
                                }
                            }
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show(ComponentLocalizedResources.SaveSuccessfully,
                            CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
        }

        /// <summary>
        ///     Invalidate lookup edit columns to reflect all changes of lookup table
        /// </summary>
        public virtual void InvalidateLookupEditColumns()
        {
            var gridView = (GridView)MainView;
            foreach (GridColumn column in gridView.Columns)
                if (column.ColumnEdit != null && column.ColumnEdit is RepositoryItemLookUpEdit)
                {

                    var rep = (RepositoryItemLookUpEdit)column.ColumnEdit;
                    var strLookupTable = _dbUtil.GetPrimaryTableWhichForeignColumnReferenceTo(BOSDataSource,
                        column.FieldName);
                    if (!string.IsNullOrEmpty(strLookupTable))
                    {
                        var dsTemp = (DataSet)BOSApp.LookupTables[strLookupTable];
                        var primaryKey = SqlDatabaseHelper.GetPrimaryKeyColumn(strLookupTable);
                        var maxKeyVal = 0;
                        if (dsTemp.Tables.Count > 0)
                        {
                            if (dsTemp.Tables[0].Rows.Count > 0)
                            {
                                if (dsTemp.Tables[0].Columns.Contains(primaryKey))
                                {
                                    var keyVal = dsTemp.Tables[0].Compute($"MAX([{primaryKey}])", "");
                                    if (double.TryParse(keyVal.ToString(), out _)
)
                                    {
                                        maxKeyVal = (int)keyVal;
                                    }
                                }
                            }
                        }
                        var dtLastModifyDate = _dbUtil.GetDateMofifyOfTableByMaxId(strLookupTable, primaryKey, maxKeyVal);
                        if (dtLastModifyDate.CompareTo((DateTime)BOSApp.LookupTablesUpdatedDate[strLookupTable]) > 0)
                        {
                            //Refesh Data Source
                            var objLookupTableController =
                                BusinessControllerFactory.GetBusinessController(strLookupTable + "Controller");
                            if (objLookupTableController != null)
                            {
                                //var ds = objLookupTableController.GetAllObjects();
                                DataSet ds = ((IBaseModuleERP)Screen.Module).GetLookupTableData(strLookupTable);
                                if (ds.Tables.Count > 0)
                                {
                                    // Update Last Updated Date of Lookup Table
                                    BOSApp.LookupTablesUpdatedDate[strLookupTable] = DateTime.Now;
                                    ((DataSet)BOSApp.LookupTables[strLookupTable]).Tables.Clear();
                                    ((DataSet)BOSApp.LookupTables[strLookupTable]).Tables.Add(ds.Tables[0].Copy());
                                }
                            }
                        }

                        rep.DataSource = ((DataSet)BOSApp.LookupTables[strLookupTable]).Tables[0];
                    }
                }
        }

        #region Variables

        protected BOSScreen _screen;
        protected string _BOSDataSource;
        protected string _BOSDataMember;
        protected string _BOSPropertyName;
        protected string _BOSFieldGroup;
        protected string _BOSFieldRelation;
        protected string _BOSComment;
        protected string _BOSError;
        protected string _BOSPrivilege;
        protected string _BOSDescription;

        #endregion

        #region Public Properties

        [Category("Design")]
        [Browsable(true)]
        public new string Name
        {
            get { return base.Name; }

            set { base.Name = value; }
        }

        public BOSScreen Screen
        {
            get { return _screen; }
            set { _screen = value; }
        }

        [Category("BOS")]
        public string BOSDataSource
        {
            get { return _BOSDataSource; }
            set { _BOSDataSource = value; }
        }

        [Category("BOS")]
        public string BOSDataMember
        {
            get { return _BOSDataMember; }
            set { _BOSDataMember = value; }
        }

        [Category("BOS")]
        public string BOSPropertyName
        {
            get { return _BOSPropertyName; }
            set { _BOSPropertyName = value; }
        }

        [Category("BOS")]
        public string BOSFieldGroup
        {
            get { return _BOSFieldGroup; }
            set { _BOSFieldGroup = value; }
        }

        [Category("BOS")]
        public string BOSFieldRelation
        {
            get { return _BOSFieldRelation; }
            set { _BOSFieldRelation = value; }
        }

        [Category("BOS")]
        public string BOSComment
        {
            get { return _BOSComment; }
            set { _BOSComment = value; }
        }

        [Category("BOS")]
        public string BOSError
        {
            get { return _BOSError; }
            set { _BOSError = value; }
        }

        [Category("BOS")]
        public string BOSPrivilege
        {
            get { return _BOSPrivilege; }
            set { _BOSPrivilege = value; }
        }

        [Category("BOS")]
        public string BOSDescription
        {
            get { return _BOSDescription; }
            set { _BOSDescription = value; }
        }

        #endregion

        #region Constructors

        private readonly BOSDbUtil _dbUtil;
        private readonly STFieldColumnsController _objFieldColumnsController;
        private string _sTFieldColumnsIdStr = "GridSearchResults-Mod-";
        public BOSSearchResultsGridControl()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            _dbUtil = new BOSDbUtil();
            _objFieldColumnsController = new STFieldColumnsController();
        }

        public BOSSearchResultsGridControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            _dbUtil = new BOSDbUtil();
            _objFieldColumnsController = new STFieldColumnsController();
        }

        #endregion

        #region Function Init Search Result GridControl

        public void InitializeControl(STFieldsInfo objFieldInfo)
        {
        }

        public void InitializeControl()
        {
            var dgvSearchResults = InitializeSearchResultsGridView();
            ViewCollection.Add(dgvSearchResults);
            MainView = dgvSearchResults;
            dgvSearchResults.GridControl = this;
            MouseDoubleClick += GridControlSearchResults_MouseDoubleClick;
            KeyUp += ((IBaseModuleERP)Screen.Module).Control_KeyUp;

            //Using embedded Navigator
            UseEmbeddedNavigator = true;
            EmbeddedNavigator.Name = "navigator_" + Name;
            var customizeColumnButton = new NavigatorCustomButton(8, BaseLocalizedResources.CustomizeColumn);
            customizeColumnButton.Tag = "CustomizeColumn";
            var saveColumnCustomizationButton = new NavigatorCustomButton(9,
                BaseLocalizedResources.SaveColumnCustomization);
            saveColumnCustomizationButton.Tag = "SaveColumnCustomization";
            EmbeddedNavigator.Buttons.CustomButtons.AddRange(new[]
            {
                customizeColumnButton,
                saveColumnCustomizationButton
            });
            EmbeddedNavigator.Buttons.Remove.Visible = false;
            EmbeddedNavigator.Buttons.Edit.Visible = false;
            EmbeddedNavigator.Buttons.Append.Visible = false;

            //Add events to navigator buttons
            EmbeddedNavigator.ButtonClick += NavigatorButton_Click;
        }

        protected virtual GridView InitializeSearchResultsGridView()
        {
            var dgvSearchResults = new GridView
            {
                Name = "fld_dgv" + Name.Substring(7)
            };
            dgvSearchResults.OptionsSelection.EnableAppearanceFocusedCell = false;
            dgvSearchResults.OptionsSelection.EnableAppearanceFocusedRow = true;
            dgvSearchResults.OptionsView.ColumnAutoWidth = false;
            dgvSearchResults.OptionsCustomization.AllowFilter = true;
            dgvSearchResults.OptionsView.ShowAutoFilterRow = true;
            dgvSearchResults.OptionsView.ShowGroupPanel = false;
            dgvSearchResults.OptionsView.ShowIndicator = false;

            dgvSearchResults.FocusedRowChanged += GridViewSearchResults_FocusedRowChanged;
            dgvSearchResults.RowClick += GridViewSearchResults_RowClick;
            dgvSearchResults.KeyUp += GridViewSearchResults_KeyUp;
            dgvSearchResults.CustomDrawCell += GridViewSearchResults_CustomDrawCell;
            dgvSearchResults.OptionsBehavior.Editable = false;
            dgvSearchResults.DataSourceChanged += GridViewSearchResults_DataSourceChanged;
            AddColumnsToGridViewResults(dgvSearchResults, BOSDataSource);

            _sTFieldColumnsIdStr = _sTFieldColumnsIdStr + Screen.Module.Name;

            InitGridViewVisibleIndex(dgvSearchResults, Screen.Module.Name, BOSDataSource);

            dgvSearchResults.PopupMenuShowing += gridView_PopupMenuShowing;
            if (BOSCommon.Devide.Current == BOSCommon.Devide.Tablet)
            {
                dgvSearchResults.RowHeight = 35;
            }
            return dgvSearchResults;
        }
        protected virtual void AddColumnsToGridViewResults(GridView gridView, string tableName)
        {
            gridView.Columns.Clear();
            var objAAColumnAliasController = new AAColumnAliasController();
            var dsColumns = objAAColumnAliasController.GetAAColumnAliasByTableName(tableName);
            if (dsColumns.Tables[0].Rows.Count > 0)
                foreach (DataRow rowColumn in dsColumns.Tables[0].Rows)
                {
                    var objAAColumnAliasInfo =
                        (AAColumnAliasInfo)objAAColumnAliasController.GetObjectFromDataRow(rowColumn);
                    if (objAAColumnAliasInfo != null)
                    {
                        var col = new GridColumn
                        {
                            Name = "col" + objAAColumnAliasInfo.AAColumnAliasName,
                            FieldName = objAAColumnAliasInfo.AAColumnAliasName,
                            Caption = objAAColumnAliasInfo.AAColumnAliasCaption,
                            Width = 100,
                            VisibleIndex = -1
                        };

                        if (_dbUtil.IsForeignKey(tableName, objAAColumnAliasInfo.AAColumnAliasName))
                        {
                            var repLookupEdit = InitColumnLookupEdit(tableName, objAAColumnAliasInfo.AAColumnAliasName,
                                    objAAColumnAliasInfo.AAColumnAliasCaption);
                            if (repLookupEdit != null)
                                col.ColumnEdit = repLookupEdit;
                        }
                        else
                        {
                            var strConfigValueTable = string.Empty;
                            if (objAAColumnAliasInfo.AAColumnAliasName.EndsWith("Combo"))
                                strConfigValueTable = objAAColumnAliasInfo.AAColumnAliasName.Substring(2,
                                    objAAColumnAliasInfo.AAColumnAliasName.Length - 7);
                            else
                                strConfigValueTable = objAAColumnAliasInfo.AAColumnAliasName.Substring(2,
                                    objAAColumnAliasInfo.AAColumnAliasName.Length - 2);

                            if (ADConfigValueUtility.ConfigValues.Tables[strConfigValueTable] != null)
                            {
                                var repLookupEdit = new RepositoryItemLookUpEdit();

                                repLookupEdit.DataSource = ADConfigValueUtility.ConfigValues.Tables[strConfigValueTable];
                                repLookupEdit.ValueMember = "Value";
                                repLookupEdit.DisplayMember = "Text";
                                repLookupEdit.ShowHeader = false;
                                var repColumn = new LookUpColumnInfo();
                                repColumn.FieldName = "Text";
                                repColumn.Width = 100;
                                repLookupEdit.Columns.Add(repColumn);
                                repLookupEdit.PopupWidth = repColumn.Width;
                                col.ColumnEdit = repLookupEdit;
                            }
                            else
                            {
                                //Init column repository based on field format group
                                col.ColumnEdit = InitColumnRepositoryFromFieldFormatGroup(tableName,
                                    objAAColumnAliasInfo.AAColumnAliasName);
                            }
                        }

                        if (col.ColumnEdit != null)
                            InitColumnRepositoryFormat(col, tableName, objAAColumnAliasInfo.AAColumnAliasName);
                        else
                            InitColumnFormat(col, tableName, objAAColumnAliasInfo.AAColumnAliasName);

                        gridView.Columns.Add(col);
                    }
                }
            else
                AddDefaultColumnsToGridView(gridView, tableName);
        }

        /// <summary>
        ///     Add default columns to grid view
        /// </summary>
        /// <param name="gridView">Grid view needs to be added columns</param>
        /// <param name="tableName">Table name of the grid view's data source</param>
        protected virtual void AddDefaultColumnsToGridView(GridView gridView, string tableName)
        {
        }

        public RepositoryItem InitColumnRepositoryFromFieldFormatGroup(string strTableName, string strColumnName)
        {
            var objFieldFormatGroupsController = new STFieldFormatGroupsController();
            var objFieldFormatGroupsInfo =
                objFieldFormatGroupsController.GetFieldFormatGroupByTableNameAndColumnName(strTableName, strColumnName);
            if (objFieldFormatGroupsInfo != null)
                if (!string.IsNullOrEmpty(objFieldFormatGroupsInfo.STFieldFormatGroupRepository))
                    return BOSUtil.GetRepositoryItemFromText(objFieldFormatGroupsInfo.STFieldFormatGroupRepository);
            return null;
        }

        public void InitColumnRepositoryFormat(GridColumn column, string strTableName, string strColumnName)
        {
            var objFieldFormatGroupsController = new STFieldFormatGroupsController();
            var objFieldFormatGroupsInfo =
                objFieldFormatGroupsController.GetFieldFormatGroupByTableNameAndColumnName(strTableName, strColumnName);
            if (objFieldFormatGroupsInfo != null)
            {
                var rep = column.ColumnEdit;
                if (objFieldFormatGroupsInfo.STFieldFormatGroupBackColor > 0)
                {
                    rep.Appearance.BackColor = Color.FromArgb(objFieldFormatGroupsInfo.STFieldFormatGroupBackColor);
                    rep.Appearance.Options.UseBackColor = true;
                }
                if (objFieldFormatGroupsInfo.STFieldFormatGroupForeColor > 0)
                {
                    rep.Appearance.ForeColor = Color.FromArgb(objFieldFormatGroupsInfo.STFieldFormatGroupForeColor);
                    rep.Appearance.Options.UseForeColor = true;
                }

                var strDefaultFontName = "Tahoma";
                var fDefaultFontSize = 8.25F;
                if (!string.IsNullOrEmpty(objFieldFormatGroupsInfo.STFieldFormatGroupFontName))
                    strDefaultFontName = objFieldFormatGroupsInfo.STFieldFormatGroupFontName;
                if (objFieldFormatGroupsInfo.STFieldFormatGroupFontSize > 0)
                    fDefaultFontSize = objFieldFormatGroupsInfo.STFieldFormatGroupFontSize;
                rep.Appearance.Font = new Font(strDefaultFontName, fDefaultFontSize);
                rep.Appearance.Options.UseFont = true;

                if (BOSUtil.IsEditRepository(rep))
                {
                    var repText = (RepositoryItemTextEdit)rep;
                    if (objFieldFormatGroupsInfo.STFieldFormatGroupDecimalRound > 0)
                    {
                        repText.Mask.MaskType = MaskType.Numeric;
                        repText.Mask.EditMask = string.Format("n{0}",
                            objFieldFormatGroupsInfo.STFieldFormatGroupDecimalRound);
                        repText.Mask.UseMaskAsDisplayFormat = true;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(objFieldFormatGroupsInfo.STFieldFormatGroupMaskType))
                        {
                            repText.Mask.MaskType =
                                BOSUtil.GetMaskTypeFromText(objFieldFormatGroupsInfo.STFieldFormatGroupMaskType);
                            repText.Mask.EditMask = objFieldFormatGroupsInfo.STFieldFormatGroupMaskEdit;
                            repText.Mask.UseMaskAsDisplayFormat = true;
                        }
                        if (!string.IsNullOrEmpty(objFieldFormatGroupsInfo.STFieldFormatGroupFormatType))
                        {
                            repText.DisplayFormat.FormatType =
                                BOSUtil.GetFormatTypeFromText(objFieldFormatGroupsInfo.STFieldFormatGroupFormatType);
                            repText.DisplayFormat.FormatString = objFieldFormatGroupsInfo.STFieldFormatGroupFormatString;
                        }
                    }
                }
            }
        }

        public void InitColumnFormat(GridColumn column, string strTableName, string strColumnName)
        {
            var objFieldFormatGroupsController = new STFieldFormatGroupsController();
            var objFieldFormatGroupsInfo =
                objFieldFormatGroupsController.GetFieldFormatGroupByTableNameAndColumnName(strTableName, strColumnName);
            if (objFieldFormatGroupsInfo != null)
            {
                if (objFieldFormatGroupsInfo.STFieldFormatGroupBackColor > 0)
                {
                    column.AppearanceCell.BackColor =
                        Color.FromArgb(objFieldFormatGroupsInfo.STFieldFormatGroupBackColor);
                    column.AppearanceCell.Options.UseBackColor = true;
                }
                if (objFieldFormatGroupsInfo.STFieldFormatGroupForeColor > 0)
                {
                    column.AppearanceCell.ForeColor =
                        Color.FromArgb(objFieldFormatGroupsInfo.STFieldFormatGroupForeColor);
                    column.AppearanceCell.Options.UseForeColor = true;
                }

                var strDefaultFontName = "Tahoma";
                var fDefaultFontSize = 8.25F;
                if (!string.IsNullOrEmpty(objFieldFormatGroupsInfo.STFieldFormatGroupFontName))
                    strDefaultFontName = objFieldFormatGroupsInfo.STFieldFormatGroupFontName;
                if (objFieldFormatGroupsInfo.STFieldFormatGroupFontSize > 0)
                    fDefaultFontSize = objFieldFormatGroupsInfo.STFieldFormatGroupFontSize;
                column.AppearanceCell.Font = new Font(strDefaultFontName, fDefaultFontSize);
                column.AppearanceCell.Options.UseFont = true;

                if (objFieldFormatGroupsInfo.STFieldFormatGroupDecimalRound > 0)
                {
                    column.ColumnEdit = BOSUtil.GetRepositoryItemFromText("RepositoryItemTextEdit");
                    InitColumnRepositoryFormat(column, strTableName, strColumnName);
                }
                else
                {
                    if (!string.IsNullOrEmpty(objFieldFormatGroupsInfo.STFieldFormatGroupFormatType))
                    {
                        column.DisplayFormat.FormatType =
                            BOSUtil.GetFormatTypeFromText(objFieldFormatGroupsInfo.STFieldFormatGroupFormatType);
                        column.DisplayFormat.FormatString = objFieldFormatGroupsInfo.STFieldFormatGroupFormatString;
                    }
                }
            }
        }

        protected virtual RepositoryItemLookUpEdit InitColumnLookupEdit(string strTableName, string strColumnName,
            string columnCaption)
        {
            var rep = new RepositoryItemLookUpEdit();
            rep.TextEditStyle = TextEditStyles.Standard;
            rep.SearchMode = SearchMode.AutoFilter;
            rep.NullText = string.Empty;

            var strLookupTable = _dbUtil.GetPrimaryTableWhichForeignColumnReferenceTo(strTableName,
                strColumnName);
            if (BOSApp.LookupTables[strLookupTable] == null)
            {
                BOSApp.InitLookupByTable(strLookupTable);
                if (BOSApp.LookupTables[strLookupTable] == null)
                    return null;
            }

            var ds = (DataSet)BOSApp.LookupTables[strLookupTable];
            rep.DataSource = ds.Tables[0];
            var strPrimaryColumn = _dbUtil.GetTablePrimaryColumn(strLookupTable);
            var strDisplayColumn = GetLookupTableDisplayColumn(strLookupTable);
            rep.ValueMember = strPrimaryColumn;
            rep.DisplayMember = strDisplayColumn;
            rep.ShowHeader = false;
            rep.QueryPopUp += RepositoryItemLookupEdit_QueryPopup;

            var colName = new LookUpColumnInfo();
            colName.Caption = columnCaption;
            colName.FieldName = rep.DisplayMember;
            colName.Width = 100;
            rep.Columns.Add(colName);

            return rep;
        }
        protected virtual RepositoryItemLookUpEdit InitColumnLookupView(string strTableName, string strColumnName,
           string columnCaption, string strDisplayColumn)
        {
            var rep = new RepositoryItemLookUpEdit();
            rep.TextEditStyle = TextEditStyles.Standard;
            rep.SearchMode = SearchMode.AutoFilter;
            rep.NullText = string.Empty;

            var strLookupTable = _dbUtil.GetPrimaryTableWhichForeignColumnReferenceTo(strTableName,
                strColumnName);
            if (BOSApp.LookupTables[strLookupTable] == null)
            {
                BOSApp.InitLookupByTable(strLookupTable);
                if (BOSApp.LookupTables[strLookupTable] == null)
                    return null;
            }

            var ds = (DataSet)BOSApp.LookupTables[strLookupTable];
            rep.DataSource = ds.Tables[0];
            var strPrimaryColumn = _dbUtil.GetTablePrimaryColumn(strLookupTable);
            //var strDisplayColumn = GetLookupTableDisplayColumn(strLookupTable);
            rep.ValueMember = strPrimaryColumn;
            rep.DisplayMember = strDisplayColumn;
            rep.ShowHeader = false;
            rep.QueryPopUp += RepositoryItemLookupEdit_QueryPopup;

            var colName = new LookUpColumnInfo();
            colName.Caption = columnCaption;
            colName.FieldName = rep.DisplayMember;
            colName.Width = 100;
            rep.Columns.Add(colName);
            return rep;
        }
        protected virtual string GetLookupTableDisplayColumn(string strLookupTableName)
        {
            //Get GELookupTableDisplayColumn from GELookupTables
            var objLookupTablesController = new GELookupTablesController();
            var objLookupTablesInfo = objLookupTablesController.GetObjectByTableName(strLookupTableName);
            if (objLookupTablesInfo != null && !string.IsNullOrEmpty(objLookupTablesInfo.GELookupTableDisplayColumn))
                return objLookupTablesInfo.GELookupTableDisplayColumn;
            //If not exist, get default display column
            var strPrimaryColumn = _dbUtil.GetTablePrimaryColumn(strLookupTableName);
            var prefix = strPrimaryColumn.Substring(0, strPrimaryColumn.Length - 2);
            if (_dbUtil.ColumnIsExist(strLookupTableName, prefix + "Name"))
                return prefix + "Name";
            if (_dbUtil.ColumnIsExist(strLookupTableName, prefix + "No"))
                return prefix + "No";
            return string.Empty;
        }

        protected virtual void RepositoryItemLookupEdit_QueryPopup(object sender, CancelEventArgs e)
        {
            var lke = (LookUpEdit)sender;
            var strLookupTable = lke.Properties.ValueMember.Substring(0, lke.Properties.ValueMember.Length - 2) + "s";
            var dsTemp = (DataSet)BOSApp.LookupTables[strLookupTable];
            var primaryKey = SqlDatabaseHelper.GetPrimaryKeyColumn(strLookupTable);
            var maxKeyVal = 0;
            if (dsTemp.Tables.Count > 0)
            {
                maxKeyVal = (int)dsTemp.Tables[0].Compute($"MAX([{primaryKey}])", "");
            }
            var dtLastModifyDate = _dbUtil.GetDateMofifyOfTableByMaxId(strLookupTable, primaryKey, maxKeyVal);
            if (dtLastModifyDate.CompareTo((DateTime)BOSApp.LookupTablesUpdatedDate[strLookupTable]) > 0)
            {
                //Refesh Data Source
                var objLookupTableController =
                    BusinessControllerFactory.GetBusinessController(strLookupTable + "Controller");
                if (objLookupTableController != null)
                {
                    var ds = objLookupTableController.GetAllObjects();

                    if (ds.Tables.Count > 0)
                    {
                        // Update Last Updated Date of Lookup Table
                        BOSApp.LookupTablesUpdatedDate[strLookupTable] = DateTime.Now;
                        ((DataSet)BOSApp.LookupTables[strLookupTable]).Tables.Clear();
                        ((DataSet)BOSApp.LookupTables[strLookupTable]).Tables.Add(ds.Tables[0].Copy());
                    }
                }
            }

            lke.Properties.DataSource = ((DataSet)BOSApp.LookupTables[strLookupTable]).Tables[0];
        }

        /// <summary>
        /// fix bug tim kiem tra ve 1 dong, ko click chon dc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridViewSearchResults_RowClick(object sender, RowClickEventArgs e)
        {
            var dgvSearchResults = (GridView)sender;
            if (e.RowHandle == dgvSearchResults.FocusedRowHandle && dgvSearchResults.FocusedRowHandle == 0)
            {
                var row = dgvSearchResults.GetDataRow(dgvSearchResults.FocusedRowHandle);
                if (row != null)
                {
                    Screen.Module.Toolbar.CurrentIndex = Screen.Module.Toolbar.ObjectCollection.Tables[0].Rows.IndexOf(row);
                    Screen.Module.Toolbar.Invalidate();
                }
            }
        }

        public virtual void GridViewSearchResults_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            var dgvSearchResults = (GridView)sender;
            //var strMainTable = ((BaseModuleERP)Screen.Module).CurrentModuleEntity.MainObject.GetType()
            //    .Name.Substring(0,
            //        ((BaseModuleERP)Screen.Module).CurrentModuleEntity.MainObject.GetType().Name.Length - 4);
            var row = dgvSearchResults.GetDataRow(dgvSearchResults.FocusedRowHandle);
            if (row != null)
            {
                Screen.Module.Toolbar.CurrentIndex = Screen.Module.Toolbar.ObjectCollection.Tables[0].Rows.IndexOf(row);
                Screen.Module.Toolbar.Invalidate();
            }
        }

        private void GridViewSearchResults_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //{                
            //    GridView gridView = sender as GridView;
            //    int iObjectID = ((BaseModuleERP)Screen.Module).Toolbar.CurrentObjectID;                
            //    ((BaseModuleERP)Screen.Module).ActionDelete();
            //    ((BaseModuleERP)Screen.Module).Search();
            //    ((BaseModuleERP)Screen.Module).InvalidateAfterSearch(null, String.Empty);
            //}
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter)
                ((BaseModuleERP)Screen.Module).ActivateDataMainScreen();
        }

        private void GridViewSearchResults_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.Column.VisibleIndex >= 0)
                try
                {
                    var strTableName =
                        BOSUtil.GetTableNameFromBusinessObject(
                            ((BaseModuleERP)Screen.Module).CurrentModuleEntity.MainObject);
                    var strColumnName = e.Column.FieldName;
                    if (strTableName.StartsWith("FA"))
                        if (strColumnName.Contains("FA" + Screen.Module.Name + "Type"))
                            if (ADConfigValueUtility.ConfigValues.Tables[Screen.Module.Name + "Type"] != null)
                                if (e.CellValue != null)
                                {
                                    var strValue = e.CellValue.ToString();
                                    var row =
                                        ADConfigValueUtility.ConfigValues.Tables[Screen.Module.Name + "Type"].Rows.Find(
                                            strValue);
                                    if (row != null)
                                        e.DisplayText = row["Text"].ToString();
                                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    (sender as GridView).Columns.Remove(e.Column);
                }
        }

        private void GridControlSearchResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var dgcSearchResults = (GridControl)sender;
            var hi = ((GridView)dgcSearchResults.MainView).CalcHitInfo(new Point(e.X, e.Y));
            if (hi.RowHandle >= 0)
            {
                BOSScreen _guiDataMainScreen = ((BaseModuleERP)Screen.Module).GetDataMainScreen(null, string.Empty);
                if (_guiDataMainScreen != null)
                {
                    _guiDataMainScreen.Activate();
                    Screen.Module.ActiveScreen = _guiDataMainScreen;
                }
            }
        }

        private void GridViewSearchResults_DataSourceChanged(object sender, EventArgs e)
        {
            var dgvSearchResults = (GridView)sender;
            var row = dgvSearchResults.GetDataRow(dgvSearchResults.FocusedRowHandle);
            if (row != null)
            {
                Screen.Module.Toolbar.CurrentIndex = Screen.Module.Toolbar.ObjectCollection.Tables[0].Rows.IndexOf(row);
                Screen.Module.Toolbar.Invalidate();
            }
        }

        #endregion

        #region Add Search Results To GridControl Functions

        #region Utilities For Data GridControl View

        public static void BindingSearchResultGridControl(GridControl gridControl, DataSet dsSearchResults, bool dataSetForToolbar = false, BaseToolbar toolbar = null)
        {
            if (dsSearchResults.Tables.Count <= 0) return;
            var gridView = (GridView)gridControl.ViewCollection[0];
            gridView.OptionsBehavior.AutoPopulateColumns = false;
            var bdsSearchResults = new BindingSource { DataSource = dsSearchResults.Tables[0] };
            if (gridControl.InvokeRequired)
            {
                var action = new Action<GridControl, BindingSource, bool, BaseToolbar, DataSet>((grid, bds, dst, tb, ds) =>
                {
                    grid.DataSource = null;
                    grid.DataSource = bds;
                    if (dst && tb != null)
                    {
                        tb.SetToolbar(ds);
                    }
                });
                gridControl.Invoke(action, new object[] { gridControl, bdsSearchResults, dataSetForToolbar, toolbar, dsSearchResults });
            }
            else
                gridControl.DataSource = new BindingSource { DataSource = dsSearchResults.Tables[0] };
        }
        protected virtual void InitGridViewVisibleIndex(GridView gridView, string strModuleName, string strTableName)
        {
            var module = ((IBaseModuleERP)Screen.Module);
            var dsColumns = _objFieldColumnsController.GetGridSearchResultColsByIDStringAndUser(_sTFieldColumnsIdStr, module.GetCurrentUserGroupID(), module.GetCurrentUserID());
            if (dsColumns.Tables[0].Rows.Count > 0)
                foreach (DataRow rowColumn in dsColumns.Tables[0].Rows)
                {
                    var fieldColInfo = (STFieldColumnsInfo)_objFieldColumnsController.GetObjectFromDataRow(rowColumn);
                    var isHas = false;
                    //uthv them cho truong hop hien thi nhieu cot cua cung FK
                    //cung field nhung khac col name
                    foreach (GridColumn item in gridView.Columns)
                    {
                        if (item.Name == fieldColInfo.STFieldColumnName)
                        {
                            item.VisibleIndex = fieldColInfo.STFieldColumnVisibleIndex;
                            item.Width = fieldColInfo.STFieldColumnWidth;
                            isHas = true;
                            break;
                        }
                    }
                    if (isHas == false && gridView.Columns[fieldColInfo.STFieldColumnFieldName] != null)
                    {
                        gridView.Columns[fieldColInfo.STFieldColumnFieldName].VisibleIndex = fieldColInfo.STFieldColumnVisibleIndex;
                        gridView.Columns[fieldColInfo.STFieldColumnFieldName].Width = fieldColInfo.STFieldColumnWidth;
                    }
                }
            else
                InitDefaultGridViewVisibleIndex(gridView, strTableName);
        }


        protected virtual void InitDefaultGridViewVisibleIndex(GridView gridView, string strTableName)
        {
        }

        #endregion

        #endregion


        #region Col Theo User/Group

        private void gridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var gr = (GridView)sender;
            if (e.Menu == null) return;

            if (e.HitInfo.HitTest == GridHitTest.ColumnPanel ||
                e.HitInfo.HitTest == GridHitTest.ColumnEdge ||
                e.HitInfo.HitTest == GridHitTest.ColumnFilterButton ||
                e.HitInfo.HitTest == GridHitTest.Column)
            {
                foreach (DXMenuItem item in e.Menu.Items)
                {
                    if (item.Tag.ToString() == DevExpress.XtraGrid.Localization.GridStringId.MenuColumnColumnCustomization.ToString())
                        item.Caption = "Tùy biến cột";
                }

                var menuItem = new DXMenuItem
                {
                    Caption = "Lưu tùy biến cột riêng tôi",
                    BeginGroup = true,
                    Tag = "SaveColumnCustomization"
                };
                menuItem.Click += SaveColumnCustomization_Click;
                e.Menu.Items.Add(menuItem);

                menuItem = new DXMenuItem
                {
                    Caption = "Sử dụng tùy biến cột mặc định",
                    Tag = "DeleteColumnCustomization"
                };
                menuItem.Click += DeleteColumnCustomization_Click;
                e.Menu.Items.Add(menuItem);

                if (((IBaseModuleERP)Screen.Module).UserIsAdmin())
                {
                    menuItem = new DXMenuItem
                    {
                        Caption = "Lưu tùy biến cột cho nhóm",
                        BeginGroup = true,
                        Tag = "SaveColumnCustomizationForGroups"
                    };
                    menuItem.Click += SaveColumnCustomization_Click;
                    e.Menu.Items.Add(menuItem);

                    menuItem = new DXMenuItem
                    {
                        Caption = "Xóa tùy biến cột của nhóm",
                        Tag = "DeleteColumnCustomizationForGroups"
                    };
                    menuItem.Click += DeleteColumnCustomization_Click;
                    e.Menu.Items.Add(menuItem);

                    menuItem = new DXMenuItem
                    {
                        BeginGroup = true,
                        Caption = "Lưu tùy biến cột toàn hệ thống",
                        Tag = "SaveColumnCustomizationForAll"
                    };
                    menuItem.Click += SaveColumnCustomization_Click;
                    e.Menu.Items.Add(menuItem);
                }
            }
        }

        private void SaveColumnCustomization_Click(object sender, EventArgs e)
        {
            SaveCustomizeColumnGridSearchResults((sender as DXMenuItem).Tag.ToString());
        }
        private void DeleteColumnCustomization_Click(object sender, EventArgs e)
        {
            DeleteCustomizeColumnGridSearchResults((sender as DXMenuItem).Tag.ToString());
        }

        private void DeleteCustomizeColumnGridSearchResults(string tag)
        {
            var module = ((IBaseModuleERP)Screen.Module);

            if (tag == "DeleteColumnCustomizationForGroups")
            {
                var userGroups = module.ShowUserGroupSelections();
                if (userGroups != null && userGroups.Length > 0)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        foreach (var group in userGroups)
                        {
                            _objFieldColumnsController.DeleteGridSearchResultColsByIDStringAndUser(_sTFieldColumnsIdStr, group.ADUserGroupID, 0);
                        }

                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Đã xóa tùy biến cột của các nhóm này. Các nhóm này sẽ dùng tùy biến cột [mặc định của hệ thống]",
                            CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
            else
            {
                var userGroupID = module.GetCurrentUserGroupID();
                var userId = module.GetCurrentUserID();
                _objFieldColumnsController.DeleteGridSearchResultColsByIDStringAndUser(_sTFieldColumnsIdStr, userGroupID, userId);
                MessageBox.Show("Tùy biến cột đã trả về [cấu hình mặc định]. Vui lòng mở lại module để cập nhật thay đổi", CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        #endregion
    }
}