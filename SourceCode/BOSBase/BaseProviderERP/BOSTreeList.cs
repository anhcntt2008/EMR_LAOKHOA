using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using BOSLib;
using BOSComponent;

namespace BOSERP
{
    public class BOSTreeList: BOSList<BOSTreeListObject>, DevExpress.XtraTreeList.TreeList.IVirtualTreeListData, IBOSTreeList
    {
        #region Variables
        protected BOSTreeListControl _treeListControl;
        #endregion

        #region Public properties
        public BOSTreeListControl TreeListControl
        {
            get
            {
                return _treeListControl;
            }
            set
            {
                _treeListControl = value;
            }
        }

        public BOSTreeListObject CurrentObject
        {
            get
            {
                DevExpress.XtraTreeList.Nodes.TreeListNode currentNode = TreeListControl.GetSelectedNode();
                if (currentNode != null)
                    return (BOSTreeListObject)TreeListControl.GetDataRecordByNode(currentNode);
                return null;
            }
            set
            {
                DevExpress.XtraTreeList.Nodes.TreeListNode currentNode = TreeListControl.GetSelectedNode();
                if (currentNode != null)
                {
                    BOSTreeListObject currentObject = (BOSTreeListObject)TreeListControl.GetDataRecordByNode(currentNode);
                    currentObject = value;
                }
            }
        }

        public bool CheckAll { get; set; }
        #endregion

        void DevExpress.XtraTreeList.TreeList.IVirtualTreeListData.VirtualTreeGetChildNodes(DevExpress.XtraTreeList.VirtualTreeGetChildNodesInfo info)
        {
            BOSTreeListObject obj = info.Node as BOSTreeListObject;
            info.Children = (BOSTreeList)obj.SubList;
        }

