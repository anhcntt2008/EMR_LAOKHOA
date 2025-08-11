using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;
using BOSLib;
using BOSComponent;
using DevExpress.XtraGrid.Views.Grid;
using Localization;

namespace BOSERP
{
    public class BOSList<T> : List<T>, IBOSList<T>, ICloneable
        where T : BusinessObject, new()
    {
        #region Constant
        public const String cstRelationForeign = "Foreign";
        public const String cstRelationParent = "Parent";
        public const String cstRelationSwitcher = "Switcher";
        public const String cstRelationNone = "None";
        #endregion

        #region variables
        protected ERPModuleEntities _entity = new ERPModuleEntities();
        protected String _relation;
        protected String _parentTableName;
        protected String _itemTableName;
        protected BOSGridControl _gridControl;
        protected String _itemTableForeignKey;

        protected int _currentIndex;
        protected IList<T> _originalList = new List<T>();
        protected bool IsEndCurrentEdit = false;

        /// <summary>
        /// A variable to indicate whether the new item row of the list is inputing
        /// </summary>
        protected bool IsInputingNewRow = false;
        #endregion

        #region Public Properties
        public ERPModuleEntities Entity
        {
            get
            {
                return _entity;
            }
            set
            {
                _entity = value;
            }
        }

        public String Relation
        {
            get
            {
                return _relation;
            }

            set
            {
                _relation = value;
            }
        }
        public BOSGridControl GridControl
        {
            get
            {
                return _gridControl;
            }
            set
            {
                _gridControl = value;
            }
        }

        public DevExpress.XtraGrid.Views.Grid.GridView GridView
        {
            get
            {
                if (GridControl != null && GridControl.Views.Count > 0)
                {
                    if (GridControl.Views[0] is GridView)
                    {
                        return (GridView)GridControl.Views[0];
                    }
                    return null;
                }
                return null;
            }
        }

        public String ParentTableName
        {
            get
            {
                return _parentTableName;
            }
            set
            {
                _parentTableName = value;
            }
        }

        public String ItemTableName
        {
            get
            {
                return _itemTableName;
            }

            set
            {
                _itemTableName = value;
            }
        }

        public String ItemTableForeignKey
        {
            get
            {
                return _itemTableForeignKey;
            }
            set
            {
                _itemTableForeignKey = value;
            }
        }

        public int CurrentIndex
        {
            get
            {
                if (GridView != null && GridView.FocusedRowHandle >= 0)
                {
                    return GridView.GetDataSourceRowIndex(GridView.FocusedRowHandle);
                }
                return -1;
            }
        }

        public IList<T> OriginalList
        {
            get
            {
                return _originalList;
            }
            set
            {
                _originalList = value;
            }
        }

        /// <summary>
        /// Gets or sets the list used to back up the current list for rollback action
        /// </summary>
        public IList<T> BackupList { get; set; }
        #endregion

        #region Constructor
        public BOSList()
        {
            BackupList = new List<T>();
        }

        public BOSList(ERPModuleEntities entity, String strParentTaleName, String strItemTableName) : this()
        {
            InitBOSList(entity, strParentTaleName, strItemTableName);
        }

        public BOSList(string itemTableName) : this()
        {
            InitBOSList(null, string.Empty, itemTableName);
        }
        #endregion

        #region Init
        public void InitBOSList(object entity, string parentTableName, string itemTableName)
        {
            InitBOSList((ERPModuleEntities)entity, parentTableName, itemTableName);
        }

        public void InitBOSList(object entity, string parentTableName, string itemTableName, string relation)
        {
            InitBOSList((ERPModuleEntities)entity, parentTableName, itemTableName, relation);
        }

        public void InitBOSList(ERPModuleEntities ent, String strParentTableName, String strItemTableName)
        {
            Entity = ent;
            BOSDbUtil dbUtil = new BOSDbUtil();
            ParentTableName = strParentTableName;
            ItemTableName = strItemTableName;
            if (!String.IsNullOrEmpty(ParentTableName))
            {
                String strParentTablePrimaryColumn = dbUtil.GetTablePrimaryColumn(ParentTableName);
                String strItemTablePrimaryColumn = dbUtil.GetTablePrimaryColumn(ItemTableName);
                ItemTableForeignKey = "FK_" + strParentTablePrimaryColumn;
                if (dbUtil.ColumnIsExist(ItemTableName, ItemTableForeignKey))
                    Relation = cstRelationForeign;
                else
                {
                    if (ItemTableName.Equals(ParentTableName))
                    {
                        Relation = cstRelationParent;
                        ItemTableForeignKey = ItemTableName.Substring(0, ItemTableName.Length - 1) + "ParentID";
                    }
                    else
                        Relation = cstRelationNone;
                }
            }
            else
            {
                Relation = cstRelationNone;
            }
        }

        /// <summary>
        /// Init BOS list with given relation
        /// </summary>
        public void InitBOSList(ERPModuleEntities ent, String strParentTableName, String strItemTableName, String strRelation)
        {
            Entity = ent;
            BOSDbUtil dbUtil = new BOSDbUtil();
            ParentTableName = strParentTableName;
            ItemTableName = strItemTableName;
            Relation = strRelation;
            switch (strRelation)
            {
                case cstRelationForeign:
                    {
                        String strParentTablePrimaryColumn = dbUtil.GetTablePrimaryColumn(ParentTableName);
                        String strItemTablePrimaryColumn = dbUtil.GetTablePrimaryColumn(ItemTableName);
                        ItemTableForeignKey = "FK_" + strParentTablePrimaryColumn;
                        break;
                    }
                case cstRelationParent:
                    {
                        ItemTableForeignKey = ItemTableName.Substring(0, ItemTableName.Length - 1) + "ParentID";
                        break;
                    }
            }
        }

        public virtual void InitBOSListGridControl()
        {
            String strGridControlName = "fld_dgc" + ItemTableName;
            InitBOSListGridControl(strGridControlName);
        }

        public virtual void InitBOSListGridControl(String strGridControlName)
        {
            if (Entity.Module.Controls[strGridControlName] != null)
            {
                InitBOSListGridControl((BOSGridControl)Entity.Module.Controls[strGridControlName]);
            }
        }

        public virtual void InitBOSListGridControl(BOSGridControl gridControl)
        {
            GridControl = gridControl;
            DevExpress.XtraGrid.Views.Grid.GridView gridView = (DevExpress.XtraGrid.Views.Grid.GridView)this.GridControl.Views[0];
            gridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(GridView_FocusedRowChanged);
            gridView.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(GridView_CellValueChanging);
        }

        public void SetDefaultListAndRefreshGridControl()
        {
            this.Clear();
            this.OriginalList.Clear();
            this.BackupList.Clear();
            if (GridControl != null)
            {
                GridControl.RefreshDataSource();
            }
        }
        #endregion

        #region Invalidate
        public virtual void Invalidate(int iObjectID)
        {
            //Invalidate lookup edit columns to reflect all changes of lookup table
            if (GridControl != null)
                GridControl.InvalidateLookupEditColumns();

            BOSDbUtil dbUtil = new BOSDbUtil();
            BaseBusinessController objItemController = BusinessControllerFactory.GetBusinessController(ItemTableName + "Controller");
            DataSet ds = new DataSet();

            if (Relation.Equals(cstRelationForeign))
            {
                ds = objItemController.GetAllDataByForeignColumn(ItemTableForeignKey, iObjectID);

            }
            else if (Relation.Equals(cstRelationParent))
            {
                ds = objItemController.GetAllObjectsByObjectParentID(iObjectID);
            }
            else if (Relation.Equals(cstRelationNone))
            {
                ds = objItemController.GetAllObjects();
            }

            Invalidate(ds);
        }

        public virtual void Invalidate(DataSet ds)
        {
            if (ds.Tables.Count > 0)
            {
                Invalidate(ds.Tables[0]);
            }
        }

        /// <summary>
        /// Invalidate based on a table
        /// </summary>
        /// <param name="table">Table contains object list</param>
        public virtual void Invalidate(DataTable table)
        {
            this.Clear();

            BaseBusinessController objItemController = BusinessControllerFactory.GetBusinessController(ItemTableName + "Controller");

            foreach (DataRow row in table.Rows)
            {
                T objT = (T)objItemController.GetObjectFromDataRow(row);
                this.Add(objT);
            }

            //Invalidate original list same as itself
            OriginalList.Clear();
            foreach (T obj in this)
                OriginalList.Add((T)obj.Clone());

            //Invalidate backup list same as itself
            BackupList.Clear();
            foreach (T obj in this)
            {
                BackupList.Add((T)obj.Clone());
            }

            //Refresh Grid if Grid is not null
            if (GridControl != null)
            {
                GridControl.RefreshDataSource();
                if (this.Count > 0)
                {
                    if (CurrentIndex >= 0 && CurrentIndex < Count)
                    {
                        GridViewFocusRow(CurrentIndex);
                    }
                    else
                    {
                        GridViewFocusRow(0);
                    }
                }
                else
                {
                    Entity.InvalidateModuleObject(BusinessObjectFactory.GetBusinessObject(ItemTableName + "Info"));
                }
            }
        }

        /// <summary>
        /// Invalidate based on a list 
        /// </summary>
        /// <param name="lst">Object list</param>
        public virtual void Invalidate(IList<T> lst)
        {
            this.Clear();
            foreach (T obj in lst)
            {
                this.Add((T)obj.Clone());
            }

            //Invalidate original list same as itself
            OriginalList.Clear();
            foreach (T obj in this)
                OriginalList.Add((T)obj.Clone());

            //Invalidate backup list same as itself
            BackupList.Clear();
            foreach (T obj in this)
            {
                BackupList.Add((T)obj.Clone());
            }

            if (GridControl != null)
            {
                GridControl.RefreshDataSource();
                if (this.Count > 0)
                {
                    if (CurrentIndex >= 0 && CurrentIndex < Count)
                    {
                        GridViewFocusRow(CurrentIndex);
                    }
                    else
                    {
                        GridViewFocusRow(0);
                    }
                }
                else
                {
                    Entity.InvalidateModuleObject(BusinessObjectFactory.GetBusinessObject(ItemTableName + "Info"));
                }
            }
        }

        /// <summary>
        /// Invalidate based on a list but don't invalidate the corresponding module object
        /// </summary>
        /// <param name="lst">Object list</param>
        public virtual void InvalidateAndNotUpdateModuleObject(IList<T> lst)
        {
            this.Clear();
            foreach (T obj in lst)
            {
                this.Add((T)obj.Clone());
            }

            //Invalidate original list same as itself
            OriginalList.Clear();
            foreach (T obj in this)
                OriginalList.Add((T)obj.Clone());

            //Invalidate backup list same as itself
            BackupList.Clear();
            foreach (T obj in this)
            {
                BackupList.Add((T)obj.Clone());
            }
        }
        #endregion

        #region Save List
        public virtual T SaveObjectToList(bool isNew)
        {
            //Invalidate look up edit columns
            if (GridControl != null)
                GridControl.InvalidateLookupEditColumns();

            BOSDbUtil dbUtil = new BOSDbUtil();
            String strMainTableName = String.Empty;
            if (Entity.MainObject != null)
                strMainTableName = BOSUtil.GetTableNameFromBusinessObject(Entity.MainObject);

            T objT = new T();
            if (!String.IsNullOrEmpty(ParentTableName))
            {
                if (ItemTableName.Equals(strMainTableName))
                {
                    objT = (T)Entity.MainObject.Clone();
                }
                else
                {
                    objT = (T)Entity.ModuleObjects[ItemTableName].Clone();
                }
            }
            else
            {
                objT = (T)Entity.ModuleObjects[ItemTableName].Clone();
            }

            if (isNew)
            {
                String strPrimaryKey = ItemTableName.Substring(0, ItemTableName.Length - 1) + "ID";
                dbUtil.SetPropertyValue(objT, strPrimaryKey, 0);
                this.Add(objT);
            }
            else
            {
                if (CurrentIndex >= 0)
                    this[CurrentIndex] = objT;
            }
            return objT;
        }

        public virtual void AddObjectToList()
        {
            this.SaveObjectToList(true);
            if (GridControl != null)
            {
                GridControl.RefreshDataSource();
                GridViewFocusRow(this.Count - 1);
            }
        }

        public virtual void ChangeObjectFromList()
        {
            this.SaveObjectToList(false);
            if (GridControl != null)
            {
                if (GridView.FocusedRowHandle >= 0)
                {
                    GridControl.RefreshDataSource();
                    //GridViewFocusRow(GridView.FocusedRowHandle);
                }
            }
        }

        public virtual void RemoveObjectFromList(int iIndex)
        {
            if (this.Count > iIndex)
            {
                this.RemoveAt(iIndex);
            }
            if (GridControl != null)
            {
                GridControl.RefreshDataSource();
            }
            if (this.Count > 0)
            {
                if (this.Count > GridView.FocusedRowHandle)
                    GridViewFocusRow(GridView.FocusedRowHandle);
                else
                    GridViewFocusRow(this.Count - 1);
            }
            else
                Entity.InvalidateModuleObject(BusinessObjectFactory.GetBusinessObject(ItemTableName + "Info"));
        }

        public virtual void RemoveSelectedRowObjectFromList()
        {
            if (GridView != null && GridView.FocusedRowHandle >= 0)
            {
                int currentIndex = CurrentIndex;
                if (Entity.Module.IsEditable())
                {
                    Entity.Module.ActionEdit();
                }
                RemoveObjectFromList(currentIndex);
            }
        }

        public virtual bool Exists(String strPropertyName, object objPropertyValue)
        {
            if (this.PosOf(strPropertyName, objPropertyValue) >= 0)
                return true;
            return false;
        }

        public virtual void GridViewFocusRow(int iRowHandle)
        {
            if (GridView != null)
            {
                if (GridView.FocusedRowHandle == iRowHandle)
                {
                    if (CurrentIndex >= 0)
                    {
                        Entity.InvalidateModuleObject((T)this[CurrentIndex].Clone());
                    }
                }
                else
                {
                    GridView.FocusedRowHandle = iRowHandle;
                }
            }
        }

        #endregion

        #region Save List, Delete List to database
        public virtual void DeleteAllItemObjects()
        {
            try
            {
                BOSDbUtil dbUtil = new BOSDbUtil();
                BaseBusinessController objItemsController = BusinessControllerFactory.GetBusinessController(ItemTableName + "Controller");
                switch (Relation)
                {
                    case cstRelationSwitcher:
                        {
                            int iParentObjectID = GetParentObjectID();
                            if (iParentObjectID > 0)
                            {
                                String strSwitcherTableName = ParentTableName.Substring(0, ParentTableName.Length - 1) + ItemTableName.Substring(2);
                                objItemsController.DeleteFromOwner(ParentTableName, iParentObjectID, strSwitcherTableName);
                            }

                            break;
                        }
                    case cstRelationForeign:
                        {
                            int iParentObjectID = GetParentObjectID();
                            if (iParentObjectID > 0)
                            {
                                objItemsController.DeleteByForeignColumn(ItemTableForeignKey, iParentObjectID);
                            }
                            break;
                        }


                    case cstRelationParent:
                        {
                            break;
                        }

                    case cstRelationNone:
                        {
                            objItemsController.DeleteAllObjects();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public virtual void DeleteItemObjects()
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            BaseBusinessController objItemsController = BusinessControllerFactory.GetBusinessController(ItemTableName + "Controller");
            String strPrimaryColumn = dbUtil.GetTablePrimaryColumn(ItemTableName);

            foreach (T obj in this)
            {
                int iObjectID = Convert.ToInt32(dbUtil.GetPropertyValue(obj, strPrimaryColumn));
                objItemsController.DeleteObject(iObjectID);
            }
        }

        public virtual void SaveItemObjects()
        {
            try
            {
                EndCurrentEdit();

                BOSDbUtil dbUtil = new BOSDbUtil();
                String strItemTablePrimaryKey = dbUtil.GetTablePrimaryColumn(ItemTableName);
                BaseBusinessController objItemsController = BusinessControllerFactory.GetBusinessController(ItemTableName + "Controller");

                foreach (T objT in this)
                {
                    int iItemObjectID = (int)dbUtil.GetPropertyValue(objT, strItemTablePrimaryKey);
                    switch (Relation)
                    {
                        case cstRelationSwitcher:
                            {
                                break;
                            }
                        case cstRelationForeign:
                            {
                                int iParentObjectID = GetParentObjectID();
                                if (iParentObjectID > 0)
                                {
                                    if (dbUtil.GetPropertyValue(objT, ItemTableForeignKey) != null)
                                        dbUtil.SetPropertyValue(objT, ItemTableForeignKey, iParentObjectID);
                                }
                                break;
                            }
                        case cstRelationParent:
                            {
                                break;
                            }
                        case cstRelationNone:
                            {
                                break;
                            }
                    }

                    //Create or update items
                    if (iItemObjectID > 0)
                    {
                        dbUtil.SetPropertyValue(objT, ERPModuleEntities.AAUpdatedUser, BOSApp.CurrentUser);
                        dbUtil.SetPropertyValue(objT, ERPModuleEntities.AAUpdatedDate, DateTime.Now);
                        objItemsController.UpdateObject(objT);
                    }
                    else
                    {
                        dbUtil.SetPropertyValue(objT, ERPModuleEntities.AACreatedUser, BOSApp.CurrentUser);
                        dbUtil.SetPropertyValue(objT, ERPModuleEntities.AACreatedDate, DateTime.Now);
                        objItemsController.CreateObject(objT);
                    }
                }

                //Delete items
                foreach (T obj in OriginalList)
                {
                    int iItemObjectID = (int)dbUtil.GetPropertyValue(obj, strItemTablePrimaryKey);
                    if (iItemObjectID > 0 && !this.Exists(strItemTablePrimaryKey, iItemObjectID))
                    {
                        objItemsController.DeleteObject(iItemObjectID);
                        Entity.DeleteObjectRelations(ItemTableName, iItemObjectID);
                    }
                }
                //Invalidate original list
                OriginalList.Clear();
                foreach (T obj in this)
                    OriginalList.Add((T)obj.Clone());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), CommonLocalizedResources.MessageBoxDefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public virtual void SaveItemObjects(bool bDeleteFirst)
        {
            if (bDeleteFirst)
            {
                DeleteAllItemObjects();
            }

            SaveItemObjects();
        }
        #endregion

        #region GridControl,GridView event handlers
        protected virtual void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!IsEndCurrentEdit)
            {
                if (this.Count > 0)
                {
                    if (CurrentIndex >= 0 && CurrentIndex < this.Count)
                    {
                        Entity.InvalidateModuleObject((T)this[CurrentIndex].Clone());
                    }
                }
            }
            IsEndCurrentEdit = false;

            if (CurrentIndex < 0)
            {
                IsInputingNewRow = true;
            }
            else
            {
                IsInputingNewRow = false;
            }
        }

        protected virtual void GridView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!IsInputingNewRow)
            {
                if (Entity.ModuleObjects[ItemTableName] != null)
                {
                    Entity.Module.SwitchToEditMode(Entity.ModuleObjects[ItemTableName], String.Empty);
                }
            }
        }
        #endregion

        /// <summary>
        /// Get position of object in list
        /// </summary>
        /// <param name="strPropertyName"></param>
        /// <param name="objPropertyValue"></param>
        /// <returns></returns>
        public virtual int PosOf(String strPropertyName, object objPropertyValue)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            for (int i = 0; i < this.Count; i++)
            {
                object objValue = dbUtil.GetPropertyValue((T)this[i], strPropertyName);
                if (objPropertyValue.Equals(objValue))
                    return i;
            }
            return -1;
        }

