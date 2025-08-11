using System;
using System.Collections;
using System.Data;
using System.Reflection;
using BOSComponent;
using BOSLib;
using DevExpress.XtraTreeList;

namespace BOSERP
{
    public class BOSTreeList : BOSList<BOSTreeListObject>, TreeList.IVirtualTreeListData, IBOSTreeList
    {
        #region Variables

        protected BOSTreeListControl _treeListControl;

        #endregion

        public override BOSTreeListObject SaveObjectToList(bool IsNew)
        {
            if (TreeListControl != null)
                TreeListControl.InvalidateLookupEditColumns();

            var dbUtil = new BOSDbUtil();
            var strMainTableName = string.Empty;
            if (Entity.MainObject != null)
                strMainTableName = BOSUtil.GetTableNameFromBusinessObject(Entity.MainObject);

            var obj = new BOSTreeListObject();
            if (!string.IsNullOrEmpty(ParentTableName))
                if (ItemTableName.Equals(strMainTableName))
                    obj = (BOSTreeListObject) Entity.MainObject.Clone();
                else
                    obj = (BOSTreeListObject) Entity.ModuleObjects[ItemTableName].Clone();
            else
                obj = (BOSTreeListObject) Entity.ModuleObjects[ItemTableName].Clone();
            //Refer sub list to new list because Clone() does not copy it
            obj.SubList = new BOSTreeList();

            if (IsNew)
            {
                var strPrimaryKey = ItemTableName.Substring(0, ItemTableName.Length - 1) + "ID";
                dbUtil.SetPropertyValue(obj, strPrimaryKey, 0);
                CurrentObject.SubList.Add(obj);
            }
            else
            {
                var currObj = CurrentObject;
                var props = currObj.GetType().GetProperties();
                foreach (var prop in props)
                    if (typeof(BOSTreeListObject).GetProperty(prop.Name) == null)
                        dbUtil.SetPropertyValue(currObj, prop.Name, dbUtil.GetPropertyValue(obj, prop.Name));
            }
            return obj;
        }

        public override void AddObjectToList()
        {
            if (CurrentObject != null)
            {
                SaveObjectToList(true);
                TreeListControl.RefreshDataSource();
                TreeListControl.ExpandAll();
            }
        }

        public override void ChangeObjectFromList()
        {
            var currNode = TreeListControl.GetSelectedNode();
            if (currNode != null)
            {
                if (TreeListControl.BOSDisplayRoot && currNode.Level == 0)
                    return;
                SaveObjectToList(false);
                TreeListControl.RefreshDataSource();
                TreeListControl.ExpandAll();
            }
        }

        public override void RemoveSelectedRowObjectFromList()
        {
            var currentNode = TreeListControl.GetSelectedNode();
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

                //Switch module to edit mode before removing
                if (Entity.Module.IsEditable())
                    Entity.Module.ActionEdit();
            }
        }

        public override void SaveItemObjects()
        {
            EndCurrentEdit();

            base.SaveItemObjects();

            var dbUtil = new BOSDbUtil();
            foreach (var obj in this)
            {
                obj.SubList.InitBOSList(Entity, ItemTableName, ItemTableName);
                var parentTablePrimaryKey = dbUtil.GetTablePrimaryColumn(obj.SubList.ParentTableName);
                var parentObjectID = Convert.ToInt32(dbUtil.GetPropertyValue(obj, parentTablePrimaryKey));
                foreach (var objSub in obj.SubList)
                    dbUtil.SetPropertyValue(objSub, obj.SubList.ItemTableForeignKey, parentObjectID);
                if (obj.SubList.Count > 0 || obj.SubList.OriginalList.Count > 0)
                    obj.SubList.SaveItemObjects();
            }
        }

        public override void Duplicate()
        {
            base.Duplicate();

            foreach (var obj in this)
                if (obj.HasChildren())
                    obj.SubList.Duplicate();
        }

        public virtual void GetLastNodes(IBOSList<BOSTreeListObject> lst)
        {
            foreach (var obj in this)
                if (obj.HasChildren())
                    obj.SubList.GetLastNodes(lst);
                else
                    lst.Add(obj);
        }