        void DevExpress.XtraTreeList.TreeList.IVirtualTreeListData.VirtualTreeGetCellValue(DevExpress.XtraTreeList.VirtualTreeGetCellValueInfo info)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            BOSTreeListObject obj = info.Node as BOSTreeListObject;
            info.CellData = dbUtil.GetPropertyValue(obj, info.Column.FieldName);
        }
        void DevExpress.XtraTreeList.TreeList.IVirtualTreeListData.VirtualTreeSetCellValue(DevExpress.XtraTreeList.VirtualTreeSetCellValueInfo info)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            BOSTreeListObject obj = info.Node as BOSTreeListObject;
            dbUtil.SetPropertyValue(obj, info.Column.FieldName, info.NewCellData);
        }

        public virtual void InitBOSTreeListControl()
        {
            String strTreeListControlName = "fld_trl" + ItemTableName;
            InitBOSTreeListControl(strTreeListControlName);
        }

        public virtual void InitBOSTreeListControl(String strTreeListControlName)
        {
            if (Entity.Module.Controls[strTreeListControlName] != null)
            {
                InitBOSTreeListControl((BOSTreeListControl)Entity.Module.Controls[strTreeListControlName]);
            }
        }

        public virtual void InitBOSTreeListControl(BOSTreeListControl treeListControl)
        {
            TreeListControl = treeListControl;
            TreeListControl.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(TreeList_FocusedNodeChanged);
            TreeListControl.CellValueChanging += new DevExpress.XtraTreeList.CellValueChangedEventHandler(TreeList_CellValueChanging);
        }

        public void SetDefaultListAndRefreshTreeListControl()
        {
            this.Clear();
            this.OriginalList.Clear();
            if (TreeListControl != null)
                TreeListControl.RefreshDataSource();
        }        

        #region Tree list event handlers
        protected virtual void TreeList_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                String strMainTableName = String.Empty;
                if (Entity.MainObject != null)
                    strMainTableName = BOSUtil.GetTableNameFromBusinessObject(Entity.MainObject);
                if (ItemTableName.Equals(strMainTableName))
                {
                    Entity.MainObject = (BusinessObject)CurrentObject.Clone();
                    Entity.UpdateMainObjectBindingSource();
                }
                else
                    Entity.InvalidateModuleObject((BusinessObject)CurrentObject.Clone());
            }
        }        

        protected virtual void TreeList_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (Entity.ModuleObjects[ItemTableName] != null)
                Entity.BusinessObject_PropertyChanged(Entity.ModuleObjects[ItemTableName], String.Empty);
        }
        #endregion

        #region Invalidation functions
        public virtual void InvalidateTreeList(int iObjectID)
        {
            CheckAll = false;
            this.Invalidate(iObjectID);

            if (TreeListControl != null)
            {
                if (this.Count > 0)
                    Entity.InvalidateModuleObject(this[0]);
                else
                    Entity.InvalidateModuleObject(BusinessObjectFactory.GetBusinessObject(ItemTableName + "Info"));
                TreeListControl.RefreshDataSource();
                TreeListControl.ExpandAll();
            }
        }

        public virtual void InvalidateTreeList(int iObjectID, bool checkAll)
        {
            CheckAll = checkAll;
            this.Invalidate(iObjectID);
            if (TreeListControl != null)
            {
                if (this.Count > 0)
                    Entity.InvalidateModuleObject(this[0]);
                else
                    Entity.InvalidateModuleObject(BusinessObjectFactory.GetBusinessObject(ItemTableName + "Info"));
                TreeListControl.RefreshDataSource();
                TreeListControl.ExpandAll();
            }
        }

        /// <summary>
        /// Invalidate tree list
        /// </summary>
        /// <param name="ds">List of root nodes</param>
        public virtual void InvalidateTreeList(DataSet ds)
        {
            InvalidateTreeList(ds, true);
        }

        /// <summary>
        /// Invalidate tree list
        /// </summary>
        /// <param name="ds">List of root nodes</param>
        /// <param name="expandAll">A value indicates whether the tree list control expands all its nodes</param>
        public virtual void InvalidateTreeList(DataSet ds, bool expandAll)
        {
            CheckAll = false;
            Invalidate(ds);

            if (TreeListControl != null)
            {
                if (this.Count > 0)
                    Entity.InvalidateModuleObject(this[0]);
                else
                    Entity.InvalidateModuleObject(BusinessObjectFactory.GetBusinessObject(ItemTableName + "Info"));
                TreeListControl.RefreshDataSource();
                if (expandAll)
                {
                    TreeListControl.ExpandAll();
                }
            }
        }

        public override void Invalidate(int iObjectID)
        {
            base.Invalidate(iObjectID);
            InvalidateSubList();
        }

        public override void Invalidate(System.Data.DataSet ds)
        {
            base.Invalidate(ds);
            InvalidateSubList();
        }

        /// <summary>
        /// Invalidate sub list of a tree list node
        /// </summary>
        private void InvalidateSubList()
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            foreach (BOSTreeListObject obj in this)
            {
                if (CheckAll)
                    obj.Selected = true;

                //Make the type of sub list same as its parent
                object objType = this.GetType().InvokeMember("", BindingFlags.CreateInstance, null, null, null);
                obj.SubList = (BOSTreeList)objType;
                obj.SubList.InitBOSList(Entity, ItemTableName, ItemTableName);

                String parentTablePrimaryKey = dbUtil.GetTablePrimaryColumn(obj.SubList.ParentTableName);
                int parentObjectID = Convert.ToInt32(dbUtil.GetPropertyValue(obj, parentTablePrimaryKey));
                obj.SubList.CheckAll = CheckAll;
                obj.SubList.Invalidate(parentObjectID);
                foreach (BOSTreeListObject objSub in obj.SubList)
                    objSub.Parent = obj;
            }   
        }
        #endregion 

        public override BOSTreeListObject SaveObjectToList(bool IsNew)
        {
            if (TreeListControl != null)
                TreeListControl.InvalidateLookupEditColumns();

            BOSDbUtil dbUtil = new BOSDbUtil();
            String strMainTableName = String.Empty;
            if (Entity.MainObject != null)
                strMainTableName = BOSUtil.GetTableNameFromBusinessObject(Entity.MainObject);

            BOSTreeListObject obj = new BOSTreeListObject();
            if (!String.IsNullOrEmpty(ParentTableName))
            {
                if (ItemTableName.Equals(strMainTableName))
                {
                    obj = (BOSTreeListObject)Entity.MainObject.Clone();
                }
                else
                {
                    obj = (BOSTreeListObject)Entity.ModuleObjects[ItemTableName].Clone();
                }
            }
            else
            {
                obj = (BOSTreeListObject)Entity.ModuleObjects[ItemTableName].Clone();
            }
            //Refer sub list to new list because Clone() does not copy it
            obj.SubList = new BOSTreeList();

            if (IsNew)
            {
                String strPrimaryKey = ItemTableName.Substring(0, ItemTableName.Length - 1) + "ID";
                dbUtil.SetPropertyValue(obj, strPrimaryKey, 0);
                CurrentObject.SubList.Add(obj);
            }
            else
            {
                BOSTreeListObject currObj = CurrentObject;
                PropertyInfo[] props = currObj.GetType().GetProperties();
                foreach (PropertyInfo prop in props)
                    if (typeof(BOSTreeListObject).GetProperty(prop.Name) == null)
                        dbUtil.SetPropertyValue(currObj, prop.Name, dbUtil.GetPropertyValue(obj, prop.Name));
            }
            return obj;
        }

        public override void AddObjectToList()
        {
            if (CurrentObject != null)
            {
                this.SaveObjectToList(true);
                TreeListControl.RefreshDataSource();
                TreeListControl.ExpandAll();
            }
        }

        public override void ChangeObjectFromList()
        {
            DevExpress.XtraTreeList.Nodes.TreeListNode currNode = TreeListControl.GetSelectedNode();
            if (currNode != null)
            {
                if (TreeListControl.BOSDisplayRoot && currNode.Level == 0)
                    return;
                this.SaveObjectToList(false);
                TreeListControl.RefreshDataSource();
                TreeListControl.ExpandAll();
            }
        }

        public override void RemoveSelectedRowObjectFromList()
        {
            DevExpress.XtraTreeList.Nodes.TreeListNode currentNode = TreeListControl.GetSelectedNode();
            if (currentNode != null)
            {
                if (TreeListControl.BOSDisplayRoot)
                {
                    if (currentNode.Level > 0)
                        currentNode.ParentNode.Nodes.Remove(currentNode);
                }
                else
                {
                    if (currentNode.Level == 0)
                        TreeListControl.Nodes.Remove(currentNode);
                    else
                        currentNode.ParentNode.Nodes.Remove(currentNode);
                }
            }
        }

        public override void SaveItemObjects()
        {
            EndCurrentEdit();

            base.SaveItemObjects();

            BOSDbUtil dbUtil = new BOSDbUtil();
            foreach (BOSTreeListObject obj in this)
            {
                obj.SubList.InitBOSList(Entity, ItemTableName, ItemTableName);
                String parentTablePrimaryKey = dbUtil.GetTablePrimaryColumn(obj.SubList.ParentTableName);
                int parentObjectID = Convert.ToInt32(dbUtil.GetPropertyValue(obj, parentTablePrimaryKey));
                foreach (BOSTreeListObject objSub in obj.SubList)
                {
                    dbUtil.SetPropertyValue(objSub, obj.SubList.ItemTableForeignKey, parentObjectID);
                }
                if (obj.SubList.Count > 0 || obj.SubList.OriginalList.Count > 0)
                    obj.SubList.SaveItemObjects();
            }
        }

        #region Functions for getting object
        public virtual BOSTreeListObject GetSelectedObject()
        {
            foreach (BOSTreeListObject obj in this)
            {
                if (obj.Selected)
                    return obj;
                if (obj.HasChildren())
                {
                    BOSTreeListObject objSub = obj.SubList.GetSelectedObject();
                    if (objSub != null)
                        return objSub;
                }
            }
            return null;
        }

        public override bool Exists(string strPropertyName, object objPropertyValue)
        {
            BOSTreeListObject obj = GetObjectByPropertyNameAndValue(strPropertyName, objPropertyValue);
            if (obj != null)
                return true;
            return false;
        }

        public virtual BOSTreeListObject GetObjectByPropertyNameAndValue(string strPropertyName, object objPropertyValue)
        {
            int pos = base.PosOf(strPropertyName, objPropertyValue);
            if (pos >= 0)
            {
                return this[pos];
            }
            else
            {
                foreach (BOSTreeListObject obj in this)
                {
                    if (obj.HasChildren())
                    {
                        BOSTreeListObject objSub = obj.SubList.GetObjectByPropertyNameAndValue(strPropertyName, objPropertyValue);
                        if (objSub != null)
                            return objSub;
                    }
                }
            }
            return null;
        }

        public virtual BOSTreeListObject GetObjectByTemplateObject(BOSTreeListObject objTemplateObject, params String[] propertyNames)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            foreach (BOSTreeListObject obj in this)
            {
                bool flag = false;
                foreach (String propertyName in propertyNames)
                    if (!dbUtil.GetPropertyValue(obj, propertyName).Equals(dbUtil.GetPropertyValue(objTemplateObject, propertyName)))
                        flag = true;
                if (flag == false)
                    return obj;
            }

            foreach (BOSTreeListObject obj in this)
            {
                if (obj.HasChildren())
                {
                    BOSTreeListObject objSub = obj.SubList.GetObjectByTemplateObject(objTemplateObject, propertyNames);
                    if (objSub != null)
                        return objSub;
                }
            }
            return null;
        }
        #endregion

        public override void Duplicate()
        {
            base.Duplicate();

            foreach (BOSTreeListObject obj in this)
                if (obj.HasChildren())
                    obj.SubList.Duplicate();
        }

        public virtual void GetLastNodes(IBOSList<BOSTreeListObject> lst)
        {
            foreach (BOSTreeListObject obj in this)
            {
                if (obj.HasChildren())
                    obj.SubList.GetLastNodes(lst);
                else
                    lst.Add(obj);
            }
        }

        public virtual void EndCurrentEdit()
        {
            if (TreeListControl != null)
                TreeListControl.FocusedNode = null;
        }

        /// <summary>
        /// Set a value to all items of tree list
        /// </summary>
        /// <param name="propertyName">Name of the property that need to be set</param>
        /// <param name="value">Value to be set</param>
        public virtual void SetValueToList(string propertyName, object value)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            foreach (BOSTreeListObject obj in this)
            {
                dbUtil.SetPropertyValue(obj, propertyName, value);
                if (obj.HasChildren())
                {
                    obj.SubList.SetValueToList(propertyName, value);
                }
            }
        }
    }   
}