        public int GetParentObjectID()
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            int iParentObjectID = 0;
            if (!String.IsNullOrEmpty(ParentTableName))
            {
                String strMainTableName = String.Empty;
                if (Entity.MainObject != null)
                {
                    strMainTableName = BOSUtil.GetTableNameFromBusinessObject(Entity.MainObject);
                }
                string strParentTablePrimaryKey = dbUtil.GetTablePrimaryColumn(ParentTableName);
                if (ParentTableName == strMainTableName)
                {
                    iParentObjectID = dbUtil.GetPropertyIntValue(Entity.MainObject, strParentTablePrimaryKey);
                }
            }
            return iParentObjectID;
        }

        /// <summary>
        /// Duplicate list by setting all item primary key to zero
        /// </summary>
        public virtual void Duplicate()
        {
            OriginalList.Clear();
            BOSDbUtil dbUtil = new BOSDbUtil();
            String itemTablePrimaryColumn = dbUtil.GetTablePrimaryColumn(ItemTableName);
            foreach (T obj in this)
                dbUtil.SetPropertyValue(obj, itemTablePrimaryColumn, 0);
        }

        /// <summary>
        /// End current edit to update binding list
        /// </summary>
        public virtual void EndCurrentEdit()
        {
            if (GridView != null)
            {
                IsEndCurrentEdit = true;
                GridView.FocusedRowHandle = -1;
            }
        }

        /// <summary>
        /// Count the number of appearance of object by property name and value
        /// </summary>
        public virtual int GetFrequence(String strPropertyName, object objPropertyValue)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            int count = 0;
            for (int i = 0; i < this.Count; i++)
            {
                object objValue = dbUtil.GetPropertyValue((T)this[i], strPropertyName);
                if (objPropertyValue.Equals(objValue))
                    count++;
            }
            return count;
        }

        /// <summary>
        /// Clone a list
        /// </summary>
        /// <returns>Copied list from the current one</returns>
        public object Clone()
        {
            BOSList<T> result = new BOSList<T>();
            result.InitBOSList(Entity, ParentTableName, ItemTableName, Relation);
            result.ItemTableForeignKey = ItemTableForeignKey;
            foreach (T obj in this)
            {
                result.Add((T)obj.Clone());
            }
            foreach (T obj in OriginalList)
            {
                result.OriginalList.Add((T)obj.Clone());
            }
            foreach (T obj in BackupList)
            {
                result.BackupList.Add((T)obj.Clone());
            }
            return result;
        }
    }
}