        /// <summary>
        ///     Set a value to all items of tree list
        /// </summary>
        /// <param name="propertyName">Name of the property that need to be set</param>
        /// <param name="value">Value to be set</param>
        public virtual void SetValueToList(string propertyName, object value)
        {
            var dbUtil = new BOSDbUtil();
            foreach (var obj in this)
            {
                dbUtil.SetPropertyValue(obj, propertyName, value);
                if (obj.HasChildren())
                    obj.SubList.SetValueToList(propertyName, value);
            }
        }

        void TreeList.IVirtualTreeListData.VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {
            var obj = info.Node as BOSTreeListObject;
            info.Children = (BOSTreeList) obj.SubList;
        }

        void TreeList.IVirtualTreeListData.VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            var dbUtil = new BOSDbUtil();
            var obj = info.Node as BOSTreeListObject;
            info.CellData = dbUtil.GetPropertyValue(obj, info.Column.FieldName);
        }

        void TreeList.IVirtualTreeListData.VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
            var dbUtil = new BOSDbUtil();
            var obj = info.Node as BOSTreeListObject;
            dbUtil.SetPropertyValue(obj, info.Column.FieldName, info.NewCellData);
        }

        public virtual void InitBOSTreeListControl()
        {
            var strTreeListControlName = "fld_trl" + ItemTableName;
            InitBOSTreeListControl(strTreeListControlName);
        }

        public virtual void InitBOSTreeListControl(string strTreeListControlName)
        {
            if (Entity.Module.Controls[strTreeListControlName] != null)
                InitBOSTreeListControl((BOSTreeListControl) Entity.Module.Controls[strTreeListControlName]);
        }

        public virtual void InitBOSTreeListControl(BOSTreeListControl treeListControl)
        {
            TreeListControl = treeListControl;
            TreeListControl.FocusedNodeChanged += TreeList_FocusedNodeChanged;
            TreeListControl.CellValueChanging += TreeList_CellValueChanging;
        }

        public void SetDefaultListAndRefreshTreeListControl()
        {
            Clear();
            OriginalList.Clear();
            if (TreeListControl != null)
                TreeListControl.RefreshDataSource();
        }

        public virtual void EndCurrentEdit()
        {
            if (TreeListControl != null)
                TreeListControl.FocusedNode = null;
        }

        #region Public properties

        public BOSTreeListControl TreeListControl
        {
            get { return _treeListControl; }
            set { _treeListControl = value; }
        }

        public BOSTreeListObject CurrentObject
        {
            get
            {
                var currentNode = TreeListControl.GetSelectedNode();
                if (currentNode != null)
                    return (BOSTreeListObject) TreeListControl.GetDataRecordByNode(currentNode);
                return null;
            }
            set
            {
                var currentNode = TreeListControl.GetSelectedNode();
                if (currentNode != null)
                {
                    var currentObject = (BOSTreeListObject) TreeListControl.GetDataRecordByNode(currentNode);
                    currentObject = value;
                }
            }
        }

        public bool CheckAll { get; set; }

        #endregion

        #region Tree list event handlers

        protected virtual void TreeList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
                Entity.InvalidateModuleObject((BusinessObject) CurrentObject.Clone());
        }

        protected virtual void TreeList_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (Entity.ModuleObjects[ItemTableName] != null)
                Entity.Module.SwitchToEditMode(Entity.ModuleObjects[ItemTableName], string.Empty);
        }

        #endregion

        #region Invalidation functions

        public virtual void InvalidateTreeList(int iObjectID)
        {
            CheckAll = false;
            Invalidate(iObjectID);

            if (Entity != null)
                if (Count > 0)
                    Entity.InvalidateModuleObject(this[0]);
                else
                    Entity.InvalidateModuleObject(BusinessObjectFactory.GetBusinessObject(ItemTableName + "Info"));

            if (TreeListControl != null)
            {
                TreeListControl.RefreshDataSource();
                TreeListControl.ExpandAll();
            }
        }

        public virtual void InvalidateTreeList(int iObjectID, bool checkAll)
        {
            CheckAll = checkAll;
            Invalidate(iObjectID);

            if (Entity != null)
                if (Count > 0)
                    Entity.InvalidateModuleObject(this[0]);
                else
                    Entity.InvalidateModuleObject(BusinessObjectFactory.GetBusinessObject(ItemTableName + "Info"));

            if (TreeListControl != null)
            {
                TreeListControl.RefreshDataSource();
                TreeListControl.ExpandAll();
            }
        }

        public virtual void InvalidateTreeList(DataSet ds, bool expandAll, bool? extra)
        {
            CheckAll = false;
            Invalidate(ds);

            if (TreeListControl != null)
            {
                if (Count > 0)
                    Entity.InvalidateModuleObject(this[0]);
                else
                    Entity.InvalidateModuleObject(BusinessObjectFactory.GetBusinessObject(ItemTableName + "Info"));
                TreeListControl.RefreshDataSource();
                if (expandAll)
                    TreeListControl.ExpandAll();
            }
        }

        public override void Invalidate(int iObjectID)
        {
            base.Invalidate(iObjectID);
            InvalidateSubList();
        }

        public override void Invalidate(DataSet ds)
        {
            base.Invalidate(ds);
            InvalidateSubList();
        }

        public virtual void Invalidate(IList lst)
        {
            Clear();
            foreach (BOSTreeListObject obj in lst)
                Add((BOSTreeListObject) obj.Clone());

            //Invalidate original list same as itself
            OriginalList.Clear();
            foreach (var obj in this)
                OriginalList.Add((BOSTreeListObject) obj.Clone());

            //Invalidate backup list same as itself
            BackupList.Clear();
            foreach (var obj in this)
                BackupList.Add((BOSTreeListObject) obj.Clone());

            InvalidateSubList();
        }

        /// <summary>
        ///     Invalidate sub list of a tree list node
        /// </summary>
        private void InvalidateSubList()
        {
            var dbUtil = new BOSDbUtil();
            foreach (var obj in this)
            {
                if (CheckAll)
                    obj.Selected = true;

                //Make the type of sub list same as its parent
                var objType = GetType().InvokeMember("", BindingFlags.CreateInstance, null, null, null);
                obj.SubList = (BOSTreeList) objType;
                obj.SubList.InitBOSList(Entity, ItemTableName, ItemTableName);

                var parentTablePrimaryKey = dbUtil.GetTablePrimaryColumn(obj.SubList.ParentTableName);
                var parentObjectID = Convert.ToInt32(dbUtil.GetPropertyValue(obj, parentTablePrimaryKey));
                obj.SubList.CheckAll = CheckAll;
                obj.SubList.Invalidate(parentObjectID);
                foreach (var objSub in obj.SubList)
                    objSub.Parent = obj;
            }
        }

        #endregion

        #region Functions for getting object

        public virtual BOSTreeListObject GetSelectedObject()
        {
            foreach (var obj in this)
            {
                if (obj.Selected)
                    return obj;
                if (obj.HasChildren())
                {
                    var objSub = obj.SubList.GetSelectedObject();
                    if (objSub != null)
                        return objSub;
                }
            }
            return null;
        }

        public override bool Exists(string strPropertyName, object objPropertyValue)
        {
            var obj = GetObjectByPropertyNameAndValue(strPropertyName, objPropertyValue);
            if (obj != null)
                return true;
            return false;
        }

        public virtual BOSTreeListObject GetObjectByPropertyNameAndValue(string strPropertyName, object objPropertyValue)
        {
            var pos = PosOf(strPropertyName, objPropertyValue);
            if (pos >= 0)
                return this[pos];
            foreach (var obj in this)
                if (obj.SubList.Count > 0)
                {
                    var objSub = obj.SubList.GetObjectByPropertyNameAndValue(strPropertyName, objPropertyValue);
                    if (objSub != null)
                        return objSub;
                }
            return null;
        }

        public virtual BOSTreeListObject GetObjectByTemplateObject(BOSTreeListObject objTemplateObject,
            params string[] propertyNames)
        {
            var dbUtil = new BOSDbUtil();
            foreach (var obj in this)
            {
                var flag = false;
                foreach (var propertyName in propertyNames)
                    if (
                        !dbUtil.GetPropertyValue(obj, propertyName)
                            .Equals(dbUtil.GetPropertyValue(objTemplateObject, propertyName)))
                        flag = true;
                if (flag == false)
                    return obj;
            }

            foreach (var obj in this)
                if (obj.SubList.Count > 0)
                {
                    var objSub = obj.SubList.GetObjectByTemplateObject(objTemplateObject, propertyNames);
                    if (objSub != null)
                        return objSub;
                }
            return null;
        }

        #endregion
    }
}