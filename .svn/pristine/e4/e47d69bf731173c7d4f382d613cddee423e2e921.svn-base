using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOSLib;
using BOSCommon;
using BOSComponent;

namespace BOSERP
{
    public partial class guiProductGroupTree : BOSERPScreen
    {
        /// <summary>
        /// The product group id
        /// </summary>
        private int ProductGroupID = 0;

        #region Public Properties
        public BOSTreeList TreeList { get; set; }

        public int ICDepartmentID { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the screen allow multiple-select
        /// of product groups
        /// </summary>
        public bool AllowMultipleSelect { get; set; }
        #endregion

        public guiProductGroupTree()
        {
            InitializeComponent();
        }

        public guiProductGroupTree(int productGroupID)
        {
            InitializeComponent();

            ProductGroupID = productGroupID;
            AllowMultipleSelect = false;
        }

        public guiProductGroupTree(int departmentID,int productGroupID)
        {
            InitializeComponent();

            ICDepartmentID = departmentID;
            ProductGroupID = productGroupID;
            AllowMultipleSelect = false;
        }

        /// <summary>
        /// Check previous selected product group
        /// </summary>
        public void CheckPreviousProductGroup()
        {
            ICProductGroupsInfo obj = (ICProductGroupsInfo)TreeList.GetObjectByPropertyNameAndValue("ICProductGroupID", ProductGroupID);
            if (obj != null)
            {
                obj.Selected = true;
                fld_trlICProductGroups.DataSource = null;
                fld_trlICProductGroups.DataSource = TreeList;                
            }
        }

        private void guiProductGroupTree_Load(object sender, EventArgs e)
        {
            //Init tree list control
            fld_trlICProductGroups.Screen = this;
            fld_trlICProductGroups.InitializeControl();
            fld_trlICProductGroups.BOSDisplayRoot = false;
            fld_trlICProductGroups.BOSDisplayOption = true;
            fld_trlICProductGroups.CellValueChanging += new DevExpress.XtraTreeList.CellValueChangedEventHandler(fld_trlICProductGroups_CellValueChanging);

            //Init tree list columns
            String tableName = BOSUtil.GetTableNameFromBusinessObjectType(typeof(ICProductGroupsInfo));
            fld_trlICProductGroups.InitTreeListColumns(tableName);
            fld_trlICProductGroups.Columns["ICProductGroupName"].VisibleIndex = 0;
            fld_trlICProductGroups.Columns["ICProductGroupNo"].VisibleIndex = 1;
            fld_trlICProductGroups.Columns["Selected"].VisibleIndex = 2;

            //Init tree list data source
            TreeList = new BOSTreeList();
            TreeList.InitBOSList(null, TableName.ICDepartmentsTableName,
                                       TableName.ICProductGroupsTableName,
                                       BOSTreeList.cstRelationForeign);
            TreeList.TreeListControl = fld_trlICProductGroups;
            fld_trlICProductGroups.DataSource = TreeList;
                        
            ICDepartmentsController objDepartmentsController = new ICDepartmentsController();
            DataSet ds = objDepartmentsController.GetAllObjects();            
            if (ds.Tables.Count > 0)
            {
                fld_lkeDepartments.Properties.DataSource = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ICDepartmentID > 0)
                        fld_lkeDepartments.EditValue = ICDepartmentID;
                    else
                        fld_lkeDepartments.ItemIndex = 0;
                }
            }

            fld_lkeICProductGroupID.Screen = this;
            fld_lkeICProductGroupID.InitializeControl();
            fld_lkeICProductGroupID.EditValue = ProductGroupID;

            CheckPreviousProductGroup();
            fld_trlICProductGroups.ExpandAll();
        }

        private void fld_trlICProductGroups_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Selected")
            {                
                BOSTreeListObject currentObject = TreeList.CurrentObject;
                if (currentObject != null && !currentObject.Selected)
                {
                    if (!AllowMultipleSelect)
                    {
                        TreeList.SetValueToList("Selected", false);
                    }
                    currentObject.Selected = true;
                    fld_trlICProductGroups.RefreshDataSource();
                }
            }
        }

        private void fld_btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void fld_lkeDepartments_EditValueChanged(object sender, EventArgs e)
        {
            int departmentID = Convert.ToInt32(fld_lkeDepartments.EditValue);
            if (departmentID > 0)
            {
                ICDepartmentID = departmentID;
                TreeList.InvalidateTreeList(departmentID);
            }
        }

        private void fld_btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public String GetSelectedProductGroupName()
        {
            ICProductGroupsInfo objProductGroupsInfo = (ICProductGroupsInfo)TreeList.GetSelectedObject();
            if (objProductGroupsInfo != null)
            {
                return objProductGroupsInfo.ICProductGroupName;
            }
            return string.Empty;
        }

        public String GetProductBarCode()
        {
            String barCode = String.Empty;
            ICDepartmentsInfo objDepartmentsInfo = (ICDepartmentsInfo)new ICDepartmentsController().GetObjectByID(ICDepartmentID);
            if (objDepartmentsInfo != null)
                barCode += objDepartmentsInfo.ICDepartmentNo;
            ICProductGroupsInfo objProductGroupsInfo = (ICProductGroupsInfo)TreeList.GetSelectedObject();
            while (objProductGroupsInfo != null)
            {
                barCode += objProductGroupsInfo.ICProductGroupNo;
                objProductGroupsInfo = (ICProductGroupsInfo)objProductGroupsInfo.Parent;
            }
            return barCode;
        }

        private void fld_lkeICProductGroupID_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            BOSLookupEdit lke = (BOSLookupEdit)sender;
            if (e.Value != null && e.Value != lke.OldEditValue)
            {
                int productGroupID = Convert.ToInt32(e.Value);
                ICProductGroupsController objProductGroupsController = new ICProductGroupsController();
                ICProductGroupsInfo objProductGroupsInfo = (ICProductGroupsInfo)objProductGroupsController.GetObjectByID(productGroupID);
                if (objProductGroupsInfo != null)
                {
                    if (objProductGroupsInfo.FK_ICDepartmentID != ICDepartmentID)
                    {
                        ICDepartmentID = objProductGroupsInfo.FK_ICDepartmentID;
                        fld_lkeDepartments.EditValue = objProductGroupsInfo.FK_ICDepartmentID;
                    }

                    TreeList.SetValueToList("Selected", false);
                    objProductGroupsInfo = (ICProductGroupsInfo)TreeList.GetObjectByPropertyNameAndValue("ICProductGroupID", productGroupID);
                    if (objProductGroupsInfo != null)
                    {
                        objProductGroupsInfo.Selected = true;
                    }
                    fld_trlICProductGroups.RefreshDataSource();
                }                
            }
        }
    }
}