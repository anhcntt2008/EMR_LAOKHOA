using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOSLib;
using BOSComponent;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using Localization;

namespace BOSERP
{
    public partial class guiFind<T> : BOSERPScreen where T : BusinessObject
    {
        #region Variables
        /// <summary>
        /// The grid control contains search result
        /// </summary>
        private BOSGridControl GridControlResult;

        /// <summary>
        /// The control causes this screen to show up
        /// </summary>
        private Control Owner;

        /// <summary>
        /// The name of table is searched on
        /// </summary>
        private String SearchTableName;

        /// <summary>
        /// List of objects is used to bind to the search grid control        
        /// </summary>
        private IList<T> ObjectList;

        /// <summary>
        /// A value indicates whether the screen allows multiple selection
        /// </summary>
        private bool AllowMultipleSelect;

        /// <summary>
        /// A value indicates whether the screen shows the object list when it's shown
        /// </summary>
        private bool ShowData;



        private bool HasRankingResult = false;
        #endregion

        #region Public Properties
        public bool IsCompareExactly = false;

        /// <summary>
        /// Gets or sets the list of selected objects
        /// </summary>
        public IList<T> SelectedObjects { get; set; }

        /// <summary>
        /// Gets or sets the name of the grid control that its component
        /// will be instantiated and used in this form
        /// </summary>
        public string GridControlName { get; set; }

        /// <summary>
        /// UtHV 
        /// Cho phep lay ve doan text trong o search trong truong hop search khong co
        /// dung trong truong hop them trieu chung
        /// </summary>
        public bool AllowAddItemNotExisted { get; private set; }
        public string FreeText { get; private set; }

        #endregion

        public guiFind()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="searchTableName">Name of the table is searched on</param>
        /// <param name="objectList">Object list is used to be a data source for search</param>
        /// <param name="owner">Control causes the screen to show up</param>
        /// <param name="module">Module the screen belongs to</param>
        public guiFind(String searchTableName, IList<T> objectList, Control owner, BaseModule module)
        {
            InitializeComponent();

            this.SearchTableName = searchTableName;
            this.ObjectList = objectList;
            this.Owner = owner;
            this.Module = module;
            AllowMultipleSelect = false;
            ShowData = true;
            SelectedObjects = new List<T>();

            AllowAddItemNotExisted = false;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="searchTableName">Name of the table is searched on</param>
        /// <param name="objectList">Object list is used to be a data source for search</param>        
        /// <param name="module">Module the screen belongs to</param>
        public guiFind(String searchTableName, IList<T> objectList, BaseModule module)
        {
            InitializeComponent();

            this.SearchTableName = searchTableName;
            this.ObjectList = objectList;
            this.Module = module;
            AllowMultipleSelect = false;
            ShowData = true;
            SelectedObjects = new List<T>();

            AllowAddItemNotExisted = false;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="searchTableName">Name of the table is searched on</param>
        /// <param name="objectList">Object list is used to be a data source for search</param>        
        /// <param name="module">Module the screen belongs to</param>
        /// <param name="allowMultipleSelect">A value indicates whether the screen allows multiple selection</param>
        public guiFind(string searchTableName, IList<T> objectList, BaseModule module, bool allowMultipleSelect)
        {
            InitializeComponent();

            SearchTableName = searchTableName;
            ObjectList = objectList;
            Module = module;
            AllowMultipleSelect = allowMultipleSelect;
            ShowData = true;
            SelectedObjects = new List<T>();

            AllowAddItemNotExisted = false;
        }
        /// <summary>
        /// UtHV them option de search containConstructor
        /// </summary>
        /// <param name="searchTableName">Name of the table is searched on</param>
        /// <param name="objectList">Object list is used to be a data source for search</param>        
        /// <param name="module">Module the screen belongs to</param>
        /// <param name="allowMultipleSelect">A value indicates whether the screen allows multiple selection</param>
        /// <param name="isCompareExactly">Search contain</param>
        public guiFind(string searchTableName, IList<T> objectList, BaseModule module, bool allowMultipleSelect,
            bool showData, bool allowAddItemNotExisted, bool isCompareExactly, bool hasRanking)
        {
            InitializeComponent();

            this.IsCompareExactly = isCompareExactly;

            SearchTableName = searchTableName;
            ObjectList = objectList;
            Module = module;
            AllowMultipleSelect = allowMultipleSelect;
            ShowData = showData;
            SelectedObjects = new List<T>();
            this.HasRankingResult = hasRanking;
            AllowAddItemNotExisted = allowAddItemNotExisted;
        }

        /// <summary>
        /// UtHV
        /// 01172017
        /// Cho phep lay ve doan text trong o search trong truong hop search khong co
        /// dung trong truong hop them trieu chung
        /// </summary>
        /// <param name="allowAddNotExistItem"></param>
        public guiFind(string searchTableName, IList<T> objectList, BaseModule module, bool allowMultipleSelect, bool showData, bool allowAddItemNotExisted)
        {
            InitializeComponent();

            SearchTableName = searchTableName;
            ObjectList = objectList;
            Module = module;
            AllowMultipleSelect = allowMultipleSelect;
            ShowData = showData;
            SelectedObjects = new List<T>();

            AllowAddItemNotExisted = allowAddItemNotExisted;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="searchTableName">Name of the table is searched on</param>
        /// <param name="objectList">Object list is used to be a data source for search</param>        
        /// <param name="module">Module the screen belongs to</param>
        /// <param name="allowMultipleSelect">A value indicates whether the screen allows multiple selection</param>
        /// <param name="showData">A value indicates whether the screen shows the object list when it's shown</param>
        public guiFind(string searchTableName, IList<T> objectList, BaseModule module, bool allowMultipleSelect, bool showData)
        {
            InitializeComponent();

            SearchTableName = searchTableName;
            ObjectList = objectList;
            Module = module;
            AllowMultipleSelect = allowMultipleSelect;
            ShowData = showData;
            SelectedObjects = new List<T>();

            AllowAddItemNotExisted = false;
        }

        private void guiFind_Load(object sender, EventArgs e)
        {
            //Init the result grid control
            string gridName = GridControlName;
            if (string.IsNullOrEmpty(gridName))
            {
                gridName = SearchTableName;
            }
            GridControlResult = BOSGridControl.Instance(gridName, this.Module.Name);
            GridControlResult.Name = "fld_dgc" + SearchTableName;
            GridControlResult.Screen = this;
            GridControlResult.BOSDataSource = SearchTableName;
            GridControlResult.Width = fld_pnlMainGroup.Width - 10;
            GridControlResult.Height = fld_pnlMainGroup.Height - 50;
            GridControlResult.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            GridControlResult.TabIndex = 0;
            GridControlResult.InitializeControl();

            //Init the grid view of the result grid control
            GridView gridView = (GridView)GridControlResult.MainView;
            if (AllowMultipleSelect)
            {
                GridColumn column = new GridColumn();
                column.Caption = BaseLocalizedResources.Select;
                column.FieldName = "Selected";
                column.OptionsColumn.AllowEdit = true;
                gridView.Columns.Insert(0, column);
                column.VisibleIndex = 0;

                fld_chkSelectAll.Visible = true;
                GridControlResult.Height = GridControlResult.Height - 30;
            }
            gridView.DoubleClick += new EventHandler(GridView_DoubleClick);

            fld_pnlMainGroup.Controls.Add(GridControlResult);
            fld_txtFind.Tag = 0;
            if (ShowData)
            {
                SearchData(null);
            }

            // UtHV [MOD]
            if (AllowAddItemNotExisted)
            {
                this.lblSelectIntruction.Visible = true;
                this.fld_btnAddNew.Visible = true;
            }
            else
            {
                this.lblSelectIntruction.Visible = false;
                this.fld_btnAddNew.Visible = false;
            }
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            ChooseObjects();
        }

        private void fld_lblSearch_Click(object sender, EventArgs e)
        {
            SearchData(fld_txtFind.Text);
        }

        private void fld_txtFind_Click(object sender, EventArgs e)
        {
            int tag = int.Parse(fld_txtFind.Tag.ToString());
            if (tag == 0)
                fld_txtFind.Text = String.Empty;
            fld_txtFind.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
        }

        private void fld_txtFind_Leave(object sender, EventArgs e)
        {
            int tag = int.Parse(fld_txtFind.Tag.ToString());
            if (String.IsNullOrEmpty(fld_txtFind.Text) || tag == 0)
            {
                fld_txtFind.Text = BaseLocalizedResources.TypeKeyWordMessage;
                fld_txtFind.Properties.Appearance.ForeColor = System.Drawing.Color.DarkGray;
                fld_txtFind.Tag = 0;
            }
            else
            {
                fld_txtFind.Tag = 1;
                fld_txtFind.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            }

        }

        private void fld_txtFind_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            int tag = int.Parse(fld_txtFind.Tag.ToString());
            if (!String.IsNullOrEmpty(fld_txtFind.Text))
            {
                fld_txtFind.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
                fld_txtFind.Tag = 1;
            }
        }

        private void fld_btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void fld_btnFind_Click(object sender, EventArgs e)
        {
            String keyWord = String.Empty;
            if (int.Parse(fld_txtFind.Tag.ToString()) != 0)
                keyWord = fld_txtFind.Text;
            SearchData(keyWord);
        }

        /// <summary>
        /// Check existence of keyword in each row
        /// </summary>
        protected bool IsExistKeyWord(String value, String keyWord)
        {
            value = value.ToLower();
            keyWord = keyWord.ToLower();
            String[] arrElement = keyWord.Split(new char[] { ' ' });
            bool isExist = false;
            foreach (String element in arrElement)
            {
                if (IsCompareExactly && value.StartsWith(element))
                {
                    isExist = true;
                }
                else if (!IsCompareExactly && value.Contains(element))
                {
                    isExist = true;
                }
            }

            if (!isExist)
            {
                value = BOSUtil.ConvertUnicodeStringToUnSign(value);
                foreach (String element in arrElement)
                {
                    if (IsCompareExactly && value.StartsWith(element))
                    {
                        isExist = true;
                    }
                    else if (!IsCompareExactly && value.Contains(element))
                    {
                        isExist = true;
                    }
                }
            }
            return isExist;
        }

        /// <summary>
        /// Search data to show on gridview
        /// </summary>
        protected void SearchData(String keyWord)
        {
            keyWord = keyWord == null ? null : keyWord.ToLower();
            DevExpress.XtraGrid.Views.Grid.GridView gridView = (DevExpress.XtraGrid.Views.Grid.GridView)GridControlResult.MainView;
            if (!String.IsNullOrEmpty(keyWord))
            {
                List<GridColumn> lstColVisible = new List<GridColumn>();
                BOSList<BusinessObject> lstObject = new BOSList<BusinessObject>();
                for (int i = 0; i < gridView.Columns.Count; i++)
                {
                    if (gridView.Columns[i].VisibleIndex >= 0)
                        lstColVisible.Add(gridView.Columns[i]);
                }
                BOSDbUtil dbUtil = new BOSDbUtil();
                List<T> bindingList = new List<T>();

                //Bind object list to grid for searching
                //GridControlResult.DataSource = ObjectList;
                // GridControlResult.RefreshDataSource();

                // UtHV Custom, uu tien search contain all key
                List<T> tempObjectList = ObjectList.Select(o => o.Clone() as T).ToList();

                if (HasRankingResult)
                {
                    for (int i = 0; i < tempObjectList.Count; i++)
                    {
                        foreach (GridColumn column in lstColVisible)
                        {
                            //int rowHandle = gridView.GetRowHandle(i);
                            //string value = gridView.GetRowCellDisplayText(rowHandle, column);
                            var obj = tempObjectList[i].Clone() as T;
                            string value = obj.GetType().GetProperty(column.FieldName).GetValue(obj, null).ToString();
                            value = value.ToLower();
                            if (value.StartsWith(keyWord))
                            {
                                bindingList.Add(obj);
                                tempObjectList.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                    for (int i = 0; i < tempObjectList.Count; i++)
                    {
                        foreach (GridColumn column in lstColVisible)
                        {
                            //int rowHandle = gridView.GetRowHandle(i);
                            //string value = gridView.GetRowCellDisplayText(rowHandle, column);
                            var obj = tempObjectList[i].Clone() as T;
                            string value = obj.GetType().GetProperty(column.FieldName).GetValue(obj, null).ToString();
                            value = value.ToLower();
                            if (value.Contains(keyWord))
                            {
                                bindingList.Add(obj);
                                tempObjectList.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                    for (int i = 0; i < tempObjectList.Count; i++)
                    {
                        foreach (GridColumn column in lstColVisible)
                        {
                            //int rowHandle = gridView.GetRowHandle(i);
                            //string value = gridView.GetRowCellDisplayText(rowHandle, column);
                            var obj = tempObjectList[i].Clone() as T;
                            string value = obj.GetType().GetProperty(column.FieldName).GetValue(obj, null).ToString();
                            value = value.ToLower();
                            value = BOSUtil.ConvertUnicodeStringToUnSign(value);
                            if (value.Contains(keyWord))
                            {
                                bindingList.Add(obj);
                                tempObjectList.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }

                for (int i = 0; i < tempObjectList.Count; i++)
                {
                    bool isExist = false;
                    foreach (GridColumn column in lstColVisible)
                    {
                        //int rowHandle = gridView.GetRowHandle(i);
                        //string value = gridView.GetRowCellDisplayText(rowHandle, column);
                        var obj = tempObjectList[i].Clone() as T;
                        var col = obj.GetType().GetProperty(column.FieldName);
                        if (col != null)
                        {
                            string value = col.GetValue(obj, null).ToString();
                            value = value.ToLower();
                            isExist = IsExistKeyWord(value, keyWord);
                            if (isExist)
                                break;
                        }
                    }
                    if (isExist)
                    {
                        bindingList.Add(tempObjectList[i].Clone() as T);
                    }
                }

                GridControlResult.DataSource = bindingList;
                GridControlResult.RefreshDataSource();
            }
            else
            {
                GridControlResult.DataSource = ObjectList;
                GridControlResult.RefreshDataSource();
            }
        }

        private void fld_btnSelect_Click(object sender, EventArgs e)
        {
            ChooseObjects();
        }

        /// <summary>
        /// Called when user selected objects. The formed will be closed
        /// and let user continue
        /// </summary>
        private void ChooseObjects()
        {
            GridView gridView = (GridView)GridControlResult.MainView;
            bool isSelected = false;
            if (!AllowMultipleSelect)
            {
                if (gridView.FocusedRowHandle >= 0)
                {
                    T obj = (T)gridView.GetRow(gridView.FocusedRowHandle);
                    BOSDbUtil dbUtil = new BOSDbUtil();
                    String primaryColumn = dbUtil.GetTablePrimaryColumn(SearchTableName);
                    int objectID = dbUtil.GetPropertyIntValue(obj, primaryColumn);
                    if (Owner != null)
                        dbUtil.SetPropertyValue(Owner, "EditValue", objectID);
                    else
                        this.Tag = objectID;
                    isSelected = true;
                    SelectedObjects.Add(obj);
                }
            }
            else
            {
                if (gridView.FocusedRowHandle >= 0)
                {
                    T obj = (T)gridView.GetRow(gridView.FocusedRowHandle);
                    obj.Selected = true;
                }

                SelectedObjects.Clear();
                foreach (T obj in ObjectList)
                {
                    if (obj.Selected)
                    {
                        SelectedObjects.Add(obj);
                        isSelected = true;
                    }
                }
            }

            bool isValid = ((BaseModuleERP)Module).CheckSelectedSearchObjects(SearchTableName, SelectedObjects);
            if (!isValid)
            {
                return;
            }

            if (!isSelected)
            {
                MessageBox.Show(BaseLocalizedResources.ChooseObjectMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void fld_chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            List<T> objects = (List<T>)GridControlResult.DataSource;
            foreach (T obj in objects)
            {
                obj.Selected = fld_chkSelectAll.Checked;
            }
            GridControlResult.RefreshDataSource();
        }

        private void fld_btnAddNew_Click(object sender, EventArgs e)
        {
            // UtHV [MOD] 01172017 
            // cho phep tra ve chuoi nhap vao o search, dung trong truong hop nhap free text
            if (AllowAddItemNotExisted && !String.IsNullOrEmpty(this.fld_txtFind.Text.Trim()))
            {
                this.Tag = null;
                this.FreeText = this.fld_txtFind.Text;
            }
            else
            {
                MessageBox.Show(BaseLocalizedResources.ChooseObjectMessage, CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}